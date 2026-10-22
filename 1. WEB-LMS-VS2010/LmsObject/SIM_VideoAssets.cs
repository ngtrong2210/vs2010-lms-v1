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

        /// <summary>
        /// Lấy danh sách video thư viện theo điều kiện lọc
        /// </summary>
        public DataTable GetLibraryList(string search, string access, string source, string usage, string status, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoLibraryList");
                objIData.AddParameter("@Search", search);
                objIData.AddParameter("@Access", access);
                objIData.AddParameter("@Source", source);
                objIData.AddParameter("@Usage", usage);
                objIData.AddParameter("@Status", status);
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
        /// Cập nhật thông tin video
        /// </summary>
        public DataTable Update(long assetId, string title, int durationSeconds, string videoUrl, string originalFileName, string mimeType, long fileSize, string status, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoUpdate");
                objIData.AddParameter("@AssetId", assetId);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@DurationSeconds", durationSeconds);
                objIData.AddParameter("@VideoUrl", videoUrl);
                objIData.AddParameter("@OriginalFileName", originalFileName);
                objIData.AddParameter("@MimeType", mimeType);
                objIData.AddParameter("@FileSize", fileSize);
                objIData.AddParameter("@Status", status);
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

        /// <summary>
        /// Tạo video mới
        /// </summary>
        public DataTable Create(string title, int durationSeconds, string videoUrl, string originalFileName, string mimeType, long fileSize, string status, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoCreate");
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@DurationSeconds", durationSeconds);
                objIData.AddParameter("@VideoUrl", videoUrl);
                objIData.AddParameter("@OriginalFileName", originalFileName);
                objIData.AddParameter("@MimeType", mimeType);
                objIData.AddParameter("@FileSize", fileSize);
                objIData.AddParameter("@Status", status);
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

        /// <summary>
        /// Xóa video
        /// </summary>
        public bool Delete(long assetId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoDelete");
                objIData.AddParameter("@AssetId", assetId);
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
        /// Lấy danh sách chia sẻ video
        /// </summary>
        public DataTable GetSharingList(long assetId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoShareGet");
                objIData.AddParameter("@AssetId", assetId);
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
        public bool UpdateSharing(long assetId, string shareScope, string selectedTeachers, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoShareUpdate");
                objIData.AddParameter("@AssetId", assetId);
                objIData.AddParameter("@ShareScope", shareScope);
                objIData.AddParameter("@SelectedTeachers", selectedTeachers);
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
        /// Nhân bản video
        /// </summary>
        public DataTable Duplicate(long assetId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoDuplicate");
                objIData.AddParameter("@AssetId", assetId);
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

        /// <summary>
        /// Lấy cấu hình chia sẻ video
        /// </summary>
        public DataSet GetSharing(long assetId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoSharingGet");
                objIData.AddParameter("@Id", assetId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataSet();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy thông tin video chi tiết
        /// </summary>
        public DataTable Get(long videoId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoGet");
                objIData.AddParameter("@Id", videoId);
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

        #endregion
    }
}
