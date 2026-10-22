using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_VideoAssets. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_VideoAssets
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách video theo người tạo
        /// </summary>
        public DataTable GetByCreator(long creatorID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@CreatorID", creatorID);
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
        /// Lấy video chi tiết với các phiên bản
        /// </summary>
        public DataTable GetWithVersions(long videoID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_VideoAssets_GetWithVersions");
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

        #endregion
    }
}
