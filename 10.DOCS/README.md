# 10.DOCS - Tài liệu & Báo cáo

## Quy tắc tổ chức file

Đây là thư mục chứa tất cả tài liệu kỹ thuật, báo cáo, và documentation của dự án.

---

## 📁 Danh sách file hiện có

| File | Mô tả | Loại |
|------|-------|------|
| `BAO_CAO_KY_THUAT.md` | Báo cáo phân tích Stored Procedures chi tiết | Markdown |
| `TOM_TAT_BAO_CAO.md` | Tóm tắt báo cáo kỹ thuật | Markdown |
| `db_procedures.txt` | Danh sách procedures export từ database | Text |

---

## 📝 Quy tắc đặt tên file

### Báo cáo kỹ thuật
- **Hậu tố**: `_BAO_CAO.md` hoặc `_REPORT.md`
- **Ngôn ngữ**: Tiếng Việt (theo yêu cầu dự án)
- **Định dạng**: Markdown

### Tài liệu hướng dẫn
- **Hậu tố**: `_HUONG_DAN.md` hoặc `_GUIDE.md`
- **Ngôn ngữ**: Tiếng Việt
- **Định dạng**: Markdown

### Tài liệu thiết kế
- **Hậu tố**: `_THIET_KE.md` hoặc `_DESIGN.md`
- **Ngôn ngữ**: Tiếng Việt
- **Định dạng**: Markdown

### Tài liệu API
- **Hậu tố**: `_API.md`
- **Ngôn ngữ**: Tiếng Việt hoặc English
- **Định dạng**: Markdown

### File export/đầu ra
- **Hậu tố**: `.txt` - Raw data export
- **Hậu tố**: `.json` - Structured data
- **Hậu tố**: `.csv` - Tabular data

---

## 📚 Cấu trúc tài liệu khuyến nghị

```
10.docs/
├── README.md                     # File này
├── 01_BAO_CAO/                   # Báo cáo kỹ thuật
│   ├── BAO_CAO_KY_THUAT.md
│   └── TOM_TAT_BAO_CAO.md
├── 02_HUONG_DAN/                 # Hướng dẫn sử dụng
│   └── HUONG_DAN_CAI_DAT.md
├── 03_THIET_KE/                  # Thiết kế hệ thống
│   └── THIET_KE_DATABASE.md
├── 04_API/                       # Tài liệu API
│   └── API_REFERENCE.md
└── 05_EXPORT/                    # File export/dữ liệu
    └── db_procedures.txt
```

---

## 📌 Quy tắc viết tài liệu

### 1. Ngôn ngữ
- Sử dụng **Tiếng Việt** làm ngôn ngữ chính
- Thuật ngữ kỹ thuật có thể giữ nguyên tiếng Anh (ví dụ: stored procedure, API, CRUD)

### 2. Định dạng Markdown
- Sử dụng các heading (#, ##, ###) để cấu trúc
- Sử dụng bảng (|) cho dữ liệu thống kê
- Sử dụng code block (```) cho code examples
- Sử dụng checklist (✅, ❌, ⚠️) cho trạng thái

### 3. Bố cục báo cáo
- Tổng quan
- Phân tích chi tiết
- Kết quả
- Vấn đề phát hiện
- Đề xuất giải pháp
- File đính kèm

### 4. Metadata
Bắt đầu mỗi tài liệu với:
```markdown
---
**Tiêu đề**: [Tên tài liệu]
**Người tạo**: [Tên]
**Ngày tạo**: [YYYY-MM-DD]
**Phiên bản**: [x.x]
**Trạng thái**: [Hoàn thành/Đang soạn thảo]
---
```

---

## 🚀 Template báo cáo kỹ thuật

```markdown
# [TÊN BÁO CÁO]

## Tổng quan
[Mô tả ngắn về mục đích báo cáo]

## Phân tích
[Chi tiết phân tích]

## Kết quả
[Bảng thống kê/kết quả]

## Vấn đề phát hiện
[List các vấn đề]

## Đề xuất giải pháp
[Giải pháp đề xuất]

## File đính kèm
[List các file liên quan]
```

---

## 📌 Ghi chú

- Tất cả tài liệu nên được version control
- Update tài liệu khi có thay đổi hệ thống
- Review tài liệu trước khi publish
- Giữ tài liệu ngắn gọn, dễ hiểu
