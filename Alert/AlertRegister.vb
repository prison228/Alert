'現状
'メッセージ表示、タイマー処理 OK
'アラート設定情報ファイル読み込み(1行のみ) OK
'アラート設定情報ファイル書き込み(1行のみ) OK
'
'残作業
'アラート設定情報一覧画面作成
'アラート設定情報ファイル読み込み(複数行対応) 複数情報を設定した際に見れるようにしたい
'アラート設定情報ファイル書き込み(複数行対応) 問題:メッセージに改行が含まれるとうまく読み込めない
'アラート通知後、設定情報からデータを削除する
'削除機能の追加


'残作業(優先度低)
'ON・OFF機能の追加
'定期時間のアラート(曜日指定)


Public Class AlertRegister
    'アラート情報ファイルのパス
    Dim ALERT_DATA_FILE_PATH As String = "C:\Users\daiki228\Source\Repos\Alert\Alert\Data\AlertData.csv"

    'アラート情報ファイル読み書き時の文字エンコード
    Dim ALERT_DATA_FILE_ENCODE As String = "shift_jis"

    '*******************************************************************
    '*フォームロード時実行
    '*******************************************************************
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim btn As Button = New Button()
        btn.Size = New Size(75, 23)
        btn.Text = ""
        btn.Location = New Point(0, 0)
        Panel1.Controls.Add(btn)

        AddHandler btn.Click, Handle


        '--------------------------------------------------------------------
        'アラート設定情報の読み込み
        '--------------------------------------------------------------------
        '"C:\test\1.txt"をShift-JISコードとして開く
        Dim sr As New System.IO.StreamReader(
            ALERT_DATA_FILE_PATH, '読み込むファイルのパス
            System.Text.Encoding.GetEncoding(ALERT_DATA_FILE_ENCODE) '文字エンコード指定
        )
        '内容をすべて読み込む
        Dim s As String = sr.ReadLine()

        '閉じる
        sr.Close()

        '--------------------------------------------------------------------
        'アラート設定情報を各コントロールに設定
        '--------------------------------------------------------------------
        Dim tmpAlertData As String() = Split(s, ",")
        Dim alertDateTime As String = tmpAlertData(0)
        Dim alertMsg As String = tmpAlertData(1)

        Dim tmpAlertDateTime As String() = Split(alertDateTime, " ")
        Dim alertDate As String = tmpAlertDateTime(0)
        Dim alertTime As String = tmpAlertDateTime(1)

        Dim tmpAlertTime As String() = Split(alertTime, ":")
        Dim alertTimeHour As String = tmpAlertTime(0)
        Dim alertTimeMinute As String = tmpAlertTime(1)

        cmbDate.Text = alertDate
        cmbHour.Text = alertTimeHour
        cmbMinute.Text = alertTimeMinute
        txtMsg.Text = alertMsg

    End Sub
    '*******************************************************************
    '*タイマー処理 1秒ごとに呼ばれる
    '*******************************************************************
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '--------------------------------------------------------------------
        'アラート情報のメッセージ表示
        '--------------------------------------------------------------------
        '現在日時を取得
        Dim currentDateTime As DateTime = DateTime.Now

        '画面に入力されているアラート日時を取得し、DateTime型に変換
        '
        Dim Tod As String = cmbDate.Text & " " & cmbHour.Text & ":" & cmbMinute.Text
        Dim alertDateTime As DateTime = DateTime.Parse(Tod)

        '現在日時と画面に入力されているアラート日時を比較し、
        '該当日時であればメッセージを送信する
        If (currentDateTime.Year = alertDateTime.Year And
           currentDateTime.Month = alertDateTime.Month And
           currentDateTime.Day = alertDateTime.Day And
           currentDateTime.Hour = alertDateTime.Hour And
           currentDateTime.Minute = alertDateTime.Minute And
           currentDateTime.Second = 0) Then

            MsgBox(currentDateTime.ToString("yyyy/mm/dd HH:MM:ss.ff") + vbCrLf + txtMsg.Text)
        End If
    End Sub
    '*******************************************************************
    '*登録ボタン押下時実行
    '*******************************************************************
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        '--------------------------------------------------------------------
        'アラート設定情報の書き込み(登録)
        '--------------------------------------------------------------------
        Dim Tod As String = cmbDate.Text & " " & cmbHour.Text & ":" & cmbMinute.Text
        Dim sw As New System.IO.StreamWriter(
            ALERT_DATA_FILE_PATH, '書き込み先ファイルパス
            True, '追記モード：True=追記, False=上書き
            System.Text.Encoding.GetEncoding(ALERT_DATA_FILE_ENCODE) '文字エンコード指定
        )
        'TextBox1.Textの内容を書き込む
        sw.WriteLine(Tod & "," & txtMsg.Text)
        '閉じる
        sw.Close()
    End Sub

    '*******************************************************************
    '*終了ボタン押下時実行
    '*******************************************************************
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '--------------------------------------------------------------------
    'デバッグ用
    '--------------------------------------------------------------------
    Private Sub DebugPrint(currentDateTime As DateTime, alertDateTime As DateTime)
        'Console.WriteLine("--------------------------")
        'Console.WriteLine(currentDateTime & " = " & alertDateTime)
        'Console.WriteLine(currentDateTime.Hour & " = " & alertDateTime.Hour)
        'Console.WriteLine(currentDateTime.Minute & " = " & alertDateTime.Minute)
        'Console.WriteLine(currentDateTime.Second & " = " & alertDateTime.Second)
        'Console.WriteLine(currentDateTime.Millisecond & " = " & alertDateTime.Millisecond)
    End Sub
End Class
