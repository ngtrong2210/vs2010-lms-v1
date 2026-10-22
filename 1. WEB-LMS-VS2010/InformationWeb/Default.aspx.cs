using System;
using System.Web.Security;

namespace InformationWeb
{
    /// <summary>
    /// Trang mặc định của ứng dụng.
    /// Tự động chuyển hướng đến Dashboard nếu đã đăng nhập, hoặc trang Login nếu chưa.
    /// </summary>
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Xử lý sự kiện Load: chuyển hướng dựa trên trạng thái xác thực của người dùng.
        /// </summary>
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
