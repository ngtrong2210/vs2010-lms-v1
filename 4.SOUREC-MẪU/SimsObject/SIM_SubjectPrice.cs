
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
	/// Created date 	: 30/07/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_SubjectPrice
	{	
		
		#region Methods	
		
        ///<summary>
        /// Add : SIM_SubjectPrice
        /// Thêm sửa dữ liệu
        /// Store: SIM_SubjectPrice_ADD 
        ///</summary>
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectPrice_AddOrEdit");
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_IsForTechClass, this.bolIsForTechClass);
                objIData.AddParameter(P_TheoryUnitPrice, this.intTheoryUnitPrice);
                objIData.AddParameter(P_PracticeUnitPrice, this.intPracticeUnitPrice);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.intSubjectPriceID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SubjectPrice_AddOrEdit", objEx);
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
