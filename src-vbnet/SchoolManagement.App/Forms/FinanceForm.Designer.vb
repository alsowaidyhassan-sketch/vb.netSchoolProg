Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports SchoolManagement.App.Controls

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class FinanceForm
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
            Me.btnNewInvoice = New SchoolManagement.App.Controls.ModernButton()
            Me.btnRecordPayment = New SchoolManagement.App.Controls.ModernButton()
            Me.btnPrintReceipt = New SchoolManagement.App.Controls.ModernButton()
            Me.cboFilterStatus = New System.Windows.Forms.ComboBox()
            Me.pnlCards = New System.Windows.Forms.Panel()
            Me.cardTotalRevenue = New SchoolManagement.App.Controls.ModernCard()
            Me.lblTotalRevenue = New System.Windows.Forms.Label()
            Me.lblRevenueTitle = New System.Windows.Forms.Label()
            Me.cardPaid = New SchoolManagement.App.Controls.ModernCard()
            Me.lblTotalPaid = New System.Windows.Forms.Label()
            Me.lblPaidTitle = New System.Windows.Forms.Label()
            Me.cardRemaining = New SchoolManagement.App.Controls.ModernCard()
            Me.lblTotalRemaining = New System.Windows.Forms.Label()
            Me.lblRemainingTitle = New System.Windows.Forms.Label()
            Me.dgvFinance = New SchoolManagement.App.Controls.ModernDataGrid()
            Me.colInvNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colStudentName = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colFeeType = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colRemaining = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colDueDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.colInvStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
            Me.pnlTop.SuspendLayout()
            Me.pnlCards.SuspendLayout()
            Me.cardTotalRevenue.SuspendLayout()
            Me.cardPaid.SuspendLayout()
            Me.cardRemaining.SuspendLayout()
            CType(Me.dgvFinance, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlTop
            '
            Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.pnlTop.Controls.Add(Me.btnNewInvoice)
            Me.pnlTop.Controls.Add(Me.btnRecordPayment)
            Me.pnlTop.Controls.Add(Me.btnPrintReceipt)
            Me.pnlTop.Controls.Add(Me.cboFilterStatus)
            Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlTop.Location = New System.Drawing.Point(0, 0)
            Me.pnlTop.Name = "pnlTop"
            Me.pnlTop.Padding = New System.Windows.Forms.Padding(12)
            Me.pnlTop.Size = New System.Drawing.Size(950, 65)
            Me.pnlTop.TabIndex = 0
            '
            'btnNewInvoice
            '
            Me.btnNewInvoice.BackColor = System.Drawing.Color.FromArgb(37, 99, 235)
            Me.btnNewInvoice.BorderRadius = 8
            Me.btnNewInvoice.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnNewInvoice.FlatAppearance.BorderSize = 0
            Me.btnNewInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnNewInvoice.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnNewInvoice.ForeColor = System.Drawing.Color.White
            Me.btnNewInvoice.HoverColor = System.Drawing.Color.FromArgb(59, 130, 246)
            Me.btnNewInvoice.Location = New System.Drawing.Point(12, 12)
            Me.btnNewInvoice.Name = "btnNewInvoice"
            Me.btnNewInvoice.Size = New System.Drawing.Size(150, 40)
            Me.btnNewInvoice.TabIndex = 0
            Me.btnNewInvoice.Text = "➕ إنشاء مطالبة مالية"
            Me.btnNewInvoice.UseVisualStyleBackColor = False
            '
            'btnRecordPayment
            '
            Me.btnRecordPayment.BackColor = System.Drawing.Color.FromArgb(16, 185, 129)
            Me.btnRecordPayment.BorderRadius = 8
            Me.btnRecordPayment.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnRecordPayment.FlatAppearance.BorderSize = 0
            Me.btnRecordPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRecordPayment.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
            Me.btnRecordPayment.ForeColor = System.Drawing.Color.White
            Me.btnRecordPayment.HoverColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.btnRecordPayment.Location = New System.Drawing.Point(170, 12)
            Me.btnRecordPayment.Name = "btnRecordPayment"
            Me.btnRecordPayment.Size = New System.Drawing.Size(150, 40)
            Me.btnRecordPayment.TabIndex = 1
            Me.btnRecordPayment.Text = "💵 تسجيل سند قبض"
            Me.btnRecordPayment.UseVisualStyleBackColor = False
            '
            'btnPrintReceipt
            '
            Me.btnPrintReceipt.BackColor = System.Drawing.Color.FromArgb(51, 65, 85)
            Me.btnPrintReceipt.BorderRadius = 8
            Me.btnPrintReceipt.Cursor = System.Windows.Forms.Cursors.Hand
            Me.btnPrintReceipt.FlatAppearance.BorderSize = 0
            Me.btnPrintReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrintReceipt.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.btnPrintReceipt.ForeColor = System.Drawing.Color.White
            Me.btnPrintReceipt.HoverColor = System.Drawing.Color.FromArgb(71, 85, 105)
            Me.btnPrintReceipt.Location = New System.Drawing.Point(330, 12)
            Me.btnPrintReceipt.Name = "btnPrintReceipt"
            Me.btnPrintReceipt.Size = New System.Drawing.Size(130, 40)
            Me.btnPrintReceipt.TabIndex = 2
            Me.btnPrintReceipt.Text = "🖨️ طباعة الوصل"
            Me.btnPrintReceipt.UseVisualStyleBackColor = False
            '
            'cboFilterStatus
            '
            Me.cboFilterStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cboFilterStatus.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.cboFilterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboFilterStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.cboFilterStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
            Me.cboFilterStatus.ForeColor = System.Drawing.Color.White
            Me.cboFilterStatus.FormattingEnabled = True
            Me.cboFilterStatus.Items.AddRange(New Object() {"جميع الفواتير والمطالبات", "مسدد بالكامل", "مسدد جزئياً", "غير مسدد (مستحق)"})
            Me.cboFilterStatus.Location = New System.Drawing.Point(740, 20)
            Me.cboFilterStatus.Name = "cboFilterStatus"
            Me.cboFilterStatus.Size = New System.Drawing.Size(195, 25)
            Me.cboFilterStatus.TabIndex = 3
            '
            'pnlCards
            '
            Me.pnlCards.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.pnlCards.Controls.Add(Me.cardRemaining)
            Me.pnlCards.Controls.Add(Me.cardPaid)
            Me.pnlCards.Controls.Add(Me.cardTotalRevenue)
            Me.pnlCards.Dock = System.Windows.Forms.DockStyle.Top
            Me.pnlCards.Location = New System.Drawing.Point(0, 65)
            Me.pnlCards.Name = "pnlCards"
            Me.pnlCards.Padding = New System.Windows.Forms.Padding(12, 10, 12, 10)
            Me.pnlCards.Size = New System.Drawing.Size(950, 95)
            Me.pnlCards.TabIndex = 1
            '
            'cardTotalRevenue
            '
            Me.cardTotalRevenue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardTotalRevenue.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cardTotalRevenue.BorderRadius = 10
            Me.cardTotalRevenue.Controls.Add(Me.lblTotalRevenue)
            Me.cardTotalRevenue.Controls.Add(Me.lblRevenueTitle)
            Me.cardTotalRevenue.Location = New System.Drawing.Point(12, 8)
            Me.cardTotalRevenue.Name = "cardTotalRevenue"
            Me.cardTotalRevenue.Padding = New System.Windows.Forms.Padding(12)
            Me.cardTotalRevenue.Size = New System.Drawing.Size(290, 75)
            Me.cardTotalRevenue.TabIndex = 0
            '
            'lblTotalRevenue
            '
            Me.lblTotalRevenue.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.lblTotalRevenue.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(96, 165, 250)
            Me.lblTotalRevenue.Location = New System.Drawing.Point(12, 38)
            Me.lblTotalRevenue.Name = "lblTotalRevenue"
            Me.lblTotalRevenue.Size = New System.Drawing.Size(266, 25)
            Me.lblTotalRevenue.TabIndex = 1
            Me.lblTotalRevenue.Text = "245,000,000 د.ع"
            Me.lblTotalRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRevenueTitle
            '
            Me.lblRevenueTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblRevenueTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblRevenueTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblRevenueTitle.Name = "lblRevenueTitle"
            Me.lblRevenueTitle.Size = New System.Drawing.Size(266, 20)
            Me.lblRevenueTitle.TabIndex = 0
            Me.lblRevenueTitle.Text = "إجمالي الأقساط والمطالبات"
            '
            'cardPaid
            '
            Me.cardPaid.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardPaid.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cardPaid.BorderRadius = 10
            Me.cardPaid.Controls.Add(Me.lblTotalPaid)
            Me.cardPaid.Controls.Add(Me.lblPaidTitle)
            Me.cardPaid.Location = New System.Drawing.Point(325, 8)
            Me.cardPaid.Name = "cardPaid"
            Me.cardPaid.Padding = New System.Windows.Forms.Padding(12)
            Me.cardPaid.Size = New System.Drawing.Size(295, 75)
            Me.cardPaid.TabIndex = 1
            '
            'lblTotalPaid
            '
            Me.lblTotalPaid.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.lblTotalPaid.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalPaid.ForeColor = System.Drawing.Color.FromArgb(52, 211, 153)
            Me.lblTotalPaid.Location = New System.Drawing.Point(12, 38)
            Me.lblTotalPaid.Name = "lblTotalPaid"
            Me.lblTotalPaid.Size = New System.Drawing.Size(271, 25)
            Me.lblTotalPaid.TabIndex = 1
            Me.lblTotalPaid.Text = "180,500,000 د.ع"
            Me.lblTotalPaid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPaidTitle
            '
            Me.lblPaidTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblPaidTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblPaidTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblPaidTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblPaidTitle.Name = "lblPaidTitle"
            Me.lblPaidTitle.Size = New System.Drawing.Size(271, 20)
            Me.lblPaidTitle.TabIndex = 0
            Me.lblPaidTitle.Text = "المبالغ المحصلة (الإيراد الفعلي)"
            '
            'cardRemaining
            '
            Me.cardRemaining.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cardRemaining.BackColor = System.Drawing.Color.FromArgb(30, 41, 59)
            Me.cardRemaining.BorderRadius = 10
            Me.cardRemaining.Controls.Add(Me.lblTotalRemaining)
            Me.cardRemaining.Controls.Add(Me.lblRemainingTitle)
            Me.cardRemaining.Location = New System.Drawing.Point(645, 8)
            Me.cardRemaining.Name = "cardRemaining"
            Me.cardRemaining.Padding = New System.Windows.Forms.Padding(12)
            Me.cardRemaining.Size = New System.Drawing.Size(293, 75)
            Me.cardRemaining.TabIndex = 2
            '
            'lblTotalRemaining
            '
            Me.lblTotalRemaining.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.lblTotalRemaining.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
            Me.lblTotalRemaining.ForeColor = System.Drawing.Color.FromArgb(248, 113, 113)
            Me.lblTotalRemaining.Location = New System.Drawing.Point(12, 38)
            Me.lblTotalRemaining.Name = "lblTotalRemaining"
            Me.lblTotalRemaining.Size = New System.Drawing.Size(269, 25)
            Me.lblTotalRemaining.TabIndex = 1
            Me.lblTotalRemaining.Text = "64,500,000 د.ع"
            Me.lblTotalRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRemainingTitle
            '
            Me.lblRemainingTitle.Dock = System.Windows.Forms.DockStyle.Top
            Me.lblRemainingTitle.Font = New System.Drawing.Font("Segoe UI", 8.5!)
            Me.lblRemainingTitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184)
            Me.lblRemainingTitle.Location = New System.Drawing.Point(12, 12)
            Me.lblRemainingTitle.Name = "lblRemainingTitle"
            Me.lblRemainingTitle.Size = New System.Drawing.Size(269, 20)
            Me.lblRemainingTitle.TabIndex = 0
            Me.lblRemainingTitle.Text = "الأقساط المتبقية (الذمم المدينة)"
            '
            'dgvFinance
            '
            Me.dgvFinance.AllowUserToAddRows = False
            Me.dgvFinance.AllowUserToDeleteRows = False
            Me.dgvFinance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
            Me.dgvFinance.BackgroundColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.dgvFinance.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.dgvFinance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.dgvFinance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvNumber, Me.colStudentName, Me.colFeeType, Me.colAmount, Me.colPaid, Me.colRemaining, Me.colDueDate, Me.colInvStatus})
            Me.dgvFinance.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dgvFinance.EnableHeadersVisualStyles = False
            Me.dgvFinance.Location = New System.Drawing.Point(0, 160)
            Me.dgvFinance.Name = "dgvFinance"
            Me.dgvFinance.ReadOnly = True
            Me.dgvFinance.RowHeadersVisible = False
            Me.dgvFinance.RowTemplate.Height = 38
            Me.dgvFinance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dgvFinance.Size = New System.Drawing.Size(950, 400)
            Me.dgvFinance.TabIndex = 2
            '
            'colInvNumber
            '
            Me.colInvNumber.FillWeight = 85.0!
            Me.colInvNumber.HeaderText = "رقم الفاتورة"
            Me.colInvNumber.Name = "colInvNumber"
            Me.colInvNumber.ReadOnly = True
            '
            'colStudentName
            '
            Me.colStudentName.FillWeight = 160.0!
            Me.colStudentName.HeaderText = "اسم الطالب الرباعي"
            Me.colStudentName.Name = "colStudentName"
            Me.colStudentName.ReadOnly = True
            '
            'colFeeType
            '
            Me.colFeeType.FillWeight = 120.0!
            Me.colFeeType.HeaderText = "نوع الرسم / القسط"
            Me.colFeeType.Name = "colFeeType"
            Me.colFeeType.ReadOnly = True
            '
            'colAmount
            '
            Me.colAmount.FillWeight = 95.0!
            Me.colAmount.HeaderText = "المبلغ المطلوب"
            Me.colAmount.Name = "colAmount"
            Me.colAmount.ReadOnly = True
            '
            'colPaid
            '
            Me.colPaid.FillWeight = 95.0!
            Me.colPaid.HeaderText = "المدفوع"
            Me.colPaid.Name = "colPaid"
            Me.colPaid.ReadOnly = True
            '
            'colRemaining
            '
            Me.colRemaining.FillWeight = 95.0!
            Me.colRemaining.HeaderText = "المتبقي"
            Me.colRemaining.Name = "colRemaining"
            Me.colRemaining.ReadOnly = True
            '
            'colDueDate
            '
            Me.colDueDate.FillWeight = 85.0!
            Me.colDueDate.HeaderText = "تاريخ الاستحقاق"
            Me.colDueDate.Name = "colDueDate"
            Me.colDueDate.ReadOnly = True
            '
            'colInvStatus
            '
            Me.colInvStatus.FillWeight = 80.0!
            Me.colInvStatus.HeaderText = "الحالة"
            Me.colInvStatus.Name = "colInvStatus"
            Me.colInvStatus.ReadOnly = True
            '
            'FinanceForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.FromArgb(15, 23, 42)
            Me.ClientSize = New System.Drawing.Size(950, 560)
            Me.Controls.Add(Me.dgvFinance)
            Me.Controls.Add(Me.pnlCards)
            Me.Controls.Add(Me.pnlTop)
            Me.Font = New System.Drawing.Font("Segoe UI", 9.5!)
            Me.Name = "FinanceForm"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Text = "الإدارة المالية والأقساط"
            Me.pnlTop.ResumeLayout(False)
            Me.pnlCards.ResumeLayout(False)
            Me.cardTotalRevenue.ResumeLayout(False)
            Me.cardPaid.ResumeLayout(False)
            Me.cardRemaining.ResumeLayout(False)
            CType(Me.dgvFinance, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents pnlTop As System.Windows.Forms.Panel
        Friend WithEvents btnNewInvoice As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnRecordPayment As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents btnPrintReceipt As SchoolManagement.App.Controls.ModernButton
        Friend WithEvents cboFilterStatus As System.Windows.Forms.ComboBox
        Friend WithEvents pnlCards As System.Windows.Forms.Panel
        Friend WithEvents cardTotalRevenue As SchoolManagement.App.Controls.ModernCard
        Friend WithEvents lblRevenueTitle As System.Windows.Forms.Label
        Friend WithEvents lblTotalRevenue As System.Windows.Forms.Label
        Friend WithEvents cardPaid As SchoolManagement.App.Controls.ModernCard
        Friend WithEvents lblPaidTitle As System.Windows.Forms.Label
        Friend WithEvents lblTotalPaid As System.Windows.Forms.Label
        Friend WithEvents cardRemaining As SchoolManagement.App.Controls.ModernCard
        Friend WithEvents lblRemainingTitle As System.Windows.Forms.Label
        Friend WithEvents lblTotalRemaining As System.Windows.Forms.Label
        Friend WithEvents dgvFinance As SchoolManagement.App.Controls.ModernDataGrid
        Friend WithEvents colInvNumber As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colStudentName As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colFeeType As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colPaid As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colRemaining As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colDueDate As System.Windows.Forms.DataGridViewTextBoxColumn
        Friend WithEvents colInvStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    End Class
End Namespace
