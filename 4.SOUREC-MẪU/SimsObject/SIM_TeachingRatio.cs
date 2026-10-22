
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
	/// Created date 	: 11/07/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_TeachingRatio
	{	
		
		#region Methods	
		        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TeachingRatio_AddOrEdit");                
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_TheoryRatio, this.decTheoryRatio);
                objIData.AddParameter(P_PracticeRatio, this.decPracticeRatio);
                objIData.AddParameter(P_Description, this.strDescription);                
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                this.lngTeachingRatioID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TeachingRatio_AddOrEdit", objEx);
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
