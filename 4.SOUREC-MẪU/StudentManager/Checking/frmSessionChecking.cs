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
    public partial class frmSessionChecking : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_SessionChecking_Edit";
        public const string PERMISSION_VIEW = "SIM_SessionChecking_View";

        #endregion

        #region Variables

        private DataTable dtbData;
        private string strClassID = "";             
         
        #endregion

        #region IForm Members

        private static frmSessionChecking _instance = null;

        public static frmSessionChecking Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSessionChecking();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSessionChecking()
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
                chkSession_CheckedChanged(null, null);
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
                gbDate.Caption = dtm.ToString("dd/MM/yyyy");
                gbDate.Name = "gbDate" + dtm.ToString("dd_MM_yyyy");                

                gvData.Bands.Add(gbDate);

                for (int i = 1; i <= 6; i++)
                {
                    BandedGridColumn gcolSession = new BandedGridColumn();
                    gvData.Columns.Add(gcolSession);
                    gbDate.Columns.Add(gcolSession);
                    
                    string strFieldName = "Session_" + dtm.ToString("dd_MM_yyyy") + "_" + i.ToString();                    
                    gcolSession.Caption = "C" + i.ToString();
                    gcolSession.Name = "gcolSession" + i.ToString();
                    gcolSession.FieldName =strFieldName;
                    gcolSession.Visible = true;
                    gcolSession.Width = 10;                    
                    gcolSession.VisibleIndex = intIndex++;
                    
                    DevExpress.XtraEditors.Repository.RepositoryItemComboBox repository = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
                    //repository.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    repository.Items.Add("");
                    repository.Items.Add("P");
                    repository.Items.Add("K");
                    gcolSession.ColumnEdit = repository;                    
                    
                    // add DataTable
                    dtbData.Columns.Add(strFieldName, typeof(string));
                }

                dtm = dtm.AddDays(1);
                //while (dtm.DayOfWeek == DayOfWeek.Saturday || dtm.DayOfWeek == DayOfWeek.Sunday)
                //    dtm = dtm.AddDays(1);

                
            }            
        }

        private void FillData()
        {
            SIM_DateChecking obj = new SIM_DateChecking();
            DataTable dtbDateChecking = obj.SearchForSessionChecking("@ClassID", uClass.ClassIDEditValue,
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
                        string strFieldName = "Session_" + Convert.ToDateTime(row["Date"]).ToString("dd_MM_yyyy_");
                        for (int i = 1; i <= 6; i++)
                            drw[strFieldName + i.ToString()] = row["Session" + i.ToString()].ToString();
                    }
                }
            }
            else
                ErrorManager.Error("Việc lấy thông tin điểm danh theo ca bị lỗi!");
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
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    btnSave.Enabled = mnuItemSave.Enabled = false;                    
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
            if (!uYearSemester.IsValidData())
                return false;

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
                if (drw["IsEdit"].ToString() == "1" || chkIsUpdateAll.Checked)
                {
                    obj.StudentID = Convert.ToInt64(drw["StudentID"]);

                    // quét hết các cột ngày
                    foreach (GridBand band in gvData.Bands)
                    {
                        if (band.Name.Contains("gbDate"))
                        {
                            string[] a = band.Caption.Split('/');
                            obj.Date = new DateTime(Convert.ToInt32(a[2]), Convert.ToInt32(a[1]), Convert.ToInt32(a[0]));                            
                            string strFieldName = "Session_" + band.Caption.Replace("/", "_");
                            obj.Session1 = drw[strFieldName + "_1"].ToString();
                            obj.Session2 = drw[strFieldName + "_2"].ToString();
                            obj.Session3 = drw[strFieldName + "_3"].ToString();
                            obj.Session4 = drw[strFieldName + "_4"].ToString();
                            obj.Session5 = drw[strFieldName + "_5"].ToString();
                            obj.Session6 = drw[strFieldName + "_6"].ToString();      
                            if (!obj.SessionCheckingEdit())
                            {
                                ErrorManager.Error("Việc cập nhật điểm danh ca bị lỗi!");
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
            if (e.RowHandle % 2 == 1)
            {
                if (e.Column.Caption == "C3" || e.Column.Caption == "C4")
                    e.Appearance.BackColor = Color.LightBlue;
                else if (e.Column.Caption == "C5")
                    e.Appearance.BackColor = Color.LightGreen;
            }
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value != null)
            {
                string str = e.Value.ToString().ToUpper();
                if (str != "P" && str != "K" && str != "")
                    e.Value = "";
            }
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        /// <summary>
        /// Hiển thị buổi cần điểm danh
        /// "Session_" + dtm.ToString("dd_MM_yyyy") + "_" + i.ToString();                    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSession_CheckedChanged(object sender, EventArgs e)
        {
            foreach (BandedGridColumn col in gvData.Columns)
            {
                if (col.FieldName.Contains("Session_"))
                {
                    string strSession = col.FieldName.Substring(col.FieldName.Length - 1);
                    switch (strSession)
                    {
                        case "1":
                        case "2":
                            col.Visible = chkIsMorning.Checked;
                            break;
                        case "3":
                        case "4":
                            col.Visible = chkIsAfternoon.Checked;
                            break;
                        case "5":
                        case "6":
                            col.Visible = chkIsEvening.Checked;
                            break;
                    }
                }

            }
        }
    }
}