using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Lms
{
    public partial class Course : StudentControl
    {
        protected long CourseId
        {
            get { return RouteLong("courseId"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            try
            {
                DataSet data = ServiceRegistry.Learning.GetDataSet(
                    "CourseDetail",
                    Values("CourseId", CourseId, "StudentId", CurrentUser.UserID)
                );
                DataTable detail = data != null && data.Tables.Count > 0 ? data.Tables[0] : null;
                DataTable lessons = data != null && data.Tables.Count > 2 ? data.Tables[2] : null;
                if (detail == null || detail.Rows.Count == 0)
                {
                    Response.Redirect(ResolveUrl("~/lms/courses"), false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }
                DataRow row = detail.Rows[0];
                long lessonId = WebData.Long(row, "ContinueLessonId");
                if (lessonId <= 0 && lessons != null)
                {
                    foreach (DataRow lesson in lessons.Rows)
                    {
                        bool completed =
                            lesson.Table.Columns.Contains("Completed")
                            && lesson["Completed"] != DBNull.Value
                            && Convert.ToBoolean(lesson["Completed"]);
                        if (!completed)
                        {
                            lessonId = WebData.Long(lesson, "Id", "LessonID");
                            break;
                        }
                    }
                    if (lessonId <= 0 && lessons.Rows.Count > 0)
                        lessonId = WebData.Long(lessons.Rows[0], "Id", "LessonID");
                }
                Response.Redirect(
                    lessonId > 0
                        ? ResolveUrl("~/lms/courses/" + CourseId + "/lessons/" + lessonId)
                        : ResolveUrl("~/lms/courses"),
                    false
                );
                Context.ApplicationInstance.CompleteRequest();
                return;
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp chi tiết môn học thất bại.", ex);
                ErrorText.Text = "Không thể nạp nội dung môn học.";
                ErrorText.Visible = true;
            }
        }

        protected string LessonUrl(object lessonId)
        {
            return ResolveUrl(
                "~/lms/courses/" + CourseId + "/lessons/" + Convert.ToString(lessonId)
            );
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
    }
}
