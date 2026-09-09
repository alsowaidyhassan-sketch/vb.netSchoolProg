import React, { useState } from 'react';
import {
  Award,
  ShieldCheck,
  Key,
  Copy,
  Check,
  Calendar,
  Clock,
  Cpu,
  Building,
  AlertTriangle,
  X,
  RefreshCw,
  FileCheck
} from 'lucide-react';
import { LicenseInfo } from '../../types';

interface LicenseModalProps {
  isOpen: boolean;
  license: LicenseInfo;
  onClose: () => void;
  onUpdateLicense: (newLicense: LicenseInfo) => void;
}

export const LicenseModal: React.FC<LicenseModalProps> = ({
  isOpen,
  license,
  onClose,
  onUpdateLicense
}) => {
  const [newKey, setNewKey] = useState('');
  const [copiedHwid, setCopiedHwid] = useState(false);
  const [feedback, setFeedback] = useState<{ type: 'success' | 'error'; message: string } | null>(null);

  if (!isOpen) return null;

  const handleCopyHwid = () => {
    navigator.clipboard.writeText(license.hardwareId);
    setCopiedHwid(true);
    setTimeout(() => setCopiedHwid(false), 2000);
  };

  const handleApplyKey = (e: React.FormEvent) => {
    e.preventDefault();
    setFeedback(null);

    const cleanKey = newKey.trim().toUpperCase();
    if (!cleanKey || cleanKey.length < 15) {
      setFeedback({
        type: 'error',
        message: 'مفتاح التفعيل المدخل غير صالح أو غير مكتمل التنسيق.'
      });
      return;
    }

    // Generate new license details based on the key
    const newExpiry = new Date();
    newExpiry.setFullYear(newExpiry.getFullYear() + 1);

    const updatedLicense: LicenseInfo = {
      ...license,
      licenseKey: cleanKey,
      issueDate: new Date().toISOString().slice(0, 10),
      expiryDate: newExpiry.toISOString().slice(0, 10),
      daysRemaining: 365,
      status: 'Active',
      edition: cleanKey.includes('ULT') ? 'Enterprise' : 'Professional'
    };

    onUpdateLicense(updatedLicense);
    setFeedback({
      type: 'success',
      message: 'تم تفعيل ترخيص البرنامج بنجاح وتمديد الصلاحية لمدة عام كامل!'
    });
    setNewKey('');
  };

  return (
    <div className="fixed inset-0 z-50 bg-slate-950/80 backdrop-blur-sm flex items-center justify-center p-4 font-['Cairo',sans-serif]">
      <div className="w-full max-w-2xl bg-slate-900 border border-slate-800 rounded-3xl p-6 shadow-2xl space-y-6 animate-in zoom-in-95">
        {/* Header */}
        <div className="flex items-center justify-between pb-4 border-b border-slate-800">
          <div className="flex items-center gap-3">
            <div className="p-3 bg-gradient-to-tr from-amber-600 to-yellow-500 text-white rounded-2xl shadow-lg shadow-amber-600/30">
              <Award className="w-6 h-6" />
            </div>
            <div>
              <h3 className="text-base font-bold text-white">ترخيص وتفعيل النظام | License & Validity</h3>
              <p className="text-xs text-slate-400">
                إدارة الاشتراك، بصمة الجهاز، وصلاحية النسخة المؤسسية
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

        {/* License Overview Card */}
        <div className="relative overflow-hidden bg-gradient-to-br from-slate-950 via-slate-900 to-blue-950/40 border border-blue-900/40 rounded-2xl p-5 space-y-4">
          <div className="flex flex-wrap items-center justify-between gap-3">
            <div className="space-y-1">
              <div className="flex items-center gap-2">
                <span className="text-xs font-bold text-slate-400">حالة الترخيص:</span>
                <span className="inline-flex items-center gap-1.5 px-2.5 py-0.5 rounded-full text-xs font-bold bg-emerald-500/20 text-emerald-400 border border-emerald-500/40 font-mono">
                  <ShieldCheck className="w-3.5 h-3.5" />
                  <span>{license.status === 'Active' ? 'مرخص رسمياً (Active)' : 'منتهي الصلاحية'}</span>
                </span>
                <span className="px-2 py-0.5 bg-blue-950 text-blue-300 rounded text-xs font-bold border border-blue-800">
                  {license.edition} Edition
                </span>
              </div>
              <div className="text-sm font-bold text-white">{license.organizationName}</div>
              <div className="text-xs text-slate-400">الجهة المرخص لها: {license.licensedTo}</div>
            </div>

            {/* Days Remaining Counter Badge */}
            <div className="p-3 bg-slate-900/90 border border-slate-700/60 rounded-2xl text-center min-w-[110px]">
              <div className="text-2xl font-black text-amber-400 font-mono">{license.daysRemaining}</div>
              <div className="text-[11px] text-slate-400">يوماً متبقياً</div>
            </div>
          </div>

          {/* Key & HWID Details Grid */}
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3 text-xs pt-2 border-t border-slate-800/80">
            <div className="space-y-1">
              <span className="text-slate-400">مفتاح الترخيص المسجل (License Key):</span>
              <div className="font-mono bg-slate-950 p-2 rounded-xl text-slate-200 border border-slate-800 text-[11px] truncate select-all">
                {license.licenseKey}
              </div>
            </div>

            <div className="space-y-1">
              <div className="flex items-center justify-between">
                <span className="text-slate-400">بصمة الجهاز (Machine GUID / HWID):</span>
                <button
                  onClick={handleCopyHwid}
                  className="text-[10px] text-blue-400 hover:text-blue-300 flex items-center gap-1 cursor-pointer"
                >
                  {copiedHwid ? <Check className="w-3 h-3 text-emerald-400" /> : <Copy className="w-3 h-3" />}
                  <span>{copiedHwid ? 'تم النسخ' : 'نسخ البصمة'}</span>
                </button>
              </div>
              <div className="font-mono bg-slate-950 p-2 rounded-xl text-slate-300 border border-slate-800 text-[11px] truncate select-all">
                {license.hardwareId}
              </div>
            </div>
          </div>

          <div className="flex flex-wrap items-center justify-between gap-4 text-xs text-slate-400 pt-1 font-mono">
            <div className="flex items-center gap-1">
              <Calendar className="w-3.5 h-3.5 text-blue-400" />
              <span>تاريخ الإصدار: {license.issueDate}</span>
            </div>
            <div className="flex items-center gap-1">
              <Clock className="w-3.5 h-3.5 text-amber-400" />
              <span>تاريخ الانتهاء: {license.expiryDate}</span>
            </div>
            <div>
              الحد الأقصى للطلاب:{' '}
              <span className="text-white font-bold">{license.maxStudents.toLocaleString('ar-SA')} طالب</span>
            </div>
          </div>
        </div>

        {/* Feedback Alert */}
        {feedback && (
          <div
            className={`p-3.5 rounded-xl border text-xs flex items-center gap-2 ${
              feedback.type === 'success'
                ? 'bg-emerald-500/10 border-emerald-500/30 text-emerald-300'
                : 'bg-rose-500/10 border-rose-500/30 text-rose-300'
            }`}
          >
            {feedback.type === 'success' ? (
              <Check className="w-4 h-4 text-emerald-400 shrink-0" />
            ) : (
              <AlertTriangle className="w-4 h-4 text-rose-400 shrink-0" />
            )}
            <span>{feedback.message}</span>
          </div>
        )}

        {/* Enter New License Key Form */}
        <form onSubmit={handleApplyKey} className="space-y-3 text-xs">
          <label className="block text-slate-300 font-bold text-right">
            تجديد الترخيص أو إدخال مفتاح منتج جديد (Product Activation Key):
          </label>
          <div className="flex flex-col sm:flex-row items-center gap-2">
            <input
              type="text"
              value={newKey}
              onChange={(e) => setNewKey(e.target.value)}
              placeholder="مثال: EDURA-2027-PRO-8891-KSA"
              className="flex-1 w-full bg-slate-950 border border-slate-800 rounded-xl px-4 py-2.5 text-white placeholder:text-slate-600 focus:outline-none focus:border-amber-500 font-mono text-center tracking-wider uppercase"
            />
            <button
              type="submit"
              className="w-full sm:w-auto px-6 py-2.5 bg-gradient-to-r from-amber-600 to-yellow-600 hover:from-amber-500 hover:to-yellow-500 text-white font-bold rounded-xl shadow-lg shadow-amber-600/30 transition-all cursor-pointer flex items-center justify-center gap-2 shrink-0"
            >
              <Key className="w-4 h-4" />
              <span>تفعيل الترخيص الآن</span>
            </button>
          </div>
          <p className="text-[11px] text-slate-500 leading-relaxed">
            لتجديد اشتراك مدرستك، يرجى تزويد قسم المبيعات ببصمة الجهاز (Machine GUID) الموضحة أعلاه للحصول على مفتاح التشفير الرقمي المعتمد.
          </p>
        </form>
      </div>
    </div>
  );
};
