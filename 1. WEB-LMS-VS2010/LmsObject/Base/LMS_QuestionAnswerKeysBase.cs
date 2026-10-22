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
    /// [LMS] Các đáp án chữ được chấp nhận cho câu hỏi trả lời ngắn.
    /// </summary>
    public partial class LMS_QuestionAnswerKeys
    {
        #region Member Variables

        private long lngQuestionAnswerKeyID = 0;//Khóa chính tự tăng của đáp án chữ.
        private long lngQuestionId = 0;//ID câu hỏi trả lời ngắn.
        private string strAnswerText = null;//Nội dung đáp án được chấp nhận.
        private bool bolIsCaseSensitive = false;//Cờ cho biết việc so khớp có phân biệt chữ hoa, chữ thường.
        private int intSortOrder = 0;//Thứ tự ưu tiên của đáp án được chấp nhận.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuestionAnswerKeyID
        /// Khóa chính tự tăng của đáp án chữ.
        /// </summary>
        public long QuestionAnswerKeyID
        {
            get { return lngQuestionAnswerKeyID; }
            set { lngQuestionAnswerKeyID = value; }
        }

        /// <summary>
        /// QuestionId
        /// ID câu hỏi trả lời ngắn.
        /// </summary>
        public long QuestionId
        {
            get { return lngQuestionId; }
            set { lngQuestionId = value; }
        }

        /// <summary>
        /// AnswerText
        /// Nội dung đáp án được chấp nhận.
        /// </summary>
        public string AnswerText
        {
            get { return strAnswerText; }
            set { strAnswerText = value; }
        }

        /// <summary>
        /// IsCaseSensitive
        /// Cờ cho biết việc so khớp có phân biệt chữ hoa, chữ thường.
        /// </summary>
        public bool IsCaseSensitive
        {
            get { return bolIsCaseSensitive; }
            set { bolIsCaseSensitive = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự ưu tiên của đáp án được chấp nhận.
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionAnswerKeyID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionAnswerKeyID])) this.lngQuestionAnswerKeyID = Convert.ToInt64(reader[C_QuestionAnswerKeyID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionId.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(reader[C_QuestionId]);
                    if (reader.GetName(i).ToUpper().Equals(C_AnswerText.ToUpper()) && !Convert.IsDBNull(reader[C_AnswerText])) this.strAnswerText = Convert.ToString(reader[C_AnswerText]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCaseSensitive.ToUpper()) && !Convert.IsDBNull(reader[C_IsCaseSensitive])) this.bolIsCaseSensitive = Convert.ToBoolean(reader[C_IsCaseSensitive]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_QuestionAnswerKeys", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuestionAnswerKeyID])) this.lngQuestionAnswerKeyID = Convert.ToInt64(drw[C_QuestionAnswerKeyID]);
                if (!Convert.IsDBNull(drw[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(drw[C_QuestionId]);
                if (!Convert.IsDBNull(drw[C_AnswerText])) this.strAnswerText = Convert.ToString(drw[C_AnswerText]);
                if (!Convert.IsDBNull(drw[C_IsCaseSensitive])) this.bolIsCaseSensitive = Convert.ToBoolean(drw[C_IsCaseSensitive]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_QuestionAnswerKeys", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuestionAnswerKeys_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuestionAnswerKeyID, this.lngQuestionAnswerKeyID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_QuestionAnswerKeys", objEx);
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
        /// Store: LMS_QuestionAnswerKeys_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuestionAnswerKeyID)
        {
            this.lngQuestionAnswerKeyID = lngQuestionAnswerKeyID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_QuestionAnswerKeys_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_AnswerText, this.strAnswerText);
                objIData.AddParameter(P_IsCaseSensitive, this.bolIsCaseSensitive);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_QuestionAnswerKeys", objEx);
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
        /// Store: LMS_QuestionAnswerKeys_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuestionAnswerKeyID, this.lngQuestionAnswerKeyID);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_AnswerText, this.strAnswerText);
                objIData.AddParameter(P_IsCaseSensitive, this.bolIsCaseSensitive);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_QuestionAnswerKeys", objEx);
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
        /// Store: LMS_QuestionAnswerKeys_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuestionAnswerKeyID, this.lngQuestionAnswerKeyID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_QuestionAnswerKeys", objEx);
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
        /// Store: LMS_QuestionAnswerKeys_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuestionAnswerKeyID)
        {
            this.lngQuestionAnswerKeyID = lngQuestionAnswerKeyID;
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

        public LMS_QuestionAnswerKeys()
        {
        }
        public LMS_QuestionAnswerKeys(long lngQuestionAnswerKeyID)
        {
            this.lngQuestionAnswerKeyID = lngQuestionAnswerKeyID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_QuestionAnswerKeys";
        public const string StoreGet = "LMS_QuestionAnswerKeys_GET";
        public const string StoreGetAll = "LMS_QuestionAnswerKeys_GETALL";
        public const string StoreSearch = "LMS_QuestionAnswerKeys_SEARCH";
        public const string StoreAdd = "LMS_QuestionAnswerKeys_ADD";
        public const string StoreEdit = "LMS_QuestionAnswerKeys_EDIT";
        public const string StoreDelete = "LMS_QuestionAnswerKeys_DELETE";

        #region Parameter Names

        public const String P_QuestionAnswerKeyID = "@" + C_QuestionAnswerKeyID;
        public const String P_QuestionId = "@" + C_QuestionId;
        public const String P_AnswerText = "@" + C_AnswerText;
        public const String P_IsCaseSensitive = "@" + C_IsCaseSensitive;
        public const String P_SortOrder = "@" + C_SortOrder;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuestionAnswerKeyID = "QuestionAnswerKeyID";
        public const String C_QuestionId = "QuestionId";
        public const String C_AnswerText = "AnswerText";
        public const String C_IsCaseSensitive = "IsCaseSensitive";
        public const String C_SortOrder = "SortOrder";

        #endregion //Column names

        #endregion Variable Static
    }
}
