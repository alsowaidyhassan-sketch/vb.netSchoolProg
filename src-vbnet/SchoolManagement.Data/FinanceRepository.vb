Imports System.Collections.Generic
Imports System.Data
Imports System.Threading.Tasks
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace Repositories
    Public Class FinanceRepository
        Implements IFinanceRepository

        Public Async Function GetInvoicesAsync(status As String) As Task(Of IEnumerable(Of FeeInvoice)) Implements IFinanceRepository.GetInvoicesAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = "SELECT [Id], [InvoiceNumber], [StudentId], [StudentName], [StudentNumber], [ClassName], [FeeType], [OriginalAmount], [DiscountAmount], [FinalAmount], [PaidAmount], [RemainingAmount], [DueDate], [Status], [CreatedAt], [IsDeleted] FROM [dbo].[FeeInvoices] WHERE [IsDeleted] = 0"
                
                If Not String.IsNullOrEmpty(status) AndAlso status <> "ALL" Then
                    sql &= " AND [Status] = @Status"
                End If
                
                sql &= " ORDER BY [Id] DESC;"
                
                Return Await conn.QueryAsync(Of FeeInvoice)(sql, New With {.Status = status})
            End Using
        End Function

        Public Async Function AddInvoiceAsync(invoice As FeeInvoice) As Task(Of Integer) Implements IFinanceRepository.AddInvoiceAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    INSERT INTO [dbo].[FeeInvoices] (
                        [InvoiceNumber], [StudentId], [StudentName], [StudentNumber], [ClassName],
                        [FeeType], [OriginalAmount], [DiscountAmount], [FinalAmount],
                        [PaidAmount], [RemainingAmount], [DueDate], [Status], [CreatedAt], [IsDeleted]
                    ) VALUES (
                        @InvoiceNumber, @StudentId, @StudentName, @StudentNumber, @ClassName,
                        @FeeType, @OriginalAmount, @DiscountAmount, @FinalAmount,
                        @PaidAmount, @RemainingAmount, @DueDate, @Status, GETDATE(), 0
                    );
                    SELECT CAST(SCOPE_IDENTITY() AS INT);"
                Return Await conn.ExecuteScalarAsync(Of Integer)(sql, invoice)
            End Using
        End Function

        Public Async Function GetReceiptsAsync(fromDate As DateTime?, toDate As DateTime?) As Task(Of IEnumerable(Of PaymentReceipt)) Implements IFinanceRepository.GetReceiptsAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = "SELECT [Id], [ReceiptNumber], [InvoiceNumber], [StudentName], [Amount], [ReceiptDate], [PaymentMethod], [ReferenceNumber], [CashierName], [CreatedAt] FROM [dbo].[PaymentReceipts] WHERE 1=1"
                If fromDate.HasValue Then
                    sql &= " AND CAST([ReceiptDate] AS DATE) >= CAST(@FromDate AS DATE)"
                End If
                If toDate.HasValue Then
                    sql &= " AND CAST([ReceiptDate] AS DATE) <= CAST(@ToDate AS DATE)"
                End If
                sql &= " ORDER BY [Id] DESC;"
                
                Return Await conn.QueryAsync(Of PaymentReceipt)(sql, New With {.FromDate = fromDate, .ToDate = toDate})
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

        Public Async Function GetFinancialSummaryAsync() As Task(Of Dictionary(Of String, Decimal)) Implements IFinanceRepository.GetFinancialSummaryAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "
                    SELECT 
                        ISNULL(SUM(FinalAmount), 0) AS TotalInvoiced,
                        ISNULL(SUM(PaidAmount), 0) AS TotalCollected,
                        ISNULL(SUM(RemainingAmount), 0) AS TotalRemaining
                    FROM [dbo].[FeeInvoices]
                    WHERE [IsDeleted] = 0;"
                    
                Dim result = Await conn.QueryFirstOrDefaultAsync(sql)
                Dim dict As New Dictionary(Of String, Decimal)()
                
                If result IsNot Nothing Then
                    dict.Add("TotalInvoiced", Convert.ToDecimal(result.TotalInvoiced))
                    dict.Add("TotalCollected", Convert.ToDecimal(result.TotalCollected))
                    dict.Add("TotalRemaining", Convert.ToDecimal(result.TotalRemaining))
                Else
                    dict.Add("TotalInvoiced", 0D)
                    dict.Add("TotalCollected", 0D)
                    dict.Add("TotalRemaining", 0D)
                End If
                
                Return dict
            End Using
        End Function
    End Class
End Namespace
