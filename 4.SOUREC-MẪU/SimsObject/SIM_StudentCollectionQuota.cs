
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
	/// Created date 	: 7/14/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_StudentCollectionQuota
	{	
		
		#region Methods	
		
				       
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollectionQuota_AddOrEdit");
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Quota, this.intQuota);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_StudentCollectionQuota_AddOrEdit", objEx);
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
