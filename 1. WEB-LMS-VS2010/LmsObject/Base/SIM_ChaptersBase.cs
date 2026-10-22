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
    /// [SIM] Các chương nội dung thuộc khóa học.
    /// </summary>
    public partial class SIM_Chapters
    {
        #region Member Variables

        private long lngChapterID = 0;//Khóa chính tự tăng của chương.
        private long lngCourseId = 0;//ID khóa học chứa chương.
        private string strTitle = null;//Tên hiển thị của chương.
        private string strDescription = null;//Mô tả nội dung của chương.
        private int intSortOrder = 0;//Thứ tự hiển thị của chương trong khóa học.
        private string strStatus = null;//Trạng thái sử dụng của chương.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo chương theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật chương gần nhất theo UTC.
        private bool bolIsDeleted = false;//Cờ xóa mềm của chương.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// ChapterID
        /// Khóa chính tự tăng của chương.
        /// </summary>
        public long ChapterID
        {
            get { return lngChapterID; }
            set { lngChapterID = value; }
        }

        /// <summary>
        /// CourseId
        /// ID khóa học chứa chương.
        /// </summary>
        public long CourseId
        {
            get { return lngCourseId; }
            set { lngCourseId = value; }
        }

        /// <summary>
        /// Title
        /// Tên hiển thị của chương.
        /// </summary>
        public string Title
        {
            get { return strTitle; }
            set { strTitle = value; }
        }

        /// <summary>
        /// Description
        /// Mô tả nội dung của chương.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị của chương trong khóa học.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của chương.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo chương theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật chương gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của chương.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_ChapterID.ToUpper()) && !Convert.IsDBNull(reader[C_ChapterID])) this.lngChapterID = Convert.ToInt64(reader[C_ChapterID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CourseId.ToUpper()) && !Convert.IsDBNull(reader[C_CourseId])) this.lngCourseId = Convert.ToInt64(reader[C_CourseId]);
                    if (reader.GetName(i).ToUpper().Equals(C_Title.ToUpper()) && !Convert.IsDBNull(reader[C_Title])) this.strTitle = Convert.ToString(reader[C_Title]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Chapters", objEx);
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
                if (!Convert.IsDBNull(drw[C_ChapterID])) this.lngChapterID = Convert.ToInt64(drw[C_ChapterID]);
                if (!Convert.IsDBNull(drw[C_CourseId])) this.lngCourseId = Convert.ToInt64(drw[C_CourseId]);
                if (!Convert.IsDBNull(drw[C_Title])) this.strTitle = Convert.ToString(drw[C_Title]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Chapters", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_Chapters_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_Chapters", objEx);
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
        /// Store: SIM_Chapters_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngChapterID)
        {
            this.lngChapterID = lngChapterID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_Chapters_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_Chapters", objEx);
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
        /// Store: SIM_Chapters_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
                objIData.AddParameter(P_CourseId, this.lngCourseId);
                objIData.AddParameter(P_Title, this.strTitle);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Chapters", objEx);
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
        /// Store: SIM_Chapters_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_ChapterID, this.lngChapterID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Chapters", objEx);
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
        /// Store: SIM_Chapters_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngChapterID)
        {
            this.lngChapterID = lngChapterID;
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

        public SIM_Chapters()
        {
        }
        public SIM_Chapters(long lngChapterID)
        {
            this.lngChapterID = lngChapterID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Chapters";
        public const string StoreGet = "SIM_Chapters_GET";
        public const string StoreGetAll = "SIM_Chapters_GETALL";
        public const string StoreSearch = "SIM_Chapters_SEARCH";
        public const string StoreAdd = "SIM_Chapters_ADD";
        public const string StoreEdit = "SIM_Chapters_EDIT";
        public const string StoreDelete = "SIM_Chapters_DELETE";

        #region Parameter Names

        public const String P_ChapterID = "@" + C_ChapterID;
        public const String P_CourseId = "@" + C_CourseId;
        public const String P_Title = "@" + C_Title;
        public const String P_Description = "@" + C_Description;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_Status = "@" + C_Status;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_IsDeleted = "@" + C_IsDeleted;

        #endregion //Parameter names

        #region Column Names

        public const String C_ChapterID = "ChapterID";
        public const String C_CourseId = "CourseId";
        public const String C_Title = "Title";
        public const String C_Description = "Description";
        public const String C_SortOrder = "SortOrder";
        public const String C_Status = "Status";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_IsDeleted = "IsDeleted";

        #endregion //Column names

        #endregion Variable Static
    }
}
