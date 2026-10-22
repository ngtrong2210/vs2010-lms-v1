
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
    public partial class SIM_ScanMarkDetail
	{	
		
		#region Methods		        

        ///<summary>
        /// Reset : SIM_ScanMarkDetail
        /// Reset dữ liệu scan của một file
        /// Store: SIM_ScanMarkDetail_DELETE 
        ///</summary>
        public bool ResetOfFile(long? scanMarkFileID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkDetail_ResetOfFile");
                objIData.AddParameter("@ScanMarkFileID", scanMarkFileID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi reset thông tin SIM_ScanMarkDetail", objEx);
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
        /// Update : SIM_ScanMarkDetail
        /// Cập nhật dữ liệu scan được vào
        /// Store: SIM_ScanMarkDetail_UpdateMark 
        ///</summary>
        public bool UpdateMark()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkDetail_UpdateMark");                
                objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);                
                objIData.AddParameter(P_Mark, this.dblMark);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanMarkDetail", objEx);
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
