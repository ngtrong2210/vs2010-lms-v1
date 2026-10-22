using System;
using System.Web;
using System.Web.Security;
using LmsObject;

namespace InformationWeb.LmsInfrastructure
{
    public static class UserSession
    {
        private const string Key = "LMS.CURRENT_USER";
        public static SYS_Users Current
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context == null || context.Session == null) return null;
                SYS_Users user = context.Session[Key] as SYS_Users;
                if (user == null && context.Request.IsAuthenticated)
                {
                    long userId;
                    if (long.TryParse(context.User.Identity.Name, out userId))
                    {
                        var userObj = new SYS_Users();
                        userObj.ID = userId;
                        if (userObj.Load())
                        {
                            user = userObj;
                            context.Session[Key] = user;
                        }
                    }
                }
                return user;
            }
        }

        public static void SignIn(SYS_Users user, bool persistent)
        {
            if (user == null) throw new ArgumentNullException("user");
            HttpContext context = HttpContext.Current;
            context.Session.Clear();
            context.Session.Abandon();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(120), persistent, user.Role ?? string.Empty, FormsAuthentication.FormsCookiePath);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            cookie.HttpOnly = true;
            cookie.Secure = context.Request.IsSecureConnection;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (persistent) cookie.Expires = ticket.Expiration;
            context.Response.Cookies.Add(cookie);
        }

        public static void SignOut()
        {
            HttpContext context = HttpContext.Current;
            FormsAuthentication.SignOut();
            if (context != null && context.Session != null) { context.Session.Clear(); context.Session.Abandon(); }
        }
    }
}
