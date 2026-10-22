
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
	/// Created date 	: 8/7/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_Promotion
	{	
		#region Member Variables

		private int? intPromotionID = null;
		private string strPromotionCode = null;
		private string strPromotionName = null;//Tên lớp
		private string strPromotionNameEn = null;//Tên lớp
		private double? dblDiscountPercentFee = null;//% giảm
		private int? intDiscountFee = null;//Học phí giảm
		private DateTime? dtmStartAt = null;//Ngày áp dụng
		private DateTime? dtmFinishAt = null;//Ngày kết thúc
		private bool bolIsActived = false;//Kích hoạt
		private bool bolAllowEditValue = false;//Cho phép điều chỉnh số tiền khuyến mãi
		private int? intOrderIndex = null;
		private string strDescription = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// PromotionID
		/// 
		/// </summary>
		public int? PromotionID
		{
			get { return  intPromotionID; }
			set { intPromotionID = value; }
		}
		/// <summary>
		/// PromotionCode
		/// 
		/// </summary>
		public string PromotionCode
		{
			get { return  strPromotionCode; }
			set { strPromotionCode = value; }
		}
		/// <summary>
		/// PromotionName
		/// Tên lớp
		/// </summary>
		public string PromotionName
		{
			get { return  strPromotionName; }
			set { strPromotionName = value; }
		}
		/// <summary>
		/// PromotionNameEn
		/// Tên lớp
		/// </summary>
		public string PromotionNameEn
		{
			get { return  strPromotionNameEn; }
			set { strPromotionNameEn = value; }
		}
		/// <summary>
		/// DiscountPercentFee
		/// % giảm
		/// </summary>
		public double? DiscountPercentFee
		{
			get { return  dblDiscountPercentFee; }
			set { dblDiscountPercentFee = value; }
		}
		/// <summary>
		/// DiscountFee
		/// Học phí giảm
		/// </summary>
		public int? DiscountFee
		{
			get { return  intDiscountFee; }
			set { intDiscountFee = value; }
		}
		/// <summary>
		/// StartAt
		/// Ngày áp dụng
		/// </summary>
		public DateTime? StartAt
		{
			get { return  dtmStartAt; }
			set { dtmStartAt = value; }
		}
		/// <summary>
		/// FinishAt
		/// Ngày kết thúc
		/// </summary>
		public DateTime? FinishAt
		{
			get { return  dtmFinishAt; }
			set { dtmFinishAt = value; }
		}
		/// <summary>
		/// IsActived
		/// Kích hoạt
		/// </summary>
		public bool IsActived
		{
			get { return  bolIsActived; }
			set { bolIsActived = value; }
		}
		/// <summary>
		/// AllowEditValue
		/// Cho phép điều chỉnh số tiền khuyến mãi
		/// </summary>
		public bool AllowEditValue
		{
			get { return  bolAllowEditValue; }
			set { bolAllowEditValue = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_PromotionID.ToUpper()) && !Convert.IsDBNull(reader[C_PromotionID])) this.intPromotionID = Convert.ToInt32(reader[C_PromotionID]);
					if (reader.GetName(i).ToUpper().Equals(C_PromotionCode.ToUpper()) && !Convert.IsDBNull(reader[C_PromotionCode])) this.strPromotionCode = Convert.ToString(reader[C_PromotionCode]);
					if (reader.GetName(i).ToUpper().Equals(C_PromotionName.ToUpper()) && !Convert.IsDBNull(reader[C_PromotionName])) this.strPromotionName = Convert.ToString(reader[C_PromotionName]);
					if (reader.GetName(i).ToUpper().Equals(C_PromotionNameEn.ToUpper()) && !Convert.IsDBNull(reader[C_PromotionNameEn])) this.strPromotionNameEn = Convert.ToString(reader[C_PromotionNameEn]);
					if (reader.GetName(i).ToUpper().Equals(C_DiscountPercentFee.ToUpper()) && !Convert.IsDBNull(reader[C_DiscountPercentFee])) this.dblDiscountPercentFee = Convert.ToDouble(reader[C_DiscountPercentFee]);
					if (reader.GetName(i).ToUpper().Equals(C_DiscountFee.ToUpper()) && !Convert.IsDBNull(reader[C_DiscountFee])) this.intDiscountFee = Convert.ToInt32(reader[C_DiscountFee]);
					if (reader.GetName(i).ToUpper().Equals(C_StartAt.ToUpper()) && !Convert.IsDBNull(reader[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(reader[C_StartAt]);
					if (reader.GetName(i).ToUpper().Equals(C_FinishAt.ToUpper()) && !Convert.IsDBNull(reader[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(reader[C_FinishAt]);
					if (reader.GetName(i).ToUpper().Equals(C_IsActived.ToUpper()) && !Convert.IsDBNull(reader[C_IsActived])) this.bolIsActived = Convert.ToBoolean(reader[C_IsActived]);
					if (reader.GetName(i).ToUpper().Equals(C_AllowEditValue.ToUpper()) && !Convert.IsDBNull(reader[C_AllowEditValue])) this.bolAllowEditValue = Convert.ToBoolean(reader[C_AllowEditValue]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_Promotion", objEx);
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
				if (!Convert.IsDBNull(drw[C_PromotionID])) this.intPromotionID = Convert.ToInt32(drw[C_PromotionID]);
				if (!Convert.IsDBNull(drw[C_PromotionCode])) this.strPromotionCode = Convert.ToString(drw[C_PromotionCode]);
				if (!Convert.IsDBNull(drw[C_PromotionName])) this.strPromotionName = Convert.ToString(drw[C_PromotionName]);
				if (!Convert.IsDBNull(drw[C_PromotionNameEn])) this.strPromotionNameEn = Convert.ToString(drw[C_PromotionNameEn]);
				if (!Convert.IsDBNull(drw[C_DiscountPercentFee])) this.dblDiscountPercentFee = Convert.ToDouble(drw[C_DiscountPercentFee]);
				if (!Convert.IsDBNull(drw[C_DiscountFee])) this.intDiscountFee = Convert.ToInt32(drw[C_DiscountFee]);
				if (!Convert.IsDBNull(drw[C_StartAt])) this.dtmStartAt = Convert.ToDateTime(drw[C_StartAt]);
				if (!Convert.IsDBNull(drw[C_FinishAt])) this.dtmFinishAt = Convert.ToDateTime(drw[C_FinishAt]);
				if (!Convert.IsDBNull(drw[C_IsActived])) this.bolIsActived = Convert.ToBoolean(drw[C_IsActived]);
				if (!Convert.IsDBNull(drw[C_AllowEditValue])) this.bolAllowEditValue = Convert.ToBoolean(drw[C_AllowEditValue]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_Promotion", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_Promotion_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Promotion_GET");
				objIData.AddParameter(P_PromotionID, this.intPromotionID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_Promotion", objEx);
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
		/// Store: SIM_Promotion_GET 
		///</summary>
		/// <returns> SIM_Promotion </returns>
		public SIM_Promotion Get(int? intPromotionID)
		{
			SIM_Promotion obj = new SIM_Promotion();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.PromotionID = intPromotionID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_Promotion
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Promotion", objEx);
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
		/// Search : SIM_Promotion
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_Promotion", objEx);
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
		/// Search : SIM_Promotion
		/// Lấy hết dữ liệu
		/// Store: SIM_Promotion_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_Promotion_GETALL");
		}

		///<summary>
		/// Search : SIM_Promotion
		/// Tìm dữ liệu
		/// Store: SIM_Promotion_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_Promotion_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_Promotion
		/// Thêm dữ liệu
		/// Store: SIM_Promotion_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Promotion_ADD");
				objIData.AddParameter(P_PromotionCode, this.strPromotionCode);
				objIData.AddParameter(P_PromotionName, this.strPromotionName);
				objIData.AddParameter(P_PromotionNameEn, this.strPromotionNameEn);
				objIData.AddParameter(P_DiscountPercentFee, this.dblDiscountPercentFee);
				objIData.AddParameter(P_DiscountFee, this.intDiscountFee);
				objIData.AddParameter(P_StartAt, this.dtmStartAt);
				objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_AllowEditValue, this.bolAllowEditValue);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.intPromotionID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_Promotion", objEx);
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
		/// Update : SIM_Promotion
		/// Cập nhật dữ liệu
		/// Store: SIM_Promotion_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Promotion_EDIT");
				objIData.AddParameter(P_PromotionID, this.intPromotionID);
				objIData.AddParameter(P_PromotionCode, this.strPromotionCode);
				objIData.AddParameter(P_PromotionName, this.strPromotionName);
				objIData.AddParameter(P_PromotionNameEn, this.strPromotionNameEn);
				objIData.AddParameter(P_DiscountPercentFee, this.dblDiscountPercentFee);
				objIData.AddParameter(P_DiscountFee, this.intDiscountFee);
				objIData.AddParameter(P_StartAt, this.dtmStartAt);
				objIData.AddParameter(P_FinishAt, this.dtmFinishAt);
				objIData.AddParameter(P_IsActived, this.bolIsActived);
				objIData.AddParameter(P_AllowEditValue, this.bolAllowEditValue);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_Promotion", objEx);
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
		/// Delete : SIM_Promotion
		/// Xóa dữ liệu
		/// Store: SIM_Promotion_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_Promotion_DELETE");
				objIData.AddParameter(P_PromotionID, this.intPromotionID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_Promotion", objEx);
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
		/// Store: SIM_Promotion_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(int? intPromotionID)
		{
			this.intPromotionID = intPromotionID;
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

		public SIM_Promotion()
		{
		}
		public SIM_Promotion(int? intPromotionID)
		{
			this.intPromotionID = intPromotionID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_PromotionID = "@" + C_PromotionID;
		public const String P_PromotionCode = "@" + C_PromotionCode;
		public const String P_PromotionName = "@" + C_PromotionName;
		public const String P_PromotionNameEn = "@" + C_PromotionNameEn;
		public const String P_DiscountPercentFee = "@" + C_DiscountPercentFee;
		public const String P_DiscountFee = "@" + C_DiscountFee;
		public const String P_StartAt = "@" + C_StartAt;
		public const String P_FinishAt = "@" + C_FinishAt;
		public const String P_IsActived = "@" + C_IsActived;
		public const String P_AllowEditValue = "@" + C_AllowEditValue;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_Description = "@" + C_Description;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_PromotionID = "PromotionID";
		public const String C_PromotionCode = "PromotionCode";
		public const String C_PromotionName = "PromotionName";
		public const String C_PromotionNameEn = "PromotionNameEn";
		public const String C_DiscountPercentFee = "DiscountPercentFee";
		public const String C_DiscountFee = "DiscountFee";
		public const String C_StartAt = "StartAt";
		public const String C_FinishAt = "FinishAt";
		public const String C_IsActived = "IsActived";
		public const String C_AllowEditValue = "AllowEditValue";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_Description = "Description";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
