
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
	/// Created date 	: 8/9/2022 
	/// Description 
	/// </summary>	
	public partial class SIM_ScanDEDetail
	{	
		#region Member Variables

		private long? lngScanFileID = null;
		private int? intOrderIndex = null;//Thứ tự dòng = Thứ tự câu hỏi (nếu là trang 2,3... thì thứ tự này là tiếp theo, ko fai từ 0)
		private string strValue1 = null;//Cột trả lời (nếu có tô thì là X)
		private string strValue2 = null;//Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		private string strValue3 = null;//Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		private string strValue4 = null;//Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		private string strValue5 = null;//Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		private string strValue6 = null;//Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		private string strDoAnswerLabelList = null;//Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		private string strTrueAnswerLabelList = null;//Danh sách nhãn câu trả lời đúng theo dạng list B,D (nhận dạng và lấy từ đề tương đương)
		private bool bolIsTrueSelected = false;//Đã chọn đúng (nhận dạng được từ đề tương đương và chấm điểm)
		private decimal? decMark = null;//Thang điểm của câu (lấy từ đề tương đương)
		private IData objIData = null;
		private bool bolIsExistIData = false;
		private Exception objErrorException = null;

		#endregion

		#region Properties 

		/// <summary>
		/// ScanFileID
		/// 
		/// </summary>
		public long? ScanFileID
		{
			get { return  lngScanFileID; }
			set { lngScanFileID = value; }
		}
		/// <summary>
		/// OrderIndex
		/// Thứ tự dòng = Thứ tự câu hỏi (nếu là trang 2,3... thì thứ tự này là tiếp theo, ko fai từ 0)
		/// </summary>
		public int? OrderIndex
		{
			get { return  intOrderIndex; }
			set { intOrderIndex = value; }
		}
		/// <summary>
		/// Value1
		/// Cột trả lời (nếu có tô thì là X)
		/// </summary>
		public string Value1
		{
			get { return  strValue1; }
			set { strValue1 = value; }
		}
		/// <summary>
		/// Value2
		/// Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		/// </summary>
		public string Value2
		{
			get { return  strValue2; }
			set { strValue2 = value; }
		}
		/// <summary>
		/// Value3
		/// Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		/// </summary>
		public string Value3
		{
			get { return  strValue3; }
			set { strValue3 = value; }
		}
		/// <summary>
		/// Value4
		/// Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		/// </summary>
		public string Value4
		{
			get { return  strValue4; }
			set { strValue4 = value; }
		}
		/// <summary>
		/// Value5
		/// Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		/// </summary>
		public string Value5
		{
			get { return  strValue5; }
			set { strValue5 = value; }
		}
		/// <summary>
		/// Value6
		/// Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		/// </summary>
		public string Value6
		{
			get { return  strValue6; }
			set { strValue6 = value; }
		}
		/// <summary>
		/// DoAnswerLabelList
		/// Danh sách nhãn câu trả lời theo dạng list B,D,E (kết quả scan) tương ứng  DoAnswerLabelID
		/// </summary>
		public string DoAnswerLabelList
		{
			get { return  strDoAnswerLabelList; }
			set { strDoAnswerLabelList = value; }
		}
		/// <summary>
		/// TrueAnswerLabelList
		/// Danh sách nhãn câu trả lời đúng theo dạng list B,D (nhận dạng và lấy từ đề tương đương)
		/// </summary>
		public string TrueAnswerLabelList
		{
			get { return  strTrueAnswerLabelList; }
			set { strTrueAnswerLabelList = value; }
		}
		/// <summary>
		/// IsTrueSelected
		/// Đã chọn đúng (nhận dạng được từ đề tương đương và chấm điểm)
		/// </summary>
		public bool IsTrueSelected
		{
			get { return  bolIsTrueSelected; }
			set { bolIsTrueSelected = value; }
		}
		/// <summary>
		/// Mark
		/// Thang điểm của câu (lấy từ đề tương đương)
		/// </summary>
		public decimal? Mark
		{
			get { return  decMark; }
			set { decMark = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_ScanFileID.ToUpper()) && !Convert.IsDBNull(reader[C_ScanFileID])) this.lngScanFileID = Convert.ToInt64(reader[C_ScanFileID]);
					if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
					if (reader.GetName(i).ToUpper().Equals(C_Value1.ToUpper()) && !Convert.IsDBNull(reader[C_Value1])) this.strValue1 = Convert.ToString(reader[C_Value1]);
					if (reader.GetName(i).ToUpper().Equals(C_Value2.ToUpper()) && !Convert.IsDBNull(reader[C_Value2])) this.strValue2 = Convert.ToString(reader[C_Value2]);
					if (reader.GetName(i).ToUpper().Equals(C_Value3.ToUpper()) && !Convert.IsDBNull(reader[C_Value3])) this.strValue3 = Convert.ToString(reader[C_Value3]);
					if (reader.GetName(i).ToUpper().Equals(C_Value4.ToUpper()) && !Convert.IsDBNull(reader[C_Value4])) this.strValue4 = Convert.ToString(reader[C_Value4]);
					if (reader.GetName(i).ToUpper().Equals(C_Value5.ToUpper()) && !Convert.IsDBNull(reader[C_Value5])) this.strValue5 = Convert.ToString(reader[C_Value5]);
					if (reader.GetName(i).ToUpper().Equals(C_Value6.ToUpper()) && !Convert.IsDBNull(reader[C_Value6])) this.strValue6 = Convert.ToString(reader[C_Value6]);
					if (reader.GetName(i).ToUpper().Equals(C_DoAnswerLabelList.ToUpper()) && !Convert.IsDBNull(reader[C_DoAnswerLabelList])) this.strDoAnswerLabelList = Convert.ToString(reader[C_DoAnswerLabelList]);
					if (reader.GetName(i).ToUpper().Equals(C_TrueAnswerLabelList.ToUpper()) && !Convert.IsDBNull(reader[C_TrueAnswerLabelList])) this.strTrueAnswerLabelList = Convert.ToString(reader[C_TrueAnswerLabelList]);
					if (reader.GetName(i).ToUpper().Equals(C_IsTrueSelected.ToUpper()) && !Convert.IsDBNull(reader[C_IsTrueSelected])) this.bolIsTrueSelected = Convert.ToBoolean(reader[C_IsTrueSelected]);
					if (reader.GetName(i).ToUpper().Equals(C_Mark.ToUpper()) && !Convert.IsDBNull(reader[C_Mark])) this.decMark = Convert.ToDecimal(reader[C_Mark]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_ScanDEDetail", objEx);
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
				if (!Convert.IsDBNull(drw[C_ScanFileID])) this.lngScanFileID = Convert.ToInt64(drw[C_ScanFileID]);
				if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
				if (!Convert.IsDBNull(drw[C_Value1])) this.strValue1 = Convert.ToString(drw[C_Value1]);
				if (!Convert.IsDBNull(drw[C_Value2])) this.strValue2 = Convert.ToString(drw[C_Value2]);
				if (!Convert.IsDBNull(drw[C_Value3])) this.strValue3 = Convert.ToString(drw[C_Value3]);
				if (!Convert.IsDBNull(drw[C_Value4])) this.strValue4 = Convert.ToString(drw[C_Value4]);
				if (!Convert.IsDBNull(drw[C_Value5])) this.strValue5 = Convert.ToString(drw[C_Value5]);
				if (!Convert.IsDBNull(drw[C_Value6])) this.strValue6 = Convert.ToString(drw[C_Value6]);
				if (!Convert.IsDBNull(drw[C_DoAnswerLabelList])) this.strDoAnswerLabelList = Convert.ToString(drw[C_DoAnswerLabelList]);
				if (!Convert.IsDBNull(drw[C_TrueAnswerLabelList])) this.strTrueAnswerLabelList = Convert.ToString(drw[C_TrueAnswerLabelList]);
				if (!Convert.IsDBNull(drw[C_IsTrueSelected])) this.bolIsTrueSelected = Convert.ToBoolean(drw[C_IsTrueSelected]);
				if (!Convert.IsDBNull(drw[C_Mark])) this.decMark = Convert.ToDecimal(drw[C_Mark]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_ScanDEDetail", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_ScanDEDetail_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDEDetail_GET");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_ScanDEDetail", objEx);
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
		/// Store: SIM_ScanDEDetail_GET 
		///</summary>
		/// <returns> SIM_ScanDEDetail </returns>
		public SIM_ScanDEDetail Get(long? lngScanFileID, int? intOrderIndex)
		{
			SIM_ScanDEDetail obj = new SIM_ScanDEDetail();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.ScanFileID = lngScanFileID;
			obj.OrderIndex = intOrderIndex;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_ScanDEDetail
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanDEDetail", objEx);
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
		/// Search : SIM_ScanDEDetail
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_ScanDEDetail", objEx);
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
		/// Search : SIM_ScanDEDetail
		/// Lấy hết dữ liệu
		/// Store: SIM_ScanDEDetail_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_ScanDEDetail_GETALL");
		}

		///<summary>
		/// Search : SIM_ScanDEDetail
		/// Tìm dữ liệu
		/// Store: SIM_ScanDEDetail_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_ScanDEDetail_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_ScanDEDetail
		/// Thêm dữ liệu
		/// Store: SIM_ScanDEDetail_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDEDetail_ADD");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Value1, this.strValue1);
				objIData.AddParameter(P_Value2, this.strValue2);
				objIData.AddParameter(P_Value3, this.strValue3);
				objIData.AddParameter(P_Value4, this.strValue4);
				objIData.AddParameter(P_Value5, this.strValue5);
				objIData.AddParameter(P_Value6, this.strValue6);
				objIData.AddParameter(P_DoAnswerLabelList, this.strDoAnswerLabelList);
				objIData.AddParameter(P_TrueAnswerLabelList, this.strTrueAnswerLabelList);
				objIData.AddParameter(P_IsTrueSelected, this.bolIsTrueSelected);
				objIData.AddParameter(P_Mark, this.decMark);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_ScanDEDetail", objEx);
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
		/// Update : SIM_ScanDEDetail
		/// Cập nhật dữ liệu
		/// Store: SIM_ScanDEDetail_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDEDetail_EDIT");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
				objIData.AddParameter(P_Value1, this.strValue1);
				objIData.AddParameter(P_Value2, this.strValue2);
				objIData.AddParameter(P_Value3, this.strValue3);
				objIData.AddParameter(P_Value4, this.strValue4);
				objIData.AddParameter(P_Value5, this.strValue5);
				objIData.AddParameter(P_Value6, this.strValue6);
				objIData.AddParameter(P_DoAnswerLabelList, this.strDoAnswerLabelList);
				objIData.AddParameter(P_TrueAnswerLabelList, this.strTrueAnswerLabelList);
				objIData.AddParameter(P_IsTrueSelected, this.bolIsTrueSelected);
				objIData.AddParameter(P_Mark, this.decMark);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_ScanDEDetail", objEx);
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
		/// Delete : SIM_ScanDEDetail
		/// Xóa dữ liệu
		/// Store: SIM_ScanDEDetail_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_ScanDEDetail_DELETE");
				objIData.AddParameter(P_ScanFileID, this.lngScanFileID);
				objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_ScanDEDetail", objEx);
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
		/// Store: SIM_ScanDEDetail_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngScanFileID, int? intOrderIndex)
		{
			this.lngScanFileID = lngScanFileID;
			this.intOrderIndex = intOrderIndex;
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

		public SIM_ScanDEDetail()
		{
		}
		public SIM_ScanDEDetail(long? lngScanFileID, int? intOrderIndex)
		{
			this.lngScanFileID = lngScanFileID;
			this.intOrderIndex = intOrderIndex;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_ScanFileID = "@" + C_ScanFileID;
		public const String P_OrderIndex = "@" + C_OrderIndex;
		public const String P_Value1 = "@" + C_Value1;
		public const String P_Value2 = "@" + C_Value2;
		public const String P_Value3 = "@" + C_Value3;
		public const String P_Value4 = "@" + C_Value4;
		public const String P_Value5 = "@" + C_Value5;
		public const String P_Value6 = "@" + C_Value6;
		public const String P_DoAnswerLabelList = "@" + C_DoAnswerLabelList;
		public const String P_TrueAnswerLabelList = "@" + C_TrueAnswerLabelList;
		public const String P_IsTrueSelected = "@" + C_IsTrueSelected;
		public const String P_Mark = "@" + C_Mark;

		#endregion //Parameter names

		#region Column Names

		public const String C_ScanFileID = "ScanFileID";
		public const String C_OrderIndex = "OrderIndex";
		public const String C_Value1 = "Value1";
		public const String C_Value2 = "Value2";
		public const String C_Value3 = "Value3";
		public const String C_Value4 = "Value4";
		public const String C_Value5 = "Value5";
		public const String C_Value6 = "Value6";
		public const String C_DoAnswerLabelList = "DoAnswerLabelList";
		public const String C_TrueAnswerLabelList = "TrueAnswerLabelList";
		public const String C_IsTrueSelected = "IsTrueSelected";
		public const String C_Mark = "Mark";

		#endregion //Column names

		#endregion Variable Static		
	}
}
