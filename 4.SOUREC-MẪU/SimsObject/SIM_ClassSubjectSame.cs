
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
	public partial class SIM_ClassSubjectSame
	{
        ///<summary>
        /// Add : SIM_ClassSubjectSame
        /// Thêm dữ liệu: Nếu trùng nghề, khóa, bậc, loại, mã nhóm: thì ko làm gì
        /// Store: SIM_ClassSubjectSame_AddOrEdit
        ///</summary>
        public bool AddOrEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ClassSubjectSame_AddOrEdit");
                objIData.AddParameter(P_ClassSubjectSameCode, this.strClassSubjectSameCode);
                objIData.AddParameter(P_ClassSubjectSameName, this.strClassSubjectSameName);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_RequestUnitText, this.intRequestUnitText);
                objIData.AddParameter(P_RequestSubjectCount, this.intRequestSubjectCount);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngClassSubjectSameID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassSubjectSame", objEx);
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
