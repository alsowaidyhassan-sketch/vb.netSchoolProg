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
  initialLicenseInfo,
  initialDbConfig,
  initialVersionInfo,
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
  initialUsers,
  initialLicenseInfo,
  initialDbConfig,
  initialVersionInfo
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
  schoolNameEn: 'Dijlah Model Secondary School for Boys',
  currentSemester: defaultSettings.activeSemester || 'الفصل الدراسي الأول',
  website: 'https://dijlah.edu.iq',
  connectionString: 'Server=localhost;Database=EduraSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;'
};
