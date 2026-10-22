
#region Using

using System;
using System.Data;
using System.Collections;
using DCore;

#endregion

namespace SimsObject
{
    /// <summary>
    /// Created by 		: SimsObject 
    /// Created date 	: 6/10/2020 
    /// Description 
    /// </summary>	
    public partial class SIM_GraduationResult
    {
        #region Member Variables

        private long? lngGraduationResultID = null;
        private long? lngStudentID = null;
        private int? intExamDateID = null;//Mã kì thii TN
        private int? intOrderExam = null;//Lần thi
        private bool bolHaveExamRegister1 = false;//Có đăng ký thi TN Chính trị
        private bool bolHaveExamRegister2 = false;//Có đăng ký thi TN LT Nghề
        private bool bolHaveExamRegister3 = false;//Có đăng ký thi TN TH Nghề
        private double? dblMoney = null;//Số tiền lệ phí thi TN
        private string strDecisionNo = null;//Số quyết định
        private DateTime? dtmSigningdate = null;//Ngày ký
        private string strSigner = null;//Người ký
        private int? intYearID = null;//Mã niên học tốt nghiệp
        private double? dblSummaryLearningMark = null;//TBC học tập toàn khoá
        private string strSummaryLearningLevel = null;//Xếp loại học tập toàn khóa
        private double? dblGraduationExamAverage = null;//Trung bình điểm thi tốt nghiệp
        private double? dblGraduationRankingAverage = null;//Trung bình xếp hạng tốt nghiệp
        private string strGraduationLevel = null;//Xếp loại tốt nghiệp
        private string strDescription = null;
        private DateTime? dtmCreatedDate = null;//Ngày tạo
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private double? dblMark1 = null;//Điểm thi TN môn 1
        private double? dblMark2 = null;//Điểm thi TN môn 2
        private double? dblMark3 = null;//Điểm thi TN môn 3
        private string strCerNo = null;//Số hiệu bằng TN
        private DateTime? dtmCerIssued = null;//Ngày cấp bằng TN
        private string strCopyCerNo = null;//Số hiệu bản sao TN
        private DateTime? dtmCopyCerIssued = null;//Ngày cấp bản sao bằng TN
        private int? intResultReview = null;//Đậu rớt hoặc null là chưa xét
        private int? intSpecialType = null;
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// GraduationResultID
        /// 
        /// </summary>
        public long? GraduationResultID
        {
            get { return lngGraduationResultID; }
            set { lngGraduationResultID = value; }
        }
        /// <summary>
        /// StudentID
        /// 
        /// </summary>
        public long? StudentID
        {
            get { return lngStudentID; }
            set { lngStudentID = value; }
        }
        /// <summary>
        /// ExamDateID
        /// Mã kì thii TN
        /// </summary>
        public int? ExamDateID
        {
            get { return intExamDateID; }
            set { intExamDateID = value; }
        }
        /// <summary>
        /// OrderExam
        /// Lần thi
        /// </summary>
        public int? OrderExam
        {
            get { return intOrderExam; }
            set { intOrderExam = value; }
        }
        /// <summary>
        /// HaveExamRegister1
        /// Có đăng ký thi TN Chính trị
        /// </summary>
        public bool HaveExamRegister1
        {
            get { return bolHaveExamRegister1; }
            set { bolHaveExamRegister1 = value; }
        }
        /// <summary>
        /// HaveExamRegister2
        /// Có đăng ký thi TN LT Nghề
        /// </summary>
        public bool HaveExamRegister2
        {
            get { return bolHaveExamRegister2; }
            set { bolHaveExamRegister2 = value; }
        }
        /// <summary>
        /// HaveExamRegister3
        /// Có đăng ký thi TN TH Nghề
        /// </summary>
        public bool HaveExamRegister3
        {
            get { return bolHaveExamRegister3; }
            set { bolHaveExamRegister3 = value; }
        }
        /// <summary>
        /// Money
        /// Số tiền lệ phí thi TN
        /// </summary>
        public double? Money
        {
            get { return dblMoney; }
            set { dblMoney = value; }
        }
        /// <summary>
        /// DecisionNo
        /// Số quyết định
        /// </summary>
        public string DecisionNo
        {
            get { return strDecisionNo; }
            set { strDecisionNo = value; }
        }
        /// <summary>
        /// Signingdate
        /// Ngày ký
        /// </summary>
        public DateTime? Signingdate
        {
            get { return dtmSigningdate; }
            set { dtmSigningdate = value; }
        }
        /// <summary>
        /// Signer
        /// Người ký
        /// </summary>
        public string Signer
        {
            get { return strSigner; }
            set { strSigner = value; }
        }
        /// <summary>
        /// YearID
        /// Mã niên học tốt nghiệp
        /// </summary>
        public int? YearID
        {
            get { return intYearID; }
            set { intYearID = value; }
        }
        /// <summary>
        /// SummaryLearningMark
        /// TBC học tập toàn khoá
        /// </summary>
        public double? SummaryLearningMark
        {
            get { return dblSummaryLearningMark; }
            set { dblSummaryLearningMark = value; }
        }
        /// <summary>
        /// SummaryLearningLevel
        /// Xếp loại học tập toàn khóa
        /// </summary>
        public string SummaryLearningLevel
        {
            get { return strSummaryLearningLevel; }
            set { strSummaryLearningLevel = value; }
        }
        /// <summary>
        /// GraduationExamAverage
        /// Trung bình điểm thi tốt nghiệp
        /// </summary>
        public double? GraduationExamAverage
        {
            get { return dblGraduationExamAverage; }
            set { dblGraduationExamAverage = value; }
        }
        /// <summary>
        /// GraduationRankingAverage
        /// Trung bình xếp hạng tốt nghiệp
        /// </summary>
        public double? GraduationRankingAverage
        {
            get { return dblGraduationRankingAverage; }
            set { dblGraduationRankingAverage = value; }
        }
        /// <summary>
        /// GraduationLevel
        /// Xếp loại tốt nghiệp
        /// </summary>
        public string GraduationLevel
        {
            get { return strGraduationLevel; }
            set { strGraduationLevel = value; }
        }
        /// <summary>
        /// Description
        /// 
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
        /// Mark1
        /// Điểm thi TN môn 1
        /// </summary>
        public double? Mark1
        {
            get { return dblMark1; }
            set { dblMark1 = value; }
        }
        /// <summary>
        /// Mark2
        /// Điểm thi TN môn 2
        /// </summary>
        public double? Mark2
        {
            get { return dblMark2; }
            set { dblMark2 = value; }
        }
        /// <summary>
        /// Mark3
        /// Điểm thi TN môn 3
        /// </summary>
        public double? Mark3
        {
            get { return dblMark3; }
            set { dblMark3 = value; }
        }
        /// <summary>
        /// CerNo
        /// Số hiệu bằng TN
        /// </summary>
        public string CerNo
        {
            get { return strCerNo; }
            set { strCerNo = value; }
        }
        /// <summary>
        /// CerIssued
        /// Ngày cấp bằng TN
        /// </summary>
        public DateTime? CerIssued
        {
            get { return dtmCerIssued; }
            set { dtmCerIssued = value; }
        }
        /// <summary>
        /// CopyCerNo
        /// Số hiệu bản sao TN
        /// </summary>
        public string CopyCerNo
        {
            get { return strCopyCerNo; }
            set { strCopyCerNo = value; }
        }
        /// <summary>
        /// CopyCerIssued
        /// Ngày cấp bản sao bằng TN
        /// </summary>
        public DateTime? CopyCerIssued
        {
            get { return dtmCopyCerIssued; }
            set { dtmCopyCerIssued = value; }
        }
        /// <summary>
        /// ResultReview
        /// Đậu rớt hoặc null là chưa xét
        /// </summary>
        public int? ResultReview
        {
            get { return intResultReview; }
            set { intResultReview = value; }
        }
        /// <summary>
        /// SpecialType
        /// 
        /// </summary>
        public int? SpecialType
        {
            get { return intSpecialType; }
            set { intSpecialType = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationResultID.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationResultID])) this.lngGraduationResultID = Convert.ToInt64(reader[C_GraduationResultID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_ExamDateID.ToUpper()) && !Convert.IsDBNull(reader[C_ExamDateID])) this.intExamDateID = Convert.ToInt32(reader[C_ExamDateID]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderExam.ToUpper()) && !Convert.IsDBNull(reader[C_OrderExam])) this.intOrderExam = Convert.ToInt32(reader[C_OrderExam]);
                    if (reader.GetName(i).ToUpper().Equals(C_HaveExamRegister1.ToUpper()) && !Convert.IsDBNull(reader[C_HaveExamRegister1])) this.bolHaveExamRegister1 = Convert.ToBoolean(reader[C_HaveExamRegister1]);
                    if (reader.GetName(i).ToUpper().Equals(C_HaveExamRegister2.ToUpper()) && !Convert.IsDBNull(reader[C_HaveExamRegister2])) this.bolHaveExamRegister2 = Convert.ToBoolean(reader[C_HaveExamRegister2]);
                    if (reader.GetName(i).ToUpper().Equals(C_HaveExamRegister3.ToUpper()) && !Convert.IsDBNull(reader[C_HaveExamRegister3])) this.bolHaveExamRegister3 = Convert.ToBoolean(reader[C_HaveExamRegister3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Money.ToUpper()) && !Convert.IsDBNull(reader[C_Money])) this.dblMoney = Convert.ToDouble(reader[C_Money]);
                    if (reader.GetName(i).ToUpper().Equals(C_DecisionNo.ToUpper()) && !Convert.IsDBNull(reader[C_DecisionNo])) this.strDecisionNo = Convert.ToString(reader[C_DecisionNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_Signingdate.ToUpper()) && !Convert.IsDBNull(reader[C_Signingdate])) this.dtmSigningdate = Convert.ToDateTime(reader[C_Signingdate]);
                    if (reader.GetName(i).ToUpper().Equals(C_Signer.ToUpper()) && !Convert.IsDBNull(reader[C_Signer])) this.strSigner = Convert.ToString(reader[C_Signer]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearID.ToUpper()) && !Convert.IsDBNull(reader[C_YearID])) this.intYearID = Convert.ToInt32(reader[C_YearID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SummaryLearningMark.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryLearningMark])) this.dblSummaryLearningMark = Convert.ToDouble(reader[C_SummaryLearningMark]);
                    if (reader.GetName(i).ToUpper().Equals(C_SummaryLearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryLearningLevel])) this.strSummaryLearningLevel = Convert.ToString(reader[C_SummaryLearningLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationExamAverage.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationExamAverage])) this.dblGraduationExamAverage = Convert.ToDouble(reader[C_GraduationExamAverage]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationRankingAverage.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationRankingAverage])) this.dblGraduationRankingAverage = Convert.ToDouble(reader[C_GraduationRankingAverage]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationLevel.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationLevel])) this.strGraduationLevel = Convert.ToString(reader[C_GraduationLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_Description.ToUpper()) && !Convert.IsDBNull(reader[C_Description])) this.strDescription = Convert.ToString(reader[C_Description]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark1.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1])) this.dblMark1 = Convert.ToDouble(reader[C_Mark1]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark2.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2])) this.dblMark2 = Convert.ToDouble(reader[C_Mark2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark3.ToUpper()) && !Convert.IsDBNull(reader[C_Mark3])) this.dblMark3 = Convert.ToDouble(reader[C_Mark3]);
                    if (reader.GetName(i).ToUpper().Equals(C_CerNo.ToUpper()) && !Convert.IsDBNull(reader[C_CerNo])) this.strCerNo = Convert.ToString(reader[C_CerNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_CerIssued.ToUpper()) && !Convert.IsDBNull(reader[C_CerIssued])) this.dtmCerIssued = Convert.ToDateTime(reader[C_CerIssued]);
                    if (reader.GetName(i).ToUpper().Equals(C_CopyCerNo.ToUpper()) && !Convert.IsDBNull(reader[C_CopyCerNo])) this.strCopyCerNo = Convert.ToString(reader[C_CopyCerNo]);
                    if (reader.GetName(i).ToUpper().Equals(C_CopyCerIssued.ToUpper()) && !Convert.IsDBNull(reader[C_CopyCerIssued])) this.dtmCopyCerIssued = Convert.ToDateTime(reader[C_CopyCerIssued]);
                    if (reader.GetName(i).ToUpper().Equals(C_ResultReview.ToUpper()) && !Convert.IsDBNull(reader[C_ResultReview])) this.intResultReview = Convert.ToInt32(reader[C_ResultReview]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialType.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialType])) this.intSpecialType = Convert.ToInt32(reader[C_SpecialType]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_GraduationResult", objEx);
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
                if (!Convert.IsDBNull(drw[C_GraduationResultID])) this.lngGraduationResultID = Convert.ToInt64(drw[C_GraduationResultID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_ExamDateID])) this.intExamDateID = Convert.ToInt32(drw[C_ExamDateID]);
                if (!Convert.IsDBNull(drw[C_OrderExam])) this.intOrderExam = Convert.ToInt32(drw[C_OrderExam]);
                if (!Convert.IsDBNull(drw[C_HaveExamRegister1])) this.bolHaveExamRegister1 = Convert.ToBoolean(drw[C_HaveExamRegister1]);
                if (!Convert.IsDBNull(drw[C_HaveExamRegister2])) this.bolHaveExamRegister2 = Convert.ToBoolean(drw[C_HaveExamRegister2]);
                if (!Convert.IsDBNull(drw[C_HaveExamRegister3])) this.bolHaveExamRegister3 = Convert.ToBoolean(drw[C_HaveExamRegister3]);
                if (!Convert.IsDBNull(drw[C_Money])) this.dblMoney = Convert.ToDouble(drw[C_Money]);
                if (!Convert.IsDBNull(drw[C_DecisionNo])) this.strDecisionNo = Convert.ToString(drw[C_DecisionNo]);
                if (!Convert.IsDBNull(drw[C_Signingdate])) this.dtmSigningdate = Convert.ToDateTime(drw[C_Signingdate]);
                if (!Convert.IsDBNull(drw[C_Signer])) this.strSigner = Convert.ToString(drw[C_Signer]);
                if (!Convert.IsDBNull(drw[C_YearID])) this.intYearID = Convert.ToInt32(drw[C_YearID]);
                if (!Convert.IsDBNull(drw[C_SummaryLearningMark])) this.dblSummaryLearningMark = Convert.ToDouble(drw[C_SummaryLearningMark]);
                if (!Convert.IsDBNull(drw[C_SummaryLearningLevel])) this.strSummaryLearningLevel = Convert.ToString(drw[C_SummaryLearningLevel]);
                if (!Convert.IsDBNull(drw[C_GraduationExamAverage])) this.dblGraduationExamAverage = Convert.ToDouble(drw[C_GraduationExamAverage]);
                if (!Convert.IsDBNull(drw[C_GraduationRankingAverage])) this.dblGraduationRankingAverage = Convert.ToDouble(drw[C_GraduationRankingAverage]);
                if (!Convert.IsDBNull(drw[C_GraduationLevel])) this.strGraduationLevel = Convert.ToString(drw[C_GraduationLevel]);
                if (!Convert.IsDBNull(drw[C_Description])) this.strDescription = Convert.ToString(drw[C_Description]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                if (!Convert.IsDBNull(drw[C_Mark1])) this.dblMark1 = Convert.ToDouble(drw[C_Mark1]);
                if (!Convert.IsDBNull(drw[C_Mark2])) this.dblMark2 = Convert.ToDouble(drw[C_Mark2]);
                if (!Convert.IsDBNull(drw[C_Mark3])) this.dblMark3 = Convert.ToDouble(drw[C_Mark3]);
                if (!Convert.IsDBNull(drw[C_CerNo])) this.strCerNo = Convert.ToString(drw[C_CerNo]);
                if (!Convert.IsDBNull(drw[C_CerIssued])) this.dtmCerIssued = Convert.ToDateTime(drw[C_CerIssued]);
                if (!Convert.IsDBNull(drw[C_CopyCerNo])) this.strCopyCerNo = Convert.ToString(drw[C_CopyCerNo]);
                if (!Convert.IsDBNull(drw[C_CopyCerIssued])) this.dtmCopyCerIssued = Convert.ToDateTime(drw[C_CopyCerIssued]);
                if (!Convert.IsDBNull(drw[C_ResultReview])) this.intResultReview = Convert.ToInt32(drw[C_ResultReview]);
                if (!Convert.IsDBNull(drw[C_SpecialType])) this.intSpecialType = Convert.ToInt32(drw[C_SpecialType]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_GraduationResult", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_GraduationResult_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_GET");
                objIData.AddParameter(P_GraduationResultID, this.lngGraduationResultID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_GraduationResult", objEx);
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
        /// Store: SIM_GraduationResult_GET 
        ///</summary>
        /// <returns> SIM_GraduationResult </returns>
        public SIM_GraduationResult Get(long? lngGraduationResultID)
        {
            SIM_GraduationResult obj = new SIM_GraduationResult();
            if (objIData != null)
                obj.IDB = objIData;
            obj.GraduationResultID = lngGraduationResultID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_GraduationResult
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_GraduationResult", objEx);
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
        /// Search : SIM_GraduationResult
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_GraduationResult", objEx);
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
        /// Search : SIM_GraduationResult
        /// Lấy hết dữ liệu
        /// Store: SIM_GraduationResult_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_GraduationResult_GETALL");
        }

        ///<summary>
        /// Search : SIM_GraduationResult
        /// Tìm dữ liệu
        /// Store: SIM_GraduationResult_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_GraduationResult_SEARCH", pars);
        }
        ///<summary>
        /// Search : SIM_GraduationResult_SEARCH_VH
        /// Tìm dữ liệu
        /// Store: SIM_GraduationResult_SEARCH_VH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search_VH(params object[] pars)
        {
            return GetDataTable("SIM_GraduationResult_SEARCH_VH", pars);
        }
        ///<summary>
        /// Add : SIM_GraduationResult
        /// Thêm dữ liệu
        /// Store: SIM_GraduationResult_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_OrderExam, this.intOrderExam);
                objIData.AddParameter(P_HaveExamRegister1, this.bolHaveExamRegister1);
                objIData.AddParameter(P_HaveExamRegister2, this.bolHaveExamRegister2);
                objIData.AddParameter(P_HaveExamRegister3, this.bolHaveExamRegister3);
                objIData.AddParameter(P_Money, this.dblMoney);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_Signingdate, this.dtmSigningdate);
                objIData.AddParameter(P_Signer, this.strSigner);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_SummaryLearningMark, this.dblSummaryLearningMark);
                objIData.AddParameter(P_SummaryLearningLevel, this.strSummaryLearningLevel);
                objIData.AddParameter(P_GraduationExamAverage, this.dblGraduationExamAverage);
                objIData.AddParameter(P_GraduationRankingAverage, this.dblGraduationRankingAverage);
                objIData.AddParameter(P_GraduationLevel, this.strGraduationLevel);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_CerNo, this.strCerNo);
                objIData.AddParameter(P_CerIssued, this.dtmCerIssued);
                objIData.AddParameter(P_CopyCerNo, this.strCopyCerNo);
                objIData.AddParameter(P_CopyCerIssued, this.dtmCopyCerIssued);
                objIData.AddParameter(P_ResultReview, this.intResultReview);
                objIData.AddParameter(P_SpecialType, this.intSpecialType);
                this.lngGraduationResultID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_GraduationResult", objEx);
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
        /// Update : SIM_GraduationResult
        /// Cập nhật dữ liệu
        /// Store: SIM_GraduationResult_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_EDIT");
                objIData.AddParameter(P_GraduationResultID, this.lngGraduationResultID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_ExamDateID, this.intExamDateID);
                objIData.AddParameter(P_OrderExam, this.intOrderExam);
                objIData.AddParameter(P_HaveExamRegister1, this.bolHaveExamRegister1);
                objIData.AddParameter(P_HaveExamRegister2, this.bolHaveExamRegister2);
                objIData.AddParameter(P_HaveExamRegister3, this.bolHaveExamRegister3);
                objIData.AddParameter(P_Money, this.dblMoney);
                objIData.AddParameter(P_DecisionNo, this.strDecisionNo);
                objIData.AddParameter(P_Signingdate, this.dtmSigningdate);
                objIData.AddParameter(P_Signer, this.strSigner);
                objIData.AddParameter(P_YearID, this.intYearID);
                objIData.AddParameter(P_SummaryLearningMark, this.dblSummaryLearningMark);
                objIData.AddParameter(P_SummaryLearningLevel, this.strSummaryLearningLevel);
                objIData.AddParameter(P_GraduationExamAverage, this.dblGraduationExamAverage);
                objIData.AddParameter(P_GraduationRankingAverage, this.dblGraduationRankingAverage);
                objIData.AddParameter(P_GraduationLevel, this.strGraduationLevel);
                objIData.AddParameter(P_Description, this.strDescription);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_CerNo, this.strCerNo);
                objIData.AddParameter(P_CerIssued, this.dtmCerIssued);
                objIData.AddParameter(P_CopyCerNo, this.strCopyCerNo);
                objIData.AddParameter(P_CopyCerIssued, this.dtmCopyCerIssued);
                objIData.AddParameter(P_ResultReview, this.intResultReview);
                objIData.AddParameter(P_SpecialType, this.intSpecialType);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_GraduationResult", objEx);
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
        /// Delete : SIM_GraduationResult
        /// Xóa dữ liệu
        /// Store: SIM_GraduationResult_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_GraduationResult_DELETE");
                objIData.AddParameter(P_GraduationResultID, this.lngGraduationResultID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_GraduationResult", objEx);
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
        /// Store: SIM_GraduationResult_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngGraduationResultID)
        {
            this.lngGraduationResultID = lngGraduationResultID;
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

        public SIM_GraduationResult()
        {
        }
        public SIM_GraduationResult(long? lngGraduationResultID)
        {
            this.lngGraduationResultID = lngGraduationResultID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_GraduationResultID = "@" + C_GraduationResultID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_ExamDateID = "@" + C_ExamDateID;
        public const String P_OrderExam = "@" + C_OrderExam;
        public const String P_HaveExamRegister1 = "@" + C_HaveExamRegister1;
        public const String P_HaveExamRegister2 = "@" + C_HaveExamRegister2;
        public const String P_HaveExamRegister3 = "@" + C_HaveExamRegister3;
        public const String P_Money = "@" + C_Money;
        public const String P_DecisionNo = "@" + C_DecisionNo;
        public const String P_Signingdate = "@" + C_Signingdate;
        public const String P_Signer = "@" + C_Signer;
        public const String P_YearID = "@" + C_YearID;
        public const String P_SummaryLearningMark = "@" + C_SummaryLearningMark;
        public const String P_SummaryLearningLevel = "@" + C_SummaryLearningLevel;
        public const String P_GraduationExamAverage = "@" + C_GraduationExamAverage;
        public const String P_GraduationRankingAverage = "@" + C_GraduationRankingAverage;
        public const String P_GraduationLevel = "@" + C_GraduationLevel;
        public const String P_Description = "@" + C_Description;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;
        public const String P_Mark1 = "@" + C_Mark1;
        public const String P_Mark2 = "@" + C_Mark2;
        public const String P_Mark3 = "@" + C_Mark3;
        public const String P_CerNo = "@" + C_CerNo;
        public const String P_CerIssued = "@" + C_CerIssued;
        public const String P_CopyCerNo = "@" + C_CopyCerNo;
        public const String P_CopyCerIssued = "@" + C_CopyCerIssued;
        public const String P_ResultReview = "@" + C_ResultReview;
        public const String P_SpecialType = "@" + C_SpecialType;

        #endregion //Parameter names

        #region Column Names

        public const String C_GraduationResultID = "GraduationResultID";
        public const String C_StudentID = "StudentID";
        public const String C_ExamDateID = "ExamDateID";
        public const String C_OrderExam = "OrderExam";
        public const String C_HaveExamRegister1 = "HaveExamRegister1";
        public const String C_HaveExamRegister2 = "HaveExamRegister2";
        public const String C_HaveExamRegister3 = "HaveExamRegister3";
        public const String C_Money = "Money";
        public const String C_DecisionNo = "DecisionNo";
        public const String C_Signingdate = "Signingdate";
        public const String C_Signer = "Signer";
        public const String C_YearID = "YearID";
        public const String C_SummaryLearningMark = "SummaryLearningMark";
        public const String C_SummaryLearningLevel = "SummaryLearningLevel";
        public const String C_GraduationExamAverage = "GraduationExamAverage";
        public const String C_GraduationRankingAverage = "GraduationRankingAverage";
        public const String C_GraduationLevel = "GraduationLevel";
        public const String C_Description = "Description";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";
        public const String C_Mark1 = "Mark1";
        public const String C_Mark2 = "Mark2";
        public const String C_Mark3 = "Mark3";
        public const String C_CerNo = "CerNo";
        public const String C_CerIssued = "CerIssued";
        public const String C_CopyCerNo = "CopyCerNo";
        public const String C_CopyCerIssued = "CopyCerIssued";
        public const String C_ResultReview = "ResultReview";
        public const String C_SpecialType = "SpecialType";

        #endregion //Column names

        #endregion Variable Static
    }
}


