using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Libs;
using Global;
using DCore;
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;
using DevExpress.XtraGrid.Views.BandedGrid;
using SystemService;

namespace StudentManager.Learning
{
    public partial class frmSubjectMarkDetail : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SubjectMarkDetail_Edit";
        public const string PERMISSION_VIEW = "SIM_SubjectMarkDetail_View";

        #endregion

        #region Variable
        
        private string strClassID = "";
        private string strListIDDeleted = "";
        DataTable dtbData;
        DataTable dtbClassSubject;
        DataTable dtbSubjectMark;
        bool bolIsFirstSearch = true;
        int intYearID;
        int? intSemester = null;
        int intRegulationIDCurrent = 0;

        private string strReport_Header_Expand = "";
        private string strReport_Header = "";
        private string strReport_Place = "";


        private bool bolHaveNormalSubject = false; // có môn bình thường trong cả kì hay năm không, có thì chỉ tính môn bình thường, không thì chỉ tính môn văn hoá

        // đếm sinh viên theo thứ tự Xs, G, K, TB k, TB, yeu kem
        private int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 ,0};

        #endregion

        #region IForm Members

        private static frmSubjectMarkDetail _instance = null;

        public static frmSubjectMarkDetail Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSubjectMarkDetail();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSubjectMarkDetail()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = false;
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
                uYearSemester.InitData();
            }
        }

        private bool IsValidData()
        {
            if (uYearSemester.YearIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn năm học!");
                uYearSemester.Focus();
                return false;
            }
            if (!uClass.IsValidData())
                return false;
            return true;
        }

        private void GetSetting()
        {
            if (SYS_SettingService.HaveNewData || bolIsFirstSearch)
            {
                strReport_Header_Expand = SYS_SettingService.GetStringValue("Report_Header_Expand");
                strReport_Header = SYS_SettingService.GetStringValue("Report_Header");
                strReport_Place = SYS_SettingService.GetStringValue("Report_Place"); 
               
            }
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                // gán cột vào lưới.
                intRegulationIDCurrent = uClass.RegulationID.Value;

                SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                SIM_Student objStudent = new SIM_Student();

                // loại các môn không tổng kết
                string strListGraduationSpecialType = "";
                strListGraduationSpecialType = "," + Global.SubjectSpecialType.TotNghiepVanHoa.ToString()
                                                    + "," + Global.SubjectSpecialType.ChinhTriTotNghiep.ToString()
                                                    + "," + Global.SubjectSpecialType.TotNghiepLT.ToString()
                                                    + "," + Global.SubjectSpecialType.TotNghiepTH.ToString() + ",";
                if (!chkNghe.Checked)
                {
                    strListGraduationSpecialType += Global.SubjectSpecialType.BinhThuong.ToString() + ",";                  
                }
                if (!chkVanHoa.Checked)
                {
                    strListGraduationSpecialType += Global.SubjectSpecialType.VanHoa.ToString() + ","; 
                }


                if (uClass.IsRegulation43OfClass) // tổ chức học kiểu tín chỉ (thì lấy môn học trong chương trình khung)
                {
                    int? intOrderLearning = null;
                    if (chkViewOnlyExam1.Checked)
                        intOrderLearning = 1;
                    dtbSubjectMark = objSubjectMark.SearchOfClass43("@ClassID", uClass.ClassIDEditValue,
                                                                //"@YearID", uYearSemester.YearIDEditValue,
                                                                //"@Semester", uYearSemester.SemesterEditValue,
                                                                "@OrderLearning", intOrderLearning); // sổ điểm với những môn mà sv lớp này đang học ở kì này


                    dtbClassSubject = objSubjectMark.GetListSubject43("@ClassID", uClass.ClassIDEditValue,
                                                            "@YearID", uYearSemester.YearIDEditValue,
                                                            "@Semester", uYearSemester.SemesterEditValue,
                                                            "@NotListSpecialType", strListGraduationSpecialType); // môn mà sv lớp này có đăng ký học ở kì này
                }
                else
                {
                    if(chkViewOnlyExam1.Checked)
                        dtbSubjectMark = objSubjectMark.SearchFirst("@ClassID", uClass.ClassIDEditValue); // lấy điểm lần học đầu tiên thôi
                    else
                        dtbSubjectMark = objSubjectMark.SearchFinal("@ClassID", uClass.ClassIDEditValue); // lấy điểm cuối cùng, có thể học lại nên hông lấy theo niên kì mà lấy theo lớp là đủ



                    dtbClassSubject = objClassSubject.SearchSimpleList("@ClassID", uClass.ClassIDEditValue,
                                                            "@YearID", uYearSemester.YearIDEditValue,
                                                            "@Semester", uYearSemester.SemesterEditValue,
                                                            "@NotListSpecialType", strListGraduationSpecialType,
                                                            "@IsOnlyForScheduling", 0); // không lấy môn chỉ sắp lịch
                }

                dtbClassSubject.Columns.Add("SubjectIndex", typeof(int));
                dtbData = objStudent.GetDataTable("SIM_Student_SearchForSummary",
                                                "@ClassID", uClass.ClassIDEditValue,
                                                "@YearID", uYearSemester.YearIDEditValue,
                                                "@Semester", uYearSemester.SemesterEditValue);                

                if (dtbData != null && dtbClassSubject != null)
                {
                    RepairGrid(); // khởi tạo cột cơ bản
                    RepairDataAndGrid(); // khởi tạo môn học vào data và lưới
                    FillData(); // điền điểm vào

                    gcData.DataSource = dtbData;                    
                    ModifyGrid();
                    chkShowColumn_CheckedChanged(null, null);

                    gvData.BestFitColumns();
                    mnuItemPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    btnSave.Enabled = mnuItemSave.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT) && !chkViewOnlyExam1.Checked; // tong ket thi lan 1 thoi thi khong luu

                    intYearID = uYearSemester.YearIDEditValueInt32.Value;
                    intSemester = uYearSemester.SemesterEditValueInt32;

                    GetSetting();
                    bolIsFirstSearch = true;
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin điểm bị lỗi!");
                }
            }
        }

        /// <summary>
        /// Khởi tạo 53 cột cho 53 tuần cho lưới
        /// </summary>
        private void RepairGrid()
        {
            // Xóa hết grid 
            gvData.Bands.Clear();
            gvData.Columns.Clear();

            // Student
            GridBand gbStudent = new GridBand(); ;            
            BandedGridColumn gcolStudentCode = new BandedGridColumn();
            BandedGridColumn gcolStudentFirstName = new BandedGridColumn();
            BandedGridColumn gcolStudentLastName = new BandedGridColumn();
            BandedGridColumn gcolBirthday = new BandedGridColumn();
            BandedGridColumn gcolGenderText = new BandedGridColumn();

            // Summary
            GridBand gbSummary = new GridBand();
            GridBand gbSummaryEthic = new GridBand();
            BandedGridColumn gcolSummaryEthicMark = new BandedGridColumn();
            BandedGridColumn gcolEthicLevel = new BandedGridColumn();

            GridBand gbSummaryLearning = new GridBand();
            BandedGridColumn gcolSummaryLearningMark = new BandedGridColumn();
            BandedGridColumn gcolLearningLevel = new BandedGridColumn();



            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gbStudent,            
            gbSummary});
            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {            
            gcolStudentCode,
            gcolStudentFirstName,
            gcolStudentLastName,
            gcolBirthday,
            gcolGenderText,
            gcolSummaryEthicMark,
            gcolEthicLevel,
            gcolSummaryLearningMark,
            gcolLearningLevel});
            gvData.CustomizationFormBounds = new System.Drawing.Rectangle(1048, 450, 223, 215);
            gvData.GridControl = gcData;
            gvData.Name = "gvData";
            gvData.OptionsCustomization.AllowBandMoving = false;
            gvData.OptionsCustomization.AllowColumnMoving = false;
            gvData.OptionsCustomization.AllowGroup = false;
            gvData.OptionsCustomization.AllowQuickHideColumns = false;
            gvData.OptionsSelection.EnableAppearanceFocusedRow = false;
            gvData.OptionsSelection.InvertSelection = true;
            gvData.OptionsSelection.MultiSelect = true;
            gvData.OptionsView.ShowGroupPanel = false;
            gvData.RowSeparatorHeight = 1;
            // 
            // gbStudent
            // 
            gbStudent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbStudent.AppearanceHeader.Options.UseFont = true;
            gbStudent.AppearanceHeader.Options.UseTextOptions = true;
            gbStudent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbStudent.Caption = "SINH VIÊN";            
            gbStudent.Columns.Add(gcolStudentCode);
            gbStudent.Columns.Add(gcolStudentFirstName);
            gbStudent.Columns.Add(gcolStudentLastName);
            gbStudent.Columns.Add(gcolBirthday);
            gbStudent.Columns.Add(gcolGenderText);
            gbStudent.Name = "gbStudent";
            gbStudent.Width = 300;
           
            // 
            // gcolStudentCode
            // 
            gcolStudentCode.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentCode.Caption = "Mã SV";
            gcolStudentCode.FieldName = "StudentCode";
            gcolStudentCode.Name = "gcolStudentCode";
            gcolStudentCode.Visible = true;
            // 
            // gcolStudentFirstName
            // 
            gcolStudentFirstName.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentFirstName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentFirstName.Caption = "Họ đệm";
            gcolStudentFirstName.FieldName = "StudentFirstName";
            gcolStudentFirstName.Name = "gcolStudentFirstName";
            gcolStudentFirstName.Visible = true;
            // 
            // gcolStudentLastName
            // 
            gcolStudentLastName.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentLastName.Caption = "Tên";
            gcolStudentLastName.FieldName = "StudentLastName";
            gcolStudentLastName.Name = "gcolStudentLastName";
            gcolStudentLastName.Visible = true;

            // gcolBirthday            
            gcolBirthday.Caption = "Ngày sinh";
            gcolBirthday.FieldName = "BirthDateText";
            gcolBirthday.Name = "gcolBirthday";
           
            gcolBirthday.Visible = true;
            gcolBirthday.AppearanceHeader.Options.UseTextOptions = true;
            gcolBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolBirthday.AppearanceCell.Options.UseTextOptions = true;
            gcolBirthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // gcolGenderText
            
            gcolGenderText.Caption = "Giới tính";
            gcolGenderText.FieldName = "GenderText";
            gcolGenderText.Name = "gcolGenderText";            
            gcolGenderText.Visible = true;
            gcolGenderText.AppearanceHeader.Options.UseTextOptions = true;
            gcolGenderText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGenderText.AppearanceCell.Options.UseTextOptions = true;
            gcolGenderText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            // 
            // gbSummary
            // 
            gbSummary.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbSummary.AppearanceHeader.Options.UseFont = true;
            gbSummary.AppearanceHeader.Options.UseTextOptions = true;
            gbSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSummary.Caption = "TỔNG KẾT";
            gbSummary.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gbSummaryEthic,
            gbSummaryLearning});
            gbSummary.Name = "gbSummary";
            gbSummary.Width = 300;

            // 
            // gbSummaryEthic
            // 
            gbSummaryEthic.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbSummaryEthic.AppearanceHeader.Options.UseFont = true;
            gbSummaryEthic.AppearanceHeader.Options.UseTextOptions = true;
            gbSummaryEthic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSummaryEthic.Caption = "Rèn luyện";
            gbSummaryEthic.Columns.Add(gcolSummaryEthicMark);
            gbSummaryEthic.Columns.Add(gcolEthicLevel);
            gbSummaryEthic.Name = "gbSummaryEthic";
            gbSummaryEthic.Width = 150;
            // 
            // gcolSummaryEthicMark
            // 
            gcolSummaryEthicMark.AppearanceHeader.Options.UseTextOptions = true;
            gcolSummaryEthicMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSummaryEthicMark.Caption = "Điểm";
            gcolSummaryEthicMark.FieldName = "EthicMark";
            gcolSummaryEthicMark.Name = "gcolSummaryEthicMark";
            gcolSummaryEthicMark.Visible = true;
            // 
            // gcolEthicLevel
            // 
            gcolEthicLevel.AppearanceHeader.Options.UseTextOptions = true;
            gcolEthicLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolEthicLevel.Caption = "Xếp loại";
            gcolEthicLevel.FieldName = "EthicLevel";
            gcolEthicLevel.Name = "gcolEthicLevel";
            gcolEthicLevel.Visible = true;
            
            // 
            // gbSummaryLearning
            // 
            gbSummaryLearning.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbSummaryLearning.AppearanceHeader.Options.UseFont = true;
            gbSummaryLearning.AppearanceHeader.Options.UseTextOptions = true;
            gbSummaryLearning.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSummaryLearning.Caption = "Học tập";
            gbSummaryLearning.Columns.Add(gcolSummaryLearningMark);
            gbSummaryLearning.Columns.Add(gcolLearningLevel);
            gbSummaryLearning.Name = "gbSummaryLearning";
            gbSummaryLearning.Width = 150;
            
            // 
            // gcolSummaryLearningMark
            // 
            gcolSummaryLearningMark.AppearanceHeader.Options.UseTextOptions = true;
            gcolSummaryLearningMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSummaryLearningMark.Caption = "TBC";
            gcolSummaryLearningMark.FieldName = "SummaryLearningMark";
            gcolSummaryLearningMark.Name = "gcolSummaryLearningMark";
            gcolSummaryLearningMark.Visible = true;
            // 
            // gcolLearningLevel
            // 
            gcolLearningLevel.AppearanceHeader.Options.UseTextOptions = true;
            gcolLearningLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolLearningLevel.Caption = "Xếp loại";
            gcolLearningLevel.FieldName = "LearningLevel";
            gcolLearningLevel.Name = "gcolLearningLevel";
            gcolLearningLevel.Visible = true;
            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gbSummary.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;


        }

        private void RepairDataAndGrid()
        {

            dtbData.Columns.Add("SummaryLearningMark", typeof(double));
            dtbData.Columns.Add("LearningLevel", typeof(string));

            dtbData.Columns.Add("SomeDebt", typeof(int));// Số môn nợ cuối cùng
            dtbData.Columns.Add("SomeCredidDebt", typeof(int)); // Số ĐVHT nợ cuối cùng
            dtbData.Columns.Add("DebtRatio", typeof(double));

            bolHaveNormalSubject = false; // tìm thử có môn bình thường hông
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                drw["SubjectIndex"] = i;
                int intSpecialType = Convert.ToInt32(drw["SpecialType"]);
                if (intSpecialType == Global.SubjectSpecialType.BinhThuong)  // môn bình thường
                    bolHaveNormalSubject = true; // có thì khi tính trung bình chỉ lấy môn bình thường mà tính, ngược lại chỉ lấy môn văn hoá

                string strSubjectID = drw["SubjectID"].ToString();
                string strSubjectCaption = drw["SubjectShortName"].ToString();

                dtbData.Columns.Add("TestAverage_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("Exam1_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("Summary1_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("Exam2_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("Summary2_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("Exam3_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("Summary3_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("FinalExam_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("FinalSummary_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("OrderLearning_" + i.ToString(), typeof(double));

                dtbData.Columns.Add("LearningLevel_" + i.ToString(), typeof(string)); // Mức đạt môn A, B, C, D, F của tín chỉ
                dtbData.Columns.Add("OtherFinalSummary_" + i.ToString(), typeof(double)); // điểm qui đổi theo mức của tính chỉ
                dtbData.Columns.Add("Passed_" + i.ToString(), typeof(bool));


                // Add mon hoc nay vao gbSemester
                GridBand gbSubject = new GridBand();
                gbSubject.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubject.AppearanceHeader.Options.UseFont = true;
                gbSubject.AppearanceHeader.Options.UseTextOptions = true;
                gbSubject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubject.Caption = strSubjectCaption;
                gbSubject.Name = "gbSubject" + i.ToString();
                gbSubject.Width = 375;

                if (intRegulationIDCurrent == 43 || intRegulationIDCurrent == 99 || intRegulationIDCurrent == 44) // cột của môn theo qui chế tín chỉ
                {
                    // 
                    // gcolFinalSummary_
                    //                
                    BandedGridColumn gcolFinalSummary = new BandedGridColumn();
                    gcolFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                    gcolFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolFinalSummary.Caption = "TKM";
                    gcolFinalSummary.FieldName = "FinalSummary_" + i.ToString();
                    gcolFinalSummary.Name = "gcolFinalSummary_" + i.ToString();
                    gcolFinalSummary.Visible = true;
                    gcolFinalSummary.AppearanceCell.Options.UseBackColor = true;

                    // 
                    // gcolLearningLevel_ -------------------Mức độ đạt của môn
                    //                
                    BandedGridColumn gcolLearningLevel = new BandedGridColumn();
                    gcolLearningLevel.AppearanceHeader.Options.UseTextOptions = true;
                    gcolLearningLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolLearningLevel.Caption = "QĐChữ";
                    gcolLearningLevel.FieldName = "LearningLevel_" + i.ToString();
                    gcolLearningLevel.Name = "gcolLearningLevel_" + i.ToString();
                    gcolLearningLevel.Visible = true;
                    gcolLearningLevel.AppearanceCell.Options.UseBackColor = true;

                    // 
                    // gcolOtherFinalSummary_ ------------------ Điểm qui đổi theo mức
                    //                
                    BandedGridColumn gcolOtherFinalSummary = new BandedGridColumn();
                    gcolOtherFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                    gcolOtherFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolOtherFinalSummary.Caption = "QĐSố";
                    gcolOtherFinalSummary.FieldName = "OtherFinalSummary_" + i.ToString();
                    gcolOtherFinalSummary.Name = "gcolOtherFinalSummary_" + i.ToString();
                    gcolOtherFinalSummary.Visible = true;
                    gcolOtherFinalSummary.AppearanceCell.BackColor = Color.LightBlue;
                    gcolOtherFinalSummary.AppearanceCell.Options.UseBackColor = true;

                    // add column vao grid
                    gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {                                           
                                            gcolFinalSummary,
                                            gcolLearningLevel,
                                            gcolOtherFinalSummary});

                    // add cot vao band subject                   
                    gbSubject.Columns.Add(gcolFinalSummary);
                    gbSubject.Columns.Add(gcolLearningLevel);
                    gbSubject.Columns.Add(gcolOtherFinalSummary);
                }
                else // cột của môn theo qui chế khác
                {
                    // 
                    // gcolTestAverage_1
                    // 
                    BandedGridColumn gcolTestAverage = new BandedGridColumn();
                    gcolTestAverage.AppearanceHeader.Options.UseTextOptions = true;
                    gcolTestAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    if (uClass.RegulationID == 25)
                        gcolTestAverage.Caption = "GK";
                    else
                        gcolTestAverage.Caption = "TBKT";
                    gcolTestAverage.FieldName = "TestAverage_" + i.ToString();
                    gcolTestAverage.Name = "gcolTestAverage_" + i.ToString();
                    gcolTestAverage.Visible = true;
                    // 
                    // gcolExam1_
                    // 
                    BandedGridColumn gcolExam1 = new BandedGridColumn();
                    gcolExam1.AppearanceHeader.Options.UseTextOptions = true;
                    gcolExam1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolExam1.Caption = "Thi1";
                    gcolExam1.FieldName = "Exam1_" + i.ToString();
                    gcolExam1.Name = "gcolExam1_" + i.ToString();
                    gcolExam1.Visible = true;
                    // 
                    // gcolSummary1_
                    // 
                    BandedGridColumn gcolSummary1 = new BandedGridColumn();
                    gcolSummary1.AppearanceHeader.Options.UseTextOptions = true;
                    gcolSummary1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolSummary1.Caption = "TKM1";
                    gcolSummary1.FieldName = "Summary1_" + i.ToString();
                    gcolSummary1.Name = "gcolSummary1_" + i.ToString();
                    gcolSummary1.Visible = true;
                    // 
                    // gcolExam2_
                    // 
                    BandedGridColumn gcolExam2 = new BandedGridColumn();
                    gcolExam2.AppearanceHeader.Options.UseTextOptions = true;
                    gcolExam2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolExam2.Caption = "Thi2";
                    gcolExam2.FieldName = "Exam2_" + i.ToString();
                    gcolExam2.Name = "gcolExam2_" + i.ToString();
                    gcolExam2.Visible = true;
                    // 
                    // gcolSummary2_
                    // 
                    BandedGridColumn gcolSummary2 = new BandedGridColumn();
                    gcolSummary2.AppearanceHeader.Options.UseTextOptions = true;
                    gcolSummary2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolSummary2.Caption = "TKM2";
                    gcolSummary2.FieldName = "Summary2_" + i.ToString();
                    gcolSummary2.Name = "gcolSummary2_" + i.ToString();
                    gcolSummary2.Visible = true;
                    // 
                    // gcolExam3_
                    // 
                    BandedGridColumn gcolExam3 = new BandedGridColumn();
                    gcolExam3.AppearanceHeader.Options.UseTextOptions = true;
                    gcolExam3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolExam3.Caption = "Thi3";
                    gcolExam3.FieldName = "Exam3_" + i.ToString();
                    gcolExam3.Name = "gcolExam3_" + i.ToString();
                    gcolExam3.Visible = true;

                    // 
                    // gcolSummary3_
                    // 
                    BandedGridColumn gcolSummary3 = new BandedGridColumn();
                    gcolSummary3.AppearanceHeader.Options.UseTextOptions = true;
                    gcolSummary3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolSummary3.Caption = "TKM3";
                    gcolSummary3.FieldName = "Summary3_" + i.ToString();
                    gcolSummary3.Name = "gcolSummary3_" + i.ToString();
                    gcolSummary3.Visible = true;


                    // 
                    // gcolFinalExam_
                    //                
                    BandedGridColumn gcolFinalExam = new BandedGridColumn();
                    gcolFinalExam.AppearanceHeader.Options.UseTextOptions = true;
                    gcolFinalExam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolFinalExam.Caption = "Thi";
                    gcolFinalExam.FieldName = "FinalExam_" + i.ToString();
                    gcolFinalExam.Name = "gcolFinalExam_" + i.ToString();
                    gcolFinalExam.Visible = true;
                    gcolFinalExam.AppearanceCell.BackColor = Color.LightBlue;
                    gcolFinalExam.AppearanceCell.Options.UseBackColor = true;
                    // 
                    // gcolFinalSummary_
                    //                
                    BandedGridColumn gcolFinalSummary = new BandedGridColumn();
                    gcolFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                    gcolFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolFinalSummary.Caption = "TKM";
                    gcolFinalSummary.FieldName = "FinalSummary_" + i.ToString();
                    gcolFinalSummary.Name = "gcolFinalSummary_" + i.ToString();
                    gcolFinalSummary.Visible = true;
                    gcolFinalSummary.AppearanceCell.BackColor = Color.LightBlue;
                    gcolFinalSummary.AppearanceCell.Options.UseBackColor = true;

                    // 
                    // gcolLearningLevel_ -------------------Mức độ đạt của môn
                    //                
                    BandedGridColumn gcolLearningLevel = new BandedGridColumn();
                    gcolLearningLevel.AppearanceHeader.Options.UseTextOptions = true;
                    gcolLearningLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolLearningLevel.Caption = "QĐChữ";
                    gcolLearningLevel.FieldName = "FinalSummary_" + i.ToString();
                    gcolLearningLevel.Name = "gcolLearningLevel_" + i.ToString();
                    gcolLearningLevel.Visible = true;
                    gcolLearningLevel.AppearanceCell.BackColor = Color.LightBlue;
                    gcolLearningLevel.AppearanceCell.Options.UseBackColor = true;

                    // 
                    // gcolOtherFinalSummary_ ------------------ Điểm qui đổi theo mức
                    //                
                    BandedGridColumn gcolOtherFinalSummary = new BandedGridColumn();
                    gcolOtherFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                    gcolOtherFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolOtherFinalSummary.Caption = "QĐSố";
                    gcolOtherFinalSummary.FieldName = "FinalSummary_" + i.ToString();
                    gcolOtherFinalSummary.Name = "gcolOtherFinalSummary_" + i.ToString();
                    gcolOtherFinalSummary.Visible = true;

                    // add column vao grid
                    gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                                            gcolTestAverage,
                                            gcolExam1,
                                            gcolSummary1,
                                            gcolExam2,
                                            gcolSummary2,
                                            gcolExam3,
                                            gcolSummary3,
                                            gcolFinalExam,
                                            gcolFinalSummary});

                    // add cot vao band subject
                    gbSubject.Columns.Add(gcolTestAverage);
                    gbSubject.Columns.Add(gcolExam1);
                    gbSubject.Columns.Add(gcolSummary1);
                    gbSubject.Columns.Add(gcolExam2);
                    gbSubject.Columns.Add(gcolSummary2);
                    gbSubject.Columns.Add(gcolExam3);
                    gbSubject.Columns.Add(gcolSummary3);
                    gbSubject.Columns.Add(gcolFinalExam);
                    gbSubject.Columns.Add(gcolFinalSummary);

                    gvData.Bands.Add(gbSubject);
                    i++;

                }

            }
        }       

        private void FillData()
        {
            for (int i = 0; i < 7; i++)
                arrStatisticCount[i] = 0;

            // Ethic Mark
            DataTable dtbEthicMark;
            dtbEthicMark = new SIM_SummaryEthicMark().Search("@YearID", uYearSemester.YearIDEditValue, "@ClassID", uClass.ClassIDEditValue);
            

            foreach (DataRow drw in dtbData.Rows)
            {
                double dblTotalMark = 0;
                int intUnitTextCount = 0;
                int SomeDebt = 0;
                double SomeCredidDebt = 0;
                double DebtRatio = 0;

                DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                {
                    string strSubjectID = drw2["SubjectID"].ToString();

                    DataRow[] rowSubjects = dtbClassSubject.Select("SubjectID='" + strSubjectID + "'");
                    if (rowSubjects.Length > 0)
                    {
                        string strIndex = rowSubjects[0]["SubjectIndex"].ToString();
                        drw["OrderLearning_" + strIndex] = drw2["OrderLearning"];
                        if (Convert.ToBoolean(drw2["IsIgnore"])) // nếu là môn Miễn
                        {
                            drw["Summary1_" + strIndex] = "-1";
                            drw["Summary2_" + strIndex] = "-1";
                            drw["Summary3_" + strIndex] = "-1";
                            drw["FinalSummary_" + strIndex] = "-1";
                        }
                        else
                        {

                            if (intRegulationIDCurrent == 43 || intRegulationIDCurrent == 99 || intRegulationIDCurrent == 44) // theo qui chế tín chỉ 09
                            {
                                drw["FinalSummary_" + strIndex] = drw2["FinalSummary"]; //TKM
                                drw["LearningLevel_" + strIndex] = drw2["LearningLevel"]; // qui đổi chữ
                                drw["OtherFinalSummary_" + strIndex] = drw2["OtherFinalSummary"]; // qui đổi số

                                // tính TBC và xếp loại theo qui chế 14
                                if (drw2["OtherFinalSummary"].ToString() != "")
                                {
                                    int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                    dblTotalMark += Convert.ToDouble(drw2["OtherFinalSummary"]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                    intUnitTextCount += intUnitText;
                                }

                            }
                            else // không phải tính chỉ
                            {
                                double? dblExam1 = 0;
                                if (drw2["Exam1"].ToString() != "")
                                    dblExam1 = Convert.ToDouble(drw2["Exam1"]);

                                drw["TestAverage_" + strIndex] = drw2["TestAverage"];
                                drw["Exam1_" + strIndex] = drw2["Exam1"];
                                drw["Summary1_" + strIndex] = drw2["Summary1"];

                                // nếu xét lần thi 1 thôi thì mình bỏ qua các lần thi khác
                                if (chkViewOnlyExam1.Checked)
                                {
                                    drw["FinalSummary_" + strIndex] = drw2["Summary1"];
                                    Decimal dSummary1 = 0;
                                    if (drw["FinalSummary_" + strIndex].ToString() != "")
                                        dSummary1 = Convert.ToDecimal(drw["FinalSummary_" + strIndex]);
                                    if (dSummary1 < 5 || (intRegulationIDCurrent !=9 && dblExam1 < 5)) // Kiem tra lần đầu môn đạt chưa
                                    {
                                        SomeDebt += 1;
                                        SomeCredidDebt += Convert.ToInt32(drw2["UnitText"]);
                                        drw["Passed_" + strIndex] = false;
                                    }
                                    else
                                        drw["Passed_" + strIndex] = true;

                                }
                                else
                                {
                                    drw["Exam2_" + strIndex] = drw2["Exam2"];
                                    drw["Summary2_" + strIndex] = drw2["Summary2"];

                                    drw["Exam3_" + strIndex] = drw2["Exam3"];
                                    drw["Summary3_" + strIndex] = drw2["Summary3"];

                                    drw["FinalExam_" + strIndex] = drw2["FinalExam"];
                                    drw["FinalSummary_" + strIndex] = drw2["FinalSummary"];

                                    // Tinh so môn nợ, Tổng ĐVHT nợ.
                                    if (drw2["Passed"].ToString() == "0")
                                    {
                                        SomeDebt += 1;
                                        SomeCredidDebt += Convert.ToInt32(drw2["UnitText"]);
                                        drw["Passed_" + strIndex] = false;
                                    }
                                    else
                                        drw["Passed_" + strIndex] = true;
                                }

                                // cộng dồn để tính điểm tổng kết
                                //int intSpecialType = Convert.ToInt32(drw2["SpecialType"]);
                                //if (drw["FinalSummary_" + strIndex].ToString() != "")
                                //{
                                //    int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                //    dblTotalMark += Convert.ToDouble(drw["FinalSummary_" + strIndex]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                //    intUnitTextCount += intUnitText;
                                //}
                                // cộng dồn để tính điểm tổng kết
                                int intSpecialType = Convert.ToInt32(drw2["SpecialType"]);
                                if ((bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.BinhThuong)  // khi có môn bình thường thì chỉ tính môn bình thường
                                        || (!bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.VanHoa)//Khi có môn văn hóa thì tính môn văn hóa
                                    || intSpecialType == 9 && (intRegulationIDCurrent == 99 || intRegulationIDCurrent == 9 || intRegulationIDCurrent == 44 || intRegulationIDCurrent == 4))//môn chính trị
                                {
                                    if (drw["FinalSummary_" + strIndex].ToString() != "")
                                    {
                                        int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                        dblTotalMark += Convert.ToDouble(drw["FinalSummary_" + strIndex]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                        intUnitTextCount += intUnitText;
                                    }
                                }
                                else if ((bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.BinhThuong)  // khi có môn bình thường thì chỉ tính môn bình thường
                                        || (!bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.VanHoa)//Khi có môn văn hóa thì tính môn văn hóa
                                    && uClass.RegulationID == 14)
                                {
                                    if (drw["FinalSummary_" + strIndex].ToString() != "")
                                    {
                                        int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                        dblTotalMark += Convert.ToDouble(drw["FinalSummary_" + strIndex]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                        intUnitTextCount += intUnitText;
                                    }
                                }
                                else if ((bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.BinhThuong)  // khi có môn bình thường thì chỉ tính môn bình thường
                                        || (!bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.VanHoa))//Khi có môn văn hóa thì tính môn văn hóa)
                                {
                                    if (drw["FinalSummary_" + strIndex].ToString() != "")
                                    {
                                        int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                        dblTotalMark += Convert.ToDouble(drw["FinalSummary_" + strIndex]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                        intUnitTextCount += intUnitText;
                                    }
                                }
                                //if (chkViewOnlyExamFinally.Checked)
                                //{
                                //    if ((bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.BinhThuong)  // khi có môn bình thường thì chỉ tính môn bình thường
                                //        || (!bolHaveNormalSubject && intSpecialType == Global.SubjectSpecialType.VanHoa)) // hoặc khi không có môn bình thường thì chỉ tính môn văn hoá
                                //    {
                                //        if (drw["FinalSummary_" + strIndex].ToString() != "")
                                //        {
                                //            int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                //            dblTotalMark += Convert.ToDouble(drw["FinalSummary_" + strIndex]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                //            intUnitTextCount += intUnitText;
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //    if (drw["FinalSummary_" + strIndex].ToString() != "")
                                //    {
                                //        int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                //        dblTotalMark += Convert.ToDouble(drw["FinalSummary_" + strIndex]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                //        intUnitTextCount += intUnitText;
                                //    }
                                //}
                            }
                        }
                    }
                }

                // tính TBC và xếp loại
                if (intUnitTextCount > 0)
                {
                    double dblSummaryLearningMark = 0;
                    
                    if(uClass.RegulationID.Value==25) // riêng qui chế 25 có 2 chữ số lẻ
                        dblSummaryLearningMark = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(dblTotalMark) / intUnitTextCount, 2, MidpointRounding.AwayFromZero));
                    else // còn lại là lấy 1 chữ số lẻ
                        dblSummaryLearningMark = Convert.ToDouble(Decimal.Round(Convert.ToDecimal(dblTotalMark) / intUnitTextCount, 1, MidpointRounding.AwayFromZero));
                    drw["SummaryLearningMark"] = dblSummaryLearningMark;
                    DebtRatio = SomeCredidDebt*100/intUnitTextCount;// Tính tỉ lệ nợ môn sau đó gán vào table
                    drw["SomeDebt"] = SomeDebt;
                    drw["SomeCredidDebt"] = SomeCredidDebt;
                    drw["DebtRatio"] = DebtRatio;

                    #region code cũ

                    //string strLearningLevel = "";


                    //if (intRegulationIDCurrent == 43 || intRegulationIDCurrent == 99) // theo qui chế tín chỉ 09
                    //{
                    //    // Xét Điểm số A,B,C,D, F
                    //    if (dblSummaryLearningMark >= 8.5)                        
                    //        strLearningLevel = "A";                            
                    //    else if (dblSummaryLearningMark >= 7)
                    //        strLearningLevel = "B";
                    //    else if (dblSummaryLearningMark >= 5.5)
                    //        strLearningLevel = "C";
                    //    else if (dblSummaryLearningMark >= 4)
                    //        strLearningLevel = "D";
                    //    else
                    //        strLearningLevel = "F";
                    //}
                    //else // theo qui chế khác
                    //{
                    //    if (dblSummaryLearningMark < 4)
                    //    {
                    //        strLearningLevel = "Kém";
                    //        arrStatisticCount[5]++; // thống kê chung Yếu kém
                    //    }            
                    //    else if (dblSummaryLearningMark < 5)
                    //    {
                    //        strLearningLevel = "Yếu";
                    //        arrStatisticCount[5]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 6)
                    //    {
                    //        strLearningLevel = "Trung bình";
                    //        arrStatisticCount[4]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 7)
                    //    {
                    //        strLearningLevel = "TB khá";
                    //        arrStatisticCount[3]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 8)
                    //    {
                    //        strLearningLevel = "Khá";
                    //        arrStatisticCount[2]++;
                    //    }
                    //    else if(dblSummaryLearningMark < 9)
                    //    {
                    //        // chỉ hạ bậc cho qui chế 22 và qui chế 09
                    //        if (
                    //            // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                    //               (intRegulationIDCurrent == 22 && (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != ""))
                    //               ||
                    //            // có 1 môn thi lại (không tính môn điều kiện) hoặc bị kỷ luật cảnh cáo trở lên thì hạ bậc
                    //               (intRegulationIDCurrent == 9 && (Convert.ToInt32(drw["SoMonBinhThuongThiLai"]) > 0 || drw["SanctionFormID"].ToString() != ""))
                    //           ) 
                    //        {
                    //            strLearningLevel = "Khá";
                    //            arrStatisticCount[2]++;
                    //        }
                    //        else
                    //        {
                    //            strLearningLevel = "Giỏi";
                    //            arrStatisticCount[1]++;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        // chỉ hạ bậc cho qui chế 22 và qui chế 09
                    //        if (
                    //            // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                    //                (intRegulationIDCurrent == 22 && (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != ""))
                    //                ||
                    //            // có 1 môn thi lại (không tính môn điều kiện) hoặc bị kỷ luật cảnh cáo trở lên thì hạ bậc
                    //                (intRegulationIDCurrent == 9 && (Convert.ToInt32(drw["SoMonBinhThuongThiLai"]) > 0 || drw["SanctionFormID"].ToString() != ""))
                    //            )
                    //        {
                    //            strLearningLevel = "Giỏi";
                    //            arrStatisticCount[1]++;
                    //        }
                    //        else
                    //        {
                    //            strLearningLevel = "Xuất sắc";
                    //            arrStatisticCount[0]++;
                    //        }
                    //    }
                    //}

                    //drw["LearningLevel"] = strLearningLevel;

                    #endregion

                }

                drw["LearningLevel"] = SimsService.SIM_SubjectMarkService.ToLearningLevel(drw, intRegulationIDCurrent, chkXemTheoNienChe.Checked); // Mr Việt chuyển xếp loại vào service


                // Điền Ethic mark vào
                rows = dtbEthicMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                if (rows.Length > 0)
                {
                    if (uYearSemester.SemesterEditValue != null)
                    {

                        drw["EthicMark"] = rows[0]["EthicMark"+uYearSemester.SemesterEditValue.ToString()];
                        drw["EthicLevel"] = rows[0]["EthicLevel" + uYearSemester.SemesterEditValue.ToString()];
                    }
                    else
                    {
                        drw["EthicMark"] = rows[0]["EthicMark" ];
                        drw["EthicLevel"] = rows[0]["EthicLevel"];
                    }
                }
            }

        }

        /// <summary>
        /// Cập nhật tổng kết điểm học tập. Vừa thêm, vừa cập nhật nếu cả có
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            SIM_SummaryLearningMark item = new SIM_SummaryLearningMark();
            item.BeginTransaction();
            item.YearID = intYearID;
            item.UpdatedUser = UserSession.Username; // them hay update deu dung truong nay

            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw["SummaryLearningMark"].ToString() != "") // có điểm tổng kết mới lưu
                {
                    item.StudentID = Convert.ToInt32(drw["StudentID"]);
                    item.Summary = Convert.ToDouble(drw["SummaryLearningMark"]);
                    item.LearningLevel = drw["LearningLevel"].ToString();

                    //item.OtherSummary = Convert.ToDouble(drw["OtherSummaryLearningMark"]);
                    //item.OtherLearningLevel = item.LearningLevel; // Đây là xếp loại hệ 4

                    if (!item.AddOrUpdate(intSemester))
                    {
                        ErrorManager.Error("Việc cập nhật tổng kết điểm học tập bị lỗi!");
                        return false;
                    }
                }
            }

            item.CommitTransaction();
            return true;
        }

        private void ModifyGrid()
        {

            if (chkViewOnlyExam1.Checked) // nếu chỉ tính lần một thì bỏ hết lần 2,3 đi
            {
                foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
                {
                    if (col.FieldName.Contains("Exam2_") || col.FieldName.Contains("Exam3_")|| col.FieldName.Contains("FinalExam_") || col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Summary3_") || col.FieldName.Contains("FinalSummary_"))
                        col.Visible = false;
                }
            }

            #region Deleted


            /*
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                col.OptionsColumn.AllowEdit = true;
                if (col.FieldName.Contains("Mark"))
                {
                    col.Caption = col.FieldName.Replace("Mark", "HS ");
                    col.DisplayFormat.FormatString = "#0.#";
                    col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                }                
                else
                {
                    switch (col.FieldName)
                    {
                        case "Order":
                            col.Caption = "STT";
                            col.OptionsColumn.AllowEdit = false;
                            break;
                        case "StudentFirstName":
                            col.Caption = "Họ lót";
                            col.OptionsColumn.AllowEdit = false;
                            break;
                        case "StudentLastName":
                            col.Caption = "Tên";
                            col.OptionsColumn.AllowEdit = false;
                            break;
                        case "TestAverage":
                            col.DisplayFormat.FormatString = "##.#";
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F,FontStyle.Bold);
                            col.Caption = "TBKT";
                            col.OptionsColumn.AllowEdit = false;                           
                            break;
                        case "Exam1":
                            col.DisplayFormat.FormatString = "#0.#";
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.Caption = "Thi lần 1";
                            break;
                        case "Exam2":
                            col.DisplayFormat.FormatString = "#0.#";
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.Caption = "Thi lần 2";
                            break;
                        case "Summary1":
                            col.DisplayFormat.FormatString = "##.#";
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.Caption = "TKM lần 1";
                            col.OptionsColumn.AllowEdit = false;
                            col.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, FontStyle.Bold);
                            break;
                        case "Summary2":
                            col.DisplayFormat.FormatString = "##.#";
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.Caption = "TKM lần 2";
                            col.OptionsColumn.AllowEdit = false;
                            col.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, FontStyle.Bold);
                            break;
                        case "FinalSummary":
                            col.DisplayFormat.FormatString = "##.#";
                            col.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                            col.Caption = "TKM";
                            col.OptionsColumn.AllowEdit = false;
                            col.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8F, FontStyle.Bold);
                            break;
                        default:
                            col.Visible = false;
                            break;
                    }
                }
            }
            */
            #endregion

            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    ModifyGrid14();
                    break;
                case 40: // trung cấp chuyên nghiệp
                    ModifyGrid40();
                    break;
                case 46: // trung cấp vừa học vừa làm
                    ModifyGrid46();
                    break;
                case 43:
                    ModifyGrid43();
                    break;
                case 25: 
                    ModifyGrid25(); // cao đẳng chính qui
                    break;
                case 04:
                case 09: // trung cấp, cao đẳng 2017
                    ModifyGrid09();
                    break;
                case 44:
                case 99: // tín chỉ
                    ModifyGrid09_TinChi();
                    break;
                default:
                    ModifyGrid09();
                    break;

            }

        }

        #region Ẩn cột trên lưới theo từng qui chế

        private void ModifyGrid14()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Summary3_") || col.FieldName.Contains("Exam3_") || col.FieldName.Contains("TestAverage_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
                    col.Visible = false;
            }
        }

        private void ModifyGrid40()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Exam3_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
                    col.Visible = false;
            }
        }

        private void ModifyGrid46()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Exam3_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
                    col.Visible = false;
            }
        }

        private void ModifyGrid43()
        {

        }

        private void ModifyGrid25()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Exam3_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
                    col.Visible = false;
            }
        }
        private void ModifyGrid09()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Exam3_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
                    col.Visible = false;
            }
        }

        private void ModifyGrid09_TinChi()
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Exam3_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
                    col.Visible = false;
            }

            gvData.Columns["OtherLearningSummary"].Visible = true;
        }


        #endregion       

        private void ExportToHTML()
        {
            string strHead = HeaderToHTML();

            string strFileName = "SubjectMarkDetail.htm";

            string str = "";
            string strRow = "";          

            int n = gvData.RowCount;
            int m = gvData.Columns.Count;
            
            for (int i = n - 1; i >= 0; i--)
            {                
                DataRow drw = gvData.GetDataRow(i);                
                strRow = "";

                for (int j = 0; j < m; j++)
                {
                    string strColumn=gvData.Columns[j].FieldName;
                    if (gvData.Columns[j].Visible)
                    {
                        string strStyle = "";
                        string strValue = drw[gvData.Columns[j].FieldName].ToString();
                        if (strValue.Length < 1)
                            strValue = "&nbsp;";
                        if (strValue == "-1")
                            strValue = "M";
                        if (strColumn == "StudentFirstName")
                            strStyle = " style='text-align:left; border-right:none; min-width:100px' ";
                        else if (strColumn == "StudentCode")
                            strStyle = " style='min-width:60px' ";
                        else if (strColumn == "EthicLevel")
                            strStyle = " style='min-width:50px' ";
                        else if (strColumn == "LearningLevel")
                            strStyle = " style='min-width:50px' ";
                        else if (strColumn == "StudentLastName")
                            strStyle = " style='text-align:left; border-left:none' ";
                        else
                        {
                            if (chkViewOnlyExam1.Checked)
                            {
                                if (strColumn.Contains("Summary1_") && strValue != "&nbsp;" && strValue != "M" && Convert.ToDouble(strValue) < 5)
                                    strStyle = " style='background-color:Yellow;' ";
                            }
                            else
                            {                                
                                if (strColumn.Contains("FinalSummary_") && strValue != "&nbsp;" && strValue!="M" && Convert.ToDouble(strValue) < 5)
                                    strStyle = " style='background-color:Yellow;' ";
                            }
                        }
                        strRow += "<td " + strStyle + ">" + strValue + "</td>";
                    }
                }
                strRow = "<tr>" + strRow + "</tr>\r\n";
                str = strRow + str;
            }

            
            str = "<table>" + strHead + str +  "</table>";

            //cộng thêm thống kê
            str += "</br>" + StatisticToHTML();

            string strTitle = "<table><tr><td colspan='2'>BẢNG TỔNG KẾT ĐIỂM ";
            if (chkViewOnlyExam1.Checked)
                strTitle += " LẦN 1";

            if (uYearSemester.SemesterEditValue != null)
                strTitle += " _ HỌC KÌ " + uYearSemester.SemesterEditValue.ToString();
            strTitle += " _ NIÊN HỌC " + uYearSemester.YearEditValueText;
            strTitle += "</td></tr>";

            strTitle += "<tr><td>KHOÁ HỌC: " + uClass.CourseName + "</td><td>BẬC: " + uClass.TrainingLevelName + "</td></tr>"
                     + "<tr><td>NGHỀ: " + uClass.BranchName + "</td><td>LỚP: " + uClass.ClassName + "</td></tr></table>";

            if (intRegulationIDCurrent == 25)
                strTitle.Replace("NGHỀ:", "NGÀNH:");


            string strFileContent = Libs.Files.ReadFile(strFileName);            
            strFileContent = strFileContent.Replace("{TITLE}", strTitle);
            strFileContent = strFileContent.Replace("{DETAIL}", str);

            //strFileContent = strFileContent.Replace("{HEADER}", strReport_Header);
            strFileContent = strFileContent.Replace("{HEADER_TOP}", strReport_Header_Expand);
            strFileContent = strFileContent.Replace("{HEADER}", strReport_Header);
            strFileContent = strFileContent.Replace("{PLACE}", strReport_Place);

            string strFileNameAs = uClass.ClassIDEditValue + "_" + strFileName;
            Libs.Files.WriteFile(strFileNameAs, strFileContent);
            System.Diagnostics.Process.Start(strFileNameAs);
        }

        private string HeaderToHTML()
        {
            string strRow0 = "<tr style='background-color:#cccccc; font-weight:bold'>";
            string strRow1 = "<tr style='background-color:#cccccc; font-weight:bold'>";
            string strRow2 = "<tr style='background-color:#cccccc; font-weight:bold'>";

            // band cấp 0
            foreach (GridBand band in gvData.Bands)
            {
                if (band.Visible)
                {
                    if (band.Children.Count > 0) // nếu có band cấp 1 thì quét band cấp 1 rồi lấy column bỏ vô
                    {
                        int intColspan0 = 0;
                        foreach (GridBand band1 in band.Children)
                        {

                            int intColspan = 0;
                            foreach (BandedGridColumn gcol in band1.Columns)
                            {
                                if (!gcol.Visible)
                                    continue;

                                if (gcol.FieldName == "StudentFirstName")
                                    strRow2 += "<td colspan='2'>Họ và tên</td>";
                                else if (gcol.FieldName != "StudentLastName")
                                    strRow2 += "<td>" + gcol.Caption + "</td>";
                                intColspan++;
                            }
                            if (intColspan > 0)
                            {
                                strRow1 += "<td colspan='" + intColspan.ToString() + "'>" + band1.Caption + "</td>";
                                intColspan0+= intColspan; // là tổng cột cấp 2
                            }
                        }
                        if (intColspan0 > 0)
                            strRow0 += "<td colspan='" + intColspan0.ToString() + "'>" + band.Caption + "</td>";
                    }
                    else // không có band cấp 1 thì lấy luôn column
                    {
                        int intColspan = 0;
                        foreach (BandedGridColumn gcol in band.Columns)
                        {
                            if (!gcol.Visible)
                                continue;

                            if (gcol.FieldName == "StudentFirstName")
                                strRow2 += "<td colspan='2'>Họ và tên</td>";
                            else if (gcol.FieldName != "StudentLastName")
                                strRow2 += "<td>" + gcol.Caption + "</td>";
                            intColspan++;
                        }
                        strRow0 += "<td colspan='" + intColspan.ToString() + "' rowspan='2'>" + band.Caption + "</td>";
                    }
                }
            }

            strRow0 += "</tr>\r\n";
            strRow1 += "</tr>\r\n";
            strRow2 += "</tr>\r\n";

            return strRow0 + strRow1 + strRow2;
        }

        private string StatisticToHTML()
        {
            DataTable dtbSummary = SimsService.SIM_SubjectMarkService.SummaryStatistic_OfCourse(dtbData, intRegulationIDCurrent); // Mr Việt: thống kê xếp loại theo cột LearningLevel

            string strRow = "<table><tr>";
            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                DataRow drw = dtbSummary.Rows[i];
                strRow += "<td style='background-color:#cccccc;'>" + drw["Title"] + "</td><td>"
                   + drw["Quantity"] + " (" + drw["Percent"] + "%)</td>";
            }
            strRow += "</tr></table>";
            return strRow;

            //double dblCount = gvData.RowCount;
            //string[] strCaption = { "Xuất sắc", "Giỏi", "Khá", "TB khá", "Trung bình", "Yếu kém" };
            //string strRow = "<table><tr>";
            //for (int i = 0; i < 6; i++)
            //{
            //    strRow += "<td style='background-color:#cccccc;'>" + strCaption[i] + "</td><td>"
            //       + arrStatisticCount[i].ToString() + " (" + Math.Round(arrStatisticCount[i] / dblCount * 100,0).ToString() + "%)</td>";
            //}
            //strRow += "</tr></table>";

            //return strRow;
        }

        #endregion


        #region Form Actions

        private void frmMakeStudentCode_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
                new Thread(LoadData).Start();
        }

        private void uYearSemester_EditValueChanged(object sender, EventArgs arg)
        {
            if (uYearSemester.YearIDEditValue != null && uClass.ClassIDEditValue != null)
                new Thread(LoadData).Start();
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            if (uYearSemester.YearIDEditValue != null && uClass.ClassIDEditValue != null)
                new Thread(LoadData).Start();
        }

        #endregion

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {                        
            if (e.Column.FieldName.Contains("FinalSummary_") && !e.Column.FieldName.Contains("OtherFinalSummary_"))
            {
                DataRow drw = gvData.GetDataRow(e.RowHandle);
                if (drw != null)
                {
                    if (e.CellValue != null && e.CellValue.ToString()!="" && Convert.ToInt32(e.CellValue) >= 0)
                    {
                        if (!Convert.ToBoolean(drw[e.Column.FieldName.Replace("FinalSummary_","Passed_")]))
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            return;
                        }
                    }
                    
                    //if (drw[e.Column.FieldName.Replace("FinalSummary_", "OrderLearning_")] != DBNull.Value)
                    //{
                    //    int intOrderLearning = Convert.ToInt32(drw[e.Column.FieldName.Replace("FinalSummary_", "OrderLearning_")]);
                    //    if (intOrderLearning == 2)
                    //        e.Appearance.BackColor = Color.OrangeRed;
                    //    else if (intOrderLearning > 2)
                    //        e.Appearance.BackColor = Color.Red;
                    //}
                }
            }
            else if (chkViewOnlyExam1.Checked && e.Column.FieldName.Contains("Summary1_"))
            {
                DataRow drw = gvData.GetDataRow(e.RowHandle);
                if (drw != null)
                {
                    if (e.CellValue != null && e.CellValue.ToString() != "" && Convert.ToInt32(e.CellValue) >=0)
                    {
                        if (!Convert.ToBoolean(drw[e.Column.FieldName.Replace("Summary1_", "Passed_")]))
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            return;
                        }
                    }
                    
                    //if (drw[e.Column.FieldName.Replace("Summary1_", "OrderLearning_")] != DBNull.Value)
                    //{
                    //    int intOrderLearning = Convert.ToInt32(drw[e.Column.FieldName.Replace("Summary1_", "OrderLearning_")]);
                    //    if (intOrderLearning == 2)
                    //        e.Appearance.BackColor = Color.OrangeRed;
                    //    else if (intOrderLearning > 2)
                    //        e.Appearance.BackColor = Color.Red;
                    //}
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveData())
                btnSave.Enabled = mnuItemSave.Enabled = false;
        }
     
        private void btnPrint_Click(object sender, EventArgs e)
        {
            ExportToHTML();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void chkShowColumn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (BandedGridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Ethic"))
                    col.Visible = chkShowEthic.Checked;
                else if (col.FieldName.Contains("TestAverage_"))
                    col.Visible = chkShowTestAverage.Checked;
                else if (col.FieldName.Contains("Exam1_"))
                    col.Visible = chkShowExam1.Checked;
                else if (col.FieldName.Contains("Exam2_"))
                    col.Visible = chkShowExam2.Checked;
                else if (col.FieldName.Contains("Exam3_"))
                    col.Visible = chkShowExam3.Checked;
                else if (col.FieldName.Contains("FinalExam_"))
                    col.Visible = chkShowExam.Checked;
                else if (col.FieldName.Contains("Summary1_"))
                    col.Visible = chkShowSummary1.Checked;
                else if (col.FieldName.Contains("Summary2_"))
                    col.Visible = chkShowSummary2.Checked;
                else if (col.FieldName.Contains("Summary3_"))
                    col.Visible = chkShowSummary3.Checked;
                else if (col.FieldName.Contains("FinalSummary_"))
                    col.Visible = chkShowSummary.Checked;
                gvData.Bands["gbSummary"].Children["gbSummaryEthic"].Visible = chkShowEthic.Checked;
                    
            }
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            uClass.RefrehData();
            uYearSemester.RefrehData();
            btnSearch_Click(null, null);
        }

        private void mnu_BangDiemChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void mnuItemPrintSummary_Click(object sender, EventArgs e)
        {
            string strReport = "";
            if (uYearSemester.SemesterEditValue == null)
            {
                //if (uClass.RegulationID.Value == 40)
                //{
                //    strReport = "Report/StudentManager/Learning/Leaning_BangDiem_NienHoc_QC40.repx";
                //}
                //else if (uClass.RegulationID.Value == 14)
                //{
                //    strReport = "Report/StudentManager/Learning/Leaning_BangDiem_NienHoc_QC14.repx";
                //}
                //else
                strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_QC14.repx";
            }
            else
            {
                if (chkViewOnlyExam1.Checked)
                {
                    //if (uClass.RegulationID.Value == 40)
                    //{
                    //    strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_Lan1_QC40.repx";
                    //}
                    //else if (uClass.RegulationID.Value == 14)
                    //{
                    //    strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_Lan1_QC14.repx";
                    //}
                    //else
                        strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_Lan1_QC14.repx";
                }
                else
                {
                    //if (uClass.RegulationID.Value == 40)
                    //{
                    //    strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_QC40.repx";
                    //}
                    //else if (uClass.RegulationID.Value == 14)
                    //{
                    //    strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_QC14.repx";
                    //}
                    //else
                        strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_QC14.repx";
                }
            }

            DataTable dtbData = (gvData.DataSource as DataView).Table;
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            // Set xep loai tot nghiep
            double iTB = 0; double iTBKha = 0; double iKha = 0; double iTot = 0; double iXuatSac = 0; double iSV = 0; double iYeu = 0;
            for (int j = 0; j < dtbData.Rows.Count; j++)
            {
                iSV += 1;
                if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Yếu" || Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Kém")
                    iYeu += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Trung bình")
                    iTB += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "TB khá")
                    iTBKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Khá")
                    iKha += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Giỏi")
                    iTot += 1;
                else if (Convert.ToString(dtbData.Rows[j]["LearningLevel"]) == "Xuất sắc")
                    iXuatSac += 1;

            }
            // truyen tham so theo ý riêng
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pYear", uYearSemester.YearEditValueText);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);

            //Truyen tham so tinh trung binh, ti le phan tram
            frm.SetParameter("pXuatSac", iXuatSac);
            frm.SetParameter("pTLXuatSac", Math.Round(iXuatSac*100.0/ iSV, 2));
            frm.SetParameter("pTot", iTot);
            frm.SetParameter("pTLTot", Math.Round(iTot * 100.0 / iSV, 2));
            frm.SetParameter("pKha", iKha);
            frm.SetParameter("pTLKha", Math.Round(iKha * 100.0 / iSV, 2));
            frm.SetParameter("pTBKha", iTBKha);
            frm.SetParameter("pTLTBKha", Math.Round(iTBKha * 100.0 / iSV, 2));
            frm.SetParameter("pTB", iTB);
            frm.SetParameter("pTLTB", Math.Round(iTB * 100.0 / iSV, 2));
            frm.SetParameter("pYeu", iYeu);
            frm.SetParameter("pTLYeu", Math.Round(iYeu * 100.0 / iSV, 2));
            frm.SetParameter("pSV", iSV);

            //Danh sách môn theo tham số tùy đặt tên mà gán lại
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"].ToString());
                frm.SetParameter("pSubjectShortName" + i.ToString(), drw["SubjectShortName"].ToString());
                //frm.SetParameter("pClassShortName" + i.ToString(), drw["ClassShortName"].ToString());
                frm.SetParameter("pUnitText" + i.ToString(), drw["UnitText"].ToString());
                i++;
            }
            frm.Show();
        }

        private void mnuQuaTrinhHocTap_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                StudentManager.Student.frmStudentInfor frmView = StudentManager.Student.frmStudentInfor.Instance;
                frmView.LoadData(null, Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                frmView.ShowDialog();
            }
        }

        private void mnuItemPrintDetail_VanHoa_Click(object sender, EventArgs e)
        {
            ExportToHTML();
        }

        private void mnuItemPrintDetail_Nghe_Click(object sender, EventArgs e)
        {
            ExportToHTML();
        }

        private void chkVanHoa_CheckedChanged(object sender, EventArgs e)
        {
            if(uClass.ClassIDEditValue != null)
                LoadData();
        }

        private void chkNghe_CheckedChanged(object sender, EventArgs e)
        {
            if (uClass.ClassIDEditValue != null)
                LoadData();
        }

        private void chkViewOnlyExam1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewOnlyExam1.Checked)
            {
                chkViewOnlyExamFinally.Checked = false;
                chkShowSummary.Checked = chkShowExam.Checked = false;
                
            }
            else
            {
                chkViewOnlyExamFinally.Checked = true;
                chkShowSummary.Checked = chkShowExam.Checked = true;
            }
            if (uClass.ClassIDEditValue != null)
                LoadData();
        }

        private void chkViewOnlyExamFinally_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViewOnlyExamFinally.Checked)
            {
                chkViewOnlyExam1.Checked = false;
                chkShowExam1.Checked = chkShowSummary1.Checked = false;
            }
            else
            {
                chkViewOnlyExam1.Checked = true;
                chkShowExam1.Checked = chkShowSummary1.Checked = true;
            }
            if (uClass.ClassIDEditValue != null)
                LoadData();
        }

    }
}