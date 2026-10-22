using System;
using System.Security.Principal;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using InformationWeb.LmsInfrastructure;

namespace InformationWeb
{
    /// <summary>
    /// Lớp Global quản lý các sự kiện toàn cục của ứng dụng ASP.NET.
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Xử lý sự kiện khi ứng dụng khởi động. Đăng ký các route.
        /// </summary>
        protected void Application_Start(object sender, EventArgs e)
        {
            LmsRouteConfig.Register(RouteTable.Routes);
        }

        /// <summary>
        /// Xử lý sự kiện xác thực request, thiết lập Principal cho người dùng từ Forms Authentication cookie.
        /// </summary>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || string.IsNullOrWhiteSpace(cookie.Value))
                return;
            try
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (ticket == null || ticket.Expired)
                    return;
                string[] roles = string.IsNullOrWhiteSpace(ticket.UserData)
                    ? new string[0]
                    : ticket.UserData.Split(',');
                Context.User = new GenericPrincipal(new FormsIdentity(ticket), roles);
            }
            catch (Exception ex)
            {
                WebLog.Error("Không đọc được Forms Authentication ticket.", ex);
            }
        }

        /// <summary>
        /// Xử lý sự kiện khi có lỗi chưa được xử lý xảy ra trong ứng dụng. Ghi log lỗi.
        /// </summary>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (exception != null)
                WebLog.Error("Lỗi ứng dụng chưa xử lý: " + Request.RawUrl, exception);
        }
    }
}
