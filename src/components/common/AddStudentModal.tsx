import React, { useState } from 'react';
import { X, UserPlus, AlertCircle, Save, Check, ShieldCheck, MapPin, Phone, CreditCard, Building } from 'lucide-react';
import { Student, IraqiIdentityDocType, IraqiProvince } from '../../types';
import { IRAQI_PROVINCES, IraqiPhoneValidator, IraqiIdentityValidator } from '../../utils/iraqiStandards';

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
  // الاسم الخماسي العراقي
  const [firstName, setFirstName] = useState('');
  const [fatherName, setFatherName] = useState('');
  const [grandFatherName, setGrandFatherName] = useState('');
  const [greatGrandFatherName, setGreatGrandFatherName] = useState('');
  const [familyName, setFamilyName] = useState('');
  const [motherName, setMotherName] = useState('');

  // الهوية والوثائق العراقية
  const [docType, setDocType] = useState<IraqiIdentityDocType>('البطاقة الوطنية الموحدة');
  const [docNumber, setDocNumber] = useState('');
  const [issuingProvince, setIssuingProvince] = useState<IraqiProvince>('بغداد');

  // البيانات الشخصية
  const [gender, setGender] = useState<'ذكر' | 'أنثى'>('ذكر');
  const [dateOfBirth, setDateOfBirth] = useState('2013-05-15');
  const [birthPlace, setBirthPlace] = useState<IraqiProvince>('بغداد');
  const [nationality, setNationality] = useState('عراقي');

  // أرقام الهواتف
  const [parentPhone, setParentPhone] = useState('0780');
  const [studentPhone, setStudentPhone] = useState('07');

  // العنوان العراقي
  const [province, setProvince] = useState<IraqiProvince>('بغداد');
  const [district, setDistrict] = useState('الكرخ');
  const [area, setArea] = useState('حي المنصور');
  const [mahalla, setMahalla] = useState('605');
  const [zuqaq, setZuqaq] = useState('12');
  const [houseNumber, setHouseNumber] = useState('8');
  const [nearestLandmark, setNearestLandmark] = useState('قرب ساحة الرواد');

  // الأكاديمي
  const [bloodType, setBloodType] = useState('O+');
  const [className, setClassName] = useState(classesList[0] || 'الصف الأول المتوسط');
  const [sectionName, setSectionName] = useState('أ (شعبة المتفوقين)');
  const [medicalNotes, setMedicalNotes] = useState('سليم ولا يعاني من أي أمراض مزمنة');
  const [error, setError] = useState('');

  if (!isOpen) return null;

  // فحص حي للهاتف
  const phoneValidation = IraqiPhoneValidator.validate(parentPhone);
  // فحص حي للوثيقة
  const identityValidation = IraqiIdentityValidator.validate(docNumber, docType);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!firstName.trim() || !fatherName.trim() || !grandFatherName.trim()) {
      setError('يرجى كتابة الاسم الثلاثي للطالب على الأقل (الاسم، الأب، الجد).');
      return;
    }

    if (!docNumber.trim()) {
      setError('يرجى إدخال رقم وثيقة الهوية الرسمية للطالب.');
      return;
    }

    if (!identityValidation.isValid) {
      setError(identityValidation.message || 'رقم الوثيقة غير صالح وفق معايير وزارة الداخلية العراقية.');
      return;
    }

    if (!phoneValidation.isValid) {
      setError(phoneValidation.errorMessage || 'يرجى إدخال رقم هاتف عراقي صالح (07XXXXXXXXX).');
      return;
    }

    const fullNameParts = [firstName, fatherName, grandFatherName, greatGrandFatherName, familyName].filter(Boolean);
    const fullName = fullNameParts.join(' ').trim();
    const parentFullName = `${fatherName} ${grandFatherName} ${familyName}`.trim();

    const randomNum = Math.floor(100 + Math.random() * 900);
    const studentNumber = `STD-2025-${randomNum}`;
    const barcode = `62810010${randomNum}`;

    let grade = 'المرحلة المتوسطة';
    if (className.includes('الابتدائي')) grade = 'المرحلة الابتدائية';
    if (className.includes('الثانوي') || className.includes('العلمي') || className.includes('الأدبي')) grade = 'المرحلة الإعدادية';

    const formattedAddress = `${province} - ${district} - ${area} - محلة ${mahalla} - زقاق ${zuqaq} - دار ${houseNumber} (${nearestLandmark})`;

    onAddStudent({
      studentNumber,
      barcode,
      nationalId: docNumber.trim(),
      identityDocumentType: docType,
      firstName: firstName.trim(),
      fatherName: fatherName.trim(),
      grandFatherName: grandFatherName.trim(),
      greatGrandFatherName: greatGrandFatherName.trim(),
      familyName: familyName.trim(),
      motherName: motherName.trim(),
      secondName: fatherName.trim(),
      thirdName: grandFatherName.trim(),
      lastName: familyName.trim() || grandFatherName.trim(),
      fullName,
      gender,
      dateOfBirth,
      birthPlace,
      nationality: gender === 'أنثى' ? 'عراقية' : 'عراقي',
      phone: studentPhone.length >= 11 ? studentPhone : parentPhone,
      email: `${studentNumber.toLowerCase()}@student.dijlah.edu.iq`,
      address: formattedAddress,
      iraqiAddress: {
        province,
        district,
        area,
        mahalla,
        zuqaq,
        houseNumber,
        nearestLandmark
      },
      primaryParentName: parentFullName,
      primaryParentPhone: parentPhone,
      emergencyContactName: parentFullName,
      emergencyContactPhone: parentPhone,
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
      <div className="bg-slate-900 border border-slate-700 rounded-2xl max-w-3xl w-full p-6 shadow-2xl space-y-4 my-8 max-h-[90vh] overflow-y-auto text-slate-100">
        <div className="flex items-center justify-between border-b border-slate-800 pb-3">
          <div className="flex items-center gap-2">
            <div className="w-10 h-10 rounded-xl bg-emerald-500/20 text-emerald-400 flex items-center justify-center">
              <UserPlus className="w-5 h-5" />
            </div>
            <div>
              <h3 className="text-lg font-bold text-white">تسجيل طالب جديد (استمارة القبول الموحدة - جمهورية العراق)</h3>
              <p className="text-xs text-slate-400">اعتماد الأسماء الخماسية، الوثائق الرسمية، العناوين وأرقام الهواتف العراقية</p>
            </div>
          </div>
          <button
            onClick={onClose}
            className="text-slate-400 hover:text-white p-1 rounded-lg hover:bg-slate-800 transition-colors"
          >
            <X className="w-5 h-5" />
          </button>
        </div>

        {error && (
          <div className="p-3 bg-rose-500/20 border border-rose-500/40 rounded-xl text-rose-300 text-sm flex items-center gap-2">
            <AlertCircle className="w-5 h-5 shrink-0" />
            <span>{error}</span>
          </div>
        )}

        <form onSubmit={handleSubmit} className="space-y-4">
          {/* قسم الاسم الخماسي واسم الأم */}
          <div className="p-4 bg-slate-800/40 rounded-xl border border-slate-700/60 space-y-3">
            <h4 className="text-xs font-bold text-emerald-400 uppercase tracking-wider flex items-center gap-2">
              <span>الاسم الكامل للطالب (سجلات وزارة التربية العراقية)</span>
            </h4>
            <div className="grid grid-cols-2 sm:grid-cols-3 gap-3">
              <div>
                <label className="block text-xs text-slate-300 mb-1">الاسم الأول *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: مصطفى"
                  value={firstName}
                  onChange={(e) => setFirstName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">اسم الأب *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: علي"
                  value={fatherName}
                  onChange={(e) => setFatherName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">اسم الجد *</label>
                <input
                  type="text"
                  required
                  placeholder="مثال: حسين"
                  value={grandFatherName}
                  onChange={(e) => setGrandFatherName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">اسم الجد الأعلى</label>
                <input
                  type="text"
                  placeholder="مثال: كاظم"
                  value={greatGrandFatherName}
                  onChange={(e) => setGreatGrandFatherName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">اللقب / العشيرة *</label>
                <input
                  type="text"
                  placeholder="مثال: الزبيدي"
                  value={familyName}
                  onChange={(e) => setFamilyName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">اسم الأم الثلاثي *</label>
                <input
                  type="text"
                  placeholder="مثال: زينب جواد عبد"
                  value={motherName}
                  onChange={(e) => setMotherName(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
            </div>
          </div>

          {/* قسم الوثائق الثبوتية العراقية */}
          <div className="p-4 bg-slate-800/40 rounded-xl border border-slate-700/60 space-y-3">
            <h4 className="text-xs font-bold text-amber-400 uppercase tracking-wider flex items-center gap-2">
              <ShieldCheck className="w-4 h-4" />
              <span>الوثائق الثبوتية والهوية العراقية (Identity Documents)</span>
            </h4>
            <div className="grid grid-cols-1 sm:grid-cols-3 gap-3">
              <div>
                <label className="block text-xs text-slate-300 mb-1">نوع الوثيقة الرسمية *</label>
                <select
                  value={docType}
                  onChange={(e) => setDocType(e.target.value as IraqiIdentityDocType)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                >
                  <option value="البطاقة الوطنية الموحدة">البطاقة الوطنية الموحدة (12 رقماً)</option>
                  <option value="هوية الأحوال المدنية">هوية الأحوال المدنية</option>
                  <option value="شهادة الجنسية العراقية">شهادة الجنسية العراقية</option>
                  <option value="جواز السفر العراقي">جواز السفر العراقي</option>
                  <option value="وثيقة رسمية أخرى">وثيقة رسمية أخرى</option>
                </select>
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">رقم الوثيقة / الهوية *</label>
                <input
                  type="text"
                  required
                  placeholder={docType === 'البطاقة الوطنية الموحدة' ? '12 رقم (مثال: 199812345678)' : 'أدخل رقم الوثيقة'}
                  value={docNumber}
                  onChange={(e) => setDocNumber(e.target.value.replace(/[^0-9a-zA-Z]/g, ''))}
                  className={`w-full bg-slate-950 border rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden ${
                    docNumber
                      ? identityValidation.isValid
                        ? 'border-emerald-500'
                        : 'border-amber-500'
                      : 'border-slate-700'
                  }`}
                />
                {docNumber && !identityValidation.isValid && (
                  <p className="text-[11px] text-amber-400 mt-1">{identityValidation.message}</p>
                )}
                {docNumber && identityValidation.isValid && (
                  <p className="text-[11px] text-emerald-400 mt-1 flex items-center gap-1">
                    <Check className="w-3 h-3" /> تم التحقق بنجاح
                  </p>
                )}
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">محافظة / دائرة الإصدار</label>
                <select
                  value={issuingProvince}
                  onChange={(e) => setIssuingProvince(e.target.value as IraqiProvince)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                >
                  {IRAQI_PROVINCES.map((p) => (
                    <option key={p} value={p}>
                      {p}
                    </option>
                  ))}
                </select>
              </div>
            </div>
          </div>

          {/* قسم الهاتف العراقي والاتصال */}
          <div className="p-4 bg-slate-800/40 rounded-xl border border-slate-700/60 space-y-3">
            <h4 className="text-xs font-bold text-sky-400 uppercase tracking-wider flex items-center gap-2">
              <Phone className="w-4 h-4" />
              <span>أرقام الهواتف العراقية وشبكات الاتصال (07XXXXXXXXX)</span>
            </h4>
            <div className="grid grid-cols-1 sm:grid-cols-2 gap-3">
              <div>
                <div className="flex items-center justify-between mb-1">
                  <label className="block text-xs text-slate-300">هاتف ولي الأمر (لإشعارات الواتساب والرسائل) *</label>
                  {phoneValidation.isValid && phoneValidation.carrier && (
                    <span className="text-[10px] px-2 py-0.5 rounded-full font-medium bg-emerald-500/20 text-emerald-300 border border-emerald-500/30">
                      {phoneValidation.carrier === 'Zain IQ' ? 'زين العراق (Zain IQ)' :
                       phoneValidation.carrier === 'Asiacell' ? 'آسيا سيل (Asiacell)' :
                       phoneValidation.carrier === 'Korek Telecom' ? 'كورك (Korek)' : phoneValidation.carrier}
                    </span>
                  )}
                </div>
                <input
                  type="tel"
                  dir="ltr"
                  required
                  placeholder="07801234567"
                  value={parentPhone}
                  onChange={(e) => setParentPhone(e.target.value.replace(/[^0-9\+]/g, ''))}
                  className={`w-full bg-slate-950 border rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden ${
                    phoneValidation.isValid ? 'border-emerald-500' : 'border-slate-700'
                  }`}
                />
                <p className="text-[11px] text-slate-400 mt-1">
                  التخزين الداخلي: <code className="text-sky-300">{phoneValidation.internationalFormat || '+9647...'}</code>
                </p>
              </div>

              <div>
                <label className="block text-xs text-slate-300 mb-1">هاتف الطالب الشخصي (اختياري)</label>
                <input
                  type="tel"
                  dir="ltr"
                  placeholder="07701234567"
                  value={studentPhone}
                  onChange={(e) => setStudentPhone(e.target.value.replace(/[^0-9\+]/g, ''))}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
                <p className="text-[11px] text-slate-400 mt-1">يدعم شبكات زين، آسيا سيل، وكورك</p>
              </div>
            </div>
          </div>

          {/* قسم العنوان العراقي الكامل */}
          <div className="p-4 bg-slate-800/40 rounded-xl border border-slate-700/60 space-y-3">
            <h4 className="text-xs font-bold text-violet-400 uppercase tracking-wider flex items-center gap-2">
              <MapPin className="w-4 h-4" />
              <span>العنوان السكني في العراق (المحافظة - المحلة - الزقاق - الدار)</span>
            </h4>
            <div className="grid grid-cols-2 sm:grid-cols-4 gap-3">
              <div>
                <label className="block text-xs text-slate-300 mb-1">المحافظة *</label>
                <select
                  value={province}
                  onChange={(e) => setProvince(e.target.value as IraqiProvince)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                >
                  {IRAQI_PROVINCES.map((p) => (
                    <option key={p} value={p}>
                      {p}
                    </option>
                  ))}
                </select>
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">القضاء / الناحية *</label>
                <input
                  type="text"
                  placeholder="مثال: الكرخ / الرصافة"
                  value={district}
                  onChange={(e) => setDistrict(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">الحي / المنطقة *</label>
                <input
                  type="text"
                  placeholder="مثال: حي المنصور"
                  value={area}
                  onChange={(e) => setArea(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">المحلة</label>
                <input
                  type="text"
                  placeholder="مثال: 605"
                  value={mahalla}
                  onChange={(e) => setMahalla(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">الزقاق</label>
                <input
                  type="text"
                  placeholder="مثال: 12"
                  value={zuqaq}
                  onChange={(e) => setZuqaq(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs text-slate-300 mb-1">رقم الدار</label>
                <input
                  type="text"
                  placeholder="مثال: 8"
                  value={houseNumber}
                  onChange={(e) => setHouseNumber(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
              <div className="col-span-2">
                <label className="block text-xs text-slate-300 mb-1">أقرب نقطة دالة *</label>
                <input
                  type="text"
                  placeholder="مثال: قرب ساحة الرواد / مجاور جامع الرحمن"
                  value={nearestLandmark}
                  onChange={(e) => setNearestLandmark(e.target.value)}
                  className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
                />
              </div>
            </div>
          </div>

          {/* التوزيع الصفي والبيانات الطبية */}
          <div className="grid grid-cols-2 sm:grid-cols-4 gap-3">
            <div>
              <label className="block text-xs text-slate-300 mb-1">الصف الدراسي *</label>
              <select
                value={className}
                onChange={(e) => setClassName(e.target.value)}
                className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
              >
                {classesList.map((c) => (
                  <option key={c} value={c}>
                    {c}
                  </option>
                ))}
              </select>
            </div>
            <div>
              <label className="block text-xs text-slate-300 mb-1">الشعبة *</label>
              <select
                value={sectionName}
                onChange={(e) => setSectionName(e.target.value)}
                className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
              >
                <option value="أ (شعبة المتفوقين)">أ (شعبة المتفوقين)</option>
                <option value="ب">شعبة ب</option>
                <option value="ج">شعبة ج</option>
                <option value="د">شعبة د</option>
              </select>
            </div>
            <div>
              <label className="block text-xs text-slate-300 mb-1">الجنس</label>
              <select
                value={gender}
                onChange={(e) => setGender(e.target.value as 'ذكر' | 'أنثى')}
                className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
              >
                <option value="ذكر">ذكر</option>
                <option value="أنثى">أنثى</option>
              </select>
            </div>
            <div>
              <label className="block text-xs text-slate-300 mb-1">فصيلة الدم</label>
              <select
                value={bloodType}
                onChange={(e) => setBloodType(e.target.value)}
                className="w-full bg-slate-950 border border-slate-700 rounded-lg px-3 py-2 text-sm text-white focus:outline-hidden focus:border-emerald-500"
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

          <div className="flex items-center justify-end gap-3 pt-3 border-t border-slate-800">
            <button
              type="button"
              onClick={onClose}
              className="px-4 py-2 text-sm text-slate-400 hover:text-white rounded-lg hover:bg-slate-800 transition-colors"
            >
              إلغاء
            </button>
            <button
              type="submit"
              className="px-5 py-2 text-sm font-bold bg-emerald-600 hover:bg-emerald-500 text-white rounded-lg shadow-lg shadow-emerald-900/30 flex items-center gap-2 transition-colors cursor-pointer"
            >
              <Save className="w-4 h-4" />
              <span>حفظ وقيد الطالب في السجل الرسمي</span>
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};
