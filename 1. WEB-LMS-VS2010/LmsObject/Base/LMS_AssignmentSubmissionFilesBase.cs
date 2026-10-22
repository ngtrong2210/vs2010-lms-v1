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
    /// [LMS] Danh sách file đính kèm của từng lần nộp bài, tách khỏi metadata bài nộp.
    /// </summary>
    public partial class LMS_AssignmentSubmissionFiles
    {
        #region Member Variables

        private long lngAssignmentSubmissionFileID = 0;//Khóa chính của file thuộc một lần nộp bài.
        private long lngAssignmentSubmissionID = 0;//ID lần nộp bài sở hữu file.
        private string strOriginalFileName = null;//Tên file gốc do học viên tải lên.
        private string strStoredFileName = null;//Tên file GUID được lưu vật lý.
        private string strFileUrl = null;//Đường dẫn tương đối an toàn trong thư mục Media/File.
        private long lngFileSize = 0;//Kích thước file tính theo byte.
        private string strMimeType = null;//Kiểu nội dung MIME đã được máy chủ kiểm tra.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm metadata file được tạo theo UTC.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// AssignmentSubmissionFileID
        /// Khóa chính của file thuộc một lần nộp bài.
        /// </summary>
        public long AssignmentSubmissionFileID
        {
            get { return lngAssignmentSubmissionFileID; }
            set { lngAssignmentSubmissionFileID = value; }
        }

        /// <summary>
        /// AssignmentSubmissionID
        /// ID lần nộp bài sở hữu file.
        /// </summary>
        public long AssignmentSubmissionID
        {
            get { return lngAssignmentSubmissionID; }
            set { lngAssignmentSubmissionID = value; }
        }

        /// <summary>
        /// OriginalFileName
        /// Tên file gốc do học viên tải lên.
        /// </summary>
        public string OriginalFileName
        {
            get { return strOriginalFileName; }
            set { strOriginalFileName = value; }
        }

        /// <summary>
        /// StoredFileName
        /// Tên file GUID được lưu vật lý.
        /// </summary>
        public string StoredFileName
        {
            get { return strStoredFileName; }
            set { strStoredFileName = value; }
        }

        /// <summary>
        /// FileUrl
        /// Đường dẫn tương đối an toàn trong thư mục Media/File.
        /// </summary>
        public string FileUrl
        {
            get { return strFileUrl; }
            set { strFileUrl = value; }
        }

        /// <summary>
        /// FileSize
        /// Kích thước file tính theo byte.
        /// </summary>
        public long FileSize
        {
            get { return lngFileSize; }
            set { lngFileSize = value; }
        }

        /// <summary>
        /// MimeType
        /// Kiểu nội dung MIME đã được máy chủ kiểm tra.
        /// </summary>
        public string MimeType
        {
            get { return strMimeType; }
            set { strMimeType = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm metadata file được tạo theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_AssignmentSubmissionFileID.ToUpper()) && !Convert.IsDBNull(reader[C_AssignmentSubmissionFileID])) this.lngAssignmentSubmissionFileID = Convert.ToInt64(reader[C_AssignmentSubmissionFileID]);
                    if (reader.GetName(i).ToUpper().Equals(C_AssignmentSubmissionID.ToUpper()) && !Convert.IsDBNull(reader[C_AssignmentSubmissionID])) this.lngAssignmentSubmissionID = Convert.ToInt64(reader[C_AssignmentSubmissionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_OriginalFileName.ToUpper()) && !Convert.IsDBNull(reader[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(reader[C_OriginalFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_StoredFileName.ToUpper()) && !Convert.IsDBNull(reader[C_StoredFileName])) this.strStoredFileName = Convert.ToString(reader[C_StoredFileName]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileUrl.ToUpper()) && !Convert.IsDBNull(reader[C_FileUrl])) this.strFileUrl = Convert.ToString(reader[C_FileUrl]);
                    if (reader.GetName(i).ToUpper().Equals(C_FileSize.ToUpper()) && !Convert.IsDBNull(reader[C_FileSize])) this.lngFileSize = Convert.ToInt64(reader[C_FileSize]);
                    if (reader.GetName(i).ToUpper().Equals(C_MimeType.ToUpper()) && !Convert.IsDBNull(reader[C_MimeType])) this.strMimeType = Convert.ToString(reader[C_MimeType]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_AssignmentSubmissionFiles", objEx);
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
                if (!Convert.IsDBNull(drw[C_AssignmentSubmissionFileID])) this.lngAssignmentSubmissionFileID = Convert.ToInt64(drw[C_AssignmentSubmissionFileID]);
                if (!Convert.IsDBNull(drw[C_AssignmentSubmissionID])) this.lngAssignmentSubmissionID = Convert.ToInt64(drw[C_AssignmentSubmissionID]);
                if (!Convert.IsDBNull(drw[C_OriginalFileName])) this.strOriginalFileName = Convert.ToString(drw[C_OriginalFileName]);
                if (!Convert.IsDBNull(drw[C_StoredFileName])) this.strStoredFileName = Convert.ToString(drw[C_StoredFileName]);
                if (!Convert.IsDBNull(drw[C_FileUrl])) this.strFileUrl = Convert.ToString(drw[C_FileUrl]);
                if (!Convert.IsDBNull(drw[C_FileSize])) this.lngFileSize = Convert.ToInt64(drw[C_FileSize]);
                if (!Convert.IsDBNull(drw[C_MimeType])) this.strMimeType = Convert.ToString(drw[C_MimeType]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_AssignmentSubmissionFiles", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_AssignmentSubmissionFiles_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_AssignmentSubmissionFileID, this.lngAssignmentSubmissionFileID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_AssignmentSubmissionFiles", objEx);
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
        /// Store: LMS_AssignmentSubmissionFiles_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngAssignmentSubmissionFileID)
        {
            this.lngAssignmentSubmissionFileID = lngAssignmentSubmissionFileID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_AssignmentSubmissionFiles_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_AssignmentSubmissionID, this.lngAssignmentSubmissionID);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_StoredFileName, this.strStoredFileName);
                objIData.AddParameter(P_FileUrl, this.strFileUrl);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_AssignmentSubmissionFiles", objEx);
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
        /// Store: LMS_AssignmentSubmissionFiles_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_AssignmentSubmissionFileID, this.lngAssignmentSubmissionFileID);
                objIData.AddParameter(P_AssignmentSubmissionID, this.lngAssignmentSubmissionID);
                objIData.AddParameter(P_OriginalFileName, this.strOriginalFileName);
                objIData.AddParameter(P_StoredFileName, this.strStoredFileName);
                objIData.AddParameter(P_FileUrl, this.strFileUrl);
                objIData.AddParameter(P_FileSize, this.lngFileSize);
                objIData.AddParameter(P_MimeType, this.strMimeType);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_AssignmentSubmissionFiles", objEx);
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
        /// Store: LMS_AssignmentSubmissionFiles_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_AssignmentSubmissionFileID, this.lngAssignmentSubmissionFileID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_AssignmentSubmissionFiles", objEx);
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
        /// Store: LMS_AssignmentSubmissionFiles_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngAssignmentSubmissionFileID)
        {
            this.lngAssignmentSubmissionFileID = lngAssignmentSubmissionFileID;
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

        public LMS_AssignmentSubmissionFiles()
        {
        }
        public LMS_AssignmentSubmissionFiles(long lngAssignmentSubmissionFileID)
        {
            this.lngAssignmentSubmissionFileID = lngAssignmentSubmissionFileID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_AssignmentSubmissionFiles";
        public const string StoreGet = "LMS_AssignmentSubmissionFiles_GET";
        public const string StoreGetAll = "LMS_AssignmentSubmissionFiles_GETALL";
        public const string StoreSearch = "LMS_AssignmentSubmissionFiles_SEARCH";
        public const string StoreAdd = "LMS_AssignmentSubmissionFiles_ADD";
        public const string StoreEdit = "LMS_AssignmentSubmissionFiles_EDIT";
        public const string StoreDelete = "LMS_AssignmentSubmissionFiles_DELETE";

        #region Parameter Names

        public const String P_AssignmentSubmissionFileID = "@" + C_AssignmentSubmissionFileID;
        public const String P_AssignmentSubmissionID = "@" + C_AssignmentSubmissionID;
        public const String P_OriginalFileName = "@" + C_OriginalFileName;
        public const String P_StoredFileName = "@" + C_StoredFileName;
        public const String P_FileUrl = "@" + C_FileUrl;
        public const String P_FileSize = "@" + C_FileSize;
        public const String P_MimeType = "@" + C_MimeType;
        public const String P_CreatedAt = "@" + C_CreatedAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_AssignmentSubmissionFileID = "AssignmentSubmissionFileID";
        public const String C_AssignmentSubmissionID = "AssignmentSubmissionID";
        public const String C_OriginalFileName = "OriginalFileName";
        public const String C_StoredFileName = "StoredFileName";
        public const String C_FileUrl = "FileUrl";
        public const String C_FileSize = "FileSize";
        public const String C_MimeType = "MimeType";
        public const String C_CreatedAt = "CreatedAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
