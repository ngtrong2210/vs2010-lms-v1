
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
	/// Created by 		: NGUYỄN VĂN VIỆT 
	/// Created date 	: 7/14/2012 
	/// Description 
	/// </summary>	
	public partial class SIM_GraduationExamReview
	{	
		#region Member Variables

		private long? lngStudentID = null;//Mã sinh viên
		private int? intOrderReview = null;//Đợt xét dự thi tốt nghiệp
		private double? dblSummaryLearningMark = null;//TBC học tập các môn học toàn khoá
		private string strLearningLevel = null;//Xếp loại học tập cả khoá
		private double? dblSummaryEthicMark = null;//Điển tổng kết rèn luyện toàn khoá
		private string strEthicLevel = null;//Xếp loại rèn luyện toàn khoá
		private int? intSpecialType = null;//Loại đặc trưng: 1_Bình thường, 2. Tốt nghiệp LT, 3. Tốt nghiệp TH, 4. CT tốt nghiệp, 5. Tốt nghiệp Văn hoá, 6. GD thể chất, 7. GD quốc phòng,8. Văn hóa
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
		/// StudentID
		/// Mã sinh viên
		/// </summary>
		public long? StudentID
		{
			get { return  lngStudentID; }
			set { lngStudentID = value; }
		}
		/// <summary>
		/// OrderReview
		/// Đợt xét dự thi tốt nghiệp
		/// </summary>
		public int? OrderReview
		{
			get { return  intOrderReview; }
			set { intOrderReview = value; }
		}
		/// <summary>
		/// SummaryLearningMark
		/// TBC học tập các môn học toàn khoá
		/// </summary>
		public double? SummaryLearningMark
		{
			get { return  dblSummaryLearningMark; }
			set { dblSummaryLearningMark = value; }
		}
		/// <summary>
		/// LearningLevel
		/// Xếp loại học tập cả khoá
		/// </summary>
		public string LearningLevel
		{
			get { return  strLearningLevel; }
			set { strLearningLevel = value; }
		}
		/// <summary>
		/// SummaryEthicMark
		/// Điển tổng kết rèn luyện toàn khoá
		/// </summary>
		public double? SummaryEthicMark
		{
			get { return  dblSummaryEthicMark; }
			set { dblSummaryEthicMark = value; }
		}
		/// <summary>
		/// EthicLevel
		/// Xếp loại rèn luyện toàn khoá
		/// </summary>
		public string EthicLevel
		{
			get { return  strEthicLevel; }
			set { strEthicLevel = value; }
		}
		/// <summary>
		/// SpecialType
		/// Loại đặc trưng: 1_Bình thường, 2. Tốt nghiệp LT, 3. Tốt nghiệp TH, 4. CT tốt nghiệp, 5. Tốt nghiệp Văn hoá, 6. GD thể chất, 7. GD quốc phòng,8. Văn hóa
		/// </summary>
		public int? SpecialType
		{
			get { return  intSpecialType; }
			set { intSpecialType = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderReview.ToUpper()) && !Convert.IsDBNull(reader[C_OrderReview])) this.intOrderReview = Convert.ToInt32(reader[C_OrderReview]);
					if (reader.GetName(i).ToUpper().Equals(C_SummaryLearningMark.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryLearningMark])) this.dblSummaryLearningMark = (double)reader[C_SummaryLearningMark];
					if (reader.GetName(i).ToUpper().Equals(C_LearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel])) this.strLearningLevel = Convert.ToString(reader[C_LearningLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_SummaryEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryEthicMark])) this.dblSummaryEthicMark = (double)reader[C_SummaryEthicMark];
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel])) this.strEthicLevel = Convert.ToString(reader[C_EthicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_SpecialType.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialType])) this.intSpecialType = Convert.ToInt32(reader[C_SpecialType]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_GraduationExamReview", objEx);
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
				if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
				if (!Convert.IsDBNull(drw[C_OrderReview])) this.intOrderReview = Convert.ToInt32(drw[C_OrderReview]);
				if (!Convert.IsDBNull(drw[C_SummaryLearningMark])) this.dblSummaryLearningMark = (double)drw[C_SummaryLearningMark];
				if (!Convert.IsDBNull(drw[C_LearningLevel])) this.strLearningLevel = Convert.ToString(drw[C_LearningLevel]);
				if (!Convert.IsDBNull(drw[C_SummaryEthicMark])) this.dblSummaryEthicMark = (double)drw[C_SummaryEthicMark];
				if (!Convert.IsDBNull(drw[C_EthicLevel])) this.strEthicLevel = Convert.ToString(drw[C_EthicLevel]);
				if (!Convert.IsDBNull(drw[C_SpecialType])) this.intSpecialType = Convert.ToInt32(drw[C_SpecialType]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_GraduationExamReview", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_GraduationExamReview_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_GraduationExamReview_GET");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_GraduationExamReview", objEx);
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
		/// Store: SIM_GraduationExamReview_GET 
		///</summary>
		/// <returns> SIM_GraduationExamReview </returns>
		public SIM_GraduationExamReview Get(long? lngStudentID)
		{
			SIM_GraduationExamReview obj = new SIM_GraduationExamReview();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentID = lngStudentID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_GraduationExamReview
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_GraduationExamReview", objEx);
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
		/// Search : SIM_GraduationExamReview
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_GraduationExamReview", objEx);
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
		/// Search : SIM_GraduationExamReview
		/// Lấy hết dữ liệu
		/// Store: SIM_GraduationExamReview_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_GraduationExamReview_GETALL");
		}

		///<summary>
		/// Search : SIM_GraduationExamReview
		/// Tìm dữ liệu
		/// Store: SIM_GraduationExamReview_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_GraduationExamReview_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_GraduationExamReview
		/// Thêm dữ liệu
		/// Store: SIM_GraduationExamReview_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_GraduationExamReview_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_OrderReview, this.intOrderReview);
				objIData.AddParameter(P_SummaryLearningMark, this.dblSummaryLearningMark);
				objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
				objIData.AddParameter(P_SummaryEthicMark, this.dblSummaryEthicMark);
				objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
				objIData.AddParameter(P_SpecialType, this.intSpecialType);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_GraduationExamReview", objEx);
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
		/// Update : SIM_GraduationExamReview
		/// Cập nhật dữ liệu
		/// Store: SIM_GraduationExamReview_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_GraduationExamReview_EDIT");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_OrderReview, this.intOrderReview);
				objIData.AddParameter(P_SummaryLearningMark, this.dblSummaryLearningMark);
				objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
				objIData.AddParameter(P_SummaryEthicMark, this.dblSummaryEthicMark);
				objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
				objIData.AddParameter(P_SpecialType, this.intSpecialType);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_GraduationExamReview", objEx);
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
		/// Delete : SIM_GraduationExamReview
		/// Xóa dữ liệu
		/// Store: SIM_GraduationExamReview_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_GraduationExamReview_DELETE");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SpecialType, this.intSpecialType);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_GraduationExamReview", objEx);
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
		/// Store: SIM_GraduationExamReview_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngStudentID)
		{
			this.lngStudentID = lngStudentID;
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

		public SIM_GraduationExamReview()
		{
		}
		public SIM_GraduationExamReview(long? lngStudentID)
		{
			this.lngStudentID = lngStudentID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentID = "@" + C_StudentID;
		public const String P_OrderReview = "@" + C_OrderReview;
		public const String P_SummaryLearningMark = "@" + C_SummaryLearningMark;
		public const String P_LearningLevel = "@" + C_LearningLevel;
		public const String P_SummaryEthicMark = "@" + C_SummaryEthicMark;
		public const String P_EthicLevel = "@" + C_EthicLevel;
		public const String P_SpecialType = "@" + C_SpecialType;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentID = "StudentID";
		public const String C_OrderReview = "OrderReview";
        public const String C_SummaryLearningMark = "SummaryLearningMark";
		public const String C_LearningLevel = "LearningLevel";
		public const String C_SummaryEthicMark = "SummaryEthicMark";
		public const String C_EthicLevel = "EthicLevel";
		public const String C_SpecialType = "SpecialType";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";

		#endregion //Column names

		#endregion Variable Static		
	}
}
