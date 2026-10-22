using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của SIM_Lessons. Generator không ghi đè file này.
    /// </summary>
    public partial class SIM_Lessons
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy danh sách bài học theo khóa học
        /// </summary>
        public DataTable GetByCourse(long courseID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@CourseID", courseID);
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
        /// Lấy danh sách bài học theo chương
        /// </summary>
        public DataTable GetByChapter(long chapterID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_GetByChapter");
                objIData.AddParameter("@ChapterID", chapterID);
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
        /// Lấy bài học theo loại
        /// </summary>
        public DataTable GetByType(string lessonType)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_GetByType");
                objIData.AddParameter("@LessonType", lessonType);
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
        /// Cập nhật thứ tự bài học
        /// </summary>
        public bool UpdateSortOrder(long lessonID, int sortOrder)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Lessons_UpdateSortOrder");
                objIData.AddParameter("@LessonID", lessonID);
                objIData.AddParameter("@SortOrder", sortOrder);
                objIData.ExecStoreToDataTable();
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion
    }
}
