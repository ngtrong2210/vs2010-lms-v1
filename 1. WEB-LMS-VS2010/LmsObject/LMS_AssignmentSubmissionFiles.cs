using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_AssignmentSubmissionFiles. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_AssignmentSubmissionFiles
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách file theo bài nộp
        /// </summary>
        public DataTable GetBySubmission(long submissionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@SubmissionID", submissionID);
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
        /// Xóa tất cả file của bài nộp
        /// </summary>
        public bool DeleteBySubmission(long submissionID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_AssignmentSubmissionFiles_DeleteBySubmission");
                objIData.AddParameter("@SubmissionID", submissionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_AssignmentSubmissionFiles", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_AssignmentSubmissionFiles", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load AssignmentSubmissionFile theo ID
        /// </summary>
        public static LMS_AssignmentSubmissionFiles LoadById(long fileId)
        {
            LMS_AssignmentSubmissionFiles file = new LMS_AssignmentSubmissionFiles();
            if (file.Get(fileId))
            {
                return file;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách AssignmentSubmissionFile theo SubmissionID
        /// </summary>
        public static List<LMS_AssignmentSubmissionFiles> LoadBySubmission(long submissionId)
        {
            LMS_AssignmentSubmissionFiles file = new LMS_AssignmentSubmissionFiles();
            DataTable dt = file.GetBySubmission(submissionId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả AssignmentSubmissionFiles
        /// </summary>
        public static List<LMS_AssignmentSubmissionFiles> LoadAll()
        {
            LMS_AssignmentSubmissionFiles file = new LMS_AssignmentSubmissionFiles();
            DataTable dt = file.GetDataTable(file.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm AssignmentSubmissionFile với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_AssignmentSubmissionFiles> Search(string condition)
        {
            LMS_AssignmentSubmissionFiles file = new LMS_AssignmentSubmissionFiles();
            DataTable dt = file.GetDataTable(file.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(FileID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_AssignmentSubmissionFiles CreateFromDataReader(IDataReader reader)
        {
            LMS_AssignmentSubmissionFiles file = new LMS_AssignmentSubmissionFiles();
            file.LoadFromDataReader(reader);
            return file;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_AssignmentSubmissionFiles CreateFromDataRow(DataRow row)
        {
            LMS_AssignmentSubmissionFiles file = new LMS_AssignmentSubmissionFiles();
            file.LoadFromDataRow(row);
            return file;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_AssignmentSubmissionFiles> FromDataTable(DataTable dt)
        {
            List<LMS_AssignmentSubmissionFiles> list = new List<LMS_AssignmentSubmissionFiles>();
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
