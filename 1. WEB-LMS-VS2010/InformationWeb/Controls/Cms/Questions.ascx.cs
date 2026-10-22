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
    /// UserControl quản lý ngân hàng câu hỏi trong CMS.
    /// Cung cấp chức năng thêm, sửa, xóa và hiển thị danh sách câu hỏi dùng trong video và bài kiểm tra.
    /// </summary>
    public partial class Questions : CmsStoreControl
    {
        /// <summary>
        /// Tiêu đề trang quản lý câu hỏi.
        /// </summary>
        protected override string PageTitle
        {
            get { return "Ngân hàng câu hỏi"; }
        }
        /// <summary>
        /// Mô tả trang quản lý câu hỏi.
        /// </summary>
        protected override string PageDescription
        {
            get { return "Quản lý câu hỏi dùng trong video và bài kiểm tra."; }
        }

        /// <summary>
        /// Đăng ký AsyncPostBackControl cho nút sửa câu hỏi trong mỗi dòng GridView.
        /// </summary>
        protected void DataGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            ScriptManager manager = ScriptManager.GetCurrent(Page);
            Control edit = e.Row.FindControl("EditQuestionButton");
            if (manager != null && edit != null)
                manager.RegisterAsyncPostBackControl(edit);
        }

        /// <summary>
        /// Xử lý sự kiện khi người dùng bấm nút sửa câu hỏi.
        /// Nạp dữ liệu câu hỏi vào form chỉnh sửa.
        /// </summary>
        protected void DataGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "EditQuestion")
                return;
            long id;
            if (!long.TryParse(Convert.ToString(e.CommandArgument), out id) || id <= 0)
                return;
            try
            {
                LMS_Questions question = new LMS_Questions();
                DataSet data = question.GetWithDetails(id);
                if (data == null || data.Tables.Count == 0 || data.Tables[0].Rows.Count == 0)
                    throw new InvalidOperationException("Không tìm thấy câu hỏi.");
                DataRow row = data.Tables[0].Rows[0];
                QuestionIdValue.Value = id.ToString(CultureInfo.InvariantCulture);
                QuestionTextInput.Text = WebData.Text(row, "QuestionText");
                QuestionDescriptionInput.Text = WebData.Text(row, "Explanation");
                QuestionScoreText.Text = Convert.ToString(
                    row["DefaultScore"],
                    CultureInfo.CurrentCulture
                );
                SelectValue(QuestionTypeList, WebData.Text(row, "QuestionType"));
                SelectValue(QuestionDifficultyList, WebData.Text(row, "Difficulty"));
                SelectValue(ShortAnswerModeList, WebData.Text(row, "ShortAnswerMode"));
                SelectValue(QuestionStatusList, WebData.Text(row, "Status"));
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

        /// <summary>
        /// Xử lý sự kiện tạo mới hoặc cập nhật câu hỏi.
        /// </summary>
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
                LMS_Questions question = new LMS_Questions();
                long id;
                if (long.TryParse(QuestionIdValue.Value, out id) && id > 0)
                {
                    question.UpdateQuestion(
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
                    id = question.CreateQuestion(
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

        /// <summary>
        /// Chuyển đổi chuỗi đa dòng thành danh sách các dòng không rỗng.
        /// </summary>
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

        /// <summary>
        /// Chọn giá trị trong DropDownList/ListControl theo value.
        /// </summary>
        private static void SelectValue(ListControl control, string value)
        {
            if (control != null && control.Items.FindByValue(value) != null)
                control.SelectedValue = value;
        }

        /// <summary>
        /// Chuyển đổi DataTable các lựa chọn thành chuỗi text định dạng code|text|isCorrect.
        /// </summary>
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

        /// <summary>
        /// Chuyển đổi DataTable các đáp án ngắn thành chuỗi text đa dòng.
        /// </summary>
        private static string AnswerKeyLines(DataTable table)
        {
            StringBuilder result = new StringBuilder();
            if (table != null)
                foreach (DataRow row in table.Rows)
                    result.AppendLine(WebData.Text(row, "AnswerText"));
            return result.ToString().Trim();
        }

        /// <summary>
        /// Chuyển đổi DataTable các ô trống thành chuỗi text định dạng blankCode|correctOptionCode.
        /// </summary>
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

        /// <summary>
        /// Lấy text hiển thị cho câu hỏi (đặc biệt xử lý cho loại CLOZE_DRAG_DROP).
        /// </summary>
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

        /// <summary>
        /// Chuyển đổi mã loại câu hỏi sang nhãn tiếng Việt.
        /// </summary>
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

        /// <summary>
        /// Chuyển đổi mã độ khó câu hỏi sang nhãn tiếng Việt.
        /// </summary>
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

        /// <summary>
        /// Chuyển đổi mã trạng thái câu hỏi sang nhãn tiếng Việt.
        /// </summary>
        protected string QuestionStatusLabel(object value)
        {
            return Convert.ToString(value) == "ACTIVE" ? "Hoạt động" : "Tạm ẩn";
        }

        /// <summary>
        /// Chuyển đổi mã trạng thái câu hỏi sang class CSS cho badge.
        /// </summary>
        protected string QuestionStatusClass(object value)
        {
            return Convert.ToString(value) == "ACTIVE"
                ? "badge-soft-success"
                : "badge-soft-warning";
        }

        /// <summary>
        /// Định dạng ngày tháng theo dd/MM/yyyy.
        /// </summary>
        protected string QuestionDateText(object value)
        {
            DateTime date;
            return DateTime.TryParse(Convert.ToString(value), out date)
                ? date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                : "—";
        }
    }
}
