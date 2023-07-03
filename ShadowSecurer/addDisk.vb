Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Public Class addDisk
    Dim pwdOK As Boolean

    Private Function WritePrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpString As String,
        ByVal lpFileName As String
    ) As Integer
    End Function

    Private Function GetPrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpDefault As String,
        ByVal lpReturnedString As String,
        ByVal nSize As Integer,
        ByVal lpFileName As String
    ) As Integer
    End Function

    Sub WriteToIniFile(ByVal diskName As String, ByVal vDiskCode As String, ByVal password As String)
        Dim iniFilePath As String = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.ini")

        WritePrivateProfileString("Settings", "DiskName", diskName, iniFilePath)
        WritePrivateProfileString("Settings", "VDiskCode", vDiskCode, iniFilePath)
        WritePrivateProfileString("Settings", "Password", password, iniFilePath)
    End Sub

    Sub ReadFromIniFile()
        Dim iniFilePath As String = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "settings.ini")

        Dim diskName As String = New String(" "c, 255)
        Dim vDiskCode As String = New String(" "c, 255)
        Dim password As String = New String(" "c, 255)

        GetPrivateProfileString("Settings", "DiskName", "", diskName, diskName.Length, iniFilePath)
        GetPrivateProfileString("Settings", "VDiskCode", "", vDiskCode, vDiskCode.Length, iniFilePath)
        GetPrivateProfileString("Settings", "Password", "", password, password.Length, iniFilePath)

        cbbDiskName.SelectedText = diskName.Trim()
        cbbVDiskCode.SelectedText = vDiskCode.Trim()
        txtPassword.Text = password.Trim()
    End Sub

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'If Not (AreControlsSet()) Then
        '    MsgBox("請將所有粗體部分都填寫好！！", vbExclamation)
        '    Return
        'End If
        WriteToIniFile(cbbDiskName.SelectedText, cbbVDiskCode.SelectedText, txtPassword.Text)
        hiddenDiskBAT()
        MsgBox("請確認虛擬儲存空間是否成功創建", vbInformation)
    End Sub

    Private Sub addDisk_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        On Error Resume Next
        ReadFromIniFile()
    End Sub

    Function AreControlsSet() As Boolean
        Dim diskName As String = cbbDiskName.SelectedText.Trim()
        Dim vDiskCode As String = cbbVDiskCode.SelectedText.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If Not String.IsNullOrEmpty(diskName) AndAlso
           Not String.IsNullOrEmpty(vDiskCode) AndAlso
           Not String.IsNullOrEmpty(password) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class