<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Configuration))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ibtnUpdate = New FontAwesome.Sharp.IconButton()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ibtnRestore = New FontAwesome.Sharp.IconButton()
        Me.ibtnBackUp = New FontAwesome.Sharp.IconButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ibtnUpdate)
        Me.GroupBox1.Controls.Add(Me.txtRate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Location = New System.Drawing.Point(12, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nis Rate"
        '
        'ibtnUpdate
        '
        Me.ibtnUpdate.FlatAppearance.BorderSize = 2
        Me.ibtnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnUpdate.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnUpdate.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnUpdate.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.ibtnUpdate.IconColor = System.Drawing.Color.Gainsboro
        Me.ibtnUpdate.IconSize = 25
        Me.ibtnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnUpdate.Location = New System.Drawing.Point(211, 82)
        Me.ibtnUpdate.Name = "ibtnUpdate"
        Me.ibtnUpdate.Rotation = 0R
        Me.ibtnUpdate.Size = New System.Drawing.Size(106, 35)
        Me.ibtnUpdate.TabIndex = 21
        Me.ibtnUpdate.Text = "Update"
        Me.ibtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnUpdate.UseVisualStyleBackColor = True
        '
        'txtRate
        '
        Me.txtRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRate.Location = New System.Drawing.Point(110, 29)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(101, 24)
        Me.txtRate.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gainsboro
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Percentage:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ProgressBar1)
        Me.GroupBox2.Controls.Add(Me.ibtnRestore)
        Me.GroupBox2.Controls.Add(Me.ibtnBackUp)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Location = New System.Drawing.Point(375, 92)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(405, 126)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Data Base Maintenance"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(19, 37)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(376, 23)
        Me.ProgressBar1.TabIndex = 24
        '
        'ibtnRestore
        '
        Me.ibtnRestore.FlatAppearance.BorderSize = 2
        Me.ibtnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnRestore.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnRestore.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnRestore.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnRestore.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.ibtnRestore.IconColor = System.Drawing.Color.Gainsboro
        Me.ibtnRestore.IconSize = 25
        Me.ibtnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnRestore.Location = New System.Drawing.Point(289, 82)
        Me.ibtnRestore.Name = "ibtnRestore"
        Me.ibtnRestore.Rotation = 0R
        Me.ibtnRestore.Size = New System.Drawing.Size(106, 35)
        Me.ibtnRestore.TabIndex = 23
        Me.ibtnRestore.Text = "Restore"
        Me.ibtnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnRestore.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnRestore.UseVisualStyleBackColor = True
        '
        'ibtnBackUp
        '
        Me.ibtnBackUp.FlatAppearance.BorderSize = 2
        Me.ibtnBackUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(5, Byte), Integer), CType(CType(7, Byte), Integer), CType(CType(11, Byte), Integer))
        Me.ibtnBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ibtnBackUp.Flip = FontAwesome.Sharp.FlipOrientation.Normal
        Me.ibtnBackUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ibtnBackUp.ForeColor = System.Drawing.Color.Gainsboro
        Me.ibtnBackUp.IconChar = FontAwesome.Sharp.IconChar.Edit
        Me.ibtnBackUp.IconColor = System.Drawing.Color.Gainsboro
        Me.ibtnBackUp.IconSize = 25
        Me.ibtnBackUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnBackUp.Location = New System.Drawing.Point(19, 82)
        Me.ibtnBackUp.Name = "ibtnBackUp"
        Me.ibtnBackUp.Rotation = 0R
        Me.ibtnBackUp.Size = New System.Drawing.Size(106, 35)
        Me.ibtnBackUp.TabIndex = 22
        Me.ibtnBackUp.Text = "Back-Up"
        Me.ibtnBackUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ibtnBackUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ibtnBackUp.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'Configuration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1307, 749)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Configuration"
        Me.Text = "Configuration"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtRate As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ibtnUpdate As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnRestore As FontAwesome.Sharp.IconButton
    Friend WithEvents ibtnBackUp As FontAwesome.Sharp.IconButton
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer1 As Timer
End Class
