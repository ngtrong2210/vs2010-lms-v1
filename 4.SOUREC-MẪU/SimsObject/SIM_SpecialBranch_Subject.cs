
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
	/// Created date 	: 5/12/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_SpecialBranch_Subject
	{	
		
		#region Methods	
		
        ///<summary>
        /// Xóa SIM_SpecialBranch_Subject
        /// Xoá chương trình đào tạo của một Khoa, khoá, chuyên ngành, bậc, loại, niên, kì
        /// </summary>
        /// <param name="item">SIM_SpecialBranch_Subject cùng loại này là xoá hết, chứ không xoá theo id</param>
        /// <returns>bool</returns>
        public bool DeleteOfSpecialBranch(SIM_SpecialBranch_Subject item)
        {
            return ExecNonQuery("SIM_SpecialBranch_Subject_DeleteOfSpecialBranch",                    
                    SIM_SpecialBranch_Subject.P_CourseID,item.CourseID,
                    SIM_SpecialBranch_Subject.P_SpecialBranchID, item.SpecialBranchID,
                    SIM_SpecialBranch_Subject.P_TrainingLevelID, item.TrainingLevelID,
                    SIM_SpecialBranch_Subject.P_TrainingType, item.TrainingType,
                    SIM_SpecialBranch_Subject.P_Year, item.Year,
                    SIM_SpecialBranch_Subject.P_Semester, item.Semester);

        }

        ///<summary>
        /// Xóa danh sách chuong trinh dao tao, với mã là một chuỗi cách nhau dấu, ví dụ ,'1','2',
        /// Store: [SIM_SpecialBranch_Subject_DeleteList]
        /// </summary>
        /// <param name="listID">string</param>
        /// <returns>bool</returns>
        public bool DeleteList(string listID)
        {
            return this.ExecNonQuery("SIM_SpecialBranch_Subject_DeleteList", "@ListID", listID);
        }


        public DataTable GetExamWeek()
        {
            return GetDataTable("SIM_SpecialBranch_Subject_GetExamWeek");           
        }

       

		#endregion
	
	}
}
