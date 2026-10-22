
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
	/// Created date 	: 5/29/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_GraduationResult_Subject
	{	
		
		#region Methods	
		
				
        ///<summary>
        /// Add : SIM_GraduationResult_Subject
        /// Thêm dữ liệu
        /// Store: SIM_GraduationResult_Subject_ADD 
        ///</summary>
        public bool AddOrEdit(bool check, long? classSubjectID, string createdUser)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_Subject_AddOrEdit");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);                
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter("@ClassSubjectID", classSubjectID);
                objIData.AddParameter("@Checked", check);
                objIData.AddParameter("@CreatedUser", createdUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_GraduationResult_Subject", objEx);
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
