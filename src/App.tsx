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
  X,
  KeyRound,
  MessageSquare,
  ShieldAlert,
  Download,
  LogOut,
  Sparkles,
  Server
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
  SchoolSettings,
  LicenseInfo,
  DbConnectionConfig,
  SystemVersionInfo,
  ToastNotification,
  UserAccount
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
  initialSettings,
  initialLicenseInfo,
  initialDbConfig,
  initialVersionInfo
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
import { ToastContainer } from './components/common/ToastContainer';
import { LoginScreen } from './components/auth/LoginScreen';
import { ChangePasswordModal } from './components/auth/ChangePasswordModal';
import { LicenseModal } from './components/system/LicenseModal';
import { SystemUpdateModal } from './components/system/SystemUpdateModal';
import { DbConnectionModal } from './components/system/DbConnectionModal';
import { ExitBackupModal } from './components/system/ExitBackupModal';
import { WhatsAppModal } from './components/common/WhatsAppModal';

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

  // Authentication State
  const [currentUser, setCurrentUser] = useState<UserAccount | null>(() => initialUsers[0] || null);

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

  // System & Connection States
  const [license, setLicense] = useState<LicenseInfo>(initialLicenseInfo);
  const [dbConfig, setDbConfig] = useState<DbConnectionConfig>(initialDbConfig);
  const [versionInfo, setVersionInfo] = useState<SystemVersionInfo>(initialVersionInfo);

  // Smart Side Notifications (Toast system)
  const [toasts, setToasts] = useState<ToastNotification[]>([
    {
      id: 'init-toast-1',
      title: 'خادم SQL Server جاهز',
      message: 'تم الاتصال بقاعدة بيانات المدرسة EduraSchoolDB بزمن استجابة 3.8ms.',
      type: 'success',
      timestamp: 'الآن',
      autoCloseDelay: 6000
    },
    {
      id: 'init-toast-2',
      title: 'تحديث برمجي متوفر v2.6.0',
      message: 'يتضمن ترقية أمان الحظر وإرسال رسائل الواتساب وترقية قواعد البيانات.',
      type: 'info',
      timestamp: 'الآن',
      actionLabel: 'فحص وتثبيت',
      onAction: () => setIsUpdateModalOpen(true),
      autoCloseDelay: 10000
    }
  ]);

  // Modal Dialogs
  const [isAddStudentOpen, setIsAddStudentOpen] = useState(false);
  const [isAddReceiptOpen, setIsAddReceiptOpen] = useState(false);
  const [isChangePasswordOpen, setIsChangePasswordOpen] = useState(false);
  const [isLicenseModalOpen, setIsLicenseModalOpen] = useState(false);
  const [isUpdateModalOpen, setIsUpdateModalOpen] = useState(false);
  const [isDbModalOpen, setIsDbModalOpen] = useState(false);
  const [isExitBackupOpen, setIsExitBackupOpen] = useState(false);
  const [isWhatsAppOpen, setIsWhatsAppOpen] = useState(false);
  const [whatsAppRecipient, setWhatsAppRecipient] = useState<{
    name: string;
    phone: string;
    studentName?: string;
    type?: 'attendance' | 'fees' | 'grades' | 'general';
    amount?: number;
    date?: string;
  }>({
    name: 'ولي أمر الطالب',
    phone: '0509988771',
    studentName: 'ريان عبد العزيز السبيعي',
    type: 'attendance'
  });

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

  // Background Automatic Update Checker
  useEffect(() => {
    if (!versionInfo.autoCheckUpdates) return;
    const updateCheckTimer = setInterval(() => {
      // Periodic check simulation
      if (versionInfo.isUpdateAvailable) {
        addToast(
          'info',
          'تحديث متوفر للنظام',
          `الإصدار الجديد (${versionInfo.latestVersion}) جاهز مع تحديثات الجداول SQL Migrations.`,
          'تحديث الآن',
          () => setIsUpdateModalOpen(true)
        );
      }
    }, 120000); // Check every 2 minutes
    return () => clearInterval(updateCheckTimer);
  }, [versionInfo.autoCheckUpdates, versionInfo.isUpdateAvailable, versionInfo.latestVersion]);

  // Toast Helper
  const addToast = (
    type: ToastNotification['type'],
    title: string,
    message: string,
    actionLabel?: string,
    onAction?: () => void
  ) => {
    const newToast: ToastNotification = {
      id: 'toast-' + Date.now() + Math.random(),
      type,
      title,
      message,
      timestamp: new Date().toLocaleTimeString('ar-SA', { hour: '2-digit', minute: '2-digit' }),
      actionLabel,
      onAction,
      autoCloseDelay: 5000
    };
    setToasts((prev) => [newToast, ...prev]);
  };

  const removeToast = (id: string) => {
    setToasts((prev) => prev.filter((t) => t.id !== id));
  };

  // Log Audit Action Helper
  const logAudit = (action: 'INSERT' | 'UPDATE' | 'DELETE' | 'BACKUP' | 'LOGIN', table: string, id: number | string, details: string) => {
    const newLog: AuditLogRecord = {
      id: Date.now(),
      timestamp: new Date().toISOString().replace('T', ' ').substring(0, 19),
      action,
      tableName: table,
      recordId: id,
      username: currentUser ? currentUser.username : 'system',
      details,
      ipAddress: '127.0.0.1 (Local Client)'
    };
    setAuditLogs((prev) => [newLog, ...prev]);
  };

  // Student Actions
  const handleAddStudent = (newStudentData: Omit<Student, 'id'>) => {
    const newId = students.length > 0 ? Math.max(...students.map((s) => s.id)) + 1 : 1;
    const fullStudent: Student = { ...newStudentData, id: newId };
    setStudents((prev) => [fullStudent, ...prev]);

    // Auto-generate tuition invoice
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
    addToast('success', 'تم حفظ الطالب بنجاح', `تم تسجيل الطالب ${fullStudent.fullName} وتوليد الفاتورة الدراسية.`);
  };

  const handleDeleteStudent = (studentId: number) => {
    const student = students.find((s) => s.id === studentId);
    setStudents((prev) => prev.filter((s) => s.id !== studentId));
    if (student) {
      logAudit('DELETE', 'Students', studentId, `تعطيل/حذف قيد الطالب: ${student.fullName}`);
      addToast('warning', 'تم حذف قيد الطالب', `تمت إزالة سجل الطالب ${student.fullName} من القائمة.`);
    }
  };

  const handleAddTeacher = (newTeacherData: Omit<Teacher, 'id'>) => {
    const newId = teachers.length > 0 ? Math.max(...teachers.map((t) => t.id)) + 1 : 1;
    const fullTeacher: Teacher = { ...newTeacherData, id: newId };
    setTeachers((prev) => [fullTeacher, ...prev]);
    logAudit('INSERT', 'Teachers', newId, `إضافة معلم جديد: ${fullTeacher.fullName} (${fullTeacher.employeeNumber})`);
    addToast('success', 'تمت إضافة المعلم', `تم تسجيل المعلم ${fullTeacher.fullName} في النظام.`);
  };

  const handleAddClass = (newClassData: Omit<ClassSection, 'id'>) => {
    const newId = classes.length > 0 ? Math.max(...classes.map((c) => c.id)) + 1 : 1;
    const fullClass: ClassSection = { ...newClassData, id: newId };
    setClasses((prev) => [...prev, fullClass]);
    logAudit('INSERT', 'Classes', newId, `إضافة قاعة/شعبة دراسية: ${fullClass.className} (${fullClass.roomNumber})`);
    addToast('success', 'تم حفظ الفصل', `تمت إضافة الشعبة ${fullClass.className} بنجاح.`);
  };

  const handleAddSubject = (newSubjectData: Omit<Subject, 'id'>) => {
    const newId = subjects.length > 0 ? Math.max(...subjects.map((s) => s.id)) + 1 : 1;
    const fullSubject: Subject = { ...newSubjectData, id: newId };
    setSubjects((prev) => [...prev, fullSubject]);
    logAudit('INSERT', 'Subjects', newId, `إضافة مادة دراسية: ${fullSubject.name} (${fullSubject.code})`);
    addToast('success', 'تم حفظ المادة', `تم إدراج منهج ${fullSubject.name} في الخطة.`);
  };

  const handleSaveAttendance = (records: AttendanceRecord[]) => {
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
    addToast('success', 'تم حفظ كشف الحضور والغياب', `تم اعتماد حضور ${records.length} طالب وتحديث السجلات بنجاح.`);
  };

  const handleUpdateGrade = (updatedGrade: StudentGrade) => {
    setGrades((prev) => prev.map((g) => (g.id === updatedGrade.id ? updatedGrade : g)));
    logAudit('UPDATE', 'Grades', updatedGrade.id, `تعديل درجات الطالب: ${updatedGrade.studentName} لمادة ${updatedGrade.subjectName}`);
    addToast('success', 'تم تحديث الدرجة', `تم حفظ تقييم الطالب ${updatedGrade.studentName}.`);
  };

  const handleAddPaymentReceipt = (receiptData: Omit<PaymentReceipt, 'id'>) => {
    const newId = payments.length > 0 ? Math.max(...payments.map((p) => p.id)) + 1 : 1;
    const fullReceipt: PaymentReceipt = { ...receiptData, id: newId };
    setPayments((prev) => [fullReceipt, ...prev]);

    // Update invoice
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
    addToast('success', 'تم إصدار سند القبض', `تم تسجيل السداد بقيمة ${fullReceipt.amount.toLocaleString()} ريال.`);
  };

  const handleAddStaff = (newStaffData: Omit<StaffMember, 'id'>) => {
    const newId = staff.length > 0 ? Math.max(...staff.map((s) => s.id)) + 1 : 1;
    const fullStaff: StaffMember = { ...newStaffData, id: newId };
    setStaff((prev) => [...prev, fullStaff]);
    logAudit('INSERT', 'Staff', newId, `إضافة موظف جديد: ${fullStaff.fullName} (${fullStaff.jobTitle})`);
    addToast('success', 'تمت إضافة الموظف', `تم تسجيل الموظف ${fullStaff.fullName} بنجاح.`);
  };

  // Backups
  const handleTriggerBackup = () => {
    const newBackup: BackupRecord = {
      id: Date.now(),
      fileName: `SchoolDB_Full_${new Date().toISOString().replace(/[-:T]/g, '_').substring(0, 15)}.bak`,
      filePath: 'D:\\SQL_Backups\\SchoolDB\\',
      fileSize: '48.2 MB',
      timestamp: new Date().toISOString().replace('T', ' ').substring(0, 19),
      status: 'Success',
      createdBy: currentUser ? currentUser.username : 'admin'
    };
    setBackups((prev) => [newBackup, ...prev]);
    logAudit('BACKUP', 'Database', 1, `إنشاء نسخة احتياطية كاملة: ${newBackup.fileName}`);
    addToast('success', 'تم إنجاز النسخ الاحتياطي', `تم حفظ ملف النسخة الاحتياطية ${newBackup.fileName} بنجاح.`);
  };

  // User Management & Security Policies
  const handleAddUser = (newUserData: Omit<SystemUser, 'id'>) => {
    const newId = systemUsers.length > 0 ? Math.max(...systemUsers.map((u) => u.id)) + 1 : 1;
    const fullUser: SystemUser = { ...newUserData, id: newId };
    setSystemUsers((prev) => [...prev, fullUser]);
    logAudit('INSERT', 'Users', newId, `إنشاء مستخدم جديد: ${fullUser.username} بصلاحية ${fullUser.role}`);
    addToast('success', 'تم إنشاء حساب مستخدم', `تم إنشاء الحساب ${fullUser.username} وتفعيل صلاحياته.`);
  };

  const handleToggleUserStatus = (userId: number) => {
    setSystemUsers((prev) =>
      prev.map((u) => (u.id === userId ? { ...u, isActive: !u.isActive } : u))
    );
    logAudit('UPDATE', 'Users', userId, `تغيير حالة تفعيل حساب المستخدم ID: ${userId}`);
    addToast('info', 'تحديث حالة الحساب', `تم تغيير إذن الدخول للمستخدم.`);
  };

  // Admin blocking user from accessing system
  const handleToggleUserBlock = (userId: number, reason?: string) => {
    setSystemUsers((prev) =>
      prev.map((u) => {
        if (u.id === userId) {
          const newBlockState = !u.isBlocked;
          return {
            ...u,
            isBlocked: newBlockState,
            isActive: !newBlockState,
            blockReason: newBlockState ? (reason || 'مخالفة السياسات الأمنية أو تعليق مؤقت') : undefined
          };
        }
        return u;
      })
    );

    const user = systemUsers.find((u) => u.id === userId);
    const actionDesc = user?.isBlocked ? 'إلغاء حظر المستخدم' : 'حظر ومنع المستخدم من دخول النظام';
    logAudit('UPDATE', 'Users', userId, `${actionDesc}: ${user?.username} (${reason || ''})`);
    addToast('warning', actionDesc, `تم تحديث ضوابط الدخول للمستخدم ${user?.fullName}.`);
  };

  // User password change (Own password only)
  const handlePasswordChanged = (userId: number, newPass: string) => {
    setSystemUsers((prev) =>
      prev.map((u) => (u.id === userId ? { ...u, password: newPass } : u))
    );
    if (currentUser && currentUser.id === userId) {
      setCurrentUser((prev) => (prev ? { ...prev, password: newPass } : null));
    }
    logAudit('UPDATE', 'Users', userId, `قام المستخدم بتغيير كلمة المرور الخاصة به بنجاح`);
    addToast('success', 'تم تغيير كلمة المرور بنجاح', 'تم تحديث كلمة المرور المشفرة الخاصة بك في قاعدة البيانات.');
  };

  // System Update & SQL Migrations
  const handleApplyUpdate = (updatedInfo: SystemVersionInfo) => {
    setVersionInfo(updatedInfo);
    logAudit('UPDATE', 'SystemVersion', 1, `ترقية النظام وتطبيق هجرة قاعدة البيانات Migration إلى الإصدار ${updatedInfo.currentVersion}`);
    addToast('success', 'تم تحديث النظام وترقية قاعدة البيانات', `أصبح النظام الآن على الإصدار ${updatedInfo.currentVersion} بنجاح.`);
  };

  // Database Connection Configuration Save
  const handleSaveDbConfig = (newConfig: DbConnectionConfig) => {
    setDbConfig(newConfig);
    logAudit('UPDATE', 'DbConnection', 1, `تحديث إعدادات ربط خادم SQL Server: ${newConfig.server}:${newConfig.port}/${newConfig.database}`);
    addToast('success', 'تم حفظ إعدادات قاعدة البيانات', `تم التحقق والربط بخادم ${newConfig.server} بنجاح.`);
  };

  // Program License Update
  const handleUpdateLicense = (newLicense: LicenseInfo) => {
    setLicense(newLicense);
    logAudit('UPDATE', 'License', 1, `تجديد وتحديث ترخيص النظام: ${newLicense.licenseKey} حتى تاريخ ${newLicense.expiryDate}`);
    addToast('success', 'تم تفعيل الترخيص بنجاح', `تم تجديد صلاحية البرنامج حتى ${newLicense.expiryDate} (${newLicense.daysRemaining} يوم متبقي).`);
  };

  // Open WhatsApp with data
  const handleOpenWhatsAppModal = (recipientData: {
    name: string;
    phone: string;
    studentName?: string;
    type?: 'attendance' | 'fees' | 'grades' | 'general';
    amount?: number;
    date?: string;
  }) => {
    setWhatsAppRecipient(recipientData);
    setIsWhatsAppOpen(true);
  };

  // Exit with backup confirmation
  const handleConfirmExitWithBackup = () => {
    handleTriggerBackup();
    addToast('success', 'تم أخذ نسخة احتياطية كاملة', 'جاري إغلاق الجلسة بأمان...');
    setTimeout(() => {
      setCurrentUser(null);
    }, 1200);
  };

  const handleConfirmExitWithoutBackup = () => {
    logAudit('LOGIN', 'Users', currentUser?.id || 1, 'تسجيل خروج فوري بدون نسخ احتياطي');
    addToast('info', 'تسجيل خروج', 'تم إغلاق الجلسة الحالية.');
    setCurrentUser(null);
  };

  const classesList = Array.from(new Set(classes.map((c) => c.className)));

  // Navigation Tabs Definition
  const tabs = [
    { key: 'dashboard' as TabKey, label: 'لوحة القيادة', icon: LayoutDashboard },
    { key: 'students' as TabKey, label: 'شؤون الطلاب', icon: GraduationCap, badge: students.length },
    { key: 'teachers' as TabKey, label: 'المعلمون', icon: Users, badge: teachers.length },
    { key: 'classes' as TabKey, label: 'الفصول والقاعات', icon: School },
    { key: 'subjects' as TabKey, label: 'المناهج والمواد', icon: BookOpen },
    { key: 'attendance' as TabKey, label: 'الحضور والغياب والواتساب', icon: CalendarCheck },
    { key: 'exams' as TabKey, label: 'الكنترول والدرجات', icon: Award },
    { key: 'finance' as TabKey, label: 'المالية والرسوم', icon: Receipt },
    { key: 'hr' as TabKey, label: 'الموارد البشرية', icon: Briefcase },
    { key: 'reports' as TabKey, label: 'التقارير الرسمية', icon: BarChart3 },
    { key: 'audit' as TabKey, label: 'التدقيق الأمني', icon: History },
    { key: 'backup' as TabKey, label: 'النسخ الاحتياطي', icon: Database },
    { key: 'security' as TabKey, label: 'المستخدمين والأمان', icon: Shield },
    { key: 'settings' as TabKey, label: 'إعدادات النظام', icon: Settings },
    { key: 'architecture' as TabKey, label: 'أكواد VB.NET و SQL', icon: Code, highlight: true }
  ];

  // If user is not authenticated, show the Login Screen
  if (!currentUser) {
    return (
      <div className="min-h-screen bg-slate-950 font-['Cairo',sans-serif]">
        <LoginScreen
          users={systemUsers}
          settings={settings}
          onLoginSuccess={(user) => {
            setCurrentUser(user);
            logAudit('LOGIN', 'Users', user.id, `تسجيل دخول ناجح للمستخدم ${user.username}`);
            addToast('success', `مرحباً بك أ. ${user.fullName}`, 'تم تسجيل الدخول بنجاح للنظام.');
          }}
        />
        {/* Toast Container on Login Screen */}
        <ToastContainer toasts={toasts} onDismiss={removeToast} />
      </div>
    );
  }

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

        {/* Center: System Status Indicators & Quick Configuration */}
        <div className="hidden lg:flex items-center gap-3 text-xs font-mono">
          {/* SQL Server Direct Connection Indicator */}
          <button
            onClick={() => setIsDbModalOpen(true)}
            className="flex items-center gap-1.5 px-3 py-1 rounded-xl bg-slate-950 hover:bg-slate-900 border border-slate-800 hover:border-blue-500 transition-colors cursor-pointer"
            title="إعدادات واختبار اتصال SQL Server الفعلي"
          >
            <span className={`w-2 h-2 rounded-full ${dbConfig.status === 'Connected' ? 'bg-emerald-500 animate-pulse' : 'bg-rose-500'}`}></span>
            <span className="text-slate-300">خادم SQL:</span>
            <span className="text-emerald-400 font-bold">{dbConfig.server}:{dbConfig.port}</span>
          </button>

          {/* License & Validity Status */}
          <button
            onClick={() => setIsLicenseModalOpen(true)}
            className="flex items-center gap-1.5 px-3 py-1 rounded-xl bg-slate-950 hover:bg-slate-900 border border-slate-800 hover:border-amber-500 transition-colors cursor-pointer"
            title="صلاحية ترخيص البرنامج ونموذج التفعيل"
          >
            <KeyRound className="w-3.5 h-3.5 text-amber-400" />
            <span className="text-slate-300">الترخيص:</span>
            <span className="text-amber-300 font-bold">{license.daysRemaining} يوم</span>
          </button>

          {/* Version & Migration Update Badge */}
          <button
            onClick={() => setIsUpdateModalOpen(true)}
            className={`flex items-center gap-1.5 px-3 py-1 rounded-xl border transition-colors cursor-pointer ${
              versionInfo.isUpdateAvailable
                ? 'bg-blue-950/80 border-blue-600 text-blue-300 hover:bg-blue-900'
                : 'bg-slate-950 border-slate-800 text-slate-400'
            }`}
            title="التحديث التلقائي وترقية قاعدة البيانات"
          >
            <RefreshCw className={`w-3.5 h-3.5 ${versionInfo.isUpdateAvailable ? 'text-blue-400 animate-spin' : 'text-slate-500'}`} />
            <span>v{versionInfo.currentVersion}</span>
            {versionInfo.isUpdateAvailable && (
              <span className="w-2 h-2 rounded-full bg-blue-400 animate-ping"></span>
            )}
          </button>

          <div className="text-slate-400 font-mono px-2 py-1">
            {currentTime}
          </div>
        </div>

        {/* Right: Quick Action Buttons, WhatsApp, User Profile & Window Controls */}
        <div className="flex items-center gap-2">
          {/* WhatsApp Quick Modal Button */}
          <button
            onClick={() => {
              setWhatsAppRecipient({
                name: 'السادة أولياء الأمور الكرام',
                phone: '0551234567',
                studentName: 'جميع الطلاب',
                type: 'general'
              });
              setIsWhatsAppOpen(true);
            }}
            className="flex items-center gap-1.5 px-3 py-1.5 bg-emerald-700/80 hover:bg-emerald-600 text-white rounded-xl text-xs font-bold border border-emerald-500/50 shadow-md shadow-emerald-700/20 transition-all cursor-pointer"
            title="إرسال رسائل واتساب مباشرة لأولياء الأمور"
          >
            <MessageSquare className="w-3.5 h-3.5" />
            <span className="hidden sm:inline">واتساب أولياء الأمور</span>
          </button>

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
            className="flex items-center gap-1.5 px-3 py-1.5 bg-indigo-600 hover:bg-indigo-500 text-white rounded-xl text-xs font-bold shadow-md shadow-indigo-600/20 transition-all cursor-pointer"
            title="إصدار سند قبض (اختصار F3)"
          >
            <CreditCard className="w-3.5 h-3.5" />
            <span className="hidden sm:inline">سند قبض</span>
          </button>

          {/* User Avatar Badge with Change Password Action */}
          <div className="flex items-center gap-2 pl-2 pr-2.5 py-1 bg-slate-950 border border-slate-800 rounded-xl text-xs">
            <div className="w-6 h-6 rounded-lg bg-rose-600 text-white font-bold flex items-center justify-center text-[11px]">
              {currentUser.fullName.charAt(0) || 'م'}
            </div>
            <div className="text-right hidden sm:block">
              <div className="font-bold text-slate-200">{currentUser.fullName}</div>
              <div className="text-[10px] text-emerald-400 font-mono">{currentUser.role}</div>
            </div>

            {/* Change Password Icon Button */}
            <button
              onClick={() => setIsChangePasswordOpen(true)}
              className="p-1 hover:bg-slate-800 text-slate-400 hover:text-blue-300 rounded transition-colors cursor-pointer"
              title="تغيير كلمة المرور الخاصة بي"
            >
              <KeyRound className="w-3.5 h-3.5" />
            </button>

            {/* Logout / Exit Prompt */}
            <button
              onClick={() => setIsExitBackupOpen(true)}
              className="p-1 hover:bg-rose-950 text-slate-400 hover:text-rose-400 rounded transition-colors cursor-pointer"
              title="الخروج من البرنامج مع خيار النسخ الاحتياطي التلقائي"
            >
              <LogOut className="w-3.5 h-3.5" />
            </button>
          </div>

          {/* Window Controls */}
          <div className="hidden sm:flex items-center gap-1 mr-1 border-r border-slate-800 pr-2">
            <button
              onClick={() => setIsExitBackupOpen(true)}
              className="p-1.5 rounded hover:bg-red-600 text-slate-400 hover:text-white transition-colors cursor-pointer"
              title="إغلاق البرنامج مع خيار النسخ الاحتياطي"
            >
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
            onOpenWhatsApp={(student) =>
              handleOpenWhatsAppModal({
                name: `ولي أمر الطالب: ${student.fullName}`,
                phone: student.primaryParentPhone || '',
                studentName: student.fullName,
                type: 'general'
              })
            }
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
            onOpenWhatsApp={(info) => handleOpenWhatsAppModal(info)}
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
            onOpenWhatsApp={(invoice) =>
              handleOpenWhatsAppModal({
                name: `ولي أمر الطالب: ${invoice.studentName}`,
                phone: '0551234567',
                studentName: invoice.studentName,
                type: 'fees',
                amount: invoice.remainingAmount
              })
            }
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
            onToggleUserBlock={handleToggleUserBlock}
            onOpenChangePassword={() => setIsChangePasswordOpen(true)}
          />
        )}

        {activeTab === 'settings' && (
          <SettingsTab
            settings={settings}
            onSaveSettings={setSettings}
            onOpenDbModal={() => setIsDbModalOpen(true)}
            onOpenLicenseModal={() => setIsLicenseModalOpen(true)}
            onOpenUpdateModal={() => setIsUpdateModalOpen(true)}
          />
        )}

        {activeTab === 'architecture' && <ArchitectureTab />}
      </main>

      {/* 4. Global Modals & Feature Dialogs */}

      {/* Add Student Modal */}
      <AddStudentModal
        isOpen={isAddStudentOpen}
        onClose={() => setIsAddStudentOpen(false)}
        onAddStudent={handleAddStudent}
        classesList={classesList}
      />

      {/* Add Receipt Modal */}
      <AddReceiptModal
        isOpen={isAddReceiptOpen}
        onClose={() => setIsAddReceiptOpen(false)}
        invoices={invoices}
        onAddReceipt={handleAddPaymentReceipt}
      />

      {/* WhatsApp Message Modal */}
      <WhatsAppModal
        isOpen={isWhatsAppOpen}
        onClose={() => setIsWhatsAppOpen(false)}
        defaultRecipient={whatsAppRecipient}
        onMessageSent={(log) => {
          logAudit('INSERT', 'WhatsAppMessageLogs', log.recipientPhone, `إرسال رسالة واتساب إلى ${log.recipientName} (${log.recipientPhone})`);
          addToast('success', 'تم إرسال رسالة الواتساب', `تم فتح محادثة الواتساب وتجهيز الرسالة لولي الأمر.`);
        }}
      />

      {/* Change Password Modal (User changes own password only) */}
      <ChangePasswordModal
        isOpen={isChangePasswordOpen}
        currentUser={currentUser}
        onClose={() => setIsChangePasswordOpen(false)}
        onPasswordChanged={handlePasswordChanged}
      />

      {/* Program License & Validity Modal */}
      <LicenseModal
        isOpen={isLicenseModalOpen}
        license={license}
        onClose={() => setIsLicenseModalOpen(false)}
        onUpdateLicense={handleUpdateLicense}
      />

      {/* System Update & SQL Migrations Modal */}
      <SystemUpdateModal
        isOpen={isUpdateModalOpen}
        versionInfo={versionInfo}
        onClose={() => setIsUpdateModalOpen(false)}
        onApplyUpdate={handleApplyUpdate}
      />

      {/* Real SQL Server Database Connection Configuration */}
      <DbConnectionModal
        isOpen={isDbModalOpen}
        config={dbConfig}
        onClose={() => setIsDbModalOpen(false)}
        onSaveConfig={handleSaveDbConfig}
      />

      {/* Exit with Auto-Backup Prompt Modal */}
      <ExitBackupModal
        isOpen={isExitBackupOpen}
        onClose={() => setIsExitBackupOpen(false)}
        onConfirmExitWithBackup={handleConfirmExitWithBackup}
        onConfirmExitWithoutBackup={handleConfirmExitWithoutBackup}
      />

      {/* Smart Side Toast Notifications Container */}
      <ToastContainer toasts={toasts} onDismiss={removeToast} />

      {/* 5. Desktop Status Bar (Bottom Bar) */}
      <footer className="bg-slate-900 border-t border-slate-800 px-4 py-1.5 flex flex-wrap items-center justify-between text-[11px] text-slate-400 font-mono select-none z-20">
        <div className="flex items-center gap-4">
          <button
            onClick={() => setIsDbModalOpen(true)}
            className="flex items-center gap-1.5 hover:text-emerald-300 transition-colors cursor-pointer"
          >
            <span className={`w-2 h-2 rounded-full ${dbConfig.status === 'Connected' ? 'bg-emerald-400' : 'bg-rose-400'}`}></span>
            <span className="text-slate-300">خادم SQL:</span>
            <span className="text-emerald-400 font-bold">{dbConfig.server}:{dbConfig.port} ({dbConfig.status})</span>
          </button>

          <span>|</span>

          <button
            onClick={() => setIsLicenseModalOpen(true)}
            className="hover:text-amber-300 transition-colors cursor-pointer"
          >
            الترخيص: <span className="text-amber-400 font-bold">{license.edition} ({license.daysRemaining} يوم متبقي)</span>
          </button>

          <span className="hidden md:inline">|</span>

          <div className="hidden md:block">
            إجمالي السجلات:{' '}
            <span className="text-blue-400 font-bold">
              {students.length + teachers.length + invoices.length + attendance.length}
            </span>
          </div>
        </div>

        <div className="flex items-center gap-3">
          <span className="text-slate-500">وقت الاستجابة: {dbConfig.latencyMs}ms</span>
          <span>|</span>
          <span className="text-slate-400">المستخدم: {currentUser.username}</span>
          <span>|</span>
          <button
            onClick={() => setIsUpdateModalOpen(true)}
            className="text-emerald-400 hover:text-emerald-300 font-bold transition-colors cursor-pointer"
          >
            نظام إدارتي v{versionInfo.currentVersion}
          </button>
        </div>
      </footer>
    </div>
  );
}
