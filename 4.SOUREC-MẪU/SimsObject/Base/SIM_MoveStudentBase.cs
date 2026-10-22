
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
	/// Created date 	: 8/21/2013 
	/// Description 
	/// </summary>	
    public partial class SIM_MoveStudent
    {
        #region Member Variables

        private int? intMoveStudentID = null;
        private long? lngStudentID = null;//Mã sinh viên tự sinh
        private string strSourceClassID = null;
        private string strDesClassID = null;
        private DateTime? dtmMoveDate = null;//Ngày chuyển lớp
        private int? intTypeAction = null;//Kiểu chuyển. 1.Chuyển lớp, 2. Lưu ban, 3. Bảo lưu (2,3 thì không chuyển sổ điểm. và cũng có thể ko cần chuyển lớp)
        private string strDescription = null;
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private bool bolIsDeleted = false;
        private DateTime? dtmDeletedDate = null;
        private string strDeletedUser = null;
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// MoveStudentID
        /// 
        /// </summary>
        public int? MoveStudentID
        {
            get { return intMoveStudentID; }
            set { intMoveStudentID = value; }
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
        /// SourceClassID
        /// 
        /// </summary>
        public string SourceClassID
        {
            get { return strSourceClassID; }
            set { strSourceClassID = value; }
        }
        /// <summary>
        /// DesClassID
        /// 
        /// </summary>
        public string DesClassID
        {
            get { return strDesClassID; }
            set { strDesClassID = value; }
        }
        /// <summary>
        /// MoveDate
        /// Ngày chuyển lớp
        /// </summary>
        public DateTime? MoveDate
        {
            get { return dtmMoveDate; }
            set { dtmMoveDate = value; }
        }
        /// <summary>
        /// TypeAction
        /// Kiểu chuyển. 1.Chuyển lớp, 2. Lưu ban, 3. Bảo lưu (2,3 thì không chuyển sổ điểm. và cũng có thể ko cần chuyển lớp)
        /// </summary>
        public int? TypeAction
        {
            get { return intTypeAction; }
            set { intTypeAction = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_MoveStudentID.ToUpper()) && !Convert.IsDBNull(reader[C_MoveStudentID])) this.intMoveStudentID = Convert.ToInt32(reader[C_MoveStudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SourceClassID.ToUpper()) && !Convert.IsDBNull(reader[C_SourceClassID])) this.strSourceClassID = Convert.ToString(reader[C_SourceClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_DesClassID.ToUpper()) && !Convert.IsDBNull(reader[C_DesClassID])) this.strDesClassID = Convert.ToString(reader[C_DesClassID]);
                    if (reader.GetName(i).ToUpper().Equals(C_MoveDate.ToUpper()) && !Convert.IsDBNull(reader[C_MoveDate])) this.dtmMoveDate = Convert.ToDateTime(reader[C_MoveDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_TypeAction.ToUpper()) && !Convert.IsDBNull(reader[C_TypeAction])) this.intTypeAction = Convert.ToInt32(reader[C_TypeAction]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_MoveStudent", objEx);
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
                if (!Convert.IsDBNull(drw[C_MoveStudentID])) this.intMoveStudentID = Convert.ToInt32(drw[C_MoveStudentID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_SourceClassID])) this.strSourceClassID = Convert.ToString(drw[C_SourceClassID]);
                if (!Convert.IsDBNull(drw[C_DesClassID])) this.strDesClassID = Convert.ToString(drw[C_DesClassID]);
                if (!Convert.IsDBNull(drw[C_MoveDate])) this.dtmMoveDate = Convert.ToDateTime(drw[C_MoveDate]);
                if (!Convert.IsDBNull(drw[C_TypeAction])) this.intTypeAction = Convert.ToInt32(drw[C_TypeAction]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_MoveStudent", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_MoveStudent_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MoveStudent_GET");
                objIData.AddParameter(P_MoveStudentID, this.intMoveStudentID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_MoveStudent", objEx);
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
        /// Store: SIM_MoveStudent_GET 
        ///</summary>
        /// <returns> SIM_MoveStudent </returns>
        public SIM_MoveStudent Get(int? intMoveStudentID)
        {
            SIM_MoveStudent obj = new SIM_MoveStudent();
            if (objIData != null)
                obj.IDB = objIData;
            obj.MoveStudentID = intMoveStudentID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_MoveStudent
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MoveStudent", objEx);
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
        /// Search : SIM_MoveStudent
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MoveStudent", objEx);
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
        /// Search : SIM_MoveStudent
        /// Lấy hết dữ liệu
        /// Store: SIM_MoveStudent_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_MoveStudent_GETALL");
        }

        ///<summary>
        /// Search : SIM_MoveStudent
        /// Tìm dữ liệu
        /// Store: SIM_MoveStudent_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_MoveStudent_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_MoveStudent
        /// Thêm dữ liệu
        /// Store: SIM_MoveStudent_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MoveStudent_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SourceClassID, this.strSourceClassID);
                objIData.AddParameter(P_DesClassID, this.strDesClassID);
                objIData.AddParameter(P_MoveDate, this.dtmMoveDate);
                objIData.AddParameter(P_TypeAction, this.intTypeAction);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.intMoveStudentID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_MoveStudent", objEx);
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
        /// Update : SIM_MoveStudent
        /// Cập nhật dữ liệu
        /// Store: SIM_MoveStudent_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MoveStudent_EDIT");
                objIData.AddParameter(P_MoveStudentID, this.intMoveStudentID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SourceClassID, this.strSourceClassID);
                objIData.AddParameter(P_DesClassID, this.strDesClassID);
                objIData.AddParameter(P_MoveDate, this.dtmMoveDate);
                objIData.AddParameter(P_TypeAction, this.intTypeAction);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_MoveStudent", objEx);
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
        /// Delete : SIM_MoveStudent
        /// Xóa dữ liệu
        /// Store: SIM_MoveStudent_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MoveStudent_DELETE");
                objIData.AddParameter(P_MoveStudentID, this.intMoveStudentID);
                objIData.AddParameter(P_DeletedUser, this.strDeletedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_MoveStudent", objEx);
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
        /// Store: SIM_MoveStudent_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(int? intMoveStudentID, string strDeletedUser)
        {
            this.intMoveStudentID = intMoveStudentID;
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

        public SIM_MoveStudent()
        {
        }
        public SIM_MoveStudent(int? intMoveStudentID)
        {
            this.intMoveStudentID = intMoveStudentID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_MoveStudentID = "@" + C_MoveStudentID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_SourceClassID = "@" + C_SourceClassID;
        public const String P_DesClassID = "@" + C_DesClassID;
        public const String P_MoveDate = "@" + C_MoveDate;
        public const String P_TypeAction = "@" + C_TypeAction;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_IsDeleted = "@" + C_IsDeleted;
        public const String P_DeletedDate = "@" + C_DeletedDate;
        public const String P_DeletedUser = "@" + C_DeletedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_MoveStudentID = "MoveStudentID";
        public const String C_StudentID = "StudentID";
        public const String C_SourceClassID = "SourceClassID";
        public const String C_DesClassID = "DesClassID";
        public const String C_MoveDate = "MoveDate";
        public const String C_TypeAction = "TypeAction";
        public const String C_Description = "Description";
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
