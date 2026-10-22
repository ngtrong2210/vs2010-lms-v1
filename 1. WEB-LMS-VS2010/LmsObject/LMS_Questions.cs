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
        /// Lấy danh sách câu hỏi có phân trang và lọc
        /// </summary>
        public DataTable ListQuestions(string search, string type, int page, int pageSize, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("QuestionList");
                objIData.AddParameter("@Search", search);
                objIData.AddParameter("@Type", type);
                objIData.AddParameter("@Page", page);
                objIData.AddParameter("@PageSize", pageSize);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
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
        /// Lấy danh sách câu hỏi có phân trang và lọc - trả về DataSet
        /// </summary>
        public DataSet ListQuestionsDataSet(string search, string type, int page, int pageSize, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("QuestionList");
                objIData.AddParameter("@Search", search);
                objIData.AddParameter("@Type", type);
                objIData.AddParameter("@Page", page);
                objIData.AddParameter("@PageSize", pageSize);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataSet();
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

        /// <summary>
        /// Cập nhật câu hỏi
        /// </summary>
        public bool UpdateQuestion(
            long id,
            string questionType,
            string questionText,
            string media,
            string explanation,
            string difficulty,
            decimal defaultScore,
            string shortAnswerMode,
            string status,
            List<string> optionCodes,
            List<string> optionTexts,
            List<bool> correctFlags,
            List<string> answerKeys,
            List<string> blankCodes,
            List<string> blankAnswers,
            long actorId,
            bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Questions_Update");
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@QuestionType", questionType);
                objIData.AddParameter("@QuestionText", questionText);
                objIData.AddParameter("@Media", media);
                objIData.AddParameter("@Explanation", explanation);
                objIData.AddParameter("@Difficulty", difficulty);
                objIData.AddParameter("@DefaultScore", defaultScore);
                objIData.AddParameter("@ShortAnswerMode", shortAnswerMode);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Tạo câu hỏi mới
        /// </summary>
        public long CreateQuestion(
            string questionType,
            string questionText,
            string media,
            string explanation,
            string difficulty,
            decimal defaultScore,
            string shortAnswerMode,
            string status,
            List<string> optionCodes,
            List<string> optionTexts,
            List<bool> correctFlags,
            List<string> answerKeys,
            List<string> blankCodes,
            List<string> blankAnswers,
            long actorId)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Questions_Create");
                objIData.AddParameter("@QuestionType", questionType);
                objIData.AddParameter("@QuestionText", questionText);
                objIData.AddParameter("@Media", media);
                objIData.AddParameter("@Explanation", explanation);
                objIData.AddParameter("@Difficulty", difficulty);
                objIData.AddParameter("@DefaultScore", defaultScore);
                objIData.AddParameter("@ShortAnswerMode", shortAnswerMode);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                object result = objIData.ExecStoreToScalar();
                return result != null ? Convert.ToInt64(result) : 0;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return 0;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy câu hỏi theo ID - trả về DataSet với các bảng liên quan
        /// </summary>
        public DataSet GetWithDetails(long id)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Questions_GetWithDetails");
                objIData.AddParameter("@Id", id);
                return objIData.ExecStoreToDataSet();
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
