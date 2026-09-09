import React from 'react';
import { AlertTriangle, Info, CheckCircle2, X } from 'lucide-react';

interface ConfirmDialogProps {
  isOpen: boolean;
  title: string;
  message: string;
  confirmText?: string;
  cancelText?: string;
  type?: 'danger' | 'warning' | 'info' | 'success';
  onConfirm: () => void;
  onCancel: () => void;
}

export const ConfirmDialog: React.FC<ConfirmDialogProps> = ({
  isOpen,
  title,
  message,
  confirmText = 'تأكيد العملية',
  cancelText = 'إلغاء',
  type = 'warning',
  onConfirm,
  onCancel
}) => {
  if (!isOpen) return null;

  const typeConfig = {
    danger: {
      icon: <AlertTriangle className="w-6 h-6 text-red-400" />,
      badgeBg: 'bg-red-950/80 border-red-800 text-red-300',
      btnBg: 'bg-red-600 hover:bg-red-500 text-white'
    },
    warning: {
      icon: <AlertTriangle className="w-6 h-6 text-amber-400" />,
      badgeBg: 'bg-amber-950/80 border-amber-800 text-amber-300',
      btnBg: 'bg-amber-600 hover:bg-amber-500 text-white'
    },
    info: {
      icon: <Info className="w-6 h-6 text-blue-400" />,
      badgeBg: 'bg-blue-950/80 border-blue-800 text-blue-300',
      btnBg: 'bg-blue-600 hover:bg-blue-500 text-white'
    },
    success: {
      icon: <CheckCircle2 className="w-6 h-6 text-emerald-400" />,
      badgeBg: 'bg-emerald-950/80 border-emerald-800 text-emerald-300',
      btnBg: 'bg-emerald-600 hover:bg-emerald-500 text-white'
    }
  }[type];

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/70 backdrop-blur-xs animate-in fade-in duration-150">
      <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4">
        <div className="flex items-start justify-between">
          <div className="flex items-center gap-3">
            <div className={`p-2.5 rounded-xl border ${typeConfig.badgeBg}`}>
              {typeConfig.icon}
            </div>
            <div>
              <h3 className="text-lg font-bold text-slate-100">{title}</h3>
              <p className="text-xs text-slate-400">تأكيد أمني مطلوب من النظام</p>
            </div>
          </div>
          <button
            onClick={onCancel}
            className="text-slate-400 hover:text-slate-200 p-1 rounded-lg hover:bg-slate-800 transition-colors"
          >
            <X className="w-5 h-5" />
          </button>
        </div>

        <p className="text-sm text-slate-300 leading-relaxed bg-slate-950/60 p-3.5 rounded-xl border border-slate-800/80">
          {message}
        </p>

        <div className="flex items-center justify-end gap-3 pt-2">
          <button
            type="button"
            onClick={onCancel}
            className="px-4 py-2 text-sm font-medium text-slate-300 hover:text-white bg-slate-800 hover:bg-slate-700 rounded-xl transition-colors cursor-pointer"
          >
            {cancelText}
          </button>
          <button
            type="button"
            onClick={() => {
              onConfirm();
              onCancel();
            }}
            className={`px-5 py-2 text-sm font-semibold rounded-xl shadow-lg transition-all cursor-pointer ${typeConfig.btnBg}`}
          >
            {confirmText}
          </button>
        </div>
      </div>
    </div>
  );
};
