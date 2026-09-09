-- ============================================================================
-- Script: 03_CreateRelations.sql
-- Description: إنشاء العلاقات والربط بين الجداول (Foreign Keys)
-- Target: Microsoft SQL Server
-- ============================================================================

USE [EduraSchoolDB];
GO

-- علاقات السنوات الدراسية
ALTER TABLE [dbo].[AcademicYears]
ADD CONSTRAINT [FK_AcademicYears_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

-- علاقات الفصول الدراسية
ALTER TABLE [dbo].[Semesters]
ADD CONSTRAINT [FK_Semesters_AcademicYears] FOREIGN KEY ([AcademicYearId])
REFERENCES [dbo].[AcademicYears] ([AcademicYearId]);

-- علاقات المراحل الدراسية
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_Grades_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

-- علاقات الصفوف
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [FK_Classes_Grades] FOREIGN KEY ([GradeId])
REFERENCES [dbo].[Grades] ([GradeId]);

-- علاقات القاعات الدراسية
ALTER TABLE [dbo].[ClassRooms]
ADD CONSTRAINT [FK_ClassRooms_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

-- علاقات الشُعب
ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [FK_Sections_Classes] FOREIGN KEY ([ClassId])
REFERENCES [dbo].[Classes] ([ClassId]);

ALTER TABLE [dbo].[Sections]
ADD CONSTRAINT [FK_Sections_ClassRooms] FOREIGN KEY ([ClassRoomId])
REFERENCES [dbo].[ClassRooms] ([ClassRoomId]);

-- علاقات الأقسام الإدارية
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [FK_Departments_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

-- علاقات الكادر والموظفين
ALTER TABLE [dbo].[Staff]
ADD CONSTRAINT [FK_Staff_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

ALTER TABLE [dbo].[Staff]
ADD CONSTRAINT [FK_Staff_Departments] FOREIGN KEY ([DepartmentId])
REFERENCES [dbo].[Departments] ([DepartmentId]);

-- علاقات المعلمين
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [FK_Teachers_Staff] FOREIGN KEY ([StaffId])
REFERENCES [dbo].[Staff] ([StaffId]);

-- علاقات المواد الدراسية
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [FK_Subjects_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

-- علاقات جدول ربط المواد بالصفوف
ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [FK_ClassSubjects_Classes] FOREIGN KEY ([ClassId])
REFERENCES [dbo].[Classes] ([ClassId]);

ALTER TABLE [dbo].[ClassSubjects]
ADD CONSTRAINT [FK_ClassSubjects_Subjects] FOREIGN KEY ([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId]);

-- علاقات أولياء الأمور
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [FK_Parents_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

-- علاقات الطلاب
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_Parents] FOREIGN KEY ([PrimaryParentId])
REFERENCES [dbo].[Parents] ([ParentId]);

ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_Classes] FOREIGN KEY ([CurrentClassId])
REFERENCES [dbo].[Classes] ([ClassId]);

ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_Sections] FOREIGN KEY ([CurrentSectionId])
REFERENCES [dbo].[Sections] ([SectionId]);

-- علاقات التسجيل
ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_Enrollments_Students] FOREIGN KEY ([StudentId])
REFERENCES [dbo].[Students] ([StudentId]);

ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_Enrollments_AcademicYears] FOREIGN KEY ([AcademicYearId])
REFERENCES [dbo].[AcademicYears] ([AcademicYearId]);

ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_Enrollments_Classes] FOREIGN KEY ([ClassId])
REFERENCES [dbo].[Classes] ([ClassId]);

ALTER TABLE [dbo].[Enrollments]
ADD CONSTRAINT [FK_Enrollments_Sections] FOREIGN KEY ([SectionId])
REFERENCES [dbo].[Sections] ([SectionId]);

-- علاقات الحضور
ALTER TABLE [dbo].[Attendance]
ADD CONSTRAINT [FK_Attendance_Students] FOREIGN KEY ([StudentId])
REFERENCES [dbo].[Students] ([StudentId]);

ALTER TABLE [dbo].[Attendance]
ADD CONSTRAINT [FK_Attendance_Sections] FOREIGN KEY ([SectionId])
REFERENCES [dbo].[Sections] ([SectionId]);

-- علاقات حضور المعلمين
ALTER TABLE [dbo].[TeacherAttendance]
ADD CONSTRAINT [FK_TeacherAttendance_Teachers] FOREIGN KEY ([TeacherId])
REFERENCES [dbo].[Teachers] ([TeacherId]);

-- علاقات الامتحانات
ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [FK_Exams_AcademicYears] FOREIGN KEY ([AcademicYearId])
REFERENCES [dbo].[AcademicYears] ([AcademicYearId]);

ALTER TABLE [dbo].[Exams]
ADD CONSTRAINT [FK_Exams_ExamTypes] FOREIGN KEY ([ExamTypeId])
REFERENCES [dbo].[ExamTypes] ([ExamTypeId]);

-- علاقات جداول الامتحانات
ALTER TABLE [dbo].[ExamSchedules]
ADD CONSTRAINT [FK_ExamSchedules_Exams] FOREIGN KEY ([ExamId])
REFERENCES [dbo].[Exams] ([ExamId]);

ALTER TABLE [dbo].[ExamSchedules]
ADD CONSTRAINT [FK_ExamSchedules_Classes] FOREIGN KEY ([ClassId])
REFERENCES [dbo].[Classes] ([ClassId]);

ALTER TABLE [dbo].[ExamSchedules]
ADD CONSTRAINT [FK_ExamSchedules_Subjects] FOREIGN KEY ([SubjectId])
REFERENCES [dbo].[Subjects] ([SubjectId]);

-- علاقات نتائج الامتحانات
ALTER TABLE [dbo].[ExamResults]
ADD CONSTRAINT [FK_ExamResults_ExamSchedules] FOREIGN KEY ([ExamScheduleId])
REFERENCES [dbo].[ExamSchedules] ([ExamScheduleId]);

ALTER TABLE [dbo].[ExamResults]
ADD CONSTRAINT [FK_ExamResults_Students] FOREIGN KEY ([StudentId])
REFERENCES [dbo].[Students] ([StudentId]);

-- علاقات الرسوم
ALTER TABLE [dbo].[StudentFees]
ADD CONSTRAINT [FK_StudentFees_Students] FOREIGN KEY ([StudentId])
REFERENCES [dbo].[Students] ([StudentId]);

ALTER TABLE [dbo].[StudentFees]
ADD CONSTRAINT [FK_StudentFees_FeeTypes] FOREIGN KEY ([FeeTypeId])
REFERENCES [dbo].[FeeTypes] ([FeeTypeId]);

-- علاقات الدفعات
ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_Payments_StudentFees] FOREIGN KEY ([StudentFeeId])
REFERENCES [dbo].[StudentFees] ([StudentFeeId]);

ALTER TABLE [dbo].[Payments]
ADD CONSTRAINT [FK_Payments_Students] FOREIGN KEY ([StudentId])
REFERENCES [dbo].[Students] ([StudentId]);

-- علاقات الرواتب
ALTER TABLE [dbo].[Salaries]
ADD CONSTRAINT [FK_Salaries_Staff] FOREIGN KEY ([StaffId])
REFERENCES [dbo].[Staff] ([StaffId]);

-- علاقات المستخدمين والصلاحيات
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_Users_Schools] FOREIGN KEY ([SchoolId])
REFERENCES [dbo].[Schools] ([SchoolId]);

ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UserId])
REFERENCES [dbo].[Users] ([UserId]);

ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY ([RoleId])
REFERENCES [dbo].[Roles] ([RoleId]);

ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_Roles] FOREIGN KEY ([RoleId])
REFERENCES [dbo].[Roles] ([RoleId]);

ALTER TABLE [dbo].[RolePermissions]
ADD CONSTRAINT [FK_RolePermissions_Permissions] FOREIGN KEY ([PermissionId])
REFERENCES [dbo].[Permissions] ([PermissionId]);

PRINT N'تم ربط جميع الجداول والعلاقات بنجاح.';
GO
