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
  ShieldAlert,
  ShieldCheck,
  Ban,
  UserCheck,
  AlertTriangle
} from 'lucide-react';
import { SystemUser } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface SecurityTabProps {
  users: SystemUser[];
  onAddUser: (user: Omit<SystemUser, 'id'>) => void;
  onToggleUserStatus: (id: number) => void;
  onToggleUserBlock?: (id: number, reason?: string) => void;
  onOpenChangePassword?: () => void;
}

export const SecurityTab: React.FC<SecurityTabProps> = ({
  users,
  onAddUser,
  onToggleUserStatus,
  onToggleUserBlock,
  onOpenChangePassword
}) => {
  const [isOpen, setIsOpen] = useState(false);
  const [blockModalUser, setBlockModalUser] = useState<SystemUser | null>(null);
  const [blockReason, setBlockReason] = useState('مخالفة السياسات الأمنية أو تعليق مؤقت للدوام');
  const [username, setUsername] = useState('');
  const [fullName, setFullName] = useState('');
  const [email, setEmail] = useState('');
  const [role, setRole] = useState<'Admin' | 'Teacher' | 'Accountant' | 'Registrar'>('Registrar');
  const [initialTempPassword, setInitialTempPassword] = useState('Welcome@2026');

  const handleCreate = (e: React.FormEvent) => {
    e.preventDefault();
    if (!username.trim() || !fullName.trim()) return;

    onAddUser({
      username: username.trim(),
      fullName: fullName.trim(),
      email: email.trim() || `${username.trim()}@alruwad.edu.sa`,
      role,
      isActive: true,
      isBlocked: false,
      password: initialTempPassword,
      lastLogin: 'لم يدخل بعد'
    });

    setUsername('');
    setFullName('');
    setIsOpen(false);
  };

  const handleConfirmBlock = () => {
    if (blockModalUser && onToggleUserBlock) {
      onToggleUserBlock(blockModalUser.id, blockReason);
    } else if (blockModalUser) {
      onToggleUserStatus(blockModalUser.id);
    }
    setBlockModalUser(null);
  };

  const columns: Column<SystemUser>[] = [
    {
      key: 'username',
      header: 'اسم المستخدم',
      sortable: true,
      width: '140px',
      render: (u) => (
        <span className="font-mono text-xs font-bold text-blue-400 bg-blue-950/60 px-2.5 py-1 rounded-lg border border-blue-900/60">
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
          <div className="font-bold text-slate-100 flex items-center gap-2">
            <span>{u.fullName}</span>
            {u.isBlocked && (
              <span className="px-1.5 py-0.5 text-[10px] bg-rose-950 text-rose-300 rounded border border-rose-800">
                محظور
              </span>
            )}
          </div>
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
        if (u.role === 'Admin' || u.role.includes('Admin')) {
          badgeColor = 'bg-red-950 text-red-300 border-red-800';
          roleName = 'المدير العام (Super Admin)';
        } else if (u.role === 'Accountant' || u.role.includes('Accountant')) {
          badgeColor = 'bg-emerald-950 text-emerald-300 border-emerald-800';
          roleName = 'المحاسب المالي (Accountant)';
        } else if (u.role === 'Registrar' || u.role.includes('Reception')) {
          badgeColor = 'bg-sky-950 text-sky-300 border-sky-800';
          roleName = 'شؤون الطلاب والاستقبال';
        } else if (u.role === 'Teacher' || u.role.includes('Teacher')) {
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
      header: 'إذن الدخول للنظام',
      render: (u) => {
        const isAllowed = u.isActive && !u.isBlocked;
        return (
          <div className="space-y-0.5">
            <span
              className={`inline-flex items-center gap-1 text-[11px] font-bold px-2.5 py-0.5 rounded-full border ${
                isAllowed
                  ? 'bg-emerald-950 text-emerald-300 border-emerald-800'
                  : 'bg-rose-950 text-rose-300 border-rose-800'
              }`}
            >
              {isAllowed ? <ShieldCheck className="w-3 h-3" /> : <Ban className="w-3 h-3" />}
              <span>{isAllowed ? 'مسموح بالدخول' : 'محظور من الدخول'}</span>
            </span>
            {u.blockReason && !isAllowed && (
              <div className="text-[10px] text-rose-400/80 truncate max-w-[150px]" title={u.blockReason}>
                {u.blockReason}
              </div>
            )}
          </div>
        );
      }
    },
    {
      key: 'actions',
      header: 'صلاحيات المدير (الحظر والإتاحة)',
      render: (u) => {
        const isAllowed = u.isActive && !u.isBlocked;
        return (
          <div className="flex items-center gap-2">
            {isAllowed ? (
              <button
                onClick={() => setBlockModalUser(u)}
                className="flex items-center gap-1.5 px-3 py-1.5 rounded-xl text-xs font-bold bg-rose-950/80 hover:bg-rose-900 text-rose-300 border border-rose-800 transition-colors cursor-pointer"
                title="منع المستخدم من تسجيل الدخول للنظام"
              >
                <Ban className="w-3.5 h-3.5" />
                <span>حظر من الدخول</span>
              </button>
            ) : (
              <button
                onClick={() => {
                  if (onToggleUserBlock) onToggleUserBlock(u.id);
                  else onToggleUserStatus(u.id);
                }}
                className="flex items-center gap-1.5 px-3 py-1.5 rounded-xl text-xs font-bold bg-emerald-950/80 hover:bg-emerald-900 text-emerald-300 border border-emerald-800 transition-colors cursor-pointer"
                title="إلغاء الحظر وتمكين المستخدم من الدخول"
              >
                <UserCheck className="w-3.5 h-3.5" />
                <span>إلغاء الحظر</span>
              </button>
            )}
          </div>
        );
      }
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
            <h2 className="text-lg font-bold text-white">إدارة الحسابات وضوابط الوصول (RBAC Security)</h2>
            <p className="text-xs text-slate-400">
              حظر ومنع المستخدمين من الدخول، إدارة الأدوار، وضمان خصوصية كلمات المرور
            </p>
          </div>
        </div>

        <div className="flex items-center gap-2">
          {onOpenChangePassword && (
            <button
              onClick={onOpenChangePassword}
              className="flex items-center gap-2 px-3.5 py-2 bg-slate-800 hover:bg-slate-700 text-slate-200 text-xs font-bold rounded-xl border border-slate-700 transition-all cursor-pointer"
            >
              <KeyRound className="w-4 h-4 text-blue-400" />
              <span>تغيير كلمة المرور الخاصة بي</span>
            </button>
          )}

          <button
            onClick={() => setIsOpen(true)}
            className="flex items-center gap-2 px-4 py-2 bg-red-600 hover:bg-red-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-red-600/30 transition-all cursor-pointer"
          >
            <UserPlus className="w-4 h-4" />
            <span>إنشاء مستخدم نظام جديد</span>
          </button>
        </div>
      </div>

      {/* Strict Privacy & Admin Rules Banner */}
      <div className="p-4 rounded-2xl bg-amber-950/20 border border-amber-800/40 flex items-start gap-3 text-xs text-amber-200">
        <ShieldAlert className="w-5 h-5 text-amber-400 shrink-0 mt-0.5" />
        <div className="space-y-1 leading-relaxed">
          <span className="font-bold text-amber-300">ميثاق الخصوصية والأمان الصارم:</span>
          <p className="text-slate-300 text-[11px]">
            وفقاً لضوابط الأمان المعتمدة، لا يحق لمدير النظام أو المشرف العام الاطلاع على كلمات مرور المستخدمين أو تعديلها من لوحة التحكم، حيث تُشفر كلمات المرور بنظام التجزئة الأحادي. يملك المدير حصرياً صلاحية <strong>منع المستخدم من دخول البرنامج (حظر الحساب)</strong> أو إلغاء الحظر، بينما يقوم كل مستخدم بتغيير كلمة المرور الخاصة به بنفسه.
          </p>
        </div>
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
                { module: 'الحضور والغياب والواتساب', admin: 'كامل (CRUD)', acc: 'محظور', reg: 'كامل (CRUD)', tea: 'رصد حصته فقط' },
                { module: 'المالية وسندات القبض', admin: 'كامل (CRUD)', acc: 'كامل (CRUD)', reg: 'محظور', tea: 'محظور' },
                { module: 'الموارد البشرية والرواتب', admin: 'كامل (CRUD)', acc: 'عرض الرواتب', reg: 'محظور', tea: 'محظور' },
                { module: 'النسخ الاحتياطي والترقيات', admin: 'كامل (Full)', acc: 'محظور', reg: 'محظور', tea: 'محظور' }
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

      {/* Block User Confirmation Dialog */}
      {blockModalUser && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/80 backdrop-blur-sm">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4 text-xs animate-in zoom-in-95">
            <div className="flex items-center gap-2.5 text-rose-400 font-bold border-b border-slate-800 pb-2.5">
              <Ban className="w-5 h-5" />
              <span>منع وحظر المستخدم من دخول البرنامج</span>
            </div>

            <div className="space-y-2">
              <p className="text-slate-200 leading-relaxed">
                هل أنت متأكد من رغبتك في حظر المستخدم <strong>{blockModalUser.fullName}</strong> ({blockModalUser.username}) من دخول البرنامج؟
              </p>
              <div>
                <label className="block text-slate-400 font-semibold mb-1">سبب الحظر (سيظهر للمستخدم عند محاولة الدخول):</label>
                <textarea
                  rows={3}
                  value={blockReason}
                  onChange={(e) => setBlockReason(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-xl p-2.5 text-white focus:outline-none focus:border-rose-500"
                />
              </div>
            </div>

            <div className="flex items-center justify-end gap-2 pt-2 border-t border-slate-800">
              <button
                type="button"
                onClick={() => setBlockModalUser(null)}
                className="px-4 py-2 bg-slate-800 text-slate-300 rounded-xl font-bold cursor-pointer"
              >
                إلغاء
              </button>
              <button
                type="button"
                onClick={handleConfirmBlock}
                className="px-5 py-2 bg-rose-600 hover:bg-rose-500 text-white font-bold rounded-xl cursor-pointer"
              >
                تأكيد الحظر الفوري
              </button>
            </div>
          </div>
        </div>
      )}

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
                  <option value="Registrar">شؤون الطلاب والاستقبال (Registrar)</option>
                  <option value="Accountant">المحاسب المالي (Accountant)</option>
                  <option value="Teacher">معلم (Teacher)</option>
                  <option value="Admin">المدير العام (Admin)</option>
                </select>
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">كلمة المرور الابتدائية المؤقتة</label>
                <input
                  type="text"
                  value={initialTempPassword}
                  onChange={(e) => setInitialTempPassword(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                />
                <div className="text-[10px] text-slate-500 mt-1">يُطلب من الموظف تغييرها عند تسجيل دخوله الأول للحفاظ على الخصوصية</div>
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
