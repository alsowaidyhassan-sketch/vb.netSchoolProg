import { IraqiIdentityDocType, IraqiProvince, PhoneValidationResult, CurrencyConfig } from '../types';

export const IRAQI_PROVINCES: IraqiProvince[] = [
  'بغداد',
  'البصرة',
  'نينوى',
  'أربيل',
  'النجف الأشرف',
  'كربلاء المقدسة',
  'بابل',
  'ذي قار',
  'الأنبار',
  'ديالى',
  'كركوك',
  'صلاح الدين',
  'ميسان',
  'المثنى',
  'القادسية',
  'واسط',
  'دهوك',
  'السليمانية'
];

export const DEFAULT_CURRENCY: CurrencyConfig = {
  code: 'IQD',
  symbol: 'د.ع',
  name: 'دينار عراقي',
  decimals: 3
};

/**
 * محول ومنسق المبالغ بالدينار العراقي (MoneyFormatter)
 */
export class IraqiMoneyFormatter {
  static format(amount: number, showSymbol: boolean = true): string {
    const formatted = Math.round(amount).toLocaleString('ar-IQ');
    return showSymbol ? `${formatted} د.ع` : formatted;
  }

  static formatWithEnglishDigits(amount: number, showSymbol: boolean = true): string {
    const formatted = Math.round(amount).toLocaleString('en-US');
    return showSymbol ? `${formatted} د.ع` : formatted;
  }

  /**
   * تحويل الرقم إلى كلمات بالدينار العراقي (تفقيط)
   */
  static toArabicWords(amount: number): string {
    const rounded = Math.floor(amount);
    if (rounded === 0) return 'صفر دينار عراقي لا غير';
    
    // Quick tafqeet representation for common amounts
    const millions = Math.floor(rounded / 1000000);
    const thousands = Math.floor((rounded % 1000000) / 1000);
    const remainder = rounded % 1000;

    const parts: string[] = [];
    if (millions > 0) {
      if (millions === 1) parts.push('مليون');
      else if (millions === 2) parts.push('مليونان');
      else if (millions >= 3 && millions <= 10) parts.push(`${millions} ملايين`);
      else parts.push(`${millions} مليون`);
    }

    if (thousands > 0) {
      if (thousands === 1) parts.push('ألف');
      else if (thousands === 2) parts.push('ألفان');
      else if (thousands >= 3 && thousands <= 10) parts.push(`${thousands} آلاف`);
      else parts.push(`${thousands} ألف`);
    }

    if (remainder > 0) {
      parts.push(`${remainder}`);
    }

    return `فقط وقدره ${parts.join(' و ')} دينار عراقي لا غير`;
  }
}

/**
 * فاحص ومتحقق أرقام الهواتف العراقية (IraqiPhoneValidator)
 */
export class IraqiPhoneValidator {
  /**
   * فحص رقم الهاتف العراقي
   * الصيغ المعتمدة:
   * محلي موبايل: 07XXXXXXXXX (11 رقم)
   * دولي: +9647XXXXXXXXX أو 009647XXXXXXXXX
   * أرضي: 01XXXXXXX (بغداد 8 أرقام) أو 02/03/04... للمحافظات
   */
  static validate(phone: string): PhoneValidationResult {
    if (!phone || typeof phone !== 'string') {
      return {
        isValid: false,
        type: 'Invalid',
        internationalFormat: '',
        localFormat: '',
        errorMessage: 'رقم الهاتف مطلوب'
      };
    }

    // تنظيف الرقم من المسافات والشُرط والرموز غير المسموحة
    let cleaned = phone.replace(/[\s\-\(\)\.]/g, '');

    // منع الحروف والرموز غير المسموحة
    if (/[^0-9\+]/.test(cleaned)) {
      return {
        isValid: false,
        type: 'Invalid',
        internationalFormat: '',
        localFormat: '',
        errorMessage: 'يجب أن يحتوي رقم الهاتف على أرقام فقط بدون أحرف أو رموز'
      };
    }

    // تحويل الصيغة الدولية إلى محلية للتحليل
    if (cleaned.startsWith('+964')) {
      cleaned = '0' + cleaned.substring(4);
    } else if (cleaned.startsWith('00964')) {
      cleaned = '0' + cleaned.substring(5);
    } else if (cleaned.startsWith('964')) {
      cleaned = '0' + cleaned.substring(3);
    }

    // فحص الموبايل العراقي (11 رقم تبدأ بـ 07)
    if (/^07[3-9]\d{8}$/.test(cleaned)) {
      const prefix = cleaned.substring(0, 3);
      let carrier: 'Zain IQ' | 'Asiacell' | 'Korek Telecom' | 'Other' = 'Other';

      if (prefix === '078' || prefix === '079') {
        carrier = 'Zain IQ';
      } else if (prefix === '077') {
        carrier = 'Asiacell';
      } else if (prefix === '075') {
        carrier = 'Korek Telecom';
      }

      const international = '+964' + cleaned.substring(1);
      return {
        isValid: true,
        type: 'Mobile',
        carrier,
        internationalFormat: international,
        localFormat: cleaned
      };
    }

    // فحص الهاتف الأرضي العراقي (بغداد 01 ومحافظات أخرى 02x)
    if (/^0[1-6]\d{6,7}$/.test(cleaned)) {
      const international = '+964' + cleaned.substring(1);
      return {
        isValid: true,
        type: 'Landline',
        carrier: 'Landline',
        internationalFormat: international,
        localFormat: cleaned
      };
    }

    return {
      isValid: false,
      type: 'Invalid',
      internationalFormat: '',
      localFormat: cleaned,
      errorMessage: 'رقم الهاتف العراقي يجب أن يبدأ بـ 07 ويتكون من 11 رقماً (مثال: 07801234567)'
    };
  }

  static toInternational(phone: string): string {
    const res = this.validate(phone);
    return res.isValid ? res.internationalFormat : phone;
  }

  static toLocal(phone: string): string {
    const res = this.validate(phone);
    return res.isValid ? res.localFormat : phone;
  }
}

/**
 * فاحص وثائق الهوية العراقية (IraqiIdentityValidator)
 */
export class IraqiIdentityValidator {
  /**
   * فحص رقم الهوية حسب نوع الوثيقة دون تثبيت الطول قسراً
   */
  static validate(docNumber: string, docType: IraqiIdentityDocType): { isValid: boolean; message?: string } {
    if (!docNumber || !docNumber.trim()) {
      return { isValid: false, message: 'رقم الوثيقة مطلوب' };
    }

    const trimmed = docNumber.trim();

    switch (docType) {
      case 'البطاقة الوطنية الموحدة':
        // البطاقة الوطنية الموحدة في العراق تتكون من 12 رقماً
        if (!/^\d{12}$/.test(trimmed)) {
          return {
            isValid: false,
            message: 'رقم البطاقة الوطنية الموحدة يجب أن يتكون من 12 رقماً (مثال: 199812345678)'
          };
        }
        break;

      case 'هوية الأحوال المدنية':
        // هوية الأحوال المدنية: أرقام قد تتراوح بين 5 إلى 10 أرقام
        if (!/^\d{4,10}$/.test(trimmed)) {
          return {
            isValid: false,
            message: 'رقم هوية الأحوال المدنية يجب أن يتكون من 4 إلى 10 أرقام'
          };
        }
        break;

      case 'شهادة الجنسية العراقية':
        if (!/^\d{4,10}$/.test(trimmed)) {
          return {
            isValid: false,
            message: 'رقم شهادة الجنسية يجب أن يتكون من 4 إلى 10 أرقام'
          };
        }
        break;

      case 'جواز السفر العراقي':
        // جواز السفر العراقي يبدأ بحرف (A, G, M) متبوعاً بـ 7 أو 8 أرقام
        if (!/^[A-Za-z]\d{7,8}$/.test(trimmed)) {
          return {
            isValid: false,
            message: 'رقم جواز السفر العراقي يجب أن يبدأ بحرف يليه 7 أو 8 أرقام (مثال: A1234567)'
          };
        }
        break;

      default:
        if (trimmed.length < 3) {
          return { isValid: false, message: 'رقم الوثيقة قصير جداً' };
        }
        break;
    }

    return { isValid: true };
  }
}
