
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
	/// Created date 	: 02/09/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_Room
	{	
		
		#region Methods	
		
        /// <summary>
        /// Lấy danh sách phòng cho việc sắp lịch học tự động
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForAutoScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Room_SearchForAutoScheduling", conditions);            
        }


        /// <summary>
        /// Lấy danh sách phòng cho việc sắp lịch thi tự động
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForAutoTestScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Room_SearchForAutoTestScheduling", conditions);
        }

        /// <summary>
        /// Kiểm tra trùng phòng
        /// Store: SIM_Room_CheckFreeTime
        /// </summary>
        /// <returns></returns>
        public string CheckFreeTime(string roomID, string roomName, DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID, string listTestScheduleID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Room_CheckFreeTime");

                objIData.AddParameter("@RoomID", roomID);
                objIData.AddParameter("@RoomName", roomName);
                objIData.AddParameter("@Date", date);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Room_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
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
