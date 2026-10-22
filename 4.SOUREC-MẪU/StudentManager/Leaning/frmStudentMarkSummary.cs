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
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;
using AccountObject;
using AccountService;
using DevExpress.XtraGrid.Views.BandedGrid;
namespace StudentManager.Learning
{
    public partial class frmStudentMarkSummary : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_VIEW = "SIM_StudentMarkSummary_View";

        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        SIM_Student itemStudentEditing = new SIM_Student(); // record đang edit
        string strServerPath_StudentImage = "";
        string strLocalFilePath_StudentImage = ""; // file hinh dang chon         
        int intRegulationID = 14;

        #endregion

        #region IForm Members

        private static frmStudentMarkSummary _instance = null;

        public static frmStudentMarkSummary Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmStudentMarkSummary();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmStudentMarkSummary()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền            
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                strServerPath_StudentImage = SystemService.SYS_SettingService.GetStringValue("ServerPath_StudentImage"); // đường dẫn hình
                GeneralService.GEN_EthnicityService.InitLookUpEdit(lookupEthnicityID);
                GeneralService.GEN_ReligionService.InitLookUpEdit(lookupReligionID);
                
                uClassID_Search.InitData();
                uYearSemester.InitData();
                uClass21.InitData();
               
                // neu co using GeneralService ở trên cùng thì viết vầy GEN_EthnicityService.InitLookUpEdit() là dc
                uStudentStatus.InitData();
            }
        }

        /// <summary>
        /// Làm mới dữ liệu trong các combobox hay này nọ...
        /// </summary>
        public void RefreshReferenceData()
        {
            //SIM_ProvinceService.HaveNewData = true;
            LoadReferenceData();
        }

        private void SearchAllEthich(long studentID)
        {
            SIM_SummaryEthicMark objEthic = new SIM_SummaryEthicMark();
            DataTable dtbData = objEthic.SearchSummaryEthicMark(studentID);
            if (dtbData != null)
            {
                gcData2.DataSource = dtbData;
                SYS_GridColumnService.InitGridColumn(gvData2, "SIM_SearchSummaryEthicMark");
            }
            
        }

        // Lay thong tin hoc phi cua sinh vien
        private void SearchReceiptPlanOfStudent(long studentID)
        {
            ACC_StudentReceiptPlan objStudentReceiptPlan = new ACC_StudentReceiptPlan();
            DataTable dtbData = objStudentReceiptPlan.Search_ReceiptPlanOfStudent(studentID,null);
            if (dtbData != null)
            {
                gcData3.DataSource = dtbData;
                SYS_GridColumnService.InitGridColumn(gvData3, "ACC_Search_ReceiptPlanOfStudent");
            }

        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                RepairGrid();
                if (uClassID_Search.CourseIDEditValue == null && uClassID_Search.TrainingLevelIDEditValue == null && uClassID_Search.BranchEditValue == null
                    && txtFullname_Search.TextTrim == "" && txtStudentCode_Search.TextTrim == "")
                {
                    MessageManager.Warning("Bạn phải chọn ít nhất một điều kiện tìm kiếm!");
                    return;
                }
                SIM_Student objStudent = new SIM_Student();
                DataTable dtbStudent = objStudent.Search(
                                            "@CourseID", uClassID_Search.CourseIDEditValue, "@BranchID", uClassID_Search.BranchEditValue,
                                            "@TrainingLevelID", uClassID_Search.TrainingLevelIDEditValue, "@TrainingType", uClassID_Search.TrainingTypeEditValue,
                                            "@ScienceID", uClassID_Search.ScienceIDEditValue,
                                            "@StudentCode", txtStudentCode_Search.Text, "@ClassID", uClassID_Search.ClassIDEditValue,
                                            "@FullName", txtFullname_Search.Text,
                                            "@Status", uStudentStatus.EditValueInt32);
                if (dtbStudent != null)
                {
                    gcData.DataSource = dtbStudent;
                    SYS_GridColumnService.InitGridColumn(gvData, "StudentMarkSummary"); // khởi tạo hiện thị cột trên lưới
                    // set order
                    gvData.SetOrder("Order");
                    gvData.SearchAndSelectRow(SIM_Student.C_StudentID, itemStudentEditing.StudentID); // chọn dòng đang edit
                    
                    mnuItemEdit.Enabled = btnEdit.Enabled = gvData.GetFocusedDataRow() != null;
                    //btnSaveGrid.Enabled = false; // load thì không cần save trên lưới                                   
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
               
            }
        }

        private void LoadSubjectMark(long studentID)
        {
            // gan thong tin diem cho sinh vien
            SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
            DataTable dtbSubjectMark = objSubjectMark.GetDataTable("SIM_SubjectMark_SearchFinalForStudent","@StudentID", studentID);
            if (dtbSubjectMark != null)
            {
                dtbSubjectMark.Columns.Add("Order", typeof(int));
                gcData1.DataSource = dtbSubjectMark;
                // set order
                gvData1.SetOrder("Order");
                ModifyGrid();

                gvData1.BestFitColumns();

                int intUnitText = 0;
                double dblTotal = 0;

                DataRow[] rows = dtbSubjectMark.Select("IsIgnore = 0 and SpecialType = 1 and FinalSummary is not null"); // chỉ tính môn bình thường, không miễn và đã có tổng kết
                foreach (DataRow drw in rows)
                {
                    int a = Convert.ToInt32(drw["UnitText"]);
                    intUnitText += a;
                    dblTotal += a * Convert.ToDouble(drw["FinalSummary"]);
                }

                if (intUnitText > 0)
                {
                    txtUnitText.Text = Convert.ToString(intUnitText);
                    txtTBC.Text = Convert.ToString(Math.Round(dblTotal / intUnitText, 1, MidpointRounding.AwayFromZero));
                    string strGraduationLevel = "";
                    if (Convert.ToDouble(txtTBC.Text) < 4)
                        strGraduationLevel = "Kém";
                    else if (Convert.ToDouble(txtTBC.Text) < 5)
                        strGraduationLevel = "Yếu";
                    else if (Convert.ToDouble(txtTBC.Text) < 6)
                        strGraduationLevel = "Trung bình";
                    else if (Convert.ToDouble(txtTBC.Text) < 7.0)
                        strGraduationLevel = "TB khá";
                    else if (Convert.ToDouble(txtTBC.Text) < 8)
                        strGraduationLevel = "Khá";
                    else if (Convert.ToDouble(txtTBC.Text) < 9)
                        strGraduationLevel = "Giỏi";
                    else
                        strGraduationLevel = "Xuất sắc";
                    txtXL.Text = strGraduationLevel;
                }
                else
                {
                    txtUnitText.Text = "0";
                    txtTBC.Text = "";
                    txtXL.Text = "";
                }
            }
        }

        /// <summary>
        /// Khởi tạo 53 cột cho 53 tuần cho lưới
        /// </summary>
        private void RepairGrid()
        {
            // Xóa hết grid 
            gvData1.Bands.Clear();
            gvData1.Columns.Clear();


            // Thêm Student Band
            GridBand gbSubject = new GridBand();
            gbSubject.Caption = "MÔN HỌC";
            gbSubject.AppearanceHeader.Options.UseFont = true;
            gbSubject.AppearanceHeader.Options.UseTextOptions = true;
            gbSubject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSubject.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbSubject.Name = "gbSubject";
            gbSubject.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;


            // gcolOrder              
            BandedGridColumn gcolOrder = new BandedGridColumn();
            gcolOrder.Caption = "STT";
            gcolOrder.FieldName = "Order";
            gcolOrder.Name = "gcolOrder";
            //gcolOrder.Width = 30;
            gcolOrder.Visible = true;
            gcolOrder.AppearanceHeader.Options.UseFont = true;
            gcolOrder.AppearanceHeader.Options.UseTextOptions = true;
            gcolOrder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolOrder.AppearanceCell.Options.UseTextOptions = true;
            gcolOrder.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // gcolSubjectID
            BandedGridColumn gcolSubjectID = new BandedGridColumn();
            gcolSubjectID.Caption = "Mã môn";
            gcolSubjectID.FieldName = "SubjectID";
            gcolSubjectID.Name = "gcolSubjectID";
            //gcolSubjectID.Width = 60;
            gcolSubjectID.Visible = true;
            gcolSubjectID.AppearanceHeader.Options.UseTextOptions = true;
            gcolSubjectID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            // gcolSubjectName
            BandedGridColumn gcolSubjectName = new BandedGridColumn();
            gcolSubjectName.Caption = "Tên môn";
            gcolSubjectName.FieldName = "SubjectName";
            gcolSubjectName.Name = "gcolSubjectName";
            //gcolSubjectName.Width = 140;
            gcolSubjectName.Visible = true;
            gcolSubjectName.AppearanceHeader.Options.UseTextOptions = true;
            gcolSubjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            
            // gcolUnitText
            BandedGridColumn gcolUnitText = new BandedGridColumn();
            gcolUnitText.Caption = "ĐVHT";
            gcolUnitText.FieldName = "UnitText";
            gcolUnitText.Name = "gcolUnitText";
            //gcolSubjectName.Width = 140;
            gcolUnitText.Visible = true;
            gcolUnitText.AppearanceHeader.Options.UseTextOptions = true;
            gcolUnitText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolUnitText.AppearanceCell.Options.UseTextOptions = true;
            gcolUnitText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            gvData1.Bands.Add(gbSubject);
            gvData1.Columns.AddRange(new BandedGridColumn[] { gcolOrder, gcolSubjectID, gcolSubjectName, gcolUnitText });
            gbSubject.Columns.Add(gcolOrder); // add cột vào Band            
            gbSubject.Columns.Add(gcolSubjectID);
            gbSubject.Columns.Add(gcolSubjectName);            
            gbSubject.Columns.Add(gcolUnitText);


            if (intRegulationID != 25)
            {
                for (int i = 1; i < 3; i++)
                {
                    GridBand gbMark = new GridBand();
                    if (i == 1)
                        gbMark.Caption = "KIỂM TRA THƯỜNG XUYÊN (HS1)";
                    else
                        gbMark.Caption = "KIỂM TRA ĐỊNH KÌ (HS2)";
                    gbMark.AppearanceHeader.Options.UseFont = true;
                    gbMark.AppearanceHeader.Options.UseTextOptions = true;
                    gbMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gbMark.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                    gbMark.Name = "gbMark" + i.ToString();
                    gvData1.Bands.Add(gbMark);

                    int j = 8;
                    //if (i == 1)
                    //{
                    //    if (txtMark1Number.EditValueInt32 != null)
                    //        j = txtMark1Number.EditValueInt32.Value;
                    //}
                    //else
                    //{
                    //    if (txtMark2Number.EditValueInt32 != null)
                    //        j = txtMark2Number.EditValueInt32.Value;
                    //}

                    for (; j > 0; j--)
                    {
                        BandedGridColumn gcolMark = new BandedGridColumn();
                        string strName = i.ToString() + j.ToString();
                        gcolMark.Caption = "HS " + strName;
                        gcolMark.FieldName = "Mark" + strName;
                        gcolMark.Name = "gcolMark" + strName;
                        gcolMark.OptionsColumn.AllowMove = false;
                        gcolMark.OptionsColumn.AllowSize = false;
                        gcolMark.Width = 40;
                        gcolMark.OptionsColumn.FixedWidth = true;
                        gcolMark.Visible = true;
                        gcolMark.AppearanceHeader.Options.UseFont = true;
                        gcolMark.AppearanceHeader.Options.UseTextOptions = true;
                        gcolMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gcolMark.AppearanceCell.Options.UseTextOptions = true;
                        gcolMark.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gcolMark.DisplayFormat.FormatString = "#0.#";
                        gcolMark.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;


                        gbMark.Columns.Add(gcolMark); // add cột tuần vào
                        gvData1.Columns.Add(gcolMark); // add cột vào lưới
                    }
                }
            }

            // Thêm TBKT Band
            GridBand gbTestAverage = new GridBand();
            gbTestAverage.Caption = "TBKT";
            gbTestAverage.AppearanceHeader.Options.UseFont = true;
            gbTestAverage.AppearanceHeader.Options.UseTextOptions = true;
            gbTestAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbTestAverage.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbTestAverage.Name = "gbTestAverage";


            BandedGridColumn gcolTestAverage = new BandedGridColumn();
            gcolTestAverage.Caption = "TBKT";
            gcolTestAverage.FieldName = "TestAverage";
            gcolTestAverage.Name = "gcolTestAverage";
            gcolTestAverage.OptionsColumn.AllowMove = false;
            gcolTestAverage.OptionsColumn.AllowSize = false;
            gcolTestAverage.OptionsColumn.FixedWidth = true;
            gcolTestAverage.Visible = true;
            gcolTestAverage.Width = 60;
            gcolTestAverage.AppearanceHeader.Options.UseFont = true;
            gcolTestAverage.AppearanceHeader.Options.UseTextOptions = true;
            gcolTestAverage.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolTestAverage.AppearanceCell.Options.UseTextOptions = true;
            gcolTestAverage.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolTestAverage.DisplayFormat.FormatString = "#0.#";
            gcolTestAverage.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gcolTestAverage.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gcolTestAverage.AppearanceCell.Options.UseFont = true;

            gvData1.Bands.Add(gbTestAverage);
            gbTestAverage.Columns.Add(gcolTestAverage); // add cột tuần vào
            gvData1.Columns.Add(gcolTestAverage); // add cột vào lưới


            // Thêm THI Band
            GridBand gbExam = new GridBand();
            gbExam.Caption = "KIỂM TRA HẾT MÔN";
            gbExam.AppearanceHeader.Options.UseFont = true;
            gbExam.AppearanceHeader.Options.UseTextOptions = true;
            gbExam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbExam.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbExam.Name = "gbExam";

            gvData1.Bands.Add(gbExam);

            for (int i = 3; i > 0; i--)
            {
                BandedGridColumn gcolExam = new BandedGridColumn();
                gcolExam.Caption = "Thi " + i.ToString();
                gcolExam.FieldName = "Exam" + i.ToString();
                gcolExam.Name = "gcolExam" + i.ToString();
                gcolExam.OptionsColumn.AllowMove = false;
                gcolExam.OptionsColumn.AllowSize = false;
                gcolExam.OptionsColumn.FixedWidth = true;
                gcolExam.Width = 60;
                gcolExam.Visible = true;
                gcolExam.AppearanceHeader.Options.UseFont = true;
                gcolExam.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam.AppearanceCell.Options.UseTextOptions = true;
                gcolExam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam.DisplayFormat.FormatString = "#0.#";
                gcolExam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                gbExam.Columns.Add(gcolExam); // add cột tuần vào
                gvData1.Columns.Add(gcolExam); // add cột vào lưới
            }

            // Thêm TKM Band
            GridBand gbSummary = new GridBand();
            gbSummary.Caption = "TKM";
            gbSummary.AppearanceHeader.Options.UseFont = true;
            gbSummary.AppearanceHeader.Options.UseTextOptions = true;
            gbSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSummary.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbSummary.Name = "gbSummary";

            gvData1.Bands.Add(gbSummary);

            for (int i = 3; i > 0; i--)
            {
                BandedGridColumn gcolSummary = new BandedGridColumn();
                gcolSummary.Caption = "Lần " + i.ToString();
                gcolSummary.FieldName = "Summary" + i.ToString();
                gcolSummary.Name = "gcolSummary" + i.ToString();
                gcolSummary.OptionsColumn.AllowMove = false;
                gcolSummary.OptionsColumn.AllowSize = false;
                gcolSummary.OptionsColumn.FixedWidth = true;
                gcolSummary.Visible = true;
                gcolSummary.Width = 60;
                gcolSummary.AppearanceHeader.Options.UseFont = true;
                gcolSummary.AppearanceHeader.Options.UseTextOptions = true;
                gcolSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary.AppearanceCell.Options.UseTextOptions = true;
                gcolSummary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary.DisplayFormat.FormatString = "#0.#";
                gcolSummary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcolSummary.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                gcolSummary.AppearanceCell.Options.UseFont = true;

                gbSummary.Columns.Add(gcolSummary); // add cột tuần vào
                gvData1.Columns.Add(gcolSummary); // add cột vào lưới
            }

            // Thêm Lần học Band
            GridBand gbOrderLearning = new GridBand();
            gbOrderLearning.Caption = "Lần học";
            gbOrderLearning.AppearanceHeader.Options.UseFont = true;
            gbOrderLearning.AppearanceHeader.Options.UseTextOptions = true;
            gbOrderLearning.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbOrderLearning.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbOrderLearning.Name = "gbOrderLearning";


            BandedGridColumn gcolOrderLearning = new BandedGridColumn();
            gcolOrderLearning.Caption = "Lần học";
            gcolOrderLearning.FieldName = "OrderLearning";
            gcolOrderLearning.Name = "gcolOrderLearning";
            gcolOrderLearning.OptionsColumn.AllowMove = false;
            gcolOrderLearning.OptionsColumn.AllowSize = false;
            gcolOrderLearning.OptionsColumn.FixedWidth = true;
            gcolOrderLearning.Visible = true;
            gcolOrderLearning.Width = 60;
            gcolOrderLearning.AppearanceHeader.Options.UseFont = true;
            gcolOrderLearning.AppearanceHeader.Options.UseTextOptions = true;
            gcolOrderLearning.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolOrderLearning.AppearanceCell.Options.UseTextOptions = true;
            gcolOrderLearning.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolOrderLearning.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gcolOrderLearning.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gcolOrderLearning.AppearanceCell.Options.UseFont = true;

            gvData1.Bands.Add(gbOrderLearning);
            gbOrderLearning.Columns.Add(gcolOrderLearning); // add cột tuần vào
            gvData1.Columns.Add(gcolOrderLearning); // add cột vào lưới


            // Miễn học Band
            GridBand gbIsIgnore = new GridBand();
            gbIsIgnore.Caption = "Miễn học";
            gbIsIgnore.AppearanceHeader.Options.UseFont = true;
            gbIsIgnore.AppearanceHeader.Options.UseTextOptions = true;
            gbIsIgnore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbIsIgnore.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbIsIgnore.Name = "gbIsIgnore";


            BandedGridColumn gcolIsIgnore = new BandedGridColumn();
            gcolIsIgnore.Caption = "Miễn học";
            gcolIsIgnore.FieldName = "IsIgnore";
            gcolIsIgnore.Name = "gcolIsIgnore";
            gcolIsIgnore.OptionsColumn.AllowMove = false;
            gcolIsIgnore.OptionsColumn.AllowSize = false;
            gcolIsIgnore.OptionsColumn.FixedWidth = true;
            gcolIsIgnore.Visible = true;
            gcolIsIgnore.Width = 60;
            gcolIsIgnore.AppearanceHeader.Options.UseFont = true;
            gcolIsIgnore.AppearanceHeader.Options.UseTextOptions = true;
            gcolIsIgnore.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolIsIgnore.AppearanceCell.Options.UseTextOptions = true;
            gcolIsIgnore.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolIsIgnore.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gcolIsIgnore.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gcolIsIgnore.AppearanceCell.Options.UseFont = true;

            gvData1.Bands.Add(gbIsIgnore);
            gbIsIgnore.Columns.Add(gcolIsIgnore); // add cột tuần vào
            gvData1.Columns.Add(gcolIsIgnore); // add cột vào lưới


            // chỉ dành cho tín chỉ 43
            if (intRegulationID == 43)
            {
                // Thêm Student Band
                GridBand gbSummary43 = new GridBand();
                gbSummary43.Caption = "ĐIỂM QUY ĐỔI";
                gbSummary43.AppearanceHeader.Options.UseFont = true;
                gbSummary43.AppearanceHeader.Options.UseTextOptions = true;
                gbSummary43.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSummary43.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                gbSummary43.Name = "gbSummary43";


                // gcolOrder              
                BandedGridColumn gcolLearningLevel = new BandedGridColumn();
                gcolLearningLevel.Caption = "Đ Chữ";
                gcolLearningLevel.FieldName = "LearningLevel";
                gcolLearningLevel.Name = "gcolLearningLevel";
                gcolLearningLevel.Width = 60;
                gcolLearningLevel.Visible = true;
                gcolLearningLevel.AppearanceHeader.Options.UseFont = true;
                gcolLearningLevel.AppearanceHeader.Options.UseTextOptions = true;
                gcolLearningLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolLearningLevel.AppearanceCell.Options.UseTextOptions = true;
                gcolLearningLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                // gcolSubjectID
                BandedGridColumn gcolOtherFinalSummary = new BandedGridColumn();
                gcolOtherFinalSummary.Caption = "Đ. Số";
                gcolOtherFinalSummary.FieldName = "OtherFinalSummary";
                gcolOtherFinalSummary.Name = "gcolOtherFinalSummary";
                gcolOtherFinalSummary.Width = 60;
                gcolOtherFinalSummary.Visible = true;
                gcolOtherFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                gcolOtherFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gvData1.Bands.Add(gbSummary43);
                gvData1.Columns.AddRange(new BandedGridColumn[] { gcolLearningLevel, gcolOtherFinalSummary });
                gbSummary43.Columns.Add(gcolLearningLevel); // add cột vào Band            
                gbSummary43.Columns.Add(gcolOtherFinalSummary);

            }
        }

        private void ModifyGrid()
        {            

            if (intRegulationID == 43)
                ModifyGrid43();
            else
            {
                switch (intRegulationID)
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
                    case 25: // cao đẳng chuyên nghiệp
                        ModifyGrid25();
                        break;
                }
            }

        }

        #region Ẩn cột trên lưới theo từng qui chế

        private void ModifyGrid14()
        {
            
            gvData1.Columns["Exam3"].Visible = false; // thi lần 3 bỏ
            gvData1.Columns["Summary3"].Visible = false; // TKM lần 3 bỏ
            gvData1.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";
        }

        private void ModifyGrid40()
        {
           
            gvData1.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";

        }

        private void ModifyGrid46()
        {
            
            gvData1.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";
        }

        private void ModifyGrid43()
        {
            // qui ước điểm điểm kiểm tra là từ Mark21-27
            // điểm Nhận thức, Chuyên cần từ Mark11,12,...

            for (int i = 3; i <= 7; i++)
            {
                gvData1.Columns["Mark1" + i.ToString()].Visible = false;
                gvData1.Columns["Mark2" + i.ToString()].Visible = false;
            }

            gvData1.Columns["Mark11"].Caption = "N.T.";
            gvData1.Columns["Mark12"].Caption = "C.Cần";

            for (int i = 1; i <= 2; i++)
                gvData1.Columns["Mark2" + i.ToString()].Caption = "(" + i.ToString() + ")";

            gvData1.Bands["gbMark1"].Caption = "Đ.Q.TRÌNH";
            gvData1.Bands["gbMark2"].Caption = "Đ. GIỮA KỲ";
            gvData1.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";

        }

        private void ModifyGrid25()
        {
            gvData1.Columns["TestAverage"].Caption = "Giữa kỳ ";
            gvData1.Bands["gbTestAverage"].Caption = "ĐIỂM GK";
            gvData1.Bands["gbExam"].Caption = "ĐIỂM THI";

            gvData1.Columns["Exam3"].Visible = false; // thi lần 3 bỏ
            gvData1.Columns["Summary3"].Visible = false; // TKM lần 3 bỏ     
        }
       
        #endregion

        /// <summary>
        /// Load dữ liệu vào tab edit
        /// </summary>        
        private void ShowEditForm(long studentID)
        {

            itemStudentEditing = new SIM_Student();
            itemStudentEditing.StudentID = studentID;
            if (!itemStudentEditing.Get()) // edit thì load lên
            {
                ErrorManager.Error("Việc lấy thông tin chỉnh sửa bị lỗi!");
                // string str = itemStudentEditing.ErrorException.Message;
                return;
            }

            // gán giá trị vào form
            txtStudentCode.Text = itemStudentEditing.StudentCode;
            txtStudentFirstName.Text = itemStudentEditing.StudentFirstName;
            txtStudentLastName.Text = itemStudentEditing.StudentLastName;
            txtBirthDay.Text = Convert.ToString(itemStudentEditing.BirthDay);
            txtBirthMonth.Text = Convert.ToString(itemStudentEditing.BirthMonth);
            txtBirthPlace.Text = itemStudentEditing.BirthPlace;
            txtBirthYear.Text = Convert.ToString(itemStudentEditing.BirthYear);
            uClass21.ClassIDEditValue = itemStudentEditing.ClassID;
            txtLiveAddress.Text = itemStudentEditing.LiveAddress;

            lookupEthnicityID.EditValue = itemStudentEditing.EthnicityID;

            if (itemStudentEditing.Image != null && itemStudentEditing.Image != "")
            {
                if (System.IO.File.Exists(strServerPath_StudentImage + itemStudentEditing.Image))
                    picStudent.Image = new Bitmap(strServerPath_StudentImage + itemStudentEditing.Image);
                else
                    picStudent.Image = null;
            }
            else
                picStudent.Image = null;
            strLocalFilePath_StudentImage = "";

            bolIsEditing = true;
            tcData.SelectedTabPage = tpDetail;
            txtStudentCode.Focus();
            LoadSubjectMark(studentID);// Load thong tin diem cho sinh viên
            SearchAllEthich(studentID);// Load thong tin diem ren luyen sinh vien
            SearchReceiptPlanOfStudent(studentID); // Lay thong tin cac khoan hoc phi cua sinh vien len.
        }

        #endregion

        #region Form Actions

        private void frmStudentMarkSummary_Load(object sender, EventArgs e)
        {
            new Thread(LoadReferenceData).Start();
            //new Thread(LoadData).Start();
            CheckPermission();
            SetToolTip();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                intRegulationID = Convert.ToInt32(drw["RegulationID"]);
                ShowEditForm(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bolIsEditing = false;
            tcData.SelectedTabPage = tpList;
        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            RefreshReferenceData();
            frmStudentMarkSummary_Load(sender, e);
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void tcData_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if ((!bolIsEditing && e.Page == tpDetail) || (bolIsEditing && e.Page == tpList))
                e.Cancel = true;
        }

        private void frmStudentMarkSummary_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F2:
                    if (!bolIsEditing)
                        btnEdit_Click(sender, null);
                    break;

                case Keys.F5:
                    if (!bolIsEditing)
                        mnuItemRefresh_Click(sender, null);
                    break;

                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.Escape:
                    if (bolIsEditing)
                        btnCancel_Click(sender, null);
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new Thread(LoadData).Start();
        }

        private void uClass21_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Bảng điểm và kết quả học tập cho một sinh viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                SIM_Student objStudentMarkSummary = new SIM_Student();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();

                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary_Nghe(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                    if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                    {
                        // print danh sách sinh viên dự thi

                        string strreport = "";
                        switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                        {
                            case 14: // cao đẳng, tc nghề
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC14.repx";
                                break;
                            case 09: // trung cấp chuyên nghiệp
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC14.repx";
                                break;
                            case 4:
                                 strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC04.repx";
                                break;
                            case 46:
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC22.repx";
                                break;

                            default:
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC.repx";
                                break;
                        }
                        SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                        
                        // Lay danh sach mon tot nghiep
                        DataTable dtbClassSubject = objClassSubject.SearchSubject_Graduation1(Convert.ToInt64(drw[SIM_Student.C_StudentID]));                        
                        if (dtbClassSubject.Rows.Count == 0)
                        {
                            MessageManager.Warning("Không thể in mẫu này cho sinh viên chưa tốt nghiệp!");
                            return;
                        }
                        if (dtbClassSubject.Rows.Count > 0)
                        {
                            frm.SetParameter("pSubjectName1", dtbClassSubject.Rows[0]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectName2", dtbClassSubject.Rows[1]["SubjectName"].ToString());
                            if (dtbClassSubject.Rows.Count > 2)
                            {
                                frm.SetParameter("pSubjectName3", dtbClassSubject.Rows[2]["SubjectName"].ToString());
                                if (dtbClassSubject.Rows[2]["FinalSummary"].ToString() != "")
                                    frm.SetParameter("pSubjectMark3", string.Format("{0:0.0}", dtbClassSubject.Rows[2]["FinalSummary"]));
                            }
                           
                            if (dtbClassSubject.Rows[0]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMark1", string.Format("{0:0.0}", dtbClassSubject.Rows[0]["FinalSummary"]));
                            if (dtbClassSubject.Rows[1]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMark2", string.Format("{0:0.0}", dtbClassSubject.Rows[1]["FinalSummary"]));
                           
                        }
                        
                        else
                        {
                            MessageManager.Warning("Không thể in mẫu này cho sinh viên chưa tốt nghiệp!");
                            return;
                        }
                        frm.Show();
                        if (gvData.GetSelectedRows().Length > 1)
                        {
                            frm.Print();
                            frm.Close();
                        }
                    }
                    else
                    {
                        ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                    }
                }
            }
            catch
            {
                ErrorManager.Error("Dữ liệu chưa hợp lệ để in!");
            }         
        }

        private void picStudent_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.jpg;*.png;*.bmp;*.gif | *.jpg;*.png;*.bmp;*.gif | *.* | *.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                picStudent.Image = new Bitmap(dlg.FileName);
                strLocalFilePath_StudentImage = dlg.FileName; // nhớ file này để chọn                
            }
        }
        #endregion

        private void mnuItemBangDiem_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();

            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi

                    string strreport = "";
                    switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                    {
                        case 14: // cao đẳng, tc nghề
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14.repx";
                            break;
                        case 40:
                        case 46:
                        case 22: // trung cấp chuyên nghiệp
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC22.repx";
                            break;                       
                        default:
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14.repx";
                            break;
                    }

                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnuItemGCN_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi

                    string strreport = "";
                    switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                    {
                        case 14: // cao đẳng, tc nghề
                            strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC14.repx";
                            break;
                        case 22:
                        case 46:
                        case 40: // trung cấp chuyên nghiệp
                            strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC22.repx";
                            break;                        
                        default:
                            strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC14.repx";
                            break;
                    }
                    // Lay danh sach mon tot nghiep
                    SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                    DataTable dtbClassSubject = objClassSubject.SearchSubject_Graduation1(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                    // Truyen thong tin các môn tốt nghiệp
                    if (dtbClassSubject.Rows.Count > 0)
                    {
                        frm.SetParameter("pSubjectName1", dtbClassSubject.Rows[0]["SubjectName"].ToString());
                        frm.SetParameter("pSubjectName2", dtbClassSubject.Rows[1]["SubjectName"].ToString());
                        frm.SetParameter("pSubjectMark1", dtbClassSubject.Rows[0]["FinalSummary"].ToString());
                        frm.SetParameter("pSubjectMark2", dtbClassSubject.Rows[1]["FinalSummary"].ToString());
                        if (dtbClassSubject.Rows.Count > 2)
                        {
                            frm.SetParameter("pSubjectName3", dtbClassSubject.Rows[2]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark3", dtbClassSubject.Rows[2]["FinalSummary"].ToString());
                        }
                        
                    }
                    else
                    {
                        return;
                    }
                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnu_BangDiem1_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();            
            SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi

                    string strreport = "";
                    switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                    {
                        case 14: // cao đẳng, tc nghề
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14_Mau2.repx";
                            break;

                        // tạm thời ko có thời gian sửa mẫu, nên dùng chung mẫu qc 14
                        //case 40: // trung cấp chuyên nghiệp
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC40.repx";
                        //    break;
                        //case 46: // trung cấp vừa học vừa làm
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC46.repx";
                        //    break;
                        //case 25: // Cao dang chinh qui
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap2_QC25.repx";
                        //    break;
                        default:
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14_Mau2.repx";
                            break;
                    }

                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);

                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

     
        private void SoDiemSoCap()
        {
            try
            {
                SIM_Student objStudentMarkSummary = new SIM_Student();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                    if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                    {
                        // print danh sách sinh viên dự thi
                        string strreport =  "Report/StudentManager/Learning/Leaning_SoHocTap_SC.repx";
                        SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                        //Truyen diem va ten cac mon hoc vao pham parameter cho cac mon hoc cua so cap nghe 
                        frm.SetParameter("pHSubjectName1", dtbStudentMarkSummary.Rows[0]["SubjectName"].ToString());
                        frm.SetParameter("pHSubjectMark1", dtbStudentMarkSummary.Rows[0]["FinalSummary"].ToString());
                        frm.SetParameter("pH1","1");
                        if (dtbStudentMarkSummary.Rows.Count > 1)
                        {
                            frm.SetParameter("pHSubjectName2", dtbStudentMarkSummary.Rows[1]["SubjectName"].ToString());
                            frm.SetParameter("pHSubjectMark2", dtbStudentMarkSummary.Rows[1]["FinalSummary"].ToString());
                            frm.SetParameter("pH2", "2");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 2)
                        {
                            frm.SetParameter("pHSubjectName3", dtbStudentMarkSummary.Rows[2]["SubjectName"].ToString());
                            frm.SetParameter("pHSubjectMark3", dtbStudentMarkSummary.Rows[2]["FinalSummary"].ToString());
                            frm.SetParameter("pH3", "3");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 3)
                        {
                            frm.SetParameter("pHSubjectName4", dtbStudentMarkSummary.Rows[3]["SubjectName"].ToString());
                            frm.SetParameter("pHSubjectMark4", dtbStudentMarkSummary.Rows[3]["FinalSummary"].ToString());
                            frm.SetParameter("pH4", "4");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 4)
                        {
                            frm.SetParameter("pHSubjectName4", dtbStudentMarkSummary.Rows[4]["SubjectName"].ToString());
                            frm.SetParameter("pHSubjectMark4", dtbStudentMarkSummary.Rows[4]["FinalSummary"].ToString());
                            frm.SetParameter("pH5", "5");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 5)
                        {
                            frm.SetParameter("pSubjectName6", dtbStudentMarkSummary.Rows[5]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark6", dtbStudentMarkSummary.Rows[5]["FinalSummary"].ToString());
                            frm.SetParameter("pH6", "6");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 6)
                        {
                            frm.SetParameter("pSubjectName7", dtbStudentMarkSummary.Rows[6]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark7", dtbStudentMarkSummary.Rows[6]["FinalSummary"].ToString());
                            frm.SetParameter("pH7", "7");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 7)
                        {
                            frm.SetParameter("pHSubjectName8", dtbStudentMarkSummary.Rows[7]["SubjectName"].ToString());
                            frm.SetParameter("pHSubjectMark8", dtbStudentMarkSummary.Rows[7]["FinalSummary"].ToString());
                            frm.SetParameter("pH8", "8");
                        }
                        if (dtbStudentMarkSummary.Rows.Count > 8)
                        {
                            frm.SetParameter("pHSubjectName9", dtbStudentMarkSummary.Rows[8]["SubjectName"].ToString());
                            frm.SetParameter("pHSubjectMark9", dtbStudentMarkSummary.Rows[8]["FinalSummary"].ToString());
                        }
                        // Lay danh sach mon tot nghiep
                        DataTable dtbClassSubject = objClassSubject.SearchSubject_Graduation1(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                       
                        // Truyen thong tin các môn tốt nghiệp
                        if (dtbClassSubject.Rows.Count > 0)
                        {
                            frm.SetParameter("pSubjectName1", dtbClassSubject.Rows[0]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark1", dtbClassSubject.Rows[0]["FinalSummary"].ToString());
                            if (dtbClassSubject.Rows.Count > 1)
                            {
                                frm.SetParameter("pSubjectName2", dtbClassSubject.Rows[1]["SubjectName"].ToString());
                                frm.SetParameter("pSubjectMark2", dtbClassSubject.Rows[1]["FinalSummary"].ToString());
                            }
                            if (dtbClassSubject.Rows.Count > 2)
                            {
                                frm.SetParameter("pSubjectName3", dtbClassSubject.Rows[2]["SubjectName"].ToString());
                                frm.SetParameter("pSubjectMark3", dtbClassSubject.Rows[2]["FinalSummary"].ToString());
                            }
                        }
                        else
                        {
                            return;
                        }
                        frm.Show();
                        if (gvData.GetSelectedRows().Length > 1)
                        {
                            frm.Print();
                            frm.Close();
                        }
                    }
                    else if (dtbStudentMarkSummary.Rows.Count == 0)
                    {
                        ErrorManager.Error("Sinh viên này chưa có điểm!");
                    }
                    else
                    {
                        ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                    }
                }
            }
            catch
            {
                ErrorManager.Error("Dữ liệu chưa hợp lệ để in!");
            }      
        }
        private void SoDiem_All(int iSoTrang)
        {
            try
            {
                SIM_Student objStudentMarkSummary = new SIM_Student();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                    // print danh sách sinh viên dự thi
                    string strreport = "Report/StudentManager/Learning/Leaning_SoHocTap.repx";
                    // Lay danh sach mon tot nghiep
                    
                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                    // in trang bìa thông tin học viên
                    if (iSoTrang == 0)
                    {
                        SystemManager.Report.frmReportView frmHS = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, "Report/StudentManager/Learning/Leaning_SoHocTap_TrangThongTin.repx", false);
                        frmHS.Show();
                        if (gvData.GetSelectedRows().Length > 1)
                        {
                            frmHS.Print();
                            frmHS.Close();
                        }
                    }
                    else if (iSoTrang == 1)
                    {
                        dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary1(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                        if (dtbStudentMarkSummary.Rows.Count > 0)
                        {
                            SystemManager.Report.frmReportView frmHS = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, "Report/StudentManager/Learning/Leaning_SoHocTap_Trang1.repx", false);
                            frm.Show();
                            if (gvData.GetSelectedRows().Length > 1)
                            {
                                frm.Print();
                                frm.Close();
                            }
                        }
                    }
                   
                }
            }
            catch
            {
                ErrorManager.Error("Dữ liệu chưa hợp lệ để in!");
            }      
        }
        private void mnuItemBangDiemNganHan_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {

                    string strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14_NganHan.repx";
                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);

                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnuItemPrint_BangTotNghiep_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

               

                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi

                    string strreport = "Report/StudentManager/Graduation/Graduation_BangTotNghiep_QC22.repx";

                    //switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                    //{
                    //    case 14: // cao đẳng, tc nghề
                    //        strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC14.repx";
                    //        break;
                    //    case 40: // trung cấp chuyên nghiệp
                    //        strreport = "Report/StudentManager/Graduation/Graduation_BangTotNghiep_QC40.repx";
                    //        break;
                    //    case 46: // trung cấp vừa học vừa làm
                    //        strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC40.repx";
                    //        break;
                    //    case 25: // Cao dang chinh qui QC25
                    //        strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC25.repx";
                    //        break;
                    //    default:
                    //        strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanTotNghiep_QC14.repx";
                    //        break;
                    //}

                                        
                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                    frm.SetParameter("pCerIssued", dtbStudentMarkSummary.Rows[0]["CerIssued"].ToString());
                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnuItem_SHTNH_Click(object sender, EventArgs e)
        {
            SoDiemSoCap();
        }

        private void mnuItem_SHT1_Click(object sender, EventArgs e)
        {
            SoDiem_All(0);
        }

        private void mnuSoHocTap_Click(object sender, EventArgs e)
        {

        }

        private void mnu_SHT2_Click(object sender, EventArgs e)
        {
            SoDiem_All(1);
        }

        private void mnu_SHTNH_Click(object sender, EventArgs e)
        {
            SoDiemSoCap();
        }

        private void mnuItemBangDiemHK_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            if (Convert.ToInt32(uYearSemester.YearIDEditValue) <= 0 || Convert.ToInt32(uYearSemester.SemesterEditValue) <= 0)
            {
                XtraMessageBox.Show("Bạn phải chọn năm học, học kỳ");
                return;
            }
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary2(Convert.ToInt64(drw[SIM_Student.C_StudentID]),
                    Convert.ToInt32(uYearSemester.YearIDEditValue), Convert.ToInt32(uYearSemester.SemesterEditValue));
                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi
                    string strreport = "";
                    switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                    {
                        case 14: // cao đẳng, tc nghề
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapHK_QC14.repx";
                            break;
                        case 40:
                        case 46:
                        case 22: // trung cấp chuyên nghiệp
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapHK_QC22.repx";
                            break;
                        default:
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapHK_QC14.repx";
                            break;
                    }

                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);

                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnuItemPrint_GCNHoanThanh_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi

                    string strreport = "Report/StudentManager/Learning/Leaning_GiayChungNhanHoanThanhChuongTrinhHoc.repx";

                    // Lay danh sach mon tot nghiep
                    SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                    DataTable dtbClassSubject = objClassSubject.SearchSubject_Graduation1(Convert.ToInt64(drw[SIM_Student.C_StudentID]));
                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                    // Truyen thong tin các môn tốt nghiệp
                    if (dtbClassSubject.Rows.Count > 0)
                    {
                        frm.SetParameter("pSubjectName1", dtbClassSubject.Rows[0]["SubjectName"].ToString());
                        frm.SetParameter("pSubjectName2", dtbClassSubject.Rows[1]["SubjectName"].ToString());
                        if (dtbClassSubject.Rows.Count > 2)
                        {
                            frm.SetParameter("pSubjectName3", dtbClassSubject.Rows[2]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark3", dtbClassSubject.Rows[2]["FinalSummary"].ToString());
                        }
                        frm.SetParameter("pSubjectMark1", dtbClassSubject.Rows[0]["FinalSummary"].ToString());
                        frm.SetParameter("pSubjectMark2", dtbClassSubject.Rows[1]["FinalSummary"].ToString());
                       
                    }
                    else
                    {
                        return;
                    }
                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnuItemDanhSachBangDiem_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            string strStudentIDList = ";";
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                strStudentIDList += drw["StudentID"] + ";";
            }
            
            //strStudentIDList = gvData.GetIDListSelected("StudentID");

            if (strStudentIDList == ";")
                return;
            DataTable dtbStudentMarkSummary = objStudentMarkSummary.GetDataTable("SIM_Student_SearchStudentMarkSummaryList", "@ClassID", uClassID_Search.ClassIDEditValue, "@StudentIDList", strStudentIDList);
            if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
            {
                // print danh sách sinh viên dự thi

                string strreport = "";
                switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                {
                    case 14: // cao đẳng, tc nghề
                        strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14_List.repx";
                        break;
                    case 40:
                    case 46:
                    case 22: // trung cấp chuyên nghiệp
                        strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC22.repx";
                        break;
                    default:
                        strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTap_QC14.repx";
                        break;
                }

                SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                frm.Show();
            }
            //}
        }

        private void mnuItemBangDiemTN_CoTNVanHoa_Click(object sender, EventArgs e)
        {
            try
            {
                SIM_Student objStudentMarkSummary = new SIM_Student();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();

                foreach (int i in gvData.GetSelectedRows())
                {
                    DataRow drw = gvData.GetDataRow(i);
                    DataTable dtbStudentMarkSummary = objStudentMarkSummary.SearchStudentMarkSummary(Convert.ToInt64(drw[SIM_Student.C_StudentID]));

                    if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                    {
                        // print danh sách sinh viên dự thi

                        string strreport = "";
                        switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                        {
                            case 14: // cao đẳng, tc nghề
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC14_CoTNVH.repx";
                                break;
                            case 22: // trung cấp chuyên nghiệp
                            case 40:
                            case 46:
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC22_CoTNVH.repx";
                                break;
                            default:
                                strreport = "Report/StudentManager/Learning/Leaning_BangDiemTotNghiep_QC14_CoTNVH.repx";
                                break;
                        }

                        SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);

                        // Lay danh sach mon tot nghiep
                        DataTable dtbClassSubject = objClassSubject.SearchSubject_Graduation1(Convert.ToInt64(drw[SIM_Student.C_StudentID]));                        
                        if (dtbClassSubject.Rows.Count == 0)
                        {
                            MessageManager.Warning("Sinh viên này chưa có điểm môn tốt nghiệp!");
                            //return;
                        }
                        for(int j = 0; j < dtbClassSubject.Rows.Count; j++)
                        {
                            frm.SetParameter("pSubjectName" + (j+1).ToString(), dtbClassSubject.Rows[j]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark" + (j+1).ToString(), dtbClassSubject.Rows[j]["FinalSummary"].ToString());
                        }
                        
                        // Lấy ds môn tốt nghiệp văn hóa                        
                        DataTable dtbClassSubject_VanHoa = objClassSubject.GetDataTable("SIM_Student_Subject_Graduation_VanHoa","@StudentID",drw[SIM_Student.C_StudentID]);
                        for (int j = 0; j < dtbClassSubject_VanHoa.Rows.Count; j++)
                        {
                            frm.SetParameter("pSubjectName_VanHoa" + (j + 1).ToString(), dtbClassSubject_VanHoa.Rows[j]["SubjectName"].ToString());
                            frm.SetParameter("pSubjectMark_VanHoa" + (j + 1).ToString(), dtbClassSubject_VanHoa.Rows[j]["FinalSummary"].ToString());
                        }                                                

                        frm.Show();
                        if (gvData.GetSelectedRows().Length > 1)
                        {
                            frm.Print();
                            frm.Close();
                        }
                    }
                    else
                    {
                        ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                    }
                }
            }
            catch
            {
                ErrorManager.Error("Dữ liệu chưa hợp lệ để in!");
            }   
        }

        private void mnuItemPrintChungNhanVH_Click(object sender, EventArgs e)
        {
            SIM_Student objStudentMarkSummary = new SIM_Student();
            SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
            foreach (int i in gvData.GetSelectedRows())
            {
                DataRow drw = gvData.GetDataRow(i);
                DataTable dtbStudentMarkSummary = objStudentMarkSummary.GetDataTable("SIM_Student_SearchStudentMarkSummary6", "@StudentID", Convert.ToInt64(drw[SIM_Student.C_StudentID]));// lấy điểm các môn nghề.
                DataTable dtbClassSubject = objClassSubject.SearchSubject_GraduationVH(Convert.ToInt64(drw[SIM_Student.C_StudentID])); // Danh sách cac mon tot nghiệp
                if (dtbStudentMarkSummary != null && dtbStudentMarkSummary.Rows.Count > 0)
                {
                    // print danh sách sinh viên dự thi

                    string strreport = "";
                    switch (Convert.ToInt32(dtbStudentMarkSummary.Rows[0]["RegulationID"]))
                    {
                        case 09: // cao đẳng, tc nghề
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapTNVH_QC09.repx";
                            break;
                        case 40:
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapTNVH_QC14.repx";
                            break;
                        case 46:
                        case 22: // trung cấp chuyên nghiệp
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapTNVH_QC22.repx";
                            break;
                        default:
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemHocTapTNVH_QC14.repx";
                            break;
                    }

                    SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbStudentMarkSummary, strreport, false);
                    DateTime dtmNow = SystemService.SYS_SettingService.CurrentDateTime;
                    frm.SetParameter("pPrint", SystemService.SYS_SettingService.GetStringValue("Report_Place")
                    + ", ngày " + dtmNow.Day.ToString()
                    + " tháng " + dtmNow.Month.ToString()
                    + " năm " + dtmNow.Year.ToString());
                    // các môn van hóa theo nhóm lớp 10,11,12
                    for (int j = 0; j < dtbStudentMarkSummary.Rows.Count; j++)
                    {
                        if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "T10")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkT10", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "T11")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkT11", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "T12")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkT12", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "V10")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkV10", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "V11")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkV11", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "V12")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkV12", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "L10")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkL10", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "L11")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkL11", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "L12")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkL12", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "H10")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkH10", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "H11")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkH11", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }
                        else if (dtbStudentMarkSummary.Rows[j]["SetType"].ToString() == "H12")
                        {
                            if (dtbStudentMarkSummary.Rows[j]["FinalSummary"].ToString() != "")
                                frm.SetParameter("pSubjectMarkH12", Convert.ToDecimal(dtbStudentMarkSummary.Rows[j]["FinalSummary"]));
                        }

                    }
                    // Truyen thong tin các môn tốt nghiệp
                    if (dtbClassSubject.Rows.Count > 0)
                    {
                        for (int k = 0; k < dtbClassSubject.Rows.Count; k++)
                        {

                            if (dtbClassSubject.Rows[k]["SetType"].ToString() == "TNT")
                            {
                                frm.SetParameter("pSubjectName1", dtbClassSubject.Rows[k]["SubjectName"].ToString());
                                if (dtbClassSubject.Rows[k]["FinalSummary"].ToString() != "")
                                    frm.SetParameter("pSubjectMark1", Convert.ToDecimal(dtbClassSubject.Rows[k]["FinalSummary"]));
                            }
                            else if (dtbClassSubject.Rows[k]["SetType"].ToString() == "TNV")
                            {
                                frm.SetParameter("pSubjectName2", dtbClassSubject.Rows[k]["SubjectName"].ToString());
                                if (dtbClassSubject.Rows[k]["FinalSummary"].ToString() != "")
                                    frm.SetParameter("pSubjectMark2", Convert.ToDecimal(dtbClassSubject.Rows[k]["FinalSummary"]));
                            }
                            else if (dtbClassSubject.Rows[k]["SetType"].ToString() == "TNL")
                            {
                                frm.SetParameter("pSubjectName3", dtbClassSubject.Rows[2]["SubjectName"].ToString());
                                if (dtbClassSubject.Rows[k]["FinalSummary"].ToString() != "")
                                    frm.SetParameter("pSubjectMark3", Convert.ToDecimal(dtbClassSubject.Rows[k]["FinalSummary"]));
                            }
                            else if (dtbClassSubject.Rows[k]["SetType"].ToString() == "TNH")
                            {
                                frm.SetParameter("pSubjectName4", dtbClassSubject.Rows[3]["SubjectName"].ToString());
                                if (dtbClassSubject.Rows[k]["FinalSummary"].ToString() != "")
                                    frm.SetParameter("pSubjectMark4", Convert.ToDecimal(dtbClassSubject.Rows[k]["FinalSummary"].ToString()));
                            }
                        }
                    }
                    else
                    {
                        return;
                    }

                    frm.Show();
                    if (gvData.GetSelectedRows().Length > 1)
                    {
                        frm.Print();
                        frm.Close();
                    }
                }
                else if (dtbStudentMarkSummary.Rows.Count == 0)
                {
                    ErrorManager.Error("Sinh viên này chưa có điểm!");
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                }
            }
        }

        private void mnuPopupGrid_Opening(object sender, CancelEventArgs e)
        {

        }
    }


}
