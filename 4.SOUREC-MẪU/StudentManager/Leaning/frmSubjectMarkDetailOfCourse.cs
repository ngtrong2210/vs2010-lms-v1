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
    public partial class frmSubjectMarkDetailOfCourse : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SubjectMarkDetailOfCourse_Edit";
        public const string PERMISSION_VIEW = "SIM_SubjectMarkDetailOfCourse_View";

        #endregion

        #region Variable
        
        DataTable dtbData;
        DataTable dtbClassSubject;
        DataTable dtbSubjectMark;
        bool bolIsFirstSearch = true;
        int? intRegulationIDCurrent = 0;

        private string strReport_Header = "";
        private string strReport_Place = "";

        private bool bolHaveNormalSubject = false; // có môn bình thường trong cả kì hay năm không, có thì chỉ tính môn bình thường, không thì chỉ tính môn văn hoá

        // đếm sinh viên theo thứ tự Xs, G, K, TB k, TB, yeu kem
        private int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 };

        #endregion

        #region IForm Members

        private static frmSubjectMarkDetailOfCourse _instance = null;

        public static frmSubjectMarkDetailOfCourse Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSubjectMarkDetailOfCourse();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSubjectMarkDetailOfCourse()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = false;
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
            btnAutoSummary.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
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
            if (!uClass.IsValidData())
                return false;
            return true;
        }

        private void GetSetting()
        {
            if (SYS_SettingService.HaveNewData || bolIsFirstSearch)
            {
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
                intRegulationIDCurrent = uClass.RegulationID; // lấy mã quy chế sẵn ra

                SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                SIM_Student objStudent = new SIM_Student();

                // loại các môn không tổng kết
                string strListGraduationSpecialType = null;
                if (!chkShowGraduation.Checked)
                    strListGraduationSpecialType = "," + Global.SubjectSpecialType.TotNghiepVanHoa.ToString()
                                                    + "," + Global.SubjectSpecialType.ChinhTriTotNghiep.ToString()
                                                    + "," + Global.SubjectSpecialType.TotNghiepLT.ToString()
                                                    + "," + Global.SubjectSpecialType.TotNghiepTH.ToString() + ",";


                // Nếu lớp đó đang tích là tổ chức học theo tín chỉ, thì lấy môn trong chương trình khung
                if (uClass.IsRegulation43OfClass) 
                {                             
                    dtbSubjectMark = objSubjectMark.SearchOfClass43("@ClassID", uClass.ClassIDEditValue,
                                                                //"@YearID", uYearSemester.YearIDEditValue,
                                                                //"@Semester", uYearSemester.SemesterEditValue,
                                                                "@OrderLearning", null); // sổ điểm với những môn mà sv lớp này đang học ở kì này


                    dtbClassSubject = objSubjectMark.GetListSubject43("@ClassID", uClass.ClassIDEditValue,
                                                            //"@YearID", uYearSemester.YearIDEditValue,
                                                            //"@Semester", uYearSemester.SemesterEditValue,
                                                            "@NotListSpecialType", strListGraduationSpecialType); // môn mà sv lớp này có đăng ký học ở kì này 
                }
                else
                {
                    dtbSubjectMark = objSubjectMark.SearchFinal("@ClassID", uClass.ClassIDEditValue); // lấy điểm cuối cùng, có thể học lại nên hông lấy theo niên kì mà lấy theo lớp là đủ

                    dtbClassSubject = objClassSubject.SearchSimpleList("@ClassID", uClass.ClassIDEditValue,
                                                            "@YearID", uYearSemester.YearIDEditValue,
                                                            "@Semester", uYearSemester.SemesterEditValue,
                                                            "@NotListSpecialType", strListGraduationSpecialType,  // Không cần loại môn tốt nghiệp hay văn hóa
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
                    mnuItemSave.Enabled = btnSave.Enabled = mnuItemPrint.Enabled 
                            && ((uYearSemester.YearIDEditValue == null && uYearSemester.SemesterEditValue == null) || !uYearSemester.Enabled) // lớp tín chỉ hoặc niên chế có chọn năm
                            && btnAutoSummary.Enabled;
                                       
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

            GridBand gbGraduation = new GridBand();
            BandedGridColumn gcolGraduationRankingAverage = new BandedGridColumn();
            BandedGridColumn gcolGraduationLevel = new BandedGridColumn();
                                
            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gbStudent,gbSummary,gbGraduation});
            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {            
            gcolStudentCode,
            gcolStudentFirstName,
            gcolStudentLastName,
            gcolBirthday,
            gcolGenderText,
            gcolSummaryLearningMark,
            gcolLearningLevel,
            gcolSummaryEthicMark,
            gcolEthicLevel,
            gcolGraduationRankingAverage,
            gcolGraduationLevel});
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

            // 
            // gbGraduation
            // 
            gbGraduation.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbGraduation.AppearanceHeader.Options.UseFont = true;
            gbGraduation.AppearanceHeader.Options.UseTextOptions = true;
            gbGraduation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbGraduation.Caption = "TỐT NGHIỆP";
            gbGraduation.Name = "gbGraduation";
            gbGraduation.Width = 300;
            gbGraduation.Columns.Add(gcolGraduationRankingAverage);
            gbGraduation.Columns.Add(gcolGraduationLevel);

            // 
            // gcolGraduationRankingAverage
            // 
            gcolGraduationRankingAverage.AppearanceHeader.Options.UseTextOptions = true;
            gcolGraduationRankingAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGraduationRankingAverage.Caption = "TBXLTN";
            gcolGraduationRankingAverage.FieldName = "GraduationRankingAverage";
            gcolGraduationRankingAverage.Name = "gcolGraduationRankingAverage";
            gcolGraduationRankingAverage.Visible = true;
            // 
            // gcolGraduationLevel
            // 
            gcolGraduationLevel.AppearanceHeader.Options.UseTextOptions = true;
            gcolGraduationLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGraduationLevel.Caption = "XLTN";
            gcolGraduationLevel.FieldName = "GraduationLevel";
            gcolGraduationLevel.Name = "gcolGraduationLevel";
            gcolGraduationLevel.Visible = true;


            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gbSummary.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gbGraduation.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
         
        }

        private void RepairDataAndGrid()
        {
                     
            dtbData.Columns.Add("SummaryLearningMark", typeof(double));
            dtbData.Columns.Add("LearningLevel", typeof(string));

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
                dtbData.Columns.Add("FinalSummary_" + i.ToString(), typeof(double));
                dtbData.Columns.Add("OrderLearning_" + i.ToString(), typeof(double));

                dtbData.Columns.Add("LearningLevel_" + i.ToString(), typeof(string)); // Mức đạt môn A, B, C, D, F của tín chỉ
                dtbData.Columns.Add("OtherFinalSummary_" + i.ToString(), typeof(double)); // điểm qui đổi theo mức của tính chỉ
                dtbData.Columns.Add("FinalTheoryExam_" + i.ToString(), typeof(double)); // điểm thi lý thuyết lớn nhất
                dtbData.Columns.Add("FinalPracticeExam_" + i.ToString(), typeof(double)); // điểm thi thực hành lớn nhất
               

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
                    if(uClass.RegulationID==25)
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
                    // gcolFinalSummary_
                    //                
                    BandedGridColumn gcolFinalSummary = new BandedGridColumn();
                    gcolFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                    gcolFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gcolFinalSummary.Caption = "TKM";
                    gcolFinalSummary.FieldName = "FinalSummary_" + i.ToString();
                    gcolFinalSummary.Name = "gcolFinalSummary_" + i.ToString();
                    gcolFinalSummary.Visible = true;                    

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
                                            gcolFinalSummary});

                    // add cot vao band subject
                    gbSubject.Columns.Add(gcolTestAverage);
                    gbSubject.Columns.Add(gcolExam1);
                    gbSubject.Columns.Add(gcolSummary1);
                    gbSubject.Columns.Add(gcolExam2);
                    gbSubject.Columns.Add(gcolSummary2);
                    gbSubject.Columns.Add(gcolExam3);
                    gbSubject.Columns.Add(gcolFinalSummary);

                    gvData.Bands.Add(gbSubject);
                    i++;
                    
                }                              

            }
        }       

        private void FillData()
        {

            for (int i = 0; i < 6; i++)
                arrStatisticCount[i] = 0;

            // theo niên, kì nào đó thì mới lấy điểm rèn luyên, toàn khóa thì đã lấy của sinh viên
            DataTable dtbEthicMark = new DataTable();
            if (uYearSemester.YearIDEditValue != null)
            {
                // Ethic Mark             
                dtbEthicMark = new SIM_SummaryEthicMark().Search("@YearID", uYearSemester.YearIDEditValue, "@ClassID", uClass.ClassIDEditValue);
            }
        
            foreach (DataRow drw in dtbData.Rows)
            {

                double dblTotalMark = 0;
                int intUnitTextCount = 0;

                DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                {
                    string strSubjectID = drw2["SubjectID"].ToString();
                    DataRow []rowSubjects = dtbClassSubject.Select("SubjectID='" + strSubjectID + "'");
                    if (rowSubjects.Length > 0)
                    {
                        string strIndex = rowSubjects[0]["SubjectIndex"].ToString();
                        drw["OrderLearning_" + strIndex] = drw2["OrderLearning"];

                        if (Convert.ToBoolean(drw2["IsIgnore"])) // nếu là môn Miễn
                        {
                            drw["Summary1_" + strIndex] = "-1";
                            drw["Summary2_" + strIndex] = "-1";
                            drw["FinalSummary_" + strIndex] = "-1";
                            drw["FinalTheoryExam_" + strIndex] = "-1";
                            drw["FinalPracticeExam_" + strIndex] = "-1";
                        }
                        else
                        {

                            if (intRegulationIDCurrent == 43 || intRegulationIDCurrent == 99 || intRegulationIDCurrent == 44) // tính theo tín chỉ
                            {
                                drw["FinalSummary_" + strIndex] = drw2["FinalSummary"]; //TKM
                                drw["LearningLevel_" + strIndex] = drw2["LearningLevel"]; // qui đổi chữ
                                drw["OtherFinalSummary_" + strIndex] = drw2["OtherFinalSummary"]; // qui đổi số


                            }
                            else // không phải tính chỉ
                            {
                                drw["TestAverage_" + strIndex] = drw2["TestAverage"];
                                drw["Exam1_" + strIndex] = drw2["Exam1"];
                                drw["Summary1_" + strIndex] = drw2["Summary1"];

                                drw["Exam2_" + strIndex] = drw2["Exam2"];
                                drw["Summary2_" + strIndex] = drw2["Summary2"];

                                drw["Exam3_" + strIndex] = drw2["Exam3"];
                                drw["FinalSummary_" + strIndex] = drw2["FinalSummary"];
                                drw["FinalTheoryExam_" + strIndex] = drw2["FinalTheoryExam"];
                                drw["FinalPracticeExam_" + strIndex] = drw2["FinalPracticeExam"];

                                // cộng dồn để tính điểm tổng kết
                                int intSpecialType = Convert.ToInt32(drw2["SpecialType"]);
                                if (intSpecialType == Global.SubjectSpecialType.BinhThuong)
                                {
                                    if (drw2["FinalSummary"].ToString() != "")
                                    {
                                        int intUnitText = Convert.ToInt32(drw2["UnitText"]);
                                        dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]) * intUnitText; // điểm đã nhân đơn vị học trình, lấy tổng kết môn cuối cùng (nếu chỉ lấy lần 1 thì mặc nhiên chỉ lấy lần 1, vì if ở trên)
                                        intUnitTextCount += intUnitText;
                                    }
                                }
                            }
                        }
                    }
                }

                #region Tinh TBC va xep loai toan khoa

                // tính TBC và xếp loại
                if (intUnitTextCount > 0)
                {
                    double dblSummaryLearningMark = 0;

                    if (intRegulationIDCurrent == 25 || intRegulationIDCurrent == 99 || intRegulationIDCurrent == 44) // riêng qui chế 25 có 2 chữ số lẻ (09 tín chỉ cũng 2 số lẻ)
                        dblSummaryLearningMark = Math.Round(dblTotalMark / intUnitTextCount, 2, MidpointRounding.AwayFromZero);
                    else // còn lại là lấy 1 chữ số lẻ
                        dblSummaryLearningMark = Math.Round(dblTotalMark / intUnitTextCount, 1, MidpointRounding.AwayFromZero);
                    drw["SummaryLearningMark"] = dblSummaryLearningMark;

                    #region code cũ

                    //string strLearningLevel = "";
                    //if (intRegulationIDCurrent == 43 || intRegulationIDCurrent == 99 || intRegulationIDCurrent == 44) // tính theo tín chỉ
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
                    //        arrStatisticCount[5]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 5)
                    //    {
                    //        strLearningLevel = "Yếu";
                    //        arrStatisticCount[4]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 6)
                    //    {
                    //        strLearningLevel = "Trung bình";
                    //        arrStatisticCount[3]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 7)
                    //    {
                    //        strLearningLevel = "TB khá";
                    //        arrStatisticCount[2]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 8)
                    //    {
                    //        strLearningLevel = "Khá";
                    //        arrStatisticCount[1]++;
                    //    }
                    //    else if (dblSummaryLearningMark < 9)
                    //    {
                    //        // chỉ hạ bậc cho qui chế 22
                    //        if (
                    //            // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                    //                (intRegulationIDCurrent == 22 && (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != ""))
                    //                ||
                    //            // có 1 môn thi lại (không tính môn điều kiện) hoặc bị kỷ luật cảnh cáo trở lên thì hạ bậc
                    //                (intRegulationIDCurrent == 9 && (Convert.ToInt32(drw["SoMonBinhThuongThiLai"]) > 0 || drw["SanctionFormID"].ToString() != ""))
                    //            )
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
                    //        // chỉ hạ bậc cho qui chế 22
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

                drw["LearningLevel"] = SimsService.SIM_SubjectMarkService.ToLearningLevel(drw, intRegulationIDCurrent); // Mr Việt chuyển xếp loại vào service

                #endregion

                if (uYearSemester.YearIDEditValue != null)
                {
                    // Điền Ethic mark vào
                    rows = dtbEthicMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    if (rows.Length > 0)
                    {
                        if (uYearSemester.SemesterEditValue != null)
                        {

                            drw["EthicMark"] = rows[0]["EthicMark" + uYearSemester.SemesterEditValue.ToString()];
                            drw["EthicLevel"] = rows[0]["EthicLevel" + uYearSemester.SemesterEditValue.ToString()];
                        }
                        else
                        {
                            drw["EthicMark"] = rows[0]["EthicMark"];
                            drw["EthicLevel"] = rows[0]["EthicLevel"];
                        }
                    }
                }

            }
        }

        private void ModifyGrid()
        {            
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
                case 09: // trung cấp, cđ 2017
                    ModifyGrid09();
                    break;
                case 44:
                case 99: // trung cấp, cđ 2017 Tín chỉ
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
                if (col.FieldName.Contains("Summary2_") || col.FieldName.Contains("Exam3_") || col.FieldName.Contains("TestAverage_")) // thi lần 3 và tổng kết 2 bỏ, chỉ có tổng kết 1 và cuối
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

        // tc, cđ 2017
        private void ModifyGrid09()
        {

        }

        // tc, cđ 2017 tín chỉ
        private void ModifyGrid09_TinChi()
        {
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
                            if (strColumn.Contains("FinalSummary_") && strValue != "&nbsp;" && strValue!="M" && Convert.ToDouble(strValue) < 5)
                                strStyle = " style='background-color:Yellow;' ";
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

            string strTitle = "<table><tr><td colspan='2'>BẢNG TỔNG KẾT ĐIỂM TOÀN KHÓA ";            
            if (uYearSemester.SemesterEditValue != null)
                strTitle += " _ HỌC KÌ " + uYearSemester.SemesterEditValue.ToString();
            strTitle += " _ NIÊN HỌC " + uYearSemester.YearEditValueText;
            strTitle += "</td></tr>";

            strTitle += "<tr><td>KHOÁ HỌC: " + uClass.CourseName + "</td><td>BẬC: " + uClass.TrainingLevelName + "</td></tr>"
                     + "<tr><td>NGHỀ: " + uClass.BranchName + "</td><td>LỚP: " + uClass.ClassName + "</td></tr></table>";

            if (uClass.RegulationID == 25)
                strTitle.Replace("NGHỀ:", "NGÀNH:");


            string strFileContent = Libs.Files.ReadFile(strFileName);            
            strFileContent = strFileContent.Replace("{TITLE}", strTitle);
            strFileContent = strFileContent.Replace("{DETAIL}", str);

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
            
            int intColspan0 = 1, intColspan1=1;
            GridBand prevBand0 = null, prevBand1 = null;

            // tiêu đề cấp 2
            foreach (BandedGridColumn gcol in gvData.Columns)
            {
                if (!gcol.Visible)
                    continue;

                if(gcol.FieldName=="StudentFirstName")
                    strRow2 += "<td colspan='2'>Họ và tên</td>";                    
                else if(gcol.FieldName!="StudentLastName")                
                    strRow2 += "<td>" + gcol.Caption + "</td>";


                // tiêu đề cấp 1
                GridBand band1 = gcol.OwnerBand;
                if (prevBand1 == null)
                {
                    prevBand1 = band1;
                }
                else
                {

                    // nếu qua band mới thì xử band cũ của cấp 1
                    if (prevBand1.Name != band1.Name)
                    {
                        if (prevBand1.BandLevel == 1) // đúng band cấp 1 thì cộng vô
                        {
                            strRow1 += "<td colspan='" + intColspan1.ToString() + "'>" + prevBand1.Caption + "</td>";

                            // rồi tính tiếp cho cấp 0
                            GridBand band0 = band1.ParentBand;
                            if (prevBand0 == null)
                            {
                                prevBand0 = band0;
                            }
                            else
                            {

                                if (prevBand0.Name != band0.Name) //    cộng dồn vào tiêu đề cấp 0
                                {
                                    strRow0 += "<td colspan='" + intColspan0.ToString() + "' >" + prevBand0.Caption + "</td>";
                                    intColspan0 = 0;
                                    prevBand0 = band0;
                                }
                            }
                        }
                        else // nếu cấp 0 luôn rồi thì cho vào tiều đề cấp 0
                        {
                            strRow0 += "<td colspan='" + intColspan0.ToString() + "' rowspan='2' >" + prevBand1.Caption + "</td>";
                            intColspan0 = 0;
                        }

                        // reset colpan cho tieu đề cấp 1
                        intColspan1 = 1;
                        prevBand1 = band1;
                    }
                    else
                        intColspan1++; // tăng colspan                
                    intColspan0++;
                }

            }

            strRow0 += "<td colspan='" + intColspan0.ToString() + "' >" + prevBand0.Caption + "</td>";
            strRow1 += "<td colspan='" + intColspan1.ToString() + "'>" + prevBand1.Caption + "</td>";

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
            uYearSemester.Reset();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
                new Thread(LoadData).Start();
        }

        private void uYearSemester_EditValueChanged(object sender, EventArgs arg)
        {
            //if (uYearSemester.YearIDEditValue != null && uClass.ClassIDEditValue != null)
            //    new Thread(LoadData).Start();
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            //if (uYearSemester.YearIDEditValue != null && uClass.ClassIDEditValue != null)
            //    new Thread(LoadData).Start();
            uYearSemester.Enabled = !uClass.IsRegulation43OfClass; // lớp theo tín chỉ thì không chọn niên, kì mà sẽ lấy hết
        }
        
        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //if (e.Column.FieldName.Contains("FinalSummary_") && !e.Column.FieldName.Contains("OtherFinalSummary_"))
            //{
            //    DataRow drw = gvData.GetDataRow(e.RowHandle);
            //    if (drw != null)
            //    {
            //        if (e.CellValue != null && e.CellValue.ToString() != "")
            //        {
            //            if (Convert.ToDouble(e.CellValue) < 5)
            //            {
            //                e.Appearance.BackColor = Color.Yellow;
            //                return;
            //            }
            //        }

            //        if (drw[e.Column.FieldName.Replace("FinalSummary_", "OrderLearning_")] != DBNull.Value)
            //        {
            //            int intOrderLearning = Convert.ToInt32(drw[e.Column.FieldName.Replace("FinalSummary_", "OrderLearning_")]);
            //            if (intOrderLearning == 2)
            //                e.Appearance.BackColor = Color.OrangeRed;
            //            else if (intOrderLearning > 2)
            //                e.Appearance.BackColor = Color.Red;
            //        }
            //    }
            //}
        }


        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void chkShowColumn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (BandedGridColumn col in gvData.Columns)
            {                
                if (col.FieldName.Contains("TestAverage_"))
                    col.Visible = chkShowTestAverage.Checked;
                else if (col.FieldName.Contains("Exam"))
                    col.Visible = chkShowExam.Checked;
                else if (col.FieldName.Contains("Summary1_"))
                    col.Visible = chkShowSummary1.Checked;
                else if (col.FieldName.Contains("Summary2_"))
                    col.Visible = chkShowSummary2.Checked;                
                    
            }
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            uClass.RefrehData();
            uYearSemester.RefrehData();
            btnSearch_Click(null, null);
        }

        #endregion
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            SIM_Student obj = new SIM_Student();
            obj.BeginTransaction();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["SummaryLearningMark"].ToString() != "")
                {
                    if (!obj.UpdateLearningSummaryOfCourse(Convert.ToInt64(drw["StudentID"]), Convert.ToDouble(drw["SummaryLearningMark"]), drw["LearningLevel"].ToString()))
                        ErrorManager.Error("Việc cập nhật bị lỗi!");
                }
                else
                {
                    if (!obj.UpdateLearningSummaryOfCourse(Convert.ToInt64(drw["StudentID"]), null, null))
                        ErrorManager.Error("Việc cập nhật bị lỗi!");
                }
            }
            obj.CommitTransaction();
            btnSave.Enabled = mnuItemSave.Enabled = false;
        }

        private void btnAutoSummary_Click(object sender, EventArgs e)
        {
            SIM_SummaryLearningMark obj = new SIM_SummaryLearningMark();

            if (uYearSemester.Enabled) // nếu cho phép chọn năm, nghĩa là không phải theo tín chỉ mới tổng hợp theo năm
            {
                if (!obj.AutoLearningSummary(
                                         "@CourseID", uClass.CourseIDEditValue,
                                         "@BranchID", uClass.BranchEditValue,
                                         "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                         "@TrainingType", uClass.TrainingTypeEditValue,
                                         "@ScienceID", uClass.ScienceIDEditValue,
                                         "@ClassID", uClass.ClassIDEditValue,
                                         "@YearID", uYearSemester.YearIDEditValue,
                                         "@UpdatedUser", UserSession.Username)
                    || !obj.AutoLearningSummary43(
                                        "@CourseID", uClass.CourseIDEditValue,
                                        "@BranchID", uClass.BranchEditValue,
                                        "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                        "@TrainingType", uClass.TrainingTypeEditValue,
                                        "@ScienceID", uClass.ScienceIDEditValue,
                                        "@ClassID", uClass.ClassIDEditValue,
                                        "@YearID", uYearSemester.Enabled ? uYearSemester.YearIDEditValue : null,
                                        "@UpdatedUser", UserSession.Username)
                )
                {
                    ErrorManager.Error("Việc tổng kết năm học bị lỗi!");
                    return;
                }
            }

            if (!obj.AutoLearningSummaryOfCourse(
                                    "@CourseID", uClass.CourseIDEditValue,
                                    "@BranchID", uClass.BranchEditValue,
                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                    "@ScienceID", uClass.ScienceIDEditValue,
                                    "@ClassID", uClass.ClassIDEditValue,
                                    "@UpdatedUser", UserSession.Username)
                || !obj.AutoLearningSummaryOfCourse43(
                                    "@CourseID", uClass.CourseIDEditValue,
                                    "@BranchID", uClass.BranchEditValue,
                                    "@TrainingLevelID", uClass.TrainingLevelIDEditValue,
                                    "@TrainingType", uClass.TrainingTypeEditValue,
                                    "@ScienceID", uClass.ScienceIDEditValue,
                                    "@ClassID", uClass.ClassIDEditValue,
                                    "@UpdatedUser", UserSession.Username)
                )
            {
                ErrorManager.Error("Việc tổng kết toàn khoá bị lỗi!");
                return;
            }

            MessageManager.Info("Cập nhật tổng kết thành công!");

        }

        private void mnuItemPrint1_Click(object sender, EventArgs e)
        {
            string strReport = "";
            if (dtbData.Rows.Count <= 0)
                return;
           
            if (uYearSemester.YearIDEditValue == null)
            {
                strReport = "Report/StudentManager/Learning/Leaning_BangDiem_ToanKhoa_QC14.repx";
            }
            else if (uYearSemester.SemesterEditValue == null)
            {
                strReport = "Report/StudentManager/Learning/Leaning_BangDiem_NamHoc_QC14.repx";
            }
            else
            {
                strReport = "Report/StudentManager/Learning/Leaning_BangDiem_HocKy_QC14.repx";
            }
             // Set xep loai tot nghiep
            int iTB = 0;int iTBKha = 0;int iKha = 0; int iTot = 0; int iXuatSac = 0;int iSV = 0;int iYeu = 0;
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
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uYearSemester.SemesterEditValue);
            frm.SetParameter("pYear", uYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            frm.SetParameter("pXuatSac", iXuatSac);
            frm.SetParameter("pTLXuatSac", iXuatSac * 100 / iSV);
            frm.SetParameter("pTot", iTot);
            frm.SetParameter("pTLTot", iTot * 100 / iSV);
            frm.SetParameter("pKha", iKha);
            frm.SetParameter("pTLKha", iKha * 100 / iSV);
            frm.SetParameter("pTBKha", iTBKha);
            frm.SetParameter("pTLTBKha", iTBKha * 100 / iSV);
            frm.SetParameter("pTB", iTB);
            frm.SetParameter("pTLTB", iTB * 100 / iSV);
            frm.SetParameter("pYeu", iYeu);
            frm.SetParameter("pTLYeu", iYeu * 100 / iSV);
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

        private void mnuItemPrint2_Click(object sender, EventArgs e)
        {
            string strReport = "Report/StudentManager/Learning/Leaning_BangDiem_ToanKhoa_QC14_NganHan.repx";
           
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strReport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);           

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
        
    }
}