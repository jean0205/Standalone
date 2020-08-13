Imports System.Diagnostics.Eventing.Reader
Imports System.Globalization
Imports System.IO
Imports System.Net
Imports System.Xml
Imports Microsoft.VisualBasic.CompilerServices
Imports Newtonsoft.Json
Imports System.ComponentModel


Public Class Frm_Employer
    Dim db As New AccessBD
    Dim empr As New Employer
    Dim empe As New Employee
    Dim isUpdating As Boolean = False
    Dim id As Integer
    Dim oth As New Others
    Dim remittanceSent As Boolean = False


    Sub New(empr As Employer)

        ' This call is required by the designer.
        InitializeComponent()
        Me.empr = empr
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub Frm_Employer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'db.ResetEarnings(empr.EmployerNo, empr.EmployerSub)
        'fill comboboxyears
        fillCmbYears()
        txtNumber.Text = empr.EmployerNo
        txtSub.Text = empr.EmployerSub
        txtName.Text = empr.BusinessName
        txtEmail1.Text = Trim(empr.Email1.Replace(";", String.Empty))
        txtemail2.Text = Trim(empr.Email2.Replace(";", String.Empty))
        Me.AcceptButton = ibtnCheck
        loadRemittance()
        remittanceSent = False
        If String.IsNullOrEmpty(txtEmail1.Text) Then
            txtEmail1.BackColor = Color.LightGreen
        Else
            txtEmail1.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
        If String.IsNullOrEmpty(txtemail2.Text) Then
            txtemail2.BackColor = Color.LightGreen
        Else
            txtemail2.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If

    End Sub
    Private Sub Frm_Employer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not remittanceSent Then
            Dim message As String = "Do you want to close before send the Remittance Form ?" & vbCrLf & "The Earnings and Contributions information will be lost."
            Dim title As String = "Close Form"
            Dim buttons As MessageBoxButtons = MessageBoxButtons.YesNo
            Dim result As DialogResult = MessageBox.Show(message, title, buttons)
            If result = DialogResult.Yes Then

            Else
                e.Cancel = True
                Exit Sub
            End If

        End If
        Form1.Visible = True
        Form1.cleanTXT()
        Me.AcceptButton = ibtnCheck
    End Sub
    Private Async Sub ibtnCheck_Click(sender As Object, e As EventArgs) Handles ibtnCheck.Click
        If CheckInformation() Then
            Exit Sub
        End If
        Dim nisNumber = txtNisNumber.Text
        Try
            Dim response As String = Await GetEmployeeHttp(nisNumber)
            Dim lstEmpe As List(Of Employee) = JsonConvert.DeserializeObject(Of List(Of Employee))(response)
            Dim empe As New Employee

            If lstEmpe.Count > 0 Then
                empe = lstEmpe(0)
                'empe = db.getEmployeeInfo(nisNumber)
                Me.empe = empe
                txtEmployeeName.Text = empe.FirstName + " " + empe.Lastname + " " + empe.MaidenName
                Dim parish As String = String.Empty
                Select Case empe.Parish
                    Case "A"
                        parish = "ST ANDREW'S"
                    Case "C"
                        parish = "CARRIACOU"
                    Case "D"
                        parish = "ST DAVID'S"
                    Case "G"
                        parish = "ST GEORGE'S"
                    Case "J"
                        parish = "J"
                    Case "M"
                        parish = "ST JOHN'S"
                    Case "P"
                        parish = "ST PATRICK'S"
                    Case "PM"
                        parish = "PETITE MARTINIQUE"
                End Select
                txtEmployeeAddress.Text = empe.Address + ", " + empe.Twon + " " + parish
                Try
                    txtEmployeePhone.Text = String.Format("{0:###-####}", Long.Parse(empe.Phone))
                Catch ex As Exception
                    txtEmployeePhone.Text = String.Empty
                End Try
                dtpBOB.Value = empe.DateOB
                PanelEmployee2.Visible = True
                Try
                    PictureBox1.Image = Await GetImageHttp(nisNumber)
                Catch ex As Exception
                    PictureBox1.Image = Image.FromFile("noimages.jpg")
                End Try
            Else
                MessageBox.Show("NIS number does not exist. Please check and try again",
                                               "Wrong Number!",
                                                    MessageBoxButtons.OK,
                                                       MessageBoxIcon.Information,
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
    Private Sub ibtnAddEmployee_Click(sender As Object, e As EventArgs) Handles ibtnAddEmployee.Click
        PanelEmployee.Visible = True
        txtNisNumber.ReadOnly = False
        ClearEmployeePanel()
        txtNisNumber.Focus()
    End Sub
    Private Sub ibtnAccept_Click(sender As Object, e As EventArgs) Handles ibtnAccept.Click
        If CheckWeeksEarning() Then
            Exit Sub
        End If
        If cmbFrequence.SelectedIndex = 0 Or cmbMonth.SelectedIndex = 0 Then
            MessageBox.Show("Please select the Frequence and the Month to pay.",
                                 "Error",
                                      MessageBoxButtons.OK,
                                         MessageBoxIcon.Error,
                                             MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf getWeeks() = 0 Then
            MessageBox.Show("Please select the Worked Weeks.",
                                "Error",
                                     MessageBoxButtons.OK,
                                        MessageBoxIcon.Error,
                                            MessageBoxDefaultButton.Button1)
        ElseIf cmbFrequence.SelectedIndex = 1 Then
            Dim monthly As Boolean = True
            insertEmployeeDgvMonthly(monthly, 0)
            PanelEmployee.Visible = False
            ClearEmployeePanel()
        ElseIf cmbFrequence.SelectedIndex = 2 Then
            Dim monthly As Boolean = False
            Dim week As Integer = getWeeks()
            insertEmployeeDgvMonthly(monthly, week)
            PanelEmployee.Visible = False
            ClearEmployeePanel()
        End If
    End Sub
    Private Function WeeksWorked(dateto As Date, dateFrom As Date) As Integer
        Dim weeks As Integer = DateDiff(DateInterval.WeekOfYear, dateto, dateFrom)
        Return weeks
    End Function
    'Select tha period
    Private Sub ibtnBack_Click(sender As Object, e As EventArgs) Handles ibtnBack.Click
        dtpPeriod.Value = dtpPeriod.Value.AddMonths(-1)
    End Sub

    Private Sub ibtnFoward_Click(sender As Object, e As EventArgs) Handles ibtnFoward.Click
        dtpPeriod.Value = dtpPeriod.Value.AddMonths(1)
    End Sub

#Region "Events"
    Private Sub txtNisNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNisNumber.KeyPress
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
    Private Sub txtearnings_TextChanged(sender As Object, e As EventArgs) Handles txtearnings.TextChanged
        If CheckInformationDate() Then
            txtearnings.Clear()
            Exit Sub
        End If
        Try
            Dim month As Integer = DateTime.ParseExact(cmbMonth.SelectedItem, "MMMM", CultureInfo.InvariantCulture).Month
            Dim year = Convert.ToInt32(cmbYear.SelectedItem)
            If txtearnings.Text.Length > 0 Then
                Dim earning As Decimal = Convert.ToDecimal(txtearnings.Text)
                If earning > 5000 Then
                    earning = 5000
                End If
                If getWeeks() <> GetNumberOfWeeksInMonth(year, month) Then
                    If earning / getWeeks() > 1160 Then
                        earning = 1160 * getWeeks()
                    End If
                End If
                Dim contribution = calculateConstribution(earning, True, 0, cmbYear.SelectedItem, cmbMonth.SelectedItem)
                Dim penalties As Decimal = calculatePenalties(contribution, cmbYear.SelectedItem, cmbMonth.SelectedItem)
                Dim interes As Decimal = calculateInteres(contribution, cmbYear.SelectedItem, cmbMonth.SelectedItem)
                txtConstribution.Text = contribution
            Else
                txtConstribution.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                   "Only Numbers",
                                        MessageBoxButtons.OK,
                                           MessageBoxIcon.Information,
                                               MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub txtearnings_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtearnings.KeyPress
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
        End If
    End Sub
    'restringir el timepicker al ano y mes seleccionado
    Private Sub cmbMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonth.SelectedIndexChanged
        If cmbMonth.SelectedIndex <> 0 Then
            clearTXT()
            If cmbYear.SelectedIndex > 0 Then
                Dim monthNumber As Integer = DateTime.ParseExact(cmbMonth.SelectedItem, "MMMM", CultureInfo.InvariantCulture).Month
                Dim dateM As Date = New DateTime(cmbYear.SelectedItem, monthNumber, 1)
                MonthCalendar1.SetDate(dateM)
                MonthCalendar1.Visible = True
                If GetNumberOfWeeksInMonth(dateM.Year, dateM.Month) = 4 Then
                    chkweek5.Visible = False
                    txtweek5.Visible = False
                Else
                    chkweek5.Visible = True
                    txtweek5.Visible = True
                End If

            Else
                MonthCalendar1.Visible = False
            End If
        Else
            MonthCalendar1.Visible = False
            gbWeeks.Visible = False
            PanelWeeks.Visible = False
            GroupBox4.Visible = False
        End If
        cmbFrequence.SelectedIndex = 0
    End Sub
    Private Sub cmbYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYear.SelectedIndexChanged
        If cmbMonth.SelectedIndex > 0 Then
            'setDates()
            clearTXT()
            If cmbMonth.SelectedIndex > 0 Then
                Dim monthNumber As Integer = DateTime.ParseExact(cmbMonth.SelectedItem, "MMMM", CultureInfo.InvariantCulture).Month
                Dim dateM As Date = New DateTime(cmbYear.SelectedItem, monthNumber, 1)
                MonthCalendar1.SetDate(dateM)
                MonthCalendar1.Visible = True
            Else
                MonthCalendar1.Visible = False
            End If
        End If
    End Sub
    Private Sub cmbFrequence_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFrequence.SelectedIndexChanged
        If cmbFrequence.SelectedIndex <> 0 And cmbMonth.SelectedIndex <> 0 Then
            PanelWeeks.Visible = True
            If cmbFrequence.SelectedIndex = 1 Then
                For Each chk As CheckBox In GroupBox5.Controls.OfType(Of CheckBox)
                    If chk.Visible Then
                        chk.Checked = True
                    Else
                        chk.Checked = False
                    End If
                Next
            Else
                For Each chk As CheckBox In GroupBox5.Controls.OfType(Of CheckBox)
                    chk.Checked = False
                Next
            End If
            If cmbFrequence.SelectedIndex = 2 Then
                gbWeeks.Visible = True
                GroupBox4.Visible = False
            Else
                gbWeeks.Visible = False
                GroupBox4.Visible = True
            End If
            txtConstribution.Visible = True
            Label17.Visible = True
            txtearnings.Clear()
            txtEarningsWeekly.Clear()
        Else
            PanelWeeks.Visible = False
            gbWeeks.Visible = False
            GroupBox4.Visible = False
            txtConstribution.Visible = False
            Label17.Visible = False

        End If

    End Sub

    Private Sub chkweek_CheckedChanged(sender As Object, e As EventArgs) Handles chkweek1.CheckedChanged, chkweek2.CheckedChanged, chkweek3.CheckedChanged, chkweek4.CheckedChanged, chkweek5.CheckedChanged
        Dim senderChk = DirectCast(sender, CheckBox)
        If chkweek1.Checked Then
            txtWeek1.Enabled = True
            txtWeek1.BackColor = Color.LightGreen
        Else
            txtWeek1.Enabled = False
            txtWeek1.Clear()
            txtWeek1.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
        If chkweek2.Checked Then
            txtWeek2.Enabled = True
            txtWeek2.BackColor = Color.LightGreen
        Else
            txtWeek2.Enabled = False
            txtWeek2.Clear()
            txtWeek2.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
        If chkweek3.Checked Then
            txtWeek3.Enabled = True
            txtWeek3.BackColor = Color.LightGreen
        Else
            txtWeek3.Enabled = False
            txtWeek3.Clear()
            txtWeek3.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
        If chkweek4.Checked Then
            txtWeek4.Enabled = True
            txtWeek4.BackColor = Color.LightGreen
        Else
            txtWeek4.Enabled = False
            txtWeek4.Clear()
            txtWeek4.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
        If chkweek5.Checked Then
            txtweek5.Enabled = True
            txtweek5.BackColor = Color.LightGreen
        Else
            txtweek5.Enabled = False
            txtweek5.Clear()
            txtweek5.BackColor = Color.FromKnownColor(KnownColor.Window)
        End If
        txtearnings.Clear()
        'txtEarningsWeekly.Clear()
    End Sub
    Private Sub txtWeek1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtweek5.KeyPress, txtWeek4.KeyPress, txtWeek3.KeyPress, txtWeek2.KeyPress, txtWeek1.KeyPress
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
        End If
    End Sub
    Private Sub txtWeek1_TextChanged(sender As Object, e As EventArgs) Handles txtWeek1.TextChanged, txtWeek2.TextChanged, txtWeek3.TextChanged, txtWeek4.TextChanged, txtweek5.TextChanged
        Dim earning As Decimal
        Dim weekEarn As Decimal
        For Each txt As TextBox In gbWeeks.Controls.OfType(Of TextBox)
            If Not String.IsNullOrEmpty(txt.Text) AndAlso txt.Name <> "txtEarningsWeekly" Then
                weekEarn = Convert.ToDecimal(txt.Text)
                If weekEarn > 1160 Then
                    weekEarn = 1160
                End If
                earning += weekEarn
            End If
        Next
        Dim count As Integer = getWeeks()
        If txtWeek1.Text.Length > 0 Or txtWeek2.Text.Length > 0 Or txtWeek3.Text.Length > 0 Or txtWeek4.Text.Length > 0 Or txtweek5.Text.Length > 0 Then
            Dim contribution = calculateConstribution(earning, False, count, cmbYear.SelectedItem, cmbMonth.SelectedItem)
            Dim penalties As Decimal = calculatePenalties(contribution, cmbYear.SelectedItem, cmbMonth.SelectedItem)
            Dim interes As Decimal = calculateInteres(contribution, cmbYear.SelectedItem, cmbMonth.SelectedItem)
            txtEarningsWeekly.Text = earning
            txtConstribution.Text = contribution
        Else
            txtEarningsWeekly.Text = "0.00"
        End If
    End Sub
    Private Sub dgv1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgv1.RowsAdded
        If dgv1.Rows.Count > 0 Then
            getTotalGeneral()
        Else
            txtTotalPenalties.Text = 0.00
            txtTotalInteres.Text = 0.00
            txttotalContrib.Text = 0.00
            txtemployees.Text = 0
        End If
    End Sub
    Private Sub dgv1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgv1.RowsRemoved
        If dgv1.Rows.Count > 0 Then
            getTotalGeneral()

        Else
            txtTotalPenalties.Text = 0.00
            txtTotalInteres.Text = 0.00
            txttotalContrib.Text = 0.00
            txtemployees.Text = 0
        End If
    End Sub
    Private Sub dgv1_CellContentClick(sender As System.Object, e As DataGridViewCellEventArgs) _
                                          Handles dgv1.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        'buttom update
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 AndAlso e.ColumnIndex = 18 Then
            ibtnAddEmployee.PerformClick()
            txtNisNumber.Text = dgv1.Rows(e.RowIndex).Cells(5).Value
            txtNisNumber.ReadOnly = True
            ibtnCheck.PerformClick()
            isUpdating = True
            id = e.RowIndex
        End If
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
          e.RowIndex >= 0 AndAlso e.ColumnIndex = 19 Then
            dgv1.Rows.RemoveAt(e.RowIndex)
            deleteRemittance()
            InsertRemittance()
            dgv1.Refresh()
            If dgv1.Rows.Count = 0 Then
                dgv1.Columns.Clear()
            End If
        End If
    End Sub




#End Region
#Region "Helpers"
    Async Sub loadRemittance()
        Try
            dgv1.Columns.Clear()
            Dim checkColumn As New DataGridViewCheckBoxColumn
            checkColumn.HeaderText = "Select"
            checkColumn.Name = "select"
            checkColumn.ReadOnly = False
            dgv1.Columns.Add(checkColumn)

            'dgv1.DataSource = db.getRemittance(empr.EmployerNo, empr.EmployerSub)
            'dgv1.DataSource = db.getRemittanceLite(empr.EmployerNo, empr.EmployerSub)
            If dgv1.Rows.Count = 0 Then
                Dim response As String = Await GetLastRemitanceHttp(empr.EmployerNo, empr.EmployerSub)
                Dim lstCnte As BindingList(Of CNTE) = JsonConvert.DeserializeObject(Of BindingList(Of CNTE))(response)
                dgv1.DataSource = lstCnte
            End If
            If dgv1.Rows.Count > 0 Then
                addColumns()
                dgv1.Columns(1).Visible = False
            End If
            dgv1.RowsDefaultCellStyle.BackColor = Color.Bisque
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                               "Error loading remittance",
                                    MessageBoxButtons.OK,
                                       MessageBoxIcon.Exclamation,
                                           MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Sub ClearEmployeePanel()
        Dim weeks As Integer = 0
        For Each chk As CheckBox In GroupBox5.Controls.OfType(Of CheckBox)
            chk.Checked = False
        Next
        For Each txt As TextBox In gbWeeks.Controls.OfType(Of TextBox)
            txt.Clear()
        Next
        For Each txt As TextBox In PanelEmployee2.Controls.OfType(Of TextBox)
            txt.Clear()
        Next
        For Each txt As TextBox In GroupBox4.Controls.OfType(Of TextBox)
            txt.Clear()
        Next
        txtNisNumber.Clear()
        txtConstribution.Visible = False
        Label17.Visible = False
        cmbYear.SelectedItem = Today.Year
        cmbFrequence.SelectedIndex = 0
        cmbMonth.SelectedIndex = 0
        gbWeeks.Visible = False
        PanelEmployee2.Visible = False
        MonthCalendar1.Visible = False
        GroupBox4.Visible = False
        chkVoluntary.Checked = False
    End Sub
    Public Function GetNumberOfWeeksInMonth(year As Integer, month As Integer) As Integer
        Return Enumerable.Range(1, DateTime.DaysInMonth(year, month)).
        Count(Function(d) (New DateTime(year, month, d)).DayOfWeek = DayOfWeek.Monday)
    End Function
    Sub insertEmployeeDgvMonthly(monthly As Boolean, weeks As Integer)
        If String.IsNullOrEmpty(txtearnings.Text) AndAlso monthly Then
            MessageBox.Show("You must enter the Insurable Earnings",
                                "Missing Information",
                                     MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1)

            Exit Sub
        End If
        Try
            Dim earning As Decimal
            Dim monthNumber As Integer = DateTime.ParseExact(cmbMonth.SelectedItem, "MMMM", CultureInfo.InvariantCulture).Month
            Dim fullName As String = empe.FirstName + " " + empe.Lastname + " " + empe.MaidenName
            If monthly Then
                earning = Convert.ToDecimal(txtearnings.Text)
                If earning > 5000 Then
                    earning = 5000
                End If
            Else
                earning = Convert.ToDecimal(txtEarningsWeekly.Text)
            End If
            Dim contribution = calculateConstribution(earning, monthly, weeks, cmbYear.SelectedItem, cmbMonth.SelectedItem)
            Dim penalties = calculatePenalties(contribution, cmbYear.SelectedItem, cmbMonth.SelectedItem)
            Dim interes = calculateInteres(contribution, cmbYear.SelectedItem, cmbMonth.SelectedItem)
            If dgv1.Rows.Count > 0 Then
                'pasar datagrid to datatable
                ' Dim dt = DirectCast(dgv1.DataSource, DataTable)
                Dim dt As New DataTable
                dt = GridtoTable(dt)
                dgv1.Columns.Clear()
                Dim R As DataRow
                If Not isUpdating Then
                    R = dt.NewRow
                Else
                    R = dt.Rows(id)
                End If
                R(1) = empr.EmployerNo
                R(2) = empr.EmployerSub
                R(3) = cmbYear.SelectedItem
                R(4) = monthNumber
                R(5) = empe.NisNumber
                R(6) = fullName
                R(7) = cmbFrequence.SelectedItem
                R(8) = getWeeks()
                R(9) = earning
                R(10) = contribution
                R(11) = Format(penalties)
                R(12) = interes
                addWeeksX(R, monthly)
                If Not isUpdating Then
                    dt.Rows.Add(R)
                    getTotalGeneral()
                Else
                    getTotalGeneral()
                End If
                dgv1.DataSource = dt
                dgv1.Columns(0).Visible = False
                addColumns()
                isUpdating = False
                deleteRemittance()
                InsertRemittance()

            Else
                Dim dt As New DataTable
                Dim R As DataRow = dt.NewRow
                dt.Columns.Add("ID")
                dt.Columns.Add("EmployerNo")
                dt.Columns.Add("EmployerSub")
                dt.Columns.Add("Year")
                dt.Columns.Add("Month")
                dt.Columns.Add("Employee-Number")
                dt.Columns.Add("Employee-Name")
                dt.Columns.Add("Frequence")
                dt.Columns.Add("Weeks-Worked")
                dt.Columns.Add("E.Earnings")
                dt.Columns.Add("Contributions")
                dt.Columns.Add("Penalties")
                dt.Columns.Add("Interest")
                dt.Columns.Add("Week1")
                dt.Columns.Add("Week2")
                dt.Columns.Add("Week3")
                dt.Columns.Add("Week4")
                dt.Columns.Add("Week5")
                R(1) = empr.EmployerNo
                R(2) = empr.EmployerSub
                R(3) = cmbYear.SelectedItem
                R(4) = monthNumber
                R(5) = empe.NisNumber
                R(6) = fullName
                R(7) = cmbFrequence.SelectedItem
                R(8) = getWeeks()
                R(9) = earning
                R(10) = contribution
                R(11) = penalties
                R(12) = interes
                addWeeksX(R, monthly)
                dt.Rows.Add(R)
                dgv1.DataSource = dt
                getTotalGeneral()
                dgv1.Columns(0).Visible = False
                isUpdating = False
                addColumns()
                InsertRemittance()
            End If
            remittanceSent = False
            checkEveryRow()
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error creating the datagriedview",
                                "Missing Information",
                                     MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Function GridtoTable(dt As DataTable) As DataTable
        For Each column As DataGridViewColumn In dgv1.Columns
            If column.Index < dgv1.Columns.Count - 2 Then
                dt.Columns.Add(column.HeaderText, column.ValueType)
            End If
        Next
        'Adding the Rows.
        For Each row As DataGridViewRow In dgv1.Rows
            dt.Rows.Add()
            For Each cell As DataGridViewCell In row.Cells
                If cell.ColumnIndex < dgv1.Columns.Count - 2 Then
                    dt.Rows(dt.Rows.Count - 1)(cell.ColumnIndex) = cell.Value
                End If

            Next
        Next
        Return dt
    End Function
    Sub addColumns()
        If Not dgv1.Columns.Contains("update") Then
            Dim btnOForm As New DataGridViewButtonColumn
            btnOForm.HeaderText = "Update"
            btnOForm.Name = "update"
            btnOForm.Text = "Update"
            btnOForm.UseColumnTextForButtonValue = True
            dgv1.Columns.Add(btnOForm)
        End If
        If Not dgv1.Columns.Contains("Delete") Then
            Dim btnOForm As New DataGridViewButtonColumn
            btnOForm.HeaderText = "Delete"
            btnOForm.Name = "Delete"
            btnOForm.Text = "Delete"
            btnOForm.UseColumnTextForButtonValue = True
            dgv1.Columns.Add(btnOForm)
        End If
    End Sub
    Sub addWeeksX(R As DataRow, monthly As Boolean)
        If (monthly) Then
            If chkweek1.Checked Then
                R(13) = "X"
            Else
                R(13) = ""
            End If
            If chkweek2.Checked Then
                R(14) = "X"
            Else
                R(14) = ""
            End If
            If chkweek3.Checked Then
                R(15) = "X"
            Else
                R(15) = ""
            End If
            If chkweek4.Checked Then
                R(16) = "X"
            Else
                R(16) = ""
            End If
            If chkweek5.Checked Then
                R(17) = "X"
            Else
                R(17) = ""
            End If
        Else
            If chkweek1.Checked Then
                R(13) = txtWeek1.Text
            Else
                R(13) = ""
            End If
            If chkweek2.Checked Then
                R(14) = txtWeek2.Text
            Else
                R(14) = ""
            End If
            If chkweek3.Checked Then
                R(15) = txtWeek3.Text
            Else
                R(15) = ""
            End If
            If chkweek4.Checked Then
                R(16) = txtWeek4.Text
            Else
                R(16) = ""
            End If
            If chkweek5.Checked Then
                R(17) = txtweek5.Text
            Else
                R(17) = ""
            End If
        End If
    End Sub
    Function getWeeks() As Integer
        Dim weeks As Integer = 0
        For Each chk As CheckBox In GroupBox5.Controls.OfType(Of CheckBox)
            If chk.Checked Then
                weeks += 1
            End If
        Next
        Return weeks
    End Function
    Private Sub clearTXT()
        txtConstribution.Clear()
    End Sub
    Sub fillCmbYears()
        ' cmbYear.Items.Add(Today.AddYears(-2).Year)
        cmbYear.Items.Add(Today.AddYears(-11).Year)
        cmbYear.Items.Add(Today.AddYears(-10).Year)
        cmbYear.Items.Add(Today.AddYears(-9).Year)
        cmbYear.Items.Add(Today.AddYears(-8).Year)
        cmbYear.Items.Add(Today.AddYears(-7).Year)
        cmbYear.Items.Add(Today.AddYears(-6).Year)
        cmbYear.Items.Add(Today.AddYears(-5).Year)
        cmbYear.Items.Add(Today.AddYears(-4).Year)
        cmbYear.Items.Add(Today.AddYears(-3).Year)
        cmbYear.Items.Add(Today.AddYears(-2).Year)
        cmbYear.Items.Add(Today.AddYears(-1).Year)
        cmbYear.Items.Add(Today.Year)
        If Today.Month > 6 Then
            cmbYear.Items.Add(Today.AddYears(1).Year)
        End If
        cmbYear.SelectedItem = Today.Year
        cmbMonth.SelectedIndex = 0
        cmbFrequence.SelectedIndex = 0
    End Sub
    Private Function CheckInformation() As Boolean
        If String.IsNullOrEmpty(txtNisNumber.Text) Then
            MessageBox.Show("You must provide the NIS Number.",
                                "Missing Information",
                                     MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1)

            Return True
        End If
        Return False
    End Function
    Private Function CheckInformationDate() As Boolean
        If cmbMonth.SelectedIndex = 0 Then
            MessageBox.Show("Please select the month to pay before.",
                                "Missing Information",
                                     MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1)

            Return True
        End If
        Return False
    End Function
    Function getNisRate(year As Integer, month As Integer) As Decimal
        Dim dateToPay As Date
        'Dim monthNumber As Integer = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month
        dateToPay = New DateTime(year, month, 1)
        If Not chkVoluntary.Checked Then
            If DateTime.Compare(dateToPay, New DateTime(2020, 1, 1)) < 0 Then
                Return 9
            End If
            If dateToPay >= New DateTime(2020, 1, 1) AndAlso dateToPay <= New DateTime(2020, 3, 31) Then
                Return 11
            End If
            If dateToPay >= New DateTime(2020, 4, 1) AndAlso dateToPay <= New DateTime(2020, 7, 31) Then
                Return 9
            End If
            Return Convert.ToDecimal(db.getNISrate)
        End If
        If chkVoluntary.Checked Then
            If dateToPay >= New DateTime(2020, 1, 1) AndAlso dateToPay <= New DateTime(2020, 3, 31) Then
                Return 8.75
            End If
            If dateToPay >= New DateTime(2020, 4, 1) AndAlso dateToPay <= New DateTime(2020, 7, 31) Then
                Return 6.75
            End If
            Return Convert.ToDecimal(db.getVoluntaryRate)
        End If
        Return 0.00
    End Function
    Function calculateConstribution(earning As Decimal, monthly As Boolean, weeks As Integer, year As Integer, monthname As String) As Decimal
        If CheckInformationDate() Then
            Exit Function
        End If
        Try
            Dim contribution As Decimal
            Dim month As Integer = DateTime.ParseExact(monthname, "MMMM", CultureInfo.InvariantCulture).Month
            If monthly Then
                If earning > 5000 Then
                    earning = 5000
                End If
                If getWeeks() <> GetNumberOfWeeksInMonth(year, month) Then
                    If earning / getWeeks() > 1160 Then
                        earning = 1160 * getWeeks()
                    End If
                End If

            ElseIf Not monthly AndAlso earning > 1160 * weeks Then
                earning = 1160 * weeks
            End If
            'empe.DateOB = New DateTime(1960, 7, 2)
            'empe.DateOB = New DateTime(2004, 7, 16)
            If InPaidMonth60(year, month) Then
                If monthly Then
                    Return constribWith60(earning, year, month, True)
                Else
                    Return constribWith60(earning, year, month, False)
                End If
            End If
            If InPaidMonth16(year, month) Then
                If monthly Then
                    Return constribWith16(earning, year, month, True)
                Else
                    Return constribWith16(earning, year, month, False)
                End If
            End If
            Dim nisrate = If((CalcularEdad(empe.DateOB, year, month) > 15 And CalcularEdad(empe.DateOB, year, month) < 60), getNisRate(year, month), 1)
            'Dim nisrate = getNisRate(year, month)
            contribution = earning * (nisrate / 100)
            Return Math.Round(contribution, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
#Disable Warning BC42353 ' Function doesn't return a value on all code paths
    End Function
#Enable Warning BC42353 ' Function doesn't return a value on all code paths

    Public Function CalcularEdad(ByVal Nacimiento As Date, year As Integer, month As Integer) As Integer
        Dim Edad As Integer = 0
        If Nacimiento.Month > month Then
            Edad = DateDiff(DateInterval.Year, Nacimiento, New DateTime(year, month, 1)) - 1
        ElseIf Nacimiento.Month = month Then
            If Nacimiento.Day > 1 Then
                Edad = DateDiff(DateInterval.Year, Nacimiento, New DateTime(year, month, 1)) - 1
            Else
                Edad = DateDiff(DateInterval.Year, Nacimiento, New DateTime(year, month, 1))
            End If
        Else
            Edad = DateDiff(DateInterval.Year, Nacimiento, New DateTime(year, month, 1))
        End If
        Return Edad
    End Function
    Public Function constribWith60(earnings As Decimal, year As Integer, month As Integer, monthly As Boolean)
        Dim weekEarning As Decimal = earnings / getWeeks()
        If weekEarning > 1160 Then
            weekEarning = 1160
        End If
        Dim totalCont As Decimal
        Dim day As Integer = 1
        'get 1st month'monday
        For x As Integer = 1 To DateTime.DaysInMonth(year, month)
            If (New DateTime(year, month, x).DayOfWeek = DayOfWeek.Monday AndAlso New DateTime(year, month, x).Day <= 7) Then
                day = x
                Exit For
            End If
        Next
        If empe.DateOB.Day < day Then
            Return Math.Round(earnings * 1 / 100, 2)
        End If
        For week As Integer = 1 To GetNumberOfWeeksInMonth(year, month)
            ' Dim x As Integer = DateDiff(DateInterval.Day, New DateTime(year, month, empe.DateOB.Day), New DateTime(year, month, day), FirstDayOfWeek.Monday)
            If chkweek1.Tag = week And chkweek1.Checked Or chkweek2.Tag = week And chkweek2.Checked Or chkweek3.Tag = week And chkweek3.Checked Or
                chkweek4.Tag = week And chkweek4.Checked Or chkweek5.Tag = week And chkweek5.Checked Then
                If DateDiff(DateInterval.Day, New DateTime(year, month, empe.DateOB.Day), New DateTime(year, month, day), FirstDayOfWeek.Monday) >= 0 Then
                    If monthly Then
                        totalCont += weekEarning * 1 / 100
                    Else
                        For Each txt As TextBox In gbWeeks.Controls.OfType(Of TextBox)
                            If txt.Tag = week AndAlso Not String.IsNullOrEmpty(txt.Text) Then
                                Dim weekC As Decimal = Convert.ToDecimal(txt.Text)
                                If weekC > 1160 Then
                                    weekC = 1160
                                End If
                                totalCont += weekC * 1 / 100
                            End If
                        Next
                    End If
                Else
                    If monthly Then
                        totalCont += weekEarning * getNisRate(year, month) / 100
                    Else
                        For Each txt As TextBox In gbWeeks.Controls.OfType(Of TextBox)
                            If txt.Tag = week AndAlso Not String.IsNullOrEmpty(txt.Text) Then
                                Dim weekC As Decimal = Convert.ToDecimal(txt.Text)
                                If weekC > 1160 Then
                                    weekC = 1160
                                End If
                                totalCont += weekC * getNisRate(year, month) / 100
                            End If
                        Next
                    End If
                End If
            End If
            day += 7
        Next
        Return Math.Round(totalCont, 2)
    End Function
    Public Function constribWith16(earnings As Decimal, year As Integer, month As Integer, monthly As Boolean)
        Dim weekEarning As Decimal = earnings / getWeeks()
        If weekEarning > 1160 Then
            weekEarning = 1160
        End If
        Dim totalCont As Decimal
        Dim day As Integer = 1
        'get 1st month'monday
        For x As Integer = 1 To DateTime.DaysInMonth(year, month)
            If (New DateTime(year, month, x).DayOfWeek = DayOfWeek.Monday AndAlso New DateTime(year, month, x).Day <= 7) Then
                day = x
                Exit For
            End If
        Next
        'antes del primer lunes del mes
        If empe.DateOB.Day < day Then
            Return Math.Round(earnings * getNisRate(year, month) / 100, 2)
        End If
        For week As Integer = 1 To GetNumberOfWeeksInMonth(year, month)
            If chkweek1.Tag = week And chkweek1.Checked Or chkweek2.Tag = week And chkweek2.Checked Or chkweek3.Tag = week And chkweek3.Checked Or
                chkweek4.Tag = week And chkweek4.Checked Or chkweek5.Tag = week And chkweek5.Checked Then
                If DateDiff(DateInterval.Day, New DateTime(year, month, empe.DateOB.Day), New DateTime(year, month, day), FirstDayOfWeek.Monday) < 0 Then
                    If monthly Then
                        totalCont += weekEarning * 1 / 100
                    Else
                        For Each txt As TextBox In gbWeeks.Controls.OfType(Of TextBox)
                            If txt.Tag = week AndAlso Not String.IsNullOrEmpty(txt.Text) Then
                                Dim weekC As Decimal = Convert.ToDecimal(txt.Text)
                                If weekC > 1160 Then
                                    weekC = 1160
                                End If
                                totalCont += weekC * 1 / 100
                            End If
                        Next
                    End If
                Else
                    If monthly Then
                        totalCont += weekEarning * getNisRate(year, month) / 100
                    Else
                        For Each txt As TextBox In gbWeeks.Controls.OfType(Of TextBox)
                            If txt.Tag = week AndAlso Not String.IsNullOrEmpty(txt.Text) Then
                                Dim weekC As Decimal = Convert.ToDecimal(txt.Text)
                                If weekC > 1160 Then
                                    weekC = 1160
                                End If
                                totalCont += weekC * getNisRate(year, month) / 100
                            End If
                        Next
                    End If
                End If
            End If
            day += 7
        Next
        Return Math.Round(totalCont, 2)
    End Function
    Public Function InPaidMonth60(year As Integer, month As Integer) As Boolean
        If month = empe.DateOB.Month Then
            Dim day = 1
            If DateDiff(DateInterval.Year, empe.DateOB, New DateTime(year, month, 1)) = 60 Then
                For x As Integer = 1 To DateTime.DaysInMonth(year, month)
                    If (New DateTime(year, month, x).DayOfWeek = DayOfWeek.Monday AndAlso New DateTime(year, month, x).Day <= 7) Then
                        day = x
                        Exit For
                    End If
                Next
                If empe.DateOB.Day < day Then

                End If
                For week As Integer = 1 To GetNumberOfWeeksInMonth(year, month)
                    If DateDiff(DateInterval.Day, New DateTime(year, month, empe.DateOB.Day), New DateTime(year, month, day), FirstDayOfWeek.Monday) >= 0 Then
                        Return True
                    End If
                    day += 7
                Next
            Else
                Return False
            End If
        End If
        Return False
    End Function
    Function InPaidMonth16(year As Integer, month As Integer) As Boolean
        If month = empe.DateOB.Month Then
            Dim day = 1
            If DateDiff(DateInterval.Year, empe.DateOB, New DateTime(year, month, 1)) = 16 Then
                For x As Integer = 1 To DateTime.DaysInMonth(year, month)
                    If (New DateTime(year, month, x).DayOfWeek = DayOfWeek.Monday AndAlso New DateTime(year, month, x).Day <= 7) Then
                        day = x
                        Exit For
                    End If
                Next
                For week As Integer = 1 To GetNumberOfWeeksInMonth(year, month)
                    Dim z = DateDiff(DateInterval.Day, New DateTime(year, month, empe.DateOB.Day), New DateTime(year, month, day), FirstDayOfWeek.Monday)
                    If DateDiff(DateInterval.Day, New DateTime(year, month, empe.DateOB.Day), New DateTime(year, month, day), FirstDayOfWeek.Monday) >= 0 Then
                        Return True
                    End If
                    day += 7
                Next
            Else
                Return False
            End If
        End If
        Return False
    End Function
    Function calculatePenalties(contribution As Decimal, year As Integer, month As String)
        Try
            Dim penalties As Decimal
            Dim monthNumber As Integer = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month
            Dim period As Date = New DateTime(year, monthNumber, 14)
            Dim payDate = New DateTime(Now.Year, Now.Month, 14)
            While db.getHoliday(payDate)
                payDate = payDate.AddDays(1)
            End While
            If payDate.DayOfWeek = DayOfWeek.Saturday Then
                payDate = payDate.AddDays(2)
            End If
            If payDate.DayOfWeek = DayOfWeek.Sunday Then
                payDate = payDate.AddDays(1)
            End If
            If Today > payDate Then
                payDate = Today
            End If
            Dim months As Integer = DateDiff(DateInterval.Month, payDate, period)
            If months = -1 Then
                If period.Day >= payDate.Day Then
                    months += 1
                End If
            End If
            If months <= -1 Then
                penalties = contribution * 0.1
            Else
                penalties = 0.00
            End If
            Return Math.Round(penalties, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Function calculateInteres(contribution As Decimal, year As Integer, month As String)
        Try
            Dim interes As Decimal
            Dim monthNumber As Integer = DateTime.ParseExact(month, "MMMM", CultureInfo.InvariantCulture).Month
            Dim period As Date = New DateTime(year, monthNumber, 14)
            'Dim months As Integer = DateDiff(DateInterval.Month, Today, period)
            Dim payDate = New DateTime(Now.Year, Now.Month, 14)
            While db.getHoliday(payDate)
                payDate = payDate.AddDays(1)
            End While
            If payDate.DayOfWeek = DayOfWeek.Saturday Then
                payDate = payDate.AddDays(2)
            End If
            If payDate.DayOfWeek = DayOfWeek.Sunday Then
                payDate = payDate.AddDays(1)
            End If
            ' Dim today = New DateTime(Now.Year, Now.Month, 17)
            If Today > payDate Then
                payDate = Today
            End If
            Dim months As Integer = DateDiff(DateInterval.Month, payDate, period)

            ' If months = -1 Then
            If period.Day >= payDate.Day Then
                months += 1
            End If
            ' End If
            If months <= -1 Then
                interes = contribution * (0.01 * Math.Abs(months))
            Else
                interes = 0.00
            End If
            Return Math.Round(interes, 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Sub getTotalGeneral()
        Dim totalpenalties As Decimal
        Dim totalInteres As Decimal
        Dim totalContribution As Decimal
        Try
            For Each row As DataGridViewRow In dgv1.Rows
                totalContribution += Convert.ToDecimal(row.Cells(10).Value)
                totalpenalties += Convert.ToDecimal(row.Cells(11).Value)
                totalInteres += Convert.ToDecimal(row.Cells(12).Value)
            Next
            txtContrib.Text = totalContribution
            txtTotalPenalties.Text = totalpenalties
            txtTotalInteres.Text = totalInteres
            txttotalContrib.Text = totalContribution + totalInteres + totalpenalties
            txtemployees.Text = dgv1.Rows.Count
        Catch ex As Exception
            MessageBox.Show(ex.Message & " Error getting the totals",
                                  "Only Numbers",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub IconButton1_Click(sender As Object, e As EventArgs) Handles IconButton1.Click
        PanelEmployee.Visible = False
        ClearEmployeePanel()
    End Sub
    Private Async Sub ibtnEmail_Click(sender As Object, e As EventArgs) Handles ibtnEmail.Click
        Try
            If dgv1.Rows.Count = 0 Then
                MessageBox.Show("You need to enter some employees before to send the remittance",
                                  "Error",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If checkEveryRow() Then
                MessageBox.Show("You need to update every employee information(Year, Month, Frequence, Earnings...)",
                                  "Error",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If remittanceSent Then
                MessageBox.Show("Your remittance form was already sent",
                                  "Error",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            Timer1.Start()
            CircularProgressBar1.Visible = True
            CircularProgressBar1.Value = 0
            CircularProgressBar1.Minimum = 0
            CircularProgressBar1.Maximum = 90
            makeFolder()
            CircularProgressBar1.Value += 10
            Dim files() As String = IO.Directory.GetFiles("C:\TempRemittance\", "*.*")
            If files.Length > 0 Then
                FileSystem.Kill("C:\TempRemittance\*.*")
            End If
            deleteRemittance()
            CircularProgressBar1.Value += 10
            InsertRemittance()
            InsertRemittanceSent()
            CircularProgressBar1.Value += 10
            loadRemittance()
            CircularProgressBar1.Value += 10
            Await Task.Run(Sub()
                               ExportRemittanceToexcel()
                           End Sub)
            CircularProgressBar1.Value += 10
            For Each email As String In getEmailsToRemittance()
                oth.sendEmailUsingOutlook("Kiosk Electronic Remittance", bodyRemittance, email)
            Next
            Dim files2() As String = IO.Directory.GetFiles("C:\TempRemittance\", "*.*")
            If files2.Length > 0 Then
                FileSystem.Kill("C:\TempRemittance\*.*")
            End If
            CircularProgressBar1.Value += 10
            Await Task.Run(Sub()
                               getTotalForPeriodos()
                           End Sub)
            CircularProgressBar1.Value += 10
            For Each email As String In getEmailsToTotals()
                oth.sendEmailUsingOutlook("Kiosk Totals", bodyTotals, email)
            Next
            Dim files3() As String = IO.Directory.GetFiles("C:\TempRemittance\", "*.*")
            If files3.Length > 0 Then
                FileSystem.Kill("C:\TempRemittance\*.*")
            End If
            CircularProgressBar1.Value += 10
            remittanceSent = True
            CircularProgressBar1.Value += 10
            CircularProgressBar1.Visible = False
            MessageBox.Show("Your Electronic Remittance was successfully submitted to NIS.",
                                 "Remittance submitted",
                                      MessageBoxButtons.OK,
                                         MessageBoxIcon.Information,
                                             MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Error deleting files",
                                  "Error",
                                       MessageBoxButtons.OK,
                                          MessageBoxIcon.Information,
                                              MessageBoxDefaultButton.Button1)

        End Try

    End Sub
    Function getEmailsToRemittance() As List(Of String)
        Dim list As New List(Of String)
        list.Add("nisremit@nisgrenada.org")
        If Not String.IsNullOrEmpty(txtEmail1.Text) Then
            If oth.IsValidEmail(Trim(txtEmail1.Text)) Then
                list.Add(Trim(txtEmail1.Text))
            End If
        End If
        If Not String.IsNullOrEmpty(txtemail2.Text) Then
            If oth.IsValidEmail(Trim(txtemail2.Text)) Then
                list.Add(Trim(txtemail2.Text))
            End If
        End If
        Return list
    End Function
    Function getEmailsToTotals() As List(Of String)
        Dim list As New List(Of String)
        list.Add("cashier@nisgrenada.org")
        'If Not String.IsNullOrEmpty(txtEmail1.Text) Then
        '    If oth.IsValidEmail(Trim(txtEmail1.Text)) Then
        '        list.Add(Trim(txtEmail1.Text))
        '    End If
        'End If
        'If Not String.IsNullOrEmpty(txtemail2.Text) Then
        '    If oth.IsValidEmail(Trim(txtemail2.Text)) Then
        '        list.Add(Trim(txtemail2.Text))
        '    End If
        'End If
        Return list
    End Function
    Sub getTotalForPeriodos()
        Try
            Dim dt As DataTable = db.getTotalByPeriods(empr.EmployerNo, empr.EmployerSub)
            ExportotalsToexcel(dt)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                            "Error creating totals document",
                                                 MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                        MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Function checkEveryRow() As Boolean
        Dim missingInfo As Boolean = False
        For Each row As DataGridViewRow In dgv1.Rows
            If String.IsNullOrEmpty(row.Cells(7).Value) Then
                row.DefaultCellStyle.ForeColor = Color.Red
                missingInfo = True
            Else
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
        Return missingInfo
    End Function
    Sub GetFilesinFolder()
        Dim files() As String = IO.Directory.GetFiles("C:\TempRemittance\", "*.xlsx")
        For Each file As String In files
            ' Do work, example
            ' Dim text As String = IO.File.ReadAllText(file)
        Next
    End Sub
    Sub InsertRemittance()
        Try
            For Each row As DataGridViewRow In dgv1.Rows
                Dim employerNo As Integer = row.Cells(1).Value
                Dim employerSub As Integer = row.Cells(2).Value
                Dim year As Integer = row.Cells(3).Value
                Dim month As Integer = row.Cells(4).Value
                Dim nisNumber As Integer = row.Cells(5).Value
                Dim name As String = row.Cells(6).Value
                Dim frequence As String = row.Cells(7).Value
                Dim weekW As Integer = row.Cells(8).Value
                Dim earnings As Decimal = row.Cells(9).Value
                Dim contrib As Decimal = row.Cells(10).Value
                Dim penalties As Decimal = row.Cells(11).Value
                Dim interest As Decimal = row.Cells(12).Value
                Dim week1 As String = row.Cells(13).Value
                Dim week2 As String = row.Cells(14).Value
                Dim week3 As String = row.Cells(15).Value
                Dim week4 As String = row.Cells(16).Value
                Dim week5 As String = row.Cells(17).Value
                db.insertRemittanceLite(employerNo, employerSub, year, month, nisNumber, name, frequence, weekW, earnings, contrib, penalties, interest, week1,
                                   week2, week3, week4, week5, Date.Now.ToString)
                'db.insertRemittance(employerNo, employerSub, year, month, nisNumber, name, frequence, weekW, earnings, contrib, penalties, interest, week1,
                '                    week2, week3, week4, week5, Date.Now)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                            "Error Inserting Remittance",
                                                 MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                        MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Sub InsertRemittanceSent()
        Try
            For Each row As DataGridViewRow In dgv1.Rows
                Dim employerNo As Integer = row.Cells(1).Value
                Dim employerSub As Integer = row.Cells(2).Value
                Dim year As Integer = row.Cells(3).Value
                Dim month As Integer = row.Cells(4).Value
                Dim nisNumber As Integer = row.Cells(5).Value
                Dim name As String = row.Cells(6).Value
                Dim frequence As String = row.Cells(7).Value
                Dim weekW As Integer = row.Cells(8).Value
                Dim earnings As Decimal = row.Cells(9).Value
                Dim contrib As Decimal = row.Cells(10).Value
                Dim penalties As Decimal = row.Cells(11).Value
                Dim interest As Decimal = row.Cells(12).Value
                Dim week1 As String = row.Cells(13).Value
                Dim week2 As String = row.Cells(14).Value
                Dim week3 As String = row.Cells(15).Value
                Dim week4 As String = row.Cells(16).Value
                Dim week5 As String = row.Cells(17).Value
                db.insertRemittanceSent(employerNo, employerSub, year, month, nisNumber, name, frequence, weekW, earnings, contrib, penalties, interest, week1,
                                    week2, week3, week4, week5, Date.Now)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                            "Error Inserting Remittance",
                                                 MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                        MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Sub deleteRemittance()
        Try
            db.deleteRemittanceLite(empr.EmployerNo, empr.EmployerSub)
            'db.deleteRemittance(empr.EmployerNo, empr.EmployerSub)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                            "Error",
                                                 MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                        MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Sub ExportRemittanceToexcel()
        Try
            Dim dt As DataTable
            dt = CType(dgv1.DataSource, DataTable).Copy()
            dt.Columns.RemoveAt(12)
            dt.Columns.RemoveAt(11)
            dt.Columns.RemoveAt(0)
            Dim _excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = _excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            ' Dim dt As System.Data.DataTable = dtTemp
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            Dim headers As New List(Of String)({"Employer", " ", "Contributions", "", "Employee", "Employee", "", "Weeks", "Insurable", "", "", "Insurable", "", "", ""})
            Dim headers2 As New List(Of String)({"Number", "Sub", "Year", "Month", "Number", "Name", "Frequence", "Worked", "Earnings", "Contributions", "Week1", "Week2", "Week3", "Week4", "Week5"})
            For Each name As String In headers
                colIndex = colIndex + 1
                _excel.Cells(1, colIndex) = name
            Next
            _excel.Cells(1, 1).EntireRow.Font.Bold = True
            colIndex = 0
            For Each name As String In headers2
                colIndex = colIndex + 1
                _excel.Cells(2, colIndex) = name
            Next
            _excel.Cells(2, 1).EntireRow.Font.Bold = True
            _excel.Cells(2, 1).EntireRow.Font.Underline = True
            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    _excel.Cells(rowIndex + 2, colIndex) = dr(dc.ColumnName)

                Next
            Next

            wSheet.Range(wSheet.Cells(3, 9), wSheet.Cells(100, 9)).NumberFormat = "0.00"
            wSheet.Range(wSheet.Cells(3, 10), wSheet.Cells(100, 10)).NumberFormat = "0.00"
            wSheet.Range(wSheet.Cells(3, 11), wSheet.Cells(100, 11)).NumberFormat = "0.00"
            wSheet.Range(wSheet.Cells(3, 12), wSheet.Cells(100, 12)).NumberFormat = "0.00"
            wSheet.Range(wSheet.Cells(3, 13), wSheet.Cells(100, 13)).NumberFormat = "0.00"
            wSheet.Range(wSheet.Cells(3, 14), wSheet.Cells(100, 14)).NumberFormat = "0.00"
            wSheet.Range(wSheet.Cells(3, 15), wSheet.Cells(100, 15)).NumberFormat = "0.00"
            wSheet.Columns.AutoFit()
            Dim strFileName As String = "C:\TempRemittance\" & empr.EmployerNo & "-" & empr.EmployerSub & "-E-Remittance(Kiosk).xlsx"
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            wBook.SaveAs(Filename:="C:\TempRemittance\" & empr.EmployerNo & "-" & empr.EmployerSub & "-E-Remittance(Kiosk).xlsx", FileFormat:=51)
            wBook.Close()
            _excel.Quit()
            releaseObject(_excel)
            releaseObject(wBook)
            releaseObject(wSheet)
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                                             "Error creating remittance document",
                                                  MessageBoxButtons.OK,
                                                     MessageBoxIcon.Information,
                                                         MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Sub ExportotalsToexcel(dt As DataTable)
        Try
            Dim files3() As String = IO.Directory.GetFiles("C:\TempRemittance\", "*.*")
            If files3.Length > 0 Then
                FileSystem.Kill("C:\TempRemittance\*.*")
            End If
            Dim _excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = _excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            Dim headers As String = empr.EmployerNo & "-" & empr.EmployerSub & "/" & empr.BusinessName
            Dim headers2 As New List(Of String)({"Year", "Month", "Total"})
            _excel.Cells(1, 1) = headers
            _excel.Cells(1, 1).EntireRow.Font.Bold = True
            colIndex = 0
            For Each name As String In headers2
                colIndex = colIndex + 1
                _excel.Cells(2, colIndex) = name
            Next
            _excel.Cells(2, 1).EntireRow.Font.Bold = True
            _excel.Cells(2, 1).EntireRow.Font.Underline = True
            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    _excel.Cells(rowIndex + 2, colIndex) = dr(dc.ColumnName)

                Next
            Next
            wSheet.Range(wSheet.Cells(1, 1), wSheet.Cells(1, 5)).Merge()
            wSheet.Range(wSheet.Cells(2, 3), wSheet.Cells(100, 3)).NumberFormat = "0.00"
            wSheet.Columns.AutoFit()
            Dim strFileName As String = "C:\TempRemittance\" & empr.EmployerNo & "-" & empr.EmployerSub & "-Totals.xlsx"
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            wBook.SaveAs(Filename:="C:\TempRemittance\" & empr.EmployerNo & "-" & empr.EmployerSub & "-Totals.xlsx", FileFormat:=51)
            wBook.Close()
            _excel.Quit()
            releaseObject(_excel)
            releaseObject(wBook)
            releaseObject(wSheet)
        Catch ex As Exception
            MessageBox.Show(ex.Message & " ",
                                             "Error",
                                                  MessageBoxButtons.OK,
                                                     MessageBoxIcon.Information,
                                                         MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing

            Dim xlp() As Process = Process.GetProcessesByName("EXCEL")

            For Each Process As Process In xlp
                Process.Kill()
                If Process.GetProcessesByName("EXCEL").Count = 0 Then
                    Exit For
                End If
            Next
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub
    Sub makeFolder()
        Try
            If (Not System.IO.Directory.Exists("C:\TempRemittance\")) Then
                System.IO.Directory.CreateDirectory("C:\TempRemittance\")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            "Error making the folder",
                                                            MessageBoxButtons.OK,
                                                               MessageBoxIcon.Information,
                                                                   MessageBoxDefaultButton.Button1)
        End Try
    End Sub
    Function CheckWeeksEarning()
        If cmbFrequence.SelectedIndex = 2 Then
            If chkweek1.Checked Then
                If String.IsNullOrEmpty(txtWeek1.Text) Then
                    MessageBox.Show("Please enter the earnings for weeks 1",
                                                "Missing Earnings",
                                                     MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information,
                                                            MessageBoxDefaultButton.Button1)
                    Return True
                End If
            End If
            If chkweek2.Checked Then
                If String.IsNullOrEmpty(txtWeek2.Text) Then
                    MessageBox.Show("Please enter the earnings for weeks 2",
                                                "Missing Earnings",
                                                     MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information,
                                                            MessageBoxDefaultButton.Button1)
                    Return True
                End If
            End If
            If chkweek3.Checked Then
                If String.IsNullOrEmpty(txtWeek3.Text) Then
                    MessageBox.Show("Please enter the earnings for weeks 3",
                                                "Missing Earnings",
                                                     MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information,
                                                            MessageBoxDefaultButton.Button1)
                    Return True
                End If
            End If
            If chkweek4.Checked Then
                If String.IsNullOrEmpty(txtWeek4.Text) Then
                    MessageBox.Show("Please enter the earnings for weeks 4",
                                                "Missing Earnings",
                                                     MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information,
                                                            MessageBoxDefaultButton.Button1)
                    Return True
                End If
            End If
            If chkweek5.Checked Then
                If String.IsNullOrEmpty(txtweek5.Text) Then
                    MessageBox.Show("Please enter the earnings for weeks 5",
                                                "Missing Earnings",
                                                     MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information,
                                                            MessageBoxDefaultButton.Button1)
                    Return True
                End If
            End If
        End If
    End Function

    'Dim nisrate = If((DateDiff(DateInterval.Year, empe.DateOB, Today) > 60), 1, Convert.ToDecimal(db.getNISrate))

    'Dim edad As Decimal = DateDiff(DateInterval.Year, empe.DateOB, Today, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        CircularProgressBar1.Text = CLng((CircularProgressBar1.Value * 100) / CircularProgressBar1.Maximum)
        If CircularProgressBar1.Value = CircularProgressBar1.Maximum Then
            Timer1.Stop()
        End If
    End Sub
    Dim bodyRemittance As String = "<p>Good Day,</p>
                                    <p>This is an automatically generated email send it from the <strong>NIS Kiosk Machine</strong>.</p>
                                    <p>Attached you can find the<strong> Electronic Remittance Form.</strong>&nbsp;</p>
                                    <p><strong>Regards,</strong>&nbsp;</p>
                                    <p><strong>NIS Kiosk.</strong></p>
                                    <p><strong>THIS IS A SYSTEM GENERATED EMAIL, PLEASE DO NOT REPLY.</strong></p>
                                    <p><strong>____________________________________________________________________________________________________________________________</strong></p>
                                    <p style=" + "text-align: justify;" + ">This email and any files transmitted with it are confidential <br /> and intended solely for the use of the individual or 
                                    entity to whom they are addressed. This message <br /> contains confidential information and is intended only for the individual named. If you are not the <br />
                                    named addressee you should not disseminate, distribute or copy this e-mail. Please notify the sender<br /> immediately by e-mail if you have received this e-mail
                                    by mistake and delete this e-mail from your system.<br /> If you are not the intended recipient you are notified that disclosing, copying, distributing or taking 
                                    any<br /> action in reliance on the contents of this information is strictly prohibited</p>"

    Dim bodyTotals As String = "<p>Good Day,</p>
                                <p>This is an automatically generated email send it from the&nbsp;<strong>NIS Kiosk Machine.</strong></p>
                                <p>Attached you can find the<strong>&nbsp;Totals for periods submitted.</strong>&nbsp;</p>
                                <p><strong>Regards,</strong>&nbsp;</p>
                                <p><strong>NIS Kiosk.</strong>&nbsp;</p>
                                <p><strong>THIS IS A SYSTEM GENERATED EMAIL, PLEASE DO NOT REPLY.</strong></p>
                                <p><strong>____________________________________________________________________________________________________________________________</strong></p>
                                <p style=" + "text-align: justify;" + ">This email and any files transmitted with it are confidential&nbsp;<br />and intended
                                solely for the use of the individual or entity to whom they are addressed. This message&nbsp;<br />contains confidential information and is intended only for the 
                                individual named. If you are not the&nbsp;<br />named addressee you should not disseminate, distribute or copy this e-mail. Please notify the sender<br />immediately
                                by e-mail if you have received this e-mail by mistake and delete this e-mail from your system.<br />If you are not the intended recipient you are notified that 
                                disclosing, copying, distributing or taking any<br />action in reliance on the contents of this information is strictly prohibited</p>"

    Private Sub chkVoluntary_CheckedChanged(sender As Object, e As EventArgs) Handles chkVoluntary.CheckedChanged
        txtEarningsWeekly.Clear()
        txtearnings.Clear()
    End Sub

    Private Sub IconButton2_Click(sender As Object, e As EventArgs)
        Dim frm As New Form2
        frm.Show()
    End Sub
#End Region

#Region "Api"
    Private Async Function GetEmployeeHttp(nisNumber As Integer) As Task(Of String)
        Dim oRequest As WebRequest = WebRequest.Create("https://localhost:44314/api/EMPE?nisNumber=" & nisNumber)
        Dim oResponse As WebResponse = oRequest.GetResponse
        Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream)
        Return Await sr.ReadToEndAsync
    End Function

    Private Async Function GetLastRemitanceHttp(employerNo As Integer, employerSub As Integer) As Task(Of String)
        Dim oRequest As WebRequest = WebRequest.Create("https://localhost:44314/api/CNTEs?employerNo=" & employerNo & " &employerSub=" & employerSub)
        Dim oResponse As WebResponse = oRequest.GetResponse
        Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream)
        Return Await sr.ReadToEndAsync
    End Function

    Private Async Function GetImageHttp(nisNumber As Integer) As Task(Of Image)
        Dim filname As String
        'add dash 
        Dim fnlen As Integer
        fnlen = nisNumber.ToString.Length
        filname = Mid(nisNumber, 1, fnlen - 1) + "-" + Mid(nisNumber, fnlen, 1) + ".jpg"
        Dim oRequest As WebRequest = WebRequest.Create("https://localhost:44314/api/EMPE?fileName=" & filname)
        Dim oResponse As WebResponse = Await oRequest.GetResponseAsync
        Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream)
        Return Image.FromStream(sr.BaseStream)
    End Function


#End Region

End Class