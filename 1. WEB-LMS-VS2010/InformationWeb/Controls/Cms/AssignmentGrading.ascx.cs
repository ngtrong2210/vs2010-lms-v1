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
    public partial class AssignmentGrading : CmsStoreControl
    {
        private SIM_Teaching _teachingService;
        private SIM_Class _academicService;
        private SIM_Teaching TeachingService
        {
            get { return _teachingService ?? (_teachingService = new SIM_Teaching()); }
        }
        private SIM_Class AcademicService
        {
            get { return _academicService ?? (_academicService = new SIM_Class()); }
        }

        protected override string Operation
        {
            get { return "SubmissionList"; }
        }
        protected override string PageTitle
        {
            get { return "Chấm và trả bài"; }
        }
        protected override string PageDescription
        {
            get { return "Theo dõi bài nộp, xem lịch sử, nhập điểm và phản hồi cho học viên."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            long classSubjectId;
            object selectedClass =
                long.TryParse(ClassSubjectFilterList.SelectedValue, out classSubjectId)
                && classSubjectId > 0
                    ? (object)classSubjectId
                    : null;
            object selectedStatus = string.IsNullOrWhiteSpace(
                SubmissionStatusFilterList.SelectedValue
            )
                ? null
                : (object)SubmissionStatusFilterList.SelectedValue;
            return Values(
                "ActorID",
                CurrentUser.UserID,
                "IsAdmin",
                CurrentUser.IsAdmin,
                "ClassSubjectID",
                selectedClass,
                "Status",
                selectedStatus,
                "Search",
                SearchText.Text.Trim(),
                "Page",
                1,
                "PageSize",
                100
            );
        }

        protected override DataTable GetDataTable(string operation, IDictionary<string, object> parameters)
        {
            return TeachingService.GetDataTable(operation, ConvertToParams(parameters));
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

        protected override void LoadData()
        {
            try
            {
                DataSet catalog = AcademicService.GetDataSet(
                    "GetCatalog",
                    ConvertToParams(Values("ActorID", CurrentUser.UserID, "IsAdmin", CurrentUser.IsAdmin))
                );
                BindClassSubjects(
                    catalog != null && catalog.Tables.Count > 8 ? catalog.Tables[8] : null
                );
                DataTable table = GetDataTable(Operation, Parameters());
                WebData.Bind(DataGrid, table, EmptyText, ErrorText);
                long selectedId;
                if (
                    !IsPostBack
                    && long.TryParse(
                        Convert.ToString(Request.QueryString["submissionId"]),
                        out selectedId
                    )
                    && selectedId > 0
                )
                {
                    DataRow selected = FindSubmission(table, selectedId);
                    if (selected != null)
                        BindSelectedSubmission(selected);
                }
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp danh sách bài nộp thất bại.", ex);
                WebData.Bind(DataGrid, null, EmptyText, ErrorText);
            }
        }

        protected void GradeButton_Click(object sender, System.EventArgs e)
        {
            ExecuteGrade("GRADE");
        }

        protected void ReturnButton_Click(object sender, System.EventArgs e)
        {
            ExecuteGrade("RETURN");
        }

        protected void DataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control open = e.Row.FindControl("OpenGradingButton");
            if (manager != null && open != null)
                manager.RegisterAsyncPostBackControl(open);
        }

        protected void DataGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "OpenGrading")
                return;
            long id;
            if (!long.TryParse(Convert.ToString(e.CommandArgument), out id) || id <= 0)
                return;
            try
            {
                DataTable table = GetDataTable(Operation, Parameters());
                DataRow selected = FindSubmission(table, id);
                if (selected == null)
                    throw new InvalidOperationException("Không tìm thấy bài nộp.");
                BindSelectedSubmission(selected);
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp bài nộp để chấm thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
            GradingModalUpdatePanel.Update();
        }

        protected string SubmissionUrl(object value)
        {
            return ResolveUrl(
                "~/cms/assignments?submissionId=" + Server.UrlEncode(Convert.ToString(value))
            );
        }

        protected string FormatSubmissionDate(object value)
        {
            if (value == null || value == DBNull.Value)
                return "—";
            DateTime date;
            return DateTime.TryParse(
                Convert.ToString(value, CultureInfo.InvariantCulture),
                out date
            )
                ? date.ToString("dd/MM/yyyy HH:mm")
                : Server.HtmlEncode(Convert.ToString(value));
        }

        protected bool IsTrue(object value)
        {
            return value != null && value != DBNull.Value && Convert.ToBoolean(value);
        }

        protected string SubmissionStatusText(object value)
        {
            string status = Convert.ToString(value).ToUpperInvariant();
            if (status == "DRAFT")
                return "Bản nháp";
            if (status == "SUBMITTED" || status == "LATE")
                return "Chờ chấm";
            if (status == "GRADED")
                return "Đã chấm";
            if (status == "RETURNED")
                return "Trả bổ sung";
            return Server.HtmlEncode(status);
        }

        protected string SubmissionStatusClass(object value)
        {
            string status = Convert.ToString(value).ToUpperInvariant();
            if (status == "GRADED")
                return "badge-soft-success";
            if (status == "RETURNED")
                return "badge-soft-danger";
            if (status == "SUBMITTED" || status == "LATE")
                return "badge-soft-primary";
            return "badge-soft-warning";
        }

        protected string SubmissionScoreText(object scoreValue, object maxValue)
        {
            if (scoreValue == null || scoreValue == DBNull.Value)
                return "—";
            return FormatDecimal(scoreValue) + "/" + FormatDecimal(maxValue);
        }

        private void ExecuteGrade(string action)
        {
            long id;
            if (!long.TryParse(SubmissionIdText.Text, out id) || id <= 0)
            {
                GradingModal.Visible = true;
                ShowActionResult(ActionMessageText, "Bài nộp không hợp lệ.", false);
                return;
            }
            object scoreValue = null;
            if (action == "GRADE")
            {
                decimal score;
                if (
                    !decimal.TryParse(
                        GradeScoreText.Text,
                        NumberStyles.Number,
                        CultureInfo.CurrentCulture,
                        out score
                    )
                    && !decimal.TryParse(
                        GradeScoreText.Text,
                        NumberStyles.Number,
                        CultureInfo.InvariantCulture,
                        out score
                    )
                )
                {
                    GradingModal.Visible = true;
                    ShowActionResult(ActionMessageText, "Điểm không hợp lệ.", false);
                    return;
                }
                if (score < 0)
                {
                    GradingModal.Visible = true;
                    ShowActionResult(ActionMessageText, "Điểm không được nhỏ hơn 0.", false);
                    return;
                }
                scoreValue = score;
            }
            try
            {
                GradeActionList.SelectedValue = action;
                bool ok = TeachingService.ExecNonQuery(
                    "Grade",
                    Values(
                        "AssignmentSubmissionID",
                        id,
                        "Score",
                        scoreValue,
                        "Feedback",
                        GradeFeedbackText.Text.Trim(),
                        "Action",
                        action,
                        "ActorID",
                        CurrentUser.UserID,
                        "IsAdmin",
                        CurrentUser.IsAdmin
                    )
                );
                ShowActionResult(
                    ActionMessageText,
                    ok
                        ? (
                            action == "GRADE"
                                ? "Đã lưu điểm và nhận xét."
                                : "Đã trả bài để học viên bổ sung."
                        )
                        : "Không thể cập nhật kết quả.",
                    ok
                );
                if (ok)
                {
                    GradingModal.Visible = false;
                    LoadData();
                }
                else
                    GradingModal.Visible = true;
            }
            catch (Exception ex)
            {
                WebLog.Error("Cập nhật kết quả chấm bài thất bại.", ex);
                GradingModal.Visible = true;
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
        }

        private void BindSelectedSubmission(DataRow row)
        {
            SubmissionIdText.Text = WebData.Text(row, "AssignmentSubmissionID");
            GradeScoreText.Text =
                row["Score"] == DBNull.Value ? string.Empty : FormatDecimal(row["Score"]);
            GradeFeedbackText.Text = WebData.Text(row, "Feedback");
            SelectedAttemptText.Text = Server.HtmlEncode(WebData.Text(row, "AttemptNumber"));
            SelectedLessonText.Text = Server.HtmlEncode(WebData.Text(row, "LessonTitle"));
            SelectedStudentText.Text = Server.HtmlEncode(
                WebData.Text(row, "StudentName")
                    + " · "
                    + WebData.Text(row, "StudentCode")
                    + " · "
                    + WebData.Text(row, "ClassName")
            );
            SelectedSubjectText.Text = Server.HtmlEncode(
                WebData.Text(row, "SubjectName")
                    + " · "
                    + WebData.Text(row, "YearName")
                    + " · HK"
                    + WebData.Text(row, "Semester")
            );
            SelectedSubmittedAtText.Text = FormatSubmissionDate(row["SubmittedAt"]);
            string submission = WebData.Text(row, "SubmissionText");
            SelectedSubmissionText.Text = Server.HtmlEncode(
                submission.Length == 0 ? "Học viên không nhập nội dung ghi chú." : submission
            );
            SelectedMaxScoreText.Text = Server.HtmlEncode(FormatDecimal(row["AssignmentMaxScore"]));
            string fileUrl = SafeFileUrl(WebData.Text(row, "FileUrl"));
            string fileName = WebData.Text(row, "OriginalFileName");
            SelectedFileLink.Visible = fileUrl.Length > 0;
            SelectedFileLink.NavigateUrl = fileUrl;
            SelectedFileLink.Text = Server.HtmlEncode(
                "Tải " + (fileName.Length == 0 ? "file bài làm" : fileName)
            );
            GradingModal.Visible = true;
        }

        private static DataRow FindSubmission(DataTable table, long id)
        {
            if (table == null)
                return null;
            foreach (DataRow row in table.Rows)
                if (WebData.Long(row, "AssignmentSubmissionID") == id)
                    return row;
            return null;
        }

        private string SafeFileUrl(string value)
        {
            string url = (value ?? string.Empty).Trim();
            if (url.StartsWith("~/", StringComparison.Ordinal))
                return ResolveUrl(url);
            if (url.StartsWith("/", StringComparison.Ordinal))
                return ResolveUrl("~" + url);
            Uri absolute;
            if (
                Uri.TryCreate(url, UriKind.Absolute, out absolute)
                && (absolute.Scheme == Uri.UriSchemeHttp || absolute.Scheme == Uri.UriSchemeHttps)
            )
                return url;
            return string.Empty;
        }

        private static string FormatDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return "0";
            decimal number;
            return decimal.TryParse(
                Convert.ToString(value, CultureInfo.InvariantCulture),
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out number
            )
                ? number.ToString("0.##", CultureInfo.CurrentCulture)
                : Convert.ToString(value);
        }

        private void BindClassSubjects(DataTable table)
        {
            string selected = ClassSubjectFilterList.SelectedValue;
            ClassSubjectFilterList.Items.Clear();
            ClassSubjectFilterList.Items.Add(new ListItem("Tất cả môn học lớp", string.Empty));
            if (table != null)
                foreach (DataRow row in table.Rows)
                {
                    if (WebData.Long(row, "OnlineCourseID") <= 0)
                        continue;
                    string label =
                        WebData.Text(row, "SubjectName")
                        + " · "
                        + WebData.Text(row, "ClassName")
                        + " · "
                        + WebData.Text(row, "YearName")
                        + " · HK"
                        + WebData.Text(row, "Semester");
                    ClassSubjectFilterList.Items.Add(
                        new ListItem(label, WebData.Text(row, "ClassSubjectID"))
                    );
                }
            if (ClassSubjectFilterList.Items.FindByValue(selected) != null)
                ClassSubjectFilterList.SelectedValue = selected;
        }
    }
}
