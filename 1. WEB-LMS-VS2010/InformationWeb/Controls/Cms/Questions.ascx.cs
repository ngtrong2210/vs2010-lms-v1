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
    public partial class Questions : CmsStoreControl
    {
        protected override ModuleService Service
        {
            get { return ServiceRegistry.Questions; }
        }
        protected override string Operation
        {
            get { return "List"; }
        }
        protected override string PageTitle
        {
            get { return "Ngân hàng câu hỏi"; }
        }
        protected override string PageDescription
        {
            get { return "Quản lý câu hỏi dùng trong video và bài kiểm tra."; }
        }

        protected override IDictionary<string, object> Parameters()
        {
            return Values(
                "Search",
                SearchText.Text.Trim(),
                "Type",
                string.IsNullOrWhiteSpace(QuestionTypeFilterList.SelectedValue)
                    ? null
                    : (object)QuestionTypeFilterList.SelectedValue,
                "Page",
                1,
                "PageSize",
                100
            );
        }

        protected void DataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control edit = e.Row.FindControl("EditQuestionButton");
            if (manager != null && edit != null)
                manager.RegisterAsyncPostBackControl(edit);
        }

        protected void DataGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "EditQuestion")
                return;
            long id;
            if (!long.TryParse(Convert.ToString(e.CommandArgument), out id) || id <= 0)
                return;
            try
            {
                DataSet data = Service.GetDataSet("Get", Values("Id", id));
                if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
                    throw new InvalidOperationException("Không tìm thấy câu hỏi.");
                DataRow question = data.Tables[0].Rows[0];
                QuestionIdValue.Value = id.ToString(CultureInfo.InvariantCulture);
                QuestionTextInput.Text = WebData.Text(question, "QuestionText");
                QuestionDescriptionInput.Text = WebData.Text(question, "Explanation");
                QuestionScoreText.Text = Convert.ToString(
                    question["DefaultScore"],
                    CultureInfo.CurrentCulture
                );
                SelectValue(QuestionTypeList, WebData.Text(question, "QuestionType"));
                SelectValue(QuestionDifficultyList, WebData.Text(question, "Difficulty"));
                SelectValue(ShortAnswerModeList, WebData.Text(question, "ShortAnswerMode"));
                SelectValue(QuestionStatusList, WebData.Text(question, "Status"));
                QuestionOptionsText.Text = OptionLines(
                    data.Tables.Count > 1 ? data.Tables[1] : null
                );
                QuestionAnswerKeysText.Text = AnswerKeyLines(
                    data.Tables.Count > 2 ? data.Tables[2] : null
                );
                QuestionBlanksText.Text = BlankLines(data.Tables.Count > 3 ? data.Tables[3] : null);
                QuestionEditorOpenValue.Value = "1";
                QuestionEditorUpdatePanel.Update();
            }
            catch (Exception ex)
            {
                WebLog.Error("Nạp câu hỏi để chỉnh sửa thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
        }

        protected void CreateQuestionButton_Click(object sender, System.EventArgs e)
        {
            decimal score;
            if (!decimal.TryParse(QuestionScoreText.Text, out score) || score < 0)
            {
                ShowActionResult(ActionMessageText, "Điểm mặc định không hợp lệ.", false);
                return;
            }
            try
            {
                List<string> codes = new List<string>(),
                    texts = new List<string>(),
                    keys = Lines(QuestionAnswerKeysText.Text),
                    blankCodes = new List<string>(),
                    blankAnswers = new List<string>();
                List<bool> correct = new List<bool>();
                foreach (string line in Lines(QuestionOptionsText.Text))
                {
                    string[] parts = line.Split(new char[] { '|' }, 3);
                    if (parts.Length < 2)
                        throw new System.ArgumentException(
                            "Phương án phải theo dạng MÃ|Nội dung|1 hoặc 0."
                        );
                    codes.Add(parts[0].Trim());
                    texts.Add(parts[1].Trim());
                    correct.Add(
                        parts.Length > 2
                            && (
                                parts[2].Trim() == "1"
                                || parts[2]
                                    .Trim()
                                    .Equals("true", System.StringComparison.OrdinalIgnoreCase)
                            )
                    );
                }
                foreach (string line in Lines(QuestionBlanksText.Text))
                {
                    string[] parts = line.Split(new char[] { '|' }, 2);
                    if (parts.Length != 2)
                        throw new System.ArgumentException(
                            "Ô trống phải theo dạng BLANK_1|MÃ_ĐÁP_ÁN."
                        );
                    blankCodes.Add(parts[0].Trim());
                    blankAnswers.Add(parts[1].Trim());
                }
                long id;
                if (long.TryParse(QuestionIdValue.Value, out id) && id > 0)
                {
                    ServiceRegistry.Questions.UpdateQuestion(
                        id,
                        QuestionTypeList.SelectedValue,
                        QuestionTextInput.Text,
                        null,
                        QuestionDescriptionInput.Text.Trim(),
                        QuestionDifficultyList.SelectedValue,
                        score,
                        ShortAnswerModeList.SelectedValue,
                        QuestionStatusList.SelectedValue,
                        codes,
                        texts,
                        correct,
                        keys,
                        blankCodes,
                        blankAnswers,
                        CurrentUser.UserID,
                        CurrentUser.IsAdmin
                    );
                    ShowActionResult(ActionMessageText, "Đã cập nhật câu hỏi ID " + id + ".", true);
                }
                else
                {
                    id = ServiceRegistry.Questions.CreateQuestion(
                        QuestionTypeList.SelectedValue,
                        QuestionTextInput.Text,
                        null,
                        QuestionDescriptionInput.Text.Trim(),
                        QuestionDifficultyList.SelectedValue,
                        score,
                        ShortAnswerModeList.SelectedValue,
                        QuestionStatusList.SelectedValue,
                        codes,
                        texts,
                        correct,
                        keys,
                        blankCodes,
                        blankAnswers,
                        CurrentUser.UserID
                    );
                    ShowActionResult(ActionMessageText, "Đã tạo câu hỏi ID " + id + ".", true);
                }
                QuestionIdValue.Value = string.Empty;
                QuestionEditorOpenValue.Value = string.Empty;
                LoadData();
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Lưu câu hỏi thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
                QuestionEditorOpenValue.Value = "1";
            }
        }

        private static List<string> Lines(string value)
        {
            List<string> result = new List<string>();
            foreach (
                string line in (value ?? string.Empty).Split(
                    new char[] { '\r', '\n' },
                    System.StringSplitOptions.RemoveEmptyEntries
                )
            )
            {
                string item = line.Trim();
                if (item.Length > 0)
                    result.Add(item);
            }
            return result;
        }

        private static void SelectValue(ListControl control, string value)
        {
            if (control != null && control.Items.FindByValue(value) != null)
                control.SelectedValue = value;
        }

        private static string OptionLines(DataTable table)
        {
            StringBuilder result = new StringBuilder();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    result.AppendLine(
                        WebData.Text(row, "OptionCode")
                            + "|"
                            + WebData.Text(row, "OptionText")
                            + "|"
                            + (Convert.ToBoolean(row["IsCorrect"]) ? "1" : "0")
                    );
            return result.ToString().Trim();
        }

        private static string AnswerKeyLines(DataTable table)
        {
            StringBuilder result = new StringBuilder();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    result.AppendLine(WebData.Text(row, "AnswerText"));
            return result.ToString().Trim();
        }

        private static string BlankLines(DataTable table)
        {
            StringBuilder result = new StringBuilder();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    result.AppendLine(
                        WebData.Text(row, "BlankCode")
                            + "|"
                            + WebData.Text(row, "CorrectOptionCode")
                    );
            return result.ToString().Trim();
        }

        protected string QuestionDisplayText(object type, object text, object description)
        {
            return Server.HtmlEncode(
                Convert.ToString(type) == "CLOZE_DRAG_DROP"
                    ? (
                        string.IsNullOrWhiteSpace(Convert.ToString(description))
                            ? "Bài đọc kéo thả"
                            : Convert.ToString(description)
                    )
                    : Convert.ToString(text)
            );
        }

        protected string QuestionTypeLabel(object value)
        {
            string type = Convert.ToString(value);
            if (type == "SINGLE_CHOICE")
                return "Một lựa chọn";
            if (type == "MULTIPLE_CHOICE")
                return "Nhiều lựa chọn";
            if (type == "TRUE_FALSE")
                return "Đúng / Sai";
            if (type == "SHORT_ANSWER")
                return "Trả lời ngắn";
            if (type == "CLOZE_DRAG_DROP")
                return "Kéo thả";
            return Server.HtmlEncode(type);
        }

        protected string QuestionDifficultyLabel(object value)
        {
            string difficulty = Convert.ToString(value);
            return difficulty == "EASY" ? "Dễ"
                : difficulty == "HARD" ? "Khó"
                : "Trung bình";
        }

        protected string QuestionDifficultyClass(object value)
        {
            string difficulty = Convert.ToString(value);
            return difficulty == "EASY" ? "badge-soft-success"
                : difficulty == "HARD" ? "badge-soft-danger"
                : "badge-soft-warning";
        }

        protected string QuestionStatusLabel(object value)
        {
            return Convert.ToString(value) == "ACTIVE" ? "Hoạt động" : "Tạm ẩn";
        }

        protected string QuestionStatusClass(object value)
        {
            return Convert.ToString(value) == "ACTIVE"
                ? "badge-soft-success"
                : "badge-soft-warning";
        }

        protected string QuestionDateText(object value)
        {
            DateTime date;
            return DateTime.TryParse(Convert.ToString(value), out date)
                ? date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                : "—";
        }
    }
}
