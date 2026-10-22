
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
	/// Created date 	: 10/24/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_SubjectChecking
	{	
		
		 	
        // Thong ke so tiet vang theo mon hoc cua sinh vien
        public DataTable SearchSubjectChecking(long? classSubjectID)
        {
            return GetDataTable("[SIM_SubjectCheckingStatistic]", "@ClassSubjectID", classSubjectID);
        }

        public bool Update(string storeName)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(P_SubjectCheckingID, this.lngSubjectCheckingID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Session, this.intSession);
                objIData.AddParameter(P_PermissionQuantity, this.decPermissionQuantity);
                objIData.AddParameter(P_NoPermissionQuantity, this.decNoPermissionQuantity);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SubjectChecking", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }
	
	}
}
