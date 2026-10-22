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

namespace StudentManager.Checking
{
    public partial class frmDateCheckingMulti : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_DateChecking_Edit";
        public const string PERMISSION_VIEW = "SIM_DateChecking_View";

        #endregion

        #region Variables

        private DataTable dtbData;
        private string strClassID = "";             
         
        #endregion

        #region IForm Members

        private static frmDateCheckingMulti _instance = null;

        public static frmDateCheckingMulti Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmDateCheckingMulti();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmDateCheckingMulti()
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
                uYearSemester.InitData();

            }
        }

        public void LoadData()
        {
            SIM_Student obj = new SIM_Student();
            dtbData = obj.SearchSimpleList("@ClassID", uClass.ClassIDEditValue);
            dtbData.Columns.Add("IsEdit", typeof(int));

            if (dtbData != null)
            {
                gcData.DataSource = dtbData;

                ModifyGridAndData();
                FillData();
                gvData.SetOrder("Order");
                gvData.BestFitColumns();

                //Nhớ lại giá trị khóa để save
                strClassID = uClass.ClassIDEditValue.ToString();

                mnuItemSave.Enabled = btnSave.Enabled = false; // load lại thì không cần save 
                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
            }
            else
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
        }

        // Add cột vào table và lưới
        private void ModifyGridAndData()
        {
            gvData.Columns.Clear();
            gvData.Bands.Clear();

            #region Student

            GridBand gbStudent = new GridBand();
            gbStudent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbStudent.AppearanceHeader.Options.UseFont = true;
            gbStudent.Caption = "SINH VIÊN";
            gbStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gbStudent.Name = "gbStudent";
            gbStudent.Width = 411;

            BandedGridColumn gcolOrder = new BandedGridColumn();
            BandedGridColumn gcolStudentCode = new BandedGridColumn();
            BandedGridColumn gcolStudentFirstName = new BandedGridColumn();
            BandedGridColumn gcolStudentLastName = new BandedGridColumn();
            BandedGridColumn gcolBirthDateText = new BandedGridColumn();
            BandedGridColumn gcolGenderText = new BandedGridColumn();

            gvData.Bands.Add(gbStudent);

            gvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            gcolOrder,
            gcolStudentCode,
            gcolStudentFirstName,
            gcolStudentLastName,
            gcolBirthDateText,
            gcolGenderText});

            gbStudent.Columns.Add(gcolOrder);
            gbStudent.Columns.Add(gcolStudentCode);
            gbStudent.Columns.Add(gcolStudentFirstName);
            gbStudent.Columns.Add(gcolStudentLastName);
            gbStudent.Columns.Add(gcolBirthDateText);
            gbStudent.Columns.Add(gcolGenderText);


            // 
            // gcolOrder
            // 
            gcolOrder.Caption = "STT";
            gcolOrder.FieldName = "Order";
            gcolOrder.Name = "gcolOrder";
            gcolOrder.OptionsColumn.AllowEdit = false;
            gcolOrder.Visible = true;
            gcolOrder.VisibleIndex = 0;
            // 
            // gcolStudentCode
            // 
            gcolStudentCode.AppearanceCell.Options.UseTextOptions = true;
            gcolStudentCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolStudentCode.Caption = "Mã SV";
            gcolStudentCode.FieldName = "StudentCode";
            gcolStudentCode.Name = "gcolStudentCode";
            gcolStudentCode.OptionsColumn.AllowEdit = false;
            gcolStudentCode.Visible = true;
            gcolStudentCode.VisibleIndex = 1;
            // 
            // gcolStudentFirstName
            // 
            gcolStudentFirstName.Caption = "Họ đệm";
            gcolStudentFirstName.FieldName = "StudentFirstName";
            gcolStudentFirstName.Name = "gcolStudentFirstName";
            gcolStudentFirstName.OptionsColumn.AllowEdit = false;
            gcolStudentFirstName.Visible = true;
            gcolStudentFirstName.VisibleIndex = 2;
            // 
            // gcolStudentLastName
            // 
            gcolStudentLastName.Caption = "Tên";
            gcolStudentLastName.FieldName = "StudentLastName";
            gcolStudentLastName.Name = "gcolStudentLastName";
            gcolStudentLastName.OptionsColumn.AllowEdit = false;
            gcolStudentLastName.Visible = true;
            gcolStudentLastName.VisibleIndex = 3;
            // 
            // gcolBirthDateText
            // 
            gcolBirthDateText.AppearanceCell.Options.UseTextOptions = true;
            gcolBirthDateText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolBirthDateText.Caption = "Ngày sinh";
            gcolBirthDateText.FieldName = "BirthDateText";
            gcolBirthDateText.Name = "gcolBirthDateText";
            gcolBirthDateText.OptionsColumn.AllowEdit = false;
            gcolBirthDateText.Visible = true;
            gcolBirthDateText.VisibleIndex = 4;
            // 
            // gcolGenderText
            // 
            gcolGenderText.AppearanceCell.Options.UseTextOptions = true;
            gcolGenderText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gcolGenderText.Caption = "Giới tính";
            gcolGenderText.FieldName = "GenderText";
            gcolGenderText.Name = "gcolGenderText";
            gcolGenderText.OptionsColumn.AllowEdit = false;
            gcolGenderText.Visible = true;
            gcolGenderText.VisibleIndex = 5;



            #endregion

            int intIndex = 6;
            DateTime dtm = dtmFromDate.EditValueDateTime.Value;
            DateTime dtmTo = dtmToDate.EditValueDateTime.Value;
            while (dtm <= dtmTo)
            {
                // 
                // gbDate
                // 
                GridBand gbDate = new GridBand();
                gbDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                gbDate.AppearanceHeader.Options.UseFont = true;
                gbDate.Caption = dtm.ToString("MM");
                gbDate.Name = "gbDate" + dtm.ToString("dd_MM_yyyy");

                gvData.Bands.Add(gbDate);


                BandedGridColumn gcolSession = new BandedGridColumn();
                gvData.Columns.Add(gcolSession);
                gbDate.Columns.Add(gcolSession);

                string strFieldName = "Date_" + dtm.ToString("dd_MM_yyyy");
                gcolSession.Caption = dtm.ToString("dd"); ;
                gcolSession.Name = "gcol" + strFieldName;
                gcolSession.FieldName = strFieldName;
                gcolSession.Visible = true;
                gcolSession.Width = 30;
                gcolSession.VisibleIndex = intIndex++;               

                DevExpress.XtraEditors.Repository.RepositoryItemComboBox repository = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                repository.Items.Add("");
                repository.Items.Add("P");
                repository.Items.Add("K");
                gcolSession.ColumnEdit = repository;

                // add DataTable
                dtbData.Columns.Add(strFieldName, typeof(string));

                dtm = dtm.AddDays(1);
                //while (dtm.DayOfWeek == DayOfWeek.Saturday || dtm.DayOfWeek == DayOfWeek.Sunday)
                //    dtm = dtm.AddDays(1);

            }

            // cột tổng
            // 
            // gbDate
            // 
            GridBand gbTotal = new GridBand();
            gbTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            gbTotal.AppearanceHeader.Options.UseFont = true;
            gbTotal.Caption = "Tổng";
            gbTotal.Name = "gbTotal";

            gvData.Bands.Add(gbTotal);


            BandedGridColumn gcolTotal = new BandedGridColumn();
            gvData.Columns.Add(gcolTotal);
            gbTotal.Columns.Add(gcolTotal);

            gcolTotal.Caption = "Tổng";
            gcolTotal.Name = "gcolTotal";
            gcolTotal.FieldName = "Total";
            gcolTotal.Visible = true;
            gcolTotal.Width = 30;
            gcolTotal.VisibleIndex = intIndex++;
            gcolTotal.OptionsColumn.AllowEdit = false;
            gcolTotal.AppearanceCell.BackColor = SystemColors.Info;
            gcolTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gcolTotal.DisplayFormat.FormatString = "#,###";

            // add DataTable
            dtbData.Columns.Add("Total", typeof(int));
            dtbData.Columns.Add("SortColumn", typeof(int)); // cot sort uu tien de luc nao dong tong cung o duoi cung
        }
            

        private void FillData()
        {
            SIM_DateChecking obj = new SIM_DateChecking();
            DataTable dtbDateChecking = obj.SearchForDateCheckingMulti("@ClassID", uClass.ClassIDEditValue,
                                                                    "@FromDate", dtmFromDate.EditValueDateTime,
                                                                    "@ToDate", dtmToDate.EditValueDateTime);
            if (dtbDateChecking != null)
            {
                // quét tất cả sinh viên
                foreach (DataRow drw in dtbData.Rows)
                {                    
                    // tìm hết điểm danh của sinh viên đó
                    DataRow[] rows = dtbDateChecking.Select("StudentID = '" + drw["StudentID"].ToString() + "'");
                    foreach (DataRow row in rows)
                    {
                        string strFieldName = "Date_" + Convert.ToDateTime(row["Date"]).ToString("dd_MM_yyyy");
                        if (row[SIM_DateChecking.C_PermissionQuantity].ToString() != "")
                            drw[strFieldName] = "P";
                        else if (row[SIM_DateChecking.C_NoPermissionQuantity].ToString() != "")
                            drw[strFieldName] = "K";
                        else
                            drw[strFieldName] = DBNull.Value;
                    }
                }
                
                // thêm dòng tổng
                DataRow drwTotal = dtbData.NewRow();
                dtbData.Rows.Add(drwTotal);
                drwTotal["StudentCode"] = "Tổng";
                drwTotal["SortColumn"] = "1";

                // tính lại tổng
                for(int i=0;i<dtbData.Rows.Count - 1;i++)
                    foreach (BandedGridColumn col in gvData.Columns)
                    {
                        CalculatorTotal(i, col.FieldName, dtbData.Rows[i][col.FieldName]);
                    }

            }
            else
                ErrorManager.Error("Việc lấy thông tin điểm danh ngày bị lỗi!");
        }

        /// <summary>
        /// tính tổng dòng và cột
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="strFieldName"></param>
        private void CalculatorTotal(int rowIndex, string strFieldName, object currentValue)
        {
            int intTotal = 0;
            int intRowCount = dtbData.Rows.Count - 1;
            if (strFieldName.Contains("Date_"))
            {
                // tổng dòng
                foreach (BandedGridColumn col in gvData.Columns)
                {
                    if (col.FieldName != strFieldName)
                    {
                        if (col.FieldName.Contains("Date_"))
                            if (dtbData.Rows[rowIndex][col.FieldName].ToString() != "")
                                intTotal++;
                    }
                }
                // do Validating chua accept cell dang edit nen fai cong them
                if (currentValue.ToString() != "")
                    intTotal++;

                if(intTotal>0)
                    dtbData.Rows[rowIndex]["Total"] = intTotal;
                else
                    dtbData.Rows[rowIndex]["Total"] = DBNull.Value;

                // tổng cột
                intTotal = 0;
                for (int i = 0; i < intRowCount; i++)
                {
                    if (i != rowIndex)
                    {
                        DataRow drw = gvData.GetDataRow(i);
                        if (drw[strFieldName].ToString() != "")
                            intTotal++;
                    }
                }
                if (currentValue.ToString() != "")
                    intTotal++;

                if (intTotal > 0)
                    dtbData.Rows[intRowCount][strFieldName] = intTotal;
                else
                    dtbData.Rows[intRowCount][strFieldName] = DBNull.Value;
            }

            // tính tổng cột tổng xuống dưới cho dòng tổng
            intTotal = 0;
            for (int i = 0; i < intRowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (drw["Total"].ToString() != "")
                    intTotal += Convert.ToInt32(drw["Total"]);
            }
            if (intTotal > 0)
                dtbData.Rows[intRowCount]["Total"] = intTotal;
            else
                dtbData.Rows[intRowCount]["Total"] = DBNull.Value;
        }
                 
        #endregion

        #region Form Actions

        private void frmYearEthicMark_Load(object sender, EventArgs e)
        {
       
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
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (uYearSemester.IsValidData())
            {
                if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
                {
                    if (SaveData())
                    {
                        //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                        btnSave.Enabled = mnuItemSave.Enabled = false;
                    }
                }
            }
        }

        private bool IsValidData()
        {
           
            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }
            if (dtmFromDate.EditValueDateTime == null)
            {
                MessageManager.Warning("Bạn phải chọn ngày bắt đầu!");
                dtmFromDate.Focus();
                return false;
            }
            if (dtmToDate.EditValueDateTime == null)
            {
                MessageManager.Warning("Bạn phải chọn ngày kết thúc!");
                dtmToDate.Focus();
                return false;
            }
            if (dtmFromDate.EditValueDateTime.Value > dtmToDate.EditValueDateTime.Value)
            {
                MessageManager.Warning("Ngày bắt đầu phải <= ngày kết thúc!");
                dtmFromDate.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_DateChecking obj = new SIM_DateChecking();
            obj.BeginTransaction();
            obj.YearID = uYearSemester.YearIDEditValueInt32;
            obj.Semester = uYearSemester.SemesterEditValueInt32;
            obj.UpdatedUser = UserSession.Username;
            // quét tất cả sinh viên
            foreach (DataRow drw in dtbData.Rows)
            {
                if (drw["IsEdit"].ToString() == "1")
                {
                    obj.StudentID = Convert.ToInt64(drw["StudentID"]);
                    
                    // quét hết các cột ngày
                    foreach (BandedGridColumn col in gvData.Columns)
                    {
                        if (col.FieldName.Contains("Date_"))
                        {
                            string[] a = col.FieldName.Replace("Date_","").Split('_');
                            obj.Date = new DateTime(Convert.ToInt32(a[2]), Convert.ToInt32(a[1]), Convert.ToInt32(a[0]));
                            obj.PermissionQuantity = null;
                            obj.NoPermissionQuantity = null;

                            string strFieldName = col.FieldName;
                            if (drw[strFieldName].ToString() == "P")
                                obj.PermissionQuantity = 1;
                            else if (drw[strFieldName].ToString() == "K")
                                obj.NoPermissionQuantity = 1;                                                           
                            if (!obj.DateCheckingMultiEdit())
                            {
                                ErrorManager.Error("Việc cập nhật điểm danh ngày bị lỗi!");
                                return false;
                            }
                        }
                    }
                    drw["IsEdit"] = 0;
                }
            }
            obj.CommitTransaction();
            return true;
        }      

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                drw["IsEdit"] = 1;
                btnSave.Enabled = mnuItemSave.Enabled = true;
            }
        }

        #endregion

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (gvData.GetDataRow(e.RowHandle)["StudentCode"].ToString() == "Tổng")
                e.Appearance.BackColor = SystemColors.Info;
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value != null)
            {
                string str = e.Value.ToString().ToUpper();
                if (str != "P" && str != "K" && str != "")
                    e.Value = "";
            }

            CalculatorTotal(gvData.FocusedRowHandle, gvData.FocusedColumn.FieldName, e.Value);
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void dockPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint1_Click(object sender, EventArgs e)
        {
            // print Sinh vien                        
            DataTable dtb = dtbData.Copy();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, "Report/StudentManager/Student/Student_InDanhDiemDanhNgay.repx", false);
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.Show();
        }
       
    }
}