namespace StudentManager.StudentCollection
{
    partial class frmReviewStudentCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReviewStudentCollection));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dgLabel1 = new Control.DgLabel();
            this.cbxResult = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSave = new Control.DgButton();
            this.btnReview = new Control.DgButton();
            this.txtMaxQuantity = new Control.UCalcEdit();
            this.txtMinMark = new Control.UCalcEdit();
            this.txtFullName = new Control.UTextEdit();
            this.txtStudentCollectionCode = new Control.UTextEdit();
            this.uSpecialBranch = new DeclarationManager.Education.USpecialBranch();
            this.txtToDate = new Control.UDateEdit();
            this.uPeriod = new StudentManager.StudentCollection.UStudentCollectionPeriod();
            this.txtFromDate = new Control.UDateEdit();
            this.btnPrint = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.cbxResult.Properties)).BeginInit();
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
            this.dockPanel1.Size = new System.Drawing.Size(242, 485);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.dgLabel1);
            this.dockPanel1_Container.Controls.Add(this.cbxResult);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.btnReview);
            this.dockPanel1_Container.Controls.Add(this.txtMaxQuantity);
            this.dockPanel1_Container.Controls.Add(this.txtMinMark);
            this.dockPanel1_Container.Controls.Add(this.txtFullName);
            this.dockPanel1_Container.Controls.Add(this.txtStudentCollectionCode);
            this.dockPanel1_Container.Controls.Add(this.uSpecialBranch);
            this.dockPanel1_Container.Controls.Add(this.txtToDate);
            this.dockPanel1_Container.Controls.Add(this.uPeriod);
            this.dockPanel1_Container.Controls.Add(this.txtFromDate);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 458);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(7, 271);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(43, 14);
            this.dgLabel1.TabIndex = 85;
            this.dgLabel1.Text = "Xét NV:";
            // 
            // cbxResult
            // 
            this.cbxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxResult.EditValue = "--Chọn nguyện vọng--";
            this.cbxResult.Location = new System.Drawing.Point(97, 268);
            this.cbxResult.Name = "cbxResult";
            this.cbxResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxResult.Properties.Items.AddRange(new object[] {
            "--Chọn nguyện vọng--",
            "1. NV1",
            "2. NV2",
            "3. NV3"});
            this.cbxResult.Size = new System.Drawing.Size(134, 20);
            this.cbxResult.TabIndex = 84;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(12, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 23);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Cập nhật";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReview
            // 
            this.btnReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReview.Enabled = false;
            this.btnReview.Image = global::StudentManager.Properties.Resources.Process3;
            this.btnReview.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnReview.Location = new System.Drawing.Point(122, 374);
            this.btnReview.Name = "btnReview";
            this.btnReview.Size = new System.Drawing.Size(104, 23);
            this.btnReview.TabIndex = 24;
            this.btnReview.Text = "Xét tuyển";
            this.btnReview.Click += new System.EventHandler(this.btnReview_Click);
            // 
            // txtMaxQuantity
            // 
            this.txtMaxQuantity.Caption = "Chỉ tiêu:";
            this.txtMaxQuantity.EditMask = "";
            this.txtMaxQuantity.EditorLeft = 90;
            this.txtMaxQuantity.EditValue = 0;
            this.txtMaxQuantity.EditValueDouble = 0D;
            this.txtMaxQuantity.EditValueInt32 = 0;
            this.txtMaxQuantity.Location = new System.Drawing.Point(8, 339);
            this.txtMaxQuantity.MaxLength = 0;
            this.txtMaxQuantity.Name = "txtMaxQuantity";
            this.txtMaxQuantity.ReadOnly = false;
            this.txtMaxQuantity.Size = new System.Drawing.Size(223, 21);
            this.txtMaxQuantity.TabIndex = 64;
            // 
            // txtMinMark
            // 
            this.txtMinMark.Caption = "Điểm xét tuyển:";
            this.txtMinMark.EditMask = "";
            this.txtMinMark.EditorLeft = 90;
            this.txtMinMark.EditValue = 0;
            this.txtMinMark.EditValueDouble = 0D;
            this.txtMinMark.EditValueInt32 = 0;
            this.txtMinMark.Location = new System.Drawing.Point(8, 312);
            this.txtMinMark.MaxLength = 0;
            this.txtMinMark.Name = "txtMinMark";
            this.txtMinMark.ReadOnly = false;
            this.txtMinMark.Size = new System.Drawing.Size(223, 21);
            this.txtMinMark.TabIndex = 63;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Caption = "Họ tên:";
            this.txtFullName.EditorLeft = 90;
            this.txtFullName.EditValue = null;
            this.txtFullName.EditValueDouble = null;
            this.txtFullName.EditValueInt32 = null;
            this.txtFullName.Location = new System.Drawing.Point(8, 241);
            this.txtFullName.MaxLength = 0;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PasswordChar = '\0';
            this.txtFullName.ReadOnly = false;
            this.txtFullName.Size = new System.Drawing.Size(223, 21);
            this.txtFullName.TabIndex = 61;
            this.txtFullName.TextTrim = "";
            // 
            // txtStudentCollectionCode
            // 
            this.txtStudentCollectionCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentCollectionCode.Caption = "Số HS:";
            this.txtStudentCollectionCode.EditorLeft = 90;
            this.txtStudentCollectionCode.EditValue = null;
            this.txtStudentCollectionCode.EditValueDouble = null;
            this.txtStudentCollectionCode.EditValueInt32 = null;
            this.txtStudentCollectionCode.Location = new System.Drawing.Point(8, 214);
            this.txtStudentCollectionCode.MaxLength = 0;
            this.txtStudentCollectionCode.Name = "txtStudentCollectionCode";
            this.txtStudentCollectionCode.PasswordChar = '\0';
            this.txtStudentCollectionCode.ReadOnly = false;
            this.txtStudentCollectionCode.Size = new System.Drawing.Size(223, 21);
            this.txtStudentCollectionCode.TabIndex = 60;
            this.txtStudentCollectionCode.TextTrim = "";
            // 
            // uSpecialBranch
            // 
            this.uSpecialBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uSpecialBranch.BranchEditValue = null;
            this.uSpecialBranch.BranchFilter = "";
            this.uSpecialBranch.EditorLeft = 90;
            this.uSpecialBranch.Location = new System.Drawing.Point(8, 110);
            this.uSpecialBranch.Name = "uSpecialBranch";
            this.uSpecialBranch.ReadOnly = false;
            this.uSpecialBranch.Size = new System.Drawing.Size(223, 46);
            this.uSpecialBranch.SpecialBranchEditValue = null;
            this.uSpecialBranch.SpecialBranchFilter = "";
            this.uSpecialBranch.TabIndex = 59;
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.Caption = "Đến ngày:";
            this.txtToDate.EditorLeft = 90;
            this.txtToDate.EditValue = null;
            this.txtToDate.EditValueDateTime = null;
            this.txtToDate.Location = new System.Drawing.Point(8, 187);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.ReadOnly = false;
            this.txtToDate.Size = new System.Drawing.Size(223, 21);
            this.txtToDate.TabIndex = 52;
            // 
            // uPeriod
            // 
            this.uPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uPeriod.CollectionType = -1;
            this.uPeriod.CourseIDEditValue = null;
            this.uPeriod.EditorLeft = 90;
            this.uPeriod.LearningLevel = -1;
            this.uPeriod.Location = new System.Drawing.Point(8, 3);
            this.uPeriod.Name = "uPeriod";
            this.uPeriod.ReadOnly = false;
            this.uPeriod.Size = new System.Drawing.Size(223, 112);
            this.uPeriod.StudentCollectionPeriodIDEditValue = null;
            this.uPeriod.TabIndex = 58;
            this.uPeriod.TrainingLevelIDEditValue = null;
            this.uPeriod.TrainingTypeEditValue = null;
            this.uPeriod.EditValueChanged += new StudentManager.StudentCollection.UStudentCollectionPeriod.EditValueChangedDelegate(this.uPeriod_EditValueChanged);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromDate.Caption = "Từ ngày:";
            this.txtFromDate.EditorLeft = 90;
            this.txtFromDate.EditValue = null;
            this.txtFromDate.EditValueDateTime = null;
            this.txtFromDate.Location = new System.Drawing.Point(8, 161);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ReadOnly = false;
            this.txtFromDate.Size = new System.Drawing.Size(223, 21);
            this.txtFromDate.TabIndex = 51;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(12, 432);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(214, 23);
            this.btnPrint.TabIndex = 55;
            this.btnPrint.Text = "In danh sách xét tuyển";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(122, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 374);
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
            this.dockPanel2.Size = new System.Drawing.Size(687, 485);
            this.dockPanel2.Text = "Hồ sơ tuyển sinh";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(679, 458);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            gridLevelNode1.RelationName = "Level1";
            gridLevelNode2.RelationName = "Level2";
            this.gcData.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2});
            this.gcData.Location = new System.Drawing.Point(0, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(679, 455);
            this.gcData.TabIndex = 32;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemEdit,
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
            // mnuItemEdit
            // 
            this.mnuItemEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.Size = new System.Drawing.Size(167, 22);
            this.mnuItemEdit.Text = "Xem chi tiết";
            this.mnuItemEdit.Click += new System.EventHandler(this.mnuItemEdit_Click);
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
            this.mnuItemSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.mnuItemExportToExcel.Click += new System.EventHandler(this.mnuItemExportToExcel_Click);
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
            this.gvData.IsSelecting = false;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.EndSorting += new System.EventHandler(this.gvData_EndSorting);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // frmReviewStudentCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 485);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.KeyPreview = true;
            this.Name = "frmReviewStudentCollection";
            this.ShowIcon = false;
            this.Text = "Xét tuyển sinh viên";
            this.Load += new System.EventHandler(this.frmReviewStudentCollection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReviewStudentCollection_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxResult.Properties)).EndInit();
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
        private Control.DgButton btnPrint;
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
        private UStudentCollectionPeriod uPeriod;
        private Control.UTextEdit txtFullName;
        private Control.UTextEdit txtStudentCollectionCode;
        private DeclarationManager.Education.USpecialBranch uSpecialBranch;
        private Control.UDateEdit txtToDate;
        private Control.UDateEdit txtFromDate;
        private Control.UCalcEdit txtMaxQuantity;
        private Control.UCalcEdit txtMinMark;
        private Control.DgButton btnReview;
        private Control.DgButton btnSave;
        private Control.DgLabel dgLabel1;
        private DevExpress.XtraEditors.ComboBoxEdit cbxResult;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}