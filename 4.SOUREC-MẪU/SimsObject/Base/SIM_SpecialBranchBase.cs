
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// DCore: 17/06/2021  For Soft
    /// Created by 		: YourName 
    /// Created date 	: 16/07/2026 
    /// Description 
    /// </summary>	
    public partial class SIM_SpecialBranch
    {
        #region Member Variables

        private string strSpecialBranchID = null;//Mã chuyên ngành
        private string strSpecialBranchName = null;//Tên chuyên ngành
        private string strSpecialBranchShortName = null;//Tên viết tắt
        private string strBranchID = null;//Mã ngành
        private string strCreatedBy = null;
        private DateTime? dtmCreatedAt = null;//Ngày tạo
        private string strModifiedBy = null;//Người sửa
        private DateTime? dtmModifiedAt = null;//Ngày sửa
        private int? intLearningLevel = null;//Trình độ chương trình học 1. Sơ cấp, 2. Trung cấp, 3. Cao đẳng
        private string strSpecialBranchNameEn = null;//Tên chuyên ngành
        private decimal? decTienDongPhuc = null;//Tiền đồng phục , để in ở giấy báo nhập học
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// SpecialBranchID
        /// Mã chuyên ngành
        /// </summary>
        public string SpecialBranchID
        {
            get { return strSpecialBranchID; }
            set { strSpecialBranchID = value; }
        }
        /// <summary>
        /// SpecialBranchName
        /// Tên chuyên ngành
        /// </summary>
        public string SpecialBranchName
        {
            get { return strSpecialBranchName; }
            set { strSpecialBranchName = value; }
        }
        /// <summary>
        /// SpecialBranchShortName
        /// Tên viết tắt
        /// </summary>
        public string SpecialBranchShortName
        {
            get { return strSpecialBranchShortName; }
            set { strSpecialBranchShortName = value; }
        }
        /// <summary>
        /// BranchID
        /// Mã ngành
        /// </summary>
        public string BranchID
        {
            get { return strBranchID; }
            set { strBranchID = value; }
        }
        /// <summary>
        /// CreatedBy
        /// 
        /// </summary>
        public string CreatedBy
        {
            get { return strCreatedBy; }
            set { strCreatedBy = value; }
        }
        /// <summary>
        /// CreatedAt
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }
        /// <summary>
        /// ModifiedBy
        /// Người sửa
        /// </summary>
        public string ModifiedBy
        {
            get { return strModifiedBy; }
            set { strModifiedBy = value; }
        }
        /// <summary>
        /// ModifiedAt
        /// Ngày sửa
        /// </summary>
        public DateTime? ModifiedAt
        {
            get { return dtmModifiedAt; }
            set { dtmModifiedAt = value; }
        }
        /// <summary>
        /// LearningLevel
        /// Trình độ chương trình học 1. Sơ cấp, 2. Trung cấp, 3. Cao đẳng
        /// </summary>
        public int? LearningLevel
        {
            get { return intLearningLevel; }
            set { intLearningLevel = value; }
        }
        /// <summary>
        /// SpecialBranchNameEn
        /// Tên chuyên ngành
        /// </summary>
        public string SpecialBranchNameEn
        {
            get { return strSpecialBranchNameEn; }
            set { strSpecialBranchNameEn = value; }
        }
        /// <summary>
        /// TienDongPhuc
        /// Tiền đồng phục , để in ở giấy báo nhập học
        /// </summary>
        public decimal? TienDongPhuc
        {
            get { return decTienDongPhuc; }
            set { decTienDongPhuc = value; }
        }

        /// <summary>
        /// IData - Đối tượng IData truy xuất dữ liệu.
        ///	Nếu null thì các tác vụ của đối tượng tự tạo connect và depose mỗi khi được gọi				
        /// </summary>
        public IData IDB
        {
            get { return objIData; }
            set
            {
                objIData = value;
                bolIsExistIData = (value != null);
            }
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
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(reader[C_SpecialBranchID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchName.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchName])) this.strSpecialBranchName = Convert.ToString(reader[C_SpecialBranchName]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchShortName.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchShortName])) this.strSpecialBranchShortName = Convert.ToString(reader[C_SpecialBranchShortName]);
                    if (reader.GetName(i).ToUpper().Equals(C_BranchID.ToUpper()) && !Convert.IsDBNull(reader[C_BranchID])) this.strBranchID = Convert.ToString(reader[C_BranchID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedBy.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedBy])) this.strCreatedBy = Convert.ToString(reader[C_CreatedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_ModifiedBy.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(reader[C_ModifiedBy]);
                    if (reader.GetName(i).ToUpper().Equals(C_ModifiedAt.ToUpper()) && !Convert.IsDBNull(reader[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(reader[C_ModifiedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel])) this.intLearningLevel = Convert.ToInt32(reader[C_LearningLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchNameEn.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchNameEn])) this.strSpecialBranchNameEn = Convert.ToString(reader[C_SpecialBranchNameEn]);
                    if (reader.GetName(i).ToUpper().Equals(C_TienDongPhuc.ToUpper()) && !Convert.IsDBNull(reader[C_TienDongPhuc])) this.decTienDongPhuc = Convert.ToDecimal(reader[C_TienDongPhuc]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SpecialBranch", objEx);
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
                if (!Convert.IsDBNull(drw[C_SpecialBranchID])) this.strSpecialBranchID = Convert.ToString(drw[C_SpecialBranchID]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchName])) this.strSpecialBranchName = Convert.ToString(drw[C_SpecialBranchName]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchShortName])) this.strSpecialBranchShortName = Convert.ToString(drw[C_SpecialBranchShortName]);
                if (!Convert.IsDBNull(drw[C_BranchID])) this.strBranchID = Convert.ToString(drw[C_BranchID]);
                if (!Convert.IsDBNull(drw[C_CreatedBy])) this.strCreatedBy = Convert.ToString(drw[C_CreatedBy]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_ModifiedBy])) this.strModifiedBy = Convert.ToString(drw[C_ModifiedBy]);
                if (!Convert.IsDBNull(drw[C_ModifiedAt])) this.dtmModifiedAt = Convert.ToDateTime(drw[C_ModifiedAt]);
                if (!Convert.IsDBNull(drw[C_LearningLevel])) this.intLearningLevel = Convert.ToInt32(drw[C_LearningLevel]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchNameEn])) this.strSpecialBranchNameEn = Convert.ToString(drw[C_SpecialBranchNameEn]);
                if (!Convert.IsDBNull(drw[C_TienDongPhuc])) this.decTienDongPhuc = Convert.ToDecimal(drw[C_TienDongPhuc]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SpecialBranch", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_SpecialBranch_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SpecialBranch_GET");
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    if (Parse(reader))
                    {
                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SpecialBranch", objEx);
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
        /// Nạp thông tin item 
        /// Store: SIM_SpecialBranch_GET 
        ///</summary>
        /// <returns> SIM_SpecialBranch </returns>
        public SIM_SpecialBranch Get(string strSpecialBranchID)
        {
            SIM_SpecialBranch obj = new SIM_SpecialBranch();
            if (objIData != null)
                obj.IDB = objIData;
            obj.SpecialBranchID = strSpecialBranchID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_SpecialBranch
        /// Thực hiện store trả về true/false
        /// <returns> true/false </returns>
        ///</summary>
        public bool ExecNonQuery(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SpecialBranch", objEx);
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
        /// Search : SIM_SpecialBranch
        /// Tìm dữ liệu
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetDataTable(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SpecialBranch", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally
            {
                if (!bolIsExistIData)
                    objIData.Disconnect();
            }
        }

        ///<summary>
        /// Search : SIM_SpecialBranch
        /// Lấy hết dữ liệu
        /// Store: SIM_SpecialBranch_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_SpecialBranch_GETALL");
        }

        ///<summary>
        /// Search : SIM_SpecialBranch
        /// Tìm dữ liệu
        /// Store: SIM_SpecialBranch_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_SpecialBranch_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_SpecialBranch
        /// Thêm dữ liệu
        /// Store: SIM_SpecialBranch_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SpecialBranch_ADD");
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_SpecialBranchName, this.strSpecialBranchName);
                objIData.AddParameter(P_SpecialBranchShortName, this.strSpecialBranchShortName);
                objIData.AddParameter(P_BranchID, this.strBranchID);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
                objIData.AddParameter(P_LearningLevel, this.intLearningLevel);
                objIData.AddParameter(P_SpecialBranchNameEn, this.strSpecialBranchNameEn);
                objIData.AddParameter(P_TienDongPhuc, this.decTienDongPhuc);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SpecialBranch", objEx);
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
        /// Update : SIM_SpecialBranch
        /// Cập nhật dữ liệu
        /// Store: SIM_SpecialBranch_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SpecialBranch_EDIT");
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.AddParameter(P_SpecialBranchName, this.strSpecialBranchName);
                objIData.AddParameter(P_SpecialBranchShortName, this.strSpecialBranchShortName);
                objIData.AddParameter(P_BranchID, this.strBranchID);
                objIData.AddParameter(P_CreatedBy, this.strCreatedBy);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_ModifiedBy, this.strModifiedBy);
                objIData.AddParameter(P_ModifiedAt, this.dtmModifiedAt);
                objIData.AddParameter(P_LearningLevel, this.intLearningLevel);
                objIData.AddParameter(P_SpecialBranchNameEn, this.strSpecialBranchNameEn);
                objIData.AddParameter(P_TienDongPhuc, this.decTienDongPhuc);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SpecialBranch", objEx);
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
        /// Delete : SIM_SpecialBranch
        /// Xóa dữ liệu
        /// Store: SIM_SpecialBranch_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SpecialBranch_DELETE");
                objIData.AddParameter(P_SpecialBranchID, this.strSpecialBranchID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SpecialBranch", objEx);
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
        /// Store: SIM_SpecialBranch_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(string strSpecialBranchID)
        {
            this.strSpecialBranchID = strSpecialBranchID;
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

        public SIM_SpecialBranch()
        {
        }
        public SIM_SpecialBranch(string strSpecialBranchID)
        {
            this.strSpecialBranchID = strSpecialBranchID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_SpecialBranchID = "@" + C_SpecialBranchID;
        public const String P_SpecialBranchName = "@" + C_SpecialBranchName;
        public const String P_SpecialBranchShortName = "@" + C_SpecialBranchShortName;
        public const String P_BranchID = "@" + C_BranchID;
        public const String P_CreatedBy = "@" + C_CreatedBy;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_ModifiedBy = "@" + C_ModifiedBy;
        public const String P_ModifiedAt = "@" + C_ModifiedAt;
        public const String P_LearningLevel = "@" + C_LearningLevel;
        public const String P_SpecialBranchNameEn = "@" + C_SpecialBranchNameEn;
        public const String P_TienDongPhuc = "@" + C_TienDongPhuc;

        #endregion //Parameter names

        #region Column Names

        public const String C_SpecialBranchID = "SpecialBranchID";
        public const String C_SpecialBranchName = "SpecialBranchName";
        public const String C_SpecialBranchShortName = "SpecialBranchShortName";
        public const String C_BranchID = "BranchID";
        public const String C_CreatedBy = "CreatedBy";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_ModifiedBy = "ModifiedBy";
        public const String C_ModifiedAt = "ModifiedAt";
        public const String C_LearningLevel = "LearningLevel";
        public const String C_SpecialBranchNameEn = "SpecialBranchNameEn";
        public const String C_TienDongPhuc = "TienDongPhuc";

        #endregion //Column names

        #endregion Variable Static
    }
}


