
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
	/// Created date 	: 24/03/2023
	/// Description 
	/// </summary>	
    public partial class SIM_ClassSubjectInfo
	{	
		
		#region Methods	
		
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ClassSubjectInfo_AddOrEdit");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_KnowledgeTarget, this.strKnowledgeTarget);
                objIData.AddParameter(P_SkillTarget, this.strSkillTarget);
                objIData.AddParameter(P_AttitudeTarget, this.strAttitudeTarget);
                objIData.AddParameter(P_ContentFile, this.strContentFile);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassSubjectInfo", objEx);
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
