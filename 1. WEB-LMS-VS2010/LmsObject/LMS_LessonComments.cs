using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace LmsObject
{
    /// <summary>
    /// Phần mở rộng nghiệp vụ của LMS_LessonComments. Generator không ghi đè file này.
    /// </summary>
    public partial class LMS_LessonComments
    {
        #region Custom Data Access Methods

        /// <summary>
        /// Lấy bình luận theo bài học
        /// </summary>
        public DataTable GetByLesson(long lessonID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreSearch);
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
        /// Lấy bình luận theo người dùng
        /// </summary>
        public DataTable GetByUser(long userID)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("LMS_LessonComments_GetByUser");
                objIData.AddParameter("@UserID", userID);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return null;
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataReader trong LMS_LessonComments", ex);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi LoadFromDataRow trong LMS_LessonComments", ex);
                return false;
            }
        }

        /// <summary>
        /// Static factory: Load LessonComment theo ID
        /// </summary>
        public static LMS_LessonComments LoadById(long commentId)
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            if (comment.Get(commentId))
            {
                return comment;
            }
            return null;
        }

        /// <summary>
        /// Static factory: Load danh sách LessonComment theo LessonID
        /// </summary>
        public static List<LMS_LessonComments> LoadByLesson(long lessonId)
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            DataTable dt = comment.GetByLesson(lessonId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static factory: Load danh sách LessonComment theo UserID
        /// </summary>
        public static List<LMS_LessonComments> LoadByUser(long userId)
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            DataTable dt = comment.GetByUser(userId);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Load tất cả LessonComments
        /// </summary>
        public static List<LMS_LessonComments> LoadAll()
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            DataTable dt = comment.GetDataTable(comment.StoreSearch);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Static: Tìm kiếm LessonComment với điều kiện tùy chỉnh
        /// </summary>
        public static List<LMS_LessonComments> Search(string condition)
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            DataTable dt = comment.GetDataTable(comment.StoreSearch, condition);
            return FromDataTable(dt);
        }

        /// <summary>
        /// Alias cho method Get() - tải lại dữ liệu từ database
        /// </summary>
        public bool Load()
        {
            return Get(CommentID);
        }

        /// <summary>
        /// Static factory: Tạo instance từ IDataReader
        /// </summary>
        public static LMS_LessonComments CreateFromDataReader(IDataReader reader)
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            comment.LoadFromDataReader(reader);
            return comment;
        }

        /// <summary>
        /// Static factory: Tạo instance từ DataRow
        /// </summary>
        public static LMS_LessonComments CreateFromDataRow(DataRow row)
        {
            LMS_LessonComments comment = new LMS_LessonComments();
            comment.LoadFromDataRow(row);
            return comment;
        }

        /// <summary>
        /// Static converter: Chuyển DataTable sang List
        /// </summary>
        public static List<LMS_LessonComments> FromDataTable(DataTable dt)
        {
            List<LMS_LessonComments> list = new List<LMS_LessonComments>();
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
