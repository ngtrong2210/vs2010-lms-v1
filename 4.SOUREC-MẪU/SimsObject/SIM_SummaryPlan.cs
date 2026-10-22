
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
	/// Created date 	: 5/26/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_SummaryPlan
	{	
		
		#region Methods	
        /// <summary>
        /// Xóa kế hoạch khung và chi tiết tuần của một lớp ở một niên        
        /// </summary>
        /// <param name="classID">Mã lớp</param>
        /// <param name="yearID">Mã niên học</param>
        /// <returns></returns>
        public bool DeleteOfClassInYear(string classID, int yearID)
        {
            return ExecNonQuery("SIM_SummaryPlan_DeleteOfClassInYear",
                                "@ClassID", classID,
                                "@YearID", yearID);            
        }

		#endregion
	
	}
}
