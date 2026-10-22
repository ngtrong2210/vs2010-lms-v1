using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class VideoEditor : CmsControl
    {
        private static readonly JavaScriptSerializer Json = new JavaScriptSerializer();
        private long VideoId
        {
            get { return RouteLong("videoId"); }
        }
        private bool CanEdit
        {
            get
            {
                return string.Equals(
                    CanEditValue.Value,
                    "true",
                    StringComparison.OrdinalIgnoreCase
                );
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (VideoId <= 0)
            {
                Response.Redirect(ResolveUrl("~/cms/videos"), true);
                return;
            }
            VideoFile.Attributes["data-submit"] = UploadVideoButton.ClientID;
            try
            {
                if (!IsPostBack)
                {
                    LoadVideo();
                    LoadQuestions(0);
                }
                LoadInteractions();
                ConfigurePermissions();
                RenderEditorPlayer();
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp trình biên tập video thất bại.", ex);
                ShowMessage(ex.Message, false);
            }
        }

        private void LoadVideo()
        {
            DataTable table = ServiceRegistry.Content.GetDataTable(
                "VideoGet",
                Values("Id", VideoId, "ActorId", CurrentUser.UserID, "IsAdmin", CurrentUser.IsAdmin)
            );
            if (table == null || table.Rows.Count == 0)
                throw new InvalidOperationException(
                    "Không tìm thấy video hoặc bạn không có quyền mở trình biên tập."
                );
            DataRow row = table.Rows[0];
            VideoAssetIdValue.Value = Text(row, "VideoAssetId");
            LessonIdValue.Value = Text(row, "LessonId");
            VideoSourceTypeValue.Value = NormalizeSource(Text(row, "SourceType"));
            VideoUrlValue.Value = Text(row, "VideoUrl");
            PosterUrlValue.Value = Text(row, "PosterUrl");
            DurationValue.Value = Text(row, "DurationSeconds");
            AllowSeekValue.Value = Bool(row, "AllowSeek").ToString().ToLowerInvariant();
            AllowSpeedValue.Value = BoolDefault(row, "AllowSpeed", true)
                .ToString()
                .ToLowerInvariant();
            RequiredWatchValue.Value = Text(row, "RequiredWatchPercent");
            VideoStatusValue.Value = Text(row, "Status");
            CanEditValue.Value = Bool(row, "CanEdit").ToString().ToLowerInvariant();
            EditorTitleText.Text = PreviewTitleText.Text = Server.HtmlEncode(Text(row, "Title"));
            EditorDurationText.Text = TimelineDurationText.Text = FormatDuration(
                DurationValue.Value
            );
        }

        private void ConfigurePermissions()
        {
            bool canEdit = CanEdit;
            EditLockPanel.Visible = !canEdit;
            SaveVideoButton.Visible = canEdit;
            UploadLabel.Visible = canEdit;
            AddAtCurrentButton.Visible = canEdit;
            InteractionEditorPanel.Enabled = canEdit;
            DuplicateVideoButton.Enabled = ToLong(VideoAssetIdValue.Value) > 0;
        }

        private DataTable LoadInteractions()
        {
            DataTable table = ServiceRegistry.Content.GetDataTable(
                "InteractionList",
                Values(
                    "VideoId",
                    VideoId,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            InteractionsRepeater.DataSource = table;
            InteractionsRepeater.DataBind();
            TimelineRepeater.DataSource = table;
            TimelineRepeater.DataBind();
            int count = table == null ? 0 : table.Rows.Count;
            InteractionCountText.Text = count.ToString();
            InteractionEmptyText.Visible = count == 0;
            InteractionsJsonValue.Value = SerializeInteractions(table);
            return table;
        }

        private void LoadQuestions(long selectedId)
        {
            DataTable table = ServiceRegistry.Questions.GetDataTable(
                "List",
                Values(
                    "Search",
                    QuestionSearchText.Text.Trim(),
                    "Type",
                    Null(QuestionTypeFilter.SelectedValue),
                    "Page",
                    1,
                    "PageSize",
                    50
                )
            );
            QuestionList.Items.Clear();
            if (table != null)
                foreach (DataRow row in table.Rows)
                {
                    long id = LongAny(row, "Id", "QuestionID");
                    if (id <= 0)
                        continue;
                    ListItem item = new ListItem(
                        TextAny(row, "QuestionText", "Title"),
                        id.ToString()
                    );
                    if (id == selectedId)
                        item.Selected = true;
                    QuestionList.Items.Add(item);
                }
        }

        protected void SearchQuestionButton_Click(object sender, EventArgs e)
        {
            long selected = ToLong(QuestionList.SelectedValue);
            LoadQuestions(selected);
            InteractionEditorPanel.Visible = true;
        }

        private void RenderEditorPlayer()
        {
            string url = VideoUrlValue.Value,
                source = NormalizeSource(VideoSourceTypeValue.Value);
            SourceBadgeText.Text = source == "YOUTUBE" ? "Nguồn YouTube" : "Video tải lên";
            editorSourceBadge.Attributes["class"] =
                "editor-source-badge " + source.ToLowerInvariant();
            if (string.IsNullOrWhiteSpace(url))
            {
                EditorPlayerHtml.Text =
                    "<div class=\"video-empty\"><i class=\"bi bi-cloud-arrow-up\"></i><strong>Chưa có video trong project</strong><span>Chọn file MP4, WebM, OGV hoặc MOV để upload.</span></div>";
                return;
            }
            if (source == "YOUTUBE")
                EditorPlayerHtml.Text =
                    "<div class=\"youtube-player-shell\"><div id=\"videoEditorYoutube\" data-youtube-id=\""
                    + A(YouTubeId(url))
                    + "\"></div></div>";
            else
                EditorPlayerHtml.Text =
                    "<video id=\"videoEditorPlayer\" src=\""
                    + A(ResolveAsset(url))
                    + "\" poster=\""
                    + A(ResolveAsset(PosterUrlValue.Value))
                    + "\" controls=\"controls\" preload=\"metadata\"></video>";
        }

        protected void UploadVideoButton_Click(object sender, EventArgs e)
        {
            string physical = null;
            try
            {
                EnsureEditable();
                if (!VideoFile.HasFile)
                    return;
                string ext = Path.GetExtension(VideoFile.FileName).ToLowerInvariant();
                if (
                    ext != ".mp4"
                    && ext != ".webm"
                    && ext != ".ogv"
                    && ext != ".ogg"
                    && ext != ".mov"
                )
                    throw new ArgumentException("Chỉ hỗ trợ MP4, WebM, OGV hoặc MOV.");
                int maxMb;
                if (
                    !int.TryParse(
                        ConfigurationManager.AppSettings["Media.MaxVideoFileSizeMB"],
                        out maxMb
                    )
                )
                    maxMb = 500;
                if (
                    VideoFile.PostedFile.ContentLength <= 0
                    || VideoFile.PostedFile.ContentLength > maxMb * 1024L * 1024L
                )
                    throw new ArgumentException("File video vượt quá " + maxMb + " MB.");
                string folder = "~/Media/Video/" + DateTime.UtcNow.ToString("yyyy/MM"),
                    name = Guid.NewGuid().ToString("N") + ext;
                Directory.CreateDirectory(Server.MapPath(folder));
                physical = Path.Combine(Server.MapPath(folder), name);
                VideoFile.SaveAs(physical);
                VideoUrlValue.Value = VirtualPathUtility.ToAbsolute(folder + "/" + name);
                VideoSourceTypeValue.Value = "LOCAL";
                RenderEditorPlayer();
                ShowMessage(
                    "Upload thành công. Hãy bấm “Lưu video” để ghi URL tương đối vào SQL.",
                    true
                );
                physical = null;
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(physical) && File.Exists(physical))
                    File.Delete(physical);
                WebLog.Error("Upload video thất bại.", ex);
                ShowMessage(ex.Message, false);
            }
        }

        protected void SaveVideoButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureEditable();
                int duration = ToInt(DurationValue.Value, 1);
                if (duration <= 0)
                    duration = 1;
                string source = NormalizeSource(VideoSourceTypeValue.Value);
                ValidateSource(source, VideoUrlValue.Value);
                DataTable result = ServiceRegistry.Content.GetDataTable(
                    "VideoUpdate",
                    Values(
                        "Id",
                        VideoId,
                        "LessonId",
                        ToLong(LessonIdValue.Value),
                        "Title",
                        HttpUtility.HtmlDecode(EditorTitleText.Text),
                        "SourceType",
                        source,
                        "VideoUrl",
                        Null(VideoUrlValue.Value),
                        "PosterUrl",
                        Null(PosterUrlValue.Value),
                        "DurationSeconds",
                        duration,
                        "AllowSeek",
                        ToBool(AllowSeekValue.Value),
                        "AllowSpeed",
                        ToBool(AllowSpeedValue.Value),
                        "RequiredWatchPercent",
                        ToDecimal(RequiredWatchValue.Value, 80),
                        "Status",
                        VideoStatusValue.Value,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
                if (result == null || result.Rows.Count == 0)
                    throw new InvalidOperationException("Store không trả về kết quả lưu video.");
                LoadVideo();
                RenderEditorPlayer();
                ShowMessage("Đã lưu video. SQL chỉ lưu URL tương đối " + VideoUrlValue.Value, true);
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu video thất bại.", ex);
                ShowMessage(ex.Message, false);
            }
        }

        protected void DuplicateVideoButton_Click(object sender, EventArgs e)
        {
            try
            {
                long assetId = ToLong(VideoAssetIdValue.Value);
                if (assetId <= 0)
                    throw new InvalidOperationException("Video chưa có tài nguyên để nhân bản.");
                DataTable result = ServiceRegistry.Content.GetDataTable(
                    "VideoLibraryDuplicate",
                    Values(
                        "Id",
                        assetId,
                        "Title",
                        HttpUtility.HtmlDecode(EditorTitleText.Text) + " - Bản sao",
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
                if (result == null || result.Rows.Count == 0)
                    throw new InvalidOperationException("Store không trả về ID video nhân bản.");
                Response.Redirect(
                    ResolveUrl("~/cms/videos/" + Convert.ToInt64(result.Rows[0][0]) + "/editor"),
                    true
                );
            }
            catch (System.Threading.ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                WebLog.Error("Nhân bản video thất bại.", ex);
                ShowMessage(ex.Message, false);
            }
        }

        protected void AddAtCurrentButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureEditable();
                ResetInteractionForm();
                InteractionTimeText.Text = Math.Max(
                        0,
                        Math.Min(
                            ToInt(CurrentTimeValue.Value, 0),
                            ToInt(DurationValue.Value, int.MaxValue)
                        )
                    )
                    .ToString();
                InteractionTimeLabel.Text = FormatDuration(InteractionTimeText.Text);
                LoadQuestions(0);
                if (QuestionList.Items.Count == 0)
                    throw new InvalidOperationException(
                        "Ngân hàng chưa có câu hỏi. Hãy tạo câu hỏi mới."
                    );
                InteractionEditorPanel.Visible = true;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, false);
            }
        }

        protected void InteractionsRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long id;
            if (!long.TryParse(Convert.ToString(e.CommandArgument), out id) || id <= 0)
                return;
            try
            {
                EnsureEditable();
                DataRow row = FindInteraction(id);
                if (row == null)
                    throw new InvalidOperationException("Không tìm thấy tương tác.");
                if (e.CommandName == "EditInteraction")
                    OpenInteraction(row);
                else if (e.CommandName == "RequestDelete")
                {
                    InteractionIdValue.Value = id.ToString();
                    DeleteConfirmPanel.Visible = true;
                }
                EditorModalUpdatePanel.Update();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, false);
            }
        }

        protected void InteractionsRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (
                e.Item.ItemType != ListItemType.Item
                && e.Item.ItemType != ListItemType.AlternatingItem
            )
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            if (manager == null)
                return;
            Control edit = e.Item.FindControl("EditInteractionButton"),
                delete = e.Item.FindControl("DeleteInteractionButton");
            if (edit != null)
                manager.RegisterAsyncPostBackControl(edit);
            if (delete != null)
                manager.RegisterAsyncPostBackControl(delete);
        }

        private void OpenInteraction(DataRow row)
        {
            long id = LongAny(row, "Id", "VideoInteractionID"),
                questionId = LongAny(row, "QuestionId", "QuestionID");
            InteractionIdValue.Value = id.ToString();
            InteractionTimeText.Text = Text(row, "TimeSeconds");
            InteractionScoreText.Text = Text(row, "Score");
            InteractionAttemptText.Text = Text(row, "AttemptLimit");
            SetSelected(InteractionStatusList, Text(row, "Status"), "ACTIVE");
            InteractionRequiredCheck.Checked = Bool(row, "Required");
            InteractionPauseCheck.Checked = Bool(row, "PauseVideo");
            InteractionSkipCheck.Checked = Bool(row, "AllowSkip");
            InteractionTimeLabel.Text = FormatDuration(InteractionTimeText.Text);
            LoadQuestions(questionId);
            InteractionEditorPanel.Visible = true;
            DeleteFromEditorButton.Visible = true;
        }

        protected void SaveInteractionButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureEditable();
                long id = ToLong(InteractionIdValue.Value),
                    questionId = ToLong(QuestionList.SelectedValue);
                int time = ToInt(InteractionTimeText.Text, -1),
                    attempts = ToInt(InteractionAttemptText.Text, 0);
                decimal score = ToDecimal(InteractionScoreText.Text, -1);
                if (
                    questionId <= 0
                    || time < 0
                    || time > ToInt(DurationValue.Value, int.MaxValue)
                    || attempts < 1
                    || score < 0
                )
                    throw new ArgumentException("Thông tin tương tác không hợp lệ.");
                IDictionary<string, object> values = Values(
                    "QuestionId",
                    questionId,
                    "TimeSeconds",
                    time,
                    "EndTimeSeconds",
                    DBNull.Value,
                    "InteractionType",
                    "QUESTION",
                    "Required",
                    InteractionRequiredCheck.Checked,
                    "PauseVideo",
                    InteractionPauseCheck.Checked,
                    "AllowSkip",
                    InteractionSkipCheck.Checked,
                    "Score",
                    score,
                    "AttemptLimit",
                    attempts,
                    "SortOrder",
                    NextSortOrder(time, id),
                    "Status",
                    InteractionStatusList.SelectedValue,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                );
                if (id > 0)
                {
                    EnsureInteraction(id);
                    values["Id"] = id;
                    if (!ServiceRegistry.Content.ExecNonQuery("InteractionUpdate", values))
                        throw new InvalidOperationException("Không thể cập nhật tương tác.");
                }
                else
                {
                    values["VideoId"] = VideoId;
                    DataTable result = ServiceRegistry.Content.GetDataTable(
                        "InteractionCreate",
                        values
                    );
                    if (result == null || result.Rows.Count == 0)
                        throw new InvalidOperationException("Không thể tạo tương tác.");
                }
                InteractionEditorPanel.Visible = false;
                ResetInteractionForm();
                LoadInteractions();
                ShowMessage("Đã lưu tương tác.", true);
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu tương tác thất bại.", ex);
                ShowMessage(ex.Message, false);
                InteractionEditorPanel.Visible = true;
            }
        }

        protected void CloseInteractionButton_Click(object sender, EventArgs e)
        {
            InteractionEditorPanel.Visible = false;
            ResetInteractionForm();
        }

        protected void DeleteFromEditorButton_Click(object sender, EventArgs e)
        {
            if (ToLong(InteractionIdValue.Value) > 0)
            {
                InteractionEditorPanel.Visible = false;
                DeleteConfirmPanel.Visible = true;
            }
            else
            {
                InteractionEditorPanel.Visible = false;
                ResetInteractionForm();
                ShowMessage("Đã bỏ câu hỏi chưa lưu khỏi danh sách.", true);
            }
        }

        protected void CancelDeleteButton_Click(object sender, EventArgs e)
        {
            DeleteConfirmPanel.Visible = false;
        }

        protected void ConfirmDeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureEditable();
                long id = ToLong(InteractionIdValue.Value);
                EnsureInteraction(id);
                if (
                    !ServiceRegistry.Content.ExecNonQuery(
                        "InteractionDelete",
                        Values(
                            "Id",
                            id,
                            "ActorId",
                            CurrentUser.UserID,
                            "IsAdmin",
                            CurrentUser.IsAdmin
                        )
                    )
                )
                    throw new InvalidOperationException("Không thể xóa tương tác.");
                DeleteConfirmPanel.Visible = false;
                InteractionEditorPanel.Visible = false;
                ResetInteractionForm();
                LoadInteractions();
                ShowMessage("Đã xóa tương tác khỏi timeline và Student Player.", true);
            }
            catch (Exception ex)
            {
                WebLog.Error("Xóa tương tác thất bại.", ex);
                ShowMessage(ex.Message, false);
                DeleteConfirmPanel.Visible = true;
            }
        }

        protected void OpenQuickQuestionButton_Click(object sender, EventArgs e)
        {
            EnsureEditable();
            QuickQuestionPanel.Visible = true;
            InteractionEditorPanel.Visible = false;
        }

        protected void CloseQuickQuestionButton_Click(object sender, EventArgs e)
        {
            QuickQuestionPanel.Visible = false;
            InteractionEditorPanel.Visible = true;
        }

        protected void SaveQuickQuestionButton_Click(object sender, EventArgs e)
        {
            try
            {
                EnsureEditable();
                decimal score = ToDecimal(QuickScoreText.Text, -1);
                if (score < 0)
                    throw new ArgumentException("Điểm mặc định không hợp lệ.");
                string type = QuickQuestionTypeList.SelectedValue;
                List<string> codes = new List<string>(),
                    texts = new List<string>(),
                    answerKeys = new List<string>();
                List<bool> correct = new List<bool>();
                if (type == "SHORT_ANSWER")
                {
                    if (!string.IsNullOrWhiteSpace(QuickAnswerText.Text))
                        answerKeys.Add(QuickAnswerText.Text.Trim());
                }
                else
                    foreach (string line in Lines(QuickOptionsText.Text))
                    {
                        string[] parts = line.Split(new char[] { '|' }, 3);
                        if (parts.Length < 2)
                            throw new ArgumentException(
                                "Phương án phải theo dạng MÃ|Nội dung|1 hoặc 0."
                            );
                        codes.Add(parts[0].Trim());
                        texts.Add(parts[1].Trim());
                        correct.Add(
                            parts.Length > 2
                                && (
                                    parts[2].Trim() == "1"
                                    || parts[2]
                                        .Trim()
                                        .Equals("true", StringComparison.OrdinalIgnoreCase)
                                )
                        );
                    }
                long questionId = ServiceRegistry.Questions.CreateQuestion(
                    type,
                    QuickQuestionText.Text,
                    null,
                    null,
                    QuickDifficultyList.SelectedValue,
                    score,
                    QuickShortModeList.SelectedValue,
                    "ACTIVE",
                    codes,
                    texts,
                    correct,
                    answerKeys,
                    new List<string>(),
                    new List<string>(),
                    CurrentUser.UserID
                );
                QuickQuestionPanel.Visible = false;
                QuestionTypeFilter.SelectedValue = type;
                QuestionSearchText.Text = string.Empty;
                LoadQuestions(questionId);
                InteractionEditorPanel.Visible = true;
                ShowMessage(
                    "Đã tạo câu hỏi mới trong ngân hàng và chọn cho tương tác hiện tại.",
                    true
                );
            }
            catch (Exception ex)
            {
                WebLog.Error("Tạo nhanh câu hỏi thất bại.", ex);
                ShowMessage(ex.Message, false);
                QuickQuestionPanel.Visible = true;
            }
        }

        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            DataTable table = LoadInteractions();
            PreviewTitleText.Text = EditorTitleText.Text;
            PreviewPlayerHtml.Text = BuildInteractivePlayer("preview", table);
            PreviewListHtml.Text = BuildPreviewList(table);
            PreviewPanel.Visible = true;
        }

        protected void ClosePreviewButton_Click(object sender, EventArgs e)
        {
            PreviewPanel.Visible = false;
        }

        private string BuildInteractivePlayer(string mode, DataTable table)
        {
            string url = VideoUrlValue.Value,
                source = NormalizeSource(VideoSourceTypeValue.Value),
                player;
            if (string.IsNullOrWhiteSpace(url))
                return "<div class=\"preview-empty\">Video chưa có file phát.</div>";
            if (source == "YOUTUBE")
                player =
                    "<div class=\"youtube-player-shell\"><div class=\"interactive-youtube\" data-youtube-id=\""
                    + A(YouTubeId(url))
                    + "\"></div></div>";
            else
                player =
                    "<video class=\"interactive-video-element\" controls=\"controls\" preload=\"metadata\" playsinline=\"playsinline\" src=\""
                    + A(ResolveAsset(url))
                    + "\"></video>";
            return "<div class=\"interactive-player"
                + (source == "YOUTUBE" ? " youtube-mode" : "")
                + "\" data-interactive-video=\"1\" data-mode=\""
                + mode
                + "\" data-video-id=\""
                + VideoId
                + "\" data-interactions-id=\""
                + InteractionsJsonValue.ClientID
                + "\" data-handler-url=\""
                + A(ResolveUrl("~/Handlers/Lms/Module.ashx"))
                + "\" data-duration=\""
                + A(DurationValue.Value)
                + "\"><div class=\"interactive-stage\">"
                + player
                + "</div><div class=\"interaction-timeline\"><div class=\"interaction-track seekable\" tabindex=\"0\"><span class=\"interaction-track-progress\"></span><span class=\"interaction-playhead\"></span></div><div class=\"timeline-current\"><i class=\"bi bi-clock\"></i><strong>00:00</strong></div></div></div>";
        }

        private string BuildPreviewList(DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
                return "<div class=\"text-secondary\">Video chưa có câu hỏi tương tác.</div>";
            StringBuilder html = new StringBuilder();
            foreach (DataRow row in table.Rows)
                html.Append("<div class=\"preview-question\"><span>")
                    .Append(H(FormatDuration(Text(row, "TimeSeconds"))))
                    .Append("</span><div><strong>")
                    .Append(H(Text(row, "QuestionText")))
                    .Append("</strong><small>")
                    .Append(Bool(row, "Required") ? "Bắt buộc" : "Tự chọn")
                    .Append(" • ")
                    .Append(H(Text(row, "Score")))
                    .Append(" điểm</small></div></div>");
            return html.ToString();
        }

        private DataRow FindInteraction(long id)
        {
            DataTable table = ServiceRegistry.Content.GetDataTable(
                "InteractionList",
                Values(
                    "VideoId",
                    VideoId,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (table != null)
                foreach (DataRow row in table.Rows)
                    if (LongAny(row, "Id", "VideoInteractionID") == id)
                        return row;
            return null;
        }

        private void EnsureInteraction(long id)
        {
            if (id <= 0 || FindInteraction(id) == null)
                throw new InvalidOperationException("Tương tác không thuộc video hiện tại.");
        }

        private void EnsureEditable()
        {
            if (!CanEdit)
                throw new InvalidOperationException(
                    "Video đã có kết quả học tập nên nội dung được khóa. Hãy nhân bản để tiếp tục chỉnh sửa."
                );
        }

        private int NextSortOrder(int time, long currentId)
        {
            DataTable table = ServiceRegistry.Content.GetDataTable(
                "InteractionList",
                Values(
                    "VideoId",
                    VideoId,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            int max = 0;
            if (table != null)
                foreach (DataRow row in table.Rows)
                    if (
                        ToInt(Text(row, "TimeSeconds"), -1) == time
                        && LongAny(row, "Id", "VideoInteractionID") != currentId
                    )
                        max = Math.Max(max, ToInt(Text(row, "SortOrder"), 0));
            return max + 1;
        }

        private void ResetInteractionForm()
        {
            InteractionIdValue.Value = string.Empty;
            InteractionTimeText.Text = "0";
            InteractionScoreText.Text = "10";
            InteractionAttemptText.Text = "1";
            InteractionStatusList.SelectedValue = "ACTIVE";
            InteractionRequiredCheck.Checked = true;
            InteractionPauseCheck.Checked = true;
            InteractionSkipCheck.Checked = false;
            DeleteFromEditorButton.Visible = false;
        }

        private string SerializeInteractions(DataTable table)
        {
            List<Dictionary<string, object>> items = new List<Dictionary<string, object>>();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    items.Add(
                        new Dictionary<string, object>
                        {
                            { "id", LongAny(row, "Id", "VideoInteractionID") },
                            { "questionId", LongAny(row, "QuestionId", "QuestionID") },
                            { "time", ToInt(Text(row, "TimeSeconds"), 0) },
                            { "label", Text(row, "QuestionText") },
                            { "description", Text(row, "Description") },
                            { "type", Text(row, "QuestionType") },
                            { "required", Bool(row, "Required") },
                            { "pauseVideo", Bool(row, "PauseVideo") },
                            { "allowSkip", Bool(row, "AllowSkip") },
                            { "score", ToDecimal(Text(row, "Score"), 0) },
                            { "attemptLimit", ToInt(Text(row, "AttemptLimit"), 1) },
                            { "status", Text(row, "Status") },
                            { "options", ParseJson(Text(row, "Options")) },
                        }
                    );
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

        private static IEnumerable<string> Lines(string value)
        {
            return (value ?? string.Empty)
                .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => x.Length > 0);
        }

        private void ValidateSource(string source, string url)
        {
            if (source == "LOCAL")
            {
                if (
                    string.IsNullOrWhiteSpace(url)
                    || !url.StartsWith("/Media/Video/", StringComparison.OrdinalIgnoreCase)
                    || url.Contains("..")
                    || url.Contains("\\")
                    || url.Contains("?")
                    || url.Contains("#")
                    || !File.Exists(Server.MapPath("~" + url))
                )
                    throw new ArgumentException("URL video local không hợp lệ.");
            }
            else if (string.IsNullOrWhiteSpace(YouTubeId(url)))
                throw new ArgumentException("URL YouTube không hợp lệ.");
        }

        private string ResolveAsset(string url)
        {
            return string.IsNullOrWhiteSpace(url) ? string.Empty
                : url.StartsWith("/", StringComparison.Ordinal) ? ResolveUrl("~" + url)
                : url;
        }

        private static string NormalizeSource(string source)
        {
            return string.Equals(source, "YOUTUBE", StringComparison.OrdinalIgnoreCase)
                ? "YOUTUBE"
                : "LOCAL";
        }

        private static string YouTubeId(string url)
        {
            Uri uri;
            if (!Uri.TryCreate(url, UriKind.Absolute, out uri) || uri.Scheme != Uri.UriSchemeHttps)
                return string.Empty;
            string host = uri.Host.ToLowerInvariant(),
                id = host.Contains("youtu.be")
                    ? uri.AbsolutePath.Trim('/')
                    : HttpUtility.ParseQueryString(uri.Query)["v"];
            if (
                string.IsNullOrWhiteSpace(id)
                && uri.AbsolutePath.IndexOf("/embed/", StringComparison.OrdinalIgnoreCase) >= 0
            )
                id = uri.AbsolutePath.Split('/').Last();
            return !string.IsNullOrWhiteSpace(id) && id.Length == 11 ? id : string.Empty;
        }

        private void ShowMessage(string text, bool success)
        {
            MessageText.Text = Server.HtmlEncode(text);
            MessageText.CssClass = "alert " + (success ? "alert-success" : "alert-danger");
            MessageText.Visible = true;
        }

        private static void SetSelected(ListControl list, string value, string fallback)
        {
            list.ClearSelection();
            ListItem item = list.Items.FindByValue(value) ?? list.Items.FindByValue(fallback);
            if (item != null)
                item.Selected = true;
        }

        private static object Null(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value.Trim();
        }

        private static string Text(DataRow row, string column)
        {
            return row != null && row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? Convert.ToString(row[column])
                : string.Empty;
        }

        private static string TextAny(DataRow row, params string[] columns)
        {
            foreach (string column in columns)
            {
                string value = Text(row, column);
                if (!string.IsNullOrWhiteSpace(value))
                    return value;
            }
            return string.Empty;
        }

        private static long LongAny(DataRow row, params string[] columns)
        {
            long value;
            foreach (string column in columns)
                if (long.TryParse(Text(row, column), out value))
                    return value;
            return 0;
        }

        private static bool Bool(DataRow row, string column)
        {
            return ToBool(Text(row, column));
        }

        private static bool BoolDefault(DataRow row, string column, bool fallback)
        {
            return row != null && row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? ToBool(row[column])
                : fallback;
        }

        private static bool ToBool(object value)
        {
            bool parsed;
            if (bool.TryParse(Convert.ToString(value), out parsed))
                return parsed;
            int number;
            return int.TryParse(Convert.ToString(value), out number) && number != 0;
        }

        private static long ToLong(object value)
        {
            long parsed;
            return long.TryParse(Convert.ToString(value), out parsed) ? parsed : 0;
        }

        private static int ToInt(object value, int fallback)
        {
            int parsed;
            return int.TryParse(Convert.ToString(value), out parsed) ? parsed : fallback;
        }

        private static decimal ToDecimal(object value, decimal fallback)
        {
            decimal parsed;
            return decimal.TryParse(Convert.ToString(value), out parsed) ? parsed : fallback;
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

        private static string H(string value)
        {
            return HttpUtility.HtmlEncode(value ?? string.Empty);
        }

        private static string A(string value)
        {
            return HttpUtility.HtmlAttributeEncode(value ?? string.Empty);
        }

        protected string FormatDuration(object value)
        {
            int total = Math.Max(0, ToInt(value, 0));
            return (total / 60).ToString("00") + ":" + (total % 60).ToString("00");
        }

        protected string QuestionTypeLabel(object value)
        {
            string type = Convert.ToString(value);
            return type == "SINGLE_CHOICE" ? "Một lựa chọn"
                : type == "MULTIPLE_CHOICE" ? "Nhiều lựa chọn"
                : type == "TRUE_FALSE" ? "Đúng / Sai"
                : type == "SHORT_ANSWER" ? "Trả lời ngắn"
                : type == "CLOZE_DRAG_DROP" ? "Kéo thả vào đoạn văn"
                : type;
        }

        protected string TimelinePosition(object value)
        {
            int duration = Math.Max(1, ToInt(DurationValue.Value, 1));
            decimal percent = Math.Min(100, Math.Max(0, ToDecimal(value, 0) * 100 / duration));
            return "left:"
                + percent.ToString(System.Globalization.CultureInfo.InvariantCulture)
                + "%";
        }
    }
}
