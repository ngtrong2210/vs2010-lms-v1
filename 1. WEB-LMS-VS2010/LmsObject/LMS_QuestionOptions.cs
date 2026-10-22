using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_QuestionOptions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_QuestionOptions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách options của câu hỏi
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
        /// Xóa tất cả options của câu hỏi
        /// </summary>
        public bool DeleteByQuestion(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuestionOptions_DeleteByQuestion");
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_QuestionOptions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_QuestionOptions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load QuestionOption theo ID
        /// </summary>
        public static LMS_QuestionOptions LoadById(long optionId)
        {
            LMS_QuestionOptions option = new LMS_QuestionOptions();
            if (option.Get(optionId))
            {
                return option;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách QuestionOption theo QuestionID
        /// </summary>
        public static List<LMS_QuestionOptions> LoadByQuestion(long questionId)
        {
            LMS_QuestionOptions option = new LMS_QuestionOptions();
            DataTable dt = option.GetByQuestion(questionId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả QuestionOptions
        /// </summary>
        public static List<LMS_QuestionOptions> LoadAll()
        {
            LMS_QuestionOptions option = new LMS_QuestionOptions();
            DataTable dt = option.GetDataTable(option.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm QuestionOption với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_QuestionOptions> Search(string condition)
        {
            LMS_QuestionOptions option = new LMS_QuestionOptions();
            DataTable dt = option.GetDataTable(option.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(OptionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_QuestionOptions CreateFromDataReader(IDataReader reader)
        {
            LMS_QuestionOptions option = new LMS_QuestionOptions();
            option.LoadFromDataReader(reader);
            return option;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_QuestionOptions CreateFromDataRow(DataRow row)
        {
            LMS_QuestionOptions option = new LMS_QuestionOptions();
            option.LoadFromDataRow(row);
            return option;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_QuestionOptions> FromDataTable(DataTable dt)
        {
            List<LMS_QuestionOptions> list = new List<LMS_QuestionOptions>();
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
