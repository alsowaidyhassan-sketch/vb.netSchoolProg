import React, { useState } from 'react';
import {
  X,
  User,
  GraduationCap,
  CalendarCheck,
  Receipt,
  HeartPulse,
  Printer,
  QrCode,
  FileText,
  Phone,
  MapPin,
  Mail,
  ShieldCheck
} from 'lucide-react';
import { Student, StudentGrade, AttendanceRecord, FeeInvoice } from '../../types';

interface StudentProfileModalProps {
  student: Student | null;
  onClose: () => void;
  grades: StudentGrade[];
  attendance: AttendanceRecord[];
  invoices: FeeInvoice[];
}

export const StudentProfileModal: React.FC<StudentProfileModalProps> = ({
  student,
  onClose,
  grades,
  attendance,
  invoices
}) => {
  const [activeTab, setActiveTab] = useState<'profile' | 'academic' | 'attendance' | 'finance' | 'medical'>('profile');

  if (!student) return null;

  const studentGrades = grades.filter((g) => g.studentId === student.id);
  const studentAttendance = attendance.filter((a) => a.studentId === student.id);
  const studentInvoices = invoices.filter((i) => i.studentId === student.id);

  const handlePrintCard = () => {
    window.print();
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/80 backdrop-blur-xs overflow-y-auto">
      <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-3xl w-full shadow-2xl overflow-hidden flex flex-col my-6 animate-in fade-in zoom-in-95 duration-150">
        {/* Header with Photo & Quick Info */}
        <div className="bg-gradient-to-r from-blue-950 via-slate-900 to-indigo-950 p-6 border-b border-slate-800 flex flex-wrap items-center justify-between gap-4">
          <div className="flex items-center gap-4">
            <div className="w-16 h-16 rounded-2xl bg-blue-600 flex items-center justify-center text-2xl font-black text-white shadow-lg border-2 border-blue-400">
              {student.firstName[0]}
            </div>
            <div>
              <div className="flex items-center gap-2">
                <h2 className="text-xl font-black text-white">{student.fullName}</h2>
                <span className="text-[10px] font-bold px-2 py-0.5 rounded-full bg-emerald-950 text-emerald-300 border border-emerald-800">
                  {student.status === 'Active' ? 'طالب منتظم ونشط' : student.status}
                </span>
              </div>
              <div className="flex items-center gap-3 text-xs text-slate-300 mt-1 font-mono">
                <span>الرقم الأكاديمي: {student.studentNumber}</span>
                <span>•</span>
                <span>الهوية: {student.nationalId}</span>
                <span>•</span>
                <span className="text-blue-300">{student.className} - {student.sectionName}</span>
              </div>
            </div>
          </div>

          <div className="flex items-center gap-2">
            <button
              onClick={handlePrintCard}
              className="flex items-center gap-1.5 px-3 py-1.5 bg-slate-800 hover:bg-slate-700 text-slate-200 text-xs font-semibold rounded-xl border border-slate-700 transition-colors cursor-pointer"
              title="طباعة بطاقة الطالب المدرسية"
            >
              <Printer className="w-4 h-4 text-blue-400" />
              <span>طباعة البطاقة</span>
            </button>
            <button
              onClick={onClose}
              className="p-1.5 rounded-xl hover:bg-slate-800 text-slate-400 hover:text-white transition-colors"
            >
              <X className="w-5 h-5" />
            </button>
          </div>
        </div>

        {/* Profile Tabs Navigation */}
        <div className="flex items-center gap-1 px-6 border-b border-slate-800 bg-slate-950/60 overflow-x-auto text-xs font-bold">
          <button
            onClick={() => setActiveTab('profile')}
            className={`flex items-center gap-2 py-3 px-4 border-b-2 transition-colors cursor-pointer ${
              activeTab === 'profile'
                ? 'border-blue-500 text-blue-400'
                : 'border-transparent text-slate-400 hover:text-slate-200'
            }`}
          >
            <User className="w-3.5 h-3.5" />
            <span>البيانات الأساسية</span>
          </button>

          <button
            onClick={() => setActiveTab('academic')}
            className={`flex items-center gap-2 py-3 px-4 border-b-2 transition-colors cursor-pointer ${
              activeTab === 'academic'
                ? 'border-blue-500 text-blue-400'
                : 'border-transparent text-slate-400 hover:text-slate-200'
            }`}
          >
            <GraduationCap className="w-3.5 h-3.5" />
            <span>كشف الدرجات والنتائج</span>
          </button>

          <button
            onClick={() => setActiveTab('attendance')}
            className={`flex items-center gap-2 py-3 px-4 border-b-2 transition-colors cursor-pointer ${
              activeTab === 'attendance'
                ? 'border-blue-500 text-blue-400'
                : 'border-transparent text-slate-400 hover:text-slate-200'
            }`}
          >
            <CalendarCheck className="w-3.5 h-3.5" />
            <span>سجل الحضور والغياب</span>
          </button>

          <button
            onClick={() => setActiveTab('finance')}
            className={`flex items-center gap-2 py-3 px-4 border-b-2 transition-colors cursor-pointer ${
              activeTab === 'finance'
                ? 'border-blue-500 text-blue-400'
                : 'border-transparent text-slate-400 hover:text-slate-200'
            }`}
          >
            <Receipt className="w-3.5 h-3.5" />
            <span>الرسوم والفواتير</span>
          </button>

          <button
            onClick={() => setActiveTab('medical')}
            className={`flex items-center gap-2 py-3 px-4 border-b-2 transition-colors cursor-pointer ${
              activeTab === 'medical'
                ? 'border-blue-500 text-blue-400'
                : 'border-transparent text-slate-400 hover:text-slate-200'
            }`}
          >
            <HeartPulse className="w-3.5 h-3.5" />
            <span>الملف الطبي</span>
          </button>
        </div>

        {/* Tab Content Body */}
        <div className="p-6 overflow-y-auto max-h-[450px] custom-scrollbar space-y-4">
          {/* TAB 1: Profile */}
          {activeTab === 'profile' && (
            <div className="space-y-4">
              <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                {/* Personal Info Box */}
                <div className="p-4 bg-slate-950/70 border border-slate-800 rounded-xl space-y-2.5 text-xs">
                  <h4 className="font-bold text-slate-200 border-b border-slate-800 pb-2">المعلومات المدنية والشخصية (جمهورية العراق)</h4>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">الاسم الخماسي واللقب:</span>
                    <span className="font-bold text-emerald-400">{student.fullName}</span>
                  </div>
                  {student.motherName && (
                    <div className="flex justify-between text-slate-300">
                      <span className="text-slate-500">اسم الأم الثلاثي:</span>
                      <span className="font-semibold text-sky-300">{student.motherName}</span>
                    </div>
                  )}
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">نوع الوثيقة الرسمية:</span>
                    <span className="font-medium text-amber-300">{student.identityDocumentType || 'البطاقة الوطنية الموحدة'}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">رقم الوثيقة / الهوية:</span>
                    <span className="font-mono font-bold text-white tracking-wider">{student.nationalId}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">الجنس:</span>
                    <span>{student.gender}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">الجنسية:</span>
                    <span>{student.nationality || 'عراقي'}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">تاريخ ومكان الولادة:</span>
                    <span className="font-mono">{student.dateOfBirth} ({student.birthPlace || 'العراق'})</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">فصيلة الدم:</span>
                    <span className="font-mono font-bold text-rose-400">{student.bloodType}</span>
                  </div>
                </div>

                {/* Contact & Guardian Info Box */}
                <div className="p-4 bg-slate-950/70 border border-slate-800 rounded-xl space-y-2.5 text-xs">
                  <h4 className="font-bold text-slate-200 border-b border-slate-800 pb-2">بيانات ولي الأمر والتواصل</h4>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">ولي الأمر:</span>
                    <span className="font-bold">{student.primaryParentName}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">هاتف ولي الأمر:</span>
                    <span className="font-mono text-blue-300">{student.primaryParentPhone}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">هاتف الطوارئ:</span>
                    <span className="font-mono">{student.emergencyContactPhone}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">البريد الأكاديمي:</span>
                    <span className="font-mono text-[11px] text-slate-400">{student.email}</span>
                  </div>
                  <div className="flex justify-between text-slate-300">
                    <span className="text-slate-500">العنوان السكني:</span>
                    <span>{student.address}</span>
                  </div>
                </div>
              </div>

              {/* Barcode & Security Card Preview */}
              <div className="p-4 bg-gradient-to-r from-slate-950 via-slate-900 to-slate-950 border border-slate-800 rounded-xl flex items-center justify-between">
                <div>
                  <div className="text-xs font-bold text-slate-200">الباركود الأكاديمي للطالب (Barcode ID)</div>
                  <div className="font-mono text-base font-bold text-blue-400 tracking-widest mt-0.5">
                    {student.barcode}
                  </div>
                  <div className="text-[10px] text-slate-500 mt-1">تاريخ القيد والتسجيل: {student.enrollmentDate}</div>
                </div>
                <div className="p-2.5 bg-white rounded-lg">
                  <QrCode className="w-10 h-10 text-slate-950" />
                </div>
              </div>
            </div>
          )}

          {/* TAB 2: Academic Grades */}
          {activeTab === 'academic' && (
            <div className="space-y-3">
              <h4 className="text-xs font-bold text-slate-300">سجل نتائج الاختبارات ورصد الدرجات</h4>
              {studentGrades.length > 0 ? (
                <div className="overflow-x-auto border border-slate-800 rounded-xl">
                  <table className="w-full text-right text-xs">
                    <thead className="bg-slate-950 text-slate-400 font-semibold">
                      <tr>
                        <th className="p-3">المادة</th>
                        <th className="p-3">نصفي (30)</th>
                        <th className="p-3">كويز (20)</th>
                        <th className="p-3">مهام (10)</th>
                        <th className="p-3">نهائي (40)</th>
                        <th className="p-3">المجموع (100)</th>
                        <th className="p-3">التقدير</th>
                        <th className="p-3">الحالة</th>
                      </tr>
                    </thead>
                    <tbody className="divide-y divide-slate-800 bg-slate-900/60">
                      {studentGrades.map((g) => (
                        <tr key={g.id}>
                          <td className="p-3 font-bold text-white">{g.subjectName}</td>
                          <td className="p-3 font-mono">{g.midtermScore}</td>
                          <td className="p-3 font-mono">{g.quizScore}</td>
                          <td className="p-3 font-mono">{g.homeworkScore}</td>
                          <td className="p-3 font-mono">{g.finalScore}</td>
                          <td className="p-3 font-mono font-bold text-blue-400">{g.totalScore}</td>
                          <td className="p-3 font-bold text-emerald-400">{g.gradeLetter}</td>
                          <td className="p-3">
                            <span className="px-2 py-0.5 rounded-full bg-emerald-950 text-emerald-300 text-[10px] font-bold border border-emerald-800">
                              ناجح
                            </span>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              ) : (
                <div className="p-8 text-center bg-slate-950/60 rounded-xl border border-slate-800 text-slate-500 text-xs">
                  لا توجد درجات مرصودة لهذا الطالب حتى الآن في الفصل الحالي.
                </div>
              )}
            </div>
          )}

          {/* TAB 3: Attendance */}
          {activeTab === 'attendance' && (
            <div className="space-y-3">
              <h4 className="text-xs font-bold text-slate-300">سجل الغياب والتأخر</h4>
              {studentAttendance.length > 0 ? (
                <div className="space-y-2">
                  {studentAttendance.map((att) => (
                    <div
                      key={att.id}
                      className="p-3 bg-slate-950/60 border border-slate-800 rounded-xl flex items-center justify-between text-xs"
                    >
                      <div className="flex items-center gap-3">
                        <span className="font-mono text-slate-400">{att.date}</span>
                        <span
                          className={`font-bold px-2 py-0.5 rounded text-[10px] ${
                            att.status === 'Present'
                              ? 'bg-emerald-950 text-emerald-300 border border-emerald-800'
                              : att.status === 'Late'
                              ? 'bg-amber-950 text-amber-300 border border-amber-800'
                              : 'bg-rose-950 text-rose-300 border border-rose-800'
                          }`}
                        >
                          {att.status === 'Present'
                            ? 'حاضر'
                            : att.status === 'Late'
                            ? `متأخر (${att.lateMinutes} دقيقة)`
                            : att.status === 'Excused'
                            ? 'غياب بعذر'
                            : 'غائب'}
                        </span>
                      </div>
                      <span className="text-slate-400 text-[11px]">{att.notes || '—'}</span>
                    </div>
                  ))}
                </div>
              ) : (
                <div className="p-8 text-center bg-slate-950/60 rounded-xl border border-slate-800 text-emerald-400 text-xs font-bold">
                  سجل الطالب نظيف بنسبة حضور 100% بدون أي غياب.
                </div>
              )}
            </div>
          )}

          {/* TAB 4: Finance */}
          {activeTab === 'finance' && (
            <div className="space-y-3">
              <h4 className="text-xs font-bold text-slate-300">الفواتير والأقساط الدراسية</h4>
              {studentInvoices.length > 0 ? (
                <div className="space-y-3">
                  {studentInvoices.map((inv) => (
                    <div
                      key={inv.id}
                      className="p-4 bg-slate-950/70 border border-slate-800 rounded-xl space-y-2 text-xs"
                    >
                      <div className="flex items-center justify-between">
                        <span className="font-mono font-bold text-blue-400">{inv.invoiceNumber}</span>
                        <span
                          className={`text-[10px] font-bold px-2 py-0.5 rounded-full ${
                            inv.status === 'Paid'
                              ? 'bg-emerald-950 text-emerald-300 border border-emerald-800'
                              : inv.status === 'Partial'
                              ? 'bg-amber-950 text-amber-300 border border-amber-800'
                              : 'bg-rose-950 text-rose-300 border border-rose-800'
                          }`}
                        >
                          {inv.status === 'Paid' ? 'مسدد بالكامل' : inv.status === 'Partial' ? 'مسدد جزئياً' : 'غير مسدد'}
                        </span>
                      </div>
                      <div className="text-slate-200 font-semibold">{inv.feeType}</div>
                      <div className="grid grid-cols-3 gap-2 pt-2 border-t border-slate-800 text-[11px]">
                        <div>
                          <span className="text-slate-500">القيمة:</span>{' '}
                          <span className="font-mono font-bold">{inv.finalAmount.toLocaleString()} د.ع</span>
                        </div>
                        <div>
                          <span className="text-slate-500">المدفوع:</span>{' '}
                          <span className="font-mono font-bold text-emerald-400">{inv.paidAmount.toLocaleString()} د.ع</span>
                        </div>
                        <div>
                          <span className="text-slate-500">المتبقي:</span>{' '}
                          <span className="font-mono font-bold text-rose-400">{inv.remainingAmount.toLocaleString()} د.ع</span>
                        </div>
                      </div>
                    </div>
                  ))}
                </div>
              ) : (
                <div className="p-8 text-center bg-slate-950/60 rounded-xl border border-slate-800 text-slate-500 text-xs">
                  لا توجد مطالبات أو فواتير مسجلة لهذا الطالب.
                </div>
              )}
            </div>
          )}

          {/* TAB 5: Medical */}
          {activeTab === 'medical' && (
            <div className="p-4 bg-slate-950/70 border border-slate-800 rounded-xl space-y-3 text-xs">
              <div className="flex items-center gap-2 text-rose-400 font-bold border-b border-slate-800 pb-2">
                <HeartPulse className="w-4 h-4" />
                <span>التقرير الطبي وسجل الحساسية</span>
              </div>
              <div className="flex items-center gap-3">
                <span className="text-slate-500">فصيلة الدم المعتمدة:</span>
                <span className="px-2.5 py-0.5 rounded-md bg-rose-950 text-rose-300 font-mono font-bold border border-rose-800">
                  {student.bloodType}
                </span>
              </div>
              <div>
                <span className="text-slate-500 block mb-1">الملاحظات الطبية والتوصيات:</span>
                <p className="bg-slate-900 p-3 rounded-lg border border-slate-800 text-slate-200 leading-relaxed">
                  {student.medicalNotes || 'لا توجد ملاحظات أو حساسية مسجلة.'}
                </p>
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};
