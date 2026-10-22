
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
	/// Created date 	: 5/12/2011 
	/// Description 
	/// </summary>	
    public partial class SIM_ClassSubjectReport
	{	
		
		#region Methods	
		
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ClassSubjectReport_AddOrEdit");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_GeneralInfo, this.strGeneralInfo);
                objIData.AddParameter(P_TimeInfo, this.strTimeInfo);
                objIData.AddParameter(P_SpecialInfo, this.strSpecialInfo);
                objIData.AddParameter(P_TeachingTime, this.strTeachingTime);
                objIData.AddParameter(P_TeachingContent, this.strTeachingContent);
                objIData.AddParameter(P_TeacherSpecialInfo, this.strTeacherSpecialInfo);
                objIData.AddParameter(P_Suggest, this.strSuggest);
                objIData.AddParameter(P_StudentSpecialInfo, this.strStudentSpecialInfo);
                objIData.AddParameter(P_ContentFile, this.strContentFile);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassSubjectReport", objEx);
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
