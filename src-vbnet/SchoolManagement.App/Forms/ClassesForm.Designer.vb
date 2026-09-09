Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ClassesForm
        Inherits System.Windows.Forms.Form

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

        Private components As System.ComponentModel.IContainer

        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pnlTop = New System.Windows.Forms.Panel()
            Me.btnAddClass = New SchoolManagement.App.Controls.ModernButton()
            Me.btnEditClass = New SchoolManagement.App.Controls.ModernButton()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblStats = New System.Windows.Forms.Label()
            Me.dgvClasses = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colClassId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colClassName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colSection = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStage = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colCapacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colEnrolled = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRoom = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAdvisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvClasses, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnAddClass)
            Me.pnlTop.Controls.Add(Me.btnEditClass)
            Me.pnlTop.Controls.Add(Me.lblTitle)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnAddClass
            '
            Me.btnAddClass.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnAddClass.BorderRadius = 8
            Me.btnAddClass.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnAddClass.FlatAppearance.BorderSize = 0
            Me.btnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddClass.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnAddClass.ForeColor = System.Drawing.Color.White
            Me.btnAddClass.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnAddClass.Location = New System.Drawing.Point(12, 12)
            Me.btnAddClass.Name = "btnAddClass"
            Me.btnAddClass.Size = New System.Drawing.Size(150, 40)
            Me.btnAddClass.TabIndex = 0
            Me.btnAddClass.Text = "➕ فتح شعبة جديدة"
            Me.btnAddClass.UseVisualStyleBackColor = False
            '
            'btnEditClass
            '
            Me.btnEditClass.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnEditClass.BorderRadius = 8
            Me.btnEditClass.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnEditClass.FlatAppearance.BorderSize = 0
            Me.btnEditClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnEditClass.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnEditClass.ForeColor = System.Drawing.Color.White
            Me.btnEditClass.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnEditClass.Location = New System.Drawing.Point(170, 12)
            Me.btnEditClass.Name = "btnEditClass"
            Me.btnEditClass.Size = New System.Drawing.Size(120, 40)
            Me.btnEditClass.TabIndex = 1
            Me.btnEditClass.Text = "تعديل الشعبة"
            Me.btnEditClass.UseVisualStyleBackColor = False
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblTitle.Location = New System.Drawing.Point(740, 22)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(194, 20)
            Me.lblTitle.TabIndex = 2
            Me.lblTitle.Text = "🏫 إدارة الصفوف والشعب الدراسية"
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlBottom.Controls.Add(Me.lblStats)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(0, 525)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
            Me.pnlBottom.Size = New System.Drawing.Size(950, 35)
            Me.pnlBottom.TabIndex = 1
            '
            'lblStats
            '
            Me.lblStats.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblStats.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblStats.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblStats.Location = New System.Drawing.Point(650, 8)
            Me.lblStats.Name = "lblStats"
            Me.lblStats.Size = New System.Drawing.Size(285, 19)
            Me.lblStats.TabIndex = 0
            Me.lblStats.Text = "إجمالي عدد الشعب الفعالة: 6 شعب"
            Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgvClasses
            '
            Me.dgvClasses.AllowUserToAddRows = False
            Me.dgvClasses.AllowUserToDeleteRows = False
            Me.dgvClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvClasses.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvClasses.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvClasses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colClassId, Me.colClassName, Me.colSection, Me.colStage, Me.colCapacity, Me.colEnrolled, Me.colRoom, Me.colAdvisor})
            Me.dgvClasses.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvClasses.EnableHeadersVisualStyles = False
            Me.dgvClasses.Location = New System.Drawing.Point(0, 65)
            Me.dgvClasses.Name = "dgvClasses"
            Me.dgvClasses.ReadOnly = True
            Me.dgvClasses.RowHeadersVisible = False
            Me.dgvClasses.RowTemplate.Height = 38
            Me.dgvClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvClasses.Size = New System.Drawing.Size(950, 460)
            Me.dgvClasses.TabIndex = 2
            '
            'colClassId
            '
            Me.colClassId.FillWeight = 70.0!
            Me.colClassId.HeaderText = "رمز الصف"
            Me.colClassId.Name = "colClassId"
            Me.colClassId.ReadOnly = True
            '
            'colClassName
            '
            Me.colClassName.FillWeight = 140.0!
            Me.colClassName.HeaderText = "اسم المرحلة والصف"
            Me.colClassName.Name = "colClassName"
            Me.colClassName.ReadOnly = True
            '
            'colSection
            '
            Me.colSection.FillWeight = 80.0!
            Me.colSection.HeaderText = "الشعبة"
            Me.colSection.Name = "colSection"
            Me.colSection.ReadOnly = True
            '
            'colStage
            '
            Me.colStage.FillWeight = 100.0!
            Me.colStage.HeaderText = "المرحلة الدراسية"
            Me.colStage.Name = "colStage"
            Me.colStage.ReadOnly = True
            '
            'colCapacity
            '
            Me.colCapacity.FillWeight = 75.0!
            Me.colCapacity.HeaderText = "السعة القصوى"
            Me.colCapacity.Name = "colCapacity"
            Me.colCapacity.ReadOnly = True
            '
            'colEnrolled
            '
            Me.colEnrolled.FillWeight = 75.0!
            Me.colEnrolled.HeaderText = "المسجلون"
            Me.colEnrolled.Name = "colEnrolled"
            Me.colEnrolled.ReadOnly = True
            '
            'colRoom
            '
            Me.colRoom.FillWeight = 90.0!
            Me.colRoom.HeaderText = "القاعة الدراسية"
            Me.colRoom.Name = "colRoom"
            Me.colRoom.ReadOnly = True
            '
            'colAdvisor
            '
            Me.colAdvisor.FillWeight = 150.0!
            Me.colAdvisor.HeaderText = "مربي الصف (المرشد)"
            Me.colAdvisor.Name = "colAdvisor"
            Me.colAdvisor.ReadOnly = True
            '
            'ClassesForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvClasses)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "ClassesForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "الصفوف والشعب"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvClasses, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnAddClass As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnEditClass As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblStats As System.Windows.Forms.Label
        Friend WithEvents dgvClasses As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colClassId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colClassName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSection As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStage As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colCapacity As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colEnrolled As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRoom As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAdvisor As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
