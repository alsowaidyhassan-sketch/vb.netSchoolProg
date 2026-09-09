import React, { useState } from 'react';
import { X, CreditCard, Save, Receipt, CheckCircle } from 'lucide-react';
import { FeeInvoice, PaymentReceipt } from '../../types';

interface AddReceiptModalProps {
  isOpen: boolean;
  onClose: () => void;
  invoices: FeeInvoice[];
  onAddReceipt: (receipt: Omit<PaymentReceipt, 'id'>) => void;
}

export const AddReceiptModal: React.FC<AddReceiptModalProps> = ({
  isOpen,
  onClose,
  invoices,
  onAddReceipt
}) => {
  const eligibleInvoices = invoices.filter((i) => i.status !== 'Paid');
  const [selectedInvoiceId, setSelectedInvoiceId] = useState<number>(
    eligibleInvoices[0]?.id || invoices[0]?.id || 1
  );
  const selectedInvoice = invoices.find((i) => i.id === selectedInvoiceId);

  const [amount, setAmount] = useState<number>(selectedInvoice?.remainingAmount || 5000);
  const [paymentMethod, setPaymentMethod] = useState<'مدى' | 'تحويل بنكي' | 'بطاقة ائتمان' | 'نقداً'>('مدى');
  const [referenceNumber, setReferenceNumber] = useState(`TXN-${Math.floor(1000000 + Math.random() * 9000000)}`);
  const [cashierName, setCashierName] = useState('فهد خالد الدوسري');

  if (!isOpen) return null;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!selectedInvoice || amount <= 0) return;

    const receiptNum = `REC-2025-${Math.floor(200 + Math.random() * 800)}`;
    onAddReceipt({
      receiptNumber: receiptNum,
      invoiceNumber: selectedInvoice.invoiceNumber,
      studentName: selectedInvoice.studentName,
      amount: Number(amount),
      date: new Date().toISOString().split('T')[0],
      paymentMethod,
      referenceNumber,
      cashierName
    });

    onClose();
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
      <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-lg w-full p-6 shadow-2xl space-y-4 text-xs">
        <div className="flex items-center justify-between border-b border-slate-800 pb-3">
          <div className="flex items-center gap-2">
            <div className="p-2 rounded-xl bg-emerald-600/20 border border-emerald-500/40 text-emerald-400">
              <Receipt className="w-5 h-5" />
            </div>
            <div>
              <h3 className="text-base font-bold text-white">إصدار سند قبض مالي رسمي</h3>
              <p className="text-xs text-slate-400">تسجيل دفعة نقدية أو إلكترونية في قيود الصندوق</p>
            </div>
          </div>
          <button onClick={onClose} className="p-1 text-slate-400 hover:text-white rounded-lg">
            <X className="w-5 h-5" />
          </button>
        </div>

        <form onSubmit={handleSubmit} className="space-y-3">
          <div>
            <label className="block text-slate-300 font-semibold mb-1">الفاتورة / الطالب المستهدف *</label>
            <select
              value={selectedInvoiceId}
              onChange={(e) => {
                const id = Number(e.target.value);
                setSelectedInvoiceId(id);
                const inv = invoices.find((i) => i.id === id);
                if (inv) setAmount(inv.remainingAmount);
              }}
              className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2.5 text-white"
            >
              {invoices.map((inv) => (
                <option key={inv.id} value={inv.id}>
                  {inv.studentName} — {inv.invoiceNumber} (المتبقي: {inv.remainingAmount.toLocaleString()} ر.س)
                </option>
              ))}
            </select>
          </div>

          {selectedInvoice && (
            <div className="p-3 bg-slate-950/70 rounded-xl border border-slate-800 grid grid-cols-3 gap-2 text-[11px]">
              <div>
                <span className="text-slate-500">المبلغ الأصلي:</span>
                <div className="font-bold text-slate-200">{selectedInvoice.finalAmount.toLocaleString()} ر.س</div>
              </div>
              <div>
                <span className="text-slate-500">المدفوع سابقاً:</span>
                <div className="font-bold text-emerald-400">{selectedInvoice.paidAmount.toLocaleString()} ر.س</div>
              </div>
              <div>
                <span className="text-slate-500">المتبقي حالياً:</span>
                <div className="font-bold text-rose-400 font-mono">{selectedInvoice.remainingAmount.toLocaleString()} ر.س</div>
              </div>
            </div>
          )}

          <div className="grid grid-cols-2 gap-3">
            <div>
              <label className="block text-slate-300 font-semibold mb-1">مبلغ السند المطلوب تحصيله (ر.س) *</label>
              <input
                type="number"
                required
                min={100}
                max={selectedInvoice ? selectedInvoice.remainingAmount : 100000}
                value={amount}
                onChange={(e) => setAmount(Number(e.target.value))}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono font-bold"
              />
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">طريقة الدفع *</label>
              <select
                value={paymentMethod}
                onChange={(e: any) => setPaymentMethod(e.target.value)}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-semibold"
              >
                <option value="مدى">مدى (Mada)</option>
                <option value="تحويل بنكي">تحويل بنكي (Bank Transfer)</option>
                <option value="بطاقة ائتمان">بطاقة ائتمان (Visa / MC)</option>
                <option value="نقداً">نقداً (Cash)</option>
              </select>
            </div>
          </div>

          <div className="grid grid-cols-2 gap-3">
            <div>
              <label className="block text-slate-300 font-semibold mb-1">رقم الإيصال / الحوالة البنكية</label>
              <input
                type="text"
                value={referenceNumber}
                onChange={(e) => setReferenceNumber(e.target.value)}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
              />
            </div>
            <div>
              <label className="block text-slate-300 font-semibold mb-1">أمين الصندوق المستلم</label>
              <input
                type="text"
                value={cashierName}
                onChange={(e) => setCashierName(e.target.value)}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
              />
            </div>
          </div>

          <div className="flex items-center justify-end gap-2 pt-3 border-t border-slate-800">
            <button
              type="button"
              onClick={onClose}
              className="px-4 py-2 bg-slate-800 text-slate-300 rounded-xl"
            >
              إلغاء
            </button>
            <button
              type="submit"
              className="px-5 py-2 bg-emerald-600 hover:bg-emerald-500 text-white font-bold rounded-xl shadow-lg shadow-emerald-600/30"
            >
              إصدار وترحيل السند
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};
