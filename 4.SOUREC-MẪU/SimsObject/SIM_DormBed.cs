
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
	/// Created date 	: 11/11/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_DormBed
	{	
		
		#region Methods	
		
        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Lấy ds giường với thông tin đăng ký sau cùng
        /// [SIM_DormBed_SearchCurrentInfo]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchCurrentInfo(params object[] conditions)
        {
            return GetDataTable("SIM_DormBed_SearchCurrentInfo", conditions);
        }

        ///<summary>
        /// Delete : SIM_DormBed
        /// Xóa dữ liệu, tự xóa khóa ngoại isdeleted = 1 trước đẻ không bị vướng
        /// Store: SIM_DormBed_DELETE2 
        ///</summary>
        public bool Delete2()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_DormBed_DELETE2");
                objIData.AddParameter(P_DormBedID, this.strDormBedID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_DormBed", objEx);
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
