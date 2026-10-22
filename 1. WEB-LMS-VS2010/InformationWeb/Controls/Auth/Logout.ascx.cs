using System;
using System.Web.UI;
using InformationWeb.LmsInfrastructure;

namespace InformationWeb.Controls.Auth
{
    /// <summary>
    /// UserControl xử lý đăng xuất người dùng.
    /// Khi load sẽ gọi UserSession.SignOut() và chuyển hướng về trang login.
    /// </summary>
    public partial class Logout : UserControl
    {
        /// <summary>
        /// Xử lý sự kiện Load: đăng xuất và chuyển hướng về trang login.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            UserSession.SignOut();
            Response.Redirect(ResolveUrl("~/login"), false);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}
