using System;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;

namespace InformationWeb.Controls.Lms
{
    public partial class Profile : StudentControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            FullNameText.Text = Server.HtmlEncode(CurrentUser.FullName);
            UsernameText.Text = Server.HtmlEncode(CurrentUser.Username);
            EmailText.Text = Server.HtmlEncode(CurrentUser.Email);
            StudentCodeText.Text = Server.HtmlEncode(CurrentUser.StudentCode);
        }
    }
}
