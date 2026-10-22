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

        /// <summary>
        /// Xóa chia sẻ video
        /// </summary>
        public bool Delete(long shareId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoShareDelete");
                objIData.AddParameter("@ShareId", shareId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy thông tin chia sẻ theo ID
        /// </summary>
        public DataTable GetById(long shareId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoShareGetById");
                objIData.AddParameter("@ShareId", shareId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
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
        /// Cập nhật chia sẻ video
        /// </summary>
        public bool Update(long shareId, long assetId, long recipientId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoShareUpdateItem");
                objIData.AddParameter("@ShareId", shareId);
                objIData.AddParameter("@AssetId", assetId);
                objIData.AddParameter("@RecipientId", recipientId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Tạo chia sẻ video mới
        /// </summary>
        public DataTable Create(long assetId, long recipientId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoShareCreate");
                objIData.AddParameter("@AssetId", assetId);
                objIData.AddParameter("@RecipientId", recipientId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
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
