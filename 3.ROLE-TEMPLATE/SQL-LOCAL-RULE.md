# QUY TẮC KẾT NỐI SQL LOCAL

## Quy tắc
- **Chỉ project này** (`WEB-LMS-VS2010`) được phép kết nối SQL local máy
- **KHÔNG** được copy connection string sang project khác
- **KHÔNG** được dùng SQL commands trong Claude Code cho project khác

## Connection String (CHỈ DÙNG TRONG PROJECT NÀY)

```xml
<add name="_ConnectionString"
     connectionString="Data Source=DESKTOP-PBMQQ03\SQLEXPRESS;Initial Catalog=LMSCMS_DB;User ID=sa;Password=nQY3n9EGcjT#pju;TrustServerCertificate=True;"
     providerName="System.Data.SqlClient" />
```

## Security Note
- Connection string chứa password - **KHÔNG** commit lên GitHub/public repo
- Chỉ dùng trong môi trường local/development
- Production nên dùng environment variable hoặc Azure Key Vault

## Claude Code Permission
Khi làm việc với SQL trong project này:
- Chỉ cho phép SQL commands trong thư mục `G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010`
- Từ chối các yêu cầu SQL từ project khác
