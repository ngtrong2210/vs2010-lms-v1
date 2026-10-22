using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Class. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Class
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách lớp theo năm học
        /// </summary>
        public DataTable GetByYear(long yearID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@YearID", yearID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy danh sách học viên theo lớp
        /// </summary>
        public DataTable GetStudents(long classID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Class_GetStudents");
                objIData.AddParameter("@ClassID", classID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy cơ cấu đào tạo đầy đủ (năm học, khoa, lớp, môn học, giảng viên, học viên, thời khóa biểu)
        /// Store: GetCatalog
        /// </summary>
        /// <param name="actorId">ID của user đang thao tác</param>
        /// <param name="isAdmin">Có phải admin không</param>
        /// <returns>DataSet chứa 10 tables dữ liệu</returns>
        public DataSet GetCatalog(int? actorId, bool isAdmin)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("GetCatalog");
                objIData.AddParameter("@ActorID", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataSet();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lưu cấu trúc đào tạo (thêm/cập nhật các entity: năm học, khoa, lớp, môn học, giảng viên, học viên, thời khóa biểu)
        /// Store: Save
        /// </summary>
        /// <param name="entityType">Loại entity (YEAR, SCIENCE, COHORT, CLASS, SUBJECT, TEACHER, STUDENT, CLASSSUBJECT, TIMETABLE)</param>
        /// <param name="dataGroupId">ID nhóm dữ liệu</param>
        /// <param name="code">Mã</param>
        /// <param name="name">Tên</param>
        /// <param name="shortName">Tên viết tắt</param>
        /// <param name="parentCode">Mã cha</param>
        /// <param name="startYear">Năm bắt đầu</param>
        /// <param name="finishYear">Năm kết thúc</param>
        /// <param name="startAt">Ngày bắt đầu</param>
        /// <param name="finishAt">Ngày kết thúc</param>
        /// <param name="yearId">ID năm học</param>
        /// <param name="semester">Học kỳ</param>
        /// <param name="classSubjectId">ID môn học trong lớp</param>
        /// <param name="classId">ID lớp</param>
        /// <param name="subjectId">ID môn học</param>
        /// <param name="teacherId">ID giảng viên</param>
        /// <param name="classSize">Sĩ số lớp</param>
        /// <param name="creditCount">Số tín chỉ</param>
        /// <param name="theoryQuantity">Số tiết lý thuyết</param>
        /// <param name="practiceQuantity">Số tiết thực hành</param>
        /// <param name="timetableId">ID thời khóa biểu</param>
        /// <param name="dayOfWeek">Thứ trong tuần</param>
        /// <param name="startPeriod">Tiết bắt đầu</param>
        /// <param name="endPeriod">Tiết kết thúc</param>
        /// <param name="startTime">Giờ bắt đầu</param>
        /// <param name="endTime">Giờ kết thúc</param>
        /// <param name="roomName">Tên phòng học</param>
        /// <param name="effectiveFrom">Ngày hiệu lực từ</param>
        /// <param name="effectiveTo">Ngày hiệu lực đến</param>
        /// <param name="actorId">ID của user đang thao tác</param>
        /// <returns>DataTable kết quả</returns>
        public DataTable SaveAcademicEntity(string entityType, int? dataGroupId, string code, string name,
            string shortName, string parentCode, int? startYear, int? finishYear, DateTime? startAt, DateTime? finishAt,
            int? yearId, int? semester, long? classSubjectId, string classId, string subjectId, string teacherId,
            int? classSize, int? creditCount, int? theoryQuantity, int? practiceQuantity, long? timetableId,
            int? dayOfWeek, int? startPeriod, int? endPeriod, TimeSpan? startTime, TimeSpan? endTime, string roomName,
            DateTime? effectiveFrom, DateTime? effectiveTo, int? actorId)
        {
            return GetDataTable("Save",
                "@EntityType", entityType,
                "@DataGroupID", dataGroupId,
                "@Code", code,
                "@Name", name,
                "@ShortName", shortName,
                "@ParentCode", parentCode,
                "@StartYear", startYear,
                "@FinishYear", finishYear,
                "@StartAt", startAt,
                "@FinishAt", finishAt,
                "@YearID", yearId,
                "@Semester", semester,
                "@ClassSubjectID", classSubjectId,
                "@ClassID", classId,
                "@SubjectID", subjectId,
                "@TeacherID", teacherId,
                "@ClassSize", classSize,
                "@CreditCount", creditCount,
                "@TheoryQuantity", theoryQuantity,
                "@PracticeQuantity", practiceQuantity,
                "@TimetableID", timetableId,
                "@DayOfWeek", dayOfWeek,
                "@StartPeriod", startPeriod,
                "@EndPeriod", endPeriod,
                "@StartTime", startTime,
                "@EndTime", endTime,
                "@RoomName", roomName,
                "@EffectiveFrom", effectiveFrom,
                "@EffectiveTo", effectiveTo,
                "@ActorID", actorId);
        }

        /// <summary>
        /// Phân học viên vào lớp và đồng bộ môn LMS
        /// Store: AssignStudents
        /// </summary>
        /// <param name="dataGroupId">ID nhóm dữ liệu</param>
        /// <param name="classId">ID lớp</param>
        /// <param name="studentUserIdsJson">JSON danh sách ID học viên</param>
        /// <param name="actorId">ID của user đang thao tác</param>
        /// <returns>DataTable kết quả</returns>
        public DataTable AssignStudentsToClass(int? dataGroupId, string classId, string studentUserIdsJson, int? actorId)
        {
            return GetDataTable("AssignStudents",
                "@DataGroupID", dataGroupId,
                "@ClassID", classId,
                "@StudentUserIDsJson", studentUserIdsJson,
                "@ActorID", actorId);
        }

        #endregion
    }
}
