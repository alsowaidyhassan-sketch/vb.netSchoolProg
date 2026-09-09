export type ModuleKey =
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
  | 'users'
  | 'backup'
  | 'audit'
  | 'settings'
  | 'solution';

export interface TabItem {
  id: ModuleKey;
  title: string;
  iconName: string;
  isPinned?: boolean;
}

export interface Student {
  id: number;
  studentNumber: string;
  barcode: string;
  nationalId: string;
  firstName: string;
  secondName: string;
  thirdName: string;
  lastName: string;
  fullName: string;
  gender: 'ذكر' | 'أنثى';
  dateOfBirth: string;
  birthPlace: string;
  nationality: string;
  phone: string;
  email: string;
  address: string;
  primaryParentName: string;
  primaryParentPhone: string;
  emergencyContactName: string;
  emergencyContactPhone: string;
  bloodType: string;
  gradeName: string;
  className: string;
  sectionName: string;
  status: 'Active' | 'Suspended' | 'Graduated';
  enrollmentDate: string;
  photoUrl?: string;
  medicalNotes?: string;
}

export interface Teacher {
  id: number;
  employeeNumber: string;
  fullName: string;
  specialization: string;
  academicDegree: string;
  phone: string;
  email: string;
  assignedSubjects: string[];
  assignedClasses: string[];
  yearsOfExperience: number;
  basicSalary: number;
  allowances: number;
  status: 'Active' | 'OnLeave' | 'Resigned';
}

export interface ClassSection {
  id: number;
  gradeName: string;
  className: string;
  sectionName: string;
  roomNumber: string;
  capacity: number;
  currentStudentsCount: number;
  supervisorTeacher: string;
}

export interface Subject {
  id: number;
  code: string;
  name: string;
  creditHours: number;
  maxScore: number;
  passingScore: number;
  teacherName: string;
  targetClass: string;
}

export interface AttendanceRecord {
  id: number;
  studentId: number;
  studentName: string;
  studentNumber: string;
  sectionName: string;
  date: string;
  status: 'Present' | 'Absent' | 'Late' | 'Excused';
  lateMinutes?: number;
  notes?: string;
}

export interface ExamRecord {
  id: number;
  examName: string;
  examType: 'نصفي' | 'نهائي' | 'شهري' | 'قصير';
  subjectName: string;
  className: string;
  examDate: string;
  maxScore: number;
  passingScore: number;
}

export interface StudentGrade {
  id: number;
  studentId: number;
  studentName: string;
  studentNumber: string;
  subjectName: string;
  midtermScore: number;
  quizScore: number;
  homeworkScore: number;
  finalScore: number;
  totalScore: number;
  percentage: number;
  gradeLetter: string;
  isPassed: boolean;
}

export interface FeeInvoice {
  id: number;
  invoiceNumber: string;
  studentId: number;
  studentName: string;
  studentNumber?: string;
  className: string;
  feeType: string;
  originalAmount: number;
  discountAmount?: number;
  discount?: number;
  taxAmount?: number;
  finalAmount: number;
  paidAmount: number;
  remainingAmount: number;
  dueDate: string;
  status: 'Paid' | 'Partial' | 'Unpaid';
}

export interface PaymentReceipt {
  id: number;
  receiptNumber: string;
  invoiceNumber: string;
  studentName: string;
  amount: number;
  date: string;
  paymentMethod: 'مدى' | 'تحويل بنكي' | 'بطاقة ائتمان' | 'نقداً';
  referenceNumber: string;
  cashierName: string;
}

export interface StaffMember {
  id: number;
  employeeNumber: string;
  fullName: string;
  jobTitle: string;
  department: string;
  phone: string;
  email: string;
  hireDate: string;
  basicSalary: number;
  allowances: number;
  deductions: number;
  netSalary: number;
  status: 'Active' | 'OnLeave';
}

export interface UserAccount {
  id: number;
  username: string;
  fullName: string;
  email: string;
  role: string;
  userType: 'Admin' | 'Teacher' | 'Accountant' | 'HR' | 'Reception';
  isActive: boolean;
  lastLogin: string;
}

export interface AuditLogItem {
  id: number;
  timestamp: string;
  username: string;
  action: 'INSERT' | 'UPDATE' | 'DELETE' | 'LOGIN' | 'BACKUP';
  tableName: string;
  recordId: string | number;
  computerName?: string;
  ipAddress?: string;
  details: string;
}

export interface BackupRecord {
  id: number;
  fileName: string;
  sizeMB?: number;
  fileSize?: string;
  filePath?: string;
  timestamp: string;
  executedBy?: string;
  createdBy?: string;
  status: 'Success' | 'Failed';
}

export interface SystemSettingsData {
  schoolName: string;
  schoolNameEn?: string;
  schoolCode?: string;
  taxNumber: string;
  phone: string;
  email: string;
  website?: string;
  address: string;
  city?: string;
  principalName?: string;
  academicYear: string;
  activeSemester?: string;
  currentSemester?: string;
  dbServer?: string;
  dbName?: string;
  connectionString?: string;
  theme?: 'DarkNavy' | 'LightModern' | 'SlateEmerald';
}

// Aliases for cross-module compatibility
export type AuditLogRecord = AuditLogItem;
export type SystemUser = UserAccount;
export type SchoolSettings = SystemSettingsData;
