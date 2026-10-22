
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
	public partial class SIM_Schedule
	{	
		
		#region Methods	

        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="teacherName"></param>
        /// <param name="date"></param>
        /// <param name="fromLessionTime"></param>
        /// <param name="toLessionTime"></param>
        /// <param name="listScheduleID"></param>
        /// <param name="listTestScheduleID"></param>
        /// <param name="day">Có truyền thì có kiểm tra trùng tiết nghỉ, ko truyền thì ko kiểm tra</param>
        /// <returns></returns>
        public string CheckFreeTime_Teacher(string teacherID,  string teacherName, DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID, string listTestScheduleID, int? day = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Teacher_CheckFreeTime");                
                objIData.AddParameter("@TeacherID", teacherID);
                objIData.AddParameter("@TeacherName", teacherName);
                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@Day", day);
                objIData.AddParameter("@FromLessionTime", fromLessionTime);
                objIData.AddParameter("@ToLessionTime", toLessionTime);
                objIData.AddParameter("@ListScheduleID", listScheduleID);
                objIData.AddParameter("@ListTestScheduleID", listTestScheduleID);
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Teacher_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public string CheckFreeTime_Room(string roomID, string roomName, DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID, string listTestScheduleID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Room_CheckFreeTime");
                objIData.AddParameter("@RoomID", roomID);
                objIData.AddParameter("@RoomName", roomName);

                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@FromLessionTime", fromLessionTime);
                objIData.AddParameter("@ToLessionTime", toLessionTime);
                objIData.AddParameter("@ListScheduleID", listScheduleID);
                objIData.AddParameter("@ListTestScheduleID", listTestScheduleID);
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Room_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public string CheckFreeTime_Class(string classID, string className, DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID, string listTestScheduleID, int? day, int? yearID, int? semester)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_CheckFreeTime");
               
                objIData.AddParameter("@ClassID", classID);
                objIData.AddParameter("@ClassName", className);

                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@FromLessionTime", fromLessionTime);
                objIData.AddParameter("@ToLessionTime", toLessionTime);
                objIData.AddParameter("@ListScheduleID", listScheduleID);
                objIData.AddParameter("@ListTestScheduleID", listTestScheduleID);


                objIData.AddParameter("@Day", day); // thêm day kiểm tiết nghỉ (3 biến do tiết nghỉ cần theo niên kì, nếu toàn khóa của lớp thì niên kỳ cho null)
                objIData.AddParameter("@YearID", yearID); 
                objIData.AddParameter("@Semester", semester); 

                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Kiểm tra trùng ngày  nghỉ
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string CheckFreeTime_SchoolFreeDate(DateTime date)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SchoolFreeDate_CheckFreeTime");
                objIData.AddParameter("@Date", date);                
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SchoolFreeDate_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        /// <summary>
        /// Kiểm tra trùng tiết nghỉ của trường
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string CheckFreeTime_SchoolTimeStatus(int? day,  int fromLessionTime, int toLessionTime)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SchoolTimeStatus_CheckFreeTime");
                objIData.AddParameter("@Day", day);
                objIData.AddParameter("@FromLessionTime", fromLessionTime);
                objIData.AddParameter("@ToLessionTime", toLessionTime);                
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SchoolTimeStatus_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }


		
        /// <summary>
        /// Kiểm tra lịch này có đã chấm công thì cũng không được đổi.
        /// Store: SIM_Schedule_CheckFreeTime
        /// </summary>
        /// <returns></returns>
        public string CheckFreeTime(string listScheduleID)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_CheckFreeTime");
                objIData.AddParameter("@ListScheduleID", listScheduleID);                
                return objIData.ExecStoreToString();                
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Schedule_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public string CheckFreeTime(DateTime date, int fromLessionTime, int toLessionTime, string listScheduleID, string listTestScheduleID,
                                    string teacherID, string teacherName, string roomID, string roomName, string classID, string className, 
                                    out bool confirmDulicateRoom, bool isAllowDuplicateRoom, int? day, bool isCheckSchoolFreeDate, bool isCheckTeacherTime, 
                                    int? yearID, int? semester)
        {
            confirmDulicateRoom = false;
            string strRs = "";
            // kiểm tra giảng viên
            if (teacherID != null && teacherID!="")
            {
                int? dayForTeacher = null;
                if (isCheckTeacherTime)
                    dayForTeacher = day;

                strRs = this.CheckFreeTime_Teacher(teacherID, teacherName, date,
                                    fromLessionTime, toLessionTime, listScheduleID, listTestScheduleID, dayForTeacher);
                if (strRs != "")
                    return strRs;
            }


            // kiểm tra lớp học có trùng lớp liên quan không
            strRs = this.CheckFreeTime_Class(classID, className, date,
                                    fromLessionTime, toLessionTime, listScheduleID, listTestScheduleID, day, yearID, semester);
            if (strRs != "")
                return strRs;


            // nhiều khi phải kiểm tra ngày nghỉ riêng, để nhảy cóc khi thêm mới, chứ hông cần kiểm tra để cấm thao thác
            if (isCheckSchoolFreeDate)
            {
                // kiểm tra lịch học, xem có trùng ngày nghỉ
                strRs = this.CheckFreeTime_SchoolFreeDate(date);
                if (strRs != "")
                    return strRs;                
            }

            // Kiểm tra lịch học có trùng tiết nghỉ của trường không?
            if (day != null)
            {
                strRs = this.CheckFreeTime_SchoolTimeStatus(day, fromLessionTime, toLessionTime);
                if (strRs != "")
                    return strRs;
            }


            // kiểm tra xem có chấm công chưa.
            strRs = this.CheckFreeTime(listScheduleID);
            if (strRs != "")
                return strRs;


            // kiểm tra phòng
            if (roomID != null && roomID != "")
            {
                if (!isAllowDuplicateRoom) // nếu chưa nhấn yes
                {
                    strRs = this.CheckFreeTime_Room(roomID, roomName, date,
                                    fromLessionTime, toLessionTime, listScheduleID, listTestScheduleID);
                    if (strRs != "")
                    {
                        if (strRs.Contains("đã sắp lịch học cho lớp")) // trùng lịch học thì hỏi xác nhận
                        {
                            // nếu  phòng này được phép trùng lịch thì hỏi, nếu yes thì cho phép lưu
                            //if (new  SIM_RoomDAO().Get(lookupRoomID.EditValueString).AllowDuplicateScheduling.Value)
                            //{
                            //    return strRs;
                            //    confirmDulicateRoom = true; // tra bien nay ra ngoai de co can hoi cho phep trung phong hay khong?
                            //}
                            //else
                            {
                                confirmDulicateRoom = true; // cần xác nhận cho phép trùng phòng hay không?
                                return strRs; // trung phong, ma phong nay khong the sep trung
                            }
                        }
                        else
                            return strRs; // trùng các loại khác thì ko cho phép trùng
                    }
                }
            }
            return ""; // rong la ok
        }




        public String GetListID(long? classSubjectID, DateTime? date, int? fromLessionTime, int? toLessionTime)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_GetListID");
                objIData.AddParameter("@ClassSubjectID", classSubjectID);
                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@FromLessionTime", fromLessionTime);
                objIData.AddParameter("@ToLessionTime", toLessionTime);
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store: SIM_Schedule_GetListID", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }



        /// <summary>
        /// Xóa tkb của một môn học lớp, loại tiết
        /// </summary>
        /// <param name="classSubjectID"></param>
        /// <param name="isPractice"></param>
        /// <returns></returns>
        public bool Delete(long? classSubjectID, bool? isPractice)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Schedule_DeleteMore");
                objIData.AddParameter(P_ClassSubjectID, classSubjectID);
                objIData.AddParameter(P_IsPractice, isPractice);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Schedule_DeleteMore", objEx);
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
        /// Store: SIM_Schedule_DeleteMore
        /// Tham số tùy biến rộng hơn - Mr Việt 02.01.2024 
        /// ClassSubjectID, IsPractice, SubjectPlanID, StartDate, FinishDate
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool Delete(params object[] pars)
        {
            return ExecNonQuery("SIM_Schedule_DeleteMore", pars);
        }

        /// <summary>
        /// Mr Việt		26/8/2022 Sử dụng đầu tiên cho Kiên Giang
        /// Tự động xử lý lại các giá trị Index, Các tiết học cộng, dồn, Tổng lượng theo môn học lớp, Tổng lượng theo tkb đã sawxp, buổi học chính,....
        /// ScheduleIndex, TotalQuantity, CSTotalQuantity, ScheduleTotalQuantity, IsFinish	
        /// </summary>
        /// <param name="pars">YearID, ClassID</param>
        /// <returns></returns>
        public bool AutoSummary(params object[] pars)
        {
            return ExecNonQuery("SIM_Schedule_AutoSummary", pars);            
        }

        /// <summary>
        /// Kiểm tra trùng lịch của HSSV theo SubjectMark tín chỉ của HSSV đó 
        ///     Hàm này chủ yếu để kiểm tra cho việc đưng ký tín chỉ, đăng ký vào sổ điểm
        /// </summary>
        /// <param name="studentID"></param>
        /// <param name="classSubjectID">Mã môn học lớp dự kiến đăng ký (kiểm luôn mã này nếu chưa có)</param>
        /// <param name="yearID"></param>
        /// <param name="semester"></param>
        /// <returns></returns>
        public string CheckFreeTime_Student(long? studentID, long? classSubjectID, int? yearID, int? semester)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Student_CheckFreeTime");

                objIData.AddParameter("@StudentID", studentID);
                objIData.AddParameter("@ClassSubjectID", classSubjectID);

                objIData.AddParameter("@YearID", yearID);
                objIData.AddParameter("@Semester", semester);

                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Student_CheckFreeTime", objEx);
                this.objErrorException = objEx;
                return objEx.Message;
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
