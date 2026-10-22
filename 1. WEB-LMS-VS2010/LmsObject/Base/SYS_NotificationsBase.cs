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
    /// [SYS] Thông báo nghiệp vụ gửi đến từng tài khoản, hỗ trợ trạng thái đã đọc và điều hướng đến dữ liệu liên quan.
    /// </summary>
    public partial class SYS_Notifications
    {
        #region Member Variables

        private long lngNotificationID = 0;//Khóa chính tự tăng của thông báo.
        private long lngRecipientUserID = 0;//Tài khoản nhận và xem thông báo.
        private long? lngActorUserID = null;//Tài khoản thực hiện hành động phát sinh thông báo; có thể rỗng đối với thông báo hệ thống.
        private string strNotificationType = null;//Loại nghiệp vụ của thông báo, ví dụ ENROLLMENT, ANSWER_SUBMITTED hoặc LESSON_COMPLETED.
        private string strTitle = null;//Tiêu đề ngắn hiển thị trong danh sách thông báo.
        private string strMessage = null;//Nội dung chi tiết giải thích sự kiện phát sinh thông báo.
        private string strReferenceType = null;//Loại dữ liệu nghiệp vụ được tham chiếu như COURSE, LESSON hoặc STUDENT_ANSWER.
        private long? lngReferenceID = null;//Khóa định danh của dữ liệu nghiệp vụ được tham chiếu.
        private string strActionUrl = null;//Đường dẫn nội bộ để mở màn hình liên quan khi người dùng chọn thông báo.
        private string strMetadataJson = null;//Dữ liệu mở rộng dạng JSON phục vụ hiển thị hoặc tích hợp trong tương lai.
        private bool bolIsRead = false;//Đánh dấu người nhận đã đọc thông báo hay chưa.
        private DateTime? dtmReadAt = null;//Thời điểm UTC người nhận đánh dấu đã đọc thông báo.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm UTC thông báo được tạo.
        private DateTime? dtmExpiresAt = null;//Thời điểm UTC thông báo hết hiệu lực; rỗng nghĩa là không tự hết hạn.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// NotificationID
        /// Khóa chính tự tăng của thông báo.
        /// </summary>
        public long NotificationID
        {
            get { return lngNotificationID; }
            set { lngNotificationID = value; }
        }

        /// <summary>
        /// RecipientUserID
        /// Tài khoản nhận và xem thông báo.
        /// </summary>
        public long RecipientUserID
        {
            get { return lngRecipientUserID; }
            set { lngRecipientUserID = value; }
        }

        /// <summary>
        /// ActorUserID
        /// Tài khoản thực hiện hành động phát sinh thông báo; có thể rỗng đối với thông báo hệ thống.
        /// </summary>
        public long? ActorUserID
        {
            get { return lngActorUserID; }
            set { lngActorUserID = value; }
        }

        /// <summary>
        /// NotificationType
        /// Loại nghiệp vụ của thông báo, ví dụ ENROLLMENT, ANSWER_SUBMITTED hoặc LESSON_COMPLETED.
        /// </summary>
        public string NotificationType
        {
            get { return strNotificationType; }
            set { strNotificationType = value; }
        }

        /// <summary>
        /// Title
        /// Tiêu đề ngắn hiển thị trong danh sách thông báo.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// Message
        /// Nội dung chi tiết giải thích sự kiện phát sinh thông báo.
        /// </summary>
        public string Message
        {
            get { return strMessage; }
            set { strMessage = value; }
        }

        /// <summary>
        /// ReferenceType
        /// Loại dữ liệu nghiệp vụ được tham chiếu như COURSE, LESSON hoặc STUDENT_ANSWER.
        /// </summary>
        public string ReferenceType
        {
            get { return strReferenceType; }
            set { strReferenceType = value; }
        }

        /// <summary>
        /// ReferenceID
        /// Khóa định danh của dữ liệu nghiệp vụ được tham chiếu.
        /// </summary>
        public long? ReferenceID
        {
            get { return lngReferenceID; }
            set { lngReferenceID = value; }
        }

        /// <summary>
        /// ActionUrl
        /// Đường dẫn nội bộ để mở màn hình liên quan khi người dùng chọn thông báo.
        /// </summary>
        public string ActionUrl
        {
            get { return strActionUrl; }
            set { strActionUrl = value; }
        }

        /// <summary>
        /// MetadataJson
        /// Dữ liệu mở rộng dạng JSON phục vụ hiển thị hoặc tích hợp trong tương lai.
        /// </summary>
        public string MetadataJson
        {
            get { return strMetadataJson; }
            set { strMetadataJson = value; }
        }

        /// <summary>
        /// IsRead
        /// Đánh dấu người nhận đã đọc thông báo hay chưa.
        /// </summary>
        public bool IsRead
        {
            get { return bolIsRead; }
            set { bolIsRead = value; }
        }

        /// <summary>
        /// ReadAt
        /// Thời điểm UTC người nhận đánh dấu đã đọc thông báo.
        /// </summary>
        public DateTime? ReadAt
        {
            get { return dtmReadAt; }
            set { dtmReadAt = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm UTC thông báo được tạo.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// ExpiresAt
        /// Thời điểm UTC thông báo hết hiệu lực; rỗng nghĩa là không tự hết hạn.
        /// </summary>
        public DateTime? ExpiresAt
        {
            get { return dtmExpiresAt; }
            set { dtmExpiresAt = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_NotificationID.ToUpper()) && !Convert.IsDBNull(reader[C_NotificationID])) this.lngNotificationID = Convert.ToInt64(reader[C_NotificationID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RecipientUserID.ToUpper()) && !Convert.IsDBNull(reader[C_RecipientUserID])) this.lngRecipientUserID = Convert.ToInt64(reader[C_RecipientUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ActorUserID.ToUpper()) && !Convert.IsDBNull(reader[C_ActorUserID])) this.lngActorUserID = Convert.ToInt64(reader[C_ActorUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_NotificationType.ToUpper()) && !Convert.IsDBNull(reader[C_NotificationType])) this.strNotificationType = Convert.ToString(reader[C_NotificationType]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_Message.ToUpper()) && !Convert.IsDBNull(reader[C_Message])) this.strMessage = Convert.ToString(reader[C_Message]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReferenceType.ToUpper()) && !Convert.IsDBNull(reader[C_ReferenceType])) this.strReferenceType = Convert.ToString(reader[C_ReferenceType]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReferenceID.ToUpper()) && !Convert.IsDBNull(reader[C_ReferenceID])) this.lngReferenceID = Convert.ToInt64(reader[C_ReferenceID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ActionUrl.ToUpper()) && !Convert.IsDBNull(reader[C_ActionUrl])) this.strActionUrl = Convert.ToString(reader[C_ActionUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_MetadataJson.ToUpper()) && !Convert.IsDBNull(reader[C_MetadataJson])) this.strMetadataJson = Convert.ToString(reader[C_MetadataJson]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRead.ToUpper()) && !Convert.IsDBNull(reader[C_IsRead])) this.bolIsRead = Convert.ToBoolean(reader[C_IsRead]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReadAt.ToUpper()) && !Convert.IsDBNull(reader[C_ReadAt])) this.dtmReadAt = Convert.ToDateTime(reader[C_ReadAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExpiresAt.ToUpper()) && !Convert.IsDBNull(reader[C_ExpiresAt])) this.dtmExpiresAt = Convert.ToDateTime(reader[C_ExpiresAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_Notifications", objEx);
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
                if (!Convert.IsDBNull(drw[C_NotificationID])) this.lngNotificationID = Convert.ToInt64(drw[C_NotificationID]);
                if (!Convert.IsDBNull(drw[C_RecipientUserID])) this.lngRecipientUserID = Convert.ToInt64(drw[C_RecipientUserID]);
                if (!Convert.IsDBNull(drw[C_ActorUserID])) this.lngActorUserID = Convert.ToInt64(drw[C_ActorUserID]);
                if (!Convert.IsDBNull(drw[C_NotificationType])) this.strNotificationType = Convert.ToString(drw[C_NotificationType]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_Message])) this.strMessage = Convert.ToString(drw[C_Message]);
                if (!Convert.IsDBNull(drw[C_ReferenceType])) this.strReferenceType = Convert.ToString(drw[C_ReferenceType]);
                if (!Convert.IsDBNull(drw[C_ReferenceID])) this.lngReferenceID = Convert.ToInt64(drw[C_ReferenceID]);
                if (!Convert.IsDBNull(drw[C_ActionUrl])) this.strActionUrl = Convert.ToString(drw[C_ActionUrl]);
                if (!Convert.IsDBNull(drw[C_MetadataJson])) this.strMetadataJson = Convert.ToString(drw[C_MetadataJson]);
                if (!Convert.IsDBNull(drw[C_IsRead])) this.bolIsRead = Convert.ToBoolean(drw[C_IsRead]);
                if (!Convert.IsDBNull(drw[C_ReadAt])) this.dtmReadAt = Convert.ToDateTime(drw[C_ReadAt]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_ExpiresAt])) this.dtmExpiresAt = Convert.ToDateTime(drw[C_ExpiresAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_Notifications", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_Notifications_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_NotificationID, this.lngNotificationID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_Notifications", objEx);
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
        /// Store: SYS_Notifications_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_Notifications Get(long lngNotificationID)
        {
            SYS_Notifications obj = new SYS_Notifications();
            if (objIData != null) obj.IDB = objIData;
            obj.NotificationID = lngNotificationID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_Notifications_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_RecipientUserID, this.lngRecipientUserID);
                objIData.AddParameter(P_ActorUserID, this.lngActorUserID);
                objIData.AddParameter(P_NotificationType, this.strNotificationType);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Message, this.strMessage);
                objIData.AddParameter(P_ReferenceType, this.strReferenceType);
                objIData.AddParameter(P_ReferenceID, this.lngReferenceID);
                objIData.AddParameter(P_ActionUrl, this.strActionUrl);
                objIData.AddParameter(P_MetadataJson, this.strMetadataJson);
                objIData.AddParameter(P_IsRead, this.bolIsRead);
                objIData.AddParameter(P_ReadAt, this.dtmReadAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ExpiresAt, this.dtmExpiresAt);
                this.lngNotificationID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_Notifications", objEx);
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
        /// Store: SYS_Notifications_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_NotificationID, this.lngNotificationID);
                objIData.AddParameter(P_RecipientUserID, this.lngRecipientUserID);
                objIData.AddParameter(P_ActorUserID, this.lngActorUserID);
                objIData.AddParameter(P_NotificationType, this.strNotificationType);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Message, this.strMessage);
                objIData.AddParameter(P_ReferenceType, this.strReferenceType);
                objIData.AddParameter(P_ReferenceID, this.lngReferenceID);
                objIData.AddParameter(P_ActionUrl, this.strActionUrl);
                objIData.AddParameter(P_MetadataJson, this.strMetadataJson);
                objIData.AddParameter(P_IsRead, this.bolIsRead);
                objIData.AddParameter(P_ReadAt, this.dtmReadAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ExpiresAt, this.dtmExpiresAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_Notifications", objEx);
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
        /// Store: SYS_Notifications_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_NotificationID, this.lngNotificationID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_Notifications", objEx);
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
        /// Store: SYS_Notifications_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngNotificationID)
        {
            this.lngNotificationID = lngNotificationID;
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

        public SYS_Notifications()
        {
        }
        public SYS_Notifications(long lngNotificationID)
        {
            this.lngNotificationID = lngNotificationID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_Notifications";
        public const string StoreGet = "SYS_Notifications_GET";
        public const string StoreGetAll = "SYS_Notifications_GETALL";
        public const string StoreSearch = "SYS_Notifications_SEARCH";
        public const string StoreAdd = "SYS_Notifications_ADD";
        public const string StoreEdit = "SYS_Notifications_EDIT";
        public const string StoreDelete = "SYS_Notifications_DELETE";

        #region Parameter Names

        public const String P_NotificationID = "@" + C_NotificationID;
        public const String P_RecipientUserID = "@" + C_RecipientUserID;
        public const String P_ActorUserID = "@" + C_ActorUserID;
        public const String P_NotificationType = "@" + C_NotificationType;
        public const String P_Title = "@" + C_Title;
        public const String P_Message = "@" + C_Message;
        public const String P_ReferenceType = "@" + C_ReferenceType;
        public const String P_ReferenceID = "@" + C_ReferenceID;
        public const String P_ActionUrl = "@" + C_ActionUrl;
        public const String P_MetadataJson = "@" + C_MetadataJson;
        public const String P_IsRead = "@" + C_IsRead;
        public const String P_ReadAt = "@" + C_ReadAt;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_ExpiresAt = "@" + C_ExpiresAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_NotificationID = "NotificationID";
        public const String C_RecipientUserID = "RecipientUserID";
        public const String C_ActorUserID = "ActorUserID";
        public const String C_NotificationType = "NotificationType";
        public const String C_Title = "Title";
        public const String C_Message = "Message";
        public const String C_ReferenceType = "ReferenceType";
        public const String C_ReferenceID = "ReferenceID";
        public const String C_ActionUrl = "ActionUrl";
        public const String C_MetadataJson = "MetadataJson";
        public const String C_IsRead = "IsRead";
        public const String C_ReadAt = "ReadAt";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_ExpiresAt = "ExpiresAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
