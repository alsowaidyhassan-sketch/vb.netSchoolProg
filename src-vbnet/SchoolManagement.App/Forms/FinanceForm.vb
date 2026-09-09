Imports System
Imports System.Windows.Forms
Imports SchoolManagement.App.Helpers

Namespace Forms
    ''' <summary>
    ''' شاشة إدارة الرسوم والأقساط المدرسية وسندات القبض بالدينار العراقي (IQD)
    ''' متوافقة بالكامل مع Visual Studio Designer
    ''' </summary>
    Partial Public Class FinanceForm
        Inherits Form

        Public Sub New()
            InitializeComponent()

            If DesignModeHelper.IsInDesignMode(Me) Then Return

            LoadInitialData()
            WireEvents()
        End Sub

        Private Sub WireEvents()
            AddHandler btnNewInvoice.Click, AddressOf BtnNewInvoice_Click
            AddHandler btnRecordPayment.Click, AddressOf BtnRecordPayment_Click
            AddHandler btnPrintReceipt.Click, AddressOf BtnPrintReceipt_Click
            AddHandler cboFilterStatus.SelectedIndexChanged, AddressOf OnFilterChanged
        End Sub

        Private Sub LoadInitialData()
            cboFilterStatus.SelectedIndex = 0
            PopulateTable()
        End Sub

        Private Sub PopulateTable()
            dgvFinance.Rows.Clear()
            dgvFinance.Rows.Add("INV-2025-001", "مصطفى علي حسين الزبيدي", "القسط السنوي - الدفعة الأولى", "1,250,000 د.ع", "1,250,000 د.ع", "0 د.ع", "2024/10/01", "مسدد بالكامل")
            dgvFinance.Rows.Add("INV-2025-002", "مصطفى علي حسين الزبيدي", "القسط السنوي - الدفعة الثانية", "1,250,000 د.ع", "500,000 د.ع", "750,000 د.ع", "2025/02/01", "مسدد جزئياً")
            dgvFinance.Rows.Add("INV-2025-003", "سجاد حيدر عبد الحسن السعدي", "القسط السنوي - كامل", "2,500,000 د.ع", "2,500,000 د.ع", "0 د.ع", "2024/09/15", "مسدد بالكامل")
            dgvFinance.Rows.Add("INV-2025-004", "أحمد فراس نوري العامري", "القسط السنوي - الدفعة الأولى", "1,250,000 د.ع", "0 د.ع", "1,250,000 د.ع", "2024/10/01", "غير مسدد (مستحق)")
            dgvFinance.Rows.Add("INV-2025-005", "يوسف عمر خطاب الجبوري", "أجور خط النقل المدرسي", "200,000 د.ع", "200,000 د.ع", "0 د.ع", "2024/11/01", "مسدد بالكامل")
            dgvFinance.Rows.Add("INV-2025-006", "كرار سلام ضياء الربيعي", "رسوم الزي المدرسي والكتب", "150,000 د.ع", "150,000 د.ع", "0 د.ع", "2024/09/20", "مسدد بالكامل")
        End Sub

        Private Sub OnFilterChanged(sender As Object, e As EventArgs)
            Dim filter = Convert.ToString(cboFilterStatus.SelectedItem)
            For Each row As DataGridViewRow In dgvFinance.Rows
                Dim st = Convert.ToString(row.Cells("colInvStatus").Value)
                row.Visible = (cboFilterStatus.SelectedIndex = 0) OrElse (st = filter)
            Next
        End Sub

        Private Sub BtnNewInvoice_Click(sender As Object, e As EventArgs)
            MessageBox.Show("إنشاء مطالبة مالية / قسط دراسي جديد للطالب.", "إنشاء مطالبة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub

        Private Sub BtnRecordPayment_Click(sender As Object, e As EventArgs)
            If dgvFinance.SelectedRows.Count = 0 Then
                MessageBox.Show("يرجى تحديد الفاتورة لتسجيل سند القبض.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            MessageBox.Show("تسجيل دفعة نقدية / سند قبض في الصندوق المالي للمدرسة.", "سند قبض", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
