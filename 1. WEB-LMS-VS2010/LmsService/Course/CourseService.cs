using System;
using System.Data;
using LmsObject;

namespace LmsService.Course
{
    // Partial class cho CourseService - chứa static utility methods
    // Base class ModuleService nằm trong LmsService.CourseService
    public static partial class CourseService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    SIM_Courses obj = new SIM_Courses();
                    dtbTable = obj.GetDataTable("SIM_Courses_SEARCHCBX");
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0);
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }

        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }

        #region UI Helpers

        public static void InitDropDownList(System.Web.UI.WebControls.DropDownList ddl, string condition = "")
        {
            DataTable dtbCopy = null;
            if (!string.IsNullOrEmpty(condition))
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ") or " + SIM_Courses.C_CourseID + " is null";
            }
            else
            {
                dtbCopy = Table;
            }

            ddl.DataSource = dtbCopy;
            ddl.DataTextField = SIM_Courses.C_Title;
            ddl.DataValueField = SIM_Courses.C_CourseID;
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Chọn khóa học--", ""));
        }

        #endregion

        #region Business Logic

        public static bool CreateCourse(string code, string title, string slug, string thumbnailUrl, string shortDescription, string description, long teacherUserId, long? courseCategoryId, string level, decimal passingScore, long createdByUserId, int dataGroupId, long? classSubjectId)
        {
            SIM_Courses obj = new SIM_Courses();
            obj.Code = code;
            obj.Title = title;
            obj.Slug = slug;
            obj.ThumbnailUrl = thumbnailUrl;
            obj.ShortDescription = shortDescription;
            obj.Description = description;
            obj.TeacherUserID = teacherUserId;
            obj.CourseCategoryID = courseCategoryId;
            obj.Level = level;
            obj.PassingScore = passingScore;
            obj.Status = "DRAFT";
            obj.CreatedAt = DateTime.UtcNow;
            obj.CreatedByUserID = createdByUserId;
            obj.IsDeleted = false;
            obj.DataGroupID = dataGroupId;
            obj.ClassSubjectID = classSubjectId;

            bool result = obj.Add();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool UpdateCourse(long courseId, string code, string title, string slug, string thumbnailUrl, string shortDescription, string description, long teacherUserId, long? courseCategoryId, string level, decimal passingScore, string status, long? updatedByUserId, int dataGroupId, long? classSubjectId)
        {
            SIM_Courses obj = new SIM_Courses();
            obj.CourseID = courseId;
            if (!obj.Get())
                return false;

            obj.Code = code;
            obj.Title = title;
            obj.Slug = slug;
            obj.ThumbnailUrl = thumbnailUrl;
            obj.ShortDescription = shortDescription;
            obj.Description = description;
            obj.TeacherUserID = teacherUserId;
            obj.CourseCategoryID = courseCategoryId;
            obj.Level = level;
            obj.PassingScore = passingScore;
            obj.Status = status;
            obj.UpdatedAt = DateTime.UtcNow;
            obj.UpdatedByUserID = updatedByUserId;
            obj.DataGroupID = dataGroupId;
            obj.ClassSubjectID = classSubjectId;

            bool result = obj.Update();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool DeleteCourse(long courseId)
        {
            SIM_Courses obj = new SIM_Courses();
            obj.CourseID = courseId;
            bool result = obj.Delete();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool PublishCourse(long courseId)
        {
            SIM_Courses obj = new SIM_Courses();
            obj.CourseID = courseId;
            if (!obj.Get())
                return false;

            bool result = obj.Publish();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool ArchiveCourse(long courseId)
        {
            SIM_Courses obj = new SIM_Courses();
            obj.CourseID = courseId;
            if (!obj.Get())
                return false;

            bool result = obj.Archive();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static DataTable GetCourseList(string condition = "")
        {
            SIM_Courses obj = new SIM_Courses();
            if (string.IsNullOrEmpty(condition))
                return obj.GetDataTable("SIM_Courses_SEARCHCBX");
            else
                return obj.Search(condition);
        }

        public static DataTable GetCourseByCategory(long categoryId)
        {
            SIM_Courses obj = new SIM_Courses();
            return obj.GetByCategory(categoryId);
        }

        public static DataTable GetCourseByTeacher(long teacherUserId)
        {
            SIM_Courses obj = new SIM_Courses();
            return obj.GetByTeacher(teacherUserId);
        }

        #endregion
    }
}
