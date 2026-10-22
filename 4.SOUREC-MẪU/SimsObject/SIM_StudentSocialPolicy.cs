
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
	/// Created date 	: 4/13/2020 
	/// Description 
	/// </summary>	
	public partial class SIM_StudentSocialPolicy
	{	
		
		#region Methods	
		
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentSocialPolicy_AddOrEdit");                
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SocialPolicyID, this.intSocialPolicyID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_PercentValue, this.decPercentValue);
                objIData.AddParameter(P_Month, this.decMonth);
                objIData.AddParameter(P_UnitSalary, this.decUnitSalary);
                objIData.AddParameter(P_Money, this.decMoney);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_Signingdate, this.dtmSigningdate);
                objIData.AddParameter(P_Signer, this.strSigner);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);

                this.lngStudentSocialPolicyID = Convert.ToInt64(objIData.ExecStoreToString());                
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_StudentSocialPolicy_AddOrEdit", objEx);
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
