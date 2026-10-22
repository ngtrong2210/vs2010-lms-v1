using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_QuizAttempts. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_QuizAttempts
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Tìm kiếm lượt làm bài theo QuizID và UserID
        /// </summary>
        public DataTable SearchByQuizUser(long quizID, long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@QuizID", quizID);
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
        /// Lấy lịch sử làm bài của học viên
        /// </summary>
        public DataTable GetUserHistory(long userID, long courseID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuizAttempts_GetUserHistory");
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
        /// Lấy câu trả lời của lượt làm bài
        /// </summary>
        public DataTable GetAnswers(long attemptID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuizAttempts_GetAnswers");
                objIData.AddParameter("@AttemptID", attemptID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_QuizAttempts", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_QuizAttempts", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load QuizAttempt theo ID
        /// </summary>
        public static LMS_QuizAttempts LoadById(long attemptId)
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            if (attempt.Get(attemptId))
            {
                return attempt;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách QuizAttempt theo QuizID và UserID
        /// </summary>
        public static List<LMS_QuizAttempts> LoadByQuizUser(long quizId, long userId)
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            DataTable dt = attempt.SearchByQuizUser(quizId, userId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load lịch sử làm bài của học viên
        /// </summary>
        public static List<LMS_QuizAttempts> LoadUserHistory(long userId, long courseId)
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            DataTable dt = attempt.GetUserHistory(userId, courseId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả QuizAttempts
        /// </summary>
        public static List<LMS_QuizAttempts> LoadAll()
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            DataTable dt = attempt.GetDataTable(attempt.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm QuizAttempt với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_QuizAttempts> Search(string condition)
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            DataTable dt = attempt.GetDataTable(attempt.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(AttemptID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_QuizAttempts CreateFromDataReader(IDataReader reader)
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            attempt.LoadFromDataReader(reader);
            return attempt;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_QuizAttempts CreateFromDataRow(DataRow row)
        {
            LMS_QuizAttempts attempt = new LMS_QuizAttempts();
            attempt.LoadFromDataRow(row);
            return attempt;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_QuizAttempts> FromDataTable(DataTable dt)
        {
            List<LMS_QuizAttempts> list = new List<LMS_QuizAttempts>();
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
