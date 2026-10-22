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
    }
}
