-- ============================================================================
-- Script: 09_CreateAudit.sql
-- Description: إنشاء آليات التدقيق الأوتوماتيكية (Audit Triggers) للعمليات الحساسة
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- 1. تريجر تدقيق التعديل والحذف على جدول الطلاب
CREATE OR ALTER TRIGGER [dbo].[trg_Students_Audit]
ON [dbo].[Students]
AFTER UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Action NVARCHAR(20);
    IF EXISTS (SELECT * FROM deleted) AND EXISTS (SELECT * FROM inserted)
        SET @Action = N'UPDATE';
    ELSE IF EXISTS (SELECT * FROM deleted)
        SET @Action = N'DELETE';
    ELSE
        RETURN;

    INSERT INTO [dbo].[AuditLogs] (
        [Username], [Action], [TableName], [RecordId], 
        [OldValues], [NewValues], [Timestamp]
    )
    SELECT 
        SYSTEM_USER,
        @Action,
        N'Students',
        d.[StudentId],
        (SELECT d.[FullName], d.[NationalId], d.[Status], d.[CurrentClassId] FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        (SELECT i.[FullName], i.[NationalId], i.[Status], i.[CurrentClassId] FROM inserted i WHERE i.[StudentId] = d.[StudentId] FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SYSUTCDATETIME()
    FROM deleted d;
END;
GO

-- 2. تريجر تدقيق سندات القبض والمدفوعات
CREATE OR ALTER TRIGGER [dbo].[trg_Payments_Audit]
ON [dbo].[Payments]
AFTER INSERT, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Action NVARCHAR(20) = CASE WHEN EXISTS(SELECT * FROM inserted) THEN N'INSERT' ELSE N'DELETE' END;

    INSERT INTO [dbo].[AuditLogs] (
        [Username], [Action], [TableName], [RecordId],
        [NewValues], [Timestamp]
    )
    SELECT 
        SYSTEM_USER,
        @Action,
        N'Payments',
        COALESCE(i.[PaymentId], d.[PaymentId]),
        (SELECT COALESCE(i.[ReceiptNumber], d.[ReceiptNumber]) AS ReceiptNumber, COALESCE(i.[Amount], d.[Amount]) AS Amount FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
        SYSUTCDATETIME()
    FROM inserted i FULL OUTER JOIN deleted d ON i.PaymentId = d.PaymentId;
END;
GO

PRINT N'تم إنشاء مشغلات التدقيق الأوتوماتيكية بنجاح.';
GO
