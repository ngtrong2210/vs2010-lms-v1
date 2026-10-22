using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsService;

namespace InformationWeb.Controls.Cms
{
    public partial class Courses : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Academic; }
        }
        protected override string Operation
        {
            get { return "GetCatalog"; }
        }
        protected override string PageTitle
        {
            get { return "Soạn nội dung môn học lớp"; }
        }
        protected override string PageDescription
        {
            get
            {
                return "Chọn đúng năm học, lớp và môn đã được phân công để xây dựng chương, bài học và bài tập.";
            }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values("ActorID", CurrentUser.UserID, "IsAdmin", CurrentUser.IsAdmin);
        }

        protected override void LoadData()
        {
            try
            {
                DataSet data = Service.GetDataSet(Operation, ConvertToParams(Parameters()));
                DataTable years = data != null && data.Tables.Count > 1 ? data.Tables[1] : null;
                DataTable offerings = data != null && data.Tables.Count > 8 ? data.Tables[8] : null;
                BindYears(years);
                DataTable filtered = FilterOfferings(offerings);
                WebData.Bind(DataGrid, filtered, EmptyText, ErrorText);
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp danh sách môn học lớp thất bại.", ex);
                WebData.Bind(DataGrid, null, EmptyText, ErrorText);
            }
        }

        private static object[] ConvertToParams(IDictionary<string, object> parameters)
        {
            List<object> list = new List<object>();
            foreach (var kvp in parameters)
            {
                list.Add("@" + kvp.Key);
                list.Add(kvp.Value ?? DBNull.Value);
            }
            return list.ToArray();
        }

        protected void DataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control settings = e.Row.FindControl("OpenSettingsButton");
            if (manager != null && settings != null)
                manager.RegisterAsyncPostBackControl(settings);
        }

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
                DataTable result = Service.GetDataTable(
                    "EnsureWorkspace",
                    ConvertToParams(Values(
                        "ClassSubjectID",
                        classSubjectId,
                        "ActorID",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
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
                DataTable result = ServiceRegistry.Courses.GetDataTable(
                    "Update",
                    ConvertToParams(Values(
                        "Id",
                        id,
                        "Code",
                        CourseSettingsCodeValue.Value,
                        "Title",
                        CourseSettingsTitleValue.Value,
                        "Slug",
                        DbString(CourseSettingsSlugValue.Value),
                        "ThumbnailUrl",
                        DbString(CourseSettingsThumbnailValue.Value),
                        "ShortDescription",
                        DbString(CourseSettingsShortDescriptionText.Text),
                        "Description",
                        DbString(CourseSettingsDescriptionValue.Value),
                        "TeacherId",
                        teacherId,
                        "CategoryId",
                        categoryId,
                        "ClassSubjectId",
                        classSubject,
                        "Level",
                        string.IsNullOrWhiteSpace(CourseSettingsLevelValue.Value)
                            ? "BEGINNER"
                            : CourseSettingsLevelValue.Value,
                        "PassingScore",
                        passingScore,
                        "Status",
                        CourseSettingsStatusList.SelectedValue,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    ))
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

        private void LoadCourseSettings(long courseId)
        {
            try
            {
                DataTable table = ServiceRegistry.Courses.GetDataTable(
                    "Get",
                    ConvertToParams(Values(
                        "Id",
                        courseId,
                        "ActorId",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    ))
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
