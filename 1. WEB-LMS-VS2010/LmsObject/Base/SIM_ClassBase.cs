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
    /// [SIM] Lớp hành chính thuộc khoa và khóa tuyển sinh.
    /// </summary>
    public partial class SIM_Class
    {
        #region Member Variables

        private int intDataGroupID;
        private string strClassID;
        private string strClassName;
        private string strClassShortName;
        private string strScienceID;
        private string strCourseID;
        private string strTrainingLevelID;
        private string strTrainingType;
        private int intClassSize;
        private DateTime? dtmStartAt;
        private DateTime? dtmFinishAt;
        private string strManagerTeacherID;
        private bool bolIsActived;
        private string strDescription;
        private IData objIData;
        private bool bolIsExistIData;
        private Exception objErrorException;

        #endregion

        #region Properties

        /// <summary>
        /// Mã đơn vị hoặc nhóm dữ liệu sở hữu lớp học.
        /// </summary>
        public int DataGroupID
        {
            get { return intDataGroupID; }
            set { intDataGroupID = value; }
        }

        /// <summary>
        /// Mã định danh duy nhất của lớp học.
        /// </summary>
        public string ClassID
        {
            get { return strClassID; }
            set { strClassID = value; }
        }

        /// <summary>
        /// Tên đầy đủ của lớp học.
        /// </summary>
        public string ClassName
        {
            get { return strClassName; }
            set { strClassName = value; }
        }

        /// <summary>
        /// Tên viết tắt của lớp học.
        /// </summary>
        public string ClassShortName
        {
            get { return strClassShortName; }
            set { strClassShortName = value; }
        }

        /// <summary>
        /// Mã khoa hoặc chuyên ngành quản lý lớp.
        /// </summary>
        public string ScienceID
        {
            get { return strScienceID; }
            set { strScienceID = value; }
        }

        /// <summary>
        /// Mã khóa học hoặc khóa tuyển sinh.
        /// </summary>
        public string CourseID
        {
            get { return strCourseID; }
            set { strCourseID = value; }
        }

        /// <summary>
        /// Mã trình độ đào tạo (ví dụ: Đại học, Cao đẳng).
        /// </summary>
        public string TrainingLevelID
        {
            get { return strTrainingLevelID; }
            set { strTrainingLevelID = value; }
        }

        /// <summary>
        /// Loại hình đào tạo (ví dụ: Chính quy, Bằng 2, Liên thông).
        /// </summary>
        public string TrainingType
        {
            get { return strTrainingType; }
            set { strTrainingType = value; }
        }

        /// <summary>
        /// Số lượng sinh viên tối đa của lớp.
        /// </summary>
        public int ClassSize
        {
            get { return intClassSize; }
            set { intClassSize = value; }
        }

        /// <summary>
        /// Ngày bắt đầu khóa học/lớp.
        /// </summary>
        public DateTime? StartAt
        {
            get { return dtmStartAt; }
            set { dtmStartAt = value; }
        }

        /// <summary>
        /// Ngày kết thúc khóa học/lớp.
        /// </summary>
        public DateTime? FinishAt
        {
            get { return dtmFinishAt; }
            set { dtmFinishAt = value; }
        }

        /// <summary>
        /// Mã giáo viên chủ nhiệm hoặc quản lý lớp.
        /// </summary>
        public string ManagerTeacherID
        {
            get { return strManagerTeacherID; }
            set { strManagerTeacherID = value; }
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
        /// Mô tả thêm thông tin về lớp học.
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }

        public IData IDB
        {
            get { return objIData; }
            set { objIData = value; bolIsExistIData = (value != null); }
        }

        public Exception ErrorException
        {
            get { return objErrorException; }
            set { objErrorException = value; }
        }

        #endregion

        #region Methods

        public bool Parse(IDataReader reader)
        {
            try
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetName(i).Equals(C_DataGroupID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.intDataGroupID = Convert.ToInt32(reader[i]);
                    if (reader.GetName(i).Equals(C_ClassID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strClassID = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_ClassName, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strClassName = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_ClassShortName, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strClassShortName = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_ScienceID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strScienceID = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_CourseID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strCourseID = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_TrainingLevelID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strTrainingLevelID = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_TrainingType, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strTrainingType = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_ClassSize, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.intClassSize = Convert.ToInt32(reader[i]);
                    if (reader.GetName(i).Equals(C_StartAt, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.dtmStartAt = Convert.ToDateTime(reader[i]);
                    if (reader.GetName(i).Equals(C_FinishAt, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.dtmFinishAt = Convert.ToDateTime(reader[i]);
                    if (reader.GetName(i).Equals(C_ManagerTeacherID, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strManagerTeacherID = Convert.ToString(reader[i]);
                    if (reader.GetName(i).Equals(C_IsActived, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.bolIsActived = Convert.ToBoolean(reader[i]);
                    if (reader.GetName(i).Equals(C_Description, StringComparison.OrdinalIgnoreCase) && !Convert.IsDBNull(reader[i])) this.strDescription = Convert.ToString(reader[i]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        public bool Parse(DataRow drw)
        {
            try
            {
                if (drw.Table.Columns.Contains(C_DataGroupID) && !Convert.IsDBNull(drw[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(drw[C_DataGroupID]);
                if (drw.Table.Columns.Contains(C_ClassID) && !Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
                if (drw.Table.Columns.Contains(C_ClassName) && !Convert.IsDBNull(drw[C_ClassName])) this.strClassName = Convert.ToString(drw[C_ClassName]);
                if (drw.Table.Columns.Contains(C_ClassShortName) && !Convert.IsDBNull(drw[C_ClassShortName])) this.strClassShortName = Convert.ToString(drw[C_ClassShortName]);
                if (drw.Table.Columns.Contains(C_ScienceID) && !Convert.IsDBNull(drw[C_ScienceID])) this.strScienceID = Convert.ToString(drw[C_ScienceID]);
                if (drw.Table.Columns.Contains(C_CourseID) && !Convert.IsDBNull(drw[C_CourseID])) this.strCourseID = Convert.ToString(drw[C_CourseID]);
                if (drw.Table.Columns.Contains(C_TrainingLevelID) && !Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
                if (drw.Table.Columns.Contains(C_TrainingType) && !Convert.IsDBNull(drw[C_TrainingType])) this.strTrainingType = Convert.ToString(drw[C_TrainingType]);
                if (drw.Table.Columns.Contains(C_ClassSize) && !Convert.IsDBNull(drw[C_ClassSize])) this.intClassSize = Convert.ToInt32(drw[C_ClassSize]);
                if (drw.Table.Columns.Contains(C_StartAt) && !Convert.IsDBNull(drw[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(drw[C_StartAt]);
                if (drw.Table.Columns.Contains(C_FinishAt) && !Convert.IsDBNull(drw[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(drw[C_FinishAt]);
                if (drw.Table.Columns.Contains(C_ManagerTeacherID) && !Convert.IsDBNull(drw[C_ManagerTeacherID])) this.strManagerTeacherID = Convert.ToString(drw[C_ManagerTeacherID]);
                if (drw.Table.Columns.Contains(C_IsActived) && !Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
                if (drw.Table.Columns.Contains(C_Description) && !Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class", objEx);
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
                objIData.AddParameter(P_ClassID, this.strClassID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                bool result = reader.Read() && Parse(reader);
                reader.Close();
                return result;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin trong SIM_Class", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        public SIM_Class Get(int intDataGroupID, string strClassID)
        {
            SIM_Class obj = new SIM_Class();
            if (objIData != null) obj.IDB = objIData;
            obj.DataGroupID = intDataGroupID;
            obj.ClassID = strClassID;
            if (obj.Get()) return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }

        public SIM_Class Get(string strClassID)
        {
            SIM_Class obj = new SIM_Class();
            if (objIData != null) obj.IDB = objIData;
            obj.ClassID = strClassID;
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class", objEx);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class", objEx);
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
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_ClassName, this.strClassName);
                objIData.AddParameter(P_ClassShortName, this.strClassShortName);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_TrainingType, this.strTrainingType);
                objIData.AddParameter(P_ClassSize, this.intClassSize);
                objIData.AddParameter(P_StartAt, this.dtmStartAt);
                objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
                objIData.AddParameter(P_ManagerTeacherID, this.strManagerTeacherID);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin trong SIM_Class", objEx);
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
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.AddParameter(P_ClassName, this.strClassName);
                objIData.AddParameter(P_ClassShortName, this.strClassShortName);
                objIData.AddParameter(P_ScienceID, this.strScienceID);
                objIData.AddParameter(P_CourseID, this.strCourseID);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_TrainingType, this.strTrainingType);
                objIData.AddParameter(P_ClassSize, this.intClassSize);
                objIData.AddParameter(P_StartAt, this.dtmStartAt);
                objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
                objIData.AddParameter(P_ManagerTeacherID, this.strManagerTeacherID);
                objIData.AddParameter(P_IsActived, this.bolIsActived);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Class", objEx);
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
                objIData.AddParameter(P_ClassID, this.strClassID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData) this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Class", objEx);
                this.objErrorException = objEx;
                return false;
            }
            finally { if (!bolIsExistIData) objIData.Disconnect(); }
        }

        /// <summary>
        /// Xóa dữ liệu
        /// Store: SIM_Class_DELETE
        /// </summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(string strClassID)
        {
            this.strClassID = strClassID;
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

        public SIM_Class() { }
        public SIM_Class(int intDataGroupID, string strClassID)
        {
            this.intDataGroupID = intDataGroupID;
            this.strClassID = strClassID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Class";
        public const string StoreGet = "SIM_Class_GET";
        public const string StoreGetAll = "SIM_Class_GETALL";
        public const string StoreSearch = "SIM_Class_SEARCH";
        public const string StoreAdd = "SIM_Class_ADD";
        public const string StoreEdit = "SIM_Class_EDIT";
        public const string StoreDelete = "SIM_Class_DELETE";

        public const string P_DataGroupID = "@" + C_DataGroupID;
        public const string P_ClassID = "@" + C_ClassID;
        public const string P_ClassName = "@" + C_ClassName;
        public const string P_ClassShortName = "@" + C_ClassShortName;
        public const string P_ScienceID = "@" + C_ScienceID;
        public const string P_CourseID = "@" + C_CourseID;
        public const string P_TrainingLevelID = "@" + C_TrainingLevelID;
        public const string P_TrainingType = "@" + C_TrainingType;
        public const string P_ClassSize = "@" + C_ClassSize;
        public const string P_StartAt = "@" + C_StartAt;
        public const string P_FinishAt = "@" + C_FinishAt;
        public const string P_ManagerTeacherID = "@" + C_ManagerTeacherID;
        public const string P_IsActived = "@" + C_IsActived;
        public const string P_Description = "@" + C_Description;

        public const string C_DataGroupID = "DataGroupID";
        public const string C_ClassID = "ClassID";
        public const string C_ClassName = "ClassName";
        public const string C_ClassShortName = "ClassShortName";
        public const string C_ScienceID = "ScienceID";
        public const string C_CourseID = "CourseID";
        public const string C_TrainingLevelID = "TrainingLevelID";
        public const string C_TrainingType = "TrainingType";
        public const string C_ClassSize = "ClassSize";
        public const string C_StartAt = "StartAt";
        public const string C_FinishAt = "FinishAt";
        public const string C_ManagerTeacherID = "ManagerTeacherID";
        public const string C_IsActived = "IsActived";
        public const string C_Description = "Description";

        #endregion
    }
}
