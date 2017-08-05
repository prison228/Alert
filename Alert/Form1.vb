Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dtToday As DateTime = DateTime.Today
        Dim Today As String = ComboBox3.Text + "/" + ComboBox1.Text + "/" + ComboBox2.Text
        If (dtToday = Today) Then
            MsgBox(dtToday + TextBox1.Text)
        End If
    End Sub

End Class
