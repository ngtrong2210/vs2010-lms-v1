---
name: ado-sqlserver-dal
description: Use when adding or editing database access, stored procedure calls, SQL Server queries, DAL classes, DataTable, SqlConnection, SqlCommand, SqlDataAdapter, or connection strings.
---
# ADO.NET SQL Server DAL
## Phạm vi
Áp dụng khi làm việc với database trong project WebForms này.
## Nguyên tắc bắt buộc
- Dùng ADO.NET.
- Ưu tiên `SqlConnection`, `SqlCommand`, `SqlDataAdapter`, `DataTable`, `DataRow`.
- Không dùng Entity Framework nếu project không có sẵn.
- Không viết SQL trực tiếp trong `.aspx.cs`.
- Code-behind gọi BLL, BLL gọi DAL.
- Connection string đặt trong `Web.config`.
- Luôn dùng parameterized query hoặc stored procedure.
- Không nối chuỗi từ input người dùng vào SQL.
## Stored Procedure
- Ưu tiên stored procedure nếu project đang dùng.
- Khi sửa store lớn, tạo file patch SQL riêng nếu cần deploy.
- Không sửa tên bảng/cột nếu không có yêu cầu.
## SQL format
Dùng style:
```sql
Select
    ColumnName
From
    TableName
Where
    ColumnName = @ColumnName
```
- Chỉ viết hoa chữ cái đầu của keyword: `Select`, `From`, `Where`, `Inner Join`, `Left Join`.
- Mỗi cột một dòng.
- Không dùng `SELECT *`.
- Không viết tắt tên bảng.
- Temp table bắt đầu bằng `#tbl`.
## Error handling
- Bọc database operation bằng `try-catch`.
- Không show raw exception ra UI.
- Dispose object đúng cách bằng `using`.
- Không swallow exception nếu mất dữ liệu hoặc lỗi nghiệp vụ.
## Performance
- Tránh load dataset lớn lặp lại.
- Điều kiện `Where` nên thân thiện index.
- Tránh query trong vòng lặp nếu có thể gom một lần.
