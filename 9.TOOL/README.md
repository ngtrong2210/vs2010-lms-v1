# 9.TOOL - Công cụ & Scripts

## Quy tắc tổ chức file

Đây là thư mục chứa các công cụ, scripts, và utility files dùng cho việc:

- Phân tích database
- Kiểm tra stored procedures
- Extract/generate code
- Scripts SQL utility

---

## 📁 Danh sách file hiện có

| File | Mô tả | Loại |
|------|-------|------|
| `comprehensive_procedure_check.sql` | Script kiểm tra chi tiết tất cả stored procedures trong database | SQL Script |
| `check_procedures.sql` | Script kiểm tra nhanh procedures | SQL Script |
| `extract_procedures.py` | Python script để extract procedures từ codebase | Python Script |

---

## 📝 Quy tắc đặt tên file

### SQL Scripts
- **Prefix**: `check_` - Cho các script kiểm tra/audit
- **Prefix**: `create_` - Cho các script tạo objects
- **Prefix**: `fix_` - Cho các script sửa lỗi
- **Prefix**: `extract_` - Cho các script extract/export
- **Hậu tố**: `.sql`

### Python Scripts
- **Prefix**: `extract_` - Extract/export dữ liệu
- **Prefix**: `generate_` - Generate code/SQL
- **Prefix**: `analyze_` - Phân tích code/database
- **Hậu tố**: `.py`

### PowerShell Scripts
- **Prefix**: `deploy_` - Deployment
- **Prefix**: `test_` - Testing
- **Hậu tố**: `.ps1`

---

## 🚀 Cách sử dụng

### 1. comprehensive_procedure_check.sql
Script kiểm tra chi tiết stored procedures trong database.

**Cách chạy:**
```sql
sqlcmd -S ".\SQLEXPRESS" -d "LMSCMS_DB_SAMPLE" -i comprehensive_procedure_check.sql
```

**Hoặc mở trong SSMS và execute.**

### 2. check_procedures.sql
Script kiểm tra nhanh số lượng procedures theo tiền tố.

**Cách chạy:**
```sql
sqlcmd -S ".\SQLEXPRESS" -d "LMSCMS_DB_SAMPLE" -i check_procedures.sql
```

### 3. extract_procedures.py
Python script để extract tên procedures từ codebase C#.

**Cách chạy:**
```bash
python extract_procedures.py
```

---

## 📌 Ghi chú

- Các script nên được comment rõ ràng
- Backup database trước khi chạy các script sửa đổi (create_, fix_)
- Test scripts trên database dev trước khi chạy trên production
