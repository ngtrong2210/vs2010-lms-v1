---
name: restructure-backend-frontend
overview: Tách rõ hai luồng ứng dụng `backend/` và `frontend/` mà không thay đổi kiến trúc code, API hoặc phân quyền. Giữ toàn bộ tài nguyên không tham gia build/runtime trong `references/`, đồng thời cập nhật mọi đường dẫn và kiểm chứng build/test.
todos:
  - id: move-backend
    content: Tạo `backend/` và di chuyển solution, source, tests, database, tools bằng Git
    status: completed
  - id: consolidate-references
    content: Hoàn tất việc gom file ngoài project vào `references/` và xác nhận không còn bản trùng ở root
    status: completed
  - id: fix-paths
    content: Cập nhật solution, project references, database root và production scripts
    status: completed
  - id: update-docs
    content: Đồng bộ README, tài liệu kiến trúc/deploy/security và ignore theo cấu trúc mới
    status: completed
  - id: verify
    content: Tìm reference cũ, build/test backend và frontend, kiểm tra package và git status
    status: completed
isProject: false
---

# Chuẩn hóa cấu trúc project

## Cấu trúc đích

```text
CMS-LMS-VueJS/
├── backend/
│   ├── Sims.sln
│   ├── src/
│   ├── tests/
│   ├── database/
│   └── tools/
├── frontend/
├── references/
│   ├── sample-data/
│   ├── sample-media/
│   └── legacy-templates/
├── docs/
├── scripts/
├── README.md
└── .gitignore
```

- `backend/` là một luồng .NET độc lập: solution, source, test, SQL và generator đi cùng nhau.
- `frontend/` giữ nguyên nội dung Vue/Vite; không refactor `src`, router, API client hoặc logic role.
- `references/` chỉ chứa dữ liệu/source tham khảo, không tham gia build và runtime. Các bản cũ ở root như `soure-code-mẫu/`, `data-mau/`, PDF/MP4 rời đã được chuyển vào đây trong thay đổi đang có và sẽ không bị nhân đôi.
- `docs/` và `scripts/` giữ ở root vì phục vụ cả backend lẫn frontend.

## Các bước thực hiện

1. Di chuyển bằng Git để bảo toàn lịch sử:
   - [`Sims.sln`](Sims.sln) → `backend/Sims.sln`.
   - [`src/`](src/) → `backend/src/`.
   - [`tests/`](tests/) → `backend/tests/`.
   - [`database/`](database/) → `backend/database/`.
   - [`tools/`](tools/) → `backend/tools/`.
   - Giữ [`references/`](references/) tại root và hoàn tất relocation đang dở từ `soure-code-mẫu/`, `data-mau/`, PDF/MP4 rời.
2. Cập nhật đường dẫn nội bộ backend:
   - Solution mới [`backend/Sims.sln`](backend/Sims.sln) trỏ tới `src`, `tests`, `tools` bên trong `backend`.
   - Giữ nguyên các `ProjectReference` giữa các project trong `backend/src`; cập nhật reference của test nếu cần theo vị trí mới.
   - Giữ nguyên mặc định `Database:ScriptsPath = ../../database` trong [`backend/src/SimsData/Data/DatabaseInitializer.cs`](backend/src/SimsData/Data/DatabaseInitializer.cs), vì từ `backend/src/Sims.Api` nó trỏ đúng tới `backend/database`; chỉ kiểm chứng lại bằng test/init path.
   - Giữ logic tìm root của [`backend/tools/SimsObjectGenerator/Program.cs`](backend/tools/SimsObjectGenerator/Program.cs): khi `Sims.sln` nằm ở `backend/`, các đường dẫn `src/Sims.Api` và `src/SimsObject` hiện có tiếp tục đúng.
   - Xác nhận [`backend/src/Sims.Api/Program.cs`](backend/src/Sims.Api/Program.cs) lưu Data Protection key tại `backend/storage/cache/data-protection`; cập nhật ignore để key và runtime storage tuyệt đối không bị commit.
3. Cập nhật automation dùng cấu trúc mới:
   - [`scripts/production/Publish-Backend.ps1`](scripts/production/Publish-Backend.ps1) dùng `backend/Sims.sln` và `backend/src/Sims.Api/Sims.Api.csproj`.
   - [`scripts/production/Invoke-ProductionDatabaseSync.ps1`](scripts/production/Invoke-ProductionDatabaseSync.ps1) dùng config/API và migration trong `backend/`, đồng thời chạy `sqlcmd` với working directory `backend/` để các lệnh `:r .\database\...` trong master SQL vẫn đúng mà không phải sửa hàng loạt SQL.
   - Giữ [`scripts/production/Build-Frontend.ps1`](scripts/production/Build-Frontend.ps1) theo `frontend/`; không trộn artifact hai luồng.
4. Đồng bộ tài liệu và ignore:
   - Cập nhật [`README.md`](README.md), [`docs/DEVELOPMENT.md`](docs/DEVELOPMENT.md), [`docs/BACKEND_ARCHITECTURE.md`](docs/BACKEND_ARCHITECTURE.md), tài liệu deployment/security và [`docs/VS_CODE_COMMANDS.html`](docs/VS_CODE_COMMANDS.html) sang lệnh `backend/...`.
   - Sửa [`references/README.md`](references/README.md) để mô tả rõ đây là khu vực ngoài luồng ứng dụng.
   - Cập nhật [`.gitignore`](.gitignore) cho `backend/**/bin`, `backend/**/obj`, runtime storage và artifact; không đưa secret hoặc generated output vào Git.
5. Kiểm chứng sau di chuyển:
   - Tìm toàn repo để bảo đảm không còn reference lỗi tới root `src/`, `tests/`, `database/`, `tools/`, `references/`, `soure-code-mẫu/` hoặc `data-mau/`.
   - Chạy `dotnet restore backend/Sims.sln`, `dotnet build backend/Sims.sln`, `dotnet test backend/Sims.sln --no-build`.
   - Chạy thử `backend/tools/SimsObjectGenerator` ở chế độ không ghi nếu công cụ hỗ trợ; nếu không, xác minh đường dẫn root/config bằng kiểm tra tĩnh để tránh sinh lại hàng loạt object.
   - Chạy `npm ci`, `npm run test`, `npm run build` trong `frontend/`.
   - Chạy build/publish script ở chế độ an toàn và xác nhận package backend không chứa `wwwroot/Media`.
   - Kiểm tra master production SQL resolve được toàn bộ `:r` từ working directory `backend/`, không thực thi migration lên database thật trong bước kiểm chứng cấu trúc.
   - Rà `git status` để bảo toàn toàn bộ thay đổi sẵn có và xác nhận Git nhận diện phần lớn thao tác là rename, không xóa nhầm source.