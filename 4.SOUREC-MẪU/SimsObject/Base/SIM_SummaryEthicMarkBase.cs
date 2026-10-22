
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
	public partial class SIM_SummaryEthicMark
	{	
		#region Member Variables

		private long? lngStudentID = null;//Mã sinh viên
		private int? intYearID = null;//Mã niên học
		private double? dblStudentEthicMark = null;//Điển rèn luyện cả năm của sinh viên
		private string strStudentEthicLevel = null;//Xếp loại rèn luyện sinh viên
		private double? dblStudentEthicMark1 = null;//Điển rèn luyện cả năm của sinh viên
		private string strStudentEthicLevel1 = null;//Xếp loại rèn luyện sinh viên
		private double? dblStudentEthicMark2 = null;//Điển rèn luyện cả năm của sinh viên
		private string strStudentEthicLevel2 = null;//Xếp loại rèn luyện sinh viên
		private double? dblTeacherEthicMark = null;//Điển rèn luyện GV
		private string strTeacherEthicLevel = null;//Xếp loại rèn luyện GV đánh giá
		private double? dblTeacherEthicMark1 = null;//Điển rèn luyện GV
		private string strTeacherEthicLevel1 = null;//Xếp loại rèn luyện GV đánh giá
		private double? dblTeacherEthicMark2 = null;//Điển rèn luyện GV
		private string strTeacherEthicLevel2 = null;//Xếp loại rèn luyện GV đánh giá
		private double? dblClassEthicMark = null;//Điển rèn luyện cả năm của lớp
		private string strClassEthicLevel = null;//Xếp loại rèn luyện cả năm
		private double? dblClassEthicMark1 = null;//Điểm rèn luyện hk 1
		private string strClassEthicLevel1 = null;//Xếp loại rèn luyện hk 1
		private double? dblClassEthicMark2 = null;//Điểm rèn luyện hk 2
		private string strClassEthicLevel2 = null;//Xếp loại rèn luyện hk 1
		private double? dblEthicMark = null;//Điển rèn luyện cả năm của hội đồng
		private string strEthicLevel = null;//Xếp loại rèn luyện cả năm
		private double? dblEthicMark1 = null;//Điểm rèn luyện hk 1
		private string strEthicLevel1 = null;//Xếp loại rèn luyện hk 1
		private double? dblEthicMark2 = null;//Điểm rèn luyện hk 2
		private string strEthicLevel2 = null;//Xếp loại rèn luyện hk 1
		private DateTime? dtmCreatedDate = null;//Ngày tạo
		private string strCreatedUser = null;//Người tạo
		private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
		private string strUpdatedUser = null;//Người cập nhật cuối
		private string strTeacherComment1 = null;//GV chủ nhiệm nhận xét đánh giá HK 1
		private string strTeacherComment2 = null;//GV chủ nhiệm nhận xét đánh giá HK 2
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
		/// YearID
		/// Mã niên học
		/// </summary>
		public int? YearID
		{
			get { return  intYearID; }
			set { intYearID = value; }
		}
		/// <summary>
		/// StudentEthicMark
		/// Điển rèn luyện cả năm của sinh viên
		/// </summary>
		public double? StudentEthicMark
		{
			get { return  dblStudentEthicMark; }
			set { dblStudentEthicMark = value; }
		}
		/// <summary>
		/// StudentEthicLevel
		/// Xếp loại rèn luyện sinh viên
		/// </summary>
		public string StudentEthicLevel
		{
			get { return  strStudentEthicLevel; }
			set { strStudentEthicLevel = value; }
		}
		/// <summary>
		/// StudentEthicMark1
		/// Điển rèn luyện cả năm của sinh viên
		/// </summary>
		public double? StudentEthicMark1
		{
			get { return  dblStudentEthicMark1; }
			set { dblStudentEthicMark1 = value; }
		}
		/// <summary>
		/// StudentEthicLevel1
		/// Xếp loại rèn luyện sinh viên
		/// </summary>
		public string StudentEthicLevel1
		{
			get { return  strStudentEthicLevel1; }
			set { strStudentEthicLevel1 = value; }
		}
		/// <summary>
		/// StudentEthicMark2
		/// Điển rèn luyện cả năm của sinh viên
		/// </summary>
		public double? StudentEthicMark2
		{
			get { return  dblStudentEthicMark2; }
			set { dblStudentEthicMark2 = value; }
		}
		/// <summary>
		/// StudentEthicLevel2
		/// Xếp loại rèn luyện sinh viên
		/// </summary>
		public string StudentEthicLevel2
		{
			get { return  strStudentEthicLevel2; }
			set { strStudentEthicLevel2 = value; }
		}
		/// <summary>
		/// TeacherEthicMark
		/// Điển rèn luyện GV
		/// </summary>
		public double? TeacherEthicMark
		{
			get { return  dblTeacherEthicMark; }
			set { dblTeacherEthicMark = value; }
		}
		/// <summary>
		/// TeacherEthicLevel
		/// Xếp loại rèn luyện GV đánh giá
		/// </summary>
		public string TeacherEthicLevel
		{
			get { return  strTeacherEthicLevel; }
			set { strTeacherEthicLevel = value; }
		}
		/// <summary>
		/// TeacherEthicMark1
		/// Điển rèn luyện GV
		/// </summary>
		public double? TeacherEthicMark1
		{
			get { return  dblTeacherEthicMark1; }
			set { dblTeacherEthicMark1 = value; }
		}
		/// <summary>
		/// TeacherEthicLevel1
		/// Xếp loại rèn luyện GV đánh giá
		/// </summary>
		public string TeacherEthicLevel1
		{
			get { return  strTeacherEthicLevel1; }
			set { strTeacherEthicLevel1 = value; }
		}
		/// <summary>
		/// TeacherEthicMark2
		/// Điển rèn luyện GV
		/// </summary>
		public double? TeacherEthicMark2
		{
			get { return  dblTeacherEthicMark2; }
			set { dblTeacherEthicMark2 = value; }
		}
		/// <summary>
		/// TeacherEthicLevel2
		/// Xếp loại rèn luyện GV đánh giá
		/// </summary>
		public string TeacherEthicLevel2
		{
			get { return  strTeacherEthicLevel2; }
			set { strTeacherEthicLevel2 = value; }
		}
		/// <summary>
		/// ClassEthicMark
		/// Điển rèn luyện cả năm của lớp
		/// </summary>
		public double? ClassEthicMark
		{
			get { return  dblClassEthicMark; }
			set { dblClassEthicMark = value; }
		}
		/// <summary>
		/// ClassEthicLevel
		/// Xếp loại rèn luyện cả năm
		/// </summary>
		public string ClassEthicLevel
		{
			get { return  strClassEthicLevel; }
			set { strClassEthicLevel = value; }
		}
		/// <summary>
		/// ClassEthicMark1
		/// Điểm rèn luyện hk 1
		/// </summary>
		public double? ClassEthicMark1
		{
			get { return  dblClassEthicMark1; }
			set { dblClassEthicMark1 = value; }
		}
		/// <summary>
		/// ClassEthicLevel1
		/// Xếp loại rèn luyện hk 1
		/// </summary>
		public string ClassEthicLevel1
		{
			get { return  strClassEthicLevel1; }
			set { strClassEthicLevel1 = value; }
		}
		/// <summary>
		/// ClassEthicMark2
		/// Điểm rèn luyện hk 2
		/// </summary>
		public double? ClassEthicMark2
		{
			get { return  dblClassEthicMark2; }
			set { dblClassEthicMark2 = value; }
		}
		/// <summary>
		/// ClassEthicLevel2
		/// Xếp loại rèn luyện hk 1
		/// </summary>
		public string ClassEthicLevel2
		{
			get { return  strClassEthicLevel2; }
			set { strClassEthicLevel2 = value; }
		}
		/// <summary>
		/// EthicMark
		/// Điển rèn luyện cả năm của hội đồng
		/// </summary>
		public double? EthicMark
		{
			get { return  dblEthicMark; }
			set { dblEthicMark = value; }
		}
		/// <summary>
		/// EthicLevel
		/// Xếp loại rèn luyện cả năm
		/// </summary>
		public string EthicLevel
		{
			get { return  strEthicLevel; }
			set { strEthicLevel = value; }
		}
		/// <summary>
		/// EthicMark1
		/// Điểm rèn luyện hk 1
		/// </summary>
		public double? EthicMark1
		{
			get { return  dblEthicMark1; }
			set { dblEthicMark1 = value; }
		}
		/// <summary>
		/// EthicLevel1
		/// Xếp loại rèn luyện hk 1
		/// </summary>
		public string EthicLevel1
		{
			get { return  strEthicLevel1; }
			set { strEthicLevel1 = value; }
		}
		/// <summary>
		/// EthicMark2
		/// Điểm rèn luyện hk 2
		/// </summary>
		public double? EthicMark2
		{
			get { return  dblEthicMark2; }
			set { dblEthicMark2 = value; }
		}
		/// <summary>
		/// EthicLevel2
		/// Xếp loại rèn luyện hk 1
		/// </summary>
		public string EthicLevel2
		{
			get { return  strEthicLevel2; }
			set { strEthicLevel2 = value; }
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
		/// TeacherComment1
		/// GV chủ nhiệm nhận xét đánh giá HK 1
		/// </summary>
		public string TeacherComment1
		{
			get { return  strTeacherComment1; }
			set { strTeacherComment1 = value; }
		}
		/// <summary>
		/// TeacherComment2
		/// GV chủ nhiệm nhận xét đánh giá HK 2
		/// </summary>
		public string TeacherComment2
		{
			get { return  strTeacherComment2; }
			set { strTeacherComment2 = value; }
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
					if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicMark])) this.dblStudentEthicMark = Convert.ToDouble(reader[C_StudentEthicMark]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicLevel])) this.strStudentEthicLevel = Convert.ToString(reader[C_StudentEthicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentEthicMark1.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicMark1])) this.dblStudentEthicMark1 = Convert.ToDouble(reader[C_StudentEthicMark1]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentEthicLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicLevel1])) this.strStudentEthicLevel1 = Convert.ToString(reader[C_StudentEthicLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentEthicMark2.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicMark2])) this.dblStudentEthicMark2 = Convert.ToDouble(reader[C_StudentEthicMark2]);
					if (reader.GetName(i).ToUpper().Equals(C_StudentEthicLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_StudentEthicLevel2])) this.strStudentEthicLevel2 = Convert.ToString(reader[C_StudentEthicLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicMark])) this.dblTeacherEthicMark = Convert.ToDouble(reader[C_TeacherEthicMark]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicLevel])) this.strTeacherEthicLevel = Convert.ToString(reader[C_TeacherEthicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicMark1.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicMark1])) this.dblTeacherEthicMark1 = Convert.ToDouble(reader[C_TeacherEthicMark1]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicLevel1])) this.strTeacherEthicLevel1 = Convert.ToString(reader[C_TeacherEthicLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicMark2.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicMark2])) this.dblTeacherEthicMark2 = Convert.ToDouble(reader[C_TeacherEthicMark2]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherEthicLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherEthicLevel2])) this.strTeacherEthicLevel2 = Convert.ToString(reader[C_TeacherEthicLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassEthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicMark])) this.dblClassEthicMark = Convert.ToDouble(reader[C_ClassEthicMark]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassEthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicLevel])) this.strClassEthicLevel = Convert.ToString(reader[C_ClassEthicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassEthicMark1.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicMark1])) this.dblClassEthicMark1 = Convert.ToDouble(reader[C_ClassEthicMark1]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassEthicLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicLevel1])) this.strClassEthicLevel1 = Convert.ToString(reader[C_ClassEthicLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassEthicMark2.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicMark2])) this.dblClassEthicMark2 = Convert.ToDouble(reader[C_ClassEthicMark2]);
					if (reader.GetName(i).ToUpper().Equals(C_ClassEthicLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_ClassEthicLevel2])) this.strClassEthicLevel2 = Convert.ToString(reader[C_ClassEthicLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicMark.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark])) this.dblEthicMark = Convert.ToDouble(reader[C_EthicMark]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel])) this.strEthicLevel = Convert.ToString(reader[C_EthicLevel]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicMark1.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark1])) this.dblEthicMark1 = Convert.ToDouble(reader[C_EthicMark1]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel1.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel1])) this.strEthicLevel1 = Convert.ToString(reader[C_EthicLevel1]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicMark2.ToUpper()) && !Convert.IsDBNull(reader[C_EthicMark2])) this.dblEthicMark2 = Convert.ToDouble(reader[C_EthicMark2]);
					if (reader.GetName(i).ToUpper().Equals(C_EthicLevel2.ToUpper()) && !Convert.IsDBNull(reader[C_EthicLevel2])) this.strEthicLevel2 = Convert.ToString(reader[C_EthicLevel2]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
					if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherComment1.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherComment1])) this.strTeacherComment1 = Convert.ToString(reader[C_TeacherComment1]);
					if (reader.GetName(i).ToUpper().Equals(C_TeacherComment2.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherComment2])) this.strTeacherComment2 = Convert.ToString(reader[C_TeacherComment2]);
 				}
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SummaryEthicMark", objEx);
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
				if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
				if (!Convert.IsDBNull(drw[C_StudentEthicMark])) this.dblStudentEthicMark = Convert.ToDouble(drw[C_StudentEthicMark]);
				if (!Convert.IsDBNull(drw[C_StudentEthicLevel])) this.strStudentEthicLevel = Convert.ToString(drw[C_StudentEthicLevel]);
				if (!Convert.IsDBNull(drw[C_StudentEthicMark1])) this.dblStudentEthicMark1 = Convert.ToDouble(drw[C_StudentEthicMark1]);
				if (!Convert.IsDBNull(drw[C_StudentEthicLevel1])) this.strStudentEthicLevel1 = Convert.ToString(drw[C_StudentEthicLevel1]);
				if (!Convert.IsDBNull(drw[C_StudentEthicMark2])) this.dblStudentEthicMark2 = Convert.ToDouble(drw[C_StudentEthicMark2]);
				if (!Convert.IsDBNull(drw[C_StudentEthicLevel2])) this.strStudentEthicLevel2 = Convert.ToString(drw[C_StudentEthicLevel2]);
				if (!Convert.IsDBNull(drw[C_TeacherEthicMark])) this.dblTeacherEthicMark = Convert.ToDouble(drw[C_TeacherEthicMark]);
				if (!Convert.IsDBNull(drw[C_TeacherEthicLevel])) this.strTeacherEthicLevel = Convert.ToString(drw[C_TeacherEthicLevel]);
				if (!Convert.IsDBNull(drw[C_TeacherEthicMark1])) this.dblTeacherEthicMark1 = Convert.ToDouble(drw[C_TeacherEthicMark1]);
				if (!Convert.IsDBNull(drw[C_TeacherEthicLevel1])) this.strTeacherEthicLevel1 = Convert.ToString(drw[C_TeacherEthicLevel1]);
				if (!Convert.IsDBNull(drw[C_TeacherEthicMark2])) this.dblTeacherEthicMark2 = Convert.ToDouble(drw[C_TeacherEthicMark2]);
				if (!Convert.IsDBNull(drw[C_TeacherEthicLevel2])) this.strTeacherEthicLevel2 = Convert.ToString(drw[C_TeacherEthicLevel2]);
				if (!Convert.IsDBNull(drw[C_ClassEthicMark])) this.dblClassEthicMark = Convert.ToDouble(drw[C_ClassEthicMark]);
				if (!Convert.IsDBNull(drw[C_ClassEthicLevel])) this.strClassEthicLevel = Convert.ToString(drw[C_ClassEthicLevel]);
				if (!Convert.IsDBNull(drw[C_ClassEthicMark1])) this.dblClassEthicMark1 = Convert.ToDouble(drw[C_ClassEthicMark1]);
				if (!Convert.IsDBNull(drw[C_ClassEthicLevel1])) this.strClassEthicLevel1 = Convert.ToString(drw[C_ClassEthicLevel1]);
				if (!Convert.IsDBNull(drw[C_ClassEthicMark2])) this.dblClassEthicMark2 = Convert.ToDouble(drw[C_ClassEthicMark2]);
				if (!Convert.IsDBNull(drw[C_ClassEthicLevel2])) this.strClassEthicLevel2 = Convert.ToString(drw[C_ClassEthicLevel2]);
				if (!Convert.IsDBNull(drw[C_EthicMark])) this.dblEthicMark = Convert.ToDouble(drw[C_EthicMark]);
				if (!Convert.IsDBNull(drw[C_EthicLevel])) this.strEthicLevel = Convert.ToString(drw[C_EthicLevel]);
				if (!Convert.IsDBNull(drw[C_EthicMark1])) this.dblEthicMark1 = Convert.ToDouble(drw[C_EthicMark1]);
				if (!Convert.IsDBNull(drw[C_EthicLevel1])) this.strEthicLevel1 = Convert.ToString(drw[C_EthicLevel1]);
				if (!Convert.IsDBNull(drw[C_EthicMark2])) this.dblEthicMark2 = Convert.ToDouble(drw[C_EthicMark2]);
				if (!Convert.IsDBNull(drw[C_EthicLevel2])) this.strEthicLevel2 = Convert.ToString(drw[C_EthicLevel2]);
				if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
				if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
				if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
				if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
				if (!Convert.IsDBNull(drw[C_TeacherComment1])) this.strTeacherComment1 = Convert.ToString(drw[C_TeacherComment1]);
				if (!Convert.IsDBNull(drw[C_TeacherComment2])) this.strTeacherComment2 = Convert.ToString(drw[C_TeacherComment2]);
				return true;
			}
			catch (Exception objEx)
			{
				new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SummaryEthicMark", objEx);
				this.objErrorException = objEx;
				return false;
			}
		}

		///<summary>
		/// Nạp thông tin item 
		/// Store: SIM_SummaryEthicMark_GET 
		///</summary>
		/// <returns>true ? Có : False ? Không</returns>
		public bool Get()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_GET");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SummaryEthicMark", objEx);
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
		/// Store: SIM_SummaryEthicMark_GET 
		///</summary>
		/// <returns> SIM_SummaryEthicMark </returns>
		public SIM_SummaryEthicMark Get(long? lngStudentID, int? intYearID)
		{
			SIM_SummaryEthicMark obj = new SIM_SummaryEthicMark();
			if (objIData != null) 
 				obj.IDB = objIData;
			obj.StudentID = lngStudentID;
			obj.YearID = intYearID;
 			if (obj.Get()) 
				return obj;
			this.objErrorException = obj.ErrorException;
			return null;
		}
		///<summary>
		/// ExecNonQuery : SIM_SummaryEthicMark
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SummaryEthicMark", objEx);
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
		/// Search : SIM_SummaryEthicMark
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
				new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SummaryEthicMark", objEx);
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
		/// Search : SIM_SummaryEthicMark
		/// Lấy hết dữ liệu
		/// Store: SIM_SummaryEthicMark_GETALL 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable GetAll()
		{
			return GetDataTable("SIM_SummaryEthicMark_GETALL");
		}

		///<summary>
		/// Search : SIM_SummaryEthicMark
		/// Tìm dữ liệu
		/// Store: SIM_SummaryEthicMark_SEARCH 
		/// <returns> DataTable </returns>
		///</summary>
		public DataTable Search(params object[] pars)
		{
			return GetDataTable("SIM_SummaryEthicMark_SEARCH",pars);
		}

		///<summary>
		/// Add : SIM_SummaryEthicMark
		/// Thêm dữ liệu
		/// Store: SIM_SummaryEthicMark_ADD 
		///</summary>
		public bool Add()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_ADD");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_StudentEthicMark, this.dblStudentEthicMark);
				objIData.AddParameter(P_StudentEthicLevel, this.strStudentEthicLevel);
				objIData.AddParameter(P_StudentEthicMark1, this.dblStudentEthicMark1);
				objIData.AddParameter(P_StudentEthicLevel1, this.strStudentEthicLevel1);
				objIData.AddParameter(P_StudentEthicMark2, this.dblStudentEthicMark2);
				objIData.AddParameter(P_StudentEthicLevel2, this.strStudentEthicLevel2);
				objIData.AddParameter(P_TeacherEthicMark, this.dblTeacherEthicMark);
				objIData.AddParameter(P_TeacherEthicLevel, this.strTeacherEthicLevel);
				objIData.AddParameter(P_TeacherEthicMark1, this.dblTeacherEthicMark1);
				objIData.AddParameter(P_TeacherEthicLevel1, this.strTeacherEthicLevel1);
				objIData.AddParameter(P_TeacherEthicMark2, this.dblTeacherEthicMark2);
				objIData.AddParameter(P_TeacherEthicLevel2, this.strTeacherEthicLevel2);
				objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
				objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
				objIData.AddParameter(P_ClassEthicMark1, this.dblClassEthicMark1);
				objIData.AddParameter(P_ClassEthicLevel1, this.strClassEthicLevel1);
				objIData.AddParameter(P_ClassEthicMark2, this.dblClassEthicMark2);
				objIData.AddParameter(P_ClassEthicLevel2, this.strClassEthicLevel2);
				objIData.AddParameter(P_EthicMark, this.dblEthicMark);
				objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
				objIData.AddParameter(P_EthicMark1, this.dblEthicMark1);
				objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
				objIData.AddParameter(P_EthicMark2, this.dblEthicMark2);
				objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
				objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
				objIData.AddParameter(P_TeacherComment1, this.strTeacherComment1);
				objIData.AddParameter(P_TeacherComment2, this.strTeacherComment2);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SummaryEthicMark", objEx);
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
		/// Update : SIM_SummaryEthicMark
		/// Cập nhật dữ liệu
		/// Store: SIM_SummaryEthicMark_EDIT 
		///</summary>
		public bool Update()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_EDIT");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
				objIData.AddParameter(P_StudentEthicMark, this.dblStudentEthicMark);
				objIData.AddParameter(P_StudentEthicLevel, this.strStudentEthicLevel);
				objIData.AddParameter(P_StudentEthicMark1, this.dblStudentEthicMark1);
				objIData.AddParameter(P_StudentEthicLevel1, this.strStudentEthicLevel1);
				objIData.AddParameter(P_StudentEthicMark2, this.dblStudentEthicMark2);
				objIData.AddParameter(P_StudentEthicLevel2, this.strStudentEthicLevel2);
				objIData.AddParameter(P_TeacherEthicMark, this.dblTeacherEthicMark);
				objIData.AddParameter(P_TeacherEthicLevel, this.strTeacherEthicLevel);
				objIData.AddParameter(P_TeacherEthicMark1, this.dblTeacherEthicMark1);
				objIData.AddParameter(P_TeacherEthicLevel1, this.strTeacherEthicLevel1);
				objIData.AddParameter(P_TeacherEthicMark2, this.dblTeacherEthicMark2);
				objIData.AddParameter(P_TeacherEthicLevel2, this.strTeacherEthicLevel2);
				objIData.AddParameter(P_ClassEthicMark, this.dblClassEthicMark);
				objIData.AddParameter(P_ClassEthicLevel, this.strClassEthicLevel);
				objIData.AddParameter(P_ClassEthicMark1, this.dblClassEthicMark1);
				objIData.AddParameter(P_ClassEthicLevel1, this.strClassEthicLevel1);
				objIData.AddParameter(P_ClassEthicMark2, this.dblClassEthicMark2);
				objIData.AddParameter(P_ClassEthicLevel2, this.strClassEthicLevel2);
				objIData.AddParameter(P_EthicMark, this.dblEthicMark);
				objIData.AddParameter(P_EthicLevel, this.strEthicLevel);
				objIData.AddParameter(P_EthicMark1, this.dblEthicMark1);
				objIData.AddParameter(P_EthicLevel1, this.strEthicLevel1);
				objIData.AddParameter(P_EthicMark2, this.dblEthicMark2);
				objIData.AddParameter(P_EthicLevel2, this.strEthicLevel2);
				objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
				objIData.AddParameter(P_TeacherComment1, this.strTeacherComment1);
				objIData.AddParameter(P_TeacherComment2, this.strTeacherComment2);
				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SummaryEthicMark", objEx);
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
		/// Delete : SIM_SummaryEthicMark
		/// Xóa dữ liệu
		/// Store: SIM_SummaryEthicMark_DELETE 
		///</summary>
		public bool Delete()
		{
			if (!bolIsExistIData)
				objIData = DCore.Data.CreateData();
			try 
			{
				objIData.CreateNewStoredProcedure("SIM_SummaryEthicMark_DELETE");
				objIData.AddParameter(P_StudentID, this.lngStudentID);
				objIData.AddParameter(P_YearID, this.intYearID);
 				objIData.ExecNonQuery();
    			return true;
			}
			catch (Exception objEx)
			{
				if (bolIsExistIData)
					this.RollBackTransaction();
				new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SummaryEthicMark", objEx);
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
		/// Store: SIM_SummaryEthicMark_DELETE 
		///</summary>
		/// <returns> true: thanh cong, false: that bai </returns>
		public bool Delete(long? lngStudentID, int? intYearID)
		{
			this.lngStudentID = lngStudentID;
			this.intYearID = intYearID;
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

		public SIM_SummaryEthicMark()
		{
		}
		public SIM_SummaryEthicMark(long? lngStudentID, int? intYearID)
		{
			this.lngStudentID = lngStudentID;
			this.intYearID = intYearID;
			this.Get();
		}

		#endregion

		#region Variable Static

		#region Parameter Names

		public const String P_StudentID = "@" + C_StudentID;
		public const String P_YearID = "@" + C_YearID;
		public const String P_StudentEthicMark = "@" + C_StudentEthicMark;
		public const String P_StudentEthicLevel = "@" + C_StudentEthicLevel;
		public const String P_StudentEthicMark1 = "@" + C_StudentEthicMark1;
		public const String P_StudentEthicLevel1 = "@" + C_StudentEthicLevel1;
		public const String P_StudentEthicMark2 = "@" + C_StudentEthicMark2;
		public const String P_StudentEthicLevel2 = "@" + C_StudentEthicLevel2;
		public const String P_TeacherEthicMark = "@" + C_TeacherEthicMark;
		public const String P_TeacherEthicLevel = "@" + C_TeacherEthicLevel;
		public const String P_TeacherEthicMark1 = "@" + C_TeacherEthicMark1;
		public const String P_TeacherEthicLevel1 = "@" + C_TeacherEthicLevel1;
		public const String P_TeacherEthicMark2 = "@" + C_TeacherEthicMark2;
		public const String P_TeacherEthicLevel2 = "@" + C_TeacherEthicLevel2;
		public const String P_ClassEthicMark = "@" + C_ClassEthicMark;
		public const String P_ClassEthicLevel = "@" + C_ClassEthicLevel;
		public const String P_ClassEthicMark1 = "@" + C_ClassEthicMark1;
		public const String P_ClassEthicLevel1 = "@" + C_ClassEthicLevel1;
		public const String P_ClassEthicMark2 = "@" + C_ClassEthicMark2;
		public const String P_ClassEthicLevel2 = "@" + C_ClassEthicLevel2;
		public const String P_EthicMark = "@" + C_EthicMark;
		public const String P_EthicLevel = "@" + C_EthicLevel;
		public const String P_EthicMark1 = "@" + C_EthicMark1;
		public const String P_EthicLevel1 = "@" + C_EthicLevel1;
		public const String P_EthicMark2 = "@" + C_EthicMark2;
		public const String P_EthicLevel2 = "@" + C_EthicLevel2;
		public const String P_CreatedDate = "@" + C_CreatedDate;
		public const String P_CreatedUser = "@" + C_CreatedUser;
		public const String P_UpdatedDate = "@" + C_UpdatedDate;
		public const String P_UpdatedUser = "@" + C_UpdatedUser;
		public const String P_TeacherComment1 = "@" + C_TeacherComment1;
		public const String P_TeacherComment2 = "@" + C_TeacherComment2;

		#endregion //Parameter names

		#region Column Names

		public const String C_StudentID = "StudentID";
		public const String C_YearID = "YearID";
		public const String C_StudentEthicMark = "StudentEthicMark";
		public const String C_StudentEthicLevel = "StudentEthicLevel";
		public const String C_StudentEthicMark1 = "StudentEthicMark1";
		public const String C_StudentEthicLevel1 = "StudentEthicLevel1";
		public const String C_StudentEthicMark2 = "StudentEthicMark2";
		public const String C_StudentEthicLevel2 = "StudentEthicLevel2";
		public const String C_TeacherEthicMark = "TeacherEthicMark";
		public const String C_TeacherEthicLevel = "TeacherEthicLevel";
		public const String C_TeacherEthicMark1 = "TeacherEthicMark1";
		public const String C_TeacherEthicLevel1 = "TeacherEthicLevel1";
		public const String C_TeacherEthicMark2 = "TeacherEthicMark2";
		public const String C_TeacherEthicLevel2 = "TeacherEthicLevel2";
		public const String C_ClassEthicMark = "ClassEthicMark";
		public const String C_ClassEthicLevel = "ClassEthicLevel";
		public const String C_ClassEthicMark1 = "ClassEthicMark1";
		public const String C_ClassEthicLevel1 = "ClassEthicLevel1";
		public const String C_ClassEthicMark2 = "ClassEthicMark2";
		public const String C_ClassEthicLevel2 = "ClassEthicLevel2";
		public const String C_EthicMark = "EthicMark";
		public const String C_EthicLevel = "EthicLevel";
		public const String C_EthicMark1 = "EthicMark1";
		public const String C_EthicLevel1 = "EthicLevel1";
		public const String C_EthicMark2 = "EthicMark2";
		public const String C_EthicLevel2 = "EthicLevel2";
		public const String C_CreatedDate = "CreatedDate";
		public const String C_CreatedUser = "CreatedUser";
		public const String C_UpdatedDate = "UpdatedDate";
		public const String C_UpdatedUser = "UpdatedUser";
		public const String C_TeacherComment1 = "TeacherComment1";
		public const String C_TeacherComment2 = "TeacherComment2";

		#endregion //Column names

		#endregion Variable Static		
	}
}
