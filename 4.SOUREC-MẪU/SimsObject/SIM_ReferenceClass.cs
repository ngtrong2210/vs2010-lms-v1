
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
	/// Created date 	: 29/08/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_ReferenceClass
	{	
		
		#region Methods		        

        ///<summary>
        /// Delete : SIM_ReferenceClass
        /// Xóa dữ liệu
        /// Store: SIM_ReferenceClass_DELETE 
        ///</summary>
        public bool Delete(object yearID, object semester)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ReferenceClass_DeleteList");
                objIData.AddParameter("@YearID", yearID);
                objIData.AddParameter("@Semester", semester);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa hết thông tin SIM_ReferenceClass", objEx);
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
        /// Add kiểu ds cho nhanh hơn
        /// </summary>
        /// <param name="referenceClassIDList">ds lớp liên quan, cách nhau dấu ;</param>
        /// <param name="groupSmallClassList">ds nhóm lớp tương ứng cách nhau dấu ;</param>
        /// <returns></returns>
        public bool AddList(string referenceClassIDList, string groupSmallClassList)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ReferenceClass_AddList");
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter("@ReferenceClassIDList",referenceClassIDList);
                objIData.AddParameter("@GroupSmallClassList", groupSmallClassList);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ReferenceClass", objEx);
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
