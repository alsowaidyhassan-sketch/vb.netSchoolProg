-- ============================================================================
-- Script: 01_CreateDatabase.sql
-- Description: إنشاء قاعدة بيانات نظام إدارة المدارس مع ضبط الـ Collation العربي
-- Target: Microsoft SQL Server 2019 / 2022
-- ============================================================================

USE [master];
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'EduraSchoolDB')
BEGIN
    ALTER DATABASE [EduraSchoolDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [EduraSchoolDB];
END
GO

CREATE DATABASE [EduraSchoolDB]
COLLATE Arabic_100_CI_AS_SC_UTF8;
GO

ALTER DATABASE [EduraSchoolDB] SET COMPATIBILITY_LEVEL = 150;
GO

-- تفعيل SNAPSHOT ISOLATION لمنع الـ Deadlocks في العمليات المتزامنة
ALTER DATABASE [EduraSchoolDB] SET ALLOW_SNAPSHOT_ISOLATION ON;
ALTER DATABASE [EduraSchoolDB] SET READ_COMMITTED_SNAPSHOT ON;
GO

USE [EduraSchoolDB];
GO

PRINT N'تم إنشاء قاعدة بيانات EduraSchoolDB بنجاح وضبط الـ Collation العربي.';
GO
