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
    /// [SIM] Danh mục phân loại khóa học.
    /// </summary>
    public partial class SIM_CourseCategories
    {
        #region Member Variables

        private long lngCourseCategoryID = 0;//Khóa chính tự tăng của danh mục khóa học.
        private string strCode = null;//Mã duy nhất của danh mục khóa học.
        private string strName = null;//Tên hiển thị của danh mục khóa học.
        private string strDescription = null;//Mô tả nội dung của danh mục khóa học.
        private int intSortOrder = 0;//Thứ tự hiển thị của danh mục, số nhỏ hiển thị trước.
        private string strStatus = null;//Trạng thái sử dụng của danh mục khóa học.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// CourseCategoryID
        /// Khóa chính tự tăng của danh mục khóa học.
        /// </summary>
        public long CourseCategoryID
        {
            get { return lngCourseCategoryID; }
            set { lngCourseCategoryID = value; }
        }

        /// <summary>
        /// Code
        /// Mã duy nhất của danh mục khóa học.
        /// </summary>
        public string Code
        {
            get { return strCode; }
            set { strCode = value; }
        }

        /// <summary>
        /// Name
        /// Tên hiển thị của danh mục khóa học.
        /// </summary>
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// Description
        /// Mô tả nội dung của danh mục khóa học.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị của danh mục, số nhỏ hiển thị trước.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// Status
        /// Trạng thái sử dụng của danh mục khóa học.
        /// </summary>
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_CourseCategoryID.ToUpper()) && !Convert.IsDBNull(reader[C_CourseCategoryID])) this.lngCourseCategoryID = Convert.ToInt64(reader[C_CourseCategoryID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Code.ToUpper()) && !Convert.IsDBNull(reader[C_Code])) this.strCode = Convert.ToString(reader[C_Code]);
                    if (reader.GetName(i).ToUpper().Equals(C_Name.ToUpper()) && !Convert.IsDBNull(reader[C_Name])) this.strName = Convert.ToString(reader[C_Name]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_Status.ToUpper()) && !Convert.IsDBNull(reader[C_Status])) this.strStatus = Convert.ToString(reader[C_Status]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_CourseCategories", objEx);
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
                if (!Convert.IsDBNull(drw[C_CourseCategoryID])) this.lngCourseCategoryID = Convert.ToInt64(drw[C_CourseCategoryID]);
                if (!Convert.IsDBNull(drw[C_Code])) this.strCode = Convert.ToString(drw[C_Code]);
                if (!Convert.IsDBNull(drw[C_Name])) this.strName = Convert.ToString(drw[C_Name]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_Status])) this.strStatus = Convert.ToString(drw[C_Status]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_CourseCategories", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_CourseCategories_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_CourseCategoryID, this.lngCourseCategoryID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_CourseCategories", objEx);
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
        /// Store: SIM_CourseCategories_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngCourseCategoryID)
        {
            this.lngCourseCategoryID = lngCourseCategoryID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_CourseCategories_ADD
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
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_CourseCategories", objEx);
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
        /// Store: SIM_CourseCategories_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_CourseCategoryID, this.lngCourseCategoryID);
                objIData.AddParameter(P_Code, this.strCode);
                objIData.AddParameter(P_Name, this.strName);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_Status, this.strStatus);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_CourseCategories", objEx);
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
        /// Store: SIM_CourseCategories_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_CourseCategoryID, this.lngCourseCategoryID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_CourseCategories", objEx);
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
        /// Store: SIM_CourseCategories_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngCourseCategoryID)
        {
            this.lngCourseCategoryID = lngCourseCategoryID;
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

        public SIM_CourseCategories()
        {
        }
        public SIM_CourseCategories(long lngCourseCategoryID)
        {
            this.lngCourseCategoryID = lngCourseCategoryID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_CourseCategories";
        public const string StoreGet = "SIM_CourseCategories_GET";
        public const string StoreGetAll = "SIM_CourseCategories_GETALL";
        public const string StoreSearch = "SIM_CourseCategories_SEARCH";
        public const string StoreAdd = "SIM_CourseCategories_ADD";
        public const string StoreEdit = "SIM_CourseCategories_EDIT";
        public const string StoreDelete = "SIM_CourseCategories_DELETE";

        #region Parameter Names

        public const String P_CourseCategoryID = "@" + C_CourseCategoryID;
        public const String P_Code = "@" + C_Code;
        public const String P_Name = "@" + C_Name;
        public const String P_Description = "@" + C_Description;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_Status = "@" + C_Status;

        #endregion //Parameter names

        #region Column Names

        public const String C_CourseCategoryID = "CourseCategoryID";
        public const String C_Code = "Code";
        public const String C_Name = "Name";
        public const String C_Description = "Description";
        public const String C_SortOrder = "SortOrder";
        public const String C_Status = "Status";

        #endregion //Column names

        #endregion Variable Static
    }
}
