using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraGrid.Views.BandedGrid;
using Libs;
using Global;
using SimsObject;
using SimsService;

namespace  StudentManager.Checking
{
    public partial class frmAttendanceStatistics : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_VIEW = "SIM_CheckingMulti_View";

        #endregion

        #region Variables

        DataTable dtbDateSchedule = null; // danh sách ngày để tạo cột
        DataTable dtbData = null; // dữ liệu chính của lưới
        DataTable dtbSchedule = null; // dữ liệu kế hoạch
        DataTable dtbStudentChecking = null; // dữ liệu điểm danh
           
        bool bolIsRefresh = false;

        private Color[] arrBackColor = { Color.White, Color.FromArgb(250, 247, 240), Color.FromArgb(246, 238, 197) };
        private Color bgColorData = Color.FromArgb(193, 216, 243); // màu lịch
        private Color foreColorData = Color.FromArgb(0, 0, 0);

        // các giá trị vị trí ô lịch
        long? lngStudentIDPos = null;
        long? lngClassOfStudentIDPos = null;
        int? intClassIDPos = null;
        string strDaysPos = null;
        DateTime? dtmDatePos = null;
        long? lngScheduleIDPos = null;
        long? lngStudentCheckingIDPos = null;
        string strValuePos = null; // nội dung điểm danh
        string  strValueContentPos = null; // nội dung bài học
        #endregion

        #region IForm Members

        private static frmAttendanceStatistics _instance = null;

        public static frmAttendanceStatistics Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmAttendanceStatistics();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmAttendanceStatistics()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền            
            //gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
        }

        private void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {

                if (bolIsRefresh)
                {
                    uClass.RefrehData();
                }
                else
                {
                    uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                    uClass.InitData();
                }

                if (dtmFrom.EditValue == null)
                {
                    dtmFrom.EditValue = DateTime.Now;
                    dtmTo.EditValue = dtmFrom.EditValueDate.Value.AddDays(+30);
                }
            }
        }

        private bool IsValidData()
        {
            if (chkShowAllDate.Checked)
            {
                if (dtmFrom.EditValue == null)
                {
                    MessageManager.Warning("Bạn phải chọn thời điểm bắt đầu!");
                    dtmFrom.Focus();
                    return false;
                }
                if (dtmTo.EditValue == null)
                {
                    MessageManager.Warning("Bạn phải chọn thời điểm kết thúc!");
                    dtmTo.Focus();
                    return false;
                }
            }
            return true;
        }

        private void BeginProcess()
        {
            btnSearch.Enabled = btnPrint.Enabled = false;
            
        }

        private void EndProcess()
        {
            btnSearch.Enabled = true;
            btnPrint.Enabled = mnuItemPrint.Enabled = mnuItemExportToExcel.Enabled = dtbData != null && dtbData.Rows.Count > 0;
            //mnuItemUnCheckDoneAll.Enabled = dtbData != null && dtbData.Rows.Count > 0 && UserSession.HasPermission(PERMISSION_EDIT);
        }

        #endregion

        #region Support Functions 2

        private void Process()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(Process));
            else
            {
                //GetSetting();
                if (ReadData())
                {
                    InitDataAndGrid();
                    //ResetData();
                    FillScheduleData();
                    FillData();
                    gcData.DataSource = dtbData;
                    gvData.BestFitColumns();
                    bolIsRefresh = false;
                }
                
                EndProcess();
            }
        }

        /// <summary>
        /// Khởi tạo cấu trúc dữ liệu và lưới
        /// </summary>
        private void InitDataAndGrid()
        {
            //if (gvData.Columns.Count>0)
            //    if (!bolIsRefresh)
            //        return; // nếu tạo rồi, mà không phải lệnh làm mới thì không cần tạo lại

            gvData.Bands.Clear();
            gvData.Columns.Clear();

            #region  Add Class Columns

            // Thêm  Band
            GridBand gbBandStudent = new GridBand();
            gbBandStudent.Caption = "SINH VIÊN";
            gbBandStudent.AppearanceHeader.Options.UseFont = true;
            gbBandStudent.AppearanceHeader.Options.UseTextOptions = true;
            gbBandStudent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbBandStudent.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbBandStudent.Name = "gbBandStudent";
            gbBandStudent.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gvData.Bands.Add(gbBandStudent);

            string[] fields = { "StudentCode", "StudentFirstName", "StudentLastName",  };
            string[] captions = { "Mã HV", "Họ đệm", "Tên" };
            int[] widths = { 60, 80, 40};
            for (int i = 0; i < fields.Length; i++)
            {
                // gcol              
                BandedGridColumn gcol = new BandedGridColumn();
                gcol.Caption = captions[i];
                gcol.FieldName = fields[i];
                gcol.Name = "gcol" + fields[i];
                gcol.Width = widths[i];
                gcol.Visible = true;
                gcol.VisibleIndex = i;
                gcol.AppearanceHeader.Options.UseFont = true;
                gcol.AppearanceHeader.Options.UseTextOptions = true;
                gcol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcol.AppearanceCell.Options.UseTextOptions = true;
                gcol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                gvData.Columns.Add(gcol);
                gbBandStudent.Columns.Add(gcol);
            }

            #endregion

            #region Add Date columns and Grid

            for (int i = 0; i < dtbDateSchedule.Rows.Count; i++)
            {

                // Add columns
                DataRow drw = dtbDateSchedule.Rows[i];
                drw["DateIndex"] = i; // vị trí phòng trên lưới
                dtbData.Columns.Add("Value_" + i.ToString(), typeof(int));
                //dtbData.Columns.Add("Content_" + i.ToString(), typeof(string));

                DateTime dtmDate = Convert.ToDateTime(drw["Date"]);

                // Thêm  Band
                GridBand gbBand = new GridBand();
                gbBand.Caption = dtmDate.ToString("dd/MM");
                gbBand.AppearanceHeader.Options.UseFont = true;
                gbBand.AppearanceHeader.Options.UseTextOptions = true;
                gbBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gbBand.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
                gbBand.Name = "gbBand";
                gvData.Bands.Add(gbBand);

                // Add Grid
                // gcol              
                BandedGridColumn gcol = new BandedGridColumn();
                gcol.Caption = Libs.MyConvert.DayOfWeekString(dtmDate);
                gcol.FieldName = "Value_" + i.ToString();
                gcol.Name = "gcol" + "Value_" + i.ToString();
                gcol.Width = 40;
                gcol.Visible = true;
                gcol.VisibleIndex = i + fields.Length;
                gcol.AppearanceHeader.Options.UseFont = true;
                gcol.AppearanceHeader.Options.UseTextOptions = true;
                gcol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcol.AppearanceCell.Options.UseTextOptions = true;
                gcol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gcol.DisplayFormat.FormatString = "#,###";
                gcol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

                gbBand.Columns.Add(gcol);
                gvData.Columns.Add(gcol);
            }

            #endregion

            #region  Add Summary Columns

            // Thêm  Band
            GridBand gbBandSummary = new GridBand();
            gbBandSummary.Caption = "TỔNG";
            gbBandSummary.AppearanceHeader.Options.UseFont = true;
            gbBandSummary.AppearanceHeader.Options.UseTextOptions = true;
            gbBandSummary.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gbBandSummary.AppearanceHeader.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
            gbBandSummary.Name = "gbBandSummary";
            gvData.Bands.Add(gbBandSummary);

            string[] fields2 = { "TotalOff"};
            string[] captions2 = { "Tổng vắng" };
            int[] widths2 = { 80};
            for (int i = 0; i < fields2.Length; i++)
            {
                // gcol              
                BandedGridColumn gcol = new BandedGridColumn();
                gcol.Caption = captions2[i];
                gcol.FieldName = fields2[i];
                gcol.Name = "gcol" + fields2[i];
                gcol.Width = widths[i];
                gcol.Visible = true;
                gcol.VisibleIndex = i;
                gcol.AppearanceHeader.Options.UseFont = true;
                gcol.AppearanceHeader.Options.UseTextOptions = true;
                gcol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gcol.AppearanceCell.Options.UseTextOptions = true;
                gcol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                gcol.DisplayFormat.FormatString = "#,###";
                gcol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gcol.AppearanceCell.BackColor = Color.White;
                if (i < 3)
                    gcol.AppearanceCell.BackColor2 = Color.LightSkyBlue;
                else
                    gcol.AppearanceCell.BackColor2 = Color.Pink;
                gcol.AppearanceCell.Options.UseBackColor = true;
                gcol.AppearanceCell.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;

                gvData.Columns.Add(gcol);
                gbBandSummary.Columns.Add(gcol);
            }

            #endregion
        }

        private bool ReadData()
        {
            SIM_SubjectChecking obj = new SIM_SubjectChecking();

            dtbData = obj.GetDataTable("SIM_Student_SearchTemplateForChecking",
                                        "@ClassID", uClass.IsRegulation43 ? null : uClass.ClassIDEditValue.ToString(),
                                        "@Fromdate", dtmFrom.EditValueDate,
                                        "@ToDate", dtmTo.EditValueDate
                                       );

            dtbStudentChecking = obj.GetDataTable("SIM_SumChecking_SearchData",
                                        "@Fromdate", dtmFrom.EditValueDate,
                                        "@ToDate", dtmTo.EditValueDate);
           
            if (dtbData == null || dtbStudentChecking == null)
            {
                ErrorManager.Error("Việc tải thông tin bị lỗi!");
                return false;
            }


            dtbDateSchedule = new DataTable();
            dtbDateSchedule.Columns.Add("Date", typeof(DateTime));
            DateTime dtmDate = dtmFrom.EditValueDate.Value;
            while (dtmDate <= dtmTo.EditValueDate.Value)
            {
                DataRow drw = dtbDateSchedule.NewRow();
                drw["Date"] = dtmDate;
                dtbDateSchedule.Rows.Add(drw);
                dtmDate = dtmDate.AddDays(1);
            }

            dtbDateSchedule.Columns.Add("DateIndex", typeof(int));
            if (dtbDateSchedule.Rows.Count > 100)
            {
                MessageManager.Warning("Dữ liệu quá nhiều, bạn vui lòng giới hạn thời gian lại!");
                return false;
            }

            if (dtbDateSchedule.Rows.Count > 300)
            {
                MessageManager.Warning("Dữ liệu quá nhiều, bạn vui lòng giới hạn thời gian lại!");
                return false;
            }

            return true;
        }

        private void ResetData()
        {
            if (dtbData == null)
                return;

            foreach (DataRow drw in dtbData.Rows)
            {
                foreach (DataColumn col in dtbData.Columns)
                    if (col.ColumnName.Contains("Value_"))
                        drw[col.ColumnName] = "";
            }
        }

        /// <summary>
        /// Fill giá trị lịch học theo lớp vào trước
        /// </summary>
        private void FillScheduleData()
        {
            if (dtbSchedule == null || dtbSchedule.Rows.Count == 0)
                return;

            foreach (DataRow drw in dtbSchedule.Rows)
            {

                #region Lấy giá trị ô lịch

                //// nội dung bài học
                //string strLearningContent = drw["LearningContent"].ToString();

                //// nội dung lịch
                //string strContent = drw["ScheduleContent"].ToString();

                //// nội dung ô lịch
                //string strValue = "";
                //strValue = MyLibs.AddTwoStr(strLearningContent, strContent);
                //if (strValue == "")
                //    strValue = "(Nội dung)";

                #endregion

                #region  tìm vị trí dòng cột để add vào lưới

                DataRow[] rowDates = dtbDateSchedule.Select("Date='" + Convert.ToDateTime(drw["Date"]).ToString("yyyy-MM-dd") + "'");
                if (rowDates.Length != 0)
                {
                    string strColumn = "Value_" + rowDates[0]["DateIndex"].ToString(); // gán vào ô giá trị ẩn
                    //string strColumnContent = "Content_" + rowDates[0]["DateIndex"].ToString(); // gán vào ô giá trị ẩn
                    //DataRow[] rows = dtbData.Select("ClassID ='" + drw["ClassID"].ToString() + "'");
                    foreach(DataRow row in dtbData.Rows) // điền các giá trị vào cho các sv của lớp
                    {
                        //drw[strColumnContent] = strValue;
                        row[strColumn] = "0"; // có lịch thì mới có giá trị "0" này (phân biệt màu và cho phép edit
                    }
                }

                #endregion

            }
        }

        /// <summary>
        /// Fill giá trị điểm danh
        /// </summary>
        private void FillData()
        {
            if (dtbStudentChecking == null || dtbStudentChecking.Rows.Count == 0)
                return;

            foreach (DataRow drw in dtbStudentChecking.Rows)
            {

                #region Lấy giá trị ô lịch                

                double? dValue = MyConvert.ToDouble(drw[SIM_SubjectChecking.C_NoPermissionQuantity]) + MyConvert.ToDouble(drw[SIM_SubjectChecking.C_PermissionQuantity]);
                double? dValue1 = MyConvert.ToDouble(drw[SIM_SubjectChecking.C_PermissionQuantity]);
                #endregion

                #region  tìm vị trí dòng cột để add vào lưới

                if (dValue != null && dValue > 0)
                {
                    DataRow[] rowDates = dtbDateSchedule.Select("Date='" + Convert.ToDateTime(drw["Date"]).ToString("yyyy-MM-dd") + "'");
                    if (rowDates.Length != 0)
                    {
                        string strColumn = "Value_" + rowDates[0]["DateIndex"].ToString();
                        DataRow[] rows = dtbData.Select("StudentID =" + drw["StudentID"].ToString());
                        if (rows.Length != 0)
                        {
                            rows[0][strColumn] = dValue;
                        }
                    }
                }
                #endregion

            }

            foreach (DataRow drw in dtbData.Rows)
                TotalRow(drw);
        }

        private bool GetPosition()
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw == null || gvData.FocusedColumn == null)
                return false;
            lngStudentIDPos = null;
            intClassIDPos = null;
            strDaysPos = null;
            dtmDatePos = null;
            lngScheduleIDPos = null;
            strValuePos = null;
            strValueContentPos = null;

            string strFieldName = gvData.FocusedColumn.FieldName;
            if (strFieldName.Contains("Student"))
            {
                lngStudentIDPos = Convert.ToInt32(drw["StudentID"]);
                intClassIDPos = Convert.ToInt32(drw["ClassID"]);
                return true;
            }
            if (strFieldName.Contains("Class"))
            {
                intClassIDPos = Convert.ToInt32(drw["ClassID"]);
                return true;
            }
            if (strFieldName.Contains("Value_"))
            {
                lngStudentIDPos = Convert.ToInt32(drw["StudentID"]);
                intClassIDPos = Convert.ToInt32(drw["ClassID"]);
                strValueContentPos = drw[gvData.FocusedColumn.FieldName.Replace("Value_", "Content_")].ToString(); // nội dung ô lịch
                strValuePos = drw[strFieldName].ToString();
                DataRow[] rowDates = dtbDateSchedule.Select("DateIndex = " + strFieldName.Replace("Value_", ""));
                if (rowDates.Length > 0)
                {
                    dtmDatePos = Convert.ToDateTime(rowDates[0]["Date"]);
                    strDaysPos = Libs.MyConvert.ToDayOfWeekInt(dtmDatePos).ToString();
                }

                // nếu có nội dung lịch thì lấy mã lịch
                //if (strValueContentPos.Length > 2)
                //{
                //    DataRow[] rows = dtbSchedule.Select("ClassID=" + intClassIDPos.ToString() + " and Date = '" + dtmDatePos.Value.ToString("yyyy-MM-dd") + "'");
                //    if (rows.Length > 0)
                //        lngScheduleIDPos = Convert.ToInt64(rows[0]["ScheduleID"]);
                //}

                // tìm mã điểm danh
                if (strValuePos != null)
                {
                    DataRow[] rows = dtbStudentChecking.Select("ClassOfStudentID=" + lngClassOfStudentIDPos.ToString() + " and Date = '" + dtmDatePos.Value.ToString("yyyy-MM-dd") + "'");
                    if (rows.Length > 0)
                        lngStudentCheckingIDPos = Convert.ToInt64(rows[0]["StudentCheckingID"]);
                }
                return true;
            }
            return false;
        }

        
        private void TotalRow(DataRow drw)
        {
            int a = 0;
            foreach (DataRow drwDate in dtbDateSchedule.Rows)
            {
                int? intValue = MyConvert.ToInt32(drw["Value_" + drwDate["DateIndex"].ToString()].ToString());
                if (intValue != null)
                    a += intValue.Value;
            }          
            drw["TotalOff"] = a;
            //drw["TotalQuantity"] = intPermission + intNoPermission + intDone + a;
        }

        /// <summary>
        /// Truyền "P" or "K" or " " . Không được truyền rỗng
        /// </summary>
        /// <param name="value"></param>
        private void CheckDone(int? value)
        {
            // gán giá trị vào lưới lại
            foreach (DataRow drw in dtbData.Rows)
            {
                //if (UserSession.HasPermissionForOffice(PERMISSION_EDIT, drw["OfficeID"].ToString()))
                //{
                    foreach (DataRow drwDate in dtbDateSchedule.Rows)
                    {
                        if (drw["Value_" + drwDate["DateIndex"].ToString()].ToString() != "") // có giá trị lịch hoặc đang có giá trị thì set được

                            drw["Value_" + drwDate["DateIndex"].ToString()] = value;
                    }
                    drw["IsEdit"] = 1;
                    TotalRow(drw);
                //}
            }
            
        }

        #endregion

        #region Grid Actions

     
        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string strFieldName = e.Column.FieldName;
            if (e.CellValue == null)
                return;
            if (e.Column.FieldName.Contains("Value_"))
            {
                string strValue = e.CellValue.ToString();
                if (strValue == "")
                    return;
                else if(strValue=="0")
                {
                    e.Appearance.BackColor = Color.LightSkyBlue;
                    e.Appearance.ForeColor = Color.Blue;                   
                }
                else //if (Convert.ToInt32(strValue) > 0)
                {
                    e.Appearance.BackColor = Color.LightPink;
                    e.Appearance.ForeColor = foreColorData;
                }
                
                //else if (e.CellValue.ToString().Contains("(XG)"))
                //{
                //    e.Appearance.BackColor = Color.LightGray;
                //    e.Appearance.ForeColor = Color.Red;
                //}
                //else if (e.CellValue.ToString().Contains("(Tạo mới)"))
                //{
                //    e.Appearance.BackColor = bgColorData;
                //    e.Appearance.ForeColor = Color.Blue;
                //}
                //else
                //{
                //    e.Appearance.BackColor = bgColorData;
                //    e.Appearance.ForeColor = foreColorData;
                //}
            }
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            string strFieldName = gvData.FocusedColumn.FieldName;
            if (strFieldName.Contains("Value_") && drw != null)
            {
                //if (!UserSession.HasPermissionForOffice(PERMISSION_EDIT, drw["OfficeID"].ToString()))
                //{
                //    e.Cancel = true;
                //    return;
                //}

                string strValue = drw[strFieldName].ToString();
                if (strValue == "") // ko có lịch và đang ở chế độ theo TKB thì bỏ qua ko cho edit
                    e.Cancel = true;
            }
        }

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value == null || e.Value.ToString() == "")
                e.Value = 0;

            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                drw["IsEdit"] = 1;
            }
        }

        #endregion        

        #region Form Actions

        private void frmSchedule_Load(object sender, EventArgs e)
        {
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }

        private void frmStudentChecking_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;
                case Keys.F4:
                    break;
                case Keys.F5:
                    mnuItemRefresh_Click(sender, null);
                    break;
                case Keys.F6:
                    break;
                case Keys.F7:
                    mnuItemPrint1_Click(sender, null);
                    break;
                case Keys.F8:
                    break;
                case Keys.Escape:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                BeginProcess();
                new Thread(Process).Start();
            }
        }

        //private void mnuItemEdit_Click(object sender, EventArgs e)
        //{
        //    if (GetPosition()) // tìm không được thì không sửa được
        //    {
        //        frmScheduleEdit frmEdit = frmScheduleEdit.Instance;
        //        frmEdit.LoadData(lngScheduleIDPos, null, strDaysPos, dtmDatePos, null, intClassIDPos, intStudentIDPos);
        //        frmEdit.ShowDialog();
        //        if (frmEdit.IsOk)
        //        {
        //            lngScheduleID = frmEdit.ScheduleIDSaved;
        //            btnSearch_Click(null, null);
        //        }
        //    }
        //}

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            LoadReferenceData();
            new Thread(Process).Start();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuPopupGrid_Opening(object sender, CancelEventArgs e)
        {
            if (gvData.FocusedColumn != null)
                if (gvData.FocusedColumn.FieldName.Contains("Value_"))
                {

                    object obj = gvData.GetFocusedValue();
                    if (obj != null)
                    {
                        if (obj.ToString().Length > 2)
                        {                            
                            mnuItemEdit.Enabled = true;
                            return;
                        }
                    }
                }
            mnuItemEdit.Enabled = false;
        }
             #endregion

        
        private void mnuItemUnCheckDoneAll_Click(object sender, EventArgs e)
        {
            CheckDone(null);
        }

        private void mnuItemPrint1_Click(object sender, EventArgs e)
        {
            // print danh sach phieu thu
            DataTable dtbPrint = dtbData.DefaultView.ToTable(); // lấy dữ liệu nhìn thấy thực tế trên lưới

            //dtbPrint.DefaultView.RowFilter = "IsSelected = 1"; // in những dòng đang check chọn
            //dtbPrint = dtbPrint.DefaultView.ToTable();

            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbPrint, "Report/StudentManager/Student/StudentChecking1.repx", false);
            frm.SetParameter("p_Course", uClass.CourseName);
            frm.SetParameter("p_Class", uClass.ClassName);

            frm.SetParameter("pfromdate", Convert.ToDateTime(dtmFrom.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pTodate", Convert.ToDateTime(dtmTo.EditValueDateTime).ToString("MM/yyyy"));
            // truyền danh sách tên cột vào
            // dtbDateSchedule có 2 cột Date, DateIndex
            foreach (DataRow drw in dtbDateSchedule.Rows)
            {
                frm.SetParameter("pCol" + drw["DateIndex"].ToString(), Convert.ToDateTime(drw["Date"]).ToString("dd/MM"));
            }

            frm.Show();
        }

        private void mnuItemCheckPermissionAll_Click(object sender, EventArgs e)
        {
            CheckDone(1);
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                    TotalRow(drw);
            }
        }

        private void chkNotNeedSchedule_CheckedChanged(object sender, EventArgs e)
        {
           
        }

    }
}