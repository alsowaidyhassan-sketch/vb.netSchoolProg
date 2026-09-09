import React, { useState, useMemo } from 'react';
import {
  UserPlus,
  Filter,
  Eye,
  Trash2,
  Edit,
  GraduationCap,
  Phone,
  School,
  CheckCircle2,
  AlertTriangle
} from 'lucide-react';
import { Student, StudentGrade, AttendanceRecord, FeeInvoice } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';
import { AddStudentModal } from '../common/AddStudentModal';
import { StudentProfileModal } from '../common/StudentProfileModal';
import { ConfirmDialog } from '../common/ConfirmDialog';

interface StudentsTabProps {
  students: Student[];
  grades: StudentGrade[];
  attendance: AttendanceRecord[];
  invoices: FeeInvoice[];
  onAddStudent: (student: Omit<Student, 'id'>) => void;
  onDeleteStudent: (id: number) => void;
  classesList: string[];
}

export const StudentsTab: React.FC<StudentsTabProps> = ({
  students,
  grades,
  attendance,
  invoices,
  onAddStudent,
  onDeleteStudent,
  classesList
}) => {
  const [selectedClass, setSelectedClass] = useState<string>('ALL');
  const [selectedStatus, setSelectedStatus] = useState<string>('ALL');
  const [isAddModalOpen, setIsAddModalOpen] = useState(false);
  const [profileStudent, setProfileStudent] = useState<Student | null>(null);
  const [studentToDelete, setStudentToDelete] = useState<Student | null>(null);

  // Filter students by class and status
  const filteredStudents = useMemo(() => {
    return students.filter((s) => {
      const matchClass = selectedClass === 'ALL' || s.className === selectedClass;
      const matchStatus = selectedStatus === 'ALL' || s.status === selectedStatus;
      return matchClass && matchStatus;
    });
  }, [students, selectedClass, selectedStatus]);

  const columns: Column<Student>[] = [
    {
      key: 'studentNumber',
      header: 'الرقم الأكاديمي',
      sortable: true,
      width: '130px',
      render: (s) => (
        <span className="font-mono text-xs font-bold text-blue-400 bg-blue-950/60 px-2 py-0.5 rounded border border-blue-900/60">
          {s.studentNumber}
        </span>
      )
    },
    {
      key: 'fullName',
      header: 'اسم الطالب الرباعي',
      sortable: true,
      render: (s) => (
        <div className="flex items-center gap-2.5">
          <div className="w-7 h-7 rounded-lg bg-blue-600/30 border border-blue-500/40 text-blue-300 font-bold flex items-center justify-center text-xs">
            {s.firstName[0]}
          </div>
          <div>
            <div className="font-bold text-slate-100">{s.fullName}</div>
            <div className="text-[11px] text-slate-400 font-mono">هوية: {s.nationalId}</div>
          </div>
        </div>
      )
    },
    {
      key: 'className',
      header: 'الصف والشعبة',
      sortable: true,
      render: (s) => (
        <div className="text-xs">
          <div className="text-slate-200 font-medium">{s.className}</div>
          <div className="text-[11px] text-slate-400">{s.sectionName}</div>
        </div>
      )
    },
    {
      key: 'primaryParentPhone',
      header: 'هاتف ولي الأمر',
      sortable: true,
      render: (s) => (
        <div className="flex items-center gap-1 font-mono text-xs text-slate-300">
          <Phone className="w-3 h-3 text-slate-500" />
          <span>{s.primaryParentPhone}</span>
        </div>
      )
    },
    {
      key: 'bloodType',
      header: 'الفصيلة',
      width: '80px',
      render: (s) => (
        <span className="font-mono text-xs font-bold text-rose-400 bg-rose-950/50 px-1.5 py-0.5 rounded border border-rose-900/50">
          {s.bloodType}
        </span>
      )
    },
    {
      key: 'status',
      header: 'الحالة',
      sortable: true,
      width: '100px',
      render: (s) => (
        <span
          className={`text-[11px] font-bold px-2 py-0.5 rounded-full border ${
            s.status === 'Active'
              ? 'bg-emerald-950/80 text-emerald-300 border-emerald-800'
              : 'bg-rose-950/80 text-rose-300 border-rose-800'
          }`}
        >
          {s.status === 'Active' ? 'منتظم' : 'موقوف'}
        </span>
      )
    },
    {
      key: 'actions',
      header: 'الخيارات',
      width: '120px',
      render: (s) => (
        <div className="flex items-center gap-1" onClick={(e) => e.stopPropagation()}>
          <button
            onClick={() => setProfileStudent(s)}
            className="p-1.5 rounded-lg hover:bg-slate-800 text-blue-400 hover:text-blue-300 transition-colors"
            title="عرض الملف الكامل للطالب"
          >
            <Eye className="w-4 h-4" />
          </button>
          <button
            onClick={() => alert(`تعديل بيانات الطالب: ${s.fullName}`)}
            className="p-1.5 rounded-lg hover:bg-slate-800 text-amber-400 hover:text-amber-300 transition-colors"
            title="تعديل البيانات"
          >
            <Edit className="w-4 h-4" />
          </button>
          <button
            onClick={() => setStudentToDelete(s)}
            className="p-1.5 rounded-lg hover:bg-red-950/60 text-red-400 hover:text-red-300 transition-colors"
            title="حذف الطالب (Soft Delete)"
          >
            <Trash2 className="w-4 h-4" />
          </button>
        </div>
      )
    }
  ];

  return (
    <div className="p-6 space-y-4 max-w-7xl mx-auto">
      {/* Header Bar */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-blue-600/20 border border-blue-500/40 rounded-xl text-blue-400">
            <GraduationCap className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">إدارة شؤون الطلاب (Students Registry)</h2>
            <p className="text-xs text-slate-400">
              قاعدة بيانات الطلاب، القيود الرسمية، السجلات الأكاديمية والطبية
            </p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          {/* Class Filter */}
          <div className="flex items-center gap-1 bg-slate-950 border border-slate-800 rounded-xl px-2 py-1 text-xs">
            <Filter className="w-3.5 h-3.5 text-slate-400" />
            <select
              value={selectedClass}
              onChange={(e) => setSelectedClass(e.target.value)}
              className="bg-transparent text-slate-200 focus:outline-none text-xs cursor-pointer"
            >
              <option value="ALL">جميع الفصول الدراسية</option>
              {classesList.map((c, i) => (
                <option key={i} value={c}>
                  {c}
                </option>
              ))}
            </select>
          </div>

          {/* Status Filter */}
          <div className="bg-slate-950 border border-slate-800 rounded-xl px-2 py-1 text-xs">
            <select
              value={selectedStatus}
              onChange={(e) => setSelectedStatus(e.target.value)}
              className="bg-transparent text-slate-200 focus:outline-none text-xs cursor-pointer"
            >
              <option value="ALL">كل الحالات</option>
              <option value="Active">الطلاب المنتظمين</option>
              <option value="Suspended">الموقوفين</option>
            </select>
          </div>

          {/* Add Student Button */}
          <button
            onClick={() => setIsAddModalOpen(true)}
            className="flex items-center gap-2 px-4 py-2 bg-blue-600 hover:bg-blue-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-blue-600/30 transition-all cursor-pointer"
          >
            <UserPlus className="w-4 h-4" />
            <span>تسجيل طالب جديد</span>
          </button>
        </div>
      </div>

      {/* Grid */}
      <ModernDataGrid
        id="students-grid"
        data={filteredStudents}
        columns={columns}
        searchPlaceholder="بحث بالاسم، الرقم الأكاديمي، أو رقم الهوية..."
        searchFields={['fullName', 'studentNumber', 'nationalId', 'className']}
        onRowClick={(student) => setProfileStudent(student)}
        exportFileName="Students_Export_Edura"
        pageSize={8}
      />

      {/* Modals */}
      <AddStudentModal
        isOpen={isAddModalOpen}
        onClose={() => setIsAddModalOpen(false)}
        onAddStudent={onAddStudent}
        classesList={classesList}
      />

      <StudentProfileModal
        student={profileStudent}
        onClose={() => setProfileStudent(null)}
        grades={grades}
        attendance={attendance}
        invoices={invoices}
      />

      <ConfirmDialog
        isOpen={studentToDelete !== null}
        title="تأكيد حذف قيد الطالب"
        message={`هل أنت متأكد من رغبتك في حذف سجل الطالب "${studentToDelete?.fullName}"؟ سيتم تعطيل حسابه (Soft Delete) وحفظ العملية في سجل التدقيق Audit Log.`}
        confirmText="نعم، احذف الطالب"
        cancelText="تراجع"
        type="danger"
        onConfirm={() => {
          if (studentToDelete) {
            onDeleteStudent(studentToDelete.id);
            setStudentToDelete(null);
          }
        }}
        onCancel={() => setStudentToDelete(null)}
      />
    </div>
  );
};
