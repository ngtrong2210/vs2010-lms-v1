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
    /// [LMS] Câu trả lời, điểm số và trạng thái chấm của học viên.
    /// </summary>
    public partial class LMS_StudentAnswers
    {
        #region Member Variables

        private long lngStudentAnswerID = 0;//Khóa chính tự tăng của lần trả lời.
        private long lngStudentUserID = 0;//ID học viên thực hiện câu trả lời.
        private long lngCourseId = 0;//ID khóa học phát sinh câu trả lời.
        private long lngLessonId = 0;//ID bài học phát sinh câu trả lời.
        private long? lngVideoId = null;//ID video phát sinh câu trả lời; rỗng nếu không từ video.
        private long? lngVideoInteractionID = null;//ID tương tác video phát sinh câu trả lời.
        private long lngQuestionId = 0;//ID câu hỏi được trả lời.
        private int intAttemptNumber = 0;//Số thứ tự lần thử của học viên với câu hỏi.
        private string strAnswerText = null;//Nội dung trả lời dạng chữ của học viên.
        private bool? bolIsCorrect = null;//Kết quả đúng/sai; rỗng khi chưa chấm.
        private decimal decScoreAwarded = 0;//Số điểm được trao cho lần trả lời.
        private string strReviewStatus = null;//Trạng thái chấm hoặc duyệt câu trả lời.
        private DateTime dtmAnsweredAt = DateTime.MinValue;//Thời điểm học viên trả lời theo UTC.
        private decimal? decTimeInVideoSeconds = null;//Vị trí video khi học viên trả lời, đơn vị giây.
        private int? intTimeSpentSeconds = null;//Thời gian học viên dùng để trả lời, đơn vị giây.
        private long? lngReviewedByUserID = null;//ID người dùng chấm hoặc duyệt câu trả lời.
        private DateTime? dtmReviewedAt = null;//Thời điểm chấm hoặc duyệt câu trả lời theo UTC.
        private string strReviewerComment = null;//Nhận xét của người chấm dành cho học viên.
        private long? lngVideoVersionID = null;//ID phiên bản video tại thời điểm học viên trả lời.
        private long? lngContentInteractionID = null;//Câu hỏi bài đọc tương tác tương ứng; rỗng đối với video hoặc quiz.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudentAnswerID
        /// Khóa chính tự tăng của lần trả lời.
        /// </summary>
        public long StudentAnswerID
        {
            get { return lngStudentAnswerID; }
            set { lngStudentAnswerID = value; }
        }

        /// <summary>
        /// StudentUserID
        /// ID học viên thực hiện câu trả lời.
        /// </summary>
        public long StudentUserID
        {
            get { return lngStudentUserID; }
            set { lngStudentUserID = value; }
        }

        /// <summary>
        /// CourseId
        /// ID khóa học phát sinh câu trả lời.
        /// </summary>
        public long CourseId
        {
            get { return lngCourseId; }
            set { lngCourseId = value; }
        }

        /// <summary>
        /// LessonId
        /// ID bài học phát sinh câu trả lời.
        /// </summary>
        public long LessonId
        {
            get { return lngLessonId; }
            set { lngLessonId = value; }
        }

        /// <summary>
        /// VideoId
        /// ID video phát sinh câu trả lời; rỗng nếu không từ video.
        /// </summary>
        public long? VideoId
        {
            get { return lngVideoId; }
            set { lngVideoId = value; }
        }

        /// <summary>
        /// VideoInteractionID
        /// ID tương tác video phát sinh câu trả lời.
        /// </summary>
        public long? VideoInteractionID
        {
            get { return lngVideoInteractionID; }
            set { lngVideoInteractionID = value; }
        }

        /// <summary>
        /// QuestionId
        /// ID câu hỏi được trả lời.
        /// </summary>
        public long QuestionId
        {
            get { return lngQuestionId; }
            set { lngQuestionId = value; }
        }

        /// <summary>
        /// AttemptNumber
        /// Số thứ tự lần thử của học viên với câu hỏi.
        /// </summary>
        public int AttemptNumber
        {
            get { return intAttemptNumber; }
            set { intAttemptNumber = value; }
        }

        /// <summary>
        /// AnswerText
        /// Nội dung trả lời dạng chữ của học viên.
        /// </summary>
        public string AnswerText
        {
            get { return strAnswerText; }
            set { strAnswerText = value; }
        }

        /// <summary>
        /// IsCorrect
        /// Kết quả đúng/sai; rỗng khi chưa chấm.
        /// </summary>
        public bool? IsCorrect
        {
            get { return bolIsCorrect; }
            set { bolIsCorrect = value; }
        }

        /// <summary>
        /// ScoreAwarded
        /// Số điểm được trao cho lần trả lời.
        /// </summary>
        public decimal ScoreAwarded
        {
            get { return decScoreAwarded; }
            set { decScoreAwarded = value; }
        }

        /// <summary>
        /// ReviewStatus
        /// Trạng thái chấm hoặc duyệt câu trả lời.
        /// </summary>
        public string ReviewStatus
        {
            get { return strReviewStatus; }
            set { strReviewStatus = value; }
        }

        /// <summary>
        /// AnsweredAt
        /// Thời điểm học viên trả lời theo UTC.
        /// </summary>
        public DateTime AnsweredAt
        {
            get { return dtmAnsweredAt; }
            set { dtmAnsweredAt = value; }
        }

        /// <summary>
        /// TimeInVideoSeconds
        /// Vị trí video khi học viên trả lời, đơn vị giây.
        /// </summary>
        public decimal? TimeInVideoSeconds
        {
            get { return decTimeInVideoSeconds; }
            set { decTimeInVideoSeconds = value; }
        }

        /// <summary>
        /// TimeSpentSeconds
        /// Thời gian học viên dùng để trả lời, đơn vị giây.
        /// </summary>
        public int? TimeSpentSeconds
        {
            get { return intTimeSpentSeconds; }
            set { intTimeSpentSeconds = value; }
        }

        /// <summary>
        /// ReviewedByUserID
        /// ID người dùng chấm hoặc duyệt câu trả lời.
        /// </summary>
        public long? ReviewedByUserID
        {
            get { return lngReviewedByUserID; }
            set { lngReviewedByUserID = value; }
        }

        /// <summary>
        /// ReviewedAt
        /// Thời điểm chấm hoặc duyệt câu trả lời theo UTC.
        /// </summary>
        public DateTime? ReviewedAt
        {
            get { return dtmReviewedAt; }
            set { dtmReviewedAt = value; }
        }

        /// <summary>
        /// ReviewerComment
        /// Nhận xét của người chấm dành cho học viên.
        /// </summary>
        public string ReviewerComment
        {
            get { return strReviewerComment; }
            set { strReviewerComment = value; }
        }

        /// <summary>
        /// VideoVersionID
        /// ID phiên bản video tại thời điểm học viên trả lời.
        /// </summary>
        public long? VideoVersionID
        {
            get { return lngVideoVersionID; }
            set { lngVideoVersionID = value; }
        }

        /// <summary>
        /// ContentInteractionID
        /// Câu hỏi bài đọc tương tác tương ứng; rỗng đối với video hoặc quiz.
        /// </summary>
        public long? ContentInteractionID
        {
            get { return lngContentInteractionID; }
            set { lngContentInteractionID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentAnswerID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentAnswerID])) this.lngStudentAnswerID = Convert.ToInt64(reader[C_StudentAnswerID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentUserID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(reader[C_StudentUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonId.ToUpper()) && !Convert.IsDBNull(reader[C_LessonId])) this.lngLessonId = Convert.ToInt64(reader[C_LessonId]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoId.ToUpper()) && !Convert.IsDBNull(reader[C_VideoId])) this.lngVideoId = Convert.ToInt64(reader[C_VideoId]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoInteractionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoInteractionID])) this.lngVideoInteractionID = Convert.ToInt64(reader[C_VideoInteractionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionId.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(reader[C_QuestionId]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptNumber.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptNumber])) this.intAttemptNumber = Convert.ToInt32(reader[C_AttemptNumber]);
                    if (reader.GetName(i).ToUpper().Equals(C_AnswerText.ToUpper()) && !Convert.IsDBNull(reader[C_AnswerText])) this.strAnswerText = Convert.ToString(reader[C_AnswerText]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCorrect.ToUpper()) && !Convert.IsDBNull(reader[C_IsCorrect])) this.bolIsCorrect = Convert.ToBoolean(reader[C_IsCorrect]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScoreAwarded.ToUpper()) && !Convert.IsDBNull(reader[C_ScoreAwarded])) this.decScoreAwarded = Convert.ToDecimal(reader[C_ScoreAwarded]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewStatus.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewStatus])) this.strReviewStatus = Convert.ToString(reader[C_ReviewStatus]);
                    if (reader.GetName(i).ToUpper().Equals(C_AnsweredAt.ToUpper()) && !Convert.IsDBNull(reader[C_AnsweredAt])) this.dtmAnsweredAt = Convert.ToDateTime(reader[C_AnsweredAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeInVideoSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_TimeInVideoSeconds])) this.decTimeInVideoSeconds = Convert.ToDecimal(reader[C_TimeInVideoSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeSpentSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_TimeSpentSeconds])) this.intTimeSpentSeconds = Convert.ToInt32(reader[C_TimeSpentSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedByUserID])) this.lngReviewedByUserID = Convert.ToInt64(reader[C_ReviewedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedAt])) this.dtmReviewedAt = Convert.ToDateTime(reader[C_ReviewedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReviewerComment.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewerComment])) this.strReviewerComment = Convert.ToString(reader[C_ReviewerComment]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(reader[C_VideoVersionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContentInteractionID.ToUpper()) && !Convert.IsDBNull(reader[C_ContentInteractionID])) this.lngContentInteractionID = Convert.ToInt64(reader[C_ContentInteractionID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_StudentAnswers", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentAnswerID])) this.lngStudentAnswerID = Convert.ToInt64(drw[C_StudentAnswerID]);
                if (!Convert.IsDBNull(drw[C_StudentUserID])) this.lngStudentUserID = Convert.ToInt64(drw[C_StudentUserID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_LessonId])) this.lngLessonId = Convert.ToInt64(drw[C_LessonId]);
                if (!Convert.IsDBNull(drw[C_VideoId])) this.lngVideoId = Convert.ToInt64(drw[C_VideoId]);
                if (!Convert.IsDBNull(drw[C_VideoInteractionID])) this.lngVideoInteractionID = Convert.ToInt64(drw[C_VideoInteractionID]);
                if (!Convert.IsDBNull(drw[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(drw[C_QuestionId]);
                if (!Convert.IsDBNull(drw[C_AttemptNumber])) this.intAttemptNumber = Convert.ToInt32(drw[C_AttemptNumber]);
                if (!Convert.IsDBNull(drw[C_AnswerText])) this.strAnswerText = Convert.ToString(drw[C_AnswerText]);
                if (!Convert.IsDBNull(drw[C_IsCorrect])) this.bolIsCorrect = Convert.ToBoolean(drw[C_IsCorrect]);
                if (!Convert.IsDBNull(drw[C_ScoreAwarded])) this.decScoreAwarded = Convert.ToDecimal(drw[C_ScoreAwarded]);
                if (!Convert.IsDBNull(drw[C_ReviewStatus])) this.strReviewStatus = Convert.ToString(drw[C_ReviewStatus]);
                if (!Convert.IsDBNull(drw[C_AnsweredAt])) this.dtmAnsweredAt = Convert.ToDateTime(drw[C_AnsweredAt]);
                if (!Convert.IsDBNull(drw[C_TimeInVideoSeconds])) this.decTimeInVideoSeconds = Convert.ToDecimal(drw[C_TimeInVideoSeconds]);
                if (!Convert.IsDBNull(drw[C_TimeSpentSeconds])) this.intTimeSpentSeconds = Convert.ToInt32(drw[C_TimeSpentSeconds]);
                if (!Convert.IsDBNull(drw[C_ReviewedByUserID])) this.lngReviewedByUserID = Convert.ToInt64(drw[C_ReviewedByUserID]);
                if (!Convert.IsDBNull(drw[C_ReviewedAt])) this.dtmReviewedAt = Convert.ToDateTime(drw[C_ReviewedAt]);
                if (!Convert.IsDBNull(drw[C_ReviewerComment])) this.strReviewerComment = Convert.ToString(drw[C_ReviewerComment]);
                if (!Convert.IsDBNull(drw[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(drw[C_VideoVersionID]);
                if (!Convert.IsDBNull(drw[C_ContentInteractionID])) this.lngContentInteractionID = Convert.ToInt64(drw[C_ContentInteractionID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_StudentAnswers", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_StudentAnswers_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_StudentAnswerID, this.lngStudentAnswerID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_StudentAnswers", objEx);
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
        /// Store: LMS_StudentAnswers_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngStudentAnswerID)
        {
            this.lngStudentAnswerID = lngStudentAnswerID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_StudentAnswers_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_VideoInteractionID, this.lngVideoInteractionID);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_AttemptNumber, this.intAttemptNumber);
                objIData.AddParameter(P_AnswerText, this.strAnswerText);
                objIData.AddParameter(P_IsCorrect, this.bolIsCorrect);
                objIData.AddParameter(P_ScoreAwarded, this.decScoreAwarded);
                objIData.AddParameter(P_ReviewStatus, this.strReviewStatus);
                objIData.AddParameter(P_AnsweredAt, this.dtmAnsweredAt);
                objIData.AddParameter(P_TimeInVideoSeconds, this.decTimeInVideoSeconds);
                objIData.AddParameter(P_TimeSpentSeconds, this.intTimeSpentSeconds);
                objIData.AddParameter(P_ReviewedByUserID, this.lngReviewedByUserID);
                objIData.AddParameter(P_ReviewedAt, this.dtmReviewedAt);
                objIData.AddParameter(P_ReviewerComment, this.strReviewerComment);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.AddParameter(P_ContentInteractionID, this.lngContentInteractionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_StudentAnswers", objEx);
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
        /// Store: LMS_StudentAnswers_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_StudentAnswerID, this.lngStudentAnswerID);
                objIData.AddParameter(P_StudentUserID, this.lngStudentUserID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_LessonId, this.lngLessonId);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_VideoInteractionID, this.lngVideoInteractionID);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_AttemptNumber, this.intAttemptNumber);
                objIData.AddParameter(P_AnswerText, this.strAnswerText);
                objIData.AddParameter(P_IsCorrect, this.bolIsCorrect);
                objIData.AddParameter(P_ScoreAwarded, this.decScoreAwarded);
                objIData.AddParameter(P_ReviewStatus, this.strReviewStatus);
                objIData.AddParameter(P_AnsweredAt, this.dtmAnsweredAt);
                objIData.AddParameter(P_TimeInVideoSeconds, this.decTimeInVideoSeconds);
                objIData.AddParameter(P_TimeSpentSeconds, this.intTimeSpentSeconds);
                objIData.AddParameter(P_ReviewedByUserID, this.lngReviewedByUserID);
                objIData.AddParameter(P_ReviewedAt, this.dtmReviewedAt);
                objIData.AddParameter(P_ReviewerComment, this.strReviewerComment);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.AddParameter(P_ContentInteractionID, this.lngContentInteractionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_StudentAnswers", objEx);
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
        /// Store: LMS_StudentAnswers_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_StudentAnswerID, this.lngStudentAnswerID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_StudentAnswers", objEx);
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
        /// Store: LMS_StudentAnswers_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngStudentAnswerID)
        {
            this.lngStudentAnswerID = lngStudentAnswerID;
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

        public LMS_StudentAnswers()
        {
        }
        public LMS_StudentAnswers(long lngStudentAnswerID)
        {
            this.lngStudentAnswerID = lngStudentAnswerID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_StudentAnswers";
        public const string StoreGet = "LMS_StudentAnswers_GET";
        public const string StoreGetAll = "LMS_StudentAnswers_GETALL";
        public const string StoreSearch = "LMS_StudentAnswers_SEARCH";
        public const string StoreAdd = "LMS_StudentAnswers_ADD";
        public const string StoreEdit = "LMS_StudentAnswers_EDIT";
        public const string StoreDelete = "LMS_StudentAnswers_DELETE";

        #region Parameter Names

        public const String P_StudentAnswerID = "@" + C_StudentAnswerID;
        public const String P_StudentUserID = "@" + C_StudentUserID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_LessonId = "@" + C_LessonId;
        public const String P_VideoId = "@" + C_VideoId;
        public const String P_VideoInteractionID = "@" + C_VideoInteractionID;
        public const String P_QuestionId = "@" + C_QuestionId;
        public const String P_AttemptNumber = "@" + C_AttemptNumber;
        public const String P_AnswerText = "@" + C_AnswerText;
        public const String P_IsCorrect = "@" + C_IsCorrect;
        public const String P_ScoreAwarded = "@" + C_ScoreAwarded;
        public const String P_ReviewStatus = "@" + C_ReviewStatus;
        public const String P_AnsweredAt = "@" + C_AnsweredAt;
        public const String P_TimeInVideoSeconds = "@" + C_TimeInVideoSeconds;
        public const String P_TimeSpentSeconds = "@" + C_TimeSpentSeconds;
        public const String P_ReviewedByUserID = "@" + C_ReviewedByUserID;
        public const String P_ReviewedAt = "@" + C_ReviewedAt;
        public const String P_ReviewerComment = "@" + C_ReviewerComment;
        public const String P_VideoVersionID = "@" + C_VideoVersionID;
        public const String P_ContentInteractionID = "@" + C_ContentInteractionID;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentAnswerID = "StudentAnswerID";
        public const String C_StudentUserID = "StudentUserID";
        public const String C_CourseId = "CourseId";
        public const String C_LessonId = "LessonId";
        public const String C_VideoId = "VideoId";
        public const String C_VideoInteractionID = "VideoInteractionID";
        public const String C_QuestionId = "QuestionId";
        public const String C_AttemptNumber = "AttemptNumber";
        public const String C_AnswerText = "AnswerText";
        public const String C_IsCorrect = "IsCorrect";
        public const String C_ScoreAwarded = "ScoreAwarded";
        public const String C_ReviewStatus = "ReviewStatus";
        public const String C_AnsweredAt = "AnsweredAt";
        public const String C_TimeInVideoSeconds = "TimeInVideoSeconds";
        public const String C_TimeSpentSeconds = "TimeSpentSeconds";
        public const String C_ReviewedByUserID = "ReviewedByUserID";
        public const String C_ReviewedAt = "ReviewedAt";
        public const String C_ReviewerComment = "ReviewerComment";
        public const String C_VideoVersionID = "VideoVersionID";
        public const String C_ContentInteractionID = "ContentInteractionID";

        #endregion //Column names

        #endregion Variable Static
    }
}
