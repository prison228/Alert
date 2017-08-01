Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("テスト")
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim dtToday As DateTime = DateTime.Today
        'ComboBox3.Text And ComboBox1.Text And ComboBox2.Text = dtToday

    End Sub
End Class
