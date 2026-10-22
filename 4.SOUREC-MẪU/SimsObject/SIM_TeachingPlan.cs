
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
	/// Created date 	: 07/08/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_TeachingPlan
	{	
		
		#region Methods	
		
				
        /// <summary>
        /// Xóa danh sách mã. Danh sách mã theo chuẩn de dung like
        /// [SIM_Schedule_DeleteList]
        /// </summary>
        /// <param name="listID">,12,5,35,5,</param>
        /// <returns></returns>
        public bool DeleteList(string listTeacherID, int yearID, int semester)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TeachingPlan_DeleteList");
                objIData.AddParameter(P_YearID, yearID);
                objIData.AddParameter(P_Semester, semester);
                objIData.AddParameter("@ListTeacherID", listTeacherID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TeachingPlan", objEx);
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
