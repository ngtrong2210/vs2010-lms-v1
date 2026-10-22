# Codex AI Configuration for NAM SÀI GÒN -WB Project

## 📁 Cấu trúc

```
.codex/
├── settings.json          # Cấu hình chính (denylist, instructions)
├── conventions.md         # Quy ước làm việc
└── README.md             # File này
```

## ⚙️ Cấu hình (settings.json)

### QUY TẮC TUYỆT ĐỐI (BẮT BUỘC TUÂN THỦ):

1. ❌ **CHỈ ĐƯỢC LÀM VIỆC TRÊN Ổ ĐĨA G**
   - Không truy cập ổ C, D, E, F, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z

2. ✅ **CHỈ LÀM VIỆC TRONG THƯ MỤC DỰ ÁN HIỆN TẠI**
   - Path: `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`
   - Không lan man sang các thư mục khác trên ổ G

3. 🔒 **MỖI PROJECT ĐỘC LẬP**
   - Chỉ đọc/viết trong thư mục của project hiện tại
   - Không đọc thông tin từ project khác
   - Không truy cập thư mục project khác

4. 📝 **QUY TẮC LÀM VIỆC**
   - Ưu tiên đọc file trước khi edit
   - Kiểm tra lỗi cú pháp C# và ASPX
   - Hiểu cấu trúc solution .NET

## 📋 Cấu trúc dự án

```
NAM SÀI GÒN -WB/
├── 1.WEB/         # ASP.NET Web Forms Application
├── 2.WIN-FORM/    # Windows Forms Application
└── sql/           # SQL Scripts
```

## 🔒 Security & Quy tắc truy cập

### Quy tắc truy cập:
- ✅ **CHỈ** được làm việc trên ổ đĩa G
- ✅ **CHỈ** được truy cập thư mục dự án hiện tại: `G:\1.1-PROJECT-MAIN\NAM SÀI GÒN -WB`
- ❌ **KHÔNG** được truy cập ổ C, D, E, F, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
- ❌ **KHÔNG** được lan man sang các thư mục khác trên ổ G
- ❌ **KHÔNG** được đọc thông tin từ project khác

### Quy tắc làm việc:
- Codex sẽ tuân thủ denylist trong settings.json
- Không tự động chạy lệnh nguy hiểm
- Luôn confirm trước khi sửa code quan trọng
- Mỗi project độc lập, không chia sẻ thông tin
