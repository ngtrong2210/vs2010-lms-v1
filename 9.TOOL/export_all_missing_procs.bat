@echo off
setlocal

set SERVER=.\SQLEXPRESS
set DATABASE=LMSCMS_DB_SAMPLE
set OUTPUT_DIR=G:\0.DỰ ÁN\2.LMS-VS2010\WEB-LMS-VS2010\9.TOOL\procs

echo Exporting missing procedures from %DATABASE%...

sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Certificate_Generate'" -y 0 -o "%OUTPUT_DIR%\LMS_Certificate_Generate.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Certificate_GetByUser'" -y 0 -o "%OUTPUT_DIR%\LMS_Certificate_GetByUser.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Content_GetByLesson'" -y 0 -o "%OUTPUT_DIR%\LMS_Content_GetByLesson.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Content_TrackProgress'" -y 0 -o "%OUTPUT_DIR%\LMS_Content_TrackProgress.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Course_GetDetails'" -y 0 -o "%OUTPUT_DIR%\LMS_Course_GetDetails.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Discussion_Create'" -y 0 -o "%OUTPUT_DIR%\LMS_Discussion_Create.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Discussion_GetByCourse'" -y 0 -o "%OUTPUT_DIR%\LMS_Discussion_GetByCourse.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Discussion_GetDetails'" -y 0 -o "%OUTPUT_DIR%\LMS_Discussion_GetDetails.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Discussion_Update'" -y 0 -o "%OUTPUT_DIR%\LMS_Discussion_Update.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Enrollment_GetByStudent'" -y 0 -o "%OUTPUT_DIR%\LMS_Enrollment_GetByStudent.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Lesson_TrackProgress'" -y 0 -o "%OUTPUT_DIR%\LMS_Lesson_TrackProgress.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Notification_GetForUser'" -y 0 -o "%OUTPUT_DIR%\LMS_Notification_GetForUser.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Notification_MarkAllAsRead'" -y 0 -o "%OUTPUT_DIR%\LMS_Notification_MarkAllAsRead.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Notification_MarkAsRead'" -y 0 -o "%OUTPUT_DIR%\LMS_Notification_MarkAsRead.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Quiz_Create'" -y 0 -o "%OUTPUT_DIR%\LMS_Quiz_Create.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Quiz_Delete'" -y 0 -o "%OUTPUT_DIR%\LMS_Quiz_Delete.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Quiz_GetByLesson'" -y 0 -o "%OUTPUT_DIR%\LMS_Quiz_GetByLesson.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Quiz_GetQuestions'" -y 0 -o "%OUTPUT_DIR%\LMS_Quiz_GetQuestions.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Quiz_Update'" -y 0 -o "%OUTPUT_DIR%\LMS_Quiz_Update.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_QuizAttempt_Create'" -y 0 -o "%OUTPUT_DIR%\LMS_QuizAttempt_Create.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_QuizAttempt_GetDetails'" -y 0 -o "%OUTPUT_DIR%\LMS_QuizAttempt_GetDetails.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_QuizQuestion_Create'" -y 0 -o "%OUTPUT_DIR%\LMS_QuizQuestion_Create.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_QuizQuestion_Delete'" -y 0 -o "%OUTPUT_DIR%\LMS_QuizQuestion_Delete.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_QuizQuestion_Update'" -y 0 -o "%OUTPUT_DIR%\LMS_QuizQuestion_Update.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Survey_SubmitResponse'" -y 0 -o "%OUTPUT_DIR%\LMS_Survey_SubmitResponse.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_SurveyAnswer_Create'" -y 0 -o "%OUTPUT_DIR%\LMS_SurveyAnswer_Create.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Video_DetachFromLesson'" -y 0 -o "%OUTPUT_DIR%\LMS_Video_DetachFromLesson.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.LMS_Video_GetByLesson'" -y 0 -o "%OUTPUT_DIR%\LMS_Video_GetByLesson.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.SIM_Notification_GetList'" -y 0 -o "%OUTPUT_DIR%\SIM_Notification_GetList.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.SIM_Notification_MarkAllRead'" -y 0 -o "%OUTPUT_DIR%\SIM_Notification_MarkAllRead.sql"
sqlcmd -S %SERVER% -d %DATABASE% -Q "EXEC sp_helptext 'dbo.SIM_Notification_MarkRead'" -y 0 -o "%OUTPUT_DIR%\SIM_Notification_MarkRead.sql"

echo Done exporting all procedures!
pause
