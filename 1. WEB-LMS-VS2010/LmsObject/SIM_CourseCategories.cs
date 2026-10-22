using System;
using System.Data;
using DCore;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_CourseCategories. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_CourseCategories
    {
        public DataTable Search(string condition)
        {
            return GetDataTable("SIM_CourseCategories_SEARCH", "@Condition", condition);
        }

        public DataTable SearchCBX()
        {
            return GetDataTable("SIM_CourseCategories_SEARCHCBX");
        }

        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_CourseCategories_UpdateStatus");
                objIData.AddParameter(P_CourseCategoryID, this.lngCourseCategoryID);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật trạng thái danh mục", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public DataTable GetActiveCategories()
        {
            return GetDataTable("SIM_CourseCategories_GetActive");
        }
    }
}
