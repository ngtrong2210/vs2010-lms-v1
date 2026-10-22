
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// DCore: 17/06/2021  For Soft
    /// Created by 		: YourName 
    /// Created date 	: 05/01/2024 
    /// Description 
    /// </summary>	
    public partial class SIM_SubjectPlan
    {
        #region Member Variables

        private long? lngSubjectPlanID = null;//Mã kế hoạch (mục nội dung dạy)
        private string strSubjectID = null;//Mã môn học/mô đun
        private int? intContentTypeID = null;//Phân loại chạy: 1_Hình; 2_Đường; 3_Tổng hợp --> để so sánh với định mức
        private string strContentGroup = null;//Nhóm nội dung, hoặc viết tắt của Content để dùng khi báo cáo
        private string strContent = null;//Nội dung dạy/học
        private string strShortContent = null;//Tên viết tắt của bài học
        private decimal? decQuantity = null;//Số giờ học (số giờ chạy nếu là lái xe)
        private bool bolIsRequestItem = false;//Có yêu cầu cấp xăng dầu
        private int? intOrderIndex = null;//Thứ tự
        private string strDescription = null;
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private int? intLearningSessionID1 = null;//Ca học mặc định 1 (để tạo lịch tự động)
        private int? intLearningSessionID2 = null;//Ca học mặc định 2 (thường là buổi chiều)
        private int? intLearningSessionID3 = null;//Ca học mặc định 3 (thường là tối)
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// SubjectPlanID
        /// Mã kế hoạch (mục nội dung dạy)
        /// </summary>
        public long? SubjectPlanID
        {
            get { return lngSubjectPlanID; }
            set { lngSubjectPlanID = value; }
        }
        /// <summary>
        /// SubjectID
        /// Mã môn học/mô đun
        /// </summary>
        public string SubjectID
        {
            get { return strSubjectID; }
            set { strSubjectID = value; }
        }
        /// <summary>
        /// ContentTypeID
        /// Phân loại chạy: 1_Hình; 2_Đường; 3_Tổng hợp --> để so sánh với định mức
        /// </summary>
        public int? ContentTypeID
        {
            get { return intContentTypeID; }
            set { intContentTypeID = value; }
        }
        /// <summary>
        /// ContentGroup
        /// Nhóm nội dung, hoặc viết tắt của Content để dùng khi báo cáo
        /// </summary>
        public string ContentGroup
        {
            get { return strContentGroup; }
            set { strContentGroup = value; }
        }
        /// <summary>
        /// Content
        /// Nội dung dạy/học
        /// </summary>
        public string Content
        {
            get { return strContent; }
            set { strContent = value; }
        }
        /// <summary>
        /// ShortContent
        /// Tên viết tắt của bài học
        /// </summary>
        public string ShortContent
        {
            get { return strShortContent; }
            set { strShortContent = value; }
        }
        /// <summary>
        /// Quantity
        /// Số giờ học (số giờ chạy nếu là lái xe)
        /// </summary>
        public decimal? Quantity
        {
            get { return decQuantity; }
            set { decQuantity = value; }
        }
        /// <summary>
        /// IsRequestItem
        /// Có yêu cầu cấp xăng dầu
        /// </summary>
        public bool IsRequestItem
        {
            get { return bolIsRequestItem; }
            set { bolIsRequestItem = value; }
        }
        /// <summary>
        /// OrderIndex
        /// Thứ tự
        /// </summary>
        public int? OrderIndex
        {
            get { return intOrderIndex; }
            set { intOrderIndex = value; }
        }
        /// <summary>
        /// Description
        /// 
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
        }
        /// <summary>
        /// CreatedDate
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }
        /// <summary>
        /// CreatedUser
        /// Người tạo
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }
        /// <summary>
        /// UpdatedDate
        /// Ngày cập nhật cuối
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }
        /// <summary>
        /// UpdatedUser
        /// Người cập nhật cuối
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
            set { strUpdatedUser = value; }
        }
        /// <summary>
        /// LearningSessionID1
        /// Ca học mặc định 1 (để tạo lịch tự động)
        /// </summary>
        public int? LearningSessionID1
        {
            get { return intLearningSessionID1; }
            set { intLearningSessionID1 = value; }
        }
        /// <summary>
        /// LearningSessionID2
        /// Ca học mặc định 2 (thường là buổi chiều)
        /// </summary>
        public int? LearningSessionID2
        {
            get { return intLearningSessionID2; }
            set { intLearningSessionID2 = value; }
        }
        /// <summary>
        /// LearningSessionID3
        /// Ca học mặc định 3 (thường là tối)
        /// </summary>
        public int? LearningSessionID3
        {
            get { return intLearningSessionID3; }
            set { intLearningSessionID3 = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectPlanID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectPlanID])) this.lngSubjectPlanID = Convert.ToInt64(reader[C_SubjectPlanID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContentTypeID.ToUpper()) && !Convert.IsDBNull(reader[C_ContentTypeID])) this.intContentTypeID = Convert.ToInt32(reader[C_ContentTypeID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ContentGroup.ToUpper()) && !Convert.IsDBNull(reader[C_ContentGroup])) this.strContentGroup = Convert.ToString(reader[C_ContentGroup]);
                    if (reader.GetName(i).ToUpper().Equals(C_Content.ToUpper()) && !Convert.IsDBNull(reader[C_Content])) this.strContent = Convert.ToString(reader[C_Content]);
                    if (reader.GetName(i).ToUpper().Equals(C_ShortContent.ToUpper()) && !Convert.IsDBNull(reader[C_ShortContent])) this.strShortContent = Convert.ToString(reader[C_ShortContent]);
                    if (reader.GetName(i).ToUpper().Equals(C_Quantity.ToUpper()) && !Convert.IsDBNull(reader[C_Quantity])) this.decQuantity = Convert.ToDecimal(reader[C_Quantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRequestItem.ToUpper()) && !Convert.IsDBNull(reader[C_IsRequestItem])) this.bolIsRequestItem = Convert.ToBoolean(reader[C_IsRequestItem]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSessionID1.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionID1])) this.intLearningSessionID1 = Convert.ToInt32(reader[C_LearningSessionID1]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSessionID2.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionID2])) this.intLearningSessionID2 = Convert.ToInt32(reader[C_LearningSessionID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningSessionID3.ToUpper()) && !Convert.IsDBNull(reader[C_LearningSessionID3])) this.intLearningSessionID3 = Convert.ToInt32(reader[C_LearningSessionID3]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SubjectPlan", objEx);
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
                if (!Convert.IsDBNull(drw[C_SubjectPlanID])) this.lngSubjectPlanID = Convert.ToInt64(drw[C_SubjectPlanID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_ContentTypeID])) this.intContentTypeID = Convert.ToInt32(drw[C_ContentTypeID]);
                if (!Convert.IsDBNull(drw[C_ContentGroup])) this.strContentGroup = Convert.ToString(drw[C_ContentGroup]);
                if (!Convert.IsDBNull(drw[C_Content])) this.strContent = Convert.ToString(drw[C_Content]);
                if (!Convert.IsDBNull(drw[C_ShortContent])) this.strShortContent = Convert.ToString(drw[C_ShortContent]);
                if (!Convert.IsDBNull(drw[C_Quantity])) this.decQuantity = Convert.ToDecimal(drw[C_Quantity]);
                if (!Convert.IsDBNull(drw[C_IsRequestItem])) this.bolIsRequestItem = Convert.ToBoolean(drw[C_IsRequestItem]);
                if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_LearningSessionID1])) this.intLearningSessionID1 = Convert.ToInt32(drw[C_LearningSessionID1]);
                if (!Convert.IsDBNull(drw[C_LearningSessionID2])) this.intLearningSessionID2 = Convert.ToInt32(drw[C_LearningSessionID2]);
                if (!Convert.IsDBNull(drw[C_LearningSessionID3])) this.intLearningSessionID3 = Convert.ToInt32(drw[C_LearningSessionID3]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SubjectPlan", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_SubjectPlan_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectPlan_GET");
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SubjectPlan", objEx);
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
        /// Store: SIM_SubjectPlan_GET 
        ///</summary>
        /// <returns> SIM_SubjectPlan </returns>
        public SIM_SubjectPlan Get(long? lngSubjectPlanID)
        {
            SIM_SubjectPlan obj = new SIM_SubjectPlan();
            if (objIData != null)
                obj.IDB = objIData;
            obj.SubjectPlanID = lngSubjectPlanID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_SubjectPlan
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SubjectPlan", objEx);
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
        /// Search : SIM_SubjectPlan
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SubjectPlan", objEx);
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
        /// Search : SIM_SubjectPlan
        /// Lấy hết dữ liệu
        /// Store: SIM_SubjectPlan_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_SubjectPlan_GETALL");
        }

        ///<summary>
        /// Search : SIM_SubjectPlan
        /// Tìm dữ liệu
        /// Store: SIM_SubjectPlan_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_SubjectPlan_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_SubjectPlan
        /// Thêm dữ liệu
        /// Store: SIM_SubjectPlan_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectPlan_ADD");
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_ContentTypeID, this.intContentTypeID);
                objIData.AddParameter(P_ContentGroup, this.strContentGroup);
                objIData.AddParameter(P_Content, this.strContent);
                objIData.AddParameter(P_ShortContent, this.strShortContent);
                objIData.AddParameter(P_Quantity, this.decQuantity);
                objIData.AddParameter(P_IsRequestItem, this.bolIsRequestItem);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_LearningSessionID1, this.intLearningSessionID1);
                objIData.AddParameter(P_LearningSessionID2, this.intLearningSessionID2);
                objIData.AddParameter(P_LearningSessionID3, this.intLearningSessionID3);
                this.lngSubjectPlanID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SubjectPlan", objEx);
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
        /// Update : SIM_SubjectPlan
        /// Cập nhật dữ liệu
        /// Store: SIM_SubjectPlan_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectPlan_EDIT");
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_ContentTypeID, this.intContentTypeID);
                objIData.AddParameter(P_ContentGroup, this.strContentGroup);
                objIData.AddParameter(P_Content, this.strContent);
                objIData.AddParameter(P_ShortContent, this.strShortContent);
                objIData.AddParameter(P_Quantity, this.decQuantity);
                objIData.AddParameter(P_IsRequestItem, this.bolIsRequestItem);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_LearningSessionID1, this.intLearningSessionID1);
                objIData.AddParameter(P_LearningSessionID2, this.intLearningSessionID2);
                objIData.AddParameter(P_LearningSessionID3, this.intLearningSessionID3);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SubjectPlan", objEx);
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
        /// Delete : SIM_SubjectPlan
        /// Xóa dữ liệu
        /// Store: SIM_SubjectPlan_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectPlan_DELETE");
                objIData.AddParameter(P_SubjectPlanID, this.lngSubjectPlanID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SubjectPlan", objEx);
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
        /// Store: SIM_SubjectPlan_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngSubjectPlanID)
        {
            this.lngSubjectPlanID = lngSubjectPlanID;
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

        public SIM_SubjectPlan()
        {
        }
        public SIM_SubjectPlan(long? lngSubjectPlanID)
        {
            this.lngSubjectPlanID = lngSubjectPlanID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_SubjectPlanID = "@" + C_SubjectPlanID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_ContentTypeID = "@" + C_ContentTypeID;
        public const String P_ContentGroup = "@" + C_ContentGroup;
        public const String P_Content = "@" + C_Content;
        public const String P_ShortContent = "@" + C_ShortContent;
        public const String P_Quantity = "@" + C_Quantity;
        public const String P_IsRequestItem = "@" + C_IsRequestItem;
        public const String P_OrderIndex = "@" + C_OrderIndex;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_LearningSessionID1 = "@" + C_LearningSessionID1;
        public const String P_LearningSessionID2 = "@" + C_LearningSessionID2;
        public const String P_LearningSessionID3 = "@" + C_LearningSessionID3;

        #endregion //Parameter names

        #region Column Names

        public const String C_SubjectPlanID = "SubjectPlanID";
        public const String C_SubjectID = "SubjectID";
        public const String C_ContentTypeID = "ContentTypeID";
        public const String C_ContentGroup = "ContentGroup";
        public const String C_Content = "Content";
        public const String C_ShortContent = "ShortContent";
        public const String C_Quantity = "Quantity";
        public const String C_IsRequestItem = "IsRequestItem";
        public const String C_OrderIndex = "OrderIndex";
        public const String C_Description = "Description";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_LearningSessionID1 = "LearningSessionID1";
        public const String C_LearningSessionID2 = "LearningSessionID2";
        public const String C_LearningSessionID3 = "LearningSessionID3";

        #endregion //Column names

        #endregion Variable Static
    }
}


