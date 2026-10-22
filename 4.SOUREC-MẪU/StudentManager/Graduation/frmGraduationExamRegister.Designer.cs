namespace StudentManager.Graduation
{
    partial class frmGraduationExamRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGraduationExamRegister));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.txtMoney = new Control.UCalcEdit();
            this.lookupExamDate = new Control.ULookUpEdit();
            this.chkTotNghiepNghe = new Control.DgCheckEdit();
            this.chkTotNghiepChinhTri = new Control.DgCheckEdit();
            this.chkTotNghiepVanHoa = new Control.DgCheckEdit();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnClose = new Control.DgButton();
            this.btnSave = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUnCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkTotNghiepNghe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTotNghiepChinhTri.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTotNghiepVanHoa.Properties)).BeginInit();
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(249, 200);
            this.dockPanel1.Size = new System.Drawing.Size(249, 469);
            this.dockPanel1.Text = "THÔNG TIN TÌM KIẾM";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.txtMoney);
            this.dockPanel1_Container.Controls.Add(this.lookupExamDate);
            this.dockPanel1_Container.Controls.Add(this.chkTotNghiepNghe);
            this.dockPanel1_Container.Controls.Add(this.chkTotNghiepChinhTri);
            this.dockPanel1_Container.Controls.Add(this.chkTotNghiepVanHoa);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(241, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // txtMoney
            // 
            this.txtMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMoney.Caption = "Phí dự thi:";
            this.txtMoney.DisplayMask = "#,###";
            this.txtMoney.EditMask = "";
            this.txtMoney.EditorLeft = 90;
            this.txtMoney.EditValue = ((long)(0));
            this.txtMoney.EditValueDouble = 0D;
            this.txtMoney.EditValueInt32 = 0;
            this.txtMoney.EditValueInt64 = ((long)(0));
            this.txtMoney.Location = new System.Drawing.Point(3, 313);
            this.txtMoney.MaxLength = 0;
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = false;
            this.txtMoney.Size = new System.Drawing.Size(231, 21);
            this.txtMoney.TabIndex = 42;
            this.txtMoney.Load += new System.EventHandler(this.txtMoney_Load);
            // 
            // lookupExamDate
            // 
            this.lookupExamDate.AllowNull = true;
            this.lookupExamDate.Caption = "Kì tổ chức thi:";
            this.lookupExamDate.DataSource = null;
            this.lookupExamDate.EditorLeft = 90;
            this.lookupExamDate.EditValue = null;
            this.lookupExamDate.Location = new System.Drawing.Point(3, 286);
            this.lookupExamDate.Name = "lookupExamDate";
            this.lookupExamDate.ReadOnly = false;
            this.lookupExamDate.RowFilter = "";
            this.lookupExamDate.Size = new System.Drawing.Size(231, 21);
            this.lookupExamDate.TabIndex = 63;
            this.lookupExamDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // chkTotNghiepNghe
            // 
            this.chkTotNghiepNghe.EnterMoveNextControl = true;
            this.chkTotNghiepNghe.Location = new System.Drawing.Point(8, 261);
            this.chkTotNghiepNghe.Name = "chkTotNghiepNghe";
            this.chkTotNghiepNghe.Properties.Caption = "TN nghề";
            this.chkTotNghiepNghe.Size = new System.Drawing.Size(97, 19);
            this.chkTotNghiepNghe.TabIndex = 58;
            this.chkTotNghiepNghe.CheckedChanged += new System.EventHandler(this.chkTotNghiepVanHoa_CheckedChanged);
            // 
            // chkTotNghiepChinhTri
            // 
            this.chkTotNghiepChinhTri.EnterMoveNextControl = true;
            this.chkTotNghiepChinhTri.Location = new System.Drawing.Point(8, 236);
            this.chkTotNghiepChinhTri.Name = "chkTotNghiepChinhTri";
            this.chkTotNghiepChinhTri.Properties.Caption = "TN chính trị";
            this.chkTotNghiepChinhTri.Size = new System.Drawing.Size(97, 19);
            this.chkTotNghiepChinhTri.TabIndex = 58;
            this.chkTotNghiepChinhTri.CheckedChanged += new System.EventHandler(this.chkTotNghiepVanHoa_CheckedChanged);
            // 
            // chkTotNghiepVanHoa
            // 
            this.chkTotNghiepVanHoa.EnterMoveNextControl = true;
            this.chkTotNghiepVanHoa.Location = new System.Drawing.Point(8, 211);
            this.chkTotNghiepVanHoa.Name = "chkTotNghiepVanHoa";
            this.chkTotNghiepVanHoa.Properties.Caption = "TN văn hoá";
            this.chkTotNghiepVanHoa.Size = new System.Drawing.Size(97, 19);
            this.chkTotNghiepVanHoa.TabIndex = 57;
            this.chkTotNghiepVanHoa.CheckedChanged += new System.EventHandler(this.chkTotNghiepVanHoa_CheckedChanged);
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
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(3, 3);
            this.uClass.Name = "uClass";
            this.uClass.OfficeIDEditValue = null;
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(231, 198);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 56;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            this.uClass.EditValueChanged += new TrainingPlan.FramePlan.UClass1.EditValueChangedDelegate(this.uClass_EditValueChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(163, 411);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(83, 411);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(3, 411);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(74, 23);
            this.btnSearch.TabIndex = 23;
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
            this.dockPanel2.Size = new System.Drawing.Size(680, 469);
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
            this.dockPanel2_Container.Size = new System.Drawing.Size(672, 442);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(-2, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(675, 443);
            this.gcData.TabIndex = 33;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemCheckAll,
            this.mnuItemUnCheckAll,
            this.toolStripSeparator4,
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(168, 160);
            // 
            // mnuItemCheckAll
            // 
            this.mnuItemCheckAll.Image = global::StudentManager.Properties.Resources.CheckIcon;
            this.mnuItemCheckAll.Name = "mnuItemCheckAll";
            this.mnuItemCheckAll.Size = new System.Drawing.Size(167, 22);
            this.mnuItemCheckAll.Text = "Chọn hết";
            this.mnuItemCheckAll.Click += new System.EventHandler(this.mnuItemCheckAll_Click);
            // 
            // mnuItemUnCheckAll
            // 
            this.mnuItemUnCheckAll.Image = global::StudentManager.Properties.Resources.UnCheckIcon;
            this.mnuItemUnCheckAll.Name = "mnuItemUnCheckAll";
            this.mnuItemUnCheckAll.Size = new System.Drawing.Size(167, 22);
            this.mnuItemUnCheckAll.Text = "Bỏ chọn hết";
            this.mnuItemUnCheckAll.Click += new System.EventHandler(this.mnuItemUnCheckAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(167, 22);
            this.mnuItemSave.Text = "Lưu";
            this.mnuItemSave.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuItemRefresh
            // 
            this.mnuItemRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemRefresh.Image")));
            this.mnuItemRefresh.Name = "mnuItemRefresh";
            this.mnuItemRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuItemRefresh.Size = new System.Drawing.Size(167, 22);
            this.mnuItemRefresh.Text = "Nạp lại";
            this.mnuItemRefresh.Click += new System.EventHandler(this.mnuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Name = "mnuItemExportToExcel";
            this.mnuItemExportToExcel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.mnuItemExportToExcel.Size = new System.Drawing.Size(167, 22);
            this.mnuItemExportToExcel.Text = "Xuất excel";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(167, 22);
            this.mnuItemClose.Text = "Đóng";
            // 
            // gvData
            // 
            this.gvData.GridControl = this.gcData;
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.LanguageID = 1;
            this.gvData.Name = "gvData";
            this.gvData.OptionsMenu.EnableColumnMenu = false;
            this.gvData.OptionsMenu.EnableFooterMenu = false;
            this.gvData.OptionsMenu.EnableGroupPanelMenu = false;
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            this.gvData.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvData_ShowingEditor);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            this.gvData.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvData_ValidatingEditor);
            // 
            // frmGraduationExamRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 469);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmGraduationExamRegister";
            this.ShowIcon = false;
            this.Text = "Đăng ký dự thi tốt nghiệp";
            this.Load += new System.EventHandler(this.frmMakeStudentCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkTotNghiepNghe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTotNghiepChinhTri.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTotNghiepVanHoa.Properties)).EndInit();
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
        private Control.DgButton btnSave;
        private Control.DgButton btnClose;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCheckAll;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUnCheckAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private Control.DgCheckEdit chkTotNghiepNghe;
        private Control.DgCheckEdit chkTotNghiepChinhTri;
        private Control.DgCheckEdit chkTotNghiepVanHoa;
        private Control.ULookUpEdit lookupExamDate;
        private Control.UCalcEdit txtMoney;
    }
}