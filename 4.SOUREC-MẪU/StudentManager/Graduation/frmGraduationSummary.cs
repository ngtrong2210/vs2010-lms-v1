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

namespace StudentManager.Graduation
{
    public partial class frmGraduationSummary : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_GraduationSummary_Edit";
        public const string PERMISSION_VIEW = "SIM_GraduationSummary_View";

        #endregion

        #region Variable

        bool bolIsEditing = false; // dang edit hay khong
        private string strClassID = "";
        private string strListIDDeleted = "";
        private Decimal iSV;
        private Decimal iXuatSac;
        private Decimal iGioi;
        private Decimal iKha;
        private Decimal iTBKha;
        private Decimal iTB;
        private Decimal iKD;
        DataTable dtbData;
        DataTable dtbClassSubject;
        DataTable dtbSubjectMark;
        bool bolIsFirstSearch = true;
        int intYearID;
        int? intSemester = null;
         int iCountSbject ;
        #endregion

        #region IForm Members

        private static frmGraduationSummary _instance = null;

        public static frmGraduationSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmGraduationSummary();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmGraduationSummary()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);            
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
                uYearID.InitData();                
            }
        }

        private bool IsValidData()
        {
            if (!uClass.IsValidData())
                return false;
            if (lookupExamDate.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn kì thi tốt nghiệp!");
                lookupExamDate.Focus();
                return false;
            }
            if (uClass.SpecialBranchIDEditValue.ToString() == "VH" && OptNghe.Checked == true)
            {
                
                 MessageManager.Warning("Bạn phải chọ là TN văn hóa!");
                return false;
            }
            if (uClass.SpecialBranchIDEditValue.ToString() != "VH" && OptVanHoa.Checked == true)
            {
                
                 MessageManager.Warning("Bạn phải chọ là TN Nghề!");
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                // gán cột vào lưới.

                SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                SIM_GraduationResult objGraduationResult = new SIM_GraduationResult();

                dtbSubjectMark = objSubjectMark.SearchSubjectMark_Graduation("@ClassID", uClass.ClassIDEditValue); // Lấy bảng điểm của các môn tốt nghiệp

                dtbClassSubject = objClassSubject.SearchSubject_Graduation("@ClassID", uClass.ClassIDEditValue);
                dtbClassSubject.Columns.Add("SubjectIndex", typeof(int));
                if (uClass.SpecialBranchIDEditValue.ToString()=="VH")
                    dtbData = objGraduationResult.Search_VH("@ClassID", uClass.ClassIDEditValue, "@ExamDateID", lookupExamDate.EditValue);
                else
                    dtbData = objGraduationResult.Search("@ClassID", uClass.ClassIDEditValue, "@ExamDateID", lookupExamDate.EditValue);

                if (dtbData != null && dtbClassSubject != null)
                {
                    RepairGrid(); // khởi tạo cột cơ bản
                    RepairDataAndGrid(); // khởi tạo môn học vào data và lưới
                    FillData(); // điền điểm vào

                    gcData.DataSource = dtbData;
                    // set order
                    gvData.SetOrder("Order");

                    gvData.BestFitColumns();
                    
                    btnPrint.Enabled = btnPrint2.Enabled = mnuItemPrint.Enabled = mnuItemPrint2.Enabled = mnuItemExportToExcel.Enabled = btnReview.Enabled = dtbData.Rows.Count > 0;
                    btnSave.Enabled = mnuItemSave.Enabled = false;
                    btnReview.Enabled = btnSetDecisionNo.Enabled = btnSetSigningdate.Enabled = btnSetYearID.Enabled = dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT);
                }
                else
                {
                    //ErrorManager.Error(obj.ErrorException);
                    ErrorManager.Error("Việc lấy thông tin điểm bị lỗi!");
                }
            }
        }

        public void LoadExamDate()
        {
            SIM_ExamDate obj = new SIM_ExamDate();
            DataTable dtb = obj.GetDataTable("SIM_ExamDate_SearchCbxByClass", "@ClassID", uClass.ClassIDEditValue);
            lookupExamDate.InitData(dtb, "--Chọn--", SIM_ExamDate.C_ExamDateID, SIM_ExamDate.C_ExamDateName, SIM_ExamDate.C_ExamDate, "Ngày thi", SIM_ExamDate.C_ExamDateName, "Tên kì thi");
        }

        private void RepairDataAndGrid()
        {
            GridBand gbSemester1 = null;
            GridBand gbSemester2 = null;
            int i = 1;
            
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                drw["SubjectIndex"] = i;
                string strSubjectID = drw["SubjectID"].ToString();
                string strSubjectCaption = drw["SubjectName"].ToString() + "(" + drw["UnitText"].ToString() + ")";
                dtbData.Columns.Add("Exam1_" + "Subject" + i, typeof(double));
                dtbData.Columns.Add("Exam2_" + "Subject" + i, typeof(double));
                dtbData.Columns.Add("Exam3_" + "Subject" + i, typeof(double));
                dtbData.Columns.Add("FinalSummary_" + "Subject" + i, typeof(double));                
                // add Grid

                #region Add Semester 1

                if (gbSemester1 == null)
                {
                    gbSemester1 = new GridBand();
                    gbSemester1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                    gbSemester1.AppearanceHeader.Options.UseFont = true;
                    gbSemester1.AppearanceHeader.Options.UseTextOptions = true;
                    gbSemester1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gbSemester1.Caption = "ĐIỂM THI TỐT NGHIỆP";
                    gbSemester1.Name = "gbSemester" + drw["Semester"].ToString();

                    // add vao Grid
                    gvData.Bands.Add(gbSemester1);
                }

                // Add mon hoc nay vao gbSemester
                GridBand gbSubject = new GridBand();
                gbSubject.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubject.AppearanceHeader.Options.UseFont = true;
                gbSubject.AppearanceHeader.Options.UseTextOptions = true;
                gbSubject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubject.Caption = strSubjectCaption;
                gbSubject.Name = "gbSubject" + strSubjectID;
                gbSubject.Width = 375;
                // 
                // gcolTestAverage_1
                // 
                BandedGridColumn gcolExam1 = new BandedGridColumn();
                gcolExam1.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam1.Caption = "Lần 1";
                gcolExam1.FieldName = "Exam1_" + "Subject" + i;
                gcolExam1.Name = "gcolExam1_" + strSubjectID;
                gcolExam1.Visible = true;
                // 
                // gcolExam1_
                // 
                BandedGridColumn gcolExam2 = new BandedGridColumn();
                gcolExam2.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam2.Caption = "Lần 2";
                gcolExam2.FieldName = "Exam2_" + "Subject" + i;
                gcolExam2.Name = "gcolExam2_" + strSubjectID;
                gcolExam2.Visible = true;
                // 
                // gcolSummary1_
                // 
                BandedGridColumn gcolExam3 = new BandedGridColumn();
                gcolExam3.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam3.Caption = "Lần 3";
                gcolExam3.FieldName = "Exam3_" + "Subject" + i;
                gcolExam3.Name = "gcolExam3_" + strSubjectID;
                gcolExam3.Visible = true;
                // 
                // gcolFinalSummary_
                // 
                BandedGridColumn gcolFinalSummary = new BandedGridColumn();
                gcolFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                gcolFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolFinalSummary.Caption = "TKM";
                gcolFinalSummary.FieldName = "FinalSummary_" + "Subject" + i;
                gcolFinalSummary.Name = "gcolFinalSummary_" + strSubjectID;
                gcolFinalSummary.Visible = true;
                gcolFinalSummary.AppearanceCell.BackColor = Color.LightBlue;
                gcolFinalSummary.AppearanceCell.Options.UseBackColor = true;

                // add column vao grid
                gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                                            gcolExam1,
                                            gcolExam2,
                                            gcolExam3,
                                            gcolFinalSummary});

                // add cot vao band subject
                gbSubject.Columns.Add(gcolExam1);
                gbSubject.Columns.Add(gcolExam2);
                gbSubject.Columns.Add(gcolExam3);
                gbSubject.Columns.Add(gcolFinalSummary);

                //add Subject band vao Semester band
                gbSemester1.Children.Add(gbSubject);


                #endregion

                i++;
            }

            #region Add Semester 2

            // Kết quả tốt nghiệp
            GridBand gbTTN = new GridBand();
            GridBand gbXHTN = new GridBand();
            if (gbSemester2 == null)
            {
                gbSemester2 = new GridBand();
                gbSemester2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSemester2.AppearanceHeader.Options.UseFont = true;
                gbSemester2.AppearanceHeader.Options.UseTextOptions = true;
                gbSemester2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSemester2.Caption = "KẾT QUẢ XÉT TỐT NGHIỆP ";
                gbSemester2.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
                        gbTTN,
                        gbXHTN});
                gbSemester2.Name = "gbSemester";

                // add vao Grid
                gvData.Bands.Add(gbSemester2);
            }
            BandedGridColumn gcolGraduationExamAverage = new BandedGridColumn();
            BandedGridColumn gcolExamLevel = new BandedGridColumn();
            // gbTTN
            // 
            gbTTN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbTTN.AppearanceHeader.Options.UseFont = true;
            gbTTN.AppearanceHeader.Options.UseTextOptions = true;
            gbTTN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbTTN.Caption = "Thi tốt nghiệp";
            gbTTN.Columns.Add(gcolExamLevel);
            gbTTN.Columns.Add(gcolGraduationExamAverage);
            gbTTN.Name = "gbTTN";
            gbTTN.Width = 150;
            // gcolTestAverage_1
            // 

            gcolGraduationExamAverage.AppearanceHeader.Options.UseTextOptions = true;
            gcolGraduationExamAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGraduationExamAverage.Caption = "TBTTN";
            gcolGraduationExamAverage.FieldName = "GraduationExamAverage";
            gcolGraduationExamAverage.Name = "GraduationExamAverage";
            gcolGraduationExamAverage.Visible = true;
            // 
            // gcolExamLevel
            // 

            gcolExamLevel.AppearanceHeader.Options.UseTextOptions = true;
            gcolExamLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolExamLevel.Caption = "XL thi TN";
            gcolExamLevel.FieldName = "ExamLevel";
            gcolExamLevel.Name = "gcolExamLevel";
            gcolExamLevel.Visible = true;
            // 
            // gbTTN
            BandedGridColumn gcolGraduationRankingAverage = new BandedGridColumn();
            BandedGridColumn gcolGraduationLevel = new BandedGridColumn();
            gbXHTN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbXHTN.AppearanceHeader.Options.UseFont = true;
            gbXHTN.AppearanceHeader.Options.UseTextOptions = true;
            gbXHTN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbXHTN.Caption = "Xếp hạng tốt nghiệp";
            gbXHTN.Columns.Add(gcolGraduationLevel);
            gbXHTN.Columns.Add(gcolGraduationRankingAverage);
            gbXHTN.Name = "gbXHTN";
            gbXHTN.Width = 150;
            // gcolSummary1_
            gcolGraduationRankingAverage.AppearanceHeader.Options.UseTextOptions = true;
            gcolGraduationRankingAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGraduationRankingAverage.Caption = "TBCXH";
            gcolGraduationRankingAverage.FieldName = "GraduationRankingAverage";
            gcolGraduationRankingAverage.Name = "gcolGraduationRankingAverage";
            gcolGraduationRankingAverage.Visible = true;
            // 
            // gcolExam2_ 
            gcolGraduationLevel.AppearanceHeader.Options.UseTextOptions = true;
            gcolGraduationLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGraduationLevel.Caption = "XL tốt nghiệp";
            gcolGraduationLevel.FieldName = "GraduationLevel";
            gcolGraduationLevel.Name = "gcolGraduationLevel";
            gcolGraduationLevel.Visible = true;
            // 
            // add column vao grid
            // gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            //       gcolGraduationExamAverage,
            //     gcolExamLevel,
            //     gcolGraduationRankingAverage,
            //     gcolGraduationLevel});

            // add cot vao band subject
            //   gbGranduation.Columns.Add(gcolGraduationExamAverage);
            // gbGranduation.Columns.Add(gcolExamLevel);
            // gbGranduation.Columns.Add(gcolGraduationRankingAverage);
            // gbGranduation.Columns.Add(gcolGraduationLevel);

            //add Subject band vao Semester band
            //  gbSemester2.Children.Add(gbGranduation);

            #endregion
        }

        /// <summary>
        /// 
        /// Khởi tạo 53 cột cho 53 tuần cho lưới
        /// </summary>
        private void RepairGrid()
        {
            // Xóa hết grid 
            gvData.Bands.Clear();
            gvData.Columns.Clear();

            // Student
            GridBand gbStudent = new GridBand(); ;
            BandedGridColumn gcolOrder = new BandedGridColumn();
            BandedGridColumn gcolStudentCode = new BandedGridColumn();
            BandedGridColumn gcolStudentFirstName = new BandedGridColumn();
            BandedGridColumn gcolStudentLastName = new BandedGridColumn();

            // Summary
            GridBand gbSummary = new GridBand();
            GridBand gbSummaryEthic = new GridBand();
            BandedGridColumn gcolSummaryEthicMark = new BandedGridColumn();
            BandedGridColumn gcolEthicLevel = new BandedGridColumn();
            BandedGridColumn gcolSanctionFormName = new BandedGridColumn();

            GridBand gbSummaryLearning = new GridBand();
            BandedGridColumn gcolSummaryLearningMark = new BandedGridColumn();
            BandedGridColumn gcolLearningLevel = new BandedGridColumn();
            BandedGridColumn gcolPercentReExam = new BandedGridColumn();

            GridBand gbEdit = new GridBand();
            BandedGridColumn gcolDecisionNo = new BandedGridColumn();
            BandedGridColumn gcolSigningdate = new BandedGridColumn();
            BandedGridColumn gcolYearID = new BandedGridColumn();
            BandedGridColumn gcolCerNo = new BandedGridColumn(); // số hiệu bằng
            BandedGridColumn gcolCerIssued = new BandedGridColumn(); // ngày cấp

            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gbStudent,
            gbSummary,
            gbEdit});
            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            gcolOrder,
            gcolStudentCode,
            gcolStudentFirstName,
            gcolStudentLastName,
            gcolSummaryEthicMark,
            gcolEthicLevel,
            gcolSanctionFormName,
            gcolSummaryLearningMark,
            gcolLearningLevel,
            gcolPercentReExam,
            gcolDecisionNo,
            gcolSigningdate,
            gcolYearID,
            gcolCerNo,
            gcolCerIssued});

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
            gbStudent.Columns.Add(gcolOrder);
            gbStudent.Columns.Add(gcolStudentCode);
            gbStudent.Columns.Add(gcolStudentFirstName);
            gbStudent.Columns.Add(gcolStudentLastName);
            gbStudent.Name = "gbStudent";
            gbStudent.Width = 300;
            // 
            // gcolOrder
            // 
            gcolOrder.AppearanceHeader.Options.UseTextOptions = true;
            gcolOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolOrder.Caption = "STT";
            gcolOrder.FieldName = "Order";
            gcolOrder.Name = "gcolOrder";
            gcolOrder.Visible = true;
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
            gbSummaryEthic.Columns.Add(gcolSanctionFormName);
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
            // gcolSanctionFormName
            // 
            gcolSanctionFormName.AppearanceHeader.Options.UseTextOptions = true;
            gcolSanctionFormName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSanctionFormName.Caption = "Kỷ luật";
            gcolSanctionFormName.FieldName = "SanctionFormName";
            gcolSanctionFormName.Name = "SanctionFormName";
            gcolSanctionFormName.Visible = true;

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
            gbSummaryLearning.Columns.Add(gcolPercentReExam);
            gbSummaryLearning.Name = "gbSummaryLearning";
            gbSummaryLearning.Width = 150;
            // 
            // gcolSummaryLearningMark
            // 
            gcolSummaryLearningMark.AppearanceHeader.Options.UseTextOptions = true;
            gcolSummaryLearningMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSummaryLearningMark.Caption = "TBC";
            gcolSummaryLearningMark.FieldName = "LearningSummary";
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
            // gcolPercentReExam
            // 
            gcolPercentReExam.AppearanceHeader.Options.UseTextOptions = true;
            gcolPercentReExam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolPercentReExam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gcolPercentReExam.DisplayFormat.FormatString = "#,#";
            gcolPercentReExam.Caption = "Số môn thi lại";
            gcolPercentReExam.FieldName = "DebitSubject";
            gcolPercentReExam.Name = "gcolPercentReExam";
            gcolPercentReExam.Visible = true;

            // 
            // gbEdit
            // 
            gbEdit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbEdit.AppearanceHeader.Options.UseFont = true;
            gbEdit.AppearanceHeader.Options.UseTextOptions = true;
            gbEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbEdit.Caption = "Quyết định";
            gbEdit.Columns.Add(gcolDecisionNo);
            gbEdit.Columns.Add(gcolSigningdate);
            gbEdit.Columns.Add(gcolYearID);
            gbEdit.Columns.Add(gcolCerNo);
            gbEdit.Columns.Add(gcolCerIssued);
            gbEdit.Name = "gbEdit";
            gbEdit.Width = 150;

            gcolDecisionNo.AppearanceHeader.Options.UseTextOptions = true;
            gcolDecisionNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolDecisionNo.Caption = "Số QĐ";
            gcolDecisionNo.FieldName = "DecisionNo";
            gcolDecisionNo.Name = "gcolDecisionNo";
            gcolDecisionNo.Visible = true;

            gcolSigningdate.AppearanceHeader.Options.UseTextOptions = true;
            gcolSigningdate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolSigningdate.Caption = "Ngày QĐ";
            gcolSigningdate.FieldName = "Signingdate";
            gcolSigningdate.Name = "gcolSigningdate";
            gcolSigningdate.Visible = true;

            gcolYearID.AppearanceHeader.Options.UseTextOptions = true;
            gcolYearID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolYearID.Caption = "Năm TN";
            gcolYearID.FieldName = "YearID";
            gcolYearID.Name = "gcolYearID";
            gcolYearID.Visible = true;

            gcolCerNo.AppearanceHeader.Options.UseTextOptions = true;
            gcolCerNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolCerNo.Caption = "Số hiệu bằng TN";
            gcolCerNo.FieldName = "CerNo";
            gcolCerNo.Name = "gcolCerNo";
            gcolCerNo.Visible = true;

            gcolCerIssued.AppearanceHeader.Options.UseTextOptions = true;
            gcolCerIssued.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolCerIssued.Caption = "Ngày cấp bằng TN";
            gcolCerIssued.FieldName = "CerIssued";
            gcolCerIssued.Name = "gcolCerIssued";
            gcolCerIssued.Visible = true;

            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gbSummary.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;


        }

        private void FillData()
        {
            foreach (DataRow drw in dtbData.Rows)
            {
                DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                double dblTotalMark = 0;
                int iSubject = 0;
                int intReExam = 0; // số môn thi lại * lần thi lại
                foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                {
                    string strSubjectID = drw2["SubjectID"].ToString();
                    DataRow[] rowSubjects = dtbClassSubject.Select("SubjectID='" + strSubjectID + "'");
                    if (rowSubjects.Length > 0)
                    {
                        string strIndex = rowSubjects[0]["SubjectIndex"].ToString();

                        drw["Exam1_" + "Subject" + strIndex] = drw2["Exam1"];
                        drw["Exam2_" + "Subject" + strIndex] = drw2["Exam2"];
                        drw["Exam3_" + "Subject" + strIndex] = drw2["Exam3"];
                        drw["FinalSummary_" + "Subject" + strIndex] = drw2["FinalSummary"];
                        // Tinh tong điểm các môn thi tốt nghiệp

                        if (drw2["FinalSummary"].ToString() != "" && (drw2["FinalSummary"].ToString() != "-1"))
                        {
                            dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                        }
                        if (drw2["FinalSummary"].ToString() != "-1")
                        {
                            iSubject += 1;
                        }
                        // nếu có môn nào đó thi lại, thì luôn gán lần thi là 2 trở lên nếu chưa gán (dùng cho dữ liệu cũ chưa gán lần thi lại khi đăng ký dự thi tốt nghiệp)
                        if ((drw2["Exam2"].ToString() != "" || drw2["Exam3"].ToString() != "") && (drw["OrderExam"].ToString() == "" || Convert.ToInt32(drw["OrderExam"]) < 2))
                            drw["OrderExam"] = 2; // gán thế này cho chắc ăn là sẽ chỉ xét đạt TB cho qui chế 40,46

                        if (drw2["Exam3"].ToString() != "")
                            intReExam += 2; // thi lại 2 lần môn này
                        else if (drw2["Exam2"].ToString() != "")
                            intReExam++; // thi lại 1 lần môn này
                    }
                }
                
                if (iSubject != 0)
                {
                    double dblGraduationExamAverage = Math.Round(dblTotalMark / iSubject, 1);
                    drw["GraduationExamAverage"] = dblGraduationExamAverage;
                    string strExamLevel = "";
                    if (dblGraduationExamAverage < 3.5)
                        strExamLevel = "Kém";
                    else if (dblGraduationExamAverage < 5)
                        strExamLevel = "Yếu";
                    else if (dblGraduationExamAverage < 6)
                        strExamLevel = "Trung bình";
                    else if (dblGraduationExamAverage < 7.0)
                        strExamLevel = "TB khá";
                    else if (dblGraduationExamAverage < 8)
                        strExamLevel = "Khá";
                    else if (dblGraduationExamAverage < 9)
                        strExamLevel = "Giỏi";
                    else
                        strExamLevel = "Xuất sắc";

                    drw["GraduationExamLevel"] = strExamLevel;
                    drw["ReExam"] = intReExam;
                }
                else
                {
                    drw["GraduationExamAverage"] = DBNull.Value;
                    drw["GraduationExamLevel"] = "";
                    drw["ReExam"] = DBNull.Value;
                }
            }


        }

        /// <summary>
        /// Cập nhật tổng kết điểm học tập. Vừa thêm, vừa cập nhật nếu cả có
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            SIM_GraduationResult item = new SIM_GraduationResult();
            SIM_Student objStudent = new SIM_Student();
            item.BeginTransaction();
            objStudent.IDB = item.IDB;          
            item.ExamDateID = lookupExamDate.EditValueInt32;
            item.UpdatedUser = UserSession.Username; // them hay update deu dung truong nay            

            for (int i = 0; i < dtbData.Rows.Count; i++)
            {                
                DataRow drw = gvData.GetDataRow(i);
                if (drw["GraduationExamAverage"].ToString() != "")
                {
                    if (dtbData.Rows[i]["GraduationLevel"].ToString() != "" && dtbData.Rows[i]["GraduationLevel"].ToString() != "Không đạt")
                    {
                        item.ResultReview = 1; // đậu
                        if (OptNghe.Checked)
                        {
                            objStudent.Status = 2; // tốt nghiệp
                            item.SpecialType = 2;
                        }
                        else
                        {
                            objStudent.Status = Convert.ToInt32(drw["Status"]);
                            item.SpecialType = 5;
                        }
                    }
                    else
                    {
                        item.ResultReview = 0; // rớt
                        objStudent.Status = 1; // đang học
                        if (OptNghe.Checked)
                        {
                            item.SpecialType = 2;
                        }
                        else
                            item.SpecialType = 5;
                    }
                    item.GraduationResultID = Convert.ToInt64(drw["GraduationResultID"]);
                    item.StudentID = Convert.ToInt32(drw["StudentID"]);

                    item.HaveExamRegister1 = Convert.ToBoolean(drw["HaveExamRegister1"]);
                    item.HaveExamRegister2 = Convert.ToBoolean(drw["HaveExamRegister2"]);
                    item.HaveExamRegister3 = Convert.ToBoolean(drw["HaveExamRegister3"]);

                    item.SummaryLearningMark = Convert.ToDouble(drw["LearningSummary"]);
                    item.SummaryLearningLevel = drw["LearningLevel"].ToString();
                    item.GraduationExamAverage = Convert.ToDouble(drw["GraduationExamAverage"]);
                    item.GraduationRankingAverage = Convert.ToDouble(drw["GraduationRankingAverage"]);
                    item.GraduationLevel = drw["GraduationLevel"].ToString();
                    if (drw["OrderExam"].ToString() != "")
                        item.OrderExam = Convert.ToInt32(drw["OrderExam"]);
                    else
                        item.OrderExam = 1;

                    item.DecisionNo = drw["DecisionNo"].ToString();
                    if (drw["Signingdate"].ToString() != "")
                        item.Signingdate = Convert.ToDateTime(drw["Signingdate"]);
                    else
                        item.Signingdate = null;

                    if (drw["YearID"].ToString() != "")
                        item.YearID = Convert.ToInt32(drw["YearID"]);
                    else
                        item.YearID = null;

                    item.CerNo = drw["CerNo"].ToString();
                    if (drw["CerIssued"].ToString() != "")
                        item.CerIssued = Convert.ToDateTime(drw["CerIssued"]);
                    else
                        item.CerIssued = null;

                    if (!item.Update())
                    {
                        ErrorManager.Error("Việc cập nhật thông tin xét tốt nghiệp bị lỗi!");
                        return false;
                    }
                    else
                    {
                        objStudent.UpdatedUser = UserSession.Username;
                        objStudent.StudentID = Convert.ToInt32(drw["StudentID"]);
                        //objStudent.Status = 2; chắc gì là 2, trạng thái được set ở trên cơ mà
                        if (!objStudent.UpdateStatus())
                        {
                            ErrorManager.Error("Cập nhật thông tin Hồ sơ SV thất bại");
                            return false;
                        }
                    }
                }
            }

            item.CommitTransaction();
            return true;
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

        #endregion

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txtDecisionNo.Text == "")
            //{
            //    MessageManager.Warning("Bạn phải nhập vào số quyết định TN");
            //    return;
            //}
            //if (uYearID.YearIDEditValue ==null)
            //{
            //    MessageManager.Warning("Bạn phải năm tốt nghiệp");
            //    return;
            //}
            //if (dateSigningdate.Text == "")
            //{
            //    MessageManager.Warning("Bạn phải nhập vào ngày TN");
            //    return;
            //}
            if (IsValidData())
            {
                if (SaveData())
                    btnSave.Enabled = mnuItemSave.Enabled = false;
            }
        }
        // Xet tot nghiep TC, CĐ  2017 (giống 14)
        private void QC04() // Quy che 09 TBXH = (TBTK * 3 + TH*2 + LT )/6. 
        {
            if (gvData.RowCount == 0)
                return;
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    int intReExam = 0;
                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepLT)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepTH)
                                {
                                    dblTotalMark += 2 * Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (Convert.ToDouble(drw2["FinalSummary"]) < 5)
                                {
                                    iMonNo++;
                                }
                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }
                    //double tk = 0;
                    if (iSoMon != 0)
                    {

                        // Tinh trung binh trung xep hang tot nghiep         
                        intReExam = Convert.ToInt32(drw["ReExam"]); // tổng lần thi lại của môn
                        if (iSoMon == 1)
                            dbGraduationRankingAverage = Math.Round((dblTotalMark + 3 * Convert.ToDouble(drw["LearningSummary"])) / 5.00, 2, MidpointRounding.AwayFromZero);
                        else
                            dbGraduationRankingAverage = Math.Round((dblTotalMark + 3 * Convert.ToDouble(drw["LearningSummary"])) / 6.00, 2, MidpointRounding.AwayFromZero);
                        dbGraduationRankingAverage = Math.Round(dbGraduationRankingAverage, 1, MidpointRounding.AwayFromZero);
                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 0 || iSoMon != dtbClassSubject.Rows.Count) // có nợ môn hoặc chưa có đủ điểm tốt nghiệp                                               
                                strGraduationLevel = "Không đạt";
                            else if (intReExam > 2 || dbGraduationRankingAverage < 6) //  thi lai từ 3 lần (tính cho lần * môn luôn) thì cao nhất là TB
                                strGraduationLevel = "Trung bình";
                            else if (intReExam > 1 || dbGraduationRankingAverage < 7.0) // thi lại 2 lần thì chỉ là Trung bình khá
                                strGraduationLevel = "Trung bình";
                            else if (intReExam > 0 || dbGraduationRankingAverage < 8) // thi lại 1 lần thì cao nhất là Khá                            
                                strGraduationLevel = "Khá";
                            else if (dbGraduationRankingAverage < 9)
                            {
                                if (Convert.ToDouble(drw["DebitSubject"]) > 1 || drw["SanctionFormID"].ToString() != "") // có học lại/thi lại or kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Khá";
                                else
                                    strGraduationLevel = "Giỏi";
                            }
                            else
                            {
                                if (Convert.ToDouble(drw["DebitSubject"]) > 0 || drw["SanctionFormID"].ToString() != "") // có học lại/thi lại or kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Giỏi";
                                else
                                    strGraduationLevel = "Xuất sắc";
                            }
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] = strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }
        }
        private void btnReview_Click(object sender, EventArgs e)
        {
            int? intReguationID = uClass.RegulationID;

            if (intReguationID == 04 || intReguationID == 44)
                QC04();

            else if (intReguationID == 09 || intReguationID == 99)
                QC09();   

            else switch (intReguationID)
            {
                case 14:
                    if (uClass.LaSoCapNghe)
                        QC14_SC();
                    else
                        QC14();
                    break;
                case 22:
                    QC22();
                    break;
                case 40:
                    QC40();
                    break;
                case 46:
                    QC46();
                    break;
                
                default:
                    QC09();
                    break;

            }
        }

        // Xet tot nghiep cho bac nghe.
        private void QC14()
        {
            if (gvData.RowCount == 0)
                return;
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepLT)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepTH)
                                {
                                    dblTotalMark += 2 * Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (Convert.ToDouble(drw2["FinalSummary"]) < 5)
                                {
                                    iMonNo++;
                                }
                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }
                    //double tk = 0;
                    if (iSoMon != 0)
                    {

                        // Tinh trung binh trung xep hang tot nghiep                        
                        dbGraduationRankingAverage = Math.Round((dblTotalMark + 3 * Convert.ToDouble(drw["LearningSummary"])) / 6, 1, MidpointRounding.AwayFromZero);

                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 0 || iSoMon != dtbClassSubject.Rows.Count)                            
                                strGraduationLevel = "Không đạt";
                            
                            else if (dbGraduationRankingAverage < 6)                            
                                strGraduationLevel = "Trung bình";
                                                            
                            else if (dbGraduationRankingAverage < 7.0)                            
                                strGraduationLevel = "TB khá";                                
                            
                            else if (dbGraduationRankingAverage < 8)                            
                                strGraduationLevel = "Khá";                                
                            
                            else if (dbGraduationRankingAverage < 9)                            
                                strGraduationLevel = "Giỏi";
                            
                            else                            
                                strGraduationLevel = "Xuất sắc";                                
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] =  strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }
        }

        private void QC14_SC()
        {
            if (gvData.RowCount == 0)
                return;
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToDouble(drw2["FinalSummary"]) < 5)
                                {
                                    iMonNo++;
                                }
                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }

                    if (iSoMon != 0)
                    {

                        // Tinh trung binh chung xep hang tot nghiep  chính là tb các môn tính điểm và môn tốt nghiệp (tính điểm hệ số 1, tốt nghiệp hệ số 2)                    
                        dbGraduationRankingAverage = Convert.ToDouble(drw["SummaryMarkAll"]); // đã tính trong store

                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 0 || iSoMon != dtbClassSubject.Rows.Count)
                                strGraduationLevel = "Không đạt";

                            else if (dbGraduationRankingAverage < 6)
                                strGraduationLevel = "Trung bình";

                            else if (dbGraduationRankingAverage < 7.0)
                                strGraduationLevel = "TB khá";

                            else if (dbGraduationRankingAverage < 8)
                                strGraduationLevel = "Khá";

                            else if (dbGraduationRankingAverage < 9)
                                strGraduationLevel = "Giỏi";

                            else
                                strGraduationLevel = "Xuất sắc";
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] = strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }
        }

        // Xet tot nghiep cho trung cap chuyen nghiep        
        private void QC22() // Quy che 22 TBXH = (TBTK + TBTTN)/2. TBTTN la trung binh cong cac mon thi tot nghiep.
        {
            if (dtbData == null || dtbData.Rows.Count == 0)
                return;

            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    int intReExam = 0;

                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepLT
                                    || Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepTH
                                    || Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.ChinhTriTotNghiep)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                else if (Convert.ToInt32(drw2["SpecialType"])==5)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (Convert.ToDouble(drw2["FinalSummary"]) < 5)
                                {
                                    iMonNo += 1;                                    
                                }

                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }
                    if (iSoMon != 0)
                    {
                        dblTotalMark = Math.Round(dblTotalMark / iSoMon, 1);
                        intReExam = Convert.ToInt32(drw["ReExam"]); // tổng lần thi lại của môn
                        // Tinh trung binh trung xep hang tot nghiep
                        dbGraduationRankingAverage = Math.Round((dblTotalMark + Convert.ToDouble(drw["LearningSummary"])) / 2, 1, MidpointRounding.AwayFromZero);
                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 0 || iSoMon != dtbClassSubject.Rows.Count) // có nợ môn hoặc chưa có đủ điểm tốt nghiệp                                               
                                strGraduationLevel = "Không đạt";
                            else if ( intReExam > 2 || dbGraduationRankingAverage < 6) //  thi lai từ 3 lần (tính cho lần * môn luôn) thì cao nhất là TB
                                strGraduationLevel = "Trung bình";
                            else if (intReExam > 1 || dbGraduationRankingAverage < 7.0) // thi lại 2 lần thì chỉ là TB khá
                                strGraduationLevel = "TB khá";
                            else if ( intReExam > 0 || dbGraduationRankingAverage < 8) // thi lại 1 lần thì cao nhất là Khá                            
                                strGraduationLevel = "Khá";                            
                            else if (dbGraduationRankingAverage < 9)
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Khá";
                                else
                                    strGraduationLevel = "Giỏi";
                            }
                            else
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Giỏi";
                                else
                                    strGraduationLevel = "Xuất sắc";
                            }
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] = strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }

        }

        // Xet tot nghiep cho trung cap chuyen nghiep        
        private void QC40() // Quy che 46 TBXH = (TBTK + TBTTN)/2. 
        {
            if (dtbData == null || dtbData.Rows.Count == 0)
                return;

            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    bool bolIs45 = false; // 1 mon no la 4.5 van dat
                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepLT
                                    || Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepTH
                                    || Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.ChinhTriTotNghiep)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }

                                if (Convert.ToDouble(drw2["FinalSummary"]) < 5)  
                                {
                                    iMonNo += 1;
                                    if (Convert.ToDouble(drw2["FinalSummary"]) >= 4.5)
                                        bolIs45 = true; // co 1 mon no thi neu mon no la 4.5 van dau
                                }

                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }
                    if (iSoMon != 0)
                    {
                        dblTotalMark = Math.Round(dblTotalMark / iSoMon, 1);

                        // Tinh trung binh trung xep hang tot nghiep
                        dbGraduationRankingAverage = Math.Round((dblTotalMark + Convert.ToDouble(drw["LearningSummary"])) / 2, 1, MidpointRounding.AwayFromZero);
                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 1 || (iMonNo == 1 && !bolIs45) || iSoMon != dtbClassSubject.Rows.Count) // có 2 môn nợ hoặc có 1 môn nợ mà môn đó < 4.5 thì rớt                                                
                                strGraduationLevel = "Không đạt";

                            else if ((drw["OrderExam"].ToString()!="" && Convert.ToInt32(drw["OrderExam"]) > 1) || dbGraduationRankingAverage < 6) // nếu thi lại thì chỉ được TB                          
                                strGraduationLevel = "Trung bình";

                            else if (dbGraduationRankingAverage < 7.0)
                                strGraduationLevel = "TB khá";

                            else if (dbGraduationRankingAverage < 8)
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "TB khá";
                                else
                                    strGraduationLevel = "Khá";
                            }
                            else if (dbGraduationRankingAverage < 9)
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Khá";
                                else
                                    strGraduationLevel = "Giỏi";
                            }
                            else
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 10 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Giỏi";
                                else
                                    strGraduationLevel = "Xuất sắc";
                            }                                                          
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] = strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }

        }

        /// <summary>
        /// TC chuyen nghiep vua lam vua hoc
        /// </summary>
        private void QC46() // Quy che 46 TBXH = (TBTK + TBTTN)/2. TBTTN la trung binh cong cac mon thi tot nghiep.
        {
            if (dtbData == null || dtbData.Rows.Count == 0)
                return;

            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    bool bolIs45 = false; // 1 mon no la 4.5 van dat
                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepLT
                                    || Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepTH
                                    || Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.ChinhTriTotNghiep)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }

                                if (Convert.ToDouble(drw2["FinalSummary"]) < 5)
                                {
                                    iMonNo += 1;
                                    if (Convert.ToDouble(drw2["FinalSummary"]) >= 4.5)
                                        bolIs45 = true; // co 1 mon no thi neu mon no la 4.5 van dau
                                }

                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }
                    if (iSoMon != 0)
                    {
                        dblTotalMark = Math.Round(dblTotalMark / iSoMon, 1);

                        // Tinh trung binh trung xep hang tot nghiep
                        dbGraduationRankingAverage = Math.Round((dblTotalMark + Convert.ToDouble(drw["LearningSummary"])) / 2, 1, MidpointRounding.AwayFromZero);
                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 1 || (iMonNo == 1 && !bolIs45) || iSoMon != dtbClassSubject.Rows.Count) // có 2 môn nợ hoặc có 1 môn nợ mà môn đó < 4.5 thì rớt                                                
                                strGraduationLevel = "Không đạt";

                            else if ( dbGraduationRankingAverage < 6) // < 6 thì TB                         
                                strGraduationLevel = "Trung bình";

                            else if (dbGraduationRankingAverage < 7.0)
                                strGraduationLevel = "TB khá";

                            else if (dbGraduationRankingAverage < 8)
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 20 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "TB khá";
                                else
                                    strGraduationLevel = "Khá";
                            }
                            else if (dbGraduationRankingAverage < 9)
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 20 || drw["SanctionFormID"].ToString() != "" // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc
                                    || (drw["OrderExam"].ToString() != "" && Convert.ToInt32(drw["OrderExam"]) > 1) ) // hoặc thi lại tốt nghiệp thì hạ bậc
                                    strGraduationLevel = "Khá";
                                else
                                    strGraduationLevel = "Giỏi";
                            }
                            else
                            {
                                if(drw["OrderExam"].ToString() != "" && Convert.ToInt32(drw["OrderExam"]) > 1) // hoặc thi lại tốt nghiệp thì chỉ là Khá
                                    strGraduationLevel = "Khá";
                                else if (Convert.ToDouble(drw["PercentReExam"]) > 20 || drw["SanctionFormID"].ToString() != "") // thi lại quá 10% và kỷ luật cảnh cáo trở lên thì hạ bậc                                    
                                    strGraduationLevel = "Giỏi";
                                else
                                    strGraduationLevel = "Xuất sắc";
                            }
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] = strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }

        }

        // Xet tot nghiep TC, CĐ  2017 (giống 14)
        private void QC09() // Quy che 09 TBXH = (TBTK * 3 + TH*2 + LT )/6. TBTTN la trung binh cong cac mon thi tot nghiep.
        {
            if (gvData.RowCount == 0)
                return;
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["ResultReviewOther"].ToString() == "") // chưa đạt ở bất cứ kì thi nào khác mới cho xét lại
                {
                    DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                    double dblTotalMark = 0;
                    double dbGraduationRankingAverage = 0;
                    int iMonNo = 0, iSoMon = 0;
                    int intReExam = 0;
                    foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                    {
                        string strSubjectID = drw2["SubjectID"].ToString();
                        if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                        {
                            if (drw2["FinalSummary"].ToString() != "")
                            {
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepLT)
                                {
                                    dblTotalMark += Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (Convert.ToInt32(drw2["SpecialType"]) == Global.SubjectSpecialType.TotNghiepTH)
                                {
                                    dblTotalMark += 2 * Convert.ToDouble(drw2["FinalSummary"]);
                                }
                                if (drw2["FinalSummary"].ToString() != "-1")
                                {
                                    if (Convert.ToDouble(drw2["FinalSummary"]) < 5)
                                    {
                                        iMonNo++;
                                    }
                                    
                                }
                                iSoMon++;
                            }
                            else
                                iMonNo++;

                        }
                    }
                    //double tk = 0;
                    if (iSoMon != 0)
                    {

                        // Tinh trung binh trung xep hang tot nghiep     
                        intReExam = Convert.ToInt32(drw["ReExam"]); // tổng lần thi lại của môn
                        dbGraduationRankingAverage = Math.Round((dblTotalMark + 3 * Convert.ToDouble(drw["LearningSummary"])) / 6.00, 2, MidpointRounding.AwayFromZero);
                        dbGraduationRankingAverage = Math.Round(dbGraduationRankingAverage, 1, MidpointRounding.AwayFromZero);
                        drw["GraduationRankingAverage"] = dbGraduationRankingAverage;

                        // tính TBC và xếp loại theo quy chế 14
                        string strGraduationLevel = "";
                        if (dbGraduationRankingAverage >= 5)
                        {
                            if (iMonNo > 0 || iSoMon != dtbClassSubject.Rows.Count) // có nợ môn hoặc chưa có đủ điểm tốt nghiệp                                               
                                strGraduationLevel = "Không đạt";
                            else if (intReExam > 2 || dbGraduationRankingAverage < 6) //  thi lai từ 3 lần (tính cho lần * môn luôn) thì cao nhất là TB
                                strGraduationLevel = "Trung bình";
                            else if (intReExam > 1 || dbGraduationRankingAverage < 7.0) // thi lại 2 lần thì chỉ là Trung bình khá
                                strGraduationLevel = "Trung bình khá";
                            else if (intReExam > 0 || dbGraduationRankingAverage < 8) // thi lại 1 lần thì cao nhất là Khá                            
                                strGraduationLevel = "Khá";
                            else if (dbGraduationRankingAverage < 9)
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 0 || drw["SanctionFormID"].ToString() != "") // có học lại/thi lại or kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Khá";
                                else
                                    strGraduationLevel = "Giỏi";
                            }
                            else
                            {
                                if (Convert.ToDouble(drw["PercentReExam"]) > 0 || drw["SanctionFormID"].ToString() != "") // có học lại/thi lại or kỷ luật cảnh cáo trở lên thì hạ bậc
                                    strGraduationLevel = "Giỏi";
                                else
                                    strGraduationLevel = "Xuất sắc";
                            }
                        }
                        else
                            strGraduationLevel = "Không đạt";

                        drw["GraduationLevel"] = strGraduationLevel;
                        btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                    else
                    {
                        drw["GraduationRankingAverage"] = 0;
                        drw["GraduationLevel"] = "";
                    }
                }
            }

        }


       


        private void Statistic(DataTable dtb)
        {
            // Set xep loai tot nghiep
            iKD = 0; iTB = 0; iTBKha = 0; iKha = 0; iGioi = 0; iXuatSac = 0; iSV = 1;
            if (dtb == null || dtb.Rows.Count == 0)
                return;

            iSV = dtb.Rows.Count;
            foreach (DataRow drw in dtb.Rows)
            {
                switch (drw["GraduationLevel"].ToString())
                {
                    case "":
                    case "Không đạt":
                        iKD++; break;
                    case "Trung bình":
                        iTB++;
                        break;
                    case "Trung bình khá":
                        iTBKha++;
                        break;
                    case "TB khá":
                        iTBKha++;
                        break;
                    case "Khá":
                        iKha++;
                        break;
                    case "Giỏi":
                        iGioi++;
                        break;
                    case "Xuất sắc":
                        iXuatSac++;
                        break;                    
                }
            }            
        }
       
        private void btnPrint2_Click(object sender, EventArgs e)
        {
            // print danh sach du dieu kien tot nghiep
            decimal TLXuatSac = 0, TLGioi = 0, TLKha = 0, TLTBKha = 0, TLTB = 0;
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            // Chi lay sinh  vien tot nghiep
            dtbData2.DefaultView.RowFilter = "Isnull(GraduationLevel,'') <> '' and GraduationLevel <> 'Không đạt' ";
            dtbData2 = dtbData2.DefaultView.ToTable();
            Statistic(dtbData2);

            string strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC14.repx";
            switch (uClass.RegulationID)
            {
                case 14:
                    if (uClass.TrainingLevelIDEditValue.ToString() == "SC" || uClass.TrainingLevelIDEditValue.ToString() == "NH")
                    {
                        strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC14_NH.repx";
                        break;
                    }
                    else
                    {
                        strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC14.repx";
                        break;
                    }
                case 40:
                case 46:
                case 22:
                    if (uClass.SpecialBranchIDEditValue.ToString() == "VH")
                    {
                        strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_VH_QC22.repx"; // trường tw3 xài chung với mẫu 14
                    }
                    else
                    {
                        strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC14.repx"; // trường tw3 xài chung với mẫu 14
                    }
                    break;
                case 4:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC04.repx"; // trường tw3 xài chung với mẫu 14
                    break;    
                case 9:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC14.repx"; // trường tw3 xài chung với mẫu 14
                    break;                
                default:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiep_QC14.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strReport, false);
            // set subject name for report
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                if (uClass.SpecialBranchIDEditValue.ToString() == "VH")
                {
                    if (drw["SpecialType"].ToString() == "5")// không lấy môn tn văn hóa
                    {
                        frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                        i++;
                    }
                }
                else
                {
                    if (drw["SpecialType"].ToString() != "5")// không lấy môn tn văn hóa
                    {
                        frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                        i++;
                    }
                }

            }
            if (iSV > 0)
            {
                // truyen tham so theo ý riêng
                TLXuatSac = iXuatSac * 100 / iSV;
                TLGioi = iGioi * 100 / iSV;
                TLKha = iKha * 100 / iSV;
                TLTBKha = iTBKha * 100 / iSV;
                TLTB = iTB * 100 / iSV;
            }
            frm.SetParameter("pCourse",uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);            
            frm.SetParameter("pSpecialBranch",uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            //Truyen tham so tinh trung binh, ti le phan tram
            frm.SetParameter("pXuatSac", iXuatSac);
            frm.SetParameter("pTLXuatSac", TLXuatSac);
            frm.SetParameter("pGioi", iGioi);
            frm.SetParameter("pTLGioi", TLGioi);
            frm.SetParameter("pKha", iKha );
            frm.SetParameter("pTLKha", TLKha);
            frm.SetParameter("pTBKha", iTBKha);
            frm.SetParameter("pTLTBKha", TLTBKha);
            frm.SetParameter("pTB", iTB);
            frm.SetParameter("pTLTB", TLTB);
            frm.SetParameter("pSV", iSV);

            frm.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print danh sach khong du dieu kien tot nghiep
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            dtbData2.DefaultView.RowFilter = "Isnull(GraduationLevel,'') ='' or GraduationLevel = 'Không đạt'";
            dtbData2 = dtbData2.DefaultView.ToTable();
            string strReport = "";
            switch (uClass.RegulationID)
            {
                case 14:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiep_QC14.repx";
                    break;
                case 22:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiep_QC22.repx";
                    break;
                case 40:
                case 46:
                case 04:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiep_QC04.repx";
                    break;    
                case 09:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiep_QC22.repx";
                    break;                
                default:
                    strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiep_QC14.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strReport, false);

            // set subject name for report
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                if (uClass.RegulationID != 22)
                {
                    if (drw["SpecialType"].ToString() != "5")// không lấy môn tn văn hóa
                    {
                        frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                        i++;
                    }
                }
                else // Lấy môn van hóa
                {
                    if (drw["SpecialType"].ToString() == "5")
                    {
                        frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                        i++;
                    }
                }
            }
            
            // truyen tham so theo ý riêng

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);   
            frm.Show();
        }
      
        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            uClass.RefrehData();
            btnSearch_Click(null, null);
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemHopHoiDong_Click(object sender, EventArgs e)
        {
            // print danh sach du dieu kien tot nghiep
            decimal TLXuatSac = 0, TLGioi = 0, TLKha=0, TLTBKha=0, TLTB=0;
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            // Chi lay sinh  vien tot nghiep
            dtbData2.DefaultView.RowFilter = "Isnull(GraduationLevel,'') <>'' and  GraduationLevel <> 'Không đạt' ";
            dtbData2 = dtbData2.DefaultView.ToTable();
            Statistic(dtbData2);

            string strReport = "";
            if (uClass.RegulationID.Value == 14)
                strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiepHD_QC14.repx";
            else if (uClass.RegulationID.Value == 14)
                strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiepHD_QC04.repx";
            else 
                strReport = "Report/StudentManager/Graduation/Graduation_DSTotNghiepHD_QC22.repx";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strReport, false);
            // set subject name for report
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                if (drw["SpecialType"].ToString() != "5")
                {
                    frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                    i++;
                }
            }            
            // truyen tham so theo ý riêng
            if (iSV > 0)
            {
                TLXuatSac = iXuatSac * 100 / iSV;
                TLGioi = iGioi * 100 / iSV;
                TLKha = iKha * 100 / iSV;
                TLTBKha = iTBKha * 100 / iSV;
                TLTB = iTB * 100 / iSV;
            }
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            //Truyen tham so tinh trung binh, ti le phan tram
            frm.SetParameter("pXuatSac", iXuatSac);
            frm.SetParameter("pTLXuatSac", TLXuatSac);
            frm.SetParameter("pGioi", iGioi);
            frm.SetParameter("pTLGioi", TLGioi);
            frm.SetParameter("pKha", iKha);
            frm.SetParameter("pTLKha", TLKha);
            frm.SetParameter("pTBKha", iTBKha);
            frm.SetParameter("pTLTBKha", TLTBKha);
            frm.SetParameter("pTB", iTB);
            frm.SetParameter("pTLTB", TLTB);
            frm.SetParameter("pSV", iSV);

            frm.Show();
        }

        private void mniItemHoiDongKTN_Click(object sender, EventArgs e)
        {
            // print danh sach khong du dieu kien tot nghiep
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            dtbData2.DefaultView.RowFilter = "Isnull(GraduationLevel,'') ='' or GraduationLevel = 'Không đạt'";
            dtbData2 = dtbData2.DefaultView.ToTable();
            string strReport = "";
            if (uClass.RegulationID.Value == 14)
                strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiepHD_QC14.repx";
            else
                strReport = "Report/StudentManager/Graduation/Graduation_DSKhongTotNghiepHD_QC22.repx";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strReport, false);

            // set subject name for report
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                if (drw["SpecialType"].ToString() != "5")
                {
                    frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                    i++;
                }
            }
            
            // truyen tham so theo ý riêng

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);            

            frm.Show();
        }

        private void mnuKetQuaThiTotnghiep_Click(object sender, EventArgs e)
        {
            // print danh sach khong du dieu kien tot nghiep
            DataTable dtbData2 = (gvData.DataSource as DataView).Table.Copy();
            Statistic(dtbData2);

            string strReport = "";
            if (uClass.RegulationID.Value == 14)
                strReport = "Report/StudentManager/Graduation/Graduation_DSKetQuaThiTotNghiep_QC14.repx";
            else
                strReport = "Report/StudentManager/Graduation/Graduation_DSKetQuaThiTotNghiep_QC22.repx";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strReport, false);

            // set subject name for report
            int i = 1;
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                if (drw["SpecialType"].ToString() != "5")// không lấy môn tn văn hóa
                {
                    frm.SetParameter("pSubject" + i.ToString(), drw["SubjectName"]);
                    i++;
                }
            }
            
            // truyen tham so theo ý riêng

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch",uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pExamDate",lookupExamDate.EditValueString);
            //Truyen tham so tinh trung binh, ti le phan tram
            if (iSV > 0)
            {
                frm.SetParameter("pXuatSac", iXuatSac);
                frm.SetParameter("pTLXuatSac", iXuatSac * 100 / iSV);
                frm.SetParameter("pGioi", iGioi);
                frm.SetParameter("pTLGioi", iGioi * 100 / iSV);
                frm.SetParameter("pKha", iKha);
                frm.SetParameter("pTLKha", iKha * 100 / iSV);
                frm.SetParameter("pTBKha", iTBKha);
                frm.SetParameter("pTLTBKha", iTBKha * 100 / iSV);
                frm.SetParameter("pTB", iTB);
                frm.SetParameter("pTLTB", iTB * 100 / iSV);
                frm.SetParameter("pKD", iKD);
                frm.SetParameter("pTLKD", iKD * 100 / iSV);
                frm.SetParameter("pSV", iSV);
            }

            frm.Show();
        }

        private void gcData_Click(object sender, EventArgs e)
        {

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

        private void mnuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn muốn xoá kết quả xét tốt nghiệp!") == System.Windows.Forms.DialogResult.Yes)
            {
                SIM_GraduationResult obj = new SIM_GraduationResult();
                obj.BeginTransaction();
                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    obj.GraduationResultID = Convert.ToInt64(drw["GraduationResultID"]);
                    obj.Get();
                    obj.DecisionNo = null;
                    obj.Signingdate = null;
                    obj.YearID = null;
                    obj.CerNo = null;
                    obj.CerIssued = null;
                    obj.SummaryLearningMark = null;
                    obj.SummaryLearningLevel = null;
                    obj.GraduationExamAverage = null;
                    obj.GraduationRankingAverage = null;
                    obj.GraduationLevel = null;
                    obj.ResultReview = null;
                    obj.UpdatedUser = UserSession.Username;
                    if (!obj.Update())
                    {
                        ErrorManager.Error("Việc xoá kết quả xét tốt nghiệp bị lỗi!");
                        return;
                    }
                }
                obj.CommitTransaction();
                new Thread(LoadData).Start();
            }
        }

        private void btnSetDecisionNo_Click(object sender, EventArgs e)
        {
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                drw["DecisionNo"] = txtDecisionNo.TextTrim;
            }
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void btnSetSigningdate_Click(object sender, EventArgs e)
        {
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                drw["Signingdate"] = dateSigningdate.EditValue != null ? dateSigningdate.EditValue : DBNull.Value;
            }
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void btnSetYearID_Click(object sender, EventArgs e)
        {
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                drw["YearID"] = uYearID.YearIDEditValue != null ? uYearID.YearIDEditValue : DBNull.Value;
            }
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnSave.Enabled = mnuItemSave.Enabled = true; // UserSession.HasPermission(PERMISSION_EDIT);
        }

        private void mnuItemPrint2_Click(object sender, EventArgs e)
        {

        }

        private void mnuItemPrint_Click(object sender, EventArgs e)
        {

        }

        private void uClass_Validated(object sender, EventArgs e)
        {
            LoadExamDate();
        }
        
    }
}