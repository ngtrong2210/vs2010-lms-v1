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
    /// [LMS] Cấu hình bài kiểm tra gắn một-một với bài học loại QUIZ.
    /// </summary>
    public partial class LMS_Quizzes
    {
        #region Member Variables

        private long lngQuizID = 0;//Khóa chính bài kiểm tra.
        private long lngLessonID = 0;//Bài học loại QUIZ sở hữu bài kiểm tra.
        private string strTitle = null;//Cột Title của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private string strDescription = null;//Cột Description của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private decimal decPassingScore = 0;//Phần trăm điểm tối thiểu để đạt.
        private int? intTimeLimitMinutes = null;//Thời gian làm bài tối đa; rỗng nghĩa là không giới hạn.
        private int intMaxAttempts = 0;//Số lượt làm tối đa của mỗi học viên.
        private bool bolShuffleQuestions = false;//Cột ShuffleQuestions của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private string strStatus = null;//Cột Status của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private long lngCreatedByUserID = 0;//Cột CreatedByUserID của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Cột CreatedAt của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private DateTime? dtmUpdatedAt = null;//Cột UpdatedAt của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuizID
        /// Khóa chính bài kiểm tra.
        /// </summary>
        public long QuizID
        {
            get { return lngQuizID; }
            set { lngQuizID = value; }
        }

        /// <summary>
        /// LessonID
        /// Bài học loại QUIZ sở hữu bài kiểm tra.
        /// </summary>
        public long LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
        }

        /// <summary>
        /// Title
        /// Cột Title của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// Description
        /// Cột Description của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// PassingScore
        /// Phần trăm điểm tối thiểu để đạt.
        /// </summary>
        public decimal PassingScore
        {
            get { return decPassingScore; }
            set { decPassingScore = value; }
        }

        /// <summary>
        /// TimeLimitMinutes
        /// Thời gian làm bài tối đa; rỗng nghĩa là không giới hạn.
        /// </summary>
        public int? TimeLimitMinutes
        {
            get { return intTimeLimitMinutes; }
            set { intTimeLimitMinutes = value; }
        }

        /// <summary>
        /// MaxAttempts
        /// Số lượt làm tối đa của mỗi học viên.
        /// </summary>
        public int MaxAttempts
        {
            get { return intMaxAttempts; }
            set { intMaxAttempts = value; }
        }

        /// <summary>
        /// ShuffleQuestions
        /// Cột ShuffleQuestions của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public bool ShuffleQuestions
        {
            get { return bolShuffleQuestions; }
            set { bolShuffleQuestions = value; }
        }

        /// <summary>
        /// Status
        /// Cột Status của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// Cột CreatedByUserID của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Cột CreatedAt của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Cột UpdatedAt của bảng LMS_Quizzes; thuộc schema nghiệp vụ LMS.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuizID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizID])) this.lngQuizID = Convert.ToInt64(reader[C_QuizID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_PassingScore.ToUpper()) && !Convert.IsDBNull(reader[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(reader[C_PassingScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLimitMinutes.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLimitMinutes])) this.intTimeLimitMinutes = Convert.ToInt32(reader[C_TimeLimitMinutes]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxAttempts.ToUpper()) && !Convert.IsDBNull(reader[C_MaxAttempts])) this.intMaxAttempts = Convert.ToInt32(reader[C_MaxAttempts]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShuffleQuestions.ToUpper()) && !Convert.IsDBNull(reader[C_ShuffleQuestions])) this.bolShuffleQuestions = Convert.ToBoolean(reader[C_ShuffleQuestions]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_Quizzes", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuizID])) this.lngQuizID = Convert.ToInt64(drw[C_QuizID]);
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(drw[C_PassingScore]);
                if (!Convert.IsDBNull(drw[C_TimeLimitMinutes])) this.intTimeLimitMinutes = Convert.ToInt32(drw[C_TimeLimitMinutes]);
                if (!Convert.IsDBNull(drw[C_MaxAttempts])) this.intMaxAttempts = Convert.ToInt32(drw[C_MaxAttempts]);
                if (!Convert.IsDBNull(drw[C_ShuffleQuestions])) this.bolShuffleQuestions = Convert.ToBoolean(drw[C_ShuffleQuestions]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_Quizzes", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_Quizzes_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_Quizzes", objEx);
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
        /// Store: LMS_Quizzes_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuizID)
        {
            this.lngQuizID = lngQuizID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_Quizzes_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_TimeLimitMinutes, this.intTimeLimitMinutes);
                objIData.AddParameter(P_MaxAttempts, this.intMaxAttempts);
                objIData.AddParameter(P_ShuffleQuestions, this.bolShuffleQuestions);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_Quizzes", objEx);
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
        /// Store: LMS_Quizzes_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_TimeLimitMinutes, this.intTimeLimitMinutes);
                objIData.AddParameter(P_MaxAttempts, this.intMaxAttempts);
                objIData.AddParameter(P_ShuffleQuestions, this.bolShuffleQuestions);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_Quizzes", objEx);
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
        /// Store: LMS_Quizzes_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_Quizzes", objEx);
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
        /// Store: LMS_Quizzes_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuizID)
        {
            this.lngQuizID = lngQuizID;
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

        public LMS_Quizzes()
        {
        }
        public LMS_Quizzes(long lngQuizID)
        {
            this.lngQuizID = lngQuizID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_Quizzes";
        public const string StoreGet = "LMS_Quizzes_GET";
        public const string StoreGetAll = "LMS_Quizzes_GETALL";
        public const string StoreSearch = "LMS_Quizzes_SEARCH";
        public const string StoreAdd = "LMS_Quizzes_ADD";
        public const string StoreEdit = "LMS_Quizzes_EDIT";
        public const string StoreDelete = "LMS_Quizzes_DELETE";

        #region Parameter Names

        public const String P_QuizID = "@" + C_QuizID;
        public const String P_LessonID = "@" + C_LessonID;
        public const String P_Title = "@" + C_Title;
        public const String P_Description = "@" + C_Description;
        public const String P_PassingScore = "@" + C_PassingScore;
        public const String P_TimeLimitMinutes = "@" + C_TimeLimitMinutes;
        public const String P_MaxAttempts = "@" + C_MaxAttempts;
        public const String P_ShuffleQuestions = "@" + C_ShuffleQuestions;
        public const String P_Status = "@" + C_Status;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuizID = "QuizID";
        public const String C_LessonID = "LessonID";
        public const String C_Title = "Title";
        public const String C_Description = "Description";
        public const String C_PassingScore = "PassingScore";
        public const String C_TimeLimitMinutes = "TimeLimitMinutes";
        public const String C_MaxAttempts = "MaxAttempts";
        public const String C_ShuffleQuestions = "ShuffleQuestions";
        public const String C_Status = "Status";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
