
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
    /// Created date 	: 09/04/2020 
    /// Description 
    /// </summary>	
    public partial class WEB_StudentCollection
    {
        #region Member Variables

        private long? lngStudentCollectionID = null;
        private string strFullName = null;
        private int? intBirthDay = null;
        private int? intBirthMonth = null;
        private int? intBirthYear = null;
        private string strBirthDateText = null;
        private string strPersonID = null;
        private string strTel = null;//Điện thoại thí sinh
        private string strTel2 = null;//Điện thoại phụ huynh
        private string strEmail = null;
        private string strFacebook = null;
        private int? intLearningLevelID = null;//Trình độ tốt nghiệp (đã tốt nghiệp bậc học): THCS, THPT, TC, ĐH, CĐ
        private string strSchoolName = null;//Trường học đã tốt nghiệp
        private string strSchoolName2 = null;//Trường học đã tốt nghiệp THCS
        private string strYearFinish = null;//Năm tốt nghiệp
        private string strTrainingLevelID = null;//Bậc đào tạo
        private string strSpecialBranchID1 = null;
        private string strSpecialBranchID2 = null;
        private string strAddress = null;
        private DateTime? dtmCreatedDate = null;
        private bool bolIsRegisterOnline = false;//Là đăng ký online. Để phân biệt với trắc nghiệp nghề nghiệp
        private bool bolChecked1 = false;
        private bool bolChecked2 = false;
        private bool bolChecked3 = false;
        private bool bolChecked4 = false;
        private bool bolChecked5 = false;
        private int? intStudentCollectionStatusID = null;//0: hồ sơ chưa xử lý, 1: hồ sơ đã xứ lý
        private string strDiplomaImage = null;
        private bool bolGender = false;//Giới tính
        private string strBirthPlace = null;//Nơi sinh
        private string strWorkingPlace = null;//Nơi làm việc, đơn vị công tác
        private string strGraduationSpecialBranch = null;// Tên ngành đã tốt nghiệp (cho việc dự tuyển liên thông sau đại học, văn bằng 2...)
        private double? dblMark1 = null;//Điểm thi tuyển sinh môn 1
        private double? dblMark2 = null;//Điểm thi tuyển sinh môn 2
        private double? dblMark3 = null;//Điểm thi tuyển sinh môn 3
        private double? dblMark4 = null;//Điểm thi môn 4
        private double? dblMark5 = null;//HK 1 lớp 12 (đã tốt nghiệp)
        private double? dblMark6 = null;//HK 2 lớp 12 (đã tốt nghiệp)
        private double? dblMark7 = null;//Cả năm lớp 12 (đã tốt nghiệp)
        private double? dblSummaryMark = null;//Tổng điểm xét tuyển
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// StudentCollectionID
        /// 
        /// </summary>
        public long? StudentCollectionID
        {
            get { return lngStudentCollectionID; }
            set { lngStudentCollectionID = value; }
        }
        /// <summary>
        /// FullName
        /// 
        /// </summary>
        public string FullName
        {
            get { return strFullName; }
            set { strFullName = value; }
        }
        /// <summary>
        /// BirthDay
        /// 
        /// </summary>
        public int? BirthDay
        {
            get { return intBirthDay; }
            set { intBirthDay = value; }
        }
        /// <summary>
        /// BirthMonth
        /// 
        /// </summary>
        public int? BirthMonth
        {
            get { return intBirthMonth; }
            set { intBirthMonth = value; }
        }
        /// <summary>
        /// BirthYear
        /// 
        /// </summary>
        public int? BirthYear
        {
            get { return intBirthYear; }
            set { intBirthYear = value; }
        }
        /// <summary>
        /// BirthDateText
        /// 
        /// </summary>
        public string BirthDateText
        {
            get { return strBirthDateText; }
            set { strBirthDateText = value; }
        }
        /// <summary>
        /// PersonID
        /// 
        /// </summary>
        public string PersonID
        {
            get { return strPersonID; }
            set { strPersonID = value; }
        }
        /// <summary>
        /// Tel
        /// Điện thoại thí sinh
        /// </summary>
        public string Tel
        {
            get { return strTel; }
            set { strTel = value; }
        }
        /// <summary>
        /// Tel2
        /// Điện thoại phụ huynh
        /// </summary>
        public string Tel2
        {
            get { return strTel2; }
            set { strTel2 = value; }
        }
        /// <summary>
        /// Email
        /// 
        /// </summary>
        public string Email
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        /// <summary>
        /// Facebook
        /// 
        /// </summary>
        public string Facebook
        {
            get { return strFacebook; }
            set { strFacebook = value; }
        }
        /// <summary>
        /// LearningLevelID
        /// Trình độ tốt nghiệp (đã tốt nghiệp bậc học): THCS, THPT, TC, ĐH, CĐ
        /// </summary>
        public int? LearningLevelID
        {
            get { return intLearningLevelID; }
            set { intLearningLevelID = value; }
        }
        /// <summary>
        /// SchoolName
        /// Trường học đã tốt nghiệp
        /// </summary>
        public string SchoolName
        {
            get { return strSchoolName; }
            set { strSchoolName = value; }
        }
        /// <summary>
        /// SchoolName2
        /// Trường học đã tốt nghiệp THCS
        /// </summary>
        public string SchoolName2
        {
            get { return strSchoolName2; }
            set { strSchoolName2 = value; }
        }
        /// <summary>
        /// YearFinish
        /// Năm tốt nghiệp
        /// </summary>
        public string YearFinish
        {
            get { return strYearFinish; }
            set { strYearFinish = value; }
        }
        /// <summary>
        /// TrainingLevelID
        /// Bậc đào tạo
        /// </summary>
        public string TrainingLevelID
        {
            get { return strTrainingLevelID; }
            set { strTrainingLevelID = value; }
        }
        /// <summary>
        /// SpecialBranchID1
        /// 
        /// </summary>
        public string SpecialBranchID1
        {
            get { return strSpecialBranchID1; }
            set { strSpecialBranchID1 = value; }
        }
        /// <summary>
        /// SpecialBranchID2
        /// 
        /// </summary>
        public string SpecialBranchID2
        {
            get { return strSpecialBranchID2; }
            set { strSpecialBranchID2 = value; }
        }
        /// <summary>
        /// Address
        /// 
        /// </summary>
        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }
        }
        /// <summary>
        /// CreatedDate
        /// 
        /// </summary>
        public DateTime? CreatedDate
        {
            get { return dtmCreatedDate; }
            set { dtmCreatedDate = value; }
        }
        /// <summary>
        /// IsRegisterOnline
        /// Là đăng ký online. Để phân biệt với trắc nghiệp nghề nghiệp
        /// </summary>
        public bool IsRegisterOnline
        {
            get { return bolIsRegisterOnline; }
            set { bolIsRegisterOnline = value; }
        }
        /// <summary>
        /// Checked1
        /// 
        /// </summary>
        public bool Checked1
        {
            get { return bolChecked1; }
            set { bolChecked1 = value; }
        }
        /// <summary>
        /// Checked2
        /// 
        /// </summary>
        public bool Checked2
        {
            get { return bolChecked2; }
            set { bolChecked2 = value; }
        }
        /// <summary>
        /// Checked3
        /// 
        /// </summary>
        public bool Checked3
        {
            get { return bolChecked3; }
            set { bolChecked3 = value; }
        }
        /// <summary>
        /// Checked4
        /// 
        /// </summary>
        public bool Checked4
        {
            get { return bolChecked4; }
            set { bolChecked4 = value; }
        }
        /// <summary>
        /// Checked5
        /// 
        /// </summary>
        public bool Checked5
        {
            get { return bolChecked5; }
            set { bolChecked5 = value; }
        }
        /// <summary>
        /// StudentCollectionStatusID
        /// 0: hồ sơ chưa xử lý, 1: hồ sơ đã xứ lý
        /// </summary>
        public int? StudentCollectionStatusID
        {
            get { return intStudentCollectionStatusID; }
            set { intStudentCollectionStatusID = value; }
        }
        /// <summary>
        /// DiplomaImage
        /// 
        /// </summary>
        public string DiplomaImage
        {
            get { return strDiplomaImage; }
            set { strDiplomaImage = value; }
        }
        /// <summary>
        /// Gender
        /// Giới tính
        /// </summary>
        public bool Gender
        {
            get { return bolGender; }
            set { bolGender = value; }
        }
        /// <summary>
        /// BirthPlace
        /// Nơi sinh
        /// </summary>
        public string BirthPlace
        {
            get { return strBirthPlace; }
            set { strBirthPlace = value; }
        }
        /// <summary>
        /// WorkingPlace
        /// Nơi làm việc, đơn vị công tác
        /// </summary>
        public string WorkingPlace
        {
            get { return strWorkingPlace; }
            set { strWorkingPlace = value; }
        }
        /// <summary>
        /// GraduationSpecialBranch
        ///  Tên ngành đã tốt nghiệp (cho việc dự tuyển liên thông sau đại học, văn bằng 2...)
        /// </summary>
        public string GraduationSpecialBranch
        {
            get { return strGraduationSpecialBranch; }
            set { strGraduationSpecialBranch = value; }
        }
        /// <summary>
        /// Mark1
        /// Điểm thi tuyển sinh môn 1
        /// </summary>
        public double? Mark1
        {
            get { return dblMark1; }
            set { dblMark1 = value; }
        }
        /// <summary>
        /// Mark2
        /// Điểm thi tuyển sinh môn 2
        /// </summary>
        public double? Mark2
        {
            get { return dblMark2; }
            set { dblMark2 = value; }
        }
        /// <summary>
        /// Mark3
        /// Điểm thi tuyển sinh môn 3
        /// </summary>
        public double? Mark3
        {
            get { return dblMark3; }
            set { dblMark3 = value; }
        }
        /// <summary>
        /// Mark4
        /// Điểm thi môn 4
        /// </summary>
        public double? Mark4
        {
            get { return dblMark4; }
            set { dblMark4 = value; }
        }
        /// <summary>
        /// Mark5
        /// HK 1 lớp 12 (đã tốt nghiệp)
        /// </summary>
        public double? Mark5
        {
            get { return dblMark5; }
            set { dblMark5 = value; }
        }
        /// <summary>
        /// Mark6
        /// HK 2 lớp 12 (đã tốt nghiệp)
        /// </summary>
        public double? Mark6
        {
            get { return dblMark6; }
            set { dblMark6 = value; }
        }
        /// <summary>
        /// Mark7
        /// Cả năm lớp 12 (đã tốt nghiệp)
        /// </summary>
        public double? Mark7
        {
            get { return dblMark7; }
            set { dblMark7 = value; }
        }
        /// <summary>
        /// SummaryMark
        /// Tổng điểm xét tuyển
        /// </summary>
        public double? SummaryMark
        {
            get { return dblSummaryMark; }
            set { dblSummaryMark = value; }
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
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionID])) this.lngStudentCollectionID = Convert.ToInt64(reader[C_StudentCollectionID]);
                    if (reader.GetName(i).ToUpper().Equals(C_FullName.ToUpper()) && !Convert.IsDBNull(reader[C_FullName])) this.strFullName = Convert.ToString(reader[C_FullName]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDay.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDay])) this.intBirthDay = Convert.ToInt32(reader[C_BirthDay]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthMonth.ToUpper()) && !Convert.IsDBNull(reader[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(reader[C_BirthMonth]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthYear.ToUpper()) && !Convert.IsDBNull(reader[C_BirthYear])) this.intBirthYear = Convert.ToInt32(reader[C_BirthYear]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthDateText.ToUpper()) && !Convert.IsDBNull(reader[C_BirthDateText])) this.strBirthDateText = Convert.ToString(reader[C_BirthDateText]);
                    if (reader.GetName(i).ToUpper().Equals(C_PersonID.ToUpper()) && !Convert.IsDBNull(reader[C_PersonID])) this.strPersonID = Convert.ToString(reader[C_PersonID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Tel.ToUpper()) && !Convert.IsDBNull(reader[C_Tel])) this.strTel = Convert.ToString(reader[C_Tel]);
                    if (reader.GetName(i).ToUpper().Equals(C_Tel2.ToUpper()) && !Convert.IsDBNull(reader[C_Tel2])) this.strTel2 = Convert.ToString(reader[C_Tel2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Email.ToUpper()) && !Convert.IsDBNull(reader[C_Email])) this.strEmail = Convert.ToString(reader[C_Email]);
                    if (reader.GetName(i).ToUpper().Equals(C_Facebook.ToUpper()) && !Convert.IsDBNull(reader[C_Facebook])) this.strFacebook = Convert.ToString(reader[C_Facebook]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevelID])) this.intLearningLevelID = Convert.ToInt32(reader[C_LearningLevelID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SchoolName.ToUpper()) && !Convert.IsDBNull(reader[C_SchoolName])) this.strSchoolName = Convert.ToString(reader[C_SchoolName]);
                    if (reader.GetName(i).ToUpper().Equals(C_SchoolName2.ToUpper()) && !Convert.IsDBNull(reader[C_SchoolName2])) this.strSchoolName2 = Convert.ToString(reader[C_SchoolName2]);
                    if (reader.GetName(i).ToUpper().Equals(C_YearFinish.ToUpper()) && !Convert.IsDBNull(reader[C_YearFinish])) this.strYearFinish = Convert.ToString(reader[C_YearFinish]);
                    if (reader.GetName(i).ToUpper().Equals(C_TrainingLevelID.ToUpper()) && !Convert.IsDBNull(reader[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(reader[C_TrainingLevelID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID1.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID1])) this.strSpecialBranchID1 = Convert.ToString(reader[C_SpecialBranchID1]);
                    if (reader.GetName(i).ToUpper().Equals(C_SpecialBranchID2.ToUpper()) && !Convert.IsDBNull(reader[C_SpecialBranchID2])) this.strSpecialBranchID2 = Convert.ToString(reader[C_SpecialBranchID2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Address.ToUpper()) && !Convert.IsDBNull(reader[C_Address])) this.strAddress = Convert.ToString(reader[C_Address]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsRegisterOnline.ToUpper()) && !Convert.IsDBNull(reader[C_IsRegisterOnline])) this.bolIsRegisterOnline = Convert.ToBoolean(reader[C_IsRegisterOnline]);
                    if (reader.GetName(i).ToUpper().Equals(C_Checked1.ToUpper()) && !Convert.IsDBNull(reader[C_Checked1])) this.bolChecked1 = Convert.ToBoolean(reader[C_Checked1]);
                    if (reader.GetName(i).ToUpper().Equals(C_Checked2.ToUpper()) && !Convert.IsDBNull(reader[C_Checked2])) this.bolChecked2 = Convert.ToBoolean(reader[C_Checked2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Checked3.ToUpper()) && !Convert.IsDBNull(reader[C_Checked3])) this.bolChecked3 = Convert.ToBoolean(reader[C_Checked3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Checked4.ToUpper()) && !Convert.IsDBNull(reader[C_Checked4])) this.bolChecked4 = Convert.ToBoolean(reader[C_Checked4]);
                    if (reader.GetName(i).ToUpper().Equals(C_Checked5.ToUpper()) && !Convert.IsDBNull(reader[C_Checked5])) this.bolChecked5 = Convert.ToBoolean(reader[C_Checked5]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentCollectionStatusID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentCollectionStatusID])) this.intStudentCollectionStatusID = Convert.ToInt32(reader[C_StudentCollectionStatusID]);
                    if (reader.GetName(i).ToUpper().Equals(C_DiplomaImage.ToUpper()) && !Convert.IsDBNull(reader[C_DiplomaImage])) this.strDiplomaImage = Convert.ToString(reader[C_DiplomaImage]);
                    if (reader.GetName(i).ToUpper().Equals(C_Gender.ToUpper()) && !Convert.IsDBNull(reader[C_Gender])) this.bolGender = Convert.ToBoolean(reader[C_Gender]);
                    if (reader.GetName(i).ToUpper().Equals(C_BirthPlace.ToUpper()) && !Convert.IsDBNull(reader[C_BirthPlace])) this.strBirthPlace = Convert.ToString(reader[C_BirthPlace]);
                    if (reader.GetName(i).ToUpper().Equals(C_WorkingPlace.ToUpper()) && !Convert.IsDBNull(reader[C_WorkingPlace])) this.strWorkingPlace = Convert.ToString(reader[C_WorkingPlace]);
                    if (reader.GetName(i).ToUpper().Equals(C_GraduationSpecialBranch.ToUpper()) && !Convert.IsDBNull(reader[C_GraduationSpecialBranch])) this.strGraduationSpecialBranch = Convert.ToString(reader[C_GraduationSpecialBranch]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark1.ToUpper()) && !Convert.IsDBNull(reader[C_Mark1])) this.dblMark1 = Convert.ToDouble(reader[C_Mark1]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark2.ToUpper()) && !Convert.IsDBNull(reader[C_Mark2])) this.dblMark2 = Convert.ToDouble(reader[C_Mark2]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark3.ToUpper()) && !Convert.IsDBNull(reader[C_Mark3])) this.dblMark3 = Convert.ToDouble(reader[C_Mark3]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark4.ToUpper()) && !Convert.IsDBNull(reader[C_Mark4])) this.dblMark4 = Convert.ToDouble(reader[C_Mark4]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark5.ToUpper()) && !Convert.IsDBNull(reader[C_Mark5])) this.dblMark5 = Convert.ToDouble(reader[C_Mark5]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark6.ToUpper()) && !Convert.IsDBNull(reader[C_Mark6])) this.dblMark6 = Convert.ToDouble(reader[C_Mark6]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark7.ToUpper()) && !Convert.IsDBNull(reader[C_Mark7])) this.dblMark7 = Convert.ToDouble(reader[C_Mark7]);
                    if (reader.GetName(i).ToUpper().Equals(C_SummaryMark.ToUpper()) && !Convert.IsDBNull(reader[C_SummaryMark])) this.dblSummaryMark = Convert.ToDouble(reader[C_SummaryMark]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong WEB_StudentCollection", objEx);
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
                if (!Convert.IsDBNull(drw[C_StudentCollectionID])) this.lngStudentCollectionID = Convert.ToInt64(drw[C_StudentCollectionID]);
                if (!Convert.IsDBNull(drw[C_FullName])) this.strFullName = Convert.ToString(drw[C_FullName]);
                if (!Convert.IsDBNull(drw[C_BirthDay])) this.intBirthDay = Convert.ToInt32(drw[C_BirthDay]);
                if (!Convert.IsDBNull(drw[C_BirthMonth])) this.intBirthMonth = Convert.ToInt32(drw[C_BirthMonth]);
                if (!Convert.IsDBNull(drw[C_BirthYear])) this.intBirthYear = Convert.ToInt32(drw[C_BirthYear]);
                if (!Convert.IsDBNull(drw[C_BirthDateText])) this.strBirthDateText = Convert.ToString(drw[C_BirthDateText]);
                if (!Convert.IsDBNull(drw[C_PersonID])) this.strPersonID = Convert.ToString(drw[C_PersonID]);
                if (!Convert.IsDBNull(drw[C_Tel])) this.strTel = Convert.ToString(drw[C_Tel]);
                if (!Convert.IsDBNull(drw[C_Tel2])) this.strTel2 = Convert.ToString(drw[C_Tel2]);
                if (!Convert.IsDBNull(drw[C_Email])) this.strEmail = Convert.ToString(drw[C_Email]);
                if (!Convert.IsDBNull(drw[C_Facebook])) this.strFacebook = Convert.ToString(drw[C_Facebook]);
                if (!Convert.IsDBNull(drw[C_LearningLevelID])) this.intLearningLevelID = Convert.ToInt32(drw[C_LearningLevelID]);
                if (!Convert.IsDBNull(drw[C_SchoolName])) this.strSchoolName = Convert.ToString(drw[C_SchoolName]);
                if (!Convert.IsDBNull(drw[C_SchoolName2])) this.strSchoolName2 = Convert.ToString(drw[C_SchoolName2]);
                if (!Convert.IsDBNull(drw[C_YearFinish])) this.strYearFinish = Convert.ToString(drw[C_YearFinish]);
                if (!Convert.IsDBNull(drw[C_TrainingLevelID])) this.strTrainingLevelID = Convert.ToString(drw[C_TrainingLevelID]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID1])) this.strSpecialBranchID1 = Convert.ToString(drw[C_SpecialBranchID1]);
                if (!Convert.IsDBNull(drw[C_SpecialBranchID2])) this.strSpecialBranchID2 = Convert.ToString(drw[C_SpecialBranchID2]);
                if (!Convert.IsDBNull(drw[C_Address])) this.strAddress = Convert.ToString(drw[C_Address]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_IsRegisterOnline])) this.bolIsRegisterOnline = Convert.ToBoolean(drw[C_IsRegisterOnline]);
                if (!Convert.IsDBNull(drw[C_Checked1])) this.bolChecked1 = Convert.ToBoolean(drw[C_Checked1]);
                if (!Convert.IsDBNull(drw[C_Checked2])) this.bolChecked2 = Convert.ToBoolean(drw[C_Checked2]);
                if (!Convert.IsDBNull(drw[C_Checked3])) this.bolChecked3 = Convert.ToBoolean(drw[C_Checked3]);
                if (!Convert.IsDBNull(drw[C_Checked4])) this.bolChecked4 = Convert.ToBoolean(drw[C_Checked4]);
                if (!Convert.IsDBNull(drw[C_Checked5])) this.bolChecked5 = Convert.ToBoolean(drw[C_Checked5]);
                if (!Convert.IsDBNull(drw[C_StudentCollectionStatusID])) this.intStudentCollectionStatusID = Convert.ToInt32(drw[C_StudentCollectionStatusID]);
                if (!Convert.IsDBNull(drw[C_DiplomaImage])) this.strDiplomaImage = Convert.ToString(drw[C_DiplomaImage]);
                if (!Convert.IsDBNull(drw[C_Gender])) this.bolGender = Convert.ToBoolean(drw[C_Gender]);
                if (!Convert.IsDBNull(drw[C_BirthPlace])) this.strBirthPlace = Convert.ToString(drw[C_BirthPlace]);
                if (!Convert.IsDBNull(drw[C_WorkingPlace])) this.strWorkingPlace = Convert.ToString(drw[C_WorkingPlace]);
                if (!Convert.IsDBNull(drw[C_GraduationSpecialBranch])) this.strGraduationSpecialBranch = Convert.ToString(drw[C_GraduationSpecialBranch]);
                if (!Convert.IsDBNull(drw[C_Mark1])) this.dblMark1 = Convert.ToDouble(drw[C_Mark1]);
                if (!Convert.IsDBNull(drw[C_Mark2])) this.dblMark2 = Convert.ToDouble(drw[C_Mark2]);
                if (!Convert.IsDBNull(drw[C_Mark3])) this.dblMark3 = Convert.ToDouble(drw[C_Mark3]);
                if (!Convert.IsDBNull(drw[C_Mark4])) this.dblMark4 = Convert.ToDouble(drw[C_Mark4]);
                if (!Convert.IsDBNull(drw[C_Mark5])) this.dblMark5 = Convert.ToDouble(drw[C_Mark5]);
                if (!Convert.IsDBNull(drw[C_Mark6])) this.dblMark6 = Convert.ToDouble(drw[C_Mark6]);
                if (!Convert.IsDBNull(drw[C_Mark7])) this.dblMark7 = Convert.ToDouble(drw[C_Mark7]);
                if (!Convert.IsDBNull(drw[C_SummaryMark])) this.dblSummaryMark = Convert.ToDouble(drw[C_SummaryMark]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong WEB_StudentCollection", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: WEB_StudentCollection_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("WEB_StudentCollection_GET");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin WEB_StudentCollection", objEx);
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
        /// Store: WEB_StudentCollection_GET 
        ///</summary>
        /// <returns> WEB_StudentCollection </returns>
        public WEB_StudentCollection Get(long? lngStudentCollectionID)
        {
            WEB_StudentCollection obj = new WEB_StudentCollection();
            if (objIData != null)
                obj.IDB = objIData;
            obj.StudentCollectionID = lngStudentCollectionID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : WEB_StudentCollection
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong WEB_StudentCollection", objEx);
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
        /// Search : WEB_StudentCollection
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong WEB_StudentCollection", objEx);
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
        /// Search : WEB_StudentCollection
        /// Lấy hết dữ liệu
        /// Store: WEB_StudentCollection_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("WEB_StudentCollection_GETALL");
        }

        ///<summary>
        /// Search : WEB_StudentCollection
        /// Tìm dữ liệu
        /// Store: WEB_StudentCollection_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("WEB_StudentCollection_SEARCH", pars);
        }

        ///<summary>
        /// Add : WEB_StudentCollection
        /// Thêm dữ liệu
        /// Store: WEB_StudentCollection_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("WEB_StudentCollection_ADD");
                objIData.AddParameter(P_FullName, this.strFullName);
                objIData.AddParameter(P_BirthDay, this.intBirthDay);
                objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
                objIData.AddParameter(P_BirthYear, this.intBirthYear);
                objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
                objIData.AddParameter(P_PersonID, this.strPersonID);
                objIData.AddParameter(P_Tel, this.strTel);
                objIData.AddParameter(P_Tel2, this.strTel2);
                objIData.AddParameter(P_Email, this.strEmail);
                objIData.AddParameter(P_Facebook, this.strFacebook);
                objIData.AddParameter(P_LearningLevelID, this.intLearningLevelID);
                objIData.AddParameter(P_SchoolName, this.strSchoolName);
                objIData.AddParameter(P_SchoolName2, this.strSchoolName2);
                objIData.AddParameter(P_YearFinish, this.strYearFinish);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_SpecialBranchID1, this.strSpecialBranchID1);
                objIData.AddParameter(P_SpecialBranchID2, this.strSpecialBranchID2);
                objIData.AddParameter(P_Address, this.strAddress);
                objIData.AddParameter(P_IsRegisterOnline, this.bolIsRegisterOnline);
                objIData.AddParameter(P_Checked1, this.bolChecked1);
                objIData.AddParameter(P_Checked2, this.bolChecked2);
                objIData.AddParameter(P_Checked3, this.bolChecked3);
                objIData.AddParameter(P_Checked4, this.bolChecked4);
                objIData.AddParameter(P_Checked5, this.bolChecked5);
                objIData.AddParameter(P_StudentCollectionStatusID, this.intStudentCollectionStatusID);
                objIData.AddParameter(P_DiplomaImage, this.strDiplomaImage);
                objIData.AddParameter(P_Gender, this.bolGender);
                objIData.AddParameter(P_BirthPlace, this.strBirthPlace);
                objIData.AddParameter(P_WorkingPlace, this.strWorkingPlace);
                objIData.AddParameter(P_GraduationSpecialBranch, this.strGraduationSpecialBranch);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_Mark5, this.dblMark5);
                objIData.AddParameter(P_Mark6, this.dblMark6);
                objIData.AddParameter(P_Mark7, this.dblMark7);
                objIData.AddParameter(P_SummaryMark, this.dblSummaryMark);
                this.lngStudentCollectionID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin WEB_StudentCollection", objEx);
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
        /// Update : WEB_StudentCollection
        /// Cập nhật dữ liệu
        /// Store: WEB_StudentCollection_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("WEB_StudentCollection_EDIT");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
                objIData.AddParameter(P_FullName, this.strFullName);
                objIData.AddParameter(P_BirthDay, this.intBirthDay);
                objIData.AddParameter(P_BirthMonth, this.intBirthMonth);
                objIData.AddParameter(P_BirthYear, this.intBirthYear);
                objIData.AddParameter(P_BirthDateText, this.strBirthDateText);
                objIData.AddParameter(P_PersonID, this.strPersonID);
                objIData.AddParameter(P_Tel, this.strTel);
                objIData.AddParameter(P_Tel2, this.strTel2);
                objIData.AddParameter(P_Email, this.strEmail);
                objIData.AddParameter(P_Facebook, this.strFacebook);
                objIData.AddParameter(P_LearningLevelID, this.intLearningLevelID);
                objIData.AddParameter(P_SchoolName, this.strSchoolName);
                objIData.AddParameter(P_SchoolName2, this.strSchoolName2);
                objIData.AddParameter(P_YearFinish, this.strYearFinish);
                objIData.AddParameter(P_TrainingLevelID, this.strTrainingLevelID);
                objIData.AddParameter(P_SpecialBranchID1, this.strSpecialBranchID1);
                objIData.AddParameter(P_SpecialBranchID2, this.strSpecialBranchID2);
                objIData.AddParameter(P_Address, this.strAddress);
                objIData.AddParameter(P_IsRegisterOnline, this.bolIsRegisterOnline);
                objIData.AddParameter(P_Checked1, this.bolChecked1);
                objIData.AddParameter(P_Checked2, this.bolChecked2);
                objIData.AddParameter(P_Checked3, this.bolChecked3);
                objIData.AddParameter(P_Checked4, this.bolChecked4);
                objIData.AddParameter(P_Checked5, this.bolChecked5);
                objIData.AddParameter(P_StudentCollectionStatusID, this.intStudentCollectionStatusID);
                objIData.AddParameter(P_DiplomaImage, this.strDiplomaImage);
                objIData.AddParameter(P_Gender, this.bolGender);
                objIData.AddParameter(P_BirthPlace, this.strBirthPlace);
                objIData.AddParameter(P_WorkingPlace, this.strWorkingPlace);
                objIData.AddParameter(P_GraduationSpecialBranch, this.strGraduationSpecialBranch);
                objIData.AddParameter(P_Mark1, this.dblMark1);
                objIData.AddParameter(P_Mark2, this.dblMark2);
                objIData.AddParameter(P_Mark3, this.dblMark3);
                objIData.AddParameter(P_Mark4, this.dblMark4);
                objIData.AddParameter(P_Mark5, this.dblMark5);
                objIData.AddParameter(P_Mark6, this.dblMark6);
                objIData.AddParameter(P_Mark7, this.dblMark7);
                objIData.AddParameter(P_SummaryMark, this.dblSummaryMark);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin WEB_StudentCollection", objEx);
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
        /// Delete : WEB_StudentCollection
        /// Xóa dữ liệu
        /// Store: WEB_StudentCollection_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("WEB_StudentCollection_DELETE");
                objIData.AddParameter(P_StudentCollectionID, this.lngStudentCollectionID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin WEB_StudentCollection", objEx);
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
        /// Store: WEB_StudentCollection_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngStudentCollectionID)
        {
            this.lngStudentCollectionID = lngStudentCollectionID;
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

        public WEB_StudentCollection()
        {
        }
        public WEB_StudentCollection(long? lngStudentCollectionID)
        {
            this.lngStudentCollectionID = lngStudentCollectionID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_StudentCollectionID = "@" + C_StudentCollectionID;
        public const String P_FullName = "@" + C_FullName;
        public const String P_BirthDay = "@" + C_BirthDay;
        public const String P_BirthMonth = "@" + C_BirthMonth;
        public const String P_BirthYear = "@" + C_BirthYear;
        public const String P_BirthDateText = "@" + C_BirthDateText;
        public const String P_PersonID = "@" + C_PersonID;
        public const String P_Tel = "@" + C_Tel;
        public const String P_Tel2 = "@" + C_Tel2;
        public const String P_Email = "@" + C_Email;
        public const String P_Facebook = "@" + C_Facebook;
        public const String P_LearningLevelID = "@" + C_LearningLevelID;
        public const String P_SchoolName = "@" + C_SchoolName;
        public const String P_SchoolName2 = "@" + C_SchoolName2;
        public const String P_YearFinish = "@" + C_YearFinish;
        public const String P_TrainingLevelID = "@" + C_TrainingLevelID;
        public const String P_SpecialBranchID1 = "@" + C_SpecialBranchID1;
        public const String P_SpecialBranchID2 = "@" + C_SpecialBranchID2;
        public const String P_Address = "@" + C_Address;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_IsRegisterOnline = "@" + C_IsRegisterOnline;
        public const String P_Checked1 = "@" + C_Checked1;
        public const String P_Checked2 = "@" + C_Checked2;
        public const String P_Checked3 = "@" + C_Checked3;
        public const String P_Checked4 = "@" + C_Checked4;
        public const String P_Checked5 = "@" + C_Checked5;
        public const String P_StudentCollectionStatusID = "@" + C_StudentCollectionStatusID;
        public const String P_DiplomaImage = "@" + C_DiplomaImage;
        public const String P_Gender = "@" + C_Gender;
        public const String P_BirthPlace = "@" + C_BirthPlace;
        public const String P_WorkingPlace = "@" + C_WorkingPlace;
        public const String P_GraduationSpecialBranch = "@" + C_GraduationSpecialBranch;
        public const String P_Mark1 = "@" + C_Mark1;
        public const String P_Mark2 = "@" + C_Mark2;
        public const String P_Mark3 = "@" + C_Mark3;
        public const String P_Mark4 = "@" + C_Mark4;
        public const String P_Mark5 = "@" + C_Mark5;
        public const String P_Mark6 = "@" + C_Mark6;
        public const String P_Mark7 = "@" + C_Mark7;
        public const String P_SummaryMark = "@" + C_SummaryMark;

        #endregion //Parameter names

        #region Column Names

        public const String C_StudentCollectionID = "StudentCollectionID";
        public const String C_FullName = "FullName";
        public const String C_BirthDay = "BirthDay";
        public const String C_BirthMonth = "BirthMonth";
        public const String C_BirthYear = "BirthYear";
        public const String C_BirthDateText = "BirthDateText";
        public const String C_PersonID = "PersonID";
        public const String C_Tel = "Tel";
        public const String C_Tel2 = "Tel2";
        public const String C_Email = "Email";
        public const String C_Facebook = "Facebook";
        public const String C_LearningLevelID = "LearningLevelID";
        public const String C_SchoolName = "SchoolName";
        public const String C_SchoolName2 = "SchoolName2";
        public const String C_YearFinish = "YearFinish";
        public const String C_TrainingLevelID = "TrainingLevelID";
        public const String C_SpecialBranchID1 = "SpecialBranchID1";
        public const String C_SpecialBranchID2 = "SpecialBranchID2";
        public const String C_Address = "Address";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_IsRegisterOnline = "IsRegisterOnline";
        public const String C_Checked1 = "Checked1";
        public const String C_Checked2 = "Checked2";
        public const String C_Checked3 = "Checked3";
        public const String C_Checked4 = "Checked4";
        public const String C_Checked5 = "Checked5";
        public const String C_StudentCollectionStatusID = "StudentCollectionStatusID";
        public const String C_DiplomaImage = "DiplomaImage";
        public const String C_Gender = "Gender";
        public const String C_BirthPlace = "BirthPlace";
        public const String C_WorkingPlace = "WorkingPlace";
        public const String C_GraduationSpecialBranch = "GraduationSpecialBranch";
        public const String C_Mark1 = "Mark1";
        public const String C_Mark2 = "Mark2";
        public const String C_Mark3 = "Mark3";
        public const String C_Mark4 = "Mark4";
        public const String C_Mark5 = "Mark5";
        public const String C_Mark6 = "Mark6";
        public const String C_Mark7 = "Mark7";
        public const String C_SummaryMark = "SummaryMark";

        #endregion //Column names

        #endregion Variable Static
    }
}
