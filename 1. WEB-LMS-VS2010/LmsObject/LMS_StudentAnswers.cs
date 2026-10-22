using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_StudentAnswers. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_StudentAnswers
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy câu trả lời của học viên theo attempt
        /// </summary>
        public DataTable GetByAttempt(long attemptID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@AttemptID", attemptID);
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
        /// Tính điểm của lượt làm bài
        /// </summary>
        public decimal CalculateScore(long attemptID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudentAnswers_CalculateScore");
                objIData.AddParameter("@AttemptID", attemptID);
                DataTable dtb = objIData.ExecStoreToDataTable();
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dtb.Rows[0][0]);
                }
                return 0;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return 0;
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_StudentAnswers", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_StudentAnswers", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load StudentAnswer theo ID
        /// </summary>
        public static LMS_StudentAnswers LoadById(long answerId)
        {
            LMS_StudentAnswers answer = new LMS_StudentAnswers();
            if (answer.Get(answerId))
            {
                return answer;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách StudentAnswer theo AttemptID
        /// </summary>
        public static List<LMS_StudentAnswers> LoadByAttempt(long attemptId)
        {
            LMS_StudentAnswers answer = new LMS_StudentAnswers();
            DataTable dt = answer.GetByAttempt(attemptId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả StudentAnswers
        /// </summary>
        public static List<LMS_StudentAnswers> LoadAll()
        {
            LMS_StudentAnswers answer = new LMS_StudentAnswers();
            DataTable dt = answer.GetDataTable(answer.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm StudentAnswer với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_StudentAnswers> Search(string condition)
        {
            LMS_StudentAnswers answer = new LMS_StudentAnswers();
            DataTable dt = answer.GetDataTable(answer.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(AnswerID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_StudentAnswers CreateFromDataReader(IDataReader reader)
        {
            LMS_StudentAnswers answer = new LMS_StudentAnswers();
            answer.LoadFromDataReader(reader);
            return answer;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_StudentAnswers CreateFromDataRow(DataRow row)
        {
            LMS_StudentAnswers answer = new LMS_StudentAnswers();
            answer.LoadFromDataRow(row);
            return answer;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_StudentAnswers> FromDataTable(DataTable dt)
        {
            List<LMS_StudentAnswers> list = new List<LMS_StudentAnswers>();
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
