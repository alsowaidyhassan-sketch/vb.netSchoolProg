# نظام إدارتي لإدارة المدارس (Edura School Management Enterprise)
### حل مكتبي متكامل واحترافي مبني بتقنية VB.NET وقاعدة بيانات Microsoft SQL Server

---

## 📌 نظرة عامة على المشروع (Project Overview)
نظام **إدارتي (Edura)** هو برنامج سطح مكتب تجاري عالي الأداء مصمم لإدارة المنشآت التعليمية والمدارس الخاصة والحكومية. تم بناء النظام وفق معايير هندسة البرمجيات المتقدمة (Clean / Layered Architecture) بلغة **VB.NET (.NET 8.0 Windows)** مع محرك قواعد بيانات **Microsoft SQL Server 2019/2022**، ومصمم بواجهة عربية أصيلة (Arabic First & RTL) وتجربة مستخدم عصرية تعتمد على نظام التبويبات المتعددة (Tabbed Interface).

---

## 🏛️ هيكلية وبنية المشروع (Solution Architecture)

```
SchoolManagement.sln
│
├── src-vbnet/
│   ├── SchoolManagement.Core/          # طبقة النواة: الكيانات (Entities), الواجهات (Interfaces), Enums
│   │   ├── Entities/
│   │   │   ├── Student.vb
│   │   │   ├── Teacher.vb
│   │   │   ├── Payment.vb
│   │   │   └── ...
│   │   └── Interfaces/
│   │       ├── IRepositories.vb
│   │       └── ...
│   │
│   ├── SchoolManagement.Data/          # طبقة الوصول للبيانات (DAL): Dapper, ADO.NET, Repositories
│   │   ├── Infrastructure/
│   │   │   └── ConnectionManager.vb
│   │   └── Repositories/
│   │       ├── StudentRepository.vb
│   │       ├── AttendanceRepository.vb
│   │       └── ...
│   │
│   ├── SchoolManagement.Services/      # طبقة منطق الأعمال (BLL): Services, Rules, Calculations
│   │   ├── Services/
│   │   │   ├── StudentService.vb
│   │   │   ├── AttendanceService.vb
│   │   │   ├── FinanceService.vb
│   │   │   └── AuthenticationService.vb
│   │
│   └── SchoolManagement.App/           # طبقة العرض والواجهات (Presentation Layer - Windows Forms Modern)
│       ├── Forms/
│       │   ├── MainForm.vb             # نافذة البرنامج الرئيسية مع نظام التبويبات Tabs والـ Sidebar
│       │   └── LoginForm.vb            # نافذة الدخول المشفرة
│       ├── Helpers/
│       │   ├── ThemeManager.vb         # مدير السمات (Dark/Light Navy Modern)
│       │   └── UIHelper.vb
│       └── appsettings.json            # إعدادات الاتصال بقاعدة البيانات
│
└── database/Scripts/                   # نصوص SQL Server كاملة ومنظمة
    ├── 01_CreateDatabase.sql           # إنشاء قاعدة البيانات مع ترميز Arabic_100_CI_AS_SC_UTF8
    ├── 02_CreateTables.sql             # إنشاء 34+ جدولاً موحداً مع قيود السلامة
    ├── 03_CreateRelations.sql          # المفاتيح الأجنبية والعلاقات
    ├── 04_CreateIndexes.sql            # الفهارس لتسريع البحث
    ├── 05_CreateStoredProcedures.sql   # الإجراءات المخزنة للعمليات المعقدة
    ├── 06_CreateViews.sql              # عروض الاستعلام للتقارير
    ├── 07_InsertDefaultData.sql        # الأدوار والصلاحيات والإعدادات
    ├── 08_CreateSecurity.sql           # مستخدم المشرف وكلمة المرور المشفرة SHA-256
    ├── 09_CreateAudit.sql              # مشغلات التدقيق الأوتوماتيكي
    └── 10_SeedData.sql                 # بيانات تجريبية حية للمدرسة والصفوف والطلاب
```

---

## ⚡ متطلبات التشغيل (Requirements)
1. **نظام التشغيل**: Windows 10 أو Windows 11 (64-bit).
2. **بيئة التشغيل**: Microsoft .NET 8.0 Desktop Runtime أو أحدث.
3. **قاعدة البيانات**: Microsoft SQL Server 2017 / 2019 / 2022 أو SQL Server Express.
4. **بيئة التطوير والتعديل**: Microsoft Visual Studio 2022 (Community / Professional / Enterprise) مع تثبيت حزمة **.NET Desktop Development**.

---

## 🛠️ خطوات تثبيت وإعداد قاعدة البيانات (SQL Server Setup)
1. افتح **SQL Server Management Studio (SSMS)** واتصل بالخادم المحلي أو الشبكي.
2. قم بتشغيل الملفات الموجودة في مجلد `database/Scripts/` بالترتيب التالي:
   - `01_CreateDatabase.sql`
   - `02_CreateTables.sql`
   - `03_CreateRelations.sql`
   - `04_CreateIndexes.sql`
   - `05_CreateStoredProcedures.sql`
   - `06_CreateViews.sql`
   - `07_InsertDefaultData.sql`
   - `08_CreateSecurity.sql`
   - `09_CreateAudit.sql`
   - `10_SeedData.sql`

---

## 🔑 بيانات الدخول الافتراضية (Default Credentials)
- **اسم المستخدم**: `admin`
- **كلمة المرور**: `Admin@2025`
- **نوع الحساب**: مدير النظام الكامل (Full System Administrator).

---

## 💻 ضبط نص الاتصال (Connection String Configuration)
افتح ملف `src-vbnet/SchoolManagement.App/appsettings.json` وعدل نص الاتصال بما يناسب خادمك:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EduraSchoolDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;"
  }
}
```

---

## 🚀 كيفية بناء وتشغيل المشروع (Build & Run)
عبر موجه الأوامر (Command Line) أو Visual Studio:
```bash
dotnet restore SchoolManagement.sln
dotnet build SchoolManagement.sln -c Release
dotnet run --project src-vbnet/SchoolManagement.App/SchoolManagement.App.vbproj
```

---

## 🌟 المزايا المنجزة (Key Features)
- ✅ **نظام التبويبات الفوري (Multi-Tab Management)**: فتح كل شاشة كتاب داخل الفورم الرئيسي مع زر إغلاق ومنع التكرار.
- ✅ **واجهة عصرية بنمط Dark Navy / Light Modern**: متناسقة بدون أزرار رمادية تقليدية مع دعم كامل لـ RTL واللغة العربية.
- ✅ **إدارة شاملة**: الطلاب، المعلمين، الفصول، المواد، الحضور والغياب السريع، الامتحانات والدرجات، الرسوم والمحاسبة، الموارد البشرية، والتقارير.
- ✅ **أمان وتدقيق**: تشفير SHA-256 + Salt، مصفوفة صلاحيات تفصيلية، وسجل تدقيق شامل (Audit Logs).
- ✅ **نسخ احتياطي واسترجاع**: نسخ كامل مضغوط لقاعدة بيانات SQL Server.
