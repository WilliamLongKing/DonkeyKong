Public Class MainMenu

    Private Sub PlayGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayGame.Click
        Me.Hide()
        Game.ShowDialog()
    End Sub

    Private Sub Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Quit.Click
        Me.Close()
    End Sub
End Class
