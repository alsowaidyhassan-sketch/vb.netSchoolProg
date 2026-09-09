import React, { useState } from 'react';
import {
  Shield,
  UserPlus,
  KeyRound,
  Lock,
  Unlock,
  CheckCircle,
  XCircle,
  Eye,
  Edit,
  Trash2
} from 'lucide-react';
import { SystemUser } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface SecurityTabProps {
  users: SystemUser[];
  onAddUser: (user: Omit<SystemUser, 'id'>) => void;
  onToggleUserStatus: (id: number) => void;
}

export const SecurityTab: React.FC<SecurityTabProps> = ({
  users,
  onAddUser,
  onToggleUserStatus
}) => {
  const [isOpen, setIsOpen] = useState(false);
  const [username, setUsername] = useState('');
  const [fullName, setFullName] = useState('');
  const [email, setEmail] = useState('');
  const [role, setRole] = useState<'Admin' | 'Teacher' | 'Accountant' | 'Registrar'>('Registrar');
  const [password, setPassword] = useState('Password@123');

  const handleCreate = (e: React.FormEvent) => {
    e.preventDefault();
    if (!username.trim() || !fullName.trim()) return;

    onAddUser({
      username: username.trim(),
      fullName: fullName.trim(),
      email: email.trim() || `${username.trim()}@alruwad.edu.sa`,
      role,
      isActive: true,
      lastLogin: 'لم يدخل بعد'
    });

    setUsername('');
    setFullName('');
    setIsOpen(false);
  };

  const columns: Column<SystemUser>[] = [
    {
      key: 'username',
      header: 'اسم المستخدم',
      sortable: true,
      width: '140px',
      render: (u) => (
        <span className="font-mono text-xs font-bold text-blue-400 bg-blue-950/60 px-2 py-0.5 rounded border border-blue-900/60">
          {u.username}
        </span>
      )
    },
    {
      key: 'fullName',
      header: 'الاسم الحقيقي',
      sortable: true,
      render: (u) => (
        <div>
          <div className="font-bold text-slate-100">{u.fullName}</div>
          <div className="text-[11px] text-slate-400 font-mono">{u.email}</div>
        </div>
      )
    },
    {
      key: 'role',
      header: 'الدور والصلاحيات',
      sortable: true,
      render: (u) => {
        let badgeColor = 'bg-blue-950 text-blue-300 border-blue-800';
        let roleName = 'مستخدم';
        if (u.role === 'Admin') {
          badgeColor = 'bg-red-950 text-red-300 border-red-800';
          roleName = 'المدير العام (Super Admin)';
        } else if (u.role === 'Accountant') {
          badgeColor = 'bg-emerald-950 text-emerald-300 border-emerald-800';
          roleName = 'المحاسب المالي (Accountant)';
        } else if (u.role === 'Registrar') {
          badgeColor = 'bg-sky-950 text-sky-300 border-sky-800';
          roleName = 'وكيل شؤون الطلاب (Registrar)';
        } else if (u.role === 'Teacher') {
          badgeColor = 'bg-indigo-950 text-indigo-300 border-indigo-800';
          roleName = 'المعلم (Teacher)';
        }

        return (
          <span className={`text-[11px] font-bold px-2.5 py-0.5 rounded-full border ${badgeColor}`}>
            {roleName}
          </span>
        );
      }
    },
    {
      key: 'lastLogin',
      header: 'آخر تسجيل دخول',
      sortable: true,
      render: (u) => <span className="font-mono text-xs text-slate-400">{u.lastLogin}</span>
    },
    {
      key: 'isActive',
      header: 'حالة الحساب',
      render: (u) => (
        <span
          className={`text-[10px] font-bold px-2 py-0.5 rounded-full border ${
            u.isActive
              ? 'bg-emerald-950 text-emerald-300 border-emerald-800'
              : 'bg-rose-950 text-rose-300 border-rose-800'
          }`}
        >
          {u.isActive ? 'مفعل ومصرح' : 'معطل ومحظور'}
        </span>
      )
    },
    {
      key: 'actions',
      header: 'التحكم',
      render: (u) => (
        <button
          onClick={() => onToggleUserStatus(u.id)}
          className={`px-2.5 py-1 rounded-lg text-xs font-semibold transition-colors cursor-pointer ${
            u.isActive
              ? 'bg-rose-950 text-rose-300 hover:bg-rose-900 border border-rose-800'
              : 'bg-emerald-950 text-emerald-300 hover:bg-emerald-900 border border-emerald-800'
          }`}
        >
          {u.isActive ? 'تعطيل الحساب' : 'تنشيط الحساب'}
        </button>
      )
    }
  ];

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-red-600/20 border border-red-500/40 rounded-xl text-red-400">
            <Shield className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">إدارة الحسابات وصلاحيات الوصول (RBAC Security)</h2>
            <p className="text-xs text-slate-400">
              تشفير كلمات المرور بـ SHA-256 + Salt، إدارة أدوار المستخدمين، ومصفوفة الصلاحيات
            </p>
          </div>
        </div>

        <button
          onClick={() => setIsOpen(true)}
          className="flex items-center gap-2 px-4 py-2 bg-red-600 hover:bg-red-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-red-600/30 transition-all cursor-pointer"
        >
          <UserPlus className="w-4 h-4" />
          <span>إنشاء مستخدم نظام جديد</span>
        </button>
      </div>

      {/* Users Grid */}
      <ModernDataGrid
        id="users-grid"
        data={users}
        columns={columns}
        searchPlaceholder="بحث باسم المستخدم، الاسم الكامل، أو الدور..."
        searchFields={['username', 'fullName', 'email', 'role']}
        exportFileName="System_Users_Export_Edura"
      />

      {/* Permissions Matrix */}
      <div className="bg-slate-900 border border-slate-800 rounded-2xl p-6 shadow-xl space-y-4">
        <h3 className="text-sm font-bold text-white flex items-center gap-2">
          <KeyRound className="w-4 h-4 text-amber-400" />
          <span>مصفوفة الصلاحيات والأدوار المعتمدة (Permissions Matrix)</span>
        </h3>

        <div className="overflow-x-auto border border-slate-800 rounded-xl">
          <table className="w-full text-right text-xs">
            <thead className="bg-slate-950 text-slate-400 font-semibold">
              <tr>
                <th className="p-3">الوحدة البرمجية</th>
                <th className="p-3 text-center">المدير العام (Admin)</th>
                <th className="p-3 text-center">المحاسب المالي (Accountant)</th>
                <th className="p-3 text-center">شؤون الطلاب (Registrar)</th>
                <th className="p-3 text-center">المعلم (Teacher)</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-slate-800">
              {[
                { module: 'شؤون الطلاب والقيد', admin: 'كامل (CRUD)', acc: 'قراءة فقط', reg: 'كامل (CRUD)', tea: 'قراءة فقط' },
                { module: 'الدرجات والكنترول', admin: 'كامل (CRUD)', acc: 'محظور', reg: 'قراءة وطباعة', tea: 'رصد مادته فقط' },
                { module: 'الحضور والغياب', admin: 'كامل (CRUD)', acc: 'محظور', reg: 'كامل (CRUD)', tea: 'رصد حصته فقط' },
                { module: 'المالية وسندات القبض', admin: 'كامل (CRUD)', acc: 'كامل (CRUD)', reg: 'محظور', tea: 'محظور' },
                { module: 'الموارد البشرية والرواتب', admin: 'كامل (CRUD)', acc: 'عرض الرواتب', reg: 'محظور', tea: 'محظور' },
                { module: 'النسخ الاحتياطي والتدقيق', admin: 'كامل (Full)', acc: 'محظور', reg: 'محظور', tea: 'محظور' }
              ].map((row, i) => (
                <tr key={i} className="hover:bg-slate-850/50">
                  <td className="p-3 font-bold text-slate-200">{row.module}</td>
                  <td className="p-3 text-center font-semibold text-emerald-400">{row.admin}</td>
                  <td className="p-3 text-center text-slate-300">{row.acc}</td>
                  <td className="p-3 text-center text-slate-300">{row.reg}</td>
                  <td className="p-3 text-center text-slate-300">{row.tea}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      {/* Add User Modal */}
      {isOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4 text-xs">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2">
              إضافة مستخدم نظام جديد (Create User)
            </h3>
            <form onSubmit={handleCreate} className="space-y-3">
              <div>
                <label className="block text-slate-300 font-semibold mb-1">اسم الدخول (Username) *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: registrar_omar"
                  value={username}
                  onChange={(e) => setUsername(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                />
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">الاسم الحقيقي للموظف *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: أ. عمر بن عبد العزيز"
                  value={fullName}
                  onChange={(e) => setFullName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                />
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">الدور الوظيفي والصلاحيات *</label>
                <select
                  value={role}
                  onChange={(e: any) => setRole(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-bold"
                >
                  <option value="Registrar">وكيل شؤون الطلاب (Registrar)</option>
                  <option value="Accountant">المحاسب المالي (Accountant)</option>
                  <option value="Teacher">معلم (Teacher)</option>
                  <option value="Admin">المدير العام (Admin)</option>
                </select>
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">كلمة المرور الافتراضية</label>
                <input
                  type="text"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                />
                <div className="text-[10px] text-slate-500 mt-1">يتم تشفير كلمة المرور بـ SHA256 + Dynamic Salt في SQL Server</div>
              </div>

              <div className="flex items-center justify-end gap-2 pt-3 border-t border-slate-800">
                <button
                  type="button"
                  onClick={() => setIsOpen(false)}
                  className="px-4 py-2 bg-slate-800 text-slate-300 rounded-xl"
                >
                  إلغاء
                </button>
                <button
                  type="submit"
                  className="px-5 py-2 bg-red-600 hover:bg-red-500 text-white font-bold rounded-xl"
                >
                  حفظ وتفعيل الحساب
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
