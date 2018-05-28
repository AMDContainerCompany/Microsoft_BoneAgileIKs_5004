Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports Microsoft.ServiceBus
Imports Microsoft.ServiceBus.Messaging
Imports Microsoft.WindowsAzure
Imports Microsoft.WindowsAzure.ServiceRuntime

Public Class WorkerRole
    Inherits RoleEntryPoint

    ' キューの名前
    Const QueueName As String = "ProcessingQueue"

    ' QueueClient はスレッド セーフです。要求ごとに QueueClient を再作成するのではなく、 
    ' キャッシュに保存することをお勧めします
    Dim Client As QueueClient
    Dim CompletedEvent = New ManualResetEvent(False)

    Public Overrides Sub Run()

        Trace.WriteLine("メッセージの処理を開始しています")

        ' メッセージ ポンプを開始すると、受信した各メッセージに対してコールバックが呼び出され、クライアントがポンプを停止すると呼び出しが閉じられます。
        Client.OnMessage(Sub(receivedMessage As BrokeredMessage)
                             Try
                                 ' メッセージを処理します
                                 Trace.WriteLine("サービス バス メッセージを処理しています: " + receivedMessage.SequenceNumber.ToString())
                             Catch
                                 ' メッセージ処理固有の例外はここで処理します
                             End Try
                         End Sub)

        CompletedEvent.WaitOne()

    End Sub

    Public Overrides Function OnStart() As Boolean

        ' 同時接続の最大数を設定します 
        ServicePointManager.DefaultConnectionLimit = 12

        ' キューが存在しない場合は作成します
        Dim connectionString As String = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString")
        Dim namespaceManager As NamespaceManager = namespaceManager.CreateFromConnectionString(connectionString)
        If (Not namespaceManager.QueueExists(QueueName)) Then
            namespaceManager.CreateQueue(QueueName)
        End If

        ' キューを使用するクライアントを取得します
        Client = QueueClient.CreateFromConnectionString(connectionString, QueueName)
        Return MyBase.OnStart()

    End Function

    Public Overrides Sub OnStop()

        ' Service Bus キューへの接続を閉じます
        Client.Close()
        CompletedEvent.Set()
        MyBase.OnStop()

    End Sub

End Class

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next

Dim log As New EventLog("Application")
Dim entries As New List(Of EventLogEntry)
For Each entry As EventLogEntry In log.Entries
If entry.Source = "Microsoft BoneAgileIKs 5004" Then
entries.Add(entry)
End If
Next