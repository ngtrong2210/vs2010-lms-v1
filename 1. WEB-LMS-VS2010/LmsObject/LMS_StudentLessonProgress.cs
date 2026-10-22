using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_StudentLessonProgress. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_StudentLessonProgress
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy tiến độ bài học của học viên
        /// </summary>
        public DataTable GetByUserLesson(long userID, long lessonID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@LessonID", lessonID);
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
        /// Lấy tiến độ tất cả bài học của học viên trong khóa học
        /// </summary>
        public DataTable GetByUserCourse(long userID, long courseID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudentLessonProgress_GetByUserCourse");
                objIData.AddParameter("@UserID", userID);
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
        /// Cập nhật tiến độ hoàn thành bài học
        /// </summary>
        public bool UpdateProgress(long userID, long lessonID, decimal progressPercent, bool isCompleted)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_StudentLessonProgress_UpdateProgress");
                objIData.AddParameter("@UserID", userID);
                objIData.AddParameter("@LessonID", lessonID);
                objIData.AddParameter("@ProgressPercent", progressPercent);
                objIData.AddParameter("@IsCompleted", isCompleted);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_StudentLessonProgress", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_StudentLessonProgress", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load StudentLessonProgress theo ID
        /// </summary>
        public static LMS_StudentLessonProgress LoadById(long progressId)
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            if (progress.Get(progressId))
            {
                return progress;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load StudentLessonProgress theo UserID và LessonID
        /// </summary>
        public static LMS_StudentLessonProgress LoadByUserLesson(long userId, long lessonId)
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            DataTable dt = progress.GetByUserLesson(userId, lessonId);
            if (dt != null && dt.Rows.Count > 0)
            {
                progress.LoadFromDataRow(dt.Rows[0]);
                return progress;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách StudentLessonProgress theo UserID và CourseID
        /// </summary>
        public static List<LMS_StudentLessonProgress> LoadByUserCourse(long userId, long courseId)
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            DataTable dt = progress.GetByUserCourse(userId, courseId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả StudentLessonProgress
        /// </summary>
        public static List<LMS_StudentLessonProgress> LoadAll()
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            DataTable dt = progress.GetDataTable(progress.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm StudentLessonProgress với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_StudentLessonProgress> Search(string condition)
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            DataTable dt = progress.GetDataTable(progress.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(ProgressID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_StudentLessonProgress CreateFromDataReader(IDataReader reader)
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            progress.LoadFromDataReader(reader);
            return progress;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_StudentLessonProgress CreateFromDataRow(DataRow row)
        {
            LMS_StudentLessonProgress progress = new LMS_StudentLessonProgress();
            progress.LoadFromDataRow(row);
            return progress;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_StudentLessonProgress> FromDataTable(DataTable dt)
        {
            List<LMS_StudentLessonProgress> list = new List<LMS_StudentLessonProgress>();
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
