Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Form2
    Private Async Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim response As String = Await GetHttp()
        Dim lst As List(Of TestViewModel)
        lst = JsonConvert.DeserializeObject(Of List(Of TestViewModel))(response)
        DataGridView1.DataSource = lst

    End Sub
    Private Async Function GetHttp() As Task(Of String)
        Dim oRequest As WebRequest = WebRequest.Create("https://localhost:44300/api/Test/" & 1)
        Dim oResponse As WebResponse = oRequest.GetResponse
        Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream)
        Return Await sr.ReadToEndAsync
    End Function
End Class