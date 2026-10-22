#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace LmsObject
{
    /// <summary>
    /// Created by 		: Generator
    /// Created date 	: 2025
    /// [LMS] Câu trả lời và điểm backend chấm cho từng câu trong một lượt quiz.
    /// </summary>
    public partial class LMS_QuizAttemptAnswers
    {
        #region Member Variables

        private long lngQuizAttemptAnswerID = 0;//Khóa chính câu trả lời trong lượt quiz.
        private long lngQuizAttemptID = 0;//Lượt quiz sở hữu câu trả lời.
        private long lngQuestionID = 0;//Câu hỏi được trả lời.
        private string strAnswerText = null;//Nội dung hoặc mã phương án học viên đã chọn; không chứa đáp án đúng.
        private bool? bolIsCorrect = null;//Kết quả đúng sai do backend xác định.
        private decimal decScoreAwarded = 0;//Điểm backend trao cho câu trả lời.
        private DateTime dtmAnsweredAt = DateTime.MinValue;//Thời điểm học viên trả lời câu hỏi theo UTC.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuizAttemptAnswerID
        /// Khóa chính câu trả lời trong lượt quiz.
        /// </summary>
        public long QuizAttemptAnswerID
        {
            get { return lngQuizAttemptAnswerID; }
            set { lngQuizAttemptAnswerID = value; }
        }

        /// <summary>
        /// QuizAttemptID
        /// Lượt quiz sở hữu câu trả lời.
        /// </summary>
        public long QuizAttemptID
        {
            get { return lngQuizAttemptID; }
            set { lngQuizAttemptID = value; }
        }

        /// <summary>
        /// QuestionID
        /// Câu hỏi được trả lời.
        /// </summary>
        public long QuestionID
        {
            get { return lngQuestionID; }
            set { lngQuestionID = value; }
        }

        /// <summary>
        /// AnswerText
        /// Nội dung hoặc mã phương án học viên đã chọn; không chứa đáp án đúng.
        /// </summary>
        public string AnswerText
        {
            get { return strAnswerText; }
            set { strAnswerText = value; }
        }

        /// <summary>
        /// IsCorrect
        /// Kết quả đúng sai do backend xác định.
        /// </summary>
        public bool? IsCorrect
        {
            get { return bolIsCorrect; }
            set { bolIsCorrect = value; }
        }

        /// <summary>
        /// ScoreAwarded
        /// Điểm backend trao cho câu trả lời.
        /// </summary>
        public decimal ScoreAwarded
        {
            get { return decScoreAwarded; }
            set { decScoreAwarded = value; }
        }

        /// <summary>
        /// AnsweredAt
        /// Thời điểm học viên trả lời câu hỏi theo UTC.
        /// </summary>
        public DateTime AnsweredAt
        {
            get { return dtmAnsweredAt; }
            set { dtmAnsweredAt = value; }
        }

        /// <summary>
        /// IData - Đối tượng IData truy xuất dữ liệu.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi
        /// </summary>
        public IData IDB
        {
            get { return objIData; }
            set { objIData = value; bolIsExistIData = (value != null); }
        }

        /// <summary>
        /// ErrorException - Đối tượng lỗi nhận trả về khi method được thực thi.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi
        /// </summary>
        public Exception ErrorException
        {
            get { return objErrorException; }
            set { objErrorException = value; }
        }

        #endregion

        #region Methods

        ///<summary>
        /// Chuyển từ một IDataReader thành đối tượng
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Parse(IDataReader reader)
        {
            try
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).ToUpper().Equals(C_QuizAttemptAnswerID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizAttemptAnswerID])) this.lngQuizAttemptAnswerID = Convert.ToInt64(reader[C_QuizAttemptAnswerID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuizAttemptID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizAttemptID])) this.lngQuizAttemptID = Convert.ToInt64(reader[C_QuizAttemptID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(reader[C_QuestionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_AnswerText.ToUpper()) && !Convert.IsDBNull(reader[C_AnswerText])) this.strAnswerText = Convert.ToString(reader[C_AnswerText]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCorrect.ToUpper()) && !Convert.IsDBNull(reader[C_IsCorrect])) this.bolIsCorrect = Convert.ToBoolean(reader[C_IsCorrect]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScoreAwarded.ToUpper()) && !Convert.IsDBNull(reader[C_ScoreAwarded])) this.decScoreAwarded = Convert.ToDecimal(reader[C_ScoreAwarded]);
                    if (reader.GetName(i).ToUpper().Equals(C_AnsweredAt.ToUpper()) && !Convert.IsDBNull(reader[C_AnsweredAt])) this.dtmAnsweredAt = Convert.ToDateTime(reader[C_AnsweredAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_QuizAttemptAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Chuyển từ một DataRow thành đối tượng
        ///</summary>
        /// <returns>true ? Có : False? Không</returns>
        public bool Parse(DataRow drw)
        {
            try
            {
                if (!Convert.IsDBNull(drw[C_QuizAttemptAnswerID])) this.lngQuizAttemptAnswerID = Convert.ToInt64(drw[C_QuizAttemptAnswerID]);
                if (!Convert.IsDBNull(drw[C_QuizAttemptID])) this.lngQuizAttemptID = Convert.ToInt64(drw[C_QuizAttemptID]);
                if (!Convert.IsDBNull(drw[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(drw[C_QuestionID]);
                if (!Convert.IsDBNull(drw[C_AnswerText])) this.strAnswerText = Convert.ToString(drw[C_AnswerText]);
                if (!Convert.IsDBNull(drw[C_IsCorrect])) this.bolIsCorrect = Convert.ToBoolean(drw[C_IsCorrect]);
                if (!Convert.IsDBNull(drw[C_ScoreAwarded])) this.decScoreAwarded = Convert.ToDecimal(drw[C_ScoreAwarded]);
                if (!Convert.IsDBNull(drw[C_AnsweredAt])) this.dtmAnsweredAt = Convert.ToDateTime(drw[C_AnsweredAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_QuizAttemptAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuizAttemptAnswers_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuizAttemptAnswerID, this.lngQuizAttemptAnswerID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    this.Parse(reader);
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_QuizAttemptAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuizAttemptAnswers_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuizAttemptAnswerID)
        {
            this.lngQuizAttemptAnswerID = lngQuizAttemptAnswerID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_QuizAttemptAnswers_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_QuizAttemptID, this.lngQuizAttemptID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_AnswerText, this.strAnswerText);
                objIData.AddParameter(P_IsCorrect, this.bolIsCorrect);
                objIData.AddParameter(P_ScoreAwarded, this.decScoreAwarded);
                objIData.AddParameter(P_AnsweredAt, this.dtmAnsweredAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_QuizAttemptAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Cập nhật dữ liệu
        /// Store: LMS_QuizAttemptAnswers_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuizAttemptAnswerID, this.lngQuizAttemptAnswerID);
                objIData.AddParameter(P_QuizAttemptID, this.lngQuizAttemptID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_AnswerText, this.strAnswerText);
                objIData.AddParameter(P_IsCorrect, this.bolIsCorrect);
                objIData.AddParameter(P_ScoreAwarded, this.decScoreAwarded);
                objIData.AddParameter(P_AnsweredAt, this.dtmAnsweredAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_QuizAttemptAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Xóa dữ liệu
        /// Store: LMS_QuizAttemptAnswers_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuizAttemptAnswerID, this.lngQuizAttemptAnswerID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_QuizAttemptAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Xóa dữ liệu
        /// Store: LMS_QuizAttemptAnswers_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuizAttemptAnswerID)
        {
            this.lngQuizAttemptAnswerID = lngQuizAttemptAnswerID;
            return this.Delete();
        }

        #endregion

        #region Transaction methods

        ///<summary>
        /// Bắt đầu một Transaction.
        ///</summary>
        /// <returns> true: ket noi thanh con; false: khong ket noi duoc </returns>
        public bool BeginTransaction()
        {
            objIData = DCore.Data.CreateData();
            try
            {
                objIData.Connect();
                objIData.BeginTransaction();
                bolIsExistIData = true;
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Hoàn thành một Transaction.
        ///</summary>
        public void CommitTransaction()
        {
            objIData.CommitTransaction();
            objIData.Disconnect();
            bolIsExistIData = false;
        }

        ///<summary>
        /// Rollback một Transaction.
        ///</summary>
        public void RollBackTransaction()
        {
            objIData.RollBackTransaction();
            objIData.Disconnect();
            bolIsExistIData = false;
        }

        #endregion

        #region Constructor

        public LMS_QuizAttemptAnswers()
        {
        }
        public LMS_QuizAttemptAnswers(long lngQuizAttemptAnswerID)
        {
            this.lngQuizAttemptAnswerID = lngQuizAttemptAnswerID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_QuizAttemptAnswers";
        public const string StoreGet = "LMS_QuizAttemptAnswers_GET";
        public const string StoreGetAll = "LMS_QuizAttemptAnswers_GETALL";
        public const string StoreSearch = "LMS_QuizAttemptAnswers_SEARCH";
        public const string StoreAdd = "LMS_QuizAttemptAnswers_ADD";
        public const string StoreEdit = "LMS_QuizAttemptAnswers_EDIT";
        public const string StoreDelete = "LMS_QuizAttemptAnswers_DELETE";

        #region Parameter Names

        public const String P_QuizAttemptAnswerID = "@" + C_QuizAttemptAnswerID;
        public const String P_QuizAttemptID = "@" + C_QuizAttemptID;
        public const String P_QuestionID = "@" + C_QuestionID;
        public const String P_AnswerText = "@" + C_AnswerText;
        public const String P_IsCorrect = "@" + C_IsCorrect;
        public const String P_ScoreAwarded = "@" + C_ScoreAwarded;
        public const String P_AnsweredAt = "@" + C_AnsweredAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuizAttemptAnswerID = "QuizAttemptAnswerID";
        public const String C_QuizAttemptID = "QuizAttemptID";
        public const String C_QuestionID = "QuestionID";
        public const String C_AnswerText = "AnswerText";
        public const String C_IsCorrect = "IsCorrect";
        public const String C_ScoreAwarded = "ScoreAwarded";
        public const String C_AnsweredAt = "AnsweredAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
