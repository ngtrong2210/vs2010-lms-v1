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
    /// [LMS] Các phương án lựa chọn của câu hỏi.
    /// </summary>
    public partial class LMS_QuestionOptions
    {
        #region Member Variables

        private long lngQuestionOptionID = 0;//Khóa chính tự tăng của phương án trả lời.
        private long lngQuestionId = 0;//ID câu hỏi sở hữu phương án.
        private string strOptionCode = null;//Mã phương án trong phạm vi câu hỏi, ví dụ A, B, C, D.
        private string strOptionText = null;//Nội dung hiển thị của phương án.
        private bool bolIsCorrect = false;//Cờ cho biết phương án là đáp án đúng.
        private int intSortOrder = 0;//Thứ tự hiển thị của phương án.
        private bool bolIsDeleted = false;//Cờ xóa mềm của phương án.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuestionOptionID
        /// Khóa chính tự tăng của phương án trả lời.
        /// </summary>
        public long QuestionOptionID
        {
            get { return lngQuestionOptionID; }
            set { lngQuestionOptionID = value; }
        }

        /// <summary>
        /// QuestionId
        /// ID câu hỏi sở hữu phương án.
        /// </summary>
        public long QuestionId
        {
            get { return lngQuestionId; }
            set { lngQuestionId = value; }
        }

        /// <summary>
        /// OptionCode
        /// Mã phương án trong phạm vi câu hỏi, ví dụ A, B, C, D.
        /// </summary>
        public string OptionCode
        {
            get { return strOptionCode; }
            set { strOptionCode = value; }
        }

        /// <summary>
        /// OptionText
        /// Nội dung hiển thị của phương án.
        /// </summary>
        public string OptionText
        {
            get { return strOptionText; }
            set { strOptionText = value; }
        }

        /// <summary>
        /// IsCorrect
        /// Cờ cho biết phương án là đáp án đúng.
        /// </summary>
        public bool IsCorrect
        {
            get { return bolIsCorrect; }
            set { bolIsCorrect = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị của phương án.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// IsDeleted
        /// Cờ xóa mềm của phương án.
        /// </summary>
        public bool IsDeleted
        {
            get { return bolIsDeleted; }
            set { bolIsDeleted = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionOptionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionOptionID])) this.lngQuestionOptionID = Convert.ToInt64(reader[C_QuestionOptionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionId.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(reader[C_QuestionId]);
                    if (reader.GetName(i).ToUpper().Equals(C_OptionCode.ToUpper()) && !Convert.IsDBNull(reader[C_OptionCode])) this.strOptionCode = Convert.ToString(reader[C_OptionCode]);
                    if (reader.GetName(i).ToUpper().Equals(C_OptionText.ToUpper()) && !Convert.IsDBNull(reader[C_OptionText])) this.strOptionText = Convert.ToString(reader[C_OptionText]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsCorrect.ToUpper()) && !Convert.IsDBNull(reader[C_IsCorrect])) this.bolIsCorrect = Convert.ToBoolean(reader[C_IsCorrect]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsDeleted.ToUpper()) && !Convert.IsDBNull(reader[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(reader[C_IsDeleted]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_QuestionOptions", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuestionOptionID])) this.lngQuestionOptionID = Convert.ToInt64(drw[C_QuestionOptionID]);
                if (!Convert.IsDBNull(drw[C_QuestionId])) this.lngQuestionId = Convert.ToInt64(drw[C_QuestionId]);
                if (!Convert.IsDBNull(drw[C_OptionCode])) this.strOptionCode = Convert.ToString(drw[C_OptionCode]);
                if (!Convert.IsDBNull(drw[C_OptionText])) this.strOptionText = Convert.ToString(drw[C_OptionText]);
                if (!Convert.IsDBNull(drw[C_IsCorrect])) this.bolIsCorrect = Convert.ToBoolean(drw[C_IsCorrect]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_IsDeleted])) this.bolIsDeleted = Convert.ToBoolean(drw[C_IsDeleted]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_QuestionOptions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuestionOptions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuestionOptionID, this.lngQuestionOptionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_QuestionOptions", objEx);
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
        /// Store: LMS_QuestionOptions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuestionOptionID)
        {
            this.lngQuestionOptionID = lngQuestionOptionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_QuestionOptions_ADD
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
                objIData.AddParameter(P_OptionCode, this.strOptionCode);
                objIData.AddParameter(P_OptionText, this.strOptionText);
                objIData.AddParameter(P_IsCorrect, this.bolIsCorrect);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_QuestionOptions", objEx);
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
        /// Store: LMS_QuestionOptions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuestionOptionID, this.lngQuestionOptionID);
                objIData.AddParameter(P_QuestionId, this.lngQuestionId);
                objIData.AddParameter(P_OptionCode, this.strOptionCode);
                objIData.AddParameter(P_OptionText, this.strOptionText);
                objIData.AddParameter(P_IsCorrect, this.bolIsCorrect);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsDeleted, this.bolIsDeleted);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_QuestionOptions", objEx);
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
        /// Store: LMS_QuestionOptions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuestionOptionID, this.lngQuestionOptionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_QuestionOptions", objEx);
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
        /// Store: LMS_QuestionOptions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuestionOptionID)
        {
            this.lngQuestionOptionID = lngQuestionOptionID;
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

        public LMS_QuestionOptions()
        {
        }
        public LMS_QuestionOptions(long lngQuestionOptionID)
        {
            this.lngQuestionOptionID = lngQuestionOptionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_QuestionOptions";
        public const string StoreGet = "LMS_QuestionOptions_GET";
        public const string StoreGetAll = "LMS_QuestionOptions_GETALL";
        public const string StoreSearch = "LMS_QuestionOptions_SEARCH";
        public const string StoreAdd = "LMS_QuestionOptions_ADD";
        public const string StoreEdit = "LMS_QuestionOptions_EDIT";
        public const string StoreDelete = "LMS_QuestionOptions_DELETE";

        #region Parameter Names

        public const String P_QuestionOptionID = "@" + C_QuestionOptionID;
        public const String P_QuestionId = "@" + C_QuestionId;
        public const String P_OptionCode = "@" + C_OptionCode;
        public const String P_OptionText = "@" + C_OptionText;
        public const String P_IsCorrect = "@" + C_IsCorrect;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_IsDeleted = "@" + C_IsDeleted;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuestionOptionID = "QuestionOptionID";
        public const String C_QuestionId = "QuestionId";
        public const String C_OptionCode = "OptionCode";
        public const String C_OptionText = "OptionText";
        public const String C_IsCorrect = "IsCorrect";
        public const String C_SortOrder = "SortOrder";
        public const String C_IsDeleted = "IsDeleted";

        #endregion //Column names

        #endregion Variable Static
    }
}
