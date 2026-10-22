using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Lms
{
    public partial class LessonPlayer : StudentControl
    {
        protected GridView AnsweredGrid;

        protected string LessonPageCss = string.Empty;
        protected string LessonTypeCss = "lesson-type-slate";
        protected string LessonTypeIconCss = "bi-journal-bookmark-fill";
        protected string LessonTypeLabel = "Bài học";
        protected string StudyTimeText = "00:00";
        protected string CurrentScoreText = "0";
        protected string CurriculumHtml = string.Empty;
        protected string LessonNavigationHtml = "<span></span><span></span>";
        protected int CourseProgressPercent;
        protected int CompletedLessons;
        protected int LessonCount;
        protected int DiscussionCount;

        private static readonly JavaScriptSerializer Json = new JavaScriptSerializer();
        private static readonly Regex BlankPattern = new Regex(
            @"\[\[([A-Za-z0-9_]+)\]\]",
            RegexOptions.Compiled
        );
        private static readonly HashSet<string> AssignmentExtensions = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase
        )
        {
            ".pdf",
            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".ppt",
            ".pptx",
            ".zip",
            ".txt",
            ".png",
            ".jpg",
            ".jpeg",
        };

        protected long LessonId
        {
            get { return RouteLong("lessonId"); }
        }
        protected long CourseId
        {
            get { return RouteLong("courseId"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet player = ServiceRegistry.Learning.GetDataSet(
                    "Player",
                    Values("LessonId", LessonId, "StudentId", CurrentUser.UserID)
                );
                DataTable lesson = Table(player, 0),
                    course = Table(player, 1),
                    video = Table(player, 2),
                    progress = Table(player, 3),
                    interactions = Table(player, 4),
                    answered = Table(player, 5);
                if (lesson == null || lesson.Rows.Count == 0)
                {
                    EmptyText.Visible = true;
                    HidePlayers();
                    return;
                }

                DataRow lessonRow = lesson.Rows[0];
                string lessonType = WebData.Text(lessonRow, "LessonType").ToUpperInvariant();
                string action = Request.Form["lessonAction"] ?? string.Empty;
                if (IsPostBack && !string.IsNullOrWhiteSpace(action))
                    ProcessAction(action, lessonType, lessonRow, First(video), interactions);

                BindHeader(
                    lessonRow,
                    First(course),
                    First(video),
                    First(progress),
                    interactions,
                    answered,
                    lessonType
                );
                BindCourseOutline();
                BindLessonType(lessonType, lessonRow, interactions, answered);
                BindComments();
                EmptyText.Visible = false;
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp hoặc xử lý bài học thất bại.", ex);
                ErrorText.Text = "Không thể thực hiện yêu cầu: " + ex.Message;
                ErrorText.Visible = true;
            }
        }

        private void ProcessAction(
            string action,
            string lessonType,
            DataRow lessonRow,
            DataRow videoRow,
            DataTable interactions
        )
        {
            if (
                action == "commentCreate"
                || action.StartsWith("commentDelete:", StringComparison.OrdinalIgnoreCase)
            )
                ProcessComment(action);
            else if (
                lessonType == "ASSIGNMENT"
                && (action == "assignmentDraft" || action == "assignmentSubmit")
            )
                SaveAssignment(action == "assignmentSubmit" ? "SUBMIT" : "DRAFT", lessonRow);
            else if (lessonType == "QUIZ" && (action == "quizStart" || action == "quizSubmit"))
                ProcessQuiz(action);
            else if (
                lessonType == "INTERACTIVE_CONTENT"
                && action.StartsWith("interactive", StringComparison.OrdinalIgnoreCase)
            )
                ProcessInteractive(action);
            else if (
                lessonType == "INTERACTIVE_VIDEO"
                && action.StartsWith("video:", StringComparison.OrdinalIgnoreCase)
            )
                ProcessVideoAnswer(action, videoRow, interactions);
        }

        private void ProcessComment(string action)
        {
            if (action == "commentCreate")
            {
                if (string.IsNullOrWhiteSpace(CommentText.Text))
                    throw new ArgumentException("Vui lòng nhập nội dung bình luận.");
                ServiceRegistry.Comments.GetDataTable(
                    "Create",
                    Values(
                        "LessonID",
                        LessonId,
                        "ActorUserID",
                        CurrentUser.UserID,
                        "IsAdmin",
                        false,
                        "IsTeacher",
                        false,
                        "Content",
                        CommentText.Text.Trim(),
                        "ParentCommentID",
                        DBNull.Value
                    )
                );
                CommentText.Text = string.Empty;
                SuccessText.Text = "Đã gửi bình luận.";
                SuccessText.Visible = true;
                return;
            }
            long id;
            if (!long.TryParse(action.Substring(action.IndexOf(':') + 1), out id))
                throw new ArgumentException("Bình luận không hợp lệ.");
            ServiceRegistry.Comments.GetDataTable(
                "Delete",
                Values(
                    "LessonCommentID",
                    id,
                    "ActorUserID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    false,
                    "IsTeacher",
                    false
                )
            );
            SuccessText.Text = "Đã xóa bình luận.";
            SuccessText.Visible = true;
        }

        private void BindComments()
        {
            DataSet data = ServiceRegistry.Comments.GetDataSet(
                "List",
                Values(
                    "LessonID",
                    LessonId,
                    "ActorUserID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    false,
                    "IsTeacher",
                    false,
                    "Page",
                    1,
                    "PageSize",
                    50
                )
            );
            DataTable rows = Table(data, 1);
            DiscussionCount = rows == null ? 0 : rows.Rows.Count;
            if (rows == null || rows.Rows.Count == 0)
            {
                CommentsHtml.Text =
                    "<div class=\"discussion-empty\"><i class=\"bi bi-chat-square-text\"></i><strong>Chưa có thảo luận</strong><span>Hãy là người đầu tiên đặt câu hỏi cho bài học này.</span></div>";
                return;
            }
            StringBuilder html = new StringBuilder();
            foreach (DataRow row in rows.Rows)
            {
                int level = ToInt(row, "CommentLevel", 0);
                string role = WebData.Text(row, "UserRole").ToLowerInvariant();
                string name = WebData.Text(row, "UserFullName");
                html.Append("<article class=\"lesson-comment comment-depth-")
                    .Append(Math.Min(level, 2))
                    .Append("\"><span class=\"comment-avatar\">")
                    .Append(H(Initials(name)))
                    .Append("</span><div class=\"comment-body\"><header><div><strong>")
                    .Append(H(name))
                    .Append("</strong><span class=\"comment-role role-")
                    .Append(A(role))
                    .Append("\">")
                    .Append(H(WebData.Text(row, "UserRole")))
                    .Append("</span></div><time>")
                    .Append(H(WebData.Text(row, "CreatedDate")))
                    .Append("</time></header><p class=\"comment-content\">")
                    .Append(H(WebData.Text(row, "Content")))
                    .Append("</p><div class=\"comment-actions\">");
                if (Bool(row, "CanDelete"))
                    html.Append(
                            "<button type=\"submit\" name=\"lessonAction\" value=\"commentDelete:"
                        )
                        .Append(H(WebData.Text(row, "Id")))
                        .Append(
                            "\" class=\"danger\" data-confirm=\"Xóa bình luận này?\"><i class=\"bi bi-trash3\"></i> Xóa</button>"
                        );
                html.Append("</div></div></article>");
            }
            CommentsHtml.Text = html.ToString();
        }

        private void BindHeader(
            DataRow lesson,
            DataRow course,
            DataRow video,
            DataRow progress,
            DataTable interactions,
            DataTable answered,
            string lessonType
        )
        {
            CourseTitleText.Text = H(WebData.Text(course, "Title"));
            LessonTitleText.Text = H(WebData.Text(lesson, "Title"));
            LessonDescriptionText.Text = H(WebData.Text(lesson, "Description"));
            WatchPercentText.Text = H(WebData.Text(progress, "WatchPercent"));
            ContentHtmlText.Text = WebData.Text(lesson, "ContentHtml");
            CurrentScoreText = H(
                string.IsNullOrWhiteSpace(WebData.Text(progress, "Score"))
                    ? "0"
                    : WebData.Text(progress, "Score")
            );
            SetLessonTypePresentation(lessonType);
            int studySeconds = ToIntAny(
                course,
                0,
                "StudySeconds",
                "TotalStudySeconds",
                "StudyTimeSeconds"
            );
            StudyTimeText = FormatStudyTime(studySeconds);
            string documentUrl = WebData.Text(lesson, "DocumentUrl");
            if (string.IsNullOrWhiteSpace(documentUrl))
                ResourceHtml.Text =
                    "<div class=\"discussion-empty\"><i class=\"bi bi-folder2-open\"></i><strong>Chưa có tài nguyên đính kèm</strong></div>";
            else
            {
                string resolved = ResolveAsset(documentUrl),
                    name = Path.GetFileName(documentUrl.Split('?')[0]);
                ResourceHtml.Text =
                    "<div class=\"resource-list-item\"><span class=\"lesson-type-icon lesson-type-red\"><i class=\"bi bi-file-earmark-pdf-fill\"></i></span><div><strong>"
                    + H(name)
                    + "</strong><small>Tài liệu đính kèm của bài học</small></div><a href=\""
                    + A(resolved)
                    + "\" target=\"_blank\"><i class=\"bi bi-download\"></i> Tải xuống</a></div>";
            }
            VideoInteractionsJsonValue.Value = SerializeVideoInteractions(interactions, answered);
            VideoHostHtml.Text = BuildVideo(video, progress, lessonType == "INTERACTIVE_VIDEO");
        }

        private void BindLessonType(
            string type,
            DataRow lesson,
            DataTable interactions,
            DataTable answered
        )
        {
            bool isVideo = type == "VIDEO" || type == "INTERACTIVE_VIDEO";
            VideoPanel.Visible = isVideo;
            VideoInteractionPanel.Visible = type == "INTERACTIVE_VIDEO";
            ContentPanel.Visible =
                (type == "EDITOR" || type == "CONTENT" || type == "DOCUMENT")
                && !string.IsNullOrWhiteSpace(WebData.Text(lesson, "ContentHtml"));
            DocumentPanel.Visible = false;
            AssignmentPanel.Visible = false;
            QuizPanel.Visible = false;
            InteractivePanel.Visible = false;
            if (type == "DOCUMENT" || type == "EDITOR")
                BindDocument(lesson);
            if (type == "ASSIGNMENT")
                BindAssignment(lesson);
            if (type == "QUIZ")
                BindQuiz();
            if (type == "INTERACTIVE_CONTENT")
                BindInteractive();
            VideoQuestionsHtml.Text =
                type == "INTERACTIVE_VIDEO" ? BuildVideoQuestions(interactions) : string.Empty;
            if (AnsweredGrid != null)
            {
                AnsweredGrid.DataSource = answered;
                AnsweredGrid.DataBind();
            }
        }

        private void BindCourseOutline()
        {
            DataSet data = ServiceRegistry.Learning.GetDataSet(
                "CourseDetail",
                Values("CourseId", CourseId, "StudentId", CurrentUser.UserID)
            );
            DataRow detail = First(Table(data, 0));
            DataTable chapters = Table(data, 1),
                lessons = Table(data, 2);
            if (lessons == null)
                return;

            LessonCount = lessons.Rows.Count;
            CompletedLessons = lessons.Rows.Cast<DataRow>().Count(row => Bool(row, "Completed"));
            CourseProgressPercent = Percentage(
                detail,
                "ProgressPercent",
                LessonCount == 0 ? 0 : (CompletedLessons * 100m / LessonCount)
            );
            int outlineStudySeconds = ToIntAny(
                detail,
                0,
                "StudySeconds",
                "TotalStudySeconds",
                "StudyTimeSeconds"
            );
            if (outlineStudySeconds > 0)
                StudyTimeText = FormatStudyTime(outlineStudySeconds);

            List<DataRow> orderedLessons = lessons.Rows.Cast<DataRow>().ToList();
            StringBuilder html = new StringBuilder();
            if (chapters != null && chapters.Rows.Count > 0)
            {
                foreach (DataRow chapter in chapters.Rows)
                {
                    long chapterId = LongAny(chapter, "Id", "ChapterID", "CourseChapterID");
                    List<DataRow> chapterLessons = orderedLessons
                        .Where(row =>
                            LongAny(row, "ChapterId", "ChapterID", "CourseChapterID") == chapterId
                        )
                        .ToList();
                    AppendChapter(html, WebData.Text(chapter, "Title"), chapterLessons);
                }
            }
            else
                AppendChapter(html, "Nội dung môn học", orderedLessons);
            CurriculumHtml = html.ToString();

            int currentIndex = orderedLessons.FindIndex(row =>
                LongAny(row, "Id", "LessonID") == LessonId
            );
            DataRow previous = currentIndex > 0 ? orderedLessons[currentIndex - 1] : null;
            DataRow next =
                currentIndex >= 0 && currentIndex + 1 < orderedLessons.Count
                    ? orderedLessons[currentIndex + 1]
                    : null;
            LessonNavigationHtml = BuildLessonNavigation(previous, next);
        }

        private void AppendChapter(StringBuilder html, string title, IList<DataRow> lessons)
        {
            html.Append(
                    "<div class=\"chapter\"><button type=\"button\" class=\"chapter-toggle\" data-chapter-toggle><span><strong>"
                )
                .Append(H(string.IsNullOrWhiteSpace(title) ? "Chương học" : title))
                .Append("</strong><small>")
                .Append(lessons.Count)
                .Append(
                    " bài học</small></span><i class=\"bi bi-chevron-up\"></i></button><div class=\"chapter-lessons\">"
                );
            foreach (DataRow lesson in lessons)
            {
                long id = LongAny(lesson, "Id", "LessonID");
                string type = WebData.Text(lesson, "LessonType"),
                    tone,
                    icon,
                    label;
                LessonTypeMeta(type, out tone, out icon, out label);
                bool current = id == LessonId,
                    completed = Bool(lesson, "Completed");
                html.Append("<a href=\"")
                    .Append(A(ResolveUrl("~/lms/courses/" + CourseId + "/lessons/" + id)))
                    .Append("\"");
                if (current)
                    html.Append(" class=\"active\"");
                html.Append("><span class=\"lesson-type-icon lesson-type-")
                    .Append(A(tone))
                    .Append("\"><i class=\"bi ")
                    .Append(A(icon))
                    .Append("\"></i></span><span><strong>")
                    .Append(H(WebData.Text(lesson, "Title")))
                    .Append("</strong><small>")
                    .Append(H(label))
                    .Append(" · ")
                    .Append(H(FormatDuration(ToIntAny(lesson, 0, "Duration", "DurationSeconds"))))
                    .Append("</small></span>");
                if (completed)
                    html.Append(
                        "<i class=\"bi bi-check-circle-fill lesson-status-complete\" title=\"Đã hoàn thành\"></i>"
                    );
                else if (current)
                    html.Append(
                        "<i class=\"bi bi-play-circle-fill lesson-status-current\" title=\"Đang học\"></i>"
                    );
                html.Append("</a>");
            }
            html.Append("</div></div>");
        }

        private string BuildLessonNavigation(DataRow previous, DataRow next)
        {
            StringBuilder html = new StringBuilder();
            if (previous == null)
                html.Append("<span></span>");
            else
                html.Append("<a class=\"previous\" href=\"")
                    .Append(
                        A(
                            ResolveUrl(
                                "~/lms/courses/"
                                    + CourseId
                                    + "/lessons/"
                                    + LongAny(previous, "Id", "LessonID")
                            )
                        )
                    )
                    .Append(
                        "\"><i class=\"bi bi-arrow-left\"></i><span><small>Bài trước</small><strong>"
                    )
                    .Append(H(WebData.Text(previous, "Title")))
                    .Append("</strong></span></a>");
            if (next == null)
                html.Append("<span></span>");
            else
                html.Append("<a class=\"next\" href=\"")
                    .Append(
                        A(
                            ResolveUrl(
                                "~/lms/courses/"
                                    + CourseId
                                    + "/lessons/"
                                    + LongAny(next, "Id", "LessonID")
                            )
                        )
                    )
                    .Append("\"><span><small>Bài tiếp theo</small><strong>")
                    .Append(H(WebData.Text(next, "Title")))
                    .Append("</strong></span><i class=\"bi bi-arrow-right\"></i></a>");
            return html.ToString();
        }

        private void SetLessonTypePresentation(string type)
        {
            string tone,
                icon,
                label;
            LessonTypeMeta(type, out tone, out icon, out label);
            LessonTypeCss = "lesson-type-" + tone;
            LessonTypeIconCss = icon;
            LessonTypeLabel = label;
            LessonPageCss =
                type == "VIDEO" || type == "INTERACTIVE_VIDEO" ? "video-lesson" : string.Empty;
        }

        private static void LessonTypeMeta(
            string type,
            out string tone,
            out string icon,
            out string label
        )
        {
            switch ((type ?? string.Empty).ToUpperInvariant())
            {
                case "VIDEO":
                case "INTERACTIVE_VIDEO":
                    tone = "blue";
                    icon = "bi-play-fill";
                    label = type == "VIDEO" ? "Video" : "Video tương tác";
                    break;
                case "INTERACTIVE_CONTENT":
                    tone = "teal";
                    icon = "bi-journal-check";
                    label = "Bài học tương tác";
                    break;
                case "EDITOR":
                case "CONTENT":
                case "DOCUMENT":
                    tone = "cyan";
                    icon = "bi-file-text-fill";
                    label = type == "CONTENT" ? "Bài đọc" : "Bài học";
                    break;
                case "PDF":
                    tone = "red";
                    icon = "bi-file-earmark-pdf-fill";
                    label = "Tài liệu PDF";
                    break;
                case "ASSIGNMENT":
                    tone = "orange";
                    icon = "bi-clipboard-check-fill";
                    label = "Bài tập";
                    break;
                case "QUIZ":
                case "TEST":
                    tone = "purple";
                    icon = "bi-ui-checks";
                    label = "Bài kiểm tra";
                    break;
                case "PRACTICE":
                    tone = "green";
                    icon = "bi-tools";
                    label = "Thực hành";
                    break;
                case "FILE":
                    tone = "slate";
                    icon = "bi-file-earmark-arrow-down-fill";
                    label = "Tệp học tập";
                    break;
                case "LINK":
                    tone = "teal";
                    icon = "bi-box-arrow-up-right";
                    label = "Liên kết";
                    break;
                default:
                    tone = "slate";
                    icon = "bi-journal-bookmark-fill";
                    label = "Bài học";
                    break;
            }
        }

        private void ProcessVideoAnswer(string action, DataRow video, DataTable interactions)
        {
            long interactionId;
            if (!long.TryParse(action.Substring(action.IndexOf(':') + 1), out interactionId))
                throw new ArgumentException("Câu hỏi trong video không hợp lệ.");
            DataRow interaction = FindAny(
                interactions,
                interactionId.ToString(),
                "Id",
                "InteractionId",
                "VideoInteractionID"
            );
            if (interaction == null || video == null)
                throw new ArgumentException("Không tìm thấy câu hỏi trong video.");
            long questionId = LongAny(interaction, "QuestionId", "QuestionID");
            string answer = ReadAnswer(
                "v_" + questionId,
                WebData.Text(interaction, "QuestionType"),
                WebData.Text(interaction, "QuestionText")
            );
            DataTable result = ServiceRegistry.Learning.GetDataTable(
                "Answer",
                Values(
                    "StudentId",
                    CurrentUser.UserID,
                    "LessonId",
                    LessonId,
                    "VideoId",
                    LongAny(video, "Id", "VideoID"),
                    "InteractionId",
                    interactionId,
                    "QuestionId",
                    questionId,
                    "AnswerText",
                    answer,
                    "TimeInVideoSeconds",
                    ToIntAny(interaction, 0, "TimeSeconds"),
                    "TimeSpentSeconds",
                    0
                )
            );
            if (result == null || result.Rows.Count == 0)
                throw new InvalidOperationException(
                    "Stored procedure không trả về kết quả câu trả lời."
                );
            SuccessText.Text = "Đã lưu câu trả lời trong video.";
            SuccessText.Visible = true;
        }

        private string BuildVideoQuestions(DataTable interactions)
        {
            if (interactions == null || interactions.Rows.Count == 0)
                return "<p class=\"text-secondary mb-0\">Bài học này không có câu hỏi tương tác.</p>";
            StringBuilder html = new StringBuilder("<div class=\"interaction-list\">");
            foreach (DataRow row in interactions.Rows)
            {
                int seconds = ToIntAny(row, 0, "TimeSeconds");
                html.Append("<button type=\"button\" data-video-question-time=\"")
                    .Append(seconds)
                    .Append("\"><span>")
                    .Append(H(FormatInteractionTime(seconds)))
                    .Append("</span><i class=\"bi bi-patch-question\"></i><div><strong>")
                    .Append(H(WebData.Text(row, "QuestionText")))
                    .Append("</strong><small>")
                    .Append(H(QuestionTypeText(WebData.Text(row, "QuestionType"))))
                    .Append(" • ")
                    .Append(H(WebData.Text(row, "Score")))
                    .Append(" điểm</small></div></button>");
            }
            return html.Append("</div>").ToString();
        }

        private void BindDocument(DataRow lesson)
        {
            string url = WebData.Text(lesson, "DocumentUrl");
            if (string.IsNullOrWhiteSpace(url))
                return;
            DocumentPanel.Visible = true;
            string resolved = ResolveAsset(url),
                name = Path.GetFileName(url.Split('?')[0]);
            StringBuilder html = new StringBuilder();
            html.Append(
                    "<div class=\"document-heading\"><span class=\"content-type-icon\"><i class=\"bi bi-paperclip\"></i></span><div><h2>Tài liệu đính kèm</h2><p>Đọc trực tiếp trên hệ thống hoặc mở file toàn màn hình.</p></div><div class=\"document-actions\"><a class=\"btn btn-action-view\" target=\"_blank\" href=\""
                )
                .Append(A(resolved))
                .Append(
                    "\"><i class=\"bi bi-arrows-fullscreen\"></i> Mở toàn màn hình</a><a class=\"btn btn-action-save\" download href=\""
                )
                .Append(A(resolved))
                .Append(
                    "\"><i class=\"bi bi-download\"></i> Tải tài liệu</a></div></div><div class=\"document-viewer\">"
                );
            if (url.IndexOf(".pdf", StringComparison.OrdinalIgnoreCase) >= 0)
                html.Append("<iframe title=\"Tài liệu bài học\" src=\"")
                    .Append(A(resolved))
                    .Append("\"></iframe>");
            else
                html.Append(
                        "<div class=\"document-file-card\"><i class=\"bi bi-file-earmark-arrow-down\"></i><strong>"
                    )
                    .Append(H(name))
                    .Append(
                        "</strong><span>Định dạng này cần mở bằng ứng dụng phù hợp trên thiết bị.</span></div>"
                    );
            html.Append("</div>");
            DocumentHtml.Text = html.ToString();
        }

        private void BindAssignment(DataRow lesson)
        {
            AssignmentPanel.Visible = true;
            BindDocument(lesson);
            DocumentPanel.Visible = false;
            AssignmentTitleText.Text = H(WebData.Text(lesson, "Title"));
            string description = WebData.Text(lesson, "ContentHtml");
            AssignmentDescriptionHtml.Text = string.IsNullOrWhiteSpace(description)
                ? H(WebData.Text(lesson, "Description"))
                : description;
            string dueAt = DateText(lesson, "DueAt");
            AssignmentMetaHtml.Text =
                "<div class=\"assignment-metadata\"><span><i class=\"bi bi-calendar2-event-fill\"></i> Hạn: "
                + H(dueAt)
                + "</span><span><i class=\"bi bi-star-fill\"></i> "
                + H(WebData.Text(lesson, "AssignmentMaxScore"))
                + " điểm</span><span><i class=\"bi bi-arrow-repeat\"></i> "
                + H(WebData.Text(lesson, "MaxSubmissionAttempts"))
                + " lần nộp</span></div>";
            DataTable history = ServiceRegistry.Learning.GetDataTable(
                "SubmissionList",
                Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
            );
            if (!IsPostBack && history != null && history.Rows.Count > 0)
                AssignmentText.Text = WebData.Text(history.Rows[0], "SubmissionText");
            AssignmentHistoryHtml.Text = BuildAssignmentHistory(history);
        }

        private void SaveAssignment(string action, DataRow lesson)
        {
            DataTable validation = ServiceRegistry.Learning.GetDataTable(
                "SubmissionValidate",
                Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID, "Action", action)
            );
            int maxMb = ToInt(
                First(validation),
                "MaxSubmissionFileSizeMB",
                ToInt(lesson, "MaxSubmissionFileSizeMB", 50)
            );
            DataTable history = ServiceRegistry.Learning.GetDataTable(
                "SubmissionList",
                Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
            );
            DataRow existing = First(history);
            string fileUrl = null,
                originalName = null,
                storedName = null,
                mime = null,
                physical = null;
            long? fileSize = null;
            try
            {
                if (AssignmentFile.HasFile)
                {
                    string ext = Path.GetExtension(AssignmentFile.FileName);
                    if (!AssignmentExtensions.Contains(ext))
                        throw new ArgumentException("Định dạng file bài làm không được hỗ trợ.");
                    if (
                        AssignmentFile.PostedFile.ContentLength <= 0
                        || AssignmentFile.PostedFile.ContentLength > maxMb * 1024L * 1024L
                    )
                        throw new ArgumentException("File bài làm vượt quá " + maxMb + " MB.");
                    originalName = Path.GetFileName(AssignmentFile.FileName);
                    storedName = Guid.NewGuid().ToString("N") + ext.ToLowerInvariant();
                    string folder =
                        "~/Media/File/Assignments/" + LessonId + "/Students/" + CurrentUser.UserID;
                    Directory.CreateDirectory(Server.MapPath(folder));
                    physical = Path.Combine(Server.MapPath(folder), storedName);
                    AssignmentFile.SaveAs(physical);
                    fileUrl = VirtualPathUtility.ToAbsolute(folder + "/" + storedName);
                    fileSize = AssignmentFile.PostedFile.ContentLength;
                    mime = AssignmentFile.PostedFile.ContentType;
                }
                else if (string.IsNullOrWhiteSpace(AssignmentText.Text) && existing != null)
                {
                    fileUrl = WebData.Text(existing, "FileUrl");
                    originalName = WebData.Text(existing, "OriginalFileName");
                    fileSize = NullableLong(existing, "FileSize");
                    mime = WebData.Text(existing, "MimeType");
                    storedName = string.IsNullOrWhiteSpace(fileUrl)
                        ? null
                        : Path.GetFileName(fileUrl);
                }
                DataTable saved = ServiceRegistry.Learning.GetDataTable(
                    "SubmissionSave",
                    Values(
                        "LessonID",
                        LessonId,
                        "StudentUserID",
                        CurrentUser.UserID,
                        "SubmissionText",
                        Null(AssignmentText.Text),
                        "FileUrl",
                        Null(fileUrl),
                        "OriginalFileName",
                        Null(originalName),
                        "StoredFileName",
                        Null(storedName),
                        "FileSize",
                        fileSize.HasValue ? (object)fileSize.Value : DBNull.Value,
                        "MimeType",
                        Null(mime),
                        "Action",
                        action
                    )
                );
                if (saved == null || saved.Rows.Count == 0)
                    throw new InvalidOperationException(
                        "Stored procedure không trả về kết quả lưu bài."
                    );
                SuccessText.Text =
                    action == "SUBMIT" ? "Đã nộp bài thành công." : "Đã lưu bản nháp.";
                SuccessText.Visible = true;
            }
            catch
            {
                if (!string.IsNullOrWhiteSpace(physical) && File.Exists(physical))
                    File.Delete(physical);
                throw;
            }
        }

        private void ProcessQuiz(string action)
        {
            if (action == "quizStart")
            {
                DataTable started = ServiceRegistry.Quiz.GetDataTable(
                    "AttemptStart",
                    Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
                );
                if (started == null || started.Rows.Count == 0)
                    throw new InvalidOperationException("Không thể bắt đầu lượt làm bài.");
                SuccessText.Text = "Đã bắt đầu lượt làm bài.";
                SuccessText.Visible = true;
                return;
            }
            DataSet data = ServiceRegistry.Quiz.GetDataSet(
                "StudentGet",
                Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
            );
            DataTable questions = Table(data, 1),
                attempts = Table(data, 2);
            DataRow active = Find(attempts, "AttemptStatus", "IN_PROGRESS");
            if (active == null)
                throw new InvalidOperationException("Không có lượt làm bài đang mở.");
            List<Dictionary<string, object>> answers = new List<Dictionary<string, object>>();
            foreach (DataRow question in questions.Rows)
            {
                long id = Convert.ToInt64(question["QuestionID"]);
                string type = WebData.Text(question, "QuestionType");
                answers.Add(
                    new Dictionary<string, object>
                    {
                        { "questionId", id },
                        {
                            "answerText",
                            ReadAnswer("q_" + id, type, WebData.Text(question, "QuestionText"))
                        },
                    }
                );
            }
            DataTable result = ServiceRegistry.Quiz.GetDataTable(
                "AttemptSubmit",
                Values(
                    "QuizAttemptID",
                    active["QuizAttemptID"],
                    "StudentUserID",
                    CurrentUser.UserID,
                    "AnswersJson",
                    Json.Serialize(answers)
                )
            );
            DataRow score = First(result);
            SuccessText.Text =
                "Đã nộp bài kiểm tra. Kết quả: "
                + H(WebData.Text(score, "ScorePercent"))
                + "% - "
                + (Bool(score, "Passed") ? "Đạt" : "Chưa đạt")
                + ".";
            SuccessText.Visible = true;
        }

        private void BindQuiz()
        {
            QuizPanel.Visible = true;
            DataSet data = ServiceRegistry.Quiz.GetDataSet(
                "StudentGet",
                Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
            );
            DataRow quiz = First(Table(data, 0));
            DataTable questions = Table(data, 1),
                attempts = Table(data, 2);
            DataRow active = Find(attempts, "AttemptStatus", "IN_PROGRESS");
            StringBuilder html = new StringBuilder();
            html.Append("<h3 class=\"h4\">")
                .Append(H(WebData.Text(quiz, "Title")))
                .Append("</h3><p>")
                .Append(H(WebData.Text(quiz, "Description")))
                .Append("</p><div class=\"alert alert-light border\">Câu hỏi: <strong>")
                .Append(questions == null ? 0 : questions.Rows.Count)
                .Append("</strong> &nbsp; Đạt từ <strong>")
                .Append(H(WebData.Text(quiz, "PassingScore")))
                .Append("%</strong> &nbsp; Số lượt: <strong>")
                .Append(H(WebData.Text(quiz, "AttemptCount")))
                .Append("/")
                .Append(H(WebData.Text(quiz, "MaxAttempts")))
                .Append("</strong></div>");
            if (active == null)
                html.Append(
                    "<button type=\"submit\" name=\"lessonAction\" value=\"quizStart\" class=\"btn btn-primary\">Bắt đầu làm bài</button>"
                );
            else
            {
                html.Append("<div class=\"alert alert-warning\">Lượt ")
                    .Append(H(WebData.Text(active, "AttemptNumber")))
                    .Append(" đang làm");
                if (!string.IsNullOrWhiteSpace(WebData.Text(active, "RemainingSeconds")))
                    html.Append(" · còn ")
                        .Append(H(WebData.Text(active, "RemainingSeconds")))
                        .Append(" giây");
                html.Append(".</div>");
                if (questions != null)
                {
                    int number = 0;
                    foreach (DataRow q in questions.Rows)
                        html.Append(BuildQuestion(q, "q_", ++number));
                }
                html.Append(
                    "<button type=\"submit\" name=\"lessonAction\" value=\"quizSubmit\" class=\"btn btn-primary\" data-confirm=\"Bạn chắc chắn muốn nộp bài kiểm tra?\">Nộp bài kiểm tra</button>"
                );
            }
            html.Append(BuildQuizHistory(attempts));
            QuizHtml.Text = html.ToString();
        }

        private void ProcessInteractive(string action)
        {
            if (action == "interactiveRead")
                ServiceRegistry.Learning.GetDataTable(
                    "ReadingProgress",
                    Values(
                        "LessonID",
                        LessonId,
                        "StudentUserID",
                        CurrentUser.UserID,
                        "ReadingProgressPercent",
                        100,
                        "LastScrollPercent",
                        100
                    )
                );
            else if (action == "interactiveComplete")
                ServiceRegistry.Learning.GetDataTable(
                    "InteractiveComplete",
                    Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
                );
            else if (action.StartsWith("interactive:", StringComparison.OrdinalIgnoreCase))
            {
                long id;
                if (!long.TryParse(action.Substring(action.IndexOf(':') + 1), out id))
                    throw new ArgumentException("Câu hỏi tương tác không hợp lệ.");
                DataSet data = ServiceRegistry.Learning.GetDataSet(
                    "InteractiveStudent",
                    Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
                );
                DataRow interaction = Find(Table(data, 1), "ContentInteractionID", id.ToString());
                if (interaction == null)
                    throw new ArgumentException("Không tìm thấy câu hỏi tương tác.");
                string answer = ReadAnswer(
                    "i_" + id,
                    WebData.Text(interaction, "QuestionType"),
                    WebData.Text(interaction, "QuestionText")
                );
                ServiceRegistry.Learning.GetDataTable(
                    "InteractiveAnswer",
                    Values(
                        "LessonID",
                        LessonId,
                        "ContentInteractionId",
                        id,
                        "QuestionId",
                        interaction["QuestionID"],
                        "StudentUserID",
                        CurrentUser.UserID,
                        "AnswerText",
                        answer,
                        "TimeSpentSeconds",
                        0
                    )
                );
            }
            SuccessText.Text = "Đã cập nhật tiến độ nội dung tương tác.";
            SuccessText.Visible = true;
        }

        private void BindInteractive()
        {
            InteractivePanel.Visible = true;
            DataSet data = ServiceRegistry.Learning.GetDataSet(
                "InteractiveStudent",
                Values("LessonID", LessonId, "StudentUserID", CurrentUser.UserID)
            );
            DataRow config = First(Table(data, 0)),
                progress = First(Table(data, 3));
            DataTable questions = Table(data, 1),
                answers = Table(data, 2);
            StringBuilder html = new StringBuilder();
            html.Append("<div class=\"alert alert-light border\">Tiến độ: <strong>")
                .Append(H(WebData.Text(progress, "ProgressPercent")))
                .Append("%</strong> &nbsp; Điểm: <strong>")
                .Append(H(WebData.Text(progress, "Score")))
                .Append("</strong> &nbsp; Quy tắc: <strong>")
                .Append(H(WebData.Text(config, "CompletionRule")))
                .Append("</strong></div>");
            if (questions != null)
            {
                int number = 0;
                foreach (DataRow q in questions.Rows)
                {
                    long id = Convert.ToInt64(q["ContentInteractionID"]);
                    html.Append(BuildQuestion(q, "i_", ++number));
                    DataRow old = Find(answers, "ContentInteractionID", id.ToString());
                    if (old != null)
                        html.Append(
                                "<div class=\"small text-secondary mb-2\">Lần trả lời gần nhất: "
                            )
                            .Append(H(WebData.Text(old, "AnswerText")))
                            .Append("</div>");
                    html.Append(
                            "<button type=\"submit\" name=\"lessonAction\" value=\"interactive:"
                        )
                        .Append(id)
                        .Append(
                            "\" class=\"btn btn-outline-primary mb-4\">Lưu câu trả lời</button>"
                        );
                }
            }
            html.Append(
                "<div class=\"d-flex gap-2\"><button type=\"submit\" name=\"lessonAction\" value=\"interactiveRead\" class=\"btn btn-outline-primary\">Đánh dấu đã đọc</button><button type=\"submit\" name=\"lessonAction\" value=\"interactiveComplete\" class=\"btn btn-primary\">Hoàn thành nội dung</button></div>"
            );
            InteractiveHtml.Text = html.ToString();
        }

        private string BuildQuestion(DataRow question, string prefix, int number)
        {
            long id = Convert.ToInt64(
                question[
                    question.Table.Columns.Contains("ContentInteractionID")
                        ? "ContentInteractionID"
                        : "QuestionID"
                ]
            );
            string type = WebData.Text(question, "QuestionType"),
                text = WebData.Text(question, "QuestionText"),
                name = prefix + id;
            IList<OptionItem> options = ParseOptions(WebData.Text(question, "Options"));
            StringBuilder html = new StringBuilder(
                "<fieldset class=\"border rounded p-3 mb-3\"><legend class=\"float-none w-auto px-2 fs-6\">Câu "
            );
            html.Append(number)
                .Append(" · ")
                .Append(H(WebData.Text(question, "Score")))
                .Append(" điểm</legend>");
            if (type == "CLOZE_DRAG_DROP")
            {
                html.Append("<p class=\"fw-semibold\">")
                    .Append(H(WebData.Text(question, "Description")))
                    .Append("</p><div class=\"lh-lg\">");
                int last = 0;
                foreach (Match m in BlankPattern.Matches(text))
                {
                    html.Append(H(text.Substring(last, m.Index - last)))
                        .Append(" <select class=\"form-select d-inline-block w-auto mx-1\" name=\"")
                        .Append(A(name + "_" + m.Groups[1].Value))
                        .Append("\"><option value=\"\">-- chọn --</option>");
                    foreach (OptionItem o in options)
                        html.Append("<option value=\"")
                            .Append(A(o.Code))
                            .Append("\">")
                            .Append(H(o.Text))
                            .Append("</option>");
                    html.Append("</select> ");
                    last = m.Index + m.Length;
                }
                html.Append(H(text.Substring(last))).Append("</div>");
            }
            else if (type == "SINGLE_CHOICE" || type == "TRUE_FALSE" || type == "MULTIPLE_CHOICE")
            {
                html.Append("<p class=\"fw-semibold\">").Append(H(text)).Append("</p>");
                string inputType = type == "MULTIPLE_CHOICE" ? "checkbox" : "radio";
                foreach (OptionItem o in options)
                    html.Append(
                            "<label class=\"d-block border rounded p-2 mb-2\"><input class=\"form-check-input me-2\" type=\""
                        )
                        .Append(inputType)
                        .Append("\" name=\"")
                        .Append(A(name))
                        .Append("\" value=\"")
                        .Append(A(o.Code))
                        .Append("\" />")
                        .Append(H(o.Text))
                        .Append("</label>");
            }
            else
                html.Append("<p class=\"fw-semibold\">")
                    .Append(H(text))
                    .Append("</p><textarea class=\"form-control\" rows=\"3\" name=\"")
                    .Append(A(name))
                    .Append("\"></textarea>");
            html.Append("</fieldset>");
            return html.ToString();
        }

        private string ReadAnswer(string name, string type, string template)
        {
            if (type == "MULTIPLE_CHOICE")
            {
                string[] values = Request.Form.GetValues(name) ?? new string[0];
                return string.Join(
                    "|",
                    values
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => x.Trim().ToUpperInvariant())
                        .Distinct()
                        .OrderBy(x => x)
                        .ToArray()
                );
            }
            if (type == "CLOZE_DRAG_DROP")
            {
                List<string> pairs = new List<string>();
                foreach (Match match in BlankPattern.Matches(template ?? string.Empty))
                {
                    string code = match.Groups[1].Value.ToUpperInvariant(),
                        value = Request.Form[name + "_" + match.Groups[1].Value];
                    if (!string.IsNullOrWhiteSpace(value))
                        pairs.Add(code + "=" + value.Trim().ToUpperInvariant());
                }
                pairs.Sort(StringComparer.Ordinal);
                return string.Join("|", pairs.ToArray());
            }
            return (Request.Form[name] ?? string.Empty).Trim();
        }

        private static IList<OptionItem> ParseOptions(string json)
        {
            List<OptionItem> result = new List<OptionItem>();
            if (string.IsNullOrWhiteSpace(json))
                return result;
            object[] rows = Json.DeserializeObject(json) as object[];
            if (rows == null)
                return result;
            foreach (object value in rows)
            {
                Dictionary<string, object> row = value as Dictionary<string, object>;
                if (row == null)
                    continue;
                result.Add(
                    new OptionItem
                    {
                        Code = Dict(row, "OptionCode"),
                        Text = Dict(row, "OptionText"),
                    }
                );
            }
            return result;
        }

        private static string BuildAssignmentHistory(DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
                return "<div class=\"text-secondary\">Chưa có bài nộp.</div>";
            StringBuilder html = new StringBuilder();
            foreach (DataRow r in table.Rows)
            {
                string url = WebData.Text(r, "FileUrl");
                html.Append(
                        "<div class=\"submission-history-item\"><div class=\"submission-record-main\"><span class=\"attempt\">Lần "
                    )
                    .Append(H(WebData.Text(r, "AttemptNumber")))
                    .Append("</span><div><strong>")
                    .Append(H(WebData.Text(r, "SubmissionStatus")))
                    .Append("</strong><small>")
                    .Append(H(WebData.Text(r, "SubmittedAt")))
                    .Append("</small></div></div>");
                if (!string.IsNullOrWhiteSpace(url))
                    html.Append("<a target=\"_blank\" href=\"")
                        .Append(A(url))
                        .Append("\"><i class=\"bi bi-file-earmark-check-fill\"></i> ")
                        .Append(H(WebData.Text(r, "OriginalFileName")))
                        .Append("</a>");
                html.Append("<span class=\"submission-score\">")
                    .Append(H(WebData.Text(r, "Score")))
                    .Append(" điểm</span></div>");
            }
            return html.ToString();
        }

        private static string BuildQuizHistory(DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
                return string.Empty;
            StringBuilder html = new StringBuilder(
                "<h4 class=\"h5 mt-4\">Lịch sử làm bài</h4><div class=\"table-responsive\"><table class=\"table\"><thead><tr><th>Lần</th><th>Trạng thái</th><th>Điểm</th><th>Kết quả</th></tr></thead><tbody>"
            );
            foreach (DataRow r in table.Rows)
                html.Append("<tr><td>")
                    .Append(H(WebData.Text(r, "AttemptNumber")))
                    .Append("</td><td>")
                    .Append(H(WebData.Text(r, "AttemptStatus")))
                    .Append("</td><td>")
                    .Append(H(WebData.Text(r, "ScorePercent")))
                    .Append("%</td><td>")
                    .Append(Bool(r, "Passed") ? "Đạt" : "Chưa đạt")
                    .Append("</td></tr>");
            return html.Append("</tbody></table></div>").ToString();
        }

        private string BuildVideo(DataRow row, DataRow progress, bool interactive)
        {
            if (row == null)
                return "<div class=\"empty-state\">Bài học này không có video.</div>";
            string sourceType = WebData.Text(row, "SourceType"),
                url = WebData.Text(row, "VideoUrl");
            if (string.IsNullOrWhiteSpace(url))
                return "<div class=\"empty-state\">Video chưa được cấu hình.</div>";
            string videoId = A(WebData.Text(row, "Id"));
            if (!interactive)
            {
                if (string.Equals(sourceType, "YOUTUBE", StringComparison.OrdinalIgnoreCase))
                    return "<div class=\"ratio ratio-16x9\"><iframe src=\""
                        + A(YouTubeEmbed(url))
                        + "\" title=\"Video bài học\" allowfullscreen=\"allowfullscreen\"></iframe></div>";
                return "<div class=\"ratio ratio-16x9 bg-dark\"><video id=\"lessonVideo\" controls=\"controls\" preload=\"metadata\" src=\""
                    + A(ResolveAsset(url))
                    + "\" data-video-id=\""
                    + videoId
                    + "\" data-allow-seek=\""
                    + A(WebData.Text(row, "AllowSeek"))
                    + "\" data-allow-speed=\""
                    + A(WebData.Text(row, "AllowSpeed"))
                    + "\"></video></div>";
            }
            string media = string.Equals(sourceType, "YOUTUBE", StringComparison.OrdinalIgnoreCase)
                ? "<div class=\"interactive-youtube\" data-youtube-id=\""
                    + A(YouTubeVideoId(url))
                    + "\"></div>"
                : "<video id=\"lessonVideo\" class=\"interactive-video-element\" controls=\"controls\" preload=\"metadata\" playsinline=\"playsinline\" src=\""
                    + A(ResolveAsset(url))
                    + "\" data-video-id=\""
                    + videoId
                    + "\" data-allow-seek=\""
                    + A(WebData.Text(row, "AllowSeek"))
                    + "\" data-allow-speed=\""
                    + A(WebData.Text(row, "AllowSpeed"))
                    + "\" data-current-time=\""
                    + A(WebData.Text(progress, "CurrentTimeSeconds"))
                    + "\" data-max-watched=\""
                    + A(WebData.Text(progress, "MaxWatchedTimeSeconds"))
                    + "\"></video>";
            return "<div class=\"interactive-player"
                + (
                    string.Equals(sourceType, "YOUTUBE", StringComparison.OrdinalIgnoreCase)
                        ? " youtube-mode"
                        : ""
                )
                + "\" data-interactive-video=\"1\" data-mode=\"student\" data-video-id=\""
                + videoId
                + "\" data-lesson-id=\""
                + LessonId
                + "\" data-student-id=\""
                + CurrentUser.UserID
                + "\" data-interactions-id=\""
                + VideoInteractionsJsonValue.ClientID
                + "\" data-handler-url=\""
                + A(ResolveUrl("~/Handlers/Lms/Module.ashx"))
                + "\" data-duration=\""
                + A(WebData.Text(row, "DurationSeconds"))
                + "\" data-initial-time=\""
                + A(WebData.Text(progress, "CurrentTimeSeconds"))
                + "\"><div class=\"interactive-stage\">"
                + media
                + "</div><div class=\"interaction-timeline\"><div class=\"interaction-track"
                + (Bool(row, "AllowSeek") ? " seekable" : "")
                + "\" tabindex=\"0\"><span class=\"interaction-track-progress\"></span><span class=\"interaction-playhead\"></span></div><div class=\"timeline-current\"><i class=\"bi bi-clock\"></i><strong>"
                + H(FormatInteractionTime(ToIntAny(progress, 0, "CurrentTimeSeconds")))
                + "</strong></div></div></div>";
        }

        private string SerializeVideoInteractions(DataTable table, DataTable answered)
        {
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            if (table != null)
                foreach (DataRow row in table.Rows)
                {
                    long id = LongAny(row, "Id", "InteractionId", "VideoInteractionID");
                    items.Add(
                        new Dictionary<string, object>
                        {
                            { "id", id },
                            { "questionId", LongAny(row, "QuestionId", "QuestionID") },
                            { "time", ToIntAny(row, 0, "TimeSeconds") },
                            { "label", WebData.Text(row, "QuestionText") },
                            { "description", WebData.Text(row, "Description") },
                            { "type", WebData.Text(row, "QuestionType") },
                            { "required", Bool(row, "Required") },
                            { "pauseVideo", Bool(row, "PauseVideo") },
                            { "allowSkip", Bool(row, "AllowSkip") },
                            { "score", WebData.Text(row, "Score") },
                            { "attemptLimit", ToIntAny(row, 1, "AttemptLimit") },
                            { "status", WebData.Text(row, "Status") },
                            {
                                "answered",
                                FindAny(
                                    answered,
                                    id.ToString(),
                                    "InteractionId",
                                    "VideoInteractionID"
                                ) != null
                            },
                            { "options", ParseJson(WebData.Text(row, "Options")) },
                        }
                    );
                }
            return Json.Serialize(items);
        }

        private static object ParseJson(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return new object[0];
            try
            {
                return Json.DeserializeObject(value);
            }
            catch
            {
                return new object[0];
            }
        }

        private static string FormatInteractionTime(int seconds)
        {
            seconds = Math.Max(0, seconds);
            return (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        private string ResolveAsset(string url)
        {
            return url.StartsWith("/", StringComparison.Ordinal) ? ResolveUrl("~" + url) : url;
        }

        private void HidePlayers()
        {
            VideoPanel.Visible =
                ContentPanel.Visible =
                DocumentPanel.Visible =
                AssignmentPanel.Visible =
                QuizPanel.Visible =
                InteractivePanel.Visible =
                VideoInteractionPanel.Visible =
                    false;
        }

        private static DataTable Table(DataSet data, int index)
        {
            return data != null && data.Tables.Count > index ? data.Tables[index] : null;
        }

        private static DataRow First(DataTable table)
        {
            return table != null && table.Rows.Count > 0 ? table.Rows[0] : null;
        }

        private static DataRow Find(DataTable table, string column, string value)
        {
            if (table == null || !table.Columns.Contains(column))
                return null;
            foreach (DataRow row in table.Rows)
                if (
                    string.Equals(
                        Convert.ToString(row[column]),
                        value,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                    return row;
            return null;
        }

        private static DataRow FindAny(DataTable table, string value, params string[] columns)
        {
            if (table == null)
                return null;
            foreach (string column in columns)
            {
                DataRow found = Find(table, column, value);
                if (found != null)
                    return found;
            }
            return null;
        }

        private static long LongAny(DataRow row, params string[] columns)
        {
            if (row != null)
                foreach (string column in columns)
                {
                    long value;
                    if (
                        row.Table.Columns.Contains(column)
                        && long.TryParse(Convert.ToString(row[column]), out value)
                    )
                        return value;
                }
            return 0;
        }

        private static int ToIntAny(DataRow row, int fallback, params string[] columns)
        {
            if (row != null)
                foreach (string column in columns)
                {
                    int value;
                    if (
                        row.Table.Columns.Contains(column)
                        && int.TryParse(Convert.ToString(row[column]), out value)
                    )
                        return value;
                }
            return fallback;
        }

        private static string DateText(DataRow row, string column)
        {
            if (row == null || !row.Table.Columns.Contains(column) || row[column] == DBNull.Value)
                return "Không giới hạn";
            DateTime value;
            return DateTime.TryParse(Convert.ToString(row[column]), out value)
                ? value.ToLocalTime().ToString("dd/MM/yyyy HH:mm")
                : Convert.ToString(row[column]);
        }

        private static int ToInt(DataRow row, string column, int fallback)
        {
            int value;
            return
                row != null
                && row.Table.Columns.Contains(column)
                && int.TryParse(Convert.ToString(row[column]), out value)
                ? value
                : fallback;
        }

        private static int Percentage(DataRow row, string column, decimal fallback)
        {
            decimal value = fallback;
            if (row != null && row.Table.Columns.Contains(column) && row[column] != DBNull.Value)
                decimal.TryParse(Convert.ToString(row[column]), out value);
            return Math.Max(
                0,
                Math.Min(100, Convert.ToInt32(Math.Round(value, MidpointRounding.AwayFromZero)))
            );
        }

        private static string FormatStudyTime(int seconds)
        {
            seconds = Math.Max(0, seconds);
            int hours = seconds / 3600,
                minutes = (seconds % 3600) / 60;
            return hours > 0
                ? hours.ToString("00") + ":" + minutes.ToString("00")
                : minutes.ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        private static string FormatDuration(int seconds)
        {
            seconds = Math.Max(0, seconds);
            return (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        private static string Initials(string name)
        {
            string[] parts = (name ?? string.Empty).Split(
                new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );
            if (parts.Length == 0)
                return "HV";
            return parts.Length == 1
                ? parts[0].Substring(0, 1).ToUpperInvariant()
                : (
                    parts[0].Substring(0, 1) + parts[parts.Length - 1].Substring(0, 1)
                ).ToUpperInvariant();
        }

        private static string QuestionTypeText(string type)
        {
            switch ((type ?? string.Empty).ToUpperInvariant())
            {
                case "SINGLE_CHOICE":
                    return "Một lựa chọn";
                case "MULTIPLE_CHOICE":
                    return "Nhiều lựa chọn";
                case "TRUE_FALSE":
                    return "Đúng / Sai";
                case "CLOZE_DRAG_DROP":
                    return "Điền khuyết";
                case "SHORT_ANSWER":
                    return "Trả lời ngắn";
                default:
                    return "Câu hỏi";
            }
        }

        private static long? NullableLong(DataRow row, string column)
        {
            long value;
            return
                row != null
                && row.Table.Columns.Contains(column)
                && long.TryParse(Convert.ToString(row[column]), out value)
                ? (long?)value
                : null;
        }

        private static bool Bool(DataRow row, string column)
        {
            bool value;
            return row != null
                && row.Table.Columns.Contains(column)
                && bool.TryParse(Convert.ToString(row[column]), out value)
                && value;
        }

        private static object Null(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim();
        }

        private static string H(string value)
        {
            return HttpUtility.HtmlEncode(value ?? string.Empty);
        }

        private static string A(string value)
        {
            return HttpUtility.HtmlAttributeEncode(value ?? string.Empty);
        }

        private static string Dict(Dictionary<string, object> row, string key)
        {
            object value;
            return row.TryGetValue(key, out value) && value != null
                ? Convert.ToString(value)
                : string.Empty;
        }

        private static IDictionary<string, object> Values(params object[] pairs)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(
                StringComparer.OrdinalIgnoreCase
            );
            for (int i = 0; i + 1 < pairs.Length; i += 2)
                values[Convert.ToString(pairs[i])] = pairs[i + 1];
            return values;
        }

        private static string YouTubeEmbed(string url)
        {
            if (url.IndexOf("/embed/", StringComparison.OrdinalIgnoreCase) >= 0)
                return url;
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                return url;
            string id =
                uri.Host.IndexOf("youtu.be", StringComparison.OrdinalIgnoreCase) >= 0
                    ? uri.AbsolutePath.Trim('/')
                    : HttpUtility.ParseQueryString(uri.Query)["v"];
            return string.IsNullOrWhiteSpace(id) ? url : "https://www.youtube.com/embed/" + id;
        }

        private static string YouTubeVideoId(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri))
                return string.Empty;
            string id =
                uri.Host.IndexOf("youtu.be", StringComparison.OrdinalIgnoreCase) >= 0
                    ? uri.AbsolutePath.Trim('/')
                    : HttpUtility.ParseQueryString(uri.Query)["v"];
            if (
                string.IsNullOrWhiteSpace(id)
                && uri.AbsolutePath.IndexOf("/embed/", StringComparison.OrdinalIgnoreCase) >= 0
            )
                id = uri.AbsolutePath.Split('/').Last();
            return id ?? string.Empty;
        }

        private sealed class OptionItem
        {
            public string Code { get; set; }
            public string Text { get; set; }
        }
    }
}
