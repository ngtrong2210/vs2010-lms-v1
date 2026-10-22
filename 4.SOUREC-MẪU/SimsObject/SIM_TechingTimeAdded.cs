
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
	/// Created date 	: 11/07/2011 
	/// Description 
	/// </summary>	
	public partial class SIM_TeachingTimeAdded
	{	
		
		#region Methods	
		/// <summary>
		/// set một số giá trị dựa vào tên biếng, cho một loạt các cột số decimal
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
        public void SetValue(string name, object value)
        {
            double? dblValue = null;
            if (value != null && value.ToString() != "" && value!= DBNull.Value)
                dblValue = Convert.ToSingle(value);
            if (dblValue <= 0)
                dblValue = null;
            switch (name)
            {
                case C_ChamThiKT_TH: 
                    this.dblChamThiKT_TH = dblValue; break;
                case C_ChamThiKT_TLTN: 
                    this.dblChamThiKT_TLTN = dblValue; break;
                case C_ChamThiKT_VD: 
                    this.dblChamThiKT_VD = dblValue; break;
                case C_ChamThiTN_TH: 
                    this.dblChamThiTN_TH = dblValue; break;
                case C_ChamThiTN_TLTN: 
                    this.dblChamThiTN_TLTN = dblValue; break;
                case C_ChamThiTN_VD: 
                    this.dblChamThiTN_VD = dblValue; break;
                case C_CoiThiKT: 
                    this.dblCoiThiKT = dblValue; break;
                case C_CoiThiTN: 
                    this.dblCoiThiTN = dblValue; break;
                case C_HuongDanThucTap: 
                    this.dblHuongDanThucTap = dblValue; break;
                case C_HuongDanThucTap2: 
                    this.dblHuongDanThucTap2 = dblValue; break;
                case C_Khac:
                    this.dblKhac = dblValue; break;
                case C_LuyenThi:
                    this.dblLuyenThi = dblValue; break;
                case C_SoanDeKT_TH:
                    this.dblSoanDeKT_TH = dblValue; break;
                case C_SoanDeKT_TL:
                    this.dblSoanDeKT_TL = dblValue; break;
                case C_SoanDeKT_TLTN:
                    this.dblSoanDeKT_TLTN= dblValue; break;
                case C_SoanDeKT_TN:
                    this.dblSoanDeKT_TN = dblValue; break;
                case C_SoanDeKT_VD:
                    this.dblSoanDeKT_VD = dblValue; break;
                case C_SoanDeTN_TH:
                    this.dblSoanDeTN_TH = dblValue; break;
                case C_SoanDeTN_TL:
                    this.dblSoanDeTN_TL = dblValue; break;
                case C_SoanDeTN_TLTN:
                    this.dblSoanDeTN_TLTN = dblValue; break;
                case C_SoanDeTN_TN:
                    this.dblSoanDeTN_TN = dblValue; break;
                case C_SoanDeTN_VD:
                    this.dblSoanDeTN_VD = dblValue; break;
                case C_SoanGiaoTrinh:
                    this.dblSoanGiaoTrinh = dblValue; break;     
                case C_Total:
                    this.dblTotal = dblValue; break;
            }
        }

        /// <summary>
        /// [SIM_TeachingTimeAdded_SearchForCoefficient]
        /// Chỉ lấy cột Total theo năm, kì
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataTable GetTotalAdded(params object[] conditions)
        {
            return GetDataTable("SIM_TeachingTimeAdded_SearchForCoefficient", conditions);
        }
		#endregion
	
	}
}
