
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
	/// Created date 	: 11/11/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_TestSchedule
	{	
		
		#region Methods	
		
        /// <summary>
        /// Lấy thông tin lịch đã được sắp cho từng giảng viên, để giới hạn khi sắp lịch tự động
        /// SIM_TestSchedule_SearchForAutoScheduling
        /// </summary>
        /// <param name="yearID"></param>
        /// <param name="semester"></param>
        /// <param name="listClassID"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public DataTable SearchForAutoScheduling(params object [] pars)
        {
            return GetDataTable("SIM_TestSchedule_SearchForAutoScheduling",pars);                                
        }

        /// <summary>
        /// SIM_TestSchedule_OfTeacher
        /// Lịch cho giảng viên
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable TestScheduleOfTeacher(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_OfTeacher", pars);            
        }

        /// <summary>
        /// [SIM_TestSchedule_SearchForEdit]
        /// Lịch cho giảng viên
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchForEdit(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_SearchForEdit", pars);
        }

        /// <summary>
        /// SIM_TestSchedule_SearchForDetailTeachingPlan
        /// Lấy dữ liệu cho frmDetailTeachingPlan Kế hoạch giảng dạy chi tiết của giảng viên
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchForDetailTeachingPlan_rpt(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_ForDetailTeachingPlan_rpt", pars);           
        }
        public DataTable SearchForDetailTeachingPlan(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_SearchForDetailTeachingPlan", pars);            
        }
        /// <summary>
        /// [SIM_TestSchedule_TeachingTimeStatistic]
        /// Thống kê thực giảng của giảng viên.
        /// Chỉ lấy những tiết đã chấm công.
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchForTeachingTimeStatistic(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_TeachingTimeStatistic", pars);
            
        }

        /// <summary>
        /// [SIM_TestSchedule_SubjectTeachingProcess]
        /// Lấy thông tin tiến độ giảng dạy của môn học
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchForSubjectTeachingProcess(params object[] pars)
        {
           return GetDataTable("SIM_TestSchedule_SubjectTeachingProcess", pars);
            
        }

        /// <summary>
        /// [SIM_TestSchedule_TeachingProcessOfTeacher]
        /// Lấy thông tin tiến độ giảng dạy giảng viên
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchForTeachingProcessOfTeacher(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_TeachingProcessOfTeacher", pars);
            
        }

        /// <summary>
        /// Store proc: [SIM_TestSchedule_SearchForSummaryTestSchedule]
        /// NGUYỄN VĂN VIỆT 30/07/2011
        /// Lấy dữ liệu cho form SummaryTestSchedule - Lịch tổng hợp của lớp
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable SearchForSummaryTestScheduleOfClass(params object[] pars)
        {
           return GetDataTable("SIM_TestSchedule_SearchForSummaryTestScheduleOfClass", pars);
            
        }

        /// <summary>
        /// Store proc: [[SIM_TestSchedule_GetListWeekOfClass]]
        /// NGUYỄN VĂN VIỆT 30/07/2011
        /// Lấy danh sách tuần có lịch thi của một lớp học
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public DataTable GetListWeekOfClass(params object[] pars)
        {
            return GetDataTable("SIM_TestSchedule_GetListWeekOfClass", pars);
            
        }

        /// <summary>
        /// Xóa danh sách mã. Danh sách mã theo chuẩn de dung like
        /// [SIM_TestSchedule_DeleteList]
        /// </summary>
        /// <param name="listID">,12,5,35,5,</param>
        /// <returns></returns>
        public bool DeleteList(string listID)
        {
            return this.ExecNonQuery("SIM_TestSchedule_DeleteList","@ListID", listID);                
        }

        /// <summary>
        /// Kiểm tra lịch học có trùng ngày nghỉ của trường hay không, và lịch này có đã chấm công thì cũng không được đổi.
        /// Store: SIM_Teacher_SearchForAutoTestScheduling
        /// </summary>
        /// <returns></returns>
        public string CheckFreeTime(DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID)
        {

            DataTable dtb = GetDataTable("SIM_TestSchedule_CheckFreeTime",
                                         "@Date", date,
                                         "@FromLessionTime", fromLessionTime,
                                         "@ToLessionTime", toLessionTime,
                                         "@ListScheduleID", listScheduleID);
            if (dtb != null)
                if (dtb.Rows.Count > 0)
                    return dtb.Rows[0][0].ToString();
            return "";
        }

        /// <summary>
        /// [SIM_TestSchedule_SearchForMakeExamSchedule]
        /// Ds lịch thi theo môn, học, kì, lần thi. Dùng để tổ chức thi
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForMakeExamSchedule(params object[] conditions)
        {
            return GetDataTable("SIM_TestSchedule_SearchForMakeExamSchedule", conditions);
        }

        /// <summary>
        /// [SIM_TestSchedule_SearchExamSchedule]
        /// Lấy ds lịch thi của môn đã tổ chức thi, làm ds quản lý
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchExamSchedule(params object[] conditions)
        {
            return GetDataTable("[SIM_TestSchedule_SearchExamSchedule]", conditions);
        }

        public DataTable SearchGraduationExamSchedule(params object[] conditions)
        {
            return GetDataTable("[SIM_TestSchedule_SearchGraduationExamSchedule]", conditions);
        }

        /// <summary>
        /// [SIM_TestSchedule_DeleteForExamSchedule]
        /// Xoá lịch thi hông của lớp, của môn niên kì, lần thi. và xoá luon sinh viên đăng ký
        /// </summary>
        /// <returns></returns>
        public bool DeleteForExamSchedule()
        {
            return this.ExecNonQuery("SIM_TestSchedule_DeleteForExamSchedule",
                    "@YearID", intYearID,
                    "@Semester", intSemester,
                    "@SubjectID", strSubjectID,
                    "@TestOrder", intTestOrder);
        }

        ///<summary>
        /// Update : SIM_Class_Subject
        /// Khóa danh sách môn học lớp ;223;56;4;
        /// Store: SIM_Class_Subject_LockList 
        ///</summary>
        public bool LockList(string listID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_LockList");
                objIData.AddParameter("@ListID", listID);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_TestSchedule", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }


        /// <summary>
        /// Cập nhật thông tin xếp lịch thi
        /// Dùng riêng cho quyền "SIM_TestScheduleEdit_Edit_Info"; // Xếp lịch thi (ngày, ca, phòng)        
        /// </summary>
        /// <returns></returns>
        public bool Update_Info()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_Edit_Info");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
                objIData.AddParameter(P_Day, this.intDay);
                objIData.AddParameter(P_Date, this.dtmDate);
                objIData.AddParameter(P_Week, this.intWeek);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_TestSessionID, this.intTestSessionID);
                objIData.AddParameter(P_RoomID, this.strRoomID);
                objIData.AddParameter(P_RoomID2, this.strRoomID2);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_MethodTestID, this.intMethodTestID);
                objIData.AddParameter(P_StudentCount, this.intStudentCount);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TestSchedule", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Cập nhật thông tin phân công giám thị
        /// Dùng riêng cho quyền "SIM_TestScheduleEdit_Edit_Teacher"; 
        ///  Chỉ thông tin giám thị
        /// </summary>
        /// <returns></returns>
        public bool Update_Teacher()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_TestSchedule_Edit_Teacher");
                objIData.AddParameter(P_ScheduleID, this.lngScheduleID);
                objIData.AddParameter(P_TeacherID1, this.strTeacherID1);
                objIData.AddParameter(P_TeacherID2, this.strTeacherID2);
                objIData.AddParameter(P_TeacherID3, this.strTeacherID3);

                objIData.AddParameter(P_ReviewTeacherID1, this.strReviewTeacherID1);
                objIData.AddParameter(P_ReviewTeacherID2, this.strReviewTeacherID2);
                objIData.AddParameter(P_ReviewTeacherID3, this.strReviewTeacherID3);

                objIData.AddParameter(P_ControlTeacherID, this.strControlTeacherID);
                objIData.AddParameter(P_NoteTeacherID, this.strNoteTeacherID);
                objIData.AddParameter(P_FollowTeacherID, this.strFollowTeacherID);

                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TestSchedule", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

		#endregion
	
	}
}
