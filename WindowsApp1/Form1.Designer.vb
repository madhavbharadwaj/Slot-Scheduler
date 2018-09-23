<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pwdLabel = New System.Windows.Forms.Label()
        Me.usnText = New System.Windows.Forms.TextBox()
        Me.usnLabel = New System.Windows.Forms.Label()
        Me.pwText = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Black
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(132, 176)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "LOGIN"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Black
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(236, 176)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(83, 37)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "CANCEL"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'pwdLabel
        '
        Me.pwdLabel.AutoSize = True
        Me.pwdLabel.BackColor = System.Drawing.Color.Transparent
        Me.pwdLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pwdLabel.ForeColor = System.Drawing.Color.White
        Me.pwdLabel.Location = New System.Drawing.Point(81, 104)
        Me.pwdLabel.Name = "pwdLabel"
        Me.pwdLabel.Size = New System.Drawing.Size(116, 23)
        Me.pwdLabel.TabIndex = 0
        Me.pwdLabel.Text = "Password :"
        '
        'usnText
        '
        Me.usnText.Location = New System.Drawing.Point(208, 53)
        Me.usnText.Name = "usnText"
        Me.usnText.Size = New System.Drawing.Size(160, 20)
        Me.usnText.TabIndex = 1
        '
        'usnLabel
        '
        Me.usnLabel.AutoSize = True
        Me.usnLabel.BackColor = System.Drawing.Color.Transparent
        Me.usnLabel.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usnLabel.ForeColor = System.Drawing.Color.White
        Me.usnLabel.Location = New System.Drawing.Point(81, 50)
        Me.usnLabel.Name = "usnLabel"
        Me.usnLabel.Size = New System.Drawing.Size(121, 23)
        Me.usnLabel.TabIndex = 0
        Me.usnLabel.Text = "Username :"
        '
        'pwText
        '
        Me.pwText.Location = New System.Drawing.Point(208, 107)
        Me.pwText.Name = "pwText"
        Me.pwText.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.pwText.Size = New System.Drawing.Size(160, 20)
        Me.pwText.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(814, 470)
        Me.ControlBox = False
        Me.Controls.Add(Me.pwText)
        Me.Controls.Add(Me.usnLabel)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.usnText)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.pwdLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.Text = "Slot Booking"
        Me.TransparencyKey = System.Drawing.Color.Maroon
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents pwdLabel As Label
    Friend WithEvents usnText As TextBox
    Friend WithEvents usnLabel As Label
    Friend WithEvents pwText As TextBox
End Class
