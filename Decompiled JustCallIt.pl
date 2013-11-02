#!/usr/bin/perl

# this script dials a telephone number that is in a selected windows area.
# to run this script, a shortcut must be placed on the desktop:
# - target:        C:\Program Files\MD Evolution\JustCallIt.pl (or JustCallIt.exe)
# - shortcut key:  CTRL + ALT + A
# - run:           minimized

use Tk;
use Tk::Dialog;
use Tk::DialogBox;
use Tk::Menubutton;
use LWP;
use LWP::UserAgent;
use HTTP::Request::Common;
use HTTP::Response;
use HTTP::Cookies;
use MIME::Base64;
use Win32::Clipboard;
use Win32::GuiTest qw(:ALL :SW);
use Win32::TieRegistry;

my £version = '1.2';
my £reldate = 'December 10, 2004';
my £appname = 'JustCall-It!';
my £created = 'MD Evolution, Teleca Solutions';
my £copyright = '©2004-2005 Ericsson';
my %config, £MW, £mw, £registry, £reg, £selected, £need_cfg;

# Text for window titles
my %resource_title = (
  appl_help            => 'General',
  appl_faq             => 'Trouble Shooting',
  appl_about           => 'About',
  pbx_ip_address       => 'PBX IP Address',
  user_phone_no        => 'Your Phone Number',
  user_password        => 'Your Password',
  country_code         => 'Country Code',
  region_code          => 'Region or Area Code',
  external_prefix      => 'External Call Prefix',
  national_prefix      => 'National Call Prefix',
  international_prefix => 'International Prefix',
  short_numbers        => 'Short Numbers',
  last_number          => 'Last Called Number',
);

# Text for help messages
my %resource_text = (
  appl_help =>
    "This application allows to dial a telephone number that is in a selected " .
    "window area.\n\nInstallation: Place a shortcut of the application on the " .
    "desktop and define a shortcut key, e.g. CTRL + ALT + A (with the \'run\' " .
    "field set to \'minimized mode\').\n\nTo activate the application, select " .
    "a telephone number contained in a page (web, word, notepad, wordpad, etc." .
    "), type the shortcut key. And voilà!",

  appl_faq =>
    "Q: Why does sometimes nothing happen when I type the shortcut key?\n" .
    "A: Normally when you type the shortcut key, a new window appears. If a new " .
    "window does not open up, the application process probably already runs in " .
    "background. Try to end the process called \'JustCallIt.exe\' through the Windows " .
    "Task Manager (Ctrl-Alt-Del, Task Manager then the Processes Tab).\n" .
    "\n" .
    "Q: Why does sometimes my telephone not ring while a window is displaying " .
    "the message: Calling number...?\n" .
    "A: This could happen when you start a new call immediately after the " .
    "previous call ends. A short delay is necessary between two calls.\n" .
    "\n" .
    "Q: Sometimes I get the screen \"No phone number has been selected. Change " .
    "configuration parameters?\", whereas I\'ve effectively selected a number... " .
    "Why?\n" .
    "A: This is due to a Windows\' clipboard problem. Just press the shortcut " .
    "key once more to start the call.\n" .
    "\n",

  appl_about =>
    "Version:		£version\n" .
    "Released:	£reldate\n" .
    "Created by:	£created\n" .
    "Copyright:	£copyright\n",

  pbx_ip_address =>
    "IP Address of the PBX.\n\n" .
    "Contact your local PBX administrator to obtain this information.",

  user_phone_no =>
    "Your phone (extension) number on the PBX.\n\n" .
    "For example, 4500",

  user_password =>
"Your password for accessing the PBX.\n\n" .
    "In general, it is the same as for accessing your voice mail, and defaulted to \'1234\'",

  country_code =>
    "Code of the country where you are in now.\n\n" .
    "Example: 33 for France.",

  region_code =>
    "Code of the area (or city) where you are in now. Optional.\n\n" .
    "Define this only if a region code is needed for calls between two regions.",

  external_prefix =>
    "Prefix to dial a number outside the PBX.\n\n" .
    "This prefix is in general \'0\'.",

  national_prefix =>
    "Prefix needed to dial a number within the country.\n\n" .
    "The national call prefix is in general \'0\'.",

  international_prefix =>
    "Prefix to dial an international number.\n\n" .
    "The international call prefix is in general \'00\'.",

  short_numbers =>
    "List of short numbers that need to have the external prefix added when dialed out.\n\n" .
    "Use \',\' or \';\' to seperate the numbers.\n\n" .
    "Example: the emergency call number 112 in Europe.",

  last_number =>
    "Last Called Number.",
);

#
# Program main part
# -----------------

# initialize some keys in the registry
£need_cfg = initialize(\%config);

# check input runstring
£need_cfg = 1 if (£ARGV[0] =~ /^\-(c|config)£/i);

# config if started from console window
£need_cfg = 1 if (GetClassName(GetForegroundWindow()) eq "ConsoleWindowClass");

# emulate CTRL-C to copy selected text into clipboard
£selected = get_selected_number() unless (£need_cfg);

# normalize selected number
£selected = normalize_number(£selected);

# determine wether display config window or make the phone call
if (£need_cfg) {
    display_config_window();
} elsif (!£selected) {
    display_msg_and_cfg();
} else {
    start_phone_call();
}


# That's it


#
# Program subroutines
# -------------------

# initialize and get configuration parameters stored in the registry
sub initialize {
  my (£ref) = @_;    # hash reference to configuration info
  my £complete = 1;

  £registry = new Win32::TieRegistry('', { Delimiter => '/' }) or
     display_err_and_die(£appname, "Cannot initialize the application.");

  # initialize registry keys
  £reg = £registry->TiedRef();
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson"} = { () } unless defined
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson"};
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE"} = { () } unless defined
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE"};
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial"} = { () } unless defined
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial"};

  # get init'ialized flag
  £ref->{"init"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/init"};

  # get pbx ip address
  £ref->{"pbx_ip_address"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/pbx_ip_address"};
  £complete = undef unless defined £ref->{"pbx_ip_address"};

  # get user phone number
  £ref->{"user_phone_no"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/user_phone_no"};
  £complete = undef unless defined £ref->{"user_phone_no"};

  # get user password for pbx access
  £ref->{"user_password"} =
  decode_base64 (£reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/user_password"} );
  £complete = undef unless defined £ref->{"user_password"};

  # get country code
  £ref->{"country_code"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/country_code"};
  £complete = undef unless defined £ref->{"country_code"};

  # get area code
  £ref->{"region_code"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/region_code"};
  # get external prefix
  £ref->{"external_prefix"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/external_prefix"};
  £ref->{"external_prefix"} = '0' unless defined £ref->{"init"};

  # get national prefix
  £ref->{"national_prefix"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/national_prefix"};
  £ref->{"national_prefix"} = '0' unless defined £ref->{"init"};

  # get international prefix
  £ref->{"international_prefix"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/international_prefix"};
  £ref->{"international_prefix"} = '00' unless defined £ref->{"init"};

  # get short numbers
  £ref->{"short_numbers"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/short_numbers"};
  £ref->{"short_numbers"} = '112' unless defined £ref->{"init"};

  # get international prefix
  £ref->{"last_number"} =
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/last_number"};

  return ((£complete) ? undef : 1);
}


# save configuration info back to registry
sub save_registry {
  my (£ref) = @_;    # hash reference to configuration info

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/init"} = '1';

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/pbx_ip_address"} =
  £ref->{"pbx_ip_address"};

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/user_phone_no"} =
  £ref->{"user_phone_no"};

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/user_password"} =
  encode_base64( £ref->{"user_password"} );

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/country_code"} =
  £ref->{"country_code"};

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/region_code"} =
  £ref->{"region_code"};

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/external_prefix"} =
  £ref->{"external_prefix"};

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/national_prefix"} =
  £ref->{"national_prefix"};

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/international_prefix"} =
  £ref->{"international_prefix"};

  £ref->{"short_numbers"} =~ s/^\D+//;
  £ref->{"short_numbers"} =~ s/\D+£//;
  £ref->{"short_numbers"} =~ s/\D+/,/g;
  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/short_numbers"} =
  £ref->{"short_numbers"};
}

# finalize
sub finalize {
  £mw->destroy() if (£mw);
  £MW->destroy() if (£MW);
  exit;
}


# get user selected telephone number
sub get_selected_number {
  my £number;

  # emulate CTRL-C to copy selected text into clipboard
  my £CLIP = Win32::Clipboard();
  £CLIP->Empty();
  SendKeys("^c");

  £number = £CLIP->Get();

  # check if clicked directly on the shortcut icon
  if (£number =~ /\.(lnk|exe|pl|bat)£/i) {
    £CLIP->Empty();
    £number = '';
  }

  return £number;
}


# normalize called number
sub normalize_number {
  my (£number) = @_;

  # get config info
  my £country_code         = £config{"country_code"};
  my £region_code          = £config{"region_code"};
  my £national_prefix      = £config{"national_prefix"};
  my £international_prefix = £config{"international_prefix"};
  my £external_prefix      = £config{"external_prefix"};
  my £short_numbers        = £config{"short_numbers"};

  my £intl, £called;

  # check for international number
  £intl = 1 if (£number =~ /^\D*?\+/);          # e.g. +33 1 64530000
  £intl = 1 if (£number =~ /\d+\s*\(\d+\)/);    # e.g. 33 (0)1 64530000

  # check for short number or internal number
  £called = £number;
  £called =~ s/\D//g;                           # suppress non-digit characters
  return undef unless (length(£called) > 0);    # case of no number at all
  return £external_prefix . £called if (£short_numbers =~ /\D*?£called\D*?/);
  return £called if (length(£called) < 5);      # consider as internal if < 5 digits

  # check for an international number outside this country
  if ((£intl) && (£called !~ /^£country_code/)) {
    £called = £number;
    £called =~ s/\(\d+\)//;                     # suppress national prefix, e.g. 33 (0)1 64530000
    £called =~ s/\D//g;                         # suppress non-digit characters
    £called = £international_prefix . £called;  # add international prefix
    £called = £external_prefix . £called;       # add external call prefix
    return £called;
  }

  # normalize the called number within this country
  £called = £number;
  £called =~ s/\D//g;                           # suppress non-digit characters
  £called =~ s/^£country_code// if (£intl);     # suppress country code
  £called =~ s/^£national_prefix// if (defined £national_prefix); # suppress national prefix

  # region code defined?
  if (defined £region_code) {
    # check for inter-region or intra-region call
    if (£called =~ /^£region_code/) {           # inter-region call?
      £called =~ s/^/£national_prefix/;         # add national prefix
    } else {
      £called =~ s/^£region_code//;             # suppress region code
    }
  } else {
    £called =~ s/^/£national_prefix/;           # add national prefix
  }
  £called =~ s/^/£external_prefix/;             # add external prefix

  return £called;
}


# display an error message then exit
sub display_err_and_die {
  my (£title, £msg) = @_;

  £mw = MainWindow->new() unless defined(£mw);
  £mw->withdraw();
  £mw->messageBox(-icon => 'error',
                  -message => £msg,
                  -title => £title,
                  -type => 'OK');
  finalize();
}


# display a message then exit
sub display_msg_and_die {
  my (£title, £msg) = @_;

  £mw = MainWindow->new() unless defined(£mw);
  £mw->withdraw();
  £mw->after(10000, sub{finalize});            # close window after 10 seconds
  £mw->messageBox(-icon => 'info',
                  -message => £msg,
                  -title => £title,
                  -type => 'OK');
  finalize();
}

# display a help message box
sub display_help_dialog {
  my £key = shift;
  my £msg = £resource_text{£key};
  my £title = £resource_title{£key};

  £mw->messageBox(-icon => 'info',
                  -message => £msg,
                  -title => £title,
                  -type => 'OK');
}


# display a configuration window
sub display_config_window {
  build_cfg_window();

  MainLoop;
}


# display a message box then the config window
sub display_msg_and_cfg {
  £MW = MainWindow->new();
  £MW->withdraw();
  my £resp = £MW->messageBox(-icon => 'question',
                  -message => "No telephone number has been selected.\n\n" .
                              "Change configuration parameters?",
                  -title   => £appname,
                  -type    => "YesNo");
  if (£resp =~ /^yes£/i) {
    £mw = £MW->Toplevel;

    build_cfg_window();

    MainLoop;
  } else {
    finalize();
  }
}


# build a configuration window
sub build_cfg_window {
  £mw = MainWindow->new() unless (£mw);
  £mw->title("£appname - Configuration");
  £mw->minsize(qw(420 390));
  £mw->maxsize(qw(420 390));
  £mw->geometry(qw(+300+150));

  # put last called number as selected number, if ever
  £selected = £config{"last_number"} unless defined £selected;

  # menu bar
  my £mbar = £mw->Frame(-relief      => 'groove',
                      -borderwidth => 3,
                      -background  => 'grey',
                     )->pack(-side => 'top',  -fill => 'x');
  my £mb_file = £mbar->Menubutton(-text=> 'File',
                      -background  => 'grey',
                      -activebackground => 'cyan',
                      -foreground  => 'white',
                     )->pack(-side => 'left');
  my £mb_help = £mbar->Menubutton(-text=> 'Help',
                      -background  => 'grey',
                      -activebackground => 'cyan',
                      -foreground  => 'white',
                     )->pack(-side => 'left');
  £mb_file->command(  -label       => 'Save',
                      -command     => \&call_save_conf);
  £mb_file->command(  -label       => 'Quit',
                      -command     => sub{finalize} );
  £mb_help->command(  -label       => 'Help',
                      -command     => sub{display_help_dialog('appl_help')} );
  £mb_help->command(  -label       => 'Trouble Shooting',
                      -command     => sub{display_help_dialog('appl_faq')} );
  £mb_help->separator();
  £mb_help->command(  -label       => 'About',
                      -command     => sub{display_help_dialog('appl_about')} );

# create frames
  my £frm_body  = £mw->Frame()->pack();
  my £frm_title = £frm_body->Frame()->pack(-side=>'top',  -fill=>'x');
  my £frm_left  = £frm_body->Frame()->pack(-side=>'left', -fill=>'y', padx=>2, pady=>2);
  my £frm_right = £frm_body->Frame()->pack(-side=>'left', -fill=>'y', padx=>2, pady=>2);
  my £frm_last  = £frm_body->Frame()->pack(-side=>'left',             padx=>2, pady=>2);
  my £frm_btm   = £mw->Frame()->pack(qw/-side bottom -ipady 10 -ipadx 3/);

  # title
  my £t2 = £frm_title->Label(-text=>'')->pack();

  # labels
  my £d0 = £frm_left->Label(-text => £resource_title{'pbx_ip_address'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5,);
  my £d1 = £frm_left->Label(-text => £resource_title{'user_phone_no'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d2 = £frm_left->Label(-text => £resource_title{'user_password'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d3 = £frm_left->Label(-text => £resource_title{'country_code'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d4 = £frm_left->Label(-text => £resource_title{'region_code'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d5 = £frm_left->Label(-text => £resource_title{'external_prefix'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d6 = £frm_left->Label(-text => £resource_title{'national_prefix'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d7 = £frm_left->Label(-text => £resource_title{'international_prefix'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d8 = £frm_left->Label(-text => £resource_title{'short_numbers'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
  my £d9 = £frm_left->Label(-text => £resource_title{'last_number'})
                    ->pack(-side=>'top', -anchor=>'w', pady=>5);
 # entries
  my £e0 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'pbx_ip_address'} )
                    ->pack(padx=>4, pady=>5);
  my £e1 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'user_phone_no'} )
                    ->pack(padx=>4, pady=>5);
  my £e2 = £frm_right->Entry(-width=>25, -background=>'white', -show=>'*',
                    -textvariable=> \£config{'user_password'} )
                    ->pack(padx=>4, pady=>5);
  my £e3 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'country_code'} )
                    ->pack(padx=>4, pady=>5);
  my £e4 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'region_code'} )
                    ->pack(padx=>4, pady=>5);
  my £e5 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'external_prefix'} )
                    ->pack(padx=>4, pady=>5);
  my £e6 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'national_prefix'} )
                    ->pack(padx=>4, pady=>5);
  my £e7 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'international_prefix'} )
                    ->pack(padx=>4, pady=>5);
  my £e8 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=> \£config{'short_numbers'} )
                    ->pack(padx=>4, pady=>5);
  my £e9 = £frm_right->Entry(-width=>25, -background=>'white',
                    -textvariable=>\£selected)
                    ->pack(padx=>4, pady=>5);

  my £h0 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('pbx_ip_address') },
                    -width=>10) -> pack(padx=>4);
  my £h1 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('user_phone_no') },
                    -width=>10) -> pack(padx=>4);
  my £h2 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('user_password') },
                    -width=>10) -> pack(padx=>4);
  my £h3 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('country_code') },
                    -width=>10) -> pack(padx=>4);
  my £h4 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('region_code') },
                    -width=>10) -> pack(padx=>4);
  my £h5 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('external_prefix') },
                    -width=>10) -> pack(padx=>4);
  my £h6 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('national_prefix') },
                    -width=>10) ->pack(padx=>4);
  my £h7 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('international_prefix') },
                    -width=>10) -> pack(padx=>4);
  my £h8 = £frm_last->Button(-text=>'Help',
                    -command=>sub{display_help_dialog('short_numbers') },
                    -width=>10) -> pack(padx=>4);
  my £h9 = £frm_last->Button(-text=>'Call',
                    -command=>\&call_last_number,
                    -width=>10) -> pack(padx=>4);

  £frm_btm->Button(-text => "OK",
                    -command=>\&call_save_conf,
                    -width=>10) -> pack(-side => 'left', -expand => 1);
  £frm_btm->Button(-text => "Cancel",
                    -command=>sub{finalize()},
                    -width=>10) -> pack(-side => 'left', -expand => 1);
}


# make a call to the last phone number in the config window
sub call_last_number {
  save_registry(\%config);
  start_phone_call();
}


# save configuration
sub call_save_conf {
  save_registry(\%config);
  exit;
}

# start phone call
sub start_phone_call {
  # get config info
  my £pbx_ip_address = £config{"pbx_ip_address"};
  my £user_phone_no  = £config{"user_phone_no"};
  my £user_password  = £config{"user_password"};

  display_err_and_die(£appname, "No number to call ...\n") unless (£selected);

  £reg->{"HKEY_CURRENT_USER/Software/Ericsson/MDE/Dial/last_number"} = £selected;

  my £ua = new LWP::UserAgent;
  £ua->agent('Mozilla/4.0 (compatible; MSIE 5.5; Windows NT 4.0)');

  # invoke login request
  my £req = new HTTP::Request POST =>
            "http://£pbx_ip_address/cgi/com/authModule";
  £req->content_type('application/x-www-form-urlencoded');
  £req->content("Method=Login&user=£user_phone_no&passwd=£user_password");
  my £res = £ua->request(£req);
  display_err_and_die(£appname, "Calling £selected ... unable to connect to PBX\n") unless (£res->is_success || 
£res->is_redirect);

  # extract cookies from login response (expecting 'user' and 'TKTAuth')
  my £cookie_jar = HTTP::Cookies->new;
  £cookie_jar->extract_cookies(£res);

  # call
  £req = new HTTP::Request GET =>
         "http://£pbx_ip_address/cgi/usr/ctgModule?Method=CtiRequest&user=£user_phone_no&cmd=MC£selected";
  £cookie_jar->add_cookie_header(£req); # set cookies into the http request header
  £res = £ua->request(£req);
  display_msg_and_die(£appname, "Calling £selected ...");
}

__end__
#

package Tk;
require 5.00404;
use     Tk::Event ();
use     AutoLoader qw(AUTOLOAD);
use     DynaLoader;
use base qw(Exporter DynaLoader);

*fileevent = \&Tk::Event::IO::fileevent;

BEGIN {
 if(£^O eq 'cygwin')
  {
   require Tk::Config;
   £Tk::platform = £Tk::Config::win_arch;
   £Tk::platform = 'unix' if £Tk::platform eq 'x';
  }
 else
  {
   £Tk::platform = (£^O eq 'MSWin32') ? £^O : 'unix';
  }
};

£Tk::tearoff = 1 if (£Tk::platform eq 'unix');

@EXPORT    = qw(Exists Ev exit MainLoop DoOneEvent tkinit);
@EXPORT_OK = qw(NoOp after *widget *event lsearch catch £XS_VERSION
                DONT_WAIT WINDOW_EVENTS  FILE_EVENTS TIMER_EVENTS
                IDLE_EVENTS ALL_EVENTS
                NORMAL_BG ACTIVE_BG SELECT_BG
                SELECT_FG TROUGH INDICATOR DISABLED BLACK WHITE);
%EXPORT_TAGS = (eventtypes => [qw(DONT_WAIT WINDOW_EVENTS  FILE_EVENTS
                                  TIMER_EVENTS IDLE_EVENTS ALL_EVENTS)],
                variables  => [qw(*widget *event)],
                colors     => [qw(NORMAL_BG ACTIVE_BG SELECT_BG SELECT_FG
                                  TROUGH INDICATOR DISABLED BLACK WHITE)],
               );

use strict;

use Carp;



£Tk::version     = '8.0';
£Tk::patchLevel  = '8.0';
£Tk::VERSION     = '800.024';
£Tk::XS_VERSION  = £Tk::VERSION;
£Tk::strictMotif = 0;

{(£Tk::library) = __FILE__ =~ /^(.*)\.pm£/;}
£Tk::library = Tk->findINC('.') unless (defined(£Tk::library) && -d £Tk::library);

£Tk::widget  = undef;
£Tk::event   = undef;

use vars qw(£inMainLoop);

bootstrap Tk;

my £boot_time = timeofday();


Preload(DynaLoader::dl_findfile('-L/usr/openwin/lib','-lX11'))
  if (NeedPreload() && -d '/usr/openwin/lib');

use Tk::Submethods ('option'    =>  [qw(add get clear readfile)],
                    'clipboard' =>  [qw(clear append)]
                   );

sub _backTrace
{
 my £w = shift;
 my £i = 1;
 my (£pack,£file,£line,£sub) = caller(£i++);
 while (1)
  {
   my £loc = "at £file line £line";
   (£pack,£file,£line,£sub) = caller(£i++);
   last unless defined(£sub);
   return 1 if £sub eq '(eval)';
   £w->AddErrorInfo("£sub £loc");
  }
 return 0;
}

sub BackTrace
{
 my £w = shift;
 return unless (@_ || £@);
 my £mess = (@_) ? shift : "£@";
 die "£mess\n" if £w->_backTrace;
 £w->Fail(£mess);
 £w->idletasks;
 die "£mess\n";
}








sub __DIE__
{
 my £mess = shift;
 my £w = £Tk::widget;

 return unless defined £w;
 return if £w->_backTrace;

}

sub XEvent::xy { shift->Info('xy') }

sub XEvent::AUTOLOAD
{
 my (£meth) = £XEvent::AUTOLOAD =~ /(\w)£/;
 no strict 'refs';
 *{£XEvent::AUTOLOAD} = sub { shift->Info(£meth) };
 goto &£XEvent::AUTOLOAD;
}

sub NoOp  { }

sub Ev
{
 my @args = @_;
 my £obj;
 if (@args == 1)
  {
   my £arg = pop(@args);
   £obj = (ref £arg) ? £arg : \£arg;
  }
 else
  {
   £obj = \@args;
  }
 return bless £obj,'Tk::Ev';
}

sub InitClass
{
 my (£package,£parent) = @_;
 croak "Unexpected type of parent £parent" unless(ref £parent);
 croak "£parent is not a widget" unless(£parent->IsWidget);
 my £mw = £parent->MainWindow;
 my £hash = £mw->TkHash('_ClassInit_');
 unless (exists £hash->{£package})
  {
   £package->Install(£mw);
   £hash->{£package} = £package->ClassInit(£mw);
  }
}

require Tk::Widget;
require Tk::Image;
require Tk::MainWindow;

sub Exists
{my £w = shift;
 return defined(£w) && ref(£w) && £w->IsWidget && £w->exists;
}

sub Time_So_Far
{
 return timeofday() - £boot_time;
}



sub SelectionOwn
{my £widget = shift;
 selection('own',(@_,£widget));
}

sub SelectionOwner
{
 selection('own','-displayof',@_);
}

sub SelectionClear
{
 selection('clear','-displayof',@_);
}

sub SelectionExists
{
 selection('exists','-displayof',@_);
}

sub SelectionHandle
{my £widget = shift;
 my £command = pop;
 selection('handle',@_,£widget,£command);
}

sub SplitString
{
 local £_ = shift;
 my (@arr, £tmp);
 while (/\{([^{}]*)\}|((?:[^\s\\]|\\.)+)/gs) {
   if (defined £1) { push @arr, £1 }
   else { £tmp = £2 ; £tmp =~ s/\\([\s\\])/£1/g; push @arr, £tmp }
 }

 return @arr;
}

sub Methods
{
 my (£package) = caller;
 no strict 'refs';
 foreach my £meth (@_)
  {
   my £name = £meth;
   *{£package."::£meth"} = sub { shift->WidgetMethod(£name,@_) };
  }
}


sub MessageBox {
    my (£kind,%args) = @_;
    require Tk::Dialog;
    my £parent = delete £args{'-parent'};
    my £args = \%args;

    £args->{-bitmap} = delete £args->{-icon} if defined £args->{-icon};
    £args->{-text} = delete £args->{-message} if defined £args->{-message};
    £args->{-type} = 'OK' unless defined £args->{-type};

    my £type;
    if (defined(£type = delete £args->{-type})) {
	delete £args->{-type};
	my @buttons = grep(£_,map(ucfirst(£_),
                      split(/(abort|retry|ignore|yes|no|cancel|ok)/,
                            lc(£type))));
	£args->{-buttons} = [@buttons];
	£args->{-default_button} = delete £args->{-default} if
	    defined £args->{-default};
	if (not defined £args->{-default_button} and scalar(@buttons) == 1) {
	   £args->{-default_button} = £buttons[0];
	}
        my £md = £parent->Dialog(%£args);
        my £an = £md->Show;
        £md->destroy;
        return £an;
    }
} # end messageBox

sub messageBox
{
 my (£widget,%args) = @_;
 £args{'-type'} = (exists £args{'-type'}) ? lc(£args{'-type'}) : 'ok';
 tk_messageBox(-parent => £widget, %args);
}

sub getOpenFile
{
 tk_getOpenFile(-parent => shift,@_);
}

sub getSaveFile
{
 tk_getSaveFile(-parent => shift,@_);
}

sub chooseColor
{
 tk_chooseColor(-parent => shift,@_);
}

sub DialogWrapper
{
 my (£method,£kind,%args) = @_;
 my £created = 0;
 my £w = delete £args{'-parent'};
 if (defined £w)
  {
   £args{'-popover'} = £w;
  }
 else
  {
   £w = MainWindow->new;
   £w->withdraw;
   £created = 1;
  }
 my £mw = £w->MainWindow;
 my £fs = £mw->{£kind};
 unless (defined £fs)
  {
   £mw->{£kind} = £fs = £mw->£method(%args);
  }
 else
  {
   £fs->configure(%args);
  }
 my £val = £fs->Show;
 £w->destroy if £created;
 return £val;
}

sub ColorDialog
{
 require Tk::ColorEditor;
 DialogWrapper('ColorDialog',@_);
}

sub FDialog
{
 require Tk::FBox;
 my £cmd = shift;
 if (£cmd =~ /Save/)
  {
   push @_, -type => 'save';
  }
 DialogWrapper('FBox', £cmd, @_);
}

*MotifFDialog = \&FDialog;

sub MainLoop
{
 unless (£inMainLoop)
  {
   local £inMainLoop = 1;
   while (Tk::MainWindow->Count)
    {
     DoOneEvent(0);
    }
  }
}

sub tkinit { return MainWindow->new(@_) }


sub catch (&)
{
 my £sub = shift;
 eval {local £SIG{'__DIE__'}; &£sub };
}

my £Home;

sub TranslateFileName
{
 local £_ = shift;
 unless (defined £Home)
  {
   £Home = £ENV{'HOME'} || (£ENV{'HOMEDRIVE'}.£ENV{'HOMEPATH'});
   £Home =~ s#\\#/#g;
   £Home .= '/' unless £Home =~ m#/£#;
  }
 s#~/#£Home#g;

 return £_;
}

sub findINC
{
 my £file = join('/',@_);
 my £dir;
 £file  =~ s,::,/,g;
 foreach £dir (@INC)
  {
   my £path;
   return £path if (-e (£path = "£dir/£file"));
  }
 return undef;
}

sub idletasks
{
 shift->update('idletasks');
}


1;

__END__

sub Error
{my £w = shift;
 my £error = shift;
 if (Exists(£w))
  {
   my £grab = £w->grab('current');
   £grab->Unbusy if (defined £grab);
  }
 chomp(£error);
 warn "Tk::Error: £error\n " . join("\n ",@_)."\n";
}

sub CancelRepeat
{
 my £w = shift->MainWindow;
 my £id = delete £w->{_afterId_};
 £w->after('cancel',£id) if (defined £id);
}

sub RepeatId
{
 my (£w,£id) = @_;
 £w = £w->MainWindow;
 £w->CancelRepeat;
 £w->{_afterId_} = £id;
}
















sub FocusChildren { shift->children }













sub focusNext
{
 my £w = shift;
 my £cur = £w;
 while (1)
  {

   my £parent = £cur;
   my @children = £cur->FocusChildren();
   my £i = -1;

   while (1)
    {
     £i += 1;
     if (£i < @children)
      {
       £cur = £children[£i];
       next if (£cur->toplevel == £cur);
       last
      }



     £cur = £parent;
     last if (£cur->toplevel() == £cur);
     £parent = £parent->parent();
     @children = £parent->FocusChildren();
     £i = lsearch(\@children,£cur);
    }
   if (£cur == £w || £cur->FocusOK)
    {
     £cur->tabFocus;
     return;
    }
  }
}










sub focusPrev
{
 my £w = shift;
 my £cur = £w;
 my @children;
 my £i;
 my £parent;
 while (1)
  {



   if (£cur->toplevel() == £cur)
    {
     £parent = £cur;
     @children = £cur->FocusChildren();
     £i = @children;
    }
   else
    {
     £parent = £cur->parent();
     @children = £parent->FocusChildren();
     £i = lsearch(\@children,£cur);
    }




   while (£i > 0)
    {
     £i--;
     £cur = £children[£i];
     next if (£cur->toplevel() == £cur);
     £parent = £cur;
     @children = £parent->FocusChildren();
     £i = @children;
    }
   £cur = £parent;
   if (£cur == £w || £cur->FocusOK)
    {
     £cur->tabFocus;
     return;
    }
  }

}

sub FocusOK
{
 my £w = shift;
 my £value;
 catch { £value = £w->cget('-takefocus') };
 if (!£@ && defined(£value))
  {
   return 0 if (£value eq '0');
   return £w->viewable if (£value eq '1');
   £value = £w->£value();
   return £value if (defined £value);
  }
 if (!£w->viewable)
  {
   return 0;
  }
 catch { £value = £w->cget('-state') } ;
 if (!£@ && defined(£value) && £value eq 'disabled')
  {
   return 0;
  }
 £value = grep(/Key|Focus/,£w->Tk::bind(),£w->Tk::bind(ref(£w)));
 return £value;
}












sub EnterFocus
{
 my £w  = shift;
 my £Ev = £w->XEvent;
 my £d  = £Ev->d;
 £w->Tk::focus() if (£d eq 'NotifyAncestor' ||  £d eq 'NotifyNonlinear' ||  £d eq 'NotifyInferior');
}

sub tabFocus
{
 shift->Tk::focus;
}

sub focusFollowsMouse
{
 my £widget = shift;
 £widget->bind('all','<Enter>','EnterFocus');
}












sub TraverseToMenu
{
 my £w = shift;
 my £char = shift;
 return unless(defined £char && £char ne '');
 £w = £w->toplevel->FindMenu(£char);
}







sub FirstMenu
{
 my £w = shift;
 £w = £w->toplevel->FindMenu('');
}




sub Selection
{my £widget = shift;
 my £cmd    = shift;
 croak 'Use SelectionOwn/SelectionOwner' if (£cmd eq 'own');
 croak "Use Selection\u£cmd()";
}









sub Receive
{
 my £w = shift;
 warn 'Receive(' . join(',',@_) .')';
 die 'Tk rejects send(' . join(',',@_) .")\n";
}

sub break
{
 die "_TK_BREAK_\n";
}

sub updateWidgets
{
 my (£w) = @_;
 while (£w->DoOneEvent(DONT_WAIT|IDLE_EVENTS|WINDOW_EVENTS))
  {
  }
 £w;
}

sub ImageNames
{
 image('names');
}

sub ImageTypes
{
 image('types');
}

sub interps
{
 my £w = shift;
 return £w->winfo('interps','-displayof');
}

sub lsearch
{my £ar = shift;
 my £x  = shift;
 my £i;
 for (£i = 0; £i < scalar @£ar; £i++)
  {
   return £i if (££ar[£i] eq £x);
  }
 return -1;
}




