using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Lms
{
    public partial class Results : StudentStoreControl
    {
        protected override string Operation
        {
            get { return "Results"; }
        }
        protected override string PageTitle
        {
            get { return "Kết quả học tập"; }
        }
        protected override string PageDescription
        {
            get { return "Điểm số và tiến độ được tính trực tiếp từ dữ liệu học tập."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values("StudentId", CurrentUser.UserID, "CourseId", null);
        }

        protected override void LoadData()
        {
            try
            {
                DataSet data = ServiceRegistry.Learning.GetDataSet(Operation, Parameters());
                DataTable courses = data != null && data.Tables.Count > 0 ? data.Tables[0] : null;
                DataTable lessons = data != null && data.Tables.Count > 1 ? data.Tables[1] : null;
                WebData.Bind(DataGrid, courses, EmptyText, ErrorText);
                CourseResultsRepeater.DataSource = courses;
                CourseResultsRepeater.DataBind();
                LessonGrid.DataSource = lessons;
                LessonGrid.DataBind();
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp kết quả học tập thất bại.", ex);
                WebData.Bind(DataGrid, null, EmptyText, ErrorText);
            }
        }

        protected string ScoreText(object value)
        {
            return
                value == null
                || value == System.DBNull.Value
                || string.IsNullOrWhiteSpace(System.Convert.ToString(value))
                ? "—"
                : Server.HtmlEncode(System.Convert.ToString(value));
        }

        protected string ProgressStyle(object value)
        {
            decimal progress;
            if (!decimal.TryParse(System.Convert.ToString(value), out progress))
                progress = 0;
            if (progress < 0)
                progress = 0;
            if (progress > 100)
                progress = 100;
            return "width:"
                + progress.ToString(System.Globalization.CultureInfo.InvariantCulture)
                + "%";
        }
    }
}
