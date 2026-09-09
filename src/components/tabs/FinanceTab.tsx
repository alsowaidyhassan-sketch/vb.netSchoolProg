import React, { useState } from 'react';
import {
  Receipt,
  CreditCard,
  Wallet,
  Plus,
  Printer,
  FileCheck2,
  CheckCircle2,
  AlertCircle,
  MessageSquare
} from 'lucide-react';
import { FeeInvoice, PaymentReceipt } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';
import { AddReceiptModal } from '../common/AddReceiptModal';

interface FinanceTabProps {
  invoices: FeeInvoice[];
  payments: PaymentReceipt[];
  onAddPaymentReceipt: (receipt: Omit<PaymentReceipt, 'id'>) => void;
  onOpenReceiptModal: () => void;
  isReceiptModalOpen: boolean;
  onCloseReceiptModal: () => void;
  onOpenWhatsApp?: (invoice: FeeInvoice) => void;
}

export const FinanceTab: React.FC<FinanceTabProps> = ({
  invoices,
  payments,
  onAddPaymentReceipt,
  onOpenReceiptModal,
  isReceiptModalOpen,
  onCloseReceiptModal,
  onOpenWhatsApp
}) => {
  const [activeSubTab, setActiveSubTab] = useState<'invoices' | 'receipts'>('invoices');
  const [selectedReceiptForPrint, setSelectedReceiptForPrint] = useState<PaymentReceipt | null>(null);

  // Stats
  const totalInvoiced = invoices.reduce((sum, i) => sum + i.finalAmount, 0);
  const totalCollected = invoices.reduce((sum, i) => sum + i.paidAmount, 0);
  const totalRemaining = invoices.reduce((sum, i) => sum + i.remainingAmount, 0);

  const invoiceColumns: Column<FeeInvoice>[] = [
    {
      key: 'invoiceNumber',
      header: 'رقم الفاتورة',
      width: '130px',
      sortable: true,
      render: (inv) => (
        <span className="font-mono text-xs font-bold text-blue-400 bg-blue-950/60 px-2 py-0.5 rounded border border-blue-900/60">
          {inv.invoiceNumber}
        </span>
      )
    },
    {
      key: 'studentName',
      header: 'اسم الطالب',
      sortable: true,
      render: (inv) => (
        <div>
          <div className="font-bold text-slate-100">{inv.studentName}</div>
          <div className="text-[11px] text-slate-400">{inv.className}</div>
        </div>
      )
    },
    {
      key: 'feeType',
      header: 'بند الرسوم',
      sortable: true,
      render: (inv) => <span className="text-xs text-slate-300">{inv.feeType}</span>
    },
    {
      key: 'finalAmount',
      header: 'المبلغ الإجمالي',
      sortable: true,
      render: (inv) => (
        <span className="font-mono text-xs font-bold text-slate-200">
          {inv.finalAmount.toLocaleString()} د.ع
        </span>
      )
    },
    {
      key: 'paidAmount',
      header: 'المدفوع',
      sortable: true,
      render: (inv) => (
        <span className="font-mono text-xs font-bold text-emerald-400">
          {inv.paidAmount.toLocaleString()} د.ع
        </span>
      )
    },
    {
      key: 'remainingAmount',
      header: 'المتبقي',
      sortable: true,
      render: (inv) => (
        <span className="font-mono text-xs font-bold text-rose-400">
          {inv.remainingAmount.toLocaleString()} د.ع
        </span>
      )
    },
    {
      key: 'status',
      header: 'حالة السداد',
      sortable: true,
      render: (inv) => (
        <span
          className={`text-[10px] font-bold px-2 py-0.5 rounded-full border ${
            inv.status === 'Paid'
              ? 'bg-emerald-950 text-emerald-300 border-emerald-800'
              : inv.status === 'Partial'
              ? 'bg-amber-950 text-amber-300 border-amber-800'
              : 'bg-rose-950 text-rose-300 border-rose-800'
          }`}
        >
          {inv.status === 'Paid' ? 'مسدد بالكامل' : inv.status === 'Partial' ? 'مسدد جزئياً' : 'غير مسدد'}
        </span>
      )
    },
    {
      key: 'actions',
      header: 'واتساب',
      width: '90px',
      render: (inv) => (
        onOpenWhatsApp ? (
          <button
            onClick={(e) => {
              e.stopPropagation();
              onOpenWhatsApp(inv);
            }}
            className="flex items-center gap-1 px-2 py-1 bg-emerald-950 hover:bg-emerald-900 text-emerald-400 hover:text-emerald-300 border border-emerald-800 rounded-lg text-xs font-bold transition-colors cursor-pointer"
            title="إرسال إشعار مطالبة مالية بالواتساب"
          >
            <MessageSquare className="w-3.5 h-3.5" />
            <span>تذكير</span>
          </button>
        ) : null
      )
    }
  ];

  const receiptColumns: Column<PaymentReceipt>[] = [
    {
      key: 'receiptNumber',
      header: 'رقم السند',
      width: '130px',
      sortable: true,
      render: (r) => (
        <span className="font-mono text-xs font-bold text-emerald-400 bg-emerald-950/60 px-2 py-0.5 rounded border border-emerald-900/60">
          {r.receiptNumber}
        </span>
      )
    },
    {
      key: 'studentName',
      header: 'الطالب',
      sortable: true,
      render: (r) => <span className="font-bold text-slate-100">{r.studentName}</span>
    },
    {
      key: 'amount',
      header: 'المبلغ المحصل',
      sortable: true,
      render: (r) => (
        <span className="font-mono text-xs font-black text-emerald-400">
          {r.amount.toLocaleString()} د.ع
        </span>
      )
    },
    {
      key: 'paymentMethod',
      header: 'طريقة الدفع',
      sortable: true,
      render: (r) => (
        <span className="text-xs bg-slate-800 text-slate-200 px-2 py-0.5 rounded border border-slate-700">
          {r.paymentMethod}
        </span>
      )
    },
    {
      key: 'date',
      header: 'التاريخ',
      sortable: true,
      render: (r) => <span className="font-mono text-xs text-slate-400">{r.date}</span>
    },
    {
      key: 'cashierName',
      header: 'أمين الصندوق',
      render: (r) => <span className="text-xs text-slate-300">{r.cashierName}</span>
    },
    {
      key: 'actions',
      header: 'طباعة',
      render: (r) => (
        <button
          onClick={() => setSelectedReceiptForPrint(r)}
          className="flex items-center gap-1 px-2.5 py-1 bg-slate-800 hover:bg-slate-700 text-blue-300 text-xs font-semibold rounded-lg transition-colors cursor-pointer"
        >
          <Printer className="w-3.5 h-3.5" />
          <span>سند رسمي</span>
        </button>
      )
    }
  ];

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Top Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-teal-600/20 border border-teal-500/40 rounded-xl text-teal-400">
            <Receipt className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">القسم المالي وإدارة الرسوم المدرسية</h2>
            <p className="text-xs text-slate-400">إصدار الفواتير، سندات القبض، متابعة الأقساط والذمم المالية</p>
          </div>
        </div>

        <div className="flex items-center gap-3">
          {/* Sub Tab Toggle */}
          <div className="flex items-center gap-1 bg-slate-950 border border-slate-800 p-1 rounded-xl text-xs font-bold">
            <button
              onClick={() => setActiveSubTab('invoices')}
              className={`px-3 py-1.5 rounded-lg transition-colors cursor-pointer ${
                activeSubTab === 'invoices' ? 'bg-blue-600 text-white' : 'text-slate-400 hover:text-white'
              }`}
            >
              فواتير الطلاب
            </button>
            <button
              onClick={() => setActiveSubTab('receipts')}
              className={`px-3 py-1.5 rounded-lg transition-colors cursor-pointer ${
                activeSubTab === 'receipts' ? 'bg-blue-600 text-white' : 'text-slate-400 hover:text-white'
              }`}
            >
              سندات القبض (Receipts)
            </button>
          </div>

          <button
            onClick={onOpenReceiptModal}
            className="flex items-center gap-2 px-4 py-2 bg-emerald-600 hover:bg-emerald-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-emerald-600/30 transition-all cursor-pointer"
          >
            <CreditCard className="w-4 h-4" />
            <span>إصدار سند قبض جديد</span>
          </button>
        </div>
      </div>

      {/* Summary Cards */}
      <div className="grid grid-cols-1 sm:grid-cols-3 gap-4">
        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-lg">
          <div className="text-xs text-slate-400 font-semibold">إجمالي المطالبات والفواتير</div>
          <div className="text-2xl font-black text-white mt-1">{totalInvoiced.toLocaleString()} د.ع</div>
          <div className="text-[11px] text-slate-500 mt-1">شاملة لكافة الطلاب والرسوم</div>
        </div>

        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-lg">
          <div className="text-xs text-emerald-400 font-semibold">إجمالي الرسوم المحصلة فعلياً</div>
          <div className="text-2xl font-black text-emerald-400 mt-1">{totalCollected.toLocaleString()} د.ع</div>
          <div className="text-[11px] text-emerald-500 mt-1">
            نسبة التحصيل: {totalInvoiced > 0 ? Math.round((totalCollected / totalInvoiced) * 100) : 0}%
          </div>
        </div>

        <div className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-lg">
          <div className="text-xs text-rose-400 font-semibold">المبالغ المتبقية والذمم المعلقة</div>
          <div className="text-2xl font-black text-rose-400 mt-1">{totalRemaining.toLocaleString()} د.ع</div>
          <div className="text-[11px] text-rose-400 mt-1">تتطلب متابعة وإرسال تذكيرات</div>
        </div>
      </div>

      {/* Grid View */}
      {activeSubTab === 'invoices' ? (
        <ModernDataGrid
          id="invoices-grid"
          data={invoices}
          columns={invoiceColumns}
          searchPlaceholder="بحث برقم الفاتورة، اسم الطالب، أو حالة السداد..."
          searchFields={['invoiceNumber', 'studentName', 'className', 'status']}
          exportFileName="Invoices_Export_Edura"
        />
      ) : (
        <ModernDataGrid
          id="receipts-grid"
          data={payments}
          columns={receiptColumns}
          searchPlaceholder="بحث برقم السند، اسم الطالب، أو أمين الصندوق..."
          searchFields={['receiptNumber', 'studentName', 'paymentMethod', 'cashierName']}
          exportFileName="Receipts_Export_Edura"
        />
      )}

      {/* Add Receipt Modal */}
      <AddReceiptModal
        isOpen={isReceiptModalOpen}
        onClose={onCloseReceiptModal}
        invoices={invoices}
        onAddReceipt={onAddPaymentReceipt}
      />

      {/* Print Receipt Voucher Dialog */}
      {selectedReceiptForPrint && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/80 backdrop-blur-xs">
          <div className="bg-white text-slate-900 rounded-2xl max-w-xl w-full p-8 shadow-2xl space-y-6">
            {/* School Receipt Header */}
            <div className="border-b-2 border-slate-900 pb-4 flex justify-between items-start">
              <div>
                <h2 className="text-lg font-black text-slate-900">ثانوية دجلة الأهلية للبنين</h2>
                <div className="text-xs text-slate-600">جمهورية العراق - وزارة التربية</div>
                <div className="text-xs text-slate-600">بغداد - الكرخ - حي المنصور</div>
              </div>
              <div className="text-left font-mono">
                <div className="text-xs text-slate-500">سند قبض رسمي</div>
                <div className="text-base font-bold text-blue-800">{selectedReceiptForPrint.receiptNumber}</div>
                <div className="text-xs text-slate-600">التاريخ: {selectedReceiptForPrint.date}</div>
              </div>
            </div>

            {/* Receipt Body */}
            <div className="space-y-3 text-sm">
              <div className="p-3 bg-slate-100 rounded-xl flex justify-between">
                <span className="font-bold">استلمنا من المكرم ولي أمر الطالب:</span>
                <span className="font-bold text-blue-900">{selectedReceiptForPrint.studentName}</span>
              </div>

              <div className="flex justify-between border-b border-slate-200 py-2">
                <span className="text-slate-600">المبلغ رقماً:</span>
                <span className="font-bold font-mono text-base text-emerald-700">
                  {selectedReceiptForPrint.amount.toLocaleString()} د.ع (دينار عراقي)
                </span>
              </div>

              <div className="flex justify-between border-b border-slate-200 py-2">
                <span className="text-slate-600">طريقة الدفع:</span>
                <span className="font-bold">{selectedReceiptForPrint.paymentMethod}</span>
              </div>

              <div className="flex justify-between border-b border-slate-200 py-2">
                <span className="text-slate-600">الرقم المرجعي للعملية:</span>
                <span className="font-mono">{selectedReceiptForPrint.referenceNumber}</span>
              </div>

              <div className="flex justify-between border-b border-slate-200 py-2">
                <span className="text-slate-600">أمين الصندوق:</span>
                <span className="font-bold">{selectedReceiptForPrint.cashierName}</span>
              </div>
            </div>

            {/* Actions */}
            <div className="flex items-center justify-end gap-3 pt-4 border-t border-slate-200">
              <button
                type="button"
                onClick={() => setSelectedReceiptForPrint(null)}
                className="px-4 py-2 bg-slate-200 text-slate-700 rounded-xl text-xs font-bold"
              >
                إغلاق
              </button>
              <button
                type="button"
                onClick={() => window.print()}
                className="flex items-center gap-1.5 px-5 py-2 bg-blue-700 hover:bg-blue-600 text-white rounded-xl text-xs font-bold"
              >
                <Printer className="w-4 h-4" />
                <span>طباعة السند</span>
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};
