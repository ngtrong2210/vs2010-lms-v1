using System;
using System.Web.Security;

namespace InformationWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string target = Request.IsAuthenticated
                ? "~/Pages/Lms/Dashboard.aspx"
                : FormsAuthentication.LoginUrl;
            Response.Redirect(ResolveUrl(target), false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
