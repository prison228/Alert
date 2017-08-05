Public Class AlertListForm

    'アラート情報ファイルのパス
    Dim ALERT_DATA_FILE_PATH As String = "C:\Users\daiki228\Source\Repos\Alert\Alert\Data\AlertData.csv"

    'アラート情報ファイル読み書き時の文字エンコード
    Dim ALERT_DATA_FILE_ENCODE As String = "shift_jis"

    '*******************************************************************
    '*フォームロード時実行
    '*******************************************************************
    Private Sub AlertListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '--------------------------------------------------------------------
        'アラート設定情報の読み込み
        '--------------------------------------------------------------------

        '"C:\test\1.txt"をShift-JISコードとして開く
        Dim sr As New System.IO.StreamReader(
            ALERT_DATA_FILE_PATH, '読み込むファイルのパス
            System.Text.Encoding.GetEncoding(ALERT_DATA_FILE_ENCODE) '文字エンコード指定
        )

        'ファイルの末尾まで1行ずつ読み込み、終端に達したら終了
        While (sr.Peek() <> -1)
            'ファイルから1行読み込む
            Dim s As String = sr.ReadLine()

            '--------------------------------------------------------------------
            'アラート設定情報を各コントロールに設定
            '--------------------------------------------------------------------
            Dim tmpAlertData As String() = Split(s, ",")
            Dim alertDateTime As String = tmpAlertData(0)
            Dim alertMsg As String = tmpAlertData(1)

            Dim tmpAlertDateTime As String() = Split(alertDateTime, " ")
            Dim alertDate As String = tmpAlertDateTime(0)
            Dim alertTime As String = tmpAlertDateTime(1)

            lstDate.Items.Add(alertDate)
            lstTime.Items.Add(alertTime)
            lstMsg.Items.Add(alertMsg)

        End While

        '閉じる
        sr.Close()
    End Sub

    Private Sub lstAlertData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstDate.SelectedIndexChanged, lstMsg.SelectedIndexChanged, lstTime.SelectedIndexChanged
        Dim lst As ListBox = CType(sender, ListBox)

        lstDate.SelectedIndex = lst.SelectedIndex
        lstTime.SelectedIndex = lst.SelectedIndex
        lstMsg.SelectedIndex = lst.SelectedIndex
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Visible = False
        Dim alertRegisterForm As AlertRegisterForm = New AlertRegisterForm()
        alertRegisterForm.Visible = True
    End Sub

    '*******************************************************************
    '*タイマー処理 1秒ごとに呼ばれる
    '*******************************************************************
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        '--------------------------------------------------------------------
        'アラート情報のメッセージ表示
        '--------------------------------------------------------------------
        '現在日時を取得
        Dim currentDateTime As DateTime = DateTime.Now

        For i = 0 To lstDate.Items.Count - 1
            Dim alertDate As String = CType(lstDate.Items.Item(i), String)
            Dim alertTime As String = CType(lstTime.Items.Item(i), String)
            Dim alertMsg As String = CType(lstMsg.Items.Item(i), String)

            '画面に入力されているアラート日時を取得し、DateTime型に変換
            Dim alertDateTime As DateTime = DateTime.Parse(alertDate & " " & alertTime)

            '現在日時と画面に入力されているアラート日時を比較し、
            '該当日時であればメッセージを送信する
            If (currentDateTime.Year = alertDateTime.Year And
               currentDateTime.Month = alertDateTime.Month And
               currentDateTime.Day = alertDateTime.Day And
               currentDateTime.Hour = alertDateTime.Hour And
               currentDateTime.Minute = alertDateTime.Minute And
               currentDateTime.Second = 0) Then

                MsgBox(currentDateTime.ToString("yyyy/MM/dd HH:mm:ss.ff") + vbCrLf + alertMsg)
            End If
        Next

    End Sub

    Private Sub lstDate_DoubleClick(sender As Object, e As EventArgs) Handles lstDate.DoubleClick, lstTime.DoubleClick, lstMsg.DoubleClick
        Dim lst As ListBox = CType(sender, ListBox)

        Me.Visible = False
        Dim alertRegisterForm As AlertRegisterForm = New AlertRegisterForm(lstDate.Items.Item(lst.SelectedIndex), lstTime.Items.Item(lst.SelectedIndex), lstMsg.Items.Item(lst.SelectedIndex))
        alertRegisterForm.Visible = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class