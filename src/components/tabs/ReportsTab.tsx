import React, { useState } from 'react';
import { BarChart3, Printer, Download, FileText, CheckCircle2 } from 'lucide-react';
import { Student, Teacher, FeeInvoice, StudentGrade } from '../../types';

interface ReportsTabProps {
  students: Student[];
  teachers: Teacher[];
  invoices: FeeInvoice[];
  grades: StudentGrade[];
}

export const ReportsTab: React.FC<ReportsTabProps> = ({
  students,
  teachers,
  invoices,
  grades
}) => {
  const [selectedReport, setSelectedReport] = useState<
    'students' | 'attendance' | 'grades' | 'finance'
  >('students');

  const printReport = () => {
    window.print();
  };

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-blue-600/20 border border-blue-500/40 rounded-xl text-blue-400">
            <BarChart3 className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">مركز التقارير والإحصاءات المتقدمة (Reports Center)</h2>
            <p className="text-xs text-slate-400">طباعة الكشوف الرسمية، التقارير الإحصائية، ونماذج الوزارة</p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          <button
            onClick={printReport}
            className="flex items-center gap-2 px-4 py-2 bg-blue-600 hover:bg-blue-500 text-white text-xs font-bold rounded-xl shadow-lg transition-all cursor-pointer"
          >
            <Printer className="w-4 h-4" />
            <span>طباعة التقرير (Print A4)</span>
          </button>
        </div>
      </div>

      {/* Report Types Selector */}
      <div className="grid grid-cols-2 sm:grid-cols-4 gap-3">
        {[
          { id: 'students', label: 'كشف الطلاب المسجلين', count: `${students.length} طالب` },
          { id: 'attendance', label: 'تقرير الحضور والغياب', count: 'نسبة 96.4%' },
          { id: 'grades', label: 'كشف الدرجات والنتائج', count: `${grades.length} رصد` },
          { id: 'finance', label: 'تقرير الذمم والرسوم', count: `${invoices.length} فاتورة` }
        ].map((rep) => (
          <button
            key={rep.id}
            onClick={() => setSelectedReport(rep.id as any)}
            className={`p-4 rounded-xl text-right transition-all border cursor-pointer ${
              selectedReport === rep.id
                ? 'bg-blue-900/40 border-blue-500 text-white shadow-lg'
                : 'bg-slate-900 border-slate-800 text-slate-400 hover:bg-slate-850 hover:text-slate-200'
            }`}
          >
            <div className="text-xs font-bold">{rep.label}</div>
            <div className="text-sm font-extrabold text-blue-300 mt-1 font-mono">{rep.count}</div>
          </button>
        ))}
      </div>

      {/* Printable Report Document Card (A4 White Preview) */}
      <div className="bg-white text-slate-900 rounded-2xl p-8 shadow-2xl border border-slate-300 max-w-4xl mx-auto space-y-6">
        {/* Report Official Header */}
        <div className="border-b-2 border-slate-900 pb-4 flex justify-between items-start">
          <div className="text-right space-y-1">
            <h1 className="text-base font-black">المملكة العربية السعودية - وزارة التعليم</h1>
            <h2 className="text-sm font-bold text-blue-900">مدارس الرواد النموذجية الأهلية</h2>
            <div className="text-xs text-slate-600">العام الدراسي: 1446-1447هـ | الفصل الدراسي الثاني</div>
          </div>
          <div className="text-left font-mono text-xs space-y-1 text-slate-600">
            <div>تاريخ التصدير: {new Date().toLocaleDateString('ar-SA')}</div>
            <div>المصدر: نظام إدارتي Enterprise</div>
            <div>المشرف: admin</div>
          </div>
        </div>

        {/* Report Content based on Selection */}
        {selectedReport === 'students' && (
          <div className="space-y-4">
            <h3 className="text-center font-bold text-base text-slate-900">كشف الطلاب المقيدين في المدرسة</h3>
            <table className="w-full text-right text-xs border-collapse border border-slate-300">
              <thead className="bg-slate-100">
                <tr>
                  <th className="border border-slate-300 p-2 text-center">#</th>
                  <th className="border border-slate-300 p-2">الرقم الأكاديمي</th>
                  <th className="border border-slate-300 p-2">اسم الطالب</th>
                  <th className="border border-slate-300 p-2">الصف الدراسي</th>
                  <th className="border border-slate-300 p-2">الهوية الوطنية</th>
                  <th className="border border-slate-300 p-2">هاتف ولي الأمر</th>
                  <th className="border border-slate-300 p-2">الحالة</th>
                </tr>
              </thead>
              <tbody>
                {students.map((s, idx) => (
                  <tr key={s.id} className={idx % 2 === 0 ? 'bg-white' : 'bg-slate-50'}>
                    <td className="border border-slate-300 p-2 text-center font-mono">{idx + 1}</td>
                    <td className="border border-slate-300 p-2 font-mono font-bold">{s.studentNumber}</td>
                    <td className="border border-slate-300 p-2 font-bold">{s.fullName}</td>
                    <td className="border border-slate-300 p-2">{s.className}</td>
                    <td className="border border-slate-300 p-2 font-mono">{s.nationalId}</td>
                    <td className="border border-slate-300 p-2 font-mono">{s.primaryParentPhone}</td>
                    <td className="border border-slate-300 p-2 font-bold text-emerald-700">منتظم</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}

        {selectedReport === 'finance' && (
          <div className="space-y-4">
            <h3 className="text-center font-bold text-base text-slate-900">كشف المطالبات والرسوم المدرسية المتأخرة</h3>
            <table className="w-full text-right text-xs border-collapse border border-slate-300">
              <thead className="bg-slate-100">
                <tr>
                  <th className="border border-slate-300 p-2 text-center">#</th>
                  <th className="border border-slate-300 p-2">رقم الفاتورة</th>
                  <th className="border border-slate-300 p-2">اسم الطالب</th>
                  <th className="border border-slate-300 p-2">المبلغ الأصلي</th>
                  <th className="border border-slate-300 p-2">المدفوع</th>
                  <th className="border border-slate-300 p-2">المتبقي (الذمة)</th>
                  <th className="border border-slate-300 p-2">الحالة</th>
                </tr>
              </thead>
              <tbody>
                {invoices.map((inv, idx) => (
                  <tr key={inv.id} className={idx % 2 === 0 ? 'bg-white' : 'bg-slate-50'}>
                    <td className="border border-slate-300 p-2 text-center font-mono">{idx + 1}</td>
                    <td className="border border-slate-300 p-2 font-mono">{inv.invoiceNumber}</td>
                    <td className="border border-slate-300 p-2 font-bold">{inv.studentName}</td>
                    <td className="border border-slate-300 p-2 font-mono">{inv.finalAmount.toLocaleString()} ر.س</td>
                    <td className="border border-slate-300 p-2 font-mono text-emerald-700">{inv.paidAmount.toLocaleString()} ر.س</td>
                    <td className="border border-slate-300 p-2 font-mono font-bold text-rose-700">
                      {inv.remainingAmount.toLocaleString()} ر.س
                    </td>
                    <td className="border border-slate-300 p-2 font-semibold">
                      {inv.status === 'Paid' ? 'مسدد' : inv.status === 'Partial' ? 'جزئي' : 'غير مسدد'}
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}

        {selectedReport === 'grades' && (
          <div className="space-y-4">
            <h3 className="text-center font-bold text-base text-slate-900">كشف نتائج الطلاب المعتمد</h3>
            <table className="w-full text-right text-xs border-collapse border border-slate-300">
              <thead className="bg-slate-100">
                <tr>
                  <th className="border border-slate-300 p-2 text-center">#</th>
                  <th className="border border-slate-300 p-2">اسم الطالب</th>
                  <th className="border border-slate-300 p-2">المادة</th>
                  <th className="border border-slate-300 p-2">المجموع</th>
                  <th className="border border-slate-300 p-2">التقدير</th>
                  <th className="border border-slate-300 p-2">الحالة</th>
                </tr>
              </thead>
              <tbody>
                {grades.map((g, idx) => (
                  <tr key={g.id} className={idx % 2 === 0 ? 'bg-white' : 'bg-slate-50'}>
                    <td className="border border-slate-300 p-2 text-center font-mono">{idx + 1}</td>
                    <td className="border border-slate-300 p-2 font-bold">{g.studentName}</td>
                    <td className="border border-slate-300 p-2">{g.subjectName}</td>
                    <td className="border border-slate-300 p-2 font-mono font-bold">{g.totalScore} / 100</td>
                    <td className="border border-slate-300 p-2 font-bold text-blue-900">{g.gradeLetter}</td>
                    <td className="border border-slate-300 p-2 font-bold text-emerald-700">ناجح</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}

        {selectedReport === 'attendance' && (
          <div className="space-y-4">
            <h3 className="text-center font-bold text-base text-slate-900">ملخص الحضور والانتظام المدرسي</h3>
            <div className="p-4 bg-slate-50 rounded-xl border border-slate-200 text-xs space-y-2">
              <div className="flex justify-between">
                <span>إجمالي أيام الدراسة المحتسبة:</span>
                <span className="font-bold">64 يوماً</span>
              </div>
              <div className="flex justify-between">
                <span>متوسط نسبة الحضور العام للمدرسة:</span>
                <span className="font-bold text-emerald-700 font-mono text-sm">96.4%</span>
              </div>
              <div className="flex justify-between">
                <span>نسبة الغياب بعذر مقبول:</span>
                <span className="font-bold text-blue-700 font-mono">1.8%</span>
              </div>
              <div className="flex justify-between">
                <span>نسبة الغياب غير المبرر:</span>
                <span className="font-bold text-rose-700 font-mono">0.6%</span>
              </div>
            </div>
          </div>
        )}

        {/* Signatures Footer */}
        <div className="pt-8 border-t border-slate-300 grid grid-cols-3 gap-4 text-center text-xs">
          <div>
            <div className="font-bold">المرشد الأكاديمي</div>
            <div className="text-slate-400 mt-6">...................................</div>
          </div>
          <div>
            <div className="font-bold">رئيس الكنترول / المحاسب</div>
            <div className="text-slate-400 mt-6">...................................</div>
          </div>
          <div>
            <div className="font-bold">مدير المدرسة والختم الرسمي</div>
            <div className="text-slate-400 mt-6">...................................</div>
          </div>
        </div>
      </div>
    </div>
  );
};
