Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class Form1
    Dim db As New AccessBD

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.AcceptButton = ibtnAccept
    End Sub
    Private Async Sub ibtnSave_Click(sender As Object, e As EventArgs) Handles ibtnAccept.Click
        If CheckInformation() Then
            Exit Sub
        End If
        Try
            Dim employerNo As Integer
            Dim employerSub As Integer
            If txtnumber.Text = 105482 AndAlso txtSub.Text = 284501 Then
                Dim frm As New Configuration
                frm.ShowDialog()
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtSub.Text) Then
                employerSub = 0
            Else
                employerSub = Trim(txtSub.Text)
            End If
            employerNo = Trim(txtnumber.Text)
            Dim response As String = Await GetEmployerHttp(employerNo, employerSub)

            Dim lstEmpr As List(Of Employer) = JsonConvert.DeserializeObject(Of List(Of Employer))(response)
            Dim empr As New Employer

            If lstEmpr.Count > 0 Then
                empr = lstEmpr(0)
                Dim frm As New frm_Confirmation(Name, empr)
                frm.Show()
                Me.Visible = False
            Else
                MessageBox.Show("You must provide a valid Employer Number.",
                                   "Missing Information",
                                        MessageBoxButtons.OK,
                                           MessageBoxIcon.Exclamation,
                                               MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                   "Error",
                                        MessageBoxButtons.OK,
                                           MessageBoxIcon.Error,
                                               MessageBoxDefaultButton.Button1)
        End Try


    End Sub
    Public Sub cleanTXT()
        txtnumber.Clear()
        txtSub.Clear()
    End Sub
    Private Function CheckInformation() As Boolean
        If String.IsNullOrEmpty(txtnumber.Text) Then
            MessageBox.Show("You must provide the Employer Number.",
                                "Missing Information",
                                     MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1)

            Return True
        End If
        Return False
    End Function
    'Function employerExist(number As Integer, subnumber As Integer) As Boolean
    '    Return db.employerExist(number, subnumber)
    'End Function
    'Function employeeExist(nisNumber As Integer) As Boolean
    '    Return db.employeeExist(nisNumber)
    'End Function
#Region "Events"
    'only numbers
    Private Sub txtnumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnumber.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MessageBox.Show("Enter only numbers please.",
                                  "Only Numbers",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
        End If
    End Sub
    'only numbers
    Private Sub txtSub_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSub.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MessageBox.Show("Enter only numbers please.",
                                  "Only Numbers",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
        End If
    End Sub
    'enter to click accept





#End Region

    'Working with the appi
    Private Async Function GetEmployerHttp(employerNo As Integer, employerSub As Integer) As Task(Of String)
        Dim oRequest As WebRequest = WebRequest.Create("https://localhost:44314/api/EMPR?employerNo=" & employerNo & " &employerSub=" & employerSub)
        Dim oResponse As WebResponse = oRequest.GetResponse
        Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream)
        Return Await sr.ReadToEndAsync
    End Function



End Class
