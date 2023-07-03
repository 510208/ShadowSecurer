<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblVdiskInfo = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCreateDisk = New System.Windows.Forms.Button()
        Me.btnDecryptDisk = New System.Windows.Forms.Button()
        Me.btnLockDisk = New System.Windows.Forms.Button()
        Me.btnDeleteDisk = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVdiskInfo
        '
        Me.lblVdiskInfo.AutoSize = True
        Me.lblVdiskInfo.Location = New System.Drawing.Point(187, 9)
        Me.lblVdiskInfo.Name = "lblVdiskInfo"
        Me.lblVdiskInfo.Size = New System.Drawing.Size(101, 12)
        Me.lblVdiskInfo.TabIndex = 0
        Me.lblVdiskInfo.Text = "虛擬磁碟狀態(&I)："
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(181, 145)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btnCreateDisk
        '
        Me.btnCreateDisk.Location = New System.Drawing.Point(187, 111)
        Me.btnCreateDisk.Name = "btnCreateDisk"
        Me.btnCreateDisk.Size = New System.Drawing.Size(140, 23)
        Me.btnCreateDisk.TabIndex = 2
        Me.btnCreateDisk.Text = "創建新虛擬磁碟(&C)"
        Me.btnCreateDisk.UseVisualStyleBackColor = True
        '
        'btnDecryptDisk
        '
        Me.btnDecryptDisk.Location = New System.Drawing.Point(189, 53)
        Me.btnDecryptDisk.Name = "btnDecryptDisk"
        Me.btnDecryptDisk.Size = New System.Drawing.Size(140, 23)
        Me.btnDecryptDisk.TabIndex = 3
        Me.btnDecryptDisk.Text = "解鎖虛擬磁碟(&U)"
        Me.btnDecryptDisk.UseVisualStyleBackColor = True
        '
        'btnLockDisk
        '
        Me.btnLockDisk.Location = New System.Drawing.Point(238, 82)
        Me.btnLockDisk.Name = "btnLockDisk"
        Me.btnLockDisk.Size = New System.Drawing.Size(140, 23)
        Me.btnLockDisk.TabIndex = 4
        Me.btnLockDisk.Text = "鎖定虛擬磁碟(&L)"
        Me.btnLockDisk.UseVisualStyleBackColor = True
        '
        'btnDeleteDisk
        '
        Me.btnDeleteDisk.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDeleteDisk.Location = New System.Drawing.Point(384, 82)
        Me.btnDeleteDisk.Name = "btnDeleteDisk"
        Me.btnDeleteDisk.Size = New System.Drawing.Size(140, 23)
        Me.btnDeleteDisk.TabIndex = 7
        Me.btnDeleteDisk.Text = "刪除虛擬磁碟(&D)"
        Me.btnDeleteDisk.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(189, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "關於(&A)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 145)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnDeleteDisk)
        Me.Controls.Add(Me.btnLockDisk)
        Me.Controls.Add(Me.btnDecryptDisk)
        Me.Controls.Add(Me.btnCreateDisk)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblVdiskInfo)
        Me.Name = "main"
        Me.Text = "ShadowSecurer"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblVdiskInfo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCreateDisk As System.Windows.Forms.Button
    Friend WithEvents btnDecryptDisk As System.Windows.Forms.Button
    Friend WithEvents btnLockDisk As System.Windows.Forms.Button
    Friend WithEvents btnDeleteDisk As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
