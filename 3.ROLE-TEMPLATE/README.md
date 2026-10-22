# CLAUDE CONFIGURATION TEMPLATE

Template cấu hình Claude Code để áp dụng cho các project mới.

## 📁 Cấu trúc thư mục

```
CLAUDE-TEMPLATE/
├── .claude/
│   ├── settings.json          # Cấu hình Claude (block ổ đĩa khác)
│   ├── README.md             # Hướng dẫn cho AI
│   └── skills/               # Các skill cho AI
│       ├── find-code.md
│       ├── fix-bug.md
│       ├── code-review.md
│       ├── add-feature.md
│       ├── project-info.md
│       ├── run-app.md
│       ├── sql-helper.md
│       ├── using-superpowers.md
│       └── ponytail.md
├── .codex/
│   ├── settings.json          # Cấu hình Codex (block ổ đĩa khác)
│   ├── conventions.md         # Quy ước cho Codex
│   └── README.md             # Hướng dẫn cho Codex
├── .ai-conventions.md        # Quy ước cho AI
└── install-claude-config.ps1 # Script cài đặt
```

## 🚀 Cách sử dụng

### Cách 1: Sử dụng file .bat (Đơn giản nhất)

Chuột phải vào file `install-claude-config.bat` → **Chạy với PowerShell**

Hoặc mở CMD và chạy:

```cmd
cd "G:\1.1-PROJECT-MAIN\CLAUDE-TEMPLATE"
install-claude-config.bat "G:\1.1-PROJECT-MAIN\PROJECT-MOI"
```

### Cách 2: Sử dụng script PowerShell

Mở PowerShell và chạy:

```powershell
cd "G:\1.1-PROJECT-MAIN\CLAUDE-TEMPLATE"
.\install-claude-config.ps1 "G:\1.1-PROJECT-MAIN\PROJECT-MOI"
```

Thay `G:\1.1-PROJECT-MAIN\PROJECT-MOI` bằng đường dẫn đến project mới của bạn.

### Cách 3: Copy thủ công

Copy toàn bộ thư mục `.claude`, `.codex` và file `.ai-conventions.md` vào project mới:

```
CLAUDE-TEMPLATE\.claude\      → PROJECT-MOI\.claude\
CLAUDE-TEMPLATE\.codex\       → PROJECT-MOI\.codex\
CLAUDE-TEMPLATE\.ai-conventions.md → PROJECT-MOI\.ai-conventions.md
```

Sau đó sửa thủ công tên project trong file `.ai-conventions.md` và `.codex/conventions.md`.

## ⚠️ Lưu ý quan trọng

- Script chỉ hoạt động với project nằm trên ổ đĩa **G:**
- Script sẽ **ghi đè** nếu đã có cấu hình cũ
- Script tự động cập nhật tên project trong file `.ai-conventions.md`

## 📋 Quy tắc được áp dụng

Sau khi cài đặt, project mới sẽ có các quy tắc:

1. ✅ **Chỉ làm việc trên ổ đĩa G:** - Không truy cập ổ C, D, E, F, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
2. ✅ **Chỉ trong thư mục project hiện tại** - Không lan man sang thư mục khác
3. ✅ **Project độc lập** - Không đọc thông tin từ project khác

## 🔧 Cập nhật template

Nếu bạn muốn cập nhật cấu hình cho tất cả project mới:

1. Sửa file trong thư mục `CLAUDE-TEMPLATE`
2. Các project đã tạo sẽ không tự động cập nhật
3. Cần chạy lại script hoặc copy thủ công cho project cũ

---

**Created**: 2026-10-22
**Location**: G:\1.1-PROJECT-MAIN\CLAUDE-TEMPLATE
