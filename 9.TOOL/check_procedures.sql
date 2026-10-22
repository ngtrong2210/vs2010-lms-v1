-- Script to check which stored procedures exist in the database
-- Run this in SQL Server Management Studio

SELECT
    name AS ProcedureName,
    type_desc AS ObjectType,
    create_date,
    modify_date
FROM sys.objects
WHERE type IN ('P', 'PC', 'X')
    AND (
        name LIKE 'LMS_%'
        OR name LIKE 'sp_%'
    )
ORDER BY name;

-- Check specifically for LMS procedures
SELECT
    'LMS_Auth_GetUserByUsername' AS ProcedureName,
    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Auth_GetUserByUsername') THEN 'EXISTS' ELSE 'MISSING' END AS Status
UNION ALL
SELECT 'LMS_Notification_GetList', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_GetList') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Notification_GetUnreadCount', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_GetUnreadCount') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Notification_Create', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_Create') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Notification_MarkAsRead', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_MarkAsRead') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Notification_MarkAllAsRead', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_MarkAllAsRead') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Notification_Delete', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_Delete') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Notification_DeleteExpired', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Notification_DeleteExpired') THEN 'EXISTS' ELSE 'MISSING' END;

-- Check for SP lookup procedures
SELECT
    'sp_Faculty_GetAll' AS ProcedureName,
    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_Faculty_GetAll') THEN 'EXISTS' ELSE 'MISSING' END AS Status
UNION ALL
SELECT 'sp_Department_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_Department_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_ClassStatus_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_ClassStatus_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_Subject_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_Subject_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_Ethnicity_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_Ethnicity_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_Religion_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_Religion_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_Province_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_Province_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_District_GetByProvince', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_District_GetByProvince') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_ClassType_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_ClassType_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_GradeLevel_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_GradeLevel_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_UserRole_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_UserRole_GetAll') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'sp_UserStatus_GetAll', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'sp_UserStatus_GetAll') THEN 'EXISTS' ELSE 'MISSING' END;

-- Check for LMS_Enrollments procedures
SELECT
    'LMS_Enrollments_SEARCH' AS ProcedureName,
    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_SEARCH') THEN 'EXISTS' ELSE 'MISSING' END AS Status
UNION ALL
SELECT 'LMS_Enrollments_GetByCourse', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_GetByCourse') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Enrollments_GetByStudent', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_GetByStudent') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Enrollments_UpdateStatus', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_UpdateStatus') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Enrollments_UpdateProgress', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_UpdateProgress') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Enrollments_UpdateLastAccess', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_UpdateLastAccess') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Enrollments_CheckEnrollment', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_CheckEnrollment') THEN 'EXISTS' ELSE 'MISSING' END
UNION ALL
SELECT 'LMS_Enrollments_SEARCHCBX', CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'LMS_Enrollments_SEARCHCBX') THEN 'EXISTS' ELSE 'MISSING' END;

-- Check for SIM_Courses procedures
SELECT
    'SIM_Courses_SEARCHCBX' AS ProcedureName,
    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'SIM_Courses_SEARCHCBX') THEN 'EXISTS' ELSE 'MISSING' END AS Status;

-- Check for SIM_CourseCategories procedures
SELECT
    'SIM_CourseCategories_SEARCHCBX' AS ProcedureName,
    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'SIM_CourseCategories_SEARCHCBX') THEN 'EXISTS' ELSE 'MISSING' END AS Status;

-- Check for SIM_Chapters procedures
SELECT
    'SIM_Chapters_SEARCHCBX' AS ProcedureName,
    CASE WHEN EXISTS (SELECT 1 FROM sys.objects WHERE name = 'SIM_Chapters_SEARCHCBX') THEN 'EXISTS' ELSE 'MISSING' END AS Status;
