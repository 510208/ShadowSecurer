Imports System.IO

Module hiddenDisk
    Sub hiddenDiskBAT()
        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "system_fuct.bat")

        ' 检查并删除现有的bat文件
        If File.Exists(tempPath) Then
            File.Delete(tempPath)
        End If

        ' 创建 system_fuct.bat 文件
        Using writer As New StreamWriter(tempPath)
            writer.WriteLine("@ECHO OFF")
            writer.WriteLine("MD C:\RECYCLE\Drives\{25336920-03F9-11CF-8FD0-00AA00686F13}>NUL")
            writer.WriteLine("IF EXIST W:NUL GOTO DELETE")
            writer.WriteLine("SUBST W: C:\RECYCLE\Drives\{25336920-03F9-11CF-8FD0-00AA00686F13}")
            writer.WriteLine("START W:")
            writer.WriteLine("EXIT")
            writer.WriteLine(":DELETE")
            writer.WriteLine("SUBST /D W:")
        End Using

        ' 运行bat文件
        Dim processInfo As New ProcessStartInfo()
        processInfo.FileName = tempPath
        processInfo.WindowStyle = ProcessWindowStyle.Hidden
        Process.Start(processInfo).WaitForExit()

        ' 删除bat文件
        File.Delete(tempPath)
    End Sub

    Function FolderExists(folderPath As String) As Boolean
        Return Directory.Exists(folderPath)
    End Function
End Module
