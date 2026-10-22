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
    /// [SIM] Thời khóa biểu học theo từng môn học lớp và khoảng thời gian hiệu lực.
    /// </summary>
    public partial class SIM_Timetable
    {
        #region Member Variables

        private long lngTimetableID = 0;//Cột TimetableID của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private int intDataGroupID = 0;//Cột DataGroupID của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private long lngClassSubjectID = 0;//Cột ClassSubjectID của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private byte bytDayOfWeek = 0;//Cột DayOfWeek của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private byte? bytStartPeriod = null;//Cột StartPeriod của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private byte? bytEndPeriod = null;//Cột EndPeriod của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private TimeSpan? tspStartTime = null;//Cột StartTime của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private TimeSpan? tspEndTime = null;//Cột EndTime của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private string strRoomName = null;//Cột RoomName của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime? dtmEffectiveFrom = null;//Cột EffectiveFrom của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime? dtmEffectiveTo = null;//Cột EffectiveTo của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private byte bytTimetableStatus = 0;//Cột TimetableStatus của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime dtmCreatedDate = DateTime.MinValue;//Cột CreatedDate của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private DateTime? dtmUpdatedDate = null;//Cột UpdatedDate của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// TimetableID
        /// Cột TimetableID của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long TimetableID
        {
            get { return lngTimetableID; }
            set { lngTimetableID = value; }
        }

        /// <summary>
        /// DataGroupID
        /// Cột DataGroupID của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public int DataGroupID
        {
            get { return intDataGroupID; }
            set { intDataGroupID = value; }
        }

        /// <summary>
        /// ClassSubjectID
        /// Cột ClassSubjectID của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public long ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
        }

        /// <summary>
        /// DayOfWeek
        /// Cột DayOfWeek của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public byte DayOfWeek
        {
            get { return bytDayOfWeek; }
            set { bytDayOfWeek = value; }
        }

        /// <summary>
        /// StartPeriod
        /// Cột StartPeriod của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public byte? StartPeriod
        {
            get { return bytStartPeriod; }
            set { bytStartPeriod = value; }
        }

        /// <summary>
        /// EndPeriod
        /// Cột EndPeriod của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public byte? EndPeriod
        {
            get { return bytEndPeriod; }
            set { bytEndPeriod = value; }
        }

        /// <summary>
        /// StartTime
        /// Cột StartTime của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public TimeSpan? StartTime
        {
            get { return tspStartTime; }
            set { tspStartTime = value; }
        }

        /// <summary>
        /// EndTime
        /// Cột EndTime của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public TimeSpan? EndTime
        {
            get { return tspEndTime; }
            set { tspEndTime = value; }
        }

        /// <summary>
        /// RoomName
        /// Cột RoomName của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public string RoomName
        {
            get { return strRoomName; }
            set { strRoomName = value; }
        }

        /// <summary>
        /// EffectiveFrom
        /// Cột EffectiveFrom của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime? EffectiveFrom
        {
            get { return dtmEffectiveFrom; }
            set { dtmEffectiveFrom = value; }
        }

        /// <summary>
        /// EffectiveTo
        /// Cột EffectiveTo của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime? EffectiveTo
        {
            get { return dtmEffectiveTo; }
            set { dtmEffectiveTo = value; }
        }

        /// <summary>
        /// TimetableStatus
        /// Cột TimetableStatus của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public byte TimetableStatus
        {
            get { return bytTimetableStatus; }
            set { bytTimetableStatus = value; }
        }

        /// <summary>
        /// CreatedDate
        /// Cột CreatedDate của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }

        /// <summary>
        /// UpdatedDate
        /// Cột UpdatedDate của bảng SIM_Timetable, lưu thông tin phục vụ nghiệp vụ được mô tả ở cấp bảng.
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_TimetableID.ToUpper()) && !Convert.IsDBNull(reader[C_TimetableID])) this.lngTimetableID = Convert.ToInt64(reader[C_TimetableID]);
                    if (reader.GetName(i).ToUpper().Equals(C_DataGroupID.ToUpper()) && !Convert.IsDBNull(reader[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(reader[C_DataGroupID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_DayOfWeek.ToUpper()) && !Convert.IsDBNull(reader[C_DayOfWeek])) this.bytDayOfWeek = Convert.ToByte(reader[C_DayOfWeek]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartPeriod.ToUpper()) && !Convert.IsDBNull(reader[C_StartPeriod])) this.bytStartPeriod = Convert.ToByte(reader[C_StartPeriod]);
                    if (reader.GetName(i).ToUpper().Equals(C_EndPeriod.ToUpper()) && !Convert.IsDBNull(reader[C_EndPeriod])) this.bytEndPeriod = Convert.ToByte(reader[C_EndPeriod]);
                    if (reader.GetName(i).ToUpper().Equals(C_StartTime.ToUpper()) && !Convert.IsDBNull(reader[C_StartTime])) this.tspStartTime = (reader[C_StartTime] is TimeSpan ? (TimeSpan)reader[C_StartTime] : TimeSpan.Parse(Convert.ToString(reader[C_StartTime])));
                    if (reader.GetName(i).ToUpper().Equals(C_EndTime.ToUpper()) && !Convert.IsDBNull(reader[C_EndTime])) this.tspEndTime = (reader[C_EndTime] is TimeSpan ? (TimeSpan)reader[C_EndTime] : TimeSpan.Parse(Convert.ToString(reader[C_EndTime])));
                    if (reader.GetName(i).ToUpper().Equals(C_RoomName.ToUpper()) && !Convert.IsDBNull(reader[C_RoomName])) this.strRoomName = Convert.ToString(reader[C_RoomName]);
                    if (reader.GetName(i).ToUpper().Equals(C_EffectiveFrom.ToUpper()) && !Convert.IsDBNull(reader[C_EffectiveFrom])) this.dtmEffectiveFrom = Convert.ToDateTime(reader[C_EffectiveFrom]);
                    if (reader.GetName(i).ToUpper().Equals(C_EffectiveTo.ToUpper()) && !Convert.IsDBNull(reader[C_EffectiveTo])) this.dtmEffectiveTo = Convert.ToDateTime(reader[C_EffectiveTo]);
                    if (reader.GetName(i).ToUpper().Equals(C_TimetableStatus.ToUpper()) && !Convert.IsDBNull(reader[C_TimetableStatus])) this.bytTimetableStatus = Convert.ToByte(reader[C_TimetableStatus]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Timetable", objEx);
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
                if (!Convert.IsDBNull(drw[C_TimetableID])) this.lngTimetableID = Convert.ToInt64(drw[C_TimetableID]);
                if (!Convert.IsDBNull(drw[C_DataGroupID])) this.intDataGroupID = Convert.ToInt32(drw[C_DataGroupID]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_DayOfWeek])) this.bytDayOfWeek = Convert.ToByte(drw[C_DayOfWeek]);
                if (!Convert.IsDBNull(drw[C_StartPeriod])) this.bytStartPeriod = Convert.ToByte(drw[C_StartPeriod]);
                if (!Convert.IsDBNull(drw[C_EndPeriod])) this.bytEndPeriod = Convert.ToByte(drw[C_EndPeriod]);
                if (!Convert.IsDBNull(drw[C_StartTime])) this.tspStartTime = (drw[C_StartTime] is TimeSpan ? (TimeSpan)drw[C_StartTime] : TimeSpan.Parse(Convert.ToString(drw[C_StartTime])));
                if (!Convert.IsDBNull(drw[C_EndTime])) this.tspEndTime = (drw[C_EndTime] is TimeSpan ? (TimeSpan)drw[C_EndTime] : TimeSpan.Parse(Convert.ToString(drw[C_EndTime])));
                if (!Convert.IsDBNull(drw[C_RoomName])) this.strRoomName = Convert.ToString(drw[C_RoomName]);
                if (!Convert.IsDBNull(drw[C_EffectiveFrom])) this.dtmEffectiveFrom = Convert.ToDateTime(drw[C_EffectiveFrom]);
                if (!Convert.IsDBNull(drw[C_EffectiveTo])) this.dtmEffectiveTo = Convert.ToDateTime(drw[C_EffectiveTo]);
                if (!Convert.IsDBNull(drw[C_TimetableStatus])) this.bytTimetableStatus = Convert.ToByte(drw[C_TimetableStatus]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Timetable", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        ///Lấy thông tin đối tượng
        /// Store: SIM_Timetable_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreGet);
                objIData.AddParameter(P_TimetableID, this.lngTimetableID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi lấy thông tin SIM_Timetable", objEx);
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
        /// Store: SIM_Timetable_GET
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Get(long lngTimetableID)
        {
            this.lngTimetableID = lngTimetableID;
            return this.Get();
        }

        ///<summary>
        ///Thêm mới dữ liệu
        /// Store: SIM_Timetable_ADD
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreAdd);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_DayOfWeek, this.bytDayOfWeek);
                objIData.AddParameter(P_StartPeriod, this.bytStartPeriod);
                objIData.AddParameter(P_EndPeriod, this.bytEndPeriod);
                objIData.AddParameter(P_StartTime, this.tspStartTime);
                objIData.AddParameter(P_EndTime, this.tspEndTime);
                objIData.AddParameter(P_RoomName, this.strRoomName);
                objIData.AddParameter(P_EffectiveFrom, this.dtmEffectiveFrom);
                objIData.AddParameter(P_EffectiveTo, this.dtmEffectiveTo);
                objIData.AddParameter(P_TimetableStatus, this.bytTimetableStatus);
                objIData.AddParameter(P_CreatedDate, this.dtmCreatedDate);
                objIData.AddParameter(P_UpdatedDate, this.dtmUpdatedDate);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm mới thông tin trong SIM_Timetable", objEx);
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
        /// Store: SIM_Timetable_EDIT
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreEdit);
                objIData.AddParameter(P_TimetableID, this.lngTimetableID);
                objIData.AddParameter(P_DataGroupID, this.intDataGroupID);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_DayOfWeek, this.bytDayOfWeek);
                objIData.AddParameter(P_StartPeriod, this.bytStartPeriod);
                objIData.AddParameter(P_EndPeriod, this.bytEndPeriod);
                objIData.AddParameter(P_StartTime, this.tspStartTime);
                objIData.AddParameter(P_EndTime, this.tspEndTime);
                objIData.AddParameter(P_RoomName, this.strRoomName);
                objIData.AddParameter(P_EffectiveFrom, this.dtmEffectiveFrom);
                objIData.AddParameter(P_EffectiveTo, this.dtmEffectiveTo);
                objIData.AddParameter(P_TimetableStatus, this.bytTimetableStatus);
                objIData.AddParameter(P_CreatedDate, this.dtmCreatedDate);
                objIData.AddParameter(P_UpdatedDate, this.dtmUpdatedDate);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin trong SIM_Timetable", objEx);
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
        /// Store: SIM_Timetable_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure(StoreDelete);
                objIData.AddParameter(P_TimetableID, this.lngTimetableID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin trong SIM_Timetable", objEx);
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
        /// Store: SIM_Timetable_DELETE
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long lngTimetableID)
        {
            this.lngTimetableID = lngTimetableID;
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

        public SIM_Timetable()
        {
        }
        public SIM_Timetable(long lngTimetableID)
        {
            this.lngTimetableID = lngTimetableID;
            this.Get();
        }

        #endregion

        #region Variable Static

        public const string TableSchema = "dbo";
        public const string TableName = "SIM_Timetable";
        public const string StoreGet = "SIM_Timetable_GET";
        public const string StoreGetAll = "SIM_Timetable_GETALL";
        public const string StoreSearch = "SIM_Timetable_SEARCH";
        public const string StoreAdd = "SIM_Timetable_ADD";
        public const string StoreEdit = "SIM_Timetable_EDIT";
        public const string StoreDelete = "SIM_Timetable_DELETE";

        #region Parameter Names

        public const String P_TimetableID = "@" + C_TimetableID;
        public const String P_DataGroupID = "@" + C_DataGroupID;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_DayOfWeek = "@" + C_DayOfWeek;
        public const String P_StartPeriod = "@" + C_StartPeriod;
        public const String P_EndPeriod = "@" + C_EndPeriod;
        public const String P_StartTime = "@" + C_StartTime;
        public const String P_EndTime = "@" + C_EndTime;
        public const String P_RoomName = "@" + C_RoomName;
        public const String P_EffectiveFrom = "@" + C_EffectiveFrom;
        public const String P_EffectiveTo = "@" + C_EffectiveTo;
        public const String P_TimetableStatus = "@" + C_TimetableStatus;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;

        #endregion //Parameter names

        #region Column Names

        public const String C_TimetableID = "TimetableID";
        public const String C_DataGroupID = "DataGroupID";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_DayOfWeek = "DayOfWeek";
        public const String C_StartPeriod = "StartPeriod";
        public const String C_EndPeriod = "EndPeriod";
        public const String C_StartTime = "StartTime";
        public const String C_EndTime = "EndTime";
        public const String C_RoomName = "RoomName";
        public const String C_EffectiveFrom = "EffectiveFrom";
        public const String C_EffectiveTo = "EffectiveTo";
        public const String C_TimetableStatus = "TimetableStatus";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_UpdatedDate = "UpdatedDate";

        #endregion //Column names

        #endregion Variable Static
    }
}
