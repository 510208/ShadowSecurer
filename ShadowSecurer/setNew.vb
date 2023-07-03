Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Text

Public Class setNew

    Dim pwdOK As Boolean = False

    Private Sub txtPwdCheck_TextChanged(sender As Object, e As EventArgs) Handles txtPwdCheck.TextChanged
        If txtPwdCheck.Text = txtPassword.Text Then
            lblCheckingInfo.Text = "密碼一致"
            If txtPassword.Text = "" Or txtPwdCheck.Text = "" Then
                lblCheckingInfo.Text = "尚未輸入"
            End If
        Else
            lblCheckingInfo.Text = "密碼不一致"
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPwdCheck.Text = txtPassword.Text Then
            lblCheckingInfo.Text = "密碼一致"
            pwdOK = True
            If txtPassword.Text = "" Or txtPwdCheck.Text = "" Then
                lblCheckingInfo.Text = "尚未輸入"
                pwdOK = False
            End If
        Else
            lblCheckingInfo.Text = "密碼不一致"
            pwdOK = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        WritePasswordToIni(txtPassword.Text)
        hiddenDiskBAT()
        main.lblVdiskInfo.Text = "已經創建磁碟機"
        main.Show()
        MsgBox("成功創建磁碟機，請重啟軟體以檢視磁碟機狀態", vbInformation)
        End
    End Sub

    Sub WritePasswordToIni(ByVal password As String)
        ' 使用UTF8编码将密码转换为字节数组
        Dim passwordBytes As Byte() = Encoding.UTF8.GetBytes(password)

        ' 对密码进行Base64编码
        Dim encryptedPassword As String = Convert.ToBase64String(passwordBytes)

        ' 获取软件所在目录的路径
        Dim softwareDirectory As String = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)

        ' 拼接info.uset的完整路径
        Dim infoFilePath As String = Path.Combine(softwareDirectory, "info.uset")

        ' 删除现有info.uset文件
        If File.Exists(infoFilePath) Then
            File.Delete(infoFilePath)
        End If

        ' 将加密后的密码写入info.uset文件
        File.WriteAllText(infoFilePath, encryptedPassword)
    End Sub



    Function ReadPasswordFromIni() As String
        ' 获取软件所在目录的路径
        Dim softwareDirectory As String = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)

        ' 拼接info.txt的完整路径
        Dim infoFilePath As String = Path.Combine(softwareDirectory, "info.uset")

        ' 检查info.txt文件是否存在
        If File.Exists(infoFilePath) Then
            ' 更改文件扩展名为.uset
            Dim newFilePath As String = Path.ChangeExtension(infoFilePath, "txt")

            ' 检查目标文件是否存在，如果存在则删除
            If File.Exists(newFilePath) Then
                File.Delete(newFilePath)
            End If

            ' 移动文件
            File.Move(infoFilePath, newFilePath)

            ' 读取加密的密码
            Dim encryptedPassword As String = File.ReadAllText(newFilePath)

            ' 对密码进行Base64解码
            Dim passwordBytes As Byte() = Convert.FromBase64String(encryptedPassword)

            ' 使用UTF8解码将密码转换为字符串
            Dim password As String = Encoding.UTF8.GetString(passwordBytes)

            ' 再次將檔名改回uset
            File.Move(newFilePath, infoFilePath)

            Return password
        Else
            Return ""
        End If
    End Function

End Class