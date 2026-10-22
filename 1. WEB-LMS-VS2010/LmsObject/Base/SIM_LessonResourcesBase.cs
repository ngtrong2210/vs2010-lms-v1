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
    /// [SIM] Các file, tài liệu hoặc liên kết đính kèm cho bài học.
    /// </summary>
    public partial class SIM_LessonResources
    {
        #region Member Variables

        private long lngLessonResourceID = 0;//Cột LessonResourceID của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngLessonID = 0;//Cột LessonID của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strResourceType = null;//Cột ResourceType của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strResourceName = null;//Cột ResourceName của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strResourceUrl = null;//Cột ResourceUrl của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strOriginalFileName = null;//Cột OriginalFileName của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long? lngFileSize = null;//Cột FileSize của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strMimeType = null;//Cột MimeType của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intSortOrder = 0;//Cột SortOrder của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngCreatedByUserID = 0;//Cột CreatedByUserID của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Cột CreatedAt của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsDeleted = false;//Cột IsDeleted của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// LessonResourceID
        /// Cột LessonResourceID của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long LessonResourceID
        {
            get { return lngLessonResourceID; }
            set { lngLessonResourceID = value; }
        }

        /// <summary>
        /// LessonID
        /// Cột LessonID của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
        }

        /// <summary>
        /// ResourceType
        /// Cột ResourceType của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string ResourceType
        {
            get { return strResourceType; }
            set { strResourceType = value; }
        }

        /// <summary>
        /// ResourceName
        /// Cột ResourceName của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string ResourceName
        {
            get { return strResourceName; }
            set { strResourceName = value; }
        }

        /// <summary>
        /// ResourceUrl
        /// Cột ResourceUrl của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string ResourceUrl
        {
            get { return strResourceUrl; }
            set { strResourceUrl = value; }
        }

        /// <summary>
        /// OriginalFileName
        /// Cột OriginalFileName của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string OriginalFileName
        {
            get { return strOriginalFileName; }
            set { strOriginalFileName = value; }
        }

        /// <summary>
        /// FileSize
        /// Cột FileSize của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long? FileSize
        {
            get { return lngFileSize; }
            set { lngFileSize = value; }
        }

        /// <summary>
        /// MimeType
        /// Cột MimeType của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string MimeType
        {
            get { return strMimeType; }
            set { strMimeType = value; }
        }

        /// <summary>
        /// SortOrder
        /// Cột SortOrder của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// Cột CreatedByUserID của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Cột CreatedAt của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cột IsDeleted của bảng SIM_LessonResources, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
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
                    if (reader.GetName(i).ToUpper().Equals(C_LessonResourceID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonResourceID])) this.lngLessonResourceID = Convert.ToInt64(reader[C_LessonResourceID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ResourceType.ToUpper()) && !Convert.IsDBNull(reader[C_ResourceType])) this.strResourceType = Convert.ToString(reader[C_ResourceType]);
                    if (reader.GetName(i).ToUpper().Equals(C_ResourceName.ToUpper()) && !Convert.IsDBNull(reader[C_ResourceName])) this.strResourceName = Convert.ToString(reader[C_ResourceName]);
                    if (reader.GetName(i).ToUpper().Equals(C_ResourceUrl.ToUpper()) && !Convert.IsDBNull(reader[C_ResourceUrl])) this.strResourceUrl = Convert.ToString(reader[C_ResourceUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_OriginalFileName.ToUpper()) && !Convert.IsDBNull(reader[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(reader[C_OriginalFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
                    if (reader.GetName(i).ToUpper().Equals(C_MimeType.ToUpper()) && !Convert.IsDBNull(reader[C_MimeType])) this.strMimeType = Convert.ToString(reader[C_MimeType]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_LessonResources", objEx);
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
                if (!Convert.IsDBNull(drw[C_LessonResourceID])) this.lngLessonResourceID = Convert.ToInt64(drw[C_LessonResourceID]);
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_ResourceType])) this.strResourceType = Convert.ToString(drw[C_ResourceType]);
                if (!Convert.IsDBNull(drw[C_ResourceName])) this.strResourceName = Convert.ToString(drw[C_ResourceName]);
                if (!Convert.IsDBNull(drw[C_ResourceUrl])) this.strResourceUrl = Convert.ToString(drw[C_ResourceUrl]);
                if (!Convert.IsDBNull(drw[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(drw[C_OriginalFileName]);
                if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
                if (!Convert.IsDBNull(drw[C_MimeType])) this.strMimeType = Convert.ToString(drw[C_MimeType]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_LessonResources", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_LessonResources_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_LessonResourceID, this.lngLessonResourceID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_LessonResources", objEx);
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
        /// Store: SIM_LessonResources_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngLessonResourceID)
        {
            this.lngLessonResourceID = lngLessonResourceID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_LessonResources_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_ResourceType, this.strResourceType);
                objIData.AddParameter(P_ResourceName, this.strResourceName);
                objIData.AddParameter(P_ResourceUrl, this.strResourceUrl);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_LessonResources", objEx);
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
        /// Store: SIM_LessonResources_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_LessonResourceID, this.lngLessonResourceID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_ResourceType, this.strResourceType);
                objIData.AddParameter(P_ResourceName, this.strResourceName);
                objIData.AddParameter(P_ResourceUrl, this.strResourceUrl);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_LessonResources", objEx);
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
        /// Store: SIM_LessonResources_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_LessonResourceID, this.lngLessonResourceID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_LessonResources", objEx);
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
        /// Store: SIM_LessonResources_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngLessonResourceID)
        {
            this.lngLessonResourceID = lngLessonResourceID;
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

        public SIM_LessonResources()
        {
        }
        public SIM_LessonResources(long lngLessonResourceID)
        {
            this.lngLessonResourceID = lngLessonResourceID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_LessonResources";
        public const string StoreGet = "SIM_LessonResources_GET";
        public const string StoreGetAll = "SIM_LessonResources_GETALL";
        public const string StoreSearch = "SIM_LessonResources_SEARCH";
        public const string StoreAdd = "SIM_LessonResources_ADD";
        public const string StoreEdit = "SIM_LessonResources_EDIT";
        public const string StoreDelete = "SIM_LessonResources_DELETE";

        #region Parameter Names

        public const String P_LessonResourceID = "@" + C_LessonResourceID;
        public const String P_LessonID = "@" + C_LessonID;
        public const String P_ResourceType = "@" + C_ResourceType;
        public const String P_ResourceName = "@" + C_ResourceName;
        public const String P_ResourceUrl = "@" + C_ResourceUrl;
        public const String P_OriginalFileName = "@" + C_OriginalFileName;
        public const String P_FileSize = "@" + C_FileSize;
        public const String P_MimeType = "@" + C_MimeType;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_IsDeleted = "@" + C_IsDeleted;

        #endregion //Parameter names

        #region Column Names

        public const String C_LessonResourceID = "LessonResourceID";
        public const String C_LessonID = "LessonID";
        public const String C_ResourceType = "ResourceType";
        public const String C_ResourceName = "ResourceName";
        public const String C_ResourceUrl = "ResourceUrl";
        public const String C_OriginalFileName = "OriginalFileName";
        public const String C_FileSize = "FileSize";
        public const String C_MimeType = "MimeType";
        public const String C_SortOrder = "SortOrder";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_IsDeleted = "IsDeleted";

        #endregion //Column names

        #endregion Variable Static
    }
}
