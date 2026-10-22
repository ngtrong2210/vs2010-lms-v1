# WEB-LMS-VS2010 - Learning Management System

## 📁 Cấu trúc dự án

```
1. WEB-LMS-VS2010/
├── InformationWeb/          # ASP.NET Web Application
├── LmsObject/              # Business Objects
├── LmsService/             # Service Layer
├── 9.tool/                 # Công cụ & Scripts
│   ├── comprehensive_procedure_check.sql
│   ├── check_procedures.sql
│   ├── extract_procedures.py
│   └── README.md
├── 10.docs/                # Tài liệu & Báo cáo
│   ├── BAO_CAO_KY_THUAT.md
│   ├── TOM_TAT_BAO_CAO.md
│   ├── db_procedures.txt
│   └── README.md
└── README.md               # File này
```

---

## 🚀 Khởi động nhanh

### Điều kiện tiên quyết
- Microsoft SQL Server 2022 Express
- Visual Studio 2010 hoặc mới hơn
- .NET Framework 4.0

### Cấu hình Database
Connection string trong `InformationWeb/Web.config`:
```xml
<add name="_ConnectionString"
     connectionString="Data Source=DESKTOP-PBMQQ03\SQLEXPRESS;Initial Catalog=LMSCMS_DB_SAMPLE;User ID=sa;Password=nQY3n9EGcjT#pju;TrustServerCertificate=True;"
     providerName="System.Data.SqlClient" />
```

---

## 📚 Tài liệu

### Báo cáo kỹ thuật mới nhất
- [Báo cáo phân tích Stored Procedures](10.docs/BAO_CAO_KY_THUAT.md)
- [Tóm tắt báo cáo](10.docs/TOM_TAT_BAO_CAO.md)

### Công cụ
- [README - Công cụ & Scripts](9.tool/README.md)
- [README - Tài liệu](10.docs/README.md)

---

## ⚠️ Vấn đề cần lưu ý

### Database Procedures
Database hiện tại **thiếu 236/358 stored procedures**:
- ❌ SIM_ (thiếu 199/202) - Course/Chapter/Lesson management
- ❌ sp_ (thiếu 12/12) - Lookup dropdowns
- ⚠️ SYS_ (thiếu 25/39) - Permissions/System
- ✅ LMS_ (đủ) - Core modules

Xem chi tiết trong [Báo cáo kỹ thuật](10.docs/BAO_CAO_KY_THUAT.md).

---

## 🛠️ Framework & Công nghệ

- **Framework**: ASP.NET Web Forms 4.0
- **Language**: C#
- **Database**: Microsoft SQL Server 2022
- **ORM/Data Access**: DCore.Data
- **URL Rewriting**: UrlRewritingNet

---

## 📝 Quy tắc tổ chức

### 9.tool - Công cụ & Scripts
Chứa các script SQL, Python, PowerShell dùng cho:
- Phân tích database
- Kiểm tra stored procedures
- Extract/generate code

### 10.docs - Tài liệu & Báo cáo
Chứa tất cả tài liệu kỹ thuật:
- Báo cáo phân tích
- Hướng dẫn sử dụng
- Tài liệu thiết kế
- File export dữ liệu

---

## 👥 Team
- [Thêm thông tin team]

## 📄 License
[Thêm thông tin license]

---

**Ngày tạo**: 2026-10-22  
**Cập nhật lần cuối**: 2026-10-22
