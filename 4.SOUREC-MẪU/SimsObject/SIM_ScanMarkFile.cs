
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
	/// Created by 		: NGUYỄN VĂN VIỆT 
	/// Created date 	: 5/12/2012 
	/// Description 
	/// </summary>	
    public partial class SIM_ScanMarkFile
	{	
		
		#region Methods	
		
        ///<summary>
        /// Delete : SIM_ScanMarkDetail
        /// Xóa dữ liệu
        /// Store: SIM_ScanMarkDetail_DELETE 
        ///</summary>
        public bool DeleteAll()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_DeleteAll");
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanMarkFile", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool DeleteList(string listID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_DeleteList");
                objIData.AddParameter("@ListID", listID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanMarkFile", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        /// Update : SIM_ScanMarkFile
        /// Đã cập nhật dữ liệu điểm vào sổ điểm
        /// Store: [SIM_ScanMarkFile_SetUpdated] 
        ///</summary>
        public bool SetUpdated()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkFile_SetUpdated");
                objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
                objIData.AddParameter(P_IsUpdated, this.bolIsUpdated);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanMarkFile", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

		#endregion
	
	}
}
