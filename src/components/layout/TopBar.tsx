import React, { useState } from 'react';
import {
  Search,
  Save,
  RotateCw,
  Bell,
  Sun,
  Moon,
  User,
  LogOut,
  KeyRound,
  Check,
  Code2
} from 'lucide-react';
import { ModuleKey } from '../../types';

interface TopBarProps {
  onOpenTab: (key: ModuleKey) => void;
  onRefreshCurrentTab: () => void;
  onSaveCurrentState: () => void;
  unreadNotificationsCount: number;
  onToggleNotifications: () => void;
  theme: 'dark' | 'light';
  onToggleTheme: () => void;
  onLogout: () => void;
}

export const TopBar: React.FC<TopBarProps> = ({
  onOpenTab,
  onRefreshCurrentTab,
  onSaveCurrentState,
  unreadNotificationsCount,
  onToggleNotifications,
  theme,
  onToggleTheme,
  onLogout
}) => {
  const [searchQuery, setSearchQuery] = useState('');
  const [showUserMenu, setShowUserMenu] = useState(false);
  const [showSaveToast, setShowSaveToast] = useState(false);

  const handleGlobalSearch = (e: React.FormEvent) => {
    e.preventDefault();
    if (!searchQuery.trim()) return;
    const q = searchQuery.toLowerCase();
    if (q.includes('طالب') || q.includes('طلاب') || q.includes('سبيعي') || q.includes('سارة')) {
      onOpenTab('students');
    } else if (q.includes('معلم') || q.includes('مدرس') || q.includes('غامدي')) {
      onOpenTab('teachers');
    } else if (q.includes('حضور') || q.includes('غياب')) {
      onOpenTab('attendance');
    } else if (q.includes('رسم') || q.includes('رسوم') || q.includes('فاتورة') || q.includes('سند')) {
      onOpenTab('finance');
    } else if (q.includes('امتحان') || q.includes('درجة') || q.includes('شهادة')) {
      onOpenTab('exams');
    } else if (q.includes('نسخ') || q.includes('احتياط')) {
      onOpenTab('backup');
    } else if (q.includes('كود') || q.includes('vb') || q.includes('sql')) {
      onOpenTab('solution');
    } else {
      onOpenTab('students');
    }
  };

  const handleSave = () => {
    onSaveCurrentState();
    setShowSaveToast(true);
    setTimeout(() => setShowSaveToast(false), 2500);
  };

  return (
    <div
      id="desktop-topbar"
      className="h-14 bg-slate-900 border-b border-slate-800 px-4 flex items-center justify-between gap-4 z-30 shrink-0"
    >
      {/* Global Quick Search */}
      <form onSubmit={handleGlobalSearch} className="relative flex-1 max-w-md">
        <Search className="absolute right-3.5 top-2.5 w-4 h-4 text-slate-400" />
        <input
          type="text"
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          placeholder="بحث شامل: الطلاب، المعلمين، الرسوم، الفصول (اضغط Enter)..."
          className="w-full bg-slate-950/80 border border-slate-800 rounded-xl pr-10 pl-16 py-2 text-xs text-slate-100 placeholder-slate-500 focus:outline-none focus:border-blue-500 transition-colors"
        />
        <span className="absolute left-2.5 top-2 px-1.5 py-0.5 rounded bg-slate-800 text-[10px] text-slate-400 font-mono border border-slate-700/60">
          Ctrl + F
        </span>
      </form>

      {/* Quick Action Buttons */}
      <div className="flex items-center gap-2">
        {/* Solution Explorer Shortcut */}
        <button
          onClick={() => onOpenTab('solution')}
          className="flex items-center gap-1.5 px-3 py-1.5 bg-blue-950/60 hover:bg-blue-900/80 text-blue-300 text-xs font-semibold rounded-lg border border-blue-800/80 transition-all cursor-pointer shadow-xs"
          title="استعراض كود مشروع VB.NET وملفات SQL Server"
        >
          <Code2 className="w-4 h-4 text-blue-400" />
          <span className="hidden sm:inline">حزمة الكود & SQL</span>
        </button>

        {/* Instant Save */}
        <button
          onClick={handleSave}
          className="flex items-center gap-1.5 px-3 py-1.5 bg-emerald-950/60 hover:bg-emerald-900/80 text-emerald-300 text-xs font-semibold rounded-lg border border-emerald-800/80 transition-all cursor-pointer shadow-xs relative"
          title="حفظ التعديلات والتغييرات (Ctrl + S)"
        >
          <Save className="w-4 h-4 text-emerald-400" />
          <span className="hidden md:inline">حفظ فوري</span>
          <span className="hidden lg:inline text-[10px] font-mono text-emerald-500">Ctrl+S</span>
        </button>

        {/* Refresh Tab */}
        <button
          onClick={onRefreshCurrentTab}
          className="p-2 rounded-lg bg-slate-800 hover:bg-slate-700 text-slate-300 hover:text-white border border-slate-700 transition-colors cursor-pointer"
          title="تحديث الصفحة الحالية (F5)"
        >
          <RotateCw className="w-4 h-4" />
        </button>

        {/* Theme Toggle */}
        <button
          onClick={onToggleTheme}
          className="p-2 rounded-lg bg-slate-800 hover:bg-slate-700 text-slate-300 hover:text-white border border-slate-700 transition-colors cursor-pointer"
          title="تبديل المظهر (Dark / Light)"
        >
          {theme === 'dark' ? (
            <Sun className="w-4 h-4 text-amber-400" />
          ) : (
            <Moon className="w-4 h-4 text-blue-400" />
          )}
        </button>

        {/* Notifications Bell */}
        <button
          onClick={onToggleNotifications}
          className="p-2 rounded-lg bg-slate-800 hover:bg-slate-700 text-slate-300 hover:text-white border border-slate-700 transition-colors cursor-pointer relative"
          title="مركز الإشعارات والتنبيهات"
        >
          <Bell className="w-4 h-4" />
          {unreadNotificationsCount > 0 && (
            <span className="absolute -top-1 -right-1 w-4 h-4 bg-red-600 text-white rounded-full text-[10px] font-bold flex items-center justify-center animate-bounce">
              {unreadNotificationsCount}
            </span>
          )}
        </button>

        {/* User Profile & Menu */}
        <div className="relative">
          <button
            onClick={() => setShowUserMenu(!showUserMenu)}
            className="flex items-center gap-2 pr-2 pl-3 py-1.5 rounded-xl bg-slate-800/80 hover:bg-slate-700 border border-slate-700 transition-colors cursor-pointer"
          >
            <div className="w-7 h-7 rounded-lg bg-blue-600 flex items-center justify-center font-bold text-xs text-white">
              م
            </div>
            <div className="text-right hidden sm:block">
              <div className="text-xs font-bold text-slate-200">المهندس أحمد</div>
              <div className="text-[10px] text-slate-400">مدير النظام (admin)</div>
            </div>
          </button>

          {showUserMenu && (
            <div className="absolute left-0 mt-2 w-52 bg-slate-900 border border-slate-700 rounded-xl shadow-2xl p-1 z-50 animate-in fade-in slide-in-from-top-2 duration-150">
              <div className="px-3 py-2 border-b border-slate-800 text-xs">
                <div className="font-bold text-slate-200">م. أحمد المنصور</div>
                <div className="text-[11px] text-slate-400 font-mono">admin@eduraschool.edu.sa</div>
              </div>

              <button
                onClick={() => {
                  onOpenTab('users');
                  setShowUserMenu(false);
                }}
                className="w-full flex items-center gap-2 px-3 py-2 text-xs text-slate-300 hover:bg-slate-800 hover:text-white rounded-lg transition-colors text-right"
              >
                <KeyRound className="w-3.5 h-3.5 text-blue-400" />
                <span>إدارة الصلاحيات والمستخدمين</span>
              </button>

              <button
                onClick={() => {
                  onOpenTab('settings');
                  setShowUserMenu(false);
                }}
                className="w-full flex items-center gap-2 px-3 py-2 text-xs text-slate-300 hover:bg-slate-800 hover:text-white rounded-lg transition-colors text-right"
              >
                <User className="w-3.5 h-3.5 text-slate-400" />
                <span>الملف الشخصي والإعدادات</span>
              </button>

              <div className="border-t border-slate-800 my-1"></div>

              <button
                onClick={() => {
                  setShowUserMenu(false);
                  onLogout();
                }}
                className="w-full flex items-center gap-2 px-3 py-2 text-xs text-red-400 hover:bg-red-950/40 hover:text-red-300 rounded-lg transition-colors text-right font-semibold"
              >
                <LogOut className="w-3.5 h-3.5" />
                <span>تسجيل الخروج من الجلسة</span>
              </button>
            </div>
          )}
        </div>
      </div>

      {/* Save Success Toast */}
      {showSaveToast && (
        <div className="fixed bottom-10 left-1/2 -translate-x-1/2 bg-emerald-600 text-white px-4 py-2.5 rounded-xl shadow-2xl flex items-center gap-2 text-xs font-bold z-50 animate-in fade-in slide-in-from-bottom-3 duration-200">
          <Check className="w-4 h-4" />
          <span>تم حفظ كافة التعديلات بنجاح في قاعدة البيانات (SQL Server)!</span>
        </div>
      )}
    </div>
  );
};
