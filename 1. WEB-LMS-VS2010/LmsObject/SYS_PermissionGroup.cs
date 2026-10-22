using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SYS_PermissionGroup. Generator không ghi đè file này.
    /// </summary>
    public partial class SYS_PermissionGroup
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy nhóm phân quyền theo module
        /// </summary>
        public DataTable GetByModule(string moduleCode)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@ModuleCode", moduleCode);
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
        /// Lấy nhóm phân quyền với danh sách quyền
        /// </summary>
        public DataTable GetWithPermissions(long groupID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SYS_PermissionGroup_GetWithPermissions");
                objIData.AddParameter("@GroupID", groupID);
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
