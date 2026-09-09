Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports SchoolManagement.Core.Entities

Namespace Interfaces
    Public Interface IRepository(Of T As Class)
        Function GetByIdAsync(id As Integer) As Task(Of T)
        Function GetAllAsync() As Task(Of IEnumerable(Of T))
        Function AddAsync(entity As T) As Task(Of Integer)
        Function UpdateAsync(entity As T) As Task(Of Boolean)
        Function DeleteAsync(id As Integer) As Task(Of Boolean)
    End Interface

    Public Interface IStudentRepository
        Inherits IRepository(Of Student)
        Function SearchStudentsAsync(query As String, classId As Integer?, status As String) As Task(Of IEnumerable(Of Student))
        Function GetByStudentNumberAsync(studentNumber As String) As Task(Of Student)
        Function GetByNationalIdAsync(nationalId As String) As Task(Of Student)
    End Interface

    Public Interface IAttendanceRepository
        Function RecordDailyAttendanceAsync(records As IEnumerable(Of AttendanceRecord)) As Task(Of Boolean)
        Function GetSectionAttendanceAsync(sectionId As Integer, attendanceDate As DateTime) As Task(Of IEnumerable(Of AttendanceRecord))
        Function GetAttendanceStatsAsync(schoolId As Integer, targetDate As DateTime) As Task(Of IDictionary(Of String, Integer))
    End Interface

    Public Interface ITeacherRepository
        Inherits IRepository(Of Teacher)
        Function GetByEmployeeNumberAsync(employeeNumber As String) As Task(Of Teacher)
        Function GetBySpecializationAsync(specialization As String) As Task(Of IEnumerable(Of Teacher))
    End Interface

    Public Interface IFinanceRepository
        Function GetInvoicesAsync(status As String) As Task(Of IEnumerable(Of FeeInvoice))
        Function AddInvoiceAsync(invoice As FeeInvoice) As Task(Of Integer)
        Function GetReceiptsAsync(fromDate As DateTime?, toDate As DateTime?) As Task(Of IEnumerable(Of PaymentReceipt))
        Function AddPaymentReceiptAsync(receipt As PaymentReceipt) As Task(Of Integer)
        Function GetFinancialSummaryAsync() As Task(Of IDictionary(Of String, Decimal))
    End Interface

    Public Interface IExamRepository
        Function GetStudentGradesAsync(studentId As Integer) As Task(Of IEnumerable(Of StudentGrade))
        Function SaveGradeAsync(grade As StudentGrade) As Task(Of Boolean)
        Function GetExamScheduleAsync(classId As Integer?) As Task(Of IEnumerable(Of ExamRecord))
    End Interface
End Namespace
