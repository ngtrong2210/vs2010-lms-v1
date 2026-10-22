#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace LmsObject
{
    /// <summary>
    /// Created by 		: Generator
    /// Created date 	: 2025
    /// [LMS] Lưu thảo luận của bài học và các câu trả lời lồng nhau bằng quan hệ tự tham chiếu.
    /// </summary>
    public partial class LMS_LessonComments
    {
        #region Member Variables

        private long lngLessonCommentID = 0;//Khóa chính tự tăng của bình luận bài học.
        private long lngCourseID = 0;//Khóa học chứa bài học được bình luận.
        private long lngLessonID = 0;//Bài học chứa luồng thảo luận.
        private long lngUserID = 0;//Tài khoản tạo bình luận hoặc câu trả lời.
        private long? lngParentCommentID = null;//Bình luận cha; rỗng nghĩa là bình luận gốc.
        private string strContent = null;//Nội dung bình luận dạng văn bản thuần, tối đa 5000 ký tự.
        private bool bolIsEdited = false;//Đánh dấu nội dung đã được tác giả chỉnh sửa.
        private DateTime dtmCreatedDate = DateTime.MinValue;//Thời điểm UTC tạo bình luận.
        private DateTime? dtmUpdatedDate = null;//Thời điểm UTC cập nhật nội dung gần nhất.
        private bool bolIsDeleted = false;//Đánh dấu xóa mềm để giữ nguyên chuỗi trả lời.
        private DateTime? dtmDeletedDate = null;//Thời điểm UTC xóa mềm bình luận.
        private long? lngDeletedUserID = null;//Tài khoản thực hiện xóa mềm bình luận.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// LessonCommentID
        /// Khóa chính tự tăng của bình luận bài học.
        /// </summary>
        public long LessonCommentID
        {
            get { return lngLessonCommentID; }
            set { lngLessonCommentID = value; }
        }

        /// <summary>
        /// CourseID
        /// Khóa học chứa bài học được bình luận.
        /// </summary>
        public long CourseID
        {
            get { return lngCourseID; }
            set { lngCourseID = value; }
        }

        /// <summary>
        /// LessonID
        /// Bài học chứa luồng thảo luận.
        /// </summary>
        public long LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
        }

        /// <summary>
        /// UserID
        /// Tài khoản tạo bình luận hoặc câu trả lời.
        /// </summary>
        public long UserID
        {
            get { return lngUserID; }
            set { lngUserID = value; }
        }

        /// <summary>
        /// ParentCommentID
        /// Bình luận cha; rỗng nghĩa là bình luận gốc.
        /// </summary>
        public long? ParentCommentID
        {
            get { return lngParentCommentID; }
            set { lngParentCommentID = value; }
        }

        /// <summary>
        /// Content
        /// Nội dung bình luận dạng văn bản thuần, tối đa 5000 ký tự.
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }

        /// <summary>
        /// IsEdited
        /// Đánh dấu nội dung đã được tác giả chỉnh sửa.
        /// </summary>
        public bool IsEdited
        {
            get { return bolIsEdited; }
            set { bolIsEdited = value; }
        }

        /// <summary>
        /// CreatedDate
        /// Thời điểm UTC tạo bình luận.
        /// </summary>
        public DateTime CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }

        /// <summary>
        /// UpdatedDate
        /// Thời điểm UTC cập nhật nội dung gần nhất.
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Đánh dấu xóa mềm để giữ nguyên chuỗi trả lời.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// DeletedDate
        /// Thời điểm UTC xóa mềm bình luận.
        /// </summary>
        public DateTime? DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }

        /// <summary>
        /// DeletedUserID
        /// Tài khoản thực hiện xóa mềm bình luận.
        /// </summary>
        public long? DeletedUserID
        {
            get { return lngDeletedUserID; }
            set { lngDeletedUserID = value; }
        }

        /// <summary>
        /// IData - Đối tượng IData truy xuất dữ liệu.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi
        /// </summary>
        public IData IDB
        {
            get { return objIData; }
            set { objIData = value; bolIsExistIData = (value != null); }
        }

        /// <summary>
        /// ErrorException - Đối tượng lỗi nhận trả về khi method được thực thi.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi
        /// </summary>
        public Exception ErrorException
        {
            get { return objErrorException; }
            set { objErrorException = value; }
        }

        #endregion

        #region Methods

        ///<summary>
        /// Chuyển từ một IDataReader thành đối tượng
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Parse(IDataReader reader)
        {
            try
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).ToUpper().Equals(C_LessonCommentID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonCommentID])) this.lngLessonCommentID = Convert.ToInt64(reader[C_LessonCommentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.lngCourseID = Convert.ToInt64(reader[C_CourseID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UserID.ToUpper()) && !Convert.IsDBNull(reader[C_UserID])) this.lngUserID = Convert.ToInt64(reader[C_UserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ParentCommentID.ToUpper()) && !Convert.IsDBNull(reader[C_ParentCommentID])) this.lngParentCommentID = Convert.ToInt64(reader[C_ParentCommentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Content.ToUpper()) && !Convert.IsDBNull(reader[C_Content])) this.strContent = Convert.ToString(reader[C_Content]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsEdited.ToUpper()) && !Convert.IsDBNull(reader[C_IsEdited])) this.bolIsEdited = Convert.ToBoolean(reader[C_IsEdited]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedUserID.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUserID])) this.lngDeletedUserID = Convert.ToInt64(reader[C_DeletedUserID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_LessonComments", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Chuyển từ một DataRow thành đối tượng
        ///</summary>
        /// <returns>true ? Có : False? Không</returns>
        public bool Parse(DataRow drw)
        {
            try
            {
                if (!Convert.IsDBNull(drw[C_LessonCommentID])) this.lngLessonCommentID = Convert.ToInt64(drw[C_LessonCommentID]);
                if (!Convert.IsDBNull(drw[C_CourseID])) this.lngCourseID = Convert.ToInt64(drw[C_CourseID]);
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_UserID])) this.lngUserID = Convert.ToInt64(drw[C_UserID]);
                if (!Convert.IsDBNull(drw[C_ParentCommentID])) this.lngParentCommentID = Convert.ToInt64(drw[C_ParentCommentID]);
                if (!Convert.IsDBNull(drw[C_Content])) this.strContent = Convert.ToString(drw[C_Content]);
                if (!Convert.IsDBNull(drw[C_IsEdited])) this.bolIsEdited = Convert.ToBoolean(drw[C_IsEdited]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
                if (!Convert.IsDBNull(drw[C_DeletedUserID])) this.lngDeletedUserID = Convert.ToInt64(drw[C_DeletedUserID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_LessonComments", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_LessonComments_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_LessonCommentID, this.lngLessonCommentID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    this.Parse(reader);
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_LessonComments", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_LessonComments_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngLessonCommentID)
        {
            this.lngLessonCommentID = lngLessonCommentID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_LessonComments_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_UserID, this.lngUserID);
                objIData.AddParameter(P_ParentCommentID, this.lngParentCommentID);
                objIData.AddParameter(P_Content, this.strContent);
                objIData.AddParameter(P_IsEdited, this.bolIsEdited);
                objIData.AddParameter(P_CreatedDate, this.dtmCreatedDate);
                objIData.AddParameter(P_UpdatedDate, this.dtmUpdatedDate);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_DeletedDate, this.dtmDeletedDate);
                objIData.AddParameter(P_DeletedUserID, this.lngDeletedUserID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_LessonComments", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Cập nhật dữ liệu
        /// Store: LMS_LessonComments_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_LessonCommentID, this.lngLessonCommentID);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_UserID, this.lngUserID);
                objIData.AddParameter(P_ParentCommentID, this.lngParentCommentID);
                objIData.AddParameter(P_Content, this.strContent);
                objIData.AddParameter(P_IsEdited, this.bolIsEdited);
                objIData.AddParameter(P_CreatedDate, this.dtmCreatedDate);
                objIData.AddParameter(P_UpdatedDate, this.dtmUpdatedDate);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_DeletedDate, this.dtmDeletedDate);
                objIData.AddParameter(P_DeletedUserID, this.lngDeletedUserID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_LessonComments", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Xóa dữ liệu
        /// Store: LMS_LessonComments_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_LessonCommentID, this.lngLessonCommentID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_LessonComments", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        ///Xóa dữ liệu
        /// Store: LMS_LessonComments_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngLessonCommentID)
        {
            this.lngLessonCommentID = lngLessonCommentID;
            return this.Delete();
        }

        #endregion

        #region Transaction methods

        ///<summary>
        /// Bắt đầu một Transaction.
        ///</summary>
        /// <returns> true: ket noi thanh con; false: khong ket noi duoc </returns>
        public bool BeginTransaction()
        {
            objIData = DCore.Data.CreateData();
            try
            {
                objIData.Connect();
                objIData.BeginTransaction();
                bolIsExistIData = true;
                return true;
            }
            catch (Exception objEx)
            {
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Hoàn thành một Transaction.
        ///</summary>
        public void CommitTransaction()
        {
            objIData.CommitTransaction();
            objIData.Disconnect();
            bolIsExistIData = false;
        }

        ///<summary>
        /// Rollback một Transaction.
        ///</summary>
        public void RollBackTransaction()
        {
            objIData.RollBackTransaction();
            objIData.Disconnect();
            bolIsExistIData = false;
        }

        #endregion

        #region Constructor

        public LMS_LessonComments()
        {
        }
        public LMS_LessonComments(long lngLessonCommentID)
        {
            this.lngLessonCommentID = lngLessonCommentID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_LessonComments";
        public const string StoreGet = "LMS_LessonComments_GET";
        public const string StoreGetAll = "LMS_LessonComments_GETALL";
        public const string StoreSearch = "LMS_LessonComments_SEARCH";
        public const string StoreAdd = "LMS_LessonComments_ADD";
        public const string StoreEdit = "LMS_LessonComments_EDIT";
        public const string StoreDelete = "LMS_LessonComments_DELETE";

        #region Parameter Names

        public const String P_LessonCommentID = "@" + C_LessonCommentID;
        public const String P_CourseID = "@" + C_CourseID;
        public const String P_LessonID = "@" + C_LessonID;
        public const String P_UserID = "@" + C_UserID;
        public const String P_ParentCommentID = "@" + C_ParentCommentID;
        public const String P_Content = "@" + C_Content;
        public const String P_IsEdited = "@" + C_IsEdited;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DeletedDate = "@" + C_DeletedDate;
        public const String P_DeletedUserID = "@" + C_DeletedUserID;

        #endregion //Parameter names

        #region Column Names

        public const String C_LessonCommentID = "LessonCommentID";
        public const String C_CourseID = "CourseID";
        public const String C_LessonID = "LessonID";
        public const String C_UserID = "UserID";
        public const String C_ParentCommentID = "ParentCommentID";
        public const String C_Content = "Content";
        public const String C_IsEdited = "IsEdited";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_DeletedDate = "DeletedDate";
        public const String C_DeletedUserID = "DeletedUserID";

        #endregion //Column names

        #endregion Variable Static
    }
}
