using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_LessonResources. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_LessonResources
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy tài nguyên theo bài học
        /// </summary>
        public DataTable GetByLesson(long lessonID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@LessonID", lessonID);
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
        /// Xóa tất cả tài nguyên của bài học
        /// </summary>
        public bool DeleteByLesson(long lessonID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_LessonResources_DeleteByLesson");
                objIData.AddParameter("@LessonID", lessonID);
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
    }
}
