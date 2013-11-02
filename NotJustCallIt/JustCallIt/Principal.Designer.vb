<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.BarMenu = New System.Windows.Forms.MenuStrip
        Me.ConfigurationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReduireToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pool = New System.Windows.Forms.Timer(Me.components)
        Me.Tray = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ConfigurationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PoolingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActiverPoolingStripMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.DésactiverStripMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.TelephoneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActiverTelStripMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.DésactiverTelStripMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.StandardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OuvertureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.FermetureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AProposMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.QuitterStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.BarMenu.SuspendLayout()
        Me.ctxMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'BarMenu
        '
        Me.BarMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem, Me.ReduireToolStripMenuItem, Me.QuitterToolStripMenuItem, Me.ToolStripMenuItem1})
        Me.BarMenu.Location = New System.Drawing.Point(0, 0)
        Me.BarMenu.Name = "BarMenu"
        Me.BarMenu.Size = New System.Drawing.Size(389, 24)
        Me.BarMenu.TabIndex = 0
        Me.BarMenu.Text = "MenuStrip1"
        '
        'ConfigurationToolStripMenuItem
        '
        Me.ConfigurationToolStripMenuItem.Name = "ConfigurationToolStripMenuItem"
        Me.ConfigurationToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.ConfigurationToolStripMenuItem.Text = "Configuration"
        '
        'ReduireToolStripMenuItem
        '
        Me.ReduireToolStripMenuItem.Name = "ReduireToolStripMenuItem"
        Me.ReduireToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReduireToolStripMenuItem.Text = "Réduire"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(67, 20)
        Me.ToolStripMenuItem1.Text = "A Propos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(89, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Copier un numéro de téléphone"
        '
        'Pool
        '
        '
        'Tray
        '
        Me.Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.Tray.BalloonTipTitle = "Appel en cours"
        Me.Tray.ContextMenuStrip = Me.ctxMenu
        Me.Tray.Icon = CType(resources.GetObject("Tray.Icon"), System.Drawing.Icon)
        Me.Tray.Text = "JustCall It!!!"
        Me.Tray.Visible = True
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConfigurationToolStripMenuItem1, Me.PoolingToolStripMenuItem, Me.TelephoneToolStripMenuItem, Me.StandardToolStripMenuItem, Me.AProposMenuItem, Me.QuitterStripMenuItem})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(151, 136)
        '
        'ConfigurationToolStripMenuItem1
        '
        Me.ConfigurationToolStripMenuItem1.Name = "ConfigurationToolStripMenuItem1"
        Me.ConfigurationToolStripMenuItem1.Size = New System.Drawing.Size(150, 22)
        Me.ConfigurationToolStripMenuItem1.Text = "Configuration"
        '
        'PoolingToolStripMenuItem
        '
        Me.PoolingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverPoolingStripMenu, Me.DésactiverStripMenu})
        Me.PoolingToolStripMenuItem.Name = "PoolingToolStripMenuItem"
        Me.PoolingToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PoolingToolStripMenuItem.Text = "Pooling"
        '
        'ActiverPoolingStripMenu
        '
        Me.ActiverPoolingStripMenu.Name = "ActiverPoolingStripMenu"
        Me.ActiverPoolingStripMenu.Size = New System.Drawing.Size(128, 22)
        Me.ActiverPoolingStripMenu.Text = "Activer"
        '
        'DésactiverStripMenu
        '
        Me.DésactiverStripMenu.Name = "DésactiverStripMenu"
        Me.DésactiverStripMenu.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverStripMenu.Text = "Désactiver"
        '
        'TelephoneToolStripMenuItem
        '
        Me.TelephoneToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActiverTelStripMenu, Me.DésactiverTelStripMenu})
        Me.TelephoneToolStripMenuItem.Enabled = False
        Me.TelephoneToolStripMenuItem.Name = "TelephoneToolStripMenuItem"
        Me.TelephoneToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.TelephoneToolStripMenuItem.Text = "Téléphone"
        Me.TelephoneToolStripMenuItem.Visible = False
        '
        'ActiverTelStripMenu
        '
        Me.ActiverTelStripMenu.Name = "ActiverTelStripMenu"
        Me.ActiverTelStripMenu.Size = New System.Drawing.Size(128, 22)
        Me.ActiverTelStripMenu.Text = "Activer"
        '
        'DésactiverTelStripMenu
        '
        Me.DésactiverTelStripMenu.Name = "DésactiverTelStripMenu"
        Me.DésactiverTelStripMenu.Size = New System.Drawing.Size(128, 22)
        Me.DésactiverTelStripMenu.Text = "Désactiver"
        '
        'StandardToolStripMenuItem
        '
        Me.StandardToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OuvertureToolStripMenuItem, Me.FermetureToolStripMenuItem})
        Me.StandardToolStripMenuItem.Enabled = False
        Me.StandardToolStripMenuItem.Name = "StandardToolStripMenuItem"
        Me.StandardToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.StandardToolStripMenuItem.Text = "Standard"
        Me.StandardToolStripMenuItem.Visible = False
        '
        'OuvertureToolStripMenuItem
        '
        Me.OuvertureToolStripMenuItem.Name = "OuvertureToolStripMenuItem"
        Me.OuvertureToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.OuvertureToolStripMenuItem.Text = "Ouverture"
        '
        'FermetureToolStripMenuItem
        '
        Me.FermetureToolStripMenuItem.Name = "FermetureToolStripMenuItem"
        Me.FermetureToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.FermetureToolStripMenuItem.Text = "Fermeture"
        '
        'AProposMenuItem
        '
        Me.AProposMenuItem.Name = "AProposMenuItem"
        Me.AProposMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.AProposMenuItem.Text = "A propos de ..."
        '
        'QuitterStripMenuItem
        '
        Me.QuitterStripMenuItem.Name = "QuitterStripMenuItem"
        Me.QuitterStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.QuitterStripMenuItem.Text = "Quitter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 3
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 175)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BarMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = Me.BarMenu
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Principal"
        Me.ShowInTaskbar = False
        Me.Text = "JustCallIt!"
        Me.BarMenu.ResumeLayout(False)
        Me.BarMenu.PerformLayout()
        Me.ctxMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents ConfigurationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReduireToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pool As System.Windows.Forms.Timer
    Friend WithEvents Tray As System.Windows.Forms.NotifyIcon
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ConfigurationToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PoolingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TelephoneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverPoolingStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActiverTelStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DésactiverTelStripMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StandardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OuvertureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FermetureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AProposMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
