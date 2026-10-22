---
name: nhatrang_check
description: >-
  Checklist chẩn đoán Nha Trang thoikhoabieu — KHT GV (frmWeekTeachingPlan2) lệch KHT lớp,
  giờ tuần LT+TH cộng đôi, store SIM_WeekDetailPlan_TongHopKeHoachGiaoVien chưa patch.
  Dùng khi user nói KHT giáo viên, kế hoạch tuần không khớp, CHƯA PATCH, F5 SQL, LTCB, NTCT076/081.
---

# nhatrang_check

Đọc skill này **trước** khi debug lại từ đầu hoặc tạo patch/verify SQL trùng.

## Phạm vi project

- Workspace: `NHA TRANG - thoikhoabieu`
- WinForms: `1.WIN-FORM 1424/ScheduleManager/Teaching/frmWeekTeachingPlan2.cs` — load store `SIM_WeekDetailPlan_TongHopKeHoachGiaoVien` (ReadData ~ dòng 148).
- KHT chi tiết lớp: `SIM_WeekDetailPlan`, cột `IsPractice` (0=LT, 1=TH).
- Patch SQL: `3. SQL/patches/` — prefix `20261001_0N_...`.

DB app thường: `HATRANG_2024` hoặc `NHATRANG_2024` (user phải chọn đúng trên SSMS).

## Triệu chứng đã biết (case mẫu)

- Một môn–lớp **2 GV** (1 LT, 1 TH), KHT lớp đúng (vd tuần 4: **10 LT + 8 TH**).
- Form **Kế hoạch GV** cả hai dòng cùng **18, 8, 8…** (LT+TH gộp).
- Case chuẩn: `LTCB_1355`, lớp `CĐ-CBMA20`, `NTCT076` (An, LT), `NTCT081` (Vũ, TH), `@YearID=2026`, `@Semester=1`.

## Nguyên nhân gốc (đã xác định)

**Không** mặc định là gán GV sai trên form môn–lớp.

Store **`dbo.SIM_WeekDetailPlan_TongHopKeHoachGiaoVien`** (bản cũ trên DB): join `SIM_WeekDetailPlan` chỉ theo `ClassSubjectID` → mọi dòng GV cùng môn–lớp nhận **cả** tuần LT và TH.

**Fix:** patch file **01** — join thêm:

```sql
Left join SIM_WeekDetailPlan tbl on #tblCS.ClassSubjectID = tbl.ClassSubjectID
    and (
        (tbl.IsPractice = 0 and isnull(#tblCS.TheoryQuantity, 0) > 0)
        or (tbl.IsPractice = 1 and isnull(#tblCS.PracticeQuantity, 0) > 0)
    )
```

File đầy đủ: `3. SQL/patches/20261001_01_PATCH_store_TongHopKeHoachGiaoVien_LT_TH.sql`.

## Quy trình agent (bắt buộc)

1. **Không** sửa WinForms trước khi biết DB đã patch chưa.
2. Chỉ dẫn user (hoặc ghi trong patch mới): SSMS → chọn DB app → **F5 = Execute**.
3. **Verify ≠ sửa:** file **02** chỉ đọc `sys.sql_modules`; **01** mới ALTER store.
4. Thứ tự user cần chạy: **01 → 02 → mở lại form KHT GV**.
5. Nếu **02 = ĐÃ PATCH** mà form vẫn sai → chạy **03** (chỉnh `@SubjectID`/`@ClassID`) hoặc **07** (filter GV/môn khác); xem duplicate `ClassSubjectID`, phân công `SIM_Class_Subject_Teacher`, dữ liệu `SIM_WeekDetailPlan`.
6. File **04–06** chỉ khi user **cố ý xóa** KHT tuần; không đưa vào luồng sửa store mặc định.
7. Patch store mới: tuân `sql-store-patches` — file patch riêng trong `3. SQL/patches/`, không sửa file SQL gom nhiều store; cập nhật số thứ tự / `20261001_00_HUONG_DAN_CHAY.txt` nếu thêm bước.

## Checklist nhanh (copy khi trả lời user)

```
- [ ] DB SSMS = DB app (HATRANG_2024 / NHATRANG_2024)
- [ ] F5 file 01 → Commands completed successfully
- [ ] F5 file 02 → PatchStatus = ĐÃ PATCH
- [ ] Exec store: NTCT076 Week_* LT only; NTCT081 Week_* TH only (LTCB_1355 / CĐ-CBMA20)
- [ ] Form KHT GV: F3 / đóng mở sau patch
```

Kỳ vọng sau patch (tuần 3 mẫu): **NTCT076 ≈ 10**, **NTCT081 ≈ 8** — **không** cùng **18**.

## Danh sách file SQL (20261001)

| Số | File | Mục đích |
|----|------|----------|
| 00 | `20261001_00_HUONG_DAN_CHAY.txt` | Hướng dẫn user |
| **01** | `20261001_01_PATCH_store_TongHopKeHoachGiaoVien_LT_TH.sql` | **Bắt buộc** — ALTER store |
| **02** | `20261001_02_KIEM_TRA_patch_LT_TH.sql` | Kiểm tra patch + gọi store mẫu |
| 03 | `20261001_03_DEBUG_LTCB1355_CDBMA20.sql` | A–G: MHL trùng, CSTeacher, WeekDetailPlan, join mô phỏng |
| 04 | `20261001_04_XOA_het_KH_tuan_LTCB1355_CDBMA20.sql` | Xóa toàn bộ KHT tuần môn–lớp |
| 05 | `20261001_05_XOA_TH_LTCB1355_CDBMA20.sql` | Xóa chỉ TH |
| 06 | `20261001_06_XOA_TH_MH0266_CDKTML18A.sql` | Case khác (MH0266) |
| 07 | `20261001_07_DEBUG_form_WeekTeachingPlan2.sql` | So khớp tham số form + store |

Chi tiết section debug: [reference.md](reference.md).

## Câu trả lời user (ngắn)

- **"CHƯA PATCH / F5 là gì?"** → Chưa chạy file **01** trên DB; F5 = Chạy script trong SSMS.
- **"Lỗi do gì?"** → Store tổng hợp KHT GV cộng LT+TH cho mọi GV cùng ClassSubjectID; fix bằng file **01**.

## Không làm lại

- Không tạo thêm verify script trùng logic **02** (chỉ mở rộng **02** nếu cần chuỗi kiểm tra mới).
- Không yêu cầu user F5 chỉ file **02** để "sửa".
- Không đổi `frmWeekTeachingPlan2` cho triệu chứng LT+TH đôi **trừ khi** đã **ĐÃ PATCH** và bằng chứng chỉ ra lỗi UI/load khác store.
