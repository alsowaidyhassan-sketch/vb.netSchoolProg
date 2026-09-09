import React, { useState } from 'react';
import {
  Database,
  Download,
  RotateCcw,
  CheckCircle2,
  Clock,
  HardDrive,
  ShieldAlert,
  Calendar,
  Play,
  FileCode
} from 'lucide-react';
import { BackupRecord } from '../../types';
import { ConfirmDialog } from '../common/ConfirmDialog';

interface BackupTabProps {
  backups: BackupRecord[];
  onTriggerBackup: () => void;
}

export const BackupTab: React.FC<BackupTabProps> = ({ backups, onTriggerBackup }) => {
  const [isBackingUp, setIsBackingUp] = useState(false);
  const [restoreModalBackup, setRestoreModalBackup] = useState<BackupRecord | null>(null);
  const [restoreSuccess, setRestoreSuccess] = useState(false);

  const handleCreateBackup = () => {
    setIsBackingUp(true);
    setTimeout(() => {
      onTriggerBackup();
      setIsBackingUp(false);
    }, 1500);
  };

  const handleConfirmRestore = () => {
    if (!restoreModalBackup) return;
    setRestoreSuccess(true);
    setRestoreModalBackup(null);
    setTimeout(() => setRestoreSuccess(false), 3000);
  };

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-purple-600/20 border border-purple-500/40 rounded-xl text-purple-400">
            <Database className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">النسخ الاحتياطي واستعادة قاعدة البيانات (SQL Server Backup & Restore)</h2>
            <p className="text-xs text-slate-400">
              إدارة ملفات .BAK، النسخ الاحتياطي التلقائي والمضغوط، واستعادة نقطة زمنية محددة
            </p>
          </div>
        </div>

        <button
          onClick={handleCreateBackup}
          disabled={isBackingUp}
          className="flex items-center gap-2 px-5 py-2 bg-purple-600 hover:bg-purple-500 disabled:opacity-50 text-white text-xs font-bold rounded-xl shadow-lg shadow-purple-600/30 transition-all cursor-pointer"
        >
          <Play className={`w-4 h-4 ${isBackingUp ? 'animate-spin' : ''}`} />
          <span>{isBackingUp ? 'جاري إنشاء النسخة الاحتياطية...' : 'إنشاء نسخة احتياطية فورية الآن (.bak)'}</span>
        </button>
      </div>

      {/* Backup Automation Status Card */}
      <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
        <div className="p-5 bg-slate-900 border border-slate-800 rounded-2xl space-y-2">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-400">الجدولة اليومية التلقائية</span>
            <span className="text-[10px] font-bold px-2 py-0.5 rounded-full bg-emerald-950 text-emerald-300 border border-emerald-800">
              مفعلة (Active)
            </span>
          </div>
          <div className="text-sm font-bold text-white">يومياً عند الساعة 02:00 صباحاً</div>
          <p className="text-[11px] text-slate-500">يتم ضغط ملف النسخة الاحتياطية تلقائياً وحفظه في مسار آمن</p>
        </div>

        <div className="p-5 bg-slate-900 border border-slate-800 rounded-2xl space-y-2">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-400">مدة الاحتفاظ (Retention Policy)</span>
            <Calendar className="w-4 h-4 text-purple-400" />
          </div>
          <div className="text-sm font-bold text-white">30 يوماً متتالية</div>
          <p className="text-[11px] text-slate-500">حذف النسخ القديمة بعد شهر لتوفير المساحة التخزينية</p>
        </div>

        <div className="p-5 bg-slate-900 border border-slate-800 rounded-2xl space-y-2">
          <div className="flex items-center justify-between">
            <span className="text-xs font-bold text-slate-400">مسار الحفظ المحلي للخادم</span>
            <HardDrive className="w-4 h-4 text-blue-400" />
          </div>
          <div className="text-xs font-mono font-bold text-blue-400 truncate">
            D:\SQL_Backups\SchoolDB\
          </div>
          <p className="text-[11px] text-slate-500">موصول مع خادم تخزين سحابي إضافي خارجي</p>
        </div>
      </div>

      {/* Backups List */}
      <div className="bg-slate-900 border border-slate-800 rounded-2xl overflow-hidden shadow-xl">
        <div className="p-4 bg-slate-950/70 border-b border-slate-800 flex items-center justify-between">
          <span className="text-xs font-bold text-slate-200">سجل ملفات النسخ الاحتياطي المتوفرة</span>
          <span className="text-xs font-mono text-slate-400">{backups.length} ملفات .bak</span>
        </div>

        <div className="divide-y divide-slate-800">
          {backups.map((b) => (
            <div
              key={b.id}
              className="p-4 flex flex-wrap items-center justify-between gap-4 hover:bg-slate-850/50 transition-colors"
            >
              <div className="flex items-center gap-3">
                <div className="p-2.5 rounded-xl bg-purple-600/20 border border-purple-500/30 text-purple-400">
                  <Database className="w-5 h-5" />
                </div>
                <div>
                  <div className="font-mono text-xs font-bold text-slate-100">{b.fileName}</div>
                  <div className="text-[11px] text-slate-400 font-mono flex items-center gap-2 mt-0.5">
                    <span>{b.timestamp}</span>
                    <span>•</span>
                    <span className="text-purple-300 font-bold">{b.fileSize}</span>
                    <span>•</span>
                    <span>المستخدم: {b.createdBy}</span>
                  </div>
                </div>
              </div>

              <div className="flex items-center gap-2">
                <span className="text-[10px] font-bold px-2 py-0.5 rounded-full bg-emerald-950 text-emerald-300 border border-emerald-800">
                  {b.status === 'Success' ? 'مكتمل وناجح 100%' : b.status}
                </span>

                <button
                  onClick={() => setRestoreModalBackup(b)}
                  className="flex items-center gap-1 px-3 py-1.5 bg-slate-800 hover:bg-slate-700 text-amber-300 text-xs font-bold rounded-xl border border-slate-700 transition-colors cursor-pointer"
                  title="استعادة قاعدة البيانات من هذا الملف"
                >
                  <RotateCcw className="w-3.5 h-3.5" />
                  <span>استعادة</span>
                </button>
              </div>
            </div>
          ))}
        </div>
      </div>

      {/* SQL Script Box */}
      <div className="bg-slate-950 border border-slate-800 rounded-2xl p-5 space-y-2">
        <div className="flex items-center justify-between">
          <div className="flex items-center gap-2 text-xs font-bold text-slate-300">
            <FileCode className="w-4 h-4 text-purple-400" />
            <span>كود T-SQL المولد للنسخ الاحتياطي في SQL Server Management Studio (SSMS)</span>
          </div>
          <button
            onClick={() => alert('تم نسخ كود T-SQL إلى الحافظة')}
            className="text-xs text-blue-400 hover:text-blue-300 font-bold cursor-pointer"
          >
            نسخ الكود
          </button>
        </div>
        <pre className="p-3 bg-slate-900/90 rounded-xl font-mono text-[11px] text-emerald-400 overflow-x-auto border border-slate-800/80">
{`-- SQL Server Native Backup Command with COMPRESSION & CHECKSUM
BACKUP DATABASE [SchoolManagementDB]
TO DISK = N'D:\\SQL_Backups\\SchoolDB\\SchoolDB_Full_${new Date().toISOString().slice(0, 10)}.bak'
WITH FORMAT, INIT,
NAME = N'SchoolManagementDB-Full Database Backup',
SKIP, NOREWIND, NOUNLOAD, COMPRESSION, CHECKSUM, STATS = 10;
GO`}
        </pre>
      </div>

      {restoreSuccess && (
        <div className="fixed bottom-12 left-1/2 -translate-x-1/2 bg-emerald-600 text-white px-5 py-2.5 rounded-xl shadow-2xl flex items-center gap-2 text-xs font-bold z-50">
          <CheckCircle2 className="w-4 h-4" />
          <span>تمت عملية استعادة قاعدة البيانات بنجاح والتحقق من سلامة الجداول!</span>
        </div>
      )}

      {/* Confirm Restore Dialog */}
      <ConfirmDialog
        isOpen={restoreModalBackup !== null}
        title="تأكيد استعادة قاعدة البيانات (Database Restore)"
        message={`تحذير أمني: أنت على وشك استعادة قاعدة البيانات من النسخة "${restoreModalBackup?.fileName}". سيتم إرجاع جميع البيانات إلى تاريخ وتوقيت إنشاء هذه النسخة. هل تريد المتابعة؟`}
        confirmText="نعم، قم باستعادة النسخة"
        cancelText="إلغاء الأمر"
        type="danger"
        onConfirm={handleConfirmRestore}
        onCancel={() => setRestoreModalBackup(null)}
      />
    </div>
  );
};
