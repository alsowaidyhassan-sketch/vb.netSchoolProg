import React, { useState, useEffect } from 'react';
import {
  MessageSquare,
  Send,
  Copy,
  Check,
  X,
  Phone,
  User,
  Sparkles,
  ExternalLink,
  ShieldCheck,
  FileText
} from 'lucide-react';
import { Student, FeeInvoice } from '../../types';
import { IraqiPhoneValidator } from '../../utils/iraqiStandards';

interface WhatsAppModalProps {
  isOpen: boolean;
  onClose: () => void;
  defaultRecipient?: {
    name: string;
    phone: string;
    studentName?: string;
    type?: 'attendance' | 'fees' | 'grades' | 'general';
    amount?: number;
    date?: string;
  };
  onMessageSent?: (logData: { recipientPhone: string; recipientName: string; text: string }) => void;
}

export const WhatsAppModal: React.FC<WhatsAppModalProps> = ({
  isOpen,
  onClose,
  defaultRecipient,
  onMessageSent
}) => {
  const [recipientName, setRecipientName] = useState('');
  const [phone, setPhone] = useState('');
  const [studentName, setStudentName] = useState('');
  const [messageType, setMessageType] = useState<'attendance' | 'fees' | 'grades' | 'general'>('attendance');
  const [messageText, setMessageText] = useState('');
  const [copied, setCopied] = useState(false);

  useEffect(() => {
    if (defaultRecipient) {
      setRecipientName(defaultRecipient.name || '');
      setPhone(defaultRecipient.phone || '');
      setStudentName(defaultRecipient.studentName || '');
      if (defaultRecipient.type) setMessageType(defaultRecipient.type);
    }
  }, [defaultRecipient]);

  // التحقق من الهاتف العراقي
  const phoneValidation = IraqiPhoneValidator.validate(phone);

  // Update template when type or variables change
  useEffect(() => {
    const sName = studentName || 'ابنكم';
    const school = 'ثانوية دجلة الأهلية للبنين - بغداد';
    const today = defaultRecipient?.date || new Date().toISOString().slice(0, 10);
    const amount = defaultRecipient?.amount?.toLocaleString('ar-IQ') || '500,000';

    switch (messageType) {
      case 'attendance':
        setMessageText(
          `السلام عليكم ورحمة الله وبركاته،\nالمكرم ولي أمر الطالب: ${sName}\nتحية طيبة،\nنحيطكم علماً بأن الطالب قد تغيب عن الدوام الرسمي للمدرسة لهذا اليوم ${today}.\nيرجى بيان سبب الغياب أو تزويد إدارة المدرسة بعذر رسمي حرصاً على مستواه العلمي ومتابعة دروسه.\nمع وافر التقدير،\nإدارة ${school}.`
        );
        break;
      case 'fees':
        setMessageText(
          `السلام عليكم ورحمة الله وبركاته،\nالمكرم ولي أمر الطالب: ${sName}\nتحية طيبة،\nنود تذكيركم بموعد استحقاق القسط الدراسي بمبلغ (${amount} د.ع - دينار عراقي).\nيرجى التفضل بمراجعة القسم المالي للمدرسة أو التسديد عبر (زين كاش / كي كارد / الصندوق).\nشاكرين لكم حسن تعاونكم واهتمامكم،\n${school} - الشؤون المالية والحسابات.`
        );
        break;
      case 'grades':
        setMessageText(
          `السلام عليكم ورحمة الله وبركاته،\nالمكرم ولي أمر الطالب: ${sName}\nتحية طيبة،\nيسر إدارة المدرسة إبلاغكم بإعلان النتائج والدرجات للامتحانات الشهرية/الفصلية مع التنويه بجهود الطالب المتميزة.\nيمكنكم الاطلاع على كشف الدرجات التفصيلي عبر التطبيق أو مراجعة إدارة المدرسة.\nمع تحيات شعبة التوجيه التربوي والتعليمي بـ ${school}.`
        );
        break;
      case 'general':
      default:
        setMessageText(
          `السلام عليكم ورحمة الله وبركاته،\nالسادة أولياء الأمور الكرام،\nنود إحاطتكم علماً بمستجدات الدوام والامتحانات والأنشطة العلمية والتربوية.\nشاكرين لكم ثقتكم ودعمكم المستمر،\nإدارة ${school}.`
        );
        break;
    }
  }, [messageType, studentName, defaultRecipient]);

  if (!isOpen) return null;

  const handleCopy = () => {
    navigator.clipboard.writeText(messageText);
    setCopied(true);
    setTimeout(() => setCopied(false), 2000);
  };

  const handleSendViaWhatsApp = () => {
    // تحويل الرقم إلى التنسيق الدولي العراقي 9647XXXXXXXX
    let cleanPhone = phone.replace(/\D/g, '');
    if (cleanPhone.startsWith('07')) {
      cleanPhone = '964' + cleanPhone.slice(1);
    } else if (cleanPhone.startsWith('7') && cleanPhone.length === 10) {
      cleanPhone = '964' + cleanPhone;
    } else if (cleanPhone.startsWith('05')) {
      cleanPhone = '966' + cleanPhone.slice(1);
    }

    const encodedText = encodeURIComponent(messageText);
    const url = `https://api.whatsapp.com/send?phone=${cleanPhone}&text=${encodedText}`;

    window.open(url, '_blank', 'noopener,noreferrer');

    if (onMessageSent) {
      onMessageSent({
        recipientPhone: cleanPhone,
        recipientName: recipientName || 'ولي أمر',
        text: messageText
      });
    }

    onClose();
  };

  return (
    <div className="fixed inset-0 z-50 bg-slate-950/80 backdrop-blur-sm flex items-center justify-center p-4 font-['Cairo',sans-serif]">
      <div className="w-full max-w-xl bg-slate-900 border border-slate-800 rounded-3xl p-6 shadow-2xl space-y-5 animate-in zoom-in-95">
        {/* Header */}
        <div className="flex items-center justify-between pb-3 border-b border-slate-800">
          <div className="flex items-center gap-3">
            <div className="p-2.5 bg-emerald-500/20 text-emerald-400 rounded-xl border border-emerald-500/30">
              <MessageSquare className="w-6 h-6" />
            </div>
            <div>
              <h3 className="text-base font-bold text-white">إرسال رسالة واتساب لولي الأمر مباشرة</h3>
              <p className="text-xs text-slate-400">Direct WhatsApp Notification & Alerts</p>
            </div>
          </div>
          <button
            onClick={onClose}
            className="p-1.5 hover:bg-slate-800 text-slate-400 hover:text-white rounded-lg transition-colors cursor-pointer"
          >
            <X className="w-4 h-4" />
          </button>
        </div>

        {/* Form Fields */}
        <div className="space-y-3.5 text-xs">
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div>
              <label className="block text-slate-300 font-semibold mb-1 text-right">
                اسم ولي الأمر / المستلم
              </label>
              <div className="relative">
                <input
                  type="text"
                  value={recipientName}
                  onChange={(e) => setRecipientName(e.target.value)}
                  placeholder="مثال: حيدر علي كاظم الزبيدي"
                  className="w-full bg-slate-950 border border-slate-800 rounded-xl px-3.5 py-2 text-white placeholder:text-slate-600 focus:outline-none focus:border-emerald-500 text-right"
                />
                <User className="w-3.5 h-3.5 text-slate-500 absolute left-3 top-3" />
              </div>
            </div>

            <div>
              <div className="flex items-center justify-between mb-1">
                <label className="text-slate-300 font-semibold text-right">
                  رقم هاتف الواتساب (07XXXXXXXXX)
                </label>
                {phoneValidation.isValid && phoneValidation.carrier && (
                  <span className="text-[10px] px-2 py-0.5 rounded-full bg-emerald-500/20 text-emerald-300 border border-emerald-500/30">
                    {phoneValidation.carrier}
                  </span>
                )}
              </div>
              <div className="relative">
                <input
                  type="tel"
                  value={phone}
                  onChange={(e) => setPhone(e.target.value)}
                  placeholder="مثال: 07801234567"
                  className="w-full bg-slate-950 border border-slate-800 rounded-xl px-3.5 py-2 text-white placeholder:text-slate-600 focus:outline-none focus:border-emerald-500 font-mono text-left"
                />
                <Phone className="w-3.5 h-3.5 text-slate-500 absolute left-3 top-3" />
              </div>
            </div>
          </div>

          <div>
            <label className="block text-slate-300 font-semibold mb-1 text-right">
              اسم الطالب / الطالبة المعني
            </label>
            <input
              type="text"
              value={studentName}
              onChange={(e) => setStudentName(e.target.value)}
              placeholder="مثال: مصطفى علي حسين الزبيدي"
              className="w-full bg-slate-950 border border-slate-800 rounded-xl px-3.5 py-2 text-white placeholder:text-slate-600 focus:outline-none focus:border-emerald-500 text-right"
            />
          </div>

          {/* Template Selector Tabs */}
          <div>
            <label className="block text-slate-300 font-semibold mb-1 text-right">
              اختيار القالب المعتمد:
            </label>
            <div className="grid grid-cols-2 sm:grid-cols-4 gap-2">
              <button
                type="button"
                onClick={() => setMessageType('attendance')}
                className={`p-2 rounded-xl border text-center transition-all cursor-pointer ${
                  messageType === 'attendance'
                    ? 'bg-emerald-600/20 border-emerald-500/60 text-emerald-300 font-bold'
                    : 'bg-slate-950 border-slate-800 text-slate-400 hover:border-slate-700'
                }`}
              >
                إشعار غياب
              </button>

              <button
                type="button"
                onClick={() => setMessageType('fees')}
                className={`p-2 rounded-xl border text-center transition-all cursor-pointer ${
                  messageType === 'fees'
                    ? 'bg-emerald-600/20 border-emerald-500/60 text-emerald-300 font-bold'
                    : 'bg-slate-950 border-slate-800 text-slate-400 hover:border-slate-700'
                }`}
              >
                سداد رسوم
              </button>

              <button
                type="button"
                onClick={() => setMessageType('grades')}
                className={`p-2 rounded-xl border text-center transition-all cursor-pointer ${
                  messageType === 'grades'
                    ? 'bg-emerald-600/20 border-emerald-500/60 text-emerald-300 font-bold'
                    : 'bg-slate-950 border-slate-800 text-slate-400 hover:border-slate-700'
                }`}
              >
                درجات وتفوق
              </button>

              <button
                type="button"
                onClick={() => setMessageType('general')}
                className={`p-2 rounded-xl border text-center transition-all cursor-pointer ${
                  messageType === 'general'
                    ? 'bg-emerald-600/20 border-emerald-500/60 text-emerald-300 font-bold'
                    : 'bg-slate-950 border-slate-800 text-slate-400 hover:border-slate-700'
                }`}
              >
                تعميم مدرسي
              </button>
            </div>
          </div>

          {/* Editable Text Area */}
          <div>
            <div className="flex items-center justify-between mb-1">
              <label className="text-slate-300 font-semibold text-right">
                نص الرسالة المرسلة لولي الأمر (يمكنك التعديل عليها):
              </label>
              <button
                type="button"
                onClick={handleCopy}
                className="text-[11px] text-emerald-400 hover:text-emerald-300 flex items-center gap-1 cursor-pointer"
              >
                {copied ? <Check className="w-3.5 h-3.5" /> : <Copy className="w-3.5 h-3.5" />}
                <span>{copied ? 'تم النسخ' : 'نسخ النص'}</span>
              </button>
            </div>
            <textarea
              rows={5}
              value={messageText}
              onChange={(e) => setMessageText(e.target.value)}
              className="w-full bg-slate-950 border border-slate-800 rounded-xl p-3 text-white placeholder:text-slate-600 focus:outline-none focus:border-emerald-500 text-right leading-relaxed custom-scrollbar"
            />
          </div>

          {/* Action Buttons */}
          <div className="flex items-center gap-3 pt-2">
            <button
              type="button"
              onClick={handleSendViaWhatsApp}
              disabled={!phone.trim()}
              className="flex-1 py-3 bg-gradient-to-r from-emerald-600 to-green-600 hover:from-emerald-500 hover:to-green-500 text-white font-bold rounded-xl shadow-lg shadow-emerald-600/30 transition-all cursor-pointer flex items-center justify-center gap-2 text-xs disabled:opacity-50"
            >
              <Send className="w-4 h-4" />
              <span>إرسال عبر واتساب مباشرة (Open WhatsApp)</span>
              <ExternalLink className="w-3.5 h-3.5" />
            </button>

            <button
              type="button"
              onClick={onClose}
              className="px-4 py-3 bg-slate-800 hover:bg-slate-700 text-slate-300 font-bold rounded-xl text-xs transition-colors cursor-pointer"
            >
              إلغاء
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
