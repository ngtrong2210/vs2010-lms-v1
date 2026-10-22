
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
    /// Created date 	: 7/14/2012 
    /// Description 
    /// </summary>	
    public partial class SIM_StudentCollectionPeriod
    {

        #region Methods

        ///<summary>
        /// Delete : SIM_StudentCollectionPeriod
        /// Xóa dữ liệu, tự xóa khóa ngoại isdeleted = 1 trước đẻ không bị vướng
        /// Store: SIM_StudentCollectionPeriod_DELETE2 
        ///</summary>
        public bool Delete2()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_StudentCollectionPeriod_DELETE2");
                objIData.AddParameter(P_StudentCollectionPeriodID, this.strStudentCollectionPeriodID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_StudentCollectionPeriod", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// SIM_StudentCollectionPeriod_GetInfo
        /// Lấy dòng thông tin Đợt tuyển sinh, có mã mới gợi ý để tạo mới NewStudentCollectionID
        /// </summary>
        /// <param name="studentCollectionPeriodID"></param>
        /// <returns></returns>
        public DataTable GetInfo(string studentCollectionPeriodID, string specialBranchID)
        {
            return GetDataTable("[SIM_StudentCollectionPeriod_GetInfo]", "@StudentCollectionPeriodID", studentCollectionPeriodID, "@SpecialBranchID", specialBranchID);
        }

        public DataTable GetInfo(string studentCollectionPeriodID)
        {
            return GetDataTable("[SIM_StudentCollectionPeriod_GetInfo]", "@StudentCollectionPeriodID");
        }

        #endregion

    }
}
