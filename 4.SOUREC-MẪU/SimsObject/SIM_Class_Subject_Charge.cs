
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
	/// Created date 	: 3/27/2013 
	/// Description 
	/// </summary>	
	public partial class SIM_Class_Subject_Charge
	{	
		
		#region Methods	
		
				
        
        /// <summary>
        /// Lấy ds sinh viên đăng ký học lại
        /// SIM_Class_Subject_Charge_SearchStudent
        /// </summary>
        /// <param name="classSubjectID"></param>
        /// <returns></returns>
        public DataTable SearchStudent(long classSubjectID)
        {
            return GetDataTable("SIM_Class_Subject_Charge_SearchStudent", "@ClassSubjectID", classSubjectID);
        }

		#endregion
	
	}
}
