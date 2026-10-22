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
