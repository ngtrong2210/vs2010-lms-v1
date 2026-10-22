# Script cài đặt cấu hình Claude cho project mới
# Sử dụng: .\install-claude-config.ps1 "Đường dẫn đến project mới"

param(
    [Parameter(Mandatory=$true)]
    [string]$ProjectPath
)

# Đường dẫn template
$TemplatePath = "G:\1.1-PROJECT-MAIN\CLAUDE-TEMPLATE"

# Kiểm tra template tồn tại
if (-not (Test-Path $TemplatePath)) {
    Write-Host "❌ Không tìm thấy thư mục template: $TemplatePath" -ForegroundColor Red
    exit 1
}

# Kiểm tra project path
if (-not (Test-Path $ProjectPath)) {
    Write-Host "❌ Không tìm thấy thư mục project: $ProjectPath" -ForegroundColor Red
    exit 1
}

# Kiểm tra project trên ổ G
if ($ProjectPath -notmatch "^G:\\") {
    Write-Host "❌ Project phải nằm trên ổ đĩa G:" -ForegroundColor Red
    exit 1
}

Write-Host "🚀 Bắt đầu cài đặt cấu hình Claude cho project..." -ForegroundColor Cyan
Write-Host "   Project: $ProjectPath" -ForegroundColor Yellow
Write-Host ""

# Copy .claude folder
$SourceClaude = Join-Path $TemplatePath ".claude"
$DestClaude = Join-Path $ProjectPath ".claude"

if (Test-Path $DestClaude) {
    Write-Host "⚠️  Thư mục .claude đã tồn tại, sẽ ghi đè..." -ForegroundColor Yellow
    Remove-Item -Path $DestClaude -Recurse -Force
}

Write-Host "📁 Copy thư mục .claude..." -ForegroundColor Green
Copy-Item -Path $SourceClaude -Destination $DestClaude -Recurse -Force

# Copy .ai-conventions.md
$SourceConventions = Join-Path $TemplatePath ".ai-conventions.md"
$DestConventions = Join-Path $ProjectPath ".ai-conventions.md"

if (Test-Path $DestConventions) {
    Write-Host "⚠️  File .ai-conventions.md đã tồn tại, sẽ ghi đè..." -ForegroundColor Yellow
    Remove-Item -Path $DestConventions -Force
}

Write-Host "📄 Copy file .ai-conventions.md..." -ForegroundColor Green
Copy-Item -Path $SourceConventions -Destination $DestConventions -Force

# Copy .codex folder
$SourceCodex = Join-Path $TemplatePath ".codex"
$DestCodex = Join-Path $ProjectPath ".codex"

if (Test-Path $DestCodex) {
    Write-Host "⚠️  Thư mục .codex đã tồn tại, sẽ ghi đè..." -ForegroundColor Yellow
    Remove-Item -Path $DestCodex -Recurse -Force
}

Write-Host "📁 Copy thư mục .codex..." -ForegroundColor Green
Copy-Item -Path $SourceCodex -Destination $DestCodex -Recurse -Force

# Cập nhật project name và path trong .ai-conventions.md
$ProjectName = Split-Path $ProjectPath -Leaf
$ConventionsContent = Get-Content $DestConventions -Raw
$ConventionsContent = $ConventionsContent -replace "{{PROJECT_PATH}}", $ProjectPath
$ConventionsContent = $ConventionsContent -replace "{{PROJECT_NAME}}", $ProjectName
Set-Content -Path $DestConventions -Value $ConventionsContent -NoNewline

# Cập nhật project name và path trong .codex/conventions.md
$CodexConventionsPath = Join-Path $DestCodex "conventions.md"
$CodexConventionsContent = Get-Content $CodexConventionsPath -Raw
$CodexConventionsContent = $CodexConventionsContent -replace "{{PROJECT_PATH}}", $ProjectPath
$CodexConventionsContent = $CodexConventionsContent -replace "{{PROJECT_NAME}}", $ProjectName
Set-Content -Path $CodexConventionsPath -Value $CodexConventionsContent -NoNewline

Write-Host ""
Write-Host "✅ Cài đặt hoàn thành!" -ForegroundColor Green
Write-Host "   - Đã copy thư mục .claude" -ForegroundColor White
Write-Host "   - Đã copy thư mục .codex" -ForegroundColor White
Write-Host "   - Đã copy file .ai-conventions.md" -ForegroundColor White
Write-Host "   - Đã cập nhật tên project: $ProjectName" -ForegroundColor White
Write-Host ""
Write-Host "📝 Các quy tắc đã áp dụng:" -ForegroundColor Cyan
Write-Host "   ✅ Chỉ làm việc trên ổ đĩa G:" -ForegroundColor White
Write-Host "   ✅ Chỉ làm việc trong thư mục project hiện tại" -ForegroundColor White
Write-Host "   ✅ Không truy cập project khác" -ForegroundColor White
Write-Host ""
