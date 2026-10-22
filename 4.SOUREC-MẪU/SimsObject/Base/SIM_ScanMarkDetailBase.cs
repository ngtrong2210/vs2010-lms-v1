
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
	/// Created date 	: 9/11/2013 
	/// Description 
	/// </summary>	
    public partial class SIM_ScanMarkDetail
    {
        #region Member Variables

        private long? lngScanMarkDataID = null;
        private long? lngScanMarkID = null;//Mã nhận dạng mỗi lần in
        private int? intExamOrder = null;//Lần thi dành cho sv thi tốt nghiệp, fai có chi tiết chứ ko theo tờ giấy 
        private int? intOrderIndex = null;//Thứ tự danh sách khi in
        private long? lngSubjectMarkID = null;//Thứ tự đó thì ứng với mã sổ điểm nào. Vì có thể trộn phòng thi, thì 
        private double? dblMark = null;//Điểm thi
        private double? dblMark1 = null;//Cột điểm 1
        private double? dblMark2 = null;//Cột điểm 2
        private double? dblMark3 = null;//Cột điểm 3
        private double? dblMark4 = null;//Cột điểm 4
        private long? lngScanMarkFileID = null;//Mã file scan đã cập nhật điểm vô dòng này
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// ScanMarkDataID
        /// 
        /// </summary>
        public long? ScanMarkDataID
        {
            get { return lngScanMarkDataID; }
            set { lngScanMarkDataID = value; }
        }
        /// <summary>
        /// ScanMarkID
        /// Mã nhận dạng mỗi lần in
        /// </summary>
        public long? ScanMarkID
        {
            get { return lngScanMarkID; }
            set { lngScanMarkID = value; }
        }
        /// <summary>
        /// ExamOrder
        /// Lần thi dành cho sv thi tốt nghiệp, fai có chi tiết chứ ko theo tờ giấy 
        /// </summary>
        public int? ExamOrder
        {
            get { return intExamOrder; }
            set { intExamOrder = value; }
        }
        /// <summary>
        /// OrderIndex
        /// Thứ tự danh sách khi in
        /// </summary>
        public int? OrderIndex
        {
            get { return intOrderIndex; }
            set { intOrderIndex = value; }
        }
        /// <summary>
        /// SubjectMarkID
        /// Thứ tự đó thì ứng với mã sổ điểm nào. Vì có thể trộn phòng thi, thì 
        /// </summary>
        public long? SubjectMarkID
        {
            get { return lngSubjectMarkID; }
            set { lngSubjectMarkID = value; }
        }
        /// <summary>
        /// Mark
        /// Điểm thi
        /// </summary>
        public double? Mark
        {
            get { return dblMark; }
            set { dblMark = value; }
        }
        /// <summary>
        /// Mark1
        /// Cột điểm 1
        /// </summary>
        public double? Mark1
        {
            get { return dblMark1; }
            set { dblMark1 = value; }
        }
        /// <summary>
        /// Mark2
        /// Cột điểm 2
        /// </summary>
        public double? Mark2
        {
            get { return dblMark2; }
            set { dblMark2 = value; }
        }
        /// <summary>
        /// Mark3
        /// Cột điểm 3
        /// </summary>
        public double? Mark3
        {
            get { return dblMark3; }
            set { dblMark3 = value; }
        }
        /// <summary>
        /// Mark4
        /// Cột điểm 4
        /// </summary>
        public double? Mark4
        {
            get { return dblMark4; }
            set { dblMark4 = value; }
        }
        /// <summary>
        /// ScanMarkFileID
        /// Mã file scan đã cập nhật điểm vô dòng này
        /// </summary>
        public long? ScanMarkFileID
        {
            get { return lngScanMarkFileID; }
            set { lngScanMarkFileID = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_ScanMarkDataID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanMarkDataID])) this.lngScanMarkDataID = Convert.ToInt64(reader[C_ScanMarkDataID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ScanMarkID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanMarkID])) this.lngScanMarkID = Convert.ToInt64(reader[C_ScanMarkID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExamOrder.ToUpper()) && !Convert.IsDBNull(reader[C_ExamOrder])) this.intExamOrder = Convert.ToInt32(reader[C_ExamOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectMarkID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectMarkID])) this.lngSubjectMarkID = Convert.ToInt64(reader[C_SubjectMarkID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark.ToUpper()) && !Convert.IsDBNull(reader[C_Mark])) this.dblMark = (double)reader[C_Mark];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark1.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1])) this.dblMark1 = (double)reader[C_Mark1];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark2.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2])) this.dblMark2 = (double)reader[C_Mark2];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark3.ToUpper()) && !Convert.IsDBNull(reader[C_Mark3])) this.dblMark3 = (double)reader[C_Mark3];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark4.ToUpper()) && !Convert.IsDBNull(reader[C_Mark4])) this.dblMark4 = (double)reader[C_Mark4];
                    if (reader.GetName(i).ToUpper().Equals(C_ScanMarkFileID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanMarkFileID])) this.lngScanMarkFileID = Convert.ToInt64(reader[C_ScanMarkFileID]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScanMarkDetail", objEx);
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
                if (!Convert.IsDBNull(drw[C_ScanMarkDataID])) this.lngScanMarkDataID = Convert.ToInt64(drw[C_ScanMarkDataID]);
                if (!Convert.IsDBNull(drw[C_ScanMarkID])) this.lngScanMarkID = Convert.ToInt64(drw[C_ScanMarkID]);
                if (!Convert.IsDBNull(drw[C_ExamOrder])) this.intExamOrder = Convert.ToInt32(drw[C_ExamOrder]);
                if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
                if (!Convert.IsDBNull(drw[C_SubjectMarkID])) this.lngSubjectMarkID = Convert.ToInt64(drw[C_SubjectMarkID]);
                if (!Convert.IsDBNull(drw[C_Mark])) this.dblMark = (double)drw[C_Mark];
                if (!Convert.IsDBNull(drw[C_Mark1])) this.dblMark1 = (double)drw[C_Mark1];
                if (!Convert.IsDBNull(drw[C_Mark2])) this.dblMark2 = (double)drw[C_Mark2];
                if (!Convert.IsDBNull(drw[C_Mark3])) this.dblMark3 = (double)drw[C_Mark3];
                if (!Convert.IsDBNull(drw[C_Mark4])) this.dblMark4 = (double)drw[C_Mark4];
                if (!Convert.IsDBNull(drw[C_ScanMarkFileID])) this.lngScanMarkFileID = Convert.ToInt64(drw[C_ScanMarkFileID]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScanMarkDetail", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_ScanMarkDetail_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkDetail_GET");
                objIData.AddParameter(P_ScanMarkDataID, this.lngScanMarkDataID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScanMarkDetail", objEx);
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
        /// Store: SIM_ScanMarkDetail_GET 
        ///</summary>
        /// <returns> SIM_ScanMarkDetail </returns>
        public SIM_ScanMarkDetail Get(long? lngScanMarkDataID)
        {
            SIM_ScanMarkDetail obj = new SIM_ScanMarkDetail();
            if (objIData != null)
                obj.IDB = objIData;
            obj.ScanMarkDataID = lngScanMarkDataID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_ScanMarkDetail
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanMarkDetail", objEx);
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
        /// Search : SIM_ScanMarkDetail
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanMarkDetail", objEx);
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
        /// Search : SIM_ScanMarkDetail
        /// Lấy hết dữ liệu
        /// Store: SIM_ScanMarkDetail_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_ScanMarkDetail_GETALL");
        }

        ///<summary>
        /// Search : SIM_ScanMarkDetail
        /// Tìm dữ liệu
        /// Store: SIM_ScanMarkDetail_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_ScanMarkDetail_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_ScanMarkDetail
        /// Thêm dữ liệu
        /// Store: SIM_ScanMarkDetail_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkDetail_ADD");
                objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
                objIData.AddParameter(P_ExamOrder, this.intExamOrder);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.AddParameter(P_Mark, this.dblMark);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
                this.lngScanMarkDataID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScanMarkDetail", objEx);
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
        /// Update : SIM_ScanMarkDetail
        /// Cập nhật dữ liệu
        /// Store: SIM_ScanMarkDetail_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkDetail_EDIT");
                objIData.AddParameter(P_ScanMarkDataID, this.lngScanMarkDataID);
                objIData.AddParameter(P_ScanMarkID, this.lngScanMarkID);
                objIData.AddParameter(P_ExamOrder, this.intExamOrder);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.AddParameter(P_Mark, this.dblMark);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_ScanMarkFileID, this.lngScanMarkFileID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanMarkDetail", objEx);
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
        /// Delete : SIM_ScanMarkDetail
        /// Xóa dữ liệu
        /// Store: SIM_ScanMarkDetail_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_ScanMarkDetail_DELETE");
                objIData.AddParameter(P_ScanMarkDataID, this.lngScanMarkDataID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanMarkDetail", objEx);
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
        /// Store: SIM_ScanMarkDetail_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngScanMarkDataID)
        {
            this.lngScanMarkDataID = lngScanMarkDataID;
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

        public SIM_ScanMarkDetail()
        {
        }
        public SIM_ScanMarkDetail(long? lngScanMarkDataID)
        {
            this.lngScanMarkDataID = lngScanMarkDataID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_ScanMarkDataID = "@" + C_ScanMarkDataID;
        public const String P_ScanMarkID = "@" + C_ScanMarkID;
        public const String P_ExamOrder = "@" + C_ExamOrder;
        public const String P_OrderIndex = "@" + C_OrderIndex;
        public const String P_SubjectMarkID = "@" + C_SubjectMarkID;
        public const String P_Mark = "@" + C_Mark;
        public const String P_Mark1 = "@" + C_Mark1;
        public const String P_Mark2 = "@" + C_Mark2;
        public const String P_Mark3 = "@" + C_Mark3;
        public const String P_Mark4 = "@" + C_Mark4;
        public const String P_ScanMarkFileID = "@" + C_ScanMarkFileID;

        #endregion //Parameter names

        #region Column Names

        public const String C_ScanMarkDataID = "ScanMarkDataID";
        public const String C_ScanMarkID = "ScanMarkID";
        public const String C_ExamOrder = "ExamOrder";
        public const String C_OrderIndex = "OrderIndex";
        public const String C_SubjectMarkID = "SubjectMarkID";
        public const String C_Mark = "Mark";
        public const String C_Mark1 = "Mark1";
        public const String C_Mark2 = "Mark2";
        public const String C_Mark3 = "Mark3";
        public const String C_Mark4 = "Mark4";
        public const String C_ScanMarkFileID = "ScanMarkFileID";

        #endregion //Column names

        #endregion Variable Static
    }
}


