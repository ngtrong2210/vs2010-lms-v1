
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
	public partial class SIM_SBSSame
	{
        ///<summary>
        /// Add : SIM_SBSSame
        /// Thêm dữ liệu: Nếu trùng nghề, khóa, bậc, loại, mã nhóm: thì ko làm gì
        /// Store: SIM_SBSSame_AddOrEdit
        ///</summary>
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SBSSame_AddOrEdit");
                objIData.AddParameter(P_SBSSameCode, this.strSBSSameCode);
                objIData.AddParameter(P_SBSSameName, this.strSBSSameName);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_TrainingType, this.strTrainingType);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_RequestUnitText, this.intRequestUnitText);
                objIData.AddParameter(P_RequestSubjectCount, this.intRequestSubjectCount);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.intSBSSameID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SBSSame", objEx);
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
