import React, { useState } from 'react';
import {
  Users,
  UserPlus,
  BookOpen,
  Phone,
  Mail,
  Award,
  Calendar,
  Briefcase,
  Trash2,
  Edit,
  Plus
} from 'lucide-react';
import { Teacher } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface TeachersTabProps {
  teachers: Teacher[];
  onAddTeacher: (teacher: Omit<Teacher, 'id'>) => void;
}

export const TeachersTab: React.FC<TeachersTabProps> = ({ teachers, onAddTeacher }) => {
  const [isAddOpen, setIsAddOpen] = useState(false);
  const [fullName, setFullName] = useState('');
  const [specialization, setSpecialization] = useState('');
  const [academicDegree, setAcademicDegree] = useState('بكالوريوس تربوي');
  const [phone, setPhone] = useState('05');
  const [email, setEmail] = useState('');
  const [experience, setExperience] = useState(5);
  const [salary, setSalary] = useState(11000);

  const handleCreateTeacher = (e: React.FormEvent) => {
    e.preventDefault();
    if (!fullName.trim() || !specialization.trim()) return;

    const empNum = `EMP-${Math.floor(1000 + Math.random() * 9000)}`;
    onAddTeacher({
      employeeNumber: empNum,
      fullName: fullName.trim(),
      specialization: specialization.trim(),
      academicDegree,
      phone,
      email: email.trim() || `${empNum.toLowerCase()}@alruwad.edu.sa`,
      assignedSubjects: [specialization.trim()],
      assignedClasses: ['الصف الأول المتوسط'],
      yearsOfExperience: Number(experience),
      basicSalary: Number(salary),
      allowances: 1200,
      status: 'Active'
    });

    setFullName('');
    setSpecialization('');
    setIsAddOpen(false);
  };

  const columns: Column<Teacher>[] = [
    {
      key: 'employeeNumber',
      header: 'الرقم الوظيفي',
      width: '120px',
      sortable: true,
      render: (t) => (
        <span className="font-mono text-xs font-bold text-indigo-400 bg-indigo-950/60 px-2 py-0.5 rounded border border-indigo-900/60">
          {t.employeeNumber}
        </span>
      )
    },
    {
      key: 'fullName',
      header: 'اسم المعلم / الكادر',
      sortable: true,
      render: (t) => (
        <div className="flex items-center gap-2.5">
          <div className="w-8 h-8 rounded-xl bg-indigo-600/30 border border-indigo-500/40 text-indigo-300 font-bold flex items-center justify-center text-xs">
            {t.fullName[2] || t.fullName[0]}
          </div>
          <div>
            <div className="font-bold text-slate-100">{t.fullName}</div>
            <div className="text-[11px] text-slate-400">{t.academicDegree}</div>
          </div>
        </div>
      )
    },
    {
      key: 'specialization',
      header: 'التخصص والمواد المسندة',
      sortable: true,
      render: (t) => (
        <div>
          <div className="text-xs font-semibold text-slate-200">{t.specialization}</div>
          <div className="flex flex-wrap gap-1 mt-1">
            {t.assignedSubjects.map((s, i) => (
              <span key={i} className="text-[10px] bg-slate-800 text-slate-300 px-1.5 py-0.2 rounded border border-slate-700">
                {s}
              </span>
            ))}
          </div>
        </div>
      )
    },
    {
      key: 'phone',
      header: 'التواصل',
      render: (t) => (
        <div className="text-xs space-y-0.5 font-mono">
          <div className="flex items-center gap-1 text-slate-300">
            <Phone className="w-3 h-3 text-slate-500" />
            <span>{t.phone}</span>
          </div>
          <div className="flex items-center gap-1 text-[11px] text-slate-400">
            <Mail className="w-3 h-3 text-slate-500" />
            <span>{t.email}</span>
          </div>
        </div>
      )
    },
    {
      key: 'yearsOfExperience',
      header: 'الخبرة',
      sortable: true,
      width: '90px',
      render: (t) => (
        <span className="font-mono text-xs text-slate-300 font-bold">
          {t.yearsOfExperience} سنوات
        </span>
      )
    },
    {
      key: 'basicSalary',
      header: 'الراتب الإجمالي',
      sortable: true,
      render: (t) => (
        <span className="font-mono text-xs font-bold text-emerald-400">
          {(t.basicSalary + t.allowances).toLocaleString()} ر.س
        </span>
      )
    },
    {
      key: 'status',
      header: 'الحالة',
      width: '90px',
      render: (t) => (
        <span className="text-[11px] font-bold px-2 py-0.5 rounded-full bg-emerald-950 text-emerald-300 border border-emerald-800">
          نشط
        </span>
      )
    }
  ];

  return (
    <div className="p-6 space-y-4 max-w-7xl mx-auto">
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-indigo-600/20 border border-indigo-500/40 rounded-xl text-indigo-400">
            <Users className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">إدارة المعلمين والكادر الأكاديمي (Faculty & Staff)</h2>
            <p className="text-xs text-slate-400">
              سجلات المعلمين، التخصصات، الجداول الدراسية، والرواتب
            </p>
          </div>
        </div>

        <button
          onClick={() => setIsAddOpen(true)}
          className="flex items-center gap-2 px-4 py-2 bg-indigo-600 hover:bg-indigo-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-indigo-600/30 transition-all cursor-pointer"
        >
          <UserPlus className="w-4 h-4" />
          <span>إضافة معلم جديد</span>
        </button>
      </div>

      <ModernDataGrid
        id="teachers-grid"
        data={teachers}
        columns={columns}
        searchPlaceholder="بحث باسم المعلم، التخصص، أو الرقم الوظيفي..."
        searchFields={['fullName', 'specialization', 'employeeNumber', 'phone']}
        exportFileName="Teachers_Export_Edura"
      />

      {/* Add Teacher Modal */}
      {isAddOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-lg w-full p-6 shadow-2xl space-y-4">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2">
              إضافة وتعيين معلم جديد
            </h3>
            <form onSubmit={handleCreateTeacher} className="space-y-3 text-xs">
              <div>
                <label className="block text-slate-300 font-semibold mb-1">اسم المعلم كاملاً *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: أ. عبد الله خالد التميمي"
                  value={fullName}
                  onChange={(e) => setFullName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white focus:outline-none focus:border-indigo-500"
                />
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">التخصص الأكاديمي *</label>
                  <input
                    type="text"
                    required
                    placeholder="مثال: الكيمياء العضوية"
                    value={specialization}
                    onChange={(e) => setSpecialization(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white focus:outline-none focus:border-indigo-500"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">المؤهل العلمي</label>
                  <select
                    value={academicDegree}
                    onChange={(e) => setAcademicDegree(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white focus:outline-none focus:border-indigo-500"
                  >
                    <option value="بكالوريوس تربوي">بكالوريوس تربوي</option>
                    <option value="ماجستير">ماجستير</option>
                    <option value="دكتوراه">دكتوراه</option>
                  </select>
                </div>
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">رقم الهاتف</label>
                  <input
                    type="tel"
                    value={phone}
                    onChange={(e) => setPhone(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">سنوات الخبرة</label>
                  <input
                    type="number"
                    value={experience}
                    onChange={(e) => setExperience(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">الراتب الأساسي (ر.س)</label>
                <input
                  type="number"
                  value={salary}
                  onChange={(e) => setSalary(Number(e.target.value))}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                />
              </div>

              <div className="flex items-center justify-end gap-2 pt-2 border-t border-slate-800">
                <button
                  type="button"
                  onClick={() => setIsAddOpen(false)}
                  className="px-4 py-2 bg-slate-800 hover:bg-slate-700 text-slate-300 rounded-xl"
                >
                  إلغاء
                </button>
                <button
                  type="submit"
                  className="px-5 py-2 bg-indigo-600 hover:bg-indigo-500 text-white font-bold rounded-xl shadow-lg"
                >
                  حفظ المعلم
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
