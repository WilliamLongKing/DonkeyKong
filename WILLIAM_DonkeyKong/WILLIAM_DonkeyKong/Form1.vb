Public Class MainForm
    Dim bstuff(3) As marioType
    Dim barrel(3) As PictureBox
    Dim fstuff(6) As floortype
    Dim numladders As Integer = 6
    Dim ladders(numladders) As PictureBox
    Dim throwtimer As Integer
    Dim dkdancing As Boolean
    Dim flashtimer As Integer
    Dim lives As Integer = 3
    Private Sub barrelset()
        Dim index As Integer
        For index = 0 To 3
            barrel(index).Visible = False
            barrel(index).Top = 70
            barrel(index).Left = 203

            bstuff(index).speed.X = 10
            bstuff(index).floating = False
            bstuff(index).onLadder = False
            bstuff(index).picNum = 1
            bstuff(index).speed.Y = 0
        Next index
    End Sub
    Public Sub floorset()
        fstuff(0).slope = -0.000000001
        fstuff(1).slope = 0.078
        fstuff(2).slope = -0.078
        fstuff(3).slope = 0.078
        fstuff(4).slope = -0.078
        fstuff(5).slope = 0
        fstuff(6).slope = 0

        fstuff(0).x = 137
        fstuff(1).x = 137
        fstuff(2).x = 137
        fstuff(3).x = 137
        fstuff(4).x = 137
        fstuff(5).x = 137
        fstuff(6).x = 137

        fstuff(0).y = 465
        fstuff(1).y = 377
        fstuff(2).y = 327
        fstuff(3).y = 226
        fstuff(4).y = 176
        fstuff(5).y = 92
        fstuff(6).y = 42

        fstuff(0).leftedge = 0
        fstuff(1).leftedge = 0
        fstuff(2).leftedge = 133
        fstuff(3).leftedge = 0
        fstuff(4).leftedge = 133
        fstuff(5).leftedge = 0
        fstuff(6).leftedge = 200

        fstuff(0).rightedge = 570
        fstuff(1).rightedge = 507
        fstuff(2).rightedge = 570
        fstuff(3).rightedge = 507
        fstuff(4).rightedge = 570
        fstuff(5).rightedge = 507
        fstuff(6).rightedge = 312
    End Sub

    Public Sub loadladders()
        ladders(0) = Ladder0
        ladders(1) = Ladder1
        ladders(2) = Ladder2
        ladders(3) = Ladder3
        ladders(4) = Ladder4
        ladders(5) = Ladder5
    End Sub

    Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Down Then
            If mstuff.floating = False Then
                mstuff.speed.Y = 5
            End If
        End If
        If e.KeyCode = Keys.Up Then
            If mstuff.floating = False Then
                mstuff.speed.Y = -5
            End If
        End If
        If e.KeyCode = Keys.Left Then
            If Mario.Left > 75 Then
                mstuff.speed.X = -5
                mstuff.facingRight = False
            End If
        End If




        If e.KeyCode = Keys.Right Then
            If Mario.Right < 600 - Mario.Width Then
                mstuff.speed.X = 5
                mstuff.facingRight = True
            End If

        End If


        If e.KeyCode = Keys.Space And mstuff.speed.Y = 0 And mstuff.onFloor = True Then
            mstuff.floattime = 0
            mstuff.speed.Y = -5
            mstuff.floating = True
        End If

    End Sub

    Private Sub MainForm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Down Then
            mstuff.speed.Y = 0
        End If
        If e.KeyCode = Keys.Up Then
            mstuff.speed.Y = -0
        End If
        If e.KeyCode = Keys.Left Then
            mstuff.speed.X = -0

        End If



        If e.KeyCode = Keys.Right Then
            mstuff.speed.X = 0
        End If


    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mstuff.picNum = 1
        Call loadladders()
        Call floorset()
        Call loadbarrels()
        Call barrelset()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim index As Integer

        moveMario()
        animateMario()
        AnimateDonkeyKong()
        ThrowBarrel()
        flashhelp()
        For index = 0 To 3
            If barrel(index).Visible = True Then
                Call movebarrel(index)
                Call AnimateBarrel(index)
                If touching(Mario, barrel(index)) = True Then
                    Timer1.Stop()
                    lives = lives - 1
                    If lives = -1 Then
                        gameoverform.showdialog()
                        Me.Close()
                    End If
                    If lives = 0 Then
                        Live3.Visible = False
                    End If
                    If lives = 1 Then
                        Live2.Visible = False
                    End If
                    If lives = 2 Then
                        Live1.Visible = False
                    End If
                    YouDieForm.ShowDialog()
                    Call ResetLevel()
                    Timer1.Start()
                End If
            End If
        Next index
        If touching(Mario, Peach) = True Then
            Timer1.Stop()
            YouWinForm.ShowDialog()
            Call ResetLevel()
            Timer1.Start()
        End If
    End Sub

    Private Sub moveMario()
        Dim FloorNumber As Integer
        FloorNumber = GetFloorNumber(Mario.Top)
        If mstuff.floating = True Then
            '-----JUMPCODE-----
            If mstuff.floattime = 10 Then
                If mstuff.speed.Y < 0 Then
                    mstuff.speed.Y = 5
                Else
                    mstuff.speed.Y = 0
                    mstuff.floating = False
                End If
                mstuff.floattime = 1
            Else
                mstuff.floattime += 1
            End If
        Else

            mstuff.onLadder = checkLadder()
            If mstuff.onLadder = True Then
                mstuff.speed.X = 0
            Else
                mstuff.speed.Y = 0
                mstuff.onFloor = True
                Mario.Top = fstuff(FloorNumber).slope *
                    (Mario.Left - fstuff(FloorNumber).x) + fstuff(FloorNumber).y - Mario.Height
                If Mario.Left > fstuff(FloorNumber).rightedge Then
                    mstuff.floating = True
                    mstuff.floattime = 1
                    mstuff.speed.Y = 5
                ElseIf Mario.Left + Mario.Width <
                    fstuff(FloorNumber).leftedge Then
                    mstuff.floating = True
                    mstuff.floattime = 1
                    mstuff.speed.Y = 5
                End If
            End If
        End If

        '-------The Rest T_T-----------
        If (Mario.Left < 77 And mstuff.speed.X < 0) Or (Mario.Left > 540 And mstuff.speed.X > 0) Then
            mstuff.speed.X = 0
        End If
        Mario.Left = Mario.Left + mstuff.speed.X
        Mario.Top = Mario.Top + mstuff.speed.Y
    End Sub

    Private Sub animateMario()
        If mstuff.speed.Y <> 0 Then
            If mstuff.floating = False Then
                If mstuff.picNum = 1 Then
                    mstuff.picNum = 2
                    Mario.Image = My.Resources.marioClimb2
                ElseIf mstuff.picNum = 2 Then
                    mstuff.picNum = 3
                    Mario.Image = My.Resources.marioClimb3
                ElseIf mstuff.picNum = 3 Then
                    mstuff.picNum = 1
                    Mario.Image = My.Resources.marioClimb1
                End If
            End If
            If mstuff.speed.X > 0 And mstuff.facingRight = True Then
                Mario.Image = My.Resources.marioRightFloat

            ElseIf mstuff.speed.X < 0 And mstuff.facingRight = False Then
                Mario.Image = My.Resources.marioLeftFloat
            End If
        Else
            If mstuff.speed.X > 0 Then
                If mstuff.picNum = 1 Then
                    Mario.Image = My.Resources.marioRightMove2
                    mstuff.picNum += 1
                ElseIf mstuff.picNum = 2 Then
                    Mario.Image = My.Resources.marioRightMove3
                    mstuff.picNum += 1
                ElseIf mstuff.picNum = 3 Then
                    Mario.Image = My.Resources.marioRightMove1
                    mstuff.picNum = 1
                End If
            ElseIf mstuff.speed.X < 0 Then
                If mstuff.picNum = 1 Then
                    Mario.Image = My.Resources.marioLeftMove2
                    mstuff.picNum += 1
                ElseIf mstuff.picNum = 2 Then
                    Mario.Image = My.Resources.marioLeftMove3
                    mstuff.picNum += 1
                ElseIf mstuff.picNum = 3 Then
                    Mario.Image = My.Resources.marioLeftMove1
                    mstuff.picNum = 1
                End If
            Else


                If mstuff.facingRight = True Then
                    Mario.Image = My.Resources.marioRightMove1
                Else
                    Mario.Image = My.Resources.marioLeftMove1
                End If
            End If
        End If
    End Sub

    Private Function checkLadder()
        Dim Index As Integer
        Dim offset As Integer
        offset = 15
        For Index = 0 To numladders - 1
            If mstuff.speed.Y < 0 Then
                If Mario.Left > ladders(Index).Left - offset And Mario.Right < ladders(Index).Right + offset Then '--leftandright---
                    If Mario.Top < ladders(Index).Bottom And Mario.Bottom > ladders(Index).Top Then '--topandbottom---
                        Return True
                    End If
                End If

            ElseIf mstuff.speed.Y > 0 Then
                If Mario.Left > ladders(Index).Left - offset And Mario.Right < ladders(Index).Right + offset Then '--leftandright---
                    If Mario.Bottom < ladders(Index).Bottom And Mario.Bottom > ladders(Index).Top - offset Then '--topandbottom---
                        Return True
                    End If
                End If
            ElseIf mstuff.speed.Y = 0 Then
                If Mario.Left > ladders(Index).Left - offset And Mario.Right < ladders(Index).Right + offset Then '--leftandright---
                    If Mario.Bottom < ladders(Index).Bottom - offset And Mario.Bottom > ladders(Index).Top + offset Then '--topandbottom---
                        Return True
                    End If
                End If
            End If
        Next Index
        Return False
    End Function
    Private Function GetFloorNumber(ByVal Thingtop As Integer)
        If Thingtop < 20 Then
            Return 6
        ElseIf Thingtop < 73 Then
            Return 5
        ElseIf Thingtop < 160 Then
            Return 4
        ElseIf Thingtop < 240 Then
            Return 3
        ElseIf Thingtop < 320 Then
            Return 2
        ElseIf Thingtop < 393 Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Sub loadbarrels()
        barrel(0) = Barrel0
        barrel(1) = Barrel1
        barrel(2) = Barrel2
        barrel(3) = Barrel3

    End Sub
    Private Sub movebarrel(ByVal index As Integer)
        Dim FloorNumber As Integer
        FloorNumber = GetFloorNumber(barrel(index).Top)
        If bstuff(index).floating = True Then
            '-----JUMPCODE-----
            If bstuff(index).floattime = 5 Then
                If bstuff(index).speed.Y < 0 Then
                    bstuff(index).speed.Y = 5
                Else
                    bstuff(index).speed.Y = 0
                    bstuff(index).floating = False
                    If fstuff(FloorNumber).slope < 0 Then
                        bstuff(index).speed.X = -10
                    Else
                        bstuff(index).speed.X = 10
                    End If
                End If
                bstuff(index).floattime = 1
            Else
                bstuff(index).floattime += 1
            End If
        Else

            bstuff(index).onLadder = BarrelCheckLadder(index)
            If bstuff(index).onLadder = True Then
                bstuff(index).speed.X = 0
                bstuff(index).speed.Y = 10
                bstuff(index).floating = True
            Else
                bstuff(index).speed.Y = 0
                bstuff(index).onFloor = True
                barrel(index).Top = fstuff(FloorNumber).slope *
                    (barrel(index).Left - fstuff(FloorNumber).x) + fstuff(FloorNumber).y - barrel(index).Height
                If barrel(index).Left > fstuff(FloorNumber).rightedge Then
                    bstuff(index).floating = True
                    bstuff(index).floattime = 1
                    bstuff(index).speed.Y = 5
                ElseIf barrel(index).Left + barrel(index).Width <
                    fstuff(FloorNumber).leftedge Then
                    bstuff(index).floating = True
                    bstuff(index).floattime = 1
                    bstuff(index).speed.Y = 5
                End If
            End If
        End If

        '-------The Rest T_T-----------
        If (barrel(index).Left < 77 And bstuff(index).speed.X < 0) Or (barrel(index).Left > 540 And bstuff(index).speed.X > 0) Then
            bstuff(index).speed.X = 0

        End If
        barrel(index).Left = barrel(index).Left + bstuff(index).speed.X
        barrel(index).Top = barrel(index).Top + bstuff(index).speed.Y
        If FloorNumber = 0 And barrel(index).Left < 88 Then
            barrel(index).Visible = False
            dkdancing = False
            throwtimer = 0
            DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbstanding.jpg")
        End If

    End Sub
    Private Function BarrelCheckLadder(ByVal index As Integer)
        Dim LadderIndex As Integer
        Dim offset As Integer
        offset = 13
        If Int(Rnd() * 2) = 0 Then
            For LadderIndex = 0 To numladders - 1
                If barrel(index).Left > ladders(LadderIndex).Left And barrel(index).Right < ladders(LadderIndex).Right Then '--leftandright---
                    If barrel(index).Bottom + offset > ladders(LadderIndex).Top And barrel(index).Bottom - offset < ladders(LadderIndex).Top Then '--topandbottom---
                        Return True
                    End If
                End If
            Next LadderIndex
        End If
        Return False
    End Function
    Private Sub AnimateBarrel(ByVal index As Integer )
        If bstuff(Index).picNum = 1 Then
            bstuff(Index).picNum = 2
            barrel(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\barrel1.jpg")
        ElseIf bstuff(Index).picNum = 2 Then
            bstuff(Index).picNum = 3
            barrel(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\barrel2.jpg")
        ElseIf bstuff(Index).picNum = 3 Then
            bstuff(Index).picNum = 4
            barrel(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\barrel3.jpg")
        ElseIf bstuff(Index).picNum = 4 Then
            bstuff(Index).picNum = 1
            barrel(Index).Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\barrel3.jpg")
        End If
    End Sub
    Private Function touching(ByVal object1 As PictureBox, object2 As PictureBox)
        If object1.Left < object2.Right And object1.Right > object2.Left Then
            If object1.Bottom > object2.Top And object1.Top < object2.Bottom Then
                Return True
            End If
        End If
        Return False
    End Function
    Public Sub ResetLevel()
        Call floorset()
        Call loadladders()
        Call marioset()
        Call barrelset()

    End Sub
    Private Sub marioset()
        mstuff.picNum = 1
        mstuff.facingRight = True
        Mario.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\mariorightmove1.jpg")
        Mario.Left = 104
        Mario.Top = 430
        mstuff.speed.X = 0
        mstuff.speed.Y = 0
        mstuff.onFloor = True
    End Sub
    Private Sub ThrowBarrel()
        Dim index As Integer
        Dim index2 As Integer
        Dim done As Boolean
        throwtimer = throwtimer + 1
        If throwtimer = 32 Then
            throwtimer = 0
            done = False
            Do While done = False
                If barrel(index).Visible = False Then
                    done = True
                    barrel(index).Visible = True
                    barrel(index).Top = 70
                    barrel(index).Left = 201
                    bstuff(index).floating = False
                    bstuff(index).onLadder = False
                    bstuff(index).picNum = 1
                    bstuff(index).speed.X = 10
                    bstuff(index).speed.Y = 0
                    dkdancing = True
                    For index2 = 0 To 3
                        If barrel(index2).Visible = False Then
                            dkdancing = False
                        End If
                    Next index2
                End If
                index = index + 1
                If index = 4 Then
                    done = True
                End If
            Loop
            End If
    End Sub
    Private Sub AnimateDonkeyKong()
        If dkdancing = False Then
        If throwtimer > 30 Then
            DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbrollingbarrel.jpg")
        ElseIf throwtimer > 15 Then
            DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbholdingbarrel.jpg")
        ElseIf throwtimer > 7 Then
            DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbgettingbarrel.jpg")
        End If
        else 
            If throwtimer > 30 Then
                DonkeyKong.Image =
                    Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbsmiling.jpg")
            ElseIf throwtimer > 22 Then
                DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbdancing2.jpg")
            ElseIf throwtimer > 14 Then
                DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbdancing.jpg")
            ElseIf throwtimer > 8 Then
                DonkeyKong.Image =
                Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\bobbstanding.jpg")
            End If
        End If
    End Sub
    Private Sub flashhelp()
        flashtimer += 1
        If flashtimer > 10 Then
            flashtimer = 0
            If hlp.Visible = True Then
                hlp.Visible = False
            Else
                hlp.Visible = True
            End If
        End If
    End Sub
End Class
