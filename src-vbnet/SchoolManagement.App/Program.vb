Imports System
Imports System.Windows.Forms
Imports Microsoft.Extensions.DependencyInjection
Imports SchoolManagement.App.Forms
Imports SchoolManagement.App.Helpers
Imports SchoolManagement.Core.Interfaces
Imports SchoolManagement.Data.Repositories
Imports SchoolManagement.Data.Migrations

Public Module Program
    Public Property ServiceProvider As IServiceProvider

    <STAThread>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        
        ' Run Database Migrations synchronously on startup
        Try
            DatabaseMigrationService.MigrateUpAsync().GetAwaiter().GetResult()
        Catch ex As Exception
            MessageBox.Show($"تعذر إعداد قاعدة البيانات: {ex.Message}", "خطأ نظام", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Configure DI Services
        Dim services As New ServiceCollection()
        ConfigureServices(services)
        ServiceProvider = services.BuildServiceProvider()

        ' Initialize Krypton Theme
        ThemeManager.InitializeTheme()
        
        Application.Run(ServiceProvider.GetRequiredService(Of MainForm)())
    End Sub

    Private Sub ConfigureServices(services As IServiceCollection)
        ' Repositories
        services.AddScoped(Of IStudentRepository, StudentRepository)()
        ' services.AddScoped(Of ITeacherRepository, TeacherRepository)()
        ' services.AddScoped(Of IFinanceRepository, FinanceRepository)()
        
        ' Forms
        services.AddTransient(Of MainForm)()
        services.AddTransient(Of StudentsForm)()
        services.AddTransient(Of TeachersForm)()
        services.AddTransient(Of AttendanceForm)()
        services.AddTransient(Of ClassesForm)()
        services.AddTransient(Of SubjectsForm)()
        services.AddTransient(Of ExamsForm)()
        services.AddTransient(Of GradesForm)()
        services.AddTransient(Of FinanceForm)()
        services.AddTransient(Of ReportsForm)()
        services.AddTransient(Of SettingsForm)()
    End Sub
End Module
