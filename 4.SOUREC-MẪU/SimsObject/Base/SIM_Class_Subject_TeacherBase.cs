
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
	/// Created date 	: 9/28/2024 
	/// Description 
	/// </summary>	
	public partial class SIM_Class_Subject_Teacher
	{	
		#region Member Variables

		private long? lngCSTeacherID = null;
		private long? lngClassSubjectID = null;//Mã môn học lớp (nếu đang phân tới lớp, thì mã này = 0)
		private string strClassID = null;//Mã lớp (phải lưu dù định mức theo lớp hay theo Môn học lớp)
		private int? intGroupSmallClass = null;//Mã nhóm lớp (nếu tách ghép thì >0, lớp bình thường thì = 0)
		private string strTeacherID = null;//Mã giáo viên được phân công
		private string strReplaceTeacherID = null;//Mã giáo viên dạy thay
		private int? intVehicleID = null;//Mã xe được cấp cho gv dạy nhóm lớp này
		private int? intFromLession = null;//Dự kiến dạy từ tiết
		private int? intToLession = null;//Dự kiến dạy đến tiết
		private int? intFromWeek = null;//Dự kiến dạy từ tuần
		private int? intToWeek = null;//Dự kiến dạy đến tuần
		private int? intTheoryQuantity = null;//Số tiết LT được phân công
		private int? intPracticeQuantity = null;//Số tiết TH được phân công
		private int? intTestQuantity = null;//Số giờ KT được phân công
		private bool bolIsMainTeacher = false;//Là giáo viên chính, nắm giữ, sẽ lưu ngược về TeachingBy, TeachingByTheory, TeachingByPractice
		private int? intIsActived = null;//Kích hoạt
		private int? intOrderIndex = null;
		private string strDescription = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private int? intCSTeacherIndex = null;//Chỉ mục phân công gv cho MHL (nó liên quan tới tiến độ tuần)
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// CSTeacherID
		/// 
		/// </summary>
		public long? CSTeacherID
		{
			get { return  lngCSTeacherID; }
			set { lngCSTeacherID = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// Mã môn học lớp (nếu đang phân tới lớp, thì mã này = 0)
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// ClassID
		/// Mã lớp (phải lưu dù định mức theo lớp hay theo Môn học lớp)
		/// </summary>
		public string ClassID
		{
			get { return  strClassID; }
			set { strClassID = value; }
		}
		/// <summary>
		/// GroupSmallClass
		/// Mã nhóm lớp (nếu tách ghép thì >0, lớp bình thường thì = 0)
		/// </summary>
		public int? GroupSmallClass
		{
			get { return  intGroupSmallClass; }
			set { intGroupSmallClass = value; }
		}
		/// <summary>
		/// TeacherID
		/// Mã giáo viên được phân công
		/// </summary>
		public string TeacherID
		{
			get { return  strTeacherID; }
			set { strTeacherID = value; }
		}
		/// <summary>
		/// ReplaceTeacherID
		/// Mã giáo viên dạy thay
		/// </summary>
		public string ReplaceTeacherID
		{
			get { return  strReplaceTeacherID; }
			set { strReplaceTeacherID = value; }
		}
		/// <summary>
		/// VehicleID
		/// Mã xe được cấp cho gv dạy nhóm lớp này
		/// </summary>
		public int? VehicleID
		{
			get { return  intVehicleID; }
			set { intVehicleID = value; }
		}
		/// <summary>
		/// FromLession
		/// Dự kiến dạy từ tiết
		/// </summary>
		public int? FromLession
		{
			get { return  intFromLession; }
			set { intFromLession = value; }
		}
		/// <summary>
		/// ToLession
		/// Dự kiến dạy đến tiết
		/// </summary>
		public int? ToLession
		{
			get { return  intToLession; }
			set { intToLession = value; }
		}
		/// <summary>
		/// FromWeek
		/// Dự kiến dạy từ tuần
		/// </summary>
		public int? FromWeek
		{
			get { return  intFromWeek; }
			set { intFromWeek = value; }
		}
		/// <summary>
		/// ToWeek
		/// Dự kiến dạy đến tuần
		/// </summary>
		public int? ToWeek
		{
			get { return  intToWeek; }
			set { intToWeek = value; }
		}
		/// <summary>
		/// TheoryQuantity
		/// Số tiết LT được phân công
		/// </summary>
		public int? TheoryQuantity
		{
			get { return  intTheoryQuantity; }
			set { intTheoryQuantity = value; }
		}
		/// <summary>
		/// PracticeQuantity
		/// Số tiết TH được phân công
		/// </summary>
		public int? PracticeQuantity
		{
			get { return  intPracticeQuantity; }
			set { intPracticeQuantity = value; }
		}
		/// <summary>
		/// TestQuantity
		/// Số giờ KT được phân công
		/// </summary>
		public int? TestQuantity
		{
			get { return  intTestQuantity; }
			set { intTestQuantity = value; }
		}
		/// <summary>
		/// IsMainTeacher
		/// Là giáo viên chính, nắm giữ, sẽ lưu ngược về TeachingBy, TeachingByTheory, TeachingByPractice
		/// </summary>
		public bool IsMainTeacher
		{
			get { return  bolIsMainTeacher; }
			set { bolIsMainTeacher = value; }
		}
		/// <summary>
		/// IsActived
		/// Kích hoạt
		/// </summary>
		public int? IsActived
		{
			get { return  intIsActived; }
			set { intIsActived = value; }
		}
		/// <summary>
		/// OrderIndex
		/// 
		/// </summary>
		public int? OrderIndex
		{
			get { return  intOrderIndex; }
			set { intOrderIndex = value; }
		}
		/// <summary>
		/// Description
		/// 
		/// </summary>
		public string Description
		{
			get { return  strDescription; }
			set { strDescription = value; }
		}
		/// <summary>
		/// CreatedDate
		/// Ngày tạo
		/// </summary>
		public DateTime? CreatedDate
		{
			get { return  dtmCreatedDate; }
			set { dtmCreatedDate = value; }
		}
		/// <summary>
		/// CreatedUser
		/// Người tạo
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
		}
		/// <summary>
		/// UpdatedDate
		/// Ngày cập nhật cuối
		/// </summary>
		public DateTime? UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
		}
		/// <summary>
		/// UpdatedUser
		/// Người cập nhật cuối
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
		}
		/// <summary>
		/// CSTeacherIndex
		/// Chỉ mục phân công gv cho MHL (nó liên quan tới tiến độ tuần)
		/// </summary>
		public int? CSTeacherIndex
		{
			get { return  intCSTeacherIndex; }
			set { intCSTeacherIndex = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_CSTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_CSTeacherID])) this.lngCSTeacherID = Convert.ToInt64(reader[C_CSTeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassID])) this.strClassID = Convert.ToString(reader[C_ClassID]);
					if (reader.GetName(i).ToUpper().Equals(C_GroupSmallClass.ToUpper()) && !Convert.IsDBNull(reader[C_GroupSmallClass])) this.intGroupSmallClass = Convert.ToInt32(reader[C_GroupSmallClass]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_ReplaceTeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_ReplaceTeacherID])) this.strReplaceTeacherID = Convert.ToString(reader[C_ReplaceTeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_VehicleID.ToUpper()) && !Convert.IsDBNull(reader[C_VehicleID])) this.intVehicleID = Convert.ToInt32(reader[C_VehicleID]);
					if (reader.GetName(i).ToUpper().Equals(C_FromLession.ToUpper()) && !Convert.IsDBNull(reader[C_FromLession])) this.intFromLession = Convert.ToInt32(reader[C_FromLession]);
					if (reader.GetName(i).ToUpper().Equals(C_ToLession.ToUpper()) && !Convert.IsDBNull(reader[C_ToLession])) this.intToLession = Convert.ToInt32(reader[C_ToLession]);
					if (reader.GetName(i).ToUpper().Equals(C_FromWeek.ToUpper()) && !Convert.IsDBNull(reader[C_FromWeek])) this.intFromWeek = Convert.ToInt32(reader[C_FromWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_ToWeek.ToUpper()) && !Convert.IsDBNull(reader[C_ToWeek])) this.intToWeek = Convert.ToInt32(reader[C_ToWeek]);
					if (reader.GetName(i).ToUpper().Equals(C_TheoryQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(reader[C_TheoryQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_PracticeQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(reader[C_PracticeQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_TestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(reader[C_TestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_IsMainTeacher.ToUpper()) && !Convert.IsDBNull(reader[C_IsMainTeacher])) this.bolIsMainTeacher = Convert.ToBoolean(reader[C_IsMainTeacher]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.intIsActived = Convert.ToInt32(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CSTeacherIndex.ToUpper()) && !Convert.IsDBNull(reader[C_CSTeacherIndex])) this.intCSTeacherIndex = Convert.ToInt32(reader[C_CSTeacherIndex]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Class_Subject_Teacher", objEx);
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
				if (!Convert.IsDBNull(drw[C_CSTeacherID])) this.lngCSTeacherID = Convert.ToInt64(drw[C_CSTeacherID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_ClassID])) this.strClassID = Convert.ToString(drw[C_ClassID]);
				if (!Convert.IsDBNull(drw[C_GroupSmallClass])) this.intGroupSmallClass = Convert.ToInt32(drw[C_GroupSmallClass]);
				if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
				if (!Convert.IsDBNull(drw[C_ReplaceTeacherID])) this.strReplaceTeacherID = Convert.ToString(drw[C_ReplaceTeacherID]);
				if (!Convert.IsDBNull(drw[C_VehicleID])) this.intVehicleID = Convert.ToInt32(drw[C_VehicleID]);
				if (!Convert.IsDBNull(drw[C_FromLession])) this.intFromLession = Convert.ToInt32(drw[C_FromLession]);
				if (!Convert.IsDBNull(drw[C_ToLession])) this.intToLession = Convert.ToInt32(drw[C_ToLession]);
				if (!Convert.IsDBNull(drw[C_FromWeek])) this.intFromWeek = Convert.ToInt32(drw[C_FromWeek]);
				if (!Convert.IsDBNull(drw[C_ToWeek])) this.intToWeek = Convert.ToInt32(drw[C_ToWeek]);
				if (!Convert.IsDBNull(drw[C_TheoryQuantity])) this.intTheoryQuantity = Convert.ToInt32(drw[C_TheoryQuantity]);
				if (!Convert.IsDBNull(drw[C_PracticeQuantity])) this.intPracticeQuantity = Convert.ToInt32(drw[C_PracticeQuantity]);
				if (!Convert.IsDBNull(drw[C_TestQuantity])) this.intTestQuantity = Convert.ToInt32(drw[C_TestQuantity]);
				if (!Convert.IsDBNull(drw[C_IsMainTeacher])) this.bolIsMainTeacher = Convert.ToBoolean(drw[C_IsMainTeacher]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.intIsActived = Convert.ToInt32(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_CSTeacherIndex])) this.intCSTeacherIndex = Convert.ToInt32(drw[C_CSTeacherIndex]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Class_Subject_Teacher", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Class_Subject_Teacher_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Teacher_GET");
				objIData.AddParameter(P_CSTeacherID, this.lngCSTeacherID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Class_Subject_Teacher", objEx);
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
		/// Store: SIM_Class_Subject_Teacher_GET 
		///</summary>
		/// <returns> SIM_Class_Subject_Teacher </returns>
		public SIM_Class_Subject_Teacher Get(long? lngCSTeacherID)
		{
			SIM_Class_Subject_Teacher obj = new SIM_Class_Subject_Teacher();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.CSTeacherID = lngCSTeacherID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Class_Subject_Teacher
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject_Teacher", objEx);
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
		/// Search : SIM_Class_Subject_Teacher
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Class_Subject_Teacher", objEx);
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
		/// Search : SIM_Class_Subject_Teacher
		/// Lấy hết dữ liệu
		/// Store: SIM_Class_Subject_Teacher_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Class_Subject_Teacher_GETALL");
		}

		///<summary>
		/// Search : SIM_Class_Subject_Teacher
		/// Tìm dữ liệu
		/// Store: SIM_Class_Subject_Teacher_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Class_Subject_Teacher_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Class_Subject_Teacher
		/// Thêm dữ liệu
		/// Store: SIM_Class_Subject_Teacher_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Teacher_ADD");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_GroupSmallClass, this.intGroupSmallClass);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_ReplaceTeacherID, this.strReplaceTeacherID);
				objIData.AddParameter(P_VehicleID, this.intVehicleID);
				objIData.AddParameter(P_FromLession, this.intFromLession);
				objIData.AddParameter(P_ToLession, this.intToLession);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_ToWeek, this.intToWeek);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
				objIData.AddParameter(P_IsMainTeacher, this.bolIsMainTeacher);
				objIData.AddParameter(P_IsActived, this.intIsActived);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_CSTeacherIndex, this.intCSTeacherIndex);
				this.lngCSTeacherID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Class_Subject_Teacher", objEx);
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
		/// Update : SIM_Class_Subject_Teacher
		/// Cập nhật dữ liệu
		/// Store: SIM_Class_Subject_Teacher_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Teacher_EDIT");
				objIData.AddParameter(P_CSTeacherID, this.lngCSTeacherID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_ClassID, this.strClassID);
				objIData.AddParameter(P_GroupSmallClass, this.intGroupSmallClass);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_ReplaceTeacherID, this.strReplaceTeacherID);
				objIData.AddParameter(P_VehicleID, this.intVehicleID);
				objIData.AddParameter(P_FromLession, this.intFromLession);
				objIData.AddParameter(P_ToLession, this.intToLession);
				objIData.AddParameter(P_FromWeek, this.intFromWeek);
				objIData.AddParameter(P_ToWeek, this.intToWeek);
				objIData.AddParameter(P_TheoryQuantity, this.intTheoryQuantity);
				objIData.AddParameter(P_PracticeQuantity, this.intPracticeQuantity);
				objIData.AddParameter(P_TestQuantity, this.intTestQuantity);
				objIData.AddParameter(P_IsMainTeacher, this.bolIsMainTeacher);
				objIData.AddParameter(P_IsActived, this.intIsActived);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_CSTeacherIndex, this.intCSTeacherIndex);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Class_Subject_Teacher", objEx);
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
		/// Delete : SIM_Class_Subject_Teacher
		/// Xóa dữ liệu
		/// Store: SIM_Class_Subject_Teacher_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Class_Subject_Teacher_DELETE");
				objIData.AddParameter(P_CSTeacherID, this.lngCSTeacherID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Class_Subject_Teacher", objEx);
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
		/// Store: SIM_Class_Subject_Teacher_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngCSTeacherID)
		{
			this.lngCSTeacherID = lngCSTeacherID;
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

		public SIM_Class_Subject_Teacher()
		{
		}
		public SIM_Class_Subject_Teacher(long? lngCSTeacherID)
		{
			this.lngCSTeacherID = lngCSTeacherID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_CSTeacherID = "@" + C_CSTeacherID;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_ClassID = "@" + C_ClassID;
		public const String P_GroupSmallClass = "@" + C_GroupSmallClass;
		public const String P_TeacherID = "@" + C_TeacherID;
		public const String P_ReplaceTeacherID = "@" + C_ReplaceTeacherID;
		public const String P_VehicleID = "@" + C_VehicleID;
		public const String P_FromLession = "@" + C_FromLession;
		public const String P_ToLession = "@" + C_ToLession;
		public const String P_FromWeek = "@" + C_FromWeek;
		public const String P_ToWeek = "@" + C_ToWeek;
		public const String P_TheoryQuantity = "@" + C_TheoryQuantity;
		public const String P_PracticeQuantity = "@" + C_PracticeQuantity;
		public const String P_TestQuantity = "@" + C_TestQuantity;
		public const String P_IsMainTeacher = "@" + C_IsMainTeacher;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_CSTeacherIndex = "@" + C_CSTeacherIndex;

		#endregion //Parameter names

		#region Column Names

		public const String C_CSTeacherID = "CSTeacherID";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_ClassID = "ClassID";
		public const String C_GroupSmallClass = "GroupSmallClass";
		public const String C_TeacherID = "TeacherID";
		public const String C_ReplaceTeacherID = "ReplaceTeacherID";
		public const String C_VehicleID = "VehicleID";
		public const String C_FromLession = "FromLession";
		public const String C_ToLession = "ToLession";
		public const String C_FromWeek = "FromWeek";
		public const String C_ToWeek = "ToWeek";
		public const String C_TheoryQuantity = "TheoryQuantity";
		public const String C_PracticeQuantity = "PracticeQuantity";
		public const String C_TestQuantity = "TestQuantity";
		public const String C_IsMainTeacher = "IsMainTeacher";
		public const String C_IsActived = "IsActived";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_CSTeacherIndex = "CSTeacherIndex";

		#endregion //Column names

		#endregion Variable Static		
	}
}
