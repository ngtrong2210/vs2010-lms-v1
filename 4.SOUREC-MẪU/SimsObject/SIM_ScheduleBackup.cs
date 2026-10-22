
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
	/// Created date 	: 12/15/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_ScheduleBackup
	{	
		
		#region Methods	
		
        ///<summary>
        /// Add : SIM_ScheduleBackupDetail
        /// Thêm dữ liệu lịch chi tiết cho backup
        /// Store: SIM_ScheduleBackup_AddDetail
        ///</summary>
        public long AddDetail()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleBackup_AddDetail");
                objIData.AddParameter(P_BackupID, this.lngBackupID);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_BranchID, this.strBranchID);
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_TrainingType, this.strTrainingType);
                objIData.AddParameter(P_ClassID, this.strClassID);
                return Convert.ToInt64(objIData.ExecStoreToString());                
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi backup thông tin lịch SIM_ScheduleBackupDetail", objEx);
                this.objErrorException = objEx;
                return -1;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        /// Add : SIM_ScheduleBackupDetail
        /// Phục hồi dữ liệu lịch học
        /// Store: SIM_ScheduleBackup_Restore
        ///</summary>
        public long Restore()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScheduleBackup_Restore");
                objIData.AddParameter(P_BackupID, this.lngBackupID);
                return Convert.ToInt64(objIData.ExecStoreToString());
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi restore thông tin lịch SIM_ScheduleBackupDetail", objEx);
                this.objErrorException = objEx;
                return -1;
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
