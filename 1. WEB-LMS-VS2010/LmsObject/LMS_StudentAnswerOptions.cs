using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_StudentAnswerOptions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_StudentAnswerOptions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy các option được chọn của câu trả lời học viên
        /// </summary>
        public DataTable GetByStudentAnswer(long studentAnswerID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@StudentAnswerID", studentAnswerID);
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
        /// Xóa các option theo câu trả lời học viên
        /// </summary>
        public bool DeleteByStudentAnswer(long studentAnswerID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudentAnswerOptions_DeleteByAnswer");
                objIData.AddParameter("@StudentAnswerID", studentAnswerID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_StudentAnswerOptions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_StudentAnswerOptions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load StudentAnswerOption theo ID
        /// </summary>
        public static LMS_StudentAnswerOptions LoadById(long answerOptionId)
        {
            LMS_StudentAnswerOptions answerOption = new LMS_StudentAnswerOptions();
            if (answerOption.Get(answerOptionId))
            {
                return answerOption;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách StudentAnswerOption theo StudentAnswerID
        /// </summary>
        public static List<LMS_StudentAnswerOptions> LoadByStudentAnswer(long studentAnswerId)
        {
            LMS_StudentAnswerOptions answerOption = new LMS_StudentAnswerOptions();
            DataTable dt = answerOption.GetByStudentAnswer(studentAnswerId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả StudentAnswerOptions
        /// </summary>
        public static List<LMS_StudentAnswerOptions> LoadAll()
        {
            LMS_StudentAnswerOptions answerOption = new LMS_StudentAnswerOptions();
            DataTable dt = answerOption.GetDataTable(answerOption.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm StudentAnswerOption với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_StudentAnswerOptions> Search(string condition)
        {
            LMS_StudentAnswerOptions answerOption = new LMS_StudentAnswerOptions();
            DataTable dt = answerOption.GetDataTable(answerOption.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(AnswerOptionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_StudentAnswerOptions CreateFromDataReader(IDataReader reader)
        {
            LMS_StudentAnswerOptions answerOption = new LMS_StudentAnswerOptions();
            answerOption.LoadFromDataReader(reader);
            return answerOption;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_StudentAnswerOptions CreateFromDataRow(DataRow row)
        {
            LMS_StudentAnswerOptions answerOption = new LMS_StudentAnswerOptions();
            answerOption.LoadFromDataRow(row);
            return answerOption;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_StudentAnswerOptions> FromDataTable(DataTable dt)
        {
            List<LMS_StudentAnswerOptions> list = new List<LMS_StudentAnswerOptions>();
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
