import {
  initialStudents,
  initialTeachers,
  initialClasses,
  initialSubjects,
  initialAttendance,
  initialExams,
  initialGrades,
  initialInvoices,
  initialPayments,
  initialStaff,
  initialAuditLogs,
  initialBackups,
  initialUsers,
  defaultSettings
} from './mockDatabase';
import { SchoolSettings, BackupRecord } from '../types';

export {
  initialStudents,
  initialTeachers,
  initialClasses,
  initialSubjects,
  initialAttendance,
  initialExams,
  initialGrades,
  initialInvoices,
  initialStaff,
  initialAuditLogs,
  initialUsers
};

export const initialReceipts = initialPayments;

export const initialBackupsFormatted: BackupRecord[] = initialBackups.map((b) => ({
  ...b,
  fileSize: `${b.sizeMB} MB`,
  filePath: 'D:\\SQL_Backups\\SchoolDB\\',
  createdBy: b.executedBy
}));

export { initialBackupsFormatted as initialBackups };

export const initialSettings: SchoolSettings = {
  ...defaultSettings,
  schoolNameEn: 'Al-Ruwwad Model Private Schools',
  currentSemester: defaultSettings.activeSemester || 'الفصل الدراسي الثاني',
  website: 'https://alruwad.edu.sa',
  connectionString: 'Server=localhost;Database=SchoolManagementDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;'
};
