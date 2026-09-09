import React, { useState, useEffect } from 'react';
import {
  LayoutDashboard,
  GraduationCap,
  Users,
  School,
  BookOpen,
  CalendarCheck,
  Award,
  Receipt,
  Briefcase,
  BarChart3,
  History,
  Database,
  Shield,
  Settings,
  Code,
  UserPlus,
  CreditCard,
  Bell,
  Search,
  CheckCircle2,
  HardDrive,
  RefreshCw,
  Minus,
  Square,
  X
} from 'lucide-react';

import {
  Student,
  Teacher,
  ClassSection,
  Subject,
  AttendanceRecord,
  ExamRecord,
  StudentGrade,
  FeeInvoice,
  PaymentReceipt,
  StaffMember,
  AuditLogRecord,
  BackupRecord,
  SystemUser,
  SchoolSettings
} from './types';

import {
  initialStudents,
  initialTeachers,
  initialClasses,
  initialSubjects,
  initialAttendance,
  initialExams,
  initialGrades,
  initialInvoices,
  initialReceipts,
  initialStaff,
  initialAuditLogs,
  initialBackups,
  initialUsers,
  initialSettings
} from './data/mockData';

// Tabs Components
import { DashboardTab } from './components/tabs/DashboardTab';
import { StudentsTab } from './components/tabs/StudentsTab';
import { TeachersTab } from './components/tabs/TeachersTab';
import { ClassesTab } from './components/tabs/ClassesTab';
import { SubjectsTab } from './components/tabs/SubjectsTab';
import { AttendanceTab } from './components/tabs/AttendanceTab';
import { ExamsTab } from './components/tabs/ExamsTab';
import { FinanceTab } from './components/tabs/FinanceTab';
import { HRTab } from './components/tabs/HRTab';
import { ReportsTab } from './components/tabs/ReportsTab';
import { AuditTab } from './components/tabs/AuditTab';
import { BackupTab } from './components/tabs/BackupTab';
import { SecurityTab } from './components/tabs/SecurityTab';
import { SettingsTab } from './components/tabs/SettingsTab';
import { ArchitectureTab } from './components/tabs/ArchitectureTab';

// Modals
import { AddStudentModal } from './components/common/AddStudentModal';
import { AddReceiptModal } from './components/common/AddReceiptModal';

type TabKey =
  | 'dashboard'
  | 'students'
  | 'teachers'
  | 'classes'
  | 'subjects'
  | 'attendance'
  | 'exams'
  | 'finance'
  | 'hr'
  | 'reports'
  | 'audit'
  | 'backup'
  | 'security'
  | 'settings'
  | 'architecture';

export default function App() {
  const [activeTab, setActiveTab] = useState<TabKey>('dashboard');

  // Core Data States
  const [students, setStudents] = useState<Student[]>(initialStudents);
  const [teachers, setTeachers] = useState<Teacher[]>(initialTeachers);
  const [classes, setClasses] = useState<ClassSection[]>(initialClasses);
  const [subjects, setSubjects] = useState<Subject[]>(initialSubjects);
  const [attendance, setAttendance] = useState<AttendanceRecord[]>(initialAttendance);
  const [exams, setExams] = useState<ExamRecord[]>(initialExams);
  const [grades, setGrades] = useState<StudentGrade[]>(initialGrades);
  const [invoices, setInvoices] = useState<FeeInvoice[]>(initialInvoices);
  const [payments, setPayments] = useState<PaymentReceipt[]>(initialReceipts);
  const [staff, setStaff] = useState<StaffMember[]>(initialStaff);
  const [auditLogs, setAuditLogs] = useState<AuditLogRecord[]>(initialAuditLogs);
  const [backups, setBackups] = useState<BackupRecord[]>(initialBackups);
  const [systemUsers, setSystemUsers] = useState<SystemUser[]>(initialUsers);
  const [settings, setSettings] = useState<SchoolSettings>(initialSettings);

  // Modals state
  const [isAddStudentOpen, setIsAddStudentOpen] = useState(false);
  const [isAddReceiptOpen, setIsAddReceiptOpen] = useState(false);

  // Time ticker
  const [currentTime, setCurrentTime] = useState<string>(
    new Date().toLocaleTimeString('ar-SA', { hour: '2-digit', minute: '2-digit', second: '2-digit' })
  );

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(
        new Date().toLocaleTimeString('ar-SA', { hour: '2-digit', minute: '2-digit', second: '2-digit' })
      );
    }, 1000);
    return () => clearInterval(timer);
  }, []);

  // Log Audit Action Helper
  const logAudit = (action: 'INSERT' | 'UPDATE' | 'DELETE' | 'BACKUP', table: string, id: number, details: string) => {
    const newLog: AuditLogRecord = {
      id: Date.now(),
      timestamp: new Date().toISOString().replace('T', ' ').substring(0, 19),
      action,
      tableName: table,
      recordId: id,
      username: 'admin',
      details,
      ipAddress: '127.0.0.1 (Local Client)'
    };
    setAuditLogs((prev) => [newLog, ...prev]);
  };

  // Actions
  const handleAddStudent = (newStudentData: Omit<Student, 'id'>) => {
    const newId = students.length > 0 ? Math.max(...students.map((s) => s.id)) + 1 : 1;
    const fullStudent: Student = { ...newStudentData, id: newId };
    setStudents((prev) => [fullStudent, ...prev]);

    // Also auto-generate tuition invoice for the newly registered student
    const newInvoice: FeeInvoice = {
      id: Date.now(),
      invoiceNumber: `INV-2025-${Math.floor(1000 + Math.random() * 9000)}`,
      studentId: newId,
      studentName: fullStudent.fullName,
      className: fullStudent.className,
      feeType: 'الرسوم الدراسية السنوية الأساسية',
      originalAmount: 18000,
      discount: 0,
      taxAmount: 2700,
      finalAmount: 20700,
      paidAmount: 0,
      remainingAmount: 20700,
      dueDate: '2025-09-01',
      status: 'Unpaid'
    };
    setInvoices((prev) => [newInvoice, ...prev]);

    logAudit('INSERT', 'Students', newId, `تسجيل طالب جديد: ${fullStudent.fullName} (${fullStudent.studentNumber})`);
  };

  const handleDeleteStudent = (studentId: number) => {
    const student = students.find((s) => s.id === studentId);
    setStudents((prev) => prev.filter((s) => s.id !== studentId));
    if (student) {
      logAudit('DELETE', 'Students', studentId, `تعطيل/حذف قيد الطالب: ${student.fullName}`);
    }
  };

  const handleAddTeacher = (newTeacherData: Omit<Teacher, 'id'>) => {
    const newId = teachers.length > 0 ? Math.max(...teachers.map((t) => t.id)) + 1 : 1;
    const fullTeacher: Teacher = { ...newTeacherData, id: newId };
    setTeachers((prev) => [fullTeacher, ...prev]);
    logAudit('INSERT', 'Teachers', newId, `إضافة معلم جديد: ${fullTeacher.fullName} (${fullTeacher.employeeNumber})`);
  };

  const handleAddClass = (newClassData: Omit<ClassSection, 'id'>) => {
    const newId = classes.length > 0 ? Math.max(...classes.map((c) => c.id)) + 1 : 1;
    const fullClass: ClassSection = { ...newClassData, id: newId };
    setClasses((prev) => [...prev, fullClass]);
    logAudit('INSERT', 'Classes', newId, `إضافة قاعة/شعبة دراسية: ${fullClass.className} (${fullClass.roomNumber})`);
  };

  const handleAddSubject = (newSubjectData: Omit<Subject, 'id'>) => {
    const newId = subjects.length > 0 ? Math.max(...subjects.map((s) => s.id)) + 1 : 1;
    const fullSubject: Subject = { ...newSubjectData, id: newId };
    setSubjects((prev) => [...prev, fullSubject]);
    logAudit('INSERT', 'Subjects', newId, `إضافة مادة دراسية: ${fullSubject.name} (${fullSubject.code})`);
  };

  const handleSaveAttendance = (records: AttendanceRecord[]) => {
    // Merge new records with existing attendance
    setAttendance((prev) => {
      const updated = [...prev];
      records.forEach((rec) => {
        const idx = updated.findIndex((a) => a.studentId === rec.studentId && a.date === rec.date);
        if (idx !== -1) {
          updated[idx] = rec;
        } else {
          updated.push(rec);
        }
      });
      return updated;
    });

    logAudit('INSERT', 'Attendance', records.length, `رصد كشف حضور يومي لعدد ${records.length} طالب`);
  };

  const handleUpdateGrade = (updatedGrade: StudentGrade) => {
    setGrades((prev) => prev.map((g) => (g.id === updatedGrade.id ? updatedGrade : g)));
    logAudit('UPDATE', 'Grades', updatedGrade.id, `تعديل درجات الطالب: ${updatedGrade.studentName} لمادة ${updatedGrade.subjectName}`);
  };

  const handleAddPaymentReceipt = (receiptData: Omit<PaymentReceipt, 'id'>) => {
    const newId = payments.length > 0 ? Math.max(...payments.map((p) => p.id)) + 1 : 1;
    const fullReceipt: PaymentReceipt = { ...receiptData, id: newId };
    setPayments((prev) => [fullReceipt, ...prev]);

    // Update corresponding invoice
    setInvoices((prev) =>
      prev.map((inv) => {
        if (inv.invoiceNumber === fullReceipt.invoiceNumber) {
          const newPaid = inv.paidAmount + fullReceipt.amount;
          const newRemaining = Math.max(0, inv.finalAmount - newPaid);
          const newStatus = newRemaining === 0 ? 'Paid' : 'Partial';
          return {
            ...inv,
            paidAmount: newPaid,
            remainingAmount: newRemaining,
            status: newStatus
          };
        }
        return inv;
      })
    );

    logAudit('INSERT', 'Payments', newId, `إصدار سند قبض رقم ${fullReceipt.receiptNumber} بمبلغ ${fullReceipt.amount} ر.س`);
  };

  const handleAddStaff = (newStaffData: Omit<StaffMember, 'id'>) => {
    const newId = staff.length > 0 ? Math.max(...staff.map((s) => s.id)) + 1 : 1;
    const fullStaff: StaffMember = { ...newStaffData, id: newId };
    setStaff((prev) => [...prev, fullStaff]);
    logAudit('INSERT', 'Staff', newId, `إضافة موظف جديد: ${fullStaff.fullName} (${fullStaff.jobTitle})`);
  };

  const handleTriggerBackup = () => {
    const newBackup: BackupRecord = {
      id: Date.now(),
      fileName: `SchoolDB_Full_${new Date().toISOString().replace(/[-:T]/g, '_').substring(0, 15)}.bak`,
      filePath: 'D:\\SQL_Backups\\SchoolDB\\',
      fileSize: '48.2 MB',
      timestamp: new Date().toISOString().replace('T', ' ').substring(0, 19),
      status: 'Success',
      createdBy: 'admin'
    };
    setBackups((prev) => [newBackup, ...prev]);
    logAudit('BACKUP', 'Database', 1, `إنشاء نسخة احتياطية كاملة: ${newBackup.fileName}`);
  };

  const handleAddUser = (newUserData: Omit<SystemUser, 'id'>) => {
    const newId = systemUsers.length > 0 ? Math.max(...systemUsers.map((u) => u.id)) + 1 : 1;
    const fullUser: SystemUser = { ...newUserData, id: newId };
    setSystemUsers((prev) => [...prev, fullUser]);
    logAudit('INSERT', 'Users', newId, `إنشاء مستخدم جديد: ${fullUser.username} بصلاحية ${fullUser.role}`);
  };

  const handleToggleUserStatus = (userId: number) => {
    setSystemUsers((prev) =>
      prev.map((u) => (u.id === userId ? { ...u, isActive: !u.isActive } : u))
    );
    logAudit('UPDATE', 'Users', userId, `تغيير حالة حساب المستخدم ID: ${userId}`);
  };

  const classesList = Array.from(new Set(classes.map((c) => c.className)));

  // Navigation Tabs Definition
  const tabs = [
    { key: 'dashboard' as TabKey, label: 'لوحة القيادة', icon: LayoutDashboard },
    { key: 'students' as TabKey, label: 'شؤون الطلاب', icon: GraduationCap, badge: students.length },
    { key: 'teachers' as TabKey, label: 'المعلمون', icon: Users, badge: teachers.length },
    { key: 'classes' as TabKey, label: 'الفصول والقاعات', icon: School },
    { key: 'subjects' as TabKey, label: 'المناهج والمواد', icon: BookOpen },
    { key: 'attendance' as TabKey, label: 'الحضور والغياب', icon: CalendarCheck },
    { key: 'exams' as TabKey, label: 'الكنترول والدرجات', icon: Award },
    { key: 'finance' as TabKey, label: 'المالية والرسوم', icon: Receipt },
    { key: 'hr' as TabKey, label: 'الموارد البشرية', icon: Briefcase },
    { key: 'reports' as TabKey, label: 'التقارير الرسمية', icon: BarChart3 },
    { key: 'audit' as TabKey, label: 'التدقيق الأمني', icon: History },
    { key: 'backup' as TabKey, label: 'النسخ الاحتياطي', icon: Database },
    { key: 'security' as TabKey, label: 'المستخدمين والأدوار', icon: Shield },
    { key: 'settings' as TabKey, label: 'إعدادات النظام', icon: Settings },
    { key: 'architecture' as TabKey, label: 'أكواد VB.NET و SQL', icon: Code, highlight: true }
  ];

  return (
    <div className="min-h-screen bg-slate-950 text-slate-100 flex flex-col font-['Cairo',sans-serif]">
      {/* 1. Desktop Window Top Bar (Title Bar & System Controls) */}
      <header className="bg-slate-900 border-b border-slate-800 px-4 py-2 flex items-center justify-between select-none shadow-md z-30">
        {/* Left: Window Branding */}
        <div className="flex items-center gap-3">
          <div className="w-8 h-8 rounded-xl bg-gradient-to-tr from-blue-600 to-indigo-500 flex items-center justify-center text-white shadow-lg shadow-blue-600/30">
            <School className="w-5 h-5" />
          </div>
          <div>
            <div className="flex items-center gap-2">
              <h1 className="text-sm font-black tracking-tight text-white">
                {settings.schoolName}
              </h1>
              <span className="text-[10px] font-mono px-2 py-0.2 rounded-md bg-blue-950 text-blue-300 border border-blue-800">
                VB.NET + SQL Server Enterprise
              </span>
            </div>
            <div className="text-[11px] text-slate-400">
              العام الدراسي: {settings.academicYear} | {settings.currentSemester}
            </div>
          </div>
        </div>

        {/* Center: System Status Indicators */}
        <div className="hidden lg:flex items-center gap-4 text-xs font-mono">
          <div className="flex items-center gap-1.5 px-2.5 py-1 rounded-lg bg-slate-950 border border-slate-800">
            <span className="w-2 h-2 rounded-full bg-emerald-500 animate-pulse"></span>
            <span className="text-slate-300">خادم SQL Server:</span>
            <span className="text-emerald-400 font-bold">متصل (Online)</span>
          </div>

          <div className="flex items-center gap-1.5 px-2.5 py-1 rounded-lg bg-slate-950 border border-slate-800">
            <HardDrive className="w-3.5 h-3.5 text-blue-400" />
            <span className="text-slate-300">قاعدة البيانات:</span>
            <span className="text-blue-300 font-bold">SchoolManagementDB</span>
          </div>

          <div className="text-slate-400 font-mono px-2 py-1">
            {currentTime}
          </div>
        </div>

        {/* Right: Quick Action Buttons & Window Controls */}
        <div className="flex items-center gap-2">
          <button
            onClick={() => setIsAddStudentOpen(true)}
            className="flex items-center gap-1.5 px-3 py-1.5 bg-blue-600 hover:bg-blue-500 text-white rounded-xl text-xs font-bold shadow-md shadow-blue-600/20 transition-all cursor-pointer"
            title="تسجيل طالب جديد (اختصار F2)"
          >
            <UserPlus className="w-3.5 h-3.5" />
            <span className="hidden sm:inline">تسجيل طالب</span>
          </button>

          <button
            onClick={() => setIsAddReceiptOpen(true)}
            className="flex items-center gap-1.5 px-3 py-1.5 bg-emerald-600 hover:bg-emerald-500 text-white rounded-xl text-xs font-bold shadow-md shadow-emerald-600/20 transition-all cursor-pointer"
            title="إصدار سند قبض (اختصار F3)"
          >
            <CreditCard className="w-3.5 h-3.5" />
            <span className="hidden sm:inline">سند قبض</span>
          </button>

          {/* User Avatar Badge */}
          <div className="flex items-center gap-2 pl-2 pr-3 py-1 bg-slate-950 border border-slate-800 rounded-xl text-xs">
            <div className="w-6 h-6 rounded-lg bg-rose-600 text-white font-bold flex items-center justify-center text-[11px]">
              م
            </div>
            <div className="text-right">
              <div className="font-bold text-slate-200">المدير العام (admin)</div>
              <div className="text-[10px] text-emerald-400 font-mono">صلاحيات كاملة CRUD</div>
            </div>
          </div>

          {/* Window Chrome Mock Controls */}
          <div className="hidden sm:flex items-center gap-1 mr-2 border-r border-slate-800 pr-2">
            <button className="p-1.5 rounded hover:bg-slate-800 text-slate-400 hover:text-white transition-colors" title="تصغير">
              <Minus className="w-3.5 h-3.5" />
            </button>
            <button className="p-1.5 rounded hover:bg-slate-800 text-slate-400 hover:text-white transition-colors" title="تكبير">
              <Square className="w-3 h-3" />
            </button>
            <button className="p-1.5 rounded hover:bg-red-600 text-slate-400 hover:text-white transition-colors" title="إغلاق">
              <X className="w-3.5 h-3.5" />
            </button>
          </div>
        </div>
      </header>

      {/* 2. Modern Tabbed Ribbon / Navigation Bar */}
      <nav className="bg-slate-900/90 border-b border-slate-800 px-4 flex items-center overflow-x-auto custom-scrollbar select-none z-20">
        <div className="flex items-center gap-1 py-1.5 min-w-max">
          {tabs.map((tab) => {
            const Icon = tab.icon;
            const isActive = activeTab === tab.key;
            return (
              <button
                key={tab.key}
                onClick={() => setActiveTab(tab.key)}
                className={`flex items-center gap-2 px-3.5 py-2 rounded-xl text-xs font-bold transition-all cursor-pointer relative ${
                  isActive
                    ? 'bg-blue-600 text-white shadow-lg shadow-blue-600/30'
                    : tab.highlight
                    ? 'bg-amber-950/60 text-amber-300 hover:bg-amber-900/50 border border-amber-800/60'
                    : 'text-slate-400 hover:text-slate-100 hover:bg-slate-800/70'
                }`}
              >
                <Icon className={`w-4 h-4 ${isActive ? 'text-white' : tab.highlight ? 'text-amber-400' : 'text-slate-400'}`} />
                <span>{tab.label}</span>
                {tab.badge !== undefined && (
                  <span
                    className={`text-[10px] font-mono px-1.5 py-0.2 rounded-full font-bold ${
                      isActive ? 'bg-white/20 text-white' : 'bg-slate-800 text-slate-300'
                    }`}
                  >
                    {tab.badge}
                  </span>
                )}
              </button>
            );
          })}
        </div>
      </nav>

      {/* 3. Main Workspace Area (Active Tab Content) */}
      <main className="flex-1 overflow-y-auto custom-scrollbar bg-gradient-to-b from-slate-950 via-slate-900 to-slate-950">
        {activeTab === 'dashboard' && (
          <DashboardTab
            students={students}
            teachers={teachers}
            classes={classes}
            invoices={invoices}
            attendance={attendance}
            grades={grades}
            auditLogs={auditLogs}
            onNavigate={(target) => setActiveTab(target as TabKey)}
            onOpenModule={(target) => setActiveTab(target as TabKey)}
            onOpenAddStudent={() => setIsAddStudentOpen(true)}
            onOpenNewStudentModal={() => setIsAddStudentOpen(true)}
            onOpenAddReceipt={() => setIsAddReceiptOpen(true)}
            onOpenNewReceiptModal={() => setIsAddReceiptOpen(true)}
          />
        )}

        {activeTab === 'students' && (
          <StudentsTab
            students={students}
            grades={grades}
            attendance={attendance}
            invoices={invoices}
            onAddStudent={handleAddStudent}
            onDeleteStudent={handleDeleteStudent}
            classesList={classesList}
          />
        )}

        {activeTab === 'teachers' && (
          <TeachersTab teachers={teachers} onAddTeacher={handleAddTeacher} />
        )}

        {activeTab === 'classes' && (
          <ClassesTab classes={classes} onAddClass={handleAddClass} />
        )}

        {activeTab === 'subjects' && (
          <SubjectsTab subjects={subjects} onAddSubject={handleAddSubject} />
        )}

        {activeTab === 'attendance' && (
          <AttendanceTab
            students={students}
            attendance={attendance}
            onSaveAttendance={handleSaveAttendance}
            classesList={classesList}
          />
        )}

        {activeTab === 'exams' && (
          <ExamsTab
            grades={grades}
            exams={exams}
            onUpdateGrade={handleUpdateGrade}
          />
        )}

        {activeTab === 'finance' && (
          <FinanceTab
            invoices={invoices}
            payments={payments}
            onAddPaymentReceipt={handleAddPaymentReceipt}
            onOpenReceiptModal={() => setIsAddReceiptOpen(true)}
            isReceiptModalOpen={isAddReceiptOpen}
            onCloseReceiptModal={() => setIsAddReceiptOpen(false)}
          />
        )}

        {activeTab === 'hr' && (
          <HRTab staff={staff} onAddStaff={handleAddStaff} />
        )}

        {activeTab === 'reports' && (
          <ReportsTab
            students={students}
            teachers={teachers}
            invoices={invoices}
            grades={grades}
          />
        )}

        {activeTab === 'audit' && <AuditTab logs={auditLogs} />}

        {activeTab === 'backup' && (
          <BackupTab backups={backups} onTriggerBackup={handleTriggerBackup} />
        )}

        {activeTab === 'security' && (
          <SecurityTab
            users={systemUsers}
            onAddUser={handleAddUser}
            onToggleUserStatus={handleToggleUserStatus}
          />
        )}

        {activeTab === 'settings' && (
          <SettingsTab settings={settings} onSaveSettings={setSettings} />
        )}

        {activeTab === 'architecture' && <ArchitectureTab />}
      </main>

      {/* 4. Global Modals */}
      <AddStudentModal
        isOpen={isAddStudentOpen}
        onClose={() => setIsAddStudentOpen(false)}
        onAddStudent={handleAddStudent}
        classesList={classesList}
      />

      <AddReceiptModal
        isOpen={isAddReceiptOpen}
        onClose={() => setIsAddReceiptOpen(false)}
        invoices={invoices}
        onAddReceipt={handleAddPaymentReceipt}
      />

      {/* 5. Desktop Status Bar (Bottom Bar) */}
      <footer className="bg-slate-900 border-t border-slate-800 px-4 py-1.5 flex flex-wrap items-center justify-between text-[11px] text-slate-400 font-mono select-none z-20">
        <div className="flex items-center gap-4">
          <div className="flex items-center gap-1.5">
            <span className="w-2 h-2 rounded-full bg-emerald-400"></span>
            <span className="text-slate-300">خادم SQL Server:</span>
            <span className="text-emerald-400 font-bold">127.0.0.1:1433 (Ready)</span>
          </div>

          <span>|</span>

          <div>
            ترميز القاعدة:{' '}
            <span className="text-slate-300 font-semibold">Arabic_100_CI_AS_SC_UTF8</span>
          </div>

          <span className="hidden md:inline">|</span>

          <div className="hidden md:block">
            إجمالي السجلات:{' '}
            <span className="text-blue-400 font-bold">
              {students.length + teachers.length + invoices.length + attendance.length}
            </span>
          </div>
        </div>

        <div className="flex items-center gap-3">
          <span className="text-slate-500">وقت الاستجابة: 2.4ms</span>
          <span>|</span>
          <span className="text-slate-400">المستخدم: admin</span>
          <span>|</span>
          <span className="text-emerald-400 font-bold">نظام إدارتي v2.5 Enterprise</span>
        </div>
      </footer>
    </div>
  );
}
