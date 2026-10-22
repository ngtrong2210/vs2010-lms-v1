using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class Dashboard : CmsControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadDashboard();
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                DataTable summary = ServiceRegistry.Reports.GetDataTable("Dashboard");
                DataRow row = summary != null && summary.Rows.Count > 0 ? summary.Rows[0] : null;
                TotalCoursesText.Text = Html(WebData.Text(row, "TotalCourses"));
                TotalStudentsText.Text = Html(WebData.Text(row, "TotalStudents"));
                TotalLessonsText.Text = Html(WebData.Text(row, "TotalLessons"));
                AverageScoreText.Text = Html(WebData.Text(row, "AverageScore"));
                QualityAverageScoreText.Text = Html(WebData.Text(row, "AverageScore"));
                TotalVideosText.Text = Html(WebData.Text(row, "TotalVideos"));
                TotalQuestionsText.Text = Html(WebData.Text(row, "TotalQuestions"));
                TotalTeachersText.Text = Html(WebData.Text(row, "TotalTeachers"));
                decimal completion;
                if (!decimal.TryParse(WebData.Text(row, "CompletionRate"), out completion))
                    completion = 0;
                completion = Math.Max(0, Math.Min(100, completion));
                CompletionRateText.Text = completion.ToString("0.##", CultureInfo.CurrentCulture);
                completionRateBar.Attributes["style"] =
                    "width:" + completion.ToString("0.##", CultureInfo.InvariantCulture) + "%";
                DataSet courseData = ServiceRegistry.Courses.GetDataSet(
                    "List",
                    ConvertToParams(Values(
                        "Search",
                        DBNull.Value,
                        "Status",
                        DBNull.Value,
                        "Page",
                        1,
                        "PageSize",
                        6,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    ))
                );
                DataTable courses =
                    courseData != null && courseData.Tables.Count > 0 ? courseData.Tables[0] : null;
                WebData.Bind(DataGrid, courses, EmptyText, ErrorText);
                ErrorText.Visible = false;
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp dashboard quản trị thất bại.", ex);
                ErrorText.Text = "Không thể nạp số liệu dashboard.";
                ErrorText.Visible = true;
            }
        }

        protected string CourseStatusLabel(object value)
        {
            string status = Convert.ToString(value);
            return status == "PUBLISHED" ? "Đã xuất bản"
                : status == "ARCHIVED" ? "Lưu trữ"
                : "Bản nháp";
        }

        protected string CourseStatusClass(object value)
        {
            string status = Convert.ToString(value);
            return status == "PUBLISHED" ? "badge-soft-success"
                : status == "ARCHIVED" ? "badge-soft-warning"
                : "badge-soft-primary";
        }

        private string Html(object value)
        {
            return Server.HtmlEncode(Convert.ToString(value));
        }

        private static IDictionary<string, object> Values(params object[] pairs)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(
                StringComparer.OrdinalIgnoreCase
            );
            for (int index = 0; index + 1 < pairs.Length; index += 2)
                values[Convert.ToString(pairs[index])] = pairs[index + 1];
            return values;
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
    }
}
