using System;
using System.Data;
using DCore;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Chapters. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Chapters
    {
        public DataTable Search(string condition)
        {
            return GetDataTable("SIM_Chapters_SEARCH", "@Condition", condition);
        }

        public DataTable GetByCourse(long courseId)
        {
            return GetDataTable("SIM_Chapters_GetByCourse", "@CourseId", courseId);
        }

        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Chapters_UpdateStatus");
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật trạng thái chương", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool Reorder(int newSortOrder)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Chapters_Reorder");
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
                objIData.AddParameter(P_SortOrder, newSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thứ tự chương", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Xóa chương theo ID (gọi store, có ActorId và IsAdmin)
        /// </summary>
        public bool Delete(long chapterId, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Chapter_Delete");
                objIData.AddParameter("@ChapterId", chapterId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa chương", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Lấy chi tiết chương theo ID (gọi store, có ActorId và IsAdmin)
        /// </summary>
        public DataTable GetById(long chapterId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Chapter_GetById");
                objIData.AddParameter("@Id", chapterId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy chi tiết chương", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Cập nhật chương (gọi store)
        /// </summary>
        public bool Update(long chapterId, string title, string description, int sortOrder, string status, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Chapter_Update");
                objIData.AddParameter("@Id", chapterId);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật chương", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Tạo mới chương (gọi store)
        /// </summary>
        public DataTable Create(long courseId, string title, string description, int sortOrder, string status, long actorId, bool isAdmin, string updatedUser = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_Chapter_Create");
                objIData.AddParameter("@CourseId", courseId);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.AddParameter("@UpdatedUser", updatedUser);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi tạo chương", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }
    }
}
