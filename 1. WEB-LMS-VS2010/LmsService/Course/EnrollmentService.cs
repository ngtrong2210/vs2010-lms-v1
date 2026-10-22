using System;
using System.Data;
using LmsObject;

namespace LmsService.Course
{
    public partial class EnrollmentService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    LMS_Enrollments obj = new LMS_Enrollments();
                    dtbTable = obj.GetDataTable("LMS_Enrollments_SEARCHCBX");
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0);
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }

        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }

        #region Business Logic

        public static bool EnrollStudent(long courseId, long studentUserId, long createdByUserId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.CourseId = courseId;
            obj.StudentUserID = studentUserId;
            obj.EnrolledAt = DateTime.UtcNow;
            obj.Status = "ENROLLED";
            obj.ProgressPercent = 0;
            obj.CreatedByUserID = createdByUserId;

            bool result = obj.Add();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool UpdateEnrollment(long enrollmentId, long courseId, long studentUserId, string status, decimal progressPercent, decimal? finalScore)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.EnrollmentID = enrollmentId;
            if (!obj.Get())
                return false;

            obj.CourseId = courseId;
            obj.StudentUserID = studentUserId;
            obj.Status = status;
            obj.ProgressPercent = progressPercent;
            obj.FinalScore = finalScore;

            bool result = obj.Update();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool DeleteEnrollment(long enrollmentId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.EnrollmentID = enrollmentId;
            bool result = obj.Delete();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool StartLearning(long enrollmentId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.EnrollmentID = enrollmentId;
            if (!obj.Get())
                return false;

            bool result = obj.StartLearning();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool CompleteLearning(long enrollmentId, decimal finalScore)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.EnrollmentID = enrollmentId;
            if (!obj.Get())
                return false;

            bool result = obj.CompleteLearning(finalScore);
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool UpdateProgress(long enrollmentId, decimal progressPercent)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.EnrollmentID = enrollmentId;
            if (!obj.Get())
                return false;

            bool result = obj.UpdateProgress(progressPercent);
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool UpdateLastAccess(long enrollmentId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            obj.EnrollmentID = enrollmentId;
            if (!obj.Get())
                return false;

            bool result = obj.UpdateLastAccess();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static DataTable GetEnrollmentList(string condition = "")
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            if (string.IsNullOrEmpty(condition))
                return obj.GetDataTable("LMS_Enrollments_SEARCHCBX");
            else
                return obj.Search(condition);
        }

        public static DataTable GetEnrollmentsByCourse(long courseId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            return obj.GetByCourse(courseId);
        }

        public static DataTable GetEnrollmentsByStudent(long studentUserId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            return obj.GetByStudent(studentUserId);
        }

        public static bool IsEnrolled(long courseId, long studentUserId)
        {
            LMS_Enrollments obj = new LMS_Enrollments();
            DataTable dtb = obj.GetDataTable("LMS_Enrollments_CheckEnrollment", "@CourseId", courseId, "@StudentUserID", studentUserId);
            return dtb != null && dtb.Rows.Count > 0;
        }

        #endregion
    }
}
