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
    /// [LMS] Danh sách câu hỏi và số điểm trong một bài kiểm tra.
    /// </summary>
    public partial class LMS_QuizQuestions
    {
        #region Member Variables

        private long lngQuizQuestionID = 0;//Khóa chính dòng câu hỏi của bài kiểm tra.
        private long lngQuizID = 0;//Bài kiểm tra sở hữu câu hỏi.
        private long lngQuestionID = 0;//Câu hỏi tham chiếu từ ngân hàng câu hỏi.
        private decimal decScore = 0;//Điểm số của câu hỏi trong bài kiểm tra.
        private int intSortOrder = 0;//Thứ tự hiển thị của câu hỏi trong bài kiểm tra.
        private bool bolIsRequired = false;//Cờ cho biết câu hỏi là bắt buộc.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// QuizQuestionID
        /// Khóa chính dòng câu hỏi của bài kiểm tra.
        /// </summary>
        public long QuizQuestionID
        {
            get { return lngQuizQuestionID; }
            set { lngQuizQuestionID = value; }
        }

        /// <summary>
        /// QuizID
        /// Bài kiểm tra sở hữu câu hỏi.
        /// </summary>
        public long QuizID
        {
            get { return lngQuizID; }
            set { lngQuizID = value; }
        }

        /// <summary>
        /// QuestionID
        /// Câu hỏi tham chiếu từ ngân hàng câu hỏi.
        /// </summary>
        public long QuestionID
        {
            get { return lngQuestionID; }
            set { lngQuestionID = value; }
        }

        /// <summary>
        /// Score
        /// Điểm số của câu hỏi trong bài kiểm tra.
        /// </summary>
        public decimal Score
        {
            get { return decScore; }
            set { decScore = value; }
        }

        /// <summary>
        /// SortOrder
        /// Thứ tự hiển thị của câu hỏi trong bài kiểm tra.
        /// </summary>
        public int SortOrder
        {
            get { return intSortOrder; }
            set { intSortOrder = value; }
        }

        /// <summary>
        /// IsRequired
        /// Cờ cho biết câu hỏi là bắt buộc.
        /// </summary>
        public bool IsRequired
        {
            get { return bolIsRequired; }
            set { bolIsRequired = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_QuizQuestionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizQuestionID])) this.lngQuizQuestionID = Convert.ToInt64(reader[C_QuizQuestionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuizID.ToUpper()) && !Convert.IsDBNull(reader[C_QuizID])) this.lngQuizID = Convert.ToInt64(reader[C_QuizID]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionID.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(reader[C_QuestionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Score.ToUpper()) && !Convert.IsDBNull(reader[C_Score])) this.decScore = Convert.ToDecimal(reader[C_Score]);
                    if (reader.GetName(i).ToUpper().Equals(C_SortOrder.ToUpper()) && !Convert.IsDBNull(reader[C_SortOrder])) this.intSortOrder = Convert.ToInt32(reader[C_SortOrder]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRequired.ToUpper()) && !Convert.IsDBNull(reader[C_IsRequired])) this.bolIsRequired = Convert.ToBoolean(reader[C_IsRequired]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_QuizQuestions", objEx);
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
                if (!Convert.IsDBNull(drw[C_QuizQuestionID])) this.lngQuizQuestionID = Convert.ToInt64(drw[C_QuizQuestionID]);
                if (!Convert.IsDBNull(drw[C_QuizID])) this.lngQuizID = Convert.ToInt64(drw[C_QuizID]);
                if (!Convert.IsDBNull(drw[C_QuestionID])) this.lngQuestionID = Convert.ToInt64(drw[C_QuestionID]);
                if (!Convert.IsDBNull(drw[C_Score])) this.decScore = Convert.ToDecimal(drw[C_Score]);
                if (!Convert.IsDBNull(drw[C_SortOrder])) this.intSortOrder = Convert.ToInt32(drw[C_SortOrder]);
                if (!Convert.IsDBNull(drw[C_IsRequired])) this.bolIsRequired = Convert.ToBoolean(drw[C_IsRequired]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_QuizQuestions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_QuizQuestions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_QuizQuestionID, this.lngQuizQuestionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_QuizQuestions", objEx);
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
        /// Store: LMS_QuizQuestions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngQuizQuestionID)
        {
            this.lngQuizQuestionID = lngQuizQuestionID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_QuizQuestions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsRequired, this.bolIsRequired);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_QuizQuestions", objEx);
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
        /// Store: LMS_QuizQuestions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_QuizQuestionID, this.lngQuizQuestionID);
                objIData.AddParameter(P_QuizID, this.lngQuizID);
                objIData.AddParameter(P_QuestionID, this.lngQuestionID);
                objIData.AddParameter(P_Score, this.decScore);
                objIData.AddParameter(P_SortOrder, this.intSortOrder);
                objIData.AddParameter(P_IsRequired, this.bolIsRequired);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_QuizQuestions", objEx);
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
        /// Store: LMS_QuizQuestions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_QuizQuestionID, this.lngQuizQuestionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_QuizQuestions", objEx);
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
        /// Store: LMS_QuizQuestions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngQuizQuestionID)
        {
            this.lngQuizQuestionID = lngQuizQuestionID;
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

        public LMS_QuizQuestions()
        {
        }
        public LMS_QuizQuestions(long lngQuizQuestionID)
        {
            this.lngQuizQuestionID = lngQuizQuestionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_QuizQuestions";
        public const string StoreGet = "LMS_QuizQuestions_GET";
        public const string StoreGetAll = "LMS_QuizQuestions_GETALL";
        public const string StoreSearch = "LMS_QuizQuestions_SEARCH";
        public const string StoreAdd = "LMS_QuizQuestions_ADD";
        public const string StoreEdit = "LMS_QuizQuestions_EDIT";
        public const string StoreDelete = "LMS_QuizQuestions_DELETE";

        #region Parameter Names

        public const String P_QuizQuestionID = "@" + C_QuizQuestionID;
        public const String P_QuizID = "@" + C_QuizID;
        public const String P_QuestionID = "@" + C_QuestionID;
        public const String P_Score = "@" + C_Score;
        public const String P_SortOrder = "@" + C_SortOrder;
        public const String P_IsRequired = "@" + C_IsRequired;

        #endregion //Parameter names

        #region Column Names

        public const String C_QuizQuestionID = "QuizQuestionID";
        public const String C_QuizID = "QuizID";
        public const String C_QuestionID = "QuestionID";
        public const String C_Score = "Score";
        public const String C_SortOrder = "SortOrder";
        public const String C_IsRequired = "IsRequired";

        #endregion //Column names

        #endregion Variable Static
    }
}
