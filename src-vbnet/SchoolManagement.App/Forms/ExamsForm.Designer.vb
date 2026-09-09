Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ExamsForm
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
            Me.btnCreateExamSchedule = New SchoolManagement.App.Controls.ModernButton()
            Me.btnPrintTable = New SchoolManagement.App.Controls.ModernButton()
            Me.cboExamType = New System.Windows.Forms.ComboBox()
            Me.lblExamType = New System.Windows.Forms.Label()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblStats = New System.Windows.Forms.Label()
            Me.dgvExams = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colExamCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colExamName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colSubject = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colClass = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRoom = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colInvigilator = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvExams, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnCreateExamSchedule)
            Me.pnlTop.Controls.Add(Me.btnPrintTable)
            Me.pnlTop.Controls.Add(Me.cboExamType)
            Me.pnlTop.Controls.Add(Me.lblExamType)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnCreateExamSchedule
            '
            Me.btnCreateExamSchedule.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnCreateExamSchedule.BorderRadius = 8
            Me.btnCreateExamSchedule.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnCreateExamSchedule.FlatAppearance.BorderSize = 0
            Me.btnCreateExamSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCreateExamSchedule.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnCreateExamSchedule.ForeColor = System.Drawing.Color.White
            Me.btnCreateExamSchedule.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnCreateExamSchedule.Location = New System.Drawing.Point(12, 12)
            Me.btnCreateExamSchedule.Name = "btnCreateExamSchedule"
            Me.btnCreateExamSchedule.Size = New System.Drawing.Size(160, 40)
            Me.btnCreateExamSchedule.TabIndex = 0
            Me.btnCreateExamSchedule.Text = "➕ جدولة امتحان جديد"
            Me.btnCreateExamSchedule.UseVisualStyleBackColor = False
            '
            'btnPrintTable
            '
            Me.btnPrintTable.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnPrintTable.BorderRadius = 8
            Me.btnPrintTable.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPrintTable.FlatAppearance.BorderSize = 0
            Me.btnPrintTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrintTable.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnPrintTable.ForeColor = System.Drawing.Color.White
            Me.btnPrintTable.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnPrintTable.Location = New System.Drawing.Point(180, 12)
            Me.btnPrintTable.Name = "btnPrintTable"
            Me.btnPrintTable.Size = New System.Drawing.Size(150, 40)
            Me.btnPrintTable.TabIndex = 1
            Me.btnPrintTable.Text = "🖨️ طباعة جدول الامتحانات"
            Me.btnPrintTable.UseVisualStyleBackColor = False
            '
            'cboExamType
            '
            Me.cboExamType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboExamType.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboExamType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboExamType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboExamType.ForeColor = System.Drawing.Color.White
            Me.cboExamType.FormattingEnabled = True
            Me.cboExamType.Items.AddRange(New Object() {"امتحانات نصف السنة 2024-2025", "امتحانات الشهر الأول (الفصل الأول)", "امتحانات الشهر الثاني (الفصل الأول)", "امتحانات نهاية السنة - الدور الأول", "امتحانات الدور الثاني"})
            Me.cboExamType.Location = New System.Drawing.Point(620, 20)
            Me.cboExamType.Name = "cboExamType"
            Me.cboExamType.Size = New System.Drawing.Size(220, 25)
            Me.cboExamType.TabIndex = 2
            '
            'lblExamType
            '
            Me.lblExamType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblExamType.AutoSize = True
            Me.lblExamType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblExamType.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblExamType.Location = New System.Drawing.Point(850, 24)
            Me.lblExamType.Name = "lblExamType"
            Me.lblExamType.Size = New System.Drawing.Size(65, 15)
            Me.lblExamType.TabIndex = 3
            Me.lblExamType.Text = "نوع الامتحان:"
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
            Me.lblStats.Location = New System.Drawing.Point(600, 8)
            Me.lblStats.Name = "lblStats"
            Me.lblStats.Size = New System.Drawing.Size(335, 19)
            Me.lblStats.TabIndex = 0
            Me.lblStats.Text = "الجداول معتمدة بحسب التقويم الرسمي لوزارة التربية العراقية"
            Me.lblStats.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgvExams
            '
            Me.dgvExams.AllowUserToAddRows = False
            Me.dgvExams.AllowUserToDeleteRows = False
            Me.dgvExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvExams.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvExams.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvExams.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExamCode, Me.colExamName, Me.colSubject, Me.colClass, Me.colDate, Me.colTime, Me.colRoom, Me.colInvigilator})
            Me.dgvExams.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvExams.EnableHeadersVisualStyles = False
            Me.dgvExams.Location = New System.Drawing.Point(0, 65)
            Me.dgvExams.Name = "dgvExams"
            Me.dgvExams.ReadOnly = True
            Me.dgvExams.RowHeadersVisible = False
            Me.dgvExams.RowTemplate.Height = 38
            Me.dgvExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvExams.Size = New System.Drawing.Size(950, 460)
            Me.dgvExams.TabIndex = 2
            '
            'colExamCode
            '
            Me.colExamCode.FillWeight = 70.0!
            Me.colExamCode.HeaderText = "الرمز"
            Me.colExamCode.Name = "colExamCode"
            Me.colExamCode.ReadOnly = True
            '
            'colExamName
            '
            Me.colExamName.FillWeight = 120.0!
            Me.colExamName.HeaderText = "عنوان الاختبار"
            Me.colExamName.Name = "colExamName"
            Me.colExamName.ReadOnly = True
            '
            'colSubject
            '
            Me.colSubject.FillWeight = 130.0!
            Me.colSubject.HeaderText = "المادة الدراسية"
            Me.colSubject.Name = "colSubject"
            Me.colSubject.ReadOnly = True
            '
            'colClass
            '
            Me.colClass.FillWeight = 100.0!
            Me.colClass.HeaderText = "الصف والشعبة"
            Me.colClass.Name = "colClass"
            Me.colClass.ReadOnly = True
            '
            'colDate
            '
            Me.colDate.FillWeight = 85.0!
            Me.colDate.HeaderText = "التاريخ"
            Me.colDate.Name = "colDate"
            Me.colDate.ReadOnly = True
            '
            'colTime
            '
            Me.colTime.FillWeight = 80.0!
            Me.colTime.HeaderText = "الوقت"
            Me.colTime.Name = "colTime"
            Me.colTime.ReadOnly = True
            '
            'colRoom
            '
            Me.colRoom.FillWeight = 80.0!
            Me.colRoom.HeaderText = "القاعة"
            Me.colRoom.Name = "colRoom"
            Me.colRoom.ReadOnly = True
            '
            'colInvigilator
            '
            Me.colInvigilator.FillWeight = 120.0!
            Me.colInvigilator.HeaderText = "المراقب المشرف"
            Me.colInvigilator.Name = "colInvigilator"
            Me.colInvigilator.ReadOnly = True
            '
            'ExamsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvExams)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "ExamsForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "الامتحانات والجداول"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvExams, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnCreateExamSchedule As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnPrintTable As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents cboExamType As System.Windows.Forms.ComboBox
        Friend WithEvents lblExamType As System.Windows.Forms.Label
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblStats As System.Windows.Forms.Label
        Friend WithEvents dgvExams As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colExamCode As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colExamName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colSubject As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colClass As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colTime As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRoom As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colInvigilator As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
