
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
	/// Created date 	: 11/07/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_Teacher
	{

        /// <summary>
        /// Lấy giáo viên để phân bổ tự động
        /// </summary>
        /// <param name="yearID">Theo nien học để tính được lượng tiết đã phân bổ trước đó</param>
        /// <param name="semester">Theo học kì</param>
        /// <returns></returns>
        public DataTable SearchForAutoDivision(int? yearID, int? semester)
        {
            return GetDataTable("SIM_Teacher_SearchForAutoDivision",
                                "@YearID", yearID,
                                "@Semester", semester);            
        }

        /// <summary>
        /// Lấy danh sách giáo viên cho việc sắp lịch học tự động
        /// Store: SIM_Teacher_SearchForAutoScheduling
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForAutoScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Teacher_SearchForAutoScheduling", conditions);            
        }


        /// <summary>
        /// Lấy danh sách giáo viên cho việc sắp lịch thi tự động
        /// Store: SIM_Teacher_SearchForAutoTestScheduling
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForAutoTestScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Teacher_SearchForAutoTestScheduling", conditions);                       
        }

        /// <summary>
        /// Kiểm tra trùng giảng viên
        /// Có truyền day thì có kiểm tra tiết nghỉ giảng viên
        /// Store: SIM_Teacher_CheckFreeTime
        /// </summary>
        /// <returns></returns>
        public string CheckFreeTime(string teacherID, string teacherName, DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID, string listTestScheduleID, int? day)
        {        
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Teacher_CheckFreeTime");                
                objIData.AddParameter("@TeacherID", teacherID);
                objIData.AddParameter("@TeacherName", teacherName);
                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@Day", day);
                objIData.AddParameter("@FromLessionTime", fromLessionTime);
                objIData.AddParameter("@ToLessionTime", toLessionTime);
                objIData.AddParameter("@ListScheduleID", listScheduleID);
                objIData.AddParameter("@ListTestScheduleID", listTestScheduleID);

				return objIData.ExecStoreToString();    			

			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Teacher_CheckFreeTime", objEx);
				this.objErrorException = objEx;
				return objEx.Message;
			}
			finally
    		{
				if (!bolIsExistIData)
					objIData.Disconnect();
    		}
		}        
	}
}
