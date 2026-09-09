sed -i 's/inv.Amount/inv.FinalAmount/g' src-vbnet/SchoolManagement.App/Forms/FinanceForm.vb
sed -i 's/inv.Paid/inv.PaidAmount/g' src-vbnet/SchoolManagement.App/Forms/FinanceForm.vb
sed -i 's/inv.Remaining/inv.RemainingAmount/g' src-vbnet/SchoolManagement.App/Forms/FinanceForm.vb

sed -i 's/\[Amount\]/\[FinalAmount\]/g' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
sed -i 's/\[Paid\]/\[PaidAmount\]/g' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
sed -i 's/SUM(Amount)/SUM(FinalAmount)/g' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
sed -i 's/SUM(Paid)/SUM(PaidAmount)/g' src-vbnet/SchoolManagement.Data/FinanceRepository.vb
