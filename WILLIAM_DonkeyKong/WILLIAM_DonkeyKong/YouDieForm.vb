Public Class YouDieForm

    Private Sub Replay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Replay.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MainForm.Close()
    End Sub
End Class