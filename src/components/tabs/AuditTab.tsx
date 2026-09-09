import React, { useState } from 'react';
import { ShieldCheck, History, Search, Filter, Eye, AlertCircle } from 'lucide-react';
import { AuditLogRecord } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface AuditTabProps {
  logs: AuditLogRecord[];
}

export const AuditTab: React.FC<AuditTabProps> = ({ logs }) => {
  const [selectedLog, setSelectedLog] = useState<AuditLogRecord | null>(null);

  const columns: Column<AuditLogRecord>[] = [
    {
      key: 'timestamp',
      header: 'التاريخ والوقت',
      width: '150px',
      sortable: true,
      render: (l) => <span className="font-mono text-xs text-slate-300">{l.timestamp}</span>
    },
    {
      key: 'username',
      header: 'المستخدم المسؤول',
      sortable: true,
      render: (l) => (
        <span className="font-mono text-xs font-bold text-blue-400 bg-blue-950/60 px-2 py-0.5 rounded border border-blue-900/60">
          {l.username}
        </span>
      )
    },
    {
      key: 'action',
      header: 'نوع العملية',
      sortable: true,
      width: '110px',
      render: (l) => {
        let badgeColor = 'bg-blue-950 text-blue-300 border-blue-800';
        if (l.action === 'INSERT') badgeColor = 'bg-emerald-950 text-emerald-300 border-emerald-800';
        if (l.action === 'UPDATE') badgeColor = 'bg-amber-950 text-amber-300 border-amber-800';
        if (l.action === 'DELETE') badgeColor = 'bg-rose-950 text-rose-300 border-rose-800';
        if (l.action === 'BACKUP') badgeColor = 'bg-purple-950 text-purple-300 border-purple-800';

        return (
          <span className={`text-[10px] font-mono font-bold px-2 py-0.5 rounded-full border ${badgeColor}`}>
            {l.action}
          </span>
        );
      }
    },
    {
      key: 'tableName',
      header: 'الجدول / الكيان',
      sortable: true,
      render: (l) => <span className="font-mono text-xs text-slate-200">{l.tableName}</span>
    },
    {
      key: 'details',
      header: 'تفاصيل الإجراء والبيانات',
      render: (l) => <span className="text-xs text-slate-300 truncate max-w-xs">{l.details}</span>
    },
    {
      key: 'ipAddress',
      header: 'عنوان IP',
      render: (l) => <span className="font-mono text-xs text-slate-500">{l.ipAddress}</span>
    },
    {
      key: 'actions',
      header: 'عرض',
      width: '70px',
      render: (l) => (
        <button
          onClick={() => setSelectedLog(l)}
          className="p-1 rounded-lg hover:bg-slate-800 text-slate-400 hover:text-blue-400 transition-colors"
          title="عرض السجل الكامل"
        >
          <Eye className="w-4 h-4" />
        </button>
      )
    }
  ];

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-red-600/20 border border-red-500/40 rounded-xl text-red-400">
            <History className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">سجل التدقيق الأمني الشامل (Security Audit Trail)</h2>
            <p className="text-xs text-slate-400">
              تتبع جميع التعديلات والحذف والإضافات عبر SQL Triggers المباشرة في قاعدة البيانات
            </p>
          </div>
        </div>

        <div className="text-xs font-mono text-slate-400 bg-slate-950 px-3 py-1.5 rounded-xl border border-slate-800">
          <span>حالة التدقيق: </span>
          <span className="text-emerald-400 font-bold">SQL Triggers Active</span>
        </div>
      </div>

      <ModernDataGrid
        id="audit-grid"
        data={logs}
        columns={columns}
        searchPlaceholder="بحث في سجلات التدقيق بالمستخدم، الجدول، أو التفاصيل..."
        searchFields={['username', 'tableName', 'action', 'details']}
        exportFileName="Audit_Trail_Export_Edura"
      />

      {/* Log Details Modal */}
      {selectedLog && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-lg w-full p-6 shadow-2xl space-y-4 text-xs">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2 flex items-center justify-between">
              <span>تفاصيل قيد التدقيق #{selectedLog.id}</span>
              <span className="font-mono text-xs text-slate-400">{selectedLog.timestamp}</span>
            </h3>

            <div className="space-y-2 text-slate-300">
              <div className="flex justify-between border-b border-slate-800/80 py-1.5">
                <span className="text-slate-500">المستخدم المنفذ:</span>
                <span className="font-mono font-bold text-blue-400">{selectedLog.username}</span>
              </div>
              <div className="flex justify-between border-b border-slate-800/80 py-1.5">
                <span className="text-slate-500">نوع العملية SQL:</span>
                <span className="font-mono font-bold">{selectedLog.action}</span>
              </div>
              <div className="flex justify-between border-b border-slate-800/80 py-1.5">
                <span className="text-slate-500">الجدول المتأثر:</span>
                <span className="font-mono">{selectedLog.tableName} (ID: {selectedLog.recordId})</span>
              </div>
              <div className="flex justify-between border-b border-slate-800/80 py-1.5">
                <span className="text-slate-500">عنوان IP والجهاز:</span>
                <span className="font-mono">{selectedLog.ipAddress}</span>
              </div>
            </div>

            <div className="space-y-1">
              <div className="text-slate-400 font-semibold">تفاصيل الحمولة (Payload Diff):</div>
              <pre className="p-3 bg-slate-950 border border-slate-800 rounded-xl font-mono text-[11px] text-emerald-400 overflow-x-auto whitespace-pre-wrap">
                {selectedLog.details}
              </pre>
            </div>

            <div className="flex justify-end pt-2">
              <button
                onClick={() => setSelectedLog(null)}
                className="px-4 py-2 bg-slate-800 hover:bg-slate-700 text-slate-200 rounded-xl"
              >
                إغلاق
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};
