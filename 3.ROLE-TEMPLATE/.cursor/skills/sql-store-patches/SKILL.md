---
name: sql-store-patches
description: >-
  Tách mọi sửa/tạo stored procedure ra file patch riêng, không chỉ sửa file SQL
  gom nhiều store. Áp dụng mọi project SQL Server. Use when sửa store, stored
  procedure, SP, function, view, ALTER PROCEDURE, patch SQL, tách file sql, gom
  store, file sql tổng, full script, deploy database.
---

# SQL Store Patches (mọi project)

User thường **gom nhiều stored procedure vào một file SQL lớn** (full script, dump, script tổng module). Skill này quy định cách làm **đúng khi sửa/tạo store** — áp dụng **mọi project**, không riêng project nào.

## Nguyên tắc cốt lõi

1. **File gom nhiều store = baseline / tham chiếu / cài mới** — không phải file deploy hàng ngày.
2. **Mỗi lần sửa hoặc tạo store → tách file patch riêng** để chạy trên DB đang vận hành.
3. **Không bắt user mở file 5000+ dòng** tìm một SP để sửa rồi chạy cả file.
4. **Một patch = một object SQL** (một SP / function / view) hoặc một nhóm thay đổi bắt buộc đi cùng nhau.
5. **Không gom thêm store vào file patch** — tránh lặp thói quen gom file.
6. **Nhiều patch cùng đợt phải đánh số `01_`, `02_`, ... theo đúng thứ tự chạy.**
7. **Patch sửa object đã tồn tại phải lưu định nghĩa cũ thành file `.sql` chứa lệnh `Create`; đây là bản lưu định nghĩa, không phải backup database và tuyệt đối không tạo bảng `Backup_*`.**

## Phân biệt hai loại file

| Loại | Mục đích | Ví dụ tên file |
|------|----------|----------------|
| **Baseline (gom nhiều store)** | Cài DB mới, lưu cấu trúc, tham chiếu toàn bộ | `fam-full.sql`, `all-stores.sql`, `Module_FAM_Script.sql` |
| **Patch (tách riêng)** | Deploy lên DB đang chạy, sửa lỗi, thêm SP mới | `20250914_FAM_Device_DELETE_fix_concat.sql` |

## Thư mục patch (linh hoạt theo project)

Tìm hoặc tạo thư mục patches phù hợp project:

```
sql/patches/                    ← ưu tiên nếu đã có sql/
Database/Scripts/Patches/
Scripts/Sql/Patches/
DB/Patches/
```

Nếu project chưa có cấu trúc → tạo `sql/patches/` ở root repo.

## Đặt tên file patch

```
NN_YYYYMMDD_<Module>_<ObjectName>_<mo_ta_ngan>.sql
```

Ví dụ:
- `01_20250914_FAM_Device_DELETE_fix_devicecode_concat.sql`
- `02_20250914_SYS_GridColumn_FAM_Device_DELETE.sql`
- `01_20260201_Create_HRS_Employee_UpdateStatus.sql` (SP mới)

Quy tắc:
- `NN` = thứ tự chạy trong cùng đợt/thư mục, luôn dùng 2 chữ số.
- `ObjectName` = tên SP/function/view (bỏ `dbo.`)
- `mo_ta_ngan` = snake_case, ≤ 40 ký tự
- Không dùng tên chung chung: `fix.sql`, `update_store.sql`
- File phụ thuộc store phải có số lớn hơn file store.

## Create vs Alter

| Tình huống | Trong patch |
|------------|-------------|
| SP **đã tồn tại** trên DB | `Alter Procedure` (body đầy đủ) |
| SP **mới hoàn toàn** | `Create Procedure` |
| User yêu cầu drop/recreate | `Drop Procedure If Exists` rồi `Create` — chỉ khi user nói rõ |

Patch phải **chạy lại an toàn** khi có thể (`Alter` > `Drop/Create`).

## Lưu định nghĩa `Create` bắt buộc trước khi sửa

- Áp dụng cho `Alter Procedure`, `Alter Function`, `Alter View`.
- Không áp dụng cho object tạo mới hoàn toàn.
- Bản lưu **chỉ là file script định nghĩa object cũ**, ví dụ `backup/FAM_DeviceCheckingDetail_Search_before_20261019.sql`.
- File này phải chứa nguyên định nghĩa chạy độc lập bằng `Create Procedure`, `Create Function` hoặc `Create View` và các `Set Ansi_Nulls`, `Set Quoted_Identifier`, `Go` cần thiết.
- Lấy định nghĩa đang chạy từ database khi có thể; nếu không truy cập được DB thì lấy bản gốc trước khi sửa trong baseline/source và báo rõ chưa đối chiếu DB live.
- Không đặt file lưu định nghĩa vào chuỗi patch đánh số để tránh chạy nhầm khi deploy.
- **Cấm** tạo `dbo.Backup_*`, `Select ... Into Backup_*`, hoặc bất kỳ bảng nào để gọi là backup khi mục tiêu chỉ là sửa store/function/view. Tạo table mới không phải là backup.
- Patch deploy chỉ kiểm tra object tồn tại rồi `Alter`; `Alter` phải ở batch mới sau `Go`.

## Template patch — sửa SP

```sql
/*
	Patch  : [dbo].[TenThuTuc] - [Mô tả ngắn]
	Date   : YYYY-MM-DD
	Module : [Module]
	Lỗi / Yêu cầu:
		[Mô tả]
	Nguyên nhân:
		[Giải thích ngắn, nếu sửa bug]
	Create cũ: backup/TenThuTuc_before_YYYYMMDD.sql
	Cách chạy:
		SSMS → chọn đúng database → F5 chạy toàn file.
*/

If Object_Id(N'[dbo].[TenThuTuc]', N'P') is null
Begin
	Raiserror(N'Không tìm thấy store dbo.TenThuTuc để cập nhật.', 16, 1)
	Return
End
Go
Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

Alter Procedure [dbo].[TenThuTuc]
(
	@Param1 bigint,
	@Param2 nvarchar(50) = null
)
As
Begin
	Set Nocount On;

	-- body đầy đủ (copy từ file gom rồi sửa)

End
Go
```

## Template patch — SP mới

```sql
/*
	Patch  : [dbo].[TenThuTuc] - Tạo mới
	Date   : YYYY-MM-DD
	Module : [Module]
	Mô tả  : [Chức năng SP]
	Cách chạy:
		SSMS → chọn đúng database → F5.
*/

Set Ansi_Nulls On
Go
Set Quoted_Identifier On
Go

If Object_Id(N'[dbo].[TenThuTuc]', N'P') Is Not Null
	Drop Procedure [dbo].[TenThuTuc]
Go

Create Procedure [dbo].[TenThuTuc]
(
	@Param1 bigint
)
As
Begin
	Set Nocount On;

	-- body

End
Go
```

## Quy trình bắt buộc cho agent

```
Task Progress:
- [ ] 1. Xác định SP/object và file gom hiện có (nếu có)
- [ ] 2. Xác định toàn bộ patch phụ thuộc và đánh số thứ tự chạy
- [ ] 3. Nếu sửa object cũ: lưu lệnh `Create` cũ thành file `backup/*_before_YYYYMMDD.sql`
- [ ] 4. Tạo file patch riêng trong thư mục patches/
- [ ] 5. Viết Alter/Create với body đầy đủ; không tạo bảng/`Backup_*` thay cho file `Create` cũ
- [ ] 6. Format SQL theo skill format-sql (nếu có)
- [ ] 7. Đồng bộ bản tương ứng vào file gom/baseline (nếu tìm thấy)
- [ ] 8. Báo user danh sách file cần chạy theo đúng số thứ tự
```

### Bước 5 — đồng bộ baseline (không bỏ qua)

Khi project có file gom nhiều store (`*full*.sql`, `*all*.sql`, `Script*.sql`, v.v.):
- Cập nhật SP tương ứng trong file gom để baseline mới nhất
- **Không** coi sửa file gom là đủ — patch riêng vẫn bắt buộc

## Khi user gom nhiều store vào một file

- **Không** thêm patch mới vào file gom đó.
- **Không** chỉ sửa trong file gom rồi bảo user chạy cả file.
- Nếu user đưa file gom 50+ SP và yêu cầu sửa 1 SP → tách 1 patch, sync 1 chỗ trong file gom.
- Nếu user yêu cầu tách hàng loạt SP ra file riêng → mỗi SP một file trong `patches/` hoặc `patches/by-object/`.

## Lưu ý SQL Server thường gặp

- Nối chuỗi với số: `Cast(CotSo As nvarchar(50)) + N'_' + CotChu` — **không** `bigint + varchar`.
- Unicode: `N'...'` khi cần.
- Temp table: `#tblTenBang`.
- Không viết SQL trong code-behind WebForms/WinForms — store trong patch, app gọi qua DAL.

## Báo user sau khi xong

Luôn nêu:
1. **Các file patch theo thứ tự `01`, `02`, ...** (đường dẫn đầy đủ)
2. **File baseline** đã sync (tên file, nếu có)
3. **File lưu định nghĩa `Create` cũ** của từng object đã sửa và nguồn lấy định nghĩa
4. **Chức năng app** cần test sau khi chạy patch
