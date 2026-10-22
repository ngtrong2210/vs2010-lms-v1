namespace StudentManager.Graduation
{
    partial class frmReviewGraduationExam
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewGraduationExam));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.chkIsNotShowReviewed = new Control.DgCheckEdit();
            this.txtDiem = new Control.UTextEdit();
            this.OptXetKhoaLuan = new Control.DgRatioButton();
            this.OptVanHoa = new Control.DgRatioButton();
            this.OptTNCT = new Control.DgRatioButton();
            this.OptNghe = new Control.DgRatioButton();
            this.btnSave = new Control.DgButton();
            this.btnPrint2 = new Control.DgButton();
            this.dgLabel1 = new Control.DgLabel();
            this.cbxOrderReview = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnReview = new Control.DgButton();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnPrint1 = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnu_DanhSach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSTongHop = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDsThiTN = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSKhongDT = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDSTongHop_VH = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuQuaTrinhHocTapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            this.mnuItemCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUnCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsNotShowReviewed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxOrderReview.Properties)).BeginInit();
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(242, 200);
            this.dockPanel1.Size = new System.Drawing.Size(242, 509);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.chkIsNotShowReviewed);
            this.dockPanel1_Container.Controls.Add(this.txtDiem);
            this.dockPanel1_Container.Controls.Add(this.OptXetKhoaLuan);
            this.dockPanel1_Container.Controls.Add(this.OptVanHoa);
            this.dockPanel1_Container.Controls.Add(this.OptTNCT);
            this.dockPanel1_Container.Controls.Add(this.OptNghe);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.btnPrint2);
            this.dockPanel1_Container.Controls.Add(this.dgLabel1);
            this.dockPanel1_Container.Controls.Add(this.cbxOrderReview);
            this.dockPanel1_Container.Controls.Add(this.btnReview);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnPrint1);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 482);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // chkIsNotShowReviewed
            // 
            this.chkIsNotShowReviewed.EnterMoveNextControl = true;
            this.chkIsNotShowReviewed.Location = new System.Drawing.Point(91, 236);
            this.chkIsNotShowReviewed.Name = "chkIsNotShowReviewed";
            this.chkIsNotShowReviewed.Properties.Caption = "Không hiển thị sv đã đạt";
            this.chkIsNotShowReviewed.Size = new System.Drawing.Size(140, 19);
            this.chkIsNotShowReviewed.TabIndex = 66;
            this.chkIsNotShowReviewed.CheckedChanged += new System.EventHandler(this.chkIsNotShowReviewed_CheckedChanged);
            // 
            // txtDiem
            // 
            this.txtDiem.AllowNull = true;
            this.txtDiem.Caption = "Điểm xét:";
            this.txtDiem.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtDiem.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtDiem.EditorLeft = 90;
            this.txtDiem.EditValue = null;
            this.txtDiem.EditValueDouble = null;
            this.txtDiem.EditValueInt32 = null;
            this.txtDiem.EnterMoveNext = true;
            this.txtDiem.FontSize = 9F;
            this.txtDiem.Location = new System.Drawing.Point(3, 316);
            this.txtDiem.MaxLength = 0;
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.PasswordChar = '\0';
            this.txtDiem.ReadOnly = false;
            this.txtDiem.Size = new System.Drawing.Size(210, 21);
            this.txtDiem.TabIndex = 65;
            this.txtDiem.TextTrim = "";
            // 
            // OptXetKhoaLuan
            // 
            this.OptXetKhoaLuan.AutoSize = true;
            this.OptXetKhoaLuan.EnterMoveNextControl = true;
            this.OptXetKhoaLuan.Location = new System.Drawing.Point(129, 293);
            this.OptXetKhoaLuan.Name = "OptXetKhoaLuan";
            this.OptXetKhoaLuan.Size = new System.Drawing.Size(90, 17);
            this.OptXetKhoaLuan.TabIndex = 62;
            this.OptXetKhoaLuan.Text = "Xét khóa luận";
            this.OptXetKhoaLuan.UseVisualStyleBackColor = true;
            this.OptXetKhoaLuan.CheckedChanged += new System.EventHandler(this.OptXetKhoaLuan_CheckedChanged);
            // 
            // OptVanHoa
            // 
            this.OptVanHoa.AutoSize = true;
            this.OptVanHoa.EnterMoveNextControl = true;
            this.OptVanHoa.Location = new System.Drawing.Point(22, 293);
            this.OptVanHoa.Name = "OptVanHoa";
            this.OptVanHoa.Size = new System.Drawing.Size(80, 17);
            this.OptVanHoa.TabIndex = 61;
            this.OptVanHoa.Text = "TN văn hóa";
            this.OptVanHoa.UseVisualStyleBackColor = true;
            this.OptVanHoa.CheckedChanged += new System.EventHandler(this.OptVanHoa_CheckedChanged);
            // 
            // OptTNCT
            // 
            this.OptTNCT.AutoSize = true;
            this.OptTNCT.EnterMoveNextControl = true;
            this.OptTNCT.Location = new System.Drawing.Point(129, 270);
            this.OptTNCT.Name = "OptTNCT";
            this.OptTNCT.Size = new System.Drawing.Size(79, 17);
            this.OptTNCT.TabIndex = 61;
            this.OptTNCT.Text = "TN chính trị";
            this.OptTNCT.UseVisualStyleBackColor = true;
            this.OptTNCT.CheckedChanged += new System.EventHandler(this.OptTNCT_CheckedChanged);
            // 
            // OptNghe
            // 
            this.OptNghe.AutoSize = true;
            this.OptNghe.Checked = true;
            this.OptNghe.EnterMoveNextControl = true;
            this.OptNghe.Location = new System.Drawing.Point(22, 270);
            this.OptNghe.Name = "OptNghe";
            this.OptNghe.Size = new System.Drawing.Size(65, 17);
            this.OptNghe.TabIndex = 61;
            this.OptNghe.TabStop = true;
            this.OptNghe.Text = "TN nghề";
            this.OptNghe.UseVisualStyleBackColor = true;
            this.OptNghe.CheckedChanged += new System.EventHandler(this.OptNghe_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(9, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint2
            // 
            this.btnPrint2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint2.Enabled = false;
            this.btnPrint2.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint2.Location = new System.Drawing.Point(9, 456);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(104, 23);
            this.btnPrint2.TabIndex = 56;
            this.btnPrint2.Text = "Không dự thi";
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(0, 215);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(86, 14);
            this.dgLabel1.TabIndex = 63;
            this.dgLabel1.Text = "Đợt tốt nghiệp:";
            // 
            // cbxOrderReview
            // 
            this.cbxOrderReview.EditValue = "1";
            this.cbxOrderReview.Location = new System.Drawing.Point(93, 213);
            this.cbxOrderReview.Name = "cbxOrderReview";
            this.cbxOrderReview.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxOrderReview.Properties.Items.AddRange(new object[] {
            "--chon--",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbxOrderReview.Properties.NullText = "--Chọn--";
            this.cbxOrderReview.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbxOrderReview.Size = new System.Drawing.Size(138, 20);
            this.cbxOrderReview.TabIndex = 62;
            // 
            // btnReview
            // 
            this.btnReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReview.Enabled = false;
            this.btnReview.Image = global::StudentManager.Properties.Resources.process;
            this.btnReview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnReview.Location = new System.Drawing.Point(119, 398);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(104, 23);
            this.btnReview.TabIndex = 61;
            this.btnReview.Text = "Xét duyệt";
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // uClass
            // 
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
            this.uClass.Size = new System.Drawing.Size(228, 201);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 56;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            // 
            // btnPrint1
            // 
            this.btnPrint1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint1.Enabled = false;
            this.btnPrint1.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint1.Location = new System.Drawing.Point(119, 427);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Size = new System.Drawing.Size(104, 23);
            this.btnPrint1.TabIndex = 55;
            this.btnPrint1.Text = "Dự thi";
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(119, 456);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(9, 398);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(242, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(687, 200);
            this.dockPanel2.Size = new System.Drawing.Size(687, 509);
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
            this.dockPanel2_Container.Size = new System.Drawing.Size(679, 482);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcData.EnterMoveNextControl = true;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gcData.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(679, 482);
            this.gcData.TabIndex = 32;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemCheckAll,
            this.mnuItemUnCheckAll,
            this.mnu_DanhSach,
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuQuaTrinhHocTapToolStripMenuItem,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(169, 220);
            // 
            // mnu_DanhSach
            // 
            this.mnu_DanhSach.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDSTongHop,
            this.mnuDsThiTN,
            this.mnuDSKhongDT,
            this.mnuDSTongHop_VH});
            this.mnu_DanhSach.Name = "mnu_DanhSach";
            this.mnu_DanhSach.Size = new System.Drawing.Size(168, 22);
            this.mnu_DanhSach.Text = "Danh sách";
            // 
            // mnuDSTongHop
            // 
            this.mnuDSTongHop.Name = "mnuDSTongHop";
            this.mnuDSTongHop.Size = new System.Drawing.Size(234, 22);
            this.mnuDSTongHop.Text = "Danh sách tổng hợp";
            this.mnuDSTongHop.Click += new System.EventHandler(this.mnuDSTongHop_Click);
            // 
            // mnuDsThiTN
            // 
            this.mnuDsThiTN.Name = "mnuDsThiTN";
            this.mnuDsThiTN.Size = new System.Drawing.Size(234, 22);
            this.mnuDsThiTN.Text = "Danh sách dự thi";
            this.mnuDsThiTN.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // mnuDSKhongDT
            // 
            this.mnuDSKhongDT.Name = "mnuDSKhongDT";
            this.mnuDSKhongDT.Size = new System.Drawing.Size(234, 22);
            this.mnuDSKhongDT.Text = "Danh sách không dự thi";
            this.mnuDSKhongDT.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // mnuDSTongHop_VH
            // 
            this.mnuDSTongHop_VH.Name = "mnuDSTongHop_VH";
            this.mnuDSTongHop_VH.Size = new System.Drawing.Size(234, 22);
            this.mnuDSTongHop_VH.Text = "Danh sách tổng hợp - Văn hóa";
            this.mnuDSTongHop_VH.Click += new System.EventHandler(this.mnuDSTongHop_VH_Click);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Enabled = false;
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(168, 22);
            this.mnuItemSave.Text = "Lưu";
            this.mnuItemSave.Visible = false;
            this.mnuItemSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(168, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuQuaTrinhHocTapToolStripMenuItem
            // 
            this.mnuQuaTrinhHocTapToolStripMenuItem.Image = global::StudentManager.Properties.Resources.Process3;
            this.mnuQuaTrinhHocTapToolStripMenuItem.Name = "mnuQuaTrinhHocTapToolStripMenuItem";
            this.mnuQuaTrinhHocTapToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.mnuQuaTrinhHocTapToolStripMenuItem.Text = "Quá trình học tập";
            this.mnuQuaTrinhHocTapToolStripMenuItem.Click += new System.EventHandler(this.mnuQuaTrinhHocTapToolStripMenuItem_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Enabled = false;
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(168, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(168, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.LanguageID = 1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            // 
            // mnuItemCheckAll
            // 
            this.mnuItemCheckAll.Name = "mnuItemCheckAll";
            this.mnuItemCheckAll.Size = new System.Drawing.Size(168, 22);
            this.mnuItemCheckAll.Text = "Chọn tất cả";
            this.mnuItemCheckAll.Click += new System.EventHandler(this.mnuItemCheckAll_Click);
            // 
            // mnuItemUnCheckAll
            // 
            this.mnuItemUnCheckAll.Name = "mnuItemUnCheckAll";
            this.mnuItemUnCheckAll.Size = new System.Drawing.Size(168, 22);
            this.mnuItemUnCheckAll.Text = "Bỏ chọn tất cả";
            this.mnuItemUnCheckAll.Click += new System.EventHandler(this.mnuItemUnCheckAll_Click);
            // 
            // frmReviewGraduationExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 509);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmReviewGraduationExam";
            this.Text = "Xét dự thi tốt nghiệp";
            this.Load += new System.EventHandler(this.frmReviewGraduationExam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsNotShowReviewed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxOrderReview.Properties)).EndInit();
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
        private Control.DgButton btnPrint1;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.DgButton btnReview;
        private DevExpress.XtraEditors.ComboBoxEdit cbxOrderReview;
        private Control.DgLabel dgLabel1;
        private Control.DgButton btnSave;
        private Control.DgButton btnPrint2;
        private Control.DgRatioButton OptVanHoa;
        private Control.DgRatioButton OptTNCT;
        private Control.DgRatioButton OptNghe;
        private Control.DgRatioButton OptXetKhoaLuan;
        private Control.UTextEdit txtDiem;
        private System.Windows.Forms.ToolStripMenuItem mnu_DanhSach;
        private System.Windows.Forms.ToolStripMenuItem mnuDSTongHop;
        private System.Windows.Forms.ToolStripMenuItem mnuDsThiTN;
        private System.Windows.Forms.ToolStripMenuItem mnuDSKhongDT;
        private System.Windows.Forms.ToolStripMenuItem mnuQuaTrinhHocTapToolStripMenuItem;
        private Control.DgCheckEdit chkIsNotShowReviewed;
        private System.Windows.Forms.ToolStripMenuItem mnuDSTongHop_VH;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCheckAll;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUnCheckAll;
    }
}