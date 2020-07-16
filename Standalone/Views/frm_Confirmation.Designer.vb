<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Confirmation
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Confirmation))
        Me.lblEmployerName = New System.Windows.Forms.Label()
        Me.ibtnNO = New FontAwesome.Sharp.IconButton()
        Me.ibtnYes = New FontAwesome.Sharp.IconButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblEmployerName
        '
        Me.lblEmployerName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblEmployerName.AutoSize = True
        Me.lblEmployerName.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.lblEmployerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployerName.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblEmployerName.Location = New System.Drawing.Point(82, 38)
        Me.lblEmployerName.Name = "lblEmployerName"
        Me.lblEmployerName.Size = New System.Drawing.Size(445, 25)
        Me.lblEmployerName.TabIndex = 9
        Me.lblEmployerName.Text = "Please enter your Employer Number and Sub"
        Me.lblEmployerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ibtnNO
        '
        Me.ibtnNO.FlatAppearance.BorderSize = 2
        Me.ibtnNO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnNO.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnNO.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnNO.IconChar = FontAwesome.Sharp.IconChar.NotEqual
        Me.ibtnNO.IconColor = System.Drawing.Color.Red
        Me.ibtnNO.IconSize = 40
        Me.ibtnNO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnNO.Location = New System.Drawing.Point(71, 149)
        Me.ibtnNO.Name = "ibtnNO"
        Me.ibtnNO.Rotation = 0R
        Me.ibtnNO.Size = New System.Drawing.Size(102, 49)
        Me.ibtnNO.TabIndex = 27
        Me.ibtnNO.Text = "NO"
        Me.ibtnNO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnNO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnNO.UseVisualStyleBackColor = True
        '
        'ibtnYes
        '
        Me.ibtnYes.FlatAppearance.BorderSize = 2
        Me.ibtnYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnYes.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnYes.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnYes.IconChar = FontAwesome.Sharp.IconChar.CheckCircle
        Me.ibtnYes.IconColor = System.Drawing.Color.ForestGreen
        Me.ibtnYes.IconSize = 40
        Me.ibtnYes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnYes.Location = New System.Drawing.Point(409, 149)
        Me.ibtnYes.Name = "ibtnYes"
        Me.ibtnYes.Rotation = 0R
        Me.ibtnYes.Size = New System.Drawing.Size(102, 49)
        Me.ibtnYes.TabIndex = 28
        Me.ibtnYes.Text = "Yes"
        Me.ibtnYes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnYes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnYes.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(171, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(241, 20)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Is this your Business Name ?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frm_Confirmation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(577, 235)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ibtnYes)
        Me.Controls.Add(Me.ibtnNO)
        Me.Controls.Add(Me.lblEmployerName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Confirmation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frm_Confirmation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblEmployerName As Label
    Friend WithEvents ibtnNO As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnYes As FontAwesome.Sharp.IconButton
    Friend WithEvents Label1 As Label
End Class
