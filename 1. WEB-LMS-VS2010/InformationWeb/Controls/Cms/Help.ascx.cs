using System;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using System.Web.UI.HtmlControls;
using System.Web.UI;

namespace InformationWeb.Controls.Cms
{
    public partial class Help : LmsControl
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
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            TextBox searchBox = (TextBox)FindControl("SearchText");
            if (searchBox != null)
            {
                string search = searchBox.Text.Trim();
                if (!string.IsNullOrEmpty(search))
                {
                    ShowMessage("Tính năng tìm kiếm đang được phát triển", true);
                }
            }
        }

        protected void ContactButton_Click(object sender, EventArgs e)
        {
            ShowMessage("Đang chuyển đến trang liên hệ...", false);
        }

        private void ShowMessage(string message, bool isError)
        {
            Label msgLabel = (Label)FindControl("ActionMessageText");
            if (msgLabel != null)
            {
                msgLabel.Visible = true;
                msgLabel.Text = message;
                msgLabel.CssClass = isError ? "help-alert error" : "help-alert success";
            }
        }
    }
}
