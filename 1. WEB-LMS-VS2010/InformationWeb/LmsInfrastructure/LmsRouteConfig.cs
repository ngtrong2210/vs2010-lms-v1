using System.Web.Routing;

namespace InformationWeb.LmsInfrastructure
{
    /// <summary>
    /// Lớp cấu hình routing cho ứng dụng LMS.
    /// </summary>
    public static class LmsRouteConfig
    {
        /// <summary>
        /// Đăng ký tất cả các route cho ứng dụng.
        /// </summary>
        /// <param name="routes">RouteCollection để đăng ký.</param>
        public static void Register(RouteCollection routes)
        {
            routes.Ignore("{resource}.axd/{*pathInfo}");
            Map(routes, "Login", "login", "~/Pages/Auth/Login.aspx"); Map(routes, "Logout", "logout", "~/Pages/Auth/Logout.aspx");
            Map(routes, "LmsDashboard", "lms/dashboard", "~/Pages/Lms/Dashboard.aspx"); Map(routes, "LmsCourses", "lms/courses", "~/Pages/Lms/Courses.aspx");
            Map(routes, "LmsCourse", "lms/courses/{courseId}", "~/Pages/Lms/Course.aspx"); Map(routes, "LmsLesson", "lms/courses/{courseId}/lessons/{lessonId}", "~/Pages/Lms/LessonPlayer.aspx");
            Map(routes, "LmsResults", "lms/results", "~/Pages/Lms/Results.aspx"); Map(routes, "LmsProfile", "lms/profile", "~/Pages/Lms/Profile.aspx");
            Map(routes, "CmsDashboard", "cms/dashboard", "~/Pages/Cms/Dashboard.aspx"); Map(routes, "CmsSearch", "cms/search", "~/Pages/Cms/Search.aspx");
            Map(routes, "CmsAcademic", "cms/academic", "~/Pages/Cms/AcademicStructure.aspx"); Map(routes, "CmsCourses", "cms/courses", "~/Pages/Cms/Courses.aspx");
            Map(routes, "CmsContent", "cms/courses/{courseId}/content", "~/Pages/Cms/ContentBuilder.aspx"); Map(routes, "CmsAssignments", "cms/assignments", "~/Pages/Cms/AssignmentGrading.aspx");
            Map(routes, "CmsVideos", "cms/videos", "~/Pages/Cms/VideoLibrary.aspx"); Map(routes, "CmsVideoEditor", "cms/videos/{videoId}/editor", "~/Pages/Cms/VideoEditor.aspx");
            Map(routes, "CmsQuestions", "cms/questions", "~/Pages/Cms/Questions.aspx"); Map(routes, "CmsStudents", "cms/students", "~/Pages/Cms/Students.aspx");
            Map(routes, "CmsEnrollments", "cms/enrollments", "~/Pages/Cms/Enrollments.aspx"); Map(routes, "CmsReports", "cms/reports", "~/Pages/Cms/Reports.aspx");
            Map(routes, "CmsUsers", "cms/users", "~/Pages/Cms/Users.aspx"); Map(routes, "CmsRoles", "cms/roles", "~/Pages/Cms/Roles.aspx"); Map(routes, "CmsSettings", "cms/settings", "~/Pages/Cms/Settings.aspx");
            Map(routes, "Forbidden", "403", "~/Pages/Errors/Forbidden.aspx"); Map(routes, "NotFound", "404", "~/Pages/Errors/NotFound.aspx"); Map(routes, "Error", "error", "~/Pages/Errors/Error.aspx");
        }
        /// <summary>
        /// Đăng ký một route đơn giản.
        /// </summary>
        /// <param name="routes">RouteCollection để đăng ký.</param>
        /// <param name="name">Tên định danh của route.</param>
        /// <param name="url">URL pattern của route.</param>
        /// <param name="file">Đường dẫn file vật lý.</param>
        private static void Map(RouteCollection routes, string name, string url, string file) { routes.MapPageRoute(name, url, file, false); }
    }
}
