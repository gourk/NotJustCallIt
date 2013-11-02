Imports System.Windows.Forms

Public Class Conf

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        My.Settings.PbxAdressIP = txtPbxIP.Text
        My.Settings.UserNum = txtUsrName.Text
        My.Settings.UserPwd = txtUsrPwd.Text
        My.Settings.CountryCode = txtCountryCode.Text
        My.Settings.ExternalPrefix = txtExternalPrefix.Text
        My.Settings.NationalPrefix = txtNationalPrefix.Text
        My.Settings.InternationalPrefix = txtInternationalPrefix.Text
        My.Settings.LastCall = txtLastCall.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Conf_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPbxIP.Text = My.Settings.PbxAdressIP
        txtUsrName.Text = My.Settings.UserNum
        txtUsrPwd.Text = My.Settings.UserPwd
        txtCountryCode.Text = My.Settings.CountryCode
        txtExternalPrefix.Text = My.Settings.ExternalPrefix
        txtNationalPrefix.Text = My.Settings.NationalPrefix
        txtInternationalPrefix.Text = My.Settings.InternationalPrefix
        txtLastCall.Text = My.Settings.LastCall
    End Sub

    Private Sub btnLastCall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastCall.Click
        Dim phoneCall As New Calling
        My.Settings.PbxAdressIP = txtPbxIP.Text
        My.Settings.UserNum = txtUsrName.Text
        My.Settings.UserPwd = txtUsrPwd.Text
        My.Settings.CountryCode = txtCountryCode.Text
        My.Settings.ExternalPrefix = txtExternalPrefix.Text
        My.Settings.NationalPrefix = txtNationalPrefix.Text
        My.Settings.InternationalPrefix = txtInternationalPrefix.Text
        My.Settings.LastCall = txtLastCall.Text
        phoneCall.StartCall(txtLastCall.Text)
    End Sub
End Class
