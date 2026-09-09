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
  UserAccount,
  AuditLogItem,
  BackupRecord,
  SystemSettingsData
} from '../types';

export const initialStudents: Student[] = [
  {
    id: 1,
    studentNumber: 'STD-2025-001',
    barcode: '62810010001',
    nationalId: '1189923451',
    firstName: 'ريان',
    secondName: 'عبد العزيز',
    thirdName: 'محمد',
    lastName: 'السبيعي',
    fullName: 'ريان عبد العزيز محمد السبيعي',
    gender: 'ذكر',
    dateOfBirth: '2018-03-14',
    birthPlace: 'الرياض',
    nationality: 'سعودي',
    phone: '0509988771',
    email: 'rayan.subaie@student.edura.sa',
    address: 'الرياض - حي الملقا',
    primaryParentName: 'عبد العزيز السبيعي',
    primaryParentPhone: '0509988771',
    emergencyContactName: 'عبد العزيز السبيعي',
    emergencyContactPhone: '0509988771',
    bloodType: 'O+',
    gradeName: 'المرحلة الابتدائية',
    className: 'الصف الأول الابتدائي',
    sectionName: 'أ (الصفوة)',
    status: 'Active',
    enrollmentDate: '2025-08-24',
    medicalNotes: 'سليم ولا يعاني من أي حساسية مزمنة'
  },
  {
    id: 2,
    studentNumber: 'STD-2025-002',
    barcode: '62810010002',
    nationalId: '1199882233',
    firstName: 'سارة',
    secondName: 'سلطان',
    thirdName: 'سعد',
    lastName: 'القحطاني',
    fullName: 'سارة سلطان سعد القحطاني',
    gender: 'أنثى',
    dateOfBirth: '2018-07-21',
    birthPlace: 'الرياض',
    nationality: 'سعودي',
    phone: '0553344556',
    email: 'sara.qahtani@student.edura.sa',
    address: 'الرياض - حي الياسمين',
    primaryParentName: 'سلطان القحطاني',
    primaryParentPhone: '0553344556',
    emergencyContactName: 'سلطان القحطاني',
    emergencyContactPhone: '0553344556',
    bloodType: 'A+',
    gradeName: 'المرحلة الابتدائية',
    className: 'الصف الأول الابتدائي',
    sectionName: 'أ (الصفوة)',
    status: 'Active',
    enrollmentDate: '2025-08-24',
    medicalNotes: 'ترتدي نظارة طبية للقراءة'
  },
  {
    id: 3,
    studentNumber: 'STD-2025-003',
    barcode: '62810010003',
    nationalId: '1177665544',
    firstName: 'عمر',
    secondName: 'فهد',
    thirdName: 'عبد الله',
    lastName: 'الشمري',
    fullName: 'عمر فهد عبد الله الشمري',
    gender: 'ذكر',
    dateOfBirth: '2012-09-10',
    birthPlace: 'الدمام',
    nationality: 'سعودي',
    phone: '0542233445',
    email: 'omar.shammari@student.edura.sa',
    address: 'الرياض - حي حطين',
    primaryParentName: 'د. منيرة الشمري (الأم)',
    primaryParentPhone: '0542233445',
    emergencyContactName: 'د. منيرة الشمري',
    emergencyContactPhone: '0542233445',
    bloodType: 'B+',
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الأول المتوسط',
    sectionName: 'أ (المتفوقين)',
    status: 'Active',
    enrollmentDate: '2025-08-24',
    medicalNotes: 'حساسية من البنسلين'
  },
  {
    id: 4,
    studentNumber: 'STD-2025-004',
    barcode: '62810010004',
    nationalId: '1166554433',
    firstName: 'فيصل',
    secondName: 'عبد العزيز',
    thirdName: 'محمد',
    lastName: 'السبيعي',
    fullName: 'فيصل عبد العزيز محمد السبيعي',
    gender: 'ذكر',
    dateOfBirth: '2008-01-05',
    birthPlace: 'الرياض',
    nationality: 'سعودي',
    phone: '0509988771',
    email: 'faisal.subaie@student.edura.sa',
    address: 'الرياض - حي الملقا',
    primaryParentName: 'عبد العزيز السبيعي',
    primaryParentPhone: '0509988771',
    emergencyContactName: 'عبد العزيز السبيعي',
    emergencyContactPhone: '0509988771',
    bloodType: 'O+',
    gradeName: 'المرحلة الثانوية',
    className: 'الصف الثالث الثانوي (مسارات)',
    sectionName: 'أ (عام)',
    status: 'Active',
    enrollmentDate: '2023-09-01'
  },
  {
    id: 5,
    studentNumber: 'STD-2025-005',
    barcode: '62810010005',
    nationalId: '1155443322',
    firstName: 'نورة',
    secondName: 'خالد',
    thirdName: 'منصور',
    lastName: 'الغامدي',
    fullName: 'نورة خالد منصور الغامدي',
    gender: 'أنثى',
    dateOfBirth: '2013-11-18',
    birthPlace: 'جدة',
    nationality: 'سعودي',
    phone: '0567788990',
    email: 'noura.ghamdi@student.edura.sa',
    address: 'الرياض - حي العقيق',
    primaryParentName: 'خالد منصور الغامدي',
    primaryParentPhone: '0567788990',
    emergencyContactName: 'خالد منصور الغامدي',
    emergencyContactPhone: '0567788990',
    bloodType: 'AB+',
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الأول المتوسط',
    sectionName: 'أ (المتفوقين)',
    status: 'Active',
    enrollmentDate: '2025-08-24'
  }
];

export const initialTeachers: Teacher[] = [
  {
    id: 1,
    employeeNumber: 'EMP-1001',
    fullName: 'أ. محمد سالم الغامدي',
    specialization: 'الرياضيات والتفكير المنطقي',
    academicDegree: 'ماجستير مناهج رياضيات',
    phone: '0501234567',
    email: 'm.alghamdi@alruwad.edu.sa',
    assignedSubjects: ['الرياضيات المتقدمة', 'الإحصاء والاحتمالات'],
    assignedClasses: ['الصف الأول المتوسط', 'الصف الثالث الثانوي'],
    yearsOfExperience: 9,
    basicSalary: 11500,
    allowances: 1500,
    status: 'Active'
  },
  {
    id: 2,
    employeeNumber: 'EMP-1002',
    fullName: 'أ. طارق عبد الرحمن الشهري',
    specialization: 'اللغة الإنجليزية وآدابها',
    academicDegree: 'بكالوريوس لغات وترجمة',
    phone: '0549876543',
    email: 't.alshehri@alruwad.edu.sa',
    assignedSubjects: ['اللغة الإنجليزية التفاعلية'],
    assignedClasses: ['الصف الأول الابتدائي', 'الصف الأول المتوسط'],
    yearsOfExperience: 7,
    basicSalary: 10800,
    allowances: 1200,
    status: 'Active'
  },
  {
    id: 3,
    employeeNumber: 'EMP-1003',
    fullName: 'أ. سارة عبد الله العتيبي',
    specialization: 'العلوم العامة والفيزياء',
    academicDegree: 'بكالوريوس علوم فيزيائية',
    phone: '0561122334',
    email: 's.alotaibi@alruwad.edu.sa',
    assignedSubjects: ['العلوم العامة والتطبيقية', 'الفيزياء الحديثة'],
    assignedClasses: ['الصف الأول المتوسط', 'الصف الثالث الثانوي'],
    yearsOfExperience: 6,
    basicSalary: 11000,
    allowances: 1400,
    status: 'Active'
  }
];

export const initialClasses: ClassSection[] = [
  {
    id: 1,
    gradeName: 'المرحلة الابتدائية',
    className: 'الصف الأول الابتدائي',
    sectionName: 'أ (الصفوة)',
    roomNumber: 'قاعة 101',
    capacity: 28,
    currentStudentsCount: 22,
    supervisorTeacher: 'أ. طارق الشهري'
  },
  {
    id: 2,
    gradeName: 'المرحلة الابتدائية',
    className: 'الصف الأول الابتدائي',
    sectionName: 'ب (الرواد)',
    roomNumber: 'قاعة 102',
    capacity: 28,
    currentStudentsCount: 20,
    supervisorTeacher: 'أ. عبد الله الحربي'
  },
  {
    id: 3,
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الأول المتوسط',
    sectionName: 'أ (المتفوقين)',
    roomNumber: 'قاعة 201',
    capacity: 32,
    currentStudentsCount: 26,
    supervisorTeacher: 'أ. محمد الغامدي'
  },
  {
    id: 4,
    gradeName: 'المرحلة الثانوية',
    className: 'الصف الثالث الثانوي (مسارات)',
    sectionName: 'أ (عام)',
    roomNumber: 'قاعة 301',
    capacity: 35,
    currentStudentsCount: 30,
    supervisorTeacher: 'أ. سارة العتيبي'
  }
];

export const initialSubjects: Subject[] = [
  {
    id: 1,
    code: 'MATH-101',
    name: 'الرياضيات المتقدمة',
    creditHours: 5,
    maxScore: 100,
    passingScore: 60,
    teacherName: 'أ. محمد سالم الغامدي',
    targetClass: 'الصف الأول المتوسط'
  },
  {
    id: 2,
    code: 'ENG-101',
    name: 'اللغة الإنجليزية التفاعلية',
    creditHours: 4,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'أ. طارق عبد الرحمن الشهري',
    targetClass: 'الصف الأول الابتدائي'
  },
  {
    id: 3,
    code: 'SCI-101',
    name: 'العلوم العامة والتطبيقية',
    creditHours: 4,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'أ. سارة عبد الله العتيبي',
    targetClass: 'الصف الأول المتوسط'
  },
  {
    id: 4,
    code: 'ARB-101',
    name: 'لغتي الجميلة والأدب العربي',
    creditHours: 4,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'أ. خالد الدوسري',
    targetClass: 'الصف الأول الابتدائي'
  }
];

export const initialAttendance: AttendanceRecord[] = [
  { id: 1, studentId: 1, studentName: 'ريان عبد العزيز السبيعي', studentNumber: 'STD-2025-001', sectionName: 'أ (الصفوة)', date: '2025-05-12', status: 'Present' },
  { id: 2, studentId: 2, studentName: 'سارة سلطان القحطاني', studentNumber: 'STD-2025-002', sectionName: 'أ (الصفوة)', date: '2025-05-12', status: 'Present' },
  { id: 3, studentId: 3, studentName: 'عمر فهد الشمري', studentNumber: 'STD-2025-003', sectionName: 'أ (المتفوقين)', date: '2025-05-12', status: 'Late', lateMinutes: 15, notes: 'ازدحام مروري' },
  { id: 4, studentId: 4, studentName: 'فيصل عبد العزيز السبيعي', studentNumber: 'STD-2025-004', sectionName: 'أ (عام)', date: '2025-05-12', status: 'Present' },
  { id: 5, studentId: 5, studentName: 'نورة خالد الغامدي', studentNumber: 'STD-2025-005', sectionName: 'أ (المتفوقين)', date: '2025-05-12', status: 'Excused', notes: 'إجازة مرضية معتمدة' }
];

export const initialExams: ExamRecord[] = [
  { id: 1, examName: 'اختبار نهاية الفصل الدراسي الأول - رياضيات', examType: 'نهائي', subjectName: 'الرياضيات المتقدمة', className: 'الصف الأول المتوسط', examDate: '2025-11-15', maxScore: 100, passingScore: 60 },
  { id: 2, examName: 'اختبار منتصف الفصل - لغة إنجليزية', examType: 'نصفي', subjectName: 'اللغة الإنجليزية التفاعلية', className: 'الصف الأول الابتدائي', examDate: '2025-10-10', maxScore: 50, passingScore: 25 },
  { id: 3, examName: 'اختبار العلوم الدوري الثاني', examType: 'شهري', subjectName: 'العلوم العامة والتطبيقية', className: 'الصف الأول المتوسط', examDate: '2025-10-25', maxScore: 40, passingScore: 20 }
];

export const initialGrades: StudentGrade[] = [
  { id: 1, studentId: 3, studentName: 'عمر فهد الشمري', studentNumber: 'STD-2025-003', subjectName: 'الرياضيات المتقدمة', midtermScore: 28, quizScore: 19, homeworkScore: 10, finalScore: 39, totalScore: 96, percentage: 96, gradeLetter: 'A+ (ممتاز مرتفع)', isPassed: true },
  { id: 2, studentId: 5, studentName: 'نورة خالد الغامدي', studentNumber: 'STD-2025-005', subjectName: 'الرياضيات المتقدمة', midtermScore: 27, quizScore: 18, homeworkScore: 9, finalScore: 38, totalScore: 92, percentage: 92, gradeLetter: 'A (ممتاز)', isPassed: true },
  { id: 3, studentId: 1, studentName: 'ريان عبد العزيز السبيعي', studentNumber: 'STD-2025-001', subjectName: 'اللغة الإنجليزية التفاعلية', midtermScore: 25, quizScore: 17, homeworkScore: 10, finalScore: 36, totalScore: 88, percentage: 88, gradeLetter: 'B+ (جيد جداً مرتفع)', isPassed: true },
  { id: 4, studentId: 2, studentName: 'سارة سلطان القحطاني', studentNumber: 'STD-2025-002', subjectName: 'اللغة الإنجليزية التفاعلية', midtermScore: 29, quizScore: 20, homeworkScore: 10, finalScore: 40, totalScore: 99, percentage: 99, gradeLetter: 'A+ (ممتاز مرتفع)', isPassed: true },
  { id: 5, studentId: 4, studentName: 'فيصل عبد العزيز السبيعي', studentNumber: 'STD-2025-004', subjectName: 'الفيزياء الحديثة', midtermScore: 24, quizScore: 15, homeworkScore: 8, finalScore: 34, totalScore: 81, percentage: 81, gradeLetter: 'B (جيد جداً)', isPassed: true }
];

export const initialInvoices: FeeInvoice[] = [
  { id: 1, invoiceNumber: 'INV-2025-0001', studentId: 1, studentName: 'ريان عبد العزيز السبيعي', studentNumber: 'STD-2025-001', className: 'الصف الأول الابتدائي', feeType: 'الرسوم الدراسية السنوية الأساسية', originalAmount: 18000, discountAmount: 1000, finalAmount: 17000, paidAmount: 17000, remainingAmount: 0, dueDate: '2025-09-01', status: 'Paid' },
  { id: 2, invoiceNumber: 'INV-2025-0002', studentId: 2, studentName: 'سارة سلطان القحطاني', studentNumber: 'STD-2025-002', className: 'الصف الأول الابتدائي', feeType: 'الرسوم الدراسية السنوية الأساسية', originalAmount: 18000, discountAmount: 0, finalAmount: 18000, paidAmount: 9000, remainingAmount: 9000, dueDate: '2025-09-01', status: 'Partial' },
  { id: 3, invoiceNumber: 'INV-2025-0003', studentId: 3, studentName: 'عمر فهد الشمري', studentNumber: 'STD-2025-003', className: 'الصف الأول المتوسط', feeType: 'الرسوم الدراسية السنوية الأساسية', originalAmount: 18000, discountAmount: 0, finalAmount: 18000, paidAmount: 0, remainingAmount: 18000, dueDate: '2025-09-01', status: 'Unpaid' },
  { id: 4, invoiceNumber: 'INV-2025-0004', studentId: 4, studentName: 'فيصل عبد العزيز السبيعي', studentNumber: 'STD-2025-004', className: 'الصف الثالث الثانوي (مسارات)', feeType: 'الرسوم الدراسية السنوية مع النقل', originalAmount: 22000, discountAmount: 2000, finalAmount: 20000, paidAmount: 10000, remainingAmount: 10000, dueDate: '2025-09-01', status: 'Partial' }
];

export const initialPayments: PaymentReceipt[] = [
  { id: 1, receiptNumber: 'REC-2025-101', invoiceNumber: 'INV-2025-0001', studentName: 'ريان عبد العزيز السبيعي', amount: 17000, date: '2025-09-02', paymentMethod: 'مدى', referenceNumber: 'TXN-9844211', cashierName: 'فهد الدوسري' },
  { id: 2, receiptNumber: 'REC-2025-102', invoiceNumber: 'INV-2025-0002', studentName: 'سارة سلطان القحطاني', amount: 9000, date: '2025-09-05', paymentMethod: 'تحويل بنكي', referenceNumber: 'BNK-SA-11029', cashierName: 'فهد الدوسري' },
  { id: 3, receiptNumber: 'REC-2025-103', invoiceNumber: 'INV-2025-0004', studentName: 'فيصل عبد العزيز السبيعي', amount: 10000, date: '2025-09-10', paymentMethod: 'بطاقة ائتمان', referenceNumber: 'VIS-9938210', cashierName: 'فهد الدوسري' }
];

export const initialStaff: StaffMember[] = [
  { id: 1, employeeNumber: 'EMP-1001', fullName: 'أ. محمد سالم الغامدي', jobTitle: 'معلم أول رياضيات', department: 'الشؤون التعليمية', phone: '0501234567', email: 'm.alghamdi@alruwad.edu.sa', hireDate: '2020-08-15', basicSalary: 11500, allowances: 1500, deductions: 500, netSalary: 12500, status: 'Active' },
  { id: 2, employeeNumber: 'EMP-1002', fullName: 'أ. طارق عبد الرحمن الشهري', jobTitle: 'معلم لغة إنجليزية', department: 'الشؤون التعليمية', phone: '0549876543', email: 't.alshehri@alruwad.edu.sa', hireDate: '2021-08-20', basicSalary: 10800, allowances: 1200, deductions: 0, netSalary: 12000, status: 'Active' },
  { id: 3, employeeNumber: 'EMP-2001', fullName: 'أ. فهد خالد الدوسري', jobTitle: 'المدير المالي ورئيس الحسابات', department: 'الشؤون المالية', phone: '0558877665', email: 'f.aldossari@alruwad.edu.sa', hireDate: '2019-03-01', basicSalary: 13500, allowances: 2000, deductions: 600, netSalary: 14900, status: 'Active' },
  { id: 4, employeeNumber: 'EMP-3001', fullName: 'أ. عبد الله إبراهيم الصالح', jobTitle: 'مسؤول القبول والتسجيل', department: 'شؤون الطلاب', phone: '0533344556', email: 'a.alsaleh@alruwad.edu.sa', hireDate: '2022-02-10', basicSalary: 8500, allowances: 1000, deductions: 0, netSalary: 9500, status: 'Active' }
];

export const initialUsers: UserAccount[] = [
  { id: 1, username: 'admin', fullName: 'م. أحمد المنصور (المشرف العام)', email: 'admin@eduraschool.edu.sa', role: 'مدير النظام (Administrator)', userType: 'Admin', isActive: true, lastLogin: '2026-09-08 14:32' },
  { id: 2, username: 'principal', fullName: 'د. عبد العزيز الصالح (المدير)', email: 'principal@alruwad.edu.sa', role: 'مدير المدرسة (Principal)', userType: 'Admin', isActive: true, lastLogin: '2026-09-07 09:15' },
  { id: 3, username: 'm.ghamdi', fullName: 'أ. محمد سالم الغامدي', email: 'm.alghamdi@alruwad.edu.sa', role: 'معلم (Teacher)', userType: 'Teacher', isActive: true, lastLogin: '2026-09-08 08:00' },
  { id: 4, username: 'accountant', fullName: 'أ. فهد خالد الدوسري', email: 'f.aldossari@alruwad.edu.sa', role: 'محاسب مالي (Accountant)', userType: 'Accountant', isActive: true, lastLogin: '2026-09-08 11:20' }
];

export const initialAuditLogs: AuditLogItem[] = [
  { id: 1, timestamp: '2026-09-08 14:30:15', username: 'admin', action: 'LOGIN', tableName: 'Users', recordId: '1', computerName: 'DESKTOP-SRV-01', details: 'تسجيل دخول ناجح للمشرف العام' },
  { id: 2, timestamp: '2026-09-08 13:12:00', username: 'accountant', action: 'INSERT', tableName: 'Payments', recordId: 'REC-2025-103', computerName: 'ACC-TERM-02', details: 'إصدار سند قبض بمبلغ 10,000 ريال للطالب فيصل السبيعي' },
  { id: 3, timestamp: '2026-09-08 11:45:22', username: 'm.ghamdi', action: 'UPDATE', tableName: 'Attendance', recordId: 'SEC-3-20250512', computerName: 'TEACH-PC-05', details: 'رصد الحضور اليومي لشعبة الصف الأول المتوسط' },
  { id: 4, timestamp: '2026-09-08 09:00:10', username: 'admin', action: 'BACKUP', tableName: 'EduraSchoolDB', recordId: 'FullBackup', computerName: 'DESKTOP-SRV-01', details: 'إنشاء نسخة احتياطية كاملة لقاعدة البيانات بنجاح' }
];

export const initialBackups: BackupRecord[] = [
  { id: 1, fileName: 'EduraSchoolDB_Backup_20260908_090010.bak', sizeMB: 48.2, timestamp: '2026-09-08 09:00:10', executedBy: 'admin', status: 'Success' },
  { id: 2, fileName: 'EduraSchoolDB_Backup_20260907_230000.bak', sizeMB: 47.9, timestamp: '2026-09-07 23:00:00', executedBy: 'AutoScheduler', status: 'Success' },
  { id: 3, fileName: 'EduraSchoolDB_Backup_20260906_230000.bak', sizeMB: 47.5, timestamp: '2026-09-06 23:00:00', executedBy: 'AutoScheduler', status: 'Success' }
];

export const defaultSettings: SystemSettingsData = {
  schoolName: 'مدارس الرواد النموذجية الأهلية',
  schoolCode: 'RUWAD-001',
  taxNumber: '310245678900003',
  phone: '0114872200',
  email: 'info@alruwad-schools.edu.sa',
  address: 'حي النخيل الغربي، طريق الملك عبد الله',
  city: 'الرياض',
  principalName: 'د. عبد العزيز بن إبراهيم الصالح',
  academicYear: '1446 - 1447هـ (2025/2026م)',
  activeSemester: 'الفصل الدراسي الثاني',
  dbServer: 'localhost\\MSSQLSERVER',
  dbName: 'EduraSchoolDB',
  theme: 'DarkNavy'
};
