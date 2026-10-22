
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
    /// Created date 	: 04/07/2019 
    /// Description 
    /// </summary>	
    public partial class SIM_ReviewContinueLearning
    {

        #region Methods

        ///<summary>
        /// Add or Update : SIM_ReviewContinueLearning
        /// Thêm or Cập nhật dữ liệu: phân biệt = kì
        /// Store: SIM_ReviewContinueLearning_AddOrUpdate 
        ///</summary>
        public bool AddOrUpdate()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ReviewContinueLearning_AddOrUpdate");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_Summary, this.dblSummary);
                objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
                objIData.AddParameter(P_Result, this.intResult);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryLearningMark", objEx);
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


