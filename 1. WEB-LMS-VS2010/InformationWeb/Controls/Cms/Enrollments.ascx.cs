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
    public partial class Enrollments : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Students; }
        }
        protected override string Operation
        {
            get { return "EnrollmentList"; }
        }
        protected override string PageTitle
        {
            get { return "Ghi danh môn học"; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values("Page", 1, "PageSize", 100);
        }

        protected override void OnLoad(EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/cms/academic"), false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void EnrollButton_Click(object sender, System.EventArgs e)
        {
            long courseId,
                studentId;
            if (
                !long.TryParse(EnrollmentCourseIdText.Text, out courseId)
                || courseId <= 0
                || !long.TryParse(EnrollmentStudentIdText.Text, out studentId)
                || studentId <= 0
            )
            {
                ShowActionResult(
                    ActionMessageText,
                    "ID môn học hoặc học viên không hợp lệ.",
                    false
                );
                return;
            }
            bool ok = Service.ExecNonQuery(
                "Enroll",
                Values("CourseId", courseId, "StudentId", studentId, "ActorId", CurrentUser.UserID)
            );
            ShowActionResult(
                ActionMessageText,
                ok ? "Đã ghi danh học viên." : "Không thể ghi danh.",
                ok
            );
            if (ok)
                LoadData();
        }

        protected void CancelEnrollmentButton_Click(object sender, System.EventArgs e)
        {
            long id;
            if (!long.TryParse(EnrollmentIdText.Text, out id) || id <= 0)
            {
                ShowActionResult(ActionMessageText, "ID ghi danh không hợp lệ.", false);
                return;
            }
            bool ok = Service.ExecNonQuery(
                "CancelEnrollment",
                Values("Id", id, "ActorId", CurrentUser.UserID)
            );
            ShowActionResult(
                ActionMessageText,
                ok ? "Đã hủy ghi danh." : "Không thể hủy ghi danh.",
                ok
            );
            if (ok)
                LoadData();
        }
    }
}
