import React, { useState, useEffect } from 'react';
import {
  Minus,
  Square,
  X,
  Database,
  ShieldCheck,
  Cpu,
  Clock,
  Sparkles,
  School
} from 'lucide-react';

interface WindowFrameProps {
  children: React.ReactNode;
  schoolName: string;
}

export const WindowFrame: React.FC<WindowFrameProps> = ({ children, schoolName }) => {
  const [time, setTime] = useState('');
  const [isMaximized, setIsMaximized] = useState(true);

  useEffect(() => {
    const update = () => {
      const now = new Date();
      setTime(
        now.toLocaleTimeString('ar-SA', {
          hour: '2-digit',
          minute: '2-digit',
          second: '2-digit'
        })
      );
    };
    update();
    const interval = setInterval(update, 1000);
    return () => clearInterval(interval);
  }, []);

  return (
    <div className="flex flex-col h-screen w-screen overflow-hidden bg-slate-950 text-slate-100 font-['Cairo',sans-serif] select-none">
      {/* Windows 11 Styled Title Bar */}
      <header
        id="desktop-titlebar"
        className="h-10 bg-slate-900/90 backdrop-blur-md border-b border-slate-800 flex items-center justify-between px-3 z-40 text-xs shrink-0"
      >
        {/* Left: Window Control Buttons (Windows style on left in RTL or right depending on OS, we provide standard controls) */}
        <div className="flex items-center gap-1.5 order-3">
          <button
            onClick={() => alert('تم تصغير النافذة (ميزة سطح المكتب)')}
            className="w-7 h-7 flex items-center justify-center rounded-md hover:bg-slate-800 text-slate-400 hover:text-slate-200 transition-colors"
            title="تصغير (Minimize)"
          >
            <Minus className="w-3.5 h-3.5" />
          </button>
          <button
            onClick={() => setIsMaximized(!isMaximized)}
            className="w-7 h-7 flex items-center justify-center rounded-md hover:bg-slate-800 text-slate-400 hover:text-slate-200 transition-colors"
            title="تكبير / استعادة (Maximize / Restore)"
          >
            <Square className="w-3 h-3" />
          </button>
          <button
            onClick={() => alert('إغلاق التطبيق يتطلب حفظ الجلسة أولاً')}
            className="w-7 h-7 flex items-center justify-center rounded-md hover:bg-red-600 hover:text-white text-slate-400 transition-colors"
            title="إغلاق (Close)"
          >
            <X className="w-3.5 h-3.5" />
          </button>
        </div>

        {/* Center: Window Title & Application Info */}
        <div className="flex items-center gap-2 order-2 text-slate-300 font-semibold tracking-wide truncate">
          <School className="w-4 h-4 text-blue-400 shrink-0" />
          <span className="text-slate-200 font-bold">{schoolName}</span>
          <span className="text-slate-600">|</span>
          <span className="text-slate-400 hidden sm:inline text-[11px]">
            نظام إدارتي لإدارة المدارس v2.4 Enterprise (VB.NET & SQL Server)
          </span>
        </div>

        {/* Right: DB Connection State & Security Badge */}
        <div className="flex items-center gap-3 order-1">
          <div className="flex items-center gap-1.5 px-2.5 py-1 rounded-full bg-emerald-950/60 border border-emerald-800/80 text-emerald-300 font-medium text-[11px]">
            <span className="w-2 h-2 rounded-full bg-emerald-400 animate-pulse"></span>
            <Database className="w-3 h-3 text-emerald-400" />
            <span className="font-mono">SQL Server: متصل (EduraSchoolDB)</span>
          </div>

          <div className="hidden md:flex items-center gap-1 text-[11px] text-slate-400 px-2 py-0.5 rounded bg-slate-800/60 border border-slate-700/50 font-mono">
            <ShieldCheck className="w-3.5 h-3.5 text-blue-400" />
            <span>Auth: SHA-256 + RBAC</span>
          </div>
        </div>
      </header>

      {/* Main Workspace Body */}
      <div className="flex-1 flex overflow-hidden relative">{children}</div>

      {/* Modern Status Bar (Bottom) */}
      <footer
        id="desktop-statusbar"
        className="h-7 bg-slate-900 border-t border-slate-800 px-3 flex items-center justify-between text-[11px] text-slate-400 shrink-0 z-40 font-mono"
      >
        <div className="flex items-center gap-4">
          <div className="flex items-center gap-1 text-slate-300">
            <span className="w-1.5 h-1.5 rounded-full bg-emerald-500"></span>
            <span>الخادم: MSSQLSERVER (Local Instance)</span>
          </div>
          <span className="text-slate-700">|</span>
          <span className="text-slate-400 hidden sm:inline">الإصدار: .NET 8.0 Windows Desktop x64</span>
          <span className="text-slate-700 hidden sm:inline">|</span>
          <div className="flex items-center gap-1 text-slate-400">
            <Cpu className="w-3 h-3 text-blue-400" />
            <span>استهلاك الذاكرة: 48.2 MB</span>
          </div>
        </div>

        <div className="flex items-center gap-4">
          <span className="text-slate-400">المستخدم: المشرف العام (admin)</span>
          <span className="text-slate-700">|</span>
          <div className="flex items-center gap-1 text-slate-300">
            <Clock className="w-3 h-3 text-amber-400" />
            <span>{time}</span>
          </div>
        </div>
      </footer>
    </div>
  );
};
