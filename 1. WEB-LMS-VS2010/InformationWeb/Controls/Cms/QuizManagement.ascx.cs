using System;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService.Course;
using System.Web.UI;

namespace InformationWeb.Controls.Cms
{
    public partial class QuizManagement : LmsControl
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
            BindQuizGrid();
        }

        private void BindFilterLists()
        {
            DropDownList courseFilter = (DropDownList)FindControl("CourseFilter");
            DropDownList courseList = (DropDownList)FindControl("CourseList");
            if (courseFilter != null) BindCourseList(courseFilter);
            if (courseList != null) BindCourseList(courseList);
        }

        private void BindCourseList(DropDownList ddl)
        {
            if (ddl == null) return;
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

        private void BindLessonList(long courseId)
        {
            DropDownList lessonList = (DropDownList)FindControl("LessonList");
            if (lessonList == null) return;

            lessonList.Items.Clear();
            lessonList.Items.Add(new ListItem("--Chọn bài học--", ""));

            if (courseId > 0)
            {
                try
                {
                    DataTable dtb = LessonService.GetLessonList("CourseID = " + courseId);
                    if (dtb != null)
                    {
                        foreach (DataRow row in dtb.Rows)
                        {
                            string title = WebData.Text(row, "Title");
                            string lessonId = WebData.Text(row, "LessonID");

                            lessonList.Items.Add(new ListItem(title, lessonId));
                        }
                    }
                }
                catch { }
            }
        }

        private void BindQuizGrid()
        {
            GridView quizGrid = (GridView)FindControl("QuizGrid");
            if (quizGrid == null) return;

            string condition = BuildFilterCondition();
            DataTable dtb = QuizService.GetQuizList(condition);
            quizGrid.DataSource = dtb;
            quizGrid.DataBind();
        }

        private string BuildFilterCondition()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            TextBox searchText = (TextBox)FindControl("SearchText");
            DropDownList courseFilter = (DropDownList)FindControl("CourseFilter");
            DropDownList typeFilter = (DropDownList)FindControl("TypeFilter");

            string search = searchText != null ? searchText.Text.Trim() : "";
            string course = courseFilter != null ? courseFilter.SelectedValue : "";
            string type = typeFilter != null ? typeFilter.SelectedValue : "";

            if (!string.IsNullOrEmpty(search))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("(Title LIKE '%" + search + "%' OR Code LIKE '%" + search + "%')");
            }

            if (!string.IsNullOrEmpty(course))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("CourseID = " + course);
            }

            if (!string.IsNullOrEmpty(type))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Type = '" + type + "'");
            }

            return sb.ToString();
        }

        protected void AddQuizButton_Click(object sender, EventArgs e)
        {
            Panel editPanel = (Panel)FindControl("EditPanel");
            Literal editPanelTitle = (Literal)FindControl("EditPanelTitle");
            HiddenField quizIdValue = (HiddenField)FindControl("QuizIdValue");

            if (editPanel != null) editPanel.Visible = true;
            if (editPanelTitle != null) editPanelTitle.Text = "Thêm bài kiểm tra mới";
            ClearForm();
            if (quizIdValue != null) quizIdValue.Value = "";
        }

        protected void FilterButton_Click(object sender, EventArgs e)
        {
            BindQuizGrid();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            TextBox searchText = (TextBox)FindControl("SearchText");
            DropDownList courseFilter = (DropDownList)FindControl("CourseFilter");
            DropDownList typeFilter = (DropDownList)FindControl("TypeFilter");

            if (searchText != null) searchText.Text = "";
            if (courseFilter != null) courseFilter.SelectedIndex = 0;
            if (typeFilter != null) typeFilter.SelectedIndex = 0;
            BindQuizGrid();
        }

        protected void CourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList courseList = (DropDownList)FindControl("CourseList");
            if (courseList != null)
            {
                long courseId = 0;
                if (!string.IsNullOrEmpty(courseList.SelectedValue))
                    courseId = Convert.ToInt64(courseList.SelectedValue);
                BindLessonList(courseId);
            }
        }

        protected void QuizGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long quizId = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName == "EditQuiz")
            {
                EditQuiz(quizId);
            }
            else if (e.CommandName == "ManageQuestions")
            {
                ManageQuestions(quizId);
            }
            else if (e.CommandName == "DeleteQuiz")
            {
                DeleteQuiz(quizId);
            }
        }

        protected void QuizGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string status = WebData.Text(drv, "Status");
                int questionCount = WebData.Int(drv, "QuestionCount");

                Label statusLabel = (Label)e.Row.FindControl("StatusLabel");
                if (statusLabel != null)
                {
                    statusLabel.Text = status == "ACTIVE" ? "Hoạt động" : "Tạm dừng";
                    statusLabel.CssClass = "status-badge " + (status == "ACTIVE" ? "status-active" : "status-inactive");
                }

                Label questionCountLabel = (Label)e.Row.FindControl("QuestionCountLabel");
                if (questionCountLabel != null)
                {
                    questionCountLabel.Text = questionCount.ToString();
                }
            }
        }

        protected void QuizGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView quizGrid = (GridView)FindControl("QuizGrid");
            if (quizGrid != null)
            {
                quizGrid.PageIndex = e.NewPageIndex;
                BindQuizGrid();
            }
        }

        private void EditQuiz(long quizId)
        {
            DataTable dtb = QuizService.GetQuizList();
            DataRow[] rows = dtb.Select("QuizID = " + quizId);

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                Panel editPanel = (Panel)FindControl("EditPanel");
                Literal editPanelTitle = (Literal)FindControl("EditPanelTitle");
                HiddenField quizIdValue = (HiddenField)FindControl("QuizIdValue");
                TextBox titleText = (TextBox)FindControl("TitleText");
                TextBox codeText = (TextBox)FindControl("CodeText");
                DropDownList courseList = (DropDownList)FindControl("CourseList");
                DropDownList lessonList = (DropDownList)FindControl("LessonList");
                DropDownList typeList = (DropDownList)FindControl("TypeList");
                TextBox durationText = (TextBox)FindControl("DurationText");
                TextBox passingScoreText = (TextBox)FindControl("PassingScoreText");
                TextBox sortOrderText = (TextBox)FindControl("SortOrderText");
                TextBox descriptionText = (TextBox)FindControl("DescriptionText");
                TextBox instructionsText = (TextBox)FindControl("InstructionsText");

                if (editPanel != null) editPanel.Visible = true;
                if (editPanelTitle != null) editPanelTitle.Text = "Chỉnh sửa bài kiểm tra";
                if (quizIdValue != null) quizIdValue.Value = quizId.ToString();
                if (titleText != null) titleText.Text = WebData.Text(row, "Title");
                if (codeText != null) codeText.Text = WebData.Text(row, "Code");
                if (courseList != null) courseList.SelectedValue = WebData.Text(row, "CourseID");
                BindLessonList(Convert.ToInt64(WebData.Text(row, "CourseID")));
                if (lessonList != null) lessonList.SelectedValue = WebData.Text(row, "LessonID");
                if (typeList != null) typeList.SelectedValue = WebData.Text(row, "Type");
                if (durationText != null) durationText.Text = WebData.Text(row, "DurationMinutes");
                if (passingScoreText != null) passingScoreText.Text = WebData.Text(row, "PassingScore");
                if (sortOrderText != null) sortOrderText.Text = WebData.Text(row, "SortOrder");
                if (descriptionText != null) descriptionText.Text = WebData.Text(row, "Description");
                if (instructionsText != null) instructionsText.Text = WebData.Text(row, "Instructions");
            }
        }

        private void ManageQuestions(long quizId)
        {
            ShowMessage("Tính năng quản lý câu hỏi đang được phát triển", true);
        }

        private void DeleteQuiz(long quizId)
        {
            bool result = QuizService.DeleteQuiz(quizId);

            if (result)
            {
                ShowMessage("Xóa bài kiểm tra thành công", false);
                BindQuizGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi xóa bài kiểm tra", true);
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            TextBox titleText = (TextBox)FindControl("TitleText");
            TextBox codeText = (TextBox)FindControl("CodeText");
            DropDownList courseList = (DropDownList)FindControl("CourseList");
            DropDownList lessonList = (DropDownList)FindControl("LessonList");
            DropDownList typeList = (DropDownList)FindControl("TypeList");
            TextBox durationText = (TextBox)FindControl("DurationText");
            TextBox passingScoreText = (TextBox)FindControl("PassingScoreText");
            TextBox sortOrderText = (TextBox)FindControl("SortOrderText");
            TextBox descriptionText = (TextBox)FindControl("DescriptionText");
            TextBox instructionsText = (TextBox)FindControl("InstructionsText");
            HiddenField quizIdValue = (HiddenField)FindControl("QuizIdValue");

            string title = titleText != null ? titleText.Text.Trim() : "";
            string code = codeText != null ? codeText.Text.Trim() : "";
            long courseId = 0;
            if (courseList != null && !string.IsNullOrEmpty(courseList.SelectedValue))
                courseId = Convert.ToInt64(courseList.SelectedValue);
            long? lessonId = null;
            if (lessonList != null && !string.IsNullOrEmpty(lessonList.SelectedValue))
                lessonId = Convert.ToInt64(lessonList.SelectedValue);
            string type = typeList != null ? typeList.SelectedValue : "LESSON";
            int durationMinutes = durationText != null ? Convert.ToInt32(durationText.Text) : 30;
            decimal passingScore = passingScoreText != null ? Convert.ToDecimal(passingScoreText.Text) : 60;
            int sortOrder = sortOrderText != null ? Convert.ToInt32(sortOrderText.Text) : 0;
            string description = descriptionText != null ? descriptionText.Text.Trim() : "";
            string instructions = instructionsText != null ? instructionsText.Text.Trim() : "";

            long quizId = 0;
            if (quizIdValue != null && !string.IsNullOrEmpty(quizIdValue.Value))
            {
                quizId = Convert.ToInt64(quizIdValue.Value);
            }

            bool result = false;

            if (quizId > 0)
            {
                result = QuizService.UpdateQuiz(quizId, title, code, courseId, lessonId, type, durationMinutes, passingScore, sortOrder, description, instructions, CurrentUser.UserID);
            }
            else
            {
                result = QuizService.CreateQuiz(title, code, courseId, lessonId, type, durationMinutes, passingScore, sortOrder, description, instructions, CurrentUser.UserID, CurrentUser.DataGroupID);
            }

            if (result)
            {
                ShowMessage("Lưu bài kiểm tra thành công", false);
                Panel editPanel = (Panel)FindControl("EditPanel");
                if (editPanel != null) editPanel.Visible = false;
                BindQuizGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi lưu bài kiểm tra", true);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Panel editPanel = (Panel)FindControl("EditPanel");
            if (editPanel != null) editPanel.Visible = false;
            ClearForm();
        }

        private void ClearForm()
        {
            TextBox titleText = (TextBox)FindControl("TitleText");
            TextBox codeText = (TextBox)FindControl("CodeText");
            DropDownList courseList = (DropDownList)FindControl("CourseList");
            DropDownList lessonList = (DropDownList)FindControl("LessonList");
            DropDownList typeList = (DropDownList)FindControl("TypeList");
            TextBox durationText = (TextBox)FindControl("DurationText");
            TextBox passingScoreText = (TextBox)FindControl("PassingScoreText");
            TextBox sortOrderText = (TextBox)FindControl("SortOrderText");
            TextBox descriptionText = (TextBox)FindControl("DescriptionText");
            TextBox instructionsText = (TextBox)FindControl("InstructionsText");

            if (titleText != null) titleText.Text = "";
            if (codeText != null) codeText.Text = "";
            if (courseList != null) courseList.SelectedIndex = 0;
            if (lessonList != null)
            {
                lessonList.Items.Clear();
                lessonList.Items.Add(new ListItem("--Chọn bài học--", ""));
            }
            if (typeList != null) typeList.SelectedValue = "LESSON";
            if (durationText != null) durationText.Text = "30";
            if (passingScoreText != null) passingScoreText.Text = "60";
            if (sortOrderText != null) sortOrderText.Text = "0";
            if (descriptionText != null) descriptionText.Text = "";
            if (instructionsText != null) instructionsText.Text = "";
        }

        private void ShowMessage(string message, bool isError)
        {
            Label msgLabel = (Label)FindControl("ActionMessageText");
            if (msgLabel != null)
            {
                msgLabel.Visible = true;
                msgLabel.Text = message;
                msgLabel.CssClass = isError ? "quiz-alert error" : "quiz-alert success";
            }
        }
    }
}
