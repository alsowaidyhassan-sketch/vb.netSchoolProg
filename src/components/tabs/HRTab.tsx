import React, { useState } from 'react';
import { Briefcase, UserPlus, Calculator, DollarSign, CheckCircle2 } from 'lucide-react';
import { StaffMember } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface HRTabProps {
  staff: StaffMember[];
  onAddStaff: (member: Omit<StaffMember, 'id'>) => void;
}

export const HRTab: React.FC<HRTabProps> = ({ staff, onAddStaff }) => {
  const [payrollGenerated, setPayrollGenerated] = useState(false);
  const [isOpen, setIsOpen] = useState(false);
  const [fullName, setFullName] = useState('');
  const [jobTitle, setJobTitle] = useState('');
  const [department, setDepartment] = useState('الشؤون التعليمية');
  const [phone, setPhone] = useState('05');
  const [basicSalary, setBasicSalary] = useState(10000);
  const [allowances, setAllowances] = useState(1500);

  const totalPayroll = staff.reduce((sum, s) => sum + s.netSalary, 0);

  const handleCreate = (e: React.FormEvent) => {
    e.preventDefault();
    if (!fullName.trim() || !jobTitle.trim()) return;

    const empNum = `EMP-${Math.floor(2000 + Math.random() * 8000)}`;
    onAddStaff({
      employeeNumber: empNum,
      fullName: fullName.trim(),
      jobTitle: jobTitle.trim(),
      department,
      phone,
      email: `${empNum.toLowerCase()}@alruwad.edu.sa`,
      hireDate: new Date().toISOString().split('T')[0],
      basicSalary: Number(basicSalary),
      allowances: Number(allowances),
      deductions: 0,
      netSalary: Number(basicSalary) + Number(allowances),
      status: 'Active'
    });

    setFullName('');
    setJobTitle('');
    setIsOpen(false);
  };

  const handleGeneratePayroll = () => {
    setPayrollGenerated(true);
    setTimeout(() => setPayrollGenerated(false), 3000);
  };

  const columns: Column<StaffMember>[] = [
    {
      key: 'employeeNumber',
      header: 'الرقم الوظيفي',
      width: '120px',
      sortable: true,
      render: (s) => (
        <span className="font-mono text-xs font-bold text-amber-400 bg-amber-950/60 px-2 py-0.5 rounded border border-amber-900/60">
          {s.employeeNumber}
        </span>
      )
    },
    {
      key: 'fullName',
      header: 'اسم الموظف',
      sortable: true,
      render: (s) => (
        <div>
          <div className="font-bold text-slate-100">{s.fullName}</div>
          <div className="text-[11px] text-slate-400">{s.jobTitle}</div>
        </div>
      )
    },
    {
      key: 'department',
      header: 'القسم / الإدارة',
      sortable: true,
      render: (s) => <span className="text-xs text-slate-300 font-medium">{s.department}</span>
    },
    {
      key: 'basicSalary',
      header: 'الأساسي',
      sortable: true,
      render: (s) => <span className="font-mono text-xs text-slate-200">{s.basicSalary.toLocaleString()} ر.س</span>
    },
    {
      key: 'allowances',
      header: 'البدلات',
      sortable: true,
      render: (s) => <span className="font-mono text-xs text-emerald-400">+{s.allowances.toLocaleString()} ر.س</span>
    },
    {
      key: 'deductions',
      header: 'الخصومات',
      sortable: true,
      render: (s) => (
        <span className="font-mono text-xs text-rose-400">
          {s.deductions > 0 ? `-${s.deductions.toLocaleString()} ر.س` : '0 ر.س'}
        </span>
      )
    },
    {
      key: 'netSalary',
      header: 'صافي الراتب المستحق',
      sortable: true,
      render: (s) => (
        <span className="font-mono text-xs font-bold text-blue-400 bg-blue-950 px-2 py-0.5 rounded border border-blue-800">
          {s.netSalary.toLocaleString()} ر.س
        </span>
      )
    }
  ];

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-amber-600/20 border border-amber-500/40 rounded-xl text-amber-400">
            <Briefcase className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">إدارة الموارد البشرية والرواتب (HR & Payroll)</h2>
            <p className="text-xs text-slate-400">ملفات الموظفين، مسيرات الرواتب الشهرية، والعقود</p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          <button
            onClick={handleGeneratePayroll}
            className="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-500 text-white text-xs font-bold rounded-xl shadow-lg transition-all cursor-pointer"
          >
            <Calculator className="w-4 h-4" />
            <span>إصدار مسير الرواتب للشهر الحالي</span>
          </button>

          <button
            onClick={() => setIsOpen(true)}
            className="flex items-center gap-2 px-4 py-2 bg-amber-600 hover:bg-amber-500 text-white text-xs font-bold rounded-xl shadow-lg transition-all cursor-pointer"
          >
            <UserPlus className="w-4 h-4" />
            <span>إضافة موظف جديد</span>
          </button>
        </div>
      </div>

      {/* Summary KPI */}
      <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-lg flex justify-between items-center">
        <div>
          <div className="text-xs text-slate-400 font-semibold">إجمالي فاتورة الرواتب الشهرية المستحقة</div>
          <div className="text-2xl font-black text-emerald-400 mt-1">{totalPayroll.toLocaleString()} ريال سعودي</div>
          <div className="text-[11px] text-slate-500 mt-0.5">عدد الموظفين: {staff.length} موظفاً</div>
        </div>
        <div className="text-left text-xs text-slate-400 font-mono">
          <div>حالة الدفع: معتمدة ومجدولة للمصرف</div>
          <div className="text-emerald-400 font-bold">جاهز للترحيل البنكي SARIE</div>
        </div>
      </div>

      <ModernDataGrid
        id="hr-grid"
        data={staff}
        columns={columns}
        searchPlaceholder="بحث باسم الموظف، المسمى الوظيفي، أو القسم..."
        searchFields={['fullName', 'jobTitle', 'department', 'employeeNumber']}
        exportFileName="Payroll_Export_Edura"
      />

      {payrollGenerated && (
        <div className="fixed bottom-12 left-1/2 -translate-x-1/2 bg-emerald-600 text-white px-5 py-2.5 rounded-xl shadow-2xl flex items-center gap-2 text-xs font-bold z-50">
          <CheckCircle2 className="w-4 h-4" />
          <span>تم اعتماد وتوليد مسير الرواتب الشهري بنجاح وتجهيز ملف الصرف البنكي!</span>
        </div>
      )}

      {/* Add Staff Modal */}
      {isOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4 text-xs">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2">
              إضافة موظف إداري أو أكاديمي جديد
            </h3>
            <form onSubmit={handleCreate} className="space-y-3">
              <div>
                <label className="block text-slate-300 font-semibold mb-1">اسم الموظف كاملاً *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: أ. حسام عادل الشريف"
                  value={fullName}
                  onChange={(e) => setFullName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                />
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">المسمى الوظيفي *</label>
                  <input
                    type="text"
                    required
                    placeholder="مثال: مسؤول العلاقات العامة"
                    value={jobTitle}
                    onChange={(e) => setJobTitle(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">القسم / الإدارة</label>
                  <select
                    value={department}
                    onChange={(e) => setDepartment(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                  >
                    <option value="الشؤون التعليمية">الشؤون التعليمية</option>
                    <option value="الشؤون المالية">الشؤون المالية</option>
                    <option value="شؤون الطلاب">شؤون الطلاب</option>
                    <option value="تقنية المعلومات IT">تقنية المعلومات IT</option>
                  </select>
                </div>
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">الراتب الأساسي</label>
                  <input
                    type="number"
                    value={basicSalary}
                    onChange={(e) => setBasicSalary(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">البدلات</label>
                  <input
                    type="number"
                    value={allowances}
                    onChange={(e) => setAllowances(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
              </div>

              <div className="flex items-center justify-end gap-2 pt-3 border-t border-slate-800">
                <button
                  type="button"
                  onClick={() => setIsOpen(false)}
                  className="px-4 py-2 bg-slate-800 text-slate-300 rounded-xl"
                >
                  إلغاء
                </button>
                <button
                  type="submit"
                  className="px-5 py-2 bg-amber-600 hover:bg-amber-500 text-white font-bold rounded-xl"
                >
                  حفظ الموظف
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
