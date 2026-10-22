
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
    /// Created date 	: 3/31/2013 
    /// Description 
    /// </summary>	
    public partial class SIM_MonthEthicMark
    {
        #region Member Variables

        private long? lngStudentID = null;//Mã sinh viên
        private DateTime? dtmMonth = null;//Tháng cơm
        private int? intYearID = null;//Mã niên học
        private int? intSemester = null;//Học kì
        private double? dblStudentEthicMark = null;//Điển rèn luyện cả năm của sinh viên
        private string strStudentEthicLevel = null;//Xếp loại rèn luyện sinh viên
        private double? dblTeacherEthicMark = null;//Điển rèn luyện GV
        private string strTeacherEthicLevel = null;//Xếp loại rèn luyện GV đánh giá
        private double? dblClassEthicMark = null;//Điển rèn luyện P.HSSV đánh giá
        private string strClassEthicLevel = null;//Xếp loại rèn luyện HSSV đánh giá
        private double? dblEthicMark = null;//Điển rèn luyện cả năm của hội đồng
        private string strEthicLevel = null;//Xếp loại rèn luyện cả năm
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
        /// StudentID
        /// Mã sinh viên
        /// </summary>
        public long? StudentID
        {
            get { return lngStudentID; }
            set { lngStudentID = value; }
        }
        /// <summary>
        /// Month
        /// Tháng cơm
        /// </summary>
        public DateTime? Month
        {
            get { return dtmMonth; }
            set { dtmMonth = value; }
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
        /// StudentEthicMark
        /// Điển rèn luyện cả năm của sinh viên
        /// </summary>
        public double? StudentEthicMark
        {
            get { return dblStudentEthicMark; }
            set { dblStudentEthicMark = value; }
        }
        /// <summary>
        /// StudentEthicLevel
        /// Xếp loại rèn luyện sinh viên
        /// </summary>
        public string StudentEthicLevel
        {
            get { return strStudentEthicLevel; }
            set { strStudentEthicLevel = value; }
        }
        /// <summary>
        /// TeacherEthicMark
        /// Điển rèn luyện GV
        /// </summary>
        public double? TeacherEthicMark
        {
            get { return dblTeacherEthicMark; }
            set { dblTeacherEthicMark = value; }
        }
        /// <summary>
        /// TeacherEthicLevel
        /// Xếp loại rèn luyện GV đánh giá
        /// </summary>
        public string TeacherEthicLevel
        {
            get { return strTeacherEthicLevel; }
            set { strTeacherEthicLevel = value; }
        }
        /// <summary>
        /// ClassEthicMark
        /// Điển rèn luyện P.HSSV đánh giá
        /// </summary>
        public double? ClassEthicMark
        {
            get { return dblClassEthicMark; }
            set { dblClassEthicMark = value; }
        }
        /// <summary>
        /// ClassEthicLevel
        /// Xếp loại rèn luyện HSSV đánh giá
        /// </summary>
        public string ClassEthicLevel
        {
            get { return strClassEthicLevel; }
            set { strClassEthicLevel = value; }
        }
        /// <summary>
        /// EthicMark
        /// Điển rèn luyện cả năm của hội đồng
        /// </summary>
        public double? EthicMark
        {
            get { return dblEthicMark; }
            set { dblEthicMark = value; }
        }
        /// <summary>
        /// EthicLevel
        /// Xếp loại rèn luyện cả năm
        /// </summary>
        public string EthicLevel
        {
            get { return strEthicLevel; }
            set { strEthicLevel = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Month.ToUpper()) && !Convert.IsDBNull(reader[C_Month])) this.dtmMonth = Convert.ToDateTime(reader[C_Month]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicMark])) this.dblStudentEthicMark = (double)reader[C_StudentEthicMark];
                    if (reader.GetName(i).ToUpper().Equals(C_StudentEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicLevel])) this.strStudentEthicLevel = Convert.ToString(reader[C_StudentEthicLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicMark])) this.dblTeacherEthicMark = (double)reader[C_TeacherEthicMark];
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicLevel])) this.strTeacherEthicLevel = Convert.ToString(reader[C_TeacherEthicLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicMark])) this.dblClassEthicMark = (double)reader[C_ClassEthicMark];
                    if (reader.GetName(i).ToUpper().Equals(C_ClassEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicLevel])) this.strClassEthicLevel = Convert.ToString(reader[C_ClassEthicLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_EthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark])) this.dblEthicMark = (double)reader[C_EthicMark];
                    if (reader.GetName(i).ToUpper().Equals(C_EthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel])) this.strEthicLevel = Convert.ToString(reader[C_EthicLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_MonthEthicMark", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_Month])) this.dtmMonth = Convert.ToDateTime(drw[C_Month]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_StudentEthicMark])) this.dblStudentEthicMark = (double)drw[C_StudentEthicMark];
                if (!Convert.IsDBNull(drw[C_StudentEthicLevel])) this.strStudentEthicLevel = Convert.ToString(drw[C_StudentEthicLevel]);
                if (!Convert.IsDBNull(drw[C_TeacherEthicMark])) this.dblTeacherEthicMark = (double)drw[C_TeacherEthicMark];
                if (!Convert.IsDBNull(drw[C_TeacherEthicLevel])) this.strTeacherEthicLevel = Convert.ToString(drw[C_TeacherEthicLevel]);
                if (!Convert.IsDBNull(drw[C_ClassEthicMark])) this.dblClassEthicMark = (double)drw[C_ClassEthicMark];
                if (!Convert.IsDBNull(drw[C_ClassEthicLevel])) this.strClassEthicLevel = Convert.ToString(drw[C_ClassEthicLevel]);
                if (!Convert.IsDBNull(drw[C_EthicMark])) this.dblEthicMark = (double)drw[C_EthicMark];
                if (!Convert.IsDBNull(drw[C_EthicLevel])) this.strEthicLevel = Convert.ToString(drw[C_EthicLevel]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_MonthEthicMark", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_MonthEthicMark_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MonthEthicMark_GET");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Month, this.dtmMonth);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_MonthEthicMark", objEx);
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
        /// Store: SIM_MonthEthicMark_GET 
        ///</summary>
        /// <returns> SIM_MonthEthicMark </returns>
        public SIM_MonthEthicMark Get(long? lngStudentID, DateTime? dtmMonth)
        {
            SIM_MonthEthicMark obj = new SIM_MonthEthicMark();
            if (objIData != null)
                obj.IDB = objIData;
            obj.StudentID = lngStudentID;
            obj.Month = dtmMonth;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_MonthEthicMark
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MonthEthicMark", objEx);
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
        /// Search : SIM_MonthEthicMark
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MonthEthicMark", objEx);
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
        /// Search : SIM_MonthEthicMark
        /// Lấy hết dữ liệu
        /// Store: SIM_MonthEthicMark_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_MonthEthicMark_GETALL");
        }

        ///<summary>
        /// Search : SIM_MonthEthicMark
        /// Tìm dữ liệu
        /// Store: SIM_MonthEthicMark_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_MonthEthicMark_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_MonthEthicMark
        /// Thêm dữ liệu
        /// Store: SIM_MonthEthicMark_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MonthEthicMark_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Month, this.dtmMonth);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_StudentEthicMark, this.dblStudentEthicMark);
                objIData.AddParameter(P_StudentEthicLevel, this.strStudentEthicLevel);
                objIData.AddParameter(P_TeacherEthicMark, this.dblTeacherEthicMark);
                objIData.AddParameter(P_TeacherEthicLevel, this.strTeacherEthicLevel);
                objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
                objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_MonthEthicMark", objEx);
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
        /// Update : SIM_MonthEthicMark
        /// Cập nhật dữ liệu
        /// Store: SIM_MonthEthicMark_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MonthEthicMark_EDIT");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Month, this.dtmMonth);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_StudentEthicMark, this.dblStudentEthicMark);
                objIData.AddParameter(P_StudentEthicLevel, this.strStudentEthicLevel);
                objIData.AddParameter(P_TeacherEthicMark, this.dblTeacherEthicMark);
                objIData.AddParameter(P_TeacherEthicLevel, this.strTeacherEthicLevel);
                objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
                objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
                objIData.AddParameter(P_EthicMark, this.dblEthicMark);
                objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_MonthEthicMark", objEx);
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
        /// Delete : SIM_MonthEthicMark
        /// Xóa dữ liệu
        /// Store: SIM_MonthEthicMark_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MonthEthicMark_DELETE");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_Month, this.dtmMonth);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_MonthEthicMark", objEx);
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
        /// Store: SIM_MonthEthicMark_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngStudentID, DateTime? dtmMonth)
        {
            this.lngStudentID = lngStudentID;
            this.dtmMonth = dtmMonth;
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

        public SIM_MonthEthicMark()
        {
        }
        public SIM_MonthEthicMark(long? lngStudentID, DateTime? dtmMonth)
        {
            this.lngStudentID = lngStudentID;
            this.dtmMonth = dtmMonth;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_StudentID = "@" + C_StudentID;
        public const String P_Month = "@" + C_Month;
        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_StudentEthicMark = "@" + C_StudentEthicMark;
        public const String P_StudentEthicLevel = "@" + C_StudentEthicLevel;
        public const String P_TeacherEthicMark = "@" + C_TeacherEthicMark;
        public const String P_TeacherEthicLevel = "@" + C_TeacherEthicLevel;
        public const String P_ClassEthicMark = "@" + C_ClassEthicMark;
        public const String P_ClassEthicLevel = "@" + C_ClassEthicLevel;
        public const String P_EthicMark = "@" + C_EthicMark;
        public const String P_EthicLevel = "@" + C_EthicLevel;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentID = "StudentID";
        public const String C_Month = "Month";
        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_StudentEthicMark = "StudentEthicMark";
        public const String C_StudentEthicLevel = "StudentEthicLevel";
        public const String C_TeacherEthicMark = "TeacherEthicMark";
        public const String C_TeacherEthicLevel = "TeacherEthicLevel";
        public const String C_ClassEthicMark = "ClassEthicMark";
        public const String C_ClassEthicLevel = "ClassEthicLevel";
        public const String C_EthicMark = "EthicMark";
        public const String C_EthicLevel = "EthicLevel";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}