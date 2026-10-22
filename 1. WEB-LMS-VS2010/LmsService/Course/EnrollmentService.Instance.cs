using System;
using System.Data;
using LmsObject;

namespace LmsService.Course
{
    public partial class EnrollmentService
    {
        // Instance methods để sử dụng với ServiceRegistry
        // Các static methods đã được chuyển sang EnrollmentService.cs

        public DataTable GetEnrollmentList()
        {
            return GetEnrollmentList(null);
        }

        public DataTable GetLessonProgress(long enrollmentId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            return obj.GetDataTable("LMS_Enrollments_GetLessonProgress", "@EnrollmentID", enrollmentId);
        }

        public DataTable GetStudentDashboard(long studentUserId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            return obj.GetDataTable("LMS_Student_GetDashboardStats", "@StudentUserID", studentUserId);
        }
    }
}
