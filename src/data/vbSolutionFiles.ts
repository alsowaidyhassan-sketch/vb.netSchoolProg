export interface CodeFile {
  path: string;
  name: string;
  language: 'vb' | 'sql' | 'json' | 'xml' | 'markdown';
  category: 'Solution' | 'Core' | 'Data' | 'Services' | 'UI' | 'Database' | 'Config';
  description: string;
  content: string;
}

export const vbSolutionFiles: CodeFile[] = [
  {
    path: 'SchoolManagement.sln',
    name: 'SchoolManagement.sln',
    language: 'xml',
    category: 'Solution',
    description: 'ملف الـ Solution الرئيسي لـ Visual Studio 2022 يربط كافة مشاريع النظام',
    content: `Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.10.35013.160
MinimumVisualStudioVersion = 10.0.40219.1
Project("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}") = "SchoolManagement.Core", "src-vbnet\\SchoolManagement.Core\\SchoolManagement.Core.vbproj", "{A1B2C3D4-E5F6-4A5B-8C9D-0E1F2A3B4C5D}"
EndProject
Project("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}") = "SchoolManagement.Data", "src-vbnet\\SchoolManagement.Data\\SchoolManagement.Data.vbproj", "{B2C3D4E5-F6A7-4B6C-9D0E-1F2A3B4C5D6E}"
EndProject
Project("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}") = "SchoolManagement.Services", "src-vbnet\\SchoolManagement.Services\\SchoolManagement.Services.vbproj", "{C3D4E5F6-A7B8-4C7D-0E1F-2A3B4C5D6E7F}"
EndProject
Project("{F184B08F-C81C-45F6-A57F-5ABD9991F28F}") = "SchoolManagement.App", "src-vbnet\\SchoolManagement.App\\SchoolManagement.App.vbproj", "{D4E5F6A7-B8C9-4D8E-1F2A-3B4C5D6E7F80}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
EndGlobal`
  },
  {
    path: 'src-vbnet/SchoolManagement.App/Forms/MainForm.vb',
    name: 'MainForm.vb',
    language: 'vb',
    category: 'UI',
    description: 'النافذة الرئيسية للنظام تدعم نظام التبويبات المتعددة Tabs وقائمة جانبية Sidebar وشريط حالة',
    content: `Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace Forms
    Public Class MainForm
        Inherits Form

        Private WithEvents pnlSidebar As Panel
        Private WithEvents pnlTopBar As Panel
        Private WithEvents pnlStatusBar As Panel
        Private WithEvents tabMain As TabControl
        Private lblAppTitle As Label
        Private lblDbStatus As Label

        Public Sub New()
            InitializeComponent()
            OpenTab("لوحة التحكم", "Dashboard")
        End Sub

        Private Sub InitializeComponent()
            Me.Text = "نظام إدارتي لإدارة المدارس - Edura School Management"
            Me.Size = New Size(1366, 768)
            Me.RightToLeft = RightToLeft.Yes
            Me.RightToLeftLayout = True
            Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)

            pnlTopBar = New Panel With { .Dock = DockStyle.Top, .Height = 56, .BackColor = Color.FromArgb(15, 23, 42) }
            pnlSidebar = New Panel With { .Dock = DockStyle.Right, .Width = 240, .BackColor = Color.FromArgb(30, 41, 59) }
            pnlStatusBar = New Panel With { .Dock = DockStyle.Bottom, .Height = 28, .BackColor = Color.FromArgb(15, 23, 42) }

            tabMain = New TabControl With {
                .Dock = DockStyle.Fill,
                .Font = New Font("Segoe UI", 10, FontStyle.Bold),
                .DrawMode = TabDrawMode.OwnerDrawFixed,
                .ItemSize = New Size(150, 36)
            }
            AddHandler tabMain.MouseDown, AddressOf OnTabMouseDown

            Me.Controls.Add(tabMain)
            Me.Controls.Add(pnlSidebar)
            Me.Controls.Add(pnlTopBar)
            Me.Controls.Add(pnlStatusBar)
        End Sub

        Public Sub OpenTab(title As String, key As String)
            ' منع تكرار فتح التبويب إذا كان مفتوحاً بالفعل
            For Each tab As TabPage In tabMain.TabPages
                If tab.Name = key Then
                    tabMain.SelectedTab = tab
                    Return
                End If
            Next

            Dim newTab = New TabPage With {
                .Name = key,
                .Text = title & "  ✕",
                .BackColor = Color.FromArgb(248, 250, 252)
            }
            tabMain.TabPages.Add(newTab)
            tabMain.SelectedTab = newTab
        End Sub

        Private Sub OnTabMouseDown(sender As Object, e As MouseEventArgs)
            For i As Integer = 0 To tabMain.TabCount - 1
                Dim r = tabMain.GetTabRect(i)
                Dim closeRect = New Rectangle(r.Right - 25, r.Top + 6, 20, 20)
                If closeRect.Contains(e.Location) Then
                    If tabMain.TabPages(i).Name <> "Dashboard" Then
                        tabMain.TabPages.RemoveAt(i)
                    End If
                    Return
                End If
            Next
        End Sub
    End Class
End Namespace`
  },
  {
    path: 'src-vbnet/SchoolManagement.Data/StudentRepository.vb',
    name: 'StudentRepository.vb',
    language: 'vb',
    category: 'Data',
    description: 'مستودع بيانات الطلاب يطبق Repository Pattern واستعلامات Dapper فائقة السرعة مع SQL Server',
    content: `Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports Dapper
Imports SchoolManagement.Core.Entities
Imports SchoolManagement.Core.Interfaces
Imports SchoolManagement.Data.Infrastructure

Namespace Repositories
    Public Class StudentRepository
        Implements IStudentRepository

        Public Async Function GetByIdAsync(id As Integer) As Task(Of Student) Implements IRepository(Of Student).GetByIdAsync
            Using conn = ConnectionManager.CreateConnection()
                Const sql As String = "SELECT * FROM [dbo].[Students] WHERE [StudentId] = @Id AND [IsActive] = 1;"
                Return Await conn.QueryFirstOrDefaultAsync(Of Student)(sql, New With {.Id = id})
            End Using
        End Function

        Public Async Function SearchStudentsAsync(query As String, classId As Integer?, status As String) As Task(Of IEnumerable(Of Student)) Implements IStudentRepository.SearchStudentsAsync
            Using conn = ConnectionManager.CreateConnection()
                Dim sql As String = "
                    SELECT * FROM [dbo].[Students]
                    WHERE [IsActive] = 1
                      AND (@Query IS NULL OR [FullName] LIKE '%' + @Query + '%' OR [StudentNumber] LIKE '%' + @Query + '%')
                      AND (@ClassId IS NULL OR [CurrentClassId] = @ClassId)
                      AND (@Status IS NULL OR [Status] = @Status)
                    ORDER BY [StudentId] DESC;"
                Return Await conn.QueryAsync(Of Student)(sql, New With {.Query = query, .ClassId = classId, .Status = status})
            End Using
        End Function
    End Class
End Namespace`
  },
  {
    path: 'src-vbnet/SchoolManagement.App/appsettings.json',
    name: 'appsettings.json',
    language: 'json',
    category: 'Config',
    description: 'ملف إعدادات الاتصال بـ Microsoft SQL Server ومعاملات التطبيق والنسخ الاحتياطي',
    content: `{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EduraSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;Connect Timeout=30;"
  },
  "ApplicationSettings": {
    "SchoolCode": "RUWAD-001",
    "ApplicationName": "Edura School Management Enterprise",
    "Version": "2.4.0",
    "Language": "ar-SA",
    "Theme": "DarkNavy",
    "EnableAuditLogs": true,
    "AutoBackupIntervalHours": 24,
    "BackupDirectory": "C:\\\\Backups\\\\EduraSchoolDB"
  }
}`
  },
  {
    path: 'database/Scripts/01_CreateDatabase.sql',
    name: '01_CreateDatabase.sql',
    language: 'sql',
    category: 'Database',
    description: 'نص إنشاء قاعدة البيانات في SQL Server مع عزل المعاملات وضبط الترميز العربي',
    content: `USE [master];
GO
CREATE DATABASE [EduraSchoolDB]
COLLATE Arabic_100_CI_AS_SC_UTF8;
GO
ALTER DATABASE [EduraSchoolDB] SET ALLOW_SNAPSHOT_ISOLATION ON;
ALTER DATABASE [EduraSchoolDB] SET READ_COMMITTED_SNAPSHOT ON;
GO`
  },
  {
    path: 'database/Scripts/02_CreateTables.sql',
    name: '02_CreateTables.sql',
    language: 'sql',
    category: 'Database',
    description: 'إنشاء كافة الجداول (34+ جدولاً) مع الأعمدة الموحدة والقيود ومفاتيح الربط الأساسية',
    content: `-- راجع ملف database/Scripts/02_CreateTables.sql في المجلد لقراءة كافة الجداول:
-- Schools, AcademicYears, Semesters, Grades, Classes, Sections, Rooms, Staff, Teachers,
-- Students, Parents, Enrollments, Attendance, Exams, ExamResults, StudentFees, Payments,
-- Users, Roles, Permissions, RolePermissions, AuditLogs, BackupLogs, Notifications, Settings`
  },
  {
    path: 'database/Scripts/05_CreateStoredProcedures.sql',
    name: '05_CreateStoredProcedures.sql',
    language: 'sql',
    category: 'Database',
    description: 'الإجراءات المخزنة لتسجيل الدخول، لوحة التحكم، تسديد الدفعات، والنسخ الاحتياطي',
    content: `CREATE OR ALTER PROCEDURE [dbo].[usp_GetDashboardStatistics]
    @SchoolId INT,
    @TodayDate DATE = NULL
AS
BEGIN
    SET NOCOUNT ON;
    -- استعلام الإحصائيات الشاملة للمدرسة
    SELECT COUNT(*) AS TotalStudents FROM [dbo].[Students] WHERE [SchoolId] = @SchoolId AND [IsActive] = 1;
END;
GO`
  },
  {
    path: 'README.md',
    name: 'README.md',
    language: 'markdown',
    category: 'Config',
    description: 'دليل التثبيت والتشغيل الشامل وشرح معمارية الحل البرمجي لـ VB.NET و SQL Server',
    content: `# نظام إدارتي لإدارة المدارس (Edura School Management Enterprise)
حل مكتبي متكامل واحترافي مبني بتقنية VB.NET وقاعدة بيانات Microsoft SQL Server.
متوافق مع .NET 8.0 و SQL Server 2019/2022.`
  }
];
