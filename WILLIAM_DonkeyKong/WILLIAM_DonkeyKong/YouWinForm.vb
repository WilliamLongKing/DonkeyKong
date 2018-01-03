Public Class YouWinForm

    Private Sub Replay_Click(sender As System.Object, e As System.EventArgs) Handles Replay.Click
        Me.Close()
    End Sub

    Private Sub Leave_Click(sender As System.Object, e As System.EventArgs) Handles Leave.Click
        MainForm.Close()
    End Sub
End Class