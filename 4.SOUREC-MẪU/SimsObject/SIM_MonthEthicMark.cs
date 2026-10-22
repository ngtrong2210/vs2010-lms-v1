
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
	/// Created date 	: 3/31/2013 
	/// Description 
	/// </summary>	
	public partial class SIM_MonthEthicMark
	{	
		
		#region Methods	
		

        /// <summary>
        /// Tổng hợp điểm rèn luyện kỳ, năm từ rèn luyện tháng
        /// [SIM_MonthEthicMark_Summary]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSummary(params object[] conditions)
        {
            return GetDataTable("[SIM_MonthEthicMark_Summary]", conditions);
        }
				
		#endregion
	
	}
}
