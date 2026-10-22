using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Videos. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Videos
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy video theo VideoAssetId
        /// </summary>
        public DataTable GetByAssetId(string assetId)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@VideoAssetId", assetId);
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
        /// Lấy danh sách video theo trạng thái
        /// </summary>
        public DataTable GetByStatus(string status)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Videos_GetByStatus");
                objIData.AddParameter("@Status", status);
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
        /// Cập nhật phiên video hiện tại
        /// </summary>
        public bool UpdateCurrentVersion(long videoID, string versionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Videos_UpdateCurrentVersion");
                objIData.AddParameter("@VideoID", videoID);
                objIData.AddParameter("@CurrentVideoVersionID", versionID);
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

        /// <summary>
        /// Lấy danh sách tương tác của video
        /// </summary>
        public DataTable GetInteractions(long videoId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("InteractionList");
                objIData.AddParameter("@VideoId", videoId);
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
        /// Cập nhật tương tác video
        /// </summary>
        public bool UpdateInteraction(
            long videoId,
            long interactionId,
            int offsetSeconds,
            string type,
            string dataJson,
            long actorId,
            bool isAdmin,
            string updatedUser = null
        )
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("InteractionUpdate");
                objIData.AddParameter("@VideoId", videoId);
                objIData.AddParameter("@Id", interactionId);
                objIData.AddParameter("@OffsetSeconds", offsetSeconds);
                objIData.AddParameter("@Type", type);
                objIData.AddParameter("@DataJson", dataJson);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
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

        /// <summary>
        /// Xóa tương tác video
        /// </summary>
        public bool DeleteInteraction(long videoId, long interactionId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("InteractionDelete");
                objIData.AddParameter("@VideoId", videoId);
                objIData.AddParameter("@Id", interactionId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
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

        /// <summary>
        /// Tạo tương tác video mới
        /// </summary>
        public DataTable CreateInteraction(
            long videoId,
            long questionId,
            int offsetSeconds,
            string type,
            string dataJson,
            long actorId,
            bool isAdmin,
            string createdUser = null
        )
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("InteractionCreate");
                objIData.AddParameter("@VideoId", videoId);
                objIData.AddParameter("@QuestionId", questionId);
                objIData.AddParameter("@TimeSeconds", offsetSeconds);
                objIData.AddParameter("@InteractionType", type);
                objIData.AddParameter("@DataJson", dataJson);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@CreatedUser", createdUser);
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
        /// Cập nhật thông tin phiên bản video
        /// </summary>
        public DataTable UpdateVideoVersion(DataRow values)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoVersionUpdate");
                if (values.Table.Columns.Contains("VideoVersionID"))
                    objIData.AddParameter("@VideoVersionID", values["VideoVersionID"]);
                if (values.Table.Columns.Contains("VideoID"))
                    objIData.AddParameter("@VideoID", values["VideoID"]);
                if (values.Table.Columns.Contains("VideoAssetID"))
                    objIData.AddParameter("@VideoAssetID", values["VideoAssetID"]);
                if (values.Table.Columns.Contains("VideoAssetVersionID"))
                    objIData.AddParameter("@VideoAssetVersionID", values["VideoAssetVersionID"]);
                if (values.Table.Columns.Contains("VersionNumber"))
                    objIData.AddParameter("@VersionNumber", values["VersionNumber"]);
                if (values.Table.Columns.Contains("Title"))
                    objIData.AddParameter("@Title", values["Title"]);
                if (values.Table.Columns.Contains("Description"))
                    objIData.AddParameter("@Description", values["Description"]);
                if (values.Table.Columns.Contains("DurationSeconds"))
                    objIData.AddParameter("@DurationSeconds", values["DurationSeconds"]);
                if (values.Table.Columns.Contains("ActorUserID"))
                    objIData.AddParameter("@ActorUserID", values["ActorUserID"]);
                if (values.Table.Columns.Contains("IsAdmin"))
                    objIData.AddParameter("@IsAdmin", values["IsAdmin"]);
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
        /// Tạo phiên bản video mới
        /// </summary>
        public DataTable CreateVideoVersion(DataRow values)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoVersionCreate");
                if (values.Table.Columns.Contains("VideoID"))
                    objIData.AddParameter("@VideoID", values["VideoID"]);
                if (values.Table.Columns.Contains("VideoAssetID"))
                    objIData.AddParameter("@VideoAssetID", values["VideoAssetID"]);
                if (values.Table.Columns.Contains("VideoAssetVersionID"))
                    objIData.AddParameter("@VideoAssetVersionID", values["VideoAssetVersionID"]);
                if (values.Table.Columns.Contains("VersionNumber"))
                    objIData.AddParameter("@VersionNumber", values["VersionNumber"]);
                if (values.Table.Columns.Contains("Title"))
                    objIData.AddParameter("@Title", values["Title"]);
                if (values.Table.Columns.Contains("Description"))
                    objIData.AddParameter("@Description", values["Description"]);
                if (values.Table.Columns.Contains("DurationSeconds"))
                    objIData.AddParameter("@DurationSeconds", values["DurationSeconds"]);
                if (values.Table.Columns.Contains("ActorUserID"))
                    objIData.AddParameter("@ActorUserID", values["ActorUserID"]);
                if (values.Table.Columns.Contains("IsAdmin"))
                    objIData.AddParameter("@IsAdmin", values["IsAdmin"]);
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
        /// Xóa phiên bản video
        /// </summary>
        public DataTable DeleteVideoVersion(long videoVersionId, long actorUserId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoVersionDelete");
                objIData.AddParameter("@VideoVersionID", videoVersionId);
                objIData.AddParameter("@ActorUserID", actorUserId);
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
        /// Lấy danh sách phiên bản của video
        /// </summary>
        public DataTable GetVideoVersions(long videoId)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Videos_GetVersions");
                objIData.AddParameter("@VideoID", videoId);
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
        public DataTable UpdateVideo(long id, long lessonId, string title, string sourceType, string videoUrl, string posterUrl, int durationSeconds, bool allowSeek, bool allowSpeed, decimal requiredWatchPercent, string status, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoUpdate");
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@LessonId", lessonId);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@SourceType", sourceType);
                objIData.AddParameter("@VideoUrl", videoUrl);
                objIData.AddParameter("@PosterUrl", posterUrl);
                objIData.AddParameter("@DurationSeconds", durationSeconds);
                objIData.AddParameter("@AllowSeek", allowSeek);
                objIData.AddParameter("@AllowSpeed", allowSpeed);
                objIData.AddParameter("@RequiredWatchPercent", requiredWatchPercent);
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
        /// Nhân bản video từ tài nguyên
        /// </summary>
        public DataTable DuplicateVideo(long assetId, string title, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoLibraryDuplicate");
                objIData.AddParameter("@Id", assetId);
                objIData.AddParameter("@Title", title);
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
        /// Lấy danh sách video assets cho picker
        /// </summary>
        public DataTable GetVideoLibraryList(string search, string access, string source, string usage, string status, long actorId, bool isAdmin)
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
        /// Gắn video vào bài học
        /// </summary>
        public DataTable AttachVideoToLesson(long lessonId, long videoId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("VideoAttach");
                objIData.AddParameter("@LessonId", lessonId);
                objIData.AddParameter("@VideoId", videoId);
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
