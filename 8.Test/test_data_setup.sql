-- ============================================
-- TEST DATA SETUP SCRIPT
-- Dự án: LMS-VS2010
-- Mục đích: Tạo dữ liệu test cho runtime testing
-- Ngày tạo: 22/10/2026
-- ============================================

USE [LMSCMS_DB]
GO

PRINT 'Bắt đầu tạo dữ liệu test...'
PRINT '================================='

-- ============================================
-- 1. TẠO USER TEST
-- ============================================

PRINT ''
PRINT '1. Tạo user test...'

-- Xóa user test nếu đã tồn tại
IF EXISTS (SELECT 1 FROM SYS_Users WHERE Username = 'student_test')
BEGIN
    PRINT '  - Xóa user test cũ: student_test'
    DELETE FROM SYS_Users WHERE Username = 'student_test'
END

IF EXISTS (SELECT 1 FROM SYS_Users WHERE Username = 'admin_test')
BEGIN
    PRINT '  - Xóa user test cũ: admin_test'
    DELETE FROM SYS_Users WHERE Username = 'admin_test'
END

-- Tạo student test
-- Password: 123456 (BCrypt hash sẽ được generate bởi ứng dụng)
-- Để test, sử dụng password hash cho mật khẩu đơn giản hoặc để NULL để ứng dụng xử lý
PRINT '  - Tạo student test (username: student_test)'
INSERT INTO SYS_Users (
    Username,
    PasswordHash,
    Email,
    FullName,
    RoleID,
    Status,
    CreatedDate,
    LastLoginDate
) VALUES (
    'student_test',
    '$2a$11$abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ', -- Placeholder hash
    'student_test@lms.local',
    'Student Test Account',
    3, -- RoleID cho Student (cần kiểm tra thực tế trong SYS_Roles)
    1, -- Status: Active
    GETDATE(),
    NULL
)

-- Tạo admin test
PRINT '  - Tạo admin test (username: admin_test)'
INSERT INTO SYS_Users (
    Username,
    PasswordHash,
    Email,
    FullName,
    RoleID,
    Status,
    CreatedDate,
    LastLoginDate
) VALUES (
    'admin_test',
    '$2a$11$abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ', -- Placeholder hash
    'admin_test@lms.local',
    'Admin Test Account',
    1, -- RoleID cho Admin
    1, -- Status: Active
    GETDATE(),
    NULL
)

PRINT '  ✅ Đã tạo 2 user test: student_test, admin_test'

-- ============================================
-- 2. KIỂM TRA VÀ TẠO DATA CHO CÁC BẢNG CÓ PROCEDURE
-- ============================================

PRINT ''
PRINT '2. Kiểm tra các bảng có trong database...'

-- Lấy danh sách bảng từ database
DECLARE @table_count INT
SELECT @table_count = COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'
PRINT '  - Số bảng trong database: ' + CAST(@table_count AS VARCHAR)

-- Hiển thị danh sách bảng LMS_
PRINT '  - Các bảng LMS_:'
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME LIKE 'LMS_%'
ORDER BY TABLE_NAME

-- Hiển thị danh sách bảng SYS_
PRINT '  - Các bảng SYS_:'
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME LIKE 'SYS_%'
ORDER BY TABLE_NAME

-- Hiển thị danh sách bảng SIM_
PRINT '  - Các bảng SIM_:'
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME LIKE 'SIM_%'
ORDER BY TABLE_NAME

-- ============================================
-- 3. TẠO DATA CHO CÁC BẢNG LMS_ CÓ PROCEDURE
-- ============================================

PRINT ''
PRINT '3. Tạo dữ liệu cho các bảng LMS_...'

-- Tạo course test nếu bảng LMS_Courses tồn tại
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LMS_Courses')
BEGIN
    PRINT '  - Tạo course test...'

    -- Xóa course test nếu đã tồn tại
    IF EXISTS (SELECT 1 FROM LMS_Courses WHERE CourseCode = 'TEST001')
    BEGIN
        DELETE FROM LMS_Courses WHERE CourseCode = 'TEST001'
    END

    INSERT INTO LMS_Courses (
        CourseCode,
        CourseName,
        Description,
        Status,
        CreatedDate,
        CreatedBy
    ) VALUES (
        'TEST001',
        'Test Course for Runtime Testing',
        'Course này được tạo tự động cho mục đích test runtime',
        1, -- Active
        GETDATE(),
        'admin_test'
    )

    PRINT '  ✅ Đã tạo course test: TEST001'
END
ELSE
BEGIN
    PRINT '  ⚠️ Bảng LMS_Courses không tồn tại'
END

-- ============================================
-- 4. KIỂM TRA ROLES
-- ============================================

PRINT ''
PRINT '4. Kiểm tra roles trong hệ thống...'

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_Roles')
BEGIN
    SELECT RoleID, RoleName, Status FROM SYS_Roles
    PRINT '  ✅ Đã hiển thị danh sách roles'
END
ELSE
BEGIN
    PRINT '  ⚠️ Bảng SYS_Roles không tồn tại'
END

-- ============================================
-- 5. TẠO SAMPLE ENROLLMENT
-- ============================================

PRINT ''
PRINT '5. Tạo enrollment test...'

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'LMS_Enrollments')
BEGIN
    -- Xóa enrollment test nếu đã tồn tại
    IF EXISTS (SELECT 1 FROM LMS_Enrollments WHERE StudentID = 'student_test' AND CourseCode = 'TEST001')
    BEGIN
        DELETE FROM LMS_Enrollments WHERE StudentID = 'student_test' AND CourseCode = 'TEST001'
    END

    -- Tạo enrollment mới
    INSERT INTO LMS_Enrollments (
        StudentID,
        CourseCode,
        EnrollmentDate,
        Status,
        Progress
    ) VALUES (
        'student_test',
        'TEST001',
        GETDATE(),
        1, -- Active
        0 -- 0% progress
    )

    PRINT '  ✅ Đã tạo enrollment test cho student_test vào course TEST001'
END
ELSE
BEGIN
    PRINT '  ⚠️ Bảng LMS_Enrollments không tồn tại'
END

-- ============================================
-- 6. TẠO NOTIFICATION TEST
-- ============================================

PRINT ''
PRINT '6. Tạo notification test...'

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SYS_Notifications')
BEGIN
    INSERT INTO SYS_Notifications (
        UserID,
        Title,
        Message,
        Type,
        IsRead,
        CreatedDate
    ) VALUES (
        'student_test',
        'Test Notification',
        'Đây là notification test cho runtime testing',
        'INFO',
        0, -- Unread
        GETDATE()
    )

    PRINT '  ✅ Đã tạo notification test'
END
ELSE
BEGIN
    PRINT '  ⚠️ Bảng SYS_Notifications không tồn tại'
END

-- ============================================
-- 7. KẾT QUẢ
-- ============================================

PRINT ''
PRINT '================================='
PRINT '✅ HOÀN THÀNH TẠO DỮ LIỆU TEST'
PRINT '================================='
PRINT ''
PRINT 'Tài khoản test đã tạo:'
PRINT '  - Student: student_test / 123456'
PRINT '  - Admin: admin_test / 123456'
PRINT ''
PRINT 'LƯU Ý QUAN TRỌNG:'
PRINT '  1. Password hash hiện tại là placeholder'
PRINT '  2. Cần update password hash đúng bằng BCrypt hoặc reset password trong ứng dụng'
PRINT '  3. RoleID có thể cần điều chỉnh tùy theo dữ liệu thực tế trong SYS_Roles'
PRINT '  4. Nếu bảng không tồn tại, script sẽ skip và thông báo'
PRINT ''
PRINT 'Chạy script này trên SQL Server trước khi test runtime.'
PRINT '================================='
GO
