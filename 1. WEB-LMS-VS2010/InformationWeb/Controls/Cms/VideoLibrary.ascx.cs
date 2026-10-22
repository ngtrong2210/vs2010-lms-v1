using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class VideoLibrary : CmsControl
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
                LoadData();
        }

        private DataTable QueryVideos()
        {
            return ServiceRegistry.Content.GetDataTable(
                "VideoLibraryList",
                Values(
                    "Search",
                    SearchText.Text.Trim(),
                    "Access",
                    AccessFilter.SelectedValue,
                    "Source",
                    "LOCAL",
                    "Usage",
                    UsageFilter.SelectedValue,
                    "Status",
                    StatusFilter.SelectedValue,
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
        }

        private void LoadData()
        {
            try
            {
                DataTable table = QueryVideos();
                VideosRepeater.DataSource = table;
                VideosRepeater.DataBind();
                int count = table == null ? 0 : table.Rows.Count;
                ResultCountText.Text = count.ToString();
                EmptyText.Visible = count == 0;
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp thư viện video thất bại.", ex);
                VideosRepeater.DataSource = null;
                VideosRepeater.DataBind();
                ResultCountText.Text = "0";
                EmptyText.Visible = true;
                ShowMessage("Không thể nạp thư viện video: " + ex.Message, false);
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            CloseModals();
            LoadData();
        }

        protected void ClearFiltersButton_Click(object sender, EventArgs e)
        {
            SearchText.Text = string.Empty;
            AccessFilter.SelectedValue =
                UsageFilter.SelectedValue =
                StatusFilter.SelectedValue =
                    "ALL";
            CloseModals();
            LoadData();
        }

        protected void OpenCreateButton_Click(object sender, EventArgs e)
        {
            ResetVideoForm();
            VideoModalEyebrow.Text = "Video của tôi";
            VideoModalTitle.Text = "Thêm video vào thư viện";
            VideoModalDescription.Text =
                "Video mới được đặt ở chế độ riêng tư. Bạn có thể chia sẻ sau khi lưu.";
            SaveVideoButton.Text = "Lưu vào thư viện";
            VideoModalPanel.Visible = true;
            VideoModalUpdatePanel.Update();
        }

        protected void CloseVideoModalButton_Click(object sender, EventArgs e)
        {
            VideoModalPanel.Visible = false;
            ResetVideoForm();
        }

        protected void CloseShareButton_Click(object sender, EventArgs e)
        {
            ShareModalPanel.Visible = false;
            ShareAssetIdValue.Value = string.Empty;
            SharedTeachersList.Items.Clear();
        }

        protected void VideosRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            if (
                e.Item.ItemType != ListItemType.Item
                && e.Item.ItemType != ListItemType.AlternatingItem
            )
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            if (manager == null)
                return;
            Control edit = e.Item.FindControl("EditInfoButton"),
                share = e.Item.FindControl("ShareButton");
            if (edit != null)
                manager.RegisterAsyncPostBackControl(edit);
            if (share != null)
                manager.RegisterAsyncPostBackControl(share);
        }

        protected void VideosRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long assetId;
            if (!long.TryParse(Convert.ToString(e.CommandArgument), out assetId) || assetId <= 0)
                return;
            try
            {
                DataRow item = FindAsset(assetId);
                if (item == null)
                    throw new InvalidOperationException(
                        "Không tìm thấy video hoặc bạn không còn quyền truy cập."
                    );
                if (e.CommandName == "EditInfo")
                    OpenEdit(item);
                else if (e.CommandName == "Share")
                    OpenSharing(item);
                else if (e.CommandName == "Duplicate")
                    Duplicate(item);
                else if (e.CommandName == "DeleteVideo")
                    Delete(item);
                if (e.CommandName == "EditInfo" || e.CommandName == "Share")
                    VideoModalUpdatePanel.Update();
            }
            catch (System.Threading.ThreadAbortException)
            {
                throw;
            }
            catch (Exception ex)
            {
                WebLog.Error("Thao tác thư viện video thất bại.", ex);
                ShowMessage(ex.Message, false);
                LoadData();
            }
        }

        private void OpenEdit(DataRow row)
        {
            if (!Bool(row, "CanEdit"))
                throw new InvalidOperationException(
                    "Video đã có kết quả học tập hoặc bạn không có quyền sửa."
                );
            VideoAssetIdValue.Value = Text(row, "Id");
            VideoTitleText.Text = Text(row, "Title");
            DurationText.Text = Text(row, "DurationSeconds");
            VideoUrlValue.Value = VideoUrlText.Text = Text(row, "VideoUrl");
            ExistingOriginalFileValue.Value = Text(row, "OriginalFileName");
            ExistingMimeValue.Value = Text(row, "MimeType");
            ExistingFileSizeValue.Value = Text(row, "FileSize");
            SetSelected(VideoStatusList, Text(row, "Status"), "ACTIVE");
            UsageCountText.Text = Text(row, "UsageCount");
            SyncNoticePanel.Visible = true;
            VideoModalEyebrow.Text = "Cập nhật đồng bộ video";
            VideoModalTitle.Text = "Sửa video chưa có kết quả";
            VideoModalDescription.Text =
                "Video chưa có điểm hoặc câu trả lời nên có thể sửa trực tiếp. Tất cả bài học đang dùng sẽ được đồng bộ.";
            SaveVideoButton.Text = "Lưu và đồng bộ";
            RenderVideoPreview();
            VideoModalPanel.Visible = true;
        }

        protected void SaveVideoButton_Click(object sender, EventArgs e)
        {
            string physical = null;
            try
            {
                long assetId;
                long.TryParse(VideoAssetIdValue.Value, out assetId);
                int duration;
                if (!int.TryParse(DurationText.Text, out duration) || duration <= 0)
                    throw new ArgumentException("Thời lượng phải lớn hơn 0 giây.");
                string title = (VideoTitleText.Text ?? string.Empty).Trim();
                if (title.Length == 0 || title.Length > 500)
                    throw new ArgumentException("Vui lòng nhập tên video hợp lệ.");
                string videoUrl = VideoUrlValue.Value,
                    original = ExistingOriginalFileValue.Value,
                    mime = ExistingMimeValue.Value;
                long existingSize;
                long.TryParse(ExistingFileSizeValue.Value, out existingSize);
                object fileSize = existingSize > 0 ? (object)existingSize : DBNull.Value;
                if (VideoFile.HasFile)
                {
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
                        stored = Guid.NewGuid().ToString("N") + ext;
                    Directory.CreateDirectory(Server.MapPath(folder));
                    physical = Path.Combine(Server.MapPath(folder), stored);
                    VideoFile.SaveAs(physical);
                    videoUrl = VirtualPathUtility.ToAbsolute(folder + "/" + stored);
                    original = Path.GetFileName(VideoFile.FileName);
                    mime = VideoFile.PostedFile.ContentType;
                    fileSize = VideoFile.PostedFile.ContentLength;
                }
                ValidateLocalVideo(videoUrl);
                IDictionary<string, object> values = Values(
                    "Title",
                    title,
                    "SourceType",
                    "LOCAL",
                    "VideoUrl",
                    videoUrl,
                    "PosterUrl",
                    DBNull.Value,
                    "DurationSeconds",
                    duration,
                    "OriginalFileName",
                    Null(original),
                    "FileSize",
                    fileSize,
                    "MimeType",
                    Null(mime),
                    "ActorId",
                    CurrentUser.UserID
                );
                if (assetId > 0)
                {
                    DataRow current = FindAsset(assetId);
                    if (current == null || !Bool(current, "CanEdit"))
                        throw new InvalidOperationException(
                            "Video đã bị khóa hoặc bạn không có quyền sửa."
                        );
                    values["Id"] = assetId;
                    values["Status"] = VideoStatusList.SelectedValue;
                    values["LessonIdsJson"] = "[]";
                    values["ChangeSummary"] = "Cập nhật đồng bộ từ Web Forms";
                    values["IsAdmin"] = CurrentUser.IsAdmin;
                    DataTable updated = ServiceRegistry.Content.GetDataTable(
                        "VideoLibraryUpdate",
                        values
                    );
                    if (updated == null || updated.Rows.Count == 0)
                        throw new InvalidOperationException(
                            "Store không trả về kết quả cập nhật video."
                        );
                    ShowMessage("Đã cập nhật video và đồng bộ các bài học đang sử dụng.", true);
                }
                else
                {
                    DataTable created = ServiceRegistry.Content.GetDataTable(
                        "VideoLibraryCreate",
                        values
                    );
                    if (created == null || created.Rows.Count == 0)
                        throw new InvalidOperationException("Store không trả về ID video mới.");
                    ShowMessage(
                        "Đã thêm video riêng tư vào thư viện. Chỉ bạn nhìn thấy cho đến khi chia sẻ.",
                        true
                    );
                }
                physical = null;
                VideoModalPanel.Visible = false;
                ResetVideoForm();
                LoadData();
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(physical) && File.Exists(physical))
                    File.Delete(physical);
                WebLog.Error("Lưu video thư viện thất bại.", ex);
                ShowMessage(ex.Message, false);
                VideoModalPanel.Visible = true;
                RenderVideoPreview();
            }
        }

        private void OpenSharing(DataRow row)
        {
            if (!Bool(row, "CanShare"))
                throw new InvalidOperationException("Bạn không có quyền chia sẻ video này.");
            long assetId = Long(row, "Id");
            DataSet data = ServiceRegistry.Content.GetDataSet(
                "VideoSharingGet",
                Values("Id", assetId, "ActorId", CurrentUser.UserID, "IsAdmin", CurrentUser.IsAdmin)
            );
            if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
                throw new InvalidOperationException("Không thể nạp cấu hình chia sẻ.");
            ShareAssetIdValue.Value = assetId.ToString();
            ShareVideoTitleText.Text = Server.HtmlEncode(Text(row, "Title"));
            SetSelected(ShareScopeList, Text(data.Tables[0].Rows[0], "ShareScope"), "PRIVATE");
            SharedTeachersList.Items.Clear();
            if (data.Tables.Count > 1)
                foreach (DataRow teacher in data.Tables[1].Rows)
                {
                    ListItem option = new ListItem(
                        Text(teacher, "FullName")
                            + " · "
                            + Text(teacher, "TeacherCode")
                            + " · "
                            + Text(teacher, "Email"),
                        Text(teacher, "Id")
                    );
                    option.Selected = Bool(teacher, "IsSelected");
                    SharedTeachersList.Items.Add(option);
                }
            ShareModalPanel.Visible = true;
        }

        protected void SaveSharingButton_Click(object sender, EventArgs e)
        {
            try
            {
                long assetId;
                if (!long.TryParse(ShareAssetIdValue.Value, out assetId) || assetId <= 0)
                    throw new InvalidOperationException("Video chia sẻ không hợp lệ.");
                DataRow row = FindAsset(assetId);
                if (row == null || !Bool(row, "CanShare"))
                    throw new InvalidOperationException("Bạn không có quyền chia sẻ video này.");
                List<long> ids = new List<long>();
                foreach (ListItem item in SharedTeachersList.Items)
                    if (item.Selected)
                    {
                        long id;
                        if (long.TryParse(item.Value, out id) && id > 0)
                            ids.Add(id);
                    }
                string scope = ShareScopeList.SelectedValue;
                if (scope == "SELECTED" && ids.Count == 0)
                    throw new ArgumentException("Vui lòng chọn ít nhất một giáo viên.");
                string json = new JavaScriptSerializer().Serialize(
                    scope == "SELECTED" ? ids : new List<long>()
                );
                bool ok = ServiceRegistry.Content.ExecNonQuery(
                    "VideoSharingSave",
                    Values(
                        "Id",
                        assetId,
                        "ShareScope",
                        scope,
                        "TeacherIdsJson",
                        json,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
                if (!ok)
                    throw new InvalidOperationException("Không thể lưu cấu hình chia sẻ.");
                ShareModalPanel.Visible = false;
                LoadData();
                ShowMessage(
                    scope == "PRIVATE" ? "Đã chuyển video về chế độ chỉ mình tôi."
                        : scope == "SCHOOL" ? "Đã chia sẻ video cho toàn bộ giáo viên trong trường."
                        : "Đã chia sẻ video cho " + ids.Count + " giáo viên.",
                    true
                );
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu chia sẻ video thất bại.", ex);
                ShowMessage(ex.Message, false);
                ShareModalPanel.Visible = true;
            }
        }

        private void Duplicate(DataRow row)
        {
            if (!Bool(row, "CanDuplicate"))
                throw new InvalidOperationException("Bạn không có quyền nhân bản video này.");
            DataTable result = ServiceRegistry.Content.GetDataTable(
                "VideoLibraryDuplicate",
                Values(
                    "Id",
                    Long(row, "Id"),
                    "Title",
                    Text(row, "Title") + " - Bản sao",
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (result == null || result.Rows.Count == 0)
                throw new InvalidOperationException("Store không trả về ID video nhân bản.");
            long videoId = Convert.ToInt64(result.Rows[0][0]);
            Response.Redirect(ResolveUrl("~/cms/videos/" + videoId + "/editor"), true);
        }

        private void Delete(DataRow row)
        {
            if (!Bool(row, "CanDelete"))
                throw new InvalidOperationException("Video đang được sử dụng nên chưa thể xóa.");
            bool ok = ServiceRegistry.Content.ExecNonQuery(
                "VideoLibraryDelete",
                Values(
                    "Id",
                    Long(row, "Id"),
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (!ok)
                throw new InvalidOperationException("Không thể xóa video.");
            LoadData();
            ShowMessage("Đã xóa video chưa sử dụng khỏi thư viện.", true);
        }

        private DataRow FindAsset(long id)
        {
            DataTable table = ServiceRegistry.Content.GetDataTable(
                "VideoLibraryList",
                Values(
                    "Search",
                    string.Empty,
                    "Access",
                    "ALL",
                    "Source",
                    "LOCAL",
                    "Usage",
                    "ALL",
                    "Status",
                    "ALL",
                    "ActorId",
                    CurrentUser.UserID,
                    "IsAdmin",
                    CurrentUser.IsAdmin
                )
            );
            if (table != null)
                foreach (DataRow row in table.Rows)
                    if (Long(row, "Id") == id)
                        return row;
            return null;
        }

        private void ResetVideoForm()
        {
            VideoAssetIdValue.Value =
                VideoUrlValue.Value =
                ExistingFileSizeValue.Value =
                ExistingOriginalFileValue.Value =
                ExistingMimeValue.Value =
                    string.Empty;
            VideoTitleText.Text = VideoUrlText.Text = VideoPreviewHtml.Text = string.Empty;
            DurationText.Text = "60";
            VideoStatusList.SelectedValue = "ACTIVE";
            SyncNoticePanel.Visible = false;
        }

        private void RenderVideoPreview()
        {
            string url = VideoUrlValue.Value;
            VideoPreviewHtml.Text = string.IsNullOrWhiteSpace(url)
                ? string.Empty
                : "<div class=\"video-preview\"><video controls=\"controls\" preload=\"metadata\" src=\""
                    + HttpUtility.HtmlAttributeEncode(ResolveUrl("~" + url))
                    + "\"></video></div>";
        }

        private void CloseModals()
        {
            VideoModalPanel.Visible = false;
            ShareModalPanel.Visible = false;
        }

        private void ShowMessage(string text, bool success)
        {
            MessageText.Text = Server.HtmlEncode(text);
            MessageText.CssClass = "alert " + (success ? "alert-success" : "alert-danger");
            MessageText.Visible = true;
        }

        private void ValidateLocalVideo(string url)
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
                throw new ArgumentException("Vui lòng chọn file video hợp lệ.");
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

        private static long Long(DataRow row, string column)
        {
            long value;
            return long.TryParse(Text(row, column), out value) ? value : 0;
        }

        private static bool Bool(DataRow row, string column)
        {
            return row != null && row.Table.Columns.Contains(column) && ConvertBool(row[column]);
        }

        private static void SetSelected(ListControl list, string value, string fallback)
        {
            list.ClearSelection();
            ListItem item = list.Items.FindByValue(value);
            if (item == null)
                item = list.Items.FindByValue(fallback);
            if (item != null)
                item.Selected = true;
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

        protected bool ToBool(object value)
        {
            return ConvertBool(value);
        }

        private static bool ConvertBool(object value)
        {
            if (value == null || value == DBNull.Value)
                return false;
            bool result;
            if (bool.TryParse(Convert.ToString(value), out result))
                return result;
            int number;
            return int.TryParse(Convert.ToString(value), out number) && number != 0;
        }

        protected long ToLong(object value)
        {
            long result;
            return
                value != null
                && value != DBNull.Value
                && long.TryParse(Convert.ToString(value), out result)
                ? result
                : 0;
        }

        protected string EditorUrl(object value)
        {
            long id = ToLong(value);
            return id > 0 ? ResolveUrl("~/cms/videos/" + id + "/editor") : "#";
        }

        protected string SourceDescription(object original, object url)
        {
            string text = Convert.ToString(original);
            return string.IsNullOrWhiteSpace(text) ? Convert.ToString(url) : text;
        }

        protected string FormatDuration(object value)
        {
            int total;
            int.TryParse(Convert.ToString(value), out total);
            return (total / 60).ToString("00") + ":" + (total % 60).ToString("00");
        }

        protected string FormatDate(object value)
        {
            DateTime date;
            return value != null && DateTime.TryParse(Convert.ToString(value), out date)
                ? date.ToLocalTime().ToString("dd/MM/yyyy")
                : "—";
        }

        protected string AccessCss(object value)
        {
            return "access-badge access-" + Convert.ToString(value).ToLowerInvariant();
        }

        protected string AccessIcon(object value)
        {
            string type = Convert.ToString(value);
            return "bi "
                + (
                    type == "OWNER" ? "bi-lock"
                    : type == "SCHOOL" ? "bi-building"
                    : type == "SHARED" ? "bi-person-check"
                    : "bi-shield-check"
                );
        }

        protected string AccessLabel(object access, object scope, object count)
        {
            string type = Convert.ToString(access),
                share = Convert.ToString(scope);
            if (type == "OWNER")
                return share == "SCHOOL" ? "Tôi · Toàn trường"
                    : share == "SELECTED" ? "Tôi · " + Convert.ToString(count) + " giáo viên"
                    : "Chỉ mình tôi";
            return type == "SCHOOL" ? "Toàn trường"
                : type == "SHARED" ? "Chia sẻ cho tôi"
                : "Quản trị viên";
        }

        protected string ThumbnailStyle(object poster, int index)
        {
            string url = Convert.ToString(poster);
            if (string.IsNullOrWhiteSpace(url))
                url = ResolveUrl(
                    "~/assets/lms/eduvers/images/courses/course-list-img-"
                        + ((index % 5) + 1)
                        + ".jpg"
                );
            else if (url.StartsWith("/", StringComparison.Ordinal))
                url = ResolveUrl("~" + url);
            return "background-image:url('"
                + HttpUtility.HtmlAttributeEncode(url.Replace("'", "%27"))
                + "')";
        }
    }
}
