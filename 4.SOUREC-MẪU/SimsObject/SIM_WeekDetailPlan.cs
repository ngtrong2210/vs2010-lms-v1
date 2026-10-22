
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
    public partial class SIM_WeekDetailPlan
	{	
		
		#region Methods	
		
        /// <summary>
        /// Lấy danh sách tuần trong một niên, một kì để sắp lịch
        /// </summary>
        /// <param name="yearID">Niên học</param>
        /// <param name="semester">Học kì</param>
        /// <param name="listClassID">Danh sách lớp</param>
        /// <returns></returns>
        public DataTable GetListWeek(int? yearID, int? semester, string listClassID)
        {
            return GetDataTable("SIM_WeekDetailPlan_GetListWeek",
                        "@YearID", yearID,
                        "@Semester", semester,
                        "@ListClassID", listClassID);
            
        }

        /// <summary>
        /// Lấy toàn bộ kế hoạch tuần của lớp và các lớp tách ghép liên quan tới lớp đó ở một niên, kì
        /// Để kiểm tra khi sửa hoặc xoá trạng thái học kì một, học kì 2 của kế hoạch tổng thể
        /// Store: SIM_WeekDetailPlan_ReferenceOfClassYear
        /// </summary>
        /// <param name="yearID">Niên học</param>
        /// <param name="semester">Học kì</param>
        /// <param name="classID">Mã lớp</param>
        /// <returns></returns>
        public DataTable GetAllReferenceOfClassYearSemester(string classID, int? yearID, int? semester)
        {
            return GetDataTable("SIM_WeekDetailPlan_ReferenceOfClassYear",
                        "@YearID", yearID,
                        "@Semester", semester,
                        "@ClassID", classID);           
        }

        /// <summary>
        /// [SIM_WeekDetailPlan_DeleteNotExists]
        /// Xóa kế hoạch chi tiết tuần của những lớp liên quan không tồn tại theo kế hoạch tổng thể
        /// </summary>
        /// <param name="classID">Mã lớp</param>
        /// <param name="yearID">Mã niên học</param>
        /// /// <param name="listWeek">Danh sách tuần trong kế hoạch tổng thể ;3;4; -> Sẽ xoá ủa các lớp liên quan không thuộc danh sách tuần này</param>
        /// <returns></returns>
        public bool DeleteNotExistOfClassInYear(string classID, int? yearID, string listWeek)
        {
            return ExecNonQuery("SIM_WeekDetailPlan_DeleteNotExists",
                                "ClassID", classID,
                                "YearID", yearID,
                                "@ListWeek", listWeek);            
        }

        /// <summary>
        /// SIM_WeekDetailPlan_SearchForGetName
        /// Lấy danh sách tuần trong một niên kèm tham số để phân loại tuần trong kế hoạch tổng thể, hiển thị text
        /// </summary>
        /// <param name="yearID">Niên học</param>
        /// <param name="semester">Học kì</param>
        /// <param name="listClassID">Danh sách lớp</param>
        /// <returns></returns>
        public DataTable SearchForGetNameInSummaryPlan(int? yearID, string listClassID)
        {
            return GetDataTable("SIM_WeekDetailPlan_SearchForGetName",
                        "@YearID", yearID,
                        "@ClassListID", listClassID);                 
        }

        /// <summary>
        /// [SIM_WeekDetailPlan_RepairWhenUpdateSubject]
        /// NGUYỄN VĂN VIỆT		25/12/2011
        ///Khi update môn học từ loại môn này sang loại môn khác phải xử lý kế hoạch theo tuần
        /// Ví dụ môn TH thì không có kế hoạch LT, môn LT thì không có kế hoạch TH.
        ///Nên phải cộng dồn lại hoặc chuyển qua. Còn từ môn thường sang tích hợp thì không xử lý, và user phải tự làm
        /// </summary>                
        /// <param name="SubjectID">Mã môn</param>        
        /// <returns></returns>
        public bool RepairWhenUpdateSubject(string subjectID)
        {
            return ExecNonQuery("SIM_WeekDetailPlan_RepairWhenUpdateSubject", "@SubjectID",subjectID);            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchWithStore(string storeName, params object[] pars)
        {
            return GetDataTable(storeName, pars);            
        }

        /// <summary>
        /// [SIM_WeekDetailPlan_RepairWhenUpdateSubject]
        /// NGUYỄN VĂN VIỆT		25/12/2011
        ///Khi update môn học từ loại môn này sang loại môn khác phải xử lý kế hoạch theo tuần
        /// Ví dụ môn TH thì không có kế hoạch LT, môn LT thì không có kế hoạch TH.
        ///Nên phải cộng dồn lại hoặc chuyển qua. Còn từ môn thường sang tích hợp thì không xử lý, và user phải tự làm
        /// </summary>                
        /// <param name="SubjectID">Mã môn</param>        
        /// <returns></returns>
        public bool RepairWhenUpdateSubject_ForClassSubject(string classID, int? yearID, int? semester)
        {
            return ExecNonQuery("SIM_WeekDetailPlan_RepairWhenUpdateSubject_ForClassSubject",
                                    "@YearID", yearID,
                                    "@Semester", semester,
                                    "@ClassID", classID);    
        }
				
		#endregion
	
	}
}
