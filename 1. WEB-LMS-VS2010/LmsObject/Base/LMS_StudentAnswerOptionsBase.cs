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
    /// [LMS] Các phương án học viên chọn cho một lần trả lời.
    /// </summary>
    public partial class LMS_StudentAnswerOptions
    {
        #region Member Variables

        private long lngStudentAnswerId = 0;//ID lần trả lời của học viên.
        private long lngQuestionOptionId = 0;//ID phương án học viên đã chọn.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudentAnswerId
        /// ID lần trả lời của học viên.
        /// </summary>
        public long StudentAnswerId
        {
            get { return lngStudentAnswerId; }
            set { lngStudentAnswerId = value; }
        }

        /// <summary>
        /// QuestionOptionId
        /// ID phương án học viên đã chọn.
        /// </summary>
        public long QuestionOptionId
        {
            get { return lngQuestionOptionId; }
            set { lngQuestionOptionId = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentAnswerId.ToUpper()) && !Convert.IsDBNull(reader[C_StudentAnswerId])) this.lngStudentAnswerId = Convert.ToInt64(reader[C_StudentAnswerId]);
                    if (reader.GetName(i).ToUpper().Equals(C_QuestionOptionId.ToUpper()) && !Convert.IsDBNull(reader[C_QuestionOptionId])) this.lngQuestionOptionId = Convert.ToInt64(reader[C_QuestionOptionId]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_StudentAnswerOptions", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentAnswerId])) this.lngStudentAnswerId = Convert.ToInt64(drw[C_StudentAnswerId]);
                if (!Convert.IsDBNull(drw[C_QuestionOptionId])) this.lngQuestionOptionId = Convert.ToInt64(drw[C_QuestionOptionId]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_StudentAnswerOptions", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_StudentAnswerOptions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_StudentAnswerId, this.lngStudentAnswerId);
                objIData.AddParameter(P_QuestionOptionId, this.lngQuestionOptionId);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_StudentAnswerOptions", objEx);
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
        /// Store: LMS_StudentAnswerOptions_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngStudentAnswerId, long lngQuestionOptionId)
        {
            this.lngStudentAnswerId = lngStudentAnswerId;
            this.lngQuestionOptionId = lngQuestionOptionId;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_StudentAnswerOptions_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_StudentAnswerId, this.lngStudentAnswerId);
                objIData.AddParameter(P_QuestionOptionId, this.lngQuestionOptionId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_StudentAnswerOptions", objEx);
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
        /// Store: LMS_StudentAnswerOptions_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_StudentAnswerId, this.lngStudentAnswerId);
                objIData.AddParameter(P_QuestionOptionId, this.lngQuestionOptionId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_StudentAnswerOptions", objEx);
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
        /// Store: LMS_StudentAnswerOptions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_StudentAnswerId, this.lngStudentAnswerId);
                objIData.AddParameter(P_QuestionOptionId, this.lngQuestionOptionId);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_StudentAnswerOptions", objEx);
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
        /// Store: LMS_StudentAnswerOptions_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngStudentAnswerId, long lngQuestionOptionId)
        {
            this.lngStudentAnswerId = lngStudentAnswerId;
            this.lngQuestionOptionId = lngQuestionOptionId;
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

        public LMS_StudentAnswerOptions()
        {
        }
        public LMS_StudentAnswerOptions(long lngStudentAnswerId, long lngQuestionOptionId)
        {
            this.lngStudentAnswerId = lngStudentAnswerId;
            this.lngQuestionOptionId = lngQuestionOptionId;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "LMS_StudentAnswerOptions";
        public const string StoreGet = "LMS_StudentAnswerOptions_GET";
        public const string StoreGetAll = "LMS_StudentAnswerOptions_GETALL";
        public const string StoreSearch = "LMS_StudentAnswerOptions_SEARCH";
        public const string StoreAdd = "LMS_StudentAnswerOptions_ADD";
        public const string StoreEdit = "LMS_StudentAnswerOptions_EDIT";
        public const string StoreDelete = "LMS_StudentAnswerOptions_DELETE";

        #region Parameter Names

        public const String P_StudentAnswerId = "@" + C_StudentAnswerId;
        public const String P_QuestionOptionId = "@" + C_QuestionOptionId;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentAnswerId = "StudentAnswerId";
        public const String C_QuestionOptionId = "QuestionOptionId";

        #endregion //Column names

        #endregion Variable Static
    }
}
