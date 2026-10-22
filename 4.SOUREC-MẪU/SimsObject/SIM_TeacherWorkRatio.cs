
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
	public partial class SIM_TeacherWorkRatio
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
                objIData.CreateNewStoredProcedure("SIM_TeacherWorkRatio_AddOrEdit");
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherWorkID, this.intTeacherWorkID);
                objIData.AddParameter(P_Ratio, this.decRatio);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                this.lngTeacherWorkRatioID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TeacherWorkRatio_AddOrEdit", objEx);
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
