Public Class Principal

   

    Private Sub Principal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Paramètrage et démarrage du timer
        Pool.Interval = 1000
        Pool.Enabled = True
        Pool.Start()
        ActiverPoolingStripMenu.Enabled = False
        DésactiverStripMenu.Enabled = True
        'Masque la fenêtre Principal
        With Me
            .Opacity = 0
            .Visible = False
        End With
    End Sub

    Private Sub ConfigurationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem.Click
        Dim ConfForm As New Conf
        Conf.Show()
    End Sub

    Private Sub Pool_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pool.Tick
        Dim num As New Number(My.Computer.Clipboard.GetText(TextDataFormat.Text))
        If num.IsNumber() Then
            Dim phoneCall As New Calling
            num.NormaliseNumber()
            Label1.Text = num.Number
            Label2.Text = Now.ToString
            phoneCall.StartCall(num.Number)
            My.Computer.Clipboard.SetText("Tél.:" + My.Computer.Clipboard.GetText(TextDataFormat.Text))
            Tray.BalloonTipText = num.Number
            Tray.ShowBalloonTip(5)
        End If
    End Sub

    Private Sub ConfigurationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfigurationToolStripMenuItem1.Click
        Dim ConfForm As New Conf
        Conf.Show()
    End Sub

    Private Sub QuitterStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AfficherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With Me
            .Opacity = 100
            .Visible = True
        End With
    End Sub

    Private Sub Tray_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tray.MouseDoubleClick
        Dim ConfForm As New Conf
        Conf.Show()
        'With Me
        '.Opacity = 100
        '.Visible = True
        'End With
    End Sub

    Private Sub ReduireToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReduireToolStripMenuItem.Click
        With Me
            .Opacity = 0
            .Visible = False
        End With
    End Sub

    Private Sub QuitterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitterToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ActiverPoolingStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverPoolingStripMenu.Click
        Pool.Enabled = True
        Pool.Start()
        ActiverPoolingStripMenu.Enabled = False
        DésactiverStripMenu.Enabled = True
    End Sub

    Private Sub DésactiverStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverStripMenu.Click
        Pool.Stop()
        Pool.Enabled = False
        ActiverPoolingStripMenu.Enabled = True
        DésactiverStripMenu.Enabled = False
    End Sub

    Private Sub ActiverTelStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActiverTelStripMenu.Click
        Dim phoneCall As New Calling
        phoneCall.StartCall("77")
    End Sub

    Private Sub DésactiverTelStripMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DésactiverTelStripMenu.Click
        Dim phoneCall As New Calling
        phoneCall.StartCall("76")
    End Sub

    Private Sub OuvertureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvertureToolStripMenuItem.Click
        Dim phoneCall As New Calling
        phoneCall.StartCall("65*3603921234")
    End Sub

    Private Sub FermetureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FermetureToolStripMenuItem.Click
        Dim phoneCall As New Calling
        phoneCall.StartCall("65*3608841234")
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim about As New AboutBox1
        about.Show()
    End Sub

    Private Sub AProposMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AProposMenuItem.Click
        Dim about As New AboutBox1
        about.Show()
    End Sub
End Class
