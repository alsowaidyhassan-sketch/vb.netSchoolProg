import React, { useState } from 'react';
import {
  DatabaseBackup,
  AlertTriangle,
  CheckCircle2,
  X,
  LogOut,
  ShieldCheck,
  HardDrive
} from 'lucide-react';

interface ExitBackupModalProps {
  isOpen: boolean;
  onClose: () => void;
  onConfirmExitWithBackup: () => void;
  onConfirmExitWithoutBackup: () => void;
}

export const ExitBackupModal: React.FC<ExitBackupModalProps> = ({
  isOpen,
  onClose,
  onConfirmExitWithBackup,
  onConfirmExitWithoutBackup
}) => {
  const [isBackingUp, setIsBackingUp] = useState(false);

  if (!isOpen) return null;

  const handleBackupAndExit = () => {
    setIsBackingUp(true);
    setTimeout(() => {
      setIsBackingUp(false);
      onConfirmExitWithBackup();
    }, 1200);
  };

  return (
    <div className="fixed inset-0 z-50 bg-slate-950/85 backdrop-blur-md flex items-center justify-center p-4 font-['Cairo',sans-serif]">
      <div className="w-full max-w-lg bg-slate-900 border border-slate-800 rounded-3xl p-6 shadow-2xl space-y-5 animate-in zoom-in-95">
        {/* Header Icon */}
        <div className="flex items-center justify-between pb-3 border-b border-slate-800">
          <div className="flex items-center gap-3">
            <div className="p-3 bg-amber-500/20 text-amber-400 rounded-2xl border border-amber-500/30">
              <DatabaseBackup className="w-6 h-6" />
            </div>
            <div>
              <h3 className="text-base font-bold text-white">تأكيد الخروج من البرنامج</h3>
              <p className="text-xs text-slate-400">حماية البيانات والنسخ الاحتياطي التلقائي</p>
            </div>
          </div>
          <button
            onClick={onClose}
            className="p-1.5 hover:bg-slate-800 text-slate-400 hover:text-white rounded-lg transition-colors cursor-pointer"
          >
            <X className="w-4 h-4" />
          </button>
        </div>

        {/* Content Question */}
        <div className="space-y-2 text-xs">
          <p className="text-slate-200 text-sm font-semibold leading-relaxed">
            هل ترغب في أخذ نسخة احتياطية لقاعدة البيانات قبل إغلاق النظام؟
          </p>
          <p className="text-slate-400 leading-relaxed">
            يوصى دائماً بحفظ نسخة احتياطية محدثة لضمان أمان العمليات والقيود المالية ورصد الحضور والغياب المسجلة خلال الجلسة الحالية.
          </p>
        </div>

        {/* Backup Target Location Info */}
        <div className="p-3 bg-slate-950 rounded-xl border border-slate-800 flex items-center gap-2.5 text-xs text-slate-400 font-mono">
          <HardDrive className="w-4 h-4 text-emerald-400 shrink-0" />
          <span className="truncate">المسار: D:\SQL_Backups\EduraSchoolDB_AutoExit_{new Date().toISOString().slice(0, 10)}.bak</span>
        </div>

        {/* Action Buttons */}
        <div className="space-y-2 pt-2">
          <button
            disabled={isBackingUp}
            onClick={handleBackupAndExit}
            className="w-full py-3 bg-gradient-to-r from-emerald-600 to-teal-600 hover:from-emerald-500 hover:to-teal-500 text-white font-bold rounded-xl shadow-lg shadow-emerald-600/30 transition-all cursor-pointer flex items-center justify-center gap-2 text-xs disabled:opacity-50"
          >
            <DatabaseBackup className={`w-4 h-4 ${isBackingUp ? 'animate-spin' : ''}`} />
            <span>{isBackingUp ? 'جاري أخذ النسخة الاحتياطية وإغلاق الجلسة...' : 'نعم، خذ نسخة احتياطية واخرج الآن'}</span>
          </button>

          <div className="grid grid-cols-2 gap-2">
            <button
              disabled={isBackingUp}
              onClick={onConfirmExitWithoutBackup}
              className="py-2.5 bg-slate-800 hover:bg-rose-950/40 text-slate-300 hover:text-rose-300 border border-slate-700 hover:border-rose-800/40 font-bold rounded-xl text-xs transition-colors cursor-pointer flex items-center justify-center gap-1.5"
            >
              <LogOut className="w-3.5 h-3.5" />
              <span>خروج بدون نسخ</span>
            </button>

            <button
              disabled={isBackingUp}
              onClick={onClose}
              className="py-2.5 bg-slate-800 hover:bg-slate-700 text-slate-300 font-bold rounded-xl text-xs transition-colors cursor-pointer"
            >
              إلغاء الأمر والعودة
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
