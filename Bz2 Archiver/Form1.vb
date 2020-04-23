Public Class Form1
    Dim filenum As Int64
    Dim outpath, inpath As String
    Dim shit

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OpenFileDialog2.Filter = "All files | *.*" 'это что бля такое this is khorosho (no)   input flies
        ' If OpenFileDialog2.ShowDialog = DialogResult.OK Then

        ' TextBox1.Text = OpenFileDialog2.FileName
        ' End I
        If OpenFileDialog2.ShowDialog = DialogResult.OK Then
            shit = OpenFileDialog2.FileNames
            filenum = shit.GetUpperBound(0) + 1
            For i = 1 To filenum
                TextBox1.Text += shit(i - 1) + vbCrLf
            Next
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OpenFileDialog1.Filter = "7zip | 7z.exe"  'fucking 7zip
        OpenFileDialog1.InitialDirectory = "C:\Program Files\7-Zip"
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TextBox4.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then 'бля буду, папка вывода
            outpath = FolderBrowserDialog1.SelectedPath
            TextBox2.Text = outpath
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim pinfo As New ProcessStartInfo() 'аааааааааааааабля
        pinfo.FileName = TextBox4.Text
        For i = 1 To filenum
            pinfo.Arguments = "a " + outpath_gen(i) + " " + shit(i - 1)
            Dim p As Process = Process.Start(pinfo)
            p.WaitForExit()
        Next i
        MsgBox("Complete!")
    End Sub


    Public Function outpath_gen(ByVal fileindex)
        Dim output As String
        output = outpath + finder_slash(fileindex) + ".bz2"
        Return output
    End Function

    Public Function finder_slash(ByVal i)

        Dim filename
        Dim fuck = 0
        Dim slashpos, slashback As Int32

        Do While fuck = 0
            slashback = slashpos
            slashpos = InStr(slashpos + 1, shit(i - 1), "\")
            If slashpos = 0 Then fuck = 1
        Loop

        filename = Mid(shit(i - 1), slashback)
        Return filename

    End Function
End Class
