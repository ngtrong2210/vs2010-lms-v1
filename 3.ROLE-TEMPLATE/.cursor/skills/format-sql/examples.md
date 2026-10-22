# Ví dụ format SQL

## Sai → đúng

### Keyword và cột

Sai:

```sql
SELECT PartnerID, PartnerCode, PartnerName FROM CRM_Partner WHERE IsDeleted = 0 ORDER BY PartnerName
```

Đúng:

```sql
Select
	CRM_Partner.PartnerID,
	CRM_Partner.PartnerCode,
	CRM_Partner.PartnerName
From CRM_Partner
Where CRM_Partner.IsDeleted = 0
Order By CRM_Partner.PartnerName
```

### Join viết tắt tên bảng

Sai:

```sql
SELECT r.ReceiptID, p.PartnerName
FROM ACC_Receipt r
INNER JOIN CRM_Partner p ON p.PartnerID = r.PartnerID
WHERE r.IsDeleted = 0 AND r.IsCanceled = 0
```

Đúng:

```sql
Select
	ACC_Receipt.ReceiptID,
	CRM_Partner.PartnerName
From ACC_Receipt
	Inner Join CRM_Partner on CRM_Partner.PartnerID = ACC_Receipt.PartnerID
Where ACC_Receipt.IsDeleted = 0
	and ACC_Receipt.IsCanceled = 0
```

### Temp table

Sai:

```sql
SELECT PartnerID INTO #Partner FROM CRM_Partner WHERE IsDeleted = 0
```

Đúng:

```sql
Select
	PartnerID
Into #tblPartner
From CRM_Partner
Where IsDeleted = 0
```

## Stored procedure đầy đủ

```sql
Alter Procedure [dbo].[ACC_Receipt_BaoCaoThucHienTheoKhachHang]
(
	@OfficeID int = null,
	@FromDate datetime,
	@ToDate datetime = null
)
As
Begin
	Set Nocount On;

	If @ToDate is null
		Set @ToDate = Getdate()

	Select
		PartnerID
	Into #tblPartner
	From CRM_Partner
	Where IsDeleted = 0

	Select
		ReceiptID,
		ReceiptDate,
		PartnerID,
		TotalMoney
	Into #tblReceipt
	From ACC_Receipt
	Where IsDeleted = 0
		and IsCanceled = 0
		and PartnerID is not null
		and (@OfficeID is null or OfficeID = @OfficeID)
		and ReceiptDate >= @FromDate
		and ReceiptDate < @ToDate

	Select
		tblReceipt.PartnerID,
		Sum(tblReceipt.TotalMoney) as "TongDoanhThu"
	Into #tblDoanhThu
	From #tblPartner
		Inner Join #tblReceipt tblReceipt on tblReceipt.PartnerID = #tblPartner.PartnerID
	Group By tblReceipt.PartnerID

	Drop Table #tblReceipt

	Select
		CRM_Partner.PartnerID,
		CRM_Partner.PartnerCode,
		CRM_Partner.PartnerName,
		Isnull(tblDoanhThu.TongDoanhThu, 0) as "TongDoanhThu"
	From #tblPartner
		Inner Join CRM_Partner on CRM_Partner.PartnerID = #tblPartner.PartnerID
		Left Join #tblDoanhThu tblDoanhThu on tblDoanhThu.PartnerID = CRM_Partner.PartnerID
	Order By CRM_Partner.OrderIndex, CRM_Partner.PartnerName

	Drop Table #tblPartner
	Drop Table #tblDoanhThu
End
```

## Insert / Update

```sql
Insert Into ACC_PaymentSegment
(
	PaymentSegmentCode,
	PaymentSegmentName,
	IsActived,
	CreatedDate,
	CreatedUser
)
Values
(
	@PaymentSegmentCode,
	@PaymentSegmentName,
	1,
	Getdate(),
	@CreatedUser
)

Update ACC_PaymentSegment
Set
	PaymentSegmentName = @PaymentSegmentName,
	UpdatedDate = Getdate(),
	UpdatedUser = @UpdatedUser
Where PaymentSegmentID = @PaymentSegmentID
	and IsDeleted = 0
```

## Select Top 1 gán biến

Sai:

```sql
Select top 1 @TrainingLevelID = TrainingLevelID, @Fullname = FullName
From WEB_StudentCollection Where StudentCollectionID = @WebStudentCollectionID
```

Đúng:

```sql
Select Top 1
	@TrainingLevelID = WEB_StudentCollection.TrainingLevelID,
	@Fullname = WEB_StudentCollection.FullName
From WEB_StudentCollection
Where WEB_StudentCollection.StudentCollectionID = @WebStudentCollectionID
```

## CTE + Insert Select

Sai:

```sql
;With ReceiptPlan as (Select tbl.ReceiptSegmentID, tbl.Money From ACC_ReceiptPlan as tbl Where tbl.TrainingLevelID = @TrainingLevelID)
Insert Into ACC_StudentReceiptPlan (StudentID, ReceiptSegmentID, Money)
Select @StudentID, ReceiptSegmentID, Money From ReceiptPlan
```

Đúng:

```sql
;With ReceiptPlan As
(
	Select
		ACC_ReceiptPlan.ReceiptSegmentID,
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
