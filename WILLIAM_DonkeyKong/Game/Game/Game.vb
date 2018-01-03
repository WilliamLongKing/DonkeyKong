Public Class Game
    Dim numBlocks As Integer = 175
    Dim direction As Integer = 2
    Dim speed As Integer = 10
    Dim jumpheight As Integer = 15
    Dim GRAVITY As Integer = 1
    Dim ground As Integer = 1000
    Dim playerXSpeed = 0
    Dim playerYSpeed = 0
    Dim moveSpeed As Integer = 10
    Dim jump As Boolean = True
    Dim leftPressed As Boolean = False
    Dim rightPressed As Boolean = False
    Dim upPressed As Boolean = False
    Dim downPressed As Boolean = False
    Dim spacePressed As Boolean = False
    Dim dirt(numBlocks) As PictureBox
    Dim cheat As cheats
    Dim cheatboxtype As Boolean = False

    Private Sub Game_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Call PauseMenu()
        End If

        If e.KeyCode = Keys.Right Then
            rightPressed = True
            direction = 2
        End If

        If e.KeyCode = Keys.Left Then
            leftPressed = True
            direction = 4
        End If

        If e.KeyCode = Keys.Up Then
            upPressed = True
            direction = 1
        End If

        If e.KeyCode = Keys.Down Then
            downPressed = True
            direction = 3
        End If

        If e.KeyCode = Keys.Space Then
            Dim currentBlock As Integer
            currentBlock = checkDirection()

            If currentBlock <> -1 Then
                dirt(currentBlock).Visible = False
            End If
        End If

        If e.KeyCode = Keys.C Then
            CheatBox.Visible = True
            CheatBox.Enabled = False
        End If
        If e.KeyCode = Keys.C Then
            cheatboxtype = True
        End If
    End Sub

    Public Sub MovePlayer()
        If rightPressed = True Then
            If checkDirection() = -1 Then
                Player.Left += speed
            End If
        End If
        If leftPressed = True Then
            If checkDirection() = -1 Then
                Player.Left -= speed
            End If
        End If
        If upPressed = True And jump = False Then
            playerYSpeed = -jumpheight
            jump = True
        End If

        Call checkAbove()

        Player.Top += playerYSpeed

        If Player.Top < ground Then
            playerYSpeed += GRAVITY
        Else
            Player.Top = ground
            jump = False
            playerYSpeed = 0
        End If
    End Sub

    Public Sub checkGround()
        Dim index As Integer
        Shadow.Location = Player.Location
        Shadow.Top += 1
        For index = 0 To numBlocks
            If Touching(Shadow, dirt(index)) And playerYSpeed > 0 Then
                ground = dirt(index).Top - Player.Height
                Shadow.Top -= 1
                Return
            End If
        Next
        ground = 1000
    End Sub

    Public Sub checkAbove()
        Dim index As Integer
        Shadow.Location = Player.Location
        Shadow.Top -= speed
        For index = 0 To numBlocks
            If Touching(Shadow, dirt(index)) And playerYSpeed < 0 Then
                playerYSpeed = 0
                Shadow.Top += speed
                Return
            End If
        Next
    End Sub

    Public Function checkDirection()
        Dim index As Integer
        Shadow.Location = Player.Location
        For index = 0 To numBlocks
            If direction = 1 Then
                Shadow.Top -= moveSpeed
                If Touching(Shadow, dirt(index)) Then
                    Shadow.Top += moveSpeed
                    Return index
                End If
                Shadow.Top += moveSpeed
            ElseIf direction = 2 Then
                Shadow.Left += moveSpeed
                If Touching(Shadow, dirt(index)) Then
                    Shadow.Left -= moveSpeed
                    Return index
                End If
                Shadow.Left -= moveSpeed
            ElseIf direction = 3 Then
                Shadow.Top += moveSpeed
                If Touching(Shadow, dirt(index)) Then
                    Shadow.Top -= moveSpeed
                    Return index
                End If
                Shadow.Top -= moveSpeed
            ElseIf direction = 4 Then
                Shadow.Left -= moveSpeed
                If Touching(Shadow, dirt(index)) Then
                    Shadow.Left += moveSpeed
                    Return index
                End If
                Shadow.Left += moveSpeed
            End If
        Next

        Return -1
    End Function

    Public Sub PauseMenu()
        PauseMenuMain.Visible = True
        PauseMenuMain.Enabled = True
        PauseMenuQuit.Visible = True
        PauseMenuQuit.Enabled = True
        PauseChangePlayerSpeed.Visible = True
        PauseChangePlayerSpeed.Enabled = True
    End Sub

    Private Sub PauseMenuMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseMenuMain.Click
        Me.Hide()
        MainMenu.ShowDialog()
    End Sub

    Private Sub PauseMenuQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseMenuQuit.Click
        MainMenu.Close()
        Me.Close()
    End Sub

    Private Function Touching(ByVal object1 As PictureBox, ByVal object2 As PictureBox)
        If object2.Visible = False Then
            Return False
        End If
        If object1.Left < object2.Right And object1.Right > object2.Left Then
            If object1.Bottom > object2.Top And object1.Top < object2.Bottom Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call checkGround()
        Call MovePlayer()
    End Sub

    Public Sub SetDirt()
        dirt(0) = PictureBox3
        dirt(1) = PictureBox4
        dirt(2) = PictureBox5
        dirt(3) = PictureBox6
        dirt(4) = PictureBox7
        dirt(5) = PictureBox8
        dirt(6) = PictureBox9
        dirt(7) = PictureBox10
        dirt(8) = PictureBox11
        dirt(9) = PictureBox12
        dirt(10) = PictureBox13
        dirt(11) = PictureBox14
        dirt(12) = PictureBox15
        dirt(13) = PictureBox16
        dirt(14) = PictureBox17
        dirt(15) = PictureBox18
        dirt(16) = PictureBox19
        dirt(17) = PictureBox20
        dirt(18) = PictureBox21
        dirt(19) = PictureBox22
        dirt(20) = PictureBox23
        dirt(21) = PictureBox24
        dirt(22) = PictureBox25
        dirt(23) = PictureBox26
        dirt(24) = PictureBox27
        dirt(25) = PictureBox28
        dirt(26) = PictureBox29
        dirt(27) = PictureBox30
        dirt(28) = PictureBox31
        dirt(29) = PictureBox32
        dirt(30) = PictureBox33
        dirt(31) = PictureBox34
        dirt(32) = PictureBox35
        dirt(33) = PictureBox36
        dirt(34) = PictureBox37
        dirt(35) = PictureBox38
        dirt(36) = PictureBox39
        dirt(37) = PictureBox40
        dirt(38) = PictureBox41
        dirt(39) = PictureBox42
        dirt(40) = PictureBox43
        dirt(41) = PictureBox44
        dirt(42) = PictureBox45
        dirt(43) = PictureBox46
        dirt(44) = PictureBox47
        dirt(45) = PictureBox48
        dirt(46) = PictureBox49
        dirt(47) = PictureBox50
        dirt(48) = PictureBox51
        dirt(49) = PictureBox52
        dirt(50) = PictureBox53
        dirt(51) = PictureBox54
        dirt(52) = PictureBox55
        dirt(53) = PictureBox56
        dirt(54) = PictureBox57
        dirt(55) = PictureBox58
        dirt(56) = PictureBox59
        dirt(57) = PictureBox60
        dirt(58) = PictureBox61
        dirt(59) = PictureBox62
        dirt(60) = PictureBox63
        dirt(61) = PictureBox64
        dirt(62) = PictureBox65
        dirt(63) = PictureBox66
        dirt(64) = PictureBox67
        dirt(65) = PictureBox68
        dirt(66) = PictureBox69
        dirt(67) = PictureBox70
        dirt(68) = PictureBox71
        dirt(69) = PictureBox72
        dirt(70) = PictureBox73
        dirt(71) = PictureBox74
        dirt(72) = PictureBox75
        dirt(73) = PictureBox76
        dirt(74) = PictureBox77
        dirt(75) = PictureBox78
        dirt(76) = PictureBox79
        dirt(77) = PictureBox80
        dirt(78) = PictureBox81
        dirt(79) = PictureBox82
        dirt(80) = PictureBox83
        dirt(81) = PictureBox84
        dirt(82) = PictureBox85
        dirt(83) = PictureBox86
        dirt(84) = PictureBox87
        dirt(85) = PictureBox88
        dirt(86) = PictureBox89
        dirt(87) = PictureBox90
        dirt(88) = PictureBox91
        dirt(89) = PictureBox92
        dirt(90) = PictureBox93
        dirt(91) = PictureBox94
        dirt(92) = PictureBox95
        dirt(93) = PictureBox96
        dirt(94) = PictureBox97
        dirt(95) = PictureBox98
        dirt(96) = PictureBox99
        dirt(97) = PictureBox100
        dirt(98) = PictureBox101
        dirt(99) = PictureBox102
        dirt(100) = PictureBox103
        dirt(101) = PictureBox104
        dirt(102) = PictureBox105
        dirt(103) = PictureBox106
        dirt(104) = PictureBox107
        dirt(105) = PictureBox108
        dirt(106) = PictureBox109
        dirt(107) = PictureBox110
        dirt(108) = PictureBox112
        dirt(109) = PictureBox113
        dirt(110) = PictureBox114
        dirt(111) = PictureBox115
        dirt(112) = PictureBox116
        dirt(113) = PictureBox117
        dirt(114) = PictureBox118
        dirt(115) = PictureBox119
        dirt(116) = PictureBox120
        dirt(117) = PictureBox121
        dirt(118) = PictureBox122
        dirt(119) = PictureBox123
        dirt(120) = PictureBox124
        dirt(121) = PictureBox125
        dirt(122) = PictureBox126
        dirt(123) = PictureBox127
        dirt(124) = PictureBox128
        dirt(125) = PictureBox129
        dirt(126) = PictureBox130
        dirt(127) = PictureBox131
        dirt(128) = PictureBox132
        dirt(129) = PictureBox133
        dirt(130) = PictureBox134
        dirt(131) = PictureBox135
        dirt(132) = PictureBox136
        dirt(133) = PictureBox137
        dirt(134) = PictureBox138
        dirt(135) = PictureBox139
        dirt(136) = PictureBox140
        dirt(137) = PictureBox141
        dirt(138) = PictureBox142
        dirt(139) = PictureBox143
        dirt(140) = PictureBox144
        dirt(141) = PictureBox145
        dirt(142) = PictureBox146
        dirt(143) = PictureBox147
        dirt(144) = PictureBox148
        dirt(145) = PictureBox149
        dirt(146) = PictureBox150
        dirt(147) = PictureBox151
        dirt(148) = PictureBox152
        dirt(149) = PictureBox153
        dirt(150) = PictureBox154
        dirt(151) = PictureBox155
        dirt(152) = PictureBox156
        dirt(153) = PictureBox157
        dirt(154) = PictureBox158
        dirt(155) = PictureBox159
        dirt(156) = PictureBox160
        dirt(157) = PictureBox161
        dirt(158) = PictureBox162
        dirt(159) = PictureBox163
        dirt(160) = PictureBox164
        dirt(161) = PictureBox165
        dirt(162) = PictureBox166
        dirt(163) = PictureBox167
        dirt(164) = PictureBox168
        dirt(165) = PictureBox169
        dirt(166) = PictureBox170
        dirt(167) = PictureBox171
        dirt(168) = PictureBox172
        dirt(169) = PictureBox173
        dirt(170) = PictureBox174
        dirt(171) = PictureBox175
        dirt(172) = PictureBox176
        dirt(173) = PictureBox177
        dirt(174) = PictureBox178
        dirt(175) = PictureBox111
    End Sub

    Private Sub Game_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp

        If e.KeyCode = Keys.Right Then
            rightPressed = False
            playerXSpeed = 0
        End If

        If e.KeyCode = Keys.Left Then
            leftPressed = False
            playerXSpeed = 0
        End If

        If e.KeyCode = Keys.Up Then
            upPressed = False
        End If

        If e.KeyCode = Keys.Down Then
            downPressed = False
        End If
    End Sub


    Private Sub Game_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetDirt()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        speed = TextBox1.Text
        TextBox1.Enabled = False
        TextBox1.Visible = False
        Label1.Enabled = False
        Label1.Visible = False
        Label2.Enabled = False
        Label2.Visible = False
        Call PauseExit()
    End Sub

    Private Sub PauseChangePlayerSpeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseChangePlayerSpeed.Click
        TextBox1.Enabled = True
        TextBox1.Visible = True
        Label1.Enabled = True
        Label1.Visible = True
        Label2.Enabled = True
        Label2.Visible = True
    End Sub

    Public Sub PauseExit()
        PauseMenuMain.Visible = False
        PauseMenuMain.Enabled = False
        PauseMenuQuit.Visible = False
        PauseMenuQuit.Enabled = False
        PauseChangePlayerSpeed.Visible = False
        PauseChangePlayerSpeed.Enabled = False
    End Sub
End Class