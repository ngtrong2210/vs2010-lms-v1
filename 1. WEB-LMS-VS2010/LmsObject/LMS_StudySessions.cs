using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_StudySessions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_StudySessions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy phiên học tập của học viên
        /// </summary>
        public DataTable GetByUser(long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@UserID", userID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy phiên học tập theo khóa học
        /// </summary>
        public DataTable GetByUserCourse(long userID, long courseID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudySessions_GetByUserCourse");
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@CourseID", courseID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy thống kê thời gian học theo ngày
        /// </summary>
        public DataTable GetDailyStats(long userID, DateTime startDate, DateTime endDate)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudySessions_GetDailyStats");
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@StartDate", startDate);
                objIData.AddParameter("@EndDate", endDate);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion

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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_StudySessions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_StudySessions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load StudySession theo ID
        /// </summary>
        public static LMS_StudySessions LoadById(long sessionId)
        {
            LMS_StudySessions session = new LMS_StudySessions();
            if (session.Get(sessionId))
            {
                return session;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách StudySession theo UserID
        /// </summary>
        public static List<LMS_StudySessions> LoadByUser(long userId)
        {
            LMS_StudySessions session = new LMS_StudySessions();
            DataTable dt = session.GetByUser(userId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load danh sách StudySession theo UserID và CourseID
        /// </summary>
        public static List<LMS_StudySessions> LoadByUserCourse(long userId, long courseId)
        {
            LMS_StudySessions session = new LMS_StudySessions();
            DataTable dt = session.GetByUserCourse(userId, courseId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả StudySessions
        /// </summary>
        public static List<LMS_StudySessions> LoadAll()
        {
            LMS_StudySessions session = new LMS_StudySessions();
            DataTable dt = session.GetDataTable(session.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm StudySession với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_StudySessions> Search(string condition)
        {
            LMS_StudySessions session = new LMS_StudySessions();
            DataTable dt = session.GetDataTable(session.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(SessionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_StudySessions CreateFromDataReader(IDataReader reader)
        {
            LMS_StudySessions session = new LMS_StudySessions();
            session.LoadFromDataReader(reader);
            return session;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_StudySessions CreateFromDataRow(DataRow row)
        {
            LMS_StudySessions session = new LMS_StudySessions();
            session.LoadFromDataRow(row);
            return session;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_StudySessions> FromDataTable(DataTable dt)
        {
            List<LMS_StudySessions> list = new List<LMS_StudySessions>();
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
