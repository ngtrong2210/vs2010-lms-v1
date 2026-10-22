using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_QuestionAnswerKeys. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_QuestionAnswerKeys
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy answer key của câu hỏi
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
        /// Xóa answer key của câu hỏi
        /// </summary>
        public bool DeleteByQuestion(long questionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_QuestionAnswerKeys_DeleteByQuestion");
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_QuestionAnswerKeys", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_QuestionAnswerKeys", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load QuestionAnswerKey theo ID
        /// </summary>
        public static LMS_QuestionAnswerKeys LoadById(long answerKeyId)
        {
            LMS_QuestionAnswerKeys answerKey = new LMS_QuestionAnswerKeys();
            if (answerKey.Get(answerKeyId))
            {
                return answerKey;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách QuestionAnswerKey theo QuestionID
        /// </summary>
        public static List<LMS_QuestionAnswerKeys> LoadByQuestion(long questionId)
        {
            LMS_QuestionAnswerKeys answerKey = new LMS_QuestionAnswerKeys();
            DataTable dt = answerKey.GetByQuestion(questionId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả QuestionAnswerKeys
        /// </summary>
        public static List<LMS_QuestionAnswerKeys> LoadAll()
        {
            LMS_QuestionAnswerKeys answerKey = new LMS_QuestionAnswerKeys();
            DataTable dt = answerKey.GetDataTable(answerKey.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm QuestionAnswerKey với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_QuestionAnswerKeys> Search(string condition)
        {
            LMS_QuestionAnswerKeys answerKey = new LMS_QuestionAnswerKeys();
            DataTable dt = answerKey.GetDataTable(answerKey.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(AnswerKeyID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_QuestionAnswerKeys CreateFromDataReader(IDataReader reader)
        {
            LMS_QuestionAnswerKeys answerKey = new LMS_QuestionAnswerKeys();
            answerKey.LoadFromDataReader(reader);
            return answerKey;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_QuestionAnswerKeys CreateFromDataRow(DataRow row)
        {
            LMS_QuestionAnswerKeys answerKey = new LMS_QuestionAnswerKeys();
            answerKey.LoadFromDataRow(row);
            return answerKey;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_QuestionAnswerKeys> FromDataTable(DataTable dt)
        {
            List<LMS_QuestionAnswerKeys> list = new List<LMS_QuestionAnswerKeys>();
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
