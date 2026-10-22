using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_PermissionCategory. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_PermissionCategory
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách phân quyền hoạt động
        /// </summary>
        public DataTable GetActiveCategories()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_PermissionCategory_GetActive");
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
        /// Lấy danh sách phân quyền với số quyền
        /// </summary>
        public DataTable GetWithPermissionCount()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_PermissionCategory_GetWithCount");
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion
    }
}
