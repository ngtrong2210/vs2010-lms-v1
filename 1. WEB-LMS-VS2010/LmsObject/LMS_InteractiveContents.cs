using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_InteractiveContents. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_InteractiveContents
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Tìm kiếm InteractiveContent theo LessonID
        /// </summary>
        public DataTable SearchByLessonID(long lessonID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter(P_LessonID, lessonID);
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
        /// Lấy danh sách câu hỏi của InteractiveContent
        /// </summary>
        public DataTable GetQuestions(long interactiveContentID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_InteractiveContents_GetQuestions");
                objIData.AddParameter(P_InteractiveContentID, interactiveContentID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_InteractiveContents", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_InteractiveContents", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load InteractiveContent theo ID
        /// </summary>
        public static LMS_InteractiveContents LoadById(long interactiveContentId)
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            if (content.Get(interactiveContentId))
            {
                return content;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách InteractiveContent theo LessonID
        /// </summary>
        public static List<LMS_InteractiveContents> LoadByLessonId(long lessonId)
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            DataTable dt = content.SearchByLessonID(lessonId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả InteractiveContents
        /// </summary>
        public static List<LMS_InteractiveContents> LoadAll()
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            DataTable dt = content.GetDataTable(content.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm InteractiveContent với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_InteractiveContents> Search(string condition)
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            DataTable dt = content.GetDataTable(content.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(InteractiveContentID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_InteractiveContents CreateFromDataReader(IDataReader reader)
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            content.LoadFromDataReader(reader);
            return content;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_InteractiveContents CreateFromDataRow(DataRow row)
        {
            LMS_InteractiveContents content = new LMS_InteractiveContents();
            content.LoadFromDataRow(row);
            return content;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_InteractiveContents> FromDataTable(DataTable dt)
        {
            List<LMS_InteractiveContents> list = new List<LMS_InteractiveContents>();
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
