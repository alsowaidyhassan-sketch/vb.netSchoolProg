import React, { useState } from 'react';
import {
  Code,
  Database,
  Layers,
  FolderTree,
  FileCode,
  Check,
  Copy,
  Terminal,
  ShieldCheck,
  Server
} from 'lucide-react';

export const ArchitectureTab: React.FC = () => {
  const [activeFile, setActiveFile] = useState<'student_entity' | 'teacher_repo' | 'student_service' | 'mainform_vb' | 'sql_script' | 'appsettings'>('student_entity');
  const [copied, setCopied] = useState(false);

  const fileContents: Record<string, { title: string; lang: string; path: string; code: string }> = {
    student_entity: {
      title: 'Student Entity Model (Core Layer)',
      lang: 'VB.NET',
      path: '/src-vbnet/SchoolManagement.Core/Entities/Student.vb',
      code: `Namespace SchoolManagement.Core.Entities

    ''' <summary>
    ''' Represents an enrolled student record in the educational institution.
    ''' Conforms to enterprise standards, validation rules, and audit requirements.
    ''' </summary>
    Public Class Student
        Public Property Id As Integer
        Public Property StudentNumber As String      ' STD-XXXXX
        Public Property NationalId As String         ' 10 digits
        Public Property FirstName As String
        Public Property SecondName As String
        Public Property ThirdName As String
        Public Property LastName As String
        Public Property Gender As String             ' ذكر / أنثى
        Public Property DateOfBirth As DateTime
        Public Property BirthPlace As String
        Public Property Nationality As String
        Public Property BloodType As String          ' O+, A+, etc.
        Public Property ClassId As Integer
        Public Property ClassName As String
        Public Property SectionName As String
        Public Property PrimaryParentName As String
        Public Property PrimaryParentPhone As String
        Public Property EmergencyContactPhone As String
        Public Property Address As String
        Public Property Email As String
        Public Property Barcode As String
        Public Property MedicalNotes As String
        Public Property EnrollmentDate As DateTime
        Public Property Status As String             ' Active, Suspended, Graduated, Transferred
        Public Property IsDeleted As Boolean

        Public ReadOnly Property FullName As String
            Get
                Return $"{FirstName} {SecondName} {ThirdName} {LastName}".Trim()
            End Get
        End Property

        Public ReadOnly Property Age As Integer
            Get
                Dim today = DateTime.Today
                Dim ageVal = today.Year - DateOfBirth.Year
                If DateOfBirth.Date > today.AddYears(-ageVal) Then ageVal -= 1
                Return ageVal
            End Get
        End Property
    End Class

End Namespace`
    },
    teacher_repo: {
      title: 'Teacher Repository with Dapper (Data Access Layer)',
      lang: 'VB.NET',
      path: '/src-vbnet/SchoolManagement.Data/TeacherRepository.vb',
      code: `Imports System.Data
Imports Dapper
Imports Microsoft.Data.SqlClient
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace SchoolManagement.Data

    Public Class TeacherRepository
        Implements ITeacherRepository

        Private ReadOnly _connectionManager As ConnectionManager

        Public Sub New(connectionManager As ConnectionManager)
            _connectionManager = connectionManager
        End Sub

        Public Async Function GetAllAsync() As Task(Of IEnumerable(Of Teacher)) Implements ITeacherRepository.GetAllAsync
            Const sql = "
                SELECT 
                    Id, EmployeeNumber, FullName, Specialization, AcademicDegree,
                    Phone, Email, AssignedSubjects, AssignedClasses,
                    YearsOfExperience, BasicSalary, Allowances, Status, IsDeleted
                FROM Teachers
                WHERE IsDeleted = 0
                ORDER BY FullName ASC;"

            Using conn = _connectionManager.CreateConnection()
                Return Await conn.QueryAsync(Of Teacher)(sql)
            End Using
        End Function

        Public Async Function AddAsync(teacher As Teacher) As Task(Of Integer) Implements ITeacherRepository.AddAsync
            Const sql = "
                INSERT INTO Teachers (
                    EmployeeNumber, FullName, Specialization, AcademicDegree,
                    Phone, Email, AssignedSubjects, AssignedClasses,
                    YearsOfExperience, BasicSalary, Allowances, Status, CreatedAt, IsDeleted
                ) VALUES (
                    @EmployeeNumber, @FullName, @Specialization, @AcademicDegree,
                    @Phone, @Email, @AssignedSubjects, @AssignedClasses,
                    @YearsOfExperience, @BasicSalary, @Allowances, @Status, GETDATE(), 0
                );
                SELECT CAST(SCOPE_IDENTITY() as int);"

            Using conn = _connectionManager.CreateConnection()
                Return Await conn.ExecuteScalarAsync(Of Integer)(sql, teacher)
            End Using
        End Function
    End Class

End Namespace`
    },
    student_service: {
      title: 'Student Service with Validation & Audit (Business Logic Layer)',
      lang: 'VB.NET',
      path: '/src-vbnet/SchoolManagement.Services/StudentService.vb',
      code: `Imports System.Text.RegularExpressions
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces

Namespace SchoolManagement.Services

    Public Class StudentService
        Private ReadOnly _studentRepo As IStudentRepository

        Public Sub New(studentRepo As IStudentRepository)
            _studentRepo = studentRepo
        End Sub

        Public Async Function RegisterNewStudentAsync(student As Student) As Task(Of Integer)
            ' 1. Enterprise Validation Rules
            If String.IsNullOrWhiteSpace(student.FirstName) OrElse String.IsNullOrWhiteSpace(student.LastName) Then
                Throw New ArgumentException("اسم الطالب واسم العائلة حقول إلزامية.")
            End If

            If String.IsNullOrWhiteSpace(student.NationalId) OrElse student.NationalId.Length <> 10 Then
                Throw New ArgumentException("رقم الهوية الوطنية / الإقامة يجب أن يتكون من 10 أرقام.")
            End If

            ' 2. Uniqueness Check
            Dim existing = Await _studentRepo.GetByNationalIdAsync(student.NationalId)
            If existing IsNot Nothing Then
                Throw New InvalidOperationException("رقم الهوية الوطنية مسجل مسبقاً لطالب آخر.")
            End If

            ' 3. Auto Generate Academic Sequence
            If String.IsNullOrWhiteSpace(student.StudentNumber) Then
                Dim nextSeq = Await _studentRepo.GetNextSequenceAsync()
                student.StudentNumber = $"STD-{DateTime.Now.Year}-{nextSeq:D4}"
                student.Barcode = $"BAR-{DateTime.Now.Year}-{nextSeq:D4}"
            End If

            student.EnrollmentDate = DateTime.Now
            student.Status = "Active"
            student.IsDeleted = False

            Return Await _studentRepo.AddAsync(student)
        End Function
    End Class

End Namespace`
    },
    mainform_vb: {
      title: 'MainForm Modern Tabbed WinForms UI (Presentation Layer)',
      lang: 'VB.NET',
      path: '/src-vbnet/SchoolManagement.App/Forms/MainForm.vb',
      code: `'=============================================================================
' Application: Edura School Management Desktop System
' Layer: Presentation (UI) Layer - WinForms with Modern Custom Drawing
' Author: Senior Software Architect & VB.NET Developer
' Framework: .NET 8.0 Windows Desktop
'=============================================================================

Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class MainForm
    Inherits Form

    Private WithEvents tabMain As TabControl
    Private statusStrip As StatusStrip
    Private lblDatabaseStatus As ToolStripStatusLabel
    Private lblUser As ToolStripStatusLabel
    Private lblTime As ToolStripStatusLabel

    Public Sub New()
        InitializeComponent()
        ApplyEnterpriseTheme()
        LoadTabs()
    End Sub

    Private Sub InitializeComponent()
        Me.Text = "نظام إدارتي لإدارة المدارس | Edura School Management Enterprise"
        Me.Size = New Size(1280, 800)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.RightToLeft = RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.Font = New Font("Cairo", 9.5F, FontStyle.Regular)
        Me.BackColor = Color.FromArgb(15, 23, 42)

        tabMain = New TabControl() With {
            .Dock = DockStyle.Fill,
            .DrawMode = TabDrawMode.OwnerDrawFixed,
            .ItemSize = New Size(140, 42),
            .SizeMode = TabSizeMode.Fixed
        }
        Me.Controls.Add(tabMain)
    End Sub

    Private Sub LoadTabs()
        tabMain.TabPages.Add(New TabPage("لوحة القيادة") With {.Tag = "Dashboard"})
        tabMain.TabPages.Add(New TabPage("شؤون الطلاب") With {.Tag = "Students"})
        tabMain.TabPages.Add(New TabPage("المعلمون") With {.Tag = "Teachers"})
        tabMain.TabPages.Add(New TabPage("الفصول والشعب") With {.Tag = "Classes"})
        tabMain.TabPages.Add(New TabPage("المواد الدراسية") With {.Tag = "Subjects"})
        tabMain.TabPages.Add(New TabPage("الحضور والغياب") With {.Tag = "Attendance"})
        tabMain.TabPages.Add(New TabPage("الامتحانات والدرجات") With {.Tag = "Exams"})
        tabMain.TabPages.Add(New TabPage("المالية والرسوم") With {.Tag = "Finance"})
        tabMain.TabPages.Add(New TabPage("الموارد البشرية") With {.Tag = "HR"})
        tabMain.TabPages.Add(New TabPage("التقارير") With {.Tag = "Reports"})
        tabMain.TabPages.Add(New TabPage("التدقيق الأمني") With {.Tag = "Audit"})
        tabMain.TabPages.Add(New TabPage("النسخ الاحتياطي") With {.Tag = "Backup"})
        tabMain.TabPages.Add(New TabPage("الإعدادات") With {.Tag = "Settings"})
    End Sub
End Class`
    },
    sql_script: {
      title: 'SQL Server Complete Database Schema & Triggers',
      lang: 'T-SQL',
      path: '/database/Scripts/Complete_SchoolManagement_DB.sql',
      code: `-- =============================================================================
-- Database: SchoolManagementDB
-- Collation: Arabic_100_CI_AS_SC_UTF8
-- Architecture: Enterprise 3-Tier with Triggers, Stored Procedures, and Indexes
-- =============================================================================

CREATE DATABASE [SchoolManagementDB]
COLLATE Arabic_100_CI_AS_SC_UTF8;
GO

USE [SchoolManagementDB];
GO

-- 1. Students Table with Audit & Soft Delete
CREATE TABLE dbo.Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    StudentNumber NVARCHAR(20) NOT NULL UNIQUE,
    NationalId NVARCHAR(10) NOT NULL UNIQUE,
    FirstName NVARCHAR(50) NOT NULL,
    SecondName NVARCHAR(50) NOT NULL,
    ThirdName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    DateOfBirth DATE NOT NULL,
    BirthPlace NVARCHAR(50) NULL,
    Nationality NVARCHAR(50) NOT NULL DEFAULT N'سعودي',
    BloodType NVARCHAR(5) NULL,
    ClassId INT NOT NULL,
    ClassName NVARCHAR(50) NOT NULL,
    SectionName NVARCHAR(20) NOT NULL,
    PrimaryParentName NVARCHAR(100) NOT NULL,
    PrimaryParentPhone NVARCHAR(20) NOT NULL,
    EmergencyContactPhone NVARCHAR(20) NULL,
    Address NVARCHAR(200) NULL,
    Email NVARCHAR(100) NULL,
    Barcode NVARCHAR(50) NOT NULL UNIQUE,
    MedicalNotes NVARCHAR(MAX) NULL,
    EnrollmentDate DATE NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT N'Active',
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    UpdatedAt DATETIME2 NULL,
    IsDeleted BIT NOT NULL DEFAULT 0
);
GO

-- 2. Audit Trail Trigger on Students
CREATE TRIGGER trg_Students_Audit
ON dbo.Students
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @Action NVARCHAR(10);
    IF EXISTS (SELECT * FROM inserted) AND EXISTS (SELECT * FROM deleted)
        SET @Action = 'UPDATE';
    ELSE IF EXISTS (SELECT * FROM inserted)
        SET @Action = 'INSERT';
    ELSE
        SET @Action = 'DELETE';

    INSERT INTO dbo.AuditLogs (TableName, Action, RecordId, Username, Timestamp, Details, IpAddress)
    SELECT 
        'Students',
        @Action,
        COALESCE(i.Id, d.Id),
        SUSER_SNAME(),
        SYSUTCDATETIME(),
        CONCAT('StudentNumber: ', COALESCE(i.StudentNumber, d.StudentNumber)),
        CONVERT(NVARCHAR(50), CONNECTIONPROPERTY('client_net_address'))
    FROM inserted i
    FULL OUTER JOIN deleted d ON i.Id = d.Id;
END;
GO`
    },
    appsettings: {
      title: 'Configuration File (appsettings.json)',
      lang: 'JSON',
      path: '/src-vbnet/SchoolManagement.App/appsettings.json',
      code: `{
  "ConnectionStrings": {
    "SchoolDatabase": "Server=localhost;Database=SchoolManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;"
  },
  "ApplicationSettings": {
    "SchoolName": "مدارس الرواد النموذجية الأهلية",
    "SchoolNameEn": "Al-Ruwwad Model Private Schools",
    "AcademicYear": "1446-1447هـ",
    "CurrentSemester": "الفصل الدراسي الثاني",
    "Theme": "ModernDark",
    "EnableAuditLogs": true,
    "AutoBackupIntervalHours": 24
  }
}`
    }
  };

  const current = fileContents[activeFile];

  const handleCopy = () => {
    navigator.clipboard.writeText(current.code);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000);
  };

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-blue-600/20 border border-blue-500/40 rounded-xl text-blue-400">
            <Layers className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">معمارية النظام والأكواد المصدرية (Architecture & VB.NET Codebase)</h2>
            <p className="text-xs text-slate-400">
              تصفح الأكواد الكاملة للطبقات: Presentation, Business Logic (BLL), Data Access (DAL), Database Triggers
            </p>
          </div>
        </div>

        <button
          onClick={handleCopy}
          className="flex items-center gap-2 px-4 py-2 bg-slate-800 hover:bg-slate-700 text-slate-200 text-xs font-bold rounded-xl border border-slate-700 transition-colors cursor-pointer"
        >
          {copied ? <Check className="w-4 h-4 text-emerald-400" /> : <Copy className="w-4 h-4" />}
          <span>{copied ? 'تم نسخ الكود!' : 'نسخ الكود المصدري'}</span>
        </button>
      </div>

      {/* Architecture Highlights */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-3 text-xs">
        <div className="p-4 bg-slate-900 border border-slate-800 rounded-xl space-y-1">
          <div className="text-blue-400 font-bold">1. طبقة الواجهات (Presentation)</div>
          <div className="text-slate-300">VB.NET WinForms + OwnerDrawFixed TabControl</div>
          <div className="text-[11px] text-slate-500 font-mono">SchoolManagement.App</div>
        </div>
        <div className="p-4 bg-slate-900 border border-slate-800 rounded-xl space-y-1">
          <div className="text-indigo-400 font-bold">2. طبقة الأعمال (Services / BLL)</div>
          <div className="text-slate-300">قواعد التحقق، الترقيم التلقائي، والعمليات التجارية</div>
          <div className="text-[11px] text-slate-500 font-mono">SchoolManagement.Services</div>
        </div>
        <div className="p-4 bg-slate-900 border border-slate-800 rounded-xl space-y-1">
          <div className="text-emerald-400 font-bold">3. طبقة الوصول للبيانات (DAL)</div>
          <div className="text-slate-300">Dapper Micro-ORM + Microsoft.Data.SqlClient</div>
          <div className="text-[11px] text-slate-500 font-mono">SchoolManagement.Data</div>
        </div>
        <div className="p-4 bg-slate-900 border border-slate-800 rounded-xl space-y-1">
          <div className="text-purple-400 font-bold">4. خادم قاعدة البيانات (Database)</div>
          <div className="text-slate-300">Microsoft SQL Server 2022 + UTF-8 + Triggers</div>
          <div className="text-[11px] text-slate-500 font-mono">SchoolManagementDB</div>
        </div>
      </div>

      {/* Code Browser Layout */}
      <div className="grid grid-cols-1 md:grid-cols-4 gap-4">
        {/* Sidebar File Explorer */}
        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-4 space-y-2 text-xs">
          <div className="text-xs font-bold text-slate-400 pb-2 border-b border-slate-800 flex items-center gap-1.5">
            <FolderTree className="w-4 h-4 text-blue-400" />
            <span>ملفات الحل البرمجي (.sln)</span>
          </div>

          <div className="space-y-1 pt-1">
            {[
              { id: 'student_entity', name: 'Student.vb (Entity)', layer: 'Core' },
              { id: 'teacher_repo', name: 'TeacherRepository.vb', layer: 'Data (Dapper)' },
              { id: 'student_service', name: 'StudentService.vb', layer: 'Services (BLL)' },
              { id: 'mainform_vb', name: 'MainForm.vb', layer: 'WinForms UI' },
              { id: 'sql_script', name: 'SchoolManagement_DB.sql', layer: 'SQL Server' },
              { id: 'appsettings', name: 'appsettings.json', layer: 'Config' }
            ].map((f) => (
              <button
                key={f.id}
                onClick={() => setActiveFile(f.id as any)}
                className={`w-full text-right p-2.5 rounded-xl transition-all cursor-pointer flex flex-col ${
                  activeFile === f.id
                    ? 'bg-blue-600/20 text-white border border-blue-500/50'
                    : 'text-slate-400 hover:bg-slate-800 hover:text-slate-200'
                }`}
              >
                <div className="font-mono text-xs font-semibold">{f.name}</div>
                <div className="text-[10px] text-slate-500">{f.layer}</div>
              </button>
            ))}
          </div>
        </div>

        {/* Code Viewer Panel */}
        <div className="md:col-span-3 bg-slate-950 border border-slate-800 rounded-2xl overflow-hidden shadow-2xl flex flex-col">
          <div className="p-3 bg-slate-900/80 border-b border-slate-800 flex items-center justify-between text-xs">
            <div className="flex items-center gap-2 font-mono">
              <FileCode className="w-4 h-4 text-blue-400" />
              <span className="text-slate-200 font-bold">{current.title}</span>
              <span className="text-[10px] bg-slate-800 text-slate-400 px-2 py-0.5 rounded">{current.lang}</span>
            </div>
            <span className="text-[11px] text-slate-500 font-mono">{current.path}</span>
          </div>

          <div className="p-4 overflow-x-auto custom-scrollbar font-mono text-xs leading-relaxed text-slate-300">
            <pre className="whitespace-pre">{current.code}</pre>
          </div>
        </div>
      </div>
    </div>
  );
};
