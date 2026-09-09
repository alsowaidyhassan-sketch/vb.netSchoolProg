Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace Services

    Public Class FinanceService
        Private ReadOnly _financeRepo As IFinanceRepository

        Public Sub New(financeRepo As IFinanceRepository)
            _financeRepo = financeRepo
        End Sub

        Public Async Function GetInvoicesAsync(status As String) As Task(Of IEnumerable(Of FeeInvoice))
            Return Await _financeRepo.GetInvoicesAsync(status)
        End Function

        Public Async Function GetReceiptsAsync(fromDate As DateTime?, toDate As DateTime?) As Task(Of IEnumerable(Of PaymentReceipt))
            Return Await _financeRepo.GetReceiptsAsync(fromDate, toDate)
        End Function

        Public Async Function IssueReceiptAsync(receipt As PaymentReceipt) As Task(Of Integer)
            If receipt.Amount <= 0 Then
                Throw New ArgumentException("مبلغ السند يجب أن يكون أكبر من صفر.")
            End If

            If String.IsNullOrWhiteSpace(receipt.ReceiptNumber) Then
                receipt.ReceiptNumber = $"REC-{DateTime.Now.Year}-{New Random().Next(1000, 9999)}"
            End If

            receipt.ReceiptDate = DateTime.Now
            receipt.CreatedAt = DateTime.Now

            Return Await _financeRepo.AddPaymentReceiptAsync(receipt)
        End Function

        Public Async Function GetFinancialSummaryAsync() As Task(Of IDictionary(Of String, Decimal))
            Return Await _financeRepo.GetFinancialSummaryAsync()
        End Function
    End Class

End Namespace
