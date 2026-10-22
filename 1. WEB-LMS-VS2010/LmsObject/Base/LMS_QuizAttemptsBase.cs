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
    /// [LMS] Mỗi lượt học viên bắt đầu và nộp bài kiểm tra.
    /// </summary>
    public partial class LMS_QuizAttempts
    {
        #region Member Variables

        private long lngQuizAttemptID = 0;//Khóa chính lượt làm bài kiểm tra.
        private long lngQuizID = 0;//ID bài kiểm tra được thực hiện.
        private long lngStudentUserID = 0;//Tài khoản học viên thực hiện lượt làm.
        private int intAttemptNumber = 0;//Số thứ tự lượt làm của học viên.
        private DateTime dtmStartedAt = DateTime.MinValue;//Thời điểm bắt đầu làm bài theo UTC.
        private DateTime? dtmSubmittedAt = null;//Thời điểm nộp bài theo UTC.
        private decimal? decScore = null;//Tổng điểm đạt được sau khi backend chấm.
        private decimal? decMaxScore = null;//Điểm tối đa có thể đạt được.
        private decimal? decScorePercent = null;//Phần trăm điểm sau khi backend chấm.
        private bool? bolPassed = null;//Cờ cho biết học viên đạt yêu cầu.
        private string strAttemptStatus = null;//Trạng thái lượt làm: IN_PROGRESS, SUBMITTED, GRADED hoặc CANCELLED.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuizAttemptID
        /// Khóa chính lượt làm bài kiểm tra.
        /// </summary>
        public long QuizAttemptID
        {
            get { return lngQuizAttemptID; }
            set { lngQuizAttemptID = value; }
        }

        /// <summary>
        /// QuizID
        /// ID bài kiểm tra được thực hiện.
        /// </summary>
        public long QuizID
        {
            get { return lngQuizID; }
            set { lngQuizID = value; }
        }

        /// <summary>
        /// StudentUserID
        /// Tài khoản học viên thực hiện lượt làm.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// AttemptNumber
        /// Số thứ tự lượt làm của học viên.
        /// </summary>
        public int AttemptNumber
        {
            get { return intAttemptNumber; }
            set { intAttemptNumber = value; }
        }

        /// <summary>
        /// StartedAt
        /// Thời điểm bắt đầu làm bài theo UTC.
        /// </summary>
        public DateTime StartedAt
        {
            get { return dtmStartedAt; }
            set { dtmStartedAt = value; }
        }

        /// <summary>
        /// SubmittedAt
        /// Thời điểm nộp bài theo UTC.
        /// </summary>
        public DateTime? SubmittedAt
        {
            get { return dtmSubmittedAt; }
            set { dtmSubmittedAt = value; }
        }

        /// <summary>
        /// Score
        /// Tổng điểm đạt được sau khi backend chấm.
        /// </summary>
        public decimal? Score
        {
            get { return decScore; }
            set { decScore = value; }
        }

        /// <summary>
        /// MaxScore
        /// Điểm tối đa có thể đạt được.
        /// </summary>
        public decimal? MaxScore
        {
            get { return decMaxScore; }
            set { decMaxScore = value; }
        }

        /// <summary>
        /// ScorePercent
        /// Phần trăm điểm sau khi backend chấm.
        /// </summary>
        public decimal? ScorePercent
        {
            get { return decScorePercent; }
            set { decScorePercent = value; }
        }

        /// <summary>
        /// Passed
        /// Cờ cho biết học viên đạt yêu cầu.
        /// </summary>
        public bool? Passed
        {
            get { return bolPassed; }
            set { bolPassed = value; }
        }

        /// <summary>
        /// AttemptStatus
        /// Trạng thái lượt làm: IN_PROGRESS, SUBMITTED, GRADED hoặc CANCELLED.
        /// </summary>
        public string AttemptStatus
        {
            get { return strAttemptStatus; }
            set { strAttemptStatus = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuizAttemptID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizAttemptID])) this.lngQuizAttemptID = Convert.ToInt64(reader[C_QuizAttemptID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuizID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizID])) this.lngQuizID = Convert.ToInt64(reader[C_QuizID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptNumber.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptNumber])) this.intAttemptNumber = Convert.ToInt32(reader[C_AttemptNumber]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartedAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(reader[C_StartedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubmittedAt.ToUpper()) && !Convert.IsDBNull(reader[C_SubmittedAt])) this.dtmSubmittedAt = Convert.ToDateTime(reader[C_SubmittedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_Score.ToUpper()) && !Convert.IsDBNull(reader[C_Score])) this.decScore = Convert.ToDecimal(reader[C_Score]);
                    if (reader.GetName(i).ToUpper().Equals(C_MaxScore.ToUpper()) && !Convert.IsDBNull(reader[C_MaxScore])) this.decMaxScore = Convert.ToDecimal(reader[C_MaxScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScorePercent.ToUpper()) && !Convert.IsDBNull(reader[C_ScorePercent])) this.decScorePercent = Convert.ToDecimal(reader[C_ScorePercent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Passed.ToUpper()) && !Convert.IsDBNull(reader[C_Passed])) this.bolPassed = Convert.ToBoolean(reader[C_Passed]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptStatus.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptStatus])) this.strAttemptStatus = Convert.ToString(reader[C_AttemptStatus]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_QuizAttempts", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuizAttemptID])) this.lngQuizAttemptID = Convert.ToInt64(drw[C_QuizAttemptID]);
                if (!Convert.IsDBNull(drw[C_QuizID])) this.lngQuizID = Convert.ToInt64(drw[C_QuizID]);
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_AttemptNumber])) this.intAttemptNumber = Convert.ToInt32(drw[C_AttemptNumber]);
                if (!Convert.IsDBNull(drw[C_StartedAt])) this.dtmStartedAt = Convert.ToDateTime(drw[C_StartedAt]);
                if (!Convert.IsDBNull(drw[C_SubmittedAt])) this.dtmSubmittedAt = Convert.ToDateTime(drw[C_SubmittedAt]);
                if (!Convert.IsDBNull(drw[C_Score])) this.decScore = Convert.ToDecimal(drw[C_Score]);
                if (!Convert.IsDBNull(drw[C_MaxScore])) this.decMaxScore = Convert.ToDecimal(drw[C_MaxScore]);
                if (!Convert.IsDBNull(drw[C_ScorePercent])) this.decScorePercent = Convert.ToDecimal(drw[C_ScorePercent]);
                if (!Convert.IsDBNull(drw[C_Passed])) this.bolPassed = Convert.ToBoolean(drw[C_Passed]);
                if (!Convert.IsDBNull(drw[C_AttemptStatus])) this.strAttemptStatus = Convert.ToString(drw[C_AttemptStatus]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_QuizAttempts", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuizAttempts_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuizAttemptID, this.lngQuizAttemptID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_QuizAttempts", objEx);
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
        /// Store: LMS_QuizAttempts_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuizAttemptID)
        {
            this.lngQuizAttemptID = lngQuizAttemptID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_QuizAttempts_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_AttemptNumber, this.intAttemptNumber);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_SubmittedAt, this.dtmSubmittedAt);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_MaxScore, this.decMaxScore);
                objIData.AddParameter(P_ScorePercent, this.decScorePercent);
                objIData.AddParameter(P_Passed, this.bolPassed);
                objIData.AddParameter(P_AttemptStatus, this.strAttemptStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_QuizAttempts", objEx);
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
        /// Store: LMS_QuizAttempts_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuizAttemptID, this.lngQuizAttemptID);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_AttemptNumber, this.intAttemptNumber);
                objIData.AddParameter(P_StartedAt, this.dtmStartedAt);
                objIData.AddParameter(P_SubmittedAt, this.dtmSubmittedAt);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_MaxScore, this.decMaxScore);
                objIData.AddParameter(P_ScorePercent, this.decScorePercent);
                objIData.AddParameter(P_Passed, this.bolPassed);
                objIData.AddParameter(P_AttemptStatus, this.strAttemptStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_QuizAttempts", objEx);
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
        /// Store: LMS_QuizAttempts_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuizAttemptID, this.lngQuizAttemptID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_QuizAttempts", objEx);
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
        /// Store: LMS_QuizAttempts_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuizAttemptID)
        {
            this.lngQuizAttemptID = lngQuizAttemptID;
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

        public LMS_QuizAttempts()
        {
        }
        public LMS_QuizAttempts(long lngQuizAttemptID)
        {
            this.lngQuizAttemptID = lngQuizAttemptID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_QuizAttempts";
        public const string StoreGet = "LMS_QuizAttempts_GET";
        public const string StoreGetAll = "LMS_QuizAttempts_GETALL";
        public const string StoreSearch = "LMS_QuizAttempts_SEARCH";
        public const string StoreAdd = "LMS_QuizAttempts_ADD";
        public const string StoreEdit = "LMS_QuizAttempts_EDIT";
        public const string StoreDelete = "LMS_QuizAttempts_DELETE";

        #region Parameter Names

        public const String P_QuizAttemptID = "@" + C_QuizAttemptID;
        public const String P_QuizID = "@" + C_QuizID;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_AttemptNumber = "@" + C_AttemptNumber;
        public const String P_StartedAt = "@" + C_StartedAt;
        public const String P_SubmittedAt = "@" + C_SubmittedAt;
        public const String P_Score = "@" + C_Score;
        public const String P_MaxScore = "@" + C_MaxScore;
        public const String P_ScorePercent = "@" + C_ScorePercent;
        public const String P_Passed = "@" + C_Passed;
        public const String P_AttemptStatus = "@" + C_AttemptStatus;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuizAttemptID = "QuizAttemptID";
        public const String C_QuizID = "QuizID";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_AttemptNumber = "AttemptNumber";
        public const String C_StartedAt = "StartedAt";
        public const String C_SubmittedAt = "SubmittedAt";
        public const String C_Score = "Score";
        public const String C_MaxScore = "MaxScore";
        public const String C_ScorePercent = "ScorePercent";
        public const String C_Passed = "Passed";
        public const String C_AttemptStatus = "AttemptStatus";

        #endregion //Column names

        #endregion Variable Static
    }
}
