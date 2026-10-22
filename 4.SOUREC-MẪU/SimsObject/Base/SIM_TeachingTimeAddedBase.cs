
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
	/// Created date 	: 8/3/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_TeachingTimeAdded
	{	
		#region Member Variables

		private long? lngTeachingTimeAddedID = null;
		private int? intYearID = null;//Mã niên học
		private int? intSemester = null;
		private string strTeacherID = null;//Mã giảng viên, Nếu = ___ (3 dấu gạch chân)  là dòng giá trị cấu hình cho năm đó, nếu hông có thì tự load năm cũ add vào
		private int? intTeacherWorkID = null;
		private long? lngClassSubjectID = null;
		private decimal? decRequestQuantity = null;//Số lượng đề xuất, gv tự nhập
		private decimal? decRequestTotal = null;//Số lượng quy đổi do người dùng tự nhập
		private decimal? decQuantity = null;//Số lượng được tính (có thể do quản lý duyệt)
		private decimal? decTotal = null;//Thời lượng quy đổi được duyệt
		private string strDescription = null;
		private bool bolIsReviewed1 = false;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewedDate1 = null;//Ngày duyệt đăng ký
		private string strReviewedUser1 = null;
		private string strReviewedComment1 = null;
		private bool bolIsReviewed = false;//Đã chấp nhận đăng ký dạy bù
		private DateTime? dtmReviewedDate = null;//Ngày duyệt đăng ký
		private string strReviewedUser = null;
		private string strReviewedComment = null;
		private string strCreatedUser = null;
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strUpdatedUser = null;//Người sửa
		private DateTime? dtmUpdatedDate = null;//Ngày sửa
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// TeachingTimeAddedID
		/// 
		/// </summary>
		public long? TeachingTimeAddedID
		{
			get { return  lngTeachingTimeAddedID; }
			set { lngTeachingTimeAddedID = value; }
		}
		/// <summary>
		/// YearID
		/// Mã niên học
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// Semester
		/// 
		/// </summary>
		public int? Semester
		{
			get { return  intSemester; }
			set { intSemester = value; }
		}
		/// <summary>
		/// TeacherID
		/// Mã giảng viên, Nếu = ___ (3 dấu gạch chân)  là dòng giá trị cấu hình cho năm đó, nếu hông có thì tự load năm cũ add vào
		/// </summary>
		public string TeacherID
		{
			get { return  strTeacherID; }
			set { strTeacherID = value; }
		}
		/// <summary>
		/// TeacherWorkID
		/// 
		/// </summary>
		public int? TeacherWorkID
		{
			get { return  intTeacherWorkID; }
			set { intTeacherWorkID = value; }
		}
		/// <summary>
		/// ClassSubjectID
		/// 
		/// </summary>
		public long? ClassSubjectID
		{
			get { return  lngClassSubjectID; }
			set { lngClassSubjectID = value; }
		}
		/// <summary>
		/// RequestQuantity
		/// Số lượng đề xuất, gv tự nhập
		/// </summary>
		public decimal? RequestQuantity
		{
			get { return  decRequestQuantity; }
			set { decRequestQuantity = value; }
		}
		/// <summary>
		/// RequestTotal
		/// Số lượng quy đổi do người dùng tự nhập
		/// </summary>
		public decimal? RequestTotal
		{
			get { return  decRequestTotal; }
			set { decRequestTotal = value; }
		}
		/// <summary>
		/// Quantity
		/// Số lượng được tính (có thể do quản lý duyệt)
		/// </summary>
		public decimal? Quantity
		{
			get { return  decQuantity; }
			set { decQuantity = value; }
		}
		/// <summary>
		/// Total
		/// Thời lượng quy đổi được duyệt
		/// </summary>
		public decimal? Total
		{
			get { return  decTotal; }
			set { decTotal = value; }
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
		/// CreatedUser
		/// 
		/// </summary>
		public string CreatedUser
		{
			get { return  strCreatedUser; }
			set { strCreatedUser = value; }
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
		/// UpdatedUser
		/// Người sửa
		/// </summary>
		public string UpdatedUser
		{
			get { return  strUpdatedUser; }
			set { strUpdatedUser = value; }
		}
		/// <summary>
		/// UpdatedDate
		/// Ngày sửa
		/// </summary>
		public DateTime? UpdatedDate
		{
			get { return  dtmUpdatedDate; }
			set { dtmUpdatedDate = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_TeachingTimeAddedID.ToUpper()) && !Convert.IsDBNull(reader[C_TeachingTimeAddedID])) this.lngTeachingTimeAddedID = Convert.ToInt64(reader[C_TeachingTimeAddedID]);
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherWorkID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherWorkID])) this.intTeacherWorkID = Convert.ToInt32(reader[C_TeacherWorkID]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestQuantity.ToUpper()) && !Convert.IsDBNull(reader[C_RequestQuantity])) this.decRequestQuantity = Convert.ToDecimal(reader[C_RequestQuantity]);
					if (reader.GetName(i).ToUpper().Equals(C_RequestTotal.ToUpper()) && !Convert.IsDBNull(reader[C_RequestTotal])) this.decRequestTotal = Convert.ToDecimal(reader[C_RequestTotal]);
					if (reader.GetName(i).ToUpper().Equals(C_Quantity.ToUpper()) && !Convert.IsDBNull(reader[C_Quantity])) this.decQuantity = Convert.ToDecimal(reader[C_Quantity]);
					if (reader.GetName(i).ToUpper().Equals(C_Total.ToUpper()) && !Convert.IsDBNull(reader[C_Total])) this.decTotal = Convert.ToDecimal(reader[C_Total]);
					if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed1.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(reader[C_IsReviewed1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(reader[C_ReviewedDate1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(reader[C_ReviewedUser1]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment1.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(reader[C_ReviewedComment1]);
					if (reader.GetName(i).ToUpper().Equals(C_IsReviewed.ToUpper()) && !Convert.IsDBNull(reader[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(reader[C_IsReviewed]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedDate.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(reader[C_ReviewedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedUser.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(reader[C_ReviewedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_ReviewedComment.ToUpper()) && !Convert.IsDBNull(reader[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(reader[C_ReviewedComment]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_TeachingTimeAdded", objEx);
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
				if (!Convert.IsDBNull(drw[C_TeachingTimeAddedID])) this.lngTeachingTimeAddedID = Convert.ToInt64(drw[C_TeachingTimeAddedID]);
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
				if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
				if (!Convert.IsDBNull(drw[C_TeacherWorkID])) this.intTeacherWorkID = Convert.ToInt32(drw[C_TeacherWorkID]);
				if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
				if (!Convert.IsDBNull(drw[C_RequestQuantity])) this.decRequestQuantity = Convert.ToDecimal(drw[C_RequestQuantity]);
				if (!Convert.IsDBNull(drw[C_RequestTotal])) this.decRequestTotal = Convert.ToDecimal(drw[C_RequestTotal]);
				if (!Convert.IsDBNull(drw[C_Quantity])) this.decQuantity = Convert.ToDecimal(drw[C_Quantity]);
				if (!Convert.IsDBNull(drw[C_Total])) this.decTotal = Convert.ToDecimal(drw[C_Total]);
				if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
				if (!Convert.IsDBNull(drw[C_IsReviewed1])) this.bolIsReviewed1 = Convert.ToBoolean(drw[C_IsReviewed1]);
				if (!Convert.IsDBNull(drw[C_ReviewedDate1])) this.dtmReviewedDate1 = Convert.ToDateTime(drw[C_ReviewedDate1]);
				if (!Convert.IsDBNull(drw[C_ReviewedUser1])) this.strReviewedUser1 = Convert.ToString(drw[C_ReviewedUser1]);
				if (!Convert.IsDBNull(drw[C_ReviewedComment1])) this.strReviewedComment1 = Convert.ToString(drw[C_ReviewedComment1]);
				if (!Convert.IsDBNull(drw[C_IsReviewed])) this.bolIsReviewed = Convert.ToBoolean(drw[C_IsReviewed]);
				if (!Convert.IsDBNull(drw[C_ReviewedDate])) this.dtmReviewedDate = Convert.ToDateTime(drw[C_ReviewedDate]);
				if (!Convert.IsDBNull(drw[C_ReviewedUser])) this.strReviewedUser = Convert.ToString(drw[C_ReviewedUser]);
				if (!Convert.IsDBNull(drw[C_ReviewedComment])) this.strReviewedComment = Convert.ToString(drw[C_ReviewedComment]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_TeachingTimeAdded", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_TeachingTimeAdded_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeachingTimeAdded_GET");
				objIData.AddParameter(P_TeachingTimeAddedID, this.lngTeachingTimeAddedID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_TeachingTimeAdded", objEx);
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
		/// Store: SIM_TeachingTimeAdded_GET 
		///</summary>
		/// <returns> SIM_TeachingTimeAdded </returns>
		public SIM_TeachingTimeAdded Get(long? lngTeachingTimeAddedID)
		{
			SIM_TeachingTimeAdded obj = new SIM_TeachingTimeAdded();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.TeachingTimeAddedID = lngTeachingTimeAddedID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_TeachingTimeAdded
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TeachingTimeAdded", objEx);
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
		/// Search : SIM_TeachingTimeAdded
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_TeachingTimeAdded", objEx);
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
		/// Search : SIM_TeachingTimeAdded
		/// Lấy hết dữ liệu
		/// Store: SIM_TeachingTimeAdded_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_TeachingTimeAdded_GETALL");
		}

		///<summary>
		/// Search : SIM_TeachingTimeAdded
		/// Tìm dữ liệu
		/// Store: SIM_TeachingTimeAdded_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_TeachingTimeAdded_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_TeachingTimeAdded
		/// Thêm dữ liệu
		/// Store: SIM_TeachingTimeAdded_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeachingTimeAdded_ADD");
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_TeacherWorkID, this.intTeacherWorkID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_RequestQuantity, this.decRequestQuantity);
				objIData.AddParameter(P_RequestTotal, this.decRequestTotal);
				objIData.AddParameter(P_Quantity, this.decQuantity);
				objIData.AddParameter(P_Total, this.decTotal);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
				objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
				objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
				objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
				objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				this.lngTeachingTimeAddedID = Convert.ToInt32(objIData.ExecStoreToString());
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_TeachingTimeAdded", objEx);
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
		/// Update : SIM_TeachingTimeAdded
		/// Cập nhật dữ liệu
		/// Store: SIM_TeachingTimeAdded_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeachingTimeAdded_EDIT");
				objIData.AddParameter(P_TeachingTimeAddedID, this.lngTeachingTimeAddedID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_Semester, this.intSemester);
				objIData.AddParameter(P_TeacherID, this.strTeacherID);
				objIData.AddParameter(P_TeacherWorkID, this.intTeacherWorkID);
				objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
				objIData.AddParameter(P_RequestQuantity, this.decRequestQuantity);
				objIData.AddParameter(P_RequestTotal, this.decRequestTotal);
				objIData.AddParameter(P_Quantity, this.decQuantity);
				objIData.AddParameter(P_Total, this.decTotal);
				objIData.AddParameter(P_Description, this.strDescription);
				objIData.AddParameter(P_IsReviewed1, this.bolIsReviewed1);
				objIData.AddParameter(P_ReviewedDate1, this.dtmReviewedDate1);
				objIData.AddParameter(P_ReviewedUser1, this.strReviewedUser1);
				objIData.AddParameter(P_ReviewedComment1, this.strReviewedComment1);
				objIData.AddParameter(P_IsReviewed, this.bolIsReviewed);
				objIData.AddParameter(P_ReviewedDate, this.dtmReviewedDate);
				objIData.AddParameter(P_ReviewedUser, this.strReviewedUser);
				objIData.AddParameter(P_ReviewedComment, this.strReviewedComment);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_TeachingTimeAdded", objEx);
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
		/// Delete : SIM_TeachingTimeAdded
		/// Xóa dữ liệu
		/// Store: SIM_TeachingTimeAdded_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_TeachingTimeAdded_DELETE");
				objIData.AddParameter(P_TeachingTimeAddedID, this.lngTeachingTimeAddedID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_TeachingTimeAdded", objEx);
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
		/// Store: SIM_TeachingTimeAdded_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngTeachingTimeAddedID)
		{
			this.lngTeachingTimeAddedID = lngTeachingTimeAddedID;
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

		public SIM_TeachingTimeAdded()
		{
		}
		public SIM_TeachingTimeAdded(long? lngTeachingTimeAddedID)
		{
			this.lngTeachingTimeAddedID = lngTeachingTimeAddedID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_TeachingTimeAddedID = "@" + C_TeachingTimeAddedID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_Semester = "@" + C_Semester;
		public const String P_TeacherID = "@" + C_TeacherID;
		public const String P_TeacherWorkID = "@" + C_TeacherWorkID;
		public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
		public const String P_RequestQuantity = "@" + C_RequestQuantity;
		public const String P_RequestTotal = "@" + C_RequestTotal;
		public const String P_Quantity = "@" + C_Quantity;
		public const String P_Total = "@" + C_Total;
		public const String P_Description = "@" + C_Description;
		public const String P_IsReviewed1 = "@" + C_IsReviewed1;
		public const String P_ReviewedDate1 = "@" + C_ReviewedDate1;
		public const String P_ReviewedUser1 = "@" + C_ReviewedUser1;
		public const String P_ReviewedComment1 = "@" + C_ReviewedComment1;
		public const String P_IsReviewed = "@" + C_IsReviewed;
		public const String P_ReviewedDate = "@" + C_ReviewedDate;
		public const String P_ReviewedUser = "@" + C_ReviewedUser;
		public const String P_ReviewedComment = "@" + C_ReviewedComment;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;

		#endregion //Parameter names

		#region Column Names

		public const String C_TeachingTimeAddedID = "TeachingTimeAddedID";
		public const String C_YearID = "YearID";
		public const String C_Semester = "Semester";
		public const String C_TeacherID = "TeacherID";
		public const String C_TeacherWorkID = "TeacherWorkID";
		public const String C_ClassSubjectID = "ClassSubjectID";
		public const String C_RequestQuantity = "RequestQuantity";
		public const String C_RequestTotal = "RequestTotal";
		public const String C_Quantity = "Quantity";
		public const String C_Total = "Total";
		public const String C_Description = "Description";
		public const String C_IsReviewed1 = "IsReviewed1";
		public const String C_ReviewedDate1 = "ReviewedDate1";
		public const String C_ReviewedUser1 = "ReviewedUser1";
		public const String C_ReviewedComment1 = "ReviewedComment1";
		public const String C_IsReviewed = "IsReviewed";
		public const String C_ReviewedDate = "ReviewedDate";
		public const String C_ReviewedUser = "ReviewedUser";
		public const String C_ReviewedComment = "ReviewedComment";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_UpdatedDate = "UpdatedDate";

		#endregion //Column names

		#endregion Variable Static		
	}
}
