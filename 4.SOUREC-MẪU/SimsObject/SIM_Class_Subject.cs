
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
	public partial class SIM_Class_Subject
	{
        #region Old method from DAO

        /// <summary>
        /// Lấy môn học lớp cho việc phân công giảng dạy tự động
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForPlanDetail(params object[] pars)
        {
            return GetDataTable("SIM_Class_Subject_SearchForDetailPlan", pars);
        }

        /// <summary>
        /// Lấy môn học lớp cho việc lên kế hoạch thi
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForTestPlanDetail(params object[] pars)
        {
            return GetDataTable("SIM_Class_Subject_SearchForTestDetailPlan", pars);
        }

        /// <summary>
        /// Lấy môn học lớp cho việc phân tiết theo tuần
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForPlanWeekDetailPlan(params object[] pars)
        {
            return GetDataTable("SIM_Class_Subject_SearchForWeekDetailPlan", pars);
        }

        public bool UpdateTeachingBy(bool? isPractice = null)
        {
            return ExecNonQuery("SIM_Class_Subject_UpdateTeachingBy",
                        P_ClassSubjectID, this.lngClassSubjectID,
                        P_TeachingBy, this.strTeachingBy,
                        P_TeachingByTheory, this.strTeachingByTheory,
                        P_ModifiedBy, this.strModifiedBy,
                        "@IsPractice", isPractice); // dùng cho cả lý thuyết và thực hành
        }

        ///<summary>
        /// Cập nhật SIM_Class_Subject
        /// store: SIM_Class_Subject_UpdatePlan
        /// </summary>
        /// <param name="item">Dữ liệu kế hoạch cho dòng lý thuyết được truyền vào, store tự hiểu update cho cái nào</param>
        /// /// <param name="isPracticeRow">Dòng thực hành hay lý thuyết</param>
        /// <returns>object</returns>
        public bool UpdatePlan(bool isPracticeRow)
        {
            return ExecNonQuery("SIM_Class_Subject_UpdatePlan",
                       P_ClassSubjectID, this.lngClassSubjectID,
                       P_TeachingBy, this.strTeachingBy,
                       P_TeachingAtRoom, this.strTeachingAtRoom,
                       P_Days, this.strDays,
                       P_ClassSubjectSession, this.intClassSubjectSession,
                       P_MethodTestID, this.intMethodTestID,
                       P_IsContractTeaching, this.bolIsContractTeaching,

                       P_ReplaceTeacherID, this.strReplaceTeacherID,
                       P_TeachingPrice, this.lngTeachingPrice,

                       P_TeachingByTheory, this.strTeachingByTheory,
                // P_TeachingByPractice, this.strTeachingByPractice,


                       P_MeetingCode, this.strMeetingCode, // CUỘC HỢP
                       P_MeetingLink, this.strMeetingLink,


                       P_TeacherList, this.strTeacherList, // DS TỔNG
                       P_RoomList, this.strRoomList,

                       P_TeacherNameList, this.strTeacherNameList,
                       P_RoomNameList, this.strRoomNameList,


                       P_TeacherListTheory, this.strTeacherListTheory, // DS lt + th (dùng chung cột này để edit theo @IsPractice)
                       P_RoomListTheory, this.strRoomListTheory,

                       P_TeacherNameListTheory, this.strTeacherNameListTheory,
                       P_RoomNameListTheory, this.strRoomNameListTheory,


                       "@IsPractice", isPracticeRow,
                       P_ModifiedBy, this.strModifiedBy);
        }

        ///<summary>
        /// Cập nhật SIM_Class_Subject
        /// store: [SIM_Class_Subject_UpdateTestPlan]
        /// </summary>
        /// <param name="item">SIM_Class_Subject</param>
        /// <returns>object</returns>
        public object UpdateTestPlan()
        {
            return ExecNonQuery("SIM_Class_Subject_UpdateTestPlan",
                        P_ClassSubjectID, this.lngClassSubjectID,
                        P_StartTestWeek, this.intStartTestWeek,
                        P_FinishTestWeek, this.intFinishTestWeek,
                        P_TestTeacher1, this.strTestTeacher1,
                        P_TestTeacher2, this.strTestTeacher2,
                        P_TestAtRoom, this.strTestAtRoom,
                        P_TestAtRoom2, this.strTestAtRoom2,
                        P_ModifiedBy, this.strModifiedBy);
        }


        #endregion
		
		#region Methods	
		
        /// <summary>
        /// Lấy môn học lớp cho việc phân công giảng dạy tự động
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForAutoDivision(int? yearID, int? semester)
        {
            return GetDataTable("SIM_Class_Subject_SearchForAutoDivision",
                        "@Semester", semester,
                        "@YearID", yearID);
        }

        /// <summary>
        /// Lấy môn học lớp cho việc phân công giảng dạy tự động
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForPlanDetail(string classID, int? yearID, int? semester)
        {

            return GetDataTable("SIM_Class_Subject_SearchForDetailPlan",
                    "@ClassID", classID,
                    "@Semester", semester,
                    "@YearID", yearID);
        }

        /// <summary>
        /// Lấy môn học lớp cho việc phân công giảng dạy tự động
        /// </summary>
        /// <returns></returns>
        public DataTable SearchForPlanWeekDetailPlan(string classID, int? yearID, int? semester)
        {
            return GetDataTable("SIM_Class_Subject_SearchForWeekDetailPlan",
                    "@ClassID", classID,
                    "@Semester", semester,
                    "@YearID", yearID);
        }

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Tìm kiếm Môn học có thể được ghép để cho form ghép lớp trả về DataTable
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForBigClass(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_SearchForBigClass", conditions);
        }

        ///<summary>
        /// Xóa danh dau mon hoc lop khi xoa mot lop ghep
        /// </summary>
        /// <param name="item">SIM_Class_Subject</param>
        /// <returns>object</returns>
        public bool DeleteForBigClass(string bigClassID)
        {
            return ExecNonQuery("SIM_Class_Subject_DeleteForBigClass",
                    "@BigClassID", bigClassID);
        }


        /// <summary>
        /// Xoa mon hoc lop cua mot lop hoc
        /// </summary>       
        /// <returns>SIM_Class_Subject</returns>
        public bool DeleteOfClass(string classID)
        {
            return ExecNonQuery("SIM_Class_Subject_DeleteOfClass",
                    "@ClassID", classID);
        }

        /// <summary>
        /// NGUYỄN VĂN VIỆT
        /// Tìm kiếm Môn học có thể được tách của một lớp
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchForSmallClass(object classID, int? yearID, int? semester, long? currentClassSubjectID)
        {
            return GetDataTable("SIM_Class_Subject_SearchForSmallClass",
                    "@ClassID", classID,
                    "@CurrentID", currentClassSubjectID,
                    "@Semester", semester,
                    "@YearID", yearID);
        }

        /// <summary>
        /// Xóa danh sách mã. Danh sách mã theo chuẩn de dung like
        /// </summary>
        /// <param name="listID">,12,5,35,5,</param>
        /// <returns></returns>
        public bool DeleteList(string listID)
        {
            return ExecNonQuery("SIM_Class_Subject_DeleteList",
                    "@ListID", listID);              
        }


        /// <summary>
        /// Lấy môn học của lớp để lặp lịch tự động
        /// </summary>     
        /// <returns></returns>
        public DataTable SearchForAutoScheduling(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_SearchForAutoScheduling", conditions);
        }

        /// <summary>
        /// Lấy danh sách lớp học phần, gồm UnitText, TheoryQuantity, PracticeQuantity, DivisionQuantity(số tiết đã phân), Teaching
        /// SIM_Class_Subject_Status
        /// </summary>     
        /// <returns></returns>
        public DataTable GetStatusForClass(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_Status", conditions);           
        }

        /// <summary>
        /// trả về null nếu không tìm thấy 
        /// </summary>
        /// <param name="yearID"></param>
        /// <param name="semester"></param>
        /// <param name="classID"></param>
        /// <param name="subjectID"></param>
        /// <returns></returns>
        public long? GetClassSubjectID(int? yearID, int? semester, string classID, string subjectID)
        {
            return GetClassSubjectID(yearID, semester, classID, subjectID, null);
        }

        /// <summary>
        /// trả về null nếu không tìm thấy 
        /// </summary>
        /// <param name="yearID"></param>
        /// <param name="semester"></param>
        /// <param name="classID"></param>
        /// <param name="subjectID"></param>
        /// <returns></returns>
        public long? GetClassSubjectID(int? yearID, int? semester, string classID, string subjectID, string bigClassID)
        {
            DataRow drw = GetRow(yearID, semester, classID, subjectID, bigClassID);
            if (drw != null)
                return Convert.ToInt64(drw["ClassSubjectID"]);
            else
                return null;
        }

        public DataRow GetRow(int? yearID, int? semester, string classID, string subjectID)
        {
            return GetRow(yearID, semester, classID, subjectID, null);
        }

        public DataRow GetRow(int? yearID, int? semester, string classID, string subjectID, string bigClassID)
        {
            // tìm ClassSubjectID dựa vào niên, kỳ, lớp, môn
            DataTable dtb = Search("@YearID", yearID, "@Semester", semester, "@ClassID", classID, "@SubjectID", subjectID, "@BigClassID", bigClassID);
            if (dtb != null)
                if (dtb.Rows.Count > 0)
                    return dtb.Rows[0];
            return null;
        }


        /// <summary>
        /// Lấy ds môn học lớp chỉ các thông tin chính, để sử dụng cho các form tính toán tổng hợp
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSimpleList(params object[] conditions)
        {
            return GetDataTable("[SIM_Class_Subject_SearchSimpleList]", conditions);
        }
        /// Lấy ds môn tốt nghiệp lên form Xét tốt nghiệp để tính
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSubject_Graduation(params object[] conditions)
        {
            return GetDataTable("[SIM_Class_Subject_Graduation]", conditions);
        }
        /// Lấy Môn học lớp
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSubject(params object[] conditions)
        {
            return GetDataTable("[SIM_Class_Subject_Search]", conditions);
        }
        /// Lấy ds môn tốt nghiệp và điểm tốt nghiệp lên để in bảng điểm ra trường cho sinh viên
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSubject_Graduation1(long studentID)
        {
            return GetDataTable("[SIM_Student_Subject_Graduation]","@StudentID", studentID);
        }
        /// Lấy ds môn tốt nghiệp và điểm tốt nghiệp môn văn hóa lên để in bảng điểm ra trường cho sinh viên
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchSubject_GraduationVH(long studentID)
        {
            return GetDataTable("[SIM_Student_SubjectVH_Graduation]", "@StudentID", studentID);
        }
        /// <summary>
        /// Lấy danh sách môn học của chương trình đào tạo khung cho tín chỉ, 
        /// nếu nhóm có tạo thì get lên toàn bộ nhóm theo CTĐT đó
        /// Khoá, hệ, bậc, loại, chuyên ngành, năm học, học kì, niên học
        /// </summary>     
        /// <returns></returns>
        public DataTable Search43(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_Search43", conditions);
        }

        /// <summary>
        /// Lấy danh sách nhóm của một môn trong tín chỉ,         
        /// Khoá, hệ, bậc, loại, chuyên ngành, năm học, học kì, niên học
        /// </summary>     
        /// <returns></returns>
        public DataTable GetDetail43(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_GetDetail43", conditions);
        } 

        /// <summary>
        /// SIM_Class_Subject_SearchForRegister43
        /// Lấy ds lớp học phần để đăng ký học phần tín chỉ
        /// Lấy theo bậc, loại, niên, kì là đủ
        /// </summary>     
        /// <returns></returns>
        public DataTable SearchForRegister43(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_SearchForRegister43", conditions);
        } 

        /// <summary>
        /// SIM_Class_Subject_SearchList43
        /// Lấy danh sách lớp học phần của một chương trình đào tạo khung
        /// SpecialBranchSubjectID, yearid, semester
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable SearchList43(params object[] conditions)
        {
            return GetDataTable("SIM_Class_Subject_SearchList43", conditions);
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
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_LockList");
                objIData.AddParameter("@ListID", listID);                
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);  
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_Class_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }


        public int? GetTotalQuantity()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_GetTotalQuantity");
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_ClassID, this.strClassID);
                return Convert.ToInt32(objIData.ExecStoreToString());

            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_Subject_GetTotalQuantity", objEx);
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
        /// NGUYỄN VĂN VIỆT     14/4/2020
        /// Cập nhật các khóa sổ điểm
        /// Khóa nào không truyền vào thì coi như không thay đổi
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public bool UpdateIsLock()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_UpdateIsLock");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_IsLockedMark, this.bolIsLockedMark);
                objIData.AddParameter(P_IsLockedExam1, this.bolIsLockedExam1);
                objIData.AddParameter(P_IsLocked, this.bolIsLocked);

                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_Class_Subject_UpdateIsLock", objEx);
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
        /// Cập nhật ngày khóa thời khóa biểu + ngày khóa lịch thi cho từng nhóm môn học lớp
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public bool Update_ScheduleLockedToDate()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_Update_ScheduleLockedToDate");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ScheduleLockedToDate, this.dtmScheduleLockedToDate);
                objIData.AddParameter(P_TestScheduleLockedToDate, this.dtmTestScheduleLockedToDate);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_Class_Subject_Update_ScheduleLockedToDate", objEx);
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
        /// Kiểm tra có khóa thời khóa biểu theo môn học lớp không?
        /// </summary>
        /// <param name="scheduleID">Nếu đang kiểm tra lịch cũ thì chỉ cần truyền mã tkb: Ktra khi sửa qua ngày khác, hoặc xóa đi</param>
        /// <param name="classSubjectID">Mã môn học lớp</param>       
        /// <param name="date">Đến ngày</param>
        /// <param name="yearID">Lười tính ngày để truyền thì truyền năm và tuần</param>       
        /// <param name="week">đến tuần</param>
        /// <returns></returns>
        public string Check_ScheduleLockedToDate(long? scheduleID, long? classSubjectID = null, DateTime? date = null, int? yearID = null, int? week = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_Check_ScheduleLockedToDate");
                objIData.AddParameter("@ClassSubjectID", classSubjectID);
                objIData.AddParameter("@ScheduleID", scheduleID);
                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@YearID", yearID);
                objIData.AddParameter("@Week", week);
                objIData.ExecNonQuery();
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi gọi store SIM_Class_Subject_Check_ScheduleLockedToDate", objEx);
                this.objErrorException = objEx;
                return "";
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }


        /// <summary>
        /// Kiểm tra có khóa lịch thi theo môn học lớp không? (sync NSG --> TW3 2025.05.21)
        /// </summary>
        /// <param name="scheduleID">Nếu đang kiểm tra lịch cũ thì chỉ cần truyền mã tkb: Ktra khi sửa qua ngày khác, hoặc xóa đi</param>
        /// <param name="classSubjectID">Mã môn học lớp</param>       
        /// <param name="date">Đến ngày</param>
        /// <param name="yearID">Lười tính ngày để truyền thì truyền năm và tuần</param>       
        /// <param name="week">đến tuần</param>
        /// <returns></returns>
        public string Check_TestScheduleLockedToDate(long? scheduleID, long? classSubjectID = null, DateTime? date = null, int? yearID = null, int? week = null)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_Check_TestScheduleLockedToDate");
                objIData.AddParameter("@ClassSubjectID", classSubjectID);
                objIData.AddParameter("@ScheduleID", scheduleID);
                objIData.AddParameter("@Date", date);
                objIData.AddParameter("@YearID", yearID);
                objIData.AddParameter("@Week", week);
                objIData.ExecNonQuery();
                return objIData.ExecStoreToString();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi gọi store SIM_Class_Subject_Check_TestScheduleLockedToDate", objEx);
                this.objErrorException = objEx;
                return "";
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }


        /// <summary>
        /// Cập nhật thông tin cho việc đăng ký tín chỉ
        /// SIM_Class_Subject_Update_ForRegister
        /// MaxRegister, StartRegister, FinishRegister, TotalFee
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public bool Update_ForRegister()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_Update_ForRegister");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);

                objIData.AddParameter(P_MaxRegister, this.intMaxRegister);
                objIData.AddParameter(P_StartRegister, this.dtmStartRegister);
                objIData.AddParameter(P_FinishRegister, this.dtmFinishRegister);
                objIData.AddParameter(P_CommitRegister, this.dtmCommitRegister);
                objIData.AddParameter(P_TotalFee, this.intTotalFee);

                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_Class_Subject_Update_ScheduleLockedToDate", objEx);
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
        /// Tự động hiệu chỉnh lại ĐVHT, LT, TH cho lớp tách ghép theo lớp gốc
        /// SIM_Class_Subject_AutoModify_ForBigAndSmall
        /// Cần ClassID, YearID, Semester
        /// </summary>
        /// <returns></returns>
        public bool AutoModify_ForBigAndSmall()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_AutoModify_ForBigAndSmall");
                objIData.AddParameter(P_ClassID, strClassID);
                objIData.AddParameter(P_YearID, intYearID);
                objIData.AddParameter(P_Semester, intSemester);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_Class_Subject_AutoModify_ForBigAndSmall", objEx);
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
        /// Cập nhật gia hạn sổ lên lớp đến ngày... cho từng nhóm môn học lớp
        /// </summary>
        /// <param name="listID"></param>
        /// <returns></returns>
        public bool Update_ScheduleCheckingExtendToDate()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_Update_ScheduleCheckingExtendToDate");
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_ScheduleCheckingExtendToDate, this.dtmScheduleCheckingExtendToDate);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa thông tin SIM_Class_Subject_Update_ScheduleCheckingExtendToDate", objEx);
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
        /// Tự động đồng bộ lại số tín chỉ, số giờ lý thuyết, thực hành, kiểm tra cho môn học lớp từ chương trình khung
        /// MR VIỆT - 26/8/2024 dùng lần đầu cho NSG
        /// </summary>
        /// <param name="specialBranchID"></param>
        /// <param name="trainingLevelID"></param>
        /// <param name="trainingType"></param>
        /// <param name="courseID"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        public bool ReSync_FromSBS(string specialBranchID, string trainingLevelID, string trainingType, string courseID, string modifiedBy)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_Subject_ReSync_FromSBS");
                objIData.AddParameter("@SpecialBranchID", specialBranchID);
                objIData.AddParameter("@TrainingLevelID", trainingLevelID);
                objIData.AddParameter("@TrainingType", trainingType);
                objIData.AddParameter("@CourseID", courseID);
                objIData.AddParameter(P_ModifiedBy, modifiedBy);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class_Subject_ReSync_FromSBS", objEx);
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
