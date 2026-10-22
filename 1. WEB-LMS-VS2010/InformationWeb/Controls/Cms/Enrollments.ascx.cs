using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.Controls.Cms
{
    /// <summary>
    /// UserControl quản lý ghi danh môn học trong CMS.
    /// Cung cấp chức năng ghi danh và hủy ghi danh học viên vào các khóa học.
    /// </summary>
    public partial class Enrollments : CmsStoreControl
    {
        /// <summary>
        /// Tiêu đề trang quản lý ghi danh.
        /// </summary>
        protected override string PageTitle
        {
            get { return "Ghi danh môn học"; }
        }

        /// <summary>
        /// Redirect sang trang academic structure khi load.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            Response.Redirect(ResolveUrl("~/cms/academic"), false);
            Context.ApplicationInstance.CompleteRequest();
        }

        /// <summary>
        /// Xử lý sự kiện ghi danh học viên vào khóa học.
        /// </summary>
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
            SIM_Student student = new SIM_Student();
            bool ok = student.Enroll(courseId, studentId, CurrentUser.UserID);
            ShowActionResult(
                ActionMessageText,
                ok ? "Đã ghi danh học viên." : "Không thể ghi danh.",
                ok
            );
            if (ok)
                LoadData();
        }

        /// <summary>
        /// Xử lý sự kiện hủy ghi danh học viên.
        /// </summary>
        protected void CancelEnrollmentButton_Click(object sender, System.EventArgs e)
        {
            long id;
            if (!long.TryParse(EnrollmentIdText.Text, out id) || id <= 0)
            {
                ShowActionResult(ActionMessageText, "ID ghi danh không hợp lệ.", false);
                return;
            }
            SIM_Student student = new SIM_Student();
            bool ok = student.CancelEnrollment(id, CurrentUser.UserID);
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
