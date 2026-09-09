import React, { useState } from 'react';
import { X, UserPlus, AlertCircle, Save, Check } from 'lucide-react';
import { Student } from '../../types';

interface AddStudentModalProps {
  isOpen: boolean;
  onClose: () => void;
  onAddStudent: (student: Omit<Student, 'id'>) => void;
  classesList: string[];
}

export const AddStudentModal: React.FC<AddStudentModalProps> = ({
  isOpen,
  onClose,
  onAddStudent,
  classesList
}) => {
  const [firstName, setFirstName] = useState('');
  const [secondName, setSecondName] = useState('');
  const [thirdName, setThirdName] = useState('');
  const [lastName, setLastName] = useState('');
  const [nationalId, setNationalId] = useState('');
  const [gender, setGender] = useState<'ذكر' | 'أنثى'>('ذكر');
  const [dateOfBirth, setDateOfBirth] = useState('2018-05-15');
  const [birthPlace, setBirthPlace] = useState('الرياض');
  const [nationality, setNationality] = useState('سعودي');
  const [phone, setPhone] = useState('05');
  const [email, setEmail] = useState('');
  const [address, setAddress] = useState('الرياض - ');
  const [primaryParentName, setPrimaryParentName] = useState('');
  const [primaryParentPhone, setPrimaryParentPhone] = useState('05');
  const [bloodType, setBloodType] = useState('O+');
  const [className, setClassName] = useState(classesList[0] || 'الصف الأول الابتدائي');
  const [sectionName, setSectionName] = useState('أ (الصفوة)');
  const [medicalNotes, setMedicalNotes] = useState('لا توجد أمراض مزمنة أو حساسية.');
  const [error, setError] = useState('');

  if (!isOpen) return null;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!firstName.trim() || !lastName.trim()) {
      setError('يرجى كتابة الاسم الأول واسم العائلة للطالب.');
      return;
    }
    if (!nationalId.trim() || nationalId.length < 10) {
      setError('رقم الهوية الوطنية / الإقامة يجب أن يتكون من 10 أرقام على الأقل.');
      return;
    }
    if (!primaryParentPhone.trim() || primaryParentPhone.length < 10) {
      setError('يرجى إدخال رقم هاتف ولي الأمر بشكل صحيح للتواصل ولإشعارات SMS.');
      return;
    }

    const fullName = `${firstName.trim()} ${secondName.trim()} ${thirdName.trim()} ${lastName.trim()}`.replace(/\s+/g, ' ');
    const randomNum = Math.floor(100 + Math.random() * 900);
    const studentNumber = `STD-2025-${randomNum}`;
    const barcode = `62810010${randomNum}`;

    let grade = 'المرحلة الابتدائية';
    if (className.includes('المتوسط')) grade = 'المرحلة المتوسطة';
    if (className.includes('الثانوي')) grade = 'المرحلة الثانوية';

    onAddStudent({
      studentNumber,
      barcode,
      nationalId: nationalId.trim(),
      firstName: firstName.trim(),
      secondName: secondName.trim(),
      thirdName: thirdName.trim(),
      lastName: lastName.trim(),
      fullName,
      gender,
      dateOfBirth,
      birthPlace,
      nationality,
      phone,
      email: email.trim() || `${studentNumber.toLowerCase()}@student.edura.sa`,
      address,
      primaryParentName: primaryParentName.trim() || `${secondName || firstName} ${lastName}`,
      primaryParentPhone,
      emergencyContactName: primaryParentName.trim() || `${secondName || firstName} ${lastName}`,
      emergencyContactPhone: primaryParentPhone,
      bloodType,
      gradeName: grade,
      className,
      sectionName,
      status: 'Active',
      enrollmentDate: new Date().toISOString().split('T')[0],
      medicalNotes
    });

    onClose();
  };

  return (
    <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-black/75 backdrop-blur-xs overflow-y-auto">
      <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-2xl w-full p-6 shadow-2xl space-y-4 my-8">
        <div className="flex items-center justify-between border-b border-slate-800 pb-3">
          <div className="flex items-center gap-2">
            <div className="p-2 rounded-xl bg-blue-600/20 border border-blue-500/40 text-blue-400">
              <UserPlus className="w-5 h-5" />
            </div>
            <div>
              <h3 className="text-base font-bold text-white">تسجيل وقيد طالب جديد</h3>
              <p className="text-xs text-slate-400">إدخال البيانات الرسمية للطالب في قاعدة بيانات SQL Server</p>
            </div>
          </div>
          <button
            onClick={onClose}
            className="p-1 rounded-lg hover:bg-slate-800 text-slate-400 hover:text-white transition-colors"
          >
            <X className="w-5 h-5" />
          </button>
        </div>

        {error && (
          <div className="p-3 bg-red-950/60 border border-red-800 text-red-200 text-xs rounded-xl flex items-center gap-2">
            <AlertCircle className="w-4 h-4 shrink-0 text-red-400" />
            <span>{error}</span>
          </div>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          {/* Names Row (Arabic 4-part name) */}
          <div className="grid grid-cols-2 sm:grid-cols-4 gap-3">
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">الاسم الأول *</label>
              <input
                type="text"
                required
                value={firstName}
                onChange={(e) => setFirstName(e.target.value)}
                placeholder="مثال: سلمان"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">اسم الأب</label>
              <input
                type="text"
                value={secondName}
                onChange={(e) => setSecondName(e.target.value)}
                placeholder="مثال: عبد الله"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">اسم الجد</label>
              <input
                type="text"
                value={thirdName}
                onChange={(e) => setThirdName(e.target.value)}
                placeholder="مثال: خالد"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">اسم العائلة *</label>
              <input
                type="text"
                required
                value={lastName}
                onChange={(e) => setLastName(e.target.value)}
                placeholder="مثال: الدوسري"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              />
            </div>
          </div>

          {/* National ID & Gender & Date of Birth & Blood Type */}
          <div className="grid grid-cols-1 sm:grid-cols-4 gap-3">
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">الهوية الوطنية / الإقامة *</label>
              <input
                type="text"
                required
                maxLength={10}
                value={nationalId}
                onChange={(e) => setNationalId(e.target.value)}
                placeholder="10 أرقام"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white font-mono focus:outline-none focus:border-blue-500"
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">الجنس</label>
              <select
                value={gender}
                onChange={(e: any) => setGender(e.target.value)}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              >
                <option value="ذكر">ذكر (بنين)</option>
                <option value="أنثى">أنثى (بنات)</option>
              </select>
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">تاريخ الميلاد</label>
              <input
                type="date"
                value={dateOfBirth}
                onChange={(e) => setDateOfBirth(e.target.value)}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white font-mono focus:outline-none focus:border-blue-500"
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">فصيلة الدم</label>
              <select
                value={bloodType}
                onChange={(e) => setBloodType(e.target.value)}
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white font-mono focus:outline-none focus:border-blue-500"
              >
                <option value="O+">O+</option>
                <option value="A+">A+</option>
                <option value="B+">B+</option>
                <option value="AB+">AB+</option>
                <option value="O-">O-</option>
                <option value="A-">A-</option>
                <option value="B-">B-</option>
                <option value="AB-">AB-</option>
              </select>
            </div>
          </div>

          {/* Academic Allocation: Class & Section */}
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3 p-3 bg-slate-950/60 rounded-xl border border-slate-800">
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">الصف الدراسي المستهدف *</label>
              <select
                value={className}
                onChange={(e) => setClassName(e.target.value)}
                className="w-full bg-slate-900 border border-slate-700 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              >
                {classesList.map((c, i) => (
                  <option key={i} value={c}>
                    {c}
                  </option>
                ))}
              </select>
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">الشعبة الدراسية</label>
              <select
                value={sectionName}
                onChange={(e) => setSectionName(e.target.value)}
                className="w-full bg-slate-900 border border-slate-700 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              >
                <option value="أ (الصفوة)">أ (الصفوة)</option>
                <option value="ب (الرواد)">ب (الرواد)</option>
                <option value="أ (المتفوقين)">أ (المتفوقين)</option>
                <option value="أ (عام)">أ (عام)</option>
              </select>
            </div>
          </div>

          {/* Guardian Information */}
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">اسم ولي الأمر / المعيل</label>
              <input
                type="text"
                value={primaryParentName}
                onChange={(e) => setPrimaryParentName(e.target.value)}
                placeholder="اتركه فارغاً ليُؤخذ من اسم الأب"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500"
              />
            </div>
            <div>
              <label className="block text-xs font-semibold text-slate-300 mb-1">هاتف ولي الأمر (لإشعارات SMS) *</label>
              <input
                type="tel"
                required
                value={primaryParentPhone}
                onChange={(e) => setPrimaryParentPhone(e.target.value)}
                placeholder="05xxxxxxxx"
                className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white font-mono focus:outline-none focus:border-blue-500"
              />
            </div>
          </div>

          {/* Medical Notes */}
          <div>
            <label className="block text-xs font-semibold text-slate-300 mb-1">الملاحظات الطبية أو التوصيات الخاصة</label>
            <textarea
              rows={2}
              value={medicalNotes}
              onChange={(e) => setMedicalNotes(e.target.value)}
              className="w-full bg-slate-950 border border-slate-800 rounded-lg px-3 py-2 text-xs text-white focus:outline-none focus:border-blue-500 resize-none"
            />
          </div>

          <div className="flex items-center justify-end gap-3 pt-3 border-t border-slate-800">
            <button
              type="button"
              onClick={onClose}
              className="px-4 py-2 text-xs font-semibold text-slate-300 hover:text-white bg-slate-800 hover:bg-slate-700 rounded-xl transition-colors cursor-pointer"
            >
              إلغاء
            </button>
            <button
              type="submit"
              className="flex items-center gap-1.5 px-5 py-2 text-xs font-bold bg-blue-600 hover:bg-blue-500 text-white rounded-xl shadow-lg shadow-blue-600/30 transition-all cursor-pointer"
            >
              <Save className="w-3.5 h-3.5" />
              <span>حفظ وقيد الطالب في النظام</span>
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};
