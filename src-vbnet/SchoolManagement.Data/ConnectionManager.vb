Imports System
Imports System.Data
Imports Microsoft.Data.SqlClient
Imports Microsoft.Extensions.Configuration

Namespace Infrastructure
    Public Class ConnectionManager
        Private Shared ReadOnly LazyConfig As Lazy(Of IConfiguration) = New Lazy(Of IConfiguration)(AddressOf BuildConfiguration)

        Private Shared Function BuildConfiguration() As IConfiguration
            Dim builder = New ConfigurationBuilder().
                SetBasePath(AppDomain.CurrentDomain.BaseDirectory).
                AddJsonFile("appsettings.json", optional:=True, reloadOnChange:=True)
            Return builder.Build()
        End Function

        Public Shared Function GetConnectionString() As String
            Dim connStr = LazyConfig.Value.GetConnectionString("DefaultConnection")
            If String.IsNullOrWhiteSpace(connStr) Then
                ' Default fallback connection for local development
                Return "Server=localhost;Database=EduraSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
            End If
            Return connStr
        End Function

        Public Shared Function CreateConnection() As IDbConnection
            Dim conn = New SqlConnection(GetConnectionString())
            Return conn
        End Function
    End Class
End Namespace
