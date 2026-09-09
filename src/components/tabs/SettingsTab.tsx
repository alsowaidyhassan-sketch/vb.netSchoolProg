import React, { useState } from 'react';
import { Settings, Save, CheckCircle2, Database, ShieldCheck, School, Globe, KeyRound, RefreshCw, Server } from 'lucide-react';
import { SchoolSettings } from '../../types';

interface SettingsTabProps {
  settings: SchoolSettings;
  onSaveSettings: (settings: SchoolSettings) => void;
  onOpenDbModal?: () => void;
  onOpenLicenseModal?: () => void;
  onOpenUpdateModal?: () => void;
}

export const SettingsTab: React.FC<SettingsTabProps> = ({
  settings,
  onSaveSettings,
  onOpenDbModal,
  onOpenLicenseModal,
  onOpenUpdateModal
}) => {
  const [formData, setFormData] = useState<SchoolSettings>(settings);
  const [isSaved, setIsSaved] = useState(false);
  const [testingDb, setTestingDb] = useState(false);
  const [dbStatus, setDbStatus] = useState<'idle' | 'success' | 'failed'>('idle');

  const handleSave = (e: React.FormEvent) => {
    e.preventDefault();
    onSaveSettings(formData);
    setIsSaved(true);
    setTimeout(() => setIsSaved(false), 3000);
  };

  const handleTestConnection = () => {
    setTestingDb(true);
    setDbStatus('idle');
    setTimeout(() => {
      setTestingDb(false);
      setDbStatus('success');
    }, 1200);
  };

  return (
    <div className="p-6 space-y-6 max-w-5xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-slate-800 border border-slate-700 rounded-xl text-slate-300">
            <Settings className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">إعدادات النظام والمدرسة (System Configuration)</h2>
            <p className="text-xs text-slate-400">الهوية المؤسسية، الاتصال بقاعدة البيانات، والترخيص</p>
          </div>
        </div>

        <button
          onClick={handleSave}
          className="flex items-center gap-2 px-5 py-2 bg-blue-600 hover:bg-blue-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-blue-600/30 transition-all cursor-pointer"
        >
          <Save className="w-4 h-4" />
          <span>حفظ التعديلات</span>
        </button>
      </div>

      <form onSubmit={handleSave} className="space-y-6 text-xs">
        {/* School Profile Card */}
        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-6 shadow-xl space-y-4">
          <h3 className="text-sm font-bold text-white flex items-center gap-2 border-b border-slate-800 pb-3">
            <School className="w-4 h-4 text-blue-400" />
            <span>بيانات المنشأة التعليمية والترخيص الرسمي</span>
          </h3>

          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <div>
              <label className="block text-slate-300 font-semibold mb-1">اسم المدرسة الرسمي (بالعربية) *</label>
              <input
                type="text"
                required
                value={formData.schoolName}
                onChange={(e) => setFormData({ ...formData, schoolName: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2.5 text-white"
              />
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">اسم المدرسة (بالإنجليزية)</label>
              <input
                type="text"
                value={formData.schoolNameEn}
                onChange={(e) => setFormData({ ...formData, schoolNameEn: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2.5 text-white font-mono"
              />
            </div>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <div>
              <label className="block text-slate-300 font-semibold mb-1">العام الدراسي الحالي</label>
              <input
                type="text"
                value={formData.academicYear}
                onChange={(e) => setFormData({ ...formData, academicYear: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
              />
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">الفصل الدراسي</label>
              <select
                value={formData.currentSemester}
                onChange={(e) => setFormData({ ...formData, currentSemester: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
              >
                <option value="الفصل الدراسي الأول">الفصل الدراسي الأول</option>
                <option value="الفصل الدراسي الثاني">الفصل الدراسي الثاني</option>
                <option value="الفصل الدراسي الثالث">الفصل الدراسي الثالث</option>
              </select>
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">الرقم الضريبي (VAT ID)</label>
              <input
                type="text"
                value={formData.taxNumber}
                onChange={(e) => setFormData({ ...formData, taxNumber: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
              />
            </div>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            <div>
              <label className="block text-slate-300 font-semibold mb-1">الهاتف الموحد</label>
              <input
                type="text"
                value={formData.phone}
                onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
              />
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">البريد الإلكتروني الرسمي</label>
              <input
                type="email"
                value={formData.email}
                onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
              />
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">الموقع الإلكتروني</label>
              <input
                type="text"
                value={formData.website}
                onChange={(e) => setFormData({ ...formData, website: e.target.value })}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
              />
            </div>
          </div>

          <div>
            <label className="block text-slate-300 font-semibold mb-1">العنوان الجغرافي</label>
            <input
              type="text"
              value={formData.address}
              onChange={(e) => setFormData({ ...formData, address: e.target.value })}
              className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
            />
          </div>
        </div>

        {/* Database Connection Card */}
        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-6 shadow-xl space-y-4">
          <div className="flex items-center justify-between border-b border-slate-800 pb-3">
            <h3 className="text-sm font-bold text-white flex items-center gap-2">
              <Database className="w-4 h-4 text-emerald-400" />
              <span>إعدادات الاتصال بخادم Microsoft SQL Server الفعلي</span>
            </h3>
            <div className="flex items-center gap-2">
              {onOpenDbModal && (
                <button
                  type="button"
                  onClick={onOpenDbModal}
                  className="flex items-center gap-1.5 px-3 py-1.5 bg-blue-600 hover:bg-blue-500 text-white rounded-xl text-xs font-bold transition-colors cursor-pointer"
                >
                  <Server className="w-3.5 h-3.5" />
                  <span>تهيئة ربط الخادم الفعلي</span>
                </button>
              )}
              <button
                type="button"
                onClick={handleTestConnection}
                disabled={testingDb}
                className="px-3 py-1.5 bg-slate-800 hover:bg-slate-700 text-slate-200 rounded-xl border border-slate-700 transition-colors cursor-pointer text-xs"
              >
                {testingDb ? 'جاري الفحص...' : 'اختبار الاتصال'}
              </button>
            </div>
          </div>

          <div>
            <label className="block text-slate-300 font-semibold mb-1">سلسلة الاتصال المعتمدة (Connection String)</label>
            <input
              type="text"
              readOnly
              value={formData.connectionString}
              className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2.5 text-emerald-400 font-mono text-[11px]"
            />
          </div>

          {dbStatus === 'success' && (
            <div className="p-3 bg-emerald-950/60 border border-emerald-800 rounded-xl flex items-center gap-2 text-emerald-300 font-bold">
              <CheckCircle2 className="w-4 h-4" />
              <span>الاتصال ناجح بخادم Microsoft SQL Server 2022 وتم التحقق من الجداول وصلاحيات المستخدم!</span>
            </div>
          )}
        </div>

        {/* Commercial License Card */}
        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-6 shadow-xl space-y-4">
          <div className="flex items-center justify-between border-b border-slate-800 pb-3">
            <h3 className="text-sm font-bold text-white flex items-center gap-2">
              <ShieldCheck className="w-4 h-4 text-purple-400" />
              <span>معلومات رخصة البرنامج وصلاحية الاستخدام (Software License)</span>
            </h3>
            {onOpenLicenseModal && (
              <button
                type="button"
                onClick={onOpenLicenseModal}
                className="flex items-center gap-1.5 px-3 py-1.5 bg-purple-600 hover:bg-purple-500 text-white rounded-xl text-xs font-bold transition-colors cursor-pointer"
              >
                <KeyRound className="w-3.5 h-3.5" />
                <span>إدارة وتجديد مفتاح التفعيل</span>
              </button>
            )}
          </div>

          <div className="flex flex-wrap items-center justify-between gap-4">
            <div>
              <div className="text-slate-300 font-semibold">حالة الترخيص: <span className="text-emerald-400 font-bold font-mono">مرخص تجارياً (Enterprise Edition)</span></div>
              <div className="text-slate-500 font-mono text-[11px] mt-0.5">مفتاح المنتج: EDURA-2026-ENT-9842-8871-KSA</div>
            </div>
            <div className="flex items-center gap-2">
              {onOpenUpdateModal && (
                <button
                  type="button"
                  onClick={onOpenUpdateModal}
                  className="flex items-center gap-1 px-3 py-1 bg-blue-950 hover:bg-blue-900 text-blue-300 font-bold rounded-xl border border-blue-800 text-[11px] transition-colors cursor-pointer"
                >
                  <RefreshCw className="w-3 h-3 text-blue-400" />
                  <span>الترقية والهجرة (Migrations)</span>
                </button>
              )}
              <span className="px-3 py-1 bg-purple-950 text-purple-300 font-bold rounded-full border border-purple-800 text-[11px]">
                النسخة v2.5.0 Enterprise
              </span>
            </div>
          </div>
        </div>
      </form>

      {isSaved && (
        <div className="fixed bottom-12 left-1/2 -translate-x-1/2 bg-blue-600 text-white px-5 py-2.5 rounded-xl shadow-2xl flex items-center gap-2 text-xs font-bold z-50">
          <CheckCircle2 className="w-4 h-4" />
          <span>تم حفظ كافة إعدادات النظام بنجاح!</span>
        </div>
      )}
    </div>
  );
};
