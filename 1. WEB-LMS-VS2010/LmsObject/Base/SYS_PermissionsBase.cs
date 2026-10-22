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
    /// [SYS] Danh mục quyền thao tác theo từng phân hệ.
    /// </summary>
    public partial class SYS_Permissions
    {
        #region Member Variables

        private long lngPermissionID = 0;//Khóa chính tự tăng của quyền.
        private string strCode = null;//Mã kỹ thuật duy nhất của quyền.
        private string strName = null;//Tên hiển thị của quyền.
        private string strModule = null;//Tên phân hệ chức năng sở hữu quyền.
        private string strDescription = null;//Mô tả thao tác mà quyền cho phép thực hiện.
        private int? intPermissionCategoryID = null;//Mã danh mục quyền chứa quyền chức năng này.
        private string strPermissionGroupID = null;//Mã nhóm quyền nghiệp vụ chứa quyền chức năng này.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// PermissionID
        /// Khóa chính tự tăng của quyền.
        /// </summary>
        public long PermissionID
        {
            get { return lngPermissionID; }
            set { lngPermissionID = value; }
        }

        /// <summary>
        /// Code
        /// Mã kỹ thuật duy nhất của quyền.
        /// </summary>
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        /// <summary>
        /// Name
        /// Tên hiển thị của quyền.
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Module
        /// Tên phân hệ chức năng sở hữu quyền.
        /// </summary>
        public string Module
        {
            get { return strModule; }
            set { strModule = value; }
        }

        /// <summary>
        /// Description
        /// Mô tả thao tác mà quyền cho phép thực hiện.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// PermissionCategoryID
        /// Mã danh mục quyền chứa quyền chức năng này.
        /// </summary>
        public int? PermissionCategoryID
        {
            get { return intPermissionCategoryID; }
            set { intPermissionCategoryID = value; }
        }

        /// <summary>
        /// PermissionGroupID
        /// Mã nhóm quyền nghiệp vụ chứa quyền chức năng này.
        /// </summary>
        public string PermissionGroupID
        {
            get { return strPermissionGroupID; }
            set { strPermissionGroupID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionID.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionID])) this.lngPermissionID = Convert.ToInt64(reader[C_PermissionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Code.ToUpper()) && !Convert.IsDBNull(reader[C_Code])) this.strCode = Convert.ToString(reader[C_Code]);
                    if (reader.GetName(i).ToUpper().Equals(C_Name.ToUpper()) && !Convert.IsDBNull(reader[C_Name])) this.strName = Convert.ToString(reader[C_Name]);
                    if (reader.GetName(i).ToUpper().Equals(C_Module.ToUpper()) && !Convert.IsDBNull(reader[C_Module])) this.strModule = Convert.ToString(reader[C_Module]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionCategoryID.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionCategoryID])) this.intPermissionCategoryID = Convert.ToInt32(reader[C_PermissionCategoryID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionGroupID])) this.strPermissionGroupID = Convert.ToString(reader[C_PermissionGroupID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_Permissions", objEx);
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
                if (!Convert.IsDBNull(drw[C_PermissionID])) this.lngPermissionID = Convert.ToInt64(drw[C_PermissionID]);
                if (!Convert.IsDBNull(drw[C_Code])) this.strCode = Convert.ToString(drw[C_Code]);
                if (!Convert.IsDBNull(drw[C_Name])) this.strName = Convert.ToString(drw[C_Name]);
                if (!Convert.IsDBNull(drw[C_Module])) this.strModule = Convert.ToString(drw[C_Module]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_PermissionCategoryID])) this.intPermissionCategoryID = Convert.ToInt32(drw[C_PermissionCategoryID]);
                if (!Convert.IsDBNull(drw[C_PermissionGroupID])) this.strPermissionGroupID = Convert.ToString(drw[C_PermissionGroupID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_Permissions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_Permissions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_PermissionID, this.lngPermissionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_Permissions", objEx);
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
        /// Store: SYS_Permissions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_Permissions Get(long lngPermissionID)
        {
            SYS_Permissions obj = new SYS_Permissions();
            if (objIData != null) obj.IDB = objIData;
            obj.PermissionID = lngPermissionID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_Permissions_ADD
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
                objIData.AddParameter(P_Name, this.strName);
                objIData.AddParameter(P_Module, this.strModule);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.AddParameter(P_PermissionGroupID, this.strPermissionGroupID);
                this.lngPermissionID = Convert.ToInt64(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_Permissions", objEx);
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
        /// Store: SYS_Permissions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_PermissionID, this.lngPermissionID);
                objIData.AddParameter(P_Code, this.strCode);
                objIData.AddParameter(P_Name, this.strName);
                objIData.AddParameter(P_Module, this.strModule);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.AddParameter(P_PermissionGroupID, this.strPermissionGroupID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_Permissions", objEx);
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
        /// Store: SYS_Permissions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_PermissionID, this.lngPermissionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_Permissions", objEx);
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
        /// Store: SYS_Permissions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngPermissionID)
        {
            this.lngPermissionID = lngPermissionID;
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

        public SYS_Permissions()
        {
        }
        public SYS_Permissions(long lngPermissionID)
        {
            this.lngPermissionID = lngPermissionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_Permissions";
        public const string StoreGet = "SYS_Permissions_GET";
        public const string StoreGetAll = "SYS_Permissions_GETALL";
        public const string StoreSearch = "SYS_Permissions_SEARCH";
        public const string StoreAdd = "SYS_Permissions_ADD";
        public const string StoreEdit = "SYS_Permissions_EDIT";
        public const string StoreDelete = "SYS_Permissions_DELETE";

        #region Parameter Names

        public const String P_PermissionID = "@" + C_PermissionID;
        public const String P_Code = "@" + C_Code;
        public const String P_Name = "@" + C_Name;
        public const String P_Module = "@" + C_Module;
        public const String P_Description = "@" + C_Description;
        public const String P_PermissionCategoryID = "@" + C_PermissionCategoryID;
        public const String P_PermissionGroupID = "@" + C_PermissionGroupID;

        #endregion //Parameter names

        #region Column Names

        public const String C_PermissionID = "PermissionID";
        public const String C_Code = "Code";
        public const String C_Name = "Name";
        public const String C_Module = "Module";
        public const String C_Description = "Description";
        public const String C_PermissionCategoryID = "PermissionCategoryID";
        public const String C_PermissionGroupID = "PermissionGroupID";

        #endregion //Column names

        #endregion Variable Static
    }
}
