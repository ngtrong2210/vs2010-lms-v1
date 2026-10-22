using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class ContentBuilder : CmsControl
    {
        private DataTable lessonTable;
        private long CourseId
        {
            get { return RouteLong("courseId"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HeadingText.Text = CourseId > 0 ? "Biên soạn môn học" : "Tạo môn học";
            if (CourseId > 0)
            {
                if (!IsPostBack)
                {
                    LoadCourse();
                    LoadQuestionBank();
                }
                else
                {
                    BindContent(GetCourseContent());
                    HeadingText.Text = Server.HtmlEncode(CourseTitleText.Text);
                    if (string.IsNullOrWhiteSpace(QuestionBankJsonValue.Value))
                        LoadQuestionBank();
                    if (VideoPickerPanel.Visible && ParseId(VideoTargetLessonValue.Value) > 0)
                        BindVideoAssets();
                }
            }
            else if (!IsPostBack)
            {
                TeacherIdText.Text = CurrentUser.UserID.ToString();
                ChapterDisplayToolbar.Visible = false;
                EmptyContentPanel.Visible = true;
                LoadQuestionBank();
            }
        }

        private void LoadCourse()
        {
            DataTable detail = ServiceRegistry.Courses.GetDataTable(
                "Get",
                Values(
                    "Id",
                    CourseId,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (detail != null && detail.Rows.Count > 0)
            {
                DataRow row = detail.Rows[0];
                CodeText.Text = WebData.Text(row, "Code");
                CourseTitleText.Text = WebData.Text(row, "Title");
                SlugText.Text = WebData.Text(row, "Slug");
                ShortDescriptionText.Text = WebData.Text(row, "ShortDescription");
                DescriptionText.Text = WebData.Text(row, "Description");
                TeacherIdText.Text = WebData.Text(row, "TeacherId", "TeacherUserID");
                CategoryIdText.Text = WebData.Text(row, "CategoryId", "CourseCategoryID");
                LevelText.Text = WebData.Text(row, "Level");
                PassingScoreText.Text = WebData.Text(row, "PassingScore");
                string status = WebData.Text(row, "Status");
                if (StatusList.Items.FindByValue(status) != null)
                    StatusList.SelectedValue = status;
                HeadingText.Text = Server.HtmlEncode(CourseTitleText.Text);
            }
            BindContent(GetCourseContent());
        }

        private void BindContent(DataSet content)
        {
            DataTable chapters =
                content != null && content.Tables.Count > 0 ? content.Tables[0] : null;
            lessonTable = content != null && content.Tables.Count > 1 ? content.Tables[1] : null;
            int chapterCount = chapters == null ? 0 : chapters.Rows.Count;

            ChapterRepeater.DataSource = chapters;
            ChapterRepeater.DataBind();
            ContentGrid.DataSource = chapters;
            ContentGrid.DataBind();
            LessonGrid.DataSource = lessonTable;
            LessonGrid.DataBind();
            ChapterCountText.Text = chapterCount.ToString();
            ChapterDisplayToolbar.Visible = chapterCount > 0;
            EmptyContentPanel.Visible = chapterCount == 0;
        }

        private void LoadQuestionBank()
        {
            DataSet data = ServiceRegistry.Questions.GetDataSet(
                "List",
                Values("Search", null, "Type", null, "Page", 1, "PageSize", 100)
            );
            DataTable table = data != null && data.Tables.Count > 0 ? data.Tables[0] : null;
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    string type = WebData.Text(row, "QuestionType");
                    string text =
                        type == "CLOZE_DRAG_DROP"
                            ? WebData.Text(row, "Description")
                            : WebData.Text(row, "QuestionText");
                    if (string.IsNullOrWhiteSpace(text))
                        text = WebData.Text(row, "QuestionText");
                    rows.Add(
                        new Dictionary<string, object>
                        {
                            { "id", WebData.Long(row, "Id", "QuestionID") },
                            { "text", text },
                            { "type", type },
                            { "score", DecimalValue(row, "DefaultScore", 0) },
                        }
                    );
                }
            }
            QuestionBankJsonValue.Value = Json().Serialize(rows);
        }

        private void LoadQuizEditor(long lessonId)
        {
            QuizPassingScoreText.Text = "50";
            QuizTimeLimitText.Text = "30";
            QuizMaxAttemptsText.Text = "1";
            QuizShuffleCheck.Checked = false;
            QuizSelectedJsonValue.Value = "[]";
            DataSet data = ServiceRegistry.Quiz.GetDataSet(
                "TeacherGet",
                Values(
                    "LessonID",
                    lessonId,
                    "ActorID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (data == null)
                return;
            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                DataRow settings = data.Tables[0].Rows[0];
                QuizPassingScoreText.Text = DefaultText(settings, "PassingScore", "50");
                QuizTimeLimitText.Text = DefaultText(settings, "TimeLimitMinutes", "30");
                QuizMaxAttemptsText.Text = DefaultText(settings, "MaxAttempts", "1");
                QuizShuffleCheck.Checked = Bool(settings, "ShuffleQuestions", false);
            }
            List<Dictionary<string, object>> selected = new List<Dictionary<string, object>>();
            if (data.Tables.Count > 1)
            {
                foreach (DataRow row in data.Tables[1].Rows)
                    selected.Add(
                        new Dictionary<string, object>
                        {
                            { "id", WebData.Long(row, "QuestionID", "Id") },
                            { "text", WebData.Text(row, "QuestionText") },
                            { "type", WebData.Text(row, "QuestionType") },
                            { "score", DecimalValue(row, "Score", 0) },
                        }
                    );
            }
            QuizSelectedJsonValue.Value = Json().Serialize(selected);
        }

        private void LoadInteractiveEditor(long lessonId)
        {
            InteractiveCompletionList.SelectedValue = "REQUIRED_QUESTIONS";
            InteractivePassingScoreText.Text = "70";
            InteractiveRequireReadingCheck.Checked = true;
            InteractiveShowResultCheck.Checked = true;
            InteractiveShowScoreCheck.Checked = true;
            InteractiveMappingsJsonValue.Value = "[]";
            InteractiveOriginalIdsValue.Value = "[]";
            DataSet data = ServiceRegistry.Content.GetDataSet(
                "InteractiveTeacher",
                Values(
                    "LessonID",
                    lessonId,
                    "ActorUserID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (data == null)
                return;
            if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
            {
                DataRow settings = data.Tables[0].Rows[0];
                SetSelected(InteractiveCompletionList, WebData.Text(settings, "CompletionRule"));
                InteractivePassingScoreText.Text = DefaultText(settings, "PassingScore", "70");
                InteractiveRequireReadingCheck.Checked = Bool(settings, "RequireReading", true);
                InteractiveShowResultCheck.Checked = Bool(settings, "ShowResultImmediately", true);
                InteractiveShowScoreCheck.Checked = Bool(settings, "ShowScore", true);
            }
            List<Dictionary<string, object>> mappings = new List<Dictionary<string, object>>();
            List<long> originalIds = new List<long>();
            if (data.Tables.Count > 1)
            {
                foreach (DataRow row in data.Tables[1].Rows)
                {
                    long id = WebData.Long(row, "ContentInteractionID", "Id");
                    originalIds.Add(id);
                    mappings.Add(
                        new Dictionary<string, object>
                        {
                            { "id", id },
                            { "questionId", WebData.Long(row, "QuestionID") },
                            { "questionText", WebData.Text(row, "QuestionText") },
                            { "questionType", WebData.Text(row, "QuestionType") },
                            { "required", Bool(row, "Required", true) },
                            { "allowRetry", Bool(row, "AllowRetry", true) },
                            { "score", DecimalValue(row, "Score", 0) },
                            { "attemptLimit", IntValue(row, "AttemptLimit", 1) },
                            { "sortOrder", IntValue(row, "SortOrder", mappings.Count + 1) },
                            { "status", WebData.Text(row, "Status") },
                        }
                    );
                }
            }
            InteractiveMappingsJsonValue.Value = Json().Serialize(mappings);
            InteractiveOriginalIdsValue.Value = Json().Serialize(originalIds);
        }

        private void SaveQuizEditor(long lessonId)
        {
            decimal passingScore;
            int maxAttempts;
            int timeLimit;
            if (
                !decimal.TryParse(QuizPassingScoreText.Text, out passingScore)
                || passingScore < 0
                || passingScore > 100
            )
                throw new ArgumentException("Điểm đạt bài kiểm tra phải từ 0 đến 100.");
            if (
                !int.TryParse(QuizMaxAttemptsText.Text, out maxAttempts)
                || maxAttempts < 1
                || maxAttempts > 20
            )
                throw new ArgumentException("Số lượt làm bài kiểm tra phải từ 1 đến 20.");
            object timeLimitValue = null;
            if (!string.IsNullOrWhiteSpace(QuizTimeLimitText.Text))
            {
                if (
                    !int.TryParse(QuizTimeLimitText.Text, out timeLimit)
                    || timeLimit < 1
                    || timeLimit > 600
                )
                    throw new ArgumentException("Thời gian bài kiểm tra phải từ 1 đến 600 phút.");
                timeLimitValue = timeLimit;
            }
            List<Dictionary<string, object>> selected = ParseDictionaryList(
                QuizSelectedJsonValue.Value
            );
            List<long> questionIds = new List<long>();
            foreach (Dictionary<string, object> item in selected)
            {
                long id = DictionaryLong(item, "id", "QuestionID", "questionId");
                if (id > 0 && !questionIds.Contains(id))
                    questionIds.Add(id);
            }
            if (questionIds.Count == 0)
                throw new ArgumentException("Bài kiểm tra cần ít nhất một câu hỏi.");
            DataTable saved = ServiceRegistry.Quiz.GetDataTable(
                "Save",
                Values(
                    "LessonID",
                    lessonId,
                    "Title",
                    LessonTitleText.Text.Trim(),
                    "Description",
                    NullIfEmpty(LessonDescriptionText.Text),
                    "PassingScore",
                    passingScore,
                    "TimeLimitMinutes",
                    timeLimitValue,
                    "MaxAttempts",
                    maxAttempts,
                    "ShuffleQuestions",
                    QuizShuffleCheck.Checked,
                    "QuestionIDsJson",
                    Json().Serialize(questionIds),
                    "ActorID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (saved == null || saved.Rows.Count == 0)
                throw new InvalidOperationException("Không thể lưu cấu hình bài kiểm tra.");
        }

        private void SaveInteractiveEditor(long lessonId)
        {
            decimal passingScore;
            if (
                !decimal.TryParse(InteractivePassingScoreText.Text, out passingScore)
                || passingScore < 0
                || passingScore > 100
            )
                throw new ArgumentException("Điểm đạt bài học tương tác phải từ 0 đến 100.");
            DataTable settings = ServiceRegistry.Content.GetDataTable(
                "InteractiveSettings",
                Values(
                    "LessonID",
                    lessonId,
                    "CompletionRule",
                    InteractiveCompletionList.SelectedValue,
                    "RequireReading",
                    InteractiveRequireReadingCheck.Checked,
                    "PassingScore",
                    passingScore,
                    "ShowResultImmediately",
                    InteractiveShowResultCheck.Checked,
                    "ShowScore",
                    InteractiveShowScoreCheck.Checked,
                    "ActorUserID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (settings == null || settings.Rows.Count == 0)
                throw new InvalidOperationException("Không thể lưu thiết lập bài học tương tác.");

            List<Dictionary<string, object>> mappings = ParseDictionaryList(
                InteractiveMappingsJsonValue.Value
            );
            List<long> originalIds = ParseLongList(InteractiveOriginalIdsValue.Value);
            List<long> activeIds = new List<long>();
            foreach (Dictionary<string, object> mapping in mappings)
            {
                long id = DictionaryLong(mapping, "id", "ContentInteractionID");
                if (id > 0)
                    activeIds.Add(id);
            }
            foreach (long id in originalIds)
            {
                if (id <= 0 || activeIds.Contains(id))
                    continue;
                DataTable deleted = ServiceRegistry.Content.GetDataTable(
                    "ContentInteractionDelete",
                    Values(
                        "ContentInteractionID",
                        id,
                        "ActorUserID",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
                if (deleted == null || deleted.Rows.Count == 0)
                    throw new InvalidOperationException(
                        "Không thể bỏ câu hỏi khỏi bài học tương tác."
                    );
            }
            for (int index = 0; index < mappings.Count; index++)
            {
                Dictionary<string, object> mapping = mappings[index];
                long id = DictionaryLong(mapping, "id", "ContentInteractionID"),
                    questionId = DictionaryLong(mapping, "questionId", "QuestionID");
                decimal score = DictionaryDecimal(mapping, "score", "Score");
                bool required = DictionaryBool(mapping, true, "required", "Required"),
                    allowRetry = DictionaryBool(mapping, true, "allowRetry", "AllowRetry");
                int attemptLimit = allowRetry
                    ? Math.Max(1, DictionaryInt(mapping, 1, "attemptLimit", "AttemptLimit"))
                    : 1;
                if (questionId <= 0 || score < 0 || score > 10000 || attemptLimit > 100)
                    throw new ArgumentException("Thiết lập câu hỏi tương tác không hợp lệ.");
                IDictionary<string, object> values = Values(
                    "QuestionID",
                    questionId,
                    "ContentAnchor",
                    null,
                    "Required",
                    required,
                    "AllowRetry",
                    allowRetry,
                    "Score",
                    score,
                    "AttemptLimit",
                    attemptLimit,
                    "SortOrder",
                    index + 1,
                    "Status",
                    "ACTIVE",
                    "ActorUserID",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                );
                DataTable result;
                if (id > 0)
                {
                    values["ContentInteractionID"] = id;
                    result = ServiceRegistry.Content.GetDataTable(
                        "ContentInteractionUpdate",
                        values
                    );
                }
                else
                {
                    values["LessonID"] = lessonId;
                    result = ServiceRegistry.Content.GetDataTable(
                        "ContentInteractionCreate",
                        values
                    );
                }
                if (result == null || result.Rows.Count == 0)
                    throw new InvalidOperationException(
                        "Không thể lưu câu hỏi trong bài học tương tác."
                    );
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                long teacherId;
                long? categoryId = NullableLong(CategoryIdText.Text);
                decimal passingScore;
                if (
                    string.IsNullOrWhiteSpace(CodeText.Text)
                    || string.IsNullOrWhiteSpace(CourseTitleText.Text)
                )
                    throw new ArgumentException("Vui lòng nhập mã và tên môn học.");
                if (!long.TryParse(TeacherIdText.Text, out teacherId) || teacherId <= 0)
                    throw new ArgumentException("ID giảng viên không hợp lệ.");
                if (!decimal.TryParse(PassingScoreText.Text, out passingScore))
                    throw new ArgumentException("Điểm đạt không hợp lệ.");
                IDictionary<string, object> values = Values(
                    "Code",
                    CodeText.Text.Trim(),
                    "Title",
                    CourseTitleText.Text.Trim(),
                    "Slug",
                    SlugText.Text.Trim(),
                    "ThumbnailUrl",
                    null,
                    "ShortDescription",
                    ShortDescriptionText.Text.Trim(),
                    "Description",
                    DescriptionText.Text,
                    "TeacherId",
                    teacherId,
                    "CategoryId",
                    categoryId,
                    "ClassSubjectID",
                    null,
                    "Level",
                    LevelText.Text.Trim(),
                    "PassingScore",
                    passingScore,
                    "Status",
                    StatusList.SelectedValue,
                    "ActorId",
                    CurrentUser.UserID
                );
                if (CourseId > 0)
                {
                    values["Id"] = CourseId;
                    values["IsAdmin"] = CurrentUser.IsAdmin;
                    bool ok = ServiceRegistry.Courses.ExecNonQuery("Update", values);
                    ShowMessage(ok ? "Đã lưu môn học." : "Không thể lưu môn học.", ok);
                    if (ok)
                        LoadCourse();
                }
                else
                {
                    DataTable created = ServiceRegistry.Courses.GetDataTable("Create", values);
                    if (created == null || created.Rows.Count == 0)
                        throw new InvalidOperationException(
                            "Stored procedure không trả về ID môn học."
                        );
                    long id = Convert.ToInt64(created.Rows[0][0]);
                    Response.Redirect(ResolveUrl("~/cms/courses/" + id + "/content"), true);
                }
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu môn học thất bại.", ex);
                ShowMessage(ex.Message, false);
            }
        }

        protected void AddChapterButton_Click(object sender, EventArgs e)
        {
            try
            {
                int sortOrder;
                long chapterId = ParseId(ChapterIdValue.Value);
                if (
                    CourseId <= 0
                    || string.IsNullOrWhiteSpace(ChapterTitleText.Text)
                    || !int.TryParse(ChapterSortOrderText.Text, out sortOrder)
                    || sortOrder < 1
                )
                    throw new ArgumentException("Tên chương hoặc thứ tự không hợp lệ.");

                IDictionary<string, object> values = Values(
                    "Title",
                    ChapterTitleText.Text.Trim(),
                    "Description",
                    NullIfEmpty(ChapterDescriptionText.Text),
                    "SortOrder",
                    sortOrder,
                    "Status",
                    ChapterStatusList.SelectedValue,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                );
                bool ok;
                if (chapterId > 0)
                {
                    EnsureChapterInCourse(chapterId);
                    values["Id"] = chapterId;
                    ok = ServiceRegistry.Content.ExecNonQuery("ChapterUpdate", values);
                }
                else
                {
                    values["CourseId"] = CourseId;
                    DataTable created = ServiceRegistry.Content.GetDataTable(
                        "ChapterCreate",
                        values
                    );
                    ok = created != null && created.Rows.Count > 0;
                }

                ShowMessage(
                    ok
                        ? (chapterId > 0 ? "Đã cập nhật chương." : "Đã thêm chương.")
                        : "Không thể lưu chương.",
                    ok
                );
                if (ok)
                {
                    ResetChapterForm();
                    LoadCourse();
                }
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu chương thất bại.", ex);
                ShowMessage(ex.Message, false);
            }
        }

        protected void AddLessonButton_Click(object sender, EventArgs e)
        {
            try
            {
                long chapterId;
                int duration,
                    sortOrder,
                    maxAttempts,
                    maxFileSize;
                decimal passingScore,
                    maxScore;
                long lessonId = ParseId(LessonIdValue.Value);
                if (
                    CourseId <= 0
                    || !long.TryParse(LessonChapterIdText.Text, out chapterId)
                    || chapterId <= 0
                    || string.IsNullOrWhiteSpace(LessonTitleText.Text)
                    || !int.TryParse(LessonDurationText.Text, out duration)
                    || duration < 0
                    || !int.TryParse(LessonSortOrderText.Text, out sortOrder)
                    || sortOrder < 1
                )
                    throw new ArgumentException("Thông tin bài học không hợp lệ.");
                if (
                    !decimal.TryParse(LessonPassingScoreText.Text, out passingScore)
                    || passingScore < 0
                    || passingScore > 100
                )
                    throw new ArgumentException("Điểm đạt phải từ 0 đến 100.");
                if (
                    !decimal.TryParse(LessonMaxScoreText.Text, out maxScore)
                    || maxScore < 1
                    || maxScore > 10000
                )
                    throw new ArgumentException("Điểm tối đa phải từ 1 đến 10000.");
                if (
                    !int.TryParse(LessonMaxAttemptsText.Text, out maxAttempts)
                    || maxAttempts < 1
                    || maxAttempts > 20
                )
                    throw new ArgumentException("Số lần nộp phải từ 1 đến 20.");
                if (
                    !int.TryParse(LessonMaxFileSizeText.Text, out maxFileSize)
                    || maxFileSize < 1
                    || maxFileSize > 200
                )
                    throw new ArgumentException("Dung lượng tệp phải từ 1 đến 200 MB.");

                EnsureChapterInCourse(chapterId);
                if (lessonId > 0)
                    EnsureLessonInCourse(lessonId);
                IDictionary<string, object> values = Values(
                    "Title",
                    LessonTitleText.Text.Trim(),
                    "Description",
                    NullIfEmpty(LessonDescriptionText.Text),
                    "LessonType",
                    LessonTypeList.SelectedValue,
                    "DurationSeconds",
                    duration,
                    "SortOrder",
                    sortOrder,
                    "IsRequired",
                    LessonRequiredCheck.Checked,
                    "PassingScore",
                    passingScore,
                    "ContentHtml",
                    NullIfEmpty(LessonContentText.Text),
                    "DocumentUrl",
                    NullIfEmpty(LessonDocumentUrlText.Text),
                    "AssignmentFolderName",
                    NullIfEmpty(LessonAssignmentFolderText.Text),
                    "AssignmentStartAt",
                    NullableDate(LessonAssignmentStartText.Text),
                    "DueAt",
                    NullableDate(LessonDueAtText.Text),
                    "AssignmentMaxScore",
                    maxScore,
                    "MaxSubmissionAttempts",
                    maxAttempts,
                    "MaxSubmissionFileSizeMB",
                    maxFileSize,
                    "AllowLateSubmission",
                    LessonAllowLateCheck.Checked,
                    "Status",
                    LessonStatusList.SelectedValue,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                );
                bool ok;
                if (lessonId > 0)
                {
                    values["Id"] = lessonId;
                    ok = ServiceRegistry.Content.ExecNonQuery("LessonUpdate", values);
                }
                else
                {
                    values["ChapterId"] = chapterId;
                    DataTable created = ServiceRegistry.Content.GetDataTable(
                        "LessonCreate",
                        values
                    );
                    ok = created != null && created.Rows.Count > 0;
                    if (ok)
                        lessonId = FirstLong(created.Rows[0], "Id", "LessonID", "Column1");
                }

                if (ok && lessonId <= 0)
                    throw new InvalidOperationException(
                        "Stored procedure không trả về ID bài học."
                    );
                if (ok && LessonTypeList.SelectedValue == "QUIZ")
                    SaveQuizEditor(lessonId);
                if (ok && LessonTypeList.SelectedValue == "INTERACTIVE_CONTENT")
                    SaveInteractiveEditor(lessonId);
                ShowMessage(ok ? "Đã lưu bài học." : "Không thể lưu bài học.", ok);
                if (ok)
                {
                    ResetLessonForm();
                    LoadCourse();
                }
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu bài học thất bại.", ex);
                ShowMessage(ex.Message, false);
                LessonModalOpenValue.Value = "1";
                LoadQuestionBank();
            }
        }

        protected void CancelChapterButton_Click(object sender, EventArgs e)
        {
            ResetChapterForm();
            LoadCourse();
        }

        protected void CancelLessonButton_Click(object sender, EventArgs e)
        {
            ResetLessonForm();
            LoadCourse();
        }

        protected void ContentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HandleChapterCommand(e.CommandName, Convert.ToString(e.CommandArgument));
        }

        protected void ChapterRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HandleChapterCommand(e.CommandName, Convert.ToString(e.CommandArgument));
        }

        protected void ChapterRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (
                e.Item.ItemType != ListItemType.Item
                && e.Item.ItemType != ListItemType.AlternatingItem
            )
                return;
            RegisterAsync(e.Item.FindControl("ChapterEditTreeButton"));
        }

        private void HandleChapterCommand(string commandName, string commandArgument)
        {
            try
            {
                long id = ParseId(commandArgument);
                if (id <= 0)
                    return;
                EnsureChapterInCourse(id);
                if (commandName == "EditItem")
                {
                    LoadChapterForm(id);
                    ContentEditorModalUpdatePanel.Update();
                }
                else if (commandName == "DeleteItem")
                {
                    bool ok = ServiceRegistry.Content.ExecNonQuery(
                        "ChapterDelete",
                        Values(
                            "Id",
                            id,
                            "ActorId",
                            CurrentUser.UserID,
                            "IsAdmin",
                            CurrentUser.IsAdmin
                        )
                    );
                    ShowMessage(
                        ok ? "Đã xóa chương và các bài học thuộc chương." : "Không thể xóa chương.",
                        ok
                    );
                    if (ok)
                    {
                        ResetChapterForm();
                        ResetLessonForm();
                        LoadCourse();
                    }
                }
                else if (commandName == "MoveUp" || commandName == "MoveDown")
                    ReorderChapter(id, commandName == "MoveUp" ? -1 : 1);
            }
            catch (Exception ex)
            {
                WebLog.Error("Thao tác chương thất bại.", ex);
                ShowMessage(ex.Message, false);
                LoadCourse();
            }
        }

        protected void LessonGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HandleLessonCommand(e.CommandName, Convert.ToString(e.CommandArgument));
        }

        protected void LessonRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HandleLessonCommand(e.CommandName, Convert.ToString(e.CommandArgument));
        }

        protected void LessonRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (
                e.Item.ItemType != ListItemType.Item
                && e.Item.ItemType != ListItemType.AlternatingItem
            )
                return;
            RegisterAsync(e.Item.FindControl("LessonEditTreeButton"));
            RegisterAsync(e.Item.FindControl("VideoPickerTreeButton"));
        }

        private void HandleLessonCommand(string commandName, string commandArgument)
        {
            try
            {
                long id = ParseId(commandArgument);
                if (id <= 0)
                    return;
                EnsureLessonInCourse(id);
                if (commandName == "EditItem")
                {
                    LoadLessonForm(id);
                    ContentEditorModalUpdatePanel.Update();
                }
                else if (commandName == "OpenVideoPicker")
                {
                    OpenVideoPicker(id);
                    VideoPickerUpdatePanel.Update();
                }
                else if (commandName == "DeleteItem")
                {
                    bool ok = ServiceRegistry.Content.ExecNonQuery(
                        "LessonDelete",
                        Values(
                            "Id",
                            id,
                            "ActorId",
                            CurrentUser.UserID,
                            "IsAdmin",
                            CurrentUser.IsAdmin
                        )
                    );
                    ShowMessage(ok ? "Đã xóa bài học." : "Không thể xóa bài học.", ok);
                    if (ok)
                    {
                        ResetLessonForm();
                        LoadCourse();
                    }
                }
                else if (commandName == "MoveUp" || commandName == "MoveDown")
                    ReorderLesson(id, commandName == "MoveUp" ? -1 : 1);
            }
            catch (Exception ex)
            {
                WebLog.Error("Thao tác bài học thất bại.", ex);
                ShowMessage(ex.Message, false);
                LoadCourse();
            }
        }

        private void LoadChapterForm(long id)
        {
            DataRow row = FindRow(GetCourseTable(0), id);
            if (row == null)
                throw new InvalidOperationException(
                    "Không tìm thấy chương trong khóa học hiện tại."
                );
            ChapterIdValue.Value = id.ToString();
            ChapterTitleText.Text = WebData.Text(row, "Title");
            ChapterDescriptionText.Text = WebData.Text(row, "Description");
            ChapterSortOrderText.Text = WebData.Text(row, "SortOrder");
            SetSelected(ChapterStatusList, WebData.Text(row, "Status"));
            ChapterFormTitle.Text = "Sửa chương";
            AddChapterButton.Text = "Cập nhật";
            CancelChapterButton.Visible = true;
            ChapterModalOpenValue.Value = "1";
            LoadCourse();
        }

        private void LoadLessonForm(long id)
        {
            DataTable detail = ServiceRegistry.Content.GetDataTable(
                "LessonGet",
                Values("Id", id, "ActorId", CurrentUser.UserID, "IsAdmin", CurrentUser.IsAdmin)
            );
            if (detail == null || detail.Rows.Count == 0)
                throw new InvalidOperationException("Không tìm thấy bài học.");
            DataRow row = detail.Rows[0];
            LessonIdValue.Value = id.ToString();
            LessonChapterIdText.Text = WebData.Text(row, "ChapterId");
            LessonTitleText.Text = WebData.Text(row, "Title");
            LessonDescriptionText.Text = WebData.Text(row, "Description");
            SetSelected(LessonTypeList, WebData.Text(row, "LessonType"));
            LessonDurationText.Text = WebData.Text(row, "DurationSeconds");
            LessonSortOrderText.Text = WebData.Text(row, "SortOrder");
            LessonPassingScoreText.Text = DefaultText(row, "PassingScore", "50");
            LessonContentText.Text = WebData.Text(row, "ContentHtml");
            LessonDocumentUrlText.Text = WebData.Text(row, "DocumentUrl");
            LessonAssignmentFolderText.Text = WebData.Text(row, "AssignmentFolderName");
            LessonAssignmentStartText.Text = DateText(row, "AssignmentStartAt");
            LessonDueAtText.Text = DateText(row, "DueAt");
            LessonMaxScoreText.Text = DefaultText(row, "AssignmentMaxScore", "100");
            LessonMaxAttemptsText.Text = DefaultText(row, "MaxSubmissionAttempts", "3");
            LessonMaxFileSizeText.Text = DefaultText(row, "MaxSubmissionFileSizeMB", "50");
            LessonRequiredCheck.Checked = Bool(row, "IsRequired", true);
            LessonAllowLateCheck.Checked = Bool(row, "AllowLateSubmission", false);
            SetSelected(LessonStatusList, WebData.Text(row, "Status"));
            if (string.IsNullOrWhiteSpace(QuestionBankJsonValue.Value))
                LoadQuestionBank();
            if (LessonTypeList.SelectedValue == "QUIZ")
                LoadQuizEditor(id);
            else if (LessonTypeList.SelectedValue == "INTERACTIVE_CONTENT")
                LoadInteractiveEditor(id);
            else
            {
                QuizSelectedJsonValue.Value = "[]";
                InteractiveMappingsJsonValue.Value = "[]";
                InteractiveOriginalIdsValue.Value = "[]";
            }
            LessonChapterIdText.Enabled = false;
            LessonFormTitle.Text = "Sửa bài học";
            AddLessonButton.Text = "Cập nhật";
            CancelLessonButton.Visible = true;
            LessonModalOpenValue.Value = "1";
            LoadCourse();
        }

        private void ReorderChapter(long id, int direction)
        {
            DataRow[] rows = GetCourseTable(0).Select(string.Empty, "SortOrder, Id");
            int index = IndexOf(rows, id),
                target = index + direction;
            if (index < 0 || target < 0 || target >= rows.Length)
            {
                ShowMessage("Chương đã ở vị trí đầu/cuối.", false);
                LoadCourse();
                return;
            }
            DataRow temp = rows[index];
            rows[index] = rows[target];
            rows[target] = temp;
            for (int i = 0; i < rows.Length; i++)
                ServiceRegistry.Content.ExecNonQuery(
                    "ChapterReorder",
                    Values(
                        "Id",
                        WebData.Long(rows[i], "Id"),
                        "SortOrder",
                        i + 1,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
            ShowMessage("Đã sắp xếp chương.", true);
            LoadCourse();
        }

        private void ReorderLesson(long id, int direction)
        {
            DataTable lessons = GetCourseTable(1);
            DataRow source = FindRow(lessons, id);
            if (source == null)
                throw new InvalidOperationException("Không tìm thấy bài học.");
            long chapterId = WebData.Long(source, "ChapterId");
            DataRow[] rows = lessons.Select("ChapterId = " + chapterId, "SortOrder, Id");
            int index = IndexOf(rows, id),
                target = index + direction;
            if (index < 0 || target < 0 || target >= rows.Length)
            {
                ShowMessage("Bài học đã ở vị trí đầu/cuối của chương.", false);
                LoadCourse();
                return;
            }
            DataRow temp = rows[index];
            rows[index] = rows[target];
            rows[target] = temp;
            for (int i = 0; i < rows.Length; i++)
                ServiceRegistry.Content.ExecNonQuery(
                    "LessonReorder",
                    Values(
                        "Id",
                        WebData.Long(rows[i], "Id"),
                        "SortOrder",
                        i + 1,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
            ShowMessage("Đã sắp xếp bài học.", true);
            LoadCourse();
        }

        private void OpenVideoPicker(long lessonId)
        {
            VideoTargetLessonValue.Value = lessonId.ToString();
            VideoSearchText.Text = string.Empty;
            VideoPickerPanel.Visible = true;
            BindVideoAssets();
        }

        private void BindVideoAssets()
        {
            DataTable table = ServiceRegistry.Content.GetDataTable(
                "VideoLibraryList",
                Values(
                    "Search",
                    VideoSearchText.Text.Trim(),
                    "Access",
                    "ALL",
                    "Source",
                    "LOCAL",
                    "Usage",
                    "ALL",
                    "Status",
                    "ACTIVE",
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            VideoAssetsRepeater.DataSource = table;
            VideoAssetsRepeater.DataBind();
            VideoPickerEmptyText.Visible = table == null || table.Rows.Count == 0;
        }

        protected void SearchVideosButton_Click(object sender, EventArgs e)
        {
            try
            {
                VideoPickerPanel.Visible = true;
                BindVideoAssets();
            }
            catch (Exception ex)
            {
                WebLog.Error("Tìm video thất bại.", ex);
                ShowMessage(ex.Message, false);
                VideoPickerPanel.Visible = true;
            }
        }

        protected void CloseVideoPickerButton_Click(object sender, EventArgs e)
        {
            VideoPickerPanel.Visible = false;
            VideoTargetLessonValue.Value = string.Empty;
            VideoSearchText.Text = string.Empty;
        }

        protected void VideoAssetsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "AttachVideo")
                return;
            try
            {
                long lessonId = ParseId(VideoTargetLessonValue.Value),
                    videoId = ParseId(Convert.ToString(e.CommandArgument));
                if (lessonId <= 0 || videoId <= 0)
                    throw new ArgumentException("Video hoặc bài học không hợp lệ.");
                EnsureLessonInCourse(lessonId);
                DataTable attached = ServiceRegistry.Content.GetDataTable(
                    "VideoAttach",
                    Values(
                        "LessonId",
                        lessonId,
                        "VideoId",
                        videoId,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
                bool ok = attached != null && attached.Rows.Count > 0;
                ShowMessage(
                    ok
                        ? "Đã tham chiếu video cho bài học. Kết quả học vẫn được tách riêng theo bài."
                        : "Không thể gắn video.",
                    ok
                );
                if (ok)
                {
                    VideoPickerPanel.Visible = false;
                    VideoTargetLessonValue.Value = string.Empty;
                    LoadCourse();
                }
                else
                {
                    VideoPickerPanel.Visible = true;
                    BindVideoAssets();
                }
            }
            catch (Exception ex)
            {
                WebLog.Error("Gắn video vào bài học thất bại.", ex);
                ShowMessage(ex.Message, false);
                VideoPickerPanel.Visible = true;
                BindVideoAssets();
            }
        }

        protected void VideoAssetsRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (
                e.Item.ItemType != ListItemType.Item
                && e.Item.ItemType != ListItemType.AlternatingItem
            )
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control attach = e.Item.FindControl("AttachVideoButton");
            if (manager != null && attach != null)
                manager.RegisterPostBackControl(attach);
        }

        private void RegisterAsync(Control control)
        {
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            if (manager != null && control != null)
                manager.RegisterAsyncPostBackControl(control);
        }

        protected object LessonsForChapter(object chapterId)
        {
            long id = ToLong(chapterId);
            if (lessonTable == null || id <= 0 || !lessonTable.Columns.Contains("ChapterId"))
                return null;
            DataView view = new DataView(lessonTable);
            view.RowFilter = "ChapterId = " + id;
            view.Sort = "SortOrder, Id";
            return view;
        }

        protected int LessonCount(object chapterId)
        {
            long id = ToLong(chapterId);
            if (lessonTable == null || id <= 0 || !lessonTable.Columns.Contains("ChapterId"))
                return 0;
            return lessonTable.Select("ChapterId = " + id).Length;
        }

        protected string StatusLabel(object value)
        {
            return Convert.ToString(value) == "ACTIVE" ? "Hoạt động" : "Tạm ẩn";
        }

        protected string StatusBadgeClass(object value)
        {
            return Convert.ToString(value) == "ACTIVE"
                ? "badge-soft-success"
                : "badge-soft-warning";
        }

        protected bool IsVideoLesson(object value)
        {
            string type = Convert.ToString(value);
            return type == "VIDEO" || type == "INTERACTIVE_VIDEO";
        }

        protected string LessonTypeLabel(object value)
        {
            string type = Convert.ToString(value);
            if (type == "INTERACTIVE_VIDEO")
                return "Video tương tác";
            if (type == "VIDEO")
                return "Video";
            if (type == "QUIZ")
                return "Bài kiểm tra";
            if (type == "EDITOR")
                return "Bài học soạn thảo";
            if (type == "DOCUMENT")
                return "Tài liệu";
            if (type == "ASSIGNMENT")
                return "Bài tập nộp file";
            if (type == "INTERACTIVE_CONTENT")
                return "Bài học tương tác";
            return type;
        }

        protected string LessonTypeIcon(object value)
        {
            string type = Convert.ToString(value);
            if (type == "INTERACTIVE_VIDEO")
                return "bi-play-btn";
            if (type == "VIDEO")
                return "bi-play-circle";
            if (type == "QUIZ")
                return "bi-ui-checks-grid";
            if (type == "EDITOR")
                return "bi-pencil-square";
            if (type == "DOCUMENT")
                return "bi-file-earmark-text";
            if (type == "ASSIGNMENT")
                return "bi-folder-check";
            if (type == "INTERACTIVE_CONTENT")
                return "bi-puzzle";
            return "bi-journal-text";
        }

        protected string LessonTypeClass(object value)
        {
            string type = Convert.ToString(value).ToLowerInvariant().Replace('_', '-');
            return "type-" + type;
        }

        protected string FormatDuration(object value)
        {
            int seconds = ToInt(value);
            if (seconds < 0)
                seconds = 0;
            return (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }

        protected string VideoTitleSuffix(object dataItem)
        {
            object value = ItemValue(dataItem, "VideoTitle");
            string title =
                value == null || value == DBNull.Value ? string.Empty : Convert.ToString(value);
            return string.IsNullOrWhiteSpace(title)
                ? string.Empty
                : " • " + Server.HtmlEncode(title);
        }

        protected bool HasEditableVideo(object dataItem)
        {
            long videoId = ItemLong(dataItem, "VideoId", "VideoID", "FirstVideoId");
            if (videoId <= 0)
                return false;
            object canEdit = ItemValue(dataItem, "CanEditVideo");
            return canEdit == null || canEdit == DBNull.Value || Convert.ToBoolean(canEdit);
        }

        protected string VideoEditorUrl(object dataItem)
        {
            long videoId = ItemLong(dataItem, "VideoId", "VideoID", "FirstVideoId");
            return videoId <= 0 ? string.Empty : ResolveUrl("~/cms/videos/" + videoId + "/editor");
        }

        protected long VideoVersionId(object dataItem)
        {
            return ItemLong(dataItem, "FirstVideoId", "VideoId", "VideoID");
        }

        protected string ItemText(object dataItem, string column)
        {
            object value = ItemValue(dataItem, column);
            return value == null || value == DBNull.Value
                ? string.Empty
                : Server.HtmlEncode(Convert.ToString(value));
        }

        private static object ItemValue(object dataItem, string column)
        {
            DataRowView view = dataItem as DataRowView;
            if (view != null && view.DataView.Table.Columns.Contains(column))
                return view[column];
            DataRow row = dataItem as DataRow;
            if (row != null && row.Table.Columns.Contains(column))
                return row[column];
            return null;
        }

        private static long ItemLong(object dataItem, params string[] columns)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                object value = ItemValue(dataItem, columns[i]);
                long result;
                if (
                    value != null
                    && value != DBNull.Value
                    && long.TryParse(Convert.ToString(value), out result)
                )
                    return result;
            }
            return 0;
        }

        private static long ToLong(object value)
        {
            long result;
            return long.TryParse(Convert.ToString(value), out result) ? result : 0;
        }

        private static int ToInt(object value)
        {
            int result;
            return int.TryParse(Convert.ToString(value), out result) ? result : 0;
        }

        private static JavaScriptSerializer Json()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 2097152;
            return serializer;
        }

        private static List<Dictionary<string, object>> ParseDictionaryList(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return new List<Dictionary<string, object>>();
            try
            {
                return Json().Deserialize<List<Dictionary<string, object>>>(json)
                    ?? new List<Dictionary<string, object>>();
            }
            catch (Exception)
            {
                throw new ArgumentException("Dữ liệu cấu hình câu hỏi không hợp lệ.");
            }
        }

        private static List<long> ParseLongList(string json)
        {
            List<long> result = new List<long>();
            if (string.IsNullOrWhiteSpace(json))
                return result;
            try
            {
                List<object> values = Json().Deserialize<List<object>>(json);
                if (values != null)
                    foreach (object value in values)
                    {
                        long id = ToLong(value);
                        if (id > 0 && !result.Contains(id))
                            result.Add(id);
                    }
                return result;
            }
            catch (Exception)
            {
                throw new ArgumentException("Danh sách định danh câu hỏi không hợp lệ.");
            }
        }

        private static object DictionaryValue(
            IDictionary<string, object> values,
            params string[] keys
        )
        {
            if (values == null)
                return null;
            foreach (string key in keys)
            {
                object result;
                if (values.TryGetValue(key, out result))
                    return result;
                foreach (KeyValuePair<string, object> pair in values)
                    if (string.Equals(pair.Key, key, StringComparison.OrdinalIgnoreCase))
                        return pair.Value;
            }
            return null;
        }

        private static long DictionaryLong(IDictionary<string, object> values, params string[] keys)
        {
            return ToLong(DictionaryValue(values, keys));
        }

        private static int DictionaryInt(
            IDictionary<string, object> values,
            int defaultValue,
            params string[] keys
        )
        {
            int result;
            return int.TryParse(Convert.ToString(DictionaryValue(values, keys)), out result)
                ? result
                : defaultValue;
        }

        private static decimal DictionaryDecimal(
            IDictionary<string, object> values,
            params string[] keys
        )
        {
            decimal result;
            return decimal.TryParse(Convert.ToString(DictionaryValue(values, keys)), out result)
                ? result
                : 0;
        }

        private static bool DictionaryBool(
            IDictionary<string, object> values,
            bool defaultValue,
            params string[] keys
        )
        {
            object value = DictionaryValue(values, keys);
            bool result;
            if (value == null || value == DBNull.Value)
                return defaultValue;
            if (bool.TryParse(Convert.ToString(value), out result))
                return result;
            int number;
            return int.TryParse(Convert.ToString(value), out number) ? number != 0 : defaultValue;
        }

        private static long FirstLong(DataRow row, params string[] columns)
        {
            return WebData.Long(row, columns);
        }

        private static decimal DecimalValue(DataRow row, string column, decimal defaultValue)
        {
            decimal result;
            return decimal.TryParse(WebData.Text(row, column), out result) ? result : defaultValue;
        }

        private static int IntValue(DataRow row, string column, int defaultValue)
        {
            int result;
            return int.TryParse(WebData.Text(row, column), out result) ? result : defaultValue;
        }

        private DataSet GetCourseContent()
        {
            return ServiceRegistry.Courses.GetDataSet(
                "Content",
                Values(
                    "CourseId",
                    CourseId,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
        }

        private DataTable GetCourseTable(int index)
        {
            DataSet content = GetCourseContent();
            if (content == null || content.Tables.Count <= index)
                throw new InvalidOperationException("Không thể nạp nội dung khóa học.");
            return content.Tables[index];
        }

        private void EnsureChapterInCourse(long id)
        {
            if (FindRow(GetCourseTable(0), id) == null)
                throw new InvalidOperationException("Chương không thuộc khóa học hiện tại.");
        }

        private void EnsureLessonInCourse(long id)
        {
            if (FindRow(GetCourseTable(1), id) == null)
                throw new InvalidOperationException("Bài học không thuộc khóa học hiện tại.");
        }

        private static DataRow FindRow(DataTable table, long id)
        {
            if (table == null)
                return null;
            foreach (DataRow row in table.Rows)
                if (WebData.Long(row, "Id") == id)
                    return row;
            return null;
        }

        private static int IndexOf(DataRow[] rows, long id)
        {
            for (int i = 0; i < rows.Length; i++)
                if (WebData.Long(rows[i], "Id") == id)
                    return i;
            return -1;
        }

        private void ResetChapterForm()
        {
            ChapterIdValue.Value = string.Empty;
            ChapterModalOpenValue.Value = string.Empty;
            ChapterTitleText.Text = string.Empty;
            ChapterDescriptionText.Text = string.Empty;
            ChapterSortOrderText.Text = "1";
            ChapterStatusList.SelectedValue = "ACTIVE";
            ChapterFormTitle.Text = "Thêm chương";
            AddChapterButton.Text = "Lưu chương";
            CancelChapterButton.Visible = false;
        }

        private void ResetLessonForm()
        {
            LessonIdValue.Value = string.Empty;
            LessonModalOpenValue.Value = string.Empty;
            LessonChapterIdText.Enabled = true;
            LessonChapterIdText.Text = string.Empty;
            LessonTitleText.Text = string.Empty;
            LessonDescriptionText.Text = string.Empty;
            LessonDurationText.Text = "0";
            LessonSortOrderText.Text = "1";
            LessonPassingScoreText.Text = "50";
            LessonContentText.Text = string.Empty;
            LessonDocumentUrlText.Text = string.Empty;
            LessonAssignmentFolderText.Text = string.Empty;
            LessonAssignmentStartText.Text = string.Empty;
            LessonDueAtText.Text = string.Empty;
            LessonMaxScoreText.Text = "100";
            LessonMaxAttemptsText.Text = "3";
            LessonMaxFileSizeText.Text = "50";
            LessonRequiredCheck.Checked = true;
            LessonAllowLateCheck.Checked = false;
            LessonTypeList.SelectedValue = "INTERACTIVE_VIDEO";
            LessonStatusList.SelectedValue = "ACTIVE";
            LessonFormTitle.Text = "Thêm bài học";
            AddLessonButton.Text = "Lưu bài học";
            CancelLessonButton.Visible = false;
            QuizPassingScoreText.Text = "50";
            QuizTimeLimitText.Text = "30";
            QuizMaxAttemptsText.Text = "1";
            QuizShuffleCheck.Checked = false;
            QuizSelectedJsonValue.Value = "[]";
            InteractiveCompletionList.SelectedValue = "REQUIRED_QUESTIONS";
            InteractivePassingScoreText.Text = "70";
            InteractiveRequireReadingCheck.Checked = true;
            InteractiveShowResultCheck.Checked = true;
            InteractiveShowScoreCheck.Checked = true;
            InteractiveMappingsJsonValue.Value = "[]";
            InteractiveOriginalIdsValue.Value = "[]";
        }

        private IDictionary<string, object> Values(params object[] pairs)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(
                StringComparer.OrdinalIgnoreCase
            );
            for (int i = 0; i + 1 < pairs.Length; i += 2)
                values[Convert.ToString(pairs[i])] = pairs[i + 1];
            return values;
        }

        private static long? NullableLong(string value)
        {
            long result;
            return long.TryParse(value, out result) && result > 0 ? (long?)result : null;
        }

        private static long ParseId(string value)
        {
            long result;
            return long.TryParse(value, out result) && result > 0 ? result : 0;
        }

        private static object NullIfEmpty(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)null : value.Trim();
        }

        private static object NullableDate(string value)
        {
            DateTime result;
            if (string.IsNullOrWhiteSpace(value))
                return null;
            if (!DateTime.TryParse(value, out result))
                throw new ArgumentException("Ngày giờ phải đúng định dạng dd/MM/yyyy HH:mm.");
            return result;
        }

        private static string DateText(DataRow row, string column)
        {
            if (row == null || !row.Table.Columns.Contains(column) || row[column] == DBNull.Value)
                return string.Empty;
            return Convert.ToDateTime(row[column]).ToString("dd/MM/yyyy HH:mm");
        }

        private static string DefaultText(DataRow row, string column, string defaultValue)
        {
            string value = WebData.Text(row, column);
            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        private static bool Bool(DataRow row, string column, bool defaultValue)
        {
            if (row == null || !row.Table.Columns.Contains(column) || row[column] == DBNull.Value)
                return defaultValue;
            return Convert.ToBoolean(row[column]);
        }

        private static void SetSelected(DropDownList list, string value)
        {
            if (list.Items.FindByValue(value) != null)
                list.SelectedValue = value;
        }

        private void ShowMessage(string text, bool success)
        {
            MessageText.Text = Server.HtmlEncode(text);
            MessageText.CssClass =
                "alert " + (success ? "alert-success" : "alert-danger") + " status-message";
            MessageText.Visible = true;
        }
    }
}
