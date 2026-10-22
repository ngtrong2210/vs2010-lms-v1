
#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimsObject;

#endregion

namespace SimsObject
{
    /// <summary>
	/// Created by 		: NGUYỄN VĂN VIỆT 
	/// Created date 	: 11/10/2012 
	/// Desc			: Data Access Object for SIM_Class_Subject_BeforeSubject
	/// </summary>	
    public partial class SIM_Class_Subject_BeforeSubject
	{
        ///<summary>
        /// Xóa [SIM_Class_Subject_BeforeSubject_DeleteOfClass]        
        /// </summary>        
        /// <returns>bool</returns>
        public bool DeleteOfClassSubject(object classID, object yearID, object semester)
        {
            return ExecNonQuery("SIM_Class_Subject_BeforeSubject_DeleteOfClassSubject",
                    SIM_Class_Subject.P_ClassID, classID,
                    SIM_Class_Subject.P_YearID, yearID,
                    SIM_Class_Subject.P_Semester, semester
                    );            
        }
	}
}
