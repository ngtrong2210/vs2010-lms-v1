
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
	/// Created date 	: 02/09/2011 
	/// Description 
	/// </summary>	
    public partial class SIM_Scholarship
	{	
		
		#region Methods	
		
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Scholarship_AddOrEdit");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_ScholarshipLevel, this.strScholarshipLevel);
                objIData.AddParameter(P_ScholarshipMonth, this.intScholarshipMonth);
                objIData.AddParameter(P_ScholarshipMoney, this.decScholarshipMoney);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngScholarshipID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Scholarship", objEx);
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
