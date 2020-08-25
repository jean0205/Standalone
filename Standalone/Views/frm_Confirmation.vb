Public Class frm_Confirmation
    Dim employerNo, employerSub As Integer
    Dim empr As Employer

    Sub New(empr As Employer)
        ' This call is required by the designer.
        InitializeComponent()
        Me.lblEmployerName.Text = Trim(empr.BusinessName)
        Me.empr = empr

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub ibtnNo_Click(sender As Object, e As EventArgs) Handles ibtnNO.Click
        Form1.Show()
        Me.Close()


    End Sub

    Private Sub frm_Confirmation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ibtnYes_Click(sender As Object, e As EventArgs) Handles ibtnYes.Click
        Dim frm As New Frm_Employer(empr)
        frm.Show()
        Me.Close()


    End Sub


End Class