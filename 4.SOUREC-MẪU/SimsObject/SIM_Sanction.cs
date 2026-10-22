
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
	public partial class SIM_Sanction
	{	
		
		#region Methods	
		
				
        public bool DeleteList(string listID)
        {
            return this.ExecNonQuery("SIM_Sanction_DeleteList", "@ListID",listID);
        }

		#endregion
	
	}
}
