using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_LearningSessions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_LearningSessions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy phiên học của học viên
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
        /// Lấy phiên học hiện tại của học viên
        /// </summary>
        public DataTable GetActiveSession(long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_LearningSessions_GetActive");
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
        /// Kết thúc phiên học
        /// </summary>
        public bool EndSession(long sessionID, int durationSeconds)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_LearningSessions_EndSession");
                objIData.AddParameter("@SessionID", sessionID);
                objIData.AddParameter("@DurationSeconds", durationSeconds);
                objIData.ExecStoreToDataTable();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_LearningSessions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_LearningSessions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load LearningSession theo ID
        /// </summary>
        public static LMS_LearningSessions LoadById(long sessionId)
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
            if (session.Get(sessionId))
            {
                return session;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách LearningSession theo UserID
        /// </summary>
        public static List<LMS_LearningSessions> LoadByUser(long userId)
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
            DataTable dt = session.GetByUser(userId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load phiên học hiện tại của học viên
        /// </summary>
        public static LMS_LearningSessions LoadActiveSession(long userId)
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
            DataTable dt = session.GetActiveSession(userId);
            if (dt != null && dt.Rows.Count > 0)
            {
                return CreateFromDataRow(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Static: Load tất cả LearningSessions
        /// </summary>
        public static List<LMS_LearningSessions> LoadAll()
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
            DataTable dt = session.GetDataTable(session.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm LearningSession với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_LearningSessions> Search(string condition)
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
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
        public static LMS_LearningSessions CreateFromDataReader(IDataReader reader)
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
            session.LoadFromDataReader(reader);
            return session;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_LearningSessions CreateFromDataRow(DataRow row)
        {
            LMS_LearningSessions session = new LMS_LearningSessions();
            session.LoadFromDataRow(row);
            return session;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_LearningSessions> FromDataTable(DataTable dt)
        {
            List<LMS_LearningSessions> list = new List<LMS_LearningSessions>();
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
