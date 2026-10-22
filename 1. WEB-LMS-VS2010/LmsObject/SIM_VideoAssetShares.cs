using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_VideoAssetShares. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_VideoAssetShares
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách chia sẻ theo video
        /// </summary>
        public DataTable GetByVideo(long videoID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@VideoID", videoID);
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
        /// Lấy danh sách chia sẻ theo người nhận
        /// </summary>
        public DataTable GetByRecipient(long recipientID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_VideoAssetShares_GetByRecipient");
                objIData.AddParameter("@RecipientID", recipientID);
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
