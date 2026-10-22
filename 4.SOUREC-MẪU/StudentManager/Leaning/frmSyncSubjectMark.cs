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
using System.Collections;


namespace StudentManager.Learning
{
    public partial class frmSyncSubjectMark : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SYS_SubjectMark_Sync";
        
        #endregion

        #region Variables

        private string strTemplageConnection = "Data Source={0};Initial Catalog={3};Persist Security Info=True;User ID={1};Password={2};";
        private string strFileConfig = "config-old-data.txt";

        DataTable dtbData;
        DataTable dtbClassSubject;
        SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
        bool bolIsGraduationSubject = true;                


        string strOldConn = "";
        DataTable dtbOldData;

        #endregion

        #region IForm Members

        private static frmSyncSubjectMark _instance = null;

        public static frmSyncSubjectMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSyncSubjectMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSyncSubjectMark()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            //gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
            //uClass.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_EDIT); // quyền xem trên khoa nào            
            //string str = UserSession.GetSubjectGroupFilter(PERMISSION_VIEW);
            //if (str != "")
            //    str = "( " + str + " ) Or TeachingBy ='" + UserSession.Username + "'";

            //lookupClassSubjectID.RowFilter = str; // quyền xem trên bộ môn nào
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
            }
        }

        private bool IsValidData()
        {            
            if (!uClass.IsValidData())
                return false;
            if (lookupOldClassSubjectID.EditValue == null)
            {
                lookupOldClassSubjectID.Focus();
                MessageManager.Warning("Bạn phải chọn môn học cũ!");
                return false;
            }
            if (lookupClassSubjectID.EditValue == null)
            {
                lookupClassSubjectID.Focus();
                MessageManager.Warning("Bạn phải chọn môn học mới!");
                return false;
            }
            return true;
        }

        public void LoadOldData()
        {            
            // lấy classsubject info

            // môn cũ
            try
            {
                DCore.IData objIData = DCore.Data.CreateData(strOldConn);
                objIData.Connect();
                string strSQL = "select 0 as \"Order\", convert(bit,1) IsSelected, DiemTN.SinhVien,SinhVien.Ma as MaSinhVien,SinhVien.Hodem, SinhVien.Ten, DL1, DL2, DL3 FROM DiemTN, SinhVien " +
                    " Where DiemTN.SinhVien = SinhVien.SinhVien " +
                    " and  DiemTN.montn = " + lookupOldClassSubjectID.EditValueString;

                dtbOldData = objIData.ExecQueryToDataTable(strSQL);

                foreach (DataRow drw in dtbOldData.Rows)
                {
                    drw["MaSinhVien"] = Libs.MyConvert.ConvertVNIToUnicode(drw["MaSinhVien"]);
                    drw["Hodem"] = Libs.MyConvert.ConvertVNIToUnicode(drw["Hodem"]);
                    drw["Ten"] = Libs.MyConvert.ConvertVNIToUnicode(drw["Ten"]);
                }

                gcOldData.DataSource = dtbOldData;
                gvOldData.SetOrder("Order");

                objIData.Disconnect();
            }
            catch
            {
                ErrorManager.Error("Không thể tải điểm môn học cũ");
            }
                       
        }

        public void LoadData()
        {
            // gán cột vào lưới.                
            RepairGrid();

            // lấy classsubject info
            objClassSubject = new SIM_Class_Subject();
            objClassSubject.ClassSubjectID = lookupClassSubjectID.EditValueInt64;

            if (!objClassSubject.Get())
            {
                ErrorManager.Error("Việc lấy thông tin môn học bị lỗi!");
                return;
            }

            SIM_SubjectMark obj = new SIM_SubjectMark();
            dtbData = obj.SearchForEdit("@ClassID", uClass.IsRegulation43 ? null : uClass.ClassIDEditValue,
                                        "@ClassSubjectID", lookupClassSubjectID.EditValue,
                                        "@IsGraduationSubject", bolIsGraduationSubject,
                                        "@SubjectID", objClassSubject.SubjectID);
            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                // set order
                gvData.SetOrder("Order");
                ModifyGrid();

                gvData.BestFitColumns();
                btnSave.Enabled = true; // chưa sửa thì không có save nếu đã từng save                        
            }
            else
            {
                //ErrorManager.Error(obj.ErrorException);
                ErrorManager.Error("Việc lấy thông tin sổ điểm bị lỗi!");

            }
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {            
            SIM_SubjectMark item = new SIM_SubjectMark();
            item.BeginTransaction();

            for (int i = 0; i < dtbOldData.Rows.Count; i++)
            {
                DataRow drw = dtbOldData.Rows[i];
                if (Convert.ToBoolean(drw["IsSelected"])) // nếu có chọn
                {
                    DataRow[] rows = dtbData.Select("StudentCode = '" + drw["MaSinhVien"].ToString() + "'");
                    if (rows.Length > 0)
                    {
                        // gan diem cu vao
                        rows[0]["Exam1"] = drw["DL1"];
                        rows[0]["Exam2"] = drw["DL2"];
                        rows[0]["Exam3"] = drw["DL3"];




                        SIM_SubjectMark item2 = new SIM_SubjectMark(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                        item2.IDB = item.IDB;
                        if (item2.Parse(rows[0]))
                        {
                            // gán lại điểm dựa vào lưới cũ                            
                            item2.HaveExamRegister = false; // bỏ đánh dấu đăng ký dự thi tốt nghiệp khi update điểm thi                        
                            if (item2.SubjectMarkID == null)// thêm mới
                            {
                                item2.CreatedUser = UserSession.Username;
                                item2.ClassSubjectID = lookupClassSubjectID.EditValueInt64;
                                item2.SubjectID = objClassSubject.SubjectID;
                                item2.OrderLearning = 1; // mặc định 1 nếu là thêm mới cho sinh viên chính lớp đó


                                if (!item2.Add())
                                {
                                    ErrorManager.Error("Việc thêm sổ điểm bị lỗi!");
                                    return false;
                                }
                            }
                            else
                            {
                                item2.UpdatedUser = UserSession.Username;
                                if (!item2.Update())
                                {
                                    ErrorManager.Error("Việc cập nhật sổ điểm bị lỗi!");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            ErrorManager.Error("Việc chuyển dữ liệu từ lưới để lưu bị lỗi!");
                            item.RollBackTransaction();// Parse hong co dung tới db nên nó hông có rollback
                            return false;
                        }
                    }
                }
            }

            item.CommitTransaction();
            string strActionLog = "Môn học: " + lookupClassSubjectID.Text + "\r\n" +
                                  "Lớp học: " + uClass.ClassName + "\r\n";
            new SystemObject.SYS_ActionLog().WriteActionLog("Cập nhật sổ điểm từ điểm cũ", strActionLog, SystemObject.ActionLogType.EDIT, 1, UserSession.Username);
            return true;
        }

        private void LoadSubjectSearch()
        {
            if (uClass.IsRegulation43)
            {
                lookupClassSubjectID.Caption = "Lớp học phần:";
                if (uClass.SpecialBranchSubjectIDEditValue != null)
                {
                    SIM_Class_Subject obj = new SIM_Class_Subject();
                    dtbClassSubject = obj.SearchList43("@SpecialBranchSubjectID", uClass.SpecialBranchSubjectIDEditValue);

                    DataRow drw = dtbClassSubject.NewRow();
                    dtbClassSubject.Rows.InsertAt(drw, 0); // thêm dòng trống  
                    lookupClassSubjectID.InitData(dtbClassSubject, "--Chọn--", "ClassSubjectID", "ClassName",
                        "ClassName", "Tên nhóm", "ClassShortName", "Tên viết tắt", "GroupSmallClass", "Thứ tự nhóm", "UnitText", "ĐVHT", "TheoryQuantity", "LT", "PracticeQuantity", "TH");
                }
                else
                    lookupClassSubjectID.DataSource = null;
            }
            else
            {
                lookupClassSubjectID.Caption = "Môn học:";
                if (uClass.ClassIDEditValue == null)
                {
                    if (dtbClassSubject != null)
                        dtbClassSubject.Clear();
                }
                else
                {
                    dtbClassSubject = objClassSubject.SearchSubject_Graduation("@ClassID", uClass.ClassIDEditValue);

                    DataRow drw = dtbClassSubject.NewRow();
                    dtbClassSubject.Rows.InsertAt(drw, 0); // thêm dòng trống
                    lookupClassSubjectID.InitData(dtbClassSubject, "--Chọn--", "ClassSubjectID", "SubjectName", "SubjectID", "Mã môn", "SubjectName", "Tên môn");

                    // môn cũ
                    try
                    {
                        DCore.IData objIData = DCore.Data.CreateData(strOldConn);
                        objIData.Connect();
                        string strSQL = "Select montn as MHLop , MonHoc.MonHoc, MonHoc.Ten,LopHoc.Ma From MonTN, MonHoc,LopHoc Where MonTN.MonHoc = MonHoc.MonHoc and MonTN.LopHoc = LopHoc.LopHoc " +
                            " and LopHoc.Ma = N'" + uClass.ClassIDEditValue + "'";
                        
                        DataTable dtbOldClassSubject = objIData.ExecQueryToDataTable(strSQL);
                       
                        foreach (DataRow r in dtbOldClassSubject.Rows)
                            r["Ten"] = Libs.MyConvert.ConvertVNIToUnicode(r["Ten"]);

                        lookupOldClassSubjectID.InitData(dtbOldClassSubject, "--Chọn--", "MHLop", "Ten", "MonHoc", "Mã môn", "Ten", "Tên môn");
                        objIData.Disconnect();
                    }
                    catch
                    {
                        ErrorManager.Error("Không thể tải môn học cũ");
                    }
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


            // Thêm Student Band
            GridBand gbStudent = new GridBand();
            gbStudent.Caption = "SINH VIÊN";
            gbStudent.AppearanceHeader.Options.UseFont = true;
            gbStudent.AppearanceHeader.Options.UseTextOptions = true;
            gbStudent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbStudent.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbStudent.Name = "gbStudent";
            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;


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

            // gcolStudentCode
            BandedGridColumn gcolStudentCode = new BandedGridColumn();
            gcolStudentCode.Caption = "Mã SV";
            gcolStudentCode.FieldName = "StudentCode";
            gcolStudentCode.Name = "gcolStudentCode";
            //gcolStudentCode.Width = 60;
            gcolStudentCode.Visible = true;
            gcolStudentCode.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


            // gcolStudentFirstName
            BandedGridColumn gcolStudentFirstName = new BandedGridColumn();
            gcolStudentFirstName.Caption = "Họ đệm";
            gcolStudentFirstName.FieldName = "StudentFirstName";
            gcolStudentFirstName.Name = "gcolStudentFirstName";
            //gcolStudentFirstName.Width = 140;
            gcolStudentFirstName.Visible = true;
            gcolStudentFirstName.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentFirstName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // gcolStudentLastName
            BandedGridColumn gcolStudentLastName = new BandedGridColumn();
            gcolStudentLastName.Caption = "Tên";
            gcolStudentLastName.FieldName = "StudentLastName";
            gcolStudentLastName.Name = "gcolStudentLastName";
            //gcolStudentFirstName.Width = 140;
            gcolStudentLastName.Visible = true;
            gcolStudentLastName.AppearanceHeader.Options.UseTextOptions = true;
            gcolStudentLastName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            // gcolBirthday
            BandedGridColumn gcolBirthday = new BandedGridColumn();
            gcolBirthday.Caption = "Ngày sinh";
            gcolBirthday.FieldName = "BirthDateText";
            gcolBirthday.Name = "gcolBirthday";
            //gcolStudentFirstName.Width = 140;
            gcolBirthday.Visible = true;
            gcolBirthday.AppearanceHeader.Options.UseTextOptions = true;
            gcolBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolBirthday.AppearanceCell.Options.UseTextOptions = true;
            gcolBirthday.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

            gvData.Bands.Add(gbStudent);
            gvData.Columns.AddRange(new BandedGridColumn[] { gcolOrder, gcolStudentCode, gcolStudentFirstName, gcolStudentLastName, gcolBirthday });
            gbStudent.Columns.Add(gcolOrder); // add cột vào Band            
            gbStudent.Columns.Add(gcolStudentCode);
            gbStudent.Columns.Add(gcolStudentFirstName);
            gbStudent.Columns.Add(gcolStudentLastName);
            gbStudent.Columns.Add(gcolBirthday);


            if (uClass.RegulationID != 25)
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
                    gvData.Bands.Add(gbMark);

                    int j = 7;                   
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
                        gvData.Columns.Add(gcolMark); // add cột vào lưới
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

            gvData.Bands.Add(gbTestAverage);
            gbTestAverage.Columns.Add(gcolTestAverage); // add cột tuần vào
            gvData.Columns.Add(gcolTestAverage); // add cột vào lưới


            // Thêm THI Band
            GridBand gbExam = new GridBand();
            gbExam.Caption = "KIỂM TRA HẾT MÔN";
            gbExam.AppearanceHeader.Options.UseFont = true;
            gbExam.AppearanceHeader.Options.UseTextOptions = true;
            gbExam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbExam.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbExam.Name = "gbExam";

            gvData.Bands.Add(gbExam);

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
                gvData.Columns.Add(gcolExam); // add cột vào lưới
            }

            // Thêm TKM Band
            GridBand gbSummary = new GridBand();
            gbSummary.Caption = "TKM";
            gbSummary.AppearanceHeader.Options.UseFont = true;
            gbSummary.AppearanceHeader.Options.UseTextOptions = true;
            gbSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSummary.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbSummary.Name = "gbSummary";

            gvData.Bands.Add(gbSummary);

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
                gvData.Columns.Add(gcolSummary); // add cột vào lưới
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

            gvData.Bands.Add(gbOrderLearning);
            gbOrderLearning.Columns.Add(gcolOrderLearning); // add cột tuần vào
            gvData.Columns.Add(gcolOrderLearning); // add cột vào lưới


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

            gvData.Bands.Add(gbIsIgnore);
            gbIsIgnore.Columns.Add(gcolIsIgnore); // add cột tuần vào
            gvData.Columns.Add(gcolIsIgnore); // add cột vào lưới


            // chỉ dành cho tín chỉ 43
            if (uClass.IsRegulation43)
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

                // gcolStudentCode
                BandedGridColumn gcolOtherFinalSummary = new BandedGridColumn();
                gcolOtherFinalSummary.Caption = "Đ. Số";
                gcolOtherFinalSummary.FieldName = "OtherFinalSummary";
                gcolOtherFinalSummary.Name = "gcolOtherFinalSummary";
                gcolOtherFinalSummary.Width = 60;
                gcolOtherFinalSummary.Visible = true;
                gcolOtherFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                gcolOtherFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                gvData.Bands.Add(gbSummary43);
                gvData.Columns.AddRange(new BandedGridColumn[] { gcolLearningLevel, gcolOtherFinalSummary });
                gbSummary43.Columns.Add(gcolLearningLevel); // add cột vào Band            
                gbSummary43.Columns.Add(gcolOtherFinalSummary);

            }
        }

        private void ModifyGrid()
        {
            if (bolIsGraduationSubject)
                ModifyGrid_GraduationSubject();

            // Ẩn hết trừ tổng kết môn cho điểm chuyển
            else if (objClassSubject.IsOldData)
            {
                gvData.Bands["gbMark1"].Visible = false; // hệ số 1 bỏ hết
                gvData.Bands["gbMark2"].Visible = false; // hệ số 2 bỏ hết
                gvData.Bands["gbTestAverage"].Visible = false; // TBKT
                gvData.Bands["gbExam"].Visible = false; // Điểm thi
                //gvData.Bands["gbIsIgnore"].Visible = false;
                gvData.Bands["gbOrderLearning"].Visible = false;
            }

            else if (uClass.IsRegulation43)
                ModifyGrid43();
            else
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
                    case 25: // cao đẳng chuyên nghiệp
                        ModifyGrid25();
                        break;
                }
            }

        }

        #region Ẩn cột trên lưới theo từng qui chế

        private void ModifyGrid14()
        {            
            gvData.Bands["gbMark1"].Visible = false; // hệ số 1 bỏ hết                       

            gvData.Columns["Exam3"].Visible = false; // thi lần 3 bỏ
            gvData.Columns["Summary3"].Visible = false; // TKM lần 3 bỏ
            gvData.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";
        }

        private void ModifyGrid40()
        {            
            gvData.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";

        }

        private void ModifyGrid46()
        {            
            gvData.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";
        }

        private void ModifyGrid43()
        {
            // qui ước điểm điểm kiểm tra là từ Mark21-27
            // điểm Nhận thức, Chuyên cần từ Mark11,12,...

            for (int i = 3; i <= 7; i++)
            {
                gvData.Columns["Mark1" + i.ToString()].Visible = false;
                gvData.Columns["Mark2" + i.ToString()].Visible = false;
            }

            gvData.Columns["Mark11"].Caption = "N.T.";
            gvData.Columns["Mark12"].Caption = "C.Cần";

            for (int i = 1; i <= 2; i++)
                gvData.Columns["Mark2" + i.ToString()].Caption = "(" + i.ToString() + ")";

            gvData.Bands["gbMark1"].Caption = "Đ.Q.TRÌNH";
            gvData.Bands["gbMark2"].Caption = "Đ. GIỮA KỲ";
            gvData.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";

        }

        private void ModifyGrid25()
        {
            gvData.Columns["TestAverage"].Caption = "Giữa kỳ ";
            gvData.Bands["gbTestAverage"].Caption = "ĐIỂM GK";
            gvData.Bands["gbExam"].Caption = "ĐIỂM THI";

            gvData.Columns["Exam3"].Visible = false; // thi lần 3 bỏ
            gvData.Columns["Summary3"].Visible = false; // TKM lần 3 bỏ     
        }

        private void ModifyGrid_GraduationSubject()
        {
            gvData.Bands["gbMark1"].Visible = false;
            gvData.Bands["gbMark2"].Visible = false;
            gvData.Bands["gbTestAverage"].Visible = false;
            gvData.Bands["gbSummary"].Visible = false;
            gvData.Bands["gbExam"].Caption = "THI TỐT NGHIỆP";
        }

        #endregion                

        #endregion

        #region Form Actions

        private void frmSyncSubjectMark_Load(object sender, EventArgs e)
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true; // lệnh này để Thread không bị warning            
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();

            try
            {                
                string str = Libs.Files.ReadFile(strFileConfig);
                string strConn = Core.Security.Secure.DecryptRijndael(str, Core.Security.MachineIdentify.MachineID);
                string[] a = strConn.Split(';');
                if (a.Length == 4)
                {
                    txtServerName.Text = a[0];
                    txtLoginName.Text = a[1];
                    txtPassword.Text = a[2];
                    txtDBName.Text = a[3];
                    strOldConn = string.Format(strTemplageConnection, txtServerName.TextTrim, txtLoginName.TextTrim, txtPassword.Text, txtDBName.TextTrim);
                }                
            }
            catch
            {                
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                btnSave.Enabled = btnSearch.Enabled = false;
                LoadData();
                LoadOldData();
                btnSave.Enabled = dtbOldData.Rows.Count > 0 && dtbData.Rows.Count > 0 && !objClassSubject.IsLocked;
                btnSearch.Enabled = true;
                //new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn chuyển điểm của những dòng sinh viên đã chọn?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    LoadData();
                    btnSave.Enabled = false;
                    MessageManager.Info("Chuyển điểm thành công!");
                }
            }
        }               

        #endregion       

        private void chkIsRegulation43_CheckedChanged(object sender, EventArgs e)
        {
            LoadSubjectSearch();
        }

        private void uClass_SpecialBranchSubjectChanged(object sender, EventArgs arg)
        {
            LoadSubjectSearch();
        }

        
        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            LoadSubjectSearch();
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strConn = string.Format(strTemplageConnection, txtServerName.TextTrim, txtLoginName.TextTrim, txtPassword.Text, txtDBName.TextTrim);
            DCore.IData objDB = DCore.Data.CreateData(strConn);
            try
            {
                objDB.Connect();
                MessageManager.Info("Kết nối thành công!");
                strOldConn = strConn;
            }
            catch (Exception objExc)
            {
                MessageManager.Error("Kết nối thất bại! " + objExc.Message);
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = txtServerName.Text + ";" + txtLoginName.Text + ";" + txtPassword.Text + ";" + txtDBName.Text;
                string str = Core.Security.Secure.EncryptRijndael(strConn, Core.Security.MachineIdentify.MachineID);

                Libs.Files.WriteFile(strFileConfig, str);
                MessageManager.Info("Đã lưu kết nối thành công!");
                strOldConn = string.Format(strTemplageConnection, txtServerName.TextTrim, txtLoginName.TextTrim, txtPassword.Text, txtDBName.TextTrim);
            }
            catch
            {
                ErrorManager.Error("Việc lưu cấu hình bị lỗi!");
            }
        }

        private void btnSaveGraduationResult_Click(object sender, EventArgs e)
        {

        }

        private void btnModifyOldData_Click(object sender, EventArgs e)
        {            
            DCore.IData objIData = DCore.Data.CreateData(strOldConn);
            try
            {                
                objIData.Connect();            
                string strSQL = "Select LopHoc,Ma From LopHoc";
                DataTable dtbClass = objIData.ExecQueryToDataTable(strSQL);
                foreach (DataRow r in dtbClass.Rows)
                {
                    //strSQL += " Update LopHoc Set Ma = N'" + Libs.MyConvert.ConvertVNIToUnicode(r["Ma"]) + "'" +
                    //    " Where LopHoc =" + r["LopHoc"].ToString();

                    strSQL += " Update LopHoc Set Ma = N'" + r["Ma"].ToString().Replace("Ð", "D") + "'" +
                        " Where LopHoc =" + r["LopHoc"].ToString();
                    objIData.ExecQueryToString(strSQL);
                }
                
                objIData.Disconnect();
                MessageManager.Info("Hiệu chỉnh dữ liệu thành công!");
            }
            catch
            {
                ErrorManager.Error("Không thể hiểu chỉnh!");
            }
        }
    }
}

