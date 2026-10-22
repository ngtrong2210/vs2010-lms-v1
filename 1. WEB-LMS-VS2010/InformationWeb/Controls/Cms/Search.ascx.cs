using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class Search : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Search; }
        }
        protected override string Operation
        {
            get { return "Search"; }
        }
        protected override string PageTitle
        {
            get { return "Tìm nhanh dữ liệu quản trị"; }
        }
        protected override string PageDescription
        {
            get { return "Tra cứu khóa học, bài học, video, câu hỏi và học viên từ một nơi."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values(
                "Search",
                SearchText.Text.Trim(),
                "ActorId",
                CurrentUser.UserID,
                "IsAdmin",
                CurrentUser.IsAdmin,
                "Limit",
                100
            );
        }

        protected override void LoadData()
        {
            if (!IsPostBack && string.IsNullOrWhiteSpace(SearchText.Text))
                SearchText.Text = System.Convert.ToString(Request.QueryString["q"]);
            string term = SearchText.Text.Trim();
            SearchValidationText.Visible = false;
            ErrorText.Visible = false;
            if (term.Length < 2)
            {
                SearchResultsPanel.Visible = false;
                SearchGuidePanel.Visible = true;
                SearchResultsRepeater.DataSource = null;
                SearchResultsRepeater.DataBind();
                if (IsPostBack || term.Length > 0)
                {
                    SearchValidationText.Text = Server.HtmlEncode(
                        "Vui lòng nhập ít nhất 2 ký tự để tìm kiếm."
                    );
                    SearchValidationText.Visible = true;
                }
                return;
            }
            try
            {
                DataTable table = Service.GetDataTable(Operation, ConvertToParams(Parameters()));
                SearchGuidePanel.Visible = false;
                SearchResultsPanel.Visible = true;
                SearchedTermText.Text = Server.HtmlEncode(term);
                int total = table == null ? 0 : table.Rows.Count;
                SearchTotalText.Text = total.ToString(CultureInfo.InvariantCulture);
                AllCountText.Text = total.ToString(CultureInfo.InvariantCulture);
                CourseCountText.Text = CountType(table, "COURSE")
                    .ToString(CultureInfo.InvariantCulture);
                LessonCountText.Text = CountType(table, "LESSON")
                    .ToString(CultureInfo.InvariantCulture);
                VideoCountText.Text = CountType(table, "VIDEO")
                    .ToString(CultureInfo.InvariantCulture);
                QuestionCountText.Text = CountType(table, "QUESTION")
                    .ToString(CultureInfo.InvariantCulture);
                StudentCountText.Text = CountType(table, "STUDENT")
                    .ToString(CultureInfo.InvariantCulture);
                SearchResultsRepeater.DataSource = table;
                SearchResultsRepeater.DataBind();
                NoSearchResultsPanel.Visible = total == 0;
            }
            catch (Exception ex)
            {
                WebLog.Error("Tìm kiếm toàn hệ thống thất bại.", ex);
                SearchGuidePanel.Visible = false;
                SearchResultsPanel.Visible = false;
                ErrorText.Text = Server.HtmlEncode("Không thể tìm kiếm dữ liệu lúc này.");
                ErrorText.Visible = true;
            }
        }

        protected string SearchTypeLabel(object value)
        {
            string type = Convert.ToString(value).ToUpperInvariant();
            if (type == "COURSE")
                return "Khóa học";
            if (type == "LESSON")
                return "Bài học";
            if (type == "VIDEO")
                return "Video";
            if (type == "QUESTION")
                return "Câu hỏi";
            if (type == "STUDENT")
                return "Học viên";
            return Server.HtmlEncode(type);
        }

        protected string SearchStatusLabel(object value)
        {
            string status = Convert.ToString(value).ToUpperInvariant();
            if (status == "ACTIVE")
                return "Hoạt động";
            if (status == "PUBLISHED")
                return "Đã xuất bản";
            if (status == "INACTIVE")
                return "Ngừng hoạt động";
            if (status == "LOCKED")
                return "Đã khóa";
            if (status == "ARCHIVED")
                return "Lưu trữ";
            if (status == "DRAFT")
                return "Bản nháp";
            return Server.HtmlEncode(status);
        }

        protected string SearchStatusClass(object value)
        {
            string status = Convert.ToString(value).ToUpperInvariant();
            if (status == "ACTIVE" || status == "PUBLISHED")
                return "active";
            if (status == "INACTIVE" || status == "LOCKED" || status == "ARCHIVED")
                return "inactive";
            return "draft";
        }

        protected string SearchIcon(object value)
        {
            string icon = Convert.ToString(value);
            if (
                icon == "bi-journal-bookmark"
                || icon == "bi-play-btn"
                || icon == "bi-collection-play"
                || icon == "bi-patch-question"
                || icon == "bi-people"
            )
                return icon;
            return "bi-search";
        }

        protected string SearchTargetUrl(object value)
        {
            string url = Convert.ToString(value).Trim();
            return url.StartsWith("/cms/", StringComparison.OrdinalIgnoreCase)
                ? ResolveUrl("~" + url)
                : ResolveUrl("~/cms/dashboard");
        }

        private static object[] ConvertToParams(IDictionary<string, object> parameters)
        {
            List<object> list = new List<object>();
            foreach (var kvp in parameters)
            {
                list.Add("@" + kvp.Key);
                list.Add(kvp.Value ?? DBNull.Value);
            }
            return list.ToArray();
        }

        private static int CountType(DataTable table, string type)
        {
            int count = 0;
            if (table == null)
                return count;
            foreach (DataRow row in table.Rows)
                if (
                    Convert
                        .ToString(row["ResultType"])
                        .Equals(type, StringComparison.OrdinalIgnoreCase)
                )
                    count++;
            return count;
        }
    }
}
