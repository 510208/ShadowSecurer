Imports System.IO

Public Class main
    Dim vdiskHave As Boolean
    Dim vdiskHaveStr As Long
    Dim passwordText As String
    Public vdiskUnlocked As Boolean = False

    Private Sub main_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If vdiskHave = False Then
            Dim ask As Long = MsgBox("尚未創建新磁碟機，是否要創建新虛擬磁碟機？", vbQuestion + vbYesNo)
            If ask = vbYes Then
                setNew.Show()
                Me.Close()
                btnCreateDisk.Enabled = True
                btnDecryptDisk.Enabled = False
                btnLockDisk.Enabled = False
                btnDeleteDisk.Enabled = False
            Else
                End
            End If
        Else
            btnCreateDisk.Enabled = False
            btnDecryptDisk.Enabled = Not vdiskUnlocked
            btnLockDisk.Enabled = vdiskUnlocked
            btnDeleteDisk.Enabled = vdiskUnlocked
        End If
    End Sub

    Private Sub main_Load(sender As Object, e As EventArgs) Handles Me.Load
        vdiskHave = FolderExists("C:\RECYCLE\Drives\{25336920-03F9-11CF-8FD0-00AA00686F13}")
        If vdiskHave = False Then
            vdiskHaveStr = 1
        Else
            vdiskHaveStr = 2
        End If
        lblVdiskInfo.Text = lblVdiskInfo.Text & Choose(vdiskHaveStr, "尚未創建磁碟機", "已經創建磁碟機")
        passwordText = setNew.ReadPasswordFromIni
        setNew.Icon = Me.Icon
        AboutBox1.Icon = Me.Icon
    End Sub

    Private Sub btnDecryptDisk_Click(sender As Object, e As EventArgs) Handles btnDecryptDisk.Click
        Dim userKeyin As String = InputBox("請輸入密碼", "ShadowSecurer 解密套件")
        If userKeyin = passwordText Then
            hiddenDiskBAT()
            If Directory.Exists("W:/") Then
                vdiskUnlocked = True
            Else
                vdiskUnlocked = False
            End If
            btnLockDisk.Enabled = vdiskUnlocked
            btnDecryptDisk.Enabled = Not vdiskUnlocked
            btnDeleteDisk.Enabled = vdiskUnlocked
        Else
            MsgBox("密碼錯誤！", vbExclamation)
        End If
    End Sub

    Private Sub btnLockDisk_Click(sender As Object, e As EventArgs) Handles btnLockDisk.Click
        hiddenDiskBAT()
        If Not (Directory.Exists("W:/")) Then
            vdiskUnlocked = False
            btnLockDisk.Enabled = vdiskUnlocked
            btnDecryptDisk.Enabled = Not vdiskUnlocked
            btnDeleteDisk.Enabled = vdiskUnlocked
            Return
        End If
        hiddenDiskBAT()
        btnLockDisk.Enabled = vdiskUnlocked
        btnDecryptDisk.Enabled = Not vdiskUnlocked
        btnDeleteDisk.Enabled = vdiskUnlocked
    End Sub

    Private Sub btnDeleteDisk_Click(sender As Object, e As EventArgs) Handles btnDeleteDisk.Click
        Dim pwd As String = InputBox("請輸入密碼驗證身分")
        If pwd <> passwordText Then
            MsgBox("密碼錯誤，請輸入正確密碼繼續！", vbExclamation)
            Return
        End If
        If InputBox("請注意！如果您繼續，原本儲存在虛擬磁碟機內的資料將會永遠消失(很久！)" & vbCrLf & "如果確定，請在底下框中鍵入'ICheck'繼續") = "ICheck" Then
            My.Computer.FileSystem.DeleteDirectory("C:\RECYCLE\Drives\{25336920-03F9-11CF-8FD0-00AA00686F13}", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
            My.Computer.FileSystem.DeleteDirectory("C:\RECYCLE", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
            My.Computer.FileSystem.DeleteFile(AppDomain.CurrentDomain.BaseDirectory & "info.uset", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.ThrowException)
            MsgBox("刪除完成！請重啟軟體", vbInformation)
            End
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AboutBox1.Show()
    End Sub

    Private Sub main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Select Case MsgBox("關閉後將會隱藏虛擬磁碟機，是否要關閉？", vbQuestion + vbYesNo)
            Case MsgBoxResult.Yes
                hiddenDiskBAT()
                If Not (Directory.Exists("W:/")) Then
                    vdiskUnlocked = False
                    btnLockDisk.Enabled = vdiskUnlocked
                    btnDecryptDisk.Enabled = Not vdiskUnlocked
                    btnDeleteDisk.Enabled = vdiskUnlocked
                    Return
                End If
                hiddenDiskBAT()
                btnLockDisk.Enabled = vdiskUnlocked
                btnDecryptDisk.Enabled = Not vdiskUnlocked
                btnDeleteDisk.Enabled = vdiskUnlocked
                End
            Case MsgBoxResult.No
                e.Cancel = True
                Return
        End Select
    End Sub
End Class
