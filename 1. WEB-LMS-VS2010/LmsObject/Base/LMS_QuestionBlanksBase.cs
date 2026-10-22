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
    /// [LMS] Danh sách ô trống và phương án đúng của câu hỏi kéo thả điền đoạn văn.
    /// </summary>
    public partial class LMS_QuestionBlanks
    {
        #region Member Variables

        private long lngQuestionBlankID = 0;//Khóa chính tự tăng của ô trống.
        private long lngQuestionID = 0;//ID câu hỏi kéo thả điền đoạn văn.
        private string strBlankCode = null;//Mã định danh duy nhất của ô trống trong câu hỏi.
        private long lngCorrectOptionID = 0;//ID phương án đúng cần điền vào ô trống.
        private int intSortOrder = 0;//Thứ tự sắp xếp của ô trống trong câu hỏi.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuestionBlankID
        /// Khóa chính tự tăng của ô trống.
        /// </summary>
        public long QuestionBlankID
        {
            get { return lngQuestionBlankID; }
            set { lngQuestionBlankID = value; }
        }

        /// <summary>
        /// QuestionID
        /// ID câu hỏi kéo thả điền đoạn văn.
        /// </summary>
        public long QuestionID
        {
            get { return lngQuestionID; }
            set { lngQuestionID = value; }
        }

        /// <summary>
        /// BlankCode
        /// Mã định danh duy nhất của ô trống trong câu hỏi.
        /// </summary>
        public string BlankCode
        {
            get { return strBlankCode; }
            set { strBlankCode = value; }
        }

        /// <summary>
        /// CorrectOptionID
        /// ID phương án đúng cần điền vào ô trống.
        /// </summary>
        public long CorrectOptionID
        {
            get { return lngCorrectOptionID; }
            set { lngCorrectOptionID = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự sắp xếp của ô trống trong câu hỏi.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionBlankID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionBlankID])) this.lngQuestionBlankID = Convert.ToInt64(reader[C_QuestionBlankID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(reader[C_QuestionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_BlankCode.ToUpper()) && !Convert.IsDBNull(reader[C_BlankCode])) this.strBlankCode = Convert.ToString(reader[C_BlankCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_CorrectOptionID.ToUpper()) && !Convert.IsDBNull(reader[C_CorrectOptionID])) this.lngCorrectOptionID = Convert.ToInt64(reader[C_CorrectOptionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_QuestionBlanks", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuestionBlankID])) this.lngQuestionBlankID = Convert.ToInt64(drw[C_QuestionBlankID]);
                if (!Convert.IsDBNull(drw[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(drw[C_QuestionID]);
                if (!Convert.IsDBNull(drw[C_BlankCode])) this.strBlankCode = Convert.ToString(drw[C_BlankCode]);
                if (!Convert.IsDBNull(drw[C_CorrectOptionID])) this.lngCorrectOptionID = Convert.ToInt64(drw[C_CorrectOptionID]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_QuestionBlanks", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuestionBlanks_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuestionBlankID, this.lngQuestionBlankID);
                IDataReader reader = objIData.ExecStoreToDataReader();
                if (reader.Read())
                {
                    this.Parse(reader);
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_QuestionBlanks", objEx);
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
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuestionBlanks_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuestionBlankID)
        {
            this.lngQuestionBlankID = lngQuestionBlankID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_QuestionBlanks_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_BlankCode, this.strBlankCode);
                objIData.AddParameter(P_CorrectOptionID, this.lngCorrectOptionID);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_QuestionBlanks", objEx);
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
        ///Cập nhật dữ liệu
        /// Store: LMS_QuestionBlanks_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuestionBlankID, this.lngQuestionBlankID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_BlankCode, this.strBlankCode);
                objIData.AddParameter(P_CorrectOptionID, this.lngCorrectOptionID);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_QuestionBlanks", objEx);
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
        /// Store: LMS_QuestionBlanks_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuestionBlankID, this.lngQuestionBlankID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_QuestionBlanks", objEx);
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
        /// Store: LMS_QuestionBlanks_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuestionBlankID)
        {
            this.lngQuestionBlankID = lngQuestionBlankID;
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

        public LMS_QuestionBlanks()
        {
        }
        public LMS_QuestionBlanks(long lngQuestionBlankID)
        {
            this.lngQuestionBlankID = lngQuestionBlankID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_QuestionBlanks";
        public const string StoreGet = "LMS_QuestionBlanks_GET";
        public const string StoreGetAll = "LMS_QuestionBlanks_GETALL";
        public const string StoreSearch = "LMS_QuestionBlanks_SEARCH";
        public const string StoreAdd = "LMS_QuestionBlanks_ADD";
        public const string StoreEdit = "LMS_QuestionBlanks_EDIT";
        public const string StoreDelete = "LMS_QuestionBlanks_DELETE";

        #region Parameter Names

        public const String P_QuestionBlankID = "@" + C_QuestionBlankID;
        public const String P_QuestionID = "@" + C_QuestionID;
        public const String P_BlankCode = "@" + C_BlankCode;
        public const String P_CorrectOptionID = "@" + C_CorrectOptionID;
        public const String P_SortOrder = "@" + C_SortOrder;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuestionBlankID = "QuestionBlankID";
        public const String C_QuestionID = "QuestionID";
        public const String C_BlankCode = "BlankCode";
        public const String C_CorrectOptionID = "CorrectOptionID";
        public const String C_SortOrder = "SortOrder";

        #endregion //Column names

        #endregion Variable Static
    }
}
