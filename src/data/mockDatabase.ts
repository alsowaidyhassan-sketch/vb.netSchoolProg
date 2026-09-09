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
    nationalId: '199812345678',
    identityDocumentType: 'البطاقة الوطنية الموحدة',
    firstName: 'مصطفى',
    fatherName: 'علي',
    grandFatherName: 'حسين',
    greatGrandFatherName: 'كاظم',
    familyName: 'الزبيدي',
    motherName: 'زينب جواد عبد',
    secondName: 'علي',
    thirdName: 'حسين',
    lastName: 'الزبيدي',
    fullName: 'مصطفى علي حسين كاظم الزبيدي',
    gender: 'ذكر',
    dateOfBirth: '2012-04-15',
    birthPlace: 'بغداد - الكرخ',
    nationality: 'عراقي',
    phone: '07801234567',
    email: 'mustafa.ali@student.dijlah.edu.iq',
    address: 'بغداد - الرصافة - الكرادة - محلة 903 - زقاق 14 - دار 22',
    iraqiAddress: {
      province: 'بغداد',
      district: 'الرصافة',
      subDistrict: 'الكرادة الشرقية',
      area: 'الكرادة داخل',
      street: 'شارع أورزدي',
      mahalla: '903',
      zuqaq: '14',
      houseNumber: '22',
      nearestLandmark: 'قرب ساحة كهرمانة'
    },
    primaryParentName: 'علي حسين كاظم الزبيدي',
    primaryParentPhone: '07801234567',
    emergencyContactName: 'علي حسين الزبيدي (الأب)',
    emergencyContactPhone: '07801234567',
    bloodType: 'O+',
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الأول المتوسط',
    sectionName: 'أ (شعبة المتفوقين)',
    status: 'Active',
    enrollmentDate: '2025-09-01',
    medicalNotes: 'سليم، لا يعاني من أي أمراض مزمنة'
  },
  {
    id: 2,
    studentNumber: 'STD-2025-002',
    barcode: '62810010002',
    nationalId: '200198765432',
    identityDocumentType: 'البطاقة الوطنية الموحدة',
    firstName: 'فاطمة',
    fatherName: 'حيدر',
    grandFatherName: 'جاسم',
    greatGrandFatherName: 'مهدي',
    familyName: 'الشمري',
    motherName: 'مريم خضير صالح',
    secondName: 'حيدر',
    thirdName: 'جاسم',
    lastName: 'الشمري',
    fullName: 'فاطمة حيدر جاسم مهدي الشمري',
    gender: 'أنثى',
    dateOfBirth: '2013-08-20',
    birthPlace: 'بغداد - الرصافة',
    nationality: 'عراقية',
    phone: '07709876543',
    email: 'fatima.haidar@student.dijlah.edu.iq',
    address: 'بغداد - الكرخ - حي الجامعة - محلة 629 - زقاق 8 - دار 15',
    iraqiAddress: {
      province: 'بغداد',
      district: 'الكرخ',
      subDistrict: 'المنصور',
      area: 'حي الجامعة',
      street: 'شارع الربيع',
      mahalla: '629',
      zuqaq: '8',
      houseNumber: '15',
      nearestLandmark: 'قرب جامع ملا حويش'
    },
    primaryParentName: 'حيدر جاسم مهدي الشمري',
    primaryParentPhone: '07709876543',
    emergencyContactName: 'حيدر جاسم الشمري',
    emergencyContactPhone: '07709876543',
    bloodType: 'A+',
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الأول المتوسط',
    sectionName: 'أ (شعبة المتفوقين)',
    status: 'Active',
    enrollmentDate: '2025-09-01',
    medicalNotes: 'ترتدي نظارات طبية'
  },
  {
    id: 3,
    studentNumber: 'STD-2025-003',
    barcode: '62810010003',
    nationalId: '200545678912',
    identityDocumentType: 'البطاقة الوطنية الموحدة',
    firstName: 'كرار',
    fatherName: 'سجاد',
    grandFatherName: 'رسول',
    greatGrandFatherName: 'حسن',
    familyName: 'العامري',
    motherName: 'فاطمة نعيم شلش',
    secondName: 'سجاد',
    thirdName: 'رسول',
    lastName: 'العامري',
    fullName: 'كرار سجاد رسول حسن العامري',
    gender: 'ذكر',
    dateOfBirth: '2011-11-05',
    birthPlace: 'البصرة',
    nationality: 'عراقي',
    phone: '07501122334',
    email: 'karrar.sajjad@student.dijlah.edu.iq',
    address: 'البصرة - العشار - محلة 102 - زقاق 4 - دار 9',
    iraqiAddress: {
      province: 'البصرة',
      district: 'البصرة',
      subDistrict: 'العشار',
      area: 'حي الخندق',
      street: 'شارع الكورنيش',
      mahalla: '102',
      zuqaq: '4',
      houseNumber: '9',
      nearestLandmark: 'قرب جسر الطنومة'
    },
    primaryParentName: 'سجاد رسول حسن العامري',
    primaryParentPhone: '07501122334',
    emergencyContactName: 'سجاد رسول العامري',
    emergencyContactPhone: '07501122334',
    bloodType: 'B+',
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الثاني المتوسط',
    sectionName: 'ب',
    status: 'Active',
    enrollmentDate: '2024-09-15',
    medicalNotes: 'سليم معافى'
  },
  {
    id: 4,
    studentNumber: 'STD-2025-004',
    barcode: '62810010004',
    nationalId: '200678901234',
    identityDocumentType: 'هوية الأحوال المدنية',
    firstName: 'زينب',
    fatherName: 'أحمد',
    grandFatherName: 'عبد الكريم',
    greatGrandFatherName: 'خضير',
    familyName: 'الدليمي',
    motherName: 'سميرة عبد الرزاق',
    secondName: 'أحمد',
    thirdName: 'عبد الكريم',
    lastName: 'الدليمي',
    fullName: 'زينب أحمد عبد الكريم خضير الدليمي',
    gender: 'أنثى',
    dateOfBirth: '2009-02-18',
    birthPlace: 'الأنبار - الرمادي',
    nationality: 'عراقية',
    phone: '07812345678',
    email: 'zainab.ahmed@student.dijlah.edu.iq',
    address: 'الأنبار - الرمادي - حي التأميم - شارع 17',
    iraqiAddress: {
      province: 'الأنبار',
      district: 'الرمادي',
      subDistrict: 'التأميم',
      area: 'حي الضباط',
      street: 'شارع 17',
      mahalla: '204',
      zuqaq: '7',
      houseNumber: '11',
      nearestLandmark: 'قرب مجمع الشفاء الطبي'
    },
    primaryParentName: 'د. أحمد عبد الكريم الدليمي',
    primaryParentPhone: '07812345678',
    emergencyContactName: 'د. أحمد عبد الكريم',
    emergencyContactPhone: '07812345678',
    bloodType: 'AB+',
    gradeName: 'المرحلة الإعدادية',
    className: 'الصف الرابع العلمي',
    sectionName: 'أ (علمي)',
    status: 'Active',
    enrollmentDate: '2023-09-20',
    medicalNotes: 'لا توجد'
  },
  {
    id: 5,
    studentNumber: 'STD-2025-005',
    barcode: '62810010005',
    nationalId: '200456789012',
    identityDocumentType: 'البطاقة الوطنية الموحدة',
    firstName: 'مقتدى',
    fatherName: 'باقر',
    grandFatherName: 'هادي',
    greatGrandFatherName: 'نعمة',
    familyName: 'الخفاجي',
    motherName: 'زهراء عبد الأمير',
    secondName: 'باقر',
    thirdName: 'هادي',
    lastName: 'الخفاجي',
    fullName: 'مقتدى باقر هادي نعمة الخفاجي',
    gender: 'ذكر',
    dateOfBirth: '2008-07-12',
    birthPlace: 'النجف الأشرف',
    nationality: 'عراقي',
    phone: '07712345678',
    email: 'muqtada.baqir@student.dijlah.edu.iq',
    address: 'النجف الأشرف - حي السعد - محلة 304 - زقاق 11 - دار 5',
    iraqiAddress: {
      province: 'النجف الأشرف',
      district: 'النجف',
      subDistrict: 'الكوفة',
      area: 'حي السعد',
      street: 'شارع الكوفة الرئيسي',
      mahalla: '304',
      zuqaq: '11',
      houseNumber: '5',
      nearestLandmark: 'مجاور مستشفى الصدر التعليمي'
    },
    primaryParentName: 'باقر هادي الخفاجي',
    primaryParentPhone: '07712345678',
    emergencyContactName: 'باقر هادي الخفاجي',
    emergencyContactPhone: '07712345678',
    bloodType: 'O-',
    gradeName: 'المرحلة الإعدادية',
    className: 'الصف الخامس العلمي',
    sectionName: 'أ (تطبيقي)',
    status: 'Active',
    enrollmentDate: '2022-09-18',
    medicalNotes: 'حساسية طفيفة ضد البنسلين'
  }
];

export const initialTeachers: Teacher[] = [
  {
    id: 1,
    employeeNumber: 'TCH-1001',
    fullName: 'أ. سرمد جاسم كاظم الخفاجي',
    specialization: 'الرياضيات والتفاضل والتكامل',
    academicDegree: 'ماجستير رياضيات تطبيقية - جامعة بغداد',
    phone: '07809988776',
    email: 'sarmad.khafaji@dijlah.edu.iq',
    assignedSubjects: ['الرياضيات المتقدمة', 'الإحصاء والاحتمالات'],
    assignedClasses: ['الصف الأول المتوسط', 'الصف الرابع العلمي'],
    yearsOfExperience: 14,
    basicSalary: 1850000,
    allowances: 350000,
    status: 'Active'
  },
  {
    id: 2,
    employeeNumber: 'TCH-1002',
    fullName: 'أ. عمر فاروق طارق الدوري',
    specialization: 'اللغة الإنجليزية وآدابها',
    academicDegree: 'بكالوريوس تربية لغة إنجليزية - جامعة الموصل',
    phone: '07701122445',
    email: 'omar.douri@dijlah.edu.iq',
    assignedSubjects: ['اللغة الإنجليزية التفاعلية'],
    assignedClasses: ['الصف الأول المتوسط', 'الصف الخامس العلمي'],
    yearsOfExperience: 9,
    basicSalary: 1600000,
    allowances: 250000,
    status: 'Active'
  },
  {
    id: 3,
    employeeNumber: 'TCH-1003',
    fullName: 'د. وفاء عبد الرضا هاشم الموسوي',
    specialization: 'الكيمياء العامة والعضوية',
    academicDegree: 'دكتوراه كيمياء - الجامعة المستنصرية',
    phone: '07503344556',
    email: 'wafaa.mousawi@dijlah.edu.iq',
    assignedSubjects: ['الكيمياء التحليلية', 'العلوم العامة'],
    assignedClasses: ['الصف الرابع العلمي', 'الصف الخامس العلمي'],
    yearsOfExperience: 16,
    basicSalary: 2100000,
    allowances: 400000,
    status: 'Active'
  },
  {
    id: 4,
    employeeNumber: 'TCH-1004',
    fullName: 'أ. حيدر صباح شعلان العامري',
    specialization: 'اللغة العربية والبلاغة',
    academicDegree: 'ماجستير لغة عربية - جامعة بابل',
    phone: '07815566778',
    email: 'haidar.amiri@dijlah.edu.iq',
    assignedSubjects: ['قواعد اللغة العربية', 'الأدب والنصوص'],
    assignedClasses: ['الصف الأول المتوسط', 'الصف الثاني المتوسط'],
    yearsOfExperience: 11,
    basicSalary: 1700000,
    allowances: 300000,
    status: 'Active'
  }
];

export const initialClasses: ClassSection[] = [
  {
    id: 1,
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الأول المتوسط',
    sectionName: 'أ (شعبة المتفوقين)',
    roomNumber: 'قاعة 101 - جناح دجلة',
    capacity: 30,
    currentStudentsCount: 28,
    supervisorTeacher: 'أ. سرمد جاسم الخفاجي'
  },
  {
    id: 2,
    gradeName: 'المرحلة المتوسطة',
    className: 'الصف الثاني المتوسط',
    sectionName: 'ب',
    roomNumber: 'قاعة 102 - جناح دجلة',
    capacity: 32,
    currentStudentsCount: 29,
    supervisorTeacher: 'أ. حيدر صباح العامري'
  },
  {
    id: 3,
    gradeName: 'المرحلة الإعدادية',
    className: 'الصف الرابع العلمي',
    sectionName: 'أ (علمي)',
    roomNumber: 'قاعة 201 - مختبر العلوم',
    capacity: 28,
    currentStudentsCount: 25,
    supervisorTeacher: 'د. وفاء الموسوي'
  },
  {
    id: 4,
    gradeName: 'المرحلة الإعدادية',
    className: 'الصف الخامس العلمي',
    sectionName: 'أ (تطبيقي)',
    roomNumber: 'قاعة 202',
    capacity: 30,
    currentStudentsCount: 27,
    supervisorTeacher: 'أ. عمر فاروق الدوري'
  }
];

export const initialSubjects: Subject[] = [
  {
    id: 1,
    code: 'MATH-201',
    name: 'الرياضيات والتحليل الجبري',
    creditHours: 5,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'أ. سرمد جاسم الخفاجي',
    targetClass: 'الصف الأول المتوسط'
  },
  {
    id: 2,
    code: 'ENG-201',
    name: 'English for Iraq (المنهج المعتمد)',
    creditHours: 4,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'أ. عمر فاروق الدوري',
    targetClass: 'الصف الأول المتوسط'
  },
  {
    id: 3,
    code: 'CHM-401',
    name: 'الكيمياء المنهجية العامة',
    creditHours: 4,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'د. وفاء الموسوي',
    targetClass: 'الصف الرابع العلمي'
  },
  {
    id: 4,
    code: 'ARB-201',
    name: 'قواعد اللغة العربية والأدب',
    creditHours: 4,
    maxScore: 100,
    passingScore: 50,
    teacherName: 'أ. حيدر صباح العامري',
    targetClass: 'الصف الأول المتوسط'
  }
];

export const initialAttendance: AttendanceRecord[] = [
  { id: 1, studentId: 1, studentName: 'مصطفى علي حسين كاظم الزبيدي', studentNumber: 'STD-2025-001', sectionName: 'أ (شعبة المتفوقين)', date: '2025-10-12', status: 'Present' },
  { id: 2, studentId: 2, studentName: 'فاطمة حيدر جاسم مهدي الشمري', studentNumber: 'STD-2025-002', sectionName: 'أ (شعبة المتفوقين)', date: '2025-10-12', status: 'Present' },
  { id: 3, studentId: 3, studentName: 'كرار سجاد رسول حسن العامري', studentNumber: 'STD-2025-003', sectionName: 'ب', date: '2025-10-12', status: 'Late', lateMinutes: 20, notes: 'ازدحام في سريع محمد القاسم' },
  { id: 4, studentId: 4, studentName: 'زينب أحمد عبد الكريم خضير الدليمي', studentNumber: 'STD-2025-004', sectionName: 'أ (علمي)', date: '2025-10-12', status: 'Present' },
  { id: 5, studentId: 5, studentName: 'مقتدى باقر هادي نعمة الخفاجي', studentNumber: 'STD-2025-005', sectionName: 'أ (تطبيقي)', date: '2025-10-12', status: 'Excused', notes: 'إجازة رسمية مصدقة' }
];

export const initialExams: ExamRecord[] = [
  { id: 1, examName: 'امتحان نصف السنة - الرياضيات', examType: 'نصفي', subjectName: 'الرياضيات والتحليل الجبري', className: 'الصف الأول المتوسط', examDate: '2026-01-20', maxScore: 100, passingScore: 50 },
  { id: 2, examName: 'امتحان الشهر الأول - اللغة الإنجليزية', examType: 'شهري', subjectName: 'English for Iraq (المنهج المعتمد)', className: 'الصف الأول المتوسط', examDate: '2025-11-10', maxScore: 100, passingScore: 50 },
  { id: 3, examName: 'امتحان الشهر الثاني - الكيمياء', examType: 'شهري', subjectName: 'الكيمياء المنهجية العامة', className: 'الصف الرابع العلمي', examDate: '2025-12-05', maxScore: 100, passingScore: 50 }
];

export const initialGrades: StudentGrade[] = [
  { id: 1, studentId: 1, studentName: 'مصطفى علي حسين كاظم الزبيدي', studentNumber: 'STD-2025-001', subjectName: 'الرياضيات والتحليل الجبري', midtermScore: 30, quizScore: 20, homeworkScore: 10, finalScore: 38, totalScore: 98, percentage: 98, gradeLetter: 'امتياز (A+)', isPassed: true },
  { id: 2, studentId: 2, studentName: 'فاطمة حيدر جاسم مهدي الشمري', studentNumber: 'STD-2025-002', subjectName: 'الرياضيات والتحليل الجبري', midtermScore: 29, quizScore: 19, homeworkScore: 10, finalScore: 37, totalScore: 95, percentage: 95, gradeLetter: 'امتياز (A+)', isPassed: true },
  { id: 3, studentId: 3, studentName: 'كرار سجاد رسول حسن العامري', studentNumber: 'STD-2025-003', subjectName: 'قواعد اللغة العربية والأدب', midtermScore: 25, quizScore: 18, homeworkScore: 9, finalScore: 35, totalScore: 87, percentage: 87, gradeLetter: 'جيد جداً (B+)', isPassed: true },
  { id: 4, studentId: 4, studentName: 'زينب أحمد عبد الكريم خضير الدليمي', studentNumber: 'STD-2025-004', subjectName: 'الكيمياء المنهجية العامة', midtermScore: 28, quizScore: 19, homeworkScore: 10, finalScore: 39, totalScore: 96, percentage: 96, gradeLetter: 'امتياز (A+)', isPassed: true },
  { id: 5, studentId: 5, studentName: 'مقتدى باقر هادي نعمة الخفاجي', studentNumber: 'STD-2025-005', subjectName: 'English for Iraq', midtermScore: 26, quizScore: 16, homeworkScore: 8, finalScore: 34, totalScore: 84, percentage: 84, gradeLetter: 'جيد جداً (B)', isPassed: true }
];

export const initialInvoices: FeeInvoice[] = [
  {
    id: 1,
    invoiceNumber: 'INV-2025-0001',
    studentId: 1,
    studentName: 'مصطفى علي حسين كاظم الزبيدي',
    studentNumber: 'STD-2025-001',
    className: 'الصف الأول المتوسط',
    feeType: 'القسط الدراسي السنوي المعتمد',
    originalAmount: 2500000,
    discountAmount: 250000,
    finalAmount: 2250000,
    paidAmount: 2250000,
    remainingAmount: 0,
    dueDate: '2025-10-01',
    status: 'Paid'
  },
  {
    id: 2,
    invoiceNumber: 'INV-2025-0002',
    studentId: 2,
    studentName: 'فاطمة حيدر جاسم مهدي الشمري',
    studentNumber: 'STD-2025-002',
    className: 'الصف الأول المتوسط',
    feeType: 'القسط الدراسي السنوي المعتمد',
    originalAmount: 2500000,
    discountAmount: 0,
    finalAmount: 2500000,
    paidAmount: 1250000,
    remainingAmount: 1250000,
    dueDate: '2025-10-01',
    status: 'Partial'
  },
  {
    id: 3,
    invoiceNumber: 'INV-2025-0003',
    studentId: 3,
    studentName: 'كرار سجاد رسول حسن العامري',
    studentNumber: 'STD-2025-003',
    className: 'الصف الثاني المتوسط',
    feeType: 'القسط الدراسي السنوي مع خط النقل',
    originalAmount: 3200000,
    discountAmount: 200000,
    finalAmount: 3000000,
    paidAmount: 0,
    remainingAmount: 3000000,
    dueDate: '2025-10-01',
    status: 'Unpaid'
  },
  {
    id: 4,
    invoiceNumber: 'INV-2025-0004',
    studentId: 4,
    studentName: 'زينب أحمد عبد الكريم خضير الدليمي',
    studentNumber: 'STD-2025-004',
    className: 'الصف الرابع العلمي',
    feeType: 'القسط الدراسي السنوي المعتمد',
    originalAmount: 2800000,
    discountAmount: 300000,
    finalAmount: 2500000,
    paidAmount: 2500000,
    remainingAmount: 0,
    dueDate: '2025-10-01',
    status: 'Paid'
  }
];

export const initialPayments: PaymentReceipt[] = [
  {
    id: 1,
    receiptNumber: 'REC-2025-101',
    invoiceNumber: 'INV-2025-0001',
    studentName: 'مصطفى علي حسين كاظم الزبيدي',
    amount: 2250000,
    date: '2025-10-05',
    paymentMethod: 'نقداً',
    referenceNumber: 'CASH-IQ-88391',
    cashierName: 'أ. نصير عبد الأمير السعدي'
  },
  {
    id: 2,
    receiptNumber: 'REC-2025-102',
    invoiceNumber: 'INV-2025-0002',
    studentName: 'فاطمة حيدر جاسم مهدي الشمري',
    amount: 1250000,
    date: '2025-10-08',
    paymentMethod: 'تحويل بنكي',
    referenceNumber: 'ZAINCASH-098231',
    cashierName: 'أ. نصير عبد الأمير السعدي'
  },
  {
    id: 3,
    receiptNumber: 'REC-2025-103',
    invoiceNumber: 'INV-2025-0004',
    studentName: 'زينب أحمد عبد الكريم خضير الدليمي',
    amount: 2500000,
    date: '2025-10-12',
    paymentMethod: 'بطاقة ائتمان',
    referenceNumber: 'QICARD-TXN-44912',
    cashierName: 'أ. نصير عبد الأمير السعدي'
  }
];

export const initialStaff: StaffMember[] = [
  {
    id: 1,
    employeeNumber: 'EMP-1001',
    fullName: 'أ. سرمد جاسم كاظم الخفاجي',
    jobTitle: 'معلم أول رياضيات ومشرف تربوي',
    department: 'الشؤون التعليمية',
    phone: '07809988776',
    email: 'sarmad.khafaji@dijlah.edu.iq',
    hireDate: '2018-09-01',
    basicSalary: 1850000,
    allowances: 350000,
    deductions: 50000,
    netSalary: 2150000,
    status: 'Active'
  },
  {
    id: 2,
    employeeNumber: 'EMP-1002',
    fullName: 'أ. نصير عبد الأمير السعدي',
    jobTitle: 'مدير الحسابات والشؤون المالية',
    department: 'الشؤون المالية',
    phone: '07705544332',
    email: 'nusayr.saadi@dijlah.edu.iq',
    hireDate: '2019-02-15',
    basicSalary: 2000000,
    allowances: 400000,
    deductions: 0,
    netSalary: 2400000,
    status: 'Active'
  },
  {
    id: 3,
    employeeNumber: 'EMP-1003',
    fullName: 'أ. كرار حامد الموسوي',
    jobTitle: 'مسؤول شؤون الطلبة والتسجيل',
    department: 'شؤون الطلاب',
    phone: '07812233445',
    email: 'karrar.mousawi@dijlah.edu.iq',
    hireDate: '2021-08-01',
    basicSalary: 1400000,
    allowances: 200000,
    deductions: 0,
    netSalary: 1600000,
    status: 'Active'
  }
];

export const initialUsers: UserAccount[] = [
  {
    id: 1,
    username: 'admin',
    fullName: 'م. أحمد المنصور (مدير النظام)',
    email: 'admin@dijlah.edu.iq',
    phone: '07801122334',
    role: 'مدير النظام (Administrator)',
    userType: 'Admin',
    password: 'admin123',
    isActive: true,
    isBlocked: false,
    lastLogin: '2026-09-08 14:32'
  },
  {
    id: 2,
    username: 'principal',
    fullName: 'د. حيدر عبد الله العبيدي (مدير المدرسة)',
    email: 'principal@dijlah.edu.iq',
    phone: '07701122334',
    role: 'مدير المدرسة (Principal)',
    userType: 'Admin',
    password: 'password123',
    isActive: true,
    isBlocked: false,
    lastLogin: '2026-09-07 09:15'
  },
  {
    id: 3,
    username: 'sarmad',
    fullName: 'أ. سرمد جاسم الخفاجي',
    email: 'sarmad.khafaji@dijlah.edu.iq',
    phone: '07809988776',
    role: 'معلم أول ومسؤول شعبة',
    userType: 'Teacher',
    password: 'password123',
    isActive: true,
    isBlocked: false,
    lastLogin: '2026-09-08 08:00'
  },
  {
    id: 4,
    username: 'accountant',
    fullName: 'أ. نصير عبد الأمير السعدي',
    email: 'nusayr.saadi@dijlah.edu.iq',
    phone: '07705544332',
    role: 'المحاسب المالي (Accountant)',
    userType: 'Accountant',
    password: 'password123',
    isActive: true,
    isBlocked: false,
    lastLogin: '2026-09-08 11:20'
  },
  {
    id: 5,
    username: 'reception',
    fullName: 'سحر كاظم الحسني',
    email: 'sahar.hasani@dijlah.edu.iq',
    phone: '07501122448',
    role: 'الاستقبال وشؤون الطلبة',
    userType: 'Reception',
    password: 'password123',
    isActive: false,
    isBlocked: true,
    blockReason: 'حساب موقوف إدارياً لمراجعة الصلاحيات السنوية',
    lastLogin: '2026-08-20 10:15'
  }
];

export const initialLicenseInfo: import('../types').LicenseInfo = {
  licenseKey: 'EDURA-2026-IQ-ENT-9842-8871',
  organizationName: 'ثانوية دجلة للبنين الأهلية النموذجية',
  licensedTo: 'شركة الصرح التربوي للتعليم الأهلي في العراق',
  edition: 'Enterprise',
  hardwareId: 'HWID-IQ-8B92-F104-ED78-990A',
  issueDate: '2025-09-01',
  expiryDate: '2027-08-31',
  daysRemaining: 357,
  maxStudents: 5000,
  maxUsers: 50,
  status: 'Active',
  signature: 'RSA-SHA256-VALID-IRAQ-MINISTRY-STANDARD'
};

export const initialDbConfig: import('../types').DbConnectionConfig = {
  server: 'localhost',
  port: 1433,
  database: 'EduraSchoolDB',
  authType: 'SQLServer',
  username: 'sa',
  password: '••••••••••',
  trustServerCertificate: true,
  connectionTimeout: 15,
  encrypt: false,
  status: 'Connected',
  latencyMs: 3.2,
  lastTested: '2026-09-08 23:10:45'
};

export const initialVersionInfo: import('../types').SystemVersionInfo = {
  currentVersion: '2.5.0 Enterprise',
  latestVersion: '2.6.0 Enterprise',
  releaseDate: '2026-09-08',
  isUpdateAvailable: true,
  autoCheckUpdates: true,
  lastChecked: '2026-09-08 22:00:00',
  changeLog: [
    'اعتماد النظام العراقي بالكامل: البطاقة الوطنية، هوية الأحوال، شهادة الجنسية، جواز السفر العراقي',
    'اعتماد أرقام الهواتف العراقية 07XXXXXXXXX والتخزين الدولي الموحد +9647XXXXXXXXX وكشف مزودي الخدمة (زين العراق، آسيا سيل، كورك)',
    'اعتماد العملة العراقية (الدينار العراقي IQD - د.ع) بجميع الحسابات والفواتير والرواتب بدقة DECIMAL(18,3)',
    'دعم الأسماء العربية الخماسية والسداسية واسم الأم وفق نظام سجلات وزارة التربية العراقية',
    'نظام العناوين العراقية المعتمد: المحافظات الـ 18، القضاء، الناحية، المحلة، الزقاق، الدار، أقرب نقطة دالة',
    'إمكانية فتح وتعديل كافة الواجهات باستخدام Visual Studio Windows Forms Designer مباشرة',
    'إنشاء كامل الكود المصدري VB.NET مع ملفات .Designer.vb وجميع جداول SQL Server'
  ],
  pendingMigrations: [
    {
      version: 'V2.6__001_CreateIdentityDocumentsTable',
      title: 'إنشاء جدول الوثائق الرسمية والهوية العراقية IdentityDocuments',
      description: 'جدول مرن لحفظ وثائق الهوية (البطاقة الوطنية 12 رقم، الأحوال المدنية، شهادة الجنسية، جواز السفر)',
      sqlScript: `CREATE TABLE dbo.IdentityDocuments (
    DocumentId INT IDENTITY(1,1) PRIMARY KEY,
    EntityType NVARCHAR(50) NOT NULL, -- Student / Teacher / Staff / Guardian
    EntityId INT NOT NULL,
    DocumentType NVARCHAR(100) NOT NULL, -- البطاقة الوطنية الموحدة / الأحوال المدنية
    DocumentNumber NVARCHAR(50) NOT NULL,
    IssueDate DATE NULL,
    ExpiryDate DATE NULL,
    IssuingProvince NVARCHAR(100) NULL,
    IssuingAuthority NVARCHAR(150) NULL,
    FamilyRecordNumber NVARCHAR(50) NULL, -- رقم السجل
    PageNumber NVARCHAR(50) NULL, -- رقم الصحيفة
    Notes NVARCHAR(500) NULL,
    IsVerified BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
CREATE UNIQUE INDEX UQ_IdentityDocuments_UniqueDoc ON dbo.IdentityDocuments(DocumentType, DocumentNumber);`,
      releaseDate: '2026-09-08',
      isApplied: false
    },
    {
      version: 'V2.6__002_AddIraqiAddressesAndPhones',
      title: 'إضافة حقول العناوين العراقية وتوحيد صِيَغ الهواتف العراقية',
      description: 'إضافة المحافظة، القضاء، المحلة، الزقاق، الدار، أقرب نقطة دالة لجدول الطلاب والكوادر',
      sqlScript: `ALTER TABLE dbo.Students ADD
    FatherName NVARCHAR(100) NULL,
    GrandFatherName NVARCHAR(100) NULL,
    GreatGrandFatherName NVARCHAR(100) NULL,
    FamilyName NVARCHAR(100) NULL,
    MotherName NVARCHAR(100) NULL,
    Province NVARCHAR(100) NOT NULL DEFAULT N'بغداد',
    District NVARCHAR(100) NULL,
    SubDistrict NVARCHAR(100) NULL,
    Mahalla NVARCHAR(50) NULL,
    Zuqaq NVARCHAR(50) NULL,
    HouseNumber NVARCHAR(50) NULL,
    NearestLandmark NVARCHAR(250) NULL;`,
      releaseDate: '2026-09-08',
      isApplied: false
    }
  ]
};

export const initialAuditLogs: AuditLogItem[] = [
  { id: 1, timestamp: '2026-09-08 14:30:15', username: 'admin', action: 'LOGIN', tableName: 'Users', recordId: '1', computerName: 'DESKTOP-BAGHDAD-01', details: 'تسجيل دخول ناجح لمدير النظام' },
  { id: 2, timestamp: '2026-09-08 13:12:00', username: 'accountant', action: 'INSERT', tableName: 'Payments', recordId: 'REC-2025-103', computerName: 'FINANCE-PC-01', details: 'إصدار سند قبض بمبلغ 2,500,000 د.ع للطالبة زينب الدليمي' },
  { id: 3, timestamp: '2026-09-08 11:45:22', username: 'sarmad', action: 'UPDATE', tableName: 'Attendance', recordId: 'SEC-1-20251012', computerName: 'TEACH-LAPTOP-02', details: 'رصد الحضور اليومي لشعبة الأول المتوسط (أ)' },
  { id: 4, timestamp: '2026-09-08 09:00:10', username: 'admin', action: 'BACKUP', tableName: 'EduraSchoolDB', recordId: 'FullBackup', computerName: 'DESKTOP-BAGHDAD-01', details: 'إنشاء نسخة احتياطية كاملة لقاعدة بيانات المدرسة بنجاح' }
];

export const initialBackups: BackupRecord[] = [
  { id: 1, fileName: 'EduraSchoolDB_Backup_20260908_090010.bak', sizeMB: 52.4, timestamp: '2026-09-08 09:00:10', executedBy: 'admin', status: 'Success' },
  { id: 2, fileName: 'EduraSchoolDB_Backup_20260907_230000.bak', sizeMB: 51.9, timestamp: '2026-09-07 23:00:00', executedBy: 'AutoScheduler', status: 'Success' },
  { id: 3, fileName: 'EduraSchoolDB_Backup_20260906_230000.bak', sizeMB: 51.5, timestamp: '2026-09-06 23:00:00', executedBy: 'AutoScheduler', status: 'Success' }
];

export const defaultSettings: SystemSettingsData = {
  schoolName: 'ثانوية دجلة للبنين الأهلية النموذجية',
  schoolNameEn: 'Dijlah Model Secondary School for Boys',
  schoolCode: 'DIJLAH-BG-01',
  taxNumber: '1004523881',
  phone: '07801122334',
  email: 'info@dijlah.edu.iq',
  address: 'بغداد - الكرخ - حي المنصور - محلة 605 - زقاق 12 - دار 8',
  city: 'بغداد',
  principalName: 'د. حيدر عبد الله العبيدي',
  academicYear: '2025 / 2026م',
  activeSemester: 'الفصل الدراسي الأول',
  dbServer: 'localhost\\MSSQLSERVER',
  dbName: 'EduraSchoolDB',
  theme: 'DarkNavy'
};
