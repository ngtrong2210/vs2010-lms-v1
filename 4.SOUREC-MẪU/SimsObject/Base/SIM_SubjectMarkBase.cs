
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
	/// Created date 	: 15/4/2015 
	/// Description 
	/// </summary>	
    public partial class SIM_SubjectMark
    {
        #region Member Variables

        private long? lngSubjectMarkID = null;
        private long? lngStudentID = null;//Mã sinh viên
        private string strSubjectID = null;
        private int? intOrderLearning = null;//Lần học, khi học lại hoặc lưu ban
        private long? lngClassSubjectID = null;
        private double? dblMark11 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark12 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark13 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark14 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark15 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark16 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark17 = null;//Điểm kiểm tra hệ số 1
        private double? dblMark21 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark22 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark23 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark24 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark25 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark26 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark27 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark28 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark29 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark210 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark211 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark212 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark213 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark214 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark215 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark216 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark217 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark218 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark219 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark220 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark221 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark222 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark223 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark224 = null;//Điểm kiểm tra hệ số 2
        private double? dblMark225 = null;//Điểm kiểm tra hệ số 2
        private double? dblTestAverage = null;//Trung bình kiểm tra
        private double? dblTheoryExam1 = null;//Điểm thi lần 1
        private double? dblTheoryExam2 = null;//Điểm thi lần 1
        private double? dblTheoryExam3 = null;//Điểm thi lần 1
        private double? dblPracticeExam1 = null;//Điểm thi lần 1
        private double? dblPracticeExam2 = null;//Điểm thi lần 1
        private double? dblPracticeExam3 = null;//Điểm thi lần 1
        private double? dblExam1 = null;//Điểm thi lần 1
        private double? dblExam2 = null;//Điểm thi lần 2
        private double? dblExam3 = null;//Thi lần 3. Thường dùng cho điểm thi tốt nghiệp
        private double? dblSummary1 = null;//Tổng kết môn với lần thi 1
        private double? dblSummary2 = null;//Tổng kết môn với lần thi 2
        private double? dblSummary3 = null;//Tổng kết môn với lần thi 3
        private double? dblFinalSummary = null;//Tổng kết môn cuối cùng
        private long? lngOldClassSubjectID = null;//Mã môn học lớp cũ mà sinh viên học môn này
        private bool bolHaveExamRegister = false;//Có đăng ký dự thi tốt nghiệp
        private int? intPassed = null;//Đã đạt hay chưa? Null là chưa xét, 1. là đạt, 0 là chưa đạt
        private bool bolNotAllowExam = false;//Không cho phép thi. Ví dụ khi không đủ cột kiểm tra
        private bool bolAllowExam = false;//Được phép dự thi hay hông?
        private string strAllowExamDescription = null;//Ghi chú kết quả cho phép dự thi KTM
        private string strLearningLevel = null;//Đánh giá kết quả học tập của môn. Tương tự xếp loại
        private double? dblOtherFinalSummary = null;//Tổng kết môn lớn nhất, với hệ số khác. Ví dụ với 43 là hệ 0-4 tương ứng với level F-A
        private int? intOrderIndex = null;//Số thứ tự sinh viên trong sổ điểmi, để import điểm quá trình khi scan
        private int? intOrderIndexExam = null;//Số thứ tự sinh viên trong ds dự thi, để import khi scan
        private int? intOrderIndexExam2 = null;//Số thứ tự sinh viên trong ds dự thi lần 2, để import khi scan
        private bool bolIsIgnore = false;//Bỏ qua, được miễn. Sẽ không nhập điểm, ko xét nợ
        private long? lngReRegisterID = null;//Mã đăng ký học lại hoặc thi lại
        private decimal? decMoney = null;//Số tiền học phí cho tín chỉ này (dùng cho tín chỉ)
        private bool bolIsPayment = false;//Đã đóng tiền (nếu tick thì phần tín chỉ này không cần thu, không cần tính vào dự kiến thu)
        private bool bolIsLast = false;//chỉ có lần học sau cùng của sinh viên ở môn nào đó được bật, còn lại = false. Null khi đăng ký học lại, chưa có lấy để tính
        private DateTime? dtmCreatedDate = null;//Mã đăng ký học lại
        private string strCreatedUser = null;//Người tạo
        private DateTime? dtmUpdatedDate = null;//Ngày cập nhật cuối
        private string strUpdatedUser = null;//Người cập nhật cuối
        private IData objIData = null;
        private bool bolIsExistIData = false;
        private Exception objErrorException = null;

        #endregion

        #region Properties

        /// <summary>
        /// SubjectMarkID
        /// 
        /// </summary>
        public long? SubjectMarkID
        {
            get { return lngSubjectMarkID; }
            set { lngSubjectMarkID = value; }
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
        /// SubjectID
        /// 
        /// </summary>
        public string SubjectID
        {
            get { return strSubjectID; }
            set { strSubjectID = value; }
        }
        /// <summary>
        /// OrderLearning
        /// Lần học, khi học lại hoặc lưu ban
        /// </summary>
        public int? OrderLearning
        {
            get { return intOrderLearning; }
            set { intOrderLearning = value; }
        }
        /// <summary>
        /// ClassSubjectID
        /// 
        /// </summary>
        public long? ClassSubjectID
        {
            get { return lngClassSubjectID; }
            set { lngClassSubjectID = value; }
        }
        /// <summary>
        /// Mark11
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark11
        {
            get { return dblMark11; }
            set { dblMark11 = value; }
        }
        /// <summary>
        /// Mark12
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark12
        {
            get { return dblMark12; }
            set { dblMark12 = value; }
        }
        /// <summary>
        /// Mark13
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark13
        {
            get { return dblMark13; }
            set { dblMark13 = value; }
        }
        /// <summary>
        /// Mark14
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark14
        {
            get { return dblMark14; }
            set { dblMark14 = value; }
        }
        /// <summary>
        /// Mark15
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark15
        {
            get { return dblMark15; }
            set { dblMark15 = value; }
        }
        /// <summary>
        /// Mark16
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark16
        {
            get { return dblMark16; }
            set { dblMark16 = value; }
        }
        /// <summary>
        /// Mark17
        /// Điểm kiểm tra hệ số 1
        /// </summary>
        public double? Mark17
        {
            get { return dblMark17; }
            set { dblMark17 = value; }
        }
        /// <summary>
        /// Mark21
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark21
        {
            get { return dblMark21; }
            set { dblMark21 = value; }
        }
        /// <summary>
        /// Mark22
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark22
        {
            get { return dblMark22; }
            set { dblMark22 = value; }
        }
        /// <summary>
        /// Mark23
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark23
        {
            get { return dblMark23; }
            set { dblMark23 = value; }
        }
        /// <summary>
        /// Mark24
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark24
        {
            get { return dblMark24; }
            set { dblMark24 = value; }
        }
        /// <summary>
        /// Mark25
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark25
        {
            get { return dblMark25; }
            set { dblMark25 = value; }
        }
        /// <summary>
        /// Mark26
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark26
        {
            get { return dblMark26; }
            set { dblMark26 = value; }
        }
        /// <summary>
        /// Mark27
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark27
        {
            get { return dblMark27; }
            set { dblMark27 = value; }
        }
        /// <summary>
        /// Mark28
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark28
        {
            get { return dblMark28; }
            set { dblMark28 = value; }
        }
        /// <summary>
        /// Mark29
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark29
        {
            get { return dblMark29; }
            set { dblMark29 = value; }
        }
        /// <summary>
        /// Mark210
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark210
        {
            get { return dblMark210; }
            set { dblMark210 = value; }
        }
        /// <summary>
        /// Mark211
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark211
        {
            get { return dblMark211; }
            set { dblMark211 = value; }
        }
        /// <summary>
        /// Mark212
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark212
        {
            get { return dblMark212; }
            set { dblMark212 = value; }
        }
        /// <summary>
        /// Mark213
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark213
        {
            get { return dblMark213; }
            set { dblMark213 = value; }
        }
        /// <summary>
        /// Mark214
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark214
        {
            get { return dblMark214; }
            set { dblMark214 = value; }
        }
        /// <summary>
        /// Mark215
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark215
        {
            get { return dblMark215; }
            set { dblMark215 = value; }
        }
        /// <summary>
        /// Mark216
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark216
        {
            get { return dblMark216; }
            set { dblMark216 = value; }
        }
        /// <summary>
        /// Mark217
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark217
        {
            get { return dblMark217; }
            set { dblMark217 = value; }
        }
        /// <summary>
        /// Mark218
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark218
        {
            get { return dblMark218; }
            set { dblMark218 = value; }
        }
        /// <summary>
        /// Mark219
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark219
        {
            get { return dblMark219; }
            set { dblMark219 = value; }
        }
        /// <summary>
        /// Mark220
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark220
        {
            get { return dblMark220; }
            set { dblMark220 = value; }
        }
        /// <summary>
        /// Mark221
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark221
        {
            get { return dblMark221; }
            set { dblMark221 = value; }
        }
        /// <summary>
        /// Mark222
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark222
        {
            get { return dblMark222; }
            set { dblMark222 = value; }
        }
        /// <summary>
        /// Mark223
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark223
        {
            get { return dblMark223; }
            set { dblMark223 = value; }
        }
        /// <summary>
        /// Mark224
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark224
        {
            get { return dblMark224; }
            set { dblMark224 = value; }
        }
        /// <summary>
        /// Mark225
        /// Điểm kiểm tra hệ số 2
        /// </summary>
        public double? Mark225
        {
            get { return dblMark225; }
            set { dblMark225 = value; }
        }
        /// <summary>
        /// TestAverage
        /// Trung bình kiểm tra
        /// </summary>
        public double? TestAverage
        {
            get { return dblTestAverage; }
            set { dblTestAverage = value; }
        }
        /// <summary>
        /// TheoryExam1
        /// Điểm thi lần 1
        /// </summary>
        public double? TheoryExam1
        {
            get { return dblTheoryExam1; }
            set { dblTheoryExam1 = value; }
        }
        /// <summary>
        /// TheoryExam2
        /// Điểm thi lần 1
        /// </summary>
        public double? TheoryExam2
        {
            get { return dblTheoryExam2; }
            set { dblTheoryExam2 = value; }
        }
        /// <summary>
        /// TheoryExam3
        /// Điểm thi lần 1
        /// </summary>
        public double? TheoryExam3
        {
            get { return dblTheoryExam3; }
            set { dblTheoryExam3 = value; }
        }
        /// <summary>
        /// PracticeExam1
        /// Điểm thi lần 1
        /// </summary>
        public double? PracticeExam1
        {
            get { return dblPracticeExam1; }
            set { dblPracticeExam1 = value; }
        }
        /// <summary>
        /// PracticeExam2
        /// Điểm thi lần 1
        /// </summary>
        public double? PracticeExam2
        {
            get { return dblPracticeExam2; }
            set { dblPracticeExam2 = value; }
        }
        /// <summary>
        /// PracticeExam3
        /// Điểm thi lần 1
        /// </summary>
        public double? PracticeExam3
        {
            get { return dblPracticeExam3; }
            set { dblPracticeExam3 = value; }
        }
        /// <summary>
        /// Exam1
        /// Điểm thi lần 1
        /// </summary>
        public double? Exam1
        {
            get { return dblExam1; }
            set { dblExam1 = value; }
        }
        /// <summary>
        /// Exam2
        /// Điểm thi lần 2
        /// </summary>
        public double? Exam2
        {
            get { return dblExam2; }
            set { dblExam2 = value; }
        }
        /// <summary>
        /// Exam3
        /// Thi lần 3. Thường dùng cho điểm thi tốt nghiệp
        /// </summary>
        public double? Exam3
        {
            get { return dblExam3; }
            set { dblExam3 = value; }
        }
        /// <summary>
        /// Summary1
        /// Tổng kết môn với lần thi 1
        /// </summary>
        public double? Summary1
        {
            get { return dblSummary1; }
            set { dblSummary1 = value; }
        }
        /// <summary>
        /// Summary2
        /// Tổng kết môn với lần thi 2
        /// </summary>
        public double? Summary2
        {
            get { return dblSummary2; }
            set { dblSummary2 = value; }
        }
        /// <summary>
        /// Summary3
        /// Tổng kết môn với lần thi 3
        /// </summary>
        public double? Summary3
        {
            get { return dblSummary3; }
            set { dblSummary3 = value; }
        }
        /// <summary>
        /// FinalSummary
        /// Tổng kết môn cuối cùng
        /// </summary>
        public double? FinalSummary
        {
            get { return dblFinalSummary; }
            set { dblFinalSummary = value; }
        }
        /// <summary>
        /// OldClassSubjectID
        /// Mã môn học lớp cũ mà sinh viên học môn này
        /// </summary>
        public long? OldClassSubjectID
        {
            get { return lngOldClassSubjectID; }
            set { lngOldClassSubjectID = value; }
        }
        /// <summary>
        /// HaveExamRegister
        /// Có đăng ký dự thi tốt nghiệp
        /// </summary>
        public bool HaveExamRegister
        {
            get { return bolHaveExamRegister; }
            set { bolHaveExamRegister = value; }
        }
        /// <summary>
        /// Passed
        /// Đã đạt hay chưa? Null là chưa xét, 1. là đạt, 0 là chưa đạt
        /// </summary>
        public int? Passed
        {
            get { return intPassed; }
            set { intPassed = value; }
        }
        /// <summary>
        /// NotAllowExam
        /// Không cho phép thi. Ví dụ khi không đủ cột kiểm tra
        /// </summary>
        public bool NotAllowExam
        {
            get { return bolNotAllowExam; }
            set { bolNotAllowExam = value; }
        }
        /// <summary>
        /// AllowExam
        /// Được phép dự thi hay hông?
        /// </summary>
        public bool AllowExam
        {
            get { return bolAllowExam; }
            set { bolAllowExam = value; }
        }
        /// <summary>
        /// AllowExamDescription
        /// Ghi chú kết quả cho phép dự thi KTM
        /// </summary>
        public string AllowExamDescription
        {
            get { return strAllowExamDescription; }
            set { strAllowExamDescription = value; }
        }
        /// <summary>
        /// LearningLevel
        /// Đánh giá kết quả học tập của môn. Tương tự xếp loại
        /// </summary>
        public string LearningLevel
        {
            get { return strLearningLevel; }
            set { strLearningLevel = value; }
        }
        /// <summary>
        /// OtherFinalSummary
        /// Tổng kết môn lớn nhất, với hệ số khác. Ví dụ với 43 là hệ 0-4 tương ứng với level F-A
        /// </summary>
        public double? OtherFinalSummary
        {
            get { return dblOtherFinalSummary; }
            set { dblOtherFinalSummary = value; }
        }
        /// <summary>
        /// OrderIndex
        /// Số thứ tự sinh viên trong sổ điểmi, để import điểm quá trình khi scan
        /// </summary>
        public int? OrderIndex
        {
            get { return intOrderIndex; }
            set { intOrderIndex = value; }
        }
        /// <summary>
        /// OrderIndexExam
        /// Số thứ tự sinh viên trong ds dự thi, để import khi scan
        /// </summary>
        public int? OrderIndexExam
        {
            get { return intOrderIndexExam; }
            set { intOrderIndexExam = value; }
        }
        /// <summary>
        /// OrderIndexExam2
        /// Số thứ tự sinh viên trong ds dự thi lần 2, để import khi scan
        /// </summary>
        public int? OrderIndexExam2
        {
            get { return intOrderIndexExam2; }
            set { intOrderIndexExam2 = value; }
        }
        /// <summary>
        /// IsIgnore
        /// Bỏ qua, được miễn. Sẽ không nhập điểm, ko xét nợ
        /// </summary>
        public bool IsIgnore
        {
            get { return bolIsIgnore; }
            set { bolIsIgnore = value; }
        }
        /// <summary>
        /// ReRegisterID
        /// Mã đăng ký học lại hoặc thi lại
        /// </summary>
        public long? ReRegisterID
        {
            get { return lngReRegisterID; }
            set { lngReRegisterID = value; }
        }
        /// <summary>
        /// Money
        /// Số tiền học phí cho tín chỉ này (dùng cho tín chỉ)
        /// </summary>
        public decimal? Money
        {
            get { return decMoney; }
            set { decMoney = value; }
        }
        /// <summary>
        /// IsPayment
        /// Đã đóng tiền (nếu tick thì phần tín chỉ này không cần thu, không cần tính vào dự kiến thu)
        /// </summary>
        public bool IsPayment
        {
            get { return bolIsPayment; }
            set { bolIsPayment = value; }
        }
        /// <summary>
        /// IsLast
        /// chỉ có lần học sau cùng của sinh viên ở môn nào đó được bật, còn lại = false. Null khi đăng ký học lại, chưa có lấy để tính
        /// </summary>
        public bool IsLast
        {
            get { return bolIsLast; }
            set { bolIsLast = value; }
        }
        /// <summary>
        /// CreatedDate
        /// Mã đăng ký học lại
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
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectMarkID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectMarkID])) this.lngSubjectMarkID = Convert.ToInt64(reader[C_SubjectMarkID]);
                    if (reader.GetName(i).ToUpper().Equals(C_StudentID.ToUpper()) && !Convert.IsDBNull(reader[C_StudentID])) this.lngStudentID = Convert.ToInt64(reader[C_StudentID]);
                    if (reader.GetName(i).ToUpper().Equals(C_SubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_SubjectID])) this.strSubjectID = Convert.ToString(reader[C_SubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderLearning.ToUpper()) && !Convert.IsDBNull(reader[C_OrderLearning])) this.intOrderLearning = Convert.ToInt32(reader[C_OrderLearning]);
                    if (reader.GetName(i).ToUpper().Equals(C_ClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(reader[C_ClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Mark11.ToUpper()) && !Convert.IsDBNull(reader[C_Mark11])) this.dblMark11 = (double)reader[C_Mark11];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark12.ToUpper()) && !Convert.IsDBNull(reader[C_Mark12])) this.dblMark12 = (double)reader[C_Mark12];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark13.ToUpper()) && !Convert.IsDBNull(reader[C_Mark13])) this.dblMark13 = (double)reader[C_Mark13];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark14.ToUpper()) && !Convert.IsDBNull(reader[C_Mark14])) this.dblMark14 = (double)reader[C_Mark14];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark15.ToUpper()) && !Convert.IsDBNull(reader[C_Mark15])) this.dblMark15 = (double)reader[C_Mark15];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark16.ToUpper()) && !Convert.IsDBNull(reader[C_Mark16])) this.dblMark16 = (double)reader[C_Mark16];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark17.ToUpper()) && !Convert.IsDBNull(reader[C_Mark17])) this.dblMark17 = (double)reader[C_Mark17];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark21.ToUpper()) && !Convert.IsDBNull(reader[C_Mark21])) this.dblMark21 = (double)reader[C_Mark21];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark22.ToUpper()) && !Convert.IsDBNull(reader[C_Mark22])) this.dblMark22 = (double)reader[C_Mark22];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark23.ToUpper()) && !Convert.IsDBNull(reader[C_Mark23])) this.dblMark23 = (double)reader[C_Mark23];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark24.ToUpper()) && !Convert.IsDBNull(reader[C_Mark24])) this.dblMark24 = (double)reader[C_Mark24];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark25.ToUpper()) && !Convert.IsDBNull(reader[C_Mark25])) this.dblMark25 = (double)reader[C_Mark25];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark26.ToUpper()) && !Convert.IsDBNull(reader[C_Mark26])) this.dblMark26 = (double)reader[C_Mark26];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark27.ToUpper()) && !Convert.IsDBNull(reader[C_Mark27])) this.dblMark27 = (double)reader[C_Mark27];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark28.ToUpper()) && !Convert.IsDBNull(reader[C_Mark28])) this.dblMark28 = (double)reader[C_Mark28];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark29.ToUpper()) && !Convert.IsDBNull(reader[C_Mark29])) this.dblMark29 = (double)reader[C_Mark29];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark210.ToUpper()) && !Convert.IsDBNull(reader[C_Mark210])) this.dblMark210 = (double)reader[C_Mark210];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark211.ToUpper()) && !Convert.IsDBNull(reader[C_Mark211])) this.dblMark211 = (double)reader[C_Mark211];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark212.ToUpper()) && !Convert.IsDBNull(reader[C_Mark212])) this.dblMark212 = (double)reader[C_Mark212];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark213.ToUpper()) && !Convert.IsDBNull(reader[C_Mark213])) this.dblMark213 = (double)reader[C_Mark213];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark214.ToUpper()) && !Convert.IsDBNull(reader[C_Mark214])) this.dblMark214 = (double)reader[C_Mark214];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark215.ToUpper()) && !Convert.IsDBNull(reader[C_Mark215])) this.dblMark215 = (double)reader[C_Mark215];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark216.ToUpper()) && !Convert.IsDBNull(reader[C_Mark216])) this.dblMark216 = (double)reader[C_Mark216];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark217.ToUpper()) && !Convert.IsDBNull(reader[C_Mark217])) this.dblMark217 = (double)reader[C_Mark217];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark218.ToUpper()) && !Convert.IsDBNull(reader[C_Mark218])) this.dblMark218 = (double)reader[C_Mark218];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark219.ToUpper()) && !Convert.IsDBNull(reader[C_Mark219])) this.dblMark219 = (double)reader[C_Mark219];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark220.ToUpper()) && !Convert.IsDBNull(reader[C_Mark220])) this.dblMark220 = (double)reader[C_Mark220];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark221.ToUpper()) && !Convert.IsDBNull(reader[C_Mark221])) this.dblMark221 = (double)reader[C_Mark221];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark222.ToUpper()) && !Convert.IsDBNull(reader[C_Mark222])) this.dblMark222 = (double)reader[C_Mark222];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark223.ToUpper()) && !Convert.IsDBNull(reader[C_Mark223])) this.dblMark223 = (double)reader[C_Mark223];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark224.ToUpper()) && !Convert.IsDBNull(reader[C_Mark224])) this.dblMark224 = (double)reader[C_Mark224];
                    if (reader.GetName(i).ToUpper().Equals(C_Mark225.ToUpper()) && !Convert.IsDBNull(reader[C_Mark225])) this.dblMark225 = (double)reader[C_Mark225];
                    if (reader.GetName(i).ToUpper().Equals(C_TestAverage.ToUpper()) && !Convert.IsDBNull(reader[C_TestAverage])) this.dblTestAverage = (double)reader[C_TestAverage];
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryExam1.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryExam1])) this.dblTheoryExam1 = (double)reader[C_TheoryExam1];
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryExam2.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryExam2])) this.dblTheoryExam2 = (double)reader[C_TheoryExam2];
                    if (reader.GetName(i).ToUpper().Equals(C_TheoryExam3.ToUpper()) && !Convert.IsDBNull(reader[C_TheoryExam3])) this.dblTheoryExam3 = (double)reader[C_TheoryExam3];
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeExam1.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeExam1])) this.dblPracticeExam1 = (double)reader[C_PracticeExam1];
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeExam2.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeExam2])) this.dblPracticeExam2 = (double)reader[C_PracticeExam2];
                    if (reader.GetName(i).ToUpper().Equals(C_PracticeExam3.ToUpper()) && !Convert.IsDBNull(reader[C_PracticeExam3])) this.dblPracticeExam3 = (double)reader[C_PracticeExam3];
                    if (reader.GetName(i).ToUpper().Equals(C_Exam1.ToUpper()) && !Convert.IsDBNull(reader[C_Exam1])) this.dblExam1 = (double)reader[C_Exam1];
                    if (reader.GetName(i).ToUpper().Equals(C_Exam2.ToUpper()) && !Convert.IsDBNull(reader[C_Exam2])) this.dblExam2 = (double)reader[C_Exam2];
                    if (reader.GetName(i).ToUpper().Equals(C_Exam3.ToUpper()) && !Convert.IsDBNull(reader[C_Exam3])) this.dblExam3 = (double)reader[C_Exam3];
                    if (reader.GetName(i).ToUpper().Equals(C_Summary1.ToUpper()) && !Convert.IsDBNull(reader[C_Summary1])) this.dblSummary1 = (double)reader[C_Summary1];
                    if (reader.GetName(i).ToUpper().Equals(C_Summary2.ToUpper()) && !Convert.IsDBNull(reader[C_Summary2])) this.dblSummary2 = (double)reader[C_Summary2];
                    if (reader.GetName(i).ToUpper().Equals(C_Summary3.ToUpper()) && !Convert.IsDBNull(reader[C_Summary3])) this.dblSummary3 = (double)reader[C_Summary3];
                    if (reader.GetName(i).ToUpper().Equals(C_FinalSummary.ToUpper()) && !Convert.IsDBNull(reader[C_FinalSummary])) this.dblFinalSummary = (double)reader[C_FinalSummary];
                    if (reader.GetName(i).ToUpper().Equals(C_OldClassSubjectID.ToUpper()) && !Convert.IsDBNull(reader[C_OldClassSubjectID])) this.lngOldClassSubjectID = Convert.ToInt64(reader[C_OldClassSubjectID]);
                    if (reader.GetName(i).ToUpper().Equals(C_HaveExamRegister.ToUpper()) && !Convert.IsDBNull(reader[C_HaveExamRegister])) this.bolHaveExamRegister = Convert.ToBoolean(reader[C_HaveExamRegister]);
                    if (reader.GetName(i).ToUpper().Equals(C_Passed.ToUpper()) && !Convert.IsDBNull(reader[C_Passed])) this.intPassed = Convert.ToInt32(reader[C_Passed]);
                    if (reader.GetName(i).ToUpper().Equals(C_NotAllowExam.ToUpper()) && !Convert.IsDBNull(reader[C_NotAllowExam])) this.bolNotAllowExam = Convert.ToBoolean(reader[C_NotAllowExam]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowExam.ToUpper()) && !Convert.IsDBNull(reader[C_AllowExam])) this.bolAllowExam = Convert.ToBoolean(reader[C_AllowExam]);
                    if (reader.GetName(i).ToUpper().Equals(C_AllowExamDescription.ToUpper()) && !Convert.IsDBNull(reader[C_AllowExamDescription])) this.strAllowExamDescription = Convert.ToString(reader[C_AllowExamDescription]);
                    if (reader.GetName(i).ToUpper().Equals(C_LearningLevel.ToUpper()) && !Convert.IsDBNull(reader[C_LearningLevel])) this.strLearningLevel = Convert.ToString(reader[C_LearningLevel]);
                    if (reader.GetName(i).ToUpper().Equals(C_OtherFinalSummary.ToUpper()) && !Convert.IsDBNull(reader[C_OtherFinalSummary])) this.dblOtherFinalSummary = (double)reader[C_OtherFinalSummary];
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndex.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(reader[C_OrderIndex]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndexExam.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndexExam])) this.intOrderIndexExam = Convert.ToInt32(reader[C_OrderIndexExam]);
                    if (reader.GetName(i).ToUpper().Equals(C_OrderIndexExam2.ToUpper()) && !Convert.IsDBNull(reader[C_OrderIndexExam2])) this.intOrderIndexExam2 = Convert.ToInt32(reader[C_OrderIndexExam2]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsIgnore.ToUpper()) && !Convert.IsDBNull(reader[C_IsIgnore])) this.bolIsIgnore = Convert.ToBoolean(reader[C_IsIgnore]);
                    if (reader.GetName(i).ToUpper().Equals(C_ReRegisterID.ToUpper()) && !Convert.IsDBNull(reader[C_ReRegisterID])) this.lngReRegisterID = Convert.ToInt64(reader[C_ReRegisterID]);
                    if (reader.GetName(i).ToUpper().Equals(C_Money.ToUpper()) && !Convert.IsDBNull(reader[C_Money])) this.decMoney = Convert.ToDecimal(reader[C_Money]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsPayment.ToUpper()) && !Convert.IsDBNull(reader[C_IsPayment])) this.bolIsPayment = Convert.ToBoolean(reader[C_IsPayment]);
                    if (reader.GetName(i).ToUpper().Equals(C_IsLast.ToUpper()) && !Convert.IsDBNull(reader[C_IsLast])) this.bolIsLast = Convert.ToBoolean(reader[C_IsLast]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(reader[C_CreatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_CreatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_CreatedUser])) this.strCreatedUser = Convert.ToString(reader[C_CreatedUser]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedDate.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(reader[C_UpdatedDate]);
                    if (reader.GetName(i).ToUpper().Equals(C_UpdatedUser.ToUpper()) && !Convert.IsDBNull(reader[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(reader[C_UpdatedUser]);
                }
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(IDataReader) trong SIM_SubjectMark", objEx);
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
                if (!Convert.IsDBNull(drw[C_SubjectMarkID])) this.lngSubjectMarkID = Convert.ToInt64(drw[C_SubjectMarkID]);
                if (!Convert.IsDBNull(drw[C_StudentID])) this.lngStudentID = Convert.ToInt64(drw[C_StudentID]);
                if (!Convert.IsDBNull(drw[C_SubjectID])) this.strSubjectID = Convert.ToString(drw[C_SubjectID]);
                if (!Convert.IsDBNull(drw[C_OrderLearning])) this.intOrderLearning = Convert.ToInt32(drw[C_OrderLearning]);
                if (!Convert.IsDBNull(drw[C_ClassSubjectID])) this.lngClassSubjectID = Convert.ToInt64(drw[C_ClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_Mark11])) this.dblMark11 = (double)drw[C_Mark11];
                if (!Convert.IsDBNull(drw[C_Mark12])) this.dblMark12 = (double)drw[C_Mark12];
                if (!Convert.IsDBNull(drw[C_Mark13])) this.dblMark13 = (double)drw[C_Mark13];
                if (!Convert.IsDBNull(drw[C_Mark14])) this.dblMark14 = (double)drw[C_Mark14];
                if (!Convert.IsDBNull(drw[C_Mark15])) this.dblMark15 = (double)drw[C_Mark15];
                if (!Convert.IsDBNull(drw[C_Mark16])) this.dblMark16 = (double)drw[C_Mark16];
                if (!Convert.IsDBNull(drw[C_Mark17])) this.dblMark17 = (double)drw[C_Mark17];
                if (!Convert.IsDBNull(drw[C_Mark21])) this.dblMark21 = (double)drw[C_Mark21];
                if (!Convert.IsDBNull(drw[C_Mark22])) this.dblMark22 = (double)drw[C_Mark22];
                if (!Convert.IsDBNull(drw[C_Mark23])) this.dblMark23 = (double)drw[C_Mark23];
                if (!Convert.IsDBNull(drw[C_Mark24])) this.dblMark24 = (double)drw[C_Mark24];
                if (!Convert.IsDBNull(drw[C_Mark25])) this.dblMark25 = (double)drw[C_Mark25];
                if (!Convert.IsDBNull(drw[C_Mark26])) this.dblMark26 = (double)drw[C_Mark26];
                if (!Convert.IsDBNull(drw[C_Mark27])) this.dblMark27 = (double)drw[C_Mark27];
                if (!Convert.IsDBNull(drw[C_Mark28])) this.dblMark28 = (double)drw[C_Mark28];
                if (!Convert.IsDBNull(drw[C_Mark29])) this.dblMark29 = (double)drw[C_Mark29];
                if (!Convert.IsDBNull(drw[C_Mark210])) this.dblMark210 = (double)drw[C_Mark210];
                if (!Convert.IsDBNull(drw[C_Mark211])) this.dblMark211 = (double)drw[C_Mark211];
                if (!Convert.IsDBNull(drw[C_Mark212])) this.dblMark212 = (double)drw[C_Mark212];
                if (!Convert.IsDBNull(drw[C_Mark213])) this.dblMark213 = (double)drw[C_Mark213];
                if (!Convert.IsDBNull(drw[C_Mark214])) this.dblMark214 = (double)drw[C_Mark214];
                if (!Convert.IsDBNull(drw[C_Mark215])) this.dblMark215 = (double)drw[C_Mark215];
                if (!Convert.IsDBNull(drw[C_Mark216])) this.dblMark216 = (double)drw[C_Mark216];
                if (!Convert.IsDBNull(drw[C_Mark217])) this.dblMark217 = (double)drw[C_Mark217];
                if (!Convert.IsDBNull(drw[C_Mark218])) this.dblMark218 = (double)drw[C_Mark218];
                if (!Convert.IsDBNull(drw[C_Mark219])) this.dblMark219 = (double)drw[C_Mark219];
                if (!Convert.IsDBNull(drw[C_Mark220])) this.dblMark220 = (double)drw[C_Mark220];
                if (!Convert.IsDBNull(drw[C_Mark221])) this.dblMark221 = (double)drw[C_Mark221];
                if (!Convert.IsDBNull(drw[C_Mark222])) this.dblMark222 = (double)drw[C_Mark222];
                if (!Convert.IsDBNull(drw[C_Mark223])) this.dblMark223 = (double)drw[C_Mark223];
                if (!Convert.IsDBNull(drw[C_Mark224])) this.dblMark224 = (double)drw[C_Mark224];
                if (!Convert.IsDBNull(drw[C_Mark225])) this.dblMark225 = (double)drw[C_Mark225];
                if (!Convert.IsDBNull(drw[C_TestAverage])) this.dblTestAverage = (double)drw[C_TestAverage];
                if (!Convert.IsDBNull(drw[C_TheoryExam1])) this.dblTheoryExam1 = (double)drw[C_TheoryExam1];
                if (!Convert.IsDBNull(drw[C_TheoryExam2])) this.dblTheoryExam2 = (double)drw[C_TheoryExam2];
                if (!Convert.IsDBNull(drw[C_TheoryExam3])) this.dblTheoryExam3 = (double)drw[C_TheoryExam3];
                if (!Convert.IsDBNull(drw[C_PracticeExam1])) this.dblPracticeExam1 = (double)drw[C_PracticeExam1];
                if (!Convert.IsDBNull(drw[C_PracticeExam2])) this.dblPracticeExam2 = (double)drw[C_PracticeExam2];
                if (!Convert.IsDBNull(drw[C_PracticeExam3])) this.dblPracticeExam3 = (double)drw[C_PracticeExam3];
                if (!Convert.IsDBNull(drw[C_Exam1])) this.dblExam1 = (double)drw[C_Exam1];
                if (!Convert.IsDBNull(drw[C_Exam2])) this.dblExam2 = (double)drw[C_Exam2];
                if (!Convert.IsDBNull(drw[C_Exam3])) this.dblExam3 = (double)drw[C_Exam3];
                if (!Convert.IsDBNull(drw[C_Summary1])) this.dblSummary1 = (double)drw[C_Summary1];
                if (!Convert.IsDBNull(drw[C_Summary2])) this.dblSummary2 = (double)drw[C_Summary2];
                if (!Convert.IsDBNull(drw[C_Summary3])) this.dblSummary3 = (double)drw[C_Summary3];
                if (!Convert.IsDBNull(drw[C_FinalSummary])) this.dblFinalSummary = (double)drw[C_FinalSummary];
                if (!Convert.IsDBNull(drw[C_OldClassSubjectID])) this.lngOldClassSubjectID = Convert.ToInt64(drw[C_OldClassSubjectID]);
                if (!Convert.IsDBNull(drw[C_HaveExamRegister])) this.bolHaveExamRegister = Convert.ToBoolean(drw[C_HaveExamRegister]);
                if (!Convert.IsDBNull(drw[C_Passed])) this.intPassed = Convert.ToInt32(drw[C_Passed]);
                if (!Convert.IsDBNull(drw[C_NotAllowExam])) this.bolNotAllowExam = Convert.ToBoolean(drw[C_NotAllowExam]);
                if (!Convert.IsDBNull(drw[C_AllowExam])) this.bolAllowExam = Convert.ToBoolean(drw[C_AllowExam]);
                if (!Convert.IsDBNull(drw[C_AllowExamDescription])) this.strAllowExamDescription = Convert.ToString(drw[C_AllowExamDescription]);
                if (!Convert.IsDBNull(drw[C_LearningLevel])) this.strLearningLevel = Convert.ToString(drw[C_LearningLevel]);
                if (!Convert.IsDBNull(drw[C_OtherFinalSummary])) this.dblOtherFinalSummary = (double)drw[C_OtherFinalSummary];
                if (!Convert.IsDBNull(drw[C_OrderIndex])) this.intOrderIndex = Convert.ToInt32(drw[C_OrderIndex]);
                if (!Convert.IsDBNull(drw[C_OrderIndexExam])) this.intOrderIndexExam = Convert.ToInt32(drw[C_OrderIndexExam]);
                if (!Convert.IsDBNull(drw[C_OrderIndexExam2])) this.intOrderIndexExam2 = Convert.ToInt32(drw[C_OrderIndexExam2]);
                if (!Convert.IsDBNull(drw[C_IsIgnore])) this.bolIsIgnore = Convert.ToBoolean(drw[C_IsIgnore]);
                if (!Convert.IsDBNull(drw[C_ReRegisterID])) this.lngReRegisterID = Convert.ToInt64(drw[C_ReRegisterID]);
                if (!Convert.IsDBNull(drw[C_Money])) this.decMoney = Convert.ToDecimal(drw[C_Money]);
                if (!Convert.IsDBNull(drw[C_IsPayment])) this.bolIsPayment = Convert.ToBoolean(drw[C_IsPayment]);
                if (!Convert.IsDBNull(drw[C_IsLast])) this.bolIsLast = Convert.ToBoolean(drw[C_IsLast]);
                if (!Convert.IsDBNull(drw[C_CreatedDate])) this.dtmCreatedDate = Convert.ToDateTime(drw[C_CreatedDate]);
                if (!Convert.IsDBNull(drw[C_CreatedUser])) this.strCreatedUser = Convert.ToString(drw[C_CreatedUser]);
                if (!Convert.IsDBNull(drw[C_UpdatedDate])) this.dtmUpdatedDate = Convert.ToDateTime(drw[C_UpdatedDate]);
                if (!Convert.IsDBNull(drw[C_UpdatedUser])) this.strUpdatedUser = Convert.ToString(drw[C_UpdatedUser]);
                return true;
            }
            catch (Exception objEx)
            {
                new SystemError(SystemConfig.ConnectionString, "Lỗi khi Parse(DataRow) trong SIM_SubjectMark", objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        ///<summary>
        /// Nạp thông tin item 
        /// Store: SIM_SubjectMark_GET 
        ///</summary>
        /// <returns>true ? Có : False ? Không</returns>
        public bool Get()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_GET");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi nạp thông tin SIM_SubjectMark", objEx);
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
        /// Store: SIM_SubjectMark_GET 
        ///</summary>
        /// <returns> SIM_SubjectMark </returns>
        public SIM_SubjectMark Get(long? lngSubjectMarkID)
        {
            SIM_SubjectMark obj = new SIM_SubjectMark();
            if (objIData != null)
                obj.IDB = objIData;
            obj.SubjectMarkID = lngSubjectMarkID;
            if (obj.Get())
                return obj;
            this.objErrorException = obj.ErrorException;
            return null;
        }
        ///<summary>
        /// ExecNonQuery : SIM_SubjectMark
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SubjectMark", objEx);
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
        /// Search : SIM_SubjectMark
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
                new SystemError(SystemConfig.ConnectionString, "Lỗi thực hiện store " + storeName + " trong SIM_SubjectMark", objEx);
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
        /// Search : SIM_SubjectMark
        /// Lấy hết dữ liệu
        /// Store: SIM_SubjectMark_GETALL 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable GetAll()
        {
            return GetDataTable("SIM_SubjectMark_GETALL");
        }

        ///<summary>
        /// Search : SIM_SubjectMark
        /// Tìm dữ liệu
        /// Store: SIM_SubjectMark_SEARCH 
        /// <returns> DataTable </returns>
        ///</summary>
        public DataTable Search(params object[] pars)
        {
            return GetDataTable("SIM_SubjectMark_SEARCH", pars);
        }

        ///<summary>
        /// Add : SIM_SubjectMark
        /// Thêm dữ liệu
        /// Store: SIM_SubjectMark_ADD 
        ///</summary>
        public bool Add()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_ADD");
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_OrderLearning, this.intOrderLearning);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_Mark11, this.dblMark11);
                objIData.AddParameter(P_Mark12, this.dblMark12);
                objIData.AddParameter(P_Mark13, this.dblMark13);
                objIData.AddParameter(P_Mark14, this.dblMark14);
                objIData.AddParameter(P_Mark15, this.dblMark15);
                objIData.AddParameter(P_Mark16, this.dblMark16);
                objIData.AddParameter(P_Mark17, this.dblMark17);
                objIData.AddParameter(P_Mark21, this.dblMark21);
                objIData.AddParameter(P_Mark22, this.dblMark22);
                objIData.AddParameter(P_Mark23, this.dblMark23);
                objIData.AddParameter(P_Mark24, this.dblMark24);
                objIData.AddParameter(P_Mark25, this.dblMark25);
                objIData.AddParameter(P_Mark26, this.dblMark26);
                objIData.AddParameter(P_Mark27, this.dblMark27);
                objIData.AddParameter(P_Mark28, this.dblMark28);
                objIData.AddParameter(P_Mark29, this.dblMark29);
                objIData.AddParameter(P_Mark210, this.dblMark210);
                objIData.AddParameter(P_Mark211, this.dblMark211);
                objIData.AddParameter(P_Mark212, this.dblMark212);
                objIData.AddParameter(P_Mark213, this.dblMark213);
                objIData.AddParameter(P_Mark214, this.dblMark214);
                objIData.AddParameter(P_Mark215, this.dblMark215);
                objIData.AddParameter(P_Mark216, this.dblMark216);
                objIData.AddParameter(P_Mark217, this.dblMark217);
                objIData.AddParameter(P_Mark218, this.dblMark218);
                objIData.AddParameter(P_Mark219, this.dblMark219);
                objIData.AddParameter(P_Mark220, this.dblMark220);
                objIData.AddParameter(P_Mark221, this.dblMark221);
                objIData.AddParameter(P_Mark222, this.dblMark222);
                objIData.AddParameter(P_Mark223, this.dblMark223);
                objIData.AddParameter(P_Mark224, this.dblMark224);
                objIData.AddParameter(P_Mark225, this.dblMark225);
                objIData.AddParameter(P_TestAverage, this.dblTestAverage);
                objIData.AddParameter(P_TheoryExam1, this.dblTheoryExam1);
                objIData.AddParameter(P_TheoryExam2, this.dblTheoryExam2);
                objIData.AddParameter(P_TheoryExam3, this.dblTheoryExam3);
                objIData.AddParameter(P_PracticeExam1, this.dblPracticeExam1);
                objIData.AddParameter(P_PracticeExam2, this.dblPracticeExam2);
                objIData.AddParameter(P_PracticeExam3, this.dblPracticeExam3);
                objIData.AddParameter(P_Exam1, this.dblExam1);
                objIData.AddParameter(P_Exam2, this.dblExam2);
                objIData.AddParameter(P_Exam3, this.dblExam3);
                objIData.AddParameter(P_Summary1, this.dblSummary1);
                objIData.AddParameter(P_Summary2, this.dblSummary2);
                objIData.AddParameter(P_Summary3, this.dblSummary3);
                objIData.AddParameter(P_FinalSummary, this.dblFinalSummary);
                objIData.AddParameter(P_OldClassSubjectID, this.lngOldClassSubjectID);
                objIData.AddParameter(P_HaveExamRegister, this.bolHaveExamRegister);
                objIData.AddParameter(P_Passed, this.intPassed);
                objIData.AddParameter(P_NotAllowExam, this.bolNotAllowExam);
                objIData.AddParameter(P_AllowExam, this.bolAllowExam);
                objIData.AddParameter(P_AllowExamDescription, this.strAllowExamDescription);
                objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
                objIData.AddParameter(P_OtherFinalSummary, this.dblOtherFinalSummary);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
                objIData.AddParameter(P_OrderIndexExam, this.intOrderIndexExam);
                objIData.AddParameter(P_OrderIndexExam2, this.intOrderIndexExam2);
                objIData.AddParameter(P_IsIgnore, this.bolIsIgnore);
                objIData.AddParameter(P_ReRegisterID, this.lngReRegisterID);
                objIData.AddParameter(P_Money, this.decMoney);
                objIData.AddParameter(P_IsPayment, this.bolIsPayment);
                objIData.AddParameter(P_IsLast, this.bolIsLast);
                objIData.AddParameter(P_CreatedUser, this.strCreatedUser);
                this.lngSubjectMarkID = Convert.ToInt32(objIData.ExecStoreToString());
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi thêm thông tin SIM_SubjectMark", objEx);
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
        /// Update : SIM_SubjectMark
        /// Cập nhật dữ liệu
        /// Store: SIM_SubjectMark_EDIT 
        ///</summary>
        public bool Update()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_EDIT");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.AddParameter(P_StudentID, this.lngStudentID);
                objIData.AddParameter(P_SubjectID, this.strSubjectID);
                objIData.AddParameter(P_OrderLearning, this.intOrderLearning);
                objIData.AddParameter(P_ClassSubjectID, this.lngClassSubjectID);
                objIData.AddParameter(P_Mark11, this.dblMark11);
                objIData.AddParameter(P_Mark12, this.dblMark12);
                objIData.AddParameter(P_Mark13, this.dblMark13);
                objIData.AddParameter(P_Mark14, this.dblMark14);
                objIData.AddParameter(P_Mark15, this.dblMark15);
                objIData.AddParameter(P_Mark16, this.dblMark16);
                objIData.AddParameter(P_Mark17, this.dblMark17);
                objIData.AddParameter(P_Mark21, this.dblMark21);
                objIData.AddParameter(P_Mark22, this.dblMark22);
                objIData.AddParameter(P_Mark23, this.dblMark23);
                objIData.AddParameter(P_Mark24, this.dblMark24);
                objIData.AddParameter(P_Mark25, this.dblMark25);
                objIData.AddParameter(P_Mark26, this.dblMark26);
                objIData.AddParameter(P_Mark27, this.dblMark27);
                objIData.AddParameter(P_Mark28, this.dblMark28);
                objIData.AddParameter(P_Mark29, this.dblMark29);
                objIData.AddParameter(P_Mark210, this.dblMark210);
                objIData.AddParameter(P_Mark211, this.dblMark211);
                objIData.AddParameter(P_Mark212, this.dblMark212);
                objIData.AddParameter(P_Mark213, this.dblMark213);
                objIData.AddParameter(P_Mark214, this.dblMark214);
                objIData.AddParameter(P_Mark215, this.dblMark215);
                objIData.AddParameter(P_Mark216, this.dblMark216);
                objIData.AddParameter(P_Mark217, this.dblMark217);
                objIData.AddParameter(P_Mark218, this.dblMark218);
                objIData.AddParameter(P_Mark219, this.dblMark219);
                objIData.AddParameter(P_Mark220, this.dblMark220);
                objIData.AddParameter(P_Mark221, this.dblMark221);
                objIData.AddParameter(P_Mark222, this.dblMark222);
                objIData.AddParameter(P_Mark223, this.dblMark223);
                objIData.AddParameter(P_Mark224, this.dblMark224);
                objIData.AddParameter(P_Mark225, this.dblMark225);
                objIData.AddParameter(P_TestAverage, this.dblTestAverage);
                objIData.AddParameter(P_TheoryExam1, this.dblTheoryExam1);
                objIData.AddParameter(P_TheoryExam2, this.dblTheoryExam2);
                objIData.AddParameter(P_TheoryExam3, this.dblTheoryExam3);
                objIData.AddParameter(P_PracticeExam1, this.dblPracticeExam1);
                objIData.AddParameter(P_PracticeExam2, this.dblPracticeExam2);
                objIData.AddParameter(P_PracticeExam3, this.dblPracticeExam3);
                objIData.AddParameter(P_Exam1, this.dblExam1);
                objIData.AddParameter(P_Exam2, this.dblExam2);
                objIData.AddParameter(P_Exam3, this.dblExam3);
                objIData.AddParameter(P_Summary1, this.dblSummary1);
                objIData.AddParameter(P_Summary2, this.dblSummary2);
                objIData.AddParameter(P_Summary3, this.dblSummary3);
                objIData.AddParameter(P_FinalSummary, this.dblFinalSummary);
                objIData.AddParameter(P_OldClassSubjectID, this.lngOldClassSubjectID);
                objIData.AddParameter(P_HaveExamRegister, this.bolHaveExamRegister);
                objIData.AddParameter(P_Passed, this.intPassed);
                objIData.AddParameter(P_NotAllowExam, this.bolNotAllowExam);
                objIData.AddParameter(P_AllowExam, this.bolAllowExam);
                objIData.AddParameter(P_AllowExamDescription, this.strAllowExamDescription);
                objIData.AddParameter(P_LearningLevel, this.strLearningLevel);
                objIData.AddParameter(P_OtherFinalSummary, this.dblOtherFinalSummary);
                objIData.AddParameter(P_OrderIndex, this.intOrderIndex);
                objIData.AddParameter(P_OrderIndexExam, this.intOrderIndexExam);
                objIData.AddParameter(P_OrderIndexExam2, this.intOrderIndexExam2);
                objIData.AddParameter(P_IsIgnore, this.bolIsIgnore);
                objIData.AddParameter(P_ReRegisterID, this.lngReRegisterID);
                objIData.AddParameter(P_Money, this.decMoney);
                objIData.AddParameter(P_IsPayment, this.bolIsPayment);
                objIData.AddParameter(P_IsLast, this.bolIsLast);
                objIData.AddParameter(P_UpdatedUser, this.strUpdatedUser);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi cập nhật thông tin SIM_SubjectMark", objEx);
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
        /// Delete : SIM_SubjectMark
        /// Xóa dữ liệu
        /// Store: SIM_SubjectMark_DELETE 
        ///</summary>
        public bool Delete()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();
            try
            {
                objIData.CreateNewStoredProcedure("SIM_SubjectMark_DELETE");
                objIData.AddParameter(P_SubjectMarkID, this.lngSubjectMarkID);
                objIData.ExecNonQuery();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(SystemConfig.ConnectionString, "Lỗi xóa thông tin SIM_SubjectMark", objEx);
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
        /// Store: SIM_SubjectMark_DELETE 
        ///</summary>
        /// <returns> true: thanh cong, false: that bai </returns>
        public bool Delete(long? lngSubjectMarkID)
        {
            this.lngSubjectMarkID = lngSubjectMarkID;
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

        public SIM_SubjectMark()
        {
        }
        public SIM_SubjectMark(long? lngSubjectMarkID)
        {
            this.lngSubjectMarkID = lngSubjectMarkID;
            this.Get();
        }

        #endregion

        #region Variable Static

        #region Parameter Names

        public const String P_SubjectMarkID = "@" + C_SubjectMarkID;
        public const String P_StudentID = "@" + C_StudentID;
        public const String P_SubjectID = "@" + C_SubjectID;
        public const String P_OrderLearning = "@" + C_OrderLearning;
        public const String P_ClassSubjectID = "@" + C_ClassSubjectID;
        public const String P_Mark11 = "@" + C_Mark11;
        public const String P_Mark12 = "@" + C_Mark12;
        public const String P_Mark13 = "@" + C_Mark13;
        public const String P_Mark14 = "@" + C_Mark14;
        public const String P_Mark15 = "@" + C_Mark15;
        public const String P_Mark16 = "@" + C_Mark16;
        public const String P_Mark17 = "@" + C_Mark17;
        public const String P_Mark21 = "@" + C_Mark21;
        public const String P_Mark22 = "@" + C_Mark22;
        public const String P_Mark23 = "@" + C_Mark23;
        public const String P_Mark24 = "@" + C_Mark24;
        public const String P_Mark25 = "@" + C_Mark25;
        public const String P_Mark26 = "@" + C_Mark26;
        public const String P_Mark27 = "@" + C_Mark27;
        public const String P_Mark28 = "@" + C_Mark28;
        public const String P_Mark29 = "@" + C_Mark29;
        public const String P_Mark210 = "@" + C_Mark210;
        public const String P_Mark211 = "@" + C_Mark211;
        public const String P_Mark212 = "@" + C_Mark212;
        public const String P_Mark213 = "@" + C_Mark213;
        public const String P_Mark214 = "@" + C_Mark214;
        public const String P_Mark215 = "@" + C_Mark215;
        public const String P_Mark216 = "@" + C_Mark216;
        public const String P_Mark217 = "@" + C_Mark217;
        public const String P_Mark218 = "@" + C_Mark218;
        public const String P_Mark219 = "@" + C_Mark219;
        public const String P_Mark220 = "@" + C_Mark220;
        public const String P_Mark221 = "@" + C_Mark221;
        public const String P_Mark222 = "@" + C_Mark222;
        public const String P_Mark223 = "@" + C_Mark223;
        public const String P_Mark224 = "@" + C_Mark224;
        public const String P_Mark225 = "@" + C_Mark225;
        public const String P_TestAverage = "@" + C_TestAverage;
        public const String P_TheoryExam1 = "@" + C_TheoryExam1;
        public const String P_TheoryExam2 = "@" + C_TheoryExam2;
        public const String P_TheoryExam3 = "@" + C_TheoryExam3;
        public const String P_PracticeExam1 = "@" + C_PracticeExam1;
        public const String P_PracticeExam2 = "@" + C_PracticeExam2;
        public const String P_PracticeExam3 = "@" + C_PracticeExam3;
        public const String P_Exam1 = "@" + C_Exam1;
        public const String P_Exam2 = "@" + C_Exam2;
        public const String P_Exam3 = "@" + C_Exam3;
        public const String P_Summary1 = "@" + C_Summary1;
        public const String P_Summary2 = "@" + C_Summary2;
        public const String P_Summary3 = "@" + C_Summary3;
        public const String P_FinalSummary = "@" + C_FinalSummary;
        public const String P_OldClassSubjectID = "@" + C_OldClassSubjectID;
        public const String P_HaveExamRegister = "@" + C_HaveExamRegister;
        public const String P_Passed = "@" + C_Passed;
        public const String P_NotAllowExam = "@" + C_NotAllowExam;
        public const String P_AllowExam = "@" + C_AllowExam;
        public const String P_AllowExamDescription = "@" + C_AllowExamDescription;
        public const String P_LearningLevel = "@" + C_LearningLevel;
        public const String P_OtherFinalSummary = "@" + C_OtherFinalSummary;
        public const String P_OrderIndex = "@" + C_OrderIndex;
        public const String P_OrderIndexExam = "@" + C_OrderIndexExam;
        public const String P_OrderIndexExam2 = "@" + C_OrderIndexExam2;
        public const String P_IsIgnore = "@" + C_IsIgnore;
        public const String P_ReRegisterID = "@" + C_ReRegisterID;
        public const String P_Money = "@" + C_Money;
        public const String P_IsPayment = "@" + C_IsPayment;
        public const String P_IsLast = "@" + C_IsLast;
        public const String P_CreatedDate = "@" + C_CreatedDate;
        public const String P_CreatedUser = "@" + C_CreatedUser;
        public const String P_UpdatedDate = "@" + C_UpdatedDate;
        public const String P_UpdatedUser = "@" + C_UpdatedUser;

        #endregion //Parameter names

        #region Column Names

        public const String C_SubjectMarkID = "SubjectMarkID";
        public const String C_StudentID = "StudentID";
        public const String C_SubjectID = "SubjectID";
        public const String C_OrderLearning = "OrderLearning";
        public const String C_ClassSubjectID = "ClassSubjectID";
        public const String C_Mark11 = "Mark11";
        public const String C_Mark12 = "Mark12";
        public const String C_Mark13 = "Mark13";
        public const String C_Mark14 = "Mark14";
        public const String C_Mark15 = "Mark15";
        public const String C_Mark16 = "Mark16";
        public const String C_Mark17 = "Mark17";
        public const String C_Mark21 = "Mark21";
        public const String C_Mark22 = "Mark22";
        public const String C_Mark23 = "Mark23";
        public const String C_Mark24 = "Mark24";
        public const String C_Mark25 = "Mark25";
        public const String C_Mark26 = "Mark26";
        public const String C_Mark27 = "Mark27";
        public const String C_Mark28 = "Mark28";
        public const String C_Mark29 = "Mark29";
        public const String C_Mark210 = "Mark210";
        public const String C_Mark211 = "Mark211";
        public const String C_Mark212 = "Mark212";
        public const String C_Mark213 = "Mark213";
        public const String C_Mark214 = "Mark214";
        public const String C_Mark215 = "Mark215";
        public const String C_Mark216 = "Mark216";
        public const String C_Mark217 = "Mark217";
        public const String C_Mark218 = "Mark218";
        public const String C_Mark219 = "Mark219";
        public const String C_Mark220 = "Mark220";
        public const String C_Mark221 = "Mark221";
        public const String C_Mark222 = "Mark222";
        public const String C_Mark223 = "Mark223";
        public const String C_Mark224 = "Mark224";
        public const String C_Mark225 = "Mark225";
        public const String C_TestAverage = "TestAverage";
        public const String C_TheoryExam1 = "TheoryExam1";
        public const String C_TheoryExam2 = "TheoryExam2";
        public const String C_TheoryExam3 = "TheoryExam3";
        public const String C_PracticeExam1 = "PracticeExam1";
        public const String C_PracticeExam2 = "PracticeExam2";
        public const String C_PracticeExam3 = "PracticeExam3";
        public const String C_Exam1 = "Exam1";
        public const String C_Exam2 = "Exam2";
        public const String C_Exam3 = "Exam3";
        public const String C_Summary1 = "Summary1";
        public const String C_Summary2 = "Summary2";
        public const String C_Summary3 = "Summary3";
        public const String C_FinalSummary = "FinalSummary";
        public const String C_OldClassSubjectID = "OldClassSubjectID";
        public const String C_HaveExamRegister = "HaveExamRegister";
        public const String C_Passed = "Passed";
        public const String C_NotAllowExam = "NotAllowExam";
        public const String C_AllowExam = "AllowExam";
        public const String C_AllowExamDescription = "AllowExamDescription";
        public const String C_LearningLevel = "LearningLevel";
        public const String C_OtherFinalSummary = "OtherFinalSummary";
        public const String C_OrderIndex = "OrderIndex";
        public const String C_OrderIndexExam = "OrderIndexExam";
        public const String C_OrderIndexExam2 = "OrderIndexExam2";
        public const String C_IsIgnore = "IsIgnore";
        public const String C_ReRegisterID = "ReRegisterID";
        public const String C_Money = "Money";
        public const String C_IsPayment = "IsPayment";
        public const String C_IsLast = "IsLast";
        public const String C_CreatedDate = "CreatedDate";
        public const String C_CreatedUser = "CreatedUser";
        public const String C_UpdatedDate = "UpdatedDate";
        public const String C_UpdatedUser = "UpdatedUser";

        #endregion //Column names

        #endregion Variable Static
    }
}

