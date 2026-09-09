Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SubjectsForm
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
            Me.btnAddSubject = New SchoolManagement.App.Controls.ModernButton()
            Me.btnCurriculumGuide = New SchoolManagement.App.Controls.ModernButton()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblStats = New System.Windows.Forms.Label()
            Me.dgvSubjects = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colSubjCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colSubjName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colGradeLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMaxGrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPassingGrade = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colWeeklyHours = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTeacher = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnAddSubject)
            Me.pnlTop.Controls.Add(Me.btnCurriculumGuide)
            Me.pnlTop.Controls.Add(Me.lblTitle)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnAddSubject
            '
            Me.btnAddSubject.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnAddSubject.BorderRadius = 8
            Me.btnAddSubject.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnAddSubject.FlatAppearance.BorderSize = 0
            Me.btnAddSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddSubject.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnAddSubject.ForeColor = System.Drawing.Color.White
            Me.btnAddSubject.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnAddSubject.Location = New System.Drawing.Point(12, 12)
            Me.btnAddSubject.Name = "btnAddSubject"
            Me.btnAddSubject.Size = New System.Drawing.Size(150, 40)
            Me.btnAddSubject.TabIndex = 0
            Me.btnAddSubject.Text = "➕ إضافة مادة دراسية"
            Me.btnAddSubject.UseVisualStyleBackColor = False
            '
            'btnCurriculumGuide
            '
            Me.btnCurriculumGuide.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnCurriculumGuide.BorderRadius = 8
            Me.btnCurriculumGuide.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCurriculumGuide.FlatAppearance.BorderSize = 0
            Me.btnCurriculumGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCurriculumGuide.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnCurriculumGuide.ForeColor = System.Drawing.Color.White
            Me.btnCurriculumGuide.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnCurriculumGuide.Location = New System.Drawing.Point(170, 12)
            Me.btnCurriculumGuide.Name = "btnCurriculumGuide"
            Me.btnCurriculumGuide.Size = New System.Drawing.Size(150, 40)
            Me.btnCurriculumGuide.TabIndex = 1
            Me.btnCurriculumGuide.Text = "📖 دليل المناهج الوزارية"
            Me.btnCurriculumGuide.UseVisualStyleBackColor = False
            '
            'lblTitle
            '
            Me.lblTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTitle.AutoSize = True
            Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
            Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblTitle.Location = New System.Drawing.Point(710, 22)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(225, 20)
            Me.lblTitle.TabIndex = 2
            Me.lblTitle.Text = "📚 المناهج والمقررات الوزارية (العراق)"
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
            Me.lblStats.Text = "إجمالي المواد المقررة: 7 مواد أساسية"
            Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgvSubjects
            '
            Me.dgvSubjects.AllowUserToAddRows = False
            Me.dgvSubjects.AllowUserToDeleteRows = False
            Me.dgvSubjects.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvSubjects.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvSubjects.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvSubjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSubjCode, Me.colSubjName, Me.colGradeLevel, Me.colMaxGrade, Me.colPassingGrade, Me.colWeeklyHours, Me.colTeacher})
            Me.dgvSubjects.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvSubjects.EnableHeadersVisualStyles = False
            Me.dgvSubjects.Location = New System.Drawing.Point(0, 65)
            Me.dgvSubjects.Name = "dgvSubjects"
            Me.dgvSubjects.ReadOnly = True
            Me.dgvSubjects.RowHeadersVisible = False
            Me.dgvSubjects.RowTemplate.Height = 38
            Me.dgvSubjects.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvSubjects.Size = New System.Drawing.Size(950, 460)
            Me.dgvSubjects.TabIndex = 2
            '
            'colSubjCode
            '
            Me.colSubjCode.FillWeight = 80.0!
            Me.colSubjCode.HeaderText = "رمز المادة"
            Me.colSubjCode.Name = "colSubjCode"
            Me.colSubjCode.ReadOnly = True
            '
            'colSubjName
            '
            Me.colSubjName.FillWeight = 160.0!
            Me.colSubjName.HeaderText = "اسم المادة الدراسية"
            Me.colSubjName.Name = "colSubjName"
            Me.colSubjName.ReadOnly = True
            '
            'colGradeLevel
            '
            Me.colGradeLevel.FillWeight = 110.0!
            Me.colGradeLevel.HeaderText = "المرحلة الدراسية"
            Me.colGradeLevel.Name = "colGradeLevel"
            Me.colGradeLevel.ReadOnly = True
            '
            'colMaxGrade
            '
            Me.colMaxGrade.FillWeight = 75.0!
            Me.colMaxGrade.HeaderText = "الدرجة العظمى"
            Me.colMaxGrade.Name = "colMaxGrade"
            Me.colMaxGrade.ReadOnly = True
            '
            'colPassingGrade
            '
            Me.colPassingGrade.FillWeight = 75.0!
            Me.colPassingGrade.HeaderText = "درجة النجاح (الصغرى)"
            Me.colPassingGrade.Name = "colPassingGrade"
            Me.colPassingGrade.ReadOnly = True
            '
            'colWeeklyHours
            '
            Me.colWeeklyHours.FillWeight = 75.0!
            Me.colWeeklyHours.HeaderText = "الحصص أسبوعياً"
            Me.colWeeklyHours.Name = "colWeeklyHours"
            Me.colWeeklyHours.ReadOnly = True
            '
            'colTeacher
            '
            Me.colTeacher.FillWeight = 140.0!
            Me.colTeacher.HeaderText = "المدرس المشرف"
            Me.colTeacher.Name = "colTeacher"
            Me.colTeacher.ReadOnly = True
            '
            'SubjectsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvSubjects)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "SubjectsForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "المواد والمناهج"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvSubjects, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnAddSubject As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnCurriculumGuide As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblStats As System.Windows.Forms.Label
        Friend WithEvents dgvSubjects As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colSubjCode As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSubjName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colGradeLevel As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMaxGrade As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPassingGrade As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colWeeklyHours As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTeacher As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
