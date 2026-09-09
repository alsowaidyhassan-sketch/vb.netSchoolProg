-- ============================================================================
-- Script: 07_InsertDefaultData.sql
-- Description: إدخال الأدوار والصلاحيات والإعدادات الافتراضية
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- 1. إدخال الأدوار الافتراضية
INSERT INTO [dbo].[Roles] ([RoleName], [Description], [IsSystemRole])
VALUES 
(N'مدير النظام (Administrator)', N'صلاحيات كاملة وغير محدودة على كافة أقسام النظام والبيانات', 1),
(N'مدير المدرسة (Principal)', N'صلاحيات إدارية وأكاديمية ومتابعة التقارير وسير العمل', 1),
(N'معلم (Teacher)', N'صلاحيات إدخال الحضور والغياب، ورصد الدرجات، والواجبات للمواد المسندة', 0),
(N'محاسب مالي (Accountant)', N'إدارة الرسوم، تحصيل الدفعات، إصدار السندات، ومتابعة المطالبات', 0),
(N'مسؤول الموارد البشرية (HR Officer)', N'إدارة شؤون الموظفين، الحضور، الإجازات، ومسيرات الرواتب', 0),
(N'موظف استقبال وتوجيه (Receptionist)', N'تسجيل الطلاب الجدد، استعراض بيانات الطلاب، وتعديل الاتصال', 0),
(N'مستعرض تقارير فقط (Viewer)', N'استعراض وتصدير التقارير الإحصائية دون إمكانية التعديل', 0);
GO

-- 2. إدخال الصلاحيات لكافة الوحدات البرمجية
INSERT INTO [dbo].[Permissions] ([Module], [Action], [PermissionKey], [Description])
VALUES
-- الطلاب
(N'Students', N'View', N'Students.View', N'استعراض قائمة الطلاب وملفاتهم'),
(N'Students', N'Create', N'Students.Create', N'إضافة طالب جديد'),
(N'Students', N'Edit', N'Students.Edit', N'تعديل بيانات الطالب'),
(N'Students', N'Delete', N'Students.Delete', N'حذف أو أرشفة طالب'),
(N'Students', N'Print', N'Students.Print', N'طباعة الملف التعريفي للطالب'),
(N'Students', N'Export', N'Students.Export', N'تصدير قائمة الطلاب إلى Excel/PDF'),

-- المعلمون
(N'Teachers', N'View', N'Teachers.View', N'استعراض قائمة المعلمين'),
(N'Teachers', N'Create', N'Teachers.Create', N'إضافة معلم جديد'),
(N'Teachers', N'Edit', N'Teachers.Edit', N'تعديل بيانات المعلم'),
(N'Teachers', N'Delete', N'Teachers.Delete', N'حذف أو إيقاف معلم'),

-- الفصول والمواد
(N'Classes', N'Manage', N'Classes.Manage', N'إدارة المراحل والصفوف والشُعب والقاعات'),
(N'Subjects', N'Manage', N'Subjects.Manage', N'إدارة المواد الدراسية والخطة التعليمية'),

-- الحضور
(N'Attendance', N'View', N'Attendance.View', N'استعراض سجلات الحضور'),
(N'Attendance', N'Record', N'Attendance.Record', N'تسجيل حضور وغياب الطلاب'),

-- الامتحانات والدرجات
(N'Exams', N'Manage', N'Exams.Manage', N'إعداد جداول الامتحانات'),
(N'Grades', N'Record', N'Grades.Record', N'رصد وتعديل درجات الطلاب'),
(N'Grades', N'Approve', N'Grades.Approve', N'اعتماد النتائج النهائية وطباعة الشهادات'),

-- الرسوم والمالية
(N'Finance', N'View', N'Finance.View', N'استعراض الرسوم والحركات المالية'),
(N'Finance', N'Collect', N'Finance.Collect', N'تحصيل الرسوم وإصدار سندات القبض'),
(N'Finance', N'Discount', N'Finance.Discount', N'تطبيق المنح والخصومات المالية'),

-- الموارد البشرية
(N'HR', N'Manage', N'HR.Manage', N'إدارة الموظفين والرواتب والإجازات'),

-- التقارير
(N'Reports', N'View', N'Reports.View', N'استعراض التقارير وطباعتها وتصديرها'),

-- الأمان والنسخ الاحتياطي
(N'Users', N'Manage', N'Users.Manage', N'إدارة المستخدمين ومنح الصلاحيات'),
(N'Backup', N'Execute', N'Backup.Execute', N'أخذ واسترجاع النسخ الاحتياطية'),
(N'Audit', N'View', N'Audit.View', N'الاطلاع على سجلات التدقيق والعمليات'),
(N'Settings', N'Manage', N'Settings.Manage', N'تعديل إعدادات النظام والمدرسة');
GO

-- 3. منح كافة الصلاحيات لدور مدير النظام Administrator
INSERT INTO [dbo].[RolePermissions] ([RoleId], [PermissionId])
SELECT 1, [PermissionId] FROM [dbo].[Permissions];
GO

PRINT N'تم إدخال الأدوار والصلاحيات الافتراضية بنجاح.';
GO
