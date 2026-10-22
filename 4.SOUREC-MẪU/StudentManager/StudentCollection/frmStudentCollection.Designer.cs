namespace StudentManager.StudentCollection
{
    partial class frmStudentCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudentCollection));
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.rdioNV3 = new System.Windows.Forms.RadioButton();
            this.txtFullName = new Control.UTextEdit();
            this.rdioNV2 = new System.Windows.Forms.RadioButton();
            this.txtStudentCollectionCode = new Control.UTextEdit();
            this.rdioNV1 = new System.Windows.Forms.RadioButton();
            this.uSpecialBranch = new DeclarationManager.Education.USpecialBranch();
            this.rdioAll = new System.Windows.Forms.RadioButton();
            this.txtToDate = new Control.UDateEdit();
            this.uPeriod = new StudentManager.StudentCollection.UStudentCollectionPeriod();
            this.txtFromDate = new Control.UDateEdit();
            this.btnAdd = new Control.DgButton();
            this.btnDelete = new Control.DgButton();
            this.btnPrint = new Control.DgButton();
            this.btnClose = new Control.DgButton();
            this.btnEdit = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemPrintCheckCer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrint3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgAdvBandedGridView();
            this.cbxResult = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dgLabel1 = new Control.DgLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxResult.Properties)).BeginInit();
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
            this.dockPanel1.Size = new System.Drawing.Size(242, 469);
            this.dockPanel1.Text = "Thông tin tìm kiếm";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.dgLabel1);
            this.dockPanel1_Container.Controls.Add(this.cbxResult);
            this.dockPanel1_Container.Controls.Add(this.rdioNV3);
            this.dockPanel1_Container.Controls.Add(this.txtFullName);
            this.dockPanel1_Container.Controls.Add(this.rdioNV2);
            this.dockPanel1_Container.Controls.Add(this.txtStudentCollectionCode);
            this.dockPanel1_Container.Controls.Add(this.rdioNV1);
            this.dockPanel1_Container.Controls.Add(this.uSpecialBranch);
            this.dockPanel1_Container.Controls.Add(this.rdioAll);
            this.dockPanel1_Container.Controls.Add(this.txtToDate);
            this.dockPanel1_Container.Controls.Add(this.uPeriod);
            this.dockPanel1_Container.Controls.Add(this.txtFromDate);
            this.dockPanel1_Container.Controls.Add(this.btnAdd);
            this.dockPanel1_Container.Controls.Add(this.btnDelete);
            this.dockPanel1_Container.Controls.Add(this.btnPrint);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnEdit);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(234, 442);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // rdioNV3
            // 
            this.rdioNV3.AutoSize = true;
            this.rdioNV3.Location = new System.Drawing.Point(119, 291);
            this.rdioNV3.Name = "rdioNV3";
            this.rdioNV3.Size = new System.Drawing.Size(98, 17);
            this.rdioNV3.TabIndex = 72;
            this.rdioNV3.Text = "Nguyện vọng 3";
            this.rdioNV3.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.AllowNull = true;
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Caption = "Họ tên:";
            this.txtFullName.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtFullName.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtFullName.EditorLeft = 85;
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
            // rdioNV2
            // 
            this.rdioNV2.AutoSize = true;
            this.rdioNV2.Location = new System.Drawing.Point(8, 291);
            this.rdioNV2.Name = "rdioNV2";
            this.rdioNV2.Size = new System.Drawing.Size(98, 17);
            this.rdioNV2.TabIndex = 71;
            this.rdioNV2.Text = "Nguyện vọng 2";
            this.rdioNV2.UseVisualStyleBackColor = true;
            // 
            // txtStudentCollectionCode
            // 
            this.txtStudentCollectionCode.AllowNull = true;
            this.txtStudentCollectionCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStudentCollectionCode.Caption = "Số HS:";
            this.txtStudentCollectionCode.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentCollectionCode.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentCollectionCode.EditorLeft = 85;
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
            // rdioNV1
            // 
            this.rdioNV1.AutoSize = true;
            this.rdioNV1.Location = new System.Drawing.Point(119, 268);
            this.rdioNV1.Name = "rdioNV1";
            this.rdioNV1.Size = new System.Drawing.Size(98, 17);
            this.rdioNV1.TabIndex = 70;
            this.rdioNV1.Text = "Nguyện vọng 1";
            this.rdioNV1.UseVisualStyleBackColor = true;
            // 
            // uSpecialBranch
            // 
            this.uSpecialBranch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uSpecialBranch.BranchEditValue = null;
            this.uSpecialBranch.BranchFilter = "";
            this.uSpecialBranch.EditorLeft = 85;
            this.uSpecialBranch.Location = new System.Drawing.Point(8, 110);
            this.uSpecialBranch.Name = "uSpecialBranch";
            this.uSpecialBranch.ReadOnly = false;
            this.uSpecialBranch.Size = new System.Drawing.Size(223, 46);
            this.uSpecialBranch.SpecialBranchEditValue = null;
            this.uSpecialBranch.SpecialBranchFilter = "";
            this.uSpecialBranch.TabIndex = 59;
            // 
            // rdioAll
            // 
            this.rdioAll.AutoSize = true;
            this.rdioAll.Checked = true;
            this.rdioAll.Location = new System.Drawing.Point(8, 268);
            this.rdioAll.Name = "rdioAll";
            this.rdioAll.Size = new System.Drawing.Size(55, 17);
            this.rdioAll.TabIndex = 69;
            this.rdioAll.TabStop = true;
            this.rdioAll.Text = "Tất cả";
            this.rdioAll.UseVisualStyleBackColor = true;
            // 
            // txtToDate
            // 
            this.txtToDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToDate.Caption = "Đến ngày:";
            this.txtToDate.EditorLeft = 85;
            this.txtToDate.EditValue = null;
            this.txtToDate.EditValueDate = null;
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
            this.uPeriod.EditorLeft = 85;
            this.uPeriod.LearningLevel = -1;
            this.uPeriod.Location = new System.Drawing.Point(8, 3);
            this.uPeriod.Name = "uPeriod";
            this.uPeriod.ReadOnly = false;
            this.uPeriod.Size = new System.Drawing.Size(223, 101);
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
            this.txtFromDate.EditorLeft = 85;
            this.txtFromDate.EditValue = null;
            this.txtFromDate.EditValueDate = null;
            this.txtFromDate.EditValueDateTime = null;
            this.txtFromDate.Location = new System.Drawing.Point(8, 161);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.ReadOnly = false;
            this.txtFromDate.Size = new System.Drawing.Size(223, 21);
            this.txtFromDate.TabIndex = 51;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(119, 358);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 23);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(12, 387);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 23);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::StudentManager.Properties.Resources.print;
            this.btnPrint.Location = new System.Drawing.Point(12, 416);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(104, 23);
            this.btnPrint.TabIndex = 55;
            this.btnPrint.Text = "In danh sách";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(119, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(104, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(119, 387);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 23);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 358);
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
            this.dockPanel2.Size = new System.Drawing.Size(687, 469);
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
            this.dockPanel2_Container.Size = new System.Drawing.Size(679, 442);
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
            this.gcData.Size = new System.Drawing.Size(679, 439);
            this.gcData.TabIndex = 32;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
            this.gcData.DoubleClick += new System.EventHandler(this.btnEdit_Click);
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemAdd,
            this.mnuItemDelete,
            this.mnuItemEdit,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemPrintCheckCer,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(168, 176);
            // 
            // mnuItemAdd
            // 
            this.mnuItemAdd.Enabled = false;
            this.mnuItemAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.mnuItemAdd.Name = "mnuItemAdd";
            this.mnuItemAdd.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuItemAdd.Size = new System.Drawing.Size(167, 22);
            this.mnuItemAdd.Text = "Thêm";
            this.mnuItemAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Enabled = false;
            this.mnuItemDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuItemDelete.Size = new System.Drawing.Size(167, 22);
            this.mnuItemDelete.Text = "Xóa";
            this.mnuItemDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.Size = new System.Drawing.Size(167, 22);
            this.mnuItemEdit.Text = "Sửa";
            this.mnuItemEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            // mnuItemPrintCheckCer
            // 
            this.mnuItemPrintCheckCer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPrint2,
            this.mnuPrint3});
            this.mnuItemPrintCheckCer.Name = "mnuItemPrintCheckCer";
            this.mnuItemPrintCheckCer.Size = new System.Drawing.Size(167, 22);
            this.mnuItemPrintCheckCer.Text = "In kiểm tra hồ sơ";
            // 
            // mnuPrint2
            // 
            this.mnuPrint2.Name = "mnuPrint2";
            this.mnuPrint2.Size = new System.Drawing.Size(190, 22);
            this.mnuPrint2.Text = "In danh sách hồ sơ A3";
            this.mnuPrint2.Click += new System.EventHandler(this.mnuPrint2_Click);
            // 
            // mnuPrint3
            // 
            this.mnuPrint3.Name = "mnuPrint3";
            this.mnuPrint3.Size = new System.Drawing.Size(190, 22);
            this.mnuPrint3.Text = "In danh sách hồ sơ A4";
            this.mnuPrint3.Click += new System.EventHandler(this.mnuPrint3_Click);
            // 
            // mnuItemExportToExcel
            // 
            this.mnuItemExportToExcel.Enabled = false;
            this.mnuItemExportToExcel.Image = global::StudentManager.Properties.Resources.excel;
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
            this.gvData.IndicatorWidth = 35;
            this.gvData.IsSelecting = false;
            this.gvData.Name = "gvData";
            this.gvData.OptionsSelection.MultiSelect = true;
            this.gvData.OptionsView.ColumnAutoWidth = false;
            this.gvData.OptionsView.ShowAutoFilterRow = true;
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvData_SelectionChanged);
            this.gvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvData_ValidateRow);
            // 
            // cbxResult
            // 
            this.cbxResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxResult.EditValue = "1. Tất cả";
            this.cbxResult.Location = new System.Drawing.Point(97, 314);
            this.cbxResult.Name = "cbxResult";
            this.cbxResult.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxResult.Properties.Items.AddRange(new object[] {
            "1. Tất cả",
            "2. Trúng tuyển"});
            this.cbxResult.Size = new System.Drawing.Size(134, 20);
            this.cbxResult.TabIndex = 83;
            // 
            // dgLabel1
            // 
            this.dgLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.dgLabel1.Location = new System.Drawing.Point(8, 317);
            this.dgLabel1.Name = "dgLabel1";
            this.dgLabel1.Size = new System.Drawing.Size(60, 14);
            this.dgLabel1.TabIndex = 84;
            this.dgLabel1.Text = "Trạng thái:";
            // 
            // frmStudentCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 469);
            this.Controls.Add(this.dockPanel2);
            this.Controls.Add(this.dockPanel1);
            this.KeyPreview = true;
            this.Name = "frmStudentCollection";
            this.ShowIcon = false;
            this.Text = "Danh sách hồ sơ tuyển sinh";
            this.Load += new System.EventHandler(this.frmStudentCollection_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStudentCollection_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel1_Container.PerformLayout();
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxResult.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private Control.DgButton btnSearch;
        private Control.DgButton btnEdit;
        private Control.DgButton btnClose;
        private Control.DgButton btnPrint;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private Control.DgButton btnAdd;
        private Control.DgButton btnDelete;
        private Control.UTextEdit txtFullName;
        private Control.UTextEdit txtStudentCollectionCode;
        private DeclarationManager.Education.USpecialBranch uSpecialBranch;
        private Control.UDateEdit txtToDate;
        private Control.UDateEdit txtFromDate;
        private UStudentCollectionPeriod uPeriod;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemPrintCheckCer;
        private System.Windows.Forms.RadioButton rdioNV3;
        private System.Windows.Forms.RadioButton rdioNV2;
        private System.Windows.Forms.RadioButton rdioNV1;
        private System.Windows.Forms.RadioButton rdioAll;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint2;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint3;
        private DevExpress.XtraEditors.ComboBoxEdit cbxResult;
        private Control.DgLabel dgLabel1;
    }
}