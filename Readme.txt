--------------------
-- Not JustCallIt --
--------------------

NotJustCallIt is a clone of JustCallIt. JustCallIt is a tool from Ericson to call a number from PC. It works only with Ericson MD Evolution.
Ericson JustCallIt user guide : http://biscuit2209.free.fr/Informatique/Technique/Editeurs/MDEvolution/Logiciels/Applications/Just%20Call%20It/Just_Call_It_Vista/justcallit-en.pdf


--Intoduction--
At work this tool is very usefull. Unfortunelly, it not compatible to Windows 7 in 2009. So made some reverse engenering to know how it works and to make it compatible with more OS.
It is built in Perl and convert in executable by Perl2Exe version 8. I found (I don't remerber where) an piece of C code to reverse it, it named Exe2Perl.
Since I had the Perl code source, it was easily to rebuilt it. At this time, I didn't use to know many language. So I built it in VB.Net.

--How Ericson MD Evolution works--
First you need to authenticate 
	http://MDEvolutionIPAddress/cgi/com/authModule
	  Post method Method=Login&user=YourUserNumber&passwd=YourPassword

And you send the number you want to call
	http://MDEvolutionIPAddress/cgi/usr/ctgModule?Method=CtiRequest&user=YourUserNumber&cmd=MCTheNumberYouWantToCall

--How NotJustCallIt works--
It is a tray icon application for Windows which call all phone number you copy in clipboard.