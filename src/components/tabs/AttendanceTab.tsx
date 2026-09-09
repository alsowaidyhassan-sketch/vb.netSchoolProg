import React, { useState } from 'react';
import {
  CalendarCheck,
  CheckCircle2,
  Clock,
  UserX,
  FileText,
  Save,
  Check,
  Calendar,
  Filter
} from 'lucide-react';
import { Student, AttendanceRecord } from '../../types';

interface AttendanceTabProps {
  students: Student[];
  attendance: AttendanceRecord[];
  onSaveAttendance: (records: AttendanceRecord[]) => void;
  classesList: string[];
}

export const AttendanceTab: React.FC<AttendanceTabProps> = ({
  students,
  attendance,
  onSaveAttendance,
  classesList
}) => {
  const [selectedDate, setSelectedDate] = useState('2025-05-12');
  const [selectedClass, setSelectedClass] = useState(classesList[0] || 'الصف الأول الابتدائي');
  const [statusMap, setStatusMap] = useState<Record<number, 'Present' | 'Absent' | 'Late' | 'Excused'>>(() => {
    const initial: Record<number, 'Present' | 'Absent' | 'Late' | 'Excused'> = {};
    students.forEach((s) => {
      const existing = attendance.find((a) => a.studentId === s.id && a.date === '2025-05-12');
      initial[s.id] = existing ? existing.status : 'Present';
    });
    return initial;
  });
  const [savedSuccess, setSavedSuccess] = useState(false);

  // Filter students by selected class
  const classStudents = students.filter((s) => s.className === selectedClass);

  const handleStatusChange = (studentId: number, status: 'Present' | 'Absent' | 'Late' | 'Excused') => {
    setStatusMap((prev) => ({ ...prev, [studentId]: status }));
  };

  const markAllPresent = () => {
    const updated: Record<number, 'Present' | 'Absent' | 'Late' | 'Excused'> = { ...statusMap };
    classStudents.forEach((s) => {
      updated[s.id] = 'Present';
    });
    setStatusMap(updated);
  };

  const handleSave = () => {
    const recordsToSave: AttendanceRecord[] = classStudents.map((s) => ({
      id: Date.now() + s.id,
      studentId: s.id,
      studentName: s.fullName,
      studentNumber: s.studentNumber,
      sectionName: s.sectionName,
      date: selectedDate,
      status: statusMap[s.id] || 'Present',
      lateMinutes: statusMap[s.id] === 'Late' ? 15 : undefined,
      notes: statusMap[s.id] === 'Excused' ? 'عذر مسجل مسبقاً' : undefined
    }));

    onSaveAttendance(recordsToSave);
    setSavedSuccess(true);
    setTimeout(() => setSavedSuccess(false), 3000);
  };

  // Counts
  const presentCount = classStudents.filter((s) => (statusMap[s.id] || 'Present') === 'Present').length;
  const lateCount = classStudents.filter((s) => statusMap[s.id] === 'Late').length;
  const excusedCount = classStudents.filter((s) => statusMap[s.id] === 'Excused').length;
  const absentCount = classStudents.filter((s) => statusMap[s.id] === 'Absent').length;

  return (
    <div className="p-6 space-y-6 max-w-7xl mx-auto">
      {/* Top Filter & Actions */}
      <div className="flex flex-wrap items-center justify-between gap-4 bg-slate-900 border border-slate-800 p-4 rounded-2xl shadow-lg">
        <div className="flex items-center gap-3">
          <div className="p-3 bg-emerald-600/20 border border-emerald-500/40 rounded-xl text-emerald-400">
            <CalendarCheck className="w-6 h-6" />
          </div>
          <div>
            <h2 className="text-lg font-bold text-white">رصد وتسجيل الحضور والغياب اليومي</h2>
            <p className="text-xs text-slate-400">نظام الرصد الفوري الذكي لكل فصل وشعبة مع إشعار أولياء الأمور</p>
          </div>
        </div>

        <div className="flex flex-wrap items-center gap-3">
          {/* Class Select */}
          <div className="bg-slate-950 border border-slate-800 rounded-xl px-3 py-1.5 text-xs flex items-center gap-2">
            <Filter className="w-3.5 h-3.5 text-slate-400" />
            <select
              value={selectedClass}
              onChange={(e) => setSelectedClass(e.target.value)}
              className="bg-transparent text-slate-200 focus:outline-none cursor-pointer"
            >
              {classesList.map((c, i) => (
                <option key={i} value={c}>
                  {c}
                </option>
              ))}
            </select>
          </div>

          {/* Date Picker */}
          <div className="bg-slate-950 border border-slate-800 rounded-xl px-3 py-1.5 text-xs flex items-center gap-2">
            <Calendar className="w-3.5 h-3.5 text-slate-400" />
            <input
              type="date"
              value={selectedDate}
              onChange={(e) => setSelectedDate(e.target.value)}
              className="bg-transparent text-slate-200 focus:outline-none font-mono cursor-pointer"
            />
          </div>

          {/* Mark All Present */}
          <button
            onClick={markAllPresent}
            className="px-3.5 py-1.5 bg-slate-800 hover:bg-slate-700 text-emerald-400 text-xs font-bold rounded-xl border border-slate-700 transition-colors cursor-pointer"
          >
            تحديد الكل كحاضر
          </button>

          {/* Save Button */}
          <button
            onClick={handleSave}
            className="flex items-center gap-1.5 px-5 py-2 bg-emerald-600 hover:bg-emerald-500 text-white text-xs font-bold rounded-xl shadow-lg shadow-emerald-600/30 transition-all cursor-pointer"
          >
            <Save className="w-4 h-4" />
            <span>حفظ واعتماد الكشف</span>
          </button>
        </div>
      </div>

      {/* Counters Bar */}
      <div className="grid grid-cols-2 sm:grid-cols-4 gap-3">
        <div className="p-3.5 rounded-xl bg-emerald-950/40 border border-emerald-800/60 flex items-center justify-between">
          <div>
            <div className="text-xs text-emerald-300 font-semibold">حاضر (Present)</div>
            <div className="text-xl font-black text-emerald-400 mt-0.5">{presentCount} طلاب</div>
          </div>
          <CheckCircle2 className="w-6 h-6 text-emerald-400 opacity-70" />
        </div>

        <div className="p-3.5 rounded-xl bg-amber-950/40 border border-amber-800/60 flex items-center justify-between">
          <div>
            <div className="text-xs text-amber-300 font-semibold">متأخر (Late)</div>
            <div className="text-xl font-black text-amber-400 mt-0.5">{lateCount} طلاب</div>
          </div>
          <Clock className="w-6 h-6 text-amber-400 opacity-70" />
        </div>

        <div className="p-3.5 rounded-xl bg-sky-950/40 border border-sky-800/60 flex items-center justify-between">
          <div>
            <div className="text-xs text-sky-300 font-semibold">بعذر (Excused)</div>
            <div className="text-xl font-black text-sky-400 mt-0.5">{excusedCount} طلاب</div>
          </div>
          <FileText className="w-6 h-6 text-sky-400 opacity-70" />
        </div>

        <div className="p-3.5 rounded-xl bg-rose-950/40 border border-rose-800/60 flex items-center justify-between">
          <div>
            <div className="text-xs text-rose-300 font-semibold">غياب بدون عذر</div>
            <div className="text-xl font-black text-rose-400 mt-0.5">{absentCount} طلاب</div>
          </div>
          <UserX className="w-6 h-6 text-rose-400 opacity-70" />
        </div>
      </div>

      {/* Student Attendance List */}
      <div className="bg-slate-900 border border-slate-800 rounded-2xl overflow-hidden shadow-xl">
        <div className="p-4 bg-slate-950/70 border-b border-slate-800 flex items-center justify-between">
          <span className="text-xs font-bold text-slate-200">
            كشف طلاب {selectedClass} — تاريخ {selectedDate}
          </span>
          <span className="text-xs text-slate-400">إجمالي طلاب الشعبة: {classStudents.length}</span>
        </div>

        {classStudents.length > 0 ? (
          <div className="divide-y divide-slate-800">
            {classStudents.map((s, idx) => {
              const currentStatus = statusMap[s.id] || 'Present';
              return (
                <div
                  key={s.id}
                  className="p-4 flex flex-wrap items-center justify-between gap-3 hover:bg-slate-850/50 transition-colors"
                >
                  <div className="flex items-center gap-3">
                    <span className="text-xs font-mono text-slate-500 w-6 text-center">{idx + 1}</span>
                    <div className="w-8 h-8 rounded-lg bg-blue-600/20 border border-blue-500/30 text-blue-300 font-bold flex items-center justify-center text-xs">
                      {s.firstName[0]}
                    </div>
                    <div>
                      <div className="text-xs font-bold text-slate-100">{s.fullName}</div>
                      <div className="text-[11px] text-slate-400 font-mono">
                        {s.studentNumber} | ولي الأمر: {s.primaryParentPhone}
                      </div>
                    </div>
                  </div>

                  {/* 4 Status Toggle Buttons */}
                  <div className="flex items-center gap-1.5">
                    <button
                      type="button"
                      onClick={() => handleStatusChange(s.id, 'Present')}
                      className={`px-3 py-1.5 rounded-lg text-xs font-bold transition-all cursor-pointer ${
                        currentStatus === 'Present'
                          ? 'bg-emerald-600 text-white shadow-md shadow-emerald-600/30 ring-2 ring-emerald-400'
                          : 'bg-slate-950 text-slate-400 hover:text-emerald-300 border border-slate-800'
                      }`}
                    >
                      حاضر
                    </button>

                    <button
                      type="button"
                      onClick={() => handleStatusChange(s.id, 'Late')}
                      className={`px-3 py-1.5 rounded-lg text-xs font-bold transition-all cursor-pointer ${
                        currentStatus === 'Late'
                          ? 'bg-amber-600 text-white shadow-md shadow-amber-600/30 ring-2 ring-amber-400'
                          : 'bg-slate-950 text-slate-400 hover:text-amber-300 border border-slate-800'
                      }`}
                    >
                      متأخر
                    </button>

                    <button
                      type="button"
                      onClick={() => handleStatusChange(s.id, 'Excused')}
                      className={`px-3 py-1.5 rounded-lg text-xs font-bold transition-all cursor-pointer ${
                        currentStatus === 'Excused'
                          ? 'bg-sky-600 text-white shadow-md shadow-sky-600/30 ring-2 ring-sky-400'
                          : 'bg-slate-950 text-slate-400 hover:text-sky-300 border border-slate-800'
                      }`}
                    >
                      بعذر
                    </button>

                    <button
                      type="button"
                      onClick={() => handleStatusChange(s.id, 'Absent')}
                      className={`px-3 py-1.5 rounded-lg text-xs font-bold transition-all cursor-pointer ${
                        currentStatus === 'Absent'
                          ? 'bg-rose-600 text-white shadow-md shadow-rose-600/30 ring-2 ring-rose-400'
                          : 'bg-slate-950 text-slate-400 hover:text-rose-300 border border-slate-800'
                      }`}
                    >
                      غائب
                    </button>
                  </div>
                </div>
              );
            })}
          </div>
        ) : (
          <div className="p-8 text-center text-slate-500 text-xs">
            لا يوجد طلاب مسجلين في هذا الصف حالياً.
          </div>
        )}
      </div>

      {savedSuccess && (
        <div className="fixed bottom-12 left-1/2 -translate-x-1/2 bg-emerald-600 text-white px-5 py-2.5 rounded-xl shadow-2xl flex items-center gap-2 text-xs font-bold animate-in fade-in slide-in-from-bottom-3 duration-200 z-50">
          <Check className="w-4 h-4" />
          <span>تم رصد وحفظ كشف الحضور بنجاح وإرسال التنبيهات لأولياء الأمور!</span>
        </div>
      )}
    </div>
  );
};
