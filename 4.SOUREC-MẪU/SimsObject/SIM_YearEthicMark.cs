
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
	public partial class SIM_YearEthicMark
	{	
		
		#region Methods	
		

        /// <summary>
        /// NGUYEN VAN VIET
        /// Lấy ds diem ren luyen nam chỉ các thông tin chính, để sử dụng cho các form tính toán tổng hợp
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSimpleList(params object[] conditions)
        {
            return GetDataTable("[SIM_YearEthicMark_SearchSimpleList]", conditions);
        }
				
		#endregion
	
	}
}
