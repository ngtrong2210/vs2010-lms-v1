using System;
using System.Data;
using System.Collections.Generic;
using DCore;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_Enrollments. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_Enrollments
    {
        public DataTable Search(string condition)
        {
            return GetDataTable("LMS_Enrollments_SEARCH", "@Condition", condition);
        }

        public DataTable GetByCourse(long courseId)
        {
            return GetDataTable("LMS_Enrollments_GetByCourse", "@CourseId", courseId);
        }

        public DataTable GetByStudent(long studentUserId)
        {
            return GetDataTable("LMS_Enrollments_GetByStudent", "@StudentUserID", studentUserId);
        }

        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Enrollments_UpdateStatus");
                objIData.AddParameter(P_EnrollmentID, this.lngEnrollmentID);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật trạng thái ghi danh", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool UpdateProgress(decimal progressPercent)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Enrollments_UpdateProgress");
                objIData.AddParameter(P_EnrollmentID, this.lngEnrollmentID);
                objIData.AddParameter(P_ProgressPercent, progressPercent);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật tiến độ", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool StartLearning()
        {
            this.strStatus = "IN_PROGRESS";
            this.dtmStartedAt = DateTime.UtcNow;
            return UpdateStatus();
        }

        public bool CompleteLearning(decimal finalScore)
        {
            this.strStatus = "COMPLETED";
            this.dtmCompletedAt = DateTime.UtcNow;
            this.decFinalScore = finalScore;
            this.decProgressPercent = 100;
            return UpdateProgress(100) && UpdateStatus();
        }

        public bool UpdateLastAccess()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Enrollments_UpdateLastAccess");
                objIData.AddParameter(P_EnrollmentID, this.lngEnrollmentID);
                objIData.AddParameter(P_LastAccessAt, DateTime.UtcNow);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thời gian truy cập", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        #region Enhanced Load Methods

        /// <summary>
        /// Load dữ liệu từ IDataReader vào object hiện tại.
        /// </summary>
        public bool LoadFromDataReader(IDataReader reader)
        {
            try
            {
                return Parse(reader);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_Enrollments", ex);
                return false;
            }
        }

        /// <summary>
        /// Load dữ liệu từ DataRow vào object hiện tại.
        /// </summary>
        public bool LoadFromDataRow(DataRow row)
        {
            try
            {
                if (row == null) return false;

                // Sử dụng Parse(DataRow) đã có trong Base class
                return Parse(row);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_Enrollments", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load Enrollment theo ID
        /// </summary>
        public static LMS_Enrollments LoadById(long enrollmentId)
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            if (enrollment.Get(enrollmentId))
            {
                return enrollment;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách Enrollment theo CourseID
        /// </summary>
        public static List<LMS_Enrollments> LoadByCourse(long courseId)
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            DataTable dt = enrollment.GetByCourse(courseId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load danh sách Enrollment theo StudentUserID
        /// </summary>
        public static List<LMS_Enrollments> LoadByStudent(long studentUserId)
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            DataTable dt = enrollment.GetByStudent(studentUserId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả Enrollments
        /// </summary>
        public static List<LMS_Enrollments> LoadAll()
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            DataTable dt = enrollment.GetDataTable("LMS_Enrollments_SEARCH", "@Condition", "");
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm Enrollment với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_Enrollments> Search(string condition)
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            DataTable dt = enrollment.Search(condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(lngEnrollmentID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_Enrollments CreateFromDataReader(IDataReader reader)
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            enrollment.LoadFromDataReader(reader);
            return enrollment;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_Enrollments CreateFromDataRow(DataRow row)
        {
            LMS_Enrollments enrollment = new LMS_Enrollments();
            enrollment.LoadFromDataRow(row);
            return enrollment;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_Enrollments> FromDataTable(DataTable dt)
        {
            List<LMS_Enrollments> list = new List<LMS_Enrollments>();
            if (dt == null) return list;

            foreach (DataRow row in dt.Rows)
            {
                list.Add(CreateFromDataRow(row));
            }
            return list;
        }

        #endregion
    }
}
