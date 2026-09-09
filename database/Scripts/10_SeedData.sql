-- ============================================================================
-- Script: 10_SeedData.sql
-- Description: تعبئة بيانات تجريبية واقعية وشاملة (مدرسة، صفوف، طلاب، معلمين، رسوم)
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- 1. إضافة المدرسة
IF NOT EXISTS (SELECT 1 FROM [dbo].[Schools])
BEGIN
    INSERT INTO [dbo].[Schools] (
        [SchoolName], [SchoolCode], [TaxNumber], [Phone], [Email], 
        [Website], [Address], [City], [PrincipalName], [LicenseNumber]
    )
    VALUES (
        N'مدارس الرواد النموذجية الأهلية', N'RUWAD-001', N'310245678900003',
        N'0114872200', N'info@alruwad-schools.edu.sa', N'https://alruwad-schools.edu.sa',
        N'حي النخيل الغربي، طريق الملك عبد الله', N'الرياض', N'د. عبد العزيز بن إبراهيم الصالح',
        N'LIC-RYD-2024-992'
    );
END
GO

-- 2. إضافة السنة الدراسية والفصول
IF NOT EXISTS (SELECT 1 FROM [dbo].[AcademicYears])
BEGIN
    INSERT INTO [dbo].[AcademicYears] ([SchoolId], [YearName], [StartDate], [EndDate], [IsCurrent])
    VALUES (1, N'1446 - 1447هـ (2025/2026م)', '2025-08-24', '2026-06-18', 1);

    DECLARE @CurYearId INT = SCOPE_IDENTITY();

    INSERT INTO [dbo].[Semesters] ([AcademicYearId], [SemesterName], [SemesterNumber], [StartDate], [EndDate], [IsCurrent])
    VALUES 
    (@CurYearId, N'الفصل الدراسي الأول', 1, '2025-08-24', '2025-11-20', 0),
    (@CurYearId, N'الفصل الدراسي الثاني', 2, '2025-12-01', '2026-03-05', 1),
    (@CurYearId, N'الفصل الدراسي الثالث', 3, '2026-03-15', '2026-06-18', 0);
END
GO

-- 3. المراحل والصفوف والقاعات
IF NOT EXISTS (SELECT 1 FROM [dbo].[Grades])
BEGIN
    INSERT INTO [dbo].[Grades] ([SchoolId], [GradeName], [StageType], [SortOrder])
    VALUES 
    (1, N'المرحلة الابتدائية', N'Primary', 1),
    (1, N'المرحلة المتوسطة', N'Middle', 2),
    (1, N'المرحلة الثانوية', N'High', 3);

    -- الصفوف
    INSERT INTO [dbo].[Classes] ([GradeId], [ClassName], [NumericLevel], [Capacity])
    VALUES 
    (1, N'الصف الأول الابتدائي', 1, 30),
    (1, N'الصف الثاني الابتدائي', 2, 30),
    (1, N'الصف الثالث الابتدائي', 3, 30),
    (2, N'الصف الأول المتوسط', 7, 32),
    (2, N'الصف الثاني المتوسط', 8, 32),
    (3, N'الصف الأول الثانوي', 10, 35),
    (3, N'الصف الثالث الثانوي (مسارات)', 12, 35);

    -- القاعات
    INSERT INTO [dbo].[ClassRooms] ([SchoolId], [RoomNumber], [Building], [Floor], [MaxCapacity], [RoomType])
    VALUES 
    (1, N'قاعة 101', N'المبنى الأكاديمي أ', N'الدور الأرضي', 35, N'Regular'),
    (1, N'قاعة 102', N'المبنى الأكاديمي أ', N'الدور الأرضي', 35, N'Regular'),
    (1, N'مختبر العلوم 1', N'مبنى المختبرات', N'الدور الأول', 40, N'Lab'),
    (1, N'معمل الحاسب الآلي', N'مبنى التقنية', N'الدور الثاني', 35, N'Lab');

    -- الشُعب
    INSERT INTO [dbo].[Sections] ([ClassId], [ClassRoomId], [SectionName], [MaxStudents])
    VALUES 
    (1, 1, N'أ (الصفوة)', 28),
    (1, 2, N'ب (الرواد)', 28),
    (4, 1, N'أ (المتفوقين)', 30),
    (6, 1, N'أ (عام)', 32);
END
GO

-- 4. الكادر والمعلمون
IF NOT EXISTS (SELECT 1 FROM [dbo].[Staff])
BEGIN
    -- إضافة قسم
    INSERT INTO [dbo].[Departments] ([SchoolId], [DepartmentName], [Description])
    VALUES 
    (1, N'الشؤون التعليمية والأكاديمية', N'الإشراف على المعلمين والمناهج والخطط'),
    (1, N'الشؤون المالية والمحاسبة', N'إدارة الفواتير والتحصيل والرواتب'),
    (1, N'الإرشاد الطلابي والقبول', N'متابعة سلوك الطلاب والقبول والتسجيل');

    -- إضافة كادر ومعلمين
    INSERT INTO [dbo].[Staff] (
        [SchoolId], [DepartmentId], [EmployeeNumber], [NationalId], 
        [FirstName], [SecondName], [LastName], [Gender], [DateOfBirth], 
        [Nationality], [Phone], [Email], [HireDate], [JobTitle], [BasicSalary], [Allowances]
    )
    VALUES 
    (1, 1, N'EMP-1001', N'1088234190', N'محمد', N'سالم', N'الغامدي', N'ذكر', '1988-04-12', N'سعودي', N'0501234567', N'm.alghamdi@alruwad.edu.sa', '2020-08-15', N'معلم أول رياضيات', 11500.00, 1500.00),
    (1, 1, N'EMP-1002', N'1099443211', N'طارق', N'عبد الرحمن', N'الشهري', N'ذكر', '1990-11-05', N'سعودي', N'0549876543', N't.alshehri@alruwad.edu.sa', '2021-08-20', N'معلم لغة إنجليزية', 10800.00, 1200.00),
    (1, 1, N'EMP-1003', N'1077654322', N'سارة', N'عبد الله', N'العتيبي', N'أنثى', '1992-06-22', N'سعودي', N'0561122334', N's.alotaibi@alruwad.edu.sa', '2022-01-10', N'معلمة فيزياء وعلوم', 11000.00, 1400.00),
    (1, 2, N'EMP-2001', N'1044321899', N'فهد', N'خالد', N'الدوسري', N'ذكر', '1985-09-18', N'سعودي', N'0558877665', N'f.aldossari@alruwad.edu.sa', '2019-03-01', N'مدير مالي ومحاسب', 13500.00, 2000.00);

    -- ربط كمعلمين
    INSERT INTO [dbo].[Teachers] ([StaffId], [Specialization], [AcademicDegree], [YearsOfExperience])
    VALUES 
    (1, N'رياضيات وتفكير منطقي', N'ماجستير مناهج رياضيات', 9),
    (2, N'لغة إنجليزية وآدابها', N'بكالوريوس لغات وترجمة', 7),
    (3, N'علوم عامة وفيزياء', N'بكالوريوس علوم فيزيائية', 6);
END
GO

-- 5. المواد الدراسية
IF NOT EXISTS (SELECT 1 FROM [dbo].[Subjects])
BEGIN
    INSERT INTO [dbo].[Subjects] ([SchoolId], [SubjectCode], [SubjectName], [CreditHours], [MaxScore], [PassingScore])
    VALUES 
    (1, N'MATH-101', N'الرياضيات المتقدمة', 5, 100.00, 60.00),
    (1, N'ENG-101', N'اللغة الإنجليزية التفاعلية', 4, 100.00, 50.00),
    (1, N'SCI-101', N'العلوم العامة والتطبيقية', 4, 100.00, 50.00),
    (1, N'ARB-101', N'لغتي الجميلة والأدب العربي', 4, 100.00, 50.00),
    (1, N'ISL-101', N'الدراسات الإسلامية والقرآن', 3, 100.00, 50.00),
    (1, N'COMP-101', N'المهارات الرقمية والذكاء الاصطناعي', 3, 100.00, 50.00);
END
GO

-- 6. أولياء الأمور والطلاب
IF NOT EXISTS (SELECT 1 FROM [dbo].[Parents])
BEGIN
    INSERT INTO [dbo].[Parents] (
        [SchoolId], [NationalId], [FirstName], [LastName], [Relationship], 
        [Phone], [Email], [Occupation], [Address]
    )
    VALUES 
    (1, N'1033221199', N'عبد العزيز', N'السبيعي', N'أب', N'0509988771', N'a.subaie@gmail.com', N'مهندس اتصالات', N'الرياض - حي الملقا'),
    (1, N'1044556677', N'سلطان', N'القحطاني', N'أب', N'0553344556', N's.qahtani@yahoo.com', N'رجل أعمال', N'الرياض - حي الياسمين'),
    (1, N'1099887766', N'منيرة', N'الشمري', N'أم', N'0542233445', N'm.shammari@gmail.com', N'طبيبة استشارية', N'الرياض - حي حطين');

    -- إضافة الطلاب
    INSERT INTO [dbo].[Students] (
        [SchoolId], [StudentNumber], [Barcode], [NationalId], 
        [FirstName], [SecondName], [ThirdName], [LastName], 
        [Gender], [DateOfBirth], [BirthPlace], [Nationality], 
        [Phone], [Address], [PrimaryParentId], [EmergencyContactName], 
        [EmergencyContactPhone], [BloodType], [CurrentClassId], [CurrentSectionId], [Status]
    )
    VALUES 
    (1, N'STD-2025-001', N'62810010001', N'1189923451', N'ريان', N'عبد العزيز', N'محمد', N'السبيعي', N'ذكر', '2018-03-14', N'الرياض', N'سعودي', N'0509988771', N'الرياض - حي الملقا', 1, N'عبد العزيز السبيعي', N'0509988771', N'O+', 1, 1, N'Active'),
    (1, N'STD-2025-002', N'62810010002', N'1199882233', N'سارة', N'سلطان', N'سعد', N'القحطاني', N'أنثى', '2018-07-21', N'الرياض', N'سعودي', N'0553344556', N'الرياض - حي الياسمين', 2, N'سلطان القحطاني', N'0553344556', N'A+', 1, 1, N'Active'),
    (1, N'STD-2025-003', N'62810010003', N'1177665544', N'عمر', N'فهد', N'عبد الله', N'الشمري', N'ذكر', '2012-09-10', N'الدمام', N'سعودي', N'0542233445', N'الرياض - حي حطين', 3, N'منيرة الشمري', N'0542233445', N'B+', 4, 3, N'Active'),
    (1, N'STD-2025-004', N'62810010004', N'1166554433', N'فيصل', N'عبد العزيز', N'محمد', N'السبيعي', N'ذكر', '2008-01-05', N'الرياض', N'سعودي', N'0509988771', N'الرياض - حي الملقا', 1, N'عبد العزيز السبيعي', N'0509988771', N'O+', 6, 4, N'Active');
END
GO

-- 7. أنواع الرسوم والفواتير
IF NOT EXISTS (SELECT 1 FROM [dbo].[FeeTypes])
BEGIN
    INSERT INTO [dbo].[FeeTypes] ([SchoolId], [FeeName], [DefaultAmount], [Frequency])
    VALUES 
    (1, N'الرسوم الدراسية السنوية الأساسية', 18000.00, N'Yearly'),
    (1, N'رسوم النقل والمواصلات المدرسية', 4000.00, N'Yearly'),
    (1, N'الحقيبة والكتب المدرسية والزي الرسمي', 1500.00, N'OneTime'),
    (1, N'رسوم الأنشطة الرياضية والمخيمات', 800.00, N'Term');

    -- فواتير للطلاب
    INSERT INTO [dbo].[StudentFees] (
        [StudentId], [FeeTypeId], [AcademicYearId], [InvoiceNumber], 
        [OriginalAmount], [DiscountAmount], [PaidAmount], [DueDate], [Status]
    )
    VALUES 
    (1, 1, 1, N'INV-2025-0001', 18000.00, 1000.00, 17000.00, '2025-09-01', N'Paid'),
    (2, 1, 1, N'INV-2025-0002', 18000.00, 0.00, 9000.00, '2025-09-01', N'Partial'),
    (3, 1, 1, N'INV-2025-0003', 18000.00, 0.00, 0.00, '2025-09-01', N'Unpaid'),
    (4, 1, 1, N'INV-2025-0004', 22000.00, 2000.00, 10000.00, '2025-09-01', N'Partial');

    -- سندات قبض
    INSERT INTO [dbo].[Payments] (
        [StudentFeeId], [StudentId], [ReceiptNumber], [Amount], [PaymentDate], 
        [PaymentMethod], [ReferenceNumber], [CashierName]
    )
    VALUES 
    (1, 1, N'REC-2025-101', 17000.00, '2025-09-02', N'Mada', N'TXN-9844211', N'فهد الدوسري'),
    (2, 2, N'REC-2025-102', 9000.00, '2025-09-05', N'BankTransfer', N'BNK-SA-11029', N'فهد الدوسري'),
    (4, 4, N'REC-2025-103', 10000.00, '2025-09-10', N'CreditCard', N'VIS-9938210', N'فهد الدوسري');
END
GO

PRINT N'تم إدخال البيانات التجريبية الشاملة SeedData بنجاح.';
GO
