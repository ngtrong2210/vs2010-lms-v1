using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_StudentVideoProgress. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_StudentVideoProgress
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy tiến độ video của học viên
        /// </summary>
        public DataTable GetByUserVideo(long userID, long videoID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@UserID", userID);
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
        /// Cập nhật tiến độ xem video
        /// </summary>
        public bool UpdateWatchProgress(long userID, long videoID, int watchedSeconds, decimal watchPercent)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudentVideoProgress_UpdateWatchProgress");
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@VideoID", videoID);
                objIData.AddParameter("@WatchedSeconds", watchedSeconds);
                objIData.AddParameter("@WatchPercent", watchPercent);
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
        /// Đánh dấu video đã xem xong
        /// </summary>
        public bool MarkAsCompleted(long userID, long videoID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudentVideoProgress_MarkCompleted");
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@VideoID", videoID);
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

        #region Enhanced Load Methods

        /// <summary>
        /// Load dữ liệu từ IDataReader vào object hiện tại.
        /// </summary>
        public bool LoadFromDataReader(IDataReader reader)
        {
            try
            {
                return Parse(reader);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_StudentVideoProgress", ex);
                return false;
            }
        }

        /// <summary>
        /// Load dữ liệu từ DataRow vào object hiện tại.
        /// </summary>
        public bool LoadFromDataRow(DataRow row)
        {
            try
            {
                if (row == null) return false;

                // Sử dụng Parse(DataRow) đã có trong Base class
                return Parse(row);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_StudentVideoProgress", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load StudentVideoProgress theo ID
        /// </summary>
        public static LMS_StudentVideoProgress LoadById(long progressId)
        {
            LMS_StudentVideoProgress progress = new LMS_StudentVideoProgress();
            if (progress.Get(progressId))
            {
                return progress;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load StudentVideoProgress theo UserID và VideoID
        /// </summary>
        public static LMS_StudentVideoProgress LoadByUserVideo(long userId, long videoId)
        {
            LMS_StudentVideoProgress progress = new LMS_StudentVideoProgress();
            DataTable dt = progress.GetByUserVideo(userId, videoId);
            if (dt != null && dt.Rows.Count > 0)
            {
                progress.LoadFromDataRow(dt.Rows[0]);
                return progress;
            }
            return null;
        }

        /// <summary>
        /// Static: Load tất cả StudentVideoProgress
        /// </summary>
        public static List<LMS_StudentVideoProgress> LoadAll()
        {
            LMS_StudentVideoProgress progress = new LMS_StudentVideoProgress();
            DataTable dt = progress.GetDataTable(progress.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm StudentVideoProgress với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_StudentVideoProgress> Search(string condition)
        {
            LMS_StudentVideoProgress progress = new LMS_StudentVideoProgress();
            DataTable dt = progress.GetDataTable(progress.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(ProgressID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_StudentVideoProgress CreateFromDataReader(IDataReader reader)
        {
            LMS_StudentVideoProgress progress = new LMS_StudentVideoProgress();
            progress.LoadFromDataReader(reader);
            return progress;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_StudentVideoProgress CreateFromDataRow(DataRow row)
        {
            LMS_StudentVideoProgress progress = new LMS_StudentVideoProgress();
            progress.LoadFromDataRow(row);
            return progress;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_StudentVideoProgress> FromDataTable(DataTable dt)
        {
            List<LMS_StudentVideoProgress> list = new List<LMS_StudentVideoProgress>();
            if (dt == null) return list;

            foreach (DataRow row in dt.Rows)
            {
                list.Add(CreateFromDataRow(row));
            }
            return list;
        }

        #endregion
    }
}
