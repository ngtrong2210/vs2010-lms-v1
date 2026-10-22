
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
	/// Created date 	: 6/8/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_ReRegister
	{	
		
		#region Methods	
		
        /// <summary>
        /// Nguyễn Văn Việt
        /// Lấy danh sách các môn nợ theo từng sinh viên.
        /// Đồng thời hiển thị thông tin đăng ký học/thi lại. Edit để đăng ký học/thi lại.
        /// Store: [SIM_ReRegister_SearchDeptSubject]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchDeptSubject(params object[] conditions)
        {
            return GetDataTable("SIM_ReRegister_SearchDeptSubject", conditions);
        }

        /// <summary>
        /// Danh sách môn học có sinh viên đang ký học lại để chọn add vào lớp
        /// SIM_ReRegister_SearchSubjectLearningReRegister
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSubjectLearningReRegister(params object[] conditions)
        {
            return GetDataTable("SIM_ReRegister_SearchSubjectLearningReRegister", conditions);
        }

        /// <summary>
        /// Danh sách sinh viên đăng ký thi lại để add vào lớp cho học
        /// SIM_ReRegister_SearchLearningReRegister
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchLearningReRegister(params object[] conditions)
        {
            return GetDataTable("SIM_ReRegister_SearchLearningReRegister", conditions);
        }

        /// <summary>
        /// DANH SÁCH MÔN HỌC LỚP CỦA NHỮNG LỚP CÓ CHỨA MÔN ĐĂNG KÝ HỌC LẠI
        /// SIM_ReRegister_SearchClassSubject
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchClassSubject(params object[] conditions)
        {
            return GetDataTable("[SIM_ReRegister_SearchClassSubject]", conditions);
        }

        /// <summary>
        ///     NGUYỄN VĂN VIỆT 9/6/2012
	    ///     DANH SÁCH SỔ ĐIỂM: Gồm sinh viên của lớp và sinh viên đăng ký học lại.
		///     Lấy theo lớp có học môn học có đăng ký học lại của niên kì.
        ///     [SIM_SubjectMark_SearchStudentForReRegister]
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchStudentForReRegister(params object[] conditions)
        {
            return GetDataTable("[SIM_SubjectMark_SearchStudentForReRegister]", conditions);
        }

		#endregion
	
	}
}
