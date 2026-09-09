Imports System.Collections.Generic
Imports System.Data
Imports System.Threading.Tasks
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces
Imports SchoolManagement.Data.Infrastructure

Namespace Repositories

    Public Class FinancialSummaryRecord
        Public Property TotalInvoiced As Decimal
        Public Property TotalCollected As Decimal
        Public Property TotalRemaining As Decimal
    End Class

    Public Class FinanceRepository
        Implements IFinanceRepository

        Public Async Function GetInvoicesAsync(status As String) As Task(Of IEnumerable(Of FeeInvoice)) Implements IFinanceRepository.GetInvoicesAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = "SELECT [Id], [InvoiceNumber], [StudentId], [FeeType], [Amount], [Paid], [DueDate], [Status], [IsDeleted] FROM [dbo].[FeeInvoices]"
                If Not String.IsNullOrEmpty(status) AndAlso status <> "ALL" Then
                    sql &= " WHERE [Status] = @Status"
                End If
                sql &= " ORDER BY [Id] DESC;"
                Return Await conn.QueryAsync(Of FeeInvoice)(sql, New With {.Status = status})
            End Using
        End Function

        Public Async Function GetReceiptsAsync(fromDate As DateTime?, toDate As DateTime?) As Task(Of IEnumerable(Of PaymentReceipt)) Implements IFinanceRepository.GetReceiptsAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "SELECT [Id], [ReceiptNumber], [InvoiceId], [AmountPaid], [PaymentDate], [Notes] FROM [dbo].[PaymentReceipts] ORDER BY [Id] DESC;"
                Return Await conn.QueryAsync(Of PaymentReceipt)(sql)
            End Using
        End Function

        Public Async Function AddPaymentReceiptAsync(receipt As PaymentReceipt) As Task(Of Integer) Implements IFinanceRepository.AddPaymentReceiptAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    INSERT INTO [dbo].[PaymentReceipts] (
                        [ReceiptNumber], [InvoiceNumber], [StudentName],
                        [Amount], [ReceiptDate], [PaymentMethod], [ReferenceNumber], [CashierName], [CreatedAt]
                    ) VALUES (
                        @ReceiptNumber, @InvoiceNumber, @StudentName,
                        @Amount, @ReceiptDate, @PaymentMethod, @ReferenceNumber, @CashierName, GETDATE()
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);"
                Return Await conn.ExecuteScalarAsync(Of Integer)(sql, receipt)
            End Using
        End Function

        Public Async Function GetFinancialSummaryAsync() As Task(Of IDictionary(Of String, Decimal)) Implements IFinanceRepository.GetFinancialSummaryAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    SELECT 
                        ISNULL(SUM(FinalAmount), 0) AS TotalInvoiced,
                        ISNULL(SUM(PaidAmount), 0) AS TotalCollected,
                        ISNULL(SUM(RemainingAmount), 0) AS TotalRemaining
                    FROM [dbo].[FeeInvoices];"
                Dim summary = Await conn.QueryFirstOrDefaultAsync(Of FinancialSummaryRecord)(sql)
                Dim dict As New Dictionary(Of String, Decimal)()
                If summary IsNot Nothing Then
                    dict("TotalInvoiced") = summary.TotalInvoiced
                    dict("TotalCollected") = summary.TotalCollected
                    dict("TotalRemaining") = summary.TotalRemaining
                Else
                    dict("TotalInvoiced") = 0D
                    dict("TotalCollected") = 0D
                    dict("TotalRemaining") = 0D
                End If
                Return dict
            End Using
        End Function
    End Class

End Namespace
