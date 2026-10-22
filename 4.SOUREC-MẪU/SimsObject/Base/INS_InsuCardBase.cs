
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
    /// Created date 	: 09/03/2020 
    /// Description 
    /// </summary>	
    public partial class INS_InsuCard
    {
        #region Member Variables

        private long? lngInsuCardID = null;//Thông tin thẻ bảo hiểm
        private long? lngStudentID = null;
        private long? lngEmployeeID = null;
        private int? intInsuPeriodID = null;//Đợt đăng ký
        private int? intInsuTypeID = null;//Loại thẻ bảo hiểm
        private int? intHospitalID = null;//Bệnh viện đăng ký thẻ
        private DateTime? dtmRegisterDate = null;//Ngày đăng ký
        private long? lngMoney = null;//Số tiền bảo hiểm phải đóng
        private bool bolIsReceivedMoney = false;//Đã đóng tiền
        private string strCardNo = null;//Số thẻ bảo hiểm
        private DateTime? dtmCardIssued = null;//Ngày cấp thẻ
        private DateTime? dtmExpiredDate = null;//Ngày hết hạn
        private string strDescription = null;//Mô tả
        private bool bolIsDeliveredCard = false;//Đã giao thẻ cho chủ thẻ
        private int? intInsuStatusID = null;//Tình trạng thẻ
        private bool bolIsActived = false;//Đang kích hoạt
        private bool bolIsCanceled = false;//Đã hủy bỏ
        private string strCancelReason = null;//Lý do hủy
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private bool bolIsDeleted = false;//Đã xóa
        private DateTime? dtmDeletedDate = null;//Ngày cập nhật cuối
        private string strDeletedUser = null;//Người cập nhật cuối
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// InsuCardID
        /// Thông tin thẻ bảo hiểm
        /// </summary>
        public long? InsuCardID
        {
            get { return lngInsuCardID; }
            set { lngInsuCardID = value; }
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
        /// EmployeeID
        /// 
        /// </summary>
        public long? EmployeeID
        {
            get { return lngEmployeeID; }
            set { lngEmployeeID = value; }
        }
        /// <summary>
        /// InsuPeriodID
        /// Đợt đăng ký
        /// </summary>
        public int? InsuPeriodID
        {
            get { return intInsuPeriodID; }
            set { intInsuPeriodID = value; }
        }
        /// <summary>
        /// InsuTypeID
        /// Loại thẻ bảo hiểm
        /// </summary>
        public int? InsuTypeID
        {
            get { return intInsuTypeID; }
            set { intInsuTypeID = value; }
        }
        /// <summary>
        /// HospitalID
        /// Bệnh viện đăng ký thẻ
        /// </summary>
        public int? HospitalID
        {
            get { return intHospitalID; }
            set { intHospitalID = value; }
        }
        /// <summary>
        /// RegisterDate
        /// Ngày đăng ký
        /// </summary>
        public DateTime? RegisterDate
        {
            get { return dtmRegisterDate; }
            set { dtmRegisterDate = value; }
        }
        /// <summary>
        /// Money
        /// Số tiền bảo hiểm phải đóng
        /// </summary>
        public long? Money
        {
            get { return lngMoney; }
            set { lngMoney = value; }
        }
        /// <summary>
        /// IsReceivedMoney
        /// Đã đóng tiền
        /// </summary>
        public bool IsReceivedMoney
        {
            get { return bolIsReceivedMoney; }
            set { bolIsReceivedMoney = value; }
        }
        /// <summary>
        /// CardNo
        /// Số thẻ bảo hiểm
        /// </summary>
        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }
        }
        /// <summary>
        /// CardIssued
        /// Ngày cấp thẻ
        /// </summary>
        public DateTime? CardIssued
        {
            get { return dtmCardIssued; }
            set { dtmCardIssued = value; }
        }
        /// <summary>
        /// ExpiredDate
        /// Ngày hết hạn
        /// </summary>
        public DateTime? ExpiredDate
        {
            get { return dtmExpiredDate; }
            set { dtmExpiredDate = value; }
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
        /// IsDeliveredCard
        /// Đã giao thẻ cho chủ thẻ
        /// </summary>
        public bool IsDeliveredCard
        {
            get { return bolIsDeliveredCard; }
            set { bolIsDeliveredCard = value; }
        }
        /// <summary>
        /// InsuStatusID
        /// Tình trạng thẻ
        /// </summary>
        public int? InsuStatusID
        {
            get { return intInsuStatusID; }
            set { intInsuStatusID = value; }
        }
        /// <summary>
        /// IsActived
        /// Đang kích hoạt
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }
        /// <summary>
        /// IsCanceled
        /// Đã hủy bỏ
        /// </summary>
        public bool IsCanceled
        {
            get { return bolIsCanceled; }
            set { bolIsCanceled = value; }
        }
        /// <summary>
        /// CancelReason
        /// Lý do hủy
        /// </summary>
        public string CancelReason
        {
            get { return strCancelReason; }
            set { strCancelReason = value; }
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
        /// IsDeleted
        /// Đã xóa
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
        }
        /// <summary>
        /// DeletedDate
        /// Ngày cập nhật cuối
        /// </summary>
        public DateTime? DeletedDate
        {
            get { return dtmDeletedDate; }
            set { dtmDeletedDate = value; }
        }
        /// <summary>
        /// DeletedUser
        /// Người cập nhật cuối
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
                    if (reader.GetName(i).ToUpper().Equals(C_InsuCardID.ToUpper()) && !Convert.IsDBNull(reader[C_InsuCardID])) this.lngInsuCardID = Convert.ToInt64(reader[C_InsuCardID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_EmployeeID.ToUpper()) && !Convert.IsDBNull(reader[C_EmployeeID])) this.lngEmployeeID = Convert.ToInt64(reader[C_EmployeeID]);
                    if (reader.GetName(i).ToUpper().Equals(C_InsuPeriodID.ToUpper()) && !Convert.IsDBNull(reader[C_InsuPeriodID])) this.intInsuPeriodID = Convert.ToInt32(reader[C_InsuPeriodID]);
                    if (reader.GetName(i).ToUpper().Equals(C_InsuTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_InsuTypeID])) this.intInsuTypeID = Convert.ToInt32(reader[C_InsuTypeID]);
                    if (reader.GetName(i).ToUpper().Equals(C_HospitalID.ToUpper()) && !Convert.IsDBNull(reader[C_HospitalID])) this.intHospitalID = Convert.ToInt32(reader[C_HospitalID]);
                    if (reader.GetName(i).ToUpper().Equals(C_RegisterDate.ToUpper()) && !Convert.IsDBNull(reader[C_RegisterDate])) this.dtmRegisterDate = Convert.ToDateTime(reader[C_RegisterDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_Money.ToUpper()) && !Convert.IsDBNull(reader[C_Money])) this.lngMoney = Convert.ToInt64(reader[C_Money]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsReceivedMoney.ToUpper()) && !Convert.IsDBNull(reader[C_IsReceivedMoney])) this.bolIsReceivedMoney = Convert.ToBoolean(reader[C_IsReceivedMoney]);
                    if (reader.GetName(i).ToUpper().Equals(C_CardNo.ToUpper()) && !Convert.IsDBNull(reader[C_CardNo])) this.strCardNo = Convert.ToString(reader[C_CardNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_CardIssued.ToUpper()) && !Convert.IsDBNull(reader[C_CardIssued])) this.dtmCardIssued = Convert.ToDateTime(reader[C_CardIssued]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExpiredDate.ToUpper()) && !Convert.IsDBNull(reader[C_ExpiredDate])) this.dtmExpiredDate = Convert.ToDateTime(reader[C_ExpiredDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeliveredCard.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeliveredCard])) this.bolIsDeliveredCard = Convert.ToBoolean(reader[C_IsDeliveredCard]);
                    if (reader.GetName(i).ToUpper().Equals(C_InsuStatusID.ToUpper()) && !Convert.IsDBNull(reader[C_InsuStatusID])) this.intInsuStatusID = Convert.ToInt32(reader[C_InsuStatusID]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCanceled.ToUpper()) && !Convert.IsDBNull(reader[C_IsCanceled])) this.bolIsCanceled = Convert.ToBoolean(reader[C_IsCanceled]);
                    if (reader.GetName(i).ToUpper().Equals(C_CancelReason.ToUpper()) && !Convert.IsDBNull(reader[C_CancelReason])) this.strCancelReason = Convert.ToString(reader[C_CancelReason]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedDate.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(reader[C_DeletedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_DeletedUser.ToUpper()) && !Convert.IsDBNull(reader[C_DeletedUser])) this.strDeletedUser = Convert.ToString(reader[C_DeletedUser]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong INS_InsuCard", objEx);
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
                if (!Convert.IsDBNull(drw[C_InsuCardID])) this.lngInsuCardID = Convert.ToInt64(drw[C_InsuCardID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_EmployeeID])) this.lngEmployeeID = Convert.ToInt64(drw[C_EmployeeID]);
                if (!Convert.IsDBNull(drw[C_InsuPeriodID])) this.intInsuPeriodID = Convert.ToInt32(drw[C_InsuPeriodID]);
                if (!Convert.IsDBNull(drw[C_InsuTypeID])) this.intInsuTypeID = Convert.ToInt32(drw[C_InsuTypeID]);
                if (!Convert.IsDBNull(drw[C_HospitalID])) this.intHospitalID = Convert.ToInt32(drw[C_HospitalID]);
                if (!Convert.IsDBNull(drw[C_RegisterDate])) this.dtmRegisterDate = Convert.ToDateTime(drw[C_RegisterDate]);
                if (!Convert.IsDBNull(drw[C_Money])) this.lngMoney = Convert.ToInt64(drw[C_Money]);
                if (!Convert.IsDBNull(drw[C_IsReceivedMoney])) this.bolIsReceivedMoney = Convert.ToBoolean(drw[C_IsReceivedMoney]);
                if (!Convert.IsDBNull(drw[C_CardNo])) this.strCardNo = Convert.ToString(drw[C_CardNo]);
                if (!Convert.IsDBNull(drw[C_CardIssued])) this.dtmCardIssued = Convert.ToDateTime(drw[C_CardIssued]);
                if (!Convert.IsDBNull(drw[C_ExpiredDate])) this.dtmExpiredDate = Convert.ToDateTime(drw[C_ExpiredDate]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_IsDeliveredCard])) this.bolIsDeliveredCard = Convert.ToBoolean(drw[C_IsDeliveredCard]);
                if (!Convert.IsDBNull(drw[C_InsuStatusID])) this.intInsuStatusID = Convert.ToInt32(drw[C_InsuStatusID]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                if (!Convert.IsDBNull(drw[C_IsCanceled])) this.bolIsCanceled = Convert.ToBoolean(drw[C_IsCanceled]);
                if (!Convert.IsDBNull(drw[C_CancelReason])) this.strCancelReason = Convert.ToString(drw[C_CancelReason]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                if (!Convert.IsDBNull(drw[C_DeletedDate])) this.dtmDeletedDate = Convert.ToDateTime(drw[C_DeletedDate]);
                if (!Convert.IsDBNull(drw[C_DeletedUser])) this.strDeletedUser = Convert.ToString(drw[C_DeletedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong INS_InsuCard", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: INS_InsuCard_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("INS_InsuCard_GET");
                objIData.AddParameter(P_InsuCardID, this.lngInsuCardID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin INS_InsuCard", objEx);
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
        /// Store: INS_InsuCard_GET 
        ///</summary>
        /// <returns> INS_InsuCard </returns>
        public INS_InsuCard Get(long? lngInsuCardID)
        {
            INS_InsuCard obj = new INS_InsuCard();
            if (objIData != null)
                obj.IDB = objIData;
            obj.InsuCardID = lngInsuCardID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : INS_InsuCard
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong INS_InsuCard", objEx);
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
        /// Search : INS_InsuCard
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong INS_InsuCard", objEx);
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
        /// Search : INS_InsuCard
        /// Lấy hết dữ liệu
        /// Store: INS_InsuCard_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("INS_InsuCard_GETALL");
        }

        ///<summary>
        /// Search : INS_InsuCard
        /// Tìm dữ liệu
        /// Store: INS_InsuCard_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("INS_InsuCard_SEARCH", pars);
        }

        ///<summary>
        /// Add : INS_InsuCard
        /// Thêm dữ liệu
        /// Store: INS_InsuCard_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("INS_InsuCard_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_EmployeeID, this.lngEmployeeID);
                objIData.AddParameter(P_InsuPeriodID, this.intInsuPeriodID);
                objIData.AddParameter(P_InsuTypeID, this.intInsuTypeID);
                objIData.AddParameter(P_HospitalID, this.intHospitalID);
                objIData.AddParameter(P_RegisterDate, this.dtmRegisterDate);
                objIData.AddParameter(P_Money, this.lngMoney);
                objIData.AddParameter(P_IsReceivedMoney, this.bolIsReceivedMoney);
                objIData.AddParameter(P_CardNo, this.strCardNo);
                objIData.AddParameter(P_CardIssued, this.dtmCardIssued);
                objIData.AddParameter(P_ExpiredDate, this.dtmExpiredDate);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_IsDeliveredCard, this.bolIsDeliveredCard);
                objIData.AddParameter(P_InsuStatusID, this.intInsuStatusID);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_IsCanceled, this.bolIsCanceled);
                objIData.AddParameter(P_CancelReason, this.strCancelReason);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngInsuCardID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin INS_InsuCard", objEx);
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
        /// Update : INS_InsuCard
        /// Cập nhật dữ liệu
        /// Store: INS_InsuCard_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("INS_InsuCard_EDIT");
                objIData.AddParameter(P_InsuCardID, this.lngInsuCardID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_EmployeeID, this.lngEmployeeID);
                objIData.AddParameter(P_InsuPeriodID, this.intInsuPeriodID);
                objIData.AddParameter(P_InsuTypeID, this.intInsuTypeID);
                objIData.AddParameter(P_HospitalID, this.intHospitalID);
                objIData.AddParameter(P_RegisterDate, this.dtmRegisterDate);
                objIData.AddParameter(P_Money, this.lngMoney);
                objIData.AddParameter(P_IsReceivedMoney, this.bolIsReceivedMoney);
                objIData.AddParameter(P_CardNo, this.strCardNo);
                objIData.AddParameter(P_CardIssued, this.dtmCardIssued);
                objIData.AddParameter(P_ExpiredDate, this.dtmExpiredDate);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_IsDeliveredCard, this.bolIsDeliveredCard);
                objIData.AddParameter(P_InsuStatusID, this.intInsuStatusID);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_IsCanceled, this.bolIsCanceled);
                objIData.AddParameter(P_CancelReason, this.strCancelReason);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin INS_InsuCard", objEx);
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
        /// Delete : INS_InsuCard
        /// Xóa dữ liệu
        /// Store: INS_InsuCard_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("INS_InsuCard_DELETE");
                objIData.AddParameter(P_InsuCardID, this.lngInsuCardID);
                objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin INS_InsuCard", objEx);
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
        /// Store: INS_InsuCard_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngInsuCardID, string strDeletedUser)
        {
            this.lngInsuCardID = lngInsuCardID;
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

        public INS_InsuCard()
        {
        }
        public INS_InsuCard(long? lngInsuCardID)
        {
            this.lngInsuCardID = lngInsuCardID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_InsuCardID = "@" + C_InsuCardID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_EmployeeID = "@" + C_EmployeeID;
        public const String P_InsuPeriodID = "@" + C_InsuPeriodID;
        public const String P_InsuTypeID = "@" + C_InsuTypeID;
        public const String P_HospitalID = "@" + C_HospitalID;
        public const String P_RegisterDate = "@" + C_RegisterDate;
        public const String P_Money = "@" + C_Money;
        public const String P_IsReceivedMoney = "@" + C_IsReceivedMoney;
        public const String P_CardNo = "@" + C_CardNo;
        public const String P_CardIssued = "@" + C_CardIssued;
        public const String P_ExpiredDate = "@" + C_ExpiredDate;
        public const String P_Description = "@" + C_Description;
        public const String P_IsDeliveredCard = "@" + C_IsDeliveredCard;
        public const String P_InsuStatusID = "@" + C_InsuStatusID;
        public const String P_IsActived = "@" + C_IsActived;
        public const String P_IsCanceled = "@" + C_IsCanceled;
        public const String P_CancelReason = "@" + C_CancelReason;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DeletedDate = "@" + C_DeletedDate;
        public const String P_DeletedUser = "@" + C_DeletedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_InsuCardID = "InsuCardID";
        public const String C_StudentID = "StudentID";
        public const String C_EmployeeID = "EmployeeID";
        public const String C_InsuPeriodID = "InsuPeriodID";
        public const String C_InsuTypeID = "InsuTypeID";
        public const String C_HospitalID = "HospitalID";
        public const String C_RegisterDate = "RegisterDate";
        public const String C_Money = "Money";
        public const String C_IsReceivedMoney = "IsReceivedMoney";
        public const String C_CardNo = "CardNo";
        public const String C_CardIssued = "CardIssued";
        public const String C_ExpiredDate = "ExpiredDate";
        public const String C_Description = "Description";
        public const String C_IsDeliveredCard = "IsDeliveredCard";
        public const String C_InsuStatusID = "InsuStatusID";
        public const String C_IsActived = "IsActived";
        public const String C_IsCanceled = "IsCanceled";
        public const String C_CancelReason = "CancelReason";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_IsDeleted = "IsDeleted";
        public const String C_DeletedDate = "DeletedDate";
        public const String C_DeletedUser = "DeletedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}


