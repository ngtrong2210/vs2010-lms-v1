using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_ContentInteractions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_ContentInteractions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy tương tác của học viên với nội dung
        /// </summary>
        public DataTable GetByUserContent(long userID, long contentID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@ContentID", contentID);
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
        /// Lấy thống kê tương tác của nội dung
        /// </summary>
        public DataTable GetContentStats(long contentID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_ContentInteractions_GetStats");
                objIData.AddParameter("@ContentID", contentID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_ContentInteractions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_ContentInteractions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load ContentInteraction theo ID
        /// </summary>
        public static LMS_ContentInteractions LoadById(long interactionId)
        {
            LMS_ContentInteractions interaction = new LMS_ContentInteractions();
            if (interaction.Get(interactionId))
            {
                return interaction;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách ContentInteraction theo UserID và ContentID
        /// </summary>
        public static List<LMS_ContentInteractions> LoadByUserContent(long userId, long contentId)
        {
            LMS_ContentInteractions interaction = new LMS_ContentInteractions();
            DataTable dt = interaction.GetByUserContent(userId, contentId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả ContentInteractions
        /// </summary>
        public static List<LMS_ContentInteractions> LoadAll()
        {
            LMS_ContentInteractions interaction = new LMS_ContentInteractions();
            DataTable dt = interaction.GetDataTable(interaction.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm ContentInteraction với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_ContentInteractions> Search(string condition)
        {
            LMS_ContentInteractions interaction = new LMS_ContentInteractions();
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
        public static LMS_ContentInteractions CreateFromDataReader(IDataReader reader)
        {
            LMS_ContentInteractions interaction = new LMS_ContentInteractions();
            interaction.LoadFromDataReader(reader);
            return interaction;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_ContentInteractions CreateFromDataRow(DataRow row)
        {
            LMS_ContentInteractions interaction = new LMS_ContentInteractions();
            interaction.LoadFromDataRow(row);
            return interaction;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_ContentInteractions> FromDataTable(DataTable dt)
        {
            List<LMS_ContentInteractions> list = new List<LMS_ContentInteractions>();
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
