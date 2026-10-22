using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.Controls.Cms
{
    /// <summary>
    /// UserControl quản lý khóa học trong CMS.
    /// Cung cấp chức năng xem danh sách, lọc, tạo workspace và chỉnh sửa thiết lập khóa học.
    /// </summary>
    public partial class Courses : CmsStoreControl
    {
        /// <summary>
        /// Tên thao tác cho stored procedure.
        /// </summary>
        protected override string Operation
        {
            get { return "GetCatalog"; }
        }

        /// <summary>
        /// Tiêu đề trang quản lý khóa học.
        /// </summary>
        protected override string PageTitle
        {
            get { return "Soạn nội dung môn học lớp"; }
        }

        /// <summary>
        /// Mô tả trang quản lý khóa học.
        /// </summary>
        protected override string PageDescription
        {
            get
            {
                return "Chọn đúng năm học, lớp và môn đã được phân công để xây dựng chương, bài học và bài tập.";
            }
        }

        /// <summary>
        /// Khởi tạo control và tải dữ liệu khi không phải postback.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!IsPostBack) LoadData();
        }

        /// <summary>
        /// Xử lý sự kiện click nút tìm kiếm.
        /// </summary>
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Xử lý sự kiện phân trang DataGrid.
        /// </summary>
        protected void DataGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataGrid.PageIndex = e.NewPageIndex;
            LoadData();
        }

        /// <summary>
        /// Tải dữ liệu danh sách khóa học và binding vào DataGrid.
        /// </summary>
        protected override void LoadData()
        {
            try
            {
                SIM_Courses courses = new SIM_Courses();
                DataTable offerings = courses.GetCatalog(1, 1000);
                DataTable years = GetYears();
                BindYears(years);
                DataTable filtered = FilterOfferings(offerings);
                DataGrid.DataSource = filtered;
                DataGrid.DataBind();
                EmptyText.Visible = filtered == null || filtered.Rows.Count == 0;
                ErrorText.Visible = false;
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp danh sách môn học lớp thất bại.", ex);
                DataGrid.DataSource = null;
                DataGrid.DataBind();
                EmptyText.Visible = true;
                ErrorText.Visible = true;
                ErrorText.Text = "Lỗi tải danh sách khóa học: " + ex.Message;
            }
        }

        /// <summary>
        /// Xử lý sự kiện RowCreated để đăng ký async postback control.
        /// </summary>
        protected void DataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control settings = e.Row.FindControl("OpenSettingsButton");
            if (manager != null && settings != null)
                manager.RegisterAsyncPostBackControl(settings);
        }

        /// <summary>
        /// Xử lý các lệnh từ DataGrid (CreateWorkspace, Settings).
        /// </summary>
        protected void DataGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OpenSettings")
            {
                long courseId;
                if (
                    long.TryParse(Convert.ToString(e.CommandArgument), out courseId)
                    && courseId > 0
                )
                {
                    LoadCourseSettings(courseId);
                    CourseSettingsUpdatePanel.Update();
                }
                return;
            }
            if (e.CommandName != "EnsureWorkspace")
                return;
            long classSubjectId;
            if (
                !long.TryParse(System.Convert.ToString(e.CommandArgument), out classSubjectId)
                || classSubjectId <= 0
            )
                return;
            try
            {
                SIM_Courses courses = new SIM_Courses();
                DataTable result = courses.EnsureWorkspace(
                    classSubjectId,
                    CurrentUser.UserID,
                    CurrentUser.IsAdmin
                );
                bool ok = result != null && result.Rows.Count > 0;
                ShowActionResult(
                    ActionMessageText,
                    ok
                        ? "Đã khởi tạo nội dung môn học lớp."
                        : "Không thể khởi tạo nội dung môn học lớp.",
                    ok
                );
                LoadData();
            }
            catch (System.Exception ex)
            {
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
        }

        /// <summary>
        /// Xử lý sự kiện lưu thiết lập khóa học.
        /// </summary>
        protected void CourseSettingsSaveButton_Click(object sender, EventArgs e)
        {
            long id,
                teacherId,
                classSubjectId;
            decimal passingScore;
            if (
                !long.TryParse(CourseSettingsIdValue.Value, out id)
                || id <= 0
                || !long.TryParse(CourseSettingsTeacherIdValue.Value, out teacherId)
                || teacherId <= 0
                || !decimal.TryParse(CourseSettingsPassingScoreText.Text, out passingScore)
                || passingScore < 0
                || passingScore > 100
            )
            {
                ShowActionResult(ActionMessageText, "Thiết lập môn học không hợp lệ.", false);
                CourseSettingsOpenValue.Value = "1";
                return;
            }
            object categoryId = OptionalLong(CourseSettingsCategoryIdValue.Value),
                classSubject = long.TryParse(
                    CourseSettingsClassSubjectIdValue.Value,
                    out classSubjectId
                )
                && classSubjectId > 0
                    ? (object)classSubjectId
                    : DBNull.Value;
            try
            {
                SIM_Courses courses = new SIM_Courses();
                DataTable result = courses.UpdateCourse(
                    id,
                    CourseSettingsCodeValue.Value,
                    CourseSettingsTitleValue.Value,
                    DbString(CourseSettingsSlugValue.Value),
                    DbString(CourseSettingsThumbnailValue.Value),
                    DbString(CourseSettingsShortDescriptionText.Text),
                    DbString(CourseSettingsDescriptionValue.Value),
                    teacherId,
                    categoryId,
                    classSubject,
                    string.IsNullOrWhiteSpace(CourseSettingsLevelValue.Value)
                        ? "BEGINNER"
                        : CourseSettingsLevelValue.Value,
                    passingScore,
                    CourseSettingsStatusList.SelectedValue,
                    CurrentUser.UserID,
                    CurrentUser.IsAdmin
                );
                bool ok =
                    result != null
                    && result.Rows.Count > 0
                    && Convert.ToInt32(result.Rows[0][0]) > 0;
                ShowActionResult(
                    ActionMessageText,
                    ok
                        ? "Đã cập nhật thiết lập môn học lớp."
                        : "Không thể cập nhật thiết lập môn học lớp.",
                    ok
                );
                CourseSettingsOpenValue.Value = ok ? string.Empty : "1";
                if (ok)
                    LoadData();
            }
            catch (Exception ex)
            {
                WebLog.Error("Cập nhật thiết lập môn học thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
                CourseSettingsOpenValue.Value = "1";
            }
        }

        /// <summary>
        /// Tải thiết lập của khóa học theo ID.
        /// </summary>
        private void LoadCourseSettings(long courseId)
        {
            try
            {
                SIM_Courses courses = new SIM_Courses();
                DataTable table = courses.GetCourseById(
                    courseId,
                    CurrentUser.UserID,
                    CurrentUser.IsAdmin
                );
                if (table == null || table.Rows.Count == 0)
                    throw new InvalidOperationException("Không tìm thấy môn học lớp.");
                DataRow row = table.Rows[0];
                CourseSettingsIdValue.Value = courseId.ToString(CultureInfo.InvariantCulture);
                CourseSettingsCodeValue.Value = WebData.Text(row, "Code");
                CourseSettingsTitleValue.Value = WebData.Text(row, "Title");
                CourseSettingsTitleText.Text = Server.HtmlEncode(WebData.Text(row, "Title"));
                CourseSettingsSlugValue.Value = WebData.Text(row, "Slug");
                CourseSettingsThumbnailValue.Value = WebData.Text(row, "ThumbnailUrl");
                CourseSettingsShortDescriptionText.Text = WebData.Text(row, "ShortDescription");
                CourseSettingsDescriptionValue.Value = WebData.Text(row, "Description");
                CourseSettingsTeacherIdValue.Value = WebData.Text(row, "TeacherId");
                CourseSettingsCategoryIdValue.Value = WebData.Text(row, "CategoryId");
                CourseSettingsClassSubjectIdValue.Value = WebData.Text(row, "ClassSubjectId");
                CourseSettingsLevelValue.Value = WebData.Text(row, "Level");
                CourseSettingsPassingScoreText.Text = Convert.ToString(
                    row["PassingScore"],
                    CultureInfo.CurrentCulture
                );
                string status = WebData.Text(row, "Status");
                if (CourseSettingsStatusList.Items.FindByValue(status) != null)
                    CourseSettingsStatusList.SelectedValue = status;
                CourseSettingsContextText.Text = Server.HtmlEncode(
                    "Thiết lập nội dung, điểm đạt và trạng thái xuất bản."
                );
                CourseSettingsOpenValue.Value = "1";
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp thiết lập môn học thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
        }

        private static object OptionalLong(string input)
        {
            long value;
            return long.TryParse(input, out value) && value > 0 ? (object)value : DBNull.Value;
        }

        private static object DbString(string input)
        {
            return string.IsNullOrWhiteSpace(input) ? (object)DBNull.Value : input.Trim();
        }

        protected bool HasCourse(object value)
        {
            long id;
            return long.TryParse(System.Convert.ToString(value), out id) && id > 0;
        }

        protected string CourseContentUrl(object value)
        {
            return ResolveUrl("~/cms/courses/" + System.Convert.ToString(value) + "/content");
        }

        protected string CourseStatusLabel(object courseId, object status)
        {
            if (!HasCourse(courseId))
                return "Chưa khởi tạo";
            string value = System.Convert.ToString(status);
            if (value == "PUBLISHED")
                return "Đã xuất bản";
            if (value == "ARCHIVED")
                return "Lưu trữ";
            return "Bản nháp";
        }

        /// <summary>
        /// Lấy danh sách năm học hoạt động.
        /// </summary>
        private DataTable GetYears()
        {
            SIM_Year year = new SIM_Year();
            return year.GetActiveYears();
        }

        /// <summary>
        /// Binding danh sách năm học vào dropdown.
        /// </summary>
        private void BindYears(DataTable years)
        {
            string selected = YearFilterList.SelectedValue;
            YearFilterList.Items.Clear();
            YearFilterList.Items.Add(new ListItem("Tất cả năm học", string.Empty));
            if (years != null)
                foreach (DataRow row in years.Rows)
                    YearFilterList.Items.Add(
                        new ListItem(WebData.Text(row, "YearName"), WebData.Text(row, "YearID"))
                    );
            if (YearFilterList.Items.FindByValue(selected) != null)
                YearFilterList.SelectedValue = selected;
        }

        /// <summary>
        /// Lọc danh sách khóa học theo các tiêu chí: năm học, kỳ học, trạng thái, từ khóa tìm kiếm.
        /// </summary>
        private DataTable FilterOfferings(DataTable source)
        {
            if (source == null)
                return null;
            DataTable result = source.Clone();
            string term = SearchText.Text.Trim().ToLowerInvariant(),
                year = YearFilterList.SelectedValue,
                semester = SemesterFilterList.SelectedValue,
                status = CourseStatusFilterList.SelectedValue;
            foreach (DataRow row in source.Rows)
            {
                bool hasCourse = WebData.Long(row, "OnlineCourseID") > 0;
                string rowStatus = hasCourse ? WebData.Text(row, "OnlineCourseStatus") : "EMPTY";
                string searchable = (
                    WebData.Text(row, "SubjectName")
                    + " "
                    + WebData.Text(row, "SubjectID")
                    + " "
                    + WebData.Text(row, "ClassName")
                    + " "
                    + WebData.Text(row, "TeacherName")
                ).ToLowerInvariant();
                if (year.Length > 0 && WebData.Text(row, "YearID") != year)
                    continue;
                if (semester.Length > 0 && WebData.Text(row, "Semester") != semester)
                    continue;
                if (
                    status.Length > 0
                    && !rowStatus.Equals(status, System.StringComparison.OrdinalIgnoreCase)
                )
                    continue;
                if (term.Length > 0 && !searchable.Contains(term))
                    continue;
                result.ImportRow(row);
            }
            return result;
        }
    }
}
