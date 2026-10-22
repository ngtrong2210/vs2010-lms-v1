
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
	/// Created date 	: 3/24/2023 
	/// Description 
	/// </summary>	
	public partial class SIM_ClassSubjectInfo
	{	
		#region Member Variables

		private long? lngClassSubjectID = null;//Mã môn học lớp (kể cả login cho tách ghép)
		private string strKnowledgeTarget = null;//Mục tiêu về Kiến thức
		private string strSkillTarget = null;//Mục tiêu về kỹ năng
		private string strAttitudeTarget = null;//Mục tiêu về thái độ
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private string strContentFile = null;//Tên tập tin giáo án cho từng buổi (chỉ chứa tên file)
		private bool bolIsReviewed1 = false;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewedDate1 = null;//Ngày duyệt đăng ký
		private string strReviewedUser1 = null;
		private string strReviewedComment1 = null;
		private bool bolIsReviewed = false;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewedDate = null;//Ngày duyệt đăng ký
		private string strReviewedUser = null;
		private string strReviewedComment = null;
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ClassSubjectID
		/// Mã môn học lớp (kể cả login cho tách ghép)
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// KnowledgeTarget
		/// Mục tiêu về Kiến thức
		/// </summary>
		public string KnowledgeTarget
		{
			get { return  strKnowledgeTarget; }
			set { strKnowledgeTarget = value; }
		}
		/// <summary>
		/// SkillTarget
		/// Mục tiêu về kỹ năng
		/// </summary>
		public string SkillTarget
		{
			get { return  strSkillTarget; }
			set { strSkillTarget = value; }
		}
		/// <summary>
		/// AttitudeTarget
		/// Mục tiêu về thái độ
		/// </summary>
		public string AttitudeTarget
		{
			get { return  strAttitudeTarget; }
			set { strAttitudeTarget = value; }
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
		/// ContentFile
		/// Tên tập tin giáo án cho từng buổi (chỉ chứa tên file)
		/// </summary>
		public string ContentFile
		{
			get { return  strContentFile; }
			set { strContentFile = value; }
		}
		/// <summary>
		/// IsReviewed1
		/// Đã chấp nhận đăng ký dạy bù
		/// </summary>
		public bool IsReviewed1
		{
			get { return  bolIsReviewed1; }
			set { bolIsReviewed1 = value; }
		}
		/// <summary>
		/// ReviewedDate1
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewedDate1
		{
			get { return  dtmReviewedDate1; }
			set { dtmReviewedDate1 = value; }
		}
		/// <summary>
		/// ReviewedUser1
		/// 
		/// </summary>
		public string ReviewedUser1
		{
			get { return  strReviewedUser1; }
			set { strReviewedUser1 = value; }
		}
		/// <summary>
		/// ReviewedComment1
		/// 
		/// </summary>
		public string ReviewedComment1
		{
			get { return  strReviewedComment1; }
			set { strReviewedComment1 = value; }
		}
		/// <summary>
		/// IsReviewed
		/// Đã chấp nhận đăng ký dạy bù
		/// </summary>
		public bool IsReviewed
		{
			get { return  bolIsReviewed; }
			set { bolIsReviewed = value; }
		}
		/// <summary>
		/// ReviewedDate
		/// Ngày duyệt đăng ký
		/// </summary>
		public DateTime? ReviewedDate
		{
			get { return  dtmReviewedDate; }
			set { dtmReviewedDate = value; }
		}
		/// <summary>
		/// ReviewedUser
		/// 
		/// </summary>
		public string ReviewedUser
		{
			get { return  strReviewedUser; }
			set { strReviewedUser = value; }
		}
		/// <summary>
		/// ReviewedComment
		/// 
		/// </summary>
		public string ReviewedComment
		{
			get { return  strReviewedComment; }
			set { strReviewedComment = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_KnowledgeTarget.ToUpper()) && !Convert.IsDBNull(reader[C_KnowledgeTarget])) this.strKnowledgeTarget = Convert.ToString(reader[C_KnowledgeTarget]);
					if (reader.GetName(i).ToUpper().Equals(C_SkillTarget.ToUpper()) && !Convert.IsDBNull(reader[C_SkillTarget])) this.strSkillTarget = Convert.ToString(reader[C_SkillTarget]);
					if (reader.GetName(i).ToUpper().Equals(C_AttitudeTarget.ToUpper()) && !Convert.IsDBNull(reader[C_AttitudeTarget])) this.strAttitudeTarget = Convert.ToString(reader[C_AttitudeTarget]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_ContentFile.ToUpper()) && !Convert.IsDBNull(reader[C_ContentFile])) this.strContentFile = Convert.ToString(reader[C_ContentFile]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed1.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(reader[C_IsReviewed1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(reader[C_ReviewedDate1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(reader[C_ReviewedUser1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(reader[C_ReviewedComment1]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(reader[C_IsReviewed]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(reader[C_ReviewedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(reader[C_ReviewedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(reader[C_ReviewedComment]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ClassSubjectInfo", objEx);
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
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_KnowledgeTarget])) this.strKnowledgeTarget = Convert.ToString(drw[C_KnowledgeTarget]);
				if (!Convert.IsDBNull(drw[C_SkillTarget])) this.strSkillTarget = Convert.ToString(drw[C_SkillTarget]);
				if (!Convert.IsDBNull(drw[C_AttitudeTarget])) this.strAttitudeTarget = Convert.ToString(drw[C_AttitudeTarget]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_ContentFile])) this.strContentFile = Convert.ToString(drw[C_ContentFile]);
				if (!Convert.IsDBNull(drw[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(drw[C_IsReviewed1]);
				if (!Convert.IsDBNull(drw[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(drw[C_ReviewedDate1]);
				if (!Convert.IsDBNull(drw[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(drw[C_ReviewedUser1]);
				if (!Convert.IsDBNull(drw[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(drw[C_ReviewedComment1]);
				if (!Convert.IsDBNull(drw[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(drw[C_IsReviewed]);
				if (!Convert.IsDBNull(drw[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(drw[C_ReviewedDate]);
				if (!Convert.IsDBNull(drw[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(drw[C_ReviewedUser]);
				if (!Convert.IsDBNull(drw[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(drw[C_ReviewedComment]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ClassSubjectInfo", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ClassSubjectInfo_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectInfo_GET");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ClassSubjectInfo", objEx);
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
		/// Store: SIM_ClassSubjectInfo_GET 
		///</summary>
		/// <returns> SIM_ClassSubjectInfo </returns>
		public SIM_ClassSubjectInfo Get(long? lngClassSubjectID)
		{
			SIM_ClassSubjectInfo obj = new SIM_ClassSubjectInfo();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ClassSubjectID = lngClassSubjectID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ClassSubjectInfo
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassSubjectInfo", objEx);
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
		/// Search : SIM_ClassSubjectInfo
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ClassSubjectInfo", objEx);
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
		/// Search : SIM_ClassSubjectInfo
		/// Lấy hết dữ liệu
		/// Store: SIM_ClassSubjectInfo_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ClassSubjectInfo_GETALL");
		}

		///<summary>
		/// Search : SIM_ClassSubjectInfo
		/// Tìm dữ liệu
		/// Store: SIM_ClassSubjectInfo_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ClassSubjectInfo_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ClassSubjectInfo
		/// Thêm dữ liệu
		/// Store: SIM_ClassSubjectInfo_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectInfo_ADD");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_KnowledgeTarget, this.strKnowledgeTarget);
				objIData.AddParameter(P_SkillTarget, this.strSkillTarget);
				objIData.AddParameter(P_AttitudeTarget, this.strAttitudeTarget);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_ContentFile, this.strContentFile);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
				objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
				objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
				objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
				objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ClassSubjectInfo", objEx);
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
		/// Update : SIM_ClassSubjectInfo
		/// Cập nhật dữ liệu
		/// Store: SIM_ClassSubjectInfo_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectInfo_EDIT");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_KnowledgeTarget, this.strKnowledgeTarget);
				objIData.AddParameter(P_SkillTarget, this.strSkillTarget);
				objIData.AddParameter(P_AttitudeTarget, this.strAttitudeTarget);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_ContentFile, this.strContentFile);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
				objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
				objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
				objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
				objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ClassSubjectInfo", objEx);
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
		/// Delete : SIM_ClassSubjectInfo
		/// Xóa dữ liệu
		/// Store: SIM_ClassSubjectInfo_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ClassSubjectInfo_DELETE");
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ClassSubjectInfo", objEx);
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
		/// Store: SIM_ClassSubjectInfo_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngClassSubjectID)
		{
			this.lngClassSubjectID = lngClassSubjectID;
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

		public SIM_ClassSubjectInfo()
		{
		}
		public SIM_ClassSubjectInfo(long? lngClassSubjectID)
		{
			this.lngClassSubjectID = lngClassSubjectID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_KnowledgeTarget = "@" + C_KnowledgeTarget;
		public const String P_SkillTarget = "@" + C_SkillTarget;
		public const String P_AttitudeTarget = "@" + C_AttitudeTarget;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_ContentFile = "@" + C_ContentFile;
		public const String P_IsReviewed1 = "@" + C_IsReviewed1;
		public const String P_ReviewedDate1 = "@" + C_ReviewedDate1;
		public const String P_ReviewedUser1 = "@" + C_ReviewedUser1;
		public const String P_ReviewedComment1 = "@" + C_ReviewedComment1;
		public const String P_IsReviewed = "@" + C_IsReviewed;
		public const String P_ReviewedDate = "@" + C_ReviewedDate;
		public const String P_ReviewedUser = "@" + C_ReviewedUser;
		public const String P_ReviewedComment = "@" + C_ReviewedComment;

		#endregion //Parameter names

		#region Column Names

		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_KnowledgeTarget = "KnowledgeTarget";
		public const String C_SkillTarget = "SkillTarget";
		public const String C_AttitudeTarget = "AttitudeTarget";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_ContentFile = "ContentFile";
		public const String C_IsReviewed1 = "IsReviewed1";
		public const String C_ReviewedDate1 = "ReviewedDate1";
		public const String C_ReviewedUser1 = "ReviewedUser1";
		public const String C_ReviewedComment1 = "ReviewedComment1";
		public const String C_IsReviewed = "IsReviewed";
		public const String C_ReviewedDate = "ReviewedDate";
		public const String C_ReviewedUser = "ReviewedUser";
		public const String C_ReviewedComment = "ReviewedComment";

		#endregion //Column names

		#endregion Variable Static		
	}
}
