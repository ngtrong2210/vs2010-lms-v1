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
    /// [SIM] Danh mục môn học thuộc chương trình đào tạo.
    /// </summary>
    public partial class SIM_Subject
    {
        #region Member Variables

        private int intDataGroupID = 0;//Cột DataGroupID của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strSubjectID = null;//Cột SubjectID của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strSubjectName = null;//Cột SubjectName của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strSubjectShortName = null;//Cột SubjectShortName của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strScienceID = null;//Cột ScienceID của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strSubjectGroupID = null;//Cột SubjectGroupID của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intTheoryQuantity = 0;//Cột TheoryQuantity của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intPracticeQuantity = 0;//Cột PracticeQuantity của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intTestQuantity = 0;//Cột TestQuantity của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private byte bytCreditCount = 0;//Cột CreditCount của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private bool bolIsActived = false;//Cột IsActived của bảng SIM_Subject, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// Mã đơn vị hoặc nhóm dữ liệu sở hữu môn học.
        /// </summary>
        public int DataGroupID
        {
            get { return intDataGroupID; }
            set { intDataGroupID = value; }
        }

        /// <summary>
        /// Mã định danh duy nhất của môn học.
        /// </summary>
        public string SubjectID
        {
            get { return strSubjectID; }
            set { strSubjectID = value; }
        }

        /// <summary>
        /// Tên đầy đủ của môn học.
        /// </summary>
        public string SubjectName
        {
            get { return strSubjectName; }
            set { strSubjectName = value; }
        }

        /// <summary>
        /// Tên viết tắt của môn học.
        /// </summary>
        public string SubjectShortName
        {
            get { return strSubjectShortName; }
            set { strSubjectShortName = value; }
        }

        /// <summary>
        /// Mã lĩnh vực khoa học hoặc chuyên ngành liên quan.
        /// </summary>
        public string ScienceID
        {
            get { return strScienceID; }
            set { strScienceID = value; }
        }

        /// <summary>
        /// Mã nhóm môn học hoặc khối kiến thức.
        /// </summary>
        public string SubjectGroupID
        {
            get { return strSubjectGroupID; }
            set { strSubjectGroupID = value; }
        }

        /// <summary>
        /// Số tiết lý thuyết.
        /// </summary>
        public int TheoryQuantity
        {
            get { return intTheoryQuantity; }
            set { intTheoryQuantity = value; }
        }

        /// <summary>
        /// Số tiết thực hành.
        /// </summary>
        public int PracticeQuantity
        {
            get { return intPracticeQuantity; }
            set { intPracticeQuantity = value; }
        }

        /// <summary>
        /// Số tiết kiểm tra/bài kiểm tra.
        /// </summary>
        public int TestQuantity
        {
            get { return intTestQuantity; }
            set { intTestQuantity = value; }
        }

        /// <summary>
        /// Số tín chỉ của môn học.
        /// </summary>
        public byte CreditCount
        {
            get { return bytCreditCount; }
            set { bytCreditCount = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_DataGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(reader[C_DataGroupID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectName.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectName])) this.strSubjectName = Convert.ToString(reader[C_SubjectName]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectShortName.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectShortName])) this.strSubjectShortName = Convert.ToString(reader[C_SubjectShortName]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScienceID.ToUpper()) && !Convert.IsDBNull(reader[C_ScienceID])) this.strScienceID = Convert.ToString(reader[C_ScienceID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectGroupID])) this.strSubjectGroupID = Convert.ToString(reader[C_SubjectGroupID]);
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(reader[C_TheoryQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(reader[C_PracticeQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_TestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(reader[C_TestQuantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreditCount.ToUpper()) && !Convert.IsDBNull(reader[C_CreditCount])) this.bytCreditCount = Convert.ToByte(reader[C_CreditCount]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi chuyển đổi dữ liệu từ IDataReader sang SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        public bool Parse(DataRow drw)
        {
            try
            {
                if (!Convert.IsDBNull(drw[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(drw[C_DataGroupID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_SubjectName])) this.strSubjectName = Convert.ToString(drw[C_SubjectName]);
                if (!Convert.IsDBNull(drw[C_SubjectShortName])) this.strSubjectShortName = Convert.ToString(drw[C_SubjectShortName]);
                if (!Convert.IsDBNull(drw[C_ScienceID])) this.strScienceID = Convert.ToString(drw[C_ScienceID]);
                if (!Convert.IsDBNull(drw[C_SubjectGroupID])) this.strSubjectGroupID = Convert.ToString(drw[C_SubjectGroupID]);
                if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(drw[C_TheoryQuantity]);
                if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(drw[C_PracticeQuantity]);
                if (!Convert.IsDBNull(drw[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(drw[C_TestQuantity]);
                if (!Convert.IsDBNull(drw[C_CreditCount])) this.bytCreditCount = Convert.ToByte(drw[C_CreditCount]);
                if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi chuyển đổi dữ liệu từ DataRow sang SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        public bool Get()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                bool result = reader.Read() && Parse(reader);
                reader.Close();
                return result;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin trong SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public SIM_Subject Get(int intDataGroupID, string strSubjectID)
        {
            SIM_Subject obj = new SIM_Subject();
            if (objIData != null) obj.IDB = objIData;
            obj.DataGroupID = intDataGroupID;
            obj.SubjectID = strSubjectID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        public SIM_Subject Get(string strSubjectID)
        {
            SIM_Subject obj = new SIM_Subject();
            if (objIData != null) obj.IDB = objIData;
            obj.SubjectID = strSubjectID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Subject", objEx);
                this.objErrorException = objEx;
                return null;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public DataTable GetAll()
        {
            return GetDataTable(StoreGetAll);
        }

        public DataTable Search(params object[] pars)
        {
            return GetDataTable(StoreSearch, pars);
        }

        public bool Add()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_SubjectName, this.strSubjectName);
                objIData.AddParameter(P_SubjectShortName, this.strSubjectShortName);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_SubjectGroupID, this.strSubjectGroupID);
                objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
                objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
                objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
                objIData.AddParameter(P_CreditCount, this.bytCreditCount);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin trong SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public bool Update()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_SubjectName, this.strSubjectName);
                objIData.AddParameter(P_SubjectShortName, this.strSubjectShortName);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_SubjectGroupID, this.strSubjectGroupID);
                objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
                objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
                objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
                objIData.AddParameter(P_CreditCount, this.bytCreditCount);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public bool Delete()
        {
            if (!bolIsExistIData) objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Subject", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Xóa dữ liệu
        /// Store: SIM_Subject_DELETE
        /// </summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(string strSubjectID)
        {
            this.strSubjectID = strSubjectID;
            return this.Delete();
        }

        #endregion

        #region Transaction methods

        public bool BeginTransaction()
        {
            objIData = DCore.Data.CreateData();
            try { objIData.Connect(); objIData.BeginTransaction(); bolIsExistIData = true; return true; }
            catch (Exception objEx) { this.objErrorException = objEx; return false; }
        }

        public void CommitTransaction() { objIData.CommitTransaction(); objIData.Disconnect(); bolIsExistIData = false; }
        public void RollBackTransaction() { objIData.RollBackTransaction(); objIData.Disconnect(); bolIsExistIData = false; }

        #endregion

        #region Constructor

        public SIM_Subject() { }
        public SIM_Subject(int intDataGroupID, string strSubjectID)
        {
            this.intDataGroupID = intDataGroupID;
            this.strSubjectID = strSubjectID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Subject";
        public const string StoreGet = "SIM_Subject_GET";
        public const string StoreGetAll = "SIM_Subject_GETALL";
        public const string StoreSearch = "SIM_Subject_SEARCH";
        public const string StoreAdd = "SIM_Subject_ADD";
        public const string StoreEdit = "SIM_Subject_EDIT";
        public const string StoreDelete = "SIM_Subject_DELETE";

        #region Parameter Names

        public const string P_DataGroupID = "@" + C_DataGroupID;
        public const string P_SubjectID = "@" + C_SubjectID;
        public const string P_SubjectName = "@" + C_SubjectName;
        public const string P_SubjectShortName = "@" + C_SubjectShortName;
        public const string P_ScienceID = "@" + C_ScienceID;
        public const string P_SubjectGroupID = "@" + C_SubjectGroupID;
        public const string P_TheoryQuantity = "@" + C_TheoryQuantity;
        public const string P_PracticeQuantity = "@" + C_PracticeQuantity;
        public const string P_TestQuantity = "@" + C_TestQuantity;
        public const string P_CreditCount = "@" + C_CreditCount;
        public const string P_IsActived = "@" + C_IsActived;

        #endregion

        #region Column Names

        public const string C_DataGroupID = "DataGroupID";
        public const string C_SubjectID = "SubjectID";
        public const string C_SubjectName = "SubjectName";
        public const string C_SubjectShortName = "SubjectShortName";
        public const string C_ScienceID = "ScienceID";
        public const string C_SubjectGroupID = "SubjectGroupID";
        public const string C_TheoryQuantity = "TheoryQuantity";
        public const string C_PracticeQuantity = "PracticeQuantity";
        public const string C_TestQuantity = "TestQuantity";
        public const string C_CreditCount = "CreditCount";
        public const string C_IsActived = "IsActived";

        #endregion

        #endregion
    }
}
