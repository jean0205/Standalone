<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Employer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Employer))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanelEmployee = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.IconButton1 = New FontAwesome.Sharp.IconButton()
        Me.ibtnCheck = New FontAwesome.Sharp.IconButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNisNumber = New System.Windows.Forms.TextBox()
        Me.PanelEmployee2 = New System.Windows.Forms.Panel()
        Me.chkVoluntary = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbWeeks = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtweek5 = New System.Windows.Forms.TextBox()
        Me.txtEarningsWeekly = New System.Windows.Forms.TextBox()
        Me.txtWeek4 = New System.Windows.Forms.TextBox()
        Me.txtWeek3 = New System.Windows.Forms.TextBox()
        Me.txtWeek2 = New System.Windows.Forms.TextBox()
        Me.txtWeek1 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtConstribution = New System.Windows.Forms.TextBox()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.PanelWeeks = New System.Windows.Forms.Panel()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkweek5 = New System.Windows.Forms.CheckBox()
        Me.chkweek4 = New System.Windows.Forms.CheckBox()
        Me.chkweek3 = New System.Windows.Forms.CheckBox()
        Me.chkweek2 = New System.Windows.Forms.CheckBox()
        Me.chkweek1 = New System.Windows.Forms.CheckBox()
        Me.ibtnAccept = New FontAwesome.Sharp.IconButton()
        Me.dtpBOB = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtearnings = New System.Windows.Forms.TextBox()
        Me.cmbFrequence = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmployeePhone = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmployeeAddress = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CircularProgressBar1 = New CircularProgressBar.CircularProgressBar()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtContrib = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtemployees = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtTotalInteres = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtTotalPenalties = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txttotalContrib = New System.Windows.Forms.TextBox()
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtEmail1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtemail2 = New System.Windows.Forms.TextBox()
        Me.ibtnEmail = New FontAwesome.Sharp.IconButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSub = New System.Windows.Forms.TextBox()
        Me.ibtnAddEmployee = New FontAwesome.Sharp.IconButton()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.PanelEmployee.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PanelEmployee2.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbWeeks.SuspendLayout()
        Me.PanelWeeks.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.PanelEmployee)
        Me.GroupBox1.Controls.Add(Me.CircularProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtContrib)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtemployees)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtTotalInteres)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtTotalPenalties)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txttotalContrib)
        Me.GroupBox1.Controls.Add(Me.dgv1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 151)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1353, 607)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'PanelEmployee
        '
        Me.PanelEmployee.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelEmployee.Controls.Add(Me.GroupBox3)
        Me.PanelEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PanelEmployee.ForeColor = System.Drawing.Color.Gainsboro
        Me.PanelEmployee.Location = New System.Drawing.Point(195, 56)
        Me.PanelEmployee.Name = "PanelEmployee"
        Me.PanelEmployee.Size = New System.Drawing.Size(925, 451)
        Me.PanelEmployee.TabIndex = 1
        Me.PanelEmployee.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.GroupBox3.Controls.Add(Me.IconButton1)
        Me.GroupBox3.Controls.Add(Me.ibtnCheck)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtNisNumber)
        Me.GroupBox3.Controls.Add(Me.PanelEmployee2)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox3.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(909, 442)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Employee Information"
        '
        'IconButton1
        '
        Me.IconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.IconButton1.FlatAppearance.BorderSize = 2
        Me.IconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.IconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.IconButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IconButton1.ForeColor = System.Drawing.Color.Gainsboro
        Me.IconButton1.IconChar = FontAwesome.Sharp.IconChar.WindowClose
        Me.IconButton1.IconColor = System.Drawing.Color.Red
        Me.IconButton1.IconSize = 30
        Me.IconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.IconButton1.Location = New System.Drawing.Point(792, 15)
        Me.IconButton1.Name = "IconButton1"
        Me.IconButton1.Rotation = 0R
        Me.IconButton1.Size = New System.Drawing.Size(108, 38)
        Me.IconButton1.TabIndex = 31
        Me.IconButton1.Text = "Close"
        Me.IconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.IconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.IconButton1.UseVisualStyleBackColor = True
        '
        'ibtnCheck
        '
        Me.ibtnCheck.FlatAppearance.BorderSize = 2
        Me.ibtnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnCheck.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnCheck.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnCheck.IconChar = FontAwesome.Sharp.IconChar.Search
        Me.ibtnCheck.IconColor = System.Drawing.Color.ForestGreen
        Me.ibtnCheck.IconSize = 30
        Me.ibtnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnCheck.Location = New System.Drawing.Point(357, 19)
        Me.ibtnCheck.Name = "ibtnCheck"
        Me.ibtnCheck.Rotation = 0R
        Me.ibtnCheck.Size = New System.Drawing.Size(119, 38)
        Me.ibtnCheck.TabIndex = 29
        Me.ibtnCheck.Text = "Check"
        Me.ibtnCheck.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnCheck.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Employee NIS Number:"
        '
        'txtNisNumber
        '
        Me.txtNisNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNisNumber.Location = New System.Drawing.Point(177, 31)
        Me.txtNisNumber.Name = "txtNisNumber"
        Me.txtNisNumber.Size = New System.Drawing.Size(161, 26)
        Me.txtNisNumber.TabIndex = 4
        '
        'PanelEmployee2
        '
        Me.PanelEmployee2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelEmployee2.Controls.Add(Me.chkVoluntary)
        Me.PanelEmployee2.Controls.Add(Me.GroupBox6)
        Me.PanelEmployee2.Controls.Add(Me.gbWeeks)
        Me.PanelEmployee2.Controls.Add(Me.Label17)
        Me.PanelEmployee2.Controls.Add(Me.txtConstribution)
        Me.PanelEmployee2.Controls.Add(Me.MonthCalendar1)
        Me.PanelEmployee2.Controls.Add(Me.PanelWeeks)
        Me.PanelEmployee2.Controls.Add(Me.ibtnAccept)
        Me.PanelEmployee2.Controls.Add(Me.dtpBOB)
        Me.PanelEmployee2.Controls.Add(Me.Label12)
        Me.PanelEmployee2.Controls.Add(Me.GroupBox4)
        Me.PanelEmployee2.Controls.Add(Me.cmbFrequence)
        Me.PanelEmployee2.Controls.Add(Me.Label10)
        Me.PanelEmployee2.Controls.Add(Me.cmbMonth)
        Me.PanelEmployee2.Controls.Add(Me.cmbYear)
        Me.PanelEmployee2.Controls.Add(Me.Label9)
        Me.PanelEmployee2.Controls.Add(Me.Label8)
        Me.PanelEmployee2.Controls.Add(Me.txtEmployeePhone)
        Me.PanelEmployee2.Controls.Add(Me.Label7)
        Me.PanelEmployee2.Controls.Add(Me.txtEmployeeAddress)
        Me.PanelEmployee2.Controls.Add(Me.Label6)
        Me.PanelEmployee2.Controls.Add(Me.txtEmployeeName)
        Me.PanelEmployee2.Controls.Add(Me.Label5)
        Me.PanelEmployee2.Location = New System.Drawing.Point(8, 76)
        Me.PanelEmployee2.Name = "PanelEmployee2"
        Me.PanelEmployee2.Size = New System.Drawing.Size(895, 360)
        Me.PanelEmployee2.TabIndex = 30
        Me.PanelEmployee2.Visible = False
        '
        'chkVoluntary
        '
        Me.chkVoluntary.AutoSize = True
        Me.chkVoluntary.Location = New System.Drawing.Point(555, 101)
        Me.chkVoluntary.Name = "chkVoluntary"
        Me.chkVoluntary.Size = New System.Drawing.Size(166, 22)
        Me.chkVoluntary.TabIndex = 36
        Me.chkVoluntary.Text = "Voluntary Contributor"
        Me.chkVoluntary.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.PictureBox1)
        Me.GroupBox6.Location = New System.Drawing.Point(782, -5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(102, 132)
        Me.GroupBox6.TabIndex = 35
        Me.GroupBox6.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(2, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(97, 115)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 34
        Me.PictureBox1.TabStop = False
        '
        'gbWeeks
        '
        Me.gbWeeks.Controls.Add(Me.Label13)
        Me.gbWeeks.Controls.Add(Me.txtweek5)
        Me.gbWeeks.Controls.Add(Me.txtEarningsWeekly)
        Me.gbWeeks.Controls.Add(Me.txtWeek4)
        Me.gbWeeks.Controls.Add(Me.txtWeek3)
        Me.gbWeeks.Controls.Add(Me.txtWeek2)
        Me.gbWeeks.Controls.Add(Me.txtWeek1)
        Me.gbWeeks.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbWeeks.ForeColor = System.Drawing.Color.Gainsboro
        Me.gbWeeks.Location = New System.Drawing.Point(4, 235)
        Me.gbWeeks.Name = "gbWeeks"
        Me.gbWeeks.Size = New System.Drawing.Size(481, 105)
        Me.gbWeeks.TabIndex = 1
        Me.gbWeeks.TabStop = False
        Me.gbWeeks.Text = "Enter Insurable Earnings per worked weeks"
        Me.gbWeeks.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(184, 75)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(133, 18)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Insurable Earnings:"
        '
        'txtweek5
        '
        Me.txtweek5.Enabled = False
        Me.txtweek5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtweek5.Location = New System.Drawing.Point(388, 29)
        Me.txtweek5.Name = "txtweek5"
        Me.txtweek5.Size = New System.Drawing.Size(82, 26)
        Me.txtweek5.TabIndex = 35
        Me.txtweek5.Tag = "5"
        '
        'txtEarningsWeekly
        '
        Me.txtEarningsWeekly.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEarningsWeekly.Location = New System.Drawing.Point(327, 72)
        Me.txtEarningsWeekly.Name = "txtEarningsWeekly"
        Me.txtEarningsWeekly.ReadOnly = True
        Me.txtEarningsWeekly.Size = New System.Drawing.Size(146, 24)
        Me.txtEarningsWeekly.TabIndex = 36
        '
        'txtWeek4
        '
        Me.txtWeek4.Enabled = False
        Me.txtWeek4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek4.Location = New System.Drawing.Point(293, 29)
        Me.txtWeek4.Name = "txtWeek4"
        Me.txtWeek4.Size = New System.Drawing.Size(82, 26)
        Me.txtWeek4.TabIndex = 34
        Me.txtWeek4.Tag = "4"
        '
        'txtWeek3
        '
        Me.txtWeek3.Enabled = False
        Me.txtWeek3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek3.Location = New System.Drawing.Point(198, 29)
        Me.txtWeek3.Name = "txtWeek3"
        Me.txtWeek3.Size = New System.Drawing.Size(82, 26)
        Me.txtWeek3.TabIndex = 33
        Me.txtWeek3.Tag = "3"
        '
        'txtWeek2
        '
        Me.txtWeek2.Enabled = False
        Me.txtWeek2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek2.Location = New System.Drawing.Point(102, 29)
        Me.txtWeek2.Name = "txtWeek2"
        Me.txtWeek2.Size = New System.Drawing.Size(82, 26)
        Me.txtWeek2.TabIndex = 32
        Me.txtWeek2.Tag = "2"
        '
        'txtWeek1
        '
        Me.txtWeek1.Enabled = False
        Me.txtWeek1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeek1.Location = New System.Drawing.Point(8, 29)
        Me.txtWeek1.Name = "txtWeek1"
        Me.txtWeek1.Size = New System.Drawing.Size(82, 26)
        Me.txtWeek1.TabIndex = 31
        Me.txtWeek1.Tag = "1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Constantia", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.PaleGreen
        Me.Label17.Location = New System.Drawing.Point(491, 327)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(141, 23)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Contributions:"
        '
        'txtConstribution
        '
        Me.txtConstribution.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConstribution.ForeColor = System.Drawing.Color.Red
        Me.txtConstribution.Location = New System.Drawing.Point(634, 323)
        Me.txtConstribution.Name = "txtConstribution"
        Me.txtConstribution.ReadOnly = True
        Me.txtConstribution.Size = New System.Drawing.Size(114, 29)
        Me.txtConstribution.TabIndex = 18
        Me.txtConstribution.Text = "$"
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.MonthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday
        Me.MonthCalendar1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.MonthCalendar1.Location = New System.Drawing.Point(635, 135)
        Me.MonthCalendar1.MaxSelectionCount = 31
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.ShowWeekNumbers = True
        Me.MonthCalendar1.TabIndex = 32
        Me.MonthCalendar1.TitleBackColor = System.Drawing.Color.Honeydew
        Me.MonthCalendar1.TrailingForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.MonthCalendar1.Visible = False
        '
        'PanelWeeks
        '
        Me.PanelWeeks.Controls.Add(Me.GroupBox5)
        Me.PanelWeeks.Location = New System.Drawing.Point(3, 144)
        Me.PanelWeeks.Name = "PanelWeeks"
        Me.PanelWeeks.Size = New System.Drawing.Size(490, 81)
        Me.PanelWeeks.TabIndex = 31
        Me.PanelWeeks.Visible = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkweek5)
        Me.GroupBox5.Controls.Add(Me.chkweek4)
        Me.GroupBox5.Controls.Add(Me.chkweek3)
        Me.GroupBox5.Controls.Add(Me.chkweek2)
        Me.GroupBox5.Controls.Add(Me.chkweek1)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox5.Location = New System.Drawing.Point(3, 11)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(481, 66)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Select Worked Weeks"
        '
        'chkweek5
        '
        Me.chkweek5.AutoSize = True
        Me.chkweek5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkweek5.Location = New System.Drawing.Point(392, 25)
        Me.chkweek5.Name = "chkweek5"
        Me.chkweek5.Size = New System.Drawing.Size(78, 22)
        Me.chkweek5.TabIndex = 4
        Me.chkweek5.Tag = "5"
        Me.chkweek5.Text = "Week 5"
        Me.chkweek5.UseVisualStyleBackColor = True
        '
        'chkweek4
        '
        Me.chkweek4.AutoSize = True
        Me.chkweek4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkweek4.Location = New System.Drawing.Point(297, 25)
        Me.chkweek4.Name = "chkweek4"
        Me.chkweek4.Size = New System.Drawing.Size(78, 22)
        Me.chkweek4.TabIndex = 3
        Me.chkweek4.Tag = "4"
        Me.chkweek4.Text = "Week 4"
        Me.chkweek4.UseVisualStyleBackColor = True
        '
        'chkweek3
        '
        Me.chkweek3.AutoSize = True
        Me.chkweek3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkweek3.Location = New System.Drawing.Point(202, 25)
        Me.chkweek3.Name = "chkweek3"
        Me.chkweek3.Size = New System.Drawing.Size(78, 22)
        Me.chkweek3.TabIndex = 2
        Me.chkweek3.Tag = "3"
        Me.chkweek3.Text = "Week 3"
        Me.chkweek3.UseVisualStyleBackColor = True
        '
        'chkweek2
        '
        Me.chkweek2.AutoSize = True
        Me.chkweek2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkweek2.Location = New System.Drawing.Point(107, 25)
        Me.chkweek2.Name = "chkweek2"
        Me.chkweek2.Size = New System.Drawing.Size(78, 22)
        Me.chkweek2.TabIndex = 1
        Me.chkweek2.Tag = "2"
        Me.chkweek2.Text = "Week 2"
        Me.chkweek2.UseVisualStyleBackColor = True
        '
        'chkweek1
        '
        Me.chkweek1.AutoSize = True
        Me.chkweek1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkweek1.Location = New System.Drawing.Point(12, 25)
        Me.chkweek1.Name = "chkweek1"
        Me.chkweek1.Size = New System.Drawing.Size(78, 22)
        Me.chkweek1.TabIndex = 0
        Me.chkweek1.Tag = "1"
        Me.chkweek1.Text = "Week 1"
        Me.chkweek1.UseVisualStyleBackColor = True
        '
        'ibtnAccept
        '
        Me.ibtnAccept.FlatAppearance.BorderSize = 2
        Me.ibtnAccept.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnAccept.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnAccept.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnAccept.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnAccept.IconChar = FontAwesome.Sharp.IconChar.Table
        Me.ibtnAccept.IconColor = System.Drawing.Color.ForestGreen
        Me.ibtnAccept.IconSize = 30
        Me.ibtnAccept.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnAccept.Location = New System.Drawing.Point(763, 309)
        Me.ibtnAccept.Name = "ibtnAccept"
        Me.ibtnAccept.Rotation = 0R
        Me.ibtnAccept.Size = New System.Drawing.Size(119, 43)
        Me.ibtnAccept.TabIndex = 30
        Me.ibtnAccept.Text = "Accept"
        Me.ibtnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnAccept.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnAccept.UseVisualStyleBackColor = True
        '
        'dtpBOB
        '
        Me.dtpBOB.Enabled = False
        Me.dtpBOB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBOB.Location = New System.Drawing.Point(527, 12)
        Me.dtpBOB.Name = "dtpBOB"
        Me.dtpBOB.Size = New System.Drawing.Size(119, 24)
        Me.dtpBOB.TabIndex = 28
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(478, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 18)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "DOB:"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.txtearnings)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox4.Location = New System.Drawing.Point(4, 262)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox4.Size = New System.Drawing.Size(481, 78)
        Me.GroupBox4.TabIndex = 26
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Enter Insurable Earnings for the month"
        Me.GroupBox4.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(180, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 18)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "Insurable Earnings:"
        '
        'txtearnings
        '
        Me.txtearnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtearnings.Location = New System.Drawing.Point(319, 46)
        Me.txtearnings.Name = "txtearnings"
        Me.txtearnings.Size = New System.Drawing.Size(146, 24)
        Me.txtearnings.TabIndex = 16
        '
        'cmbFrequence
        '
        Me.cmbFrequence.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFrequence.FormattingEnabled = True
        Me.cmbFrequence.Items.AddRange(New Object() {"Select", "Monthly", "Weekly"})
        Me.cmbFrequence.Location = New System.Drawing.Point(409, 102)
        Me.cmbFrequence.Name = "cmbFrequence"
        Me.cmbFrequence.Size = New System.Drawing.Size(117, 26)
        Me.cmbFrequence.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(326, 106)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 18)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Frequence:"
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Items.AddRange(New Object() {"Select", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.cmbMonth.Location = New System.Drawing.Point(200, 102)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(117, 26)
        Me.cmbMonth.TabIndex = 12
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(50, 102)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(85, 26)
        Me.cmbYear.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(146, 106)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 18)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Month:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(7, 106)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 18)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Year:"
        '
        'txtEmployeePhone
        '
        Me.txtEmployeePhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeePhone.Location = New System.Drawing.Point(527, 48)
        Me.txtEmployeePhone.Name = "txtEmployeePhone"
        Me.txtEmployeePhone.ReadOnly = True
        Me.txtEmployeePhone.Size = New System.Drawing.Size(122, 26)
        Me.txtEmployeePhone.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(473, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 18)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Phone:"
        '
        'txtEmployeeAddress
        '
        Me.txtEmployeeAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeAddress.Location = New System.Drawing.Point(79, 44)
        Me.txtEmployeeAddress.Name = "txtEmployeeAddress"
        Me.txtEmployeeAddress.ReadOnly = True
        Me.txtEmployeeAddress.Size = New System.Drawing.Size(378, 26)
        Me.txtEmployeeAddress.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 18)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Address:"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmployeeName.Location = New System.Drawing.Point(79, 8)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(378, 26)
        Me.txtEmployeeName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Name:"
        '
        'CircularProgressBar1
        '
        Me.CircularProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.CircularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner
        Me.CircularProgressBar1.AnimationSpeed = 500
        Me.CircularProgressBar1.BackColor = System.Drawing.Color.Transparent
        Me.CircularProgressBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 70.0!, System.Drawing.FontStyle.Bold)
        Me.CircularProgressBar1.ForeColor = System.Drawing.Color.Silver
        Me.CircularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(49, Byte), Integer))
        Me.CircularProgressBar1.InnerMargin = 1
        Me.CircularProgressBar1.InnerWidth = -1
        Me.CircularProgressBar1.Location = New System.Drawing.Point(483, 91)
        Me.CircularProgressBar1.MarqueeAnimationSpeed = 2000
        Me.CircularProgressBar1.Name = "CircularProgressBar1"
        Me.CircularProgressBar1.OuterColor = System.Drawing.Color.Green
        Me.CircularProgressBar1.OuterMargin = -25
        Me.CircularProgressBar1.OuterWidth = 26
        Me.CircularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularProgressBar1.ProgressWidth = 25
        Me.CircularProgressBar1.SecondaryFont = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.CircularProgressBar1.Size = New System.Drawing.Size(320, 320)
        Me.CircularProgressBar1.StartAngle = 275
        Me.CircularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.CircularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.CircularProgressBar1.SubscriptMargin = New System.Windows.Forms.Padding(10, -35, 0, 0)
        Me.CircularProgressBar1.SubscriptText = ""
        Me.CircularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.CircularProgressBar1.SuperscriptMargin = New System.Windows.Forms.Padding(10, 35, 0, 0)
        Me.CircularProgressBar1.SuperscriptText = "%"
        Me.CircularProgressBar1.TabIndex = 309
        Me.CircularProgressBar1.Text = "0"
        Me.CircularProgressBar1.TextMargin = New System.Windows.Forms.Padding(8, 8, 0, 0)
        Me.CircularProgressBar1.Value = 68
        Me.CircularProgressBar1.Visible = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label15.Location = New System.Drawing.Point(437, 574)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 20)
        Me.Label15.TabIndex = 35
        Me.Label15.Text = "Contributions:"
        '
        'txtContrib
        '
        Me.txtContrib.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContrib.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtContrib.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtContrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContrib.ForeColor = System.Drawing.Color.Gainsboro
        Me.txtContrib.Location = New System.Drawing.Point(558, 575)
        Me.txtContrib.Name = "txtContrib"
        Me.txtContrib.ReadOnly = True
        Me.txtContrib.Size = New System.Drawing.Size(95, 19)
        Me.txtContrib.TabIndex = 34
        Me.txtContrib.Text = "$"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label14.Location = New System.Drawing.Point(18, 574)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(101, 20)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Employees:"
        '
        'txtemployees
        '
        Me.txtemployees.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtemployees.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtemployees.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtemployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemployees.ForeColor = System.Drawing.Color.Gainsboro
        Me.txtemployees.Location = New System.Drawing.Point(120, 575)
        Me.txtemployees.Name = "txtemployees"
        Me.txtemployees.ReadOnly = True
        Me.txtemployees.Size = New System.Drawing.Size(66, 19)
        Me.txtemployees.TabIndex = 32
        '
        'Label20
        '
        Me.Label20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label20.Location = New System.Drawing.Point(880, 574)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 20)
        Me.Label20.TabIndex = 31
        Me.Label20.Text = "Interest:"
        '
        'txtTotalInteres
        '
        Me.txtTotalInteres.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalInteres.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtTotalInteres.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalInteres.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalInteres.ForeColor = System.Drawing.Color.Gainsboro
        Me.txtTotalInteres.Location = New System.Drawing.Point(957, 575)
        Me.txtTotalInteres.Name = "txtTotalInteres"
        Me.txtTotalInteres.ReadOnly = True
        Me.txtTotalInteres.Size = New System.Drawing.Size(95, 19)
        Me.txtTotalInteres.TabIndex = 30
        Me.txtTotalInteres.Text = "$"
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label19.Location = New System.Drawing.Point(678, 574)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(88, 20)
        Me.Label19.TabIndex = 29
        Me.Label19.Text = "Penalties:"
        '
        'txtTotalPenalties
        '
        Me.txtTotalPenalties.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalPenalties.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txtTotalPenalties.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalPenalties.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPenalties.ForeColor = System.Drawing.Color.Gainsboro
        Me.txtTotalPenalties.Location = New System.Drawing.Point(768, 575)
        Me.txtTotalPenalties.Name = "txtTotalPenalties"
        Me.txtTotalPenalties.ReadOnly = True
        Me.txtTotalPenalties.Size = New System.Drawing.Size(95, 19)
        Me.txtTotalPenalties.TabIndex = 28
        Me.txtTotalPenalties.Text = "$"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label18.Location = New System.Drawing.Point(1074, 569)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(135, 25)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Total to Pay:"
        '
        'txttotalContrib
        '
        Me.txttotalContrib.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txttotalContrib.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.txttotalContrib.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txttotalContrib.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttotalContrib.ForeColor = System.Drawing.Color.Gainsboro
        Me.txttotalContrib.Location = New System.Drawing.Point(1208, 571)
        Me.txttotalContrib.Name = "txttotalContrib"
        Me.txttotalContrib.ReadOnly = True
        Me.txttotalContrib.Size = New System.Drawing.Size(125, 23)
        Me.txttotalContrib.TabIndex = 26
        Me.txttotalContrib.Text = "$"
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgv1.Location = New System.Drawing.Point(6, 19)
        Me.dgv1.MultiSelect = False
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.RowHeadersVisible = False
        Me.dgv1.RowHeadersWidth = 50
        Me.dgv1.RowTemplate.Height = 35
        Me.dgv1.Size = New System.Drawing.Size(1341, 525)
        Me.dgv1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.GroupBox7)
        Me.GroupBox2.Controls.Add(Me.ibtnEmail)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtSub)
        Me.GroupBox2.Controls.Add(Me.ibtnAddEmployee)
        Me.GroupBox2.Controls.Add(Me.txtName)
        Me.GroupBox2.Controls.Add(Me.txtNumber)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1353, 140)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Employer Information"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtEmail1)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.txtemail2)
        Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox7.Location = New System.Drawing.Point(518, 22)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(457, 98)
        Me.GroupBox7.TabIndex = 37
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Enter your email address here to get a copy of the remittance forms"
        '
        'txtEmail1
        '
        Me.txtEmail1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail1.Location = New System.Drawing.Point(73, 24)
        Me.txtEmail1.Name = "txtEmail1"
        Me.txtEmail1.Size = New System.Drawing.Size(344, 26)
        Me.txtEmail1.TabIndex = 36
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(58, 17)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Email 2:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 27)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 17)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "Email 1:"
        '
        'txtemail2
        '
        Me.txtemail2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtemail2.Location = New System.Drawing.Point(73, 60)
        Me.txtemail2.Name = "txtemail2"
        Me.txtemail2.Size = New System.Drawing.Size(344, 26)
        Me.txtemail2.TabIndex = 34
        '
        'ibtnEmail
        '
        Me.ibtnEmail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ibtnEmail.BackColor = System.Drawing.Color.DarkOrange
        Me.ibtnEmail.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.ibtnEmail.FlatAppearance.BorderSize = 2
        Me.ibtnEmail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ibtnEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ibtnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnEmail.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnEmail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ibtnEmail.IconChar = FontAwesome.Sharp.IconChar.EnvelopeOpenText
        Me.ibtnEmail.IconColor = System.Drawing.Color.ForestGreen
        Me.ibtnEmail.IconSize = 60
        Me.ibtnEmail.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ibtnEmail.Location = New System.Drawing.Point(1169, 33)
        Me.ibtnEmail.Name = "ibtnEmail"
        Me.ibtnEmail.Rotation = 0R
        Me.ibtnEmail.Size = New System.Drawing.Size(179, 87)
        Me.ibtnEmail.TabIndex = 32
        Me.ibtnEmail.Text = "Submit Form"
        Me.ibtnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnEmail.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(307, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 20)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Sub:"
        '
        'txtSub
        '
        Me.txtSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSub.Location = New System.Drawing.Point(348, 35)
        Me.txtSub.Name = "txtSub"
        Me.txtSub.ReadOnly = True
        Me.txtSub.Size = New System.Drawing.Size(60, 26)
        Me.txtSub.TabIndex = 30
        '
        'ibtnAddEmployee
        '
        Me.ibtnAddEmployee.FlatAppearance.BorderSize = 2
        Me.ibtnAddEmployee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnAddEmployee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnAddEmployee.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnAddEmployee.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnAddEmployee.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnAddEmployee.IconChar = FontAwesome.Sharp.IconChar.Plus
        Me.ibtnAddEmployee.IconColor = System.Drawing.Color.ForestGreen
        Me.ibtnAddEmployee.IconSize = 45
        Me.ibtnAddEmployee.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ibtnAddEmployee.Location = New System.Drawing.Point(994, 33)
        Me.ibtnAddEmployee.Name = "ibtnAddEmployee"
        Me.ibtnAddEmployee.Rotation = 0R
        Me.ibtnAddEmployee.Size = New System.Drawing.Size(165, 87)
        Me.ibtnAddEmployee.TabIndex = 29
        Me.ibtnAddEmployee.Text = "Add Employee"
        Me.ibtnAddEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnAddEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnAddEmployee.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(146, 83)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(344, 26)
        Me.txtName.TabIndex = 3
        '
        'txtNumber
        '
        Me.txtNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumber.Location = New System.Drawing.Point(148, 35)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.ReadOnly = True
        Me.txtNumber.Size = New System.Drawing.Size(151, 26)
        Me.txtNumber.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Employer Number:"
        '
        'Timer1
        '
        '
        'Frm_Employer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1377, 770)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_Employer"
        Me.Text = "Electronic Remittance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelEmployee.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PanelEmployee2.ResumeLayout(False)
        Me.PanelEmployee2.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbWeeks.ResumeLayout(False)
        Me.gbWeeks.PerformLayout()
        Me.PanelWeeks.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtNumber As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PanelEmployee As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNisNumber As TextBox
    Friend WithEvents ibtnAddEmployee As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnCheck As FontAwesome.Sharp.IconButton
    Friend WithEvents Label4 As Label
    Friend WithEvents txtSub As TextBox
    Friend WithEvents PanelEmployee2 As Panel
    Friend WithEvents txtEmployeePhone As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtEmployeeAddress As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmployeeName As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtearnings As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbFrequence As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtConstribution As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtpBOB As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents ibtnAccept As FontAwesome.Sharp.IconButton
    Friend WithEvents PanelWeeks As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents chkweek5 As CheckBox
    Friend WithEvents chkweek4 As CheckBox
    Friend WithEvents chkweek3 As CheckBox
    Friend WithEvents chkweek2 As CheckBox
    Friend WithEvents chkweek1 As CheckBox
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents gbWeeks As GroupBox
    Friend WithEvents txtweek5 As TextBox
    Friend WithEvents txtWeek4 As TextBox
    Friend WithEvents txtWeek3 As TextBox
    Friend WithEvents txtWeek2 As TextBox
    Friend WithEvents txtWeek1 As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txttotalContrib As TextBox
    Friend WithEvents ibtnEmail As FontAwesome.Sharp.IconButton
    Friend WithEvents Label20 As Label
    Friend WithEvents txtTotalInteres As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtTotalPenalties As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtEarningsWeekly As TextBox
    Friend WithEvents IconButton1 As FontAwesome.Sharp.IconButton
    Friend WithEvents Label14 As Label
    Friend WithEvents txtemployees As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtContrib As TextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtEmail1 As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents txtemail2 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents CircularProgressBar1 As CircularProgressBar.CircularProgressBar
    Friend WithEvents Timer1 As Timer
    Friend WithEvents chkVoluntary As CheckBox
End Class
