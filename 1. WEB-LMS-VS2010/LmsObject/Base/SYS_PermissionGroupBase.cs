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
    /// [SYS] Nhóm quyền nghiệp vụ nằm trong một danh mục quyền.
    /// </summary>
    public partial class SYS_PermissionGroup
    {
        #region Member Variables

        private string strPermissionGroupID = null;//Cột PermissionGroupID của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strPermissionGroupName = null;//Cột PermissionGroupName của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intPermissionCategoryID = 0;//Cột PermissionCategoryID của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intSortOrder = 0;//Cột SortOrder của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsActived = false;//Cột IsActived của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// PermissionGroupID
        /// Cột PermissionGroupID của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string PermissionGroupID
        {
            get { return strPermissionGroupID; }
            set { strPermissionGroupID = value; }
        }

        /// <summary>
        /// PermissionGroupName
        /// Cột PermissionGroupName của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string PermissionGroupName
        {
            get { return strPermissionGroupName; }
            set { strPermissionGroupName = value; }
        }

        /// <summary>
        /// PermissionCategoryID
        /// Cột PermissionCategoryID của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int PermissionCategoryID
        {
            get { return intPermissionCategoryID; }
            set { intPermissionCategoryID = value; }
        }

        /// <summary>
        /// SortOrder
        /// Cột SortOrder của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// IsActived
        /// Cột IsActived của bảng SYS_PermissionGroup, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionGroupID])) this.strPermissionGroupID = Convert.ToString(reader[C_PermissionGroupID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionGroupName.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionGroupName])) this.strPermissionGroupName = Convert.ToString(reader[C_PermissionGroupName]);
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionCategoryID.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionCategoryID])) this.intPermissionCategoryID = Convert.ToInt32(reader[C_PermissionCategoryID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_PermissionGroup", objEx);
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
                if (!Convert.IsDBNull(drw[C_PermissionGroupID])) this.strPermissionGroupID = Convert.ToString(drw[C_PermissionGroupID]);
                if (!Convert.IsDBNull(drw[C_PermissionGroupName])) this.strPermissionGroupName = Convert.ToString(drw[C_PermissionGroupName]);
                if (!Convert.IsDBNull(drw[C_PermissionCategoryID])) this.intPermissionCategoryID = Convert.ToInt32(drw[C_PermissionCategoryID]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_PermissionGroup", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_PermissionGroup_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_PermissionGroupID, this.strPermissionGroupID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_PermissionGroup", objEx);
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
        /// Store: SYS_PermissionGroup_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_PermissionGroup Get(string strPermissionGroupID)
        {
            SYS_PermissionGroup obj = new SYS_PermissionGroup();
            if (objIData != null) obj.IDB = objIData;
            obj.PermissionGroupID = strPermissionGroupID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_PermissionGroup_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_PermissionGroupID, this.strPermissionGroupID);
                objIData.AddParameter(P_PermissionGroupName, this.strPermissionGroupName);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_PermissionGroup", objEx);
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
        /// Store: SYS_PermissionGroup_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_PermissionGroupID, this.strPermissionGroupID);
                objIData.AddParameter(P_PermissionGroupName, this.strPermissionGroupName);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_PermissionGroup", objEx);
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
        /// Store: SYS_PermissionGroup_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_PermissionGroupID, this.strPermissionGroupID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_PermissionGroup", objEx);
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
        /// Store: SYS_PermissionGroup_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(string strPermissionGroupID)
        {
            this.strPermissionGroupID = strPermissionGroupID;
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

        public SYS_PermissionGroup()
        {
        }
        public SYS_PermissionGroup(string strPermissionGroupID)
        {
            this.strPermissionGroupID = strPermissionGroupID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_PermissionGroup";
        public const string StoreGet = "SYS_PermissionGroup_GET";
        public const string StoreGetAll = "SYS_PermissionGroup_GETALL";
        public const string StoreSearch = "SYS_PermissionGroup_SEARCH";
        public const string StoreAdd = "SYS_PermissionGroup_ADD";
        public const string StoreEdit = "SYS_PermissionGroup_EDIT";
        public const string StoreDelete = "SYS_PermissionGroup_DELETE";

        #region Parameter Names

        public const String P_PermissionGroupID = "@" + C_PermissionGroupID;
        public const String P_PermissionGroupName = "@" + C_PermissionGroupName;
        public const String P_PermissionCategoryID = "@" + C_PermissionCategoryID;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_IsActived = "@" + C_IsActived;

        #endregion //Parameter names

        #region Column Names

        public const String C_PermissionGroupID = "PermissionGroupID";
        public const String C_PermissionGroupName = "PermissionGroupName";
        public const String C_PermissionCategoryID = "PermissionCategoryID";
        public const String C_SortOrder = "SortOrder";
        public const String C_IsActived = "IsActived";

        #endregion //Column names

        #endregion Variable Static
    }
}
