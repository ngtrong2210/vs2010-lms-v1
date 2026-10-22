using System;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService.Course;

namespace InformationWeb.Controls.Cms
{
    public partial class CourseEnrollments : LmsControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            BindFilterLists();
            BindEnrollmentGrid();
        }

        private void BindFilterLists()
        {
            BindCourseList(CourseFilter);
            BindCourseList(CourseList);
            BindStudentList(StudentFilter);
            BindStudentList(StudentList);
        }

        private void BindCourseList(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Chọn khóa học--", ""));

            try
            {
                DataTable dtb = CourseService.GetCourseList();
                if (dtb != null)
                {
                    foreach (DataRow row in dtb.Rows)
                    {
                        string title = WebData.Text(row, "Title");
                        string courseId = WebData.Text(row, "CourseID");

                        ddl.Items.Add(new ListItem(title, courseId));
                    }
                }
            }
            catch { }
        }

        private void BindStudentList(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Chọn học viên--", ""));

            try
            {
                DataTable dtb = ServiceRegistry.Users.GetDataSet("SearchAll", null).Tables[0];
                if (dtb != null)
                {
                    foreach (DataRow row in dtb.Rows)
                    {
                        string userName = WebData.Text(row, "UserName");
                        string fullName = WebData.Text(row, "FullName");
                        string userId = WebData.Text(row, "UserID");

                        ddl.Items.Add(new ListItem(fullName + " (" + userName + ")", userId));
                    }
                }
            }
            catch { }
        }

        private void BindEnrollmentGrid()
        {
            string condition = BuildFilterCondition();
            DataTable dtb = EnrollmentService.GetEnrollmentList(condition);
            EnrollmentGrid.DataSource = dtb;
            EnrollmentGrid.DataBind();
        }

        private string BuildFilterCondition()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string course = CourseFilter.SelectedValue;
            string student = StudentFilter.SelectedValue;
            string status = StatusFilter.SelectedValue;

            if (!string.IsNullOrEmpty(course))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("CourseId = " + course);
            }

            if (!string.IsNullOrEmpty(student))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("StudentUserID = " + student);
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Status = '" + status + "'");
            }

            return sb.ToString();
        }

        protected void AddEnrollmentButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = true;
            EditPanelTitle.Text = "Đăng ký học viên mới";
            ClearForm();
            EnrollmentIdValue.Value = "";
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            BindEnrollmentGrid();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            CourseFilter.SelectedIndex = 0;
            StudentFilter.SelectedIndex = 0;
            StatusFilter.SelectedIndex = 0;
            BindEnrollmentGrid();
        }

        protected void EnrollmentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long enrollmentId = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName == "EditEnrollment")
            {
                EditEnrollment(enrollmentId);
            }
            else if (e.CommandName == "DeleteEnrollment")
            {
                DeleteEnrollment(enrollmentId);
            }
        }

        protected void EnrollmentGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string status = WebData.Text(drv, "Status");
                decimal progress = WebData.Decimal(drv, "ProgressPercent");
                decimal? finalScore = WebData.NullableDecimal(drv, "FinalScore");

                Label statusLabel = (Label)e.Row.FindControl("StatusLabel");
                if (statusLabel != null)
                {
                    statusLabel.Text = GetStatusText(status);
                    statusLabel.CssClass = "status-badge " + GetStatusClass(status);
                }

                Label progressLabel = (Label)e.Row.FindControl("ProgressLabel");
                if (progressLabel != null)
                {
                    progressLabel.Text = progress.ToString("0") + "%";
                }

                Label scoreLabel = (Label)e.Row.FindControl("ScoreLabel");
                if (scoreLabel != null)
                {
                    scoreLabel.Text = finalScore.HasValue ? finalScore.Value.ToString("0.0") : "-";
                }
            }
        }

        protected void EnrollmentGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            EnrollmentGrid.PageIndex = e.NewPageIndex;
            BindEnrollmentGrid();
        }

        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "ENROLLED": return "Đã đăng ký";
                case "IN_PROGRESS": return "Đang học";
                case "COMPLETED": return "Hoàn thành";
                case "DROPPED": return "Đã bỏ";
                default: return status;
            }
        }

        private string GetStatusClass(string status)
        {
            switch (status)
            {
                case "ENROLLED": return "status-enrolled";
                case "IN_PROGRESS": return "status-inprogress";
                case "COMPLETED": return "status-completed";
                case "DROPPED": return "status-dropped";
                default: return "";
            }
        }

        private void EditEnrollment(long enrollmentId)
        {
            DataTable dtb = EnrollmentService.GetEnrollmentList();
            DataRow[] rows = dtb.Select("EnrollmentID = " + enrollmentId);

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                EditPanel.Visible = true;
                EditPanelTitle.Text = "Chỉnh sửa đăng ký";
                EnrollmentIdValue.Value = enrollmentId.ToString();
                CourseList.SelectedValue = WebData.Text(row, "CourseId");
                StudentList.SelectedValue = WebData.Text(row, "StudentUserID");
                StatusList.SelectedValue = WebData.Text(row, "Status");
                ProgressPercentText.Text = WebData.Text(row, "ProgressPercent");
                FinalScoreText.Text = WebData.Text(row, "FinalScore");
            }
        }

        private void DeleteEnrollment(long enrollmentId)
        {
            bool result = EnrollmentService.DeleteEnrollment(enrollmentId);

            if (result)
            {
                ShowMessage("Xóa đăng ký thành công", false);
                BindEnrollmentGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi xóa đăng ký", true);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            long courseId = Convert.ToInt64(CourseList.SelectedValue);
            long studentUserId = Convert.ToInt64(StudentList.SelectedValue);
            string status = StatusList.SelectedValue;
            decimal progressPercent = Convert.ToDecimal(ProgressPercentText.Text);
            decimal? finalScore = null;
            if (!string.IsNullOrEmpty(FinalScoreText.Text))
                finalScore = Convert.ToDecimal(FinalScoreText.Text);

            long enrollmentId = 0;
            if (!string.IsNullOrEmpty(EnrollmentIdValue.Value))
            {
                enrollmentId = Convert.ToInt64(EnrollmentIdValue.Value);
            }

            bool result = false;

            if (enrollmentId > 0)
            {
                result = EnrollmentService.UpdateEnrollment(enrollmentId, courseId, studentUserId, status, progressPercent, finalScore);
            }
            else
            {
                result = EnrollmentService.EnrollStudent(courseId, studentUserId, CurrentUser.UserID);
            }

            if (result)
            {
                ShowMessage("Lưu đăng ký thành công", false);
                EditPanel.Visible = false;
                BindEnrollmentGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi lưu đăng ký", true);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ClearForm();
        }

        private void ClearForm()
        {
            CourseList.SelectedIndex = 0;
            StudentList.SelectedIndex = 0;
            StatusList.SelectedValue = "ENROLLED";
            ProgressPercentText.Text = "0";
            FinalScoreText.Text = "";
        }

        private void ShowMessage(string message, bool isError)
        {
            ActionMessageText.Visible = true;
            ActionMessageText.Text = message;
            ActionMessageText.CssClass = isError ? "alert alert-danger" : "alert alert-success";
        }
    }
}
