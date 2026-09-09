-- ============================================================================
-- Script: 04_CreateIndexes.sql
-- Description: إنشاء الفهارس (Indexes) لتسريع عمليات البحث والاستعلام
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- فهارس الطلاب
CREATE NONCLUSTERED INDEX [IX_Students_Search] 
ON [dbo].[Students] ([FullName], [Phone], [NationalId])
INCLUDE ([StudentNumber], [Gender], [CurrentClassId], [CurrentSectionId], [Status]);
GO

CREATE NONCLUSTERED INDEX [IX_Students_ClassSection]
ON [dbo].[Students] ([CurrentClassId], [CurrentSectionId])
INCLUDE ([StudentNumber], [FullName], [Status], [Gender]);
GO

-- فهارس الحضور والغياب
CREATE NONCLUSTERED INDEX [IX_Attendance_DateStatus]
ON [dbo].[Attendance] ([AttendanceDate], [Status])
INCLUDE ([StudentId], [SectionId]);
GO

CREATE NONCLUSTERED INDEX [IX_Attendance_StudentDate]
ON [dbo].[Attendance] ([StudentId], [AttendanceDate])
INCLUDE ([Status], [LateMinutes]);
GO

-- فهارس الرسوم والمدفوعات
CREATE NONCLUSTERED INDEX [IX_StudentFees_StudentStatus]
ON [dbo].[StudentFees] ([StudentId], [Status])
INCLUDE ([InvoiceNumber], [OriginalAmount], [DiscountAmount], [PaidAmount], [DueDate]);
GO

CREATE NONCLUSTERED INDEX [IX_Payments_Date]
ON [dbo].[Payments] ([PaymentDate])
INCLUDE ([StudentFeeId], [StudentId], [Amount], [PaymentMethod], [ReceiptNumber]);
GO

-- فهارس نتائج الامتحانات
CREATE NONCLUSTERED INDEX [IX_ExamResults_Schedule]
ON [dbo].[ExamResults] ([ExamScheduleId], [IsPassed])
INCLUDE ([StudentId], [ObtainedScore]);
GO

-- فهارس الموظفين والمعلمين
CREATE NONCLUSTERED INDEX [IX_Staff_NamePhone]
ON [dbo].[Staff] ([FullName], [Phone])
INCLUDE ([EmployeeNumber], [JobTitle], [DepartmentId], [IsActive]);
GO

-- فهارس سجل التدقيق Audit
CREATE NONCLUSTERED INDEX [IX_AuditLogs_Timestamp]
ON [dbo].[AuditLogs] ([Timestamp] DESC)
INCLUDE ([Username], [Action], [TableName], [RecordId]);
GO

PRINT N'تم إنشاء جميع الفهارس الاستراتيجية بنجاح.';
GO
