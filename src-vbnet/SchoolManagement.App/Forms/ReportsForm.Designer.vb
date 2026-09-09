Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ReportsForm
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
            Me.btnGenerateReport = New SchoolManagement.App.Controls.ModernButton()
            Me.btnPrint = New SchoolManagement.App.Controls.ModernButton()
            Me.btnExportExcel = New SchoolManagement.App.Controls.ModernButton()
            Me.cboReportType = New System.Windows.Forms.ComboBox()
            Me.lblReportType = New System.Windows.Forms.Label()
            Me.pnlBottom = New System.Windows.Forms.Panel()
            Me.lblInfo = New System.Windows.Forms.Label()
            Me.dgvReportPreview = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colItem1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colItem2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colItem3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colItem4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colItem5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlBottom.SuspendLayout()
            CType(Me.dgvReportPreview, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnGenerateReport)
            Me.pnlTop.Controls.Add(Me.btnPrint)
            Me.pnlTop.Controls.Add(Me.btnExportExcel)
            Me.pnlTop.Controls.Add(Me.cboReportType)
            Me.pnlTop.Controls.Add(Me.lblReportType)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnGenerateReport
            '
            Me.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnGenerateReport.BorderRadius = 8
            Me.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnGenerateReport.FlatAppearance.BorderSize = 0
            Me.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGenerateReport.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnGenerateReport.ForeColor = System.Drawing.Color.White
            Me.btnGenerateReport.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnGenerateReport.Location = New System.Drawing.Point(12, 12)
            Me.btnGenerateReport.Name = "btnGenerateReport"
            Me.btnGenerateReport.Size = New System.Drawing.Size(140, 40)
            Me.btnGenerateReport.TabIndex = 0
            Me.btnGenerateReport.Text = "⚡ توليد التقرير"
            Me.btnGenerateReport.UseVisualStyleBackColor = False
            '
            'btnPrint
            '
            Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnPrint.BorderRadius = 8
            Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPrint.FlatAppearance.BorderSize = 0
            Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnPrint.ForeColor = System.Drawing.Color.White
            Me.btnPrint.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnPrint.Location = New System.Drawing.Point(160, 12)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(120, 40)
            Me.btnPrint.TabIndex = 1
            Me.btnPrint.Text = "🖨️ طباعة رسمية"
            Me.btnPrint.UseVisualStyleBackColor = False
            '
            'btnExportExcel
            '
            Me.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(16, 185, 129)
            Me.btnExportExcel.BorderRadius = 8
            Me.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnExportExcel.FlatAppearance.BorderSize = 0
            Me.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnExportExcel.ForeColor = System.Drawing.Color.White
            Me.btnExportExcel.HoverColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.btnExportExcel.Location = New System.Drawing.Point(290, 12)
            Me.btnExportExcel.Name = "btnExportExcel"
            Me.btnExportExcel.Size = New System.Drawing.Size(130, 40)
            Me.btnExportExcel.TabIndex = 2
            Me.btnExportExcel.Text = "📊 تصدير Excel"
            Me.btnExportExcel.UseVisualStyleBackColor = False
            '
            'cboReportType
            '
            Me.cboReportType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboReportType.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboReportType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboReportType.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboReportType.ForeColor = System.Drawing.Color.White
            Me.cboReportType.FormattingEnabled = True
            Me.cboReportType.Items.AddRange(New Object() {"سجل القيد العام للطلبة (النموذج الوزاري)", "بطاقة الدرجات المدرسية (الجلاء المدرسي)", "كشف الحضور والغياب الشهري للمديرية العامة", "التقرير المالي وحركة الصندوق والأقساط", "إحصائيات نسب النجاح والرسوب للمراحل الدراسية"})
            Me.cboReportType.Location = New System.Drawing.Point(540, 20)
            Me.cboReportType.Name = "cboReportType"
            Me.cboReportType.Size = New System.Drawing.Size(290, 25)
            Me.cboReportType.TabIndex = 3
            '
            'lblReportType
            '
            Me.lblReportType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblReportType.AutoSize = True
            Me.lblReportType.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblReportType.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225)
            Me.lblReportType.Location = New System.Drawing.Point(835, 24)
            Me.lblReportType.Name = "lblReportType"
            Me.lblReportType.Size = New System.Drawing.Size(100, 15)
            Me.lblReportType.TabIndex = 4
            Me.lblReportType.Text = "التقرير المطلوب:"
            '
            'pnlBottom
            '
            Me.pnlBottom.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlBottom.Controls.Add(Me.lblInfo)
            Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlBottom.Location = New System.Drawing.Point(0, 525)
            Me.pnlBottom.Name = "pnlBottom"
            Me.pnlBottom.Padding = New System.Windows.Forms.Padding(15, 8, 15, 8)
            Me.pnlBottom.Size = New System.Drawing.Size(950, 35)
            Me.pnlBottom.TabIndex = 1
            '
            'lblInfo
            '
            Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Right
            Me.lblInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
            Me.lblInfo.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblInfo.Location = New System.Drawing.Point(400, 8)
            Me.lblInfo.Name = "lblInfo"
            Me.lblInfo.Size = New System.Drawing.Size(535, 19)
            Me.lblInfo.TabIndex = 0
            Me.lblInfo.Text = "التقارير مصممة بحسب مواصفات ومتطلبات وزارة التربية العراقية - المديريات العامة لل" &
    "تربية"
            Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgvReportPreview
            '
            Me.dgvReportPreview.AllowUserToAddRows = False
            Me.dgvReportPreview.AllowUserToDeleteRows = False
            Me.dgvReportPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvReportPreview.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvReportPreview.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvReportPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvReportPreview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem1, Me.colItem2, Me.colItem3, Me.colItem4, Me.colItem5})
            Me.dgvReportPreview.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvReportPreview.EnableHeadersVisualStyles = False
            Me.dgvReportPreview.Location = New System.Drawing.Point(0, 65)
            Me.dgvReportPreview.Name = "dgvReportPreview"
            Me.dgvReportPreview.ReadOnly = True
            Me.dgvReportPreview.RowHeadersVisible = False
            Me.dgvReportPreview.RowTemplate.Height = 38
            Me.dgvReportPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvReportPreview.Size = New System.Drawing.Size(950, 460)
            Me.dgvReportPreview.TabIndex = 2
            '
            'colItem1
            '
            Me.colItem1.FillWeight = 80.0!
            Me.colItem1.HeaderText = "الرمز / التسلسل"
            Me.colItem1.Name = "colItem1"
            Me.colItem1.ReadOnly = True
            '
            'colItem2
            '
            Me.colItem2.FillWeight = 160.0!
            Me.colItem2.HeaderText = "البيان / الاسم الكامل"
            Me.colItem2.Name = "colItem2"
            Me.colItem2.ReadOnly = True
            '
            'colItem3
            '
            Me.colItem3.FillWeight = 110.0!
            Me.colItem3.HeaderText = "المرحلة / التصنيف"
            Me.colItem3.Name = "colItem3"
            Me.colItem3.ReadOnly = True
            '
            'colItem4
            '
            Me.colItem4.FillWeight = 100.0!
            Me.colItem4.HeaderText = "القيمة / المعدل / المبلغ"
            Me.colItem4.Name = "colItem4"
            Me.colItem4.ReadOnly = True
            '
            'colItem5
            '
            Me.colItem5.FillWeight = 90.0!
            Me.colItem5.HeaderText = "النتيجة / الحالة"
            Me.colItem5.Name = "colItem5"
            Me.colItem5.ReadOnly = True
            '
            'ReportsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvReportPreview)
            Me.Controls.Add(Me.pnlBottom)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "ReportsForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "التقارير والإحصائيات الوزارية"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlTop.PerformLayout()
            Me.pnlBottom.ResumeLayout(False)
            CType(Me.dgvReportPreview, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnGenerateReport As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnPrint As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnExportExcel As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents cboReportType As System.Windows.Forms.ComboBox
        Friend WithEvents lblReportType As System.Windows.Forms.Label
        Friend WithEvents pnlBottom As System.Windows.Forms.Panel
        Friend WithEvents lblInfo As System.Windows.Forms.Label
        Friend WithEvents dgvReportPreview As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colItem1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colItem2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colItem3 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colItem4 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colItem5 As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
