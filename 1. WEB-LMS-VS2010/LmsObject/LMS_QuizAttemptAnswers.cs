using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_QuizAttemptAnswers. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_QuizAttemptAnswers
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy câu trả lời theo lượt làm bài
        /// </summary>
        public DataTable GetByAttempt(long attemptID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
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

        /// <summary>
        /// Lấy câu trả lời theo câu hỏi
        /// </summary>
        public DataTable GetByQuestion(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuizAttemptAnswers_GetByQuestion");
                objIData.AddParameter("@QuestionID", questionID);
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
        /// Xóa câu trả lời theo lượt làm bài
        /// </summary>
        public bool DeleteByAttempt(long attemptID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuizAttemptAnswers_DeleteByAttempt");
                objIData.AddParameter("@AttemptID", attemptID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_QuizAttemptAnswers", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_QuizAttemptAnswers", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load QuizAttemptAnswer theo ID
        /// </summary>
        public static LMS_QuizAttemptAnswers LoadById(long answerId)
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            if (answer.Get(answerId))
            {
                return answer;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách QuizAttemptAnswer theo AttemptID
        /// </summary>
        public static List<LMS_QuizAttemptAnswers> LoadByAttempt(long attemptId)
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            DataTable dt = answer.GetByAttempt(attemptId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load danh sách QuizAttemptAnswer theo QuestionID
        /// </summary>
        public static List<LMS_QuizAttemptAnswers> LoadByQuestion(long questionId)
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            DataTable dt = answer.GetByQuestion(questionId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả QuizAttemptAnswers
        /// </summary>
        public static List<LMS_QuizAttemptAnswers> LoadAll()
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            DataTable dt = answer.GetDataTable(answer.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm QuizAttemptAnswer với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_QuizAttemptAnswers> Search(string condition)
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            DataTable dt = answer.GetDataTable(answer.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(AnswerID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_QuizAttemptAnswers CreateFromDataReader(IDataReader reader)
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            answer.LoadFromDataReader(reader);
            return answer;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_QuizAttemptAnswers CreateFromDataRow(DataRow row)
        {
            LMS_QuizAttemptAnswers answer = new LMS_QuizAttemptAnswers();
            answer.LoadFromDataRow(row);
            return answer;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_QuizAttemptAnswers> FromDataTable(DataTable dt)
        {
            List<LMS_QuizAttemptAnswers> list = new List<LMS_QuizAttemptAnswers>();
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
