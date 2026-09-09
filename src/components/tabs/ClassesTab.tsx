import React, { useState } from 'react';
import { School, Users, Plus, CheckCircle, DoorOpen } from 'lucide-react';
import { ClassSection } from '../../types';

interface ClassesTabProps {
  classes: ClassSection[];
  onAddClass: (newClass: Omit<ClassSection, 'id'>) => void;
}

export const ClassesTab: React.FC<ClassesTabProps> = ({ classes, onAddClass }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [gradeName, setGradeName] = useState('المرحلة الابتدائية');
  const [className, setClassName] = useState('');
  const [sectionName, setSectionName] = useState('أ');
  const [roomNumber, setRoomNumber] = useState('قاعة ');
  const [capacity, setCapacity] = useState(30);
  const [supervisorTeacher, setSupervisorTeacher] = useState('أ. محمد الغامدي');

  const handleAdd = (e: React.FormEvent) => {
    e.preventDefault();
    if (!className.trim()) return;

    onAddClass({
      gradeName,
      className: className.trim(),
      sectionName: sectionName.trim(),
      roomNumber: roomNumber.trim(),
      capacity: Number(capacity),
      currentStudentsCount: 0,
      supervisorTeacher
    });

    setClassName('');
    setIsOpen(false);
  };

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-sky-600/20 border border-sky-500/40 rounded-xl text-sky-400">
            <School className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">إدارة الفصول والشعب والقاعات الدراسية</h2>
            <p className="text-xs text-slate-400">توزيع الطلاب، الطاقة الاستيعابية، ورواد الفصول</p>
          </div>
        </div>

        <button
          onClick={() => setIsOpen(true)}
          className="flex items-center gap-2 px-4 py-2 bg-sky-600 hover:bg-sky-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-sky-600/30 transition-all cursor-pointer"
        >
          <Plus className="w-4 h-4" />
          <span>إضافة شعبة / قاعة جديدة</span>
        </button>
      </div>

      {/* Grid of Class Cards */}
      <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5">
        {classes.map((cls) => {
          const occupancyRate = Math.round((cls.currentStudentsCount / cls.capacity) * 100);
          return (
            <div
              key={cls.id}
              className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-xl hover:border-slate-700 transition-all flex flex-col justify-between space-y-4"
            >
              <div>
                <div className="flex items-center justify-between">
                  <span className="text-[10px] font-bold px-2 py-0.5 rounded-md bg-slate-950 border border-slate-800 text-slate-400">
                    {cls.gradeName}
                  </span>
                  <span className="flex items-center gap-1 text-[11px] font-mono text-sky-400 font-bold">
                    <DoorOpen className="w-3.5 h-3.5" />
                    <span>{cls.roomNumber}</span>
                  </span>
                </div>

                <h3 className="text-base font-bold text-white mt-2">{cls.className}</h3>
                <div className="text-xs text-slate-300 font-semibold mt-0.5">الشعبة: {cls.sectionName}</div>
              </div>

              {/* Occupancy Progress */}
              <div className="space-y-1.5 bg-slate-950/60 p-3 rounded-xl border border-slate-800/80">
                <div className="flex justify-between text-xs font-semibold">
                  <span className="text-slate-400">نسبة الإشغال:</span>
                  <span className={occupancyRate >= 90 ? 'text-rose-400' : 'text-emerald-400'}>
                    {cls.currentStudentsCount} / {cls.capacity} طالب ({occupancyRate}%)
                  </span>
                </div>
                <div className="w-full h-2.5 bg-slate-900 rounded-full overflow-hidden border border-slate-800">
                  <div
                    style={{ width: `${Math.min(100, occupancyRate)}%` }}
                    className={`h-full rounded-full ${
                      occupancyRate >= 90 ? 'bg-rose-500' : 'bg-sky-500'
                    }`}
                  ></div>
                </div>
              </div>

              <div className="pt-2 border-t border-slate-800 flex items-center justify-between text-xs text-slate-400">
                <span>رائد الفصل:</span>
                <span className="font-bold text-slate-200">{cls.supervisorTeacher}</span>
              </div>
            </div>
          );
        })}
      </div>

      {/* Add Modal */}
      {isOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4 text-xs">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2">
              إضافة شعبة دراسية جديدة
            </h3>
            <form onSubmit={handleAdd} className="space-y-3">
              <div>
                <label className="block text-slate-300 font-semibold mb-1">المرحلة الدراسية</label>
                <select
                  value={gradeName}
                  onChange={(e) => setGradeName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                >
                  <option value="المرحلة الابتدائية">المرحلة الابتدائية</option>
                  <option value="المرحلة المتوسطة">المرحلة المتوسطة</option>
                  <option value="المرحلة الثانوية">المرحلة الثانوية</option>
                </select>
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">اسم الصف *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: الصف الثاني المتوسط"
                  value={className}
                  onChange={(e) => setClassName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                />
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">رمز الشعبة</label>
                  <input
                    type="text"
                    value={sectionName}
                    onChange={(e) => setSectionName(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">رقم القاعة</label>
                  <input
                    type="text"
                    value={roomNumber}
                    onChange={(e) => setRoomNumber(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                  />
                </div>
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">الطاقة الاستيعابية</label>
                  <input
                    type="number"
                    value={capacity}
                    onChange={(e) => setCapacity(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">رائد الفصل</label>
                  <input
                    type="text"
                    value={supervisorTeacher}
                    onChange={(e) => setSupervisorTeacher(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                  />
                </div>
              </div>

              <div className="flex items-center justify-end gap-2 pt-3 border-t border-slate-800">
                <button
                  type="button"
                  onClick={() => setIsOpen(false)}
                  className="px-4 py-2 bg-slate-800 text-slate-300 rounded-xl"
                >
                  إلغاء
                </button>
                <button
                  type="submit"
                  className="px-5 py-2 bg-sky-600 hover:bg-sky-500 text-white font-bold rounded-xl"
                >
                  حفظ القاعة
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
