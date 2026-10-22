
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
    /// Created date 	: 12/7/2012 
    /// Description 
    /// </summary>	
    public partial class SIM_HistoryPrintCer
    {
        #region Member Variables

        private long? lngHistoryPrintCerID = null;//Mã lịch sử cấp phát giấy cho sinh viên
        private long? lngStudentID = null;//Mã sinh viên tự sinh
        private int? intCerTypeID = null;//Mã loại giấy tờ, chứng nhận, xác nhận
        private DateTime? dtmPrintDate = null;//Ngày in/ cấp phát
        private string strReason = null;//Lý do cấp giấy
        private string strDescription = null;//Mô tả
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// HistoryPrintCerID
        /// Mã lịch sử cấp phát giấy cho sinh viên
        /// </summary>
        public long? HistoryPrintCerID
        {
            get { return lngHistoryPrintCerID; }
            set { lngHistoryPrintCerID = value; }
        }
        /// <summary>
        /// StudentID
        /// Mã sinh viên tự sinh
        /// </summary>
        public long? StudentID
        {
            get { return lngStudentID; }
            set { lngStudentID = value; }
        }
        /// <summary>
        /// CerTypeID
        /// Mã loại giấy tờ, chứng nhận, xác nhận
        /// </summary>
        public int? CerTypeID
        {
            get { return intCerTypeID; }
            set { intCerTypeID = value; }
        }
        /// <summary>
        /// PrintDate
        /// Ngày in/ cấp phát
        /// </summary>
        public DateTime? PrintDate
        {
            get { return dtmPrintDate; }
            set { dtmPrintDate = value; }
        }
        /// <summary>
        /// Reason
        /// Lý do cấp giấy
        /// </summary>
        public string Reason
        {
            get { return strReason; }
            set { strReason = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_HistoryPrintCerID.ToUpper()) && !Convert.IsDBNull(reader[C_HistoryPrintCerID])) this.lngHistoryPrintCerID = Convert.ToInt64(reader[C_HistoryPrintCerID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CerTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_CerTypeID])) this.intCerTypeID = Convert.ToInt32(reader[C_CerTypeID]);
                    if (reader.GetName(i).ToUpper().Equals(C_PrintDate.ToUpper()) && !Convert.IsDBNull(reader[C_PrintDate])) this.dtmPrintDate = Convert.ToDateTime(reader[C_PrintDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_Reason.ToUpper()) && !Convert.IsDBNull(reader[C_Reason])) this.strReason = Convert.ToString(reader[C_Reason]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_HistoryPrintCer", objEx);
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
                if (!Convert.IsDBNull(drw[C_HistoryPrintCerID])) this.lngHistoryPrintCerID = Convert.ToInt64(drw[C_HistoryPrintCerID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_CerTypeID])) this.intCerTypeID = Convert.ToInt32(drw[C_CerTypeID]);
                if (!Convert.IsDBNull(drw[C_PrintDate])) this.dtmPrintDate = Convert.ToDateTime(drw[C_PrintDate]);
                if (!Convert.IsDBNull(drw[C_Reason])) this.strReason = Convert.ToString(drw[C_Reason]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_HistoryPrintCer", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_HistoryPrintCer_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_HistoryPrintCer_GET");
                objIData.AddParameter(P_HistoryPrintCerID, this.lngHistoryPrintCerID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_HistoryPrintCer", objEx);
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
        /// Store: SIM_HistoryPrintCer_GET 
        ///</summary>
        /// <returns> SIM_HistoryPrintCer </returns>
        public SIM_HistoryPrintCer Get(long? lngHistoryPrintCerID)
        {
            SIM_HistoryPrintCer obj = new SIM_HistoryPrintCer();
            if (objIData != null)
                obj.IDB = objIData;
            obj.HistoryPrintCerID = lngHistoryPrintCerID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_HistoryPrintCer
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_HistoryPrintCer", objEx);
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
        /// Search : SIM_HistoryPrintCer
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_HistoryPrintCer", objEx);
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
        /// Search : SIM_HistoryPrintCer
        /// Lấy hết dữ liệu
        /// Store: SIM_HistoryPrintCer_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_HistoryPrintCer_GETALL");
        }

        ///<summary>
        /// Search : SIM_HistoryPrintCer
        /// Tìm dữ liệu
        /// Store: SIM_HistoryPrintCer_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_HistoryPrintCer_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_HistoryPrintCer
        /// Thêm dữ liệu
        /// Store: SIM_HistoryPrintCer_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_HistoryPrintCer_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_CerTypeID, this.intCerTypeID);
                objIData.AddParameter(P_PrintDate, this.dtmPrintDate);
                objIData.AddParameter(P_Reason, this.strReason);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngHistoryPrintCerID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_HistoryPrintCer", objEx);
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
        /// Update : SIM_HistoryPrintCer
        /// Cập nhật dữ liệu
        /// Store: SIM_HistoryPrintCer_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_HistoryPrintCer_EDIT");
                objIData.AddParameter(P_HistoryPrintCerID, this.lngHistoryPrintCerID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_CerTypeID, this.intCerTypeID);
                objIData.AddParameter(P_PrintDate, this.dtmPrintDate);
                objIData.AddParameter(P_Reason, this.strReason);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_HistoryPrintCer", objEx);
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
        /// Delete : SIM_HistoryPrintCer
        /// Xóa dữ liệu
        /// Store: SIM_HistoryPrintCer_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_HistoryPrintCer_DELETE");
                objIData.AddParameter(P_HistoryPrintCerID, this.lngHistoryPrintCerID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_HistoryPrintCer", objEx);
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
        /// Store: SIM_HistoryPrintCer_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngHistoryPrintCerID)
        {
            this.lngHistoryPrintCerID = lngHistoryPrintCerID;
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

        public SIM_HistoryPrintCer()
        {
        }
        public SIM_HistoryPrintCer(long? lngHistoryPrintCerID)
        {
            this.lngHistoryPrintCerID = lngHistoryPrintCerID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_HistoryPrintCerID = "@" + C_HistoryPrintCerID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_CerTypeID = "@" + C_CerTypeID;
        public const String P_PrintDate = "@" + C_PrintDate;
        public const String P_Reason = "@" + C_Reason;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_HistoryPrintCerID = "HistoryPrintCerID";
        public const String C_StudentID = "StudentID";
        public const String C_CerTypeID = "CerTypeID";
        public const String C_PrintDate = "PrintDate";
        public const String C_Reason = "Reason";
        public const String C_Description = "Description";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}


