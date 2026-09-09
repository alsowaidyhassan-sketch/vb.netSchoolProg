import React from 'react';
import {
  Users,
  GraduationCap,
  CalendarCheck,
  UserX,
  Receipt,
  Wallet,
  School,
  FileCheck2,
  TrendingUp,
  UserPlus,
  CreditCard,
  CheckCircle2,
  DatabaseBackup,
  AlertCircle,
  Clock,
  ArrowUpRight
} from 'lucide-react';
import { ModuleKey, Student, Teacher, FeeInvoice, AuditLogItem } from '../../types';

interface DashboardTabProps {
  students?: Student[];
  teachers?: Teacher[];
  invoices?: FeeInvoice[];
  auditLogs?: AuditLogItem[];
  classes?: any[];
  attendance?: any[];
  grades?: any[];
  onOpenModule?: (key: ModuleKey | string) => void;
  onNavigate?: (key: ModuleKey | string) => void;
  onOpenNewStudentModal?: () => void;
  onOpenAddStudent?: () => void;
  onOpenNewReceiptModal?: () => void;
  onOpenAddReceipt?: () => void;
}

export const DashboardTab: React.FC<DashboardTabProps> = ({
  students = [],
  teachers = [],
  invoices = [],
  auditLogs = [],
  onOpenModule,
  onNavigate,
  onOpenNewStudentModal,
  onOpenAddStudent,
  onOpenNewReceiptModal,
  onOpenAddReceipt
}) => {
  const handleOpenModule = (key: any) => {
    if (onOpenModule) onOpenModule(key);
    else if (onNavigate) onNavigate(key);
  };

  const handleOpenStudentModal = () => {
    if (onOpenNewStudentModal) onOpenNewStudentModal();
    else if (onOpenAddStudent) onOpenAddStudent();
  };

  const handleOpenReceiptModal = () => {
    if (onOpenNewReceiptModal) onOpenNewReceiptModal();
    else if (onOpenAddReceipt) onOpenAddReceipt();
  };

  // Computed statistics
  const totalStudents = (students || []).length;
  const activeStudents = (students || []).filter((s) => s.status === 'Active').length;
  const totalTeachers = (teachers || []).length;

  const totalInvoiced = (invoices || []).reduce((sum, inv) => sum + (inv.finalAmount || 0), 0);
  const totalPaid = (invoices || []).reduce((sum, inv) => sum + (inv.paidAmount || 0), 0);
  const totalRemaining = (invoices || []).reduce((sum, inv) => sum + (inv.remainingAmount || 0), 0);
  const collectionRate = totalInvoiced > 0 ? Math.round((totalPaid / totalInvoiced) * 100) : 0;

  const kpis = [
    {
      title: 'إجمالي الطلاب المسجلين',
      value: `${totalStudents} طالب/ـة`,
      subtitle: `${activeStudents} طالب نشط مسدد`,
      icon: <GraduationCap className="w-5 h-5 text-blue-400" />,
      badge: '+12% هذا العام',
      badgeColor: 'text-emerald-400 bg-emerald-950/60 border-emerald-800',
      module: 'students' as ModuleKey
    },
    {
      title: 'الكادر الأكاديمي والتعليمي',
      value: `${totalTeachers} معلماً`,
      subtitle: 'نصاب الحصص مكتمل 100%',
      icon: <Users className="w-5 h-5 text-indigo-400" />,
      badge: 'مستقر',
      badgeColor: 'text-blue-400 bg-blue-950/60 border-blue-800',
      module: 'teachers' as ModuleKey
    },
    {
      title: 'نسبة الحضور اليوم',
      value: '96.4%',
      subtitle: 'تم تسجيل غياب 4 طلاب فقط',
      icon: <CalendarCheck className="w-5 h-5 text-emerald-400" />,
      badge: 'ممتاز',
      badgeColor: 'text-emerald-400 bg-emerald-950/60 border-emerald-800',
      module: 'attendance' as ModuleKey
    },
    {
      title: 'الغياب والتأخر اليوم',
      value: '4 حالات',
      subtitle: '2 بعذر، 1 بدون عذر، 1 متأخر',
      icon: <UserX className="w-5 h-5 text-amber-400" />,
      badge: 'تنبيه',
      badgeColor: 'text-amber-400 bg-amber-950/60 border-amber-800',
      module: 'attendance' as ModuleKey
    },
    {
      title: 'إجمالي الرسوم المحصلة',
      value: `${totalPaid.toLocaleString()} ر.س`,
      subtitle: `نسبة التحصيل ${collectionRate}%`,
      icon: <Receipt className="w-5 h-5 text-teal-400" />,
      badge: `تحصيل ${collectionRate}%`,
      badgeColor: 'text-teal-400 bg-teal-950/60 border-teal-800',
      module: 'finance' as ModuleKey
    },
    {
      title: 'المبالغ المتبقية والذمم',
      value: `${totalRemaining.toLocaleString()} ر.س`,
      subtitle: 'فواتير مستحقة الدفع',
      icon: <Wallet className="w-5 h-5 text-rose-400" />,
      badge: 'متابعة مطلوبة',
      badgeColor: 'text-rose-400 bg-rose-950/60 border-rose-800',
      module: 'finance' as ModuleKey
    },
    {
      title: 'الفصول والقاعات النشطة',
      value: '4 فصول',
      subtitle: 'معدل الإشغال 82%',
      icon: <School className="w-5 h-5 text-sky-400" />,
      badge: 'جاهزة',
      badgeColor: 'text-sky-400 bg-sky-950/60 border-sky-800',
      module: 'classes' as ModuleKey
    },
    {
      title: 'الاختبارات المجدولة',
      value: '3 اختبارات',
      subtitle: 'نهاية الفصل الدراسي',
      icon: <FileCheck2 className="w-5 h-5 text-purple-400" />,
      badge: 'قريباً',
      badgeColor: 'text-purple-400 bg-purple-950/60 border-purple-800',
      module: 'exams' as ModuleKey
    }
  ];

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Banner / Academic Context */}
      <div className="bg-gradient-to-r from-blue-950/70 via-slate-900 to-indigo-950/70 border border-blue-900/40 rounded-2xl p-5 shadow-lg flex flex-wrap items-center justify-between gap-4">
        <div>
          <div className="flex items-center gap-2 mb-1">
            <span className="w-2.5 h-2.5 rounded-full bg-emerald-400 animate-ping"></span>
            <span className="text-xs font-bold text-blue-300">
              العام الدراسي 1446 - 1447هـ | الفصل الدراسي الثاني
            </span>
          </div>
          <h2 className="text-2xl font-extrabold text-white tracking-tight">
            مرحباً بك في لوحة القيادة الذكية لمدارس الرواد النموذجية
          </h2>
          <p className="text-xs text-slate-300 mt-1">
            كافة العمليات متصلة بشكل حي ومباشر بقاعدة بيانات Microsoft SQL Server مع التحديث الفوري.
          </p>
        </div>

        {/* Quick Actions Shortcuts */}
        <div className="flex flex-wrap items-center gap-2">
          <button
            onClick={handleOpenStudentModal}
            className="flex items-center gap-2 px-3.5 py-2 bg-blue-600 hover:bg-blue-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-blue-600/30 transition-all cursor-pointer"
          >
            <UserPlus className="w-4 h-4" />
            <span>تسجيل طالب جديد</span>
          </button>

          <button
            onClick={handleOpenReceiptModal}
            className="flex items-center gap-2 px-3.5 py-2 bg-emerald-600 hover:bg-emerald-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-emerald-600/30 transition-all cursor-pointer"
          >
            <CreditCard className="w-4 h-4" />
            <span>سند قبض مالي</span>
          </button>

          <button
            onClick={() => handleOpenModule('attendance')}
            className="flex items-center gap-2 px-3.5 py-2 bg-slate-800 hover:bg-slate-700 text-slate-200 text-xs font-bold rounded-xl border border-slate-700 transition-all cursor-pointer"
          >
            <CalendarCheck className="w-4 h-4 text-emerald-400" />
            <span>رصد الحضور</span>
          </button>
        </div>
      </div>

      {/* 8 Metric KPI Cards Grid */}
      <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-4">
        {kpis.map((kpi, idx) => (
          <div
            key={idx}
            onClick={() => handleOpenModule(kpi.module)}
            className="bg-slate-900/90 hover:bg-slate-800/90 border border-slate-800 hover:border-slate-700 rounded-2xl p-4 transition-all duration-200 shadow-lg cursor-pointer group flex flex-col justify-between"
          >
            <div className="flex items-start justify-between mb-3">
              <div className="p-2.5 rounded-xl bg-slate-950/80 border border-slate-800/80 group-hover:border-blue-500/40 transition-colors">
                {kpi.icon}
              </div>
              <span
                className={`text-[10px] font-bold px-2 py-0.5 rounded-md border font-mono ${kpi.badgeColor}`}
              >
                {kpi.badge}
              </span>
            </div>

            <div>
              <div className="text-xs text-slate-400 font-medium">{kpi.title}</div>
              <div className="text-xl font-black text-white mt-1 group-hover:text-blue-300 transition-colors">
                {kpi.value}
              </div>
              <div className="text-[11px] text-slate-400 mt-0.5">{kpi.subtitle}</div>
            </div>

            <div className="mt-3 pt-2 border-t border-slate-800/60 flex items-center justify-between text-[11px] text-blue-400 font-semibold group-hover:translate-x-[-2px] transition-transform">
              <span>فتح الوحدة</span>
              <ArrowUpRight className="w-3.5 h-3.5" />
            </div>
          </div>
        ))}
      </div>

      {/* Analytical Visualizers & Real-time Feeds */}
      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* Left 2 Cols: Finance & Performance Progress */}
        <div className="lg:col-span-2 space-y-6">
          {/* Financial Overview Card */}
          <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-xl space-y-4">
            <div className="flex items-center justify-between border-b border-slate-800 pb-3">
              <div className="flex items-center gap-2">
                <Receipt className="w-5 h-5 text-emerald-400" />
                <h3 className="text-sm font-bold text-slate-100">
                  الموقف المالي للرسوم المدرسية (سنة 1446-1447هـ)
                </h3>
              </div>
              <button
                onClick={() => onOpenModule('finance')}
                className="text-xs text-blue-400 hover:text-blue-300 font-semibold flex items-center gap-1"
              >
                <span>شاشة المحاسبة</span>
                <ArrowUpRight className="w-3.5 h-3.5" />
              </button>
            </div>

            {/* Financial Progress Bar */}
            <div className="space-y-2">
              <div className="flex justify-between text-xs font-semibold">
                <span className="text-emerald-400">
                  المحصل: {totalPaid.toLocaleString()} ر.س ({collectionRate}%)
                </span>
                <span className="text-rose-400">
                  المتبقي: {totalRemaining.toLocaleString()} ر.س ({100 - collectionRate}%)
                </span>
              </div>
              <div className="w-full h-3.5 bg-slate-950 rounded-full overflow-hidden flex border border-slate-800">
                <div
                  style={{ width: `${collectionRate}%` }}
                  className="bg-gradient-to-r from-emerald-600 to-teal-400 h-full rounded-r-full transition-all duration-500"
                ></div>
                <div
                  style={{ width: `${100 - collectionRate}%` }}
                  className="bg-rose-950/70 h-full rounded-l-full"
                ></div>
              </div>
              <div className="text-[11px] text-slate-400 flex justify-between">
                <span>إجمالي المطالبات: {totalInvoiced.toLocaleString()} ريال سعودي</span>
                <span className="text-slate-400 font-mono">آخر تحديث: لحظي</span>
              </div>
            </div>

            {/* Fast Stats Blocks */}
            <div className="grid grid-cols-3 gap-3 pt-2">
              <div className="p-3 bg-slate-950/60 rounded-xl border border-slate-800/80 text-center">
                <div className="text-[11px] text-slate-400">سندات القبض المسجلة</div>
                <div className="text-base font-extrabold text-emerald-400 mt-0.5">3 سندات</div>
              </div>
              <div className="p-3 bg-slate-950/60 rounded-xl border border-slate-800/80 text-center">
                <div className="text-[11px] text-slate-400">فواتير مسددة بالكامل</div>
                <div className="text-base font-extrabold text-blue-400 mt-0.5">
                  {invoices.filter((i) => i.status === 'Paid').length} فواتير
                </div>
              </div>
              <div className="p-3 bg-slate-950/60 rounded-xl border border-slate-800/80 text-center">
                <div className="text-[11px] text-slate-400">فواتير قيد التحصيل</div>
                <div className="text-base font-extrabold text-amber-400 mt-0.5">
                  {invoices.filter((i) => i.status !== 'Paid').length} فواتير
                </div>
              </div>
            </div>
          </div>

          {/* Attendance Breakdown Card */}
          <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-xl space-y-4">
            <div className="flex items-center justify-between border-b border-slate-800 pb-3">
              <div className="flex items-center gap-2">
                <CalendarCheck className="w-5 h-5 text-blue-400" />
                <h3 className="text-sm font-bold text-slate-100">
                  سجل الحضور والغياب اليومي لجميع المراحل
                </h3>
              </div>
              <span className="text-xs px-2.5 py-0.5 rounded-full bg-blue-950 border border-blue-800 text-blue-300 font-mono">
                اليوم: الثلاثاء
              </span>
            </div>

            <div className="grid grid-cols-2 sm:grid-cols-4 gap-3 text-center">
              <div className="p-3 rounded-xl bg-emerald-950/40 border border-emerald-800/60">
                <div className="text-xs text-emerald-300 font-medium">حاضر (Present)</div>
                <div className="text-2xl font-black text-emerald-400 mt-1">96.4%</div>
                <div className="text-[10px] text-emerald-400 mt-0.5">حضور نظامي</div>
              </div>

              <div className="p-3 rounded-xl bg-amber-950/40 border border-amber-800/60">
                <div className="text-xs text-amber-300 font-medium">تأخر صباحي (Late)</div>
                <div className="text-2xl font-black text-amber-400 mt-1">1.8%</div>
                <div className="text-[10px] text-amber-400 mt-0.5">أقل من 15 دقيقة</div>
              </div>

              <div className="p-3 rounded-xl bg-sky-950/40 border border-sky-800/60">
                <div className="text-xs text-sky-300 font-medium">غياب بعذر (Excused)</div>
                <div className="text-2xl font-black text-sky-400 mt-1">1.2%</div>
                <div className="text-[10px] text-sky-400 mt-0.5">تقارير طبية معتمدة</div>
              </div>

              <div className="p-3 rounded-xl bg-rose-950/40 border border-rose-800/60">
                <div className="text-xs text-rose-300 font-medium">غياب بدون عذر</div>
                <div className="text-2xl font-black text-rose-400 mt-1">0.6%</div>
                <div className="text-[10px] text-rose-400 mt-0.5">تم إشعار ولي الأمر SMS</div>
              </div>
            </div>
          </div>
        </div>

        {/* Right 1 Col: Live Audit Log Stream */}
        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-xl flex flex-col">
          <div className="flex items-center justify-between border-b border-slate-800 pb-3 mb-3">
            <div className="flex items-center gap-2">
              <Clock className="w-4 h-4 text-blue-400" />
              <h3 className="text-sm font-bold text-slate-100">سجل العمليات المباشر (Audit)</h3>
            </div>
            <button
              onClick={() => handleOpenModule('audit')}
              className="text-xs text-blue-400 hover:text-blue-300 font-semibold"
            >
              عرض السجل الكامل
            </button>
          </div>

          <div className="flex-1 space-y-3 overflow-y-auto max-h-[380px] custom-scrollbar pr-1">
            {(auditLogs || []).slice(0, 6).map((log) => (
              <div
                key={log.id}
                className="p-3 rounded-xl bg-slate-950/70 border border-slate-800 text-xs space-y-1 hover:border-slate-700 transition-colors"
              >
                <div className="flex items-center justify-between">
                  <span
                    className={`font-mono font-bold text-[10px] px-1.5 py-0.5 rounded ${
                      log.action === 'INSERT'
                        ? 'bg-emerald-950 text-emerald-300 border border-emerald-800'
                        : log.action === 'UPDATE'
                        ? 'bg-amber-950 text-amber-300 border border-amber-800'
                        : log.action === 'BACKUP'
                        ? 'bg-blue-950 text-blue-300 border border-blue-800'
                        : 'bg-purple-950 text-purple-300 border border-purple-800'
                    }`}
                  >
                    {log.action}
                  </span>
                  <span className="text-[10px] text-slate-400 font-mono">{log.timestamp}</span>
                </div>

                <div className="text-slate-200 font-semibold">{log.details}</div>

                <div className="flex items-center justify-between text-[10px] text-slate-400 pt-1">
                  <span>المستخدم: {log.username}</span>
                  <span className="font-mono">الجدول: {log.tableName}</span>
                </div>
              </div>
            ))}
          </div>

          <div className="mt-4 pt-3 border-t border-slate-800 flex items-center justify-between text-[11px] text-slate-400">
            <span>التسجيل التلقائي عبر SQL Triggers:</span>
            <span className="text-emerald-400 font-bold">نشط وفعال</span>
          </div>
        </div>
      </div>
    </div>
  );
};
