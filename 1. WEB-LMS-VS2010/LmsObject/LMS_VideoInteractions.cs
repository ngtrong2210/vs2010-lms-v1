using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_VideoInteractions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_VideoInteractions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy tương tác của học viên với video
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
        /// Lấy thống kê tương tác của video
        /// </summary>
        public DataTable GetVideoStats(long videoID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_VideoInteractions_GetStats");
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_VideoInteractions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_VideoInteractions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load VideoInteraction theo ID
        /// </summary>
        public static LMS_VideoInteractions LoadById(long interactionId)
        {
            LMS_VideoInteractions interaction = new LMS_VideoInteractions();
            if (interaction.Get(interactionId))
            {
                return interaction;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách VideoInteraction theo UserID và VideoID
        /// </summary>
        public static List<LMS_VideoInteractions> LoadByUserVideo(long userId, long videoId)
        {
            LMS_VideoInteractions interaction = new LMS_VideoInteractions();
            DataTable dt = interaction.GetByUserVideo(userId, videoId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả VideoInteractions
        /// </summary>
        public static List<LMS_VideoInteractions> LoadAll()
        {
            LMS_VideoInteractions interaction = new LMS_VideoInteractions();
            DataTable dt = interaction.GetDataTable(interaction.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm VideoInteraction với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_VideoInteractions> Search(string condition)
        {
            LMS_VideoInteractions interaction = new LMS_VideoInteractions();
            DataTable dt = interaction.GetDataTable(interaction.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(InteractionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_VideoInteractions CreateFromDataReader(IDataReader reader)
        {
            LMS_VideoInteractions interaction = new LMS_VideoInteractions();
            interaction.LoadFromDataReader(reader);
            return interaction;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_VideoInteractions CreateFromDataRow(DataRow row)
        {
            LMS_VideoInteractions interaction = new LMS_VideoInteractions();
            interaction.LoadFromDataRow(row);
            return interaction;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_VideoInteractions> FromDataTable(DataTable dt)
        {
            List<LMS_VideoInteractions> list = new List<LMS_VideoInteractions>();
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
