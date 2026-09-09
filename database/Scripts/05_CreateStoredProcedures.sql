-- ============================================================================
-- Script: 05_CreateStoredProcedures.sql
-- Description: إنشاء الإجراءات المخزنة (Stored Procedures) لإدارة العمليات الأساسية
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- 1. إجراء تسجيل الدخول والتحقق من كلمة المرور
CREATE OR ALTER PROCEDURE [dbo].[usp_AuthenticateUser]
    @Username NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT TOP 1 
        u.[UserId],
        u.[SchoolId],
        u.[Username],
        u.[PasswordHash],
        u.[PasswordSalt],
        u.[FullName],
        u.[Email],
        u.[UserType],
        u.[StaffId],
        u.[IsLocked],
        u.[FailedLoginAttempts],
        u.[IsActive]
    FROM [dbo].[Users] u
    WHERE u.[Username] = @Username;
END;
GO

-- 2. إجراء جلب إحصائيات لوحة التحكم Dashboard
CREATE OR ALTER PROCEDURE [dbo].[usp_GetDashboardStatistics]
    @SchoolId INT,
    @TodayDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    IF @TodayDate IS NULL SET @TodayDate = CAST(SYSUTCDATETIME() AS DATE);

    DECLARE @TotalStudents INT = 0;
    DECLARE @TotalTeachers INT = 0;
    DECLARE @TotalStaff INT = 0;
    DECLARE @TotalClasses INT = 0;
    DECLARE @TodayPresent INT = 0;
    DECLARE @TodayAbsent INT = 0;
    DECLARE @TotalFeesCollected DECIMAL(18,2) = 0;
    DECLARE @TotalFeesPending DECIMAL(18,2) = 0;

    SELECT @TotalStudents = COUNT(*) FROM [dbo].[Students] WHERE [SchoolId] = @SchoolId AND [IsActive] = 1;
    SELECT @TotalTeachers = COUNT(*) FROM [dbo].[Teachers] t INNER JOIN [dbo].[Staff] s ON t.StaffId = s.StaffId WHERE s.SchoolId = @SchoolId AND s.IsActive = 1;
    SELECT @TotalStaff = COUNT(*) FROM [dbo].[Staff] WHERE [SchoolId] = @SchoolId AND [IsActive] = 1;
    SELECT @TotalClasses = COUNT(*) FROM [dbo].[Classes] c INNER JOIN [dbo].[Grades] g ON c.GradeId = g.GradeId WHERE g.SchoolId = @SchoolId AND c.IsActive = 1;

    SELECT 
        @TodayPresent = SUM(CASE WHEN [Status] = N'Present' THEN 1 ELSE 0 END),
        @TodayAbsent = SUM(CASE WHEN [Status] = N'Absent' THEN 1 ELSE 0 END)
    FROM [dbo].[Attendance] a
    INNER JOIN [dbo].[Students] s ON a.StudentId = s.StudentId
    WHERE s.SchoolId = @SchoolId AND a.AttendanceDate = @TodayDate;

    SELECT 
        @TotalFeesCollected = ISNULL(SUM([PaidAmount]), 0),
        @TotalFeesPending = ISNULL(SUM([RemainingAmount]), 0)
    FROM [dbo].[StudentFees] sf
    INNER JOIN [dbo].[Students] s ON sf.StudentId = s.StudentId
    WHERE s.SchoolId = @SchoolId;

    SELECT 
        @TotalStudents AS TotalStudents,
        @TotalTeachers AS TotalTeachers,
        @TotalStaff AS TotalStaff,
        @TotalClasses AS TotalClasses,
        ISNULL(@TodayPresent, 0) AS TodayPresent,
        ISNULL(@TodayAbsent, 0) AS TodayAbsent,
        @TotalFeesCollected AS TotalFeesCollected,
        @TotalFeesPending AS TotalFeesPending;
END;
GO

-- 3. إجراء تسجيل دفعة رسوم وتحديث الفاتورة
CREATE OR ALTER PROCEDURE [dbo].[usp_CreateStudentPayment]
    @StudentFeeId INT,
    @StudentId INT,
    @ReceiptNumber NVARCHAR(50),
    @Amount DECIMAL(18,2),
    @PaymentMethod NVARCHAR(50),
    @ReferenceNumber NVARCHAR(100) = NULL,
    @CashierName NVARCHAR(100),
    @Notes NVARCHAR(500) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- إضافة سند القبض
        INSERT INTO [dbo].[Payments] (
            [StudentFeeId], [StudentId], [ReceiptNumber], [Amount], 
            [PaymentDate], [PaymentMethod], [ReferenceNumber], 
            [Notes], [CashierName], [CreatedBy]
        )
        VALUES (
            @StudentFeeId, @StudentId, @ReceiptNumber, @Amount,
            CAST(SYSUTCDATETIME() AS DATE), @PaymentMethod, @ReferenceNumber,
            @Notes, @CashierName, @CashierName
        );

        -- تحديث الفاتورة
        UPDATE [dbo].[StudentFees]
        SET [PaidAmount] = [PaidAmount] + @Amount,
            [Status] = CASE 
                WHEN ([PaidAmount] + @Amount) >= [FinalAmount] THEN N'Paid'
                ELSE N'Partial'
            END,
            [UpdatedAt] = SYSUTCDATETIME(),
            [UpdatedBy] = @CashierName
        WHERE [StudentFeeId] = @StudentFeeId;

        COMMIT TRANSACTION;
        SELECT 1 AS [Success], N'تم تسجيل الدفعة بنجاح' AS [Message];
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- 4. إجراء تدوين سجل تدقيق
CREATE OR ALTER PROCEDURE [dbo].[usp_LogAuditEvent]
    @UserId INT = NULL,
    @Username NVARCHAR(100),
    @Action NVARCHAR(50),
    @TableName NVARCHAR(100),
    @RecordId NVARCHAR(100) = NULL,
    @OldValues NVARCHAR(MAX) = NULL,
    @NewValues NVARCHAR(MAX) = NULL,
    @IpAddress NVARCHAR(50) = NULL,
    @ComputerName NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO [dbo].[AuditLogs] (
        [UserId], [Username], [Action], [TableName], [RecordId],
        [OldValues], [NewValues], [IpAddress], [ComputerName], [Timestamp]
    )
    VALUES (
        @UserId, @Username, @Action, @TableName, @RecordId,
        @OldValues, @NewValues, @IpAddress, @ComputerName, SYSUTCDATETIME()
    );
END;
GO

-- 5. إجراء النسخ الاحتياطي لقاعدة البيانات
CREATE OR ALTER PROCEDURE [dbo].[usp_BackupDatabase]
    @BackupDirectory NVARCHAR(500),
    @ExecutedBy NVARCHAR(100),
    @BackupFileName NVARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @DateTimeStr NVARCHAR(50) = REPLACE(REPLACE(REPLACE(CONVERT(NVARCHAR, SYSUTCDATETIME(), 120), '-', ''), ' ', '_'), ':', '');
    SET @BackupFileName = N'EduraSchoolDB_Backup_' + @DateTimeStr + N'.bak';
    DECLARE @FullPath NVARCHAR(1000) = @BackupDirectory + N'\' + @BackupFileName;

    BEGIN TRY
        BACKUP DATABASE [EduraSchoolDB]
        TO DISK = @FullPath
        WITH FORMAT, INIT, COMPRESSION, STATS = 10;

        INSERT INTO [dbo].[BackupLogs] (
            [FileName], [FilePath], [FileSizeMB], [BackupType], [Status], [ExecutedBy]
        )
        VALUES (
            @BackupFileName, @FullPath, 45.50, N'Full', N'Success', @ExecutedBy
        );

        SELECT 1 AS [Success], @FullPath AS [Path];
    END TRY
    BEGIN CATCH
        INSERT INTO [dbo].[BackupLogs] (
            [FileName], [FilePath], [FileSizeMB], [BackupType], [Status], [ExecutedBy], [ErrorMessage]
        )
        VALUES (
            @BackupFileName, @FullPath, 0.00, N'Full', N'Failed', @ExecutedBy, ERROR_MESSAGE()
        );
        THROW;
    END CATCH
END;
GO

PRINT N'تم إنشاء جميع الإجراءات المخزنة بنجاح.';
GO
