---
name: format-sql
description: Format SQL Server queries and stored procedures to project style (Select/From/Where first-letter-only, one column per line, #tbl temp tables, no abbreviated table names). Use when writing, rewriting, formatting, or reviewing SQL, T-SQL, stored procedures, or when the user mentions format SQL, viết SQL, chỉnh SQL, stored procedure.
---

# Format SQL

Áp dụng mọi lúc khi viết, sửa, hoặc format SQL (query, stored procedure, script `.sql`, SQL trong DAL).

## Keyword casing

Chỉ viết hoa chữ cái đầu. Không dùng ALL CAPS (`SELECT`, `FROM`) và không dùng lowercase (`select`, `from`).

```
Select
From
Where
Inner Join
Left Join
Order By
Group By
Having
Into
Insert
Update
Delete
Create Procedure
Alter Procedure
Declare
Begin
End
If
Set
Drop Table
Union All
Exists
Not Exists
Is null
Is not null
Top
While
Return
Raiserror
With
Case
When
Then
Else
End
As
```

Hàm SQL: chữ cái đầu hoa — `Isnull`, `Sum`, `Count`, `Max`, `Min`, `Year`, `Month`, `Getdate`, `Dateadd`, `Convert`, `Cast`, `Ltrim`, `Str`, `Scope_Identity`.

- `is null` / `is not null`: viết thường `is null`, `is not null` (giống `and` / `or` / `on`).
- `Top`: `Select Top 1` — số ngay sau `Top`.

## Cột

- Mỗi cột một dòng.
- Cột đầu tiên ngay dòng sau `Select`, thụt 1 tab.
- Cột tiếp theo: tab + tên cột, dấu phẩy ở cuối dòng trước.
- Không `Select *` trừ khi user yêu cầu rõ.
- Alias cột: `as "TenCot"` hoặc `as TenCot`.

```sql
Select
	CRM_Partner.PartnerID,
	CRM_Partner.PartnerCode,
	CRM_Partner.PartnerName
From CRM_Partner
```

## Từ khóa mệnh đề

Mỗi mệnh đề chính một dòng riêng, canh trái với `Select`:

```sql
Select
	ACC_Receipt.ReceiptID,
	ACC_Receipt.ReceiptDate,
	ACC_Receipt.TotalMoney
From ACC_Receipt
Where ACC_Receipt.IsDeleted = 0
	and ACC_Receipt.IsCanceled = 0
	and ACC_Receipt.ReceiptDate >= @FromDate
Order By ACC_Receipt.ReceiptDate
```

- `Where` / `and` / `or`: điều kiện đầu cùng dòng `Where` (hoặc dòng sau nếu dài). Điều kiện tiếp theo xuống dòng, thụt 1 tab, bắt đầu bằng `and` / `or`.
- Không viết `AND` hoa.

## Join

- `Inner Join` / `Left Join` xuống dòng, thụt 1 tab so với `From`.
- Giữ nguyên tên bảng. Không viết tắt (`CRM_Partner`, không `cp` / `p` / `t1`).
- Alias chỉ khi cần (temp table, self-join, bảng xuất hiện nhiều lần): `SMS_OutputVoucher tblOutput`.
- Điều kiện `on` cùng dòng join. Điều kiện join phụ xuống dòng, thụt thêm, bắt đầu bằng `and`.

```sql
From SMS_OutputVoucher tblOutput
	Inner Join SMS_OutputVoucherDetail tblDetail on tblDetail.OutputVoucherID = tblOutput.OutputVoucherID
	Inner Join SMS_Store on SMS_Store.StoreID = tblOutput.OutputStoreID
	Left Join CRM_Partner on CRM_Partner.PartnerID = tblOutput.PartnerID
		and CRM_Partner.IsDeleted = 0
```

## Tên bảng

- Giữ nguyên tên bảng gốc: `CRM_Partner`, `ACC_Receipt`, `SMS_Item`.
- Không viết tắt tên bảng.
- Qualify cột bằng tên bảng hoặc alias khi query có join.

## Temp table

Bắt buộc prefix `#tbl` + PascalCase, không dấu cách:

```
#tblMonth
#tblPartner
#tblReceipt
#tblDoanhThu
#tblItemPartner
```

```sql
Select
	PartnerID
Into #tblPartner
From CRM_Partner
Where IsDeleted = 0

Drop Table #tblPartner
```

Alias temp table khi join: `#tblReceipt tblReceipt`.

## Tham số và biến

- Tham số stored procedure: `@PascalCase` — `@OfficeID`, `@FromDate`, `@ToDate`.
- Biến local: `@camelCase` — `@date`, `@i`, `@msg`.
- Luôn parameterized. Cấm nối chuỗi SQL.

### Declare

- Khai báo nhiều biến: mỗi biến một dòng, dấu phẩy cuối dòng trước.
- Gom theo nhóm logic, comment `--` cho từng nhóm nếu cần.

```sql
Declare @PeriodID nvarchar(50),
	@TrainingLevelID nvarchar(50),
	@BranchID nvarchar(50),
	@msg nvarchar(500)
```

### Gán biến từ Select

- `Select Top 1 @var = Cot`: mỗi phép gán một dòng, thụt 1 tab.

```sql
Select Top 1
	@TrainingLevelID = WEB_StudentCollection.TrainingLevelID,
	@SpecialBranchID = WEB_StudentCollection.SpecialBranchID1,
	@Fullname = WEB_StudentCollection.FullName
From WEB_StudentCollection
Where WEB_StudentCollection.StudentCollectionID = @WebStudentCollectionID
```

- Gán đơn: `Select @BranchID = SIM_SpecialBranch.BranchID From SIM_SpecialBranch Where ...`

## Stored procedure

```sql
Alter Procedure [dbo].[TenThuTuc]
(
	@OfficeID int = null,
	@FromDate datetime,
	@ToDate datetime = null
)
As
Begin
	Set Nocount On;

	-- body

End
```

- `Create Procedure` khi tạo mới; `Alter Procedure` khi sửa file đã có.
- Tham số mỗi dòng, thụt 1 tab.
- Comment mô tả đầu file / đầu block bằng `--` hoặc `/* */`.

## Insert / Update / Delete

```sql
Insert Into ACC_Receipt
(
	ReceiptDate,
	PartnerID,
	TotalMoney,
	CreatedUser
)
Values
(
	@ReceiptDate,
	@PartnerID,
	@TotalMoney,
	@CreatedUser
)

Update CRM_Partner
Set
	PartnerName = @PartnerName,
	UpdatedDate = Getdate(),
	UpdatedUser = @UpdatedUser
Where PartnerID = @PartnerID
	and IsDeleted = 0

Delete From ACC_Receipt
Where ReceiptID = @ReceiptID
	and IsDeleted = 0
```

### Insert Into ... Select

- Danh sách cột `Insert` và `Select` tương ứng: mỗi cột một dòng.
- Comment inline `--` giữ nguyên sau cột nếu có.

```sql
Insert Into SIM_Student
(
	StudentCode,
	StudentFirstName,
	StudentLastName,
	CreatedUser,
	IsAutoCreate
)
Select
	@StudentCode,
	@FirstName,
	@LastName,
	@CreatedUser,
	1 -- IsAutoCreate
From WEB_StudentCollection
Where WEB_StudentCollection.StudentCollectionID = @WebStudentCollectionID
```

## CTE (Common Table Expression)

- Bắt đầu bằng `;With` nếu có câu lệnh trước đó.
- Tên CTE PascalCase; mỗi CTE một block `As (...)`.
- Nhiều CTE nối bằng dấu phẩy, CTE sau xuống dòng cùng cấp `With`.

```sql
;With ReceiptPlan As
(
	Select
		ACC_ReceiptPlan.ReceiptSegmentID,
		ACC_ReceiptPlan.YearID,
		ACC_ReceiptPlan.Money
	From ACC_ReceiptPlan
	Where ACC_ReceiptPlan.TrainingLevelID = @TrainingLevelID
		and ACC_ReceiptPlan.SpecialBranchID = @SpecialBranchID

	Union All

	Select
		ACC_ReceiptPlan.ReceiptSegmentID,
		ACC_ReceiptPlan.YearID,
		ACC_ReceiptPlan.Money
	From ACC_ReceiptPlan
	Where ACC_ReceiptPlan.TrainingLevelID = @TrainingLevelID
)
Insert Into ACC_StudentReceiptPlan
(
	StudentID,
	ReceiptSegmentID,
	Money
)
Select
	@StudentID,
	ReceiptPlan.ReceiptSegmentID,
	ReceiptPlan.Money
From ReceiptPlan
```

- Trong CTE/subquery `Not Exists`: dùng `Select 1`, không `Select *`.

## Case When

```sql
Case
	When @IsDriverCer = 1 Then ACC_ReceiptPlan.Money2
	Else ACC_ReceiptPlan.Money
End as Money
```

- `Case` / `When` / `Then` / `Else` / `End`: hoa chữ đầu.
- Biểu thức ngắn có thể một dòng: `Case When @TrainingLevelID = 'LX' Then 0 Else 1 End`

## While Exists

```sql
While Exists
(
	Select 1
	From SIM_StudentCollection
	Where SIM_StudentCollection.StudentCollectionCode = @StudentCollectionCode
		and SIM_StudentCollection.IsDeleted = 0
)
Begin
	Set @StudentCollectionCode = @BaseCode + '-' + Cast(@i As varchar)
	Set @i = @i + 1
End
```

## If / Raiserror / Return

```sql
If @PeriodID is null
Begin
	Set @msg = N'Không tìm thấy đợt tuyển sinh đang mở'
	Raiserror(@msg, 16, 1)
	Return
End
```

## Cấm

- `SELECT` / `FROM` / `WHERE` / `INNER JOIN` viết hoa toàn bộ.
- `select *` khi đã biết cột cần lấy.
- Viết tắt tên bảng (`p`, `t1`, `cp`).
- Temp table không bắt đầu `#tbl`.
- Nối chuỗi SQL thay vì parameter.
- Gom nhiều cột trên một dòng.

## Checklist trước khi trả SQL

- [ ] Keyword chỉ hoa chữ đầu
- [ ] Mỗi cột một dòng
- [ ] Tên bảng gốc, không viết tắt
- [ ] Temp table dạng `#tbl...`
- [ ] Parameter, không concatenate
- [ ] Join / Where / Order By đúng indent
- [ ] CTE / Insert Select / While Exists đúng block
- [ ] `is null` / `is not null` viết thường
- [ ] `Not Exists` dùng `Select 1`

Ví dụ đầy đủ: [examples.md](examples.md)
