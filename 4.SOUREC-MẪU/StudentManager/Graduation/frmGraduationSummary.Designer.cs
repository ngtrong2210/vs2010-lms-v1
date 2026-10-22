namespace StudentManager.Graduation
{
    partial class frmGraduationSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraduationSummary));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lookupExamDate = new Control.ULookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSetDecisionNo = new Control.DgButton();
            this.btnSetSigningdate = new Control.DgButton();
            this.btnSetYearID = new Control.DgButton();
            this.dateSigningdate = new Control.UDateEdit();
            this.txtDecisionNo = new Control.UTextEdit();
            this.uYearID = new DeclarationManager.Education.UYear();
            this.btnPrint2 = new Control.DgButton();
            this.btnReview = new Control.DgButton();
            this.btnSave = new Control.DgButton();
            this.btnPrint = new Control.DgButton();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuKetQuaThiTotnghiep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mniItemHoiDongKTN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDanhSachKTN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemHopHoiDong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemTotnghiep = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuaTrinhHocTap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgAdvBandedGridView();
            this.OptVanHoa = new Control.DgRatioButton();
            this.OptNghe = new Control.DgRatioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.dockPanel2});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("02219bdd-a6dc-4a42-8ac7-960bcb8240ce");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Options.ShowCloseButton = false;
            this.dockPanel1.OriginalSize = new System.Drawing.Size(249, 200);
            this.dockPanel1.Size = new System.Drawing.Size(249, 476);
            this.dockPanel1.Text = "THÔNG TIN TÌM KIẾM";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.OptVanHoa);
            this.dockPanel1_Container.Controls.Add(this.lookupExamDate);
            this.dockPanel1_Container.Controls.Add(this.OptNghe);
            this.dockPanel1_Container.Controls.Add(this.groupBox1);
            this.dockPanel1_Container.Controls.Add(this.btnPrint2);
            this.dockPanel1_Container.Controls.Add(this.btnReview);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(241, 449);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // lookupExamDate
            // 
            this.lookupExamDate.AllowNull = true;
            this.lookupExamDate.Caption = "Kì tổ chức thi:";
            this.lookupExamDate.DataSource = null;
            this.lookupExamDate.EditorLeft = 90;
            this.lookupExamDate.EditValue = null;
            this.lookupExamDate.Location = new System.Drawing.Point(3, 203);
            this.lookupExamDate.Name = "lookupExamDate";
            this.lookupExamDate.ReadOnly = false;
            this.lookupExamDate.RowFilter = "";
            this.lookupExamDate.Size = new System.Drawing.Size(231, 21);
            this.lookupExamDate.TabIndex = 62;
            this.lookupExamDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSetDecisionNo);
            this.groupBox1.Controls.Add(this.btnSetSigningdate);
            this.groupBox1.Controls.Add(this.btnSetYearID);
            this.groupBox1.Controls.Add(this.dateSigningdate);
            this.groupBox1.Controls.Add(this.txtDecisionNo);
            this.groupBox1.Controls.Add(this.uYearID);
            this.groupBox1.Location = new System.Drawing.Point(3, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quyết định tốt nghiệp";
            // 
            // btnSetDecisionNo
            // 
            this.btnSetDecisionNo.Enabled = false;
            this.btnSetDecisionNo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSetDecisionNo.Location = new System.Drawing.Point(200, 20);
            this.btnSetDecisionNo.Name = "btnSetDecisionNo";
            this.btnSetDecisionNo.Size = new System.Drawing.Size(27, 23);
            this.btnSetDecisionNo.TabIndex = 67;
            this.btnSetDecisionNo.Click += new System.EventHandler(this.btnSetDecisionNo_Click);
            // 
            // btnSetSigningdate
            // 
            this.btnSetSigningdate.Enabled = false;
            this.btnSetSigningdate.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSetSigningdate.Location = new System.Drawing.Point(200, 42);
            this.btnSetSigningdate.Name = "btnSetSigningdate";
            this.btnSetSigningdate.Size = new System.Drawing.Size(27, 23);
            this.btnSetSigningdate.TabIndex = 66;
            this.btnSetSigningdate.Click += new System.EventHandler(this.btnSetSigningdate_Click);
            // 
            // btnSetYearID
            // 
            this.btnSetYearID.Enabled = false;
            this.btnSetYearID.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSetYearID.Location = new System.Drawing.Point(200, 64);
            this.btnSetYearID.Name = "btnSetYearID";
            this.btnSetYearID.Size = new System.Drawing.Size(27, 23);
            this.btnSetYearID.TabIndex = 65;
            this.btnSetYearID.Click += new System.EventHandler(this.btnSetYearID_Click);
            // 
            // dateSigningdate
            // 
            this.dateSigningdate.Caption = "Ngày QĐ:";
            this.dateSigningdate.EditorLeft = 90;
            this.dateSigningdate.EditValue = null;
            this.dateSigningdate.EditValueDate = null;
            this.dateSigningdate.EditValueDateTime = null;
            this.dateSigningdate.FormatString = "d";
            this.dateSigningdate.Location = new System.Drawing.Point(10, 42);
            this.dateSigningdate.Name = "dateSigningdate";
            this.dateSigningdate.ReadOnly = false;
            this.dateSigningdate.Size = new System.Drawing.Size(184, 21);
            this.dateSigningdate.TabIndex = 61;
            // 
            // txtDecisionNo
            // 
            this.txtDecisionNo.AllowNull = true;
            this.txtDecisionNo.Caption = "Số quyết định:";
            this.txtDecisionNo.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtDecisionNo.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtDecisionNo.EditorLeft = 90;
            this.txtDecisionNo.EditValue = null;
            this.txtDecisionNo.EditValueDouble = null;
            this.txtDecisionNo.EditValueInt32 = null;
            this.txtDecisionNo.EnterMoveNext = true;
            this.txtDecisionNo.FontSize = 9F;
            this.txtDecisionNo.Location = new System.Drawing.Point(10, 20);
            this.txtDecisionNo.MaxLength = 0;
            this.txtDecisionNo.Name = "txtDecisionNo";
            this.txtDecisionNo.PasswordChar = '\0';
            this.txtDecisionNo.ReadOnly = false;
            this.txtDecisionNo.Size = new System.Drawing.Size(184, 21);
            this.txtDecisionNo.TabIndex = 60;
            this.txtDecisionNo.TextTrim = "";
            // 
            // uYearID
            // 
            this.uYearID.EditorLeft = 90;
            this.uYearID.Location = new System.Drawing.Point(10, 64);
            this.uYearID.Name = "uYearID";
            this.uYearID.ReadOnly = false;
            this.uYearID.Size = new System.Drawing.Size(184, 24);
            this.uYearID.TabIndex = 34;
            this.uYearID.YearIDEditValue = null;
            // 
            // btnPrint2
            // 
            this.btnPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint2.Enabled = false;
            this.btnPrint2.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint2.Location = new System.Drawing.Point(129, 386);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(106, 26);
            this.btnPrint2.TabIndex = 4;
            this.btnPrint2.Text = "Tốt nghiệp";
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // btnReview
            // 
            this.btnReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReview.Enabled = false;
            this.btnReview.Image = global::StudentManager.Properties.Resources.process;
            this.btnReview.Location = new System.Drawing.Point(130, 354);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(105, 26);
            this.btnReview.TabIndex = 5;
            this.btnReview.Text = "Xét duyệt";
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(8, 386);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(8, 418);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(106, 26);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Không TN";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // uClass
            // 
            this.uClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uClass.BranchEditValue = null;
            this.uClass.ClassEdit = null;
            this.uClass.ClassFilter = "";
            this.uClass.ClassIDEditValue = null;
            this.uClass.ClassSubject = null;
            this.uClass.ClassSubjectFilter = "";
            this.uClass.ClassSubjectIDEditValue = null;
            this.uClass.CourseIDEditValue = null;
            this.uClass.EditorLeft = 90;
            this.uClass.IsOnlyClass = true;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(3, 3);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(231, 196);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 0;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            this.uClass.Validated += new System.EventHandler(this.uClass_Validated);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(129, 418);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(8, 354);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(106, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(249, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(680, 200);
            this.dockPanel2.Size = new System.Drawing.Size(735, 476);
            this.dockPanel2.Text = "DANH SÁCH SINH VIÊN";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(727, 449);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(-1, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(729, 450);
            this.gcData.TabIndex = 6;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            this.gcData.Click += new System.EventHandler(this.gcData_Click);
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemSave,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuKetQuaThiTotnghiep,
            this.mnuItemPrint,
            this.mnuItemPrint2,
            this.mnuItemExportToExcel,
            this.mnuQuaTrinhHocTap,
            this.toolStripSeparator2,
            this.mnuItemDelete,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(225, 214);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Enabled = false;
            this.mnuItemSave.Image = global::StudentManager.Properties.Resources.Save;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.Size = new System.Drawing.Size(224, 22);
            this.mnuItemSave.Text = "Cập nhật";
            this.mnuItemSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(224, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuKetQuaThiTotnghiep
            // 
            this.mnuKetQuaThiTotnghiep.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuKetQuaThiTotnghiep.Name = "mnuKetQuaThiTotnghiep";
            this.mnuKetQuaThiTotnghiep.Size = new System.Drawing.Size(224, 22);
            this.mnuKetQuaThiTotnghiep.Text = "Kết quả thi tốt nghiệp";
            this.mnuKetQuaThiTotnghiep.Click += new System.EventHandler(this.mnuKetQuaThiTotnghiep_Click);
            // 
            // mnuItemPrint
            // 
            this.mnuItemPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniItemHoiDongKTN,
            this.mnuItemDanhSachKTN});
            this.mnuItemPrint.Enabled = false;
            this.mnuItemPrint.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuItemPrint.Name = "mnuItemPrint";
            this.mnuItemPrint.Size = new System.Drawing.Size(224, 22);
            this.mnuItemPrint.Text = "Danh sách không tốt nghiệp";
            this.mnuItemPrint.Click += new System.EventHandler(this.mnuItemPrint_Click);
            // 
            // mniItemHoiDongKTN
            // 
            this.mniItemHoiDongKTN.Name = "mniItemHoiDongKTN";
            this.mniItemHoiDongKTN.Size = new System.Drawing.Size(224, 22);
            this.mniItemHoiDongKTN.Text = "Danh sách họp hội đồng";
            this.mniItemHoiDongKTN.Click += new System.EventHandler(this.mniItemHoiDongKTN_Click);
            // 
            // mnuItemDanhSachKTN
            // 
            this.mnuItemDanhSachKTN.Name = "mnuItemDanhSachKTN";
            this.mnuItemDanhSachKTN.Size = new System.Drawing.Size(224, 22);
            this.mnuItemDanhSachKTN.Text = "Danh sách không tốt nghiệp";
            this.mnuItemDanhSachKTN.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // mnuItemPrint2
            // 
            this.mnuItemPrint2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemHopHoiDong,
            this.mnuItemTotnghiep});
            this.mnuItemPrint2.Enabled = false;
            this.mnuItemPrint2.Image = global::StudentManager.Properties.Resources.print1;
            this.mnuItemPrint2.Name = "mnuItemPrint2";
            this.mnuItemPrint2.Size = new System.Drawing.Size(224, 22);
            this.mnuItemPrint2.Text = "Danh sách tốt nghiệp";
            this.mnuItemPrint2.Click += new System.EventHandler(this.mnuItemPrint2_Click);
            // 
            // mnuItemHopHoiDong
            // 
            this.mnuItemHopHoiDong.Name = "mnuItemHopHoiDong";
            this.mnuItemHopHoiDong.Size = new System.Drawing.Size(247, 22);
            this.mnuItemHopHoiDong.Text = "Danh sách họp hội đồng";
            this.mnuItemHopHoiDong.Click += new System.EventHandler(this.mnuItemHopHoiDong_Click);
            // 
            // mnuItemTotnghiep
            // 
            this.mnuItemTotnghiep.Name = "mnuItemTotnghiep";
            this.mnuItemTotnghiep.Size = new System.Drawing.Size(247, 22);
            this.mnuItemTotnghiep.Text = "Danh sách công nhận tốt nghiệp";
            this.mnuItemTotnghiep.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Enabled = false;
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(224, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // mnuQuaTrinhHocTap
            // 
            this.mnuQuaTrinhHocTap.Image = global::StudentManager.Properties.Resources.Process3;
            this.mnuQuaTrinhHocTap.Name = "mnuQuaTrinhHocTap";
            this.mnuQuaTrinhHocTap.Size = new System.Drawing.Size(224, 22);
            this.mnuQuaTrinhHocTap.Text = "Quá trình học tập";
            this.mnuQuaTrinhHocTap.Click += new System.EventHandler(this.mnuQuaTrinhHocTap_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.Size = new System.Drawing.Size(224, 22);
            this.mnuItemDelete.Text = "Xoá kết quả xét";
            this.mnuItemDelete.Click += new System.EventHandler(this.mnuItemDelete_Click);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(224, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvData
            // 
            this.gvData.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.gvData.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.gvData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvData.Appearance.RowSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gvData.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvData.CustomizationFormBounds = new System.Drawing.Rectangle(1048, 450, 223, 215);
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.LanguageID = 1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsBehavior.Editable = false;
            this.gvData.OptionsCustomization.AllowBandMoving = false;
            this.gvData.OptionsCustomization.AllowColumnMoving = false;
            this.gvData.OptionsCustomization.AllowGroup = false;
            this.gvData.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvData.OptionsSelection.InvertSelection = true;
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.RowSeparatorHeight = 1;
            this.gvData.SummaryCollection = "";
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // OptVanHoa
            // 
            this.OptVanHoa.AutoSize = true;
            this.OptVanHoa.EnterMoveNextControl = true;
            this.OptVanHoa.Location = new System.Drawing.Point(120, 334);
            this.OptVanHoa.Name = "OptVanHoa";
            this.OptVanHoa.Size = new System.Drawing.Size(80, 17);
            this.OptVanHoa.TabIndex = 63;
            this.OptVanHoa.Text = "TN văn hóa";
            this.OptVanHoa.UseVisualStyleBackColor = true;
            // 
            // OptNghe
            // 
            this.OptNghe.AutoSize = true;
            this.OptNghe.Checked = true;
            this.OptNghe.EnterMoveNextControl = true;
            this.OptNghe.Location = new System.Drawing.Point(13, 334);
            this.OptNghe.Name = "OptNghe";
            this.OptNghe.Size = new System.Drawing.Size(65, 17);
            this.OptNghe.TabIndex = 62;
            this.OptNghe.TabStop = true;
            this.OptNghe.Text = "TN nghề";
            this.OptNghe.UseVisualStyleBackColor = true;
            // 
            // frmGraduationSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 476);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmGraduationSummary";
            this.ShowIcon = false;
            this.Text = "Xét tốt nghiệp";
            this.Load += new System.EventHandler(this.frmMakeStudentCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private Control.DgButton btnSearch;
        private Control.DgButton btnClose;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private Control.DgButton btnPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint;
        private Control.DgButton btnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private Control.DgButton btnPrint2;
        private Control.DgButton btnReview;
        private System.Windows.Forms.GroupBox groupBox1;
        private DeclarationManager.Education.UYear uYearID;
        private Control.UTextEdit txtDecisionNo;
        private Control.UDateEdit dateSigningdate;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrint2;
        private System.Windows.Forms.ToolStripMenuItem mniItemHoiDongKTN;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDanhSachKTN;
        private System.Windows.Forms.ToolStripMenuItem mnuItemHopHoiDong;
        private System.Windows.Forms.ToolStripMenuItem mnuItemTotnghiep;
        private Control.ULookUpEdit lookupExamDate;
        private System.Windows.Forms.ToolStripMenuItem mnuKetQuaThiTotnghiep;
        private System.Windows.Forms.ToolStripMenuItem mnuQuaTrinhHocTap;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private Control.DgButton btnSetDecisionNo;
        private Control.DgButton btnSetSigningdate;
        private Control.DgButton btnSetYearID;
        private Control.DgRatioButton OptVanHoa;
        private Control.DgRatioButton OptNghe;
    }
}