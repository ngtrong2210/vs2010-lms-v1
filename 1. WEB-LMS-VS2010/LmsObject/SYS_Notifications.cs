using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_Notifications. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_Notifications
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy thông báo theo người dùng
        /// </summary>
        public DataTable GetByUser(long userID, bool? isRead = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@UserID", userID);
                if (isRead.HasValue) objIData.AddParameter("@IsRead", isRead.Value);
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
        /// Đánh dấu thông báo đã đọc
        /// </summary>
        public bool MarkAsRead(long notificationID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_Notifications_MarkAsRead");
                objIData.AddParameter("@NotificationID", notificationID);
                objIData.ExecStoreToDataTable();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion
    }
}
