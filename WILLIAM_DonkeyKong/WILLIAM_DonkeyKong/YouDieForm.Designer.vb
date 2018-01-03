<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class YouDieForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(YouDieForm))
        Me.Replay = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Quit = New System.Windows.Forms.PictureBox()
        CType(Me.Quit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Replay
        '
        Me.Replay.Location = New System.Drawing.Point(542, 478)
        Me.Replay.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Replay.Name = "Replay"
        Me.Replay.Size = New System.Drawing.Size(220, 48)
        Me.Replay.TabIndex = 4
        Me.Replay.Text = "Respawn" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Replay.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(794, 478)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 46)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Give Up"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Quit
        '
        Me.Quit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Quit.Image = CType(resources.GetObject("Quit.Image"), System.Drawing.Image)
        Me.Quit.Location = New System.Drawing.Point(0, 0)
        Me.Quit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Quit.Name = "Quit"
        Me.Quit.Size = New System.Drawing.Size(1231, 539)
        Me.Quit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Quit.TabIndex = 0
        Me.Quit.TabStop = False
        '
        'YouDieForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 539)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Replay)
        Me.Controls.Add(Me.Quit)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "YouDieForm"
        Me.Text = "YouDieForm"
        CType(Me.Quit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Quit As System.Windows.Forms.PictureBox
    Friend WithEvents Replay As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
