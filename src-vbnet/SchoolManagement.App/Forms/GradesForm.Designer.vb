Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class GradesForm
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
            Me.btnSaveGrades = New SchoolManagement.App.Controls.ModernButton()
            Me.btnExportMasterSheet = New SchoolManagement.App.Controls.ModernButton()
            Me.cboSubject = New System.Windows.Forms.ComboBox()
            Me.lblSubject = New System.Windows.Forms.Label()
            Me.cboClass = New System.Windows.Forms.ComboBox()
            Me.lblClass = New System.Windows.Forms.Label()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblGradeStats = New System.Windows.Forms.Label()
            Me.dgvGrades = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colStudentId = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMonth1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMonth2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTerm1Quest = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMidYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAnnualQuest = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinalExam = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinalAverage = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colEvaluation = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnSaveGrades)
            Me.pnlTop.Controls.Add(Me.btnExportMasterSheet)
            Me.pnlTop.Controls.Add(Me.cboSubject)
            Me.pnlTop.Controls.Add(Me.lblSubject)
            Me.pnlTop.Controls.Add(Me.cboClass)
            Me.pnlTop.Controls.Add(Me.lblClass)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(1000, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnSaveGrades
            '
            Me.btnSaveGrades.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnSaveGrades.BorderRadius = 8
            Me.btnSaveGrades.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnSaveGrades.FlatAppearance.BorderSize = 0
            Me.btnSaveGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSaveGrades.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnSaveGrades.ForeColor = System.Drawing.Color.White
            Me.btnSaveGrades.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnSaveGrades.Location = New System.Drawing.Point(12, 12)
            Me.btnSaveGrades.Name = "btnSaveGrades"
            Me.btnSaveGrades.Size = New System.Drawing.Size(130, 40)
            Me.btnSaveGrades.TabIndex = 0
            Me.btnSaveGrades.Text = "💾 حفظ الدرجات"
            Me.btnSaveGrades.UseVisualStyleBackColor = False
            '
            'btnExportMasterSheet
            '
            Me.btnExportMasterSheet.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnExportMasterSheet.BorderRadius = 8
            Me.btnExportMasterSheet.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportMasterSheet.FlatAppearance.BorderSize = 0
            Me.btnExportMasterSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExportMasterSheet.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnExportMasterSheet.ForeColor = System.Drawing.Color.White
            Me.btnExportMasterSheet.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnExportMasterSheet.Location = New System.Drawing.Point(150, 12)
            Me.btnExportMasterSheet.Name = "btnExportMasterSheet"
            Me.btnExportMasterSheet.Size = New System.Drawing.Size(155, 40)
            Me.btnExportMasterSheet.TabIndex = 1
            Me.btnExportMasterSheet.Text = "📊 شيت الدرجات الوزاري"
            Me.btnExportMasterSheet.UseVisualStyleBackColor = False
            '
            'cboSubject
            '
            Me.cboSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboSubject.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboSubject.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboSubject.ForeColor = System.Drawing.Color.White
            Me.cboSubject.FormattingEnabled = True
            Me.cboSubject.Items.AddRange(New Object() {"الرياضيات", "اللغة العربية", "اللغة الإنجليزية", "الفيزياء", "الكيمياء", "الأحياء", "التربية الإسلامية"})
            Me.cboSubject.Location = New System.Drawing.Point(520, 20)
            Me.cboSubject.Name = "cboSubject"
            Me.cboSubject.Size = New System.Drawing.Size(160, 25)
            Me.cboSubject.TabIndex = 2
            '
            'lblSubject
            '
            Me.lblSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblSubject.AutoSize = True
            Me.lblSubject.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblSubject.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblSubject.Location = New System.Drawing.Point(685, 24)
            Me.lblSubject.Name = "lblSubject"
            Me.lblSubject.Size = New System.Drawing.Size(42, 15)
            Me.lblSubject.TabIndex = 3
            Me.lblSubject.Text = "المادة:"
            '
            'cboClass
            '
            Me.cboClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboClass.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboClass.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboClass.ForeColor = System.Drawing.Color.White
            Me.cboClass.FormattingEnabled = True
            Me.cboClass.Items.AddRange(New Object() {"الرابع العلمي (أ)", "الرابع العلمي (ب)", "الخامس العلمي (أ)", "السادس العلمي (أ)"})
            Me.cboClass.Location = New System.Drawing.Point(740, 20)
            Me.cboClass.Name = "cboClass"
            Me.cboClass.Size = New System.Drawing.Size(170, 25)
            Me.cboClass.TabIndex = 4
            '
            'lblClass
            '
            Me.lblClass.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblClass.AutoSize = True
            Me.lblClass.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblClass.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblClass.Location = New System.Drawing.Point(915, 24)
            Me.lblClass.Name = "lblClass"
            Me.lblClass.Size = New System.Drawing.Size(73, 15)
            Me.lblClass.TabIndex = 5
            Me.lblClass.Text = "الصف والشعبة:"
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlBottom.Controls.Add(Me.lblGradeStats)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(0, 525)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
            Me.pnlBottom.Size = New System.Drawing.Size(1000, 35)
            Me.pnlBottom.TabIndex = 1
            '
            'lblGradeStats
            '
            Me.lblGradeStats.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblGradeStats.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblGradeStats.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblGradeStats.Location = New System.Drawing.Point(15, 8)
            Me.lblGradeStats.Name = "lblGradeStats"
            Me.lblGradeStats.Size = New System.Drawing.Size(970, 19)
            Me.lblGradeStats.TabIndex = 0
            Me.lblGradeStats.Text = "إحصائية المادة: نسبة النجاح: 100% | أعلى درجة: 96 | أدنى درجة: 68 | المعدل العام:" &
    " 84.4"
            Me.lblGradeStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dgvGrades
            '
            Me.dgvGrades.AllowUserToAddRows = False
            Me.dgvGrades.AllowUserToDeleteRows = False
            Me.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvGrades.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvGrades.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvGrades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colStudentId, Me.colStudentName, Me.colMonth1, Me.colMonth2, Me.colTerm1Quest, Me.colMidYear, Me.colAnnualQuest, Me.colFinalExam, Me.colFinalAverage, Me.colEvaluation})
            Me.dgvGrades.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvGrades.EnableHeadersVisualStyles = False
            Me.dgvGrades.Location = New System.Drawing.Point(0, 65)
            Me.dgvGrades.Name = "dgvGrades"
            Me.dgvGrades.RowHeadersVisible = False
            Me.dgvGrades.RowTemplate.Height = 38
            Me.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
            Me.dgvGrades.Size = New System.Drawing.Size(1000, 460)
            Me.dgvGrades.TabIndex = 2
            '
            'colStudentId
            '
            Me.colStudentId.FillWeight = 75.0!
            Me.colStudentId.HeaderText = "الرقم"
            Me.colStudentId.Name = "colStudentId"
            Me.colStudentId.ReadOnly = True
            '
            'colStudentName
            '
            Me.colStudentName.FillWeight = 160.0!
            Me.colStudentName.HeaderText = "اسم الطالب الرباعي"
            Me.colStudentName.Name = "colStudentName"
            Me.colStudentName.ReadOnly = True
            '
            'colMonth1
            '
            Me.colMonth1.FillWeight = 60.0!
            Me.colMonth1.HeaderText = "شهر 1"
            Me.colMonth1.Name = "colMonth1"
            '
            'colMonth2
            '
            Me.colMonth2.FillWeight = 60.0!
            Me.colMonth2.HeaderText = "شهر 2"
            Me.colMonth2.Name = "colMonth2"
            '
            'colTerm1Quest
            '
            Me.colTerm1Quest.FillWeight = 70.0!
            Me.colTerm1Quest.HeaderText = "سعي ف1"
            Me.colTerm1Quest.Name = "colTerm1Quest"
            Me.colTerm1Quest.ReadOnly = True
            '
            'colMidYear
            '
            Me.colMidYear.FillWeight = 65.0!
            Me.colMidYear.HeaderText = "نصف السنة"
            Me.colMidYear.Name = "colMidYear"
            '
            'colAnnualQuest
            '
            Me.colAnnualQuest.FillWeight = 70.0!
            Me.colAnnualQuest.HeaderText = "السعي السنوي"
            Me.colAnnualQuest.Name = "colAnnualQuest"
            Me.colAnnualQuest.ReadOnly = True
            '
            'colFinalExam
            '
            Me.colFinalExam.FillWeight = 65.0!
            Me.colFinalExam.HeaderText = "النهائي"
            Me.colFinalExam.Name = "colFinalExam"
            '
            'colFinalAverage
            '
            Me.colFinalAverage.FillWeight = 70.0!
            Me.colFinalAverage.HeaderText = "المعدل النهائي"
            Me.colFinalAverage.Name = "colFinalAverage"
            Me.colFinalAverage.ReadOnly = True
            '
            'colEvaluation
            '
            Me.colEvaluation.FillWeight = 75.0!
            Me.colEvaluation.HeaderText = "التقدير"
            Me.colEvaluation.Name = "colEvaluation"
            Me.colEvaluation.ReadOnly = True
            '
            'GradesForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(1000, 560)
            Me.Controls.Add(Me.dgvGrades)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "GradesForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "دفتر الدرجات والسعي السنوي"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvGrades, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnSaveGrades As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnExportMasterSheet As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents cboSubject As System.Windows.Forms.ComboBox
        Friend WithEvents lblSubject As System.Windows.Forms.Label
        Friend WithEvents cboClass As System.Windows.Forms.ComboBox
        Friend WithEvents lblClass As System.Windows.Forms.Label
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblGradeStats As System.Windows.Forms.Label
        Friend WithEvents dgvGrades As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colStudentId As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStudentName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMonth1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMonth2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTerm1Quest As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMidYear As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAnnualQuest As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinalExam As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinalAverage As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colEvaluation As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
