using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Student. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Student
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách học viên theo lớp
        /// </summary>
        public DataTable GetByClass(long classID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@ClassID", classID);
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
        /// Lấy học viên theo user
        /// </summary>
        public DataTable GetByUser(long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_GetByUser");
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
        /// Lấy danh sách ghi danh môn học
        /// </summary>
        public DataTable EnrollmentList(int page, int pageSize)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_EnrollmentList");
                objIData.AddParameter("@Page", page);
                objIData.AddParameter("@PageSize", pageSize);
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
        /// Ghi danh học viên vào khóa học
        /// </summary>
        public bool Enroll(long courseId, long studentId, long actorId)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_Enroll");
                objIData.AddParameter("@CourseId", courseId);
                objIData.AddParameter("@StudentId", studentId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Hủy ghi danh học viên
        /// </summary>
        public bool CancelEnrollment(long id, long actorId)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_CancelEnrollment");
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@ActorId", actorId);
                objIData.ExecNonQuery();
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
    }
}
