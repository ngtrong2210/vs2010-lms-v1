using System;
using System.Data;
using System.Collections.Generic;
using DCore;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Courses. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Courses
    {
        public DataTable Search(string condition)
        {
            return GetDataTable("SIM_Courses_SEARCH", "@Condition", condition);
        }

        public DataTable SearchCBX()
        {
            return GetDataTable("SIM_Courses_SEARCHCBX");
        }

        public bool UpdateStatus()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_UpdateStatus");
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật trạng thái khóa học", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        public bool Publish()
        {
            this.strStatus = "PUBLISHED";
            this.dtmPublishedAt = DateTime.UtcNow;
            return UpdateStatus();
        }

        public bool Archive()
        {
            this.strStatus = "ARCHIVED";
            return UpdateStatus();
        }

        public DataTable GetByCategory(long categoryId)
        {
            return GetDataTable("SIM_Courses_GetByCategory", "@CourseCategoryID", categoryId);
        }

        public DataTable GetByTeacher(long teacherUserId)
        {
            return GetDataTable("SIM_Courses_GetByTeacher", "@TeacherUserID", teacherUserId);
        }

        /// <summary>
        /// Lấy thông tin khóa học theo ID (gọi store SIM_Courses_Get)
        /// </summary>
        public DataTable Get(long id, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_Get");
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin khóa học", objEx);
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
        /// Cập nhật khóa học (gọi store SIM_Courses_Update)
        /// </summary>
        public bool Update(string code, string title, string slug, string thumbnailUrl, string shortDescription, string description, long teacherId, long? categoryId, long? classSubjectId, string level, decimal passingScore, string status, long id, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_Update");
                objIData.AddParameter("@Code", code);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Slug", slug);
                objIData.AddParameter("@ThumbnailUrl", thumbnailUrl);
                objIData.AddParameter("@ShortDescription", shortDescription);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@TeacherId", teacherId);
                objIData.AddParameter("@CategoryId", categoryId);
                objIData.AddParameter("@ClassSubjectID", classSubjectId);
                objIData.AddParameter("@Level", level);
                objIData.AddParameter("@PassingScore", passingScore);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa học", objEx);
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
        /// Tạo mới khóa học (gọi store SIM_Courses_Create)
        /// </summary>
        public DataTable Create(string code, string title, string slug, string thumbnailUrl, string shortDescription, string description, long teacherId, long? categoryId, long? classSubjectId, string level, decimal passingScore, string status, long actorId)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_Create");
                objIData.AddParameter("@Code", code);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Slug", slug);
                objIData.AddParameter("@ThumbnailUrl", thumbnailUrl);
                objIData.AddParameter("@ShortDescription", shortDescription);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@TeacherId", teacherId);
                objIData.AddParameter("@CategoryId", categoryId);
                objIData.AddParameter("@ClassSubjectID", classSubjectId);
                objIData.AddParameter("@Level", level);
                objIData.AddParameter("@PassingScore", passingScore);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi tạo khóa học", objEx);
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
        /// Lấy nội dung đầy đủ của khóa học (chương và bài học) - trả về DataSet
        /// </summary>
        public DataSet GetContent(long courseId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_Content");
                objIData.AddParameter("@CourseId", courseId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataSet();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy nội dung khóa học", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        #region Enhanced Load Methods

        /// <summary>
        /// Load dữ liệu từ IDataReader vào object hiện tại.
        /// </summary>
        public bool LoadFromDataReader(IDataReader reader)
        {
            try
            {
                return Parse(reader);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong SIM_Courses", ex);
                return false;
            }
        }

        /// <summary>
        /// Load dữ liệu từ DataRow vào object hiện tại.
        /// </summary>
        public bool LoadFromDataRow(DataRow row)
        {
            try
            {
                if (row == null) return false;

                // Sử dụng Parse(DataRow) đã có trong Base class
                return Parse(row);
            }
            catch (Exception ex)
            {
                objErrorException = ex;
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong SIM_Courses", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load Course theo ID
        /// </summary>
        public static SIM_Courses LoadById(long courseId)
        {
            SIM_Courses course = new SIM_Courses();
            if (course.Get(courseId))
            {
                return course;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách Course theo CategoryID
        /// </summary>
        public static List<SIM_Courses> LoadByCategory(long categoryId)
        {
            SIM_Courses course = new SIM_Courses();
            DataTable dt = course.GetByCategory(categoryId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load danh sách Course theo TeacherUserID
        /// </summary>
        public static List<SIM_Courses> LoadByTeacher(long teacherUserId)
        {
            SIM_Courses course = new SIM_Courses();
            DataTable dt = course.GetByTeacher(teacherUserId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả Courses
        /// </summary>
        public static List<SIM_Courses> LoadAll()
        {
            SIM_Courses course = new SIM_Courses();
            DataTable dt = course.GetDataTable(course.StoreGetAll);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm Course với điều kiện tùy chỉnh
        /// </summary>
        public static List<SIM_Courses> Search(string condition)
        {
            SIM_Courses course = new SIM_Courses();
            DataTable dt = course.Search(condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Lấy danh sách khóa học (catalog) cho CMS
        /// </summary>
        public DataTable GetCatalog(int page, int pageSize)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_GetCatalog");
                objIData.AddParameter("@Page", page);
                objIData.AddParameter("@PageSize", pageSize);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy danh sách khóa học", objEx);
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
        /// Đảm bảo workspace cho môn học lớp tồn tại
        /// </summary>
        public DataTable EnsureWorkspace(long classSubjectId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_EnsureWorkspace");
                objIData.AddParameter("@ClassSubjectID", classSubjectId);
                objIData.AddParameter("@ActorID", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi khởi tạo workspace", objEx);
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
        /// Cập nhật thông tin khóa học
        /// </summary>
        public DataTable UpdateCourse(
            long id,
            string code,
            string title,
            string slug,
            string thumbnailUrl,
            string shortDescription,
            string description,
            long teacherId,
            object categoryId,
            object classSubjectId,
            string level,
            decimal passingScore,
            string status,
            long actorId,
            bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_Update");
                objIData.AddParameter("@Id", id);
                objIData.AddParameter("@Code", code);
                objIData.AddParameter("@Title", title);
                objIData.AddParameter("@Slug", slug);
                objIData.AddParameter("@ThumbnailUrl", thumbnailUrl);
                objIData.AddParameter("@ShortDescription", shortDescription);
                objIData.AddParameter("@Description", description);
                objIData.AddParameter("@TeacherId", teacherId);
                objIData.AddParameter("@CategoryId", categoryId);
                objIData.AddParameter("@ClassSubjectId", classSubjectId);
                objIData.AddParameter("@Level", level);
                objIData.AddParameter("@PassingScore", passingScore);
                objIData.AddParameter("@Status", status);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật khóa học", objEx);
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
        /// Lấy thông tin khóa học theo ID
        /// </summary>
        public DataTable GetCourseById(long courseId, long actorId, bool isAdmin)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Courses_Get");
                objIData.AddParameter("@Id", courseId);
                objIData.AddParameter("@ActorId", actorId);
                objIData.AddParameter("@IsAdmin", isAdmin);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin khóa học", objEx);
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
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(lngCourseID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static SIM_Courses CreateFromDataReader(IDataReader reader)
        {
            SIM_Courses course = new SIM_Courses();
            course.LoadFromDataReader(reader);
            return course;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static SIM_Courses CreateFromDataRow(DataRow row)
        {
            SIM_Courses course = new SIM_Courses();
            course.LoadFromDataRow(row);
            return course;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<SIM_Courses> FromDataTable(DataTable dt)
        {
            List<SIM_Courses> list = new List<SIM_Courses>();
            if (dt == null) return list;

            foreach (DataRow row in dt.Rows)
            {
                list.Add(CreateFromDataRow(row));
            }
            return list;
        }

        #endregion
    }
}
