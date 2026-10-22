using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_QuestionBlanks. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_QuestionBlanks
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách chỗ trống của câu hỏi
        /// </summary>
        public DataTable GetByQuestion(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@QuestionID", questionID);
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
        /// Xóa tất cả chỗ trống của câu hỏi
        /// </summary>
        public bool DeleteByQuestion(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuestionBlanks_DeleteByQuestion");
                objIData.AddParameter("@QuestionID", questionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_QuestionBlanks", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_QuestionBlanks", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load QuestionBlank theo ID
        /// </summary>
        public static LMS_QuestionBlanks LoadById(long blankId)
        {
            LMS_QuestionBlanks blank = new LMS_QuestionBlanks();
            if (blank.Get(blankId))
            {
                return blank;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách QuestionBlank theo QuestionID
        /// </summary>
        public static List<LMS_QuestionBlanks> LoadByQuestion(long questionId)
        {
            LMS_QuestionBlanks blank = new LMS_QuestionBlanks();
            DataTable dt = blank.GetByQuestion(questionId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả QuestionBlanks
        /// </summary>
        public static List<LMS_QuestionBlanks> LoadAll()
        {
            LMS_QuestionBlanks blank = new LMS_QuestionBlanks();
            DataTable dt = blank.GetDataTable(blank.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm QuestionBlank với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_QuestionBlanks> Search(string condition)
        {
            LMS_QuestionBlanks blank = new LMS_QuestionBlanks();
            DataTable dt = blank.GetDataTable(blank.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(BlankID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_QuestionBlanks CreateFromDataReader(IDataReader reader)
        {
            LMS_QuestionBlanks blank = new LMS_QuestionBlanks();
            blank.LoadFromDataReader(reader);
            return blank;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_QuestionBlanks CreateFromDataRow(DataRow row)
        {
            LMS_QuestionBlanks blank = new LMS_QuestionBlanks();
            blank.LoadFromDataRow(row);
            return blank;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_QuestionBlanks> FromDataTable(DataTable dt)
        {
            List<LMS_QuestionBlanks> list = new List<LMS_QuestionBlanks>();
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
