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
    /// [LMS] Câu hỏi tương tác tại các mốc thời gian của video.
    /// </summary>
    public partial class LMS_VideoInteractions
    {
        #region Member Variables

        private long lngVideoInteractionID = 0;//Khóa chính tự tăng của tương tác video.
        private long lngVideoId = 0;//ID video chứa mốc tương tác.
        private long lngQuestionId = 0;//ID câu hỏi được hiển thị tại mốc tương tác.
        private int intTimeSeconds = 0;//Thời điểm bắt đầu tương tác tính từ đầu video, đơn vị giây.
        private int? intEndTimeSeconds = null;//Thời điểm kết thúc vùng tương tác tính bằng giây; có thể rỗng.
        private string strInteractionType = null;//Loại tương tác được kích hoạt trong video.
        private bool bolRequired = false;//Cờ bắt buộc học viên phải trả lời tương tác.
        private bool bolPauseVideo = false;//Cờ tự động tạm dừng video khi tương tác xuất hiện.
        private bool bolAllowSkip = false;//Cờ cho phép học viên bỏ qua tương tác.
        private decimal decScore = 0;//Điểm tối đa của tương tác.
        private int intAttemptLimit = 0;//Số lần tối đa được phép trả lời tương tác.
        private int intSortOrder = 0;//Thứ tự xử lý khi nhiều tương tác cùng thời điểm.
        private string strStatus = null;//Trạng thái sử dụng của tương tác.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo tương tác theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật tương tác gần nhất theo UTC.
        private bool bolIsDeleted = false;//Cờ xóa mềm của tương tác.
        private long? lngVideoVersionID = null;//ID phiên bản video chứa mốc tương tác.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// VideoInteractionID
        /// Khóa chính tự tăng của tương tác video.
        /// </summary>
        public long VideoInteractionID
        {
            get { return lngVideoInteractionID; }
            set { lngVideoInteractionID = value; }
        }

        /// <summary>
        /// VideoId
        /// ID video chứa mốc tương tác.
        /// </summary>
        public long VideoId
        {
            get { return lngVideoId; }
            set { lngVideoId = value; }
        }

        /// <summary>
        /// QuestionId
        /// ID câu hỏi được hiển thị tại mốc tương tác.
        /// </summary>
        public long QuestionId
        {
            get { return lngQuestionId; }
            set { lngQuestionId = value; }
        }

        /// <summary>
        /// TimeSeconds
        /// Thời điểm bắt đầu tương tác tính từ đầu video, đơn vị giây.
        /// </summary>
        public int TimeSeconds
        {
            get { return intTimeSeconds; }
            set { intTimeSeconds = value; }
        }

        /// <summary>
        /// EndTimeSeconds
        /// Thời điểm kết thúc vùng tương tác tính bằng giây; có thể rỗng.
        /// </summary>
        public int? EndTimeSeconds
        {
            get { return intEndTimeSeconds; }
            set { intEndTimeSeconds = value; }
        }

        /// <summary>
        /// InteractionType
        /// Loại tương tác được kích hoạt trong video.
        /// </summary>
        public string InteractionType
        {
            get { return strInteractionType; }
            set { strInteractionType = value; }
        }

        /// <summary>
        /// Required
        /// Cờ bắt buộc học viên phải trả lời tương tác.
        /// </summary>
        public bool Required
        {
            get { return bolRequired; }
            set { bolRequired = value; }
        }

        /// <summary>
        /// PauseVideo
        /// Cờ tự động tạm dừng video khi tương tác xuất hiện.
        /// </summary>
        public bool PauseVideo
        {
            get { return bolPauseVideo; }
            set { bolPauseVideo = value; }
        }

        /// <summary>
        /// AllowSkip
        /// Cờ cho phép học viên bỏ qua tương tác.
        /// </summary>
        public bool AllowSkip
        {
            get { return bolAllowSkip; }
            set { bolAllowSkip = value; }
        }

        /// <summary>
        /// Score
        /// Điểm tối đa của tương tác.
        /// </summary>
        public decimal Score
        {
            get { return decScore; }
            set { decScore = value; }
        }

        /// <summary>
        /// AttemptLimit
        /// Số lần tối đa được phép trả lời tương tác.
        /// </summary>
        public int AttemptLimit
        {
            get { return intAttemptLimit; }
            set { intAttemptLimit = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự xử lý khi nhiều tương tác cùng thời điểm.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của tương tác.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo tương tác theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật tương tác gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của tương tác.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// VideoVersionID
        /// ID phiên bản video chứa mốc tương tác.
        /// </summary>
        public long? VideoVersionID
        {
            get { return lngVideoVersionID; }
            set { lngVideoVersionID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_VideoInteractionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoInteractionID])) this.lngVideoInteractionID = Convert.ToInt64(reader[C_VideoInteractionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoId.ToUpper()) && !Convert.IsDBNull(reader[C_VideoId])) this.lngVideoId = Convert.ToInt64(reader[C_VideoId]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionId.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(reader[C_QuestionId]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_TimeSeconds])) this.intTimeSeconds = Convert.ToInt32(reader[C_TimeSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_EndTimeSeconds.ToUpper()) && !Convert.IsDBNull(reader[C_EndTimeSeconds])) this.intEndTimeSeconds = Convert.ToInt32(reader[C_EndTimeSeconds]);
                    if (reader.GetName(i).ToUpper().Equals(C_InteractionType.ToUpper()) && !Convert.IsDBNull(reader[C_InteractionType])) this.strInteractionType = Convert.ToString(reader[C_InteractionType]);
                    if (reader.GetName(i).ToUpper().Equals(C_Required.ToUpper()) && !Convert.IsDBNull(reader[C_Required])) this.bolRequired = Convert.ToBoolean(reader[C_Required]);
                    if (reader.GetName(i).ToUpper().Equals(C_PauseVideo.ToUpper()) && !Convert.IsDBNull(reader[C_PauseVideo])) this.bolPauseVideo = Convert.ToBoolean(reader[C_PauseVideo]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowSkip.ToUpper()) && !Convert.IsDBNull(reader[C_AllowSkip])) this.bolAllowSkip = Convert.ToBoolean(reader[C_AllowSkip]);
                    if (reader.GetName(i).ToUpper().Equals(C_Score.ToUpper()) && !Convert.IsDBNull(reader[C_Score])) this.decScore = Convert.ToDecimal(reader[C_Score]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptLimit.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptLimit])) this.intAttemptLimit = Convert.ToInt32(reader[C_AttemptLimit]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_VideoVersionID.ToUpper()) && !Convert.IsDBNull(reader[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(reader[C_VideoVersionID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_VideoInteractions", objEx);
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
                if (!Convert.IsDBNull(drw[C_VideoInteractionID])) this.lngVideoInteractionID = Convert.ToInt64(drw[C_VideoInteractionID]);
                if (!Convert.IsDBNull(drw[C_VideoId])) this.lngVideoId = Convert.ToInt64(drw[C_VideoId]);
                if (!Convert.IsDBNull(drw[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(drw[C_QuestionId]);
                if (!Convert.IsDBNull(drw[C_TimeSeconds])) this.intTimeSeconds = Convert.ToInt32(drw[C_TimeSeconds]);
                if (!Convert.IsDBNull(drw[C_EndTimeSeconds])) this.intEndTimeSeconds = Convert.ToInt32(drw[C_EndTimeSeconds]);
                if (!Convert.IsDBNull(drw[C_InteractionType])) this.strInteractionType = Convert.ToString(drw[C_InteractionType]);
                if (!Convert.IsDBNull(drw[C_Required])) this.bolRequired = Convert.ToBoolean(drw[C_Required]);
                if (!Convert.IsDBNull(drw[C_PauseVideo])) this.bolPauseVideo = Convert.ToBoolean(drw[C_PauseVideo]);
                if (!Convert.IsDBNull(drw[C_AllowSkip])) this.bolAllowSkip = Convert.ToBoolean(drw[C_AllowSkip]);
                if (!Convert.IsDBNull(drw[C_Score])) this.decScore = Convert.ToDecimal(drw[C_Score]);
                if (!Convert.IsDBNull(drw[C_AttemptLimit])) this.intAttemptLimit = Convert.ToInt32(drw[C_AttemptLimit]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_VideoVersionID])) this.lngVideoVersionID = Convert.ToInt64(drw[C_VideoVersionID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_VideoInteractions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_VideoInteractions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_VideoInteractionID, this.lngVideoInteractionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_VideoInteractions", objEx);
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
        /// Store: LMS_VideoInteractions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngVideoInteractionID)
        {
            this.lngVideoInteractionID = lngVideoInteractionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_VideoInteractions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_TimeSeconds, this.intTimeSeconds);
                objIData.AddParameter(P_EndTimeSeconds, this.intEndTimeSeconds);
                objIData.AddParameter(P_InteractionType, this.strInteractionType);
                objIData.AddParameter(P_Required, this.bolRequired);
                objIData.AddParameter(P_PauseVideo, this.bolPauseVideo);
                objIData.AddParameter(P_AllowSkip, this.bolAllowSkip);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_AttemptLimit, this.intAttemptLimit);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_VideoInteractions", objEx);
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
        /// Store: LMS_VideoInteractions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_VideoInteractionID, this.lngVideoInteractionID);
                objIData.AddParameter(P_VideoId, this.lngVideoId);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_TimeSeconds, this.intTimeSeconds);
                objIData.AddParameter(P_EndTimeSeconds, this.intEndTimeSeconds);
                objIData.AddParameter(P_InteractionType, this.strInteractionType);
                objIData.AddParameter(P_Required, this.bolRequired);
                objIData.AddParameter(P_PauseVideo, this.bolPauseVideo);
                objIData.AddParameter(P_AllowSkip, this.bolAllowSkip);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_AttemptLimit, this.intAttemptLimit);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_VideoVersionID, this.lngVideoVersionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_VideoInteractions", objEx);
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
        /// Store: LMS_VideoInteractions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_VideoInteractionID, this.lngVideoInteractionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_VideoInteractions", objEx);
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
        /// Store: LMS_VideoInteractions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngVideoInteractionID)
        {
            this.lngVideoInteractionID = lngVideoInteractionID;
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

        public LMS_VideoInteractions()
        {
        }
        public LMS_VideoInteractions(long lngVideoInteractionID)
        {
            this.lngVideoInteractionID = lngVideoInteractionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_VideoInteractions";
        public const string StoreGet = "LMS_VideoInteractions_GET";
        public const string StoreGetAll = "LMS_VideoInteractions_GETALL";
        public const string StoreSearch = "LMS_VideoInteractions_SEARCH";
        public const string StoreAdd = "LMS_VideoInteractions_ADD";
        public const string StoreEdit = "LMS_VideoInteractions_EDIT";
        public const string StoreDelete = "LMS_VideoInteractions_DELETE";

        #region Parameter Names

        public const String P_VideoInteractionID = "@" + C_VideoInteractionID;
        public const String P_VideoId = "@" + C_VideoId;
        public const String P_QuestionId = "@" + C_QuestionId;
        public const String P_TimeSeconds = "@" + C_TimeSeconds;
        public const String P_EndTimeSeconds = "@" + C_EndTimeSeconds;
        public const String P_InteractionType = "@" + C_InteractionType;
        public const String P_Required = "@" + C_Required;
        public const String P_PauseVideo = "@" + C_PauseVideo;
        public const String P_AllowSkip = "@" + C_AllowSkip;
        public const String P_Score = "@" + C_Score;
        public const String P_AttemptLimit = "@" + C_AttemptLimit;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_Status = "@" + C_Status;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_VideoVersionID = "@" + C_VideoVersionID;

        #endregion //Parameter names

        #region Column Names

        public const String C_VideoInteractionID = "VideoInteractionID";
        public const String C_VideoId = "VideoId";
        public const String C_QuestionId = "QuestionId";
        public const String C_TimeSeconds = "TimeSeconds";
        public const String C_EndTimeSeconds = "EndTimeSeconds";
        public const String C_InteractionType = "InteractionType";
        public const String C_Required = "Required";
        public const String C_PauseVideo = "PauseVideo";
        public const String C_AllowSkip = "AllowSkip";
        public const String C_Score = "Score";
        public const String C_AttemptLimit = "AttemptLimit";
        public const String C_SortOrder = "SortOrder";
        public const String C_Status = "Status";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_VideoVersionID = "VideoVersionID";

        #endregion //Column names

        #endregion Variable Static
    }
}
