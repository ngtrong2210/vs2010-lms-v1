using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_Quizzes. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_Quizzes
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Tìm kiếm Quiz theo LessonID
        /// </summary>
        public DataTable SearchByLessonID(long lessonID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter(P_LessonID, lessonID);
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
        /// Lấy danh sách câu hỏi của Quiz
        /// </summary>
        public DataTable GetQuestions(long quizID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Quizzes_GetQuestions");
                objIData.AddParameter(P_QuizID, quizID);
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
        /// Đếm số lượt làm bài của học viên
        /// </summary>
        public int CountAttempts(long quizID, long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Quizzes_CountAttempts");
                objIData.AddParameter(P_QuizID, quizID);
                objIData.AddParameter("@UserID", userID);
                DataTable dtb = objIData.ExecStoreToDataTable();
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    return Convert.ToInt32(dtb.Rows[0][0]);
                }
                return 0;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return 0;
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_Quizzes", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_Quizzes", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load Quiz theo ID
        /// </summary>
        public static LMS_Quizzes LoadById(long quizId)
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            if (quiz.Get(quizId))
            {
                return quiz;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách Quiz theo LessonID
        /// </summary>
        public static List<LMS_Quizzes> LoadByLessonId(long lessonId)
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            DataTable dt = quiz.SearchByLessonID(lessonId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả Quiz
        /// </summary>
        public static List<LMS_Quizzes> LoadAll()
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            DataTable dt = quiz.GetDataTable(quiz.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm Quiz với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_Quizzes> Search(string condition)
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            DataTable dt = quiz.GetDataTable(quiz.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(QuizID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_Quizzes CreateFromDataReader(IDataReader reader)
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            quiz.LoadFromDataReader(reader);
            return quiz;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_Quizzes CreateFromDataRow(DataRow row)
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            quiz.LoadFromDataRow(row);
            return quiz;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_Quizzes> FromDataTable(DataTable dt)
        {
            List<LMS_Quizzes> list = new List<LMS_Quizzes>();
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
