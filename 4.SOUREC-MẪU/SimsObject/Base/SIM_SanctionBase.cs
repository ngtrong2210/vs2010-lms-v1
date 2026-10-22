
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
    /// Created date 	: 12/11/2012 
    /// Description 
    /// </summary>	
    public partial class SIM_Sanction
    {
        #region Member Variables

        private long? lngSanctionID = null;
        private long? lngStudentID = null;
        private string strDecisionNo = null;//Số quyết định
        private DateTime? dtmSigningdate = null;//Ngày ký
        private string strSigner = null;//Người ký
        private string strReason = null;
        private string strViolationTypeID = null;//Mã Loại hình vi phạm
        private string strSanctionFormID = null;//Mã hình thức xử phạt
        private DateTime? dtmEffectiveDate = null;//Ngày hiệu lực
        private DateTime? dtmExpiredDate = null;//Ngày hết hiệu lực
        private bool bolIsSuspended = false;//Đình chỉ
        private int? intYearID = null;//Mã niên học
        private int? intSemester = null;//Học kì
        private string strDescription = null;
        private bool bolIsActived = false;//Đã có giá trị quyết định
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// SanctionID
        /// 
        /// </summary>
        public long? SanctionID
        {
            get { return lngSanctionID; }
            set { lngSanctionID = value; }
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
        /// DecisionNo
        /// Số quyết định
        /// </summary>
        public string DecisionNo
        {
            get { return strDecisionNo; }
            set { strDecisionNo = value; }
        }
        /// <summary>
        /// Signingdate
        /// Ngày ký
        /// </summary>
        public DateTime? Signingdate
        {
            get { return dtmSigningdate; }
            set { dtmSigningdate = value; }
        }
        /// <summary>
        /// Signer
        /// Người ký
        /// </summary>
        public string Signer
        {
            get { return strSigner; }
            set { strSigner = value; }
        }
        /// <summary>
        /// Reason
        /// 
        /// </summary>
        public string Reason
        {
            get { return strReason; }
            set { strReason = value; }
        }
        /// <summary>
        /// ViolationTypeID
        /// Mã Loại hình vi phạm
        /// </summary>
        public string ViolationTypeID
        {
            get { return strViolationTypeID; }
            set { strViolationTypeID = value; }
        }
        /// <summary>
        /// SanctionFormID
        /// Mã hình thức xử phạt
        /// </summary>
        public string SanctionFormID
        {
            get { return strSanctionFormID; }
            set { strSanctionFormID = value; }
        }
        /// <summary>
        /// EffectiveDate
        /// Ngày hiệu lực
        /// </summary>
        public DateTime? EffectiveDate
        {
            get { return dtmEffectiveDate; }
            set { dtmEffectiveDate = value; }
        }
        /// <summary>
        /// ExpiredDate
        /// Ngày hết hiệu lực
        /// </summary>
        public DateTime? ExpiredDate
        {
            get { return dtmExpiredDate; }
            set { dtmExpiredDate = value; }
        }
        /// <summary>
        /// IsSuspended
        /// Đình chỉ
        /// </summary>
        public bool IsSuspended
        {
            get { return bolIsSuspended; }
            set { bolIsSuspended = value; }
        }
        /// <summary>
        /// YearID
        /// Mã niên học
        /// </summary>
        public int? YearID
        {
            get { return intYearID; }
            set { intYearID = value; }
        }
        /// <summary>
        /// Semester
        /// Học kì
        /// </summary>
        public int? Semester
        {
            get { return intSemester; }
            set { intSemester = value; }
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
        /// IsActived
        /// Đã có giá trị quyết định
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
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
        /// CreatedUser
        /// Người tạo
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }
        /// <summary>
        /// UpdatedDate
        /// Ngày cập nhật cuối
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }
        /// <summary>
        /// UpdatedUser
        /// Người cập nhật cuối
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
            set { strUpdatedUser = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_SanctionID.ToUpper()) && !Convert.IsDBNull(reader[C_SanctionID])) this.lngSanctionID = Convert.ToInt64(reader[C_SanctionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_DecisionNo.ToUpper()) && !Convert.IsDBNull(reader[C_DecisionNo])) this.strDecisionNo = Convert.ToString(reader[C_DecisionNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_Signingdate.ToUpper()) && !Convert.IsDBNull(reader[C_Signingdate])) this.dtmSigningdate = Convert.ToDateTime(reader[C_Signingdate]);
                    if (reader.GetName(i).ToUpper().Equals(C_Signer.ToUpper()) && !Convert.IsDBNull(reader[C_Signer])) this.strSigner = Convert.ToString(reader[C_Signer]);
                    if (reader.GetName(i).ToUpper().Equals(C_Reason.ToUpper()) && !Convert.IsDBNull(reader[C_Reason])) this.strReason = Convert.ToString(reader[C_Reason]);
                    if (reader.GetName(i).ToUpper().Equals(C_ViolationTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_ViolationTypeID])) this.strViolationTypeID = Convert.ToString(reader[C_ViolationTypeID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SanctionFormID.ToUpper()) && !Convert.IsDBNull(reader[C_SanctionFormID])) this.strSanctionFormID = Convert.ToString(reader[C_SanctionFormID]);
                    if (reader.GetName(i).ToUpper().Equals(C_EffectiveDate.ToUpper()) && !Convert.IsDBNull(reader[C_EffectiveDate])) this.dtmEffectiveDate = Convert.ToDateTime(reader[C_EffectiveDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExpiredDate.ToUpper()) && !Convert.IsDBNull(reader[C_ExpiredDate])) this.dtmExpiredDate = Convert.ToDateTime(reader[C_ExpiredDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsSuspended.ToUpper()) && !Convert.IsDBNull(reader[C_IsSuspended])) this.bolIsSuspended = Convert.ToBoolean(reader[C_IsSuspended]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Sanction", objEx);
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
                if (!Convert.IsDBNull(drw[C_SanctionID])) this.lngSanctionID = Convert.ToInt64(drw[C_SanctionID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_DecisionNo])) this.strDecisionNo = Convert.ToString(drw[C_DecisionNo]);
                if (!Convert.IsDBNull(drw[C_Signingdate])) this.dtmSigningdate = Convert.ToDateTime(drw[C_Signingdate]);
                if (!Convert.IsDBNull(drw[C_Signer])) this.strSigner = Convert.ToString(drw[C_Signer]);
                if (!Convert.IsDBNull(drw[C_Reason])) this.strReason = Convert.ToString(drw[C_Reason]);
                if (!Convert.IsDBNull(drw[C_ViolationTypeID])) this.strViolationTypeID = Convert.ToString(drw[C_ViolationTypeID]);
                if (!Convert.IsDBNull(drw[C_SanctionFormID])) this.strSanctionFormID = Convert.ToString(drw[C_SanctionFormID]);
                if (!Convert.IsDBNull(drw[C_EffectiveDate])) this.dtmEffectiveDate = Convert.ToDateTime(drw[C_EffectiveDate]);
                if (!Convert.IsDBNull(drw[C_ExpiredDate])) this.dtmExpiredDate = Convert.ToDateTime(drw[C_ExpiredDate]);
                if (!Convert.IsDBNull(drw[C_IsSuspended])) this.bolIsSuspended = Convert.ToBoolean(drw[C_IsSuspended]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Sanction", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_Sanction_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Sanction_GET");
                objIData.AddParameter(P_SanctionID, this.lngSanctionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Sanction", objEx);
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
        /// Store: SIM_Sanction_GET 
        ///</summary>
        /// <returns> SIM_Sanction </returns>
        public SIM_Sanction Get(long? lngSanctionID)
        {
            SIM_Sanction obj = new SIM_Sanction();
            if (objIData != null)
                obj.IDB = objIData;
            obj.SanctionID = lngSanctionID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_Sanction
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Sanction", objEx);
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
        /// Search : SIM_Sanction
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Sanction", objEx);
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
        /// Search : SIM_Sanction
        /// Lấy hết dữ liệu
        /// Store: SIM_Sanction_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_Sanction_GETALL");
        }

        ///<summary>
        /// Search : SIM_Sanction
        /// Tìm dữ liệu
        /// Store: SIM_Sanction_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_Sanction_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_Sanction
        /// Thêm dữ liệu
        /// Store: SIM_Sanction_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Sanction_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_Signingdate, this.dtmSigningdate);
                objIData.AddParameter(P_Signer, this.strSigner);
                objIData.AddParameter(P_Reason, this.strReason);
                objIData.AddParameter(P_ViolationTypeID, this.strViolationTypeID);
                objIData.AddParameter(P_SanctionFormID, this.strSanctionFormID);
                objIData.AddParameter(P_EffectiveDate, this.dtmEffectiveDate);
                objIData.AddParameter(P_ExpiredDate, this.dtmExpiredDate);
                objIData.AddParameter(P_IsSuspended, this.bolIsSuspended);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngSanctionID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Sanction", objEx);
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
        /// Update : SIM_Sanction
        /// Cập nhật dữ liệu
        /// Store: SIM_Sanction_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Sanction_EDIT");
                objIData.AddParameter(P_SanctionID, this.lngSanctionID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_Signingdate, this.dtmSigningdate);
                objIData.AddParameter(P_Signer, this.strSigner);
                objIData.AddParameter(P_Reason, this.strReason);
                objIData.AddParameter(P_ViolationTypeID, this.strViolationTypeID);
                objIData.AddParameter(P_SanctionFormID, this.strSanctionFormID);
                objIData.AddParameter(P_EffectiveDate, this.dtmEffectiveDate);
                objIData.AddParameter(P_ExpiredDate, this.dtmExpiredDate);
                objIData.AddParameter(P_IsSuspended, this.bolIsSuspended);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Sanction", objEx);
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
        /// Delete : SIM_Sanction
        /// Xóa dữ liệu
        /// Store: SIM_Sanction_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_Sanction_DELETE");
                objIData.AddParameter(P_SanctionID, this.lngSanctionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Sanction", objEx);
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
        /// Store: SIM_Sanction_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngSanctionID)
        {
            this.lngSanctionID = lngSanctionID;
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

        public SIM_Sanction()
        {
        }
        public SIM_Sanction(long? lngSanctionID)
        {
            this.lngSanctionID = lngSanctionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_SanctionID = "@" + C_SanctionID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_DecisionNo = "@" + C_DecisionNo;
        public const String P_Signingdate = "@" + C_Signingdate;
        public const String P_Signer = "@" + C_Signer;
        public const String P_Reason = "@" + C_Reason;
        public const String P_ViolationTypeID = "@" + C_ViolationTypeID;
        public const String P_SanctionFormID = "@" + C_SanctionFormID;
        public const String P_EffectiveDate = "@" + C_EffectiveDate;
        public const String P_ExpiredDate = "@" + C_ExpiredDate;
        public const String P_IsSuspended = "@" + C_IsSuspended;
        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_Description = "@" + C_Description;
        public const String P_IsActived = "@" + C_IsActived;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_SanctionID = "SanctionID";
        public const String C_StudentID = "StudentID";
        public const String C_DecisionNo = "DecisionNo";
        public const String C_Signingdate = "Signingdate";
        public const String C_Signer = "Signer";
        public const String C_Reason = "Reason";
        public const String C_ViolationTypeID = "ViolationTypeID";
        public const String C_SanctionFormID = "SanctionFormID";
        public const String C_EffectiveDate = "EffectiveDate";
        public const String C_ExpiredDate = "ExpiredDate";
        public const String C_IsSuspended = "IsSuspended";
        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_Description = "Description";
        public const String C_IsActived = "IsActived";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}


