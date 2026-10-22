using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Lms
{
    public partial class Courses : StudentStoreControl
    {
        protected override string Operation
        {
            get { return "CourseList"; }
        }
        protected override string PageTitle
        {
            get { return "Môn học của tôi"; }
        }
        protected override string PageDescription
        {
            get { return "Theo dõi và tiếp tục các môn học lớp đã được phân."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values("StudentId", CurrentUser.UserID);
        }

        protected override void LoadData()
        {
            try
            {
                DataTable source = ServiceRegistry.Learning.GetDataTable(Operation, Parameters());
                DataTable filtered = FilterCourses(source);
                WebData.Bind(DataGrid, filtered, EmptyText, ErrorText);
                CourseListRepeater.DataSource = filtered;
                CourseListRepeater.DataBind();
                CourseCountText.Text = (filtered == null ? 0 : filtered.Rows.Count).ToString(
                    System.Globalization.CultureInfo.InvariantCulture
                );
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp môn học của học viên thất bại.", ex);
                WebData.Bind(DataGrid, null, EmptyText, ErrorText);
            }
        }

        protected string CourseUrl(object courseId, object continueLessonId)
        {
            string course = System.Convert.ToString(courseId),
                lesson = System.Convert.ToString(continueLessonId);
            return ResolveUrl(
                string.IsNullOrWhiteSpace(lesson) || lesson == "0"
                    ? "~/lms/courses/" + course
                    : "~/lms/courses/" + course + "/lessons/" + lesson
            );
        }

        protected string CourseImage(int index)
        {
            return ResolveUrl(
                "~/assets/lms/eduvers/images/courses/course-list-img-" + ((index % 5) + 1) + ".jpg"
            );
        }

        protected string TeacherImage(int index)
        {
            return ResolveUrl(
                "~/assets/lms/eduvers/images/courses/course-list-client-img-"
                    + ((index % 5) + 1)
                    + ".jpg"
            );
        }

        protected string EnrollmentStatusText(object value)
        {
            return System.Convert.ToString(value) == "COMPLETED" ? "Hoàn thành" : "Đang học";
        }

        private DataTable FilterCourses(DataTable source)
        {
            if (source == null)
                return null;
            DataTable result = source.Clone();
            string term = CourseSearchText.Text.Trim().ToLowerInvariant(),
                status = CourseStatusFilterList.SelectedValue;
            foreach (DataRow row in source.Rows)
            {
                string searchable = (
                    WebData.Text(row, "Title") + " " + WebData.Text(row, "TeacherName")
                ).ToLowerInvariant();
                if (term.Length > 0 && !searchable.Contains(term))
                    continue;
                if (
                    status.Length > 0
                    && !WebData
                        .Text(row, "EnrollmentStatus")
                        .Equals(status, System.StringComparison.OrdinalIgnoreCase)
                )
                    continue;
                result.ImportRow(row);
            }
            return result;
        }
    }
}
