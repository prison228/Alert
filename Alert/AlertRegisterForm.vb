'現状
'メッセージ表示、タイマー処理 OK
'アラート設定情報ファイル読み込み(1行のみ) OK
'アラート設定情報ファイル書き込み(1行のみ) OK
'
'残作業(優先度高)
'更新・削除
'複数行を改行込み(カンマ)が入力されても読み込み出来るようにする。
'
'残作業
'アラート設定情報一覧画面作成
'アラート設定情報ファイル読み込み(複数行対応) 複数情報を設定した際に見れるようにしたい
'アラート設定情報ファイル書き込み(複数行対応) 問題:メッセージに改行が含まれるとうまく読み込めない
'アラート通知後、設定情報からデータを削除する
'削除機能の追加
'
'残作業(優先度低)
'ON・OFF機能の追加
'定期時間のアラート(曜日指定)
'Windows起動時の起動

Public Class AlertRegisterForm
    'アラート情報ファイルのパス
    Dim ALERT_DATA_FILE_PATH As String = "C:\Users\daiki228\Source\Repos\Alert\Alert\Data\AlertData.csv"

    'アラート情報ファイル読み書き時の文字エンコード
    Dim ALERT_DATA_FILE_ENCODE As String = "shift_jis"

    Public Sub New()
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。
    End Sub

    Public Sub New(alertDate As String, alertTime As String, alertMsg As String)
        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()
        ' InitializeComponent() 呼び出しの後で初期化を追加します。

        Dim tmpAlertTime As String() = Split(alertTime, ":")
        Dim alertTimeHour As String = tmpAlertTime(0)
        Dim alertTimeMinute As String = tmpAlertTime(1)

        dtpAlertDate.Text = alertDate
        cmbTimeHour.Text = alertTimeHour
        cmbTimeMinute.Text = alertTimeMinute
        txtMsg.Text = alertMsg

    End Sub

    '*******************************************************************
    '*フォームロード時実行
    '*******************************************************************
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i = 0 To 23
            cmbTimeHour.Items.Add(i)
        Next

        For i = 0 To 59
            cmbTimeMinute.Items.Add(i)
        Next

    End Sub

    '*******************************************************************
    '*登録ボタン押下時実行
    '*******************************************************************
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        '--------------------------------------------------------------------
        'アラート設定情報の書き込み(登録)
        '--------------------------------------------------------------------
        Dim Tod As String = dtpAlertDate.Value.ToString("yyyy/MM/dd") & " " & cmbTimeHour.Text & ":" & cmbTimeMinute.Text
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
    '*戻るボタン押下時実行
    '*******************************************************************
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        AlertListForm.Visible = True
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
