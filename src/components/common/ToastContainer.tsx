import React from 'react';
import {
  CheckCircle2,
  AlertTriangle,
  Info,
  XCircle,
  X,
  Bell,
  ArrowLeft
} from 'lucide-react';
import { ToastNotification } from '../../types';

interface ToastContainerProps {
  toasts: ToastNotification[];
  onDismiss: (id: string) => void;
}

export const ToastContainer: React.FC<ToastContainerProps> = ({ toasts, onDismiss }) => {
  if (!toasts || toasts.length === 0) return null;

  const getIcon = (type: ToastNotification['type']) => {
    switch (type) {
      case 'success':
        return <CheckCircle2 className="w-5 h-5 text-emerald-400 shrink-0" />;
      case 'warning':
        return <AlertTriangle className="w-5 h-5 text-amber-400 shrink-0" />;
      case 'error':
        return <XCircle className="w-5 h-5 text-rose-400 shrink-0" />;
      case 'info':
      default:
        return <Info className="w-5 h-5 text-blue-400 shrink-0" />;
    }
  };

  const getBorderColor = (type: ToastNotification['type']) => {
    switch (type) {
      case 'success':
        return 'border-emerald-500/40 bg-slate-900/95 shadow-emerald-950/40';
      case 'warning':
        return 'border-amber-500/40 bg-slate-900/95 shadow-amber-950/40';
      case 'error':
        return 'border-rose-500/40 bg-slate-900/95 shadow-rose-950/40';
      case 'info':
      default:
        return 'border-blue-500/40 bg-slate-900/95 shadow-blue-950/40';
    }
  };

  return (
    <aside 
      aria-label="تنبيهات النظام الذكية"
      className="fixed bottom-10 left-6 z-50 flex flex-col-reverse gap-3 max-w-sm w-full pointer-events-none select-none"
    >
      {toasts.map((toast) => (
        <div
          key={toast.id}
          className={`pointer-events-auto flex items-start gap-3 p-4 rounded-2xl border shadow-2xl backdrop-blur-md transition-all duration-300 animate-in slide-in-from-bottom-5 fade-in ${getBorderColor(
            toast.type
          )}`}
        >
          {getIcon(toast.type)}

          <div className="flex-1 text-right text-xs">
            <div className="flex items-center justify-between gap-2 mb-1">
              <span className="font-bold text-slate-100">{toast.title}</span>
              <span className="text-[10px] text-slate-500 font-mono">{toast.timestamp}</span>
            </div>
            <p className="text-slate-300 leading-relaxed">{toast.message}</p>

            {toast.actionLabel && toast.onAction && (
              <button
                onClick={() => {
                  toast.onAction?.();
                  onDismiss(toast.id);
                }}
                className="mt-2.5 inline-flex items-center gap-1.5 px-3 py-1 bg-blue-600 hover:bg-blue-500 text-white rounded-lg text-[11px] font-bold transition-colors cursor-pointer"
              >
                <span>{toast.actionLabel}</span>
                <ArrowLeft className="w-3 h-3" />
              </button>
            )}
          </div>

          <button
            onClick={() => onDismiss(toast.id)}
            className="p-1 hover:bg-slate-800 text-slate-400 hover:text-white rounded-lg transition-colors cursor-pointer"
            title="إغلاق التنبيه"
          >
            <X className="w-4 h-4" />
          </button>
        </div>
      ))}
    </aside>
  );
};
