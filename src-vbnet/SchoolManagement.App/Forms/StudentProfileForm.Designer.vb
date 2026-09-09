Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class StudentProfileForm
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
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.lblStudentIdHeader = New System.Windows.Forms.Label()
            Me.lblStudentNameHeader = New System.Windows.Forms.Label()
            Me.pnlFooter = New System.Windows.Forms.Panel()
            Me.btnClose = New SchoolManagement.App.Controls.ModernButton()
            Me.btnPrint = New SchoolManagement.App.Controls.ModernButton()
            Me.tabProfile = New System.Windows.Forms.TabControl()
            Me.tabGeneral = New System.Windows.Forms.TabPage()
            Me.cardAddress = New SchoolManagement.App.Controls.ModernCard()
            Me.lblAddressValue = New System.Windows.Forms.Label()
            Me.lblAddressTitle = New System.Windows.Forms.Label()
            Me.cardIdentity = New SchoolManagement.App.Controls.ModernCard()
            Me.lblIdentityValue = New System.Windows.Forms.Label()
            Me.lblIdentityTitle = New System.Windows.Forms.Label()
            Me.cardBasic = New SchoolManagement.App.Controls.ModernCard()
            Me.lblBasicValue = New System.Windows.Forms.Label()
            Me.lblBasicTitle = New System.Windows.Forms.Label()
            Me.tabFinance = New System.Windows.Forms.TabPage()
            Me.dgvStudentFinance = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colFinInv = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinTitle = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinRemaining = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.tabGrades = New System.Windows.Forms.TabPage()
            Me.dgvStudentGrades = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colSubj = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMonth1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMonth2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colMidYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFinal = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDecision = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlHeader.SuspendLayout()
            Me.pnlFooter.SuspendLayout()
            Me.tabProfile.SuspendLayout()
            Me.tabGeneral.SuspendLayout()
            Me.cardAddress.SuspendLayout()
            Me.cardIdentity.SuspendLayout()
            Me.cardBasic.SuspendLayout()
            Me.tabFinance.SuspendLayout()
            CType(Me.dgvStudentFinance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabGrades.SuspendLayout()
            CType(Me.dgvStudentGrades, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlHeader
            '
            Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlHeader.Controls.Add(Me.lblStudentIdHeader)
            Me.pnlHeader.Controls.Add(Me.lblStudentNameHeader)
            Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Padding = New System.Windows.Forms.Padding(15)
            Me.pnlHeader.Size = New System.Drawing.Size(900, 70)
            Me.pnlHeader.TabIndex = 0
            '
            'lblStudentIdHeader
            '
            Me.lblStudentIdHeader.AutoSize = True
            Me.lblStudentIdHeader.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblStudentIdHeader.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblStudentIdHeader.Location = New System.Drawing.Point(15, 38)
            Me.lblStudentIdHeader.Name = "lblStudentIdHeader"
            Me.lblStudentIdHeader.Size = New System.Drawing.Size(185, 17)
            Me.lblStudentIdHeader.TabIndex = 1
            Me.lblStudentIdHeader.Text = "الرقم الأكاديمي: STD-2025-001"
            '
            'lblStudentNameHeader
            '
            Me.lblStudentNameHeader.AutoSize = True
            Me.lblStudentNameHeader.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblStudentNameHeader.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblStudentNameHeader.Location = New System.Drawing.Point(15, 12)
            Me.lblStudentNameHeader.Name = "lblStudentNameHeader"
            Me.lblStudentNameHeader.Size = New System.Drawing.Size(262, 25)
            Me.lblStudentNameHeader.TabIndex = 0
            Me.lblStudentNameHeader.Text = "الإضبارة الأكاديمية: مصطفى علي"
            '
            'pnlFooter
            '
            Me.pnlFooter.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlFooter.Controls.Add(Me.btnClose)
            Me.pnlFooter.Controls.Add(Me.btnPrint)
            Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlFooter.Location = New System.Drawing.Point(0, 565)
            Me.pnlFooter.Name = "pnlFooter"
            Me.pnlFooter.Padding = New System.Windows.Forms.Padding(15, 10, 15, 10)
            Me.pnlFooter.Size = New System.Drawing.Size(900, 55)
            Me.pnlFooter.TabIndex = 1
            '
            'btnClose
            '
            Me.btnClose.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnClose.BorderRadius = 8
            Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnClose.FlatAppearance.BorderSize = 0
            Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnClose.ForeColor = System.Drawing.Color.White
            Me.btnClose.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnClose.Location = New System.Drawing.Point(15, 10)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(110, 35)
            Me.btnClose.TabIndex = 1
            Me.btnClose.Text = "إغلاق"
            Me.btnClose.UseVisualStyleBackColor = False
            '
            'btnPrint
            '
            Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnPrint.BorderRadius = 8
            Me.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPrint.FlatAppearance.BorderSize = 0
            Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrint.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnPrint.ForeColor = System.Drawing.Color.White
            Me.btnPrint.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnPrint.Location = New System.Drawing.Point(135, 10)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(160, 35)
            Me.btnPrint.TabIndex = 0
            Me.btnPrint.Text = "🖨️ طباعة الإضبارة"
            Me.btnPrint.UseVisualStyleBackColor = False
            '
            'tabProfile
            '
            Me.tabProfile.Controls.Add(Me.tabGeneral)
            Me.tabProfile.Controls.Add(Me.tabFinance)
            Me.tabProfile.Controls.Add(Me.tabGrades)
            Me.tabProfile.Dock = System.Windows.Forms.DockStyle.Fill
            Me.tabProfile.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.tabProfile.Location = New System.Drawing.Point(0, 70)
            Me.tabProfile.Name = "tabProfile"
            Me.tabProfile.SelectedIndex = 0
            Me.tabProfile.Size = New System.Drawing.Size(900, 495)
            Me.tabProfile.TabIndex = 2
            '
            'tabGeneral
            '
            Me.tabGeneral.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.tabGeneral.Controls.Add(Me.cardAddress)
            Me.tabGeneral.Controls.Add(Me.cardIdentity)
            Me.tabGeneral.Controls.Add(Me.cardBasic)
            Me.tabGeneral.Location = New System.Drawing.Point(4, 26)
            Me.tabGeneral.Name = "tabGeneral"
            Me.tabGeneral.Padding = New System.Windows.Forms.Padding(15)
            Me.tabGeneral.Size = New System.Drawing.Size(892, 465)
            Me.tabGeneral.TabIndex = 0
            Me.tabGeneral.Text = "📄 البيانات الأساسية والوثائق"
            '
            'cardAddress
            '
            Me.cardAddress.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cardAddress.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.cardAddress.BorderRadius = 10
            Me.cardAddress.Controls.Add(Me.lblAddressValue)
            Me.cardAddress.Controls.Add(Me.lblAddressTitle)
            Me.cardAddress.Dock = System.Windows.Forms.DockStyle.Top
            Me.cardAddress.Location = New System.Drawing.Point(15, 275)
            Me.cardAddress.Name = "cardAddress"
            Me.cardAddress.Padding = New System.Windows.Forms.Padding(15)
            Me.cardAddress.Size = New System.Drawing.Size(862, 130)
            Me.cardAddress.TabIndex = 2
            '
            'lblAddressValue
            '
            Me.lblAddressValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblAddressValue.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblAddressValue.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
            Me.lblAddressValue.Location = New System.Drawing.Point(15, 38)
            Me.lblAddressValue.Name = "lblAddressValue"
            Me.lblAddressValue.Size = New System.Drawing.Size(832, 77)
            Me.lblAddressValue.TabIndex = 1
            Me.lblAddressValue.Text = "المحافظة: بغداد | القضاء: الكرخ | الحي: المنصور | محلة: 612 | زقاق: 14 | دار: 25 " &
    "| أقرب نقطة دالة: قرب جامع دراغ"
            '
            'lblAddressTitle
            '
            Me.lblAddressTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblAddressTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblAddressTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblAddressTitle.Location = New System.Drawing.Point(15, 15)
            Me.lblAddressTitle.Name = "lblAddressTitle"
            Me.lblAddressTitle.Size = New System.Drawing.Size(832, 23)
            Me.lblAddressTitle.TabIndex = 0
            Me.lblAddressTitle.Text = "📍 العنوان السكني ووسائل التواصل"
            '
            'cardIdentity
            '
            Me.cardIdentity.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cardIdentity.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.cardIdentity.BorderRadius = 10
            Me.cardIdentity.Controls.Add(Me.lblIdentityValue)
            Me.cardIdentity.Controls.Add(Me.lblIdentityTitle)
            Me.cardIdentity.Dock = System.Windows.Forms.DockStyle.Top
            Me.cardIdentity.Location = New System.Drawing.Point(15, 145)
            Me.cardIdentity.Name = "cardIdentity"
            Me.cardIdentity.Padding = New System.Windows.Forms.Padding(15)
            Me.cardIdentity.Size = New System.Drawing.Size(862, 130)
            Me.cardIdentity.TabIndex = 1
            '
            'lblIdentityValue
            '
            Me.lblIdentityValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblIdentityValue.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblIdentityValue.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
            Me.lblIdentityValue.Location = New System.Drawing.Point(15, 38)
            Me.lblIdentityValue.Name = "lblIdentityValue"
            Me.lblIdentityValue.Size = New System.Drawing.Size(832, 77)
            Me.lblIdentityValue.TabIndex = 1
            Me.lblIdentityValue.Text = "نوع الوثيقة: البطاقة الوطنية الموحدة | رقم الوثيقة: 200812345678 | جهة الإصدار: د" &
    "ائرة أحوال المنصور | الجنسية: عراقي"
            '
            'lblIdentityTitle
            '
            Me.lblIdentityTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblIdentityTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblIdentityTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblIdentityTitle.Location = New System.Drawing.Point(15, 15)
            Me.lblIdentityTitle.Name = "lblIdentityTitle"
            Me.lblIdentityTitle.Size = New System.Drawing.Size(832, 23)
            Me.lblIdentityTitle.TabIndex = 0
            Me.lblIdentityTitle.Text = "🆔 الوثائق الثبوتية الرسمية"
            '
            'cardBasic
            '
            Me.cardBasic.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cardBasic.BorderColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.cardBasic.BorderRadius = 10
            Me.cardBasic.Controls.Add(Me.lblBasicValue)
            Me.cardBasic.Controls.Add(Me.lblBasicTitle)
            Me.cardBasic.Dock = System.Windows.Forms.DockStyle.Top
            Me.cardBasic.Location = New System.Drawing.Point(15, 15)
            Me.cardBasic.Name = "cardBasic"
            Me.cardBasic.Padding = New System.Windows.Forms.Padding(15)
            Me.cardBasic.Size = New System.Drawing.Size(862, 130)
            Me.cardBasic.TabIndex = 0
            '
            'lblBasicValue
            '
            Me.lblBasicValue.Dock = System.Windows.Forms.DockStyle.Fill
            Me.lblBasicValue.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.lblBasicValue.ForeColor = System.Drawing.Color.FromArgb(226, 232, 240)
            Me.lblBasicValue.Location = New System.Drawing.Point(15, 38)
            Me.lblBasicValue.Name = "lblBasicValue"
            Me.lblBasicValue.Size = New System.Drawing.Size(832, 77)
            Me.lblBasicValue.TabIndex = 1
            Me.lblBasicValue.Text = "الاسم الخماسي: مصطفى علي حسين كاظم الزبيدي | اسم الأم: فاطمة جاسم محمد | تاريخ ال" &
    "ولادة: 2008-05-14 | الصف: الرابع العلمي (أ)"
            '
            'lblBasicTitle
            '
            Me.lblBasicTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblBasicTitle.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
            Me.lblBasicTitle.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblBasicTitle.Location = New System.Drawing.Point(15, 15)
            Me.lblBasicTitle.Name = "lblBasicTitle"
            Me.lblBasicTitle.Size = New System.Drawing.Size(832, 23)
            Me.lblBasicTitle.TabIndex = 0
            Me.lblBasicTitle.Text = "👤 المعلومات الشخصية"
            '
            'tabFinance
            '
            Me.tabFinance.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.tabFinance.Controls.Add(Me.dgvStudentFinance)
            Me.tabFinance.Location = New System.Drawing.Point(4, 26)
            Me.tabFinance.Name = "tabFinance"
            Me.tabFinance.Padding = New System.Windows.Forms.Padding(15)
            Me.tabFinance.Size = New System.Drawing.Size(892, 465)
            Me.tabFinance.TabIndex = 1
            Me.tabFinance.Text = "💰 الأقساط والمدفوعات (IQD)"
            '
            'dgvStudentFinance
            '
            Me.dgvStudentFinance.AllowUserToAddRows = False
            Me.dgvStudentFinance.AllowUserToDeleteRows = False
            Me.dgvStudentFinance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvStudentFinance.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvStudentFinance.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvStudentFinance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvStudentFinance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFinInv, Me.colFinTitle, Me.colFinAmount, Me.colFinPaid, Me.colFinRemaining, Me.colFinStatus})
            Me.dgvStudentFinance.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvStudentFinance.EnableHeadersVisualStyles = False
            Me.dgvStudentFinance.Location = New System.Drawing.Point(15, 15)
            Me.dgvStudentFinance.Name = "dgvStudentFinance"
            Me.dgvStudentFinance.ReadOnly = True
            Me.dgvStudentFinance.RowHeadersVisible = False
            Me.dgvStudentFinance.RowTemplate.Height = 36
            Me.dgvStudentFinance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvStudentFinance.Size = New System.Drawing.Size(862, 435)
            Me.dgvStudentFinance.TabIndex = 0
            '
            'colFinInv
            '
            Me.colFinInv.HeaderText = "رقم الوصل"
            Me.colFinInv.Name = "colFinInv"
            Me.colFinInv.ReadOnly = True
            '
            'colFinTitle
            '
            Me.colFinTitle.HeaderText = "البيان / الدفعة"
            Me.colFinTitle.Name = "colFinTitle"
            Me.colFinTitle.ReadOnly = True
            '
            'colFinAmount
            '
            Me.colFinAmount.HeaderText = "المبلغ المطلوب (IQD)"
            Me.colFinAmount.Name = "colFinAmount"
            Me.colFinAmount.ReadOnly = True
            '
            'colFinPaid
            '
            Me.colFinPaid.HeaderText = "المدفوع (IQD)"
            Me.colFinPaid.Name = "colFinPaid"
            Me.colFinPaid.ReadOnly = True
            '
            'colFinRemaining
            '
            Me.colFinRemaining.HeaderText = "المتبقي (IQD)"
            Me.colFinRemaining.Name = "colFinRemaining"
            Me.colFinRemaining.ReadOnly = True
            '
            'colFinStatus
            '
            Me.colFinStatus.HeaderText = "الحالة"
            Me.colFinStatus.Name = "colFinStatus"
            Me.colFinStatus.ReadOnly = True
            '
            'tabGrades
            '
            Me.tabGrades.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.tabGrades.Controls.Add(Me.dgvStudentGrades)
            Me.tabGrades.Location = New System.Drawing.Point(4, 26)
            Me.tabGrades.Name = "tabGrades"
            Me.tabGrades.Padding = New System.Windows.Forms.Padding(15)
            Me.tabGrades.Size = New System.Drawing.Size(892, 465)
            Me.tabGrades.TabIndex = 2
            Me.tabGrades.Text = "📈 الدرجات والمحصلة العراقية"
            '
            'dgvStudentGrades
            '
            Me.dgvStudentGrades.AllowUserToAddRows = False
            Me.dgvStudentGrades.AllowUserToDeleteRows = False
            Me.dgvStudentGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvStudentGrades.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvStudentGrades.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvStudentGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvStudentGrades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSubj, Me.colMonth1, Me.colMonth2, Me.colMidYear, Me.colFinal, Me.colDecision})
            Me.dgvStudentGrades.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvStudentGrades.EnableHeadersVisualStyles = False
            Me.dgvStudentGrades.Location = New System.Drawing.Point(15, 15)
            Me.dgvStudentGrades.Name = "dgvStudentGrades"
            Me.dgvStudentGrades.ReadOnly = True
            Me.dgvStudentGrades.RowHeadersVisible = False
            Me.dgvStudentGrades.RowTemplate.Height = 36
            Me.dgvStudentGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvStudentGrades.Size = New System.Drawing.Size(862, 435)
            Me.dgvStudentGrades.TabIndex = 0
            '
            'colSubj
            '
            Me.colSubj.HeaderText = "المادة الدراسية"
            Me.colSubj.Name = "colSubj"
            Me.colSubj.ReadOnly = True
            '
            'colMonth1
            '
            Me.colMonth1.HeaderText = "الشهر الأول"
            Me.colMonth1.Name = "colMonth1"
            Me.colMonth1.ReadOnly = True
            '
            'colMonth2
            '
            Me.colMonth2.HeaderText = "الشهر الثاني"
            Me.colMonth2.Name = "colMonth2"
            Me.colMonth2.ReadOnly = True
            '
            'colMidYear
            '
            Me.colMidYear.HeaderText = "نصف السنة"
            Me.colMidYear.Name = "colMidYear"
            Me.colMidYear.ReadOnly = True
            '
            'colFinal
            '
            Me.colFinal.HeaderText = "المعدل النهائي"
            Me.colFinal.Name = "colFinal"
            Me.colFinal.ReadOnly = True
            '
            'colDecision
            '
            Me.colDecision.HeaderText = "القرار (ناجح/مكمل)"
            Me.colDecision.Name = "colDecision"
            Me.colDecision.ReadOnly = True
            '
            'StudentProfileForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(900, 620)
            Me.Controls.Add(Me.tabProfile)
            Me.Controls.Add(Me.pnlFooter)
            Me.Controls.Add(Me.pnlHeader)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.MinimumSize = New System.Drawing.Size(800, 550)
            Me.Name = "StudentProfileForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "الإضبارة الشاملة للطالب"
            Me.pnlHeader.ResumeLayout(False)
            Me.pnlHeader.PerformLayout()
            Me.pnlFooter.ResumeLayout(False)
            Me.tabProfile.ResumeLayout(False)
            Me.tabGeneral.ResumeLayout(False)
            Me.cardAddress.ResumeLayout(False)
            Me.cardIdentity.ResumeLayout(False)
            Me.cardBasic.ResumeLayout(False)
            Me.tabFinance.ResumeLayout(False)
            CType(Me.dgvStudentFinance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabGrades.ResumeLayout(False)
            CType(Me.dgvStudentGrades, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents lblStudentNameHeader As System.Windows.Forms.Label
        Friend WithEvents lblStudentIdHeader As System.Windows.Forms.Label
        Friend WithEvents pnlFooter As System.Windows.Forms.Panel
        Friend WithEvents btnPrint As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnClose As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents tabProfile As System.Windows.Forms.TabControl
        Friend WithEvents tabGeneral As System.Windows.Forms.TabPage
        Friend WithEvents cardBasic As SchoolManagement.App.Controls.ModernCard
        Friend WithEvents lblBasicTitle As System.Windows.Forms.Label
        Friend WithEvents lblBasicValue As System.Windows.Forms.Label
        Friend WithEvents cardIdentity As SchoolManagement.App.Controls.ModernCard
        Friend WithEvents lblIdentityTitle As System.Windows.Forms.Label
        Friend WithEvents lblIdentityValue As System.Windows.Forms.Label
        Friend WithEvents cardAddress As SchoolManagement.App.Controls.ModernCard
        Friend WithEvents lblAddressTitle As System.Windows.Forms.Label
        Friend WithEvents lblAddressValue As System.Windows.Forms.Label
        Friend WithEvents tabFinance As System.Windows.Forms.TabPage
        Friend WithEvents dgvStudentFinance As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colFinInv As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinTitle As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinAmount As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinPaid As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinRemaining As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinStatus As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents tabGrades As System.Windows.Forms.TabPage
        Friend WithEvents dgvStudentGrades As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colSubj As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMonth1 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMonth2 As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colMidYear As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFinal As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDecision As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
