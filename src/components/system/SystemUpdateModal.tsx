import React, { useState } from 'react';
import {
  RefreshCw,
  Download,
  Database,
  CheckCircle2,
  AlertCircle,
  Clock,
  Sparkles,
  Terminal,
  FileCode,
  ShieldCheck,
  X,
  ArrowRight
} from 'lucide-react';
import { SystemVersionInfo, PendingMigration } from '../../types';

interface SystemUpdateModalProps {
  isOpen: boolean;
  versionInfo: SystemVersionInfo;
  onClose: () => void;
  onApplyUpdate: (updatedInfo: SystemVersionInfo) => void;
}

export const SystemUpdateModal: React.FC<SystemUpdateModalProps> = ({
  isOpen,
  versionInfo,
  onClose,
  onApplyUpdate
}) => {
  const [isChecking, setIsChecking] = useState(false);
  const [isMigrating, setIsMigrating] = useState(false);
  const [migrationStep, setMigrationStep] = useState<string>('');
  const [migrationProgress, setMigrationProgress] = useState(0);
  const [showSqlPreview, setShowSqlPreview] = useState<string | null>(null);
  const [autoCheck, setAutoCheck] = useState(versionInfo.autoCheckUpdates);
  const [success, setSuccess] = useState(false);

  if (!isOpen) return null;

  const handleCheckUpdates = () => {
    setIsChecking(true);
    setTimeout(() => {
      setIsChecking(false);
    }, 1200);
  };

  const handleStartUpdateAndMigration = () => {
    setIsMigrating(true);
    setMigrationProgress(15);
    setMigrationStep('الخطوة 1/4: التحقق من سلامة الاتصال بقاعدة بيانات SQL Server...');

    setTimeout(() => {
      setMigrationProgress(40);
      setMigrationStep('الخطوة 2/4: إنشاء نقطة استعادة وتوثيق المخطط الحالي (Schema Snapshot)...');

      setTimeout(() => {
        setMigrationProgress(75);
        setMigrationStep('الخطوة 3/4: تنفيذ سكربتات الترقية (V2.6 Database Migrations)...');

        setTimeout(() => {
          setMigrationProgress(100);
          setMigrationStep('الخطوة 4/4: تم تطبيق كافة التعديلات وتحديث سجل __SchemaVersions بنجاح!');

          setTimeout(() => {
            const updated: SystemVersionInfo = {
              ...versionInfo,
              currentVersion: versionInfo.latestVersion,
              isUpdateAvailable: false,
              pendingMigrations: versionInfo.pendingMigrations.map((m) => ({
                ...m,
                isApplied: true,
                appliedDate: new Date().toISOString().replace('T', ' ').slice(0, 19)
              }))
            };
            onApplyUpdate(updated);
            setIsMigrating(false);
            setSuccess(true);
          }, 800);
        }, 1200);
      }, 1000);
    }, 1000);
  };

  return (
    <div className="fixed inset-0 z-50 bg-slate-950/80 backdrop-blur-sm flex items-center justify-center p-4 font-['Cairo',sans-serif]">
      <div className="w-full max-w-2xl bg-slate-900 border border-slate-800 rounded-3xl p-6 shadow-2xl space-y-6 animate-in zoom-in-95 max-h-[90vh] overflow-y-auto custom-scrollbar">
        {/* Header */}
        <div className="flex items-center justify-between pb-4 border-b border-slate-800">
          <div className="flex items-center gap-3">
            <div className="p-3 bg-gradient-to-tr from-blue-600 to-indigo-500 text-white rounded-2xl shadow-lg shadow-blue-600/30">
              <RefreshCw className={`w-6 h-6 ${isChecking ? 'animate-spin' : ''}`} />
            </div>
            <div>
              <h3 className="text-base font-bold text-white">مركز التحديثات وترقية قاعدة البيانات</h3>
              <p className="text-xs text-slate-400">
                Automatic Software Updates & SQL Database Schema Migrations
              </p>
            </div>
          </div>
          <button
            onClick={onClose}
            className="p-2 hover:bg-slate-800 text-slate-400 hover:text-white rounded-xl transition-colors cursor-pointer"
          >
            <X className="w-5 h-5" />
          </button>
        </div>

        {/* Current vs Latest Status */}
        <div className="grid grid-cols-1 sm:grid-cols-2 gap-4">
          <div className="p-4 rounded-2xl bg-slate-950 border border-slate-800 space-y-1 text-xs">
            <span className="text-slate-400 font-semibold">الإصدار المثبت حالياً:</span>
            <div className="text-lg font-mono font-black text-slate-200">v{versionInfo.currentVersion}</div>
            <div className="text-[11px] text-emerald-400 font-bold flex items-center gap-1">
              <CheckCircle2 className="w-3.5 h-3.5" />
              <span>مستقر ويعمل بكفاءة</span>
            </div>
          </div>

          <div className="p-4 rounded-2xl bg-slate-950 border border-slate-800 space-y-1 text-xs">
            <span className="text-slate-400 font-semibold">أحدث إصدار متوفر:</span>
            <div className="text-lg font-mono font-black text-blue-400">v{versionInfo.latestVersion}</div>
            <div className="text-[11px] text-slate-400">
              تاريخ الطرح: {versionInfo.releaseDate}
            </div>
          </div>
        </div>

        {/* Auto Check Toggle */}
        <div className="flex items-center justify-between p-3.5 rounded-xl bg-slate-950/70 border border-slate-800 text-xs">
          <div className="space-y-0.5">
            <div className="font-bold text-slate-200">التحديث التلقائي للنظام وقاعدة البيانات</div>
            <div className="text-[11px] text-slate-400">
              فحص دوري للإصدارات الجديدة وتنزيل ترقيات المخطط عند توفرها
            </div>
          </div>
          <label className="relative inline-flex items-center cursor-pointer">
            <input
              type="checkbox"
              checked={autoCheck}
              onChange={(e) => setAutoCheck(e.target.checked)}
              className="sr-only peer"
            />
            <div className="w-11 h-6 bg-slate-800 peer-focus:outline-none rounded-full peer peer-checked:after:translate-x-full rtl:peer-checked:after:-translate-x-full peer-checked:after:border-white after:content-[''] after:absolute after:top-[2px] after:start-[2px] after:bg-white after:border-slate-300 after:border after:rounded-full after:h-5 after:w-5 after:transition-all peer-checked:bg-blue-600"></div>
          </label>
        </div>

        {/* Success State */}
        {success && (
          <div className="p-5 bg-emerald-500/10 border border-emerald-500/30 rounded-2xl text-center space-y-2 text-xs text-emerald-300">
            <CheckCircle2 className="w-8 h-8 text-emerald-400 mx-auto" />
            <div className="text-sm font-bold text-white">تمت ترقية البرنامج وقاعدة البيانات بنجاح!</div>
            <p className="text-slate-300 text-[11px]">
              النظام يعمل الآن بأحدث إصدار v{versionInfo.latestVersion} وتم تنفيذ كافة ترقيات الجداول والمؤشرات.
            </p>
          </div>
        )}

        {/* Update Available Box & Migrations List */}
        {versionInfo.isUpdateAvailable && !success && (
          <div className="space-y-4">
            {/* Changelog */}
            <div className="p-4 bg-blue-950/20 border border-blue-800/40 rounded-2xl space-y-2 text-xs">
              <div className="flex items-center gap-2 font-bold text-blue-300">
                <Sparkles className="w-4 h-4 text-blue-400" />
                <span>أبرز التحسينات والمميزات في الإصدار الجديد v{versionInfo.latestVersion}:</span>
              </div>
              <ul className="list-disc list-inside space-y-1 text-slate-300 text-[11px] pr-2">
                {versionInfo.changeLog.map((item, i) => (
                  <li key={i}>{item}</li>
                ))}
              </ul>
            </div>

            {/* Pending Database Migrations */}
            <div className="space-y-2.5 text-xs">
              <div className="flex items-center justify-between">
                <div className="flex items-center gap-2 font-bold text-slate-200">
                  <Database className="w-4 h-4 text-emerald-400" />
                  <span>ترقيات قاعدة البيانات المطلوبة (Database Migrations):</span>
                </div>
                <span className="text-[10px] text-amber-400 font-mono">
                  {versionInfo.pendingMigrations.filter((m) => !m.isApplied).length} تعديلات معلقة
                </span>
              </div>

              <div className="space-y-2">
                {versionInfo.pendingMigrations.map((migration) => (
                  <div
                    key={migration.version}
                    className="p-3 bg-slate-950 rounded-xl border border-slate-800 space-y-1.5"
                  >
                    <div className="flex items-center justify-between">
                      <span className="font-mono text-blue-400 text-[11px] font-bold">
                        {migration.version}
                      </span>
                      <button
                        onClick={() =>
                          setShowSqlPreview(
                            showSqlPreview === migration.version ? null : migration.version
                          )
                        }
                        className="text-[10px] text-slate-400 hover:text-white flex items-center gap-1 cursor-pointer font-mono"
                      >
                        <FileCode className="w-3 h-3 text-blue-400" />
                        <span>{showSqlPreview === migration.version ? 'إخفاء SQL' : 'معاينة كود SQL'}</span>
                      </button>
                    </div>
                    <div className="text-slate-200 font-semibold">{migration.title}</div>
                    <div className="text-[11px] text-slate-400">{migration.description}</div>

                    {showSqlPreview === migration.version && (
                      <div className="mt-2 p-3 bg-slate-900 border border-slate-700/80 rounded-lg font-mono text-[10px] text-slate-300 whitespace-pre overflow-x-auto custom-scrollbar">
                        {migration.sqlScript}
                      </div>
                    )}
                  </div>
                ))}
              </div>
            </div>

            {/* Migration Progress Bar */}
            {isMigrating && (
              <div className="p-4 bg-slate-950 border border-blue-500/40 rounded-2xl space-y-2.5 animate-in fade-in">
                <div className="flex items-center justify-between text-xs">
                  <span className="text-blue-300 font-bold">{migrationStep}</span>
                  <span className="font-mono text-blue-400 font-bold">{migrationProgress}%</span>
                </div>
                <div className="w-full bg-slate-800 h-2.5 rounded-full overflow-hidden">
                  <div
                    className="bg-gradient-to-r from-blue-600 to-emerald-500 h-full transition-all duration-500 rounded-full"
                    style={{ width: `${migrationProgress}%` }}
                  />
                </div>
              </div>
            )}

            {/* Action Buttons */}
            <div className="flex flex-wrap items-center gap-3 pt-2">
              <button
                disabled={isMigrating}
                onClick={handleStartUpdateAndMigration}
                className="flex-1 py-3 bg-gradient-to-r from-blue-600 to-indigo-600 hover:from-blue-500 hover:to-indigo-500 text-white font-bold rounded-xl shadow-lg shadow-blue-600/30 transition-all cursor-pointer flex items-center justify-center gap-2 text-xs disabled:opacity-50"
              >
                <Download className="w-4 h-4" />
                <span>تثبيت التحديث وتطبيق ترقية قاعدة البيانات الآن (Run Migration)</span>
              </button>

              <button
                type="button"
                disabled={isMigrating}
                onClick={handleCheckUpdates}
                className="px-4 py-3 bg-slate-800 hover:bg-slate-700 text-slate-300 font-bold rounded-xl text-xs transition-colors cursor-pointer flex items-center gap-1.5"
              >
                <RefreshCw className={`w-3.5 h-3.5 ${isChecking ? 'animate-spin' : ''}`} />
                <span>فحص التحديثات</span>
              </button>
            </div>
          </div>
        )}

        {!versionInfo.isUpdateAvailable && !success && (
          <div className="p-6 bg-slate-950 rounded-2xl text-center space-y-2 text-xs border border-slate-800">
            <CheckCircle2 className="w-8 h-8 text-emerald-400 mx-auto" />
            <div className="text-sm font-bold text-white">أنت تستخدم أحدث إصدار بالفعل</div>
            <p className="text-slate-400 text-[11px]">
              قاعدة البيانات ومخطط الجداول متزامنة بالكامل مع كافة التحديثات المعتمدة.
            </p>
            <button
              onClick={handleCheckUpdates}
              className="mt-3 px-4 py-2 bg-slate-800 hover:bg-slate-700 text-slate-200 rounded-xl text-xs font-bold inline-flex items-center gap-1.5 cursor-pointer"
            >
              <RefreshCw className={`w-3.5 h-3.5 ${isChecking ? 'animate-spin' : ''}`} />
              <span>إعادة فحص التحديثات الآن</span>
            </button>
          </div>
        )}
      </div>
    </div>
  );
};
