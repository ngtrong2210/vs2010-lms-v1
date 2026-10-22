using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Lms
{
    public partial class Dashboard : StudentStoreControl
    {
        protected override string Operation
        {
            get { return "Dashboard"; }
        }
        protected override string PageTitle
        {
            get { return "Xin chào, " + CurrentUser.FullName + " 👋"; }
        }
        protected override string PageDescription
        {
            get { return "Tiếp tục hành trình học tập và hoàn thành mục tiêu hôm nay."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values("StudentId", CurrentUser.UserID);
        }

        protected override void LoadData()
        {
            try
            {
                DataSet data = ServiceRegistry.Learning.GetDataSet(Operation, Parameters());
                DataTable summary = data != null && data.Tables.Count > 0 ? data.Tables[0] : null;
                DataTable courses = data != null && data.Tables.Count > 1 ? data.Tables[1] : null;
                DataRow row = summary != null && summary.Rows.Count > 0 ? summary.Rows[0] : null;
                ActiveCourseCountText.Text = Server.HtmlEncode(
                    WebData.Text(row, "ActiveCourseCount")
                );
                CompletedLessonCountText.Text = Server.HtmlEncode(
                    WebData.Text(row, "CompletedLessonCount")
                );
                AverageScoreText.Text = Server.HtmlEncode(WebData.Text(row, "AverageScore"));
                long seconds = WebData.Long(row, "LearningSeconds");
                LearningTimeText.Text = Server.HtmlEncode(
                    string.Format("{0}g {1}p", seconds / 3600, (seconds % 3600) / 60)
                );
                DataTable recent = TopRows(courses, 2);
                CourseRepeater.DataSource = recent;
                CourseRepeater.DataBind();
                DataRow first = courses != null && courses.Rows.Count > 0 ? courses.Rows[0] : null;
                decimal progress;
                if (!decimal.TryParse(WebData.Text(first, "ProgressPercent"), out progress))
                    progress = 0;
                RecentProgressText.Text = Server.HtmlEncode(
                    System
                        .Math.Round(progress)
                        .ToString(System.Globalization.CultureInfo.CurrentCulture)
                );
                RecentCourseTitleText.Text = Server.HtmlEncode(
                    first == null ? "Chưa có môn học lớp" : WebData.Text(first, "Title")
                );
                ContinueButton.Visible = first != null;
                if (first != null)
                    ContinueButton.NavigateUrl = CourseUrl(
                        first["Id"],
                        first.Table.Columns.Contains("ContinueLessonId")
                            ? first["ContinueLessonId"]
                            : null
                    );
                EmptyText.Visible = courses == null || courses.Rows.Count == 0;
                ErrorText.Visible = false;
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp tổng quan học viên thất bại.", ex);
                ErrorText.Text = "Không thể nạp dữ liệu học tập.";
                ErrorText.Visible = true;
            }
        }

        protected string CourseUrl(object courseId, object continueLessonId)
        {
            string course = System.Convert.ToString(courseId);
            string lesson = System.Convert.ToString(continueLessonId);
            return ResolveUrl(
                string.IsNullOrWhiteSpace(lesson)
                    ? "~/lms/courses/" + course
                    : "~/lms/courses/" + course + "/lessons/" + lesson
            );
        }

        protected string Html(object value)
        {
            return Server.HtmlEncode(System.Convert.ToString(value));
        }

        private static DataTable TopRows(DataTable source, int count)
        {
            if (source == null)
                return null;
            DataTable result = source.Clone();
            for (int index = 0; index < source.Rows.Count && index < count; index++)
                result.ImportRow(source.Rows[index]);
            return result;
        }
    }
}
