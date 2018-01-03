Public Class Cheat
    Dim cheat As cheats
    Dim cheatboxtype As Boolean
    Dim CheatBox As PictureBox
    Public Sub cheatsub()
        If cheatboxtype = True Then
            CheatBox.Visible = True
            CheatBox.Enabled = True
            CheatBox.Focus()
        End If
    End Sub
End Class
