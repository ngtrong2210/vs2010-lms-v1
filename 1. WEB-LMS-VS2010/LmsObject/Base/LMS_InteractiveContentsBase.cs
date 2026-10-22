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
    /// Cấu hình bài học đọc hiểu có câu hỏi tương tác.
    /// </summary>
    public partial class LMS_InteractiveContents
    {
        #region Member Variables

        private long lngInteractiveContentID = 0;//Khóa chính của cấu hình bài học tương tác.
        private long lngLessonID = 0;//Bài học loại INTERACTIVE_CONTENT được cấu hình.
        private string strCompletionRule = null;//Quy tắc hoàn thành: câu bắt buộc, toàn bộ câu hỏi hoặc đạt điểm.
        private bool bolRequireReading = false;//Yêu cầu học viên đọc hết nội dung trước khi hoàn thành.
        private decimal decPassingScore = 0;//Phần trăm điểm tối thiểu khi dùng quy tắc PASSING_SCORE.
        private bool bolShowResultImmediately = false;//Cho phép trả kết quả đúng sai và giải thích ngay sau khi trả lời.
        private bool bolShowScore = false;//Cho phép học viên xem điểm của bài.
        private long lngCreatedByUserID = 0;//Người dùng đã tạo cấu hình bài học tương tác.
        private DateTime dtmCreatedAt = DateTime.MinValue;//Thời điểm tạo cấu hình theo UTC.
        private long? lngUpdatedByUserID = null;//Người dùng cập nhật cấu hình gần nhất.
        private DateTime? dtmUpdatedAt = null;//Thời điểm cập nhật cấu hình gần nhất theo UTC.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// InteractiveContentID
        /// Khóa chính của cấu hình bài học tương tác.
        /// </summary>
        public long InteractiveContentID
        {
            get { return lngInteractiveContentID; }
            set { lngInteractiveContentID = value; }
        }

        /// <summary>
        /// LessonID
        /// Bài học loại INTERACTIVE_CONTENT được cấu hình.
        /// </summary>
        public long LessonID
        {
            get { return lngLessonID; }
            set { lngLessonID = value; }
        }

        /// <summary>
        /// CompletionRule
        /// Quy tắc hoàn thành: câu bắt buộc, toàn bộ câu hỏi hoặc đạt điểm.
        /// </summary>
        public string CompletionRule
        {
            get { return strCompletionRule; }
            set { strCompletionRule = value; }
        }

        /// <summary>
        /// RequireReading
        /// Yêu cầu học viên đọc hết nội dung trước khi hoàn thành.
        /// </summary>
        public bool RequireReading
        {
            get { return bolRequireReading; }
            set { bolRequireReading = value; }
        }

        /// <summary>
        /// PassingScore
        /// Phần trăm điểm tối thiểu khi dùng quy tắc PASSING_SCORE.
        /// </summary>
        public decimal PassingScore
        {
            get { return decPassingScore; }
            set { decPassingScore = value; }
        }

        /// <summary>
        /// ShowResultImmediately
        /// Cho phép trả kết quả đúng sai và giải thích ngay sau khi trả lời.
        /// </summary>
        public bool ShowResultImmediately
        {
            get { return bolShowResultImmediately; }
            set { bolShowResultImmediately = value; }
        }

        /// <summary>
        /// ShowScore
        /// Cho phép học viên xem điểm của bài.
        /// </summary>
        public bool ShowScore
        {
            get { return bolShowScore; }
            set { bolShowScore = value; }
        }

        /// <summary>
        /// CreatedByUserID
        /// Người dùng đã tạo cấu hình bài học tương tác.
        /// </summary>
        public long CreatedByUserID
        {
            get { return lngCreatedByUserID; }
            set { lngCreatedByUserID = value; }
        }

        /// <summary>
        /// CreatedAt
        /// Thời điểm tạo cấu hình theo UTC.
        /// </summary>
        public DateTime CreatedAt
        {
            get { return dtmCreatedAt; }
            set { dtmCreatedAt = value; }
        }

        /// <summary>
        /// UpdatedByUserID
        /// Người dùng cập nhật cấu hình gần nhất.
        /// </summary>
        public long? UpdatedByUserID
        {
            get { return lngUpdatedByUserID; }
            set { lngUpdatedByUserID = value; }
        }

        /// <summary>
        /// UpdatedAt
        /// Thời điểm cập nhật cấu hình gần nhất theo UTC.
        /// </summary>
        public DateTime? UpdatedAt
        {
            get { return dtmUpdatedAt; }
            set { dtmUpdatedAt = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_InteractiveContentID.ToUpper()) && !Convert.IsDBNull(reader[C_InteractiveContentID])) this.lngInteractiveContentID = Convert.ToInt64(reader[C_InteractiveContentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_LessonID.ToUpper()) && !Convert.IsDBNull(reader[C_LessonID])) this.lngLessonID = Convert.ToInt64(reader[C_LessonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CompletionRule.ToUpper()) && !Convert.IsDBNull(reader[C_CompletionRule])) this.strCompletionRule = Convert.ToString(reader[C_CompletionRule]);
                    if (reader.GetName(i).ToUpper().Equals(C_RequireReading.ToUpper()) && !Convert.IsDBNull(reader[C_RequireReading])) this.bolRequireReading = Convert.ToBoolean(reader[C_RequireReading]);
                    if (reader.GetName(i).ToUpper().Equals(C_PassingScore.ToUpper()) && !Convert.IsDBNull(reader[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(reader[C_PassingScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShowResultImmediately.ToUpper()) && !Convert.IsDBNull(reader[C_ShowResultImmediately])) this.bolShowResultImmediately = Convert.ToBoolean(reader[C_ShowResultImmediately]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShowScore.ToUpper()) && !Convert.IsDBNull(reader[C_ShowScore])) this.bolShowScore = Convert.ToBoolean(reader[C_ShowScore]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(reader[C_CreatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(reader[C_CreatedAt]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedByUserID.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(reader[C_UpdatedByUserID]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedAt.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(reader[C_UpdatedAt]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong LMS_InteractiveContents", objEx);
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
                if (!Convert.IsDBNull(drw[C_InteractiveContentID])) this.lngInteractiveContentID = Convert.ToInt64(drw[C_InteractiveContentID]);
                if (!Convert.IsDBNull(drw[C_LessonID])) this.lngLessonID = Convert.ToInt64(drw[C_LessonID]);
                if (!Convert.IsDBNull(drw[C_CompletionRule])) this.strCompletionRule = Convert.ToString(drw[C_CompletionRule]);
                if (!Convert.IsDBNull(drw[C_RequireReading])) this.bolRequireReading = Convert.ToBoolean(drw[C_RequireReading]);
                if (!Convert.IsDBNull(drw[C_PassingScore])) this.decPassingScore = Convert.ToDecimal(drw[C_PassingScore]);
                if (!Convert.IsDBNull(drw[C_ShowResultImmediately])) this.bolShowResultImmediately = Convert.ToBoolean(drw[C_ShowResultImmediately]);
                if (!Convert.IsDBNull(drw[C_ShowScore])) this.bolShowScore = Convert.ToBoolean(drw[C_ShowScore]);
                if (!Convert.IsDBNull(drw[C_CreatedByUserID])) this.lngCreatedByUserID = Convert.ToInt64(drw[C_CreatedByUserID]);
                if (!Convert.IsDBNull(drw[C_CreatedAt])) this.dtmCreatedAt = Convert.ToDateTime(drw[C_CreatedAt]);
                if (!Convert.IsDBNull(drw[C_UpdatedByUserID])) this.lngUpdatedByUserID = Convert.ToInt64(drw[C_UpdatedByUserID]);
                if (!Convert.IsDBNull(drw[C_UpdatedAt])) this.dtmUpdatedAt = Convert.ToDateTime(drw[C_UpdatedAt]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong LMS_InteractiveContents", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: LMS_InteractiveContents_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_InteractiveContentID, this.lngInteractiveContentID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin LMS_InteractiveContents", objEx);
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
        /// Store: LMS_InteractiveContents_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngInteractiveContentID)
        {
            this.lngInteractiveContentID = lngInteractiveContentID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: LMS_InteractiveContents_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_CompletionRule, this.strCompletionRule);
                objIData.AddParameter(P_RequireReading, this.bolRequireReading);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_ShowResultImmediately, this.bolShowResultImmediately);
                objIData.AddParameter(P_ShowScore, this.bolShowScore);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong LMS_InteractiveContents", objEx);
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
        /// Store: LMS_InteractiveContents_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_InteractiveContentID, this.lngInteractiveContentID);
                objIData.AddParameter(P_LessonID, this.lngLessonID);
                objIData.AddParameter(P_CompletionRule, this.strCompletionRule);
                objIData.AddParameter(P_RequireReading, this.bolRequireReading);
                objIData.AddParameter(P_PassingScore, this.decPassingScore);
                objIData.AddParameter(P_ShowResultImmediately, this.bolShowResultImmediately);
                objIData.AddParameter(P_ShowScore, this.bolShowScore);
                objIData.AddParameter(P_CreatedByUserID, this.lngCreatedByUserID);
                objIData.AddParameter(P_CreatedAt, this.dtmCreatedAt);
                objIData.AddParameter(P_UpdatedByUserID, this.lngUpdatedByUserID);
                objIData.AddParameter(P_UpdatedAt, this.dtmUpdatedAt);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong LMS_InteractiveContents", objEx);
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
        /// Store: LMS_InteractiveContents_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_InteractiveContentID, this.lngInteractiveContentID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong LMS_InteractiveContents", objEx);
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
        /// Store: LMS_InteractiveContents_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngInteractiveContentID)
        {
            this.lngInteractiveContentID = lngInteractiveContentID;
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

        public LMS_InteractiveContents()
        {
        }
        public LMS_InteractiveContents(long lngInteractiveContentID)
        {
            this.lngInteractiveContentID = lngInteractiveContentID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_InteractiveContentID = "@" + C_InteractiveContentID;
        public const String P_LessonID = "@" + C_LessonID;
        public const String P_CompletionRule = "@" + C_CompletionRule;
        public const String P_RequireReading = "@" + C_RequireReading;
        public const String P_PassingScore = "@" + C_PassingScore;
        public const String P_ShowResultImmediately = "@" + C_ShowResultImmediately;
        public const String P_ShowScore = "@" + C_ShowScore;
        public const String P_CreatedByUserID = "@" + C_CreatedByUserID;
        public const String P_CreatedAt = "@" + C_CreatedAt;
        public const String P_UpdatedByUserID = "@" + C_UpdatedByUserID;
        public const String P_UpdatedAt = "@" + C_UpdatedAt;

        #endregion //Parameter names

        #region Column Names

        public const String C_InteractiveContentID = "InteractiveContentID";
        public const String C_LessonID = "LessonID";
        public const String C_CompletionRule = "CompletionRule";
        public const String C_RequireReading = "RequireReading";
        public const String C_PassingScore = "PassingScore";
        public const String C_ShowResultImmediately = "ShowResultImmediately";
        public const String C_ShowScore = "ShowScore";
        public const String C_CreatedByUserID = "CreatedByUserID";
        public const String C_CreatedAt = "CreatedAt";
        public const String C_UpdatedByUserID = "UpdatedByUserID";
        public const String C_UpdatedAt = "UpdatedAt";

        #endregion //Column names

        #endregion Variable Static
    }
}
