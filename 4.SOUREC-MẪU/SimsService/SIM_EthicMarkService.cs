using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;
using System.Windows.Forms;


namespace SimsService
{
    /// <summary>
    /// Class này không có theo object, vì nó dùng chung cho việc xếp loại rèn luyện
    /// </summary>
    public partial class SIM_EthicMarkService
    {
        /// <summary>
        /// Xếp loại điểm rèn luyện cho 1 dòng đang edit
        /// </summary>
        /// <param name="drw"></param>
        /// <param name="fieldMark"></param>
        /// <param name="fieldLevel"></param>
        public static void SummaryEthic(DataRow drw, string fieldMark, string fieldLevel, int? regulationID)
        {
            drw[fieldLevel] = ToEthicLevel(drw[fieldMark], regulationID);            
        }

        /// <summary>
        /// Xếp loại cho 1 điểm rèn luyện
        /// </summary>
        /// <param name="ethicMark"></param>
        /// <param name="regulationID"></param>
        /// <returns></returns>
        public static string ToEthicLevel(object ethicMark, int? regulationID)
        {            
            string strLevel = "";
            if (ethicMark != null && ethicMark.ToString().Trim() != "")
            {
                double? dblMark = Convert.ToDouble(ethicMark);
                
                if (regulationID == 14 || regulationID == 22 || regulationID == 40 || regulationID == 46)
                {
                    if (dblMark >= 90)
                    {
                        strLevel = "Xuất sắc";
                    }
                    else if (dblMark >= 80)
                    {
                        strLevel = "Tốt";
                    }
                    else if (dblMark >= 70)
                    {
                        strLevel = "Khá";
                    }
                    else if (dblMark >= 60)
                    {
                        strLevel = "TB Khá";
                    }
                    else if (dblMark >= 50)
                    {
                        strLevel = "Trung bình";
                    }
                    else if (dblMark >= 30)
                    {
                        strLevel = "Yếu";
                    }
                    else
                    {
                        strLevel = "Yếu";// thông tư 17 đã bõ TBKha và kém
                    }
                }
                else // thông tư 17 đã bõ TBKha và kém
                {

                    if (dblMark >= 90)
                    {
                        strLevel = "Xuất sắc";
                    }
                    else if (dblMark >= 80)
                    {
                        strLevel = "Tốt";
                    }
                    else if (dblMark >= 70)
                    {
                        strLevel = "Khá";
                    }
                    else if (dblMark >= 50)
                    {
                        strLevel = "Trung bình";
                    }
                    else
                    {
                        strLevel = "Yếu";
                    }
                }
            }


            return strLevel;
        }
    }
}
