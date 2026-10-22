
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
	/// Created date 	: 27/06/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_TeachingTimeCoefficient
	{	
		
		#region Methods	
		
        /// <summary>
        /// Tính giờ dạy giảng viên đã quy đổi hệ số
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable GetTeachingTime(params object[] conditions)
        {
            return GetDataTable("SIM_TeachingTimeCoefficient_GetTeachingTime", conditions);
        }

        /// <summary>
        /// Tính giờ dạy giảng viên chi tiết có kèm hệ số cho phép edit lại
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable GetTeachingTimeDetail(params object[] conditions)
        {
            return GetDataTable("SIM_TeachingTimeCoefficient_GetTeachingTimeDetail", conditions);
        }	

        


		#endregion
	
	}
}
