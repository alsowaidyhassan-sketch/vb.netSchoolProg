import React, { useState } from 'react';
import { BookOpen, Plus, Award, Clock } from 'lucide-react';
import { Subject } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface SubjectsTabProps {
  subjects: Subject[];
  onAddSubject: (subject: Omit<Subject, 'id'>) => void;
}

export const SubjectsTab: React.FC<SubjectsTabProps> = ({ subjects, onAddSubject }) => {
  const [isOpen, setIsOpen] = useState(false);
  const [code, setCode] = useState('');
  const [name, setName] = useState('');
  const [creditHours, setCreditHours] = useState(4);
  const [maxScore, setMaxScore] = useState(100);
  const [passingScore, setPassingScore] = useState(50);
  const [teacherName, setTeacherName] = useState('أ. محمد سالم الغامدي');
  const [targetClass, setTargetClass] = useState('الصف الأول المتوسط');

  const handleAdd = (e: React.FormEvent) => {
    e.preventDefault();
    if (!name.trim() || !code.trim()) return;

    onAddSubject({
      code: code.trim().toUpperCase(),
      name: name.trim(),
      creditHours: Number(creditHours),
      maxScore: Number(maxScore),
      passingScore: Number(passingScore),
      teacherName,
      targetClass
    });

    setCode('');
    setName('');
    setIsOpen(false);
  };

  const columns: Column<Subject>[] = [
    {
      key: 'code',
      header: 'رمز المادة',
      width: '120px',
      sortable: true,
      render: (s) => (
        <span className="font-mono text-xs font-bold text-amber-400 bg-amber-950/60 px-2 py-0.5 rounded border border-amber-900/60">
          {s.code}
        </span>
      )
    },
    {
      key: 'name',
      header: 'اسم المادة الدراسية',
      sortable: true,
      render: (s) => (
        <div className="font-bold text-slate-100 flex items-center gap-2">
          <BookOpen className="w-4 h-4 text-blue-400" />
          <span>{s.name}</span>
        </div>
      )
    },
    {
      key: 'targetClass',
      header: 'الصف المستهدف',
      sortable: true,
      render: (s) => <span className="text-xs text-slate-300">{s.targetClass}</span>
    },
    {
      key: 'teacherName',
      header: 'رئيس المادة / المعلم',
      sortable: true,
      render: (s) => <span className="text-xs text-slate-300 font-medium">{s.teacherName}</span>
    },
    {
      key: 'creditHours',
      header: 'الحصص الأسبوعية',
      sortable: true,
      width: '130px',
      render: (s) => (
        <span className="font-mono text-xs text-slate-300">
          {s.creditHours} حصص
        </span>
      )
    },
    {
      key: 'passingScore',
      header: 'درجة النجاح / النهاية العظمى',
      sortable: true,
      render: (s) => (
        <span className="font-mono text-xs text-emerald-400 font-bold">
          {s.passingScore} / {s.maxScore}
        </span>
      )
    }
  ];

  return (
    <div className="p-6 space-y-4 max-w-7xl mx-auto">
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-amber-600/20 border border-amber-500/40 rounded-xl text-amber-400">
            <BookOpen className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">الخطة الدراسية والمناهج (Curriculum & Subjects)</h2>
            <p className="text-xs text-slate-400">توصيف المواد، الأوزان النسبية، والدرجات العظمى والصغرى</p>
          </div>
        </div>

        <button
          onClick={() => setIsOpen(true)}
          className="flex items-center gap-2 px-4 py-2 bg-amber-600 hover:bg-amber-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-amber-600/30 transition-all cursor-pointer"
        >
          <Plus className="w-4 h-4" />
          <span>إضافة مادة دراسية</span>
        </button>
      </div>

      <ModernDataGrid
        id="subjects-grid"
        data={subjects}
        columns={columns}
        searchPlaceholder="بحث برمز المادة، الاسم، أو المعلم..."
        searchFields={['name', 'code', 'teacherName', 'targetClass']}
        exportFileName="Subjects_Export_Edura"
      />

      {isOpen && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4 text-xs">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2">
              إضافة مادة دراسية للخطة الأكاديمية
            </h3>
            <form onSubmit={handleAdd} className="space-y-3">
              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">رمز المادة *</label>
                  <input
                    type="text"
                    required
                    placeholder="مثال: CHEM-101"
                    value={code}
                    onChange={(e) => setCode(e.target.value)}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">الحصص أسبوعياً</label>
                  <input
                    type="number"
                    value={creditHours}
                    onChange={(e) => setCreditHours(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">اسم المادة الدراسية *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: الكيمياء العامة"
                  value={name}
                  onChange={(e) => setName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                />
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">الدرجة العظمى</label>
                  <input
                    type="number"
                    value={maxScore}
                    onChange={(e) => setMaxScore(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">درجة النجاح</label>
                  <input
                    type="number"
                    value={passingScore}
                    onChange={(e) => setPassingScore(Number(e.target.value))}
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
              </div>

              <div>
                <label className="block text-slate-300 font-semibold mb-1">الصف المستهدف</label>
                <input
                  type="text"
                  value={targetClass}
                  onChange={(e) => setTargetClass(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white"
                />
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
                  className="px-5 py-2 bg-amber-600 hover:bg-amber-500 text-white font-bold rounded-xl"
                >
                  حفظ المادة
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
