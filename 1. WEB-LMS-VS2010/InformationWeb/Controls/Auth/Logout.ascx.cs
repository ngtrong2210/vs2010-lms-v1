using System;
using System.Web.UI;
using InformationWeb.LmsInfrastructure;

namespace InformationWeb.Controls.Auth
{
    public partial class Logout : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession.SignOut();
            Response.Redirect(ResolveUrl("~/login"), false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
