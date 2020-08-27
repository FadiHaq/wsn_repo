<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.components = New System.ComponentModel.Container()
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnRead = New System.Windows.Forms.Button()
        Me.Received = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'timer1
        '
        Me.timer1.Interval = 500
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(160, 48)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(75, 23)
        Me.btnRead.TabIndex = 0
        Me.btnRead.Text = "Button1"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'Received
        '
        Me.Received.Location = New System.Drawing.Point(140, 128)
        Me.Received.Name = "Received"
        Me.Received.Size = New System.Drawing.Size(100, 20)
        Me.Received.TabIndex = 1
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Received)
        Me.Controls.Add(Me.btnRead)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnRead As System.Windows.Forms.Button
    Friend WithEvents Received As System.Windows.Forms.TextBox
End Class
