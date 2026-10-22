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
    /// Liên kết câu hỏi dùng chung với một bài học tương tác.
    /// </summary>
    public partial class LMS_ContentInteractions
    {
        #region Member Variables

        private long lngContentInteractionID = 0;//Khóa chính của câu hỏi trong bài học tương tác.
        private long lngInteractiveContentID = 0;//Cấu hình bài học tương tác sở hữu câu hỏi.
        private long lngQuestionID = 0;//Câu hỏi dùng lại từ ngân hàng LMS_Questions.
        private string strContentAnchor = null;//Điểm neo tùy chọn để liên hệ câu hỏi với một phần nội dung.
        private bool bolRequired = false;//Đánh dấu câu hỏi bắt buộc.
        private bool bolAllowRetry = false;//Cho phép học viên thử lại khi chưa đạt.
        private decimal decScore = 0;//Điểm tối đa của câu hỏi trong bài.
        private int intAttemptLimit = 0;//Số lần trả lời tối đa.
        private int intSortOrder = 0;//Thứ tự hiển thị câu hỏi.
        private string strStatus = null;//Trạng thái sử dụng của câu hỏi trong bài học.
        private long lngCreatedByUserID = 0;//Người dùng đã gắn câu hỏi vào bài học.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm gắn câu hỏi theo UTC.
        private long? lngUpdatedByUserID = null;//Người dùng cập nhật liên kết câu hỏi gần nhất.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật liên kết câu hỏi gần nhất theo UTC.
        private bool bolIsDeleted = false;//Cờ xóa mềm của câu hỏi trong bài học.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// ContentInteractionID
        /// Khóa chính của câu hỏi trong bài học tương tác.
        /// </summary>
        public long ContentInteractionID
        {
            get { return lngContentInteractionID; }
            set { lngContentInteractionID = value; }
        }

        /// <summary>
        /// InteractiveContentID
        /// Cấu hình bài học tương tác sở hữu câu hỏi.
        /// </summary>
        public long InteractiveContentID
        {
            get { return lngInteractiveContentID; }
            set { lngInteractiveContentID = value; }
        }

        /// <summary>
        /// QuestionID
        /// Câu hỏi dùng lại từ ngân hàng LMS_Questions.
        /// </summary>
        public long QuestionID
        {
            get { return lngQuestionID; }
            set { lngQuestionID = value; }
        }

        /// <summary>
        /// ContentAnchor
        /// Điểm neo tùy chọn để liên hệ câu hỏi với một phần nội dung.
        /// </summary>
        public string ContentAnchor
        {
            get { return strContentAnchor; }
            set { strContentAnchor = value; }
        }

        /// <summary>
        /// Required
        /// Đánh dấu câu hỏi bắt buộc.
        /// </summary>
        public bool Required
        {
            get { return bolRequired; }
            set { bolRequired = value; }
        }

        /// <summary>
        /// AllowRetry
        /// Cho phép học viên thử lại khi chưa đạt.
        /// </summary>
        public bool AllowRetry
        {
            get { return bolAllowRetry; }
            set { bolAllowRetry = value; }
        }

        /// <summary>
        /// Score
        /// Điểm tối đa của câu hỏi trong bài.
        /// </summary>
        public decimal Score
        {
            get { return decScore; }
            set { decScore = value; }
        }

        /// <summary>
        /// AttemptLimit
        /// Số lần trả lời tối đa.
        /// </summary>
        public int AttemptLimit
        {
            get { return intAttemptLimit; }
            set { intAttemptLimit = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị câu hỏi.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của câu hỏi trong bài học.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// Người dùng đã gắn câu hỏi vào bài học.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm gắn câu hỏi theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedByUserID
        /// Người dùng cập nhật liên kết câu hỏi gần nhất.
        /// </summary>
        public long? UpdatedByUserID
        {
            get { return lngUpdatedByUserID; }
            set { lngUpdatedByUserID = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật liên kết câu hỏi gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của câu hỏi trong bài học.
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
                    if (reader.GetName(i).ToUpper().Equals(C_ContentInteractionID.ToUpper()) && !Convert.IsDBNull(reader[C_ContentInteractionID])) this.lngContentInteractionID = Convert.ToInt64(reader[C_ContentInteractionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_InteractiveContentID.ToUpper()) && !Convert.IsDBNull(reader[C_InteractiveContentID])) this.lngInteractiveContentID = Convert.ToInt64(reader[C_InteractiveContentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(reader[C_QuestionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContentAnchor.ToUpper()) && !Convert.IsDBNull(reader[C_ContentAnchor])) this.strContentAnchor = Convert.ToString(reader[C_ContentAnchor]);
                    if (reader.GetName(i).ToUpper().Equals(C_Required.ToUpper()) && !Convert.IsDBNull(reader[C_Required])) this.bolRequired = Convert.ToBoolean(reader[C_Required]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowRetry.ToUpper()) && !Convert.IsDBNull(reader[C_AllowRetry])) this.bolAllowRetry = Convert.ToBoolean(reader[C_AllowRetry]);
                    if (reader.GetName(i).ToUpper().Equals(C_Score.ToUpper()) && !Convert.IsDBNull(reader[C_Score])) this.decScore = Convert.ToDecimal(reader[C_Score]);
                    if (reader.GetName(i).ToUpper().Equals(C_AttemptLimit.ToUpper()) && !Convert.IsDBNull(reader[C_AttemptLimit])) this.intAttemptLimit = Convert.ToInt32(reader[C_AttemptLimit]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(reader[C_UpdatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_ContentInteractions", objEx);
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
                if (!Convert.IsDBNull(drw[C_ContentInteractionID])) this.lngContentInteractionID = Convert.ToInt64(drw[C_ContentInteractionID]);
                if (!Convert.IsDBNull(drw[C_InteractiveContentID])) this.lngInteractiveContentID = Convert.ToInt64(drw[C_InteractiveContentID]);
                if (!Convert.IsDBNull(drw[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(drw[C_QuestionID]);
                if (!Convert.IsDBNull(drw[C_ContentAnchor])) this.strContentAnchor = Convert.ToString(drw[C_ContentAnchor]);
                if (!Convert.IsDBNull(drw[C_Required])) this.bolRequired = Convert.ToBoolean(drw[C_Required]);
                if (!Convert.IsDBNull(drw[C_AllowRetry])) this.bolAllowRetry = Convert.ToBoolean(drw[C_AllowRetry]);
                if (!Convert.IsDBNull(drw[C_Score])) this.decScore = Convert.ToDecimal(drw[C_Score]);
                if (!Convert.IsDBNull(drw[C_AttemptLimit])) this.intAttemptLimit = Convert.ToInt32(drw[C_AttemptLimit]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(drw[C_UpdatedByUserID]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_ContentInteractions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_ContentInteractions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_ContentInteractionID, this.lngContentInteractionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_ContentInteractions", objEx);
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
        /// Store: LMS_ContentInteractions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngContentInteractionID)
        {
            this.lngContentInteractionID = lngContentInteractionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_ContentInteractions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_InteractiveContentID, this.lngInteractiveContentID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_ContentAnchor, this.strContentAnchor);
                objIData.AddParameter(P_Required, this.bolRequired);
                objIData.AddParameter(P_AllowRetry, this.bolAllowRetry);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_AttemptLimit, this.intAttemptLimit);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_ContentInteractions", objEx);
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
        /// Store: LMS_ContentInteractions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_ContentInteractionID, this.lngContentInteractionID);
                objIData.AddParameter(P_InteractiveContentID, this.lngInteractiveContentID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_ContentAnchor, this.strContentAnchor);
                objIData.AddParameter(P_Required, this.bolRequired);
                objIData.AddParameter(P_AllowRetry, this.bolAllowRetry);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_AttemptLimit, this.intAttemptLimit);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_ContentInteractions", objEx);
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
        /// Store: LMS_ContentInteractions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_ContentInteractionID, this.lngContentInteractionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_ContentInteractions", objEx);
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
        /// Store: LMS_ContentInteractions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngContentInteractionID)
        {
            this.lngContentInteractionID = lngContentInteractionID;
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

        public LMS_ContentInteractions()
        {
        }
        public LMS_ContentInteractions(long lngContentInteractionID)
        {
            this.lngContentInteractionID = lngContentInteractionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_ContentInteractions";
        public const string StoreGet = "LMS_ContentInteractions_GET";
        public const string StoreGetAll = "LMS_ContentInteractions_GETALL";
        public const string StoreSearch = "LMS_ContentInteractions_SEARCH";
        public const string StoreAdd = "LMS_ContentInteractions_ADD";
        public const string StoreEdit = "LMS_ContentInteractions_EDIT";
        public const string StoreDelete = "LMS_ContentInteractions_DELETE";

        #region Parameter Names

        public const String P_ContentInteractionID = "@" + C_ContentInteractionID;
        public const String P_InteractiveContentID = "@" + C_InteractiveContentID;
        public const String P_QuestionID = "@" + C_QuestionID;
        public const String P_ContentAnchor = "@" + C_ContentAnchor;
        public const String P_Required = "@" + C_Required;
        public const String P_AllowRetry = "@" + C_AllowRetry;
        public const String P_Score = "@" + C_Score;
        public const String P_AttemptLimit = "@" + C_AttemptLimit;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_Status = "@" + C_Status;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedByUserID = "@" + C_UpdatedByUserID;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_IsDeleted = "@" + C_IsDeleted;

        #endregion //Parameter names

        #region Column Names

        public const String C_ContentInteractionID = "ContentInteractionID";
        public const String C_InteractiveContentID = "InteractiveContentID";
        public const String C_QuestionID = "QuestionID";
        public const String C_ContentAnchor = "ContentAnchor";
        public const String C_Required = "Required";
        public const String C_AllowRetry = "AllowRetry";
        public const String C_Score = "Score";
        public const String C_AttemptLimit = "AttemptLimit";
        public const String C_SortOrder = "SortOrder";
        public const String C_Status = "Status";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedByUserID = "UpdatedByUserID";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_IsDeleted = "IsDeleted";

        #endregion //Column names

        #endregion Variable Static
    }
}
