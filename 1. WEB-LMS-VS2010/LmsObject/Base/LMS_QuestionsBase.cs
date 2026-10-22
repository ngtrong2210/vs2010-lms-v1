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
    /// [LMS] Ngân hàng câu hỏi dùng trong hoạt động học tập.
    /// </summary>
    public partial class LMS_Questions
    {
        #region Member Variables

        private long lngQuestionID = 0;//Khóa chính tự tăng của câu hỏi.
        private string strQuestionType = null;//Loại câu hỏi: một lựa chọn, nhiều lựa chọn, đúng/sai hoặc trả lời ngắn.
        private string strQuestionText = null;//Nội dung chính của câu hỏi.
        private string strDescription = null;//Thông tin bổ sung hoặc ngữ cảnh của câu hỏi.
        private string strExplanation = null;//Lời giải thích đáp án hiển thị sau khi trả lời.
        private string strDifficulty = null;//Mức độ khó của câu hỏi.
        private decimal decDefaultScore = 0;//Điểm mặc định khi sử dụng câu hỏi.
        private string strShortAnswerMode = null;//Quy tắc so khớp đáp án cho câu hỏi trả lời ngắn.
        private long lngCreatedByUserID = 0;//ID người dùng tạo câu hỏi.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo câu hỏi theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật câu hỏi gần nhất theo UTC.
        private string strStatus = null;//Trạng thái sử dụng của câu hỏi.
        private bool bolIsDeleted = false;//Cờ xóa mềm của câu hỏi.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuestionID
        /// Khóa chính tự tăng của câu hỏi.
        /// </summary>
        public long QuestionID
        {
            get { return lngQuestionID; }
            set { lngQuestionID = value; }
        }

        /// <summary>
        /// QuestionType
        /// Loại câu hỏi: một lựa chọn, nhiều lựa chọn, đúng/sai hoặc trả lời ngắn.
        /// </summary>
        public string QuestionType
        {
            get { return strQuestionType; }
            set { strQuestionType = value; }
        }

        /// <summary>
        /// QuestionText
        /// Nội dung chính của câu hỏi.
        /// </summary>
        public string QuestionText
        {
            get { return strQuestionText; }
            set { strQuestionText = value; }
        }

        /// <summary>
        /// Description
        /// Thông tin bổ sung hoặc ngữ cảnh của câu hỏi.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// Explanation
        /// Lời giải thích đáp án hiển thị sau khi trả lời.
        /// </summary>
        public string Explanation
        {
            get { return strExplanation; }
            set { strExplanation = value; }
        }

        /// <summary>
        /// Difficulty
        /// Mức độ khó của câu hỏi.
        /// </summary>
        public string Difficulty
        {
            get { return strDifficulty; }
            set { strDifficulty = value; }
        }

        /// <summary>
        /// DefaultScore
        /// Điểm mặc định khi sử dụng câu hỏi.
        /// </summary>
        public decimal DefaultScore
        {
            get { return decDefaultScore; }
            set { decDefaultScore = value; }
        }

        /// <summary>
        /// ShortAnswerMode
        /// Quy tắc so khớp đáp án cho câu hỏi trả lời ngắn.
        /// </summary>
        public string ShortAnswerMode
        {
            get { return strShortAnswerMode; }
            set { strShortAnswerMode = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// ID người dùng tạo câu hỏi.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo câu hỏi theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật câu hỏi gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của câu hỏi.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của câu hỏi.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(reader[C_QuestionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionType.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionType])) this.strQuestionType = Convert.ToString(reader[C_QuestionType]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionText.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionText])) this.strQuestionText = Convert.ToString(reader[C_QuestionText]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_Explanation.ToUpper()) && !Convert.IsDBNull(reader[C_Explanation])) this.strExplanation = Convert.ToString(reader[C_Explanation]);
                    if (reader.GetName(i).ToUpper().Equals(C_Difficulty.ToUpper()) && !Convert.IsDBNull(reader[C_Difficulty])) this.strDifficulty = Convert.ToString(reader[C_Difficulty]);
                    if (reader.GetName(i).ToUpper().Equals(C_DefaultScore.ToUpper()) && !Convert.IsDBNull(reader[C_DefaultScore])) this.decDefaultScore = Convert.ToDecimal(reader[C_DefaultScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShortAnswerMode.ToUpper()) && !Convert.IsDBNull(reader[C_ShortAnswerMode])) this.strShortAnswerMode = Convert.ToString(reader[C_ShortAnswerMode]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_Questions", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(drw[C_QuestionID]);
                if (!Convert.IsDBNull(drw[C_QuestionType])) this.strQuestionType = Convert.ToString(drw[C_QuestionType]);
                if (!Convert.IsDBNull(drw[C_QuestionText])) this.strQuestionText = Convert.ToString(drw[C_QuestionText]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_Explanation])) this.strExplanation = Convert.ToString(drw[C_Explanation]);
                if (!Convert.IsDBNull(drw[C_Difficulty])) this.strDifficulty = Convert.ToString(drw[C_Difficulty]);
                if (!Convert.IsDBNull(drw[C_DefaultScore])) this.decDefaultScore = Convert.ToDecimal(drw[C_DefaultScore]);
                if (!Convert.IsDBNull(drw[C_ShortAnswerMode])) this.strShortAnswerMode = Convert.ToString(drw[C_ShortAnswerMode]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_Questions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_Questions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_Questions", objEx);
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
        /// Store: LMS_Questions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuestionID)
        {
            this.lngQuestionID = lngQuestionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_Questions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_QuestionType, this.strQuestionType);
                objIData.AddParameter(P_QuestionText, this.strQuestionText);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_Explanation, this.strExplanation);
                objIData.AddParameter(P_Difficulty, this.strDifficulty);
                objIData.AddParameter(P_DefaultScore, this.decDefaultScore);
                objIData.AddParameter(P_ShortAnswerMode, this.strShortAnswerMode);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_Questions", objEx);
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
        /// Store: LMS_Questions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_QuestionType, this.strQuestionType);
                objIData.AddParameter(P_QuestionText, this.strQuestionText);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_Explanation, this.strExplanation);
                objIData.AddParameter(P_Difficulty, this.strDifficulty);
                objIData.AddParameter(P_DefaultScore, this.decDefaultScore);
                objIData.AddParameter(P_ShortAnswerMode, this.strShortAnswerMode);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_Questions", objEx);
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
        /// Store: LMS_Questions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_Questions", objEx);
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
        /// Store: LMS_Questions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuestionID)
        {
            this.lngQuestionID = lngQuestionID;
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

        public LMS_Questions()
        {
        }
        public LMS_Questions(long lngQuestionID)
        {
            this.lngQuestionID = lngQuestionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_Questions";
        public const string StoreGet = "LMS_Questions_GET";
        public const string StoreGetAll = "LMS_Questions_GETALL";
        public const string StoreSearch = "LMS_Questions_SEARCH";
        public const string StoreAdd = "LMS_Questions_ADD";
        public const string StoreEdit = "LMS_Questions_EDIT";
        public const string StoreDelete = "LMS_Questions_DELETE";

        #region Parameter Names

        public const String P_QuestionID = "@" + C_QuestionID;
        public const String P_QuestionType = "@" + C_QuestionType;
        public const String P_QuestionText = "@" + C_QuestionText;
        public const String P_Description = "@" + C_Description;
        public const String P_Explanation = "@" + C_Explanation;
        public const String P_Difficulty = "@" + C_Difficulty;
        public const String P_DefaultScore = "@" + C_DefaultScore;
        public const String P_ShortAnswerMode = "@" + C_ShortAnswerMode;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_Status = "@" + C_Status;
        public const String P_IsDeleted = "@" + C_IsDeleted;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuestionID = "QuestionID";
        public const String C_QuestionType = "QuestionType";
        public const String C_QuestionText = "QuestionText";
        public const String C_Description = "Description";
        public const String C_Explanation = "Explanation";
        public const String C_Difficulty = "Difficulty";
        public const String C_DefaultScore = "DefaultScore";
        public const String C_ShortAnswerMode = "ShortAnswerMode";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_Status = "Status";
        public const String C_IsDeleted = "IsDeleted";

        #endregion //Column names

        #endregion Variable Static
    }
}
