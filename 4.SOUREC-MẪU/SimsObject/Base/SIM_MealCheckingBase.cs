
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// Created by 		: YourName 
    /// Created date 	: 12/13/2012 
    /// Description 
    /// </summary>	
    public partial class SIM_MealChecking
    {
        #region Member Variables

        private long? lngMealCheckingID = null;//Mã tự tăng
        private long? lngStudentID = null;//Mã sinh viên
        private double? dblSubMoney = null;//Tiền trợ cấp
        private double? dblSocialAssistanceMoney = null;//Tiền trợ cấp
        private double? dblPolicyAssistanceMoney = null;//Tiền trợ cấp
        private DateTime? dtmMonth = null;//Tháng cơm
        private int? intDay1 = null;
        private int? intDay2 = null;
        private int? intDay3 = null;
        private int? intDay4 = null;
        private int? intDay5 = null;
        private int? intDay6 = null;
        private int? intDay7 = null;
        private int? intDay8 = null;
        private int? intDay9 = null;
        private int? intDay10 = null;
        private int? intDay11 = null;
        private int? intDay12 = null;
        private int? intDay13 = null;
        private int? intDay14 = null;
        private int? intDay15 = null;
        private int? intDay16 = null;
        private int? intDay17 = null;
        private int? intDay18 = null;
        private int? intDay19 = null;
        private int? intDay20 = null;
        private int? intDay21 = null;
        private int? intDay22 = null;
        private int? intDay23 = null;
        private int? intDay24 = null;
        private int? intDay25 = null;
        private int? intDay26 = null;
        private int? intDay27 = null;
        private int? intDay28 = null;
        private int? intDay29 = null;
        private int? intDay30 = null;
        private int? intDay31 = null;
        private int? intQuantity = null;//Tổng cử cơm
        private double? dblPrice = null;//Giá tiền mỗi cữ cơm
        private double? dblTotalMoney = null;//Tổng tiền
        private string strDescription = null;//Mô tả
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
        /// MealCheckingID
        /// Mã tự tăng
        /// </summary>
        public long? MealCheckingID
        {
            get { return lngMealCheckingID; }
            set { lngMealCheckingID = value; }
        }
        /// <summary>
        /// StudentID
        /// Mã sinh viên
        /// </summary>
        public long? StudentID
        {
            get { return lngStudentID; }
            set { lngStudentID = value; }
        }
        /// <summary>
        /// SubMoney
        /// Tiền trợ cấp
        /// </summary>
        public double? SubMoney
        {
            get { return dblSubMoney; }
            set { dblSubMoney = value; }
        }
        /// <summary>
        /// SocialAssistanceMoney
        /// Tiền trợ cấp
        /// </summary>
        public double? SocialAssistanceMoney
        {
            get { return dblSocialAssistanceMoney; }
            set { dblSocialAssistanceMoney = value; }
        }
        /// <summary>
        /// PolicyAssistanceMoney
        /// Tiền trợ cấp
        /// </summary>
        public double? PolicyAssistanceMoney
        {
            get { return dblPolicyAssistanceMoney; }
            set { dblPolicyAssistanceMoney = value; }
        }
        /// <summary>
        /// Month
        /// Tháng cơm
        /// </summary>
        public DateTime? Month
        {
            get { return dtmMonth; }
            set { dtmMonth = value; }
        }
        /// <summary>
        /// Day1
        /// 
        /// </summary>
        public int? Day1
        {
            get { return intDay1; }
            set { intDay1 = value; }
        }
        /// <summary>
        /// Day2
        /// 
        /// </summary>
        public int? Day2
        {
            get { return intDay2; }
            set { intDay2 = value; }
        }
        /// <summary>
        /// Day3
        /// 
        /// </summary>
        public int? Day3
        {
            get { return intDay3; }
            set { intDay3 = value; }
        }
        /// <summary>
        /// Day4
        /// 
        /// </summary>
        public int? Day4
        {
            get { return intDay4; }
            set { intDay4 = value; }
        }
        /// <summary>
        /// Day5
        /// 
        /// </summary>
        public int? Day5
        {
            get { return intDay5; }
            set { intDay5 = value; }
        }
        /// <summary>
        /// Day6
        /// 
        /// </summary>
        public int? Day6
        {
            get { return intDay6; }
            set { intDay6 = value; }
        }
        /// <summary>
        /// Day7
        /// 
        /// </summary>
        public int? Day7
        {
            get { return intDay7; }
            set { intDay7 = value; }
        }
        /// <summary>
        /// Day8
        /// 
        /// </summary>
        public int? Day8
        {
            get { return intDay8; }
            set { intDay8 = value; }
        }
        /// <summary>
        /// Day9
        /// 
        /// </summary>
        public int? Day9
        {
            get { return intDay9; }
            set { intDay9 = value; }
        }
        /// <summary>
        /// Day10
        /// 
        /// </summary>
        public int? Day10
        {
            get { return intDay10; }
            set { intDay10 = value; }
        }
        /// <summary>
        /// Day11
        /// 
        /// </summary>
        public int? Day11
        {
            get { return intDay11; }
            set { intDay11 = value; }
        }
        /// <summary>
        /// Day12
        /// 
        /// </summary>
        public int? Day12
        {
            get { return intDay12; }
            set { intDay12 = value; }
        }
        /// <summary>
        /// Day13
        /// 
        /// </summary>
        public int? Day13
        {
            get { return intDay13; }
            set { intDay13 = value; }
        }
        /// <summary>
        /// Day14
        /// 
        /// </summary>
        public int? Day14
        {
            get { return intDay14; }
            set { intDay14 = value; }
        }
        /// <summary>
        /// Day15
        /// 
        /// </summary>
        public int? Day15
        {
            get { return intDay15; }
            set { intDay15 = value; }
        }
        /// <summary>
        /// Day16
        /// 
        /// </summary>
        public int? Day16
        {
            get { return intDay16; }
            set { intDay16 = value; }
        }
        /// <summary>
        /// Day17
        /// 
        /// </summary>
        public int? Day17
        {
            get { return intDay17; }
            set { intDay17 = value; }
        }
        /// <summary>
        /// Day18
        /// 
        /// </summary>
        public int? Day18
        {
            get { return intDay18; }
            set { intDay18 = value; }
        }
        /// <summary>
        /// Day19
        /// 
        /// </summary>
        public int? Day19
        {
            get { return intDay19; }
            set { intDay19 = value; }
        }
        /// <summary>
        /// Day20
        /// 
        /// </summary>
        public int? Day20
        {
            get { return intDay20; }
            set { intDay20 = value; }
        }
        /// <summary>
        /// Day21
        /// 
        /// </summary>
        public int? Day21
        {
            get { return intDay21; }
            set { intDay21 = value; }
        }
        /// <summary>
        /// Day22
        /// 
        /// </summary>
        public int? Day22
        {
            get { return intDay22; }
            set { intDay22 = value; }
        }
        /// <summary>
        /// Day23
        /// 
        /// </summary>
        public int? Day23
        {
            get { return intDay23; }
            set { intDay23 = value; }
        }
        /// <summary>
        /// Day24
        /// 
        /// </summary>
        public int? Day24
        {
            get { return intDay24; }
            set { intDay24 = value; }
        }
        /// <summary>
        /// Day25
        /// 
        /// </summary>
        public int? Day25
        {
            get { return intDay25; }
            set { intDay25 = value; }
        }
        /// <summary>
        /// Day26
        /// 
        /// </summary>
        public int? Day26
        {
            get { return intDay26; }
            set { intDay26 = value; }
        }
        /// <summary>
        /// Day27
        /// 
        /// </summary>
        public int? Day27
        {
            get { return intDay27; }
            set { intDay27 = value; }
        }
        /// <summary>
        /// Day28
        /// 
        /// </summary>
        public int? Day28
        {
            get { return intDay28; }
            set { intDay28 = value; }
        }
        /// <summary>
        /// Day29
        /// 
        /// </summary>
        public int? Day29
        {
            get { return intDay29; }
            set { intDay29 = value; }
        }
        /// <summary>
        /// Day30
        /// 
        /// </summary>
        public int? Day30
        {
            get { return intDay30; }
            set { intDay30 = value; }
        }
        /// <summary>
        /// Day31
        /// 
        /// </summary>
        public int? Day31
        {
            get { return intDay31; }
            set { intDay31 = value; }
        }
        /// <summary>
        /// Quantity
        /// Tổng cử cơm
        /// </summary>
        public int? Quantity
        {
            get { return intQuantity; }
            set { intQuantity = value; }
        }
        /// <summary>
        /// Price
        /// Giá tiền mỗi cữ cơm
        /// </summary>
        public double? Price
        {
            get { return dblPrice; }
            set { dblPrice = value; }
        }
        /// <summary>
        /// TotalMoney
        /// Tổng tiền
        /// </summary>
        public double? TotalMoney
        {
            get { return dblTotalMoney; }
            set { dblTotalMoney = value; }
        }
        /// <summary>
        /// Description
        /// Mô tả
        /// </summary>
        public string Description
        {
            get { return strDescription; }
            set { strDescription = value; }
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
        /// CreatedUser
        /// Người tạo
        /// </summary>
        public string CreatedUser
        {
            get { return strCreatedUser; }
            set { strCreatedUser = value; }
        }
        /// <summary>
        /// UpdatedDate
        /// Ngày cập nhật cuối
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return dtmUpdatedDate; }
            set { dtmUpdatedDate = value; }
        }
        /// <summary>
        /// UpdatedUser
        /// Người cập nhật cuối
        /// </summary>
        public string UpdatedUser
        {
            get { return strUpdatedUser; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_MealCheckingID.ToUpper()) && !Convert.IsDBNull(reader[C_MealCheckingID])) this.lngMealCheckingID = Convert.ToInt64(reader[C_MealCheckingID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubMoney.ToUpper()) && !Convert.IsDBNull(reader[C_SubMoney])) this.dblSubMoney = (double)reader[C_SubMoney];
                    if (reader.GetName(i).ToUpper().Equals(C_SocialAssistanceMoney.ToUpper()) && !Convert.IsDBNull(reader[C_SocialAssistanceMoney])) this.dblSocialAssistanceMoney = (double)reader[C_SocialAssistanceMoney];
                    if (reader.GetName(i).ToUpper().Equals(C_PolicyAssistanceMoney.ToUpper()) && !Convert.IsDBNull(reader[C_PolicyAssistanceMoney])) this.dblPolicyAssistanceMoney = (double)reader[C_PolicyAssistanceMoney];
                    if (reader.GetName(i).ToUpper().Equals(C_Month.ToUpper()) && !Convert.IsDBNull(reader[C_Month])) this.dtmMonth = Convert.ToDateTime(reader[C_Month]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day1.ToUpper()) && !Convert.IsDBNull(reader[C_Day1])) this.intDay1 = Convert.ToInt32(reader[C_Day1]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day2.ToUpper()) && !Convert.IsDBNull(reader[C_Day2])) this.intDay2 = Convert.ToInt32(reader[C_Day2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day3.ToUpper()) && !Convert.IsDBNull(reader[C_Day3])) this.intDay3 = Convert.ToInt32(reader[C_Day3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day4.ToUpper()) && !Convert.IsDBNull(reader[C_Day4])) this.intDay4 = Convert.ToInt32(reader[C_Day4]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day5.ToUpper()) && !Convert.IsDBNull(reader[C_Day5])) this.intDay5 = Convert.ToInt32(reader[C_Day5]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day6.ToUpper()) && !Convert.IsDBNull(reader[C_Day6])) this.intDay6 = Convert.ToInt32(reader[C_Day6]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day7.ToUpper()) && !Convert.IsDBNull(reader[C_Day7])) this.intDay7 = Convert.ToInt32(reader[C_Day7]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day8.ToUpper()) && !Convert.IsDBNull(reader[C_Day8])) this.intDay8 = Convert.ToInt32(reader[C_Day8]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day9.ToUpper()) && !Convert.IsDBNull(reader[C_Day9])) this.intDay9 = Convert.ToInt32(reader[C_Day9]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day10.ToUpper()) && !Convert.IsDBNull(reader[C_Day10])) this.intDay10 = Convert.ToInt32(reader[C_Day10]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day11.ToUpper()) && !Convert.IsDBNull(reader[C_Day11])) this.intDay11 = Convert.ToInt32(reader[C_Day11]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day12.ToUpper()) && !Convert.IsDBNull(reader[C_Day12])) this.intDay12 = Convert.ToInt32(reader[C_Day12]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day13.ToUpper()) && !Convert.IsDBNull(reader[C_Day13])) this.intDay13 = Convert.ToInt32(reader[C_Day13]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day14.ToUpper()) && !Convert.IsDBNull(reader[C_Day14])) this.intDay14 = Convert.ToInt32(reader[C_Day14]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day15.ToUpper()) && !Convert.IsDBNull(reader[C_Day15])) this.intDay15 = Convert.ToInt32(reader[C_Day15]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day16.ToUpper()) && !Convert.IsDBNull(reader[C_Day16])) this.intDay16 = Convert.ToInt32(reader[C_Day16]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day17.ToUpper()) && !Convert.IsDBNull(reader[C_Day17])) this.intDay17 = Convert.ToInt32(reader[C_Day17]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day18.ToUpper()) && !Convert.IsDBNull(reader[C_Day18])) this.intDay18 = Convert.ToInt32(reader[C_Day18]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day19.ToUpper()) && !Convert.IsDBNull(reader[C_Day19])) this.intDay19 = Convert.ToInt32(reader[C_Day19]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day20.ToUpper()) && !Convert.IsDBNull(reader[C_Day20])) this.intDay20 = Convert.ToInt32(reader[C_Day20]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day21.ToUpper()) && !Convert.IsDBNull(reader[C_Day21])) this.intDay21 = Convert.ToInt32(reader[C_Day21]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day22.ToUpper()) && !Convert.IsDBNull(reader[C_Day22])) this.intDay22 = Convert.ToInt32(reader[C_Day22]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day23.ToUpper()) && !Convert.IsDBNull(reader[C_Day23])) this.intDay23 = Convert.ToInt32(reader[C_Day23]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day24.ToUpper()) && !Convert.IsDBNull(reader[C_Day24])) this.intDay24 = Convert.ToInt32(reader[C_Day24]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day25.ToUpper()) && !Convert.IsDBNull(reader[C_Day25])) this.intDay25 = Convert.ToInt32(reader[C_Day25]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day26.ToUpper()) && !Convert.IsDBNull(reader[C_Day26])) this.intDay26 = Convert.ToInt32(reader[C_Day26]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day27.ToUpper()) && !Convert.IsDBNull(reader[C_Day27])) this.intDay27 = Convert.ToInt32(reader[C_Day27]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day28.ToUpper()) && !Convert.IsDBNull(reader[C_Day28])) this.intDay28 = Convert.ToInt32(reader[C_Day28]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day29.ToUpper()) && !Convert.IsDBNull(reader[C_Day29])) this.intDay29 = Convert.ToInt32(reader[C_Day29]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day30.ToUpper()) && !Convert.IsDBNull(reader[C_Day30])) this.intDay30 = Convert.ToInt32(reader[C_Day30]);
                    if (reader.GetName(i).ToUpper().Equals(C_Day31.ToUpper()) && !Convert.IsDBNull(reader[C_Day31])) this.intDay31 = Convert.ToInt32(reader[C_Day31]);
                    if (reader.GetName(i).ToUpper().Equals(C_Quantity.ToUpper()) && !Convert.IsDBNull(reader[C_Quantity])) this.intQuantity = Convert.ToInt32(reader[C_Quantity]);
                    if (reader.GetName(i).ToUpper().Equals(C_Price.ToUpper()) && !Convert.IsDBNull(reader[C_Price])) this.dblPrice = (double)reader[C_Price];
                    if (reader.GetName(i).ToUpper().Equals(C_TotalMoney.ToUpper()) && !Convert.IsDBNull(reader[C_TotalMoney])) this.dblTotalMoney = (double)reader[C_TotalMoney];
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_MealChecking", objEx);
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
                if (!Convert.IsDBNull(drw[C_MealCheckingID])) this.lngMealCheckingID = Convert.ToInt64(drw[C_MealCheckingID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_SubMoney])) this.dblSubMoney = (double)drw[C_SubMoney];
                if (!Convert.IsDBNull(drw[C_SocialAssistanceMoney])) this.dblSocialAssistanceMoney = (double)drw[C_SocialAssistanceMoney];
                if (!Convert.IsDBNull(drw[C_PolicyAssistanceMoney])) this.dblPolicyAssistanceMoney = (double)drw[C_PolicyAssistanceMoney];
                if (!Convert.IsDBNull(drw[C_Month])) this.dtmMonth = Convert.ToDateTime(drw[C_Month]);
                if (!Convert.IsDBNull(drw[C_Day1])) this.intDay1 = Convert.ToInt32(drw[C_Day1]);
                if (!Convert.IsDBNull(drw[C_Day2])) this.intDay2 = Convert.ToInt32(drw[C_Day2]);
                if (!Convert.IsDBNull(drw[C_Day3])) this.intDay3 = Convert.ToInt32(drw[C_Day3]);
                if (!Convert.IsDBNull(drw[C_Day4])) this.intDay4 = Convert.ToInt32(drw[C_Day4]);
                if (!Convert.IsDBNull(drw[C_Day5])) this.intDay5 = Convert.ToInt32(drw[C_Day5]);
                if (!Convert.IsDBNull(drw[C_Day6])) this.intDay6 = Convert.ToInt32(drw[C_Day6]);
                if (!Convert.IsDBNull(drw[C_Day7])) this.intDay7 = Convert.ToInt32(drw[C_Day7]);
                if (!Convert.IsDBNull(drw[C_Day8])) this.intDay8 = Convert.ToInt32(drw[C_Day8]);
                if (!Convert.IsDBNull(drw[C_Day9])) this.intDay9 = Convert.ToInt32(drw[C_Day9]);
                if (!Convert.IsDBNull(drw[C_Day10])) this.intDay10 = Convert.ToInt32(drw[C_Day10]);
                if (!Convert.IsDBNull(drw[C_Day11])) this.intDay11 = Convert.ToInt32(drw[C_Day11]);
                if (!Convert.IsDBNull(drw[C_Day12])) this.intDay12 = Convert.ToInt32(drw[C_Day12]);
                if (!Convert.IsDBNull(drw[C_Day13])) this.intDay13 = Convert.ToInt32(drw[C_Day13]);
                if (!Convert.IsDBNull(drw[C_Day14])) this.intDay14 = Convert.ToInt32(drw[C_Day14]);
                if (!Convert.IsDBNull(drw[C_Day15])) this.intDay15 = Convert.ToInt32(drw[C_Day15]);
                if (!Convert.IsDBNull(drw[C_Day16])) this.intDay16 = Convert.ToInt32(drw[C_Day16]);
                if (!Convert.IsDBNull(drw[C_Day17])) this.intDay17 = Convert.ToInt32(drw[C_Day17]);
                if (!Convert.IsDBNull(drw[C_Day18])) this.intDay18 = Convert.ToInt32(drw[C_Day18]);
                if (!Convert.IsDBNull(drw[C_Day19])) this.intDay19 = Convert.ToInt32(drw[C_Day19]);
                if (!Convert.IsDBNull(drw[C_Day20])) this.intDay20 = Convert.ToInt32(drw[C_Day20]);
                if (!Convert.IsDBNull(drw[C_Day21])) this.intDay21 = Convert.ToInt32(drw[C_Day21]);
                if (!Convert.IsDBNull(drw[C_Day22])) this.intDay22 = Convert.ToInt32(drw[C_Day22]);
                if (!Convert.IsDBNull(drw[C_Day23])) this.intDay23 = Convert.ToInt32(drw[C_Day23]);
                if (!Convert.IsDBNull(drw[C_Day24])) this.intDay24 = Convert.ToInt32(drw[C_Day24]);
                if (!Convert.IsDBNull(drw[C_Day25])) this.intDay25 = Convert.ToInt32(drw[C_Day25]);
                if (!Convert.IsDBNull(drw[C_Day26])) this.intDay26 = Convert.ToInt32(drw[C_Day26]);
                if (!Convert.IsDBNull(drw[C_Day27])) this.intDay27 = Convert.ToInt32(drw[C_Day27]);
                if (!Convert.IsDBNull(drw[C_Day28])) this.intDay28 = Convert.ToInt32(drw[C_Day28]);
                if (!Convert.IsDBNull(drw[C_Day29])) this.intDay29 = Convert.ToInt32(drw[C_Day29]);
                if (!Convert.IsDBNull(drw[C_Day30])) this.intDay30 = Convert.ToInt32(drw[C_Day30]);
                if (!Convert.IsDBNull(drw[C_Day31])) this.intDay31 = Convert.ToInt32(drw[C_Day31]);
                if (!Convert.IsDBNull(drw[C_Quantity])) this.intQuantity = Convert.ToInt32(drw[C_Quantity]);
                if (!Convert.IsDBNull(drw[C_Price])) this.dblPrice = (double)drw[C_Price];
                if (!Convert.IsDBNull(drw[C_TotalMoney])) this.dblTotalMoney = (double)drw[C_TotalMoney];
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_MealChecking", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_MealChecking_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MealChecking_GET");
                objIData.AddParameter(P_MealCheckingID, this.lngMealCheckingID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_MealChecking", objEx);
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
        /// Store: SIM_MealChecking_GET 
        ///</summary>
        /// <returns> SIM_MealChecking </returns>
        public SIM_MealChecking Get(long? lngMealCheckingID)
        {
            SIM_MealChecking obj = new SIM_MealChecking();
            if (objIData != null)
                obj.IDB = objIData;
            obj.MealCheckingID = lngMealCheckingID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_MealChecking
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MealChecking", objEx);
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
        /// Search : SIM_MealChecking
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_MealChecking", objEx);
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
        /// Search : SIM_MealChecking
        /// Lấy hết dữ liệu
        /// Store: SIM_MealChecking_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_MealChecking_GETALL");
        }

        ///<summary>
        /// Search : SIM_MealChecking
        /// Tìm dữ liệu
        /// Store: SIM_MealChecking_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_MealChecking_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_MealChecking
        /// Thêm dữ liệu
        /// Store: SIM_MealChecking_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MealChecking_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SubMoney, this.dblSubMoney);
                objIData.AddParameter(P_SocialAssistanceMoney, this.dblSocialAssistanceMoney);
                objIData.AddParameter(P_PolicyAssistanceMoney, this.dblPolicyAssistanceMoney);
                objIData.AddParameter(P_Month, this.dtmMonth);
                objIData.AddParameter(P_Day1, this.intDay1);
                objIData.AddParameter(P_Day2, this.intDay2);
                objIData.AddParameter(P_Day3, this.intDay3);
                objIData.AddParameter(P_Day4, this.intDay4);
                objIData.AddParameter(P_Day5, this.intDay5);
                objIData.AddParameter(P_Day6, this.intDay6);
                objIData.AddParameter(P_Day7, this.intDay7);
                objIData.AddParameter(P_Day8, this.intDay8);
                objIData.AddParameter(P_Day9, this.intDay9);
                objIData.AddParameter(P_Day10, this.intDay10);
                objIData.AddParameter(P_Day11, this.intDay11);
                objIData.AddParameter(P_Day12, this.intDay12);
                objIData.AddParameter(P_Day13, this.intDay13);
                objIData.AddParameter(P_Day14, this.intDay14);
                objIData.AddParameter(P_Day15, this.intDay15);
                objIData.AddParameter(P_Day16, this.intDay16);
                objIData.AddParameter(P_Day17, this.intDay17);
                objIData.AddParameter(P_Day18, this.intDay18);
                objIData.AddParameter(P_Day19, this.intDay19);
                objIData.AddParameter(P_Day20, this.intDay20);
                objIData.AddParameter(P_Day21, this.intDay21);
                objIData.AddParameter(P_Day22, this.intDay22);
                objIData.AddParameter(P_Day23, this.intDay23);
                objIData.AddParameter(P_Day24, this.intDay24);
                objIData.AddParameter(P_Day25, this.intDay25);
                objIData.AddParameter(P_Day26, this.intDay26);
                objIData.AddParameter(P_Day27, this.intDay27);
                objIData.AddParameter(P_Day28, this.intDay28);
                objIData.AddParameter(P_Day29, this.intDay29);
                objIData.AddParameter(P_Day30, this.intDay30);
                objIData.AddParameter(P_Day31, this.intDay31);
                objIData.AddParameter(P_Quantity, this.intQuantity);
                objIData.AddParameter(P_Price, this.dblPrice);
                objIData.AddParameter(P_TotalMoney, this.dblTotalMoney);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngMealCheckingID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_MealChecking", objEx);
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
        /// Update : SIM_MealChecking
        /// Cập nhật dữ liệu
        /// Store: SIM_MealChecking_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MealChecking_EDIT");
                objIData.AddParameter(P_MealCheckingID, this.lngMealCheckingID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SubMoney, this.dblSubMoney);
                objIData.AddParameter(P_SocialAssistanceMoney, this.dblSocialAssistanceMoney);
                objIData.AddParameter(P_PolicyAssistanceMoney, this.dblPolicyAssistanceMoney);
                objIData.AddParameter(P_Month, this.dtmMonth);
                objIData.AddParameter(P_Day1, this.intDay1);
                objIData.AddParameter(P_Day2, this.intDay2);
                objIData.AddParameter(P_Day3, this.intDay3);
                objIData.AddParameter(P_Day4, this.intDay4);
                objIData.AddParameter(P_Day5, this.intDay5);
                objIData.AddParameter(P_Day6, this.intDay6);
                objIData.AddParameter(P_Day7, this.intDay7);
                objIData.AddParameter(P_Day8, this.intDay8);
                objIData.AddParameter(P_Day9, this.intDay9);
                objIData.AddParameter(P_Day10, this.intDay10);
                objIData.AddParameter(P_Day11, this.intDay11);
                objIData.AddParameter(P_Day12, this.intDay12);
                objIData.AddParameter(P_Day13, this.intDay13);
                objIData.AddParameter(P_Day14, this.intDay14);
                objIData.AddParameter(P_Day15, this.intDay15);
                objIData.AddParameter(P_Day16, this.intDay16);
                objIData.AddParameter(P_Day17, this.intDay17);
                objIData.AddParameter(P_Day18, this.intDay18);
                objIData.AddParameter(P_Day19, this.intDay19);
                objIData.AddParameter(P_Day20, this.intDay20);
                objIData.AddParameter(P_Day21, this.intDay21);
                objIData.AddParameter(P_Day22, this.intDay22);
                objIData.AddParameter(P_Day23, this.intDay23);
                objIData.AddParameter(P_Day24, this.intDay24);
                objIData.AddParameter(P_Day25, this.intDay25);
                objIData.AddParameter(P_Day26, this.intDay26);
                objIData.AddParameter(P_Day27, this.intDay27);
                objIData.AddParameter(P_Day28, this.intDay28);
                objIData.AddParameter(P_Day29, this.intDay29);
                objIData.AddParameter(P_Day30, this.intDay30);
                objIData.AddParameter(P_Day31, this.intDay31);
                objIData.AddParameter(P_Quantity, this.intQuantity);
                objIData.AddParameter(P_Price, this.dblPrice);
                objIData.AddParameter(P_TotalMoney, this.dblTotalMoney);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_MealChecking", objEx);
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
        /// Delete : SIM_MealChecking
        /// Xóa dữ liệu
        /// Store: SIM_MealChecking_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_MealChecking_DELETE");
                objIData.AddParameter(P_MealCheckingID, this.lngMealCheckingID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_MealChecking", objEx);
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
        /// Store: SIM_MealChecking_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngMealCheckingID)
        {
            this.lngMealCheckingID = lngMealCheckingID;
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

        public SIM_MealChecking()
        {
        }
        public SIM_MealChecking(long? lngMealCheckingID)
        {
            this.lngMealCheckingID = lngMealCheckingID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_MealCheckingID = "@" + C_MealCheckingID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_SubMoney = "@" + C_SubMoney;
        public const String P_SocialAssistanceMoney = "@" + C_SocialAssistanceMoney;
        public const String P_PolicyAssistanceMoney = "@" + C_PolicyAssistanceMoney;
        public const String P_Month = "@" + C_Month;
        public const String P_Day1 = "@" + C_Day1;
        public const String P_Day2 = "@" + C_Day2;
        public const String P_Day3 = "@" + C_Day3;
        public const String P_Day4 = "@" + C_Day4;
        public const String P_Day5 = "@" + C_Day5;
        public const String P_Day6 = "@" + C_Day6;
        public const String P_Day7 = "@" + C_Day7;
        public const String P_Day8 = "@" + C_Day8;
        public const String P_Day9 = "@" + C_Day9;
        public const String P_Day10 = "@" + C_Day10;
        public const String P_Day11 = "@" + C_Day11;
        public const String P_Day12 = "@" + C_Day12;
        public const String P_Day13 = "@" + C_Day13;
        public const String P_Day14 = "@" + C_Day14;
        public const String P_Day15 = "@" + C_Day15;
        public const String P_Day16 = "@" + C_Day16;
        public const String P_Day17 = "@" + C_Day17;
        public const String P_Day18 = "@" + C_Day18;
        public const String P_Day19 = "@" + C_Day19;
        public const String P_Day20 = "@" + C_Day20;
        public const String P_Day21 = "@" + C_Day21;
        public const String P_Day22 = "@" + C_Day22;
        public const String P_Day23 = "@" + C_Day23;
        public const String P_Day24 = "@" + C_Day24;
        public const String P_Day25 = "@" + C_Day25;
        public const String P_Day26 = "@" + C_Day26;
        public const String P_Day27 = "@" + C_Day27;
        public const String P_Day28 = "@" + C_Day28;
        public const String P_Day29 = "@" + C_Day29;
        public const String P_Day30 = "@" + C_Day30;
        public const String P_Day31 = "@" + C_Day31;
        public const String P_Quantity = "@" + C_Quantity;
        public const String P_Price = "@" + C_Price;
        public const String P_TotalMoney = "@" + C_TotalMoney;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_MealCheckingID = "MealCheckingID";
        public const String C_StudentID = "StudentID";
        public const String C_SubMoney = "SubMoney";
        public const String C_SocialAssistanceMoney = "SocialAssistanceMoney";
        public const String C_PolicyAssistanceMoney = "PolicyAssistanceMoney";
        public const String C_Month = "Month";
        public const String C_Day1 = "Day1";
        public const String C_Day2 = "Day2";
        public const String C_Day3 = "Day3";
        public const String C_Day4 = "Day4";
        public const String C_Day5 = "Day5";
        public const String C_Day6 = "Day6";
        public const String C_Day7 = "Day7";
        public const String C_Day8 = "Day8";
        public const String C_Day9 = "Day9";
        public const String C_Day10 = "Day10";
        public const String C_Day11 = "Day11";
        public const String C_Day12 = "Day12";
        public const String C_Day13 = "Day13";
        public const String C_Day14 = "Day14";
        public const String C_Day15 = "Day15";
        public const String C_Day16 = "Day16";
        public const String C_Day17 = "Day17";
        public const String C_Day18 = "Day18";
        public const String C_Day19 = "Day19";
        public const String C_Day20 = "Day20";
        public const String C_Day21 = "Day21";
        public const String C_Day22 = "Day22";
        public const String C_Day23 = "Day23";
        public const String C_Day24 = "Day24";
        public const String C_Day25 = "Day25";
        public const String C_Day26 = "Day26";
        public const String C_Day27 = "Day27";
        public const String C_Day28 = "Day28";
        public const String C_Day29 = "Day29";
        public const String C_Day30 = "Day30";
        public const String C_Day31 = "Day31";
        public const String C_Quantity = "Quantity";
        public const String C_Price = "Price";
        public const String C_TotalMoney = "TotalMoney";
        public const String C_Description = "Description";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}


