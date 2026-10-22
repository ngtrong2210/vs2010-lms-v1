@echo off
REM Script cài đặt cấu hình Claude cho project mới
REM Sử dụng: install-claude-config.bat "Đường dẫn đến project mới"

if "%~1"=="" (
    echo ❌ Vui long cung cap duong dan den project moi
    echo.
    echo Cach su dung:
    echo   install-claude-config.bat "G:\1.1-PROJECT-MAIN\PROJECT-MOI"
    echo.
    pause
    exit /b 1
)

set "PROJECT_PATH=%~1"

REM Kiểm tra project path có phải ổ G không
echo %PROJECT_PATH% | findstr /b /i "G:\\" >nul
if %errorlevel% neq 0 (
    echo ❌ Project phai nam tren o dia G:
    pause
    exit /b 1
)

REM Kiểm tra project path tồn tại
if not exist "%PROJECT_PATH%" (
    echo ❌ Khong tim thay thu muc project: %PROJECT_PATH%
    pause
    exit /b 1
)

echo.
echo 🚀 Bat dau cai dat cau hinh Claude cho project...
echo    Project: %PROJECT_PATH%
echo.

REM Chạy PowerShell script
powershell -ExecutionPolicy Bypass -File "%~dp0install-claude-config.ps1" -ProjectPath "%PROJECT_PATH%"

if %errorlevel% equ 0 (
    echo.
    echo ✅ Cai dat hoan thanh!
) else (
    echo.
    echo ❌ Co loi xay ra trong qua trinh cai dat
)

pause
