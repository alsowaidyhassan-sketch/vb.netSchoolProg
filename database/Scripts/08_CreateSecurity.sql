-- ============================================================================
-- Script: 08_CreateSecurity.sql
-- Description: إنشاء مستخدم المدير الافتراضي وتأمين كلمات المرور باستخدام SHA-256 و Salt
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- كلمة المرور الافتراضية: Admin@2025
-- نستخدم HASHBYTES('SHA2_256', ...) مع Salt عشوائي فريد
DECLARE @DefaultSalt NVARCHAR(128) = N'f8d2b904e5718a38c201d4a9840212f1';
DECLARE @DefaultPassword NVARCHAR(100) = N'Admin@2025';
DECLARE @Combined NVARCHAR(256) = @DefaultPassword + @DefaultSalt;
DECLARE @Hash NVARCHAR(256) = CONVERT(NVARCHAR(256), HASHBYTES('SHA2_256', @Combined), 2);

-- إضافة المستخدم المدير إذا لم يكن موجوداً
IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [Username] = N'admin')
BEGIN
    INSERT INTO [dbo].[Users] (
        [SchoolId], [Username], [PasswordHash], [PasswordSalt],
        [FullName], [Email], [Phone], [UserType], [IsActive], [CreatedBy]
    )
    VALUES (
        1, N'admin', @Hash, @DefaultSalt,
        N'المهندس أحمد المنصور - المشرف العام', N'admin@eduraschool.edu.sa',
        N'0555123456', N'Admin', 1, N'System'
    );

    DECLARE @NewUserId INT = SCOPE_IDENTITY();

    -- ربط المستخدم بدور مدير النظام (RoleId = 1)
    INSERT INTO [dbo].[UserRoles] ([UserId], [RoleId])
    VALUES (@NewUserId, 1);

    PRINT N'تم إنشاء حساب المدير الافتراضي: admin / Admin@2025 بنجاح.';
END
ELSE
BEGIN
    PRINT N'حساب المدير موجود مسبقاً.';
END
GO
