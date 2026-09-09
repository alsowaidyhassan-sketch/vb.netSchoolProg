import React, { useState } from 'react';
import { FileCheck2, Award, CheckCircle2, Save, Filter, Plus } from 'lucide-react';
import { StudentGrade, ExamRecord } from '../../types';
import { ModernDataGrid, Column } from '../common/ModernDataGrid';

interface ExamsTabProps {
  grades: StudentGrade[];
  exams: ExamRecord[];
  onUpdateGrade: (grade: StudentGrade) => void;
}

export const ExamsTab: React.FC<ExamsTabProps> = ({ grades, exams, onUpdateGrade }) => {
  const [activeView, setActiveView] = useState<'gradebook' | 'exams'>('gradebook');
  const [editingGrade, setEditingGrade] = useState<StudentGrade | null>(null);

  const calculateGradeDetails = (midterm: number, quiz: number, homework: number, final: number) => {
    const total = Math.min(100, Math.max(0, midterm + quiz + homework + final));
    let letter = 'F (راسب)';
    let isPassed = false;
    if (total >= 95) {
      letter = 'A+ (ممتاز مرتفع)';
      isPassed = true;
    } else if (total >= 90) {
      letter = 'A (ممتاز)';
      isPassed = true;
    } else if (total >= 85) {
      letter = 'B+ (جيد جداً مرتفع)';
      isPassed = true;
    } else if (total >= 80) {
      letter = 'B (جيد جداً)';
      isPassed = true;
    } else if (total >= 75) {
      letter = 'C+ (جيد مرتفع)';
      isPassed = true;
    } else if (total >= 60) {
      letter = 'D (مقبول)';
      isPassed = true;
    }

    return { total, percentage: total, gradeLetter: letter, isPassed };
  };

  const handleSaveEdit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!editingGrade) return;

    const computed = calculateGradeDetails(
      Number(editingGrade.midtermScore),
      Number(editingGrade.quizScore),
      Number(editingGrade.homeworkScore),
      Number(editingGrade.finalScore)
    );

    onUpdateGrade({
      ...editingGrade,
      totalScore: computed.total,
      percentage: computed.percentage,
      gradeLetter: computed.gradeLetter,
      isPassed: computed.isPassed
    });

    setEditingGrade(null);
  };

  const gradeColumns: Column<StudentGrade>[] = [
    {
      key: 'studentNumber',
      header: 'الرقم الأكاديمي',
      width: '120px',
      sortable: true,
      render: (g) => <span className="font-mono text-xs text-blue-400 font-bold">{g.studentNumber}</span>
    },
    {
      key: 'studentName',
      header: 'اسم الطالب',
      sortable: true,
      render: (g) => <span className="font-bold text-slate-100">{g.studentName}</span>
    },
    {
      key: 'subjectName',
      header: 'المادة',
      sortable: true,
      render: (g) => <span className="text-xs text-slate-300 font-medium">{g.subjectName}</span>
    },
    {
      key: 'midtermScore',
      header: 'نصفي (30)',
      sortable: true,
      render: (g) => <span className="font-mono text-xs text-slate-200">{g.midtermScore}</span>
    },
    {
      key: 'quizScore',
      header: 'كويز (20)',
      sortable: true,
      render: (g) => <span className="font-mono text-xs text-slate-200">{g.quizScore}</span>
    },
    {
      key: 'homeworkScore',
      header: 'واجبات (10)',
      sortable: true,
      render: (g) => <span className="font-mono text-xs text-slate-200">{g.homeworkScore}</span>
    },
    {
      key: 'finalScore',
      header: 'نهائي (40)',
      sortable: true,
      render: (g) => <span className="font-mono text-xs text-slate-200">{g.finalScore}</span>
    },
    {
      key: 'totalScore',
      header: 'المجموع (100)',
      sortable: true,
      render: (g) => (
        <span className="font-mono text-xs font-black text-blue-400 bg-blue-950 px-2 py-0.5 rounded border border-blue-800">
          {g.totalScore}
        </span>
      )
    },
    {
      key: 'gradeLetter',
      header: 'التقدير',
      sortable: true,
      render: (g) => (
        <span className="text-xs font-bold text-emerald-400">{g.gradeLetter}</span>
      )
    },
    {
      key: 'isPassed',
      header: 'النتيجة',
      render: (g) => (
        <span
          className={`text-[10px] font-bold px-2 py-0.5 rounded-full border ${
            g.isPassed
              ? 'bg-emerald-950 text-emerald-300 border-emerald-800'
              : 'bg-rose-950 text-rose-300 border-rose-800'
          }`}
        >
          {g.isPassed ? 'ناجح' : 'راسب'}
        </span>
      )
    },
    {
      key: 'actions',
      header: 'رصد',
      render: (g) => (
        <button
          onClick={() => setEditingGrade(g)}
          className="px-2.5 py-1 bg-slate-800 hover:bg-slate-700 text-blue-300 text-xs font-semibold rounded-lg transition-colors cursor-pointer"
        >
          تعديل الدرجات
        </button>
      )
    }
  ];

  return (
    <div className="p-6 space-y-4 max-w-7xl mx-auto">
      {/* Header */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-purple-600/20 border border-purple-500/40 rounded-xl text-purple-400">
            <Award className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">الكنترول المدرسي ورصد الدرجات والامتحانات</h2>
            <p className="text-xs text-slate-400">سجل الدرجات التراكمي، حساب المعدلات التلقائي، والشهادات</p>
          </div>
        </div>

        {/* View Toggle */}
        <div className="flex items-center gap-1 bg-slate-950 border border-slate-800 p-1 rounded-xl text-xs font-bold">
          <button
            onClick={() => setActiveView('gradebook')}
            className={`px-3 py-1.5 rounded-lg transition-colors cursor-pointer ${
              activeView === 'gradebook' ? 'bg-blue-600 text-white' : 'text-slate-400 hover:text-white'
            }`}
          >
            سجل الدرجات (Gradebook)
          </button>
          <button
            onClick={() => setActiveView('exams')}
            className={`px-3 py-1.5 rounded-lg transition-colors cursor-pointer ${
              activeView === 'exams' ? 'bg-blue-600 text-white' : 'text-slate-400 hover:text-white'
            }`}
          >
            جدول الاختبارات الرسمية
          </button>
        </div>
      </div>

      {activeView === 'gradebook' ? (
        <ModernDataGrid
          id="grades-grid"
          data={grades}
          columns={gradeColumns}
          searchPlaceholder="بحث باسم الطالب، المادة، أو التقدير..."
          searchFields={['studentName', 'studentNumber', 'subjectName', 'gradeLetter']}
          exportFileName="Grades_Export_Edura"
        />
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          {exams.map((ex) => (
            <div
              key={ex.id}
              className="bg-slate-900 border border-slate-800 rounded-2xl p-5 shadow-lg space-y-3"
            >
              <div className="flex items-center justify-between">
                <span className="text-[10px] font-bold px-2 py-0.5 rounded bg-purple-950 text-purple-300 border border-purple-800">
                  {ex.examType}
                </span>
                <span className="font-mono text-xs text-slate-400">{ex.examDate}</span>
              </div>
              <h3 className="text-sm font-bold text-white">{ex.examName}</h3>
              <div className="text-xs text-slate-300">
                المادة: <span className="font-semibold text-blue-300">{ex.subjectName}</span>
              </div>
              <div className="text-xs text-slate-300">
                الفصل: <span className="font-semibold">{ex.className}</span>
              </div>
              <div className="pt-2 border-t border-slate-800 flex justify-between text-xs font-mono">
                <span className="text-slate-400">الدرجة العظمى: {ex.maxScore}</span>
                <span className="text-emerald-400 font-bold">النجاح: {ex.passingScore}</span>
              </div>
            </div>
          ))}
        </div>
      )}

      {/* Edit Grade Modal */}
      {editingGrade && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs">
          <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-md w-full p-6 shadow-2xl space-y-4 text-xs">
            <h3 className="text-base font-bold text-white border-b border-slate-800 pb-2">
              رصد وتعديل درجات: {editingGrade.studentName}
            </h3>
            <p className="text-slate-400">المادة: {editingGrade.subjectName}</p>

            <form onSubmit={handleSaveEdit} className="space-y-3">
              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">اختبار نصفي (من 30)</label>
                  <input
                    type="number"
                    max={30}
                    min={0}
                    value={editingGrade.midtermScore}
                    onChange={(e) =>
                      setEditingGrade({ ...editingGrade, midtermScore: Number(e.target.value) })
                    }
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">اختبارات قصيرة (من 20)</label>
                  <input
                    type="number"
                    max={20}
                    min={0}
                    value={editingGrade.quizScore}
                    onChange={(e) =>
                      setEditingGrade({ ...editingGrade, quizScore: Number(e.target.value) })
                    }
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
              </div>

              <div className="grid grid-cols-2 gap-3">
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">مهام وواجبات (من 10)</label>
                  <input
                    type="number"
                    max={10}
                    min={0}
                    value={editingGrade.homeworkScore}
                    onChange={(e) =>
                      setEditingGrade({ ...editingGrade, homeworkScore: Number(e.target.value) })
                    }
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
                <div>
                  <label className="block text-slate-300 font-semibold mb-1">اختبار نهائي (من 40)</label>
                  <input
                    type="number"
                    max={40}
                    min={0}
                    value={editingGrade.finalScore}
                    onChange={(e) =>
                      setEditingGrade({ ...editingGrade, finalScore: Number(e.target.value) })
                    }
                    className="w-full bg-slate-950 border border-slate-800 rounded-lg p-2 text-white font-mono"
                  />
                </div>
              </div>

              <div className="flex items-center justify-end gap-2 pt-3 border-t border-slate-800">
                <button
                  type="button"
                  onClick={() => setEditingGrade(null)}
                  className="px-4 py-2 bg-slate-800 text-slate-300 rounded-xl"
                >
                  إلغاء
                </button>
                <button
                  type="submit"
                  className="px-5 py-2 bg-blue-600 hover:bg-blue-500 text-white font-bold rounded-xl"
                >
                  حفظ واحتساب المعدل
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </div>
  );
};
