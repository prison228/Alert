<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AlertRegister
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmbHour = New System.Windows.Forms.ComboBox()
        Me.cmbMinute = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbDate = New System.Windows.Forms.ComboBox()
        Me.txtMsg = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbHour
        '
        Me.cmbHour.FormattingEnabled = True
        Me.cmbHour.Location = New System.Drawing.Point(46, 85)
        Me.cmbHour.Name = "cmbHour"
        Me.cmbHour.Size = New System.Drawing.Size(72, 20)
        Me.cmbHour.TabIndex = 0
        Me.cmbHour.Text = "1"
        '
        'cmbMinute
        '
        Me.cmbMinute.FormattingEnabled = True
        Me.cmbMinute.Location = New System.Drawing.Point(142, 85)
        Me.cmbMinute.Name = "cmbMinute"
        Me.cmbMinute.Size = New System.Drawing.Size(72, 20)
        Me.cmbMinute.TabIndex = 1
        Me.cmbMinute.Text = "20"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(124, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = ":"
        '
        'cmbDate
        '
        Me.cmbDate.FormattingEnabled = True
        Me.cmbDate.Location = New System.Drawing.Point(46, 59)
        Me.cmbDate.Name = "cmbDate"
        Me.cmbDate.Size = New System.Drawing.Size(168, 20)
        Me.cmbDate.TabIndex = 3
        Me.cmbDate.Text = "2017/8/5"
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(46, 111)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.Size = New System.Drawing.Size(168, 95)
        Me.txtMsg.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Controls.Add(Me.txtMsg)
        Me.Panel1.Controls.Add(Me.btnRegister)
        Me.Panel1.Controls.Add(Me.cmbDate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbMinute)
        Me.Panel1.Controls.Add(Me.cmbHour)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 237)
        Me.Panel1.TabIndex = 2
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(139, 212)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "終了"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(46, 212)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(72, 23)
        Me.btnRegister.TabIndex = 1
        Me.btnRegister.Text = "登録"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(103, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "登録完了"
        '
        'AlertRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "AlertRegister"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbHour As ComboBox
    Friend WithEvents cmbMinute As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbDate As ComboBox
    Friend WithEvents txtMsg As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnRegister As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnExit As Button
    Friend WithEvents Label2 As Label
End Class
