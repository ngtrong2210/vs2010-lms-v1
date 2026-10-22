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
    /// [SYS] Danh mục cấp cao dùng phân loại quyền hệ thống.
    /// </summary>
    public partial class SYS_PermissionCategory
    {
        #region Member Variables

        private int intPermissionCategoryID = 0;//Cột PermissionCategoryID của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strPermissionCategoryName = null;//Cột PermissionCategoryName của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsDefault = false;//Cột IsDefault của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsActived = false;//Cột IsActived của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intSortOrder = 0;//Cột SortOrder của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// PermissionCategoryID
        /// Cột PermissionCategoryID của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int PermissionCategoryID
        {
            get { return intPermissionCategoryID; }
            set { intPermissionCategoryID = value; }
        }

        /// <summary>
        /// PermissionCategoryName
        /// Cột PermissionCategoryName của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string PermissionCategoryName
        {
            get { return strPermissionCategoryName; }
            set { strPermissionCategoryName = value; }
        }

        /// <summary>
        /// IsDefault
        /// Cột IsDefault của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public bool IsDefault
        {
            get { return bolIsDefault; }
            set { bolIsDefault = value; }
        }

        /// <summary>
        /// IsActived
        /// Cột IsActived của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }

        /// <summary>
        /// SortOrder
        /// Cột SortOrder của bảng SYS_PermissionCategory, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionCategoryID.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionCategoryID])) this.intPermissionCategoryID = Convert.ToInt32(reader[C_PermissionCategoryID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PermissionCategoryName.ToUpper()) && !Convert.IsDBNull(reader[C_PermissionCategoryName])) this.strPermissionCategoryName = Convert.ToString(reader[C_PermissionCategoryName]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDefault.ToUpper()) && !Convert.IsDBNull(reader[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(reader[C_IsDefault]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SYS_PermissionCategory", objEx);
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
                if (!Convert.IsDBNull(drw[C_PermissionCategoryID])) this.intPermissionCategoryID = Convert.ToInt32(drw[C_PermissionCategoryID]);
                if (!Convert.IsDBNull(drw[C_PermissionCategoryName])) this.strPermissionCategoryName = Convert.ToString(drw[C_PermissionCategoryName]);
                if (!Convert.IsDBNull(drw[C_IsDefault])) this.bolIsDefault = Convert.ToBoolean(drw[C_IsDefault]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SYS_PermissionCategory", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SYS_PermissionCategory_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SYS_PermissionCategory", objEx);
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
        /// Store: SYS_PermissionCategory_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public SYS_PermissionCategory Get(int intPermissionCategoryID)
        {
            SYS_PermissionCategory obj = new SYS_PermissionCategory();
            if (objIData != null) obj.IDB = objIData;
            obj.PermissionCategoryID = intPermissionCategoryID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SYS_PermissionCategory_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.AddParameter(P_PermissionCategoryName, this.strPermissionCategoryName);
                objIData.AddParameter(P_IsDefault, this.bolIsDefault);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SYS_PermissionCategory", objEx);
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
        /// Store: SYS_PermissionCategory_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.AddParameter(P_PermissionCategoryName, this.strPermissionCategoryName);
                objIData.AddParameter(P_IsDefault, this.bolIsDefault);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SYS_PermissionCategory", objEx);
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
        /// Store: SYS_PermissionCategory_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_PermissionCategoryID, this.intPermissionCategoryID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SYS_PermissionCategory", objEx);
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
        /// Store: SYS_PermissionCategory_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(int intPermissionCategoryID)
        {
            this.intPermissionCategoryID = intPermissionCategoryID;
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

        public SYS_PermissionCategory()
        {
        }
        public SYS_PermissionCategory(int intPermissionCategoryID)
        {
            this.intPermissionCategoryID = intPermissionCategoryID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SYS_PermissionCategory";
        public const string StoreGet = "SYS_PermissionCategory_GET";
        public const string StoreGetAll = "SYS_PermissionCategory_GETALL";
        public const string StoreSearch = "SYS_PermissionCategory_SEARCH";
        public const string StoreAdd = "SYS_PermissionCategory_ADD";
        public const string StoreEdit = "SYS_PermissionCategory_EDIT";
        public const string StoreDelete = "SYS_PermissionCategory_DELETE";

        #region Parameter Names

        public const String P_PermissionCategoryID = "@" + C_PermissionCategoryID;
        public const String P_PermissionCategoryName = "@" + C_PermissionCategoryName;
        public const String P_IsDefault = "@" + C_IsDefault;
        public const String P_IsActived = "@" + C_IsActived;
        public const String P_SortOrder = "@" + C_SortOrder;

        #endregion //Parameter names

        #region Column Names

        public const String C_PermissionCategoryID = "PermissionCategoryID";
        public const String C_PermissionCategoryName = "PermissionCategoryName";
        public const String C_IsDefault = "IsDefault";
        public const String C_IsActived = "IsActived";
        public const String C_SortOrder = "SortOrder";

        #endregion //Column names

        #endregion Variable Static
    }
}
