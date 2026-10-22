using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_AssignmentSubmissions. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_AssignmentSubmissions
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy bài nộp của học viên theo assignment
        /// </summary>
        public DataTable GetByAssignmentUser(long assignmentID, long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@AssignmentID", assignmentID);
                objIData.AddParameter("@UserID", userID);
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
        /// Lấy danh sách bài nộp theo assignment
        /// </summary>
        public DataTable GetByAssignment(long assignmentID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_AssignmentSubmissions_GetByAssignment");
                objIData.AddParameter("@AssignmentID", assignmentID);
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
        /// Chấm điểm bài nộp
        /// </summary>
        public bool GradeSubmission(long submissionID, decimal score, string feedback)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_AssignmentSubmissions_Grade");
                objIData.AddParameter("@SubmissionID", submissionID);
                objIData.AddParameter("@Score", score);
                objIData.AddParameter("@Feedback", feedback);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_AssignmentSubmissions", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_AssignmentSubmissions", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load AssignmentSubmission theo ID
        /// </summary>
        public static LMS_AssignmentSubmissions LoadById(long submissionId)
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            if (submission.Get(submissionId))
            {
                return submission;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách AssignmentSubmission theo AssignmentID
        /// </summary>
        public static List<LMS_AssignmentSubmissions> LoadByAssignment(long assignmentId)
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            DataTable dt = submission.GetByAssignment(assignmentId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load bài nộp của học viên theo assignment
        /// </summary>
        public static LMS_AssignmentSubmissions LoadByAssignmentUser(long assignmentId, long userId)
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            DataTable dt = submission.GetByAssignmentUser(assignmentId, userId);
            if (dt != null && dt.Rows.Count > 0)
            {
                return CreateFromDataRow(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// Static: Load tất cả AssignmentSubmissions
        /// </summary>
        public static List<LMS_AssignmentSubmissions> LoadAll()
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            DataTable dt = submission.GetDataTable(submission.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm AssignmentSubmission với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_AssignmentSubmissions> Search(string condition)
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            DataTable dt = submission.GetDataTable(submission.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(SubmissionID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_AssignmentSubmissions CreateFromDataReader(IDataReader reader)
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            submission.LoadFromDataReader(reader);
            return submission;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_AssignmentSubmissions CreateFromDataRow(DataRow row)
        {
            LMS_AssignmentSubmissions submission = new LMS_AssignmentSubmissions();
            submission.LoadFromDataRow(row);
            return submission;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_AssignmentSubmissions> FromDataTable(DataTable dt)
        {
            List<LMS_AssignmentSubmissions> list = new List<LMS_AssignmentSubmissions>();
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
