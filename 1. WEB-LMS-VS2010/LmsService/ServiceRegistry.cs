using LmsService.Course;
using LmsService.Lesson;

namespace LmsService
{
    public static class ServiceRegistry
    {
        public static AuthService Auth { get { return new AuthService(); } }
        public static AcademicService Academic { get { return new AcademicService(); } }
        public static CourseService Courses { get { return new CourseService(); } }
        public static ContentService Content { get { return new ContentService(); } }
        public static EnrollmentService Enrollments { get { return new EnrollmentService(); } }
        public static LearningService Learning { get { return new LearningService(); } }
        public static LessonCommentService Comments { get { return new LessonCommentService(); } }
        public static NotificationService Notifications { get { return new NotificationService(); } }
        public static QuestionService Questions { get { return new QuestionService(); } }
        public static QuizService Quiz { get { return new QuizService(); } }
        public static ReportService Reports { get { return new ReportService(); } }
        public static SearchService Search { get { return new SearchService(); } }
        public static StudentService Students { get { return new StudentService(); } }
        public static SystemAdministrationService Administration { get { return new SystemAdministrationService(); } }
        public static TeacherService Teacher { get { return new TeacherService(); } }
        public static TeachingService Teaching { get { return new TeachingService(); } }
        public static InteractiveContentService InteractiveContent { get { return new InteractiveContentService(); } }
        // Alias cho Administration để tương thích với code cũ
        public static SystemAdministrationService Users { get { return Administration; } }
    }
}
