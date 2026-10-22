using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_QuizQuestions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_QuizQuestions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách câu hỏi của Quiz theo thứ tự
        /// </summary>
        public DataTable GetQuizQuestions(long quizID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@QuizID", quizID);
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
        /// Xóa tất cả câu hỏi của Quiz
        /// </summary>
        public bool ClearQuizQuestions(long quizID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuizQuestions_Clear");
                objIData.AddParameter("@QuizID", quizID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_QuizQuestions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_QuizQuestions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load QuizQuestion theo ID
        /// </summary>
        public static LMS_QuizQuestions LoadById(long quizQuestionId)
        {
            LMS_QuizQuestions quizQuestion = new LMS_QuizQuestions();
            if (quizQuestion.Get(quizQuestionId))
            {
                return quizQuestion;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách QuizQuestion theo QuizID
        /// </summary>
        public static List<LMS_QuizQuestions> LoadByQuiz(long quizId)
        {
            LMS_QuizQuestions quizQuestion = new LMS_QuizQuestions();
            DataTable dt = quizQuestion.GetQuizQuestions(quizId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả QuizQuestions
        /// </summary>
        public static List<LMS_QuizQuestions> LoadAll()
        {
            LMS_QuizQuestions quizQuestion = new LMS_QuizQuestions();
            DataTable dt = quizQuestion.GetDataTable(quizQuestion.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm QuizQuestion với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_QuizQuestions> Search(string condition)
        {
            LMS_QuizQuestions quizQuestion = new LMS_QuizQuestions();
            DataTable dt = quizQuestion.GetDataTable(quizQuestion.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(QuizQuestionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_QuizQuestions CreateFromDataReader(IDataReader reader)
        {
            LMS_QuizQuestions quizQuestion = new LMS_QuizQuestions();
            quizQuestion.LoadFromDataReader(reader);
            return quizQuestion;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_QuizQuestions CreateFromDataRow(DataRow row)
        {
            LMS_QuizQuestions quizQuestion = new LMS_QuizQuestions();
            quizQuestion.LoadFromDataRow(row);
            return quizQuestion;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_QuizQuestions> FromDataTable(DataTable dt)
        {
            List<LMS_QuizQuestions> list = new List<LMS_QuizQuestions>();
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
