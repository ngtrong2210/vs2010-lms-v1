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
    /// [SIM] Danh mục khóa tuyển sinh, ví dụ K18; không phải không gian học trực tuyến.
    /// </summary>
    public partial class SIM_Course
    {
        #region Member Variables

        private int intDataGroupID;
        private string strCourseID;
        private string strCourseName;
        private int intStartYear;
        private int intFinishYear;
        private bool bolIsActived;
        private IData objIData;
        private bool bolIsExistIData;
        private Exception objErrorException;

        #endregion

        #region Properties

        /// <summary>
        /// Mã đơn vị hoặc nhóm dữ liệu sở hữu khóa tuyển sinh.
        /// </summary>
        public int DataGroupID
        {
            get { return intDataGroupID; }
            set { intDataGroupID = value; }
        }

        /// <summary>
        /// Mã định danh duy nhất của khóa tuyển sinh.
        /// </summary>
        public string CourseID
        {
            get { return strCourseID; }
            set { strCourseID = value; }
        }

        /// <summary>
        /// Tên khóa tuyển sinh (ví dụ: K18, K19).
        /// </summary>
        public string CourseName
        {
            get { return strCourseName; }
            set { strCourseName = value; }
        }

        /// <summary>
        /// Năm bắt đầu khóa tuyển sinh.
        /// </summary>
        public int StartYear
        {
            get { return intStartYear; }
            set { intStartYear = value; }
        }

        /// <summary>
        /// Năm kết thúc khóa tuyển sinh.
        /// </summary>
        public int FinishYear
        {
            get { return intFinishYear; }
            set { intFinishYear = value; }
        }

        /// <summary>
        /// Trạng thái kích hoạt: true ? Đang hoạt động : false ? Đã khóa.
        /// </summary>
        public bool IsActived
        {
            get { return bolIsActived; }
            set { bolIsActived = value; }
        }

        /// <summary>
        /// Giao diện kết nối cơ sở dữ liệu.
        /// </summary>
        public IData IDB
        {
            get { return objIData; }
            set { objIData = value; bolIsExistIData = (value != null); }
        }

        /// <summary>
        /// Thông tin lỗi khi thực hiện thao tác cơ sở dữ liệu.
        /// </summary>
        public Exception ErrorException
        {
            get { return objErrorException; }
            set { objErrorException = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Đọc dữ liệu từ IDataReader vào đối tượng.
        /// </summary>
        public bool Parse(IDataReader reader)
        {
            try
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).Equals(C_DataGroupID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.intDataGroupID = Convert.ToInt32(reader[i]);
                    if (reader.GetName(i).Equals(C_CourseID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strCourseID = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_CourseName, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strCourseName = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_StartYear, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.intStartYear = Convert.ToInt32(reader[i]);
                    if (reader.GetName(i).Equals(C_FinishYear, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.intFinishYear = Convert.ToInt32(reader[i]);
                    if (reader.GetName(i).Equals(C_IsActived, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.bolIsActived = Convert.ToBoolean(reader[i]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        /// <summary>
        /// Đọc dữ liệu từ DataRow vào đối tượng.
        /// </summary>
        public bool Parse(DataRow drw)
        {
            try
            {
                if (drw.Table.Columns.Contains(C_DataGroupID) && !Convert.IsDBNull(drw[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(drw[C_DataGroupID]);
                if (drw.Table.Columns.Contains(C_CourseID) && !Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
                if (drw.Table.Columns.Contains(C_CourseName) && !Convert.IsDBNull(drw[C_CourseName])) this.strCourseName = Convert.ToString(drw[C_CourseName]);
                if (drw.Table.Columns.Contains(C_StartYear) && !Convert.IsDBNull(drw[C_StartYear])) this.intStartYear = Convert.ToInt32(drw[C_StartYear]);
                if (drw.Table.Columns.Contains(C_FinishYear) && !Convert.IsDBNull(drw[C_FinishYear])) this.intFinishYear = Convert.ToInt32(drw[C_FinishYear]);
                if (drw.Table.Columns.Contains(C_IsActived) && !Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        /// <summary>
        /// Nạp thông tin từ cơ sở dữ liệu theo khóa chính.
        /// </summary>
        public bool Get()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                bool result = reader.Read() && Parse(reader);
                reader.Close();
                return result;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Nạp thông tin theo khóa chính (DataGroupID, CourseID).
        /// </summary>
        public SIM_Course Get(int intDataGroupID, string strCourseID)
        {
            SIM_Course obj = new SIM_Course();
            if (objIData != null) obj.IDB = objIData;
            obj.DataGroupID = intDataGroupID;
            obj.CourseID = strCourseID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        /// <summary>
        /// Nạp thông tin theo khóa chính (CourseID).
        /// </summary>
        public SIM_Course Get(string strCourseID)
        {
            SIM_Course obj = new SIM_Course();
            if (objIData != null) obj.IDB = objIData;
            obj.CourseID = strCourseID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        /// <summary>
        /// Thực thi stored procedure không trả về dữ liệu (INSERT, UPDATE, DELETE).
        /// </summary>
        public bool ExecNonQuery(string storeName, params object[] pars)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Thực thi stored procedure trả về DataTable.
        /// </summary>
        public DataTable GetDataTable(string storeName, params object[] pars)
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Lấy danh sách tất cả các khóa tuyển sinh.
        /// </summary>
        public DataTable GetAll()
        {
            return GetDataTable(StoreGetAll);
        }

        /// <summary>
        /// Tìm kiếm khóa tuyển sinh theo điều kiện.
        /// </summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable(StoreSearch, pars);
        }

        /// <summary>
        /// Thêm mới khóa tuyển sinh.
        /// </summary>
        public bool Add()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_CourseName, this.strCourseName);
                objIData.AddParameter(P_StartYear, this.intStartYear);
                objIData.AddParameter(P_FinishYear, this.intFinishYear);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Cập nhật thông tin khóa tuyển sinh.
        /// </summary>
        public bool Update()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_CourseName, this.strCourseName);
                objIData.AddParameter(P_StartYear, this.intStartYear);
                objIData.AddParameter(P_FinishYear, this.intFinishYear);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Xóa khóa tuyển sinh.
        /// </summary>
        public bool Delete()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Course", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        #endregion

        #region Transaction methods

        /// <summary>
        /// Bắt đầu giao dịch (transaction).
        /// </summary>
        public bool BeginTransaction()
        {
            objIData = DCore.Data.CreateData();
            try { objIData.Connect(); objIData.BeginTransaction(); bolIsExistIData = true; return true; }
            catch (Exception objEx) { this.objErrorException = objEx; return false; }
        }

        /// <summary>
        /// Xác nhận giao dịch (commit).
        /// </summary>
        public void CommitTransaction() { objIData.CommitTransaction(); objIData.Disconnect(); bolIsExistIData = false; }

        /// <summary>
        /// Hoàn tác giao dịch (rollback).
        /// </summary>
        public void RollBackTransaction() { objIData.RollBackTransaction(); objIData.Disconnect(); bolIsExistIData = false; }

        #endregion

        #region Constructor

        /// <summary>
        /// Khởi tạo đối tượng mặc định.
        /// </summary>
        public SIM_Course() { }

        /// <summary>
        /// Khởi tạo đối tượng theo khóa chính.
        /// </summary>
        public SIM_Course(int intDataGroupID, string strCourseID)
        {
            this.intDataGroupID = intDataGroupID;
            this.strCourseID = strCourseID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Course";
        public const string StoreGet = "SIM_Course_GET";
        public const string StoreGetAll = "SIM_Course_GETALL";
        public const string StoreSearch = "SIM_Course_SEARCH";
        public const string StoreAdd = "SIM_Course_ADD";
        public const string StoreEdit = "SIM_Course_EDIT";
        public const string StoreDelete = "SIM_Course_DELETE";

        public const string P_DataGroupID = "@" + C_DataGroupID;
        public const string P_CourseID = "@" + C_CourseID;
        public const string P_CourseName = "@" + C_CourseName;
        public const string P_StartYear = "@" + C_StartYear;
        public const string P_FinishYear = "@" + C_FinishYear;
        public const string P_IsActived = "@" + C_IsActived;

        public const string C_DataGroupID = "DataGroupID";
        public const string C_CourseID = "CourseID";
        public const string C_CourseName = "CourseName";
        public const string C_StartYear = "StartYear";
        public const string C_FinishYear = "FinishYear";
        public const string C_IsActived = "IsActived";

        #endregion
    }
}
