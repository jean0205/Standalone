Imports System.IO

Public Class Configuration
    Dim db As New AccessBD
    Dim db2 As New Database
    Private Sub ibtnUpdate_Click(sender As Object, e As EventArgs) Handles ibtnUpdate.Click
        Dim message As String = "Do you want to change the NIS Percentage?"
        Dim title As String = "Update Nis"
        Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
        Dim result As DialogResult = MessageBox.Show(message, title, buttons)
        If result = DialogResult.Yes Then
            Try
                Dim rate As Decimal = Convert.ToDecimal(txtRate.Text)
                db.UpdateNisRate(rate.ToString)
                MessageBox.Show("Nis Rate successfully updated.",
                                   "Update NIS",
                                        MessageBoxButtons.OK,
                                           MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1)

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub txtRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRate.KeyPress
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." AndAlso Not CType(sender, TextBox).Text.Contains(".") Then
            e.Handled = False
        Else
            e.Handled = True
            MessageBox.Show("Enter only numbers and dot please.",
                                   "Only Numbers",
                                        MessageBoxButtons.OK,
                                           MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1)
            txtRate.Text = db.getNISrate
        End If
    End Sub

    Private Sub Configuration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtRate.Text = db.getNISrate
    End Sub

    Private Sub Configuration_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Form1.cleanTXT()
    End Sub

    Private Sub ibtnBackUp_Click(sender As Object, e As EventArgs) Handles ibtnBackUp.Click
        db2.backupDB()

    End Sub

    Private Sub ibtnRestore_Click(sender As Object, e As EventArgs) Handles ibtnRestore.Click
        Dim ofd As OpenFileDialog = New OpenFileDialog
        ofd.DefaultExt = "BAK"
        ofd.FileName = "Upload file to data base"
        ofd.InitialDirectory = "c:\DataBase"
        ofd.Filter = "All files|*.*|BAK files|*.bak"
        ofd.Title = "Select file"
        If ofd.ShowDialog() <> DialogResult.Cancel Then
            Dim fdirectory As New FileInfo(ofd.FileName)
            Dim fName As New FileInfo(ofd.FileName)
            Dim folder As String = fdirectory.Directory.ToString()
            Dim name As String = fName.Name
            Try
                Timer1.Enabled = True
                db2.RestoreDB(ofd.FileName)
            Catch ex As Exception
                MessageBox.Show(ex.Message,
                                 "Error",
                                      MessageBoxButtons.OK,
                                         MessageBoxIcon.Information,
                                             MessageBoxDefaultButton.Button1)
            End Try


        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            MessageBox.Show("Data Base successfully restored.",
                                  "Error",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
    End Sub
End Class