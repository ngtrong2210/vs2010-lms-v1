using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Collections;
using DevExpress.XtraGrid.Views.BandedGrid;
using Xls = Microsoft.Office.Interop.Excel;
using Libs;
using Global;
using DCore;
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;
using SystemService;

namespace StudentManager.Learning
{
    public partial class frmImportSubjectMark : FormBase, IForm
    {
        #region Consts
                
        public const string PERMISSION_VIEW = "SYS_ImportSubjectMark_View";

        #endregion

        #region Variable


        private string strFileName = "";
        DataTable dtbData;
        DataTable dtbClassSubject;
        DataTable dtbSubjectMark;
        bool bolIsFirstSearch = true;
        int intYearID;
        int? intSemester = null;

        private string strReport_Header = "";
        private string strReport_Place = "";        

        // đếm sinh viên theo thứ tự Xs, G, K, TB k, TB, yeu kem
        private int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0 };

        #endregion

        #region IForm Members

        private static frmImportSubjectMark _instance = null;

        public static frmImportSubjectMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmImportSubjectMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmImportSubjectMark()
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

                SIM_SubjectMark objSubjectMark = new SIM_SubjectMark();
                SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
                SIM_Student objStudent = new SIM_Student();

                string strListGraduationSpecialType = "," + Global.SubjectSpecialType.TotNghiepVanHoa.ToString()
                    + "," + Global.SubjectSpecialType.ChinhTriTotNghiep.ToString()
                    + "," + Global.SubjectSpecialType.TotNghiepLT.ToString()
                    + "," + Global.SubjectSpecialType.TotNghiepTH.ToString() + ",";


                if (uClass.RegulationID.Value == 43) // lấy sổ điểm và môn học lớp theo tín chỉ
                {                    
                    dtbSubjectMark = objSubjectMark.SearchOfClass43("@ClassID", uClass.ClassIDEditValue,
                                                                "@YearID", uYearSemester.YearIDEditValue,
                                                                "@Semester", uYearSemester.SemesterEditValue,
                                                                "@OrderLearning", null); // sổ điểm với những môn mà sv lớp này đang học ở kì này (lần thi null nghĩa là lấy hết)


                    dtbClassSubject = objSubjectMark.GetListSubject43("@ClassID", uClass.ClassIDEditValue,
                                                            "@YearID", uYearSemester.YearIDEditValue,
                                                            "@Semester", uYearSemester.SemesterEditValue,
                                                            "@NotListSpecialType",strListGraduationSpecialType); // môn mà sv lớp này có đăng ký học ở kì này
                }
                else
                {                    
                    dtbSubjectMark = objSubjectMark.SearchFinal("@ClassID", uClass.ClassIDEditValue); // lấy điểm lần học đầu tiên thôi                    
                    dtbClassSubject = objClassSubject.SearchSimpleList("@ClassID", uClass.ClassIDEditValue,
                                                            "@YearID", uYearSemester.YearIDEditValue,
                                                            "@Semester", uYearSemester.SemesterEditValue,
                                                            "@NotListSpecialType", strListGraduationSpecialType,
                                                            "@IsLocked",0); // khoá rùi thì ko import
                }
                
                dtbData = objStudent.SearchSimpleList("@ClassID", uClass.ClassIDEditValue);                

                if (dtbData != null && dtbClassSubject != null)
                {
                    RepairGrid(); // khởi tạo cột cơ bản
                    RepairDataAndGrid(); // khởi tạo môn học vào data và lưới
                    FillData(); // điền điểm vào

                    gcData.DataSource = dtbData;

                    // set order
                    gvData.SetOrder("Order");
                    ModifyGrid();

                    gvData.BestFitColumns();
                    chkShowColumn_CheckedChanged(null, null);


                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                    btnImportFromExcel.Enabled = mnuItemImportFromExcel.Enabled = dtbData.Rows.Count > 0;                    

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
            BandedGridColumn gcolOrder = new BandedGridColumn();
            BandedGridColumn gcolStudentCode = new BandedGridColumn();
            BandedGridColumn gcolStudentFirstName = new BandedGridColumn();
            BandedGridColumn gcolStudentLastName = new BandedGridColumn();

            

            gvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            gbStudent});
            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            gcolOrder,
            gcolStudentCode,
            gcolStudentFirstName,
            gcolStudentLastName});
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
            
            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            
        }

        private void RepairDataAndGrid()
        {
            int intRegulationID = uClass.RegulationID.Value;

            GridBand gbSemester1 = null;
            GridBand gbSemester2 = null;
            
            foreach (DataRow drw in dtbClassSubject.Rows)
            {
                string strSubjectID = drw["SubjectID"].ToString();
                string strSubjectCaption = drw["SubjectName"].ToString();

                dtbData.Columns.Add("TestAverage_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("Exam1_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("Summary1_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("Exam2_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("Summary2_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("Exam3_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("Summary3_" + strSubjectID, typeof(double));
                dtbData.Columns.Add("FinalSummary_" + strSubjectID, typeof(double));                

                dtbData.Columns.Add("SubjectMarkID_" + strSubjectID, typeof(long)); // mã sổ điểm nếu có, chưa có thì có edit fải tạo mới                

                // add Grid

                #region Add Semester 1 or 2

                // Qua kì mới thì add Band Kì
                if (drw["Semester"].ToString() == "1")
                {
                    if (gbSemester1 == null)
                    {
                        gbSemester1 = new GridBand();
                        gbSemester1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                        gbSemester1.AppearanceHeader.Options.UseFont = true;
                        gbSemester1.AppearanceHeader.Options.UseTextOptions = true;
                        gbSemester1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gbSemester1.Caption = "HỌC KỲ " + drw["Semester"].ToString();
                        gbSemester1.Name = "gbSemester" + drw["Semester"].ToString();

                        // add vao Grid
                        gvData.Bands.Add(gbSemester1);
                    }
                }
                else
                {
                    // Qua kì mới thì add Band Kì              
                    if (gbSemester2 == null)
                    {
                        gbSemester2 = new GridBand();
                        gbSemester2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                        gbSemester2.AppearanceHeader.Options.UseFont = true;
                        gbSemester2.AppearanceHeader.Options.UseTextOptions = true;
                        gbSemester2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gbSemester2.Caption = "HỌC KỲ " + drw["Semester"].ToString();
                        gbSemester2.Name = "gbSemester" + drw["Semester"].ToString();

                        // add vao Grid
                        gvData.Bands.Add(gbSemester2);
                    }
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

                GridBand gbSubjectID1 = new GridBand();
                gbSubjectID1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID1.AppearanceHeader.Options.UseFont = true;
                gbSubjectID1.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID1.Caption = strSubjectID;
                gbSubjectID1.Name = "gbSubjectID1" + strSubjectID;
                GridBand gbSubjectID2 = new GridBand();
                gbSubjectID2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID2.AppearanceHeader.Options.UseFont = true;
                gbSubjectID2.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID2.Caption = strSubjectID;
                gbSubjectID2.Name = "gbSubjectID2" + strSubjectID;
                GridBand gbSubjectID3 = new GridBand();
                gbSubjectID3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID3.AppearanceHeader.Options.UseFont = true;
                gbSubjectID3.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID3.Caption = strSubjectID;
                gbSubjectID3.Name = "gbSubjectID3" + strSubjectID;
                GridBand gbSubjectID4 = new GridBand();
                gbSubjectID4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID4.AppearanceHeader.Options.UseFont = true;
                gbSubjectID4.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID4.Caption = strSubjectID;
                gbSubjectID4.Name = "gbSubjectID4" + strSubjectID;
                GridBand gbSubjectID5 = new GridBand();
                gbSubjectID5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID5.AppearanceHeader.Options.UseFont = true;
                gbSubjectID5.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID5.Caption = strSubjectID;
                gbSubjectID5.Name = "gbSubjectID5" + strSubjectID;
                GridBand gbSubjectID6 = new GridBand();
                gbSubjectID6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID6.AppearanceHeader.Options.UseFont = true;
                gbSubjectID6.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID6.Caption = strSubjectID;
                gbSubjectID6.Name = "gbSubjectID6" + strSubjectID;
                GridBand gbSubjectID7 = new GridBand();
                gbSubjectID7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbSubjectID7.AppearanceHeader.Options.UseFont = true;
                gbSubjectID7.AppearanceHeader.Options.UseTextOptions = true;
                gbSubjectID7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbSubjectID7.Caption = strSubjectID;
                gbSubjectID7.Name = "gbSubjectID7" + strSubjectID; 

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
                gcolTestAverage.FieldName = "TestAverage_" + strSubjectID;
                gcolTestAverage.Name = "gcolTestAverage_" + strSubjectID;
                gcolTestAverage.Visible = true;
                gcolTestAverage.AppearanceCell.BackColor = Color.LightBlue;
                gcolTestAverage.AppearanceCell.Options.UseBackColor = true;
                // 
                // gcolExam1_
                // 
                BandedGridColumn gcolExam1 = new BandedGridColumn();
                gcolExam1.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam1.Caption = "Thi1";
                gcolExam1.FieldName = "Exam1_" + strSubjectID;
                gcolExam1.Name = "gcolExam1_" + strSubjectID;
                gcolExam1.Visible = true;
                // 
                // gcolSummary1_
                // 
                BandedGridColumn gcolSummary1 = new BandedGridColumn();
                gcolSummary1.AppearanceHeader.Options.UseTextOptions = true;
                gcolSummary1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary1.Caption = "TKM1";
                gcolSummary1.FieldName = "Summary1_" + strSubjectID;
                gcolSummary1.Name = "gcolSummary1_" + strSubjectID;
                gcolSummary1.Visible = true;
                // 
                // gcolExam2_
                // 
                BandedGridColumn gcolExam2 = new BandedGridColumn();
                gcolExam2.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam2.Caption = "Thi2";
                gcolExam2.FieldName = "Exam2_" + strSubjectID;
                gcolExam2.Name = "gcolExam2_" + strSubjectID;
                gcolExam2.Visible = true;
                // 
                // gcolSummary2_
                // 
                BandedGridColumn gcolSummary2 = new BandedGridColumn();
                gcolSummary2.AppearanceHeader.Options.UseTextOptions = true;
                gcolSummary2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary2.Caption = "TKM2";
                gcolSummary2.FieldName = "Summary2_" + strSubjectID;
                gcolSummary2.Name = "gcolSummary2_" + strSubjectID;
                gcolSummary2.Visible = true;
                // 
                // gcolExam3_
                // 
                BandedGridColumn gcolExam3 = new BandedGridColumn();
                gcolExam3.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam3.Caption = "Thi3";
                gcolExam3.FieldName = "Exam3_" + strSubjectID;
                gcolExam3.Name = "gcolExam3_" + strSubjectID;
                gcolExam3.Visible = true;
                

                // 
                // gcolSummary3_
                // 
                BandedGridColumn gcolSummary3 = new BandedGridColumn();
                gcolSummary3.AppearanceHeader.Options.UseTextOptions = true;
                gcolSummary3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary3.Caption = "TKM3";
                gcolSummary3.FieldName = "Summary3_" + strSubjectID;
                gcolSummary3.Name = "gcolSummary3_" + strSubjectID;
                gcolSummary3.Visible = true;                


                // add column vao grid
                gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
                                            gcolTestAverage,
                                            gcolExam1,
                                            gcolSummary1,
                                            gcolExam2,
                                            gcolSummary2,
                                            gcolExam3,
                                            gcolSummary3});

                // add cot vao band subject
                gbSubjectID1.Columns.Add(gcolTestAverage);
                gbSubjectID2.Columns.Add(gcolExam1);
                gbSubjectID3.Columns.Add(gcolSummary1);
                gbSubjectID4.Columns.Add(gcolExam2);
                gbSubjectID5.Columns.Add(gcolSummary2);
                gbSubjectID6.Columns.Add(gcolExam3);
                gbSubjectID7.Columns.Add(gcolSummary3);


                //add Subject band vao Semester band
                // Qua kì mới thì add Band Kì
                if (drw["Semester"].ToString() == "1")
                    gbSemester1.Children.Add(gbSubject);
                else
                    gbSemester2.Children.Add(gbSubject);

                gbSubject.Children.Add(gbSubjectID1);
                gbSubject.Children.Add(gbSubjectID2);
                gbSubject.Children.Add(gbSubjectID3);
                gbSubject.Children.Add(gbSubjectID4);
                gbSubject.Children.Add(gbSubjectID5);
                gbSubject.Children.Add(gbSubjectID6);
                gbSubject.Children.Add(gbSubjectID7);

                #endregion
            }
        }

        private void FillData()
        {
            foreach (DataRow drw in dtbData.Rows)
            {         
                DataRow[] rows = dtbSubjectMark.Select("StudentID='" + drw["StudentID"].ToString() + "'");
                foreach (DataRow drw2 in rows) // mỗi môn chỉ xuất hiện 1 lần vì nó đã lấy lần cuối cùng trong bảng điểm
                {
                    string strSubjectID = drw2["SubjectID"].ToString();
                    if (dtbClassSubject.Select("SubjectID='" + strSubjectID + "'").Length > 0)
                    {                        

                        drw["TestAverage_" + strSubjectID] = drw2["TestAverage"];
                        drw["Exam1_" + strSubjectID] = drw2["Exam1"];
                        drw["Summary1_" + strSubjectID] = drw2["Summary1"];

                        drw["Exam2_" + strSubjectID] = drw2["Exam2"];
                        drw["Summary2_" + strSubjectID] = drw2["Summary2"];

                        drw["Exam3_" + strSubjectID] = drw2["Exam3"];
                        drw["Summary3_" + strSubjectID] = drw2["Summary3"];

                        drw["SubjectMarkID_" + strSubjectID] = drw2["SubjectMarkID"];
                    }
                }
            }
        }

        /// <summary>
        /// Cập nhật tổng kết điểm học tập. Vừa thêm, vừa cập nhật nếu cả có
        /// </summary>
        /// <returns></returns>
        private void SaveData()
        {
            SIM_SubjectMark itemBegin = new SIM_SubjectMark();
            itemBegin.BeginTransaction();            

            //quét lưới sinh viên
            int intRowCount = dtbData.Rows.Count;            
            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = gvData.GetDataRow(i);                

                // quét ds cột trên lưới
                foreach (DataRow drw2 in dtbClassSubject.Rows)
                {
                    string strSubjectID = drw2["SubjectID"].ToString();
                                        
                    SIM_SubjectMark item = new SIM_SubjectMark();
                    item.IDB = itemBegin.IDB;
                    item.StudentID = Convert.ToInt32(drw["StudentID"]);
                    item.UpdatedUser = UserSession.Username;
                    item.SubjectID = strSubjectID;
                    item.ClassSubjectID = Convert.ToInt32(drw2["ClassSubjectID"]);

                    if (drw["SubjectMarkID_"+strSubjectID].ToString() != "")
                        item.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID_" + strSubjectID]);

                    if (drw["TestAverage_" + strSubjectID].ToString() != "")                    
                        item.TestAverage = Convert.ToDouble(drw["TestAverage_" + strSubjectID]);

                    if (drw["Exam1_" + strSubjectID].ToString() != "")
                        item.Exam1 = Convert.ToDouble(drw["Exam1_" + strSubjectID]);
                    if (drw["Exam2_" + strSubjectID].ToString() != "")
                        item.Exam2 = Convert.ToDouble(drw["Exam2_" + strSubjectID]);
                    if (drw["Exam3_" + strSubjectID].ToString() != "")
                        item.Exam3 = Convert.ToDouble(drw["Exam3_" + strSubjectID]);

                    if (drw["Summary1_" + strSubjectID].ToString() != "")
                        item.Summary1 = Convert.ToDouble(drw["Summary1_" + strSubjectID]);
                    if (drw["Summary2_" + strSubjectID].ToString() != "")
                        item.Summary2 = Convert.ToDouble(drw["Summary2_" + strSubjectID]);
                    if (drw["Summary3_" + strSubjectID].ToString() != "")
                        item.Summary3 = Convert.ToDouble(drw["Summary3_" + strSubjectID]);
                   
                    if (!item.Import())
                    {
                        ErrorManager.Error("Việc import điểm bị lỗi!");
                        return;
                    }
                    drw["SubjectMarkID_" + strSubjectID] = item.SubjectMarkID; // gán lại mã nếu insert thành công
                }

                progressBar.Position = Convert.ToInt32(Convert.ToDouble(i) / intRowCount * 100);
            }

            itemBegin.CommitTransaction();

            btnSave.Enabled = mnuItemSave.Enabled = false;
            MessageManager.Info("Đã cập nhật thành công!");
        }
        
        private void ModifyGrid()
        {
        }

        public int FillDataFromExcel(string columnCaptionForSearch, string ignoreCaptions, string strFileName)
        {
            columnCaptionForSearch = columnCaptionForSearch.ToUpper();
            ignoreCaptions = ignoreCaptions.ToUpper();


            string strValue = ""; // giá trị của ô
            string strFieldNameForSearch = ""; // cột này làm khoá để search

            // OPEN FILE                
            ExcelObject objExcel;
            objExcel = new Libs.ExcelObject(strFileName);

            Xls.Range range = objExcel.WorkSheet.get_Range("A1", "FF500"); // tạm thời cho tối đa khoản này thoi
            System.Array myValues = range.Cells.get_Value(System.Reflection.Missing.Value) as System.Array;
            objExcel.Close(false);


            // tìm dòng tiêu đề chuẩn trong table dựa vào cột làm chuẩn
            #region  Tìm dòng trong excel chứa Tiêu đề làm chuẩn

            int i = 0, j = 0;
            for (i = 1; i < 10; i++)
            {
                for (j = 1; j < 10; j++)
                {
                    if (myValues.GetValue(i, j) != null)
                    {
                        strValue = myValues.GetValue(i, j).ToString().ToUpper();
                        if (strValue == columnCaptionForSearch)
                            break;
                    }
                }

                if (strValue == columnCaptionForSearch)
                    break;
            }

            if (i == 10)
                return -1; // không tìm thấy giá trị cột chuẩn

            #endregion

            // dựa vào dòng chuẩn thứ i tìm được, tìm bảng máp cột lưới và cột excel để quét
            #region  Tìm bảng map giữa cột ở lưới và cột ở excel

            Hashtable hstColumnMap = new Hashtable();
            j = 1; // tìm lại từ đầu                    
            while (true)
            {
                if (myValues.GetValue(i, j) == null)
                    break;
                strValue = myValues.GetValue(i, j).ToString().ToUpper();

                // nếu cột đó hông thuộc danh sách loại trừ
                if (!ignoreCaptions.Contains("," + strValue + ","))
                {
                    foreach (BandedGridColumn gcol in gvData.Columns)
                    {
                        if (strValue == gcol.Caption.ToUpper() && !hstColumnMap.ContainsKey(gcol.FieldName))// cùng tiêu đề cột
                        {
                            // nếu là cột mã thì add thẳng luôn
                            // nhớ lại fieldName tương ứng trên lưới có caption truyền vào
                            if (strValue == columnCaptionForSearch)
                            {
                                strFieldNameForSearch = gcol.FieldName;
                                hstColumnMap.Add(gcol.FieldName, j);
                                break;
                            }
                            else
                            {
                                // Kiểm tra tiếp cùng mã môn mới chọn 
                                object objSubjectID = myValues.GetValue(i - 1, j);
                                if (objSubjectID != null && gcol.OwnerBand.Caption.Contains(objSubjectID.ToString())) // cùng mã môn
                                {
                                    hstColumnMap.Add(gcol.FieldName, j);
                                    break;
                                }
                            }


                        }
                    }
                }
                j++;
            }
            if (hstColumnMap.Count == 0)
                return 0;

            #endregion

            #region Quyét dữ liệu đưa vào lưới

            i++; // bỏ qua dòng tiêu đề
            int intDoneCount = 0;
            while (true)
            {
                object objKeyValue = myValues.GetValue(i, Convert.ToInt32(hstColumnMap[strFieldNameForSearch]));
                if (objKeyValue == null || objKeyValue.ToString().Trim() == "")
                    break;

                // tìm dòng trong lưới
                int intRowIndex = gvData.SearchRow(strFieldNameForSearch, objKeyValue);
                if (intRowIndex >= 0)
                {
                    // quét cột để đổ vào
                    foreach (string strKey in hstColumnMap.Keys)
                    {
                        // nếu có cột tương ứng thì gán giá trị vào
                        if (strKey != strFieldNameForSearch)
                        {
                            object objValue = myValues.GetValue(i, Convert.ToInt32(hstColumnMap[strKey]));
                            DataRow drw = gvData.GetDataRow(intRowIndex);

                            if (objValue != null)
                            {
                                drw[strKey] = objValue;
                            }
                            else
                            {
                                drw[strKey] = DBNull.Value;
                            }
                        }
                    }
                    intDoneCount++;
                }

                i++; // tăng dòng trong excel
            }

            #endregion

            progressBar.Position = 100;
            btnSave.Enabled = mnuItemSave.Enabled = true;
            if (intDoneCount > 0)
                MessageBox.Show("Đã nhập dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return intDoneCount;
        }

        private void ImportFromExcel()
        {
            progressBar.Position = 0;
            FillDataFromExcel("Mã SV", ",Họ đệm,Tên,Ngày sinh,", strFileName);
            
        }
        
        #endregion

        #region Form Actions

        private void frmMakeStudentCode_Load(object sender, EventArgs e)
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true; // lệnh này để Thread không bị warning            
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
                    if (drw[e.Column.FieldName.Replace("FinalSummary_", "OrderLearning_")] != DBNull.Value)
                    {
                        int intOrderLearning = Convert.ToInt32(drw[e.Column.FieldName.Replace("FinalSummary_", "OrderLearning_")]);
                        if (intOrderLearning == 2)
                            e.Appearance.BackColor = Color.Yellow;
                        else if (intOrderLearning > 2)
                            e.Appearance.BackColor = Color.OrangeRed;
                    }
                }
            }          
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            //SaveData();
            progressBar.Position = 0;
            new Thread(SaveData).Start();
           
        }
             
        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        
        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void btnImportFromExcel_Click(object sender, EventArgs e)
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Excel(*.xls)| *.xls";
            if (dlg.ShowDialog() != DialogResult.Cancel)
            {
                // OPEN FILE
                strFileName = dlg.FileName;
                if (strFileName != null && strFileName != "")
                {
                    //ImportFromExcel();
                    new Thread(ImportFromExcel).Start();
                }
            }
        }

        private void chkShowColumn_CheckedChanged(object sender, EventArgs e)
        {
            foreach (BandedGridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("TestAverage_"))
                {
                    col.OwnerBand.Visible  = col.Visible = chkShowTestAverage.Checked;
                    
                }
                else if (col.FieldName.Contains("Exam"))
                {
                    col.OwnerBand.Visible = col.Visible = chkShowExam.Checked;
                }
                else if (col.FieldName.Contains("Summary1_"))
                {
                    col.OwnerBand.Visible = col.Visible = chkShowSummary1.Checked;
                }
                else if (col.FieldName.Contains("Summary2_"))
                {
                    col.OwnerBand.Visible = col.Visible = chkShowSummary2.Checked;
                }

            }
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                if (e.Value != null)
                {
                    if (e.Value.ToString() == "")
                        e.Value = DBNull.Value;
                    else
                    {

                        double a = 0;
                        if (double.TryParse(e.Value.ToString(), out a))
                            if (a > 10 || a < 0)
                            {
                                e.ErrorText = "Điểm số không hợp lệ!";
                                e.Valid = false;
                            }
                    }
                }
            }
        }
    }
}