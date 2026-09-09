import React, { useState } from 'react';
import {
  School,
  Lock,
  User,
  Eye,
  EyeOff,
  AlertCircle,
  CheckCircle2,
  ShieldCheck,
  KeyRound,
  ShieldAlert,
  HelpCircle
} from 'lucide-react';
import { UserAccount, SchoolSettings } from '../../types';

interface LoginScreenProps {
  users: UserAccount[];
  settings: SchoolSettings;
  onLoginSuccess: (user: UserAccount) => void;
}

export const LoginScreen: React.FC<LoginScreenProps> = ({
  users,
  settings,
  onLoginSuccess
}) => {
  const [username, setUsername] = useState('admin');
  const [password, setPassword] = useState('admin123');
  const [showPassword, setShowPassword] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [isBlockedError, setIsBlockedError] = useState<{ isBlocked: boolean; reason?: string } | null>(null);
  const [rememberMe, setRememberMe] = useState(true);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);
    setIsBlockedError(null);

    const user = users.find(
      (u) => u.username.toLowerCase() === username.trim().toLowerCase()
    );

    if (!user) {
      setError('اسم المستخدم غير صحيح أو غير مسجل بالنظام.');
      return;
    }

    // Check if password matches
    if (user.password && user.password !== password) {
      setError('كلمة المرور غير صحيحة. يرجى إعادة المحاولة.');
      return;
    }

    // Check if blocked or inactive
    if (user.isBlocked || !user.isActive) {
      setIsBlockedError({
        isBlocked: true,
        reason: user.blockReason || 'الحساب معطل إدارياً بأمر مدير النظام.'
      });
      return;
    }

    // Success
    onLoginSuccess(user);
  };

  const handleQuickSelectUser = (u: UserAccount) => {
    setUsername(u.username);
    setPassword(u.password || 'password123');
    setError(null);
    setIsBlockedError(null);
  };

  return (
    <div className="fixed inset-0 z-50 bg-slate-950 flex items-center justify-center p-4 overflow-y-auto font-['Cairo',sans-serif]">
      {/* Background Aesthetic Grid Pattern */}
      <div className="absolute inset-0 bg-[linear-gradient(to_right,#1e293b15_1px,transparent_1px),linear-gradient(to_bottom,#1e293b15_1px,transparent_1px)] bg-[size:4rem_4rem] [mask-image:radial-gradient(ellipse_60%_50%_at_50%_50%,#000_70%,transparent_100%)] pointer-events-none" />

      <div className="relative w-full max-w-md bg-slate-900/90 border border-slate-800 rounded-3xl p-8 shadow-2xl backdrop-blur-xl space-y-6">
        {/* Brand Header */}
        <div className="text-center space-y-2">
          <div className="inline-flex items-center justify-center w-16 h-16 rounded-2xl bg-gradient-to-tr from-blue-600 to-indigo-500 text-white shadow-xl shadow-blue-600/30 mb-2">
            <School className="w-8 h-8" />
          </div>
          <h2 className="text-xl font-black text-white">{settings.schoolName}</h2>
          <p className="text-xs text-slate-400">
            بوابة تسجيل الدخول الآمنة | نظام إدارتي Enterprise v2.6
          </p>
        </div>

        {/* Error Alert */}
        {error && (
          <div className="p-3 bg-rose-500/10 border border-rose-500/30 rounded-xl flex items-start gap-2.5 text-xs text-rose-400 animate-in fade-in">
            <AlertCircle className="w-4 h-4 shrink-0 mt-0.5" />
            <span>{error}</span>
          </div>
        )}

        {/* Blocked Account Notice */}
        {isBlockedError && (
          <div className="p-4 bg-amber-500/10 border border-amber-500/40 rounded-2xl space-y-2 text-xs text-amber-300 animate-in fade-in">
            <div className="flex items-center gap-2 font-bold text-amber-200">
              <ShieldAlert className="w-5 h-5 text-amber-400" />
              <span>الحساب محظور من الدخول بأمر الإدارة</span>
            </div>
            <p className="text-slate-300 text-[11px] leading-relaxed">
              {isBlockedError.reason}
            </p>
            <div className="text-[10px] text-amber-400/80 bg-amber-950/40 p-2 rounded-lg border border-amber-800/40">
              ملاحظة أمنية: لا يحق للمدير الاطلاع على كلمة مرورك، ولكن يحق له حظر الدخول.
            </div>
          </div>
        )}

        {/* Form */}
        <form onSubmit={handleSubmit} className="space-y-4 text-xs">
          <div>
            <label className="block text-slate-300 font-semibold mb-1.5 text-right">
              اسم المستخدم (Username)
            </label>
            <div className="relative">
              <input
                type="text"
                required
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                placeholder="أدخل اسم المستخدم..."
                className="w-full bg-slate-950 border border-slate-800 rounded-xl px-4 py-3 pl-10 text-white placeholder:text-slate-600 focus:outline-none focus:border-blue-500 transition-colors text-right"
              />
              <User className="w-4 h-4 text-slate-500 absolute left-3.5 top-3.5" />
            </div>
          </div>

          <div>
            <label className="block text-slate-300 font-semibold mb-1.5 text-right">
              كلمة المرور (Password)
            </label>
            <div className="relative">
              <input
                type={showPassword ? 'text' : 'password'}
                required
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                placeholder="أدخل كلمة المرور..."
                className="w-full bg-slate-950 border border-slate-800 rounded-xl px-4 py-3 pl-10 text-white placeholder:text-slate-600 focus:outline-none focus:border-blue-500 transition-colors text-right font-mono"
              />
              <button
                type="button"
                onClick={() => setShowPassword(!showPassword)}
                className="absolute left-3.5 top-3.5 text-slate-500 hover:text-slate-300 cursor-pointer"
              >
                {showPassword ? <EyeOff className="w-4 h-4" /> : <Eye className="w-4 h-4" />}
              </button>
            </div>
          </div>

          <div className="flex items-center justify-between text-[11px] text-slate-400">
            <label className="flex items-center gap-2 cursor-pointer">
              <input
                type="checkbox"
                checked={rememberMe}
                onChange={(e) => setRememberMe(e.target.checked)}
                className="rounded border-slate-700 bg-slate-950 text-blue-600 focus:ring-0"
              />
              <span>تذكر بيانات الدخول</span>
            </label>

            <span className="text-slate-500">حماية مشفرة عبر SQL Server</span>
          </div>

          <button
            type="submit"
            className="w-full py-3 bg-blue-600 hover:bg-blue-500 text-white font-bold rounded-xl shadow-lg shadow-blue-600/30 transition-all cursor-pointer flex items-center justify-center gap-2"
          >
            <KeyRound className="w-4 h-4" />
            <span>تسجيل الدخول إلى النظام</span>
          </button>
        </form>

        {/* Quick Demo Switcher */}
        <div className="pt-4 border-t border-slate-800/80 space-y-2.5">
          <div className="flex items-center justify-between text-[11px] text-slate-400 font-semibold">
            <span>تسجيل دخول سريع للتجربة:</span>
            <span className="text-[10px] text-blue-400 font-mono">Fast Switch</span>
          </div>

          <div className="grid grid-cols-2 gap-2">
            {users.map((u) => (
              <button
                key={u.id}
                type="button"
                onClick={() => handleQuickSelectUser(u)}
                className={`p-2 rounded-xl text-right transition-all text-[11px] cursor-pointer border ${
                  username === u.username
                    ? 'bg-blue-600/20 border-blue-500/50 text-blue-200'
                    : u.isBlocked
                    ? 'bg-amber-950/20 border-amber-800/30 text-amber-300'
                    : 'bg-slate-950/60 border-slate-800 hover:border-slate-700 text-slate-300'
                }`}
              >
                <div className="font-bold truncate">{u.fullName}</div>
                <div className="text-[9px] text-slate-500 flex items-center justify-between">
                  <span>{u.role.split(' ')[0]}</span>
                  {u.isBlocked ? (
                    <span className="text-amber-400 font-mono">محظور</span>
                  ) : (
                    <span className="text-emerald-400 font-mono">نشط</span>
                  )}
                </div>
              </button>
            ))}
          </div>
        </div>
      </div>
    </div>
  );
};
