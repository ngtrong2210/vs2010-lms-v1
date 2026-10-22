using System;
using System.Web;
using System.Web.UI;
using LmsObject;

namespace InformationWeb.LmsInfrastructure
{
    /// <summary>
    /// Lớp base cho các trang yêu cầu xác thực người dùng.
    /// </summary>
    public abstract class AuthenticatedPage : Page
    {
        /// <summary>
        /// Lấy thông tin người dùng hiện tại từ session.
        /// </summary>
        public SYS_Users CurrentUser { get { return UserSession.Current; } }

        /// <summary>
        /// Khởi tạo trang và kiểm tra xác thực.
        /// </summary>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session != null) ViewStateUserKey = Session.SessionID;
            if (!Request.IsAuthenticated || CurrentUser == null)
            {
                Response.Redirect(ResolveUrl("~/login?returnUrl=" + HttpUtility.UrlEncode(Request.RawUrl)), true);
                return;
            }
            AuthorizeCurrentUser();
        }
        /// <summary>
        /// Phương thức ảo để các lớp con override kiểm tra quyền truy cập.
        /// </summary>
        protected virtual void AuthorizeCurrentUser() { }

        /// <summary>
        /// Kiểm tra quyền của người dùng, nếu không có quyền thì chuyển hướng đến trang 403.
        /// </summary>
        /// <param name="permission">Tên quyền cần kiểm tra.</param>
        protected void RequirePermission(string permission) { if (CurrentUser == null || !CurrentUser.HasPermission(permission)) RedirectForbidden(); }

        /// <summary>
        /// Chuyển hướng đến trang 403 (Forbidden).
        /// </summary>
        protected void RedirectForbidden()
        {
            Response.Redirect(ResolveUrl("~/403"), true);
        }

        /// <summary>
        /// Lấy giá trị long từ route parameter.
        /// </summary>
        /// <param name="name">Tên parameter trong route.</param>
        /// <returns>Giá trị long hoặc 0 nếu không hợp lệ.</returns>
        protected long RouteLong(string name)
        {
            object raw = RouteData.Values[name]; long value;
            return raw != null && long.TryParse(Convert.ToString(raw), out value) ? value : 0L;
        }
    }

    /// <summary>
    /// Lớp base cho các trang CMS (Content Management System) - chỉ Admin và Teacher được truy cập.
    /// </summary>
    public abstract class CmsPage : AuthenticatedPage
    {
        protected override void AuthorizeCurrentUser() { if (CurrentUser == null || (!CurrentUser.IsAdmin && !CurrentUser.IsTeacher)) RedirectForbidden(); }
    }

    /// <summary>
    /// Lớp base cho các trang của sinh viên - chỉ Student được truy cập.
    /// </summary>
    public abstract class StudentPage : AuthenticatedPage
    {
        protected override void AuthorizeCurrentUser() { if (CurrentUser == null || !CurrentUser.IsStudent) RedirectForbidden(); }
    }

    /// <summary>
    /// Lớp base cho các UserControl yêu cầu xác thực người dùng.
    /// </summary>
    public abstract class AuthenticatedControl : UserControl
    {
        /// <summary>
        /// Lấy thông tin người dùng hiện tại từ session.
        /// </summary>
        public SYS_Users CurrentUser { get { return UserSession.Current; } }

        /// <summary>
        /// Khởi tạo control và kiểm tra xác thực.
        /// </summary>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Session != null) Page.ViewStateUserKey = Session.SessionID;
            if (!Request.IsAuthenticated || CurrentUser == null)
            {
                Response.Redirect(ResolveUrl("~/login?returnUrl=" + HttpUtility.UrlEncode(Request.RawUrl)), true);
                return;
            }
            AuthorizeCurrentUser();
        }

        /// <summary>
        /// Phương thức ảo để các lớp con override kiểm tra quyền truy cập.
        /// </summary>
        protected virtual void AuthorizeCurrentUser() { }

        /// <summary>
        /// Kiểm tra quyền của người dùng, nếu không có quyền thì chuyển hướng đến trang 403.
        /// </summary>
        /// <param name="permission">Tên quyền cần kiểm tra.</param>
        protected void RequirePermission(string permission) { if (CurrentUser == null || !CurrentUser.HasPermission(permission)) RedirectForbidden(); }

        /// <summary>
        /// Chuyển hướng đến trang 403 (Forbidden).
        /// </summary>
        protected void RedirectForbidden() { Response.Redirect(ResolveUrl("~/403"), true); }

        /// <summary>
        /// Lấy giá trị long từ route parameter.
        /// </summary>
        /// <param name="name">Tên parameter trong route.</param>
        /// <returns>Giá trị long hoặc 0 nếu không hợp lệ.</returns>
        protected long RouteLong(string name)
        {
            object raw = Page.RouteData.Values[name]; long value;
            return raw != null && long.TryParse(Convert.ToString(raw), out value) ? value : 0L;
        }
    }

    /// <summary>
    /// Lớp base cho các UserControl CMS - chỉ Admin và Teacher được truy cập.
    /// </summary>
    public abstract class CmsControl : AuthenticatedControl
    {
        protected override void AuthorizeCurrentUser() { if (CurrentUser == null || (!CurrentUser.IsAdmin && !CurrentUser.IsTeacher)) RedirectForbidden(); }
    }

    /// <summary>
    /// Lớp base cho các UserControl của sinh viên - chỉ Student được truy cập.
    /// </summary>
    public abstract class StudentControl : AuthenticatedControl
    {
        protected override void AuthorizeCurrentUser() { if (CurrentUser == null || !CurrentUser.IsStudent) RedirectForbidden(); }
    }
}
