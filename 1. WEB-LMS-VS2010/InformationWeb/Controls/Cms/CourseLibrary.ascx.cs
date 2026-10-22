using System;
using System.Data;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;
using LmsService.Course;

namespace InformationWeb.Controls.Cms
{
    /// <summary>
    /// UserControl quản lý thư viện khóa học trong CMS.
    /// Cung cấp chức năng thêm, sửa, xóa, xuất bản và lưu trữ khóa học.
    /// </summary>
    public partial class CourseLibrary : LmsControl
    {
        /// <summary>
        /// Xử lý sự kiện tải trang. Tải dữ liệu nếu không phải là postback.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        /// <summary>
        /// Tải dữ liệu cho trang: danh sách lọc và danh sách khóa học.
        /// </summary>
        public void LoadData()
        {
            BindFilterLists();
            BindCourseGrid();
        }

        /// <summary>
        /// Liên kết dữ liệu cho các danh sách lọc: danh mục, giảng viên, môn học.
        /// </summary>
        private void BindFilterLists()
        {
            CategoryService.InitDropDownList(CategoryFilter);
            CategoryService.InitDropDownList(CategoryList);

            BindUserList(TeacherFilter);
            BindUserList(TeacherList);

            BindClassSubjectList(ClassSubjectList);
        }

        /// <summary>
        /// Liên kết danh sách người dùng vào dropdown list. Hiển thị định dạng "Tên đầy đủ (Tên đăng nhập)".
        /// </summary>
        private void BindUserList(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Chọn giảng viên--", ""));

            try
            {
                var users = new SYS_Users();
                DataTable dtb = users.GetDataSet("SearchAll", null).Tables[0];
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

        /// <summary>
        /// Liên kết danh sách môn học (ClassSubject) vào dropdown list.
        /// </summary>
        private void BindClassSubjectList(DropDownList ddl)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("--Chọn môn học--", ""));

            try
            {
                var classObj = new SIM_Class();
                DataTable dtb = classObj.GetDataSet("GetClassSubjects", null).Tables[0];
                if (dtb != null)
                {
                    foreach (DataRow row in dtb.Rows)
                    {
                        string subjectName = WebData.Text(row, "SubjectName");
                        string classSubjectId = WebData.Text(row, "ClassSubjectID");

                        ddl.Items.Add(new ListItem(subjectName, classSubjectId));
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Liên kết dữ liệu cho GridView hiển thị danh sách khóa học.
        /// </summary>
        private void BindCourseGrid()
        {
            string condition = BuildFilterCondition();
            DataTable dtb = CourseService.GetCourseList(condition);
            CourseGrid.DataSource = dtb;
            CourseGrid.DataBind();
        }

        /// <summary>
        /// Xây dựng chuỗi điều kiện lọc dựa trên các tiêu chí: từ khóa tìm kiếm, danh mục, trạng thái, giảng viên.
        /// </summary>
        private string BuildFilterCondition()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            string search = SearchText.Text.Trim();
            string category = CategoryFilter.SelectedValue;
            string status = StatusFilter.SelectedValue;
            string teacher = TeacherFilter.SelectedValue;

            if (!string.IsNullOrEmpty(search))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("(Title LIKE '%" + search + "%' OR Code LIKE '%" + search + "%')");
            }

            if (!string.IsNullOrEmpty(category))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("CourseCategoryID = " + category);
            }

            if (!string.IsNullOrEmpty(status))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Status = '" + status + "'");
            }

            if (!string.IsNullOrEmpty(teacher))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("TeacherUserID = " + teacher);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Xử lý sự kiện nhấn nút thêm khóa học mới. Hiển thị form chỉnh sửa với tiêu đề "Thêm khóa học mới".
        /// </summary>
        protected void AddCourseButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = true;
            EditPanelTitle.Text = "Thêm khóa học mới";
            ClearForm();
            CourseIdValue.Value = "";
        }

        /// <summary>
        /// Xử lý sự kiện nhấn nút lọc. Tải lại danh sách khóa học theo điều kiện lọc.
        /// </summary>
        protected void FilterButton_Click(object sender, EventArgs e)
        {
            BindCourseGrid();
        }

        /// <summary>
        /// Xử lý sự kiện nhấn nút đặt lại. Xóa tất cả điều kiện lọc và tải lại danh sách khóa học.
        /// </summary>
        protected void ResetButton_Click(object sender, EventArgs e)
        {
            SearchText.Text = "";
            CategoryFilter.SelectedIndex = 0;
            StatusFilter.SelectedIndex = 0;
            TeacherFilter.SelectedIndex = 0;
            BindCourseGrid();
        }

        /// <summary>
        /// Xử lý các lệnh trên dòng GridView: EditCourse, DeleteCourse, PublishCourse, ArchiveCourse.
        /// </summary>
        protected void CourseGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            long courseId = Convert.ToInt64(e.CommandArgument);

            if (e.CommandName == "EditCourse")
            {
                EditCourse(courseId);
            }
            else if (e.CommandName == "PublishCourse")
            {
                PublishCourse(courseId);
            }
            else if (e.CommandName == "ArchiveCourse")
            {
                ArchiveCourse(courseId);
            }
            else if (e.CommandName == "DeleteCourse")
            {
                DeleteCourse(courseId);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi một dòng được tạo trong GridView. Định dạng hiển thị trạng thái khóa học.
        /// </summary>
        protected void CourseGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                string status = WebData.Text(drv, "Status");

                Label statusLabel = (Label)e.Row.FindControl("StatusLabel");
                if (statusLabel != null)
                {
                    statusLabel.Text = GetStatusText(status);
                    statusLabel.CssClass = "status-badge " + GetStatusClass(status);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện chuyển trang trên GridView. Tải lại dữ liệu cho trang mới.
        /// </summary>
        protected void CourseGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CourseGrid.PageIndex = e.NewPageIndex;
            BindCourseGrid();
        }

        /// <summary>
        /// Chuyển đổi mã trạng thái sang nhãn tiếng Việt.
        /// </summary>
        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "DRAFT": return "Nháp";
                case "PUBLISHED": return "Đã xuất bản";
                case "ARCHIVED": return "Lưu trữ";
                default: return status;
            }
        }

        /// <summary>
        /// Chuyển đổi mã trạng thái sang class CSS cho hiển thị màu sắc.
        /// </summary>
        private string GetStatusClass(string status)
        {
            switch (status)
            {
                case "DRAFT": return "status-draft";
                case "PUBLISHED": return "status-published";
                case "ARCHIVED": return "status-archived";
                default: return "";
            }
        }

        /// <summary>
        /// Tải thông tin khóa học vào form chỉnh sửa. Hiển thị panel chỉnh sửa với tiêu đề "Chỉnh sửa khóa học".
        /// </summary>
        private void EditCourse(long courseId)
        {
            DataTable dtb = CourseService.GetCourseList(null);
            DataRow[] rows = dtb.Select("CourseID = " + courseId);

            if (rows.Length > 0)
            {
                DataRow row = rows[0];
                EditPanel.Visible = true;
                EditPanelTitle.Text = "Chỉnh sửa khóa học";
                CourseIdValue.Value = courseId.ToString();
                CodeText.Text = WebData.Text(row, "Code");
                TitleText.Text = WebData.Text(row, "Title");
                SlugText.Text = WebData.Text(row, "Slug");
                ThumbnailUrlText.Text = WebData.Text(row, "ThumbnailUrl");
                ShortDescriptionText.Text = WebData.Text(row, "ShortDescription");
                DescriptionText.Text = WebData.Text(row, "Description");
                TeacherList.SelectedValue = WebData.Text(row, "TeacherUserID");
                CategoryList.SelectedValue = WebData.Text(row, "CourseCategoryID");
                LevelList.SelectedValue = WebData.Text(row, "Level");
                PassingScoreText.Text = WebData.Text(row, "PassingScore");
                ClassSubjectList.SelectedValue = WebData.Text(row, "ClassSubjectID");
                StatusList.SelectedValue = WebData.Text(row, "Status");
            }
        }

        /// <summary>
        /// Xuất bản khóa học. Hiển thị thông báo kết quả và tải lại danh sách.
        /// </summary>
        private void PublishCourse(long courseId)
        {
            bool result = CourseService.PublishCourse(courseId);

            if (result)
            {
                ShowMessage("Xuất bản khóa học thành công", false);
                BindCourseGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi xuất bản khóa học", true);
            }
        }

        /// <summary>
        /// Lưu trữ khóa học. Hiển thị thông báo kết quả và tải lại danh sách.
        /// </summary>
        private void ArchiveCourse(long courseId)
        {
            bool result = CourseService.ArchiveCourse(courseId);

            if (result)
            {
                ShowMessage("Lưu trữ khóa học thành công", false);
                BindCourseGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi lưu trữ khóa học", true);
            }
        }

        /// <summary>
        /// Xóa khóa học. Hiển thị thông báo kết quả và tải lại danh sách.
        /// </summary>
        private void DeleteCourse(long courseId)
        {
            bool result = CourseService.DeleteCourse(courseId);

            if (result)
            {
                ShowMessage("Xóa khóa học thành công", false);
                BindCourseGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi xóa khóa học", true);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn nút lưu. Thêm mới hoặc cập nhật khóa học dựa trên CourseIdValue.
        /// </summary>
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string code = CodeText.Text.Trim();
            string title = TitleText.Text.Trim();
            string slug = SlugText.Text.Trim();
            string thumbnailUrl = ThumbnailUrlText.Text.Trim();
            string shortDescription = ShortDescriptionText.Text.Trim();
            string description = DescriptionText.Text.Trim();
            long teacherUserId = Convert.ToInt64(TeacherList.SelectedValue);
            long? courseCategoryId = null;
            if (!string.IsNullOrEmpty(CategoryList.SelectedValue))
                courseCategoryId = Convert.ToInt64(CategoryList.SelectedValue);
            string level = LevelList.SelectedValue;
            decimal passingScore = Convert.ToDecimal(PassingScoreText.Text);
            string status = StatusList.SelectedValue;
            long? classSubjectId = null;
            if (!string.IsNullOrEmpty(ClassSubjectList.SelectedValue))
                classSubjectId = Convert.ToInt64(ClassSubjectList.SelectedValue);

            long courseId = 0;
            if (!string.IsNullOrEmpty(CourseIdValue.Value))
            {
                courseId = Convert.ToInt64(CourseIdValue.Value);
            }

            bool result = false;

            if (courseId > 0)
            {
                result = CourseService.UpdateCourse(courseId, code, title, slug, thumbnailUrl, shortDescription, description, teacherUserId, courseCategoryId, level, passingScore, status, CurrentUser.UserID, CurrentUser.DataGroupID, classSubjectId);
            }
            else
            {
                result = CourseService.CreateCourse(code, title, slug, thumbnailUrl, shortDescription, description, teacherUserId, courseCategoryId, level, passingScore, CurrentUser.UserID, CurrentUser.DataGroupID, classSubjectId);
            }

            if (result)
            {
                ShowMessage("Lưu khóa học thành công", false);
                EditPanel.Visible = false;
                BindCourseGrid();
            }
            else
            {
                ShowMessage("Có lỗi xảy ra khi lưu khóa học", true);
            }
        }

        /// <summary>
        /// Xử lý sự kiện nhấn nút hủy. Ẩn panel chỉnh sửa và xóa form.
        /// </summary>
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            EditPanel.Visible = false;
            ClearForm();
        }

        /// <summary>
        /// Xóa dữ liệu trong form chỉnh sửa, đặt lại về giá trị mặc định.
        /// </summary>
        private void ClearForm()
        {
            CodeText.Text = "";
            TitleText.Text = "";
            SlugText.Text = "";
            ThumbnailUrlText.Text = "";
            ShortDescriptionText.Text = "";
            DescriptionText.Text = "";
            TeacherList.SelectedIndex = 0;
            CategoryList.SelectedIndex = 0;
            LevelList.SelectedValue = "BEGINNER";
            PassingScoreText.Text = "60";
            ClassSubjectList.SelectedIndex = 0;
            StatusList.SelectedValue = "DRAFT";
        }

        /// <summary>
        /// Hiển thị thông báo cho người dùng. isError = true hiển thị thông báo lỗi (danger), false hiển thị thông báo thành công (success).
        /// </summary>
        private void ShowMessage(string message, bool isError)
        {
            ActionMessageText.Visible = true;
            ActionMessageText.Text = message;
            ActionMessageText.CssClass = isError ? "alert alert-danger" : "alert alert-success";
        }
    }
}
