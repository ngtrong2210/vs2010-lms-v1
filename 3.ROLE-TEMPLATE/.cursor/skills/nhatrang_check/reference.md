# nhatrang_check — reference

## Bảng / đối tượng

| Đối tượng | Vai trò |
|-----------|---------|
| `SIM_Class_Subject` | Môn–lớp (ClassSubjectID) |
| `SIM_Class_Subject_Teacher` | Phân GV; TheoryQuantity/PracticeQuantity theo dòng CSTeacher |
| `SIM_WeekDetailPlan` | Giờ từng tuần; IsPractice 0/1 |
| `SIM_WeekDetailPlan_TongHopKeHoachGiaoVien` | Store lưới KHT GV |

## Debug 03 — các section

- **A:** Nhiều `ClassSubjectID` cùng SubjectID+ClassID+Year → dữ liệu trùng MHL.
- **B:** `SIM_Class_Subject_Teacher` — mấy GV, LT/TH từng dòng.
- **C:** Chi tiết tuần LT/TH trong `SIM_WeekDetailPlan`.
- **D–G:** Tổng theo tuần, so join có/không lọc IsPractice (mô phỏng trước/sau patch).

## Debug 07

Tham số `@ScienceID`, `@SubjectGroupID`, `@TeacherID`, `@IsContractTeaching` phải khớp combobox trên form khi user F3.

## Verify 02 — chuỗi bắt buộc trong definition

- `tbl.IsPractice = 0 and isnull(#tblCS.TheoryQuantity, 0) > 0`
- `tbl.IsPractice = 1 and isnull(#tblCS.PracticeQuantity, 0) > 0`

Thiếu một trong hai → **CHƯA PATCH**.

## Đường dẫn tuyệt đối (Windows)

`g:/1.1-PROJECT-MAIN/NHA TRANG/NHA TRANG - thoikhoabieu/3. SQL/patches/`
