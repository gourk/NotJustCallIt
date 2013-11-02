<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Conf
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblPbxIP = New System.Windows.Forms.Label
        Me.lblUsrName = New System.Windows.Forms.Label
        Me.lblUsrPwd = New System.Windows.Forms.Label
        Me.txtPbxIP = New System.Windows.Forms.TextBox
        Me.txtUsrName = New System.Windows.Forms.TextBox
        Me.txtUsrPwd = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblCountryCode = New System.Windows.Forms.Label
        Me.lblExternalPrefix = New System.Windows.Forms.Label
        Me.lblNationalPrefix = New System.Windows.Forms.Label
        Me.lblInternationalPrefix = New System.Windows.Forms.Label
        Me.txtCountryCode = New System.Windows.Forms.TextBox
        Me.txtExternalPrefix = New System.Windows.Forms.TextBox
        Me.txtNationalPrefix = New System.Windows.Forms.TextBox
        Me.txtInternationalPrefix = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblLastCall = New System.Windows.Forms.Label
        Me.txtLastCall = New System.Windows.Forms.TextBox
        Me.btnLastCall = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(278, 416)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Annuler"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtUsrPwd)
        Me.GroupBox1.Controls.Add(Me.txtUsrName)
        Me.GroupBox1.Controls.Add(Me.txtPbxIP)
        Me.GroupBox1.Controls.Add(Me.lblUsrPwd)
        Me.GroupBox1.Controls.Add(Me.lblUsrName)
        Me.GroupBox1.Controls.Add(Me.lblPbxIP)
        Me.GroupBox1.Location = New System.Drawing.Point(36, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 119)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Authentification"
        '
        'lblPbxIP
        '
        Me.lblPbxIP.AutoSize = True
        Me.lblPbxIP.Location = New System.Drawing.Point(17, 31)
        Me.lblPbxIP.Name = "lblPbxIP"
        Me.lblPbxIP.Size = New System.Drawing.Size(56, 13)
        Me.lblPbxIP.TabIndex = 0
        Me.lblPbxIP.Text = "IP du PBX"
        '
        'lblUsrName
        '
        Me.lblUsrName.AutoSize = True
        Me.lblUsrName.Location = New System.Drawing.Point(17, 56)
        Me.lblUsrName.Name = "lblUsrName"
        Me.lblUsrName.Size = New System.Drawing.Size(84, 13)
        Me.lblUsrName.TabIndex = 1
        Me.lblUsrName.Text = "Nom d'utilisateur"
        '
        'lblUsrPwd
        '
        Me.lblUsrPwd.AutoSize = True
        Me.lblUsrPwd.Location = New System.Drawing.Point(17, 82)
        Me.lblUsrPwd.Name = "lblUsrPwd"
        Me.lblUsrPwd.Size = New System.Drawing.Size(71, 13)
        Me.lblUsrPwd.TabIndex = 2
        Me.lblUsrPwd.Text = "Mot de passe"
        '
        'txtPbxIP
        '
        Me.txtPbxIP.Location = New System.Drawing.Point(166, 23)
        Me.txtPbxIP.Name = "txtPbxIP"
        Me.txtPbxIP.Size = New System.Drawing.Size(160, 20)
        Me.txtPbxIP.TabIndex = 3
        '
        'txtUsrName
        '
        Me.txtUsrName.Location = New System.Drawing.Point(166, 49)
        Me.txtUsrName.Name = "txtUsrName"
        Me.txtUsrName.Size = New System.Drawing.Size(160, 20)
        Me.txtUsrName.TabIndex = 4
        '
        'txtUsrPwd
        '
        Me.txtUsrPwd.Location = New System.Drawing.Point(166, 75)
        Me.txtUsrPwd.Name = "txtUsrPwd"
        Me.txtUsrPwd.Size = New System.Drawing.Size(160, 20)
        Me.txtUsrPwd.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtInternationalPrefix)
        Me.GroupBox2.Controls.Add(Me.txtNationalPrefix)
        Me.GroupBox2.Controls.Add(Me.txtExternalPrefix)
        Me.GroupBox2.Controls.Add(Me.txtCountryCode)
        Me.GroupBox2.Controls.Add(Me.lblInternationalPrefix)
        Me.GroupBox2.Controls.Add(Me.lblNationalPrefix)
        Me.GroupBox2.Controls.Add(Me.lblExternalPrefix)
        Me.GroupBox2.Controls.Add(Me.lblCountryCode)
        Me.GroupBox2.Location = New System.Drawing.Point(37, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(356, 151)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Paramètres régionaux"
        '
        'lblCountryCode
        '
        Me.lblCountryCode.AutoSize = True
        Me.lblCountryCode.Location = New System.Drawing.Point(17, 26)
        Me.lblCountryCode.Name = "lblCountryCode"
        Me.lblCountryCode.Size = New System.Drawing.Size(58, 13)
        Me.lblCountryCode.TabIndex = 0
        Me.lblCountryCode.Text = "Code Pays"
        '
        'lblExternalPrefix
        '
        Me.lblExternalPrefix.AutoSize = True
        Me.lblExternalPrefix.Location = New System.Drawing.Point(17, 50)
        Me.lblExternalPrefix.Name = "lblExternalPrefix"
        Me.lblExternalPrefix.Size = New System.Drawing.Size(77, 13)
        Me.lblExternalPrefix.TabIndex = 1
        Me.lblExternalPrefix.Text = "Préfixe externe"
        '
        'lblNationalPrefix
        '
        Me.lblNationalPrefix.AutoSize = True
        Me.lblNationalPrefix.Location = New System.Drawing.Point(17, 74)
        Me.lblNationalPrefix.Name = "lblNationalPrefix"
        Me.lblNationalPrefix.Size = New System.Drawing.Size(79, 13)
        Me.lblNationalPrefix.TabIndex = 2
        Me.lblNationalPrefix.Text = "Préfixe national"
        '
        'lblInternationalPrefix
        '
        Me.lblInternationalPrefix.AutoSize = True
        Me.lblInternationalPrefix.Location = New System.Drawing.Point(17, 98)
        Me.lblInternationalPrefix.Name = "lblInternationalPrefix"
        Me.lblInternationalPrefix.Size = New System.Drawing.Size(99, 13)
        Me.lblInternationalPrefix.TabIndex = 3
        Me.lblInternationalPrefix.Text = "Préfixe international"
        '
        'txtCountryCode
        '
        Me.txtCountryCode.Location = New System.Drawing.Point(166, 19)
        Me.txtCountryCode.Name = "txtCountryCode"
        Me.txtCountryCode.Size = New System.Drawing.Size(160, 20)
        Me.txtCountryCode.TabIndex = 4
        '
        'txtExternalPrefix
        '
        Me.txtExternalPrefix.Location = New System.Drawing.Point(166, 43)
        Me.txtExternalPrefix.Name = "txtExternalPrefix"
        Me.txtExternalPrefix.Size = New System.Drawing.Size(160, 20)
        Me.txtExternalPrefix.TabIndex = 5
        '
        'txtNationalPrefix
        '
        Me.txtNationalPrefix.Location = New System.Drawing.Point(166, 67)
        Me.txtNationalPrefix.Name = "txtNationalPrefix"
        Me.txtNationalPrefix.Size = New System.Drawing.Size(160, 20)
        Me.txtNationalPrefix.TabIndex = 6
        '
        'txtInternationalPrefix
        '
        Me.txtInternationalPrefix.Location = New System.Drawing.Point(166, 91)
        Me.txtInternationalPrefix.Name = "txtInternationalPrefix"
        Me.txtInternationalPrefix.Size = New System.Drawing.Size(160, 20)
        Me.txtInternationalPrefix.TabIndex = 7
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnLastCall)
        Me.GroupBox3.Controls.Add(Me.txtLastCall)
        Me.GroupBox3.Controls.Add(Me.lblLastCall)
        Me.GroupBox3.Location = New System.Drawing.Point(37, 303)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(357, 93)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Manuel"
        '
        'lblLastCall
        '
        Me.lblLastCall.AutoSize = True
        Me.lblLastCall.Location = New System.Drawing.Point(20, 30)
        Me.lblLastCall.Name = "lblLastCall"
        Me.lblLastCall.Size = New System.Drawing.Size(70, 13)
        Me.lblLastCall.TabIndex = 0
        Me.lblLastCall.Text = "Dernier appel"
        '
        'txtLastCall
        '
        Me.txtLastCall.Location = New System.Drawing.Point(166, 22)
        Me.txtLastCall.Name = "txtLastCall"
        Me.txtLastCall.Size = New System.Drawing.Size(159, 20)
        Me.txtLastCall.TabIndex = 1
        '
        'btnLastCall
        '
        Me.btnLastCall.Location = New System.Drawing.Point(132, 60)
        Me.btnLastCall.Name = "btnLastCall"
        Me.btnLastCall.Size = New System.Drawing.Size(75, 23)
        Me.btnLastCall.TabIndex = 2
        Me.btnLastCall.Text = "Appeler"
        Me.btnLastCall.UseVisualStyleBackColor = True
        '
        'Conf
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(436, 457)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Conf"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuration"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUsrPwd As System.Windows.Forms.TextBox
    Friend WithEvents txtUsrName As System.Windows.Forms.TextBox
    Friend WithEvents txtPbxIP As System.Windows.Forms.TextBox
    Friend WithEvents lblUsrPwd As System.Windows.Forms.Label
    Friend WithEvents lblUsrName As System.Windows.Forms.Label
    Friend WithEvents lblPbxIP As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblInternationalPrefix As System.Windows.Forms.Label
    Friend WithEvents lblNationalPrefix As System.Windows.Forms.Label
    Friend WithEvents lblExternalPrefix As System.Windows.Forms.Label
    Friend WithEvents lblCountryCode As System.Windows.Forms.Label
    Friend WithEvents txtCountryCode As System.Windows.Forms.TextBox
    Friend WithEvents txtExternalPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtNationalPrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtInternationalPrefix As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLastCall As System.Windows.Forms.Button
    Friend WithEvents txtLastCall As System.Windows.Forms.TextBox
    Friend WithEvents lblLastCall As System.Windows.Forms.Label

End Class
