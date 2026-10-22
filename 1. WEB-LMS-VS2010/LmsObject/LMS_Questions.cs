using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_Questions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_Questions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Tìm kiếm câu hỏi theo điều kiện
        /// </summary>
        public DataTable SearchByFilter(string questionType, string difficulty, string status)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter(P_QuestionType, questionType);
                objIData.AddParameter(P_Difficulty, difficulty);
                objIData.AddParameter(P_Status, status);
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
        /// Lấy danh sách options của câu hỏi
        /// </summary>
        public DataTable GetOptions(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Questions_GetOptions");
                objIData.AddParameter(P_QuestionID, questionID);
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
        /// Lấy answer key của câu hỏi
        /// </summary>
        public DataTable GetAnswerKey(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Questions_GetAnswerKey");
                objIData.AddParameter(P_QuestionID, questionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_Questions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_Questions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load Question theo ID
        /// </summary>
        public static LMS_Questions LoadById(long questionId)
        {
            LMS_Questions question = new LMS_Questions();
            if (question.Get(questionId))
            {
                return question;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách Question theo QuizID
        /// </summary>
        public static List<LMS_Questions> LoadByQuizId(long quizId)
        {
            LMS_Quizzes quiz = new LMS_Quizzes();
            DataTable dt = quiz.GetQuestions(quizId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load danh sách Question theo InteractiveContentID
        /// </summary>
        public static List<LMS_Questions> LoadByInteractiveContentId(long interactiveContentId)
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            DataTable dt = content.GetQuestions(interactiveContentId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả Questions
        /// </summary>
        public static List<LMS_Questions> LoadAll()
        {
            LMS_Questions question = new LMS_Questions();
            DataTable dt = question.GetDataTable(question.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm Question với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_Questions> Search(string condition)
        {
            LMS_Questions question = new LMS_Questions();
            DataTable dt = question.GetDataTable(question.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm Question theo filter
        /// </summary>
        public static List<LMS_Questions> SearchByFilter(string questionType, string difficulty, string status)
        {
            LMS_Questions question = new LMS_Questions();
            DataTable dt = question.SearchByFilter(questionType, difficulty, status);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(QuestionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_Questions CreateFromDataReader(IDataReader reader)
        {
            LMS_Questions question = new LMS_Questions();
            question.LoadFromDataReader(reader);
            return question;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_Questions CreateFromDataRow(DataRow row)
        {
            LMS_Questions question = new LMS_Questions();
            question.LoadFromDataRow(row);
            return question;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_Questions> FromDataTable(DataTable dt)
        {
            List<LMS_Questions> list = new List<LMS_Questions>();
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
