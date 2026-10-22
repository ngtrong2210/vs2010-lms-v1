using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_Roles. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_Roles
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách role hoạt động
        /// </summary>
        public DataTable GetActiveRoles()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_Roles_GetActive");
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
        /// Lấy role với danh sách quyền
        /// </summary>
        public DataTable GetWithPermissions(long roleID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_Roles_GetWithPermissions");
                objIData.AddParameter("@RoleID", roleID);
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
