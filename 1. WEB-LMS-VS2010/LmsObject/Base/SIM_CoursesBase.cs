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
    /// [SIM] Thông tin tổng quan và trạng thái xuất bản của khóa học.
    /// </summary>
    public partial class SIM_Courses
    {
        #region Member Variables

        private long lngCourseID = 0;//Khóa chính tự tăng của khóa học.
        private string strCode = null;//Mã nghiệp vụ duy nhất của khóa học.
        private string strTitle = null;//Tên hiển thị của khóa học.
        private string strSlug = null;//Chuỗi định danh thân thiện dùng trong đường dẫn URL.
        private string strThumbnailUrl = null;//Đường dẫn ảnh đại diện của khóa học.
        private string strShortDescription = null;//Mô tả ngắn dùng tại danh sách và thẻ khóa học.
        private string strDescription = null;//Nội dung giới thiệu chi tiết của khóa học.
        private long lngTeacherUserID = 0;//ID giảng viên phụ trách khóa học.
        private long? lngCourseCategoryID = null;//ID danh mục của khóa học; có thể chưa phân loại.
        private string strLevel = null;//Cấp độ kiến thức của khóa học.
        private decimal decPassingScore = 0;//Điểm tối thiểu theo thang 100 để đạt khóa học.
        private string strStatus = null;//Trạng thái khóa học: DRAFT, PUBLISHED hoặc ARCHIVED.
        private DateTime? dtmPublishedAt = null;//Thời điểm khóa học được xuất bản theo UTC.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo khóa học theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật khóa học gần nhất theo UTC.
        private long lngCreatedByUserID = 0;//ID người dùng tạo khóa học.
        private long? lngUpdatedByUserID = null;//ID người dùng cập nhật khóa học gần nhất.
        private bool bolIsDeleted = false;//Cờ xóa mềm của khóa học.
        private int intDataGroupID = 0;//Mã đơn vị sở hữu không gian học trực tuyến.
        private long? lngClassSubjectID = null;//Mã môn học lớp được liên kết với không gian học trực tuyến này.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// CourseID
        /// Khóa chính tự tăng của khóa học.
        /// </summary>
        public long CourseID
        {
            get { return lngCourseID; }
            set { lngCourseID = value; }
        }

        /// <summary>
        /// Code
        /// Mã nghiệp vụ duy nhất của khóa học.
        /// </summary>
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        /// <summary>
        /// Title
        /// Tên hiển thị của khóa học.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// Slug
        /// Chuỗi định danh thân thiện dùng trong đường dẫn URL.
        /// </summary>
        public string Slug
        {
            get { return strSlug; }
            set { strSlug = value; }
        }

        /// <summary>
        /// ThumbnailUrl
        /// Đường dẫn ảnh đại diện của khóa học.
        /// </summary>
        public string ThumbnailUrl
        {
            get { return strThumbnailUrl; }
            set { strThumbnailUrl = value; }
        }

        /// <summary>
        /// ShortDescription
        /// Mô tả ngắn dùng tại danh sách và thẻ khóa học.
        /// </summary>
        public string ShortDescription
        {
            get { return strShortDescription; }
            set { strShortDescription = value; }
        }

        /// <summary>
        /// Description
        /// Nội dung giới thiệu chi tiết của khóa học.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// TeacherUserID
        /// ID giảng viên phụ trách khóa học.
        /// </summary>
        public long TeacherUserID
        {
            get { return lngTeacherUserID; }
            set { lngTeacherUserID = value; }
        }

        /// <summary>
        /// CourseCategoryID
        /// ID danh mục của khóa học; có thể chưa phân loại.
        /// </summary>
        public long? CourseCategoryID
        {
            get { return lngCourseCategoryID; }
            set { lngCourseCategoryID = value; }
        }

        /// <summary>
        /// Level
        /// Cấp độ kiến thức của khóa học.
        /// </summary>
        public string Level
        {
            get { return strLevel; }
            set { strLevel = value; }
        }

        /// <summary>
        /// PassingScore
        /// Điểm tối thiểu theo thang 100 để đạt khóa học.
        /// </summary>
        public decimal PassingScore
        {
            get { return decPassingScore; }
            set { decPassingScore = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái khóa học: DRAFT, PUBLISHED hoặc ARCHIVED.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// PublishedAt
        /// Thời điểm khóa học được xuất bản theo UTC.
        /// </summary>
        public DateTime? PublishedAt
        {
            get { return dtmPublishedAt; }
            set { dtmPublishedAt = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo khóa học theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật khóa học gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// ID người dùng tạo khóa học.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// UpdatedByUserID
        /// ID người dùng cập nhật khóa học gần nhất.
        /// </summary>
        public long? UpdatedByUserID
        {
            get { return lngUpdatedByUserID; }
            set { lngUpdatedByUserID = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của khóa học.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }

        /// <summary>
        /// DataGroupID
        /// Mã đơn vị sở hữu không gian học trực tuyến.
        /// </summary>
        public int DataGroupID
        {
            get { return intDataGroupID; }
            set { intDataGroupID = value; }
        }

        /// <summary>
        /// ClassSubjectID
        /// Mã môn học lớp được liên kết với không gian học trực tuyến này.
        /// </summary>
        public long? ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_CourseID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseID])) this.lngCourseID = Convert.ToInt64(reader[C_CourseID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Code.ToUpper()) && !Convert.IsDBNull(reader[C_Code])) this.strCode = Convert.ToString(reader[C_Code]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_Slug.ToUpper()) && !Convert.IsDBNull(reader[C_Slug])) this.strSlug = Convert.ToString(reader[C_Slug]);
                    if (reader.GetName(i).ToUpper().Equals(C_ThumbnailUrl.ToUpper()) && !Convert.IsDBNull(reader[C_ThumbnailUrl])) this.strThumbnailUrl = Convert.ToString(reader[C_ThumbnailUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShortDescription.ToUpper()) && !Convert.IsDBNull(reader[C_ShortDescription])) this.strShortDescription = Convert.ToString(reader[C_ShortDescription]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherUserID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherUserID])) this.lngTeacherUserID = Convert.ToInt64(reader[C_TeacherUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseCategoryID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseCategoryID])) this.lngCourseCategoryID = Convert.ToInt64(reader[C_CourseCategoryID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Level.ToUpper()) && !Convert.IsDBNull(reader[C_Level])) this.strLevel = Convert.ToString(reader[C_Level]);
                    if (reader.GetName(i).ToUpper().Equals(C_PassingScore.ToUpper()) && !Convert.IsDBNull(reader[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(reader[C_PassingScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_PublishedAt.ToUpper()) && !Convert.IsDBNull(reader[C_PublishedAt])) this.dtmPublishedAt = Convert.ToDateTime(reader[C_PublishedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(reader[C_UpdatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DataGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(reader[C_DataGroupID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Courses", objEx);
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
                if (!Convert.IsDBNull(drw[C_CourseID])) this.lngCourseID = Convert.ToInt64(drw[C_CourseID]);
                if (!Convert.IsDBNull(drw[C_Code])) this.strCode = Convert.ToString(drw[C_Code]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_Slug])) this.strSlug = Convert.ToString(drw[C_Slug]);
                if (!Convert.IsDBNull(drw[C_ThumbnailUrl])) this.strThumbnailUrl = Convert.ToString(drw[C_ThumbnailUrl]);
                if (!Convert.IsDBNull(drw[C_ShortDescription])) this.strShortDescription = Convert.ToString(drw[C_ShortDescription]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_TeacherUserID])) this.lngTeacherUserID = Convert.ToInt64(drw[C_TeacherUserID]);
                if (!Convert.IsDBNull(drw[C_CourseCategoryID])) this.lngCourseCategoryID = Convert.ToInt64(drw[C_CourseCategoryID]);
                if (!Convert.IsDBNull(drw[C_Level])) this.strLevel = Convert.ToString(drw[C_Level]);
                if (!Convert.IsDBNull(drw[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(drw[C_PassingScore]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_PublishedAt])) this.dtmPublishedAt = Convert.ToDateTime(drw[C_PublishedAt]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(drw[C_UpdatedByUserID]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(drw[C_DataGroupID]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Courses", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_Courses_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_Courses", objEx);
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
        /// Store: SIM_Courses_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngCourseID)
        {
            this.lngCourseID = lngCourseID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_Courses_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_Code, this.strCode);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Slug, this.strSlug);
                objIData.AddParameter(P_ThumbnailUrl, this.strThumbnailUrl);
                objIData.AddParameter(P_ShortDescription, this.strShortDescription);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_TeacherUserID, this.lngTeacherUserID);
                objIData.AddParameter(P_CourseCategoryID, this.lngCourseCategoryID);
                objIData.AddParameter(P_Level, this.strLevel);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_PublishedAt, this.dtmPublishedAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_Courses", objEx);
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
        /// Store: SIM_Courses_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.AddParameter(P_Code, this.strCode);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Slug, this.strSlug);
                objIData.AddParameter(P_ThumbnailUrl, this.strThumbnailUrl);
                objIData.AddParameter(P_ShortDescription, this.strShortDescription);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_TeacherUserID, this.lngTeacherUserID);
                objIData.AddParameter(P_CourseCategoryID, this.lngCourseCategoryID);
                objIData.AddParameter(P_Level, this.strLevel);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_PublishedAt, this.dtmPublishedAt);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Courses", objEx);
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
        /// Store: SIM_Courses_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_CourseID, this.lngCourseID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Courses", objEx);
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
        /// Store: SIM_Courses_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngCourseID)
        {
            this.lngCourseID = lngCourseID;
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

        public SIM_Courses()
        {
        }
        public SIM_Courses(long lngCourseID)
        {
            this.lngCourseID = lngCourseID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Courses";
        public const string StoreGet = "SIM_Courses_GET";
        public const string StoreGetAll = "SIM_Courses_GETALL";
        public const string StoreSearch = "SIM_Courses_SEARCH";
        public const string StoreAdd = "SIM_Courses_ADD";
        public const string StoreEdit = "SIM_Courses_EDIT";
        public const string StoreDelete = "SIM_Courses_DELETE";

        #region Parameter Names

        public const String P_CourseID = "@" + C_CourseID;
        public const String P_Code = "@" + C_Code;
        public const String P_Title = "@" + C_Title;
        public const String P_Slug = "@" + C_Slug;
        public const String P_ThumbnailUrl = "@" + C_ThumbnailUrl;
        public const String P_ShortDescription = "@" + C_ShortDescription;
        public const String P_Description = "@" + C_Description;
        public const String P_TeacherUserID = "@" + C_TeacherUserID;
        public const String P_CourseCategoryID = "@" + C_CourseCategoryID;
        public const String P_Level = "@" + C_Level;
        public const String P_PassingScore = "@" + C_PassingScore;
        public const String P_Status = "@" + C_Status;
        public const String P_PublishedAt = "@" + C_PublishedAt;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_UpdatedByUserID = "@" + C_UpdatedByUserID;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DataGroupID = "@" + C_DataGroupID;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;

        #endregion //Parameter names

        #region Column Names

        public const String C_CourseID = "CourseID";
        public const String C_Code = "Code";
        public const String C_Title = "Title";
        public const String C_Slug = "Slug";
        public const String C_ThumbnailUrl = "ThumbnailUrl";
        public const String C_ShortDescription = "ShortDescription";
        public const String C_Description = "Description";
        public const String C_TeacherUserID = "TeacherUserID";
        public const String C_CourseCategoryID = "CourseCategoryID";
        public const String C_Level = "Level";
        public const String C_PassingScore = "PassingScore";
        public const String C_Status = "Status";
        public const String C_PublishedAt = "PublishedAt";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_UpdatedByUserID = "UpdatedByUserID";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_DataGroupID = "DataGroupID";
        public const String C_ClassSubjectID = "ClassSubjectID";

        #endregion //Column names

        #endregion Variable Static
    }
}
