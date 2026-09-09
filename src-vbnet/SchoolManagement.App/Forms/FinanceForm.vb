Imports System
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة الرسوم والأقساط المدرسية وسندات القبض بالدينار العراقي (IQD)
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class FinanceForm
        Inherits Form

        Private ReadOnly _financeRepository As IFinanceRepository

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Sub New(financeRepository As IFinanceRepository)
            Me.New()
            
            If DesignModeHelper.IsInDesignMode(Me) Then Return
            
            _financeRepository = financeRepository
            
            AddHandler Me.Load, AddressOf OnFormLoad
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnNewInvoice.Click, AddressOf BtnNewInvoice_Click
            AddHandler btnRecordPayment.Click, AddressOf BtnRecordPayment_Click
            AddHandler btnPrintReceipt.Click, AddressOf BtnPrintReceipt_Click
            AddHandler cboFilterStatus.SelectedIndexChanged, AddressOf OnFilterChanged
        End Sub

        Private Async Sub OnFormLoad(sender As Object, e As EventArgs)
            cboFilterStatus.SelectedIndex = 0
            Await PopulateTableAsync()
            Await LoadSummaryAsync()
        End Sub

        Private Async Function PopulateTableAsync() As Task
            Try
                dgvFinance.Rows.Clear()
                Dim filterStatus = If(cboFilterStatus.SelectedIndex > 0, cboFilterStatus.SelectedItem.ToString(), "ALL")
                Dim invoices = Await _financeRepository.GetInvoicesAsync(filterStatus)
                
                For Each inv In invoices
                    dgvFinance.Rows.Add(
                        inv.InvoiceNumber,
                        $"طالب {inv.StudentId}", ' To Do: Get real student name via JOIN
                        inv.FeeType,
                        $"{inv.FinalAmount:N0} د.ع",
                        $"{inv.PaidAmount:N0} د.ع",
                        $"{inv.RemainingAmount:N0} د.ع",
                        inv.DueDate?.ToString("yyyy/MM/dd"),
                        inv.Status
                    )
                Next
            Catch ex As Exception
                MessageBox.Show($"تعذر تحميل البيانات المالية: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Async Function LoadSummaryAsync() As Task
            Try
                Dim summary = Await _financeRepository.GetFinancialSummaryAsync()
                lblTotalInvoiced.Text = $"{summary("TotalInvoiced"):N0} د.ع"
                lblTotalCollected.Text = $"{summary("TotalCollected"):N0} د.ع"
                lblTotalRemaining.Text = $"{summary("TotalRemaining"):N0} د.ع"
            Catch ex As Exception
                Console.WriteLine($"Summary load failed: {ex.Message}")
            End Try
        End Function

        Private Async Sub OnFilterChanged(sender As Object, e As EventArgs)
            Await PopulateTableAsync()
        End Sub

        Private Sub BtnNewInvoice_Click(sender As Object, e As EventArgs)
            MessageBox.Show("سيتم إدراج شاشة تفاصيل الفاتورة قريباً.", "إنشاء مطالبة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnRecordPayment_Click(sender As Object, e As EventArgs)
            If dgvFinance.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد الفاتورة لتسجيل سند القبض.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            MessageBox.Show("سيتم إدراج شاشة سندات القبض قريباً.", "سند قبض", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnPrintReceipt_Click(sender As Object, e As EventArgs)
            If dgvFinance.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد الفاتورة لطباعة وصل القبض المالي.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            MessageBox.Show("جاري تجهيز سند القبض والوصل الرسمي للطباعة وختم الإدارة الحسابية.", "طباعة الوصل", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
