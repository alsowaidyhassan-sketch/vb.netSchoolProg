-- ============================================================================
-- Script: 02_CreateTables.sql
-- Description: إنشاء جميع جداول نظام إدارة المدارس مع القيود والأعمدة التدقيقية
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- 1. جدول المدارس (Schools)
CREATE TABLE [dbo].[Schools] (
    [SchoolId] INT IDENTITY(1,1) NOT NULL,
    [SchoolName] NVARCHAR(200) NOT NULL,
    [SchoolCode] NVARCHAR(50) NOT NULL,
    [TaxNumber] NVARCHAR(50) NULL,
    [Phone] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(150) NOT NULL,
    [Website] NVARCHAR(200) NULL,
    [Address] NVARCHAR(500) NOT NULL,
    [City] NVARCHAR(100) NOT NULL,
    [Country] NVARCHAR(100) NOT NULL DEFAULT N'جمهورية العراق',
    [PostalCode] NVARCHAR(20) NULL,
    [LogoPath] NVARCHAR(500) NULL,
    [PrincipalName] NVARCHAR(150) NOT NULL,
    [LicenseNumber] NVARCHAR(100) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED ([SchoolId] ASC),
    CONSTRAINT [UQ_Schools_SchoolCode] UNIQUE NONCLUSTERED ([SchoolCode] ASC)
);
GO

-- 2. السنوات الدراسية (AcademicYears)
CREATE TABLE [dbo].[AcademicYears] (
    [AcademicYearId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [YearName] NVARCHAR(100) NOT NULL, -- مثال: 2025/2026
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [IsCurrent] BIT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_AcademicYears] PRIMARY KEY CLUSTERED ([AcademicYearId] ASC)
);
GO

-- 3. الفصول الدراسية (Semesters)
CREATE TABLE [dbo].[Semesters] (
    [SemesterId] INT IDENTITY(1,1) NOT NULL,
    [AcademicYearId] INT NOT NULL,
    [SemesterName] NVARCHAR(100) NOT NULL, -- الفصل الأول / الثاني / الثالث
    [SemesterNumber] TINYINT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [IsCurrent] BIT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Semesters] PRIMARY KEY CLUSTERED ([SemesterId] ASC)
);
GO

-- 4. المراحل الدراسية (Grades / Stages)
CREATE TABLE [dbo].[Grades] (
    [GradeId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [GradeName] NVARCHAR(100) NOT NULL, -- الابتدائي، المتوسط، الثانوي
    [StageType] NVARCHAR(50) NOT NULL, -- Primary / Middle / High
    [SortOrder] INT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Grades] PRIMARY KEY CLUSTERED ([GradeId] ASC)
);
GO

-- 5. الصفوف الدراسية (Classes)
CREATE TABLE [dbo].[Classes] (
    [ClassId] INT IDENTITY(1,1) NOT NULL,
    [GradeId] INT NOT NULL,
    [ClassName] NVARCHAR(100) NOT NULL, -- الصف الأول، الثاني، الثالث
    [NumericLevel] INT NOT NULL,
    [Capacity] INT NOT NULL DEFAULT 30,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED ([ClassId] ASC)
);
GO

-- 6. القاعات الدراسية (ClassRooms)
CREATE TABLE [dbo].[ClassRooms] (
    [ClassRoomId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [RoomNumber] NVARCHAR(50) NOT NULL,
    [Building] NVARCHAR(100) NOT NULL,
    [Floor] NVARCHAR(50) NOT NULL,
    [MaxCapacity] INT NOT NULL DEFAULT 35,
    [RoomType] NVARCHAR(50) NOT NULL DEFAULT N'Regular', -- Regular / Lab / Library
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ClassRooms] PRIMARY KEY CLUSTERED ([ClassRoomId] ASC)
);
GO

-- 7. الشُعب الدراسية (Sections)
CREATE TABLE [dbo].[Sections] (
    [SectionId] INT IDENTITY(1,1) NOT NULL,
    [ClassId] INT NOT NULL,
    [ClassRoomId] INT NULL,
    [SectionName] NVARCHAR(50) NOT NULL, -- أ / ب / ج
    [MaxStudents] INT NOT NULL DEFAULT 30,
    [LeaderTeacherId] INT NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Sections] PRIMARY KEY CLUSTERED ([SectionId] ASC)
);
GO

-- 8. الأقسام الإدارية (Departments)
CREATE TABLE [dbo].[Departments] (
    [DepartmentId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [DepartmentName] NVARCHAR(150) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);
GO

-- 9. الكادر والموظفون (Staff)
CREATE TABLE [dbo].[Staff] (
    [StaffId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [DepartmentId] INT NULL,
    [EmployeeNumber] NVARCHAR(50) NOT NULL,
    [NationalId] NVARCHAR(30) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [SecondName] NVARCHAR(100) NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [FullName] AS ([FirstName] + ' ' + ISNULL([SecondName] + ' ', '') + [LastName]) PERSISTED,
    [Gender] NVARCHAR(10) NOT NULL, -- ذكر / أنثى
    [DateOfBirth] DATE NOT NULL,
    [Nationality] NVARCHAR(100) NOT NULL DEFAULT N'عراقي',
    [Phone] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(150) NOT NULL,
    [Address] NVARCHAR(500) NULL,
    [HireDate] DATE NOT NULL,
    [JobTitle] NVARCHAR(100) NOT NULL,
    [BasicSalary] DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    [Allowances] DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    [PhotoPath] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED ([StaffId] ASC),
    CONSTRAINT [UQ_Staff_EmployeeNumber] UNIQUE NONCLUSTERED ([EmployeeNumber] ASC),
    CONSTRAINT [UQ_Staff_NationalId] UNIQUE NONCLUSTERED ([NationalId] ASC)
);
GO

-- 10. المعلمون (Teachers)
CREATE TABLE [dbo].[Teachers] (
    [TeacherId] INT IDENTITY(1,1) NOT NULL,
    [StaffId] INT NOT NULL,
    [Specialization] NVARCHAR(150) NOT NULL,
    [AcademicDegree] NVARCHAR(100) NOT NULL, -- بكالوريوس / ماجستير / دكتوراه
    [GraduationUniversity] NVARCHAR(200) NULL,
    [GraduationYear] INT NULL,
    [YearsOfExperience] INT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED ([TeacherId] ASC)
);
GO

-- 11. المواد الدراسية (Subjects)
CREATE TABLE [dbo].[Subjects] (
    [SubjectId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [SubjectCode] NVARCHAR(50) NOT NULL,
    [SubjectName] NVARCHAR(150) NOT NULL,
    [CreditHours] INT NOT NULL DEFAULT 3,
    [MaxScore] DECIMAL(6,2) NOT NULL DEFAULT 100.00,
    [PassingScore] DECIMAL(6,2) NOT NULL DEFAULT 50.00,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED ([SubjectId] ASC),
    CONSTRAINT [UQ_Subjects_Code] UNIQUE NONCLUSTERED ([SchoolId] ASC, [SubjectCode] ASC)
);
GO

-- 12. ربط المواد بالصفوف (ClassSubjects)
CREATE TABLE [dbo].[ClassSubjects] (
    [ClassSubjectId] INT IDENTITY(1,1) NOT NULL,
    [ClassId] INT NOT NULL,
    [SubjectId] INT NOT NULL,
    [WeeklyClasses] INT NOT NULL DEFAULT 4,
    [IsMandatory] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ClassSubjects] PRIMARY KEY CLUSTERED ([ClassSubjectId] ASC),
    CONSTRAINT [UQ_ClassSubjects] UNIQUE NONCLUSTERED ([ClassId] ASC, [SubjectId] ASC)
);
GO

-- 13. أولياء الأمور (Parents)
CREATE TABLE [dbo].[Parents] (
    [ParentId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [NationalId] NVARCHAR(30) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [FullName] AS ([FirstName] + ' ' + [LastName]) PERSISTED,
    [Relationship] NVARCHAR(50) NOT NULL DEFAULT N'أب', -- أب / أم / ولي أمر
    [Phone] NVARCHAR(20) NOT NULL,
    [AlternativePhone] NVARCHAR(20) NULL,
    [Email] NVARCHAR(150) NULL,
    [Occupation] NVARCHAR(150) NULL,
    [Workplace] NVARCHAR(200) NULL,
    [Address] NVARCHAR(500) NOT NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Parents] PRIMARY KEY CLUSTERED ([ParentId] ASC),
    CONSTRAINT [UQ_Parents_NationalId] UNIQUE NONCLUSTERED ([NationalId] ASC)
);
GO

-- 14. الطلاب (Students - المعايير العراقية: الاسم الخماسي، وثائق الهوية، والعنوان العراقي)
CREATE TABLE [dbo].[Students] (
    [StudentId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [StudentNumber] NVARCHAR(50) NOT NULL,
    [Barcode] NVARCHAR(100) NULL,
    
    -- وثائق الهوية العراقية
    [IdentityDocumentType] NVARCHAR(50) NOT NULL DEFAULT N'البطاقة الوطنية الموحدة', -- البطاقة الوطنية الموحدة / هوية الأحوال المدنية / شهادة الجنسية العراقية / جواز السفر
    [NationalId] NVARCHAR(30) NOT NULL, -- رقم البطاقة الوطنية (12 رقماً) أو رقم الهوية

    -- الاسم الخماسي العراقي واسم الأم
    [FirstName] NVARCHAR(100) NOT NULL, -- الاسم الأول
    [FatherName] NVARCHAR(100) NOT NULL, -- اسم الأب
    [GrandFatherName] NVARCHAR(100) NOT NULL, -- اسم الجد
    [GreatGrandFatherName] NVARCHAR(100) NULL, -- اسم الجد الأعلى
    [FamilyName] NVARCHAR(100) NULL, -- اللقب أو العشيرة
    [MotherName] NVARCHAR(150) NULL, -- اسم الأم الثلاثي

    -- حقول التوافق مع الأنظمة السابقة
    [SecondName] NVARCHAR(100) NULL,
    [ThirdName] NVARCHAR(100) NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [FullName] AS ([FirstName] + ' ' + [FatherName] + ' ' + [GrandFatherName] + ISNULL(' ' + [GreatGrandFatherName], '') + ISNULL(' ' + [FamilyName], '')) PERSISTED,

    [Gender] NVARCHAR(10) NOT NULL, -- ذكر / أنثى
    [DateOfBirth] DATE NOT NULL,
    [BirthPlace] NVARCHAR(100) NULL DEFAULT N'بغداد',
    [Nationality] NVARCHAR(100) NOT NULL DEFAULT N'عراقي',
    [Phone] NVARCHAR(20) NULL, -- أرقام الهواتف العراقية 07XXXXXXXXX
    [Email] NVARCHAR(150) NULL,

    -- تفاصيل العنوان السكني في جمهورية العراق
    [Province] NVARCHAR(100) NOT NULL DEFAULT N'بغداد', -- المحافظة
    [District] NVARCHAR(100) NULL, -- القضاء
    [SubDistrict] NVARCHAR(100) NULL, -- الناحية
    [Area] NVARCHAR(150) NULL, -- الحي أو المنطقة
    [Mahalla] NVARCHAR(50) NULL, -- المحلة
    [Zuqaq] NVARCHAR(50) NULL, -- الزقاق
    [HouseNumber] NVARCHAR(50) NULL, -- رقم الدار
    [NearestLandmark] NVARCHAR(200) NULL, -- أقرب نقطة دالة
    [Address] NVARCHAR(500) NULL,

    [PhotoPath] NVARCHAR(500) NULL,
    [PrimaryParentId] INT NULL,
    [EmergencyContactName] NVARCHAR(150) NOT NULL,
    [EmergencyContactPhone] NVARCHAR(20) NOT NULL,
    [BloodType] NVARCHAR(10) NULL,
    [HasSpecialNeeds] BIT NOT NULL DEFAULT 0,
    [MedicalNotes] NVARCHAR(MAX) NULL,
    [CurrentSectionId] INT NULL,
    [CurrentClassId] INT NULL,
    [Status] NVARCHAR(50) NOT NULL DEFAULT N'Active', -- Active / Suspended / Graduated / Transferred
    [EnrollmentDate] DATE NOT NULL DEFAULT CAST(SYSUTCDATETIME() AS DATE),
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CONSTRAINT [UQ_Students_StudentNumber] UNIQUE NONCLUSTERED ([StudentNumber] ASC),
    CONSTRAINT [UQ_Students_NationalId] UNIQUE NONCLUSTERED ([NationalId] ASC)
);
GO

-- 14.ب جدول الوثائق الثبوتية الرسمية العراقية (IdentityDocuments)
CREATE TABLE [dbo].[IdentityDocuments] (
    [DocumentId] INT IDENTITY(1,1) NOT NULL,
    [OwnerType] NVARCHAR(50) NOT NULL, -- Student / Parent / Staff
    [OwnerId] INT NOT NULL,
    [DocumentType] NVARCHAR(100) NOT NULL, -- البطاقة الوطنية الموحدة / هوية الأحوال المدنية / شهادة الجنسية العراقية / جواز السفر العراقي
    [DocumentNumber] NVARCHAR(50) NOT NULL,
    [IssuingAuthority] NVARCHAR(150) NULL, -- دائرة أحوال الكرخ / الرصافة
    [IssuingProvince] NVARCHAR(100) NOT NULL DEFAULT N'بغداد',
    [IssueDate] DATE NULL,
    [ExpiryDate] DATE NULL,
    [PageNumber] NVARCHAR(50) NULL, -- الصحيفة
    [RecordNumber] NVARCHAR(50) NULL, -- السجل
    [FamilyRecordNumber] NVARCHAR(50) NULL, -- الرقم العائلي
    [DocumentScanPath] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    CONSTRAINT [PK_IdentityDocuments] PRIMARY KEY CLUSTERED ([DocumentId] ASC)
);
GO

-- 15. تسجيل الطلاب في السنوات الدراسية (Enrollments)
CREATE TABLE [dbo].[Enrollments] (
    [EnrollmentId] INT IDENTITY(1,1) NOT NULL,
    [StudentId] INT NOT NULL,
    [AcademicYearId] INT NOT NULL,
    [ClassId] INT NOT NULL,
    [SectionId] INT NOT NULL,
    [EnrollmentDate] DATE NOT NULL,
    [RollNumber] INT NULL,
    [Status] NVARCHAR(50) NOT NULL DEFAULT N'Enrolled', -- Enrolled / Completed / Dropped / Promoted
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Enrollments] PRIMARY KEY CLUSTERED ([EnrollmentId] ASC),
    CONSTRAINT [UQ_Enrollments_Year] UNIQUE NONCLUSTERED ([StudentId] ASC, [AcademicYearId] ASC)
);
GO

-- 16. حضور وغياب الطلاب (Attendance)
CREATE TABLE [dbo].[Attendance] (
    [AttendanceId] BIGINT IDENTITY(1,1) NOT NULL,
    [StudentId] INT NOT NULL,
    [SectionId] INT NOT NULL,
    [AcademicYearId] INT NOT NULL,
    [AttendanceDate] DATE NOT NULL,
    [Status] NVARCHAR(20) NOT NULL, -- Present / Absent / Late / Excused
    [LateMinutes] INT NOT NULL DEFAULT 0,
    [ExcuseReason] NVARCHAR(500) NULL,
    [RecordedBy] NVARCHAR(100) NOT NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceId] ASC),
    CONSTRAINT [UQ_Attendance_Day] UNIQUE NONCLUSTERED ([StudentId] ASC, [AttendanceDate] ASC)
);
GO

-- 17. حضور المعلمين (TeacherAttendance)
CREATE TABLE [dbo].[TeacherAttendance] (
    [TeacherAttendanceId] BIGINT IDENTITY(1,1) NOT NULL,
    [TeacherId] INT NOT NULL,
    [AttendanceDate] DATE NOT NULL,
    [CheckInTime] TIME(0) NULL,
    [CheckOutTime] TIME(0) NULL,
    [Status] NVARCHAR(20) NOT NULL DEFAULT N'Present', -- Present / Absent / Late / OnLeave
    [Notes] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_TeacherAttendance] PRIMARY KEY CLUSTERED ([TeacherAttendanceId] ASC),
    CONSTRAINT [UQ_TeacherAttendance_Day] UNIQUE NONCLUSTERED ([TeacherId] ASC, [AttendanceDate] ASC)
);
GO

-- 18. أنواع الامتحانات (ExamTypes)
CREATE TABLE [dbo].[ExamTypes] (
    [ExamTypeId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [TypeName] NVARCHAR(100) NOT NULL, -- شهري / نصفي / نهائي / قصير / عملي
    [WeightPercentage] DECIMAL(5,2) NOT NULL DEFAULT 20.00,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ExamTypes] PRIMARY KEY CLUSTERED ([ExamTypeId] ASC)
);
GO

-- 19. الامتحانات (Exams)
CREATE TABLE [dbo].[Exams] (
    [ExamId] INT IDENTITY(1,1) NOT NULL,
    [AcademicYearId] INT NOT NULL,
    [SemesterId] INT NOT NULL,
    [ExamTypeId] INT NOT NULL,
    [ExamName] NVARCHAR(200) NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NOT NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Exams] PRIMARY KEY CLUSTERED ([ExamId] ASC)
);
GO

-- 20. جداول الامتحانات للمواد (ExamSchedules)
CREATE TABLE [dbo].[ExamSchedules] (
    [ExamScheduleId] INT IDENTITY(1,1) NOT NULL,
    [ExamId] INT NOT NULL,
    [ClassId] INT NOT NULL,
    [SubjectId] INT NOT NULL,
    [ExamDate] DATE NOT NULL,
    [StartTime] TIME(0) NOT NULL,
    [EndTime] TIME(0) NOT NULL,
    [MaxScore] DECIMAL(6,2) NOT NULL DEFAULT 100.00,
    [PassingScore] DECIMAL(6,2) NOT NULL DEFAULT 50.00,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ExamSchedules] PRIMARY KEY CLUSTERED ([ExamScheduleId] ASC)
);
GO

-- 21. نتائج الامتحانات والدرجات (ExamResults)
CREATE TABLE [dbo].[ExamResults] (
    [ExamResultId] BIGINT IDENTITY(1,1) NOT NULL,
    [ExamScheduleId] INT NOT NULL,
    [StudentId] INT NOT NULL,
    [ObtainedScore] DECIMAL(6,2) NOT NULL,
    [Percentage] AS (([ObtainedScore] / 100.00) * 100.00) PERSISTED,
    [IsPassed] BIT NOT NULL DEFAULT 1,
    [Remarks] NVARCHAR(250) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_ExamResults] PRIMARY KEY CLUSTERED ([ExamResultId] ASC),
    CONSTRAINT [UQ_ExamResults_Student] UNIQUE NONCLUSTERED ([ExamScheduleId] ASC, [StudentId] ASC)
);
GO

-- 22. أنواع الرسوم الدراسية (FeeTypes)
CREATE TABLE [dbo].[FeeTypes] (
    [FeeTypeId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [FeeName] NVARCHAR(150) NOT NULL, -- رسوم دراسية / نقل مدرسي / كتب وزي / نشاط
    [DefaultAmount] DECIMAL(18,2) NOT NULL,
    [Frequency] NVARCHAR(50) NOT NULL DEFAULT N'Yearly', -- OneTime / Monthly / Term / Yearly
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_FeeTypes] PRIMARY KEY CLUSTERED ([FeeTypeId] ASC)
);
GO

-- 23. الفواتير والرسوم المستحقة على الطلاب (StudentFees)
CREATE TABLE [dbo].[StudentFees] (
    [StudentFeeId] INT IDENTITY(1,1) NOT NULL,
    [StudentId] INT NOT NULL,
    [FeeTypeId] INT NOT NULL,
    [AcademicYearId] INT NOT NULL,
    [InvoiceNumber] NVARCHAR(50) NOT NULL,
    [OriginalAmount] DECIMAL(18,2) NOT NULL,
    [DiscountAmount] DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    [FinalAmount] AS ([OriginalAmount] - [DiscountAmount]) PERSISTED,
    [PaidAmount] DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    [RemainingAmount] AS ([OriginalAmount] - [DiscountAmount] - [PaidAmount]) PERSISTED,
    [DueDate] DATE NOT NULL,
    [Status] NVARCHAR(50) NOT NULL DEFAULT N'Unpaid', -- Paid / Partial / Unpaid / Overdue
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_StudentFees] PRIMARY KEY CLUSTERED ([StudentFeeId] ASC),
    CONSTRAINT [UQ_StudentFees_Invoice] UNIQUE NONCLUSTERED ([InvoiceNumber] ASC)
);
GO

-- 24. سندات القبض والدفعات (Payments)
CREATE TABLE [dbo].[Payments] (
    [PaymentId] INT IDENTITY(1,1) NOT NULL,
    [StudentFeeId] INT NOT NULL,
    [StudentId] INT NOT NULL,
    [ReceiptNumber] NVARCHAR(50) NOT NULL,
    [Amount] DECIMAL(18,2) NOT NULL,
    [PaymentDate] DATE NOT NULL,
    [PaymentMethod] NVARCHAR(50) NOT NULL DEFAULT N'Cash', -- Cash / BankTransfer / CreditCard / Mada / Cheque
    [ReferenceNumber] NVARCHAR(100) NULL,
    [Notes] NVARCHAR(500) NULL,
    [CashierName] NVARCHAR(100) NOT NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([PaymentId] ASC),
    CONSTRAINT [UQ_Payments_Receipt] UNIQUE NONCLUSTERED ([ReceiptNumber] ASC)
);
GO

-- 25. رواتب الموظفين (Salaries)
CREATE TABLE [dbo].[Salaries] (
    [SalaryId] INT IDENTITY(1,1) NOT NULL,
    [StaffId] INT NOT NULL,
    [MonthYear] NVARCHAR(20) NOT NULL, -- 2025-05
    [BasicSalary] DECIMAL(18,2) NOT NULL,
    [Allowances] DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    [Deductions] DECIMAL(18,2) NOT NULL DEFAULT 0.00,
    [NetSalary] AS ([BasicSalary] + [Allowances] - [Deductions]) PERSISTED,
    [PaymentDate] DATE NULL,
    [Status] NVARCHAR(50) NOT NULL DEFAULT N'Pending', -- Pending / Paid / Hold
    [PaymentMethod] NVARCHAR(50) NOT NULL DEFAULT N'BankTransfer',
    [Notes] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Salaries] PRIMARY KEY CLUSTERED ([SalaryId] ASC)
);
GO

-- 26. المستخدمون (Users)
CREATE TABLE [dbo].[Users] (
    [UserId] INT IDENTITY(1,1) NOT NULL,
    [SchoolId] INT NOT NULL,
    [Username] NVARCHAR(50) NOT NULL,
    [PasswordHash] NVARCHAR(256) NOT NULL,
    [PasswordSalt] NVARCHAR(128) NOT NULL,
    [FullName] NVARCHAR(150) NOT NULL,
    [Email] NVARCHAR(150) NOT NULL,
    [Phone] NVARCHAR(20) NULL,
    [UserType] NVARCHAR(50) NOT NULL DEFAULT N'Staff', -- Admin / Teacher / Accountant / Reception
    [StaffId] INT NULL,
    [IsLocked] BIT NOT NULL DEFAULT 0,
    [FailedLoginAttempts] INT NOT NULL DEFAULT 0,
    [LastLoginDate] DATETIME2(7) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [UQ_Users_Username] UNIQUE NONCLUSTERED ([Username] ASC)
);
GO

-- 27. الأدوار (Roles)
CREATE TABLE [dbo].[Roles] (
    [RoleId] INT IDENTITY(1,1) NOT NULL,
    [RoleName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(250) NULL,
    [IsSystemRole] BIT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    [UpdatedAt] DATETIME2(7) NULL,
    [CreatedBy] NVARCHAR(100) NOT NULL DEFAULT N'System',
    [UpdatedBy] NVARCHAR(100) NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([RoleId] ASC),
    CONSTRAINT [UQ_Roles_Name] UNIQUE NONCLUSTERED ([RoleName] ASC)
);
GO

-- 28. الصلاحيات (Permissions)
CREATE TABLE [dbo].[Permissions] (
    [PermissionId] INT IDENTITY(1,1) NOT NULL,
    [Module] NVARCHAR(100) NOT NULL, -- Students / Teachers / Classes / Fees / Exams / Reports / Settings / Backup
    [Action] NVARCHAR(100) NOT NULL, -- View / Create / Edit / Delete / Print / Export
    [PermissionKey] NVARCHAR(150) NOT NULL, -- Students.View, Students.Create, etc.
    [Description] NVARCHAR(250) NULL,
    CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED ([PermissionId] ASC),
    CONSTRAINT [UQ_Permissions_Key] UNIQUE NONCLUSTERED ([PermissionKey] ASC)
);
GO

-- 29. صلاحيات الأدوار (RolePermissions)
CREATE TABLE [dbo].[RolePermissions] (
    [RolePermissionId] INT IDENTITY(1,1) NOT NULL,
    [RoleId] INT NOT NULL,
    [PermissionId] INT NOT NULL,
    CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED ([RolePermissionId] ASC),
    CONSTRAINT [UQ_RolePermissions] UNIQUE NONCLUSTERED ([RoleId] ASC, [PermissionId] ASC)
);
GO

-- 30. أدوار المستخدمين (UserRoles)
CREATE TABLE [dbo].[UserRoles] (
    [UserRoleId] INT IDENTITY(1,1) NOT NULL,
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [UQ_UserRoles] UNIQUE NONCLUSTERED ([UserId] ASC, [RoleId] ASC)
);
GO

-- 31. سجل التدقيق والرقابة (AuditLogs)
CREATE TABLE [dbo].[AuditLogs] (
    [AuditLogId] BIGINT IDENTITY(1,1) NOT NULL,
    [UserId] INT NULL,
    [Username] NVARCHAR(100) NOT NULL,
    [Action] NVARCHAR(50) NOT NULL, -- INSERT / UPDATE / DELETE / LOGIN / LOGOUT / BACKUP
    [TableName] NVARCHAR(100) NOT NULL,
    [RecordId] NVARCHAR(100) NULL,
    [OldValues] NVARCHAR(MAX) NULL,
    [NewValues] NVARCHAR(MAX) NULL,
    [IpAddress] NVARCHAR(50) NULL,
    [ComputerName] NVARCHAR(100) NULL,
    [Timestamp] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED ([AuditLogId] ASC)
);
GO

-- 32. سجلات النسخ الاحتياطي (BackupLogs)
CREATE TABLE [dbo].[BackupLogs] (
    [BackupLogId] INT IDENTITY(1,1) NOT NULL,
    [FileName] NVARCHAR(500) NOT NULL,
    [FilePath] NVARCHAR(1000) NOT NULL,
    [FileSizeMB] DECIMAL(10,2) NOT NULL,
    [BackupType] NVARCHAR(50) NOT NULL DEFAULT N'Full', -- Full / Differential / Log
    [Status] NVARCHAR(50) NOT NULL DEFAULT N'Success',
    [ExecutedBy] NVARCHAR(100) NOT NULL,
    [ExecutionTimeSeconds] INT NOT NULL DEFAULT 0,
    [ErrorMessage] NVARCHAR(MAX) NULL,
    [Timestamp] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT [PK_BackupLogs] PRIMARY KEY CLUSTERED ([BackupLogId] ASC)
);
GO

-- 33. الإشعارات والتنبيهات (Notifications)
CREATE TABLE [dbo].[Notifications] (
    [NotificationId] INT IDENTITY(1,1) NOT NULL,
    [Title] NVARCHAR(200) NOT NULL,
    [Message] NVARCHAR(1000) NOT NULL,
    [Category] NVARCHAR(50) NOT NULL DEFAULT N'General', -- Fees / Attendance / Exams / System
    [Priority] NVARCHAR(20) NOT NULL DEFAULT N'Normal', -- Low / Normal / High / Urgent
    [TargetUserId] INT NULL, -- NULL تعني للجميع
    [IsRead] BIT NOT NULL DEFAULT 0,
    [ActionUrl] NVARCHAR(250) NULL,
    [CreatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT [PK_Notifications] PRIMARY KEY CLUSTERED ([NotificationId] ASC)
);
GO

-- 34. إعدادات النظام (SystemSettings)
CREATE TABLE [dbo].[SystemSettings] (
    [SettingId] INT IDENTITY(1,1) NOT NULL,
    [SettingKey] NVARCHAR(100) NOT NULL,
    [SettingValue] NVARCHAR(MAX) NOT NULL,
    [Category] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(250) NULL,
    [UpdatedAt] DATETIME2(7) NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT [PK_SystemSettings] PRIMARY KEY CLUSTERED ([SettingId] ASC),
    CONSTRAINT [UQ_SystemSettings_Key] UNIQUE NONCLUSTERED ([SettingKey] ASC)
);
GO

PRINT N'تم إنشاء جميع جداول النظام بنجاح.';
GO
