
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
	public partial class SIM_MealChecking
	{	
		
		#region Methods	
                
        /// <summary>
        /// Thong ke so tiet vang theo ngày sinh vien 
        /// SIM_MealChecking_Statistic
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchStatistic(params object[] conditions)
        {
            return GetDataTable("[SIM_MealChecking_SearchStatistic]", conditions);
        }

        /// <summary>
        /// Thong ke thanh toán tiền tháng cho sinh viên
        /// SIM_MealChecking_SearchPayment
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchPayment(params object[] conditions)
        {
            return GetDataTable("[SIM_MealChecking_SearchPayment]", conditions);
        }
                
		#endregion
	
	}
}
