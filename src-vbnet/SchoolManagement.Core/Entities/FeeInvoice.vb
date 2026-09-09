Imports System

Namespace Entities

    ''' <summary>
    ''' Represents a tuition or services fee invoice issued to a student.
    ''' </summary>
    Public Class FeeInvoice
        Public Property Id As Integer
        Public Property InvoiceNumber As String
        Public Property StudentId As Integer
        Public Property StudentName As String
        Public Property StudentNumber As String
        Public Property ClassName As String
        Public Property FeeType As String
        Public Property OriginalAmount As Decimal
        Public Property DiscountAmount As Decimal
        Public Property FinalAmount As Decimal
        Public Property PaidAmount As Decimal
        Public Property RemainingAmount As Decimal
        Public Property DueDate As DateTime
        Public Property Status As String         ' Paid, Partial, Unpaid
        Public Property CreatedAt As DateTime
    End Class

    ''' <summary>
    ''' Represents an official cash or electronic payment receipt voucher.
    ''' </summary>
    Public Class PaymentReceipt
        Public Property Id As Integer
        Public Property ReceiptNumber As String
        Public Property InvoiceNumber As String
        Public Property StudentName As String
        Public Property Amount As Decimal
        Public Property Date As DateTime
        Public Property PaymentMethod As String  ' مدى, تحويل بنكي, بطاقة ائتمان, نقداً
        Public Property ReferenceNumber As String
        Public Property CashierName As String
        Public Property CreatedAt As DateTime
    End Class

End Namespace
