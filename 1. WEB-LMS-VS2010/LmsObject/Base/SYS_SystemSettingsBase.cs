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
    /// [SYS] Cấu hình vận hành và hiển thị dùng chung của hệ thống.
    /// </summary>
    public partial class SYS_SystemSettings
    {
        #region Member Variables

        private long lngSystemSettingID = 0;//Khóa chính định danh cấu hình hệ thống.
        private string strSettingKey = null;//Mã cấu hình duy nhất dùng trong mã nguồn và API.
        private string strSettingName = null;//Tên tiếng Việt hiển thị cho quản trị viên.
        private string strSettingValue = null;//Giá trị cấu hình được lưu dưới dạng chuỗi và diễn giải theo DataType.
        private string strDataType = null;//Kiểu dữ liệu của giá trị: TEXT, NUMBER, BOOLEAN, EMAIL hoặc URL.
        private string strCategory = null;//Nhóm cấu hình phục vụ phân loại trên giao diện.
        private string strDescription = null;//Mô tả ý nghĩa và phạm vi ảnh hưởng của cấu hình.
        private int intSortOrder = 0;//Thứ tự hiển thị cấu hình trong cùng nhóm.
        private bool bolIsPublic = false;//Cho biết cấu hình có được phép công khai cho giao diện người dùng hay không.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm cấu hình được tạo theo UTC.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cấu hình được cập nhật gần nhất theo UTC.
        private long? lngUpdatedByUserID = null;//Tài khoản quản trị cập nhật cấu hình gần nhất; liên kết SYS_Users.UserID.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// SystemSettingID
        /// Khóa chính định danh cấu hình hệ thống.
        /// </summary>
        public long SystemSettingID
        {
            get { return lngSystemSettingID; }
            set { lngSystemSettingID = value; }
        }

        /// <summary>
        /// SettingKey
        /// Mã cấu hình duy nhất dùng trong mã nguồn và API.
        /// </summary>
        public string SettingKey
        {
            get { return strSettingKey; }
            set { strSettingKey = value; }
        }

        /// <summary>
        /// SettingName
        /// Tên tiếng Việt hiển thị cho quản trị viên.
        /// </summary>
        public string SettingName
        {
            get { return strSettingName; }
            set { strSettingName = value; }
        }

        /// <summary>
        /// SettingValue
        /// Giá trị cấu hình được lưu dưới dạng chuỗi và diễn giải theo DataType.
        /// </summary>
        public string SettingValue
        {
            get { return strSettingValue; }
            set { strSettingValue = value; }
        }

        /// <summary>
        /// DataType
        /// Kiểu dữ liệu của giá trị: TEXT, NUMBER, BOOLEAN, EMAIL hoặc URL.
        /// </summary>
        public string DataType
        {
            get { return strDataType; }
            set { strDataType = value; }
        }

        /// <summary>
        /// Category
        /// Nhóm cấu hình phục vụ phân loại trên giao diện.
        /// </summary>
        public string Category
        {
            get { return strCategory; }
            set { strCategory = value; }
        }

        /// <summary>
        /// Description
        /// Mô tả ý nghĩa và phạm vi ảnh hưởng của cấu hình.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị cấu hình trong cùng nhóm.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// IsPublic
        /// Cho biết cấu hình có được phép công khai cho giao diện người dùng hay không.
        /// </summary>
        public bool IsPublic
        {
            get { return bolIsPublic; }
            set { bolIsPublic = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm cấu hình được tạo theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cấu hình được cập nhật gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
        }

        /// <summary>
        /// UpdatedByUserID
        /// Tài khoản quản trị cập nhật cấu hình gần nhất; liên kết SYS_Users.UserID.
        /// </summary>
        public long? UpdatedByUserID
        {
            get { return lngUpdatedByUserID; }
            set { lngUpdatedByUserID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_SystemSettingID.ToUpper()) && !Convert.IsDBNull(reader[C_SystemSettingID])) this.lngSystemSettingID = Convert.ToInt64(reader[C_SystemSettingID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SettingKey.ToUpper()) && !Convert.IsDBNull(reader[C_SettingKey])) this.strSettingKey = Convert.ToString(reader[C_SettingKey]);
                    if (reader.GetName(i).ToUpper().Equals(C_SettingName.ToUpper()) && !Convert.IsDBNull(reader[C_SettingName])) this.strSettingName = Convert.ToString(reader[C_SettingName]);
                    if (reader.GetName(i).ToUpper().Equals(C_SettingValue.ToUpper()) && !Convert.IsDBNull(reader[C_SettingValue])) this.strSettingValue = Convert.ToString(reader[C_SettingValue]);
                    if (reader.GetName(i).ToUpper().Equals(C_DataType.ToUpper()) && !Convert.IsDBNull(reader[C_DataType])) this.strDataType = Convert.ToString(reader[C_DataType]);
                    if (reader.GetName(i).ToUpper().Equals(C_Category.ToUpper()) && !Convert.IsDBNull(reader[C_Category])) this.strCategory = Convert.ToString(reader[C_Category]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsPublic.ToUpper()) && !Convert.IsDBNull(reader[C_IsPublic])) this.bolIsPublic = Convert.ToBoolean(reader[C_IsPublic]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(reader[C_UpdatedByUserID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_SystemSettings", objEx);
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
                if (!Convert.IsDBNull(drw[C_SystemSettingID])) this.lngSystemSettingID = Convert.ToInt64(drw[C_SystemSettingID]);
                if (!Convert.IsDBNull(drw[C_SettingKey])) this.strSettingKey = Convert.ToString(drw[C_SettingKey]);
                if (!Convert.IsDBNull(drw[C_SettingName])) this.strSettingName = Convert.ToString(drw[C_SettingName]);
                if (!Convert.IsDBNull(drw[C_SettingValue])) this.strSettingValue = Convert.ToString(drw[C_SettingValue]);
                if (!Convert.IsDBNull(drw[C_DataType])) this.strDataType = Convert.ToString(drw[C_DataType]);
                if (!Convert.IsDBNull(drw[C_Category])) this.strCategory = Convert.ToString(drw[C_Category]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_IsPublic])) this.bolIsPublic = Convert.ToBoolean(drw[C_IsPublic]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(drw[C_UpdatedByUserID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_SystemSettings", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_SystemSettings_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_SystemSettingID, this.lngSystemSettingID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_SystemSettings", objEx);
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
        /// Store: SYS_SystemSettings_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_SystemSettings Get(long lngSystemSettingID)
        {
            SYS_SystemSettings obj = new SYS_SystemSettings();
            if (objIData != null) obj.IDB = objIData;
            obj.SystemSettingID = lngSystemSettingID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_SystemSettings_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_SettingKey, this.strSettingKey);
                objIData.AddParameter(P_SettingName, this.strSettingName);
                objIData.AddParameter(P_SettingValue, this.strSettingValue);
                objIData.AddParameter(P_DataType, this.strDataType);
                objIData.AddParameter(P_Category, this.strCategory);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsPublic, this.bolIsPublic);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                this.lngSystemSettingID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_SystemSettings", objEx);
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
        /// Store: SYS_SystemSettings_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_SystemSettingID, this.lngSystemSettingID);
                objIData.AddParameter(P_SettingKey, this.strSettingKey);
                objIData.AddParameter(P_SettingName, this.strSettingName);
                objIData.AddParameter(P_SettingValue, this.strSettingValue);
                objIData.AddParameter(P_DataType, this.strDataType);
                objIData.AddParameter(P_Category, this.strCategory);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsPublic, this.bolIsPublic);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_SystemSettings", objEx);
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
        /// Store: SYS_SystemSettings_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_SystemSettingID, this.lngSystemSettingID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_SystemSettings", objEx);
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
        /// Store: SYS_SystemSettings_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngSystemSettingID)
        {
            this.lngSystemSettingID = lngSystemSettingID;
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

        public SYS_SystemSettings()
        {
        }
        public SYS_SystemSettings(long lngSystemSettingID)
        {
            this.lngSystemSettingID = lngSystemSettingID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_SystemSettings";
        public const string StoreGet = "SYS_SystemSettings_GET";
        public const string StoreGetAll = "SYS_SystemSettings_GETALL";
        public const string StoreSearch = "SYS_SystemSettings_SEARCH";
        public const string StoreAdd = "SYS_SystemSettings_ADD";
        public const string StoreEdit = "SYS_SystemSettings_EDIT";
        public const string StoreDelete = "SYS_SystemSettings_DELETE";

        #region Parameter Names

        public const String P_SystemSettingID = "@" + C_SystemSettingID;
        public const String P_SettingKey = "@" + C_SettingKey;
        public const String P_SettingName = "@" + C_SettingName;
        public const String P_SettingValue = "@" + C_SettingValue;
        public const String P_DataType = "@" + C_DataType;
        public const String P_Category = "@" + C_Category;
        public const String P_Description = "@" + C_Description;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_IsPublic = "@" + C_IsPublic;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;
        public const String P_UpdatedByUserID = "@" + C_UpdatedByUserID;

        #endregion //Parameter names

        #region Column Names

        public const String C_SystemSettingID = "SystemSettingID";
        public const String C_SettingKey = "SettingKey";
        public const String C_SettingName = "SettingName";
        public const String C_SettingValue = "SettingValue";
        public const String C_DataType = "DataType";
        public const String C_Category = "Category";
        public const String C_Description = "Description";
        public const String C_SortOrder = "SortOrder";
        public const String C_IsPublic = "IsPublic";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedAt = "UpdatedAt";
        public const String C_UpdatedByUserID = "UpdatedByUserID";

        #endregion //Column names

        #endregion Variable Static
    }
}
