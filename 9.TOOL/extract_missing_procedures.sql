-- Script để export full definition của các procedures còn thiếu
-- Chạy trên database LMSCMS_DB_SAMPLE

SET NOCOUNT ON;

-- Lấy danh sách procedures cần export
DECLARE @ProcedureName NVARCHAR(200)
DECLARE @SQL NVARCHAR(MAX)

-- Tạo cursor để loop qua từng procedure
DECLARE proc_cursor CURSOR FOR
SELECT name FROM sys.procedures
WHERE type = 'P'
AND name IN (
    'LMS_Certificate_Generate',
    'LMS_Certificate_GetByUser',
    'LMS_Content_GetByLesson',
    'LMS_Content_TrackProgress',
    'LMS_Course_GetDetails',
    'LMS_Discussion_Create',
    'LMS_Discussion_GetByCourse',
    'LMS_Discussion_GetDetails',
    'LMS_Discussion_Update',
    'LMS_Enrollment_GetByStudent',
    'LMS_Lesson_TrackProgress',
    'LMS_Notification_GetForUser',
    'LMS_Notification_MarkAllAsRead',
    'LMS_Notification_MarkAsRead',
    'LMS_Quiz_Create',
    'LMS_Quiz_Delete',
    'LMS_Quiz_GetByLesson',
    'LMS_Quiz_GetQuestions',
    'LMS_Quiz_Update',
    'LMS_QuizAttempt_Create',
    'LMS_QuizAttempt_GetDetails',
    'LMS_QuizQuestion_Create',
    'LMS_QuizQuestion_Delete',
    'LMS_QuizQuestion_Update',
    'LMS_Survey_SubmitResponse',
    'LMS_SurveyAnswer_Create',
    'LMS_Video_DetachFromLesson',
    'LMS_Video_GetByLesson',
    'SIM_Notification_GetList',
    'SIM_Notification_MarkAllRead',
    'SIM_Notification_MarkRead'
)
ORDER BY name

OPEN proc_cursor
FETCH NEXT FROM proc_cursor INTO @ProcedureName

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'GO'
    PRINT '-- ============================================='
    PRINT '-- Procedure: ' + @ProcedureName
    PRINT '-- ============================================='
    PRINT ''

    EXEC sp_helptext @ProcedureName

    PRINT ''
    FETCH NEXT FROM proc_cursor INTO @ProcedureName
END

CLOSE proc_cursor
DEALLOCATE proc_cursor
