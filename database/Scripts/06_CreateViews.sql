-- ============================================================================
-- Script: 06_CreateViews.sql
-- Description: إنشاء عروض الاستعلام (Views) لخدمة التقارير والواجهات
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- 1. عرض تفاصيل الطلاب الشامل
CREATE OR ALTER VIEW [dbo].[vw_StudentDetails]
AS
SELECT 
    s.[StudentId],
    s.[SchoolId],
    s.[StudentNumber],
    s.[Barcode],
    s.[NationalId],
    s.[FullName] AS [StudentName],
    s.[Gender],
    s.[DateOfBirth],
    DATEDIFF(YEAR, s.[DateOfBirth], GETDATE()) AS [Age],
    s.[Phone],
    s.[Email],
    s.[Address],
    s.[Status],
    s.[EnrollmentDate],
    s.[BloodType],
    c.[ClassId],
    c.[ClassName],
    sec.[SectionId],
    sec.[SectionName],
    g.[GradeId],
    g.[GradeName],
    p.[ParentId],
    p.[FullName] AS [ParentName],
    p.[Phone] AS [ParentPhone],
    s.[EmergencyContactName],
    s.[EmergencyContactPhone],
    s.[IsActive]
FROM [dbo].[Students] s
LEFT JOIN [dbo].[Classes] c ON s.[CurrentClassId] = c.[ClassId]
LEFT JOIN [dbo].[Sections] sec ON s.[CurrentSectionId] = sec.[SectionId]
LEFT JOIN [dbo].[Grades] g ON c.[GradeId] = g.[GradeId]
LEFT JOIN [dbo].[Parents] p ON s.[PrimaryParentId] = p.[ParentId];
GO

-- 2. عرض ملخص الحضور اليومي
CREATE OR ALTER VIEW [dbo].[vw_DailyAttendanceSummary]
AS
SELECT 
    a.[AttendanceDate],
    c.[ClassId],
    c.[ClassName],
    sec.[SectionId],
    sec.[SectionName],
    COUNT(a.[AttendanceId]) AS [TotalStudents],
    SUM(CASE WHEN a.[Status] = N'Present' THEN 1 ELSE 0 END) AS [PresentCount],
    SUM(CASE WHEN a.[Status] = N'Absent' THEN 1 ELSE 0 END) AS [AbsentCount],
    SUM(CASE WHEN a.[Status] = N'Late' THEN 1 ELSE 0 END) AS [LateCount],
    SUM(CASE WHEN a.[Status] = N'Excused' THEN 1 ELSE 0 END) AS [ExcusedCount],
    ROUND(CAST(SUM(CASE WHEN a.[Status] = N'Present' THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(COUNT(a.[AttendanceId]), 0) * 100, 2) AS [AttendancePercentage]
FROM [dbo].[Attendance] a
INNER JOIN [dbo].[Sections] sec ON a.[SectionId] = sec.[SectionId]
INNER JOIN [dbo].[Classes] c ON sec.[ClassId] = c.[ClassId]
GROUP BY a.[AttendanceDate], c.[ClassId], c.[ClassName], sec.[SectionId], sec.[SectionName];
GO

-- 3. عرض الرسوم والتحصيلات
CREATE OR ALTER VIEW [dbo].[vw_FeeCollectionSummary]
AS
SELECT 
    sf.[StudentFeeId],
    sf.[InvoiceNumber],
    s.[StudentId],
    s.[StudentNumber],
    s.[FullName] AS [StudentName],
    c.[ClassName],
    sec.[SectionName],
    ft.[FeeName],
    sf.[OriginalAmount],
    sf.[DiscountAmount],
    sf.[FinalAmount],
    sf.[PaidAmount],
    sf.[RemainingAmount],
    sf.[DueDate],
    sf.[Status]
FROM [dbo].[StudentFees] sf
INNER JOIN [dbo].[Students] s ON sf.[StudentId] = s.[StudentId]
INNER JOIN [dbo].[FeeTypes] ft ON sf.[FeeTypeId] = ft.[FeeTypeId]
LEFT JOIN [dbo].[Classes] c ON s.[CurrentClassId] = c.[ClassId]
LEFT JOIN [dbo].[Sections] sec ON s.[CurrentSectionId] = sec.[SectionId];
GO

PRINT N'تم إنشاء عروض الاستعلام بنجاح.';
GO
