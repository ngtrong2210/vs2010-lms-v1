using System;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.Controls.Cms
{
    public partial class CourseProgress : LmsControl
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
            BindProgressGrid();
            UpdateSummary();
        }

        private void BindFilterLists()
        {
            BindCourseList(CourseFilter);
            BindStudentList(StudentFilter);
            BindClassList(ClassFilter);
        }

        private void BindCourseList(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Tất cả--", ""));

            try
            {
                SIM_Courses obj = new SIM_Courses();
                DataTable dtb = obj.SearchCBX();
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
            ddl.Items.Add(new ListItem("--Tất cả--", ""));

            try
            {
                SYS_Users obj = new SYS_Users();
                DataTable dtb = obj.GetDataSet("SYS_Users_SearchAll", null).Tables[0];
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

        private void BindClassList(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Tất cả--", ""));

            try
            {
                SIM_Class obj = new SIM_Class();
                DataTable dtb = obj.Search(null);
                if (dtb != null)
                {
                    foreach (DataRow row in dtb.Rows)
                    {
                        string className = WebData.Text(row, "ClassName");
                        string classId = WebData.Text(row, "ClassID");

                        ddl.Items.Add(new ListItem(className, classId));
                    }
                }
            }
            catch { }
        }

        private void BindProgressGrid()
        {
            string condition = BuildFilterCondition();
            LMS_Enrollments obj = new LMS_Enrollments();
            DataTable dtb = obj.Search(condition);
            ProgressGrid.DataSource = dtb;
            ProgressGrid.DataBind();
        }

        private string BuildFilterCondition()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string course = CourseFilter.SelectedValue;
            string student = StudentFilter.SelectedValue;
            string @class = ClassFilter.SelectedValue;

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

            if (!string.IsNullOrEmpty(@class))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("ClassID = " + @class);
            }

            return sb.ToString();
        }

        private void UpdateSummary()
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            DataTable dtb = obj.Search(BuildFilterCondition());

            int totalStudents = dtb.Rows.Count;
            int inProgress = 0;
            int completed = 0;
            decimal totalScore = 0;
            int scoreCount = 0;

            foreach (DataRow row in dtb.Rows)
            {
                string status = WebData.Text(row, "Status");
                decimal? finalScore = WebData.NullableDecimal(row, "FinalScore");

                if (status == "IN_PROGRESS")
                    inProgress++;
                else if (status == "COMPLETED")
                    completed++;

                if (finalScore.HasValue)
                {
                    totalScore += finalScore.Value;
                    scoreCount++;
                }
            }

            TotalStudentsText.Text = totalStudents.ToString();
            InProgressText.Text = inProgress.ToString();
            CompletedText.Text = completed.ToString();
            AverageScoreText.Text = scoreCount > 0 ? (totalScore / scoreCount).ToString("0.0") : "-";
        }

        protected void CourseFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProgressGrid();
            UpdateSummary();
        }

        protected void StudentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProgressGrid();
            UpdateSummary();
        }

        protected void ClassFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindProgressGrid();
            UpdateSummary();
        }

        protected void ExportButton_Click(object sender, EventArgs e)
        {
            ShowMessage("Tính năng xuất báo cáo đang được phát triển", true);
        }

        protected void ProgressGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long enrollmentId = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName == "ViewProgress")
            {
                ViewProgressDetail(enrollmentId);
            }
        }

        protected void ProgressGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string status = WebData.Text(drv, "Status");
                decimal progress = WebData.Decimal(drv, "ProgressPercent");
                decimal? finalScore = WebData.NullableDecimal(drv, "FinalScore");
                int lessonsCompleted = WebData.Int(drv, "LessonsCompleted");
                int totalLessons = WebData.Int(drv, "TotalLessons");
                DateTime? lastActivity = WebData.NullableDateTime(drv, "LastAccessAt");

                Label statusLabel = (Label)e.Row.FindControl("StatusLabel");
                if (statusLabel != null)
                {
                    statusLabel.Text = GetStatusText(status);
                    statusLabel.CssClass = "status-badge " + GetStatusClass(status);
                }

                Label progressLabel = (Label)e.Row.FindControl("ProgressLabel");
                System.Web.UI.HtmlControls.HtmlGenericControl progressBar = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Row.FindControl("ProgressBar");
                if (progressLabel != null && progressBar != null)
                {
                    progressLabel.Text = progress.ToString("0") + "%";
                    progressBar.Style.Add("width", progress.ToString("0") + "%");
                    progressBar.Attributes.Add("class", "progress-bar progress-bar-" + GetProgressBarClass(progress));
                }

                Label scoreLabel = (Label)e.Row.FindControl("ScoreLabel");
                if (scoreLabel != null)
                {
                    scoreLabel.Text = finalScore.HasValue ? finalScore.Value.ToString("0.0") : "-";
                }

                Label lessonsCompletedLabel = (Label)e.Row.FindControl("LessonsCompletedLabel");
                if (lessonsCompletedLabel != null)
                {
                    lessonsCompletedLabel.Text = lessonsCompleted + "/" + totalLessons;
                }

                Label lastActivityLabel = (Label)e.Row.FindControl("LastActivityLabel");
                if (lastActivityLabel != null)
                {
                    lastActivityLabel.Text = lastActivity.HasValue ? lastActivity.Value.ToString("dd/MM/yyyy") : "-";
                }
            }
        }

        protected void ProgressGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ProgressGrid.PageIndex = e.NewPageIndex;
            BindProgressGrid();
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

        private string GetProgressBarClass(decimal progress)
        {
            if (progress >= 75) return "success";
            if (progress >= 50) return "info";
            if (progress >= 25) return "warning";
            return "danger";
        }

        private void ViewProgressDetail(long enrollmentId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            DataTable dtb = obj.Search(null);
            DataRow[] rows = dtb.Select("EnrollmentID = " + enrollmentId);

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                DetailPanel.Visible = true;
                DetailStudentName.Text = WebData.Text(row, "StudentName");
                DetailCourseTitle.Text = WebData.Text(row, "CourseTitle");
                DetailClassName.Text = WebData.Text(row, "ClassName");

                BindLessonProgress(enrollmentId);
            }
        }

        private void BindLessonProgress(long enrollmentId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            DataTable dtb = obj.GetDataTable("LMS_Enrollments_GetLessonProgress", "@EnrollmentID", enrollmentId);
            LessonProgressGrid.DataSource = dtb;
            LessonProgressGrid.DataBind();
        }

        protected void CloseDetailButton_Click(object sender, EventArgs e)
        {
            DetailPanel.Visible = false;
        }

        private void ShowMessage(string message, bool isError)
        {
            ActionMessageText.Visible = true;
            ActionMessageText.Text = message;
            ActionMessageText.CssClass = isError ? "alert alert-danger" : "alert alert-success";
        }
    }
}
