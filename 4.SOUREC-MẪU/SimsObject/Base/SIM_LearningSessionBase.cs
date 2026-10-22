
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
    /// Created date 	: 10/10/2023 
    /// Description 
    /// </summary>	
    public partial class SIM_LearningSession
    {
        #region Member Variables

        private int? intLearningSessionID = null;//Mã ca học
        private string strLearningSessionName = null;//Tên ca học
        private DateTime? dtmStartTime = null;//Giờ bắt đầu
        private DateTime? dtmFinishTime = null;//Giờ kết thúc
        private int? intStartLession = null;//Tiết bắt đầu
        private int? intFinishLession = null;//Tiết kết thúc
        private string strDescription = null;//Mô tả
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private int? intSession = null;//Thuộc buổi học (0. Sáng, 1. Chiều, 2. Tối). Tự động điền theo theo StartTime để xử lý nhanh trong store
        private decimal? decTimeLen = null;//Tổng thời lượng ca học (theo đơn vị giờ)
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// LearningSessionID
        /// Mã ca học
        /// </summary>
        public int? LearningSessionID
        {
            get { return intLearningSessionID; }
            set { intLearningSessionID = value; }
        }
        /// <summary>
        /// LearningSessionName
        /// Tên ca học
        /// </summary>
        public string LearningSessionName
        {
            get { return strLearningSessionName; }
            set { strLearningSessionName = value; }
        }
        /// <summary>
        /// StartTime
        /// Giờ bắt đầu
        /// </summary>
        public DateTime? StartTime
        {
            get { return dtmStartTime; }
            set { dtmStartTime = value; }
        }
        /// <summary>
        /// FinishTime
        /// Giờ kết thúc
        /// </summary>
        public DateTime? FinishTime
        {
            get { return dtmFinishTime; }
            set { dtmFinishTime = value; }
        }
        /// <summary>
        /// StartLession
        /// Tiết bắt đầu
        /// </summary>
        public int? StartLession
        {
            get { return intStartLession; }
            set { intStartLession = value; }
        }
        /// <summary>
        /// FinishLession
        /// Tiết kết thúc
        /// </summary>
        public int? FinishLession
        {
            get { return intFinishLession; }
            set { intFinishLession = value; }
        }
        /// <summary>
        /// Description
        /// Mô tả
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
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
        /// Session
        /// Thuộc buổi học (0. Sáng, 1. Chiều, 2. Tối). Tự động điền theo theo StartTime để xử lý nhanh trong store
        /// </summary>
        public int? Session
        {
            get { return intSession; }
            set { intSession = value; }
        }
        /// <summary>
        /// TimeLen
        /// Tổng thời lượng ca học (theo đơn vị giờ)
        /// </summary>
        public decimal? TimeLen
        {
            get { return decTimeLen; }
            set { decTimeLen = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSessionID.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionID])) this.intLearningSessionID = Convert.ToInt32(reader[C_LearningSessionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSessionName.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionName])) this.strLearningSessionName = Convert.ToString(reader[C_LearningSessionName]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTime.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(reader[C_StartTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishTime.ToUpper()) && !Convert.IsDBNull(reader[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(reader[C_FinishTime]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartLession.ToUpper()) && !Convert.IsDBNull(reader[C_StartLession])) this.intStartLession = Convert.ToInt32(reader[C_StartLession]);
                    if (reader.GetName(i).ToUpper().Equals(C_FinishLession.ToUpper()) && !Convert.IsDBNull(reader[C_FinishLession])) this.intFinishLession = Convert.ToInt32(reader[C_FinishLession]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_Session.ToUpper()) && !Convert.IsDBNull(reader[C_Session])) this.intSession = Convert.ToInt32(reader[C_Session]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimeLen.ToUpper()) && !Convert.IsDBNull(reader[C_TimeLen])) this.decTimeLen = Convert.ToDecimal(reader[C_TimeLen]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_LearningSession", objEx);
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
                if (!Convert.IsDBNull(drw[C_LearningSessionID])) this.intLearningSessionID = Convert.ToInt32(drw[C_LearningSessionID]);
                if (!Convert.IsDBNull(drw[C_LearningSessionName])) this.strLearningSessionName = Convert.ToString(drw[C_LearningSessionName]);
                if (!Convert.IsDBNull(drw[C_StartTime])) this.dtmStartTime = Convert.ToDateTime(drw[C_StartTime]);
                if (!Convert.IsDBNull(drw[C_FinishTime])) this.dtmFinishTime = Convert.ToDateTime(drw[C_FinishTime]);
                if (!Convert.IsDBNull(drw[C_StartLession])) this.intStartLession = Convert.ToInt32(drw[C_StartLession]);
                if (!Convert.IsDBNull(drw[C_FinishLession])) this.intFinishLession = Convert.ToInt32(drw[C_FinishLession]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_Session])) this.intSession = Convert.ToInt32(drw[C_Session]);
                if (!Convert.IsDBNull(drw[C_TimeLen])) this.decTimeLen = Convert.ToDecimal(drw[C_TimeLen]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_LearningSession", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_LearningSession_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_LearningSession_GET");
                objIData.AddParameter(P_LearningSessionID, this.intLearningSessionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_LearningSession", objEx);
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
        /// Store: SIM_LearningSession_GET 
        ///</summary>
        /// <returns> SIM_LearningSession </returns>
        public SIM_LearningSession Get(int? intLearningSessionID)
        {
            SIM_LearningSession obj = new SIM_LearningSession();
            if (objIData != null)
                obj.IDB = objIData;
            obj.LearningSessionID = intLearningSessionID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_LearningSession
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_LearningSession", objEx);
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
        /// Search : SIM_LearningSession
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_LearningSession", objEx);
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
        /// Search : SIM_LearningSession
        /// Lấy hết dữ liệu
        /// Store: SIM_LearningSession_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_LearningSession_GETALL");
        }

        ///<summary>
        /// Search : SIM_LearningSession
        /// Tìm dữ liệu
        /// Store: SIM_LearningSession_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_LearningSession_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_LearningSession
        /// Thêm dữ liệu
        /// Store: SIM_LearningSession_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_LearningSession_ADD");
                objIData.AddParameter(P_LearningSessionName, this.strLearningSessionName);
                objIData.AddParameter(P_StartTime, this.dtmStartTime);
                objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
                objIData.AddParameter(P_StartLession, this.intStartLession);
                objIData.AddParameter(P_FinishLession, this.intFinishLession);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_Session, this.intSession);
                objIData.AddParameter(P_TimeLen, this.decTimeLen);
                this.intLearningSessionID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_LearningSession", objEx);
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
        /// Update : SIM_LearningSession
        /// Cập nhật dữ liệu
        /// Store: SIM_LearningSession_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_LearningSession_EDIT");
                objIData.AddParameter(P_LearningSessionID, this.intLearningSessionID);
                objIData.AddParameter(P_LearningSessionName, this.strLearningSessionName);
                objIData.AddParameter(P_StartTime, this.dtmStartTime);
                objIData.AddParameter(P_FinishTime, this.dtmFinishTime);
                objIData.AddParameter(P_StartLession, this.intStartLession);
                objIData.AddParameter(P_FinishLession, this.intFinishLession);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_Session, this.intSession);
                objIData.AddParameter(P_TimeLen, this.decTimeLen);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_LearningSession", objEx);
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
        /// Delete : SIM_LearningSession
        /// Xóa dữ liệu
        /// Store: SIM_LearningSession_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_LearningSession_DELETE");
                objIData.AddParameter(P_LearningSessionID, this.intLearningSessionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_LearningSession", objEx);
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
        /// Store: SIM_LearningSession_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(int? intLearningSessionID)
        {
            this.intLearningSessionID = intLearningSessionID;
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

        public SIM_LearningSession()
        {
        }
        public SIM_LearningSession(int? intLearningSessionID)
        {
            this.intLearningSessionID = intLearningSessionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_LearningSessionID = "@" + C_LearningSessionID;
        public const String P_LearningSessionName = "@" + C_LearningSessionName;
        public const String P_StartTime = "@" + C_StartTime;
        public const String P_FinishTime = "@" + C_FinishTime;
        public const String P_StartLession = "@" + C_StartLession;
        public const String P_FinishLession = "@" + C_FinishLession;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_Session = "@" + C_Session;
        public const String P_TimeLen = "@" + C_TimeLen;

        #endregion //Parameter names

        #region Column Names

        public const String C_LearningSessionID = "LearningSessionID";
        public const String C_LearningSessionName = "LearningSessionName";
        public const String C_StartTime = "StartTime";
        public const String C_FinishTime = "FinishTime";
        public const String C_StartLession = "StartLession";
        public const String C_FinishLession = "FinishLession";
        public const String C_Description = "Description";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_Session = "Session";
        public const String C_TimeLen = "TimeLen";

        #endregion //Column names

        #endregion Variable Static
    }
}


