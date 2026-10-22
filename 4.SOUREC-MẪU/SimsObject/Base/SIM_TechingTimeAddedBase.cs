
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
    /// Created date 	: 12/07/2011 
    /// Description 
    /// </summary>	
    public partial class SIM_TeachingTimeAdded
    {
        #region Member Variables

        private int? intYearID = null;//Mã niên học
        private int? intSemester = null;
        private string strTeacherID = null;//Mã giảng viên, Nếu = ___ (3 dấu gạch chân)  là dòng giá trị cấu hình cho năm đó, nếu hông có thì tự load năm cũ add vào
        private double? dblSoanDeKT_TL = null;//Hệ số giờ giảng viên
        private double? dblSoanDeKT_TLTN = null;
        private double? dblSoanDeKT_TN = null;
        private double? dblSoanDeKT_VD = null;//Ngày tạo
        private double? dblSoanDeKT_TH = null;//Người sửa
        private double? dblCoiThiKT = null;//Ngày sửa
        private double? dblChamThiKT_TLTN = null;
        private double? dblChamThiKT_VD = null;
        private double? dblChamThiKT_TH = null;
        private double? dblSoanDeTN_TL = null;//Hệ số giờ giảng viên
        private double? dblSoanDeTN_TLTN = null;
        private double? dblSoanDeTN_TN = null;
        private double? dblSoanDeTN_VD = null;//Ngày tạo
        private double? dblSoanDeTN_TH = null;//Người sửa
        private double? dblCoiThiTN = null;//Ngày sửa
        private double? dblChamThiTN_TLTN = null;
        private double? dblChamThiTN_VD = null;
        private double? dblChamThiTN_TH = null;
        private double? dblHuongDanThucTap = null;//Ngày
        private double? dblHuongDanThucTap2 = null;
        private double? dblLuyenThi = null;
        private double? dblSoanGiaoTrinh = null;
        private double? dblKhac = null;
        private double? dblTotal = null;
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
        /// YearID
        /// Mã niên học
        /// </summary>
        public int? YearID
        {
            get { return intYearID; }
            set { intYearID = value; }
        }
        /// <summary>
        /// Semester
        /// 
        /// </summary>
        public int? Semester
        {
            get { return intSemester; }
            set { intSemester = value; }
        }
        /// <summary>
        /// TeacherID
        /// Mã giảng viên, Nếu = ___ (3 dấu gạch chân)  là dòng giá trị cấu hình cho năm đó, nếu hông có thì tự load năm cũ add vào
        /// </summary>
        public string TeacherID
        {
            get { return strTeacherID; }
            set { strTeacherID = value; }
        }
        /// <summary>
        /// SoanDeKT_TL
        /// Hệ số giờ giảng viên
        /// </summary>
        public double? SoanDeKT_TL
        {
            get { return dblSoanDeKT_TL; }
            set { dblSoanDeKT_TL = value; }
        }
        /// <summary>
        /// SoanDeKT_TLTN
        /// 
        /// </summary>
        public double? SoanDeKT_TLTN
        {
            get { return dblSoanDeKT_TLTN; }
            set { dblSoanDeKT_TLTN = value; }
        }
        /// <summary>
        /// SoanDeKT_TN
        /// 
        /// </summary>
        public double? SoanDeKT_TN
        {
            get { return dblSoanDeKT_TN; }
            set { dblSoanDeKT_TN = value; }
        }
        /// <summary>
        /// SoanDeKT_VD
        /// Ngày tạo
        /// </summary>
        public double? SoanDeKT_VD
        {
            get { return dblSoanDeKT_VD; }
            set { dblSoanDeKT_VD = value; }
        }
        /// <summary>
        /// SoanDeKT_TH
        /// Người sửa
        /// </summary>
        public double? SoanDeKT_TH
        {
            get { return dblSoanDeKT_TH; }
            set { dblSoanDeKT_TH = value; }
        }
        /// <summary>
        /// CoiThiKT
        /// Ngày sửa
        /// </summary>
        public double? CoiThiKT
        {
            get { return dblCoiThiKT; }
            set { dblCoiThiKT = value; }
        }
        /// <summary>
        /// ChamThiKT_TLTN
        /// 
        /// </summary>
        public double? ChamThiKT_TLTN
        {
            get { return dblChamThiKT_TLTN; }
            set { dblChamThiKT_TLTN = value; }
        }
        /// <summary>
        /// ChamThiKT_VD
        /// 
        /// </summary>
        public double? ChamThiKT_VD
        {
            get { return dblChamThiKT_VD; }
            set { dblChamThiKT_VD = value; }
        }
        /// <summary>
        /// ChamThiKT_TH
        /// 
        /// </summary>
        public double? ChamThiKT_TH
        {
            get { return dblChamThiKT_TH; }
            set { dblChamThiKT_TH = value; }
        }
        /// <summary>
        /// SoanDeTN_TL
        /// Hệ số giờ giảng viên
        /// </summary>
        public double? SoanDeTN_TL
        {
            get { return dblSoanDeTN_TL; }
            set { dblSoanDeTN_TL = value; }
        }
        /// <summary>
        /// SoanDeTN_TLTN
        /// 
        /// </summary>
        public double? SoanDeTN_TLTN
        {
            get { return dblSoanDeTN_TLTN; }
            set { dblSoanDeTN_TLTN = value; }
        }
        /// <summary>
        /// SoanDeTN_TN
        /// 
        /// </summary>
        public double? SoanDeTN_TN
        {
            get { return dblSoanDeTN_TN; }
            set { dblSoanDeTN_TN = value; }
        }
        /// <summary>
        /// SoanDeTN_VD
        /// Ngày tạo
        /// </summary>
        public double? SoanDeTN_VD
        {
            get { return dblSoanDeTN_VD; }
            set { dblSoanDeTN_VD = value; }
        }
        /// <summary>
        /// SoanDeTN_TH
        /// Người sửa
        /// </summary>
        public double? SoanDeTN_TH
        {
            get { return dblSoanDeTN_TH; }
            set { dblSoanDeTN_TH = value; }
        }
        /// <summary>
        /// CoiThiTN
        /// Ngày sửa
        /// </summary>
        public double? CoiThiTN
        {
            get { return dblCoiThiTN; }
            set { dblCoiThiTN = value; }
        }
        /// <summary>
        /// ChamThiTN_TLTN
        /// 
        /// </summary>
        public double? ChamThiTN_TLTN
        {
            get { return dblChamThiTN_TLTN; }
            set { dblChamThiTN_TLTN = value; }
        }
        /// <summary>
        /// ChamThiTN_VD
        /// 
        /// </summary>
        public double? ChamThiTN_VD
        {
            get { return dblChamThiTN_VD; }
            set { dblChamThiTN_VD = value; }
        }
        /// <summary>
        /// ChamThiTN_TH
        /// 
        /// </summary>
        public double? ChamThiTN_TH
        {
            get { return dblChamThiTN_TH; }
            set { dblChamThiTN_TH = value; }
        }
        /// <summary>
        /// HuongDanThucTap
        /// Ngày
        /// </summary>
        public double? HuongDanThucTap
        {
            get { return dblHuongDanThucTap; }
            set { dblHuongDanThucTap = value; }
        }
        /// <summary>
        /// HuongDanThucTap2
        /// 
        /// </summary>
        public double? HuongDanThucTap2
        {
            get { return dblHuongDanThucTap2; }
            set { dblHuongDanThucTap2 = value; }
        }
        /// <summary>
        /// LuyenThi
        /// 
        /// </summary>
        public double? LuyenThi
        {
            get { return dblLuyenThi; }
            set { dblLuyenThi = value; }
        }
        /// <summary>
        /// SoanGiaoTrinh
        /// 
        /// </summary>
        public double? SoanGiaoTrinh
        {
            get { return dblSoanGiaoTrinh; }
            set { dblSoanGiaoTrinh = value; }
        }
        /// <summary>
        /// Khac
        /// 
        /// </summary>
        public double? Khac
        {
            get { return dblKhac; }
            set { dblKhac = value; }
        }
        /// <summary>
        /// Total
        /// 
        /// </summary>
        public double? Total
        {
            get { return dblTotal; }
            set { dblTotal = value; }
        }
        /// <summary>
        /// CreatedUser
        /// 
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
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
        /// UpdatedUser
        /// Người sửa
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
            set { strUpdatedUser = value; }
        }
        /// <summary>
        /// UpdatedDate
        /// Ngày sửa
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
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Semester.ToUpper()) && !Convert.IsDBNull(reader[C_Semester])) this.intSemester = Convert.ToInt32(reader[C_Semester]);
                    if (reader.GetName(i).ToUpper().Equals(C_TeacherID.ToUpper()) && !Convert.IsDBNull(reader[C_TeacherID])) this.strTeacherID = Convert.ToString(reader[C_TeacherID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeKT_TL.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeKT_TL])) this.dblSoanDeKT_TL = (double)reader[C_SoanDeKT_TL];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeKT_TLTN.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeKT_TLTN])) this.dblSoanDeKT_TLTN = (double)reader[C_SoanDeKT_TLTN];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeKT_TN.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeKT_TN])) this.dblSoanDeKT_TN = (double)reader[C_SoanDeKT_TN];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeKT_VD.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeKT_VD])) this.dblSoanDeKT_VD = (double)reader[C_SoanDeKT_VD];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeKT_TH.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeKT_TH])) this.dblSoanDeKT_TH = (double)reader[C_SoanDeKT_TH];
                    if (reader.GetName(i).ToUpper().Equals(C_CoiThiKT.ToUpper()) && !Convert.IsDBNull(reader[C_CoiThiKT])) this.dblCoiThiKT = (double)reader[C_CoiThiKT];
                    if (reader.GetName(i).ToUpper().Equals(C_ChamThiKT_TLTN.ToUpper()) && !Convert.IsDBNull(reader[C_ChamThiKT_TLTN])) this.dblChamThiKT_TLTN = (double)reader[C_ChamThiKT_TLTN];
                    if (reader.GetName(i).ToUpper().Equals(C_ChamThiKT_VD.ToUpper()) && !Convert.IsDBNull(reader[C_ChamThiKT_VD])) this.dblChamThiKT_VD = (double)reader[C_ChamThiKT_VD];
                    if (reader.GetName(i).ToUpper().Equals(C_ChamThiKT_TH.ToUpper()) && !Convert.IsDBNull(reader[C_ChamThiKT_TH])) this.dblChamThiKT_TH = (double)reader[C_ChamThiKT_TH];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeTN_TL.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeTN_TL])) this.dblSoanDeTN_TL = (double)reader[C_SoanDeTN_TL];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeTN_TLTN.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeTN_TLTN])) this.dblSoanDeTN_TLTN = (double)reader[C_SoanDeTN_TLTN];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeTN_TN.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeTN_TN])) this.dblSoanDeTN_TN = (double)reader[C_SoanDeTN_TN];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeTN_VD.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeTN_VD])) this.dblSoanDeTN_VD = (double)reader[C_SoanDeTN_VD];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanDeTN_TH.ToUpper()) && !Convert.IsDBNull(reader[C_SoanDeTN_TH])) this.dblSoanDeTN_TH = (double)reader[C_SoanDeTN_TH];
                    if (reader.GetName(i).ToUpper().Equals(C_CoiThiTN.ToUpper()) && !Convert.IsDBNull(reader[C_CoiThiTN])) this.dblCoiThiTN = (double)reader[C_CoiThiTN];
                    if (reader.GetName(i).ToUpper().Equals(C_ChamThiTN_TLTN.ToUpper()) && !Convert.IsDBNull(reader[C_ChamThiTN_TLTN])) this.dblChamThiTN_TLTN = (double)reader[C_ChamThiTN_TLTN];
                    if (reader.GetName(i).ToUpper().Equals(C_ChamThiTN_VD.ToUpper()) && !Convert.IsDBNull(reader[C_ChamThiTN_VD])) this.dblChamThiTN_VD = (double)reader[C_ChamThiTN_VD];
                    if (reader.GetName(i).ToUpper().Equals(C_ChamThiTN_TH.ToUpper()) && !Convert.IsDBNull(reader[C_ChamThiTN_TH])) this.dblChamThiTN_TH = (double)reader[C_ChamThiTN_TH];
                    if (reader.GetName(i).ToUpper().Equals(C_HuongDanThucTap.ToUpper()) && !Convert.IsDBNull(reader[C_HuongDanThucTap])) this.dblHuongDanThucTap = (double)reader[C_HuongDanThucTap];
                    if (reader.GetName(i).ToUpper().Equals(C_HuongDanThucTap2.ToUpper()) && !Convert.IsDBNull(reader[C_HuongDanThucTap2])) this.dblHuongDanThucTap2 = (double)reader[C_HuongDanThucTap2];
                    if (reader.GetName(i).ToUpper().Equals(C_LuyenThi.ToUpper()) && !Convert.IsDBNull(reader[C_LuyenThi])) this.dblLuyenThi = (double)reader[C_LuyenThi];
                    if (reader.GetName(i).ToUpper().Equals(C_SoanGiaoTrinh.ToUpper()) && !Convert.IsDBNull(reader[C_SoanGiaoTrinh])) this.dblSoanGiaoTrinh = (double)reader[C_SoanGiaoTrinh];
                    if (reader.GetName(i).ToUpper().Equals(C_Khac.ToUpper()) && !Convert.IsDBNull(reader[C_Khac])) this.dblKhac = (double)reader[C_Khac];
                    if (reader.GetName(i).ToUpper().Equals(C_Total.ToUpper()) && !Convert.IsDBNull(reader[C_Total])) this.dblTotal = (double)reader[C_Total];
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
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_Semester])) this.intSemester = Convert.ToInt32(drw[C_Semester]);
                if (!Convert.IsDBNull(drw[C_TeacherID])) this.strTeacherID = Convert.ToString(drw[C_TeacherID]);
                if (!Convert.IsDBNull(drw[C_SoanDeKT_TL])) this.dblSoanDeKT_TL = (double)drw[C_SoanDeKT_TL];
                if (!Convert.IsDBNull(drw[C_SoanDeKT_TLTN])) this.dblSoanDeKT_TLTN = (double)drw[C_SoanDeKT_TLTN];
                if (!Convert.IsDBNull(drw[C_SoanDeKT_TN])) this.dblSoanDeKT_TN = (double)drw[C_SoanDeKT_TN];
                if (!Convert.IsDBNull(drw[C_SoanDeKT_VD])) this.dblSoanDeKT_VD = (double)drw[C_SoanDeKT_VD];
                if (!Convert.IsDBNull(drw[C_SoanDeKT_TH])) this.dblSoanDeKT_TH = (double)drw[C_SoanDeKT_TH];
                if (!Convert.IsDBNull(drw[C_CoiThiKT])) this.dblCoiThiKT = (double)drw[C_CoiThiKT];
                if (!Convert.IsDBNull(drw[C_ChamThiKT_TLTN])) this.dblChamThiKT_TLTN = (double)drw[C_ChamThiKT_TLTN];
                if (!Convert.IsDBNull(drw[C_ChamThiKT_VD])) this.dblChamThiKT_VD = (double)drw[C_ChamThiKT_VD];
                if (!Convert.IsDBNull(drw[C_ChamThiKT_TH])) this.dblChamThiKT_TH = (double)drw[C_ChamThiKT_TH];
                if (!Convert.IsDBNull(drw[C_SoanDeTN_TL])) this.dblSoanDeTN_TL = (double)drw[C_SoanDeTN_TL];
                if (!Convert.IsDBNull(drw[C_SoanDeTN_TLTN])) this.dblSoanDeTN_TLTN = (double)drw[C_SoanDeTN_TLTN];
                if (!Convert.IsDBNull(drw[C_SoanDeTN_TN])) this.dblSoanDeTN_TN = (double)drw[C_SoanDeTN_TN];
                if (!Convert.IsDBNull(drw[C_SoanDeTN_VD])) this.dblSoanDeTN_VD = (double)drw[C_SoanDeTN_VD];
                if (!Convert.IsDBNull(drw[C_SoanDeTN_TH])) this.dblSoanDeTN_TH = (double)drw[C_SoanDeTN_TH];
                if (!Convert.IsDBNull(drw[C_CoiThiTN])) this.dblCoiThiTN = (double)drw[C_CoiThiTN];
                if (!Convert.IsDBNull(drw[C_ChamThiTN_TLTN])) this.dblChamThiTN_TLTN = (double)drw[C_ChamThiTN_TLTN];
                if (!Convert.IsDBNull(drw[C_ChamThiTN_VD])) this.dblChamThiTN_VD = (double)drw[C_ChamThiTN_VD];
                if (!Convert.IsDBNull(drw[C_ChamThiTN_TH])) this.dblChamThiTN_TH = (double)drw[C_ChamThiTN_TH];
                if (!Convert.IsDBNull(drw[C_HuongDanThucTap])) this.dblHuongDanThucTap = (double)drw[C_HuongDanThucTap];
                if (!Convert.IsDBNull(drw[C_HuongDanThucTap2])) this.dblHuongDanThucTap2 = (double)drw[C_HuongDanThucTap2];
                if (!Convert.IsDBNull(drw[C_LuyenThi])) this.dblLuyenThi = (double)drw[C_LuyenThi];
                if (!Convert.IsDBNull(drw[C_SoanGiaoTrinh])) this.dblSoanGiaoTrinh = (double)drw[C_SoanGiaoTrinh];
                if (!Convert.IsDBNull(drw[C_Khac])) this.dblKhac = (double)drw[C_Khac];
                if (!Convert.IsDBNull(drw[C_Total])) this.dblTotal = (double)drw[C_Total];
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
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
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
        public SIM_TeachingTimeAdded Get(int? intYearID, int? intSemester, string strTeacherID)
        {
            SIM_TeachingTimeAdded obj = new SIM_TeachingTimeAdded();
            if (objIData != null)
                obj.IDB = objIData;
            obj.YearID = intYearID;
            obj.Semester = intSemester;
            obj.TeacherID = strTeacherID;
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
            return GetDataTable("SIM_TeachingTimeAdded_SEARCH", pars);
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
                objIData.AddParameter(P_SoanDeKT_TL, this.dblSoanDeKT_TL);
                objIData.AddParameter(P_SoanDeKT_TLTN, this.dblSoanDeKT_TLTN);
                objIData.AddParameter(P_SoanDeKT_TN, this.dblSoanDeKT_TN);
                objIData.AddParameter(P_SoanDeKT_VD, this.dblSoanDeKT_VD);
                objIData.AddParameter(P_SoanDeKT_TH, this.dblSoanDeKT_TH);
                objIData.AddParameter(P_CoiThiKT, this.dblCoiThiKT);
                objIData.AddParameter(P_ChamThiKT_TLTN, this.dblChamThiKT_TLTN);
                objIData.AddParameter(P_ChamThiKT_VD, this.dblChamThiKT_VD);
                objIData.AddParameter(P_ChamThiKT_TH, this.dblChamThiKT_TH);
                objIData.AddParameter(P_SoanDeTN_TL, this.dblSoanDeTN_TL);
                objIData.AddParameter(P_SoanDeTN_TLTN, this.dblSoanDeTN_TLTN);
                objIData.AddParameter(P_SoanDeTN_TN, this.dblSoanDeTN_TN);
                objIData.AddParameter(P_SoanDeTN_VD, this.dblSoanDeTN_VD);
                objIData.AddParameter(P_SoanDeTN_TH, this.dblSoanDeTN_TH);
                objIData.AddParameter(P_CoiThiTN, this.dblCoiThiTN);
                objIData.AddParameter(P_ChamThiTN_TLTN, this.dblChamThiTN_TLTN);
                objIData.AddParameter(P_ChamThiTN_VD, this.dblChamThiTN_VD);
                objIData.AddParameter(P_ChamThiTN_TH, this.dblChamThiTN_TH);
                objIData.AddParameter(P_HuongDanThucTap, this.dblHuongDanThucTap);
                objIData.AddParameter(P_HuongDanThucTap2, this.dblHuongDanThucTap2);
                objIData.AddParameter(P_LuyenThi, this.dblLuyenThi);
                objIData.AddParameter(P_SoanGiaoTrinh, this.dblSoanGiaoTrinh);
                objIData.AddParameter(P_Khac, this.dblKhac);
                objIData.AddParameter(P_Total, this.dblTotal);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.ExecNonQuery();
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
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
                objIData.AddParameter(P_SoanDeKT_TL, this.dblSoanDeKT_TL);
                objIData.AddParameter(P_SoanDeKT_TLTN, this.dblSoanDeKT_TLTN);
                objIData.AddParameter(P_SoanDeKT_TN, this.dblSoanDeKT_TN);
                objIData.AddParameter(P_SoanDeKT_VD, this.dblSoanDeKT_VD);
                objIData.AddParameter(P_SoanDeKT_TH, this.dblSoanDeKT_TH);
                objIData.AddParameter(P_CoiThiKT, this.dblCoiThiKT);
                objIData.AddParameter(P_ChamThiKT_TLTN, this.dblChamThiKT_TLTN);
                objIData.AddParameter(P_ChamThiKT_VD, this.dblChamThiKT_VD);
                objIData.AddParameter(P_ChamThiKT_TH, this.dblChamThiKT_TH);
                objIData.AddParameter(P_SoanDeTN_TL, this.dblSoanDeTN_TL);
                objIData.AddParameter(P_SoanDeTN_TLTN, this.dblSoanDeTN_TLTN);
                objIData.AddParameter(P_SoanDeTN_TN, this.dblSoanDeTN_TN);
                objIData.AddParameter(P_SoanDeTN_VD, this.dblSoanDeTN_VD);
                objIData.AddParameter(P_SoanDeTN_TH, this.dblSoanDeTN_TH);
                objIData.AddParameter(P_CoiThiTN, this.dblCoiThiTN);
                objIData.AddParameter(P_ChamThiTN_TLTN, this.dblChamThiTN_TLTN);
                objIData.AddParameter(P_ChamThiTN_VD, this.dblChamThiTN_VD);
                objIData.AddParameter(P_ChamThiTN_TH, this.dblChamThiTN_TH);
                objIData.AddParameter(P_HuongDanThucTap, this.dblHuongDanThucTap);
                objIData.AddParameter(P_HuongDanThucTap2, this.dblHuongDanThucTap2);
                objIData.AddParameter(P_LuyenThi, this.dblLuyenThi);
                objIData.AddParameter(P_SoanGiaoTrinh, this.dblSoanGiaoTrinh);
                objIData.AddParameter(P_Khac, this.dblKhac);
                objIData.AddParameter(P_Total, this.dblTotal);
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
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_Semester, this.intSemester);
                objIData.AddParameter(P_TeacherID, this.strTeacherID);
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
        public bool Delete(int? intYearID, int? intSemester, string strTeacherID)
        {
            this.intYearID = intYearID;
            this.intSemester = intSemester;
            this.strTeacherID = strTeacherID;
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
        public SIM_TeachingTimeAdded(int? intYearID, int? intSemester, string strTeacherID)
        {
            this.intYearID = intYearID;
            this.intSemester = intSemester;
            this.strTeacherID = strTeacherID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_YearID = "@" + C_YearID;
        public const String P_Semester = "@" + C_Semester;
        public const String P_TeacherID = "@" + C_TeacherID;
        public const String P_SoanDeKT_TL = "@" + C_SoanDeKT_TL;
        public const String P_SoanDeKT_TLTN = "@" + C_SoanDeKT_TLTN;
        public const String P_SoanDeKT_TN = "@" + C_SoanDeKT_TN;
        public const String P_SoanDeKT_VD = "@" + C_SoanDeKT_VD;
        public const String P_SoanDeKT_TH = "@" + C_SoanDeKT_TH;
        public const String P_CoiThiKT = "@" + C_CoiThiKT;
        public const String P_ChamThiKT_TLTN = "@" + C_ChamThiKT_TLTN;
        public const String P_ChamThiKT_VD = "@" + C_ChamThiKT_VD;
        public const String P_ChamThiKT_TH = "@" + C_ChamThiKT_TH;
        public const String P_SoanDeTN_TL = "@" + C_SoanDeTN_TL;
        public const String P_SoanDeTN_TLTN = "@" + C_SoanDeTN_TLTN;
        public const String P_SoanDeTN_TN = "@" + C_SoanDeTN_TN;
        public const String P_SoanDeTN_VD = "@" + C_SoanDeTN_VD;
        public const String P_SoanDeTN_TH = "@" + C_SoanDeTN_TH;
        public const String P_CoiThiTN = "@" + C_CoiThiTN;
        public const String P_ChamThiTN_TLTN = "@" + C_ChamThiTN_TLTN;
        public const String P_ChamThiTN_VD = "@" + C_ChamThiTN_VD;
        public const String P_ChamThiTN_TH = "@" + C_ChamThiTN_TH;
        public const String P_HuongDanThucTap = "@" + C_HuongDanThucTap;
        public const String P_HuongDanThucTap2 = "@" + C_HuongDanThucTap2;
        public const String P_LuyenThi = "@" + C_LuyenThi;
        public const String P_SoanGiaoTrinh = "@" + C_SoanGiaoTrinh;
        public const String P_Khac = "@" + C_Khac;
        public const String P_Total = "@" + C_Total;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;

        #endregion //Parameter names

        #region Column Names

        public const String C_YearID = "YearID";
        public const String C_Semester = "Semester";
        public const String C_TeacherID = "TeacherID";
        public const String C_SoanDeKT_TL = "SoanDeKT_TL";
        public const String C_SoanDeKT_TLTN = "SoanDeKT_TLTN";
        public const String C_SoanDeKT_TN = "SoanDeKT_TN";
        public const String C_SoanDeKT_VD = "SoanDeKT_VD";
        public const String C_SoanDeKT_TH = "SoanDeKT_TH";
        public const String C_CoiThiKT = "CoiThiKT";
        public const String C_ChamThiKT_TLTN = "ChamThiKT_TLTN";
        public const String C_ChamThiKT_VD = "ChamThiKT_VD";
        public const String C_ChamThiKT_TH = "ChamThiKT_TH";
        public const String C_SoanDeTN_TL = "SoanDeTN_TL";
        public const String C_SoanDeTN_TLTN = "SoanDeTN_TLTN";
        public const String C_SoanDeTN_TN = "SoanDeTN_TN";
        public const String C_SoanDeTN_VD = "SoanDeTN_VD";
        public const String C_SoanDeTN_TH = "SoanDeTN_TH";
        public const String C_CoiThiTN = "CoiThiTN";
        public const String C_ChamThiTN_TLTN = "ChamThiTN_TLTN";
        public const String C_ChamThiTN_VD = "ChamThiTN_VD";
        public const String C_ChamThiTN_TH = "ChamThiTN_TH";
        public const String C_HuongDanThucTap = "HuongDanThucTap";
        public const String C_HuongDanThucTap2 = "HuongDanThucTap2";
        public const String C_LuyenThi = "LuyenThi";
        public const String C_SoanGiaoTrinh = "SoanGiaoTrinh";
        public const String C_Khac = "Khac";
        public const String C_Total = "Total";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_UpdatedDate = "UpdatedDate";

        #endregion //Column names

        #endregion Variable Static
    }
}


