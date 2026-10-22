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
    public partial class frmSubjectMark : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SubjectMark_Edit";
        public const string PERMISSION_DELETE = "SIM_SubjectMark_Delete";
        public const string PERMISSION_EDIT_MORETIME = "SIM_SubjectMark_EditMoreTime"; // có quyền edit nhiều lần dù sổ điểm bị khóa
        public const string PERMISSION_VIEW = "SIM_SubjectMark_View";

        public const string PERMISSION_QUICK_REGISTER = "SIM_SubjectMark_QuickRegister"; // thêm nhanh hồ sơ học viên vào sổ điểm

        #endregion

        #region Variables

        DataTable dtbData;
        bool bolIsGraduationSubject = false;        
        bool bolIsTextMark = false;
        bool bolIsPractice = false; // là môn có thi lý thuyết thực hành
        int intTheoryRatio = 1;
        int intPracticeRatio = 1;
        string strSubjectID = "";

        int intSpecialType = 1; // 2 bổ sung 2 biến này để xử lý lưới cho môn GDQP điểm cũ
        bool bolIsOldData = false;

        SIM_Class_Subject objClassSubject;

        string strClassSubjectIDSaved = ""; // danh sách môn học lớp đã có thao tác và save, để khi thoát ra là khóa lại

        DataTable dtbSummary = null;

        #endregion

        #region IForm Members

        private static frmSubjectMark _instance = null;

        public static frmSubjectMark Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSubjectMark();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSubjectMark()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            //gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
            uClass.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_VIEW); // quyền xem trên khoa nào            
            string str = UserSession.GetSubjectGroupFilter(PERMISSION_VIEW);
            if (str != "")
                str = "( " + str + " ) Or TeachingBy ='" + UserSession.Username + "'";

            uClass.ClassSubjectFilter = str; // quyền xem trên bộ môn nào
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
            if (uClass.ClassSubjectIDEditValue == null)
            {
                uClass.Focus();
                MessageManager.Warning("Bạn phải chọn môn học lớp!");
                return false;
            }
            return true;
        }

        public void LoadData()
        {
            // gán cột vào lưới.                
            RepairGrid();

            // lấy classsubject info
            objClassSubject = new SIM_Class_Subject();
            objClassSubject.ClassSubjectID = uClass.ClassSubjectIDEditValue;
            if (!objClassSubject.Get())
            {
                ErrorManager.Error("Việc lấy thông tin môn học bị lỗi!");
                return;
            }

            objClassSubject.Mark1Number = txtMark1Number.EditValueInt32;
            objClassSubject.Mark2Number = txtMark2Number.EditValueInt32; // gán lại lúc nữa save luôn


            SIM_SubjectMark obj = new SIM_SubjectMark();
            dtbData = obj.SearchForEdit(
                                        //"@ClassID", uClass.IsRegulation43 ? null : uClass.ClassIDEditValue,
                                        "@ClassSubjectID", uClass.ClassSubjectIDEditValue
                                        //"@IsGraduationSubject", bolIsGraduationSubject,
                                        //"@SubjectID", strSubjectID
                                        );
            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                // set order
                ModifyGrid();

                gvData.BestFitColumns();
                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save                     
                btnSave.Enabled = mnuItemSave.Enabled = true; // chưa sửa thì không có save nếu đã từng save
                foreach(DataRow drw in dtbData.Rows)
                    if (drw["SubjectMarkID"].ToString() != "")
                    {
                        btnSave.Enabled = mnuItemSave.Enabled = false; // từng save rồi, không cần save khi mới tìm
                        break;
                    }



                // có quyền cập nhật của khoa này của bộ môn này không                                        
                string strSubjectGroupID = new SIM_Subject().Get(objClassSubject.SubjectID).SubjectGroupID;
                mnuItemImportFromExcel.Enabled = gvData.OptionsBehavior.Editable = dtbData.Rows.Count > 0
                                        && !objClassSubject.IsLocked // và môn học lớp chưa bị khoá
                                        && (
                                            UserSession.HasPermission(PERMISSION_EDIT, uClass.ScienceIDEditValue, strSubjectGroupID) // có quyền trên khoa, bộ môn
                                            || objClassSubject.TeachingBy == UserSession.Username  // hoặc là giảng viên dạy môn đó
                                           );

                mnuItemDelete.Enabled = mnuItemDeleteAll.Enabled =
                                        dtbData.Rows.Count > 0
                                        && !objClassSubject.IsLocked // và môn học lớp chưa bị khoá
                                        && (
                                              UserSession.HasPermission(PERMISSION_DELETE, uClass.ScienceIDEditValue, strSubjectGroupID)// có quyền trên khoa, bộ môn   
                                         //   || objClassSubject.TeachingBy == UserSession.Username  // hoặc là giảng viên dạy môn đó
                                           );              
                mnuItem_QuickRegister.Enabled =
                                        !objClassSubject.IsLocked // và môn học lớp chưa bị khoá
                                        && (
                                            UserSession.HasPermission(PERMISSION_QUICK_REGISTER, uClass.ScienceIDEditValue, strSubjectGroupID) // có quyền đăng ký học nhanh
                                            || uClass.ClassEdit.ManagerTeacherID == UserSession.Username // hoặc chủ nhiệm
                                            );


                // load thống kê
                dtbSummary = SimsService.SIM_SubjectMarkService.SummaryStatistic(dtbData, uClass.RegulationID); // Mr Việt đã chuyển thống kê vào service để dùng chung với web
                gcSummary.DataSource = dtbSummary;

                //// load thống kê
                //if (uClass.RegulationID == 99 || uClass.RegulationID == 43)
                //    SummaryStatistic_TinChi();
                //else
                //    SummaryStatistic();

                mnuItemReTotalRow.Enabled = gvData.OptionsBehavior.Editable;    
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

            // nếu có gõ lại số cột hs1, hs2 thì mới update lại môn học lớp
            if (!txtMark1Number.ReadOnly || !txtMark2Number.ReadOnly)
            {
                objClassSubject.IDB = item.IDB;
                if (!objClassSubject.Update())
                {
                    ErrorManager.Error("Cập nhật sổ điểm bị lỗi!");
                    return false;
                }
            }

            string strLogDetail = "";

            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw["IsEdit"].ToString() == "1" || drw["SubjectMarkID"].ToString() == "") // nếu dòng nào chưa có, thì chưa edit vẫn thêm vào luôn, cho danh sách dự thi lấy
                {
                    SIM_SubjectMark item2 = new SIM_SubjectMark(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;
                    if (item2.Parse(drw))
                    {
                        //item2.HaveExamRegister = false;        // bỏ đăng ký dự thi khi cập nhật điểm           
                        if (item2.SubjectMarkID == null)// thêm mới
                        {
                            item2.CreatedUser = UserSession.Username;
                            item2.OrderLearning = 1; // mặc định 1 nếu là thêm mới cho sinh viên chính lớp đó
                            //item2.ClassSubjectID = uClass.ClassSubjectIDEditValue;
                            //item2.SubjectID = objClassSubject.SubjectID;



                            if (!item2.Add())
                            {
                                ErrorManager.Error("Việc thêm sổ điểm bị lỗi!");
                                return false;
                            }

                            // nhớ log
                            strLogDetail += "Sinh viên: " + gvData.GetDataRow(i)["StudentCode"] + " - " + gvData.GetDataRow(i)["StudentFirstName"] + " " + gvData.GetDataRow(i)["StudentLastName"] + "\r\n";
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

            if (!item.UpdateIsLast())
            {
                ErrorManager.Error("Việc cập nhật sổ điểm bị lỗi!");
                return false;
            }

            item.CommitTransaction();

            string strActionLog = "Môn học: " + uClass.SubjectName + "\r\n" +
                                  "Lớp học: " + uClass.ClassIDEditValue + "\r\n" +
                                  "Niên học: " + uClass.UYearSemester.YearEditValueText + "\r\n" +
                                  "Học kì: " + uClass.Semester.ToString() + "\r\n\r\n" +
                                  strLogDetail;

            new SystemObject.SYS_ActionLog().WriteActionLog("Cập nhật sổ điểm", strActionLog, SystemObject.ActionLogType.EDIT, 2, UserSession.Username);
            return true;
        }

        /// <summary>
        /// Khởi tạo 53 cột cho 53 tuần cho lưới
        /// </summary>
        private void RepairGrid()
        {
            int? intRegulationID = uClass.RegulationID;

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
            gvData.Columns.AddRange(new BandedGridColumn[] { gcolStudentCode, gcolStudentFirstName, gcolStudentLastName, gcolBirthday });
            gbStudent.Columns.Add(gcolStudentCode);
            gbStudent.Columns.Add(gcolStudentFirstName);
            gbStudent.Columns.Add(gcolStudentLastName);
            gbStudent.Columns.Add(gcolBirthday);


            if (intRegulationID != 25)
            {
                for (int i = 1; i < 3; i++)
                {
                    GridBand gbMark = new GridBand();
                    if (i == 1)
                        gbMark.Caption = "KT THƯỜNG XUYÊN (HS1)";
                    else
                        gbMark.Caption = "KT ĐỊNH KÌ (HS2)";
                    gbMark.AppearanceHeader.Options.UseFont = true;
                    gbMark.AppearanceHeader.Options.UseTextOptions = true;
                    gbMark.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gbMark.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                    gbMark.Name = "gbMark" + i.ToString();
                    gvData.Bands.Add(gbMark);

                    int j = 7;
                    if (i == 1)
                    {
                        if (txtMark1Number.EditValueInt32 != null)
                            j = txtMark1Number.EditValueInt32.Value;
                    }
                    else
                    {
                        if (txtMark2Number.EditValueInt32 != null)
                            j = txtMark2Number.EditValueInt32.Value;
                    }

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


            // Thêm THI lt_th Band
            GridBand gbExamLTTH = new GridBand();
            gbExamLTTH.Caption = "THI LT - TH";
            gbExamLTTH.AppearanceHeader.Options.UseFont = true;
            gbExamLTTH.AppearanceHeader.Options.UseTextOptions = true;
            gbExamLTTH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbExamLTTH.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbExamLTTH.Name = "gbExamLTTH";

            gvData.Bands.Add(gbExamLTTH);

            for (int i = 2; i > 0; i--)
            {
                BandedGridColumn gcolExamTH = new BandedGridColumn();
                gcolExamTH.Caption = "TH" + i.ToString();
                gcolExamTH.FieldName = "PracticeExam" + i.ToString();
                gcolExamTH.Name = "gcolExamTH" + i.ToString();
                gcolExamTH.OptionsColumn.AllowMove = false;
                gcolExamTH.OptionsColumn.AllowSize = false;
                gcolExamTH.OptionsColumn.FixedWidth = true;
                gcolExamTH.Width = 35;
                gcolExamTH.Visible = true;
                gcolExamTH.AppearanceHeader.Options.UseFont = true;
                gcolExamTH.AppearanceHeader.Options.UseTextOptions = true;
                gcolExamTH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExamTH.AppearanceCell.Options.UseTextOptions = true;
                gcolExamTH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExamTH.DisplayFormat.FormatString = "#0.#";
                gcolExamTH.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcolExamTH.AppearanceCell.BackColor = Color.LightSkyBlue;

                gcolExamTH.AppearanceCell.Options.UseBackColor = true;

                gbExamLTTH.Columns.Add(gcolExamTH); // add cột tuần vào
                gvData.Columns.Add(gcolExamTH); // add cột vào lưới
            }

            for (int i = 2; i > 0; i--)
            {
                BandedGridColumn gcolExamLT = new BandedGridColumn();
                gcolExamLT.Caption = "LT" + i.ToString();
                gcolExamLT.FieldName = "TheoryExam" + i.ToString();
                gcolExamLT.Name = "gcolExamLT" + i.ToString();
                gcolExamLT.OptionsColumn.AllowMove = false;
                gcolExamLT.OptionsColumn.AllowSize = false;
                gcolExamLT.OptionsColumn.FixedWidth = true;
                gcolExamLT.Width = 35;
                gcolExamLT.Visible = true;
                gcolExamLT.AppearanceHeader.Options.UseFont = true;
                gcolExamLT.AppearanceHeader.Options.UseTextOptions = true;
                gcolExamLT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExamLT.AppearanceCell.Options.UseTextOptions = true;
                gcolExamLT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExamLT.DisplayFormat.FormatString = "#0.#";
                gcolExamLT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                gcolExamLT.AppearanceCell.BackColor = Color.LightBlue;
                gcolExamLT.AppearanceCell.Options.UseBackColor = true;

                gbExamLTTH.Columns.Add(gcolExamLT); // add cột tuần vào
                gvData.Columns.Add(gcolExamLT); // add cột vào lưới
            }


            // Thêm THI Band
            GridBand gbExam = new GridBand();
            gbExam.Caption = "KT HẾT MÔN";
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
                gcolExam.Width = 40;
                gcolExam.Visible = true;
                gcolExam.AppearanceHeader.Options.UseFont = true;
                gcolExam.AppearanceHeader.Options.UseTextOptions = true;
                gcolExam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam.AppearanceCell.Options.UseTextOptions = true;
                gcolExam.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolExam.DisplayFormat.FormatString = "#0.#";
                gcolExam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcolExam.AppearanceCell.BackColor = Color.MistyRose;
                gcolExam.AppearanceCell.Options.UseBackColor = true;

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
                gcolSummary.Width = 50;
                gcolSummary.AppearanceHeader.Options.UseFont = true;
                gcolSummary.AppearanceHeader.Options.UseTextOptions = true;
                gcolSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary.AppearanceCell.Options.UseTextOptions = true;
                gcolSummary.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolSummary.DisplayFormat.FormatString = "#0.#";
                gcolSummary.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcolSummary.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                gcolSummary.AppearanceCell.Options.UseFont = true;
                gcolSummary.AppearanceCell.BackColor = Color.LightPink;
                gcolSummary.AppearanceCell.Options.UseBackColor = true;

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

            BandedGridColumn gcolGroupSmallClass = new BandedGridColumn();
            gcolGroupSmallClass.Caption = "Nhóm";
            gcolGroupSmallClass.FieldName = "GroupSmallClass";
            gcolGroupSmallClass.Name = "gcolGroupSmallClass";
            gcolGroupSmallClass.OptionsColumn.AllowMove = false;
            gcolGroupSmallClass.OptionsColumn.AllowSize = false;
            gcolGroupSmallClass.OptionsColumn.FixedWidth = true;
            gcolGroupSmallClass.Visible = true;
            gcolGroupSmallClass.Width = 60;
            gcolGroupSmallClass.AppearanceHeader.Options.UseFont = true;
            gcolGroupSmallClass.AppearanceHeader.Options.UseTextOptions = true;
            gcolGroupSmallClass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGroupSmallClass.AppearanceCell.Options.UseTextOptions = true;
            gcolGroupSmallClass.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGroupSmallClass.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gcolGroupSmallClass.AppearanceCell.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gcolGroupSmallClass.AppearanceCell.Options.UseFont = true;

            gvData.Bands.Add(gbOrderLearning);
            gbOrderLearning.Columns.Add(gcolOrderLearning); // add cột tuần vào
            gbOrderLearning.Columns.Add(gcolGroupSmallClass);
            gvData.Columns.Add(gcolOrderLearning); // add cột vào lưới
            gvData.Columns.Add(gcolGroupSmallClass);


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

            if (intSpecialType == 7 && bolIsOldData) // Mr Việt - 13.06.2023 Khi là môn giáo dục quốc phòng và là điểm chuyển thì coi như điểm chuyển niên chế
                ;
            else if (intRegulationID == 43 || intRegulationID == 99 || intRegulationID == 44) // Quy chế 43 tín chỉ or 09 tín chỉ 2017
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
                gcolLearningLevel.Width = 50;
                gcolLearningLevel.Visible = true;
                gcolLearningLevel.AppearanceHeader.Options.UseFont = true;
                gcolLearningLevel.AppearanceHeader.Options.UseTextOptions = true;
                gcolLearningLevel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolLearningLevel.AppearanceCell.Options.UseTextOptions = true;
                gcolLearningLevel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolLearningLevel.AppearanceCell.BackColor = Color.LightGreen;
                gcolLearningLevel.AppearanceCell.Options.UseBackColor = true;

                // gcolStudentCode
                BandedGridColumn gcolOtherFinalSummary = new BandedGridColumn();
                gcolOtherFinalSummary.Caption = "Đ. Số";
                gcolOtherFinalSummary.FieldName = "OtherFinalSummary";
                gcolOtherFinalSummary.Name = "gcolOtherFinalSummary";
                gcolOtherFinalSummary.Width = 50;
                gcolOtherFinalSummary.Visible = true;
                gcolOtherFinalSummary.AppearanceHeader.Options.UseTextOptions = true;
                gcolOtherFinalSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcolOtherFinalSummary.AppearanceCell.BackColor = Color.LightGreen;
                gcolOtherFinalSummary.AppearanceCell.Options.UseBackColor = true;

                gvData.Bands.Add(gbSummary43);
                gvData.Columns.AddRange(new BandedGridColumn[] { gcolLearningLevel, gcolOtherFinalSummary });
                gbSummary43.Columns.Add(gcolLearningLevel); // add cột vào Band            
                gbSummary43.Columns.Add(gcolOtherFinalSummary);
            }

            #region Column Hệ thống

            // Hệt hống
            GridBand gbSystem = new GridBand();
            gbSystem.Caption = "Hệ thống";
            gbSystem.AppearanceHeader.Options.UseFont = true;
            gbSystem.AppearanceHeader.Options.UseTextOptions = true;
            gbSystem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbSystem.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbSystem.Name = "gbSystem";


            BandedGridColumn gcolCreatedDate = new BandedGridColumn();
            gcolCreatedDate.Caption = "Ngày tạo";
            gcolCreatedDate.FieldName = "CreatedDate";
            gcolCreatedDate.Name = "gcolCreatedDate";
            gcolCreatedDate.Visible = true;
            gcolCreatedDate.Width = 60;
            gcolCreatedDate.AppearanceHeader.Options.UseFont = true;
            gcolCreatedDate.AppearanceHeader.Options.UseTextOptions = true;
            gcolCreatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolCreatedDate.AppearanceCell.Options.UseTextOptions = true;
            gcolCreatedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            BandedGridColumn gcolCreatedUser = new BandedGridColumn();
            gcolCreatedUser.Caption = "Người tạo";
            gcolCreatedUser.FieldName = "CreatedUser";
            gcolCreatedUser.Name = "gcolCreatedUser";
            gcolCreatedUser.Visible = true;
            gcolCreatedUser.Width = 60;
            gcolCreatedUser.AppearanceHeader.Options.UseFont = true;
            gcolCreatedUser.AppearanceHeader.Options.UseTextOptions = true;
            gcolCreatedUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolCreatedUser.AppearanceCell.Options.UseTextOptions = true;
            gcolCreatedUser.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            BandedGridColumn gcolUpdatedDate = new BandedGridColumn();
            gcolUpdatedDate.Caption = "Ngày sửa";
            gcolUpdatedDate.FieldName = "UpdatedDate";
            gcolUpdatedDate.Name = "gcolUpdatedDate";
            gcolUpdatedDate.Visible = true;
            gcolUpdatedDate.Width = 60;
            gcolUpdatedDate.AppearanceHeader.Options.UseFont = true;
            gcolUpdatedDate.AppearanceHeader.Options.UseTextOptions = true;
            gcolUpdatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolUpdatedDate.AppearanceCell.Options.UseTextOptions = true;
            gcolUpdatedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            BandedGridColumn gcolUpdatedUser = new BandedGridColumn();
            gcolUpdatedUser.Caption = "Người sửa";
            gcolUpdatedUser.FieldName = "UpdatedUser";
            gcolUpdatedUser.Name = "gcolUpdatedUser";
            gcolUpdatedUser.Visible = true;
            gcolUpdatedUser.Width = 60;
            gcolUpdatedUser.AppearanceHeader.Options.UseFont = true;
            gcolUpdatedUser.AppearanceHeader.Options.UseTextOptions = true;
            gcolUpdatedUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolUpdatedUser.AppearanceCell.Options.UseTextOptions = true;
            gcolUpdatedUser.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            gvData.Bands.Add(gbSystem);
            gbSystem.Columns.Add(gcolUpdatedUser);
            gbSystem.Columns.Add(gcolUpdatedDate);
            gbSystem.Columns.Add(gcolCreatedUser);
            gbSystem.Columns.Add(gcolCreatedDate); // add cột tuần vào

            gvData.Columns.AddRange(new BandedGridColumn[] { gcolCreatedDate, gcolCreatedUser, gcolUpdatedDate, gcolUpdatedUser });

            #endregion
        }


        private void ModifyGrid()
        {
            // môn LT, TH
            gvData.Bands["gbExamLTTH"].Visible = bolIsPractice;

            // nếu là môn tốt nghiệp niên chế (không phải đang nhập điểm dạng tín chỉ) - vì tín chỉ giờ môn tốt nghiệp coi như môn học
            if ((bolIsGraduationSubject || intSpecialType == Global.SubjectSpecialType.TotNghiepVanHoa) && !uClass.IsRegulation43) // môn TN văn hóa hiển thị như môn TN nghề
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
                    case 22:
                        ModifyGrid22();
                        break;
                    case 4:
                    case 9: // trung cấp, cao đẳng chuyên nghiệp 2017
                        ModifyGrid09();
                        break;
                    case 44:
                    case 99:// trung cấp, cao đẳng chuyên nghiệp 2017 (Tín Chỉ)
                        ModifyGrid09_TinChi();
                        break;
                    default:
                        ModifyGrid09();
                        break;

                }
            }

        }

        #region Ẩn cột trên lưới theo từng qui chế

        private void ModifyGrid14()
        {
            if (txtMark1Number.EditValueInt32 == null || txtMark1Number.EditValueInt32 == 0)
                gvData.Bands["gbMark1"].Visible = false;
            if (txtMark2Number.EditValueInt32 == null || txtMark2Number.EditValueInt32 == 0)
                gvData.Bands["gbMark2"].Visible = false;

            gvData.Columns["Exam3"].Visible = false; // thi lần 3 bỏ
            gvData.Columns["Summary3"].Visible = false; // TKM lần 3 bỏ
            gvData.Bands["gbExam"].Caption = bolIsPractice ? "HỆ SỐ 3" : "KT HẾT MÔN";
        }

        private void ModifyGrid22()
        {
            if (txtMark1Number.EditValueInt32 == null || txtMark1Number.EditValueInt32 == 0)
                gvData.Bands["gbMark1"].Visible = false;
            if (txtMark2Number.EditValueInt32 == null || txtMark2Number.EditValueInt32 == 0)
                gvData.Bands["gbMark2"].Visible = false;

            gvData.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";

        }

        private void ModifyGrid40()
        {
            if (txtMark1Number.EditValueInt32 == null || txtMark1Number.EditValueInt32 == 0)
                gvData.Bands["gbMark1"].Visible = false;
            if (txtMark2Number.EditValueInt32 == null || txtMark2Number.EditValueInt32 == 0)
                gvData.Bands["gbMark2"].Visible = false;

            gvData.Bands["gbExam"].Caption = "KIỂM TRA HẾT MÔN";

        }

        private void ModifyGrid46()
        {
            if (txtMark1Number.EditValueInt32 == null || txtMark1Number.EditValueInt32 == 0)
                gvData.Bands["gbMark1"].Visible = false;
            if (txtMark2Number.EditValueInt32 == null || txtMark2Number.EditValueInt32 == 0)
                gvData.Bands["gbMark2"].Visible = false;

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

        /// <summary>
        /// Niên chế 09, cđ, tc 2017
        /// </summary>
        private void ModifyGrid09()
        {
            if (txtMark1Number.EditValueInt32 == null || txtMark1Number.EditValueInt32 == 0)
                gvData.Bands["gbMark1"].Visible = false;
            if (txtMark2Number.EditValueInt32 == null || txtMark2Number.EditValueInt32 == 0)
                gvData.Bands["gbMark2"].Visible = false;

            gvData.Bands["gbExam"].Caption = "KT HẾT MÔN";

        }

        /// <summary>
        /// Tín chỉ tc 09, cđ, tc 2017
        /// </summary>
        private void ModifyGrid09_TinChi()
        {
            if (txtMark1Number.EditValueInt32 == null || txtMark1Number.EditValueInt32 == 0)
                gvData.Bands["gbMark1"].Visible = false;
            if (txtMark2Number.EditValueInt32 == null || txtMark2Number.EditValueInt32 == 0)
                gvData.Bands["gbMark2"].Visible = false;

            gvData.Bands["gbExam"].Caption = "KT HẾT MÔN";
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

        #region Tính điểm trung bình 1 dòng theo từng qui chế

        //private void TotalRow(DataRow drw)
        //{
        //    if (drw["OrderLearning"].ToString() == "")
        //        drw["OrderLearning"] = 1;

        //    if ((bolIsGraduationSubject || intSpecialType == Global.SubjectSpecialType.TotNghiepVanHoa) && !uClass.IsRegulation43)// nếu không phải đang chọn tín chỉ và là môn tốt nghiệp, TN VĂN Hóa TÍNH NHƯ TN NGHỀ
        //        TotalRow_Graduation(drw);
        //    else if (bolIsTextMark)
        //        TotalRow_MarkText(drw);
        //    else if (objClassSubject.IsOldData)
        //        TotalRow_OldData(drw);             // nếu là điểm chuyển thì chỉ cần nhập cột TKM và đạt hay không thôi
        //    else
        //    {
        //        switch (uClass.RegulationID)
        //        {
        //            case 14:
        //                //if (drw["SpecialType"].ToString() == "8") // là môn văn hóa tính theo quy chế 22
        //                //    TotalRow22(drw);
        //                //else
        //                    TotalRow14(drw);
        //                break;
        //            case 22:
        //                TotalRow22(drw);
        //                break;
        //            case 40:
        //                TotalRow40(drw);
        //                break;
        //            case 46:
        //                TotalRow46(drw);
        //                break;
        //            case 25:
        //                TotalRow25(drw);
        //                break;
        //            case 9: // tc, cđ chuyên nghiệp 2017
        //                 if (intSpecialType == 8)
        //                    TotalRow09_VanHoa(drw);
        //                else
        //                    TotalRow09(drw);
        //                break;
        //            case 99: // tc, cđ chuyên nghiệp 2017 Tín chỉ
        //                TotalRow09_TinChi(drw);
        //                break;
        //        }
        //    }
        //}
        ///// <summary>
        ///// Cách tính điểm cho môn văn hóa
        ///// (Hệ số 1 + Hệ số 2 x 2 + Điểm thi x 3 ) / tổng hệ số
        ///// Giống như quy chế 14
        ///// </summary>
        ///// <param name="drw"></param>
        //private static void TotalRow09_VanHoa(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    int intCount = 0;
        //    int intMark1Number = Convert.ToInt32(drw["Mark1Number"]);
        //    int intMark2Number = Convert.ToInt32(drw["Mark2Number"]);

        //    // Tính TBKT luôn 2 hệ số           
        //    for (int i = 1; i <= 25 && i <= intMark1Number; i++)
        //    {
        //        {
        //            string strValue = drw["Mark1" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount++; // tính đủ số cột
        //        }
        //    }

        //    for (int i = 1; i <= 25 && i <= intMark2Number; i++)
        //    {
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount += 2; // tính đủ số cột
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;


        //    // Tính TMK dựa vào điểm thi
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);

        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "")
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTBKT.Value + dblExam3.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;

        //    // có quy định điểm tối thiểu trong môn học thì xét theo, không thì mặc định là 5
        //    double dblRequestMinMark = 5;
        //    try
        //    {
        //        if (drw["RequestMinMark"].ToString() != "" && drw["RequestMinMark"].ToString() != "0")
        //            dblRequestMinMark = Convert.ToDouble(drw["RequestMinMark"]);
        //    }
        //    catch { }


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if ( dblFinalSummary >= dblRequestMinMark) // Qui chế 09 chỉ kiểm tra tổng kết môn >=5. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}  // End TotalRow09
        //private void TotalRow_Graduation(DataRow drw)
        //{
        //    double? dblExam1 = null, dblExam2 = null, dblExam3 = null;
        //    if (drw["Exam1"].ToString() != "")
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //    if (drw["Exam2"].ToString() != "")
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //    if (drw["Exam3"].ToString() != "")
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);

        //    if (dblExam1 != null)
        //        drw["Summary1"] = dblExam1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblExam2 != null)
        //        drw["Summary2"] = dblExam2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblExam3 != null)
        //        drw["Summary3"] = dblExam3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblExam1;

        //    if (dblExam2 > dblFinalSummary)
        //        dblFinalSummary = dblExam2;
        //    if (dblExam3 > dblFinalSummary)
        //        dblFinalSummary = dblExam3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (dblFinalSummary >= 5)
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}

        //private void TotalRow_MarkText(DataRow drw)
        //{
        //    double? dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    if (drw["Summary1"].ToString() != "")
        //        dblSummary1 = Convert.ToDouble(drw["Summary1"]);
        //    if (drw["Summary2"].ToString() != "")
        //        dblSummary2 = Convert.ToDouble(drw["Summary2"]);
        //    if (drw["Summary3"].ToString() != "")
        //        dblSummary3 = Convert.ToDouble(drw["Summary3"]);

        //    // Xét tổng kết môn cuối cùng
        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (dblFinalSummary > 100)
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}

        //private void TotalRow_OldData(DataRow drw)
        //{
        //    double? dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    if (drw["Summary1"].ToString() != "")
        //        dblSummary1 = Convert.ToDouble(drw["Summary1"]);
        //    if (drw["Summary2"].ToString() != "")
        //        dblSummary2 = Convert.ToDouble(drw["Summary2"]);
        //    if (drw["Summary3"].ToString() != "")
        //        dblSummary3 = Convert.ToDouble(drw["Summary3"]);

        //    // Xét tổng kết môn cuối cùng
        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (dblFinalSummary >= 5)
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}

        ///// <summary>
        ///// Trả về kq đạt hay không?
        ///// Chỉ cần có LT, hoặc TH <=5 là không đạt
        ///// </summary>
        ///// <param name="drw"></param>
        ///// <returns></returns>
        //private bool TotalTheoryPracticeExam(DataRow drw)
        //{
        //    if (!bolIsPractice)
        //        return true;

        //    bool bolTheoryPassed = false;
        //    bool bolPracticePassed = false;

        //    double dblMaxTheory = -1;
        //    double dblMaxPractice = -1;

        //    for (int i = 1; i < 3; i++)
        //    {
        //        double dblTheory = -1;
        //        double dblPractice = -1;
        //        int intFlag = 0;
        //        if (drw["TheoryExam" + i.ToString()].ToString() != "")
        //        {
        //            dblTheory = Convert.ToDouble(drw["TheoryExam" + i.ToString()]);
        //            // nếu đạt LT
        //            if (dblTheory >= 3)
        //                bolTheoryPassed = true;
        //            // lay diem sau cung tu vi tri dang tinh ve truoc
        //            dblMaxTheory = dblTheory;
        //            intFlag++;
        //        }
        //        if (drw["PracticeExam" + i.ToString()].ToString() != "")
        //        {
        //            dblPractice = Convert.ToDouble(drw["PracticeExam" + i.ToString()]);
        //            //Nếu đạt TH
        //            if (dblPractice >= 5)
        //                bolPracticePassed = true;
        //            // lay diem sau cung tu vi tri dang tinh ve truoc
        //            dblMaxPractice = dblPractice;
        //            intFlag++;
        //        }

        //        if (intFlag > 0 && dblMaxTheory >= 0 && dblMaxPractice >= 0)
        //        {
        //            drw["Exam" + i.ToString()] = Math.Round((dblMaxTheory * intTheoryRatio + dblMaxPractice * intPracticeRatio) / (intTheoryRatio + intPracticeRatio), 1, MidpointRounding.AwayFromZero);
        //        }
        //        else
        //            drw["Exam" + i.ToString()] = DBNull.Value;

        //    }
        //    return bolTheoryPassed && bolPracticePassed; // cả 2 đều có điểm đạt mới là đạt
        //}

        //private void TotalRow14(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblSummary1 = null, dblSummary2 = null;
        //    double? dblTBKT2 = 0;
        //    int intCount = 0; int iMark1 = 0;
        //    drw["NotAllowExam"] = false;

        //    /// tính TBKT hệ số 1
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark1Number.Value; i++)
        //    {
        //        string strValue = drw["Mark1" + i.ToString()].ToString();
        //        if (strValue != "")
        //        {
        //            double a = Convert.ToDouble(strValue);
        //            dblTBKT += a;

        //            if (a == 0)
        //                drw["NotAllowExam"] = true;

        //        }
        //        else
        //            drw["NotAllowExam"] = true;

        //        // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)

        //        if (strValue != "")
        //        {
        //            intCount++; // tính đủ số cột
        //            iMark1++;
        //        }
        //    }

        //    // Tính TBKT hệ số 2
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark2Number.Value; i++)
        //    {
        //        string strValue = drw["Mark2" + i.ToString()].ToString();
        //        if (strValue != "")
        //        {
        //            double a = Convert.ToDouble(strValue);
        //            dblTBKT += a * 2;

        //            if (a == 0)
        //                drw["NotAllowExam"] = true;

        //        }
        //        else
        //            drw["NotAllowExam"] = true;

        //        // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)

        //        if (strValue != "")
        //            intCount += 2; // tính đủ số cột
        //    }
            

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTBKT2 = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;

        //    // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
        //    bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

        //    // Tính TKM
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        if (iMark1>0)
        //            dblSummary1 = Math.Round((dblTBKT2.Value + dblExam1.Value) / 2, 1, MidpointRounding.AwayFromZero);
        //        else
        //            dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        if (iMark1 > 0)
        //            dblSummary2 = Math.Round((dblTBKT2.Value + dblExam2.Value) / 2, 1, MidpointRounding.AwayFromZero);
        //        else
        //            dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value * 3) / (intCount + 3), 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;
        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    // Xét tổng kết môn cuối cùng
        //    if (dblSummary1 != null && dblSummary2 != null)
        //    {
        //        if (dblSummary2 > dblSummary1)
        //            drw["FinalSummary"] = dblSummary2;
        //        else
        //            drw["FinalSummary"] = dblSummary1;
        //    }
        //    else
        //        drw["FinalSummary"] = drw["Summary1"];


        //    // tính đạt môn : Thi >=5 và TKM >=5
        //    if (dblSummary1 != null) // có thi lần 1 mới tính
        //    {
        //        if (bolTheoryPracticePassed && (dblExam1 >= 5 || dblExam2 >= 5) && (dblSummary1 >= 5 || dblSummary2 >= 5)) // thi và tkm >=5 và LT_TH đạt(dv môn TH)                   
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //} // End TotalRow14

        //private void TotalRow22(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    int intCount = 0;

        //    // Tính TBKT luôn 2 hệ số           
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark1Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark1" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount++; // tính đủ số cột
        //        }
        //    }

        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark2Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount += 2; // tính đủ số cột
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;

        //    // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
        //    bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

        //    // nếu có tbkt thì + chia 10, không thì chia 6
        //    if (intCount > 0)
        //        intCount = 10;
        //    else
        //        intCount = 6;

        //    // Tính TMK dựa vào điểm thi
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "")
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (bolTheoryPracticePassed && dblFinalSummary >= 5 && dblTBKT >= 3 && (dblExam1 >= 3 || dblExam2 >= 3))// qui chế 22 ko kiểm tra điểm thi
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}  // End TotalRow40

        //private void TotalRow40(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    int intCount = 0;

        //    // Tính TBKT luôn 2 hệ số           
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark1Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark1" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount++; // tính đủ số cột
        //        }
        //    }

        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark2Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount += 2; // tính đủ số cột
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;

        //    // nếu có tbkt thì + chia đôi, không thì chia 1
        //    if (intCount > 0)
        //        intCount = 2;
        //    else
        //        intCount = 1;

        //    // Tính TMK dựa vào điểm thi
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value) / intCount, 1, MidpointRounding.AwayFromZero);

        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "")
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTBKT.Value + dblExam3.Value) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (dblFinalSummary >= 5)
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}  // End TotalRow40

        //private void TotalRow46(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    int intCount = 0;

        //    // Tính TBKT luôn 2 hệ số           
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark1Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark1" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount++; // tính đủ số cột
        //        }
        //    }

        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark2Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount += 2; // tính đủ số cột
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;

        //    // nếu có tbkt thì + chia đôi, không thì chia 1
        //    if (intCount > 0)
        //        intCount = 2;
        //    else
        //        intCount = 1;

        //    // Tính TMK dựa vào điểm thi
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTBKT.Value + dblExam1.Value) / intCount, 1, MidpointRounding.AwayFromZero);

        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTBKT.Value + dblExam2.Value) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "")
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTBKT.Value + dblExam3.Value) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (dblFinalSummary >= 5)
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //} // End TotalRow46

        ///// <summary>
        ///// Các hệ số tương ứng trong Class_Subject là 1,2,3,4
        ///// </summary>
        ///// <param name="drw"></param>
        //private void TotalRow43(DataRow drw)
        //{
        //    double? dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null, dblTestAverage = null;
        //    double? dblMark11 = null, dblMark12 = null; // Nhận thức và Chuyên cần


        //    // Điểm nhận thức, Điểm chuyên cần------------------------------------------------------------
        //    if (drw["Mark11"] != null && drw["Mark11"].ToString() != "")
        //        dblMark11 = Convert.ToDouble(drw["Mark11"]);
        //    if (drw["Mark11"] != null && drw["Mark12"].ToString() != "")
        //        dblMark12 = Convert.ToDouble(drw["Mark12"]);


        //    // Tính TBKT với điểm của hệ số 2-------------------------------------------------
        //    int intCount = 0;
        //    double? dblTBKT = 0;

        //    for (int a = 1; a < 3; a++)
        //    {
        //        for (int i = 1; i < 7; i++)
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //            {
        //                dblTBKT += Convert.ToDouble(strValue);
        //                intCount++;
        //            }
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTestAverage = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;




        //    // Tính TMK dựa vào điểm thi và TBKT và điểm Nhận thức và chuyên cần.---------------------------------            
        //    double dblSum = 0;
        //    double dblSumRatio = 0;
        //    if (dblMark11 != null)
        //    {
        //        dblSum = dblMark11.Value * objClassSubject.MarkRatio1.Value;
        //        dblSumRatio = objClassSubject.MarkRatio1.Value;
        //    }
        //    if (dblMark12 != null)
        //    {
        //        dblSum += dblMark12.Value * objClassSubject.MarkRatio2.Value;
        //        dblSumRatio += objClassSubject.MarkRatio2.Value;
        //    }
        //    if (dblTestAverage != null)
        //    {
        //        dblSum += dblTestAverage.Value * objClassSubject.MarkRatio3.Value;
        //        dblSumRatio += objClassSubject.MarkRatio3.Value;
        //    }


        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblSum + dblExam1.Value * objClassSubject.MarkRatio4.Value) / (dblSumRatio + objClassSubject.MarkRatio4.Value), 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam2"].ToString() != "" && dblTestAverage != null)
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblSum + dblExam2.Value * objClassSubject.MarkRatio4.Value) / (dblSumRatio + objClassSubject.MarkRatio4.Value), 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "" && dblTestAverage != null)
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblSum + dblExam3.Value * objClassSubject.MarkRatio4.Value) / (dblSumRatio + objClassSubject.MarkRatio4.Value), 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // Xét Điểm số A,B,C,D, F
        //    if (dblFinalSummary >= 8.5)
        //    {
        //        drw["LearningLevel"] = "A";
        //        drw["OtherFinalSummary"] = 4;
        //        drw["Passed"] = 1;
        //    }
        //    else if (dblFinalSummary >= 7)
        //    {
        //        drw["LearningLevel"] = "B";
        //        drw["OtherFinalSummary"] = 3;
        //        drw["Passed"] = 1;
        //    }
        //    else if (dblFinalSummary >= 5.5)
        //    {
        //        drw["LearningLevel"] = "C";
        //        drw["OtherFinalSummary"] = 2;
        //        drw["Passed"] = 1;
        //    }
        //    else if (dblFinalSummary >= 4)
        //    {
        //        drw["LearningLevel"] = "D";
        //        drw["OtherFinalSummary"] = 1;
        //        drw["Passed"] = 1;
        //    }
        //    else
        //    {
        //        drw["LearningLevel"] = "F";
        //        drw["OtherFinalSummary"] = 0;
        //        drw["Passed"] = 0;
        //    }


        //} // End TotalRow46

        ///// <summary>
        ///// Cột Điểm TP = TestAverage và ứng với hệ số MarkRatio1 trong Class_Subject
        ///// Cột điểm thi có hệ số là MarkRatio2 trong Class_subject
        ///// </summary>
        ///// <param name="drw"></param>
        //private void TotalRow25(DataRow drw)
        //{
        //    double? dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null, dblTestAverage = null;

        //    if (objClassSubject.MarkRatio1 == null || objClassSubject.MarkRatio2 == null)
        //    {
        //        objClassSubject.MarkRatio1 = 1;
        //        objClassSubject.MarkRatio2 = 1;
        //    }

        //    double dblSumRatio = objClassSubject.MarkRatio1.Value + objClassSubject.MarkRatio2.Value;

        //    // Tính TBKT với điểm của hệ số 2-------------------------------------------------           

        //    if (drw["TestAverage"].ToString() != "")
        //        dblTestAverage = Convert.ToDouble(drw["TestAverage"]) * objClassSubject.MarkRatio1.Value; // Điểm TP đã nhân hệ số (cột HS đầu tiên trong class_subject)
        //    else
        //        return; // chưa có điểm này thì không tính luôn.



        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTestAverage.Value + dblExam1.Value * objClassSubject.MarkRatio2.Value) / dblSumRatio, 0);
        //    }
        //    if (drw["Exam2"].ToString() != "" && dblTestAverage != null)
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTestAverage.Value + dblExam2.Value * objClassSubject.MarkRatio2.Value) / dblSumRatio, 0);
        //    }
        //    if (drw["Exam3"].ToString() != "" && dblTestAverage != null)
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTestAverage.Value + dblExam3.Value * objClassSubject.MarkRatio2.Value) / dblSumRatio, 0);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;

        //    // tính đạt môn : Thi >=5 và TKM >=5
        //    if (dblFinalSummary != null) // có thi lần 1 mới tính
        //    {
        //        if ((dblExam1 >= 5 || dblExam2 >= 5) && (dblFinalSummary >= 5))
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;

        //} // End TotalRow25

        ///// <summary>
        ///// Trung cấp, cao đẳng chuyên nghiệp 2017
        ///// TBM = (TBKT*4 + Thi * 6)/10
        ///// </summary>
        ///// <param name="drw"></param>
        //private void TotalRow09(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    int intCount = 0;

        //    // Tính TBKT luôn 2 hệ số           
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark1Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark1" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue); //nhân hệ số                                            

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount++; // tính đủ số cột
        //        }
        //    }

        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark2Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount += 2; // tính đủ số cột
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;

        //    // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
        //    bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

        //    // nếu có tbkt thì + chia 10, không thì chia 6
        //    if (intCount > 0)
        //        intCount = 10;
        //    else
        //        intCount = 6;

        //    // Tính TMK dựa vào điểm thi
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "")
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }



        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (bolTheoryPracticePassed && dblFinalSummary >= 5) // Qui chế 09 chỉ kiểm tra tổng kết môn >=5. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;
        //}  // End TotalRow40


        ///// <summary>
        ///// Trung cấp, cao đẳng chuyên nghiệp 2017 theo tín chỉ
        ///// Có điểm quy đổi
        ///// TBM = (TBKT*4 + Thi * 6)/10
        ///// </summary>
        ///// <param name="drw"></param>
        //private void TotalRow09_TinChi(DataRow drw)
        //{
        //    double? dblTBKT = 0, dblExam1 = null, dblExam2 = null, dblExam3 = null, dblSummary1 = null, dblSummary2 = null, dblSummary3 = null;
        //    int intCount = 0;

        //    bool bolHaveEmptyMark = false;

        //    // Tính TBKT luôn 2 hệ số           
        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark1Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark1" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue); //nhân hệ số      
        //            else
        //                bolHaveEmptyMark = true; // có cột rỗng

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount++; // tính đủ số cột
        //        }
        //    }

        //    for (int i = 1; i <= 25 && i <= objClassSubject.Mark2Number.Value; i++)
        //    {
        //        {
        //            string strValue = drw["Mark2" + i.ToString()].ToString();
        //            if (strValue != "")
        //                dblTBKT += Convert.ToDouble(strValue) * 2; //nhân hệ số
        //            else
        //                bolHaveEmptyMark = true; // có cột rỗng

        //            // nếu có điểm thì tăng số cột, nếu học lại thì chỉ tăng cột khi có nhập điểm (học lại thì không cần đủ số cột)
        //            //if (Convert.ToInt32(drw["OrderLearning"]) < 2 || strValue != "")
        //            if (strValue != "")
        //                intCount += 2; // tính đủ số cột
        //        }
        //    }

        //    if (intCount > 0)
        //        drw["TestAverage"] = dblTBKT = Math.Round(dblTBKT.Value / intCount, 1, MidpointRounding.AwayFromZero);
        //    else
        //        drw["TestAverage"] = DBNull.Value;

        //    // Tính lại điểm thi nếu có thi LT-TH:  thi = (LT + TH)/2
        //    bool bolTheoryPracticePassed = TotalTheoryPracticeExam(drw);

        //    // nếu có tbkt thì + chia 10, không thì chia 6
        //    if (intCount > 0)
        //        intCount = 10;
        //    else
        //        intCount = 6;

        //    // Tính TMK dựa vào điểm thi
        //    if (drw["Exam1"].ToString() != "")
        //    {
        //        dblExam1 = Convert.ToDouble(drw["Exam1"]);
        //        dblSummary1 = Math.Round((dblTBKT.Value * 4 + dblExam1.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);

        //    }
        //    if (drw["Exam2"].ToString() != "")
        //    {
        //        dblExam2 = Convert.ToDouble(drw["Exam2"]);
        //        dblSummary2 = Math.Round((dblTBKT.Value * 4 + dblExam2.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }
        //    if (drw["Exam3"].ToString() != "")
        //    {
        //        dblExam3 = Convert.ToDouble(drw["Exam3"]);
        //        dblSummary3 = Math.Round((dblTBKT.Value * 4 + dblExam3.Value * 6) / intCount, 1, MidpointRounding.AwayFromZero);
        //    }


        //    if (dblSummary1 != null)
        //        drw["Summary1"] = dblSummary1;
        //    else
        //        drw["Summary1"] = DBNull.Value;

        //    if (dblSummary2 != null)
        //        drw["Summary2"] = dblSummary2;
        //    else
        //        drw["Summary2"] = DBNull.Value;

        //    if (dblSummary3 != null)
        //        drw["Summary3"] = dblSummary3;
        //    else
        //        drw["Summary3"] = DBNull.Value;


        //    // Xét tổng kết môn cuối cùng
        //    double? dblFinalSummary = dblSummary1;

        //    if (dblSummary2 > dblFinalSummary)
        //        dblFinalSummary = dblSummary2;
        //    if (dblSummary3 > dblFinalSummary)
        //        dblFinalSummary = dblSummary3;

        //    if (dblFinalSummary != null)
        //        drw["FinalSummary"] = dblFinalSummary;
        //    else
        //        drw["FinalSummary"] = DBNull.Value;


        //    // tính đạt môn :  TKM >=5
        //    if (dblFinalSummary != null)
        //    {
        //        if (bolTheoryPracticePassed && dblFinalSummary >= 4) // Qui chế 09_Tín chỉ chỉ kiểm tra tổng kết môn >= 4. Còn tbkt đã ràng buộc cho học viên đủ điều kiện dự thi.
        //            drw["Passed"] = 1;
        //        else
        //            drw["Passed"] = 0;
        //    }
        //    else
        //        drw["Passed"] = DBNull.Value;

        //    // Xét Điểm số A,B,C,D, F
        //    if (bolHaveEmptyMark) // chưa đủ cột điểm
        //    {
        //        drw["LearningLevel"] = "I";
        //        drw["OtherFinalSummary"] = DBNull.Value;
        //    }
        //    else if (dblFinalSummary >= 8.5)
        //    {
        //        drw["LearningLevel"] = "A";
        //        drw["OtherFinalSummary"] = 4;
        //    }
        //    else if (dblFinalSummary >= 7)
        //    {
        //        drw["LearningLevel"] = "B";
        //        drw["OtherFinalSummary"] = 3;
        //    }
        //    else if (dblFinalSummary >= 5.5)
        //    {
        //        drw["LearningLevel"] = "C";
        //        drw["OtherFinalSummary"] = 2;
        //    }
        //    else if (dblFinalSummary >= 4)
        //    {
        //        drw["LearningLevel"] = "D";
        //        drw["OtherFinalSummary"] = 1;
        //    }
        //    else if (dblFinalSummary != null) // đã có điểm không đạt
        //    {
        //        drw["LearningLevel"] = "F";
        //        drw["OtherFinalSummary"] = 0;
        //    }
        //    else // đủ cột, chưa điểm thi
        //    {
        //        drw["LearningLevel"] = "X";
        //        drw["OtherFinalSummary"] = DBNull.Value;
        //    }

        //}  // End TotalRow40

        #endregion

        private bool IsValidMark(object value)
        {
            if (value == null || value.ToString() == "")
                return true;

            double a = 0;
            if (double.TryParse(value.ToString(), out a))
            {
                if (a > 10 || a < 0)
                {

                    return false;
                }
            }
            return true;
        }

        private void ImportFromExcel()
        {
            if (gvData.QuickImportFromExcel("Mã SV", ",Họ đệm,Tên,Ngày sinh,Miễn học,") > 0)
            {
                if (!objClassSubject.IsOldData)
                {
                    for (int i = 0; i < gvData.RowCount; i++)
                    {
                        DataRow drw = gvData.GetDataRow(i);



                        if (drw["IsEdit"].ToString() == "1")
                        {
                            #region Check diem

                            for (int d = 1; d <= txtMark1Number.EditValueInt32; d++)
                            {
                                if (!IsValidMark(drw["Mark1" + d.ToString()]))
                                {
                                    MessageManager.Warning("Hệ số 1" + d.ToString() + " của mã SV " + drw["StudentCode"].ToString() + " không được lớn hơn 10");
                                    btnSave.Enabled = mnuItemSave.Enabled = false;
                                    return;
                                }
                            }

                            for (int d = 1; d <= txtMark2Number.EditValueInt32; d++)
                            {
                                if (!IsValidMark(drw["Mark2" + d.ToString()]))
                                {
                                    MessageManager.Warning("Hệ số 2" + d.ToString() + " của mã SV " + drw["StudentCode"].ToString() + " không được lớn hơn 10");
                                    btnSave.Enabled = mnuItemSave.Enabled = false;
                                    return;
                                }
                            }

                            for (int d = 1; d < 4; d++)
                            {
                                if (!IsValidMark(drw["Exam" + d.ToString()]))
                                {
                                    MessageManager.Warning("Điểm thi lần " + d.ToString() + " của mã SV " + drw["StudentCode"].ToString() + " không được lớn hơn 10");
                                    btnSave.Enabled = mnuItemSave.Enabled = false;
                                    return;
                                }
                            }

                            #endregion

                            SimsService.SIM_SubjectMarkService.TotalRow(drw);
                        }
                    }
                }
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }

        /// <summary>
        /// Khóa giảng viên hoặc một số user nào đó tùy hiệu chỉnh
        /// Hiện tại chỉ khóa giảng viên khi cập nhật
        /// 0. Giảng viên
        /// </summary>
        private void LockClassSubject()
        {
            if (strClassSubjectIDSaved != "")
            {
                if (!UserSession.HasPermission(PERMISSION_EDIT_MORETIME))
                {
                    SIM_Class_Subject obj = new SIM_Class_Subject();
                    obj.ModifiedBy = UserSession.Username;
                    obj.IsLocked = true;
                    strClassSubjectIDSaved += ";";
                    if (!obj.LockList(strClassSubjectIDSaved))
                    {
                        ErrorManager.Error("Việc khóa sổ điểm bị lỗi!");
                    }
                    else
                    {
                        MessageManager.Warning("Những môn học lớp đã bị khóa sau khi chỉnh sửa thành công!");
                        strClassSubjectIDSaved = "";
                    }
                }
            }
        }

        /// <summary>
        /// classSubjectID
        /// </summary>
        /// <param name="classSubjectID">Chính là mã môn học lớp</param>        
        /// <param name="pageNo">1,3,5 cho điểm quá trình hệ số 1. 2,4,6 cho điểm quá trình hệ số 2</param>
        /// <returns>Trả về mã tự tăng của file scan vừa tạo để in ra giấy scan</returns>
        private long? SaveForScan(long classSubjectID, int pageNo)
        {
            SIM_ScanMark objFile = new SIM_ScanMark();
            SIM_ScanMarkDetail objFileDetail = new SIM_ScanMarkDetail();
            objFile.BeginTransaction();
            objFileDetail.IDB = objFile.IDB;

            // tạo file scan
            objFile.PageID = classSubjectID;
            objFile.PageNo = pageNo;
            objFile.CreatedUser = UserSession.Username;
            if (!objFile.Add())
            {
                ErrorManager.Error("Việc tạo file scan bị lỗi!");
                return null;
            }

            // chi tiết file scan 
            objFileDetail.ScanMarkID = objFile.ScanMarkID;
            int intOrderIndex = 0;
            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = dtbData.Rows[i];
                objFileDetail.OrderIndex = intOrderIndex++;
                objFileDetail.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);
                if (!objFileDetail.Add())
                {
                    ErrorManager.Error("Việc tạo nội dung file scan bị lỗi!");
                    return null;
                }
            }
            objFile.CommitTransaction();
            return objFile.ScanMarkID;
        }

        public void QuickLoadData(long? classSubjectID, string classID = null, int? yearID = null, int? semester = null)
        {
            if (!uClass.IsInit)
                LoadReferenceData();

            // khác mới phải reset full
            if (uClass.ClassIDEditValue != classID || uClass.YearID != yearID || uClass.Semester != semester)
                uClass.Reset();

            uClass.YearID = yearID;
            uClass.Semester = semester;
            uClass.ClassIDEditValue = classID;

            if (classSubjectID != null)
            {
                uClass.ClassSubjectIDEditValue = classSubjectID;
            }

            if (uClass.ClassSubjectIDEditValue != null)
            {
                btnSearch_Click(null, null);
            }
        }

        /// <summary>
        /// Đăng ký nhanh sv vào sổ điểm này
        /// </summary>
        /// <returns></returns>
        private bool QuickRegister()
        {
            if (dtbData == null)
            {
                MessageManager.Warning("Bạn phải tải sổ điểm trước khi thêm đăng ký học!");
                return false;
            }

            Student.frmSelectStudent frm = Student.frmSelectStudent.Instance;
            frm.ISMultiSelect = true;
            frm.ShowDialog();
            if (frm.IsOk)
            {
                SIM_SubjectMark obj = new SIM_SubjectMark();
                obj.BeginTransaction();

                string strActionLog = "";

                List<SIM_Student> lst = frm.ListSelected;
                foreach (SIM_Student item in lst)
                {
                    if (dtbData.Select("StudentID=" + item.StudentID.ToString()).Length == 0)
                    {
                        SIM_SubjectMark itemSubjectMark = new SIM_SubjectMark();
                        itemSubjectMark.IDB = obj.IDB;

                        itemSubjectMark.StudentID = item.StudentID; // sinh viên
                        itemSubjectMark.ClassSubjectID = uClass.ClassSubjectIDEditValue; // môn học lớp (nếu ghép hay tách thì store tự xử lý lưu sổ điểm về lớp gốc)
                        itemSubjectMark.CreatedUser = UserSession.Username;

                        if (!itemSubjectMark.QuickRegister(true)) // quản lý đăng ký bỏ qua kiểm tra FinishRegister
                        {
                            ErrorManager.Error("Không thể đăng ký học cho <" + item.StudentCode + " - " + item.StudentFirstName + " " + item.StudentLastName + ">!\r\n" + itemSubjectMark.ErrorException.Message);
                            return false;
                        }

                        strActionLog += "Sinh viên: " + item.StudentCode + " - " + item.StudentFirstName + " " + item.StudentLastName + "\r\n";
                    }
                }


                // cập nhật lại islast nếu có đăng ký 
                if (strActionLog != "")
                {
                    if (!obj.UpdateIsLast())
                    {
                        ErrorManager.Error("Việc cập nhật sổ điểm bị lỗi!");
                        return false;
                    }
                }

                // commit
                obj.CommitTransaction();

                // write log                
                new SystemObject.SYS_ActionLog().WriteActionLog("Đăng ký nhanh học viên vào sổ điểm", strActionLog, SystemObject.ActionLogType.ADD, 1, UserSession.Username);
                return true;
            }

            return false; // không có làm gì
        }

        /// <summary>
        /// Tổng hợp thống kê xếp loại, tỉ lệ đạt
        /// </summary>
        //private void SummaryStatistic()
        //{
        //    string[] arrStatisticTitle = { "Xuất sắc", "Giỏi", "Khá", "TB Khá", "TB", "Yếu kém", "Đạt", "Không đạt", "Miễn", "Chưa có điểm", "Thi >=5", "Thi <5" };
        //    int[] arrStatisticCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //    foreach (DataRow drw in dtbData.Rows)
        //    {
        //        if (drw["Exam1"].ToString() != "")
        //        {
        //            double dblExam = Convert.ToDouble(drw["Exam1"]);
        //            if (drw["Exam2"].ToString() != "")
        //                if (Convert.ToDouble(drw["Exam2"]) > dblExam)
        //                    dblExam = Convert.ToDouble(drw["Exam2"]);

        //            if (drw["Exam3"].ToString() != "")
        //                if (Convert.ToDouble(drw["Exam3"]) > dblExam)
        //                    dblExam = Convert.ToDouble(drw["Exam3"]);
        //            if (dblExam >= 5)
        //                arrStatisticCount[10]++;
        //            else
        //                arrStatisticCount[11]++;
        //        }

        //        if (drw["IsIgnore"].ToString() == "")
        //            drw["IsIgnore"] = false;

        //        if (Convert.ToBoolean(drw["IsIgnore"]))
        //            arrStatisticCount[8]++;
        //        else if (drw["FinalSummary"].ToString() == "")
        //            arrStatisticCount[9]++;
        //        else
        //        {
        //            double dblFinalSummary = Convert.ToDouble(drw["FinalSummary"]);

        //            bool bolPassed = false;
        //            if(drw["Passed"].ToString()!="")
        //                bolPassed =  Convert.ToBoolean(drw["Passed"]);
        //            if (bolPassed)
        //                arrStatisticCount[7]++;
        //            else
        //                arrStatisticCount[8]++;

        //            if (dblFinalSummary >= 9 && bolPassed)
        //            {
        //                arrStatisticCount[0]++;
        //            }
        //            else if (dblFinalSummary >= 8 && bolPassed)
        //            {
        //                arrStatisticCount[1]++;
        //            }
        //            else if (dblFinalSummary >= 7 && bolPassed)
        //            {
        //                arrStatisticCount[2]++;
        //            }
        //            else if (dblFinalSummary >= 6 && bolPassed)
        //            {
        //                arrStatisticCount[3]++;
        //            }
        //            else if (dblFinalSummary >= 5 && bolPassed)
        //            {
        //                arrStatisticCount[4]++;
        //            }
        //            else
        //                arrStatisticCount[5]++;
        //        }
        //    }

        //    double a = dtbData.Rows.Count;
        //    // Tao table
        //    if (dtbSummary == null)
        //    {
        //        dtbSummary = new DataTable();
        //        dtbSummary.Columns.Add("Title", typeof(string));
        //        dtbSummary.Columns.Add("Quantity", typeof(int));
        //        dtbSummary.Columns.Add("Percent", typeof(double));
        //    }
        //    else
        //        dtbSummary.Clear();
        //    for (int i = 0; i < 12; i++)
        //    {
        //        DataRow drw = dtbSummary.NewRow();
        //        drw["Title"] = arrStatisticTitle[i];
        //        drw["Quantity"] = arrStatisticCount[i];
        //        drw["Percent"] = Math.Round(arrStatisticCount[i] / a * 100, 0);
        //        dtbSummary.Rows.Add(drw);
        //    }
        //    gcSummary.DataSource = dtbSummary;
        //}

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
            {
                if (btnSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi trước khi nạp lại dữ liệu?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return;
                    else if (dlrConfirm == DialogResult.Yes)
                        if (!SaveData())
                            return;// lưu không thành công thì return
                }
                LoadData();
                //new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    LoadData();
                    //new Thread(LoadData).Start();
                    strClassSubjectIDSaved += ";" + objClassSubject.ClassSubjectID.ToString(); // nhớ lại mã môn học lớp để lát lock không cho edit nữa
                }
            }
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                if (drw["IsNotRegister"].ToString() == "")
                    drw["IsNotRegister"] = 0;

                if (!Convert.ToBoolean(drw["IsNotRegister"]))
                {
                    drw["Mark1Number"] = txtMark1Number.EditValueInt32; // theo form, thay gì db có thể chưa lưu
                    drw["Mark2Number"] = txtMark2Number.EditValueInt32;

                    SIM_SubjectMarkService.TotalRow(drw);
                }
                drw["IsEdit"] = 1;
                btnSave.Enabled = mnuItemSave.Enabled = true;
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
                    {
                        e.Value = DBNull.Value;
                        return;
                    }
                    
                    string strValue = e.Value.ToString().Replace(Libs.MyConvert.DigitGroupingSymbol, Libs.MyConvert.DecimalSymbol); // dấu . hay , đều về dấu của số thập phân
                    e.Value = strValue;
                    if (bolIsTextMark)
                    {
                        if (strValue == "1" || strValue == "Đ" || strValue == "D")
                            e.Value = 110;
                        else if (strValue == "0" || strValue == "2" || strValue == "CĐ" || strValue == "CD")
                            e.Value = 100;
                        else
                        {
                            e.ErrorText = "Vui lòng nhập 1 (= D = Đ) hoặc 0 (= 2 = CD = CĐ)";
                            e.Valid = false;
                        }
                    }
                    else
                    {
                        double a = 0;
                        if (double.TryParse(strValue, out a))
                        {
                            if (a > 10 || a < 0)
                            {
                                e.ErrorText = "Vui lòng nhập số từ 0 - 10";
                                e.Valid = false;
                            }
                        }
                    }
                }
            }
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            if (uClass.ClassSubjectIDEditValue != null)
            {
                // tìm xem phải mon TN hông
                DataRow drw = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
                intSpecialType = Convert.ToInt32(drw["SpecialType"]);
                bolIsOldData = Convert.ToBoolean(drw["IsOldData"]);
                strSubjectID = drw["SubjectID"].ToString();
                txtMark1Number.EditValue = drw["Mark1Number"].ToString();
                txtMark2Number.EditValue = drw["Mark2Number"].ToString();

                bolIsGraduationSubject = intSpecialType == Global.SubjectSpecialType.TotNghiepLT
                    || intSpecialType == Global.SubjectSpecialType.TotNghiepTH
                    || intSpecialType == Global.SubjectSpecialType.ChinhTriTotNghiep;
                bolIsTextMark = Convert.ToBoolean(drw["IsTextMark"]);
                bolIsPractice = Convert.ToBoolean(drw["IsPractice"]); // mon co thuc hanh
                intTheoryRatio = Convert.ToInt32(drw["TheoryRatio"]); // hệ số thi LT, TH
                intPracticeRatio = Convert.ToInt32(drw["PracticeRatio"]);
                LoadData();
                //new Thread(LoadData).Start();
            }
            else
            {
                dtbData = null;
                gcData.DataSource = dtbData;
                btnSave.Enabled = mnuItemSave.Enabled = false;
            }
        }

        #endregion

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName == "StudentCode")
            {
                DataRow drw = gvData.GetDataRow(e.RowHandle);
                if (drw != null)
                {
                    if (drw["OrderLearning"].ToString() != "")
                    {
                        int intOrderLearning = Convert.ToInt32(drw["OrderLearning"]);
                        if (intOrderLearning == 2)
                            e.Appearance.BackColor = Color.Yellow;
                        else if (intOrderLearning > 2)
                            e.Appearance.BackColor = Color.OrangeRed;
                    }
                }
            }
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            string strExcelFileName = gvData.QuickExportToExcel();
            if (strExcelFileName != null && strExcelFileName != "")
            {
                string strTitle = "BẢNG ĐIỂM MÔN " + strSubjectID + "-" + uClass.SubjectName.ToUpper()
                    + " _ LỚP " + uClass.ClassIDEditValue
                    + " _ NIÊN HỌC " + uClass.UYearSemester.YearEditValueText + " _ HỌC KÌ " + uClass.Semester.ToString();

                SystemService.SYS_SettingService.AddHeaderAndFooter(strExcelFileName, gvData.RowCount, strTitle);
            }


        }

        private void mnuItemImportFromExcel_Click(object sender, EventArgs e)
        {
            ImportFromExcel();
            //new Thread(ImportFromExcel).Start();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // print danh sach du dieu kien tot nghiep
            DataTable dtbData = (gvData.DataSource as DataView).Table;
            string strreport = "";

            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiem_QC14.repx";
                    break;
                case 40: // trung cấp chuyên nghiệp
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 46: // trung cấp vừa học vừa làm
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC46.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC25.repx";
                    break;
                case 4:
                case 09: // 09 niên chế: tc,cđ 2017
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;
                case 44:
                case 99: // 09 tín chỉ tc,cđ 2017
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09_TinChi.repx";
                    break;
                default:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw["UnitText"].ToString());

            frm.SetParameter("pTheo", drw["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw["PracticeQuantity"].ToString());

            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                DataRow drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatisticTitle" + i.ToString(), drw2["Title"].ToString());
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            frm.Show();
        }

        private void mnu_DanhSachGiuaKy_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
                if (!SaveData())
                    return;
            // print danh sach sinh vien du thi giua ky
            DataTable dtbData = (gvData.DataSource as DataView).Table.Copy();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    drw["Exam1"] = drw["Exam2"] = drw["Exam3"] = DBNull.Value;
                    drw["Summary1"] = drw["Summary2"] = drw["Summary3"] = drw["FinalSummary"] = -1;
                }
            }

            string strreport = "";
            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    {
                        //if (txtMark1Number.EditValueInt32 > 0 && txtMark2Number.EditValueInt32 > 0)
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                        //else if (txtMark1Number.EditValueInt32 == 0 && txtMark2Number.EditValueInt32 > 0)
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        //else
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        break;
                    }
                case 40: // trung cấp chuyên nghiệp  
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 46: // trung cấp vừa học vừa làm
                case 22:
                    //strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC22.repx";
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC25.repx";
                    break;
                case 4:
                case 9: // tc, cd chuyên nghiệp 2017
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;

                default: strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;
            }


            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw2 = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw2["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw2["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw2["UnitText"].ToString());

            frm.SetParameter("pTheo", drw2["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw2["PracticeQuantity"].ToString());

            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatisticTitle" + i.ToString(), drw2["Title"].ToString());
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            frm.Show();
        }

        private void mnuItemExportTemplateExcel_Click(object sender, EventArgs e)
        {
            Hashtable hstReplaceValues = new Hashtable();
            hstReplaceValues.Add("{Khoa}", uClass.ScienceName);
            hstReplaceValues.Add("{Ngành}", uClass.SpecialBranchName);
            hstReplaceValues.Add("{Lớp}", uClass.ClassName);
            hstReplaceValues.Add("{MaMôn}", uClass.ClassSubjectIDEditValue);
            hstReplaceValues.Add("{Môn}", uClass.SubjectName);
            hstReplaceValues.Add("{Niên}", uClass.UYearSemester.YearEditValueText);
            hstReplaceValues.Add("{Kì}", uClass.Semester);

            if (objClassSubject.TeachingBy != "")
            {
                BO.SIM_Teacher itemTeacher = new DataAccess.SIM_TeacherDAO().Get(objClassSubject.TeachingBy);
                if (itemTeacher != null)
                    hstReplaceValues.Add("{Giáo viên}", itemTeacher.TeacherFirstName + " " + itemTeacher.TeacherLastName);
            }
            hstReplaceValues.Add("{Hệ số môn}", objClassSubject.UnitText);
            hstReplaceValues.Add("{LT}", objClassSubject.TheoryQuantity);
            hstReplaceValues.Add("{TH}", objClassSubject.PracticeQuantity);
            hstReplaceValues.Add("{Tổng giờ}", objClassSubject.TheoryQuantity + objClassSubject.PracticeQuantity);
            hstReplaceValues.Add("{Số Giờ Khung}", objClassSubject.TheoryQuantity + objClassSubject.PracticeQuantity + (objClassSubject.TestQuantity == null ? 0 : objClassSubject.TestQuantity));
            switch (uClass.RegulationID.Value)
            {
                case 14:
                    if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "\\MauExcel\\BangDiem\\Bang ghi diem qua trinh_14.xls", Application.StartupPath + "\\MauExcel\\BangDiem"))
                        MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
                    break;
                case 40:
                    if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "\\MauExcel\\BangDiem\\Bang ghi diem qua trinh_40_22.xls", Application.StartupPath + "\\MauExcel\\BangDiem"))
                        MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
                    break;
                case 22:
                    if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "\\MauExcel\\BangDiem\\Bang ghi diem qua trinh_40_22.xls", Application.StartupPath + "\\MauExcel\\BangDiem"))
                        MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
                    break;
                case 09:
                case 99:
                    if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "\\MauExcel\\BangDiem\\Bang ghi diem qua trinh_09.xls", Application.StartupPath + "\\MauExcel\\BangDiem"))
                        MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
                    break;
                default:
                    if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "\\MauExcel\\BangDiem\\Bang ghi diem qua trinh_40_22.xls", Application.StartupPath + "\\MauExcel\\BangDiem"))
                        MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
                    break;
            }

            
        }

        private void mnu_DanhSachCuoiKy_Click(object sender, EventArgs e)
        {
            // print danh sach sinh vien du thi giua ky
            DataTable dtbData = (gvData.DataSource as DataView).Table.Copy();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    drw["Exam1"] = drw["Exam2"] = drw["Exam3"] = DBNull.Value;
                    drw["Summary1"] = drw["Summary2"] = drw["Summary3"] = drw["FinalSummary"] = -1;
                }
            }
            string strreport = "";
            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    {
                        if (txtMark1Number.EditValueInt32 > 0 && txtMark2Number.EditValueInt32 > 0)
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet_QC40.repx";
                        else if (txtMark1Number.EditValueInt32 == 0 && txtMark2Number.EditValueInt32 > 0)
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet_QC14.repx";
                        else
                            strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet_QC40.repx";
                        break;
                    }
                case 40: // trung cấp chuyên nghiệp                    
                case 46: // trung cấp vừa học vừa làm
                case 22:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet_QC22.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC25.repx";
                    break;
                case 9:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet_QC09.repx";
                    break;
                default:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet_QC09.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw2 = uClass.ClassSubject.Select("ClassSubjectID = " +uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw2["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw2["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw2["UnitText"].ToString());

            frm.SetParameter("pTheo", drw2["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw2["PracticeQuantity"].ToString());

            for (int i = 0; i <= 5; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            int j = 6;
            for (int i = 10; i <= 11; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatistic" + j.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + j.ToString() + j.ToString(), drw2["Percent"].ToString() + " %");
                j++;
            }


            frm.Show();
        }

        private void frmSubjectMark_FormClosing(object sender, FormClosingEventArgs e)
        {
            LockClassSubject();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn muốn thực sự xoá sổ điểm ở những dòng đang chọn!") == System.Windows.Forms.DialogResult.Yes)
            {
                string strLogDetail = "";

                SIM_SubjectMark obj = new SIM_SubjectMark();
                obj.BeginTransaction();

                foreach (int i in gvData.GetSelectedRows())
                {
                    if (gvData.GetDataRow(i)["SubjectMarkID"].ToString() != "")
                    {
                        obj.SubjectMarkID = Convert.ToInt64(gvData.GetDataRow(i)["SubjectMarkID"]);
                        if (!obj.Delete())
                        {
                            if (obj.ErrorException.ToString().Contains("SIM_ExamSchedule"))
                                ErrorManager.Error("Môn này đã được tổ chức thi! Vui lòng xoá tổ chức thi trước khi xoá sổ điểm!");
                            else
                                ErrorManager.Error("Việc xoá sổ điểm bị lỗi!");
                            return;
                        }

                        // nhớ log
                        strLogDetail += "Sinh viên: " + gvData.GetDataRow(i)["StudentCode"] + " - " + gvData.GetDataRow(i)["StudentFirstName"] + " " + gvData.GetDataRow(i)["StudentLastName"] + "\r\n";
                    }
                }
                if (!obj.UpdateIsLast())
                {
                    ErrorManager.Error("Việc xoá sổ điểm bị lỗi!");
                    return;
                }
                obj.CommitTransaction();
                gvData.DeleteSelectedRows();
                btnSave.Enabled = mnuItemSave.Enabled = false;

                // ghi log
                string strActionLog = "Môn học: " + uClass.SubjectName + "\r\n" +
                                  "Lớp học: " + uClass.ClassIDEditValue + "\r\n" +
                                  "Niên học: " + uClass.UYearSemester.YearEditValueText + "\r\n" +
                                  "Học kì: " + uClass.Semester.ToString() + "\r\n\r\n" +
                                  strLogDetail;

                new SystemObject.SYS_ActionLog().WriteActionLog("Xóa Sổ điểm", strActionLog, SystemObject.ActionLogType.DEL, 4, UserSession.Username);
            }
        }

        private void mnuItemPrintScan_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
                if (!SaveData())
                    return;
            btnSave.Enabled = mnuItemSave.Enabled = false; // đã save

            // Tạo một file scan mới. Lưu đầy đủ giá trị và số thứ tự sinh viên vào dữ liệu file scan
            string strPage = (sender as ToolStripMenuItem).Name;
            int intPageNo = Convert.ToInt32(strPage.Substring(strPage.Length - 1));

            long? lngScanMarkID = SaveForScan(uClass.ClassSubjectIDEditValue.Value, intPageNo);
            if (lngScanMarkID != null)
            {
                // print danh sach sinh vien kiểm tra định kỳ 
                string strreport = strreport = "Report/StudentManager/Learning/Leaning_DiemQuaTrinh_Scan.repx";
                SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

                frm.SetParameter("par_Class", uClass.ClassIDEditValue);
                frm.SetParameter("par_Semester", uClass.Semester);
                frm.SetParameter("par_Year", uClass.UYearSemester.YearEditValueText);

                //Truyen tham so tinh trung binh, ti le phan tram            
                frm.SetParameter("par_Subject", uClass.SubjectName);
                frm.SetParameter("par_Recognize", lngScanMarkID); // dùng mã file scan để làm mã nhận dạng
                frm.SetParameter("par_Page", intPageNo); // dùng mã file scan để làm mã nhận dạng
                frm.SetParameter("par_HaveDigits", uClass.RegulationID == 14 ? "1" : ""); // 14 moi co so lẻ     
                frm.SetParameter("par_PrintDate", DateTime.Now.ToString("dd / MM / yyyy"));
                frm.Show();
            }
        }

        private void gvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{DOWN}");
        }

        private void mnuItemPrint_DiemQuaTrinh_Click(object sender, EventArgs e)
        {
            // print danh sach sinh vien du thi giua ky
            DataTable dtbData = (gvData.DataSource as DataView).Table.Copy();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    drw["Exam1"] = drw["Exam2"] = drw["Exam3"] = DBNull.Value;
                    drw["Summary1"] = drw["Summary2"] = drw["Summary3"] = drw["FinalSummary"] = -1;
                }
            }

            string strreport = "Report/StudentManager/Learning/Leaning_BangDiemQuaTrinh_NH.repx";
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw2 = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw2["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw2["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw2["UnitText"].ToString());

            frm.SetParameter("pTheo", drw2["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw2["PracticeQuantity"].ToString());

            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatisticTitle" + i.ToString(), drw2["Title"].ToString());
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            frm.Show();
        }

        private void mnuItemDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn muốn thực sự xoá sổ điểm của môn học lớp này?") == System.Windows.Forms.DialogResult.Yes)
            {
                SIM_SubjectMark obj = new SIM_SubjectMark();
                obj.ClassSubjectID = objClassSubject.ClassSubjectID;
                obj.BeginTransaction();
                if (!obj.DeleteOfClassSubject())
                {
                    if (obj.ErrorException.ToString().Contains("SIM_ExamSchedule"))
                        ErrorManager.Error("Môn này đã được tổ chức thi! Vui lòng xoá tổ chức thi trước khi xoá sổ điểm!");
                    else
                        ErrorManager.Error("Việc xoá sổ điểm bị lỗi!");
                    return;
                }

                if (!obj.UpdateIsLast())
                {
                    ErrorManager.Error("Việc xoá sổ điểm bị lỗi!");
                    return;
                }
                obj.CommitTransaction();
                gvData.DeleteSelectedRows();
                btnSave.Enabled = mnuItemSave.Enabled = false;

                // ghi log
                string strActionLog = "Môn học: " + uClass.SubjectName + "\r\n" +
                                  "Lớp học: " + uClass.ClassIDEditValue + "\r\n" +
                                  "Niên học: " + uClass.UYearSemester.YearEditValueText + "\r\n" +
                                  "Học kì: " + uClass.Semester.ToString();

                new SystemObject.SYS_ActionLog().WriteActionLog("Xóa tất cả Sổ điểm", strActionLog, SystemObject.ActionLogType.DEL, 5, UserSession.Username);

            }
        }

        private void mnuItemPrint_TongKet2_Click(object sender, EventArgs e)
        {
            // print danh sach sinh vien du thi giua ky
            DataTable dtbData = (gvData.DataSource as DataView).Table.Copy();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    drw["Exam1"] = drw["Exam2"] = drw["Exam3"] = DBNull.Value;
                    drw["Summary1"] = drw["Summary2"] = drw["Summary3"] = drw["FinalSummary"] = -1;
                }
            }

            string strreport = "";
            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC14.repx";
                    break;
                case 40: // trung cấp chuyên nghiệp                    
                case 46: // trung cấp vừa học vừa làm
                case 22:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC22.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC25.repx";
                    break;
                case 4:
                case 09: // TC, CĐ chuyên nghiệp 2017
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC09.repx";
                    break;
                case 44:
                case 99: // TC, CĐ chuyên nghiệp 2017 (tín chỉ)
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC09_TinChi.repx";
                    break;
                default: strreport = "Report/StudentManager/Learning/Leaning_BangDiemTongKet2_QC09.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassIDEditValue);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw2 = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw2["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw2["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw2["UnitText"].ToString());

            frm.SetParameter("pTheo", drw2["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw2["PracticeQuantity"].ToString());

            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatisticTitle" + i.ToString(), drw2["Title"].ToString());
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            frm.Show();
        }

        private void gvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.AbsoluteIndex > 4)
            {
                if (bolIsTextMark)
                {
                    if (e.CellValue != null)
                    {
                        if (e.CellValue.ToString() == "110")
                            e.DisplayText = "Đ";
                        else if (e.CellValue.ToString() == "100")
                            e.DisplayText = "CĐ";
                    }
                }
            }
        }

        private void mnu_IsReLearning_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
                if (!SaveData())
                    return;
            // print danh sach sinh vien du thi giua ky
            DataTable dtbData = (gvData.DataSource as DataView).Table.Copy();
            dtbData.DefaultView.RowFilter = "OrderLearning = 2";
            dtbData = dtbData.DefaultView.ToTable();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    drw["Exam1"] = drw["Exam2"] = drw["Exam3"] = DBNull.Value;
                    drw["Summary1"] = drw["Summary2"] = drw["Summary3"] = drw["FinalSummary"] = -1;
                }
            }

            string strreport = "";
            switch (uClass.RegulationID)
            {
                case 14: // cao đẳng, tc nghề
                    {
                        //if (txtMark1Number.EditValueInt32 > 0 && txtMark2Number.EditValueInt32 > 0)
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                        //else if (txtMark1Number.EditValueInt32 == 0 && txtMark2Number.EditValueInt32 > 0)
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        //else
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        break;
                    }
                case 40: // trung cấp chuyên nghiệp  
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 46: // trung cấp vừa học vừa làm
                case 22:
                    //strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC22.repx";
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC25.repx";
                    break;
                case 4:
                case 9: // tc, cđ 2017 (09 niên chế)
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;
                default:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                    break;
            }
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw2 = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw2["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw2["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw2["UnitText"].ToString());

            frm.SetParameter("pTheo", drw2["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw2["PracticeQuantity"].ToString());

            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatisticTitle" + i.ToString(), drw2["Title"].ToString());
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            frm.Show();
        }

        private void mnu_IsRetest_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled)
                if (!SaveData())
                    return;
            // print danh sach sinh vien du thi giua ky
            DataTable dtbData = (gvData.DataSource as DataView).Table.Copy();
            dtbData.DefaultView.RowFilter = "Exam2 >= 0";
            dtbData = dtbData.DefaultView.ToTable();
            foreach (DataRow drw in dtbData.Rows)
            {
                if (Convert.ToBoolean(drw["IsIgnore"]))
                {
                    drw["Exam1"] = drw["Exam2"] = drw["Exam3"] = DBNull.Value;
                    drw["Summary1"] = drw["Summary2"] = drw["Summary3"] = drw["FinalSummary"] = -1;
                }
            }

            string strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
            switch (uClass.RegulationID.Value)
            {
                case 14: // cao đẳng, tc nghề
                    {
                        //if (txtMark1Number.EditValueInt32 > 0 && txtMark2Number.EditValueInt32 > 0)
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                        //else if (txtMark1Number.EditValueInt32 == 0 && txtMark2Number.EditValueInt32 > 0)
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        //else
                        //    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC14.repx";
                        break;
                    }
                case 40: // trung cấp chuyên nghiệp  
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 46: // trung cấp vừa học vừa làm
                case 22:
                    //strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC22.repx";
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC40.repx";
                    break;
                case 43: // tín chỉ
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC43.repx";
                    break;
                case 25:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemGiuaKy_QC25.repx";
                    break;
                case 4:
                case 9: // tc, cđ 2017
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;
                case 44:
                case 99: // 09 tín chỉ tc,cđ 2017
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09_TinChi.repx";
                    break;
                default:
                    strreport = "Report/StudentManager/Learning/Leaning_BangDiemChiTiet_QC09.repx";
                    break;                
            }

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, strreport, false);

            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);

            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pSemester", uClass.Semester);
            frm.SetParameter("pYearID", uClass.UYearSemester.YearEditValueText);

            //Truyen tham so tinh trung binh, ti le phan tram
            DataRow drw2 = uClass.ClassSubject.Select("ClassSubjectID = " + uClass.ClassSubjectIDEditValue.ToString())[0];
            frm.SetParameter("pSubject", drw2["SubjectName"].ToString());
            frm.SetParameter("pClassShortName", drw2["ClassShortName"].ToString());
            frm.SetParameter("pUnitText", drw2["UnitText"].ToString());

            frm.SetParameter("pTheo", drw2["TheoryQuantity"].ToString());
            frm.SetParameter("pPrac", drw2["PracticeQuantity"].ToString());

            for (int i = 0; i < dtbSummary.Rows.Count; i++)
            {
                drw2 = dtbSummary.Rows[i];
                frm.SetParameter("pStatisticTitle" + i.ToString(), drw2["Title"].ToString());
                frm.SetParameter("pStatistic" + i.ToString(), drw2["Quantity"].ToString());
                frm.SetParameter("pStatistic" + i.ToString() + i.ToString(), drw2["Percent"].ToString() + " %");
            }

            frm.Show();
        }       

        private void mnuItem_QuickRegister_Click(object sender, EventArgs e)
        {
            if (QuickRegister()) // đăng ký nhanh học viên vào sổ điểm
            {
                LoadData();
                MessageManager.Info("Đã đăng ký thành công!");
            }
        }

        private void mnuItemReTotalRow_Click(object sender, EventArgs e)
        {
            if (dtbData != null && dtbData.Rows.Count > 0)
            {
                foreach (DataRow drw in dtbData.Rows)
                {
                    if (drw["IsNotRegister"].ToString() == "")
                        drw["IsNotRegister"] = 0;

                    if (!Convert.ToBoolean(drw["IsNotRegister"]))
                    {
                        drw["Mark1Number"] = txtMark1Number.EditValueInt32; // theo form, thay gì db có thể chưa lưu
                        drw["Mark2Number"] = txtMark2Number.EditValueInt32;
                        drw["IsEdit"] = 1;//phải bật edit để lưu
                        SIM_SubjectMarkService.TotalRow(drw);
                    }
                }

                btnSave.Enabled = mnuItemSave.Enabled = true;
                MessageManager.Info("Đã xử lý điểm thành công!\r\nTuy nhiên dữ liệu vẫn chưa được lưu cho tới khi bạn nhấn Cập nhật!");
            }
        }
    }
}

