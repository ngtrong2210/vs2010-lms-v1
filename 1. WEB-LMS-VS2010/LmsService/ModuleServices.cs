using System;
using System.Collections.Generic;
using System.Data;
using LmsObject;
using LmsService.Core;

namespace LmsService
{
    public sealed class AcademicService : ModuleService
    {
        public AcademicService() : base(Map(
            "GetCatalog", "dbo.LMS_Academic_GetCatalog",
            "Save", "dbo.LMS_Academic_Save",
            "AssignStudents", "dbo.LMS_Academic_Student_AssignClass",
            "EnsureWorkspace", "dbo.LMS_ClassSubject_Workspace_Ensure")) { }
    }

    // CourseService base class - partial với LmsService.Course.CourseService
    public sealed class CourseService : ModuleService
    {
        public CourseService() : base(Map(
            "List", "dbo.LMS_Course_GetList",
            "Get", "dbo.LMS_Course_GetById",
            "Content", "dbo.LMS_Course_GetContent",
            "Create", "dbo.LMS_Course_Create",
            "Update", "dbo.LMS_Course_Update",
            "ChangeStatus", "dbo.LMS_Course_ChangeStatus",
            "Delete", "dbo.LMS_Course_Delete")) { }
    }

    public sealed class ContentService : ModuleService
    {
        public ContentService() : base(Map(
            "ChapterList", "dbo.LMS_Chapter_GetByCourse",
            "ChapterCreate", "dbo.LMS_Chapter_Create",
            "ChapterUpdate", "dbo.LMS_Chapter_Update",
            "ChapterDelete", "dbo.LMS_Chapter_Delete",
            "ChapterReorder", "dbo.LMS_Chapter_Reorder",
            "LessonGet", "dbo.LMS_Lesson_GetById",
            "LessonCreate", "dbo.LMS_Lesson_Create",
            "LessonUpdate", "dbo.LMS_Lesson_Update",
            "LessonDelete", "dbo.LMS_Lesson_Delete",
            "LessonReorder", "dbo.LMS_Lesson_Reorder",
            "VideoGet", "dbo.LMS_Video_GetById",
            "VideoCreate", "dbo.LMS_Video_Create",
            "VideoUpdate", "dbo.LMS_Video_Update",
            "VideoAttach", "dbo.LMS_Video_AttachToLesson",
            "VideoLibraryList", "dbo.LMS_VideoLibrary_GetList",
            "VideoLibraryUsage", "dbo.LMS_VideoVersion_GetUsageByVideoAsset",
            "VideoLibraryCreate", "dbo.LMS_VideoLibrary_Create",
            "VideoLibraryUpdate", "dbo.LMS_VideoLibrary_Update",
            "VideoLibraryDuplicate", "dbo.LMS_VideoLibrary_Duplicate",
            "VideoLibraryDelete", "dbo.LMS_VideoLibrary_Delete",
            "VideoSharingGet", "dbo.LMS_VideoLibrary_Sharing_Get",
            "VideoSharingSave", "dbo.LMS_VideoLibrary_Sharing_Save",
            "VideoLibraryAttach", "dbo.LMS_VideoLibrary_Attach",
            "InteractionList", "dbo.LMS_VideoInteraction_GetByVideo",
            "InteractionPreview", "dbo.LMS_VideoInteraction_PreviewAnswer",
            "InteractionCreate", "dbo.LMS_VideoInteraction_Create",
            "InteractionUpdate", "dbo.LMS_VideoInteraction_Update",
            "InteractionDelete", "dbo.LMS_VideoInteraction_Delete",
            "InteractionReorder", "dbo.LMS_VideoInteraction_Reorder",
            "InteractiveTeacher", "dbo.LMS_InteractiveContent_GetForTeacher",
            "InteractiveSettings", "dbo.LMS_InteractiveContent_SaveSettings",
            "ContentInteractionCreate", "dbo.LMS_ContentInteraction_Create",
            "ContentInteractionUpdate", "dbo.LMS_ContentInteraction_Update",
            "ContentInteractionDelete", "dbo.LMS_ContentInteraction_Delete",
            "ContentInteractionReorder", "dbo.LMS_ContentInteraction_Reorder")) { }
    }

    public sealed class LearningService : ModuleService
    {
        public LearningService() : base(Map(
            "Dashboard", "dbo.LMS_Student_GetDashboardStats",
            "CourseList", "dbo.LMS_StudentCourse_GetList",
            "CourseDetail", "dbo.LMS_StudentCourse_GetDetail",
            "Results", "dbo.LMS_StudentResults_Get",
            "Player", "dbo.LMS_LessonPlayer_GetData",
            "VideoProgress", "dbo.LMS_StudentVideoProgress_Save",
            "Answer", "dbo.LMS_StudentAnswer_Submit",
            // Interactive content operations đã chuyển sang InteractiveContentService
            "InteractiveStudent", "dbo.LMS_InteractiveContent_GetForStudent",
            "InteractiveAnswer", "dbo.LMS_InteractiveContent_SubmitAnswer",
            "ReadingProgress", "dbo.LMS_InteractiveContent_SaveReadingProgress",
            "InteractiveComplete", "dbo.LMS_InteractiveContent_Complete",
            "StudyStart", "dbo.LMS_StudySession_Start",
            "StudyHeartbeat", "dbo.LMS_StudySession_Heartbeat",
            "StudyEnd", "dbo.LMS_StudySession_End",
            "SubmissionValidate", "dbo.LMS_AssignmentSubmission_Validate",
            "SubmissionList", "dbo.LMS_AssignmentSubmission_GetByLesson",
            "SubmissionSave", "dbo.LMS_AssignmentSubmission_Save")) { }
    }

    public sealed class LessonCommentService : ModuleService
    {
        public LessonCommentService() : base(Map(
            "List", "dbo.LMS_LessonComment_GetByLesson",
            "Create", "dbo.LMS_LessonComment_Insert",
            "Update", "dbo.LMS_LessonComment_Update",
            "Delete", "dbo.LMS_LessonComment_Delete")) { }
    }

    public sealed class QuestionService : ModuleService
    {
        public QuestionService() : base(Map(
            "List", "dbo.LMS_Question_GetList",
            "Get", "dbo.LMS_Question_GetById",
            "Create", "dbo.LMS_Question_Create",
            "Update", "dbo.LMS_Question_Update",
            "Delete", "dbo.LMS_Question_Delete",
            "DeleteAnswers", "dbo.LMS_QuestionAnswers_DeleteByQuestion",
            "OptionCreate", "dbo.LMS_QuestionOption_Create",
            "AnswerKeyCreate", "dbo.LMS_QuestionAnswerKey_Create",
            "BlankCreate", "dbo.LMS_QuestionBlank_Create")) { }

        public long CreateQuestion(string questionType, string questionText, string description, string explanation, string difficulty, decimal defaultScore, string shortAnswerMode, string status, IList<string> optionCodes, IList<string> optionTexts, IList<bool> optionCorrect, IList<string> answerKeys, IList<string> blankCodes, IList<string> blankAnswers, long actorId)
        {
            questionText = InputGuard.RequiredText(questionText, 10000, "nội dung câu hỏi");
            if (optionCodes == null || optionTexts == null || optionCorrect == null || optionCodes.Count != optionTexts.Count || optionCodes.Count != optionCorrect.Count) throw new ArgumentException("Danh sách phương án không hợp lệ.");
            if (blankCodes == null || blankAnswers == null || blankCodes.Count != blankAnswers.Count) throw new ArgumentException("Danh sách ô trống không hợp lệ.");
            if (string.Equals(questionType, "SHORT_ANSWER", StringComparison.OrdinalIgnoreCase) && (answerKeys == null || answerKeys.Count == 0) && !string.Equals(shortAnswerMode, "MANUAL_REVIEW", StringComparison.OrdinalIgnoreCase)) throw new ArgumentException("Câu trả lời ngắn cần ít nhất một đáp án mẫu.");
            if (!string.Equals(questionType, "SHORT_ANSWER", StringComparison.OrdinalIgnoreCase) && optionCodes.Count < 2) throw new ArgumentException("Câu hỏi cần ít nhất hai phương án.");
            HashSet<string> uniqueCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase); int correctCount = 0;
            for (int i = 0; i < optionCodes.Count; i++) { optionCodes[i] = InputGuard.RequiredText(optionCodes[i], 100, "mã phương án"); optionTexts[i] = InputGuard.RequiredText(optionTexts[i], 2000, "nội dung phương án"); if (!uniqueCodes.Add(optionCodes[i])) throw new ArgumentException("Mã phương án không được trùng nhau."); if (optionCorrect[i]) correctCount++; }
            if (!string.Equals(questionType, "SHORT_ANSWER", StringComparison.OrdinalIgnoreCase) && !string.Equals(questionType, "CLOZE_DRAG_DROP", StringComparison.OrdinalIgnoreCase) && correctCount == 0) throw new ArgumentException("Câu hỏi cần ít nhất một đáp án đúng.");
            if ((string.Equals(questionType, "SINGLE_CHOICE", StringComparison.OrdinalIgnoreCase) || string.Equals(questionType, "TRUE_FALSE", StringComparison.OrdinalIgnoreCase)) && correctCount != 1) throw new ArgumentException("Loại câu hỏi này phải có đúng một đáp án đúng.");
            if (string.Equals(questionType, "CLOZE_DRAG_DROP", StringComparison.OrdinalIgnoreCase) && blankCodes.Count == 0) throw new ArgumentException("Câu kéo thả cần ít nhất một ô trống.");

            SYS_Users data = new SYS_Users();
            bool active = data.BeginTransaction();
            if (!active) throw new InvalidOperationException("Không thể bắt đầu transaction lưu câu hỏi.");
            try
            {
                DataTable result = data.GetDataTable(Procedure("Create"), "@Id", DBNull.Value, "@QuestionType", questionType, "@QuestionText", questionText, "@Description", description, "@Explanation", explanation, "@Difficulty", difficulty, "@DefaultScore", defaultScore, "@ShortAnswerMode", shortAnswerMode, "@Status", status, "@ActorId", actorId);
                if (result == null || result.Rows.Count == 0) { active = false; throw new InvalidOperationException("Stored procedure không trả về ID câu hỏi."); }
                long questionId = Convert.ToInt64(result.Rows[0][0]);
                if (!data.ExecNonQuery(Procedure("DeleteAnswers"), "@QuestionId", questionId)) { active = false; throw new InvalidOperationException("Không thể khởi tạo đáp án câu hỏi."); }
                for (int i = 0; i < optionCodes.Count; i++) if (!data.ExecNonQuery(Procedure("OptionCreate"), "@QuestionId", questionId, "@OptionCode", optionCodes[i], "@OptionText", optionTexts[i], "@IsCorrect", optionCorrect[i], "@SortOrder", i + 1)) { active = false; throw new InvalidOperationException("Không thể lưu phương án câu hỏi."); }
                if (answerKeys != null) for (int i = 0; i < answerKeys.Count; i++) if (!data.ExecNonQuery(Procedure("AnswerKeyCreate"), "@QuestionId", questionId, "@AnswerText", answerKeys[i], "@IsCaseSensitive", false, "@SortOrder", i + 1)) { active = false; throw new InvalidOperationException("Không thể lưu đáp án mẫu."); }
                for (int i = 0; i < blankCodes.Count; i++) if (!data.ExecNonQuery(Procedure("BlankCreate"), "@QuestionId", questionId, "@BlankCode", blankCodes[i], "@CorrectOptionCode", blankAnswers[i], "@SortOrder", i + 1)) { active = false; throw new InvalidOperationException("Không thể lưu ô trống."); }
                data.CommitTransaction(); active = false; return questionId;
            }
            catch
            {
                if (active) data.RollBackTransaction();
                throw;
            }
        }

        public void UpdateQuestion(long questionId, string questionType, string questionText, string description, string explanation, string difficulty, decimal defaultScore, string shortAnswerMode, string status, IList<string> optionCodes, IList<string> optionTexts, IList<bool> optionCorrect, IList<string> answerKeys, IList<string> blankCodes, IList<string> blankAnswers, long actorId, bool isAdmin)
        {
            if (questionId <= 0) throw new ArgumentException("Câu hỏi không hợp lệ.");
            questionText = InputGuard.RequiredText(questionText, 10000, "nội dung câu hỏi");
            if (optionCodes == null || optionTexts == null || optionCorrect == null || optionCodes.Count != optionTexts.Count || optionCodes.Count != optionCorrect.Count) throw new ArgumentException("Danh sách phương án không hợp lệ.");
            if (blankCodes == null || blankAnswers == null || blankCodes.Count != blankAnswers.Count) throw new ArgumentException("Danh sách ô trống không hợp lệ.");
            if (string.Equals(questionType, "SHORT_ANSWER", StringComparison.OrdinalIgnoreCase) && (answerKeys == null || answerKeys.Count == 0) && !string.Equals(shortAnswerMode, "MANUAL_REVIEW", StringComparison.OrdinalIgnoreCase)) throw new ArgumentException("Câu trả lời ngắn cần ít nhất một đáp án mẫu.");
            if (!string.Equals(questionType, "SHORT_ANSWER", StringComparison.OrdinalIgnoreCase) && optionCodes.Count < 2) throw new ArgumentException("Câu hỏi cần ít nhất hai phương án.");
            HashSet<string> uniqueCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase); int correctCount = 0;
            for (int i = 0; i < optionCodes.Count; i++) { optionCodes[i] = InputGuard.RequiredText(optionCodes[i], 100, "mã phương án"); optionTexts[i] = InputGuard.RequiredText(optionTexts[i], 2000, "nội dung phương án"); if (!uniqueCodes.Add(optionCodes[i])) throw new ArgumentException("Mã phương án không được trùng nhau."); if (optionCorrect[i]) correctCount++; }
            if (!string.Equals(questionType, "SHORT_ANSWER", StringComparison.OrdinalIgnoreCase) && !string.Equals(questionType, "CLOZE_DRAG_DROP", StringComparison.OrdinalIgnoreCase) && correctCount == 0) throw new ArgumentException("Câu hỏi cần ít nhất một đáp án đúng.");
            if ((string.Equals(questionType, "SINGLE_CHOICE", StringComparison.OrdinalIgnoreCase) || string.Equals(questionType, "TRUE_FALSE", StringComparison.OrdinalIgnoreCase)) && correctCount != 1) throw new ArgumentException("Loại câu hỏi này phải có đúng một đáp án đúng.");
            if (string.Equals(questionType, "CLOZE_DRAG_DROP", StringComparison.OrdinalIgnoreCase) && blankCodes.Count == 0) throw new ArgumentException("Câu kéo thả cần ít nhất một ô trống.");

            SYS_Users data = new SYS_Users(); bool active = data.BeginTransaction();
            if (!active) throw new InvalidOperationException("Không thể bắt đầu transaction lưu câu hỏi.");
            try
            {
                DataTable result = data.GetDataTable(Procedure("Update"), "@Id", questionId, "@QuestionType", questionType, "@QuestionText", questionText, "@Description", description, "@Explanation", explanation, "@Difficulty", difficulty, "@DefaultScore", defaultScore, "@ShortAnswerMode", shortAnswerMode, "@Status", status, "@ActorId", actorId, "@IsAdmin", isAdmin);
                if (result == null || result.Rows.Count == 0) { active = false; throw new InvalidOperationException("Không thể cập nhật câu hỏi."); }
                if (!data.ExecNonQuery(Procedure("DeleteAnswers"), "@QuestionId", questionId)) { active = false; throw new InvalidOperationException("Không thể làm mới đáp án câu hỏi."); }
                for (int i = 0; i < optionCodes.Count; i++) if (!data.ExecNonQuery(Procedure("OptionCreate"), "@QuestionId", questionId, "@OptionCode", optionCodes[i], "@OptionText", optionTexts[i], "@IsCorrect", optionCorrect[i], "@SortOrder", i + 1)) { active = false; throw new InvalidOperationException("Không thể lưu phương án câu hỏi."); }
                if (answerKeys != null) for (int i = 0; i < answerKeys.Count; i++) if (!data.ExecNonQuery(Procedure("AnswerKeyCreate"), "@QuestionId", questionId, "@AnswerText", answerKeys[i], "@IsCaseSensitive", false, "@SortOrder", i + 1)) { active = false; throw new InvalidOperationException("Không thể lưu đáp án mẫu."); }
                for (int i = 0; i < blankCodes.Count; i++) if (!data.ExecNonQuery(Procedure("BlankCreate"), "@QuestionId", questionId, "@BlankCode", blankCodes[i], "@CorrectOptionCode", blankAnswers[i], "@SortOrder", i + 1)) { active = false; throw new InvalidOperationException("Không thể lưu ô trống."); }
                data.CommitTransaction(); active = false;
            }
            catch
            {
                if (active) data.RollBackTransaction();
                throw;
            }
        }
    }

    public sealed class QuizService : ModuleService
    {
        public QuizService() : base(Map(
            "TeacherGet", "dbo.LMS_Quiz_GetForTeacher",
            "Save", "dbo.LMS_Quiz_Save",
            "StudentGet", "dbo.LMS_Quiz_GetForStudent",
            "AttemptStart", "dbo.LMS_QuizAttempt_Start",
            "AttemptSubmit", "dbo.LMS_QuizAttempt_Submit")) { }
    }

    public sealed class ReportService : ModuleService
    {
        public ReportService() : base(Map(
            "Dashboard", "dbo.LMS_Report_Dashboard",
            "CourseOverview", "dbo.LMS_Report_CourseOverview",
            "StudentProgress", "dbo.LMS_Report_StudentProgress",
            "VideoEngagement", "dbo.LMS_Report_VideoEngagement",
            "QuestionPerformance", "dbo.LMS_Report_QuestionPerformance",
            "LessonCompletion", "dbo.LMS_Report_LessonCompletion")) { }
    }

    public sealed class SearchService : ModuleService
    {
        public SearchService() : base(Map("Search", "dbo.LMS_GlobalSearch")) { }
    }

    public sealed class StudentService : ModuleService
    {
        public StudentService() : base(Map(
            "List", "dbo.LMS_Student_GetList",
            "Get", "dbo.LMS_Student_GetById",
            "EnrollmentList", "dbo.LMS_Enrollment_GetList",
            "Enroll", "dbo.LMS_Enrollment_Create",
            "CancelEnrollment", "dbo.LMS_Enrollment_Cancel")) { }
    }

    public sealed class SystemAdministrationService : ModuleService
    {
        public SystemAdministrationService() : base(Map(
            "UserList", "dbo.SYS_User_GetList",
            "UserGet", "dbo.SYS_User_GetByID",
            "UserCreate", "dbo.SYS_User_Create",
            "UserUpdate", "dbo.SYS_User_Update",
            "UserStatus", "dbo.SYS_User_SetStatus",
            "RoleList", "dbo.SYS_Role_GetList",
            "RolePermissions", "dbo.SYS_Role_GetPermissions",
            "RolePermissionsSave", "dbo.SYS_Role_SavePermissions",
            "Settings", "dbo.SYS_SystemSetting_GetList",
            "SettingsSave", "dbo.SYS_SystemSetting_Update")) { }

        public static string HashPassword(string password)
        {
            password = InputGuard.RequiredText(password, 100, "mật khẩu");
            if (password.Length < 6) throw new System.ArgumentException("Mật khẩu phải có ít nhất 6 ký tự.");
            return BCrypt.Net.BCrypt.HashPassword(password, 11);
        }

        public bool SaveSettings(IDictionary<string, string> settings, long actorUserId)
        {
            if (settings == null || settings.Count == 0) throw new ArgumentException("Cần ít nhất một cấu hình để lưu.");
            SYS_SystemSettings executor = new SYS_SystemSettings();
            if (!executor.BeginTransaction()) return false;
            try
            {
                foreach (KeyValuePair<string, string> setting in settings)
                {
                    if (!executor.ExecNonQuery(Procedure("SettingsSave"), "@SettingKey", setting.Key, "@SettingValue", setting.Value, "@ActorUserID", actorUserId)) return false;
                }
                executor.CommitTransaction();
                return true;
            }
            catch
            {
                try { executor.RollBackTransaction(); } catch { }
                return false;
            }
        }
    }

    public sealed class TeacherService : ModuleService
    {
        public TeacherService() : base(Map(
            "Dashboard", "dbo.LMS_Teacher_GetDashboardStats",
            "CourseAnalytics", "dbo.LMS_Teacher_GetCourseAnalytics")) { }
    }

    public sealed class TeachingService : ModuleService
    {
        public TeachingService() : base(Map(
            "SubmissionList", "dbo.LMS_AssignmentSubmission_GetForTeacher",
            "Grade", "dbo.LMS_AssignmentSubmission_Grade")) { }
    }
}
