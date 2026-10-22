using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_AuditLogs. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_AuditLogs
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy nhật ký hoạt động theo người dùng
        /// </summary>
        public DataTable GetByUser(long userID, DateTime? fromDate = null, DateTime? toDate = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@UserID", userID);
                if (fromDate.HasValue) objIData.AddParameter("@FromDate", fromDate.Value);
                if (toDate.HasValue) objIData.AddParameter("@ToDate", toDate.Value);
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
        /// Lấy nhật ký theo loại hành động
        /// </summary>
        public DataTable GetByAction(string actionType)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_AuditLogs_GetByAction");
                objIData.AddParameter("@ActionType", actionType);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion
    }
}
