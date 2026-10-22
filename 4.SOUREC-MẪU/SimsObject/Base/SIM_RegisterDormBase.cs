
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// Created by 		: YourName 
    /// Created date 	: 11/11/2012 
    /// Description 
    /// </summary>	
    public partial class SIM_RegisterDorm
    {
        #region Member Variables

        private long? lngRegisterDormID = null;
        private long? lngStudentID = null;
        private string strDormBedID = null;
        private DateTime? dtmStartDate = null;
        private DateTime? dtmEndDate = null;
        private int? intRegisterDormType = null;
        private bool bolIsLeft = false;//Đã trả phòng
        private string strDescription = null;
        private string strCreatedUser = null;
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strUpdatedUser = null;//Người sửa
        private DateTime? dtmUpdatedDate = null;//Ngày sửa
        private bool bolIsDeleted = false;
        private DateTime? dtmDeletedDate = null;
        private string strDeletedUser = null;
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// RegisterDormID
        /// 
        /// </summary>
        public long? RegisterDormID
        {
            get { return lngRegisterDormID; }
            set { lngRegisterDormID = value; }
        }
        /// <summary>
        /// StudentID
        /// 
        /// </summary>
        public long? StudentID
        {
            get { return lngStudentID; }
            set { lngStudentID = value; }
        }
        /// <summary>
        /// DormBedID
        /// 
        /// </summary>
        public string DormBedID
        {
            get { return strDormBedID; }
            set { strDormBedID = value; }
        }
        /// <summary>
        /// StartDate
        /// 
        /// </summary>
        public DateTime? StartDate
        {
            get { return dtmStartDate; }
            set { dtmStartDate = value; }
        }
        /// <summary>
        /// EndDate
        /// 
        /// </summary>
        public DateTime? EndDate
        {
            get { return dtmEndDate; }
            set { dtmEndDate = value; }
        }
        /// <summary>
        /// RegisterDormType
        /// 
        /// </summary>
        public int? RegisterDormType
        {
            get { return intRegisterDormType; }
            set { intRegisterDormType = value; }
        }
        /// <summary>
        /// IsLeft
        /// Đã trả phòng
        /// </summary>
        public bool IsLeft
        {
            get { return bolIsLeft; }
            set { bolIsLeft = value; }
        }
        /// <summary>
        /// Description
        /// 
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        /// <summary>
        /// CreatedUser
        /// 
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }
        /// <summary>
        /// CreatedDate
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }
        /// <summary>
        /// UpdatedUser
        /// Người sửa
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
            set { strUpdatedUser = value; }
        }
        /// <summary>
        /// UpdatedDate
        /// Ngày sửa
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }
        /// <summary>
        /// IsDeleted
        /// 
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }
        /// <summary>
        /// DeletedDate
        /// 
        /// </summary>
        public DateTime? DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }
        /// <summary>
        /// DeletedUser
        /// 
        /// </summary>
        public string DeletedUser
        {
            get { return strDeletedUser; }
            set { strDeletedUser = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_RegisterDormID.ToUpper()) && !Convert.IsDBNull(reader[C_RegisterDormID])) this.lngRegisterDormID = Convert.ToInt64(reader[C_RegisterDormID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_DormBedID.ToUpper()) && !Convert.IsDBNull(reader[C_DormBedID])) this.strDormBedID = Convert.ToString(reader[C_DormBedID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartDate.ToUpper()) && !Convert.IsDBNull(reader[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(reader[C_StartDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_EndDate.ToUpper()) && !Convert.IsDBNull(reader[C_EndDate])) this.dtmEndDate = Convert.ToDateTime(reader[C_EndDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_RegisterDormType.ToUpper()) && !Convert.IsDBNull(reader[C_RegisterDormType])) this.intRegisterDormType = Convert.ToInt32(reader[C_RegisterDormType]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLeft.ToUpper()) && !Convert.IsDBNull(reader[C_IsLeft])) this.bolIsLeft = Convert.ToBoolean(reader[C_IsLeft]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedUser.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUser])) this.strDeletedUser = Convert.ToString(reader[C_DeletedUser]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_RegisterDorm", objEx);
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
                if (!Convert.IsDBNull(drw[C_RegisterDormID])) this.lngRegisterDormID = Convert.ToInt64(drw[C_RegisterDormID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_DormBedID])) this.strDormBedID = Convert.ToString(drw[C_DormBedID]);
                if (!Convert.IsDBNull(drw[C_StartDate])) this.dtmStartDate = Convert.ToDateTime(drw[C_StartDate]);
                if (!Convert.IsDBNull(drw[C_EndDate])) this.dtmEndDate = Convert.ToDateTime(drw[C_EndDate]);
                if (!Convert.IsDBNull(drw[C_RegisterDormType])) this.intRegisterDormType = Convert.ToInt32(drw[C_RegisterDormType]);
                if (!Convert.IsDBNull(drw[C_IsLeft])) this.bolIsLeft = Convert.ToBoolean(drw[C_IsLeft]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
                if (!Convert.IsDBNull(drw[C_DeletedUser])) this.strDeletedUser = Convert.ToString(drw[C_DeletedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_RegisterDorm", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_RegisterDorm_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RegisterDorm_GET");
                objIData.AddParameter(P_RegisterDormID, this.lngRegisterDormID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_RegisterDorm", objEx);
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
        /// Store: SIM_RegisterDorm_GET 
        ///</summary>
        /// <returns> SIM_RegisterDorm </returns>
        public SIM_RegisterDorm Get(long? lngRegisterDormID)
        {
            SIM_RegisterDorm obj = new SIM_RegisterDorm();
            if (objIData != null)
                obj.IDB = objIData;
            obj.RegisterDormID = lngRegisterDormID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_RegisterDorm
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_RegisterDorm", objEx);
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
        /// Search : SIM_RegisterDorm
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_RegisterDorm", objEx);
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
        /// Search : SIM_RegisterDorm
        /// Lấy hết dữ liệu
        /// Store: SIM_RegisterDorm_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_RegisterDorm_GETALL");
        }

        ///<summary>
        /// Search : SIM_RegisterDorm
        /// Tìm dữ liệu
        /// Store: SIM_RegisterDorm_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_RegisterDorm_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_RegisterDorm
        /// Thêm dữ liệu
        /// Store: SIM_RegisterDorm_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RegisterDorm_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_DormBedID, this.strDormBedID);
                objIData.AddParameter(P_StartDate, this.dtmStartDate);
                objIData.AddParameter(P_EndDate, this.dtmEndDate);
                objIData.AddParameter(P_RegisterDormType, this.intRegisterDormType);
                objIData.AddParameter(P_IsLeft, this.bolIsLeft);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngRegisterDormID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_RegisterDorm", objEx);
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
        /// Update : SIM_RegisterDorm
        /// Cập nhật dữ liệu
        /// Store: SIM_RegisterDorm_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RegisterDorm_EDIT");
                objIData.AddParameter(P_RegisterDormID, this.lngRegisterDormID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_DormBedID, this.strDormBedID);
                objIData.AddParameter(P_StartDate, this.dtmStartDate);
                objIData.AddParameter(P_EndDate, this.dtmEndDate);
                objIData.AddParameter(P_RegisterDormType, this.intRegisterDormType);
                objIData.AddParameter(P_IsLeft, this.bolIsLeft);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_RegisterDorm", objEx);
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
        /// Delete : SIM_RegisterDorm
        /// Xóa dữ liệu
        /// Store: SIM_RegisterDorm_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_RegisterDorm_DELETE");
                objIData.AddParameter(P_RegisterDormID, this.lngRegisterDormID);
                objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_RegisterDorm", objEx);
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
        /// Store: SIM_RegisterDorm_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngRegisterDormID, string strDeletedUser)
        {
            this.lngRegisterDormID = lngRegisterDormID;
            this.strDeletedUser = strDeletedUser;
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

        public SIM_RegisterDorm()
        {
        }
        public SIM_RegisterDorm(long? lngRegisterDormID)
        {
            this.lngRegisterDormID = lngRegisterDormID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_RegisterDormID = "@" + C_RegisterDormID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_DormBedID = "@" + C_DormBedID;
        public const String P_StartDate = "@" + C_StartDate;
        public const String P_EndDate = "@" + C_EndDate;
        public const String P_RegisterDormType = "@" + C_RegisterDormType;
        public const String P_IsLeft = "@" + C_IsLeft;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DeletedDate = "@" + C_DeletedDate;
        public const String P_DeletedUser = "@" + C_DeletedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_RegisterDormID = "RegisterDormID";
        public const String C_StudentID = "StudentID";
        public const String C_DormBedID = "DormBedID";
        public const String C_StartDate = "StartDate";
        public const String C_EndDate = "EndDate";
        public const String C_RegisterDormType = "RegisterDormType";
        public const String C_IsLeft = "IsLeft";
        public const String C_Description = "Description";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_DeletedDate = "DeletedDate";
        public const String C_DeletedUser = "DeletedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}


