
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
	/// Created date 	: 3/20/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_DateChecking
	{	
		
		#region Methods	
                
        /// <summary>
        /// Thong ke so tiet vang theo ngày sinh vien 
        /// SIM_DateChecking_Statistic
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable DateCheckingStatistic(params object[] conditions)
        {
            return GetDataTable("[SIM_DateChecking_Statistic]", conditions);
        }

        /// <summary>
        /// Thong ke so tiet vang theo ca sinh vien 
        /// SIM_DateChecking_SessionCheckingStatistic
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SessionCheckingStatistic(params object[] conditions)
        {
            return GetDataTable("[SIM_DateChecking_SessionCheckingStatistic]", conditions);
        }
        /// <summary>
        /// [SIM_DateChecking_SearchForSessionChecking]
        /// Tìm điểm danh theo ca để fill vào form
        /// </summary>
        /// <param name="classID"></param>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        public DataTable SearchForSessionChecking(params object[] conditions)
        {
            return GetDataTable("SIM_DateChecking_SearchForSessionChecking", conditions);
        }


        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Data điểm danh ngày từ ngày tới ngày của sinh viên
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForDateCheckingMulti(params object[] conditions)
        {
            return GetDataTable("SIM_DateChecking_SearchForDateCheckingMulti", conditions);
        }

        ///<summary>
        /// Update : [SIM_DateChecking_SessionChecking_Edit]
        /// Thêm hoặc update hoặc xóa điểm danh ca        
        ///</summary>
        public bool SessionCheckingEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_DateChecking_SessionChecking_Edit");                
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Session1, this.strSession1);
                objIData.AddParameter(P_Session2, this.strSession2);
                objIData.AddParameter(P_Session3, this.strSession3);
                objIData.AddParameter(P_Session4, this.strSession4);
                objIData.AddParameter(P_Session5, this.strSession5);
                objIData.AddParameter(P_Session6, this.strSession6); 
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_DateChecking", objEx);
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
        /// Cập nhật điểm danh ngày: từ ngày tới dày
        /// SIM_DateChecking_DateCheckingMulti_Edit
        /// </summary>
        /// <returns></returns>
        public bool DateCheckingMultiEdit()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_DateChecking_DateCheckingMulti_Edit");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_PermissionQuantity, this.intPermissionQuantity);
                objIData.AddParameter(P_NoPermissionQuantity, this.intNoPermissionQuantity);                
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_DateChecking", objEx);
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
