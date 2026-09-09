sed -i '/Imports SchoolManagement.Core.Interfaces/a\Imports SchoolManagement.Data.Infrastructure' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
sed -i 's/Public Async Function GetFinancialSummaryAsync() As Task(Of Dictionary(Of String, Decimal))/Public Async Function GetFinancialSummaryAsync() As Task(Of IDictionary(Of String, Decimal))/g' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
sed -i 's/Return dict/Return CType(dict, IDictionary(Of String, Decimal))/g' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
