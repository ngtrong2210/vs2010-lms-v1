namespace StudentManager.Learning
{
    partial class frmSyncSubjectMark
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
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.lookupOldClassSubjectID = new Control.ULookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveConfig = new Control.DgButton();
            this.btnConnect = new Control.DgButton();
            this.txtDBName = new Control.UTextEdit();
            this.txtServerName = new Control.UTextEdit();
            this.txtPassword = new Control.UTextEdit();
            this.txtLoginName = new Control.UTextEdit();
            this.uClass = new TrainingPlan.FramePlan.UClass1();
            this.btnClose = new Control.DgButton();
            this.btnSearch = new Control.DgButton();
            this.btnSave = new Control.DgButton();
            this.lookupClassSubjectID = new Control.ULookUpEdit();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcOldData = new Control.DgGridControl();
            this.gvOldData = new Control.DgAdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.bandedGridColumn7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridColumn1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcData = new Control.DgGridControl();
            this.gvData = new Control.DgAdvBandedGridView();
            this.btnModifyOldData = new Control.DgButton();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcOldData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOldData)).BeginInit();
            this.dockPanel3.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel1,
            this.panelContainer1});
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
            this.dockPanel1.OriginalSize = new System.Drawing.Size(247, 200);
            this.dockPanel1.Size = new System.Drawing.Size(247, 538);
            this.dockPanel1.Text = "THÔNG TIN TÌM KIẾM";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.btnModifyOldData);
            this.dockPanel1_Container.Controls.Add(this.lookupOldClassSubjectID);
            this.dockPanel1_Container.Controls.Add(this.groupBox1);
            this.dockPanel1_Container.Controls.Add(this.uClass);
            this.dockPanel1_Container.Controls.Add(this.btnClose);
            this.dockPanel1_Container.Controls.Add(this.btnSearch);
            this.dockPanel1_Container.Controls.Add(this.btnSave);
            this.dockPanel1_Container.Controls.Add(this.lookupClassSubjectID);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(239, 511);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // lookupOldClassSubjectID
            // 
            this.lookupOldClassSubjectID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupOldClassSubjectID.Caption = "Môn học cũ:";
            this.lookupOldClassSubjectID.DataSource = null;
            this.lookupOldClassSubjectID.EditorLeft = 90;
            this.lookupOldClassSubjectID.EditValue = null;
            this.lookupOldClassSubjectID.Location = new System.Drawing.Point(3, 204);
            this.lookupOldClassSubjectID.Name = "lookupOldClassSubjectID";
            this.lookupOldClassSubjectID.ReadOnly = false;
            this.lookupOldClassSubjectID.RowFilter = "";
            this.lookupOldClassSubjectID.Size = new System.Drawing.Size(232, 21);
            this.lookupOldClassSubjectID.TabIndex = 39;
            this.lookupOldClassSubjectID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveConfig);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtDBName);
            this.groupBox1.Controls.Add(this.txtServerName);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtLoginName);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.groupBox1.Location = new System.Drawing.Point(2, 332);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 157);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server cũ";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveConfig.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConfig.Appearance.Options.UseFont = true;
            this.btnSaveConfig.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSaveConfig.Location = new System.Drawing.Point(27, 122);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(98, 22);
            this.btnSaveConfig.TabIndex = 9;
            this.btnSaveConfig.Text = "Lưu cấu hình";
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Appearance.Options.UseFont = true;
            this.btnConnect.Image = global::StudentManager.Properties.Resources.Process3;
            this.btnConnect.Location = new System.Drawing.Point(131, 122);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(98, 22);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Kết nối thử";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBName.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDBName.Appearance.Options.UseForeColor = true;
            this.txtDBName.Caption = "Tên dữ liệu:";
            this.txtDBName.EditorLeft = 70;
            this.txtDBName.EditValue = null;
            this.txtDBName.EditValueDouble = null;
            this.txtDBName.EditValueInt32 = null;
            this.txtDBName.Location = new System.Drawing.Point(6, 95);
            this.txtDBName.MaxLength = 200;
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.PasswordChar = '\0';
            this.txtDBName.ReadOnly = false;
            this.txtDBName.Size = new System.Drawing.Size(223, 21);
            this.txtDBName.TabIndex = 7;
            this.txtDBName.TextTrim = "";
            // 
            // txtServerName
            // 
            this.txtServerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerName.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtServerName.Appearance.Options.UseForeColor = true;
            this.txtServerName.Caption = "Máy chủ:";
            this.txtServerName.EditorLeft = 70;
            this.txtServerName.EditValue = null;
            this.txtServerName.EditValueDouble = null;
            this.txtServerName.EditValueInt32 = null;
            this.txtServerName.Location = new System.Drawing.Point(6, 19);
            this.txtServerName.MaxLength = 200;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.PasswordChar = '\0';
            this.txtServerName.ReadOnly = false;
            this.txtServerName.Size = new System.Drawing.Size(223, 21);
            this.txtServerName.TabIndex = 4;
            this.txtServerName.TextTrim = "";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPassword.Appearance.Options.UseForeColor = true;
            this.txtPassword.Caption = "Mật khẩu:";
            this.txtPassword.EditorLeft = 70;
            this.txtPassword.EditValue = null;
            this.txtPassword.EditValueDouble = null;
            this.txtPassword.EditValueInt32 = null;
            this.txtPassword.Location = new System.Drawing.Point(6, 69);
            this.txtPassword.MaxLength = 200;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = false;
            this.txtPassword.Size = new System.Drawing.Size(223, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.TextTrim = "";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLoginName.Appearance.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLoginName.Appearance.Options.UseForeColor = true;
            this.txtLoginName.Caption = "Tài khoản:";
            this.txtLoginName.EditorLeft = 70;
            this.txtLoginName.EditValue = null;
            this.txtLoginName.EditValueDouble = null;
            this.txtLoginName.EditValueInt32 = null;
            this.txtLoginName.Location = new System.Drawing.Point(6, 44);
            this.txtLoginName.MaxLength = 200;
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.PasswordChar = '\0';
            this.txtLoginName.ReadOnly = false;
            this.txtLoginName.Size = new System.Drawing.Size(223, 21);
            this.txtLoginName.TabIndex = 5;
            this.txtLoginName.TextTrim = "";
            // 
            // uClass
            // 
            this.uClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uClass.BranchEditValue = null;
            this.uClass.ClassFilter = "";
            this.uClass.ClassIDEditValue = null;
            this.uClass.CourseIDEditValue = null;
            this.uClass.EditorLeft = 90;
            this.uClass.IsRegulation43 = false;
            this.uClass.Location = new System.Drawing.Point(4, 3);
            this.uClass.Name = "uClass";
            this.uClass.ReadOnly = false;
            this.uClass.ScienceFilter = "";
            this.uClass.ScienceIDEditValue = null;
            this.uClass.Semester = null;
            this.uClass.Size = new System.Drawing.Size(232, 195);
            this.uClass.SpecialBranchIDEditValue = null;
            this.uClass.SpecialBranchSubjectIDEditValue = null;
            this.uClass.TabIndex = 56;
            this.uClass.TrainingLevelIDEditValue = null;
            this.uClass.TrainingTypeEditValue = null;
            this.uClass.YearID = null;
            this.uClass.EditValueChanged += new TrainingPlan.FramePlan.UClass1.EditValueChangedDelegate(this.uClass_EditValueChanged);
            this.uClass.SpecialBranchSubjectChanged += new TrainingPlan.FramePlan.UClass1.SpecialBranchSubjectChangedDelegate(this.uClass_SpecialBranchSubjectChanged);
            this.uClass.Regulation43CheckChanged += new TrainingPlan.FramePlan.UClass1.Regulation43CheckChangedDelegate(this.chkIsRegulation43_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(165, 264);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(70, 23);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btnSearch.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(4, 264);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Tải điểm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Image = global::StudentManager.Properties.Resources.insert;
            this.btnSave.Location = new System.Drawing.Point(85, 264);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Chuyển";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lookupClassSubjectID
            // 
            this.lookupClassSubjectID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupClassSubjectID.Caption = "Môn học mới:";
            this.lookupClassSubjectID.DataSource = null;
            this.lookupClassSubjectID.EditorLeft = 90;
            this.lookupClassSubjectID.EditValue = null;
            this.lookupClassSubjectID.Location = new System.Drawing.Point(3, 231);
            this.lookupClassSubjectID.Name = "lookupClassSubjectID";
            this.lookupClassSubjectID.ReadOnly = false;
            this.lookupClassSubjectID.RowFilter = "";
            this.lookupClassSubjectID.Size = new System.Drawing.Size(232, 21);
            this.lookupClassSubjectID.TabIndex = 38;
            this.lookupClassSubjectID.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Controls.Add(this.dockPanel3);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContainer1.ID = new System.Guid("01f48ec3-91d2-4c25-b00a-016ef1660495");
            this.panelContainer1.Location = new System.Drawing.Point(247, 0);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(682, 200);
            this.panelContainer1.Size = new System.Drawing.Size(682, 538);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.ID = new System.Guid("5702986f-33f0-4dca-8fbc-e2d48a1e6fbd");
            this.dockPanel2.Location = new System.Drawing.Point(0, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.Options.ShowAutoHideButton = false;
            this.dockPanel2.Options.ShowCloseButton = false;
            this.dockPanel2.OriginalSize = new System.Drawing.Size(682, 264);
            this.dockPanel2.Size = new System.Drawing.Size(682, 264);
            this.dockPanel2.Text = "Điểm cũ";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dockPanel2_Container.Controls.Add(this.gcOldData);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(674, 237);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcOldData
            // 
            this.gcOldData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcOldData.Location = new System.Drawing.Point(-5, 0);
            this.gcOldData.MainView = this.gvOldData;
            this.gcOldData.Name = "gcOldData";
            this.gcOldData.Size = new System.Drawing.Size(680, 241);
            this.gcOldData.TabIndex = 23;
            this.gcOldData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvOldData});
            // 
            // gvOldData
            // 
            this.gvOldData.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.gvOldData.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Transparent;
            this.gvOldData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvOldData.Appearance.RowSeparator.BackColor = System.Drawing.SystemColors.ControlDark;
            this.gvOldData.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gvOldData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3});
            this.gvOldData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.bandedGridColumn2,
            this.bandedGridColumn3,
            this.bandedGridColumn4,
            this.bandedGridColumn5,
            this.bandedGridColumn6,
            this.bandedGridColumn7,
            this.bandedGridColumn8,
            this.bandedGridColumn1});
            this.gvOldData.CustomizationFormBounds = new System.Drawing.Rectangle(1048, 450, 223, 215);
            this.gvOldData.GridControl = this.gcOldData;
            this.gvOldData.IsSelecting = false;
            this.gvOldData.Name = "gvOldData";
            this.gvOldData.OptionsCustomization.AllowBandMoving = false;
            this.gvOldData.OptionsCustomization.AllowColumnMoving = false;
            this.gvOldData.OptionsCustomization.AllowGroup = false;
            this.gvOldData.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvOldData.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvOldData.OptionsSelection.InvertSelection = true;
            this.gvOldData.OptionsSelection.MultiSelect = true;
            this.gvOldData.OptionsView.ShowGroupPanel = false;
            this.gvOldData.ResetGridColumn = true;
            this.gvOldData.RowFilter = "";
            this.gvOldData.RowSeparatorHeight = 1;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Sinh Viên";
            this.gridBand1.Columns.Add(this.bandedGridColumn8);
            this.gridBand1.Columns.Add(this.bandedGridColumn2);
            this.gridBand1.Columns.Add(this.bandedGridColumn3);
            this.gridBand1.Columns.Add(this.bandedGridColumn4);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 320;
            // 
            // bandedGridColumn8
            // 
            this.bandedGridColumn8.Caption = "STT";
            this.bandedGridColumn8.FieldName = "Order";
            this.bandedGridColumn8.Name = "bandedGridColumn8";
            this.bandedGridColumn8.Visible = true;
            this.bandedGridColumn8.Width = 32;
            // 
            // bandedGridColumn2
            // 
            this.bandedGridColumn2.Caption = "Mã SV";
            this.bandedGridColumn2.FieldName = "MaSinhVien";
            this.bandedGridColumn2.Name = "bandedGridColumn2";
            this.bandedGridColumn2.Visible = true;
            this.bandedGridColumn2.Width = 71;
            // 
            // bandedGridColumn3
            // 
            this.bandedGridColumn3.Caption = "Họ đệm";
            this.bandedGridColumn3.FieldName = "Hodem";
            this.bandedGridColumn3.Name = "bandedGridColumn3";
            this.bandedGridColumn3.Visible = true;
            this.bandedGridColumn3.Width = 164;
            // 
            // bandedGridColumn4
            // 
            this.bandedGridColumn4.Caption = "Tên";
            this.bandedGridColumn4.FieldName = "Ten";
            this.bandedGridColumn4.Name = "bandedGridColumn4";
            this.bandedGridColumn4.Visible = true;
            this.bandedGridColumn4.Width = 53;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Điểm";
            this.gridBand2.Columns.Add(this.bandedGridColumn5);
            this.gridBand2.Columns.Add(this.bandedGridColumn6);
            this.gridBand2.Columns.Add(this.bandedGridColumn7);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 257;
            // 
            // bandedGridColumn5
            // 
            this.bandedGridColumn5.Caption = "Điểm lần 1";
            this.bandedGridColumn5.FieldName = "DL1";
            this.bandedGridColumn5.Name = "bandedGridColumn5";
            this.bandedGridColumn5.Visible = true;
            this.bandedGridColumn5.Width = 85;
            // 
            // bandedGridColumn6
            // 
            this.bandedGridColumn6.Caption = "Điểm lần 2";
            this.bandedGridColumn6.FieldName = "DL2";
            this.bandedGridColumn6.Name = "bandedGridColumn6";
            this.bandedGridColumn6.Visible = true;
            this.bandedGridColumn6.Width = 85;
            // 
            // bandedGridColumn7
            // 
            this.bandedGridColumn7.Caption = "Điểm lần 3";
            this.bandedGridColumn7.FieldName = "DL3";
            this.bandedGridColumn7.Name = "bandedGridColumn7";
            this.bandedGridColumn7.Visible = true;
            this.bandedGridColumn7.Width = 87;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Chọn";
            this.gridBand3.Columns.Add(this.bandedGridColumn1);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 51;
            // 
            // bandedGridColumn1
            // 
            this.bandedGridColumn1.Caption = "Chọn";
            this.bandedGridColumn1.FieldName = "IsSelected";
            this.bandedGridColumn1.Name = "bandedGridColumn1";
            this.bandedGridColumn1.Visible = true;
            this.bandedGridColumn1.Width = 51;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel3.ID = new System.Guid("f72da74f-4ce5-4584-97e5-4dd051c69dbd");
            this.dockPanel3.Location = new System.Drawing.Point(0, 264);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(682, 274);
            this.dockPanel3.Size = new System.Drawing.Size(682, 274);
            this.dockPanel3.Text = "Điểm mới";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.gcData);
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(674, 247);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.Location = new System.Drawing.Point(-2, 0);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(677, 248);
            this.gcData.TabIndex = 24;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
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
            this.gvData.IsSelecting = false;
            this.gvData.Name = "gvData";
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
            // 
            // btnModifyOldData
            // 
            this.btnModifyOldData.Image = global::StudentManager.Properties.Resources.sao;
            this.btnModifyOldData.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnModifyOldData.Location = new System.Drawing.Point(4, 303);
            this.btnModifyOldData.Name = "btnModifyOldData";
            this.btnModifyOldData.Size = new System.Drawing.Size(227, 23);
            this.btnModifyOldData.TabIndex = 24;
            this.btnModifyOldData.Text = "Hiệu chỉnh mã lớp trên dữ liệu cũ";
            this.btnModifyOldData.Click += new System.EventHandler(this.btnModifyOldData_Click);
            // 
            // frmSyncSubjectMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 538);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.dockPanel1);
            this.Name = "frmSyncSubjectMark";
            this.ShowIcon = false;
            this.Text = "Chuyển điểm TN từ hệ thống cũ";
            this.Load += new System.EventHandler(this.frmSyncSubjectMark_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcOldData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvOldData)).EndInit();
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
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
        private TrainingPlan.FramePlan.UClass1 uClass;
        private Control.ULookUpEdit lookupClassSubjectID;
        private Control.DgGridControl gcOldData;
        private Control.DgAdvBandedGridView gvOldData;
        private System.Windows.Forms.GroupBox groupBox1;
        private Control.UTextEdit txtDBName;
        private Control.UTextEdit txtServerName;
        private Control.UTextEdit txtPassword;
        private Control.UTextEdit txtLoginName;
        private Control.DgButton btnConnect;
        private Control.DgButton btnSaveConfig;
        private Control.ULookUpEdit lookupOldClassSubjectID;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private Control.DgGridControl gcData;
        private Control.DgAdvBandedGridView gvData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn bandedGridColumn1;
        private Control.DgButton btnModifyOldData;
    }
}