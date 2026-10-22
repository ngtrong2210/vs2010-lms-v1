namespace StudentManager.Graduation
{
    partial class frmExamDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamDate));
            this.gcData = new Control.DgGridControl();
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.gvData = new Control.DgGridView();
            this.tcData = new Control.DgTabControl();
            this.tpList = new Control.DgTabPage();
            this.btnClose = new Control.DgButton();
            this.btnEdit = new Control.DgButton();
            this.btnDelete = new Control.DgButton();
            this.btnAdd = new Control.DgButton();
            this.tpDetail = new Control.DgTabPage();
            this.uYearSemester = new DeclarationManager.Education.UYearSemester();
            this.dtmExamDate = new Control.UDateEdit();
            this.txtOrderIndex = new Control.UCalcEdit();
            this.chkIsDefault = new Control.DgCheckEdit();
            this.chkIsActived = new Control.DgCheckEdit();
            this.txtDescription = new Control.URichTextEdit();
            this.btnCancel = new Control.DgButton();
            this.btnSaveEdit = new Control.DgButton();
            this.txtExamDateName = new Control.UTextEdit();
            this.chkIsGraduation = new Control.DgCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).BeginInit();
            this.tcData.SuspendLayout();
            this.tpList.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActived.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsGraduation.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.EnterMoveNextControl = true;
            this.gcData.Location = new System.Drawing.Point(-1, -1);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(614, 315);
            this.gcData.TabIndex = 0;
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
            this.mnuItemSave,
            this.toolStripSeparator3,
            this.mnuItemRefresh,
            this.toolStripSeparator1,
            this.mnuItemExportToExcel,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(168, 176);
            // 
            // mnuItemAdd
            // 
            this.mnuItemAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.mnuItemAdd.Name = "mnuItemAdd";
            this.mnuItemAdd.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.mnuItemAdd.Size = new System.Drawing.Size(167, 22);
            this.mnuItemAdd.Text = "Thêm";
            this.mnuItemAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mnuItemDelete
            // 
            this.mnuItemDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.mnuItemDelete.Name = "mnuItemDelete";
            this.mnuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.mnuItemDelete.Size = new System.Drawing.Size(167, 22);
            this.mnuItemDelete.Text = "Xóa";
            this.mnuItemDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // mnuItemEdit
            // 
            this.mnuItemEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.mnuItemEdit.Name = "mnuItemEdit";
            this.mnuItemEdit.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuItemEdit.Size = new System.Drawing.Size(167, 22);
            this.mnuItemEdit.Text = "Sửa";
            this.mnuItemEdit.Click += new System.EventHandler(this.btnEdit_Click);
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
            this.gvData.OptionsView.ShowGroupPanel = false;
            this.gvData.ResetGridColumn = true;
            this.gvData.RowFilter = "";
            this.gvData.SummaryCollection = "";
            this.gvData.SummaryDisplayFormat = null;
            this.gvData.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gvData_SelectionChanged);
            this.gvData.EndSorting += new System.EventHandler(this.gvData_EndSorting);
            // 
            // tcData
            // 
            this.tcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcData.Location = new System.Drawing.Point(0, 0);
            this.tcData.Name = "tcData";
            this.tcData.SelectedTabPage = this.tpList;
            this.tcData.SelectIndex = 1;
            this.tcData.Size = new System.Drawing.Size(619, 376);
            this.tcData.TabIndex = 1;
            this.tcData.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tpList,
            this.tpDetail});
            this.tcData.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.tcData_SelectedPageChanging);
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.btnClose);
            this.tpList.Controls.Add(this.btnEdit);
            this.tpList.Controls.Add(this.btnDelete);
            this.tpList.Controls.Add(this.btnAdd);
            this.tpList.Controls.Add(this.gcData);
            this.tpList.Name = "tpList";
            this.tpList.Size = new System.Drawing.Size(613, 350);
            this.tpList.Text = "Danh sách kì thi";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::StudentManager.Properties.Resources.Cancel;
            this.btnClose.Location = new System.Drawing.Point(530, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Image = global::StudentManager.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(165, 320);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Sửa  ";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Image = global::StudentManager.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(84, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xoá  ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Image = global::StudentManager.Properties.Resources.Add;
            this.btnAdd.Location = new System.Drawing.Point(3, 320);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm  ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tpDetail
            // 
            this.tpDetail.Controls.Add(this.chkIsGraduation);
            this.tpDetail.Controls.Add(this.uYearSemester);
            this.tpDetail.Controls.Add(this.dtmExamDate);
            this.tpDetail.Controls.Add(this.txtOrderIndex);
            this.tpDetail.Controls.Add(this.chkIsDefault);
            this.tpDetail.Controls.Add(this.chkIsActived);
            this.tpDetail.Controls.Add(this.txtDescription);
            this.tpDetail.Controls.Add(this.btnCancel);
            this.tpDetail.Controls.Add(this.btnSaveEdit);
            this.tpDetail.Controls.Add(this.txtExamDateName);
            this.tpDetail.Name = "tpDetail";
            this.tpDetail.Size = new System.Drawing.Size(613, 350);
            this.tpDetail.Text = "Chi tiết kì thi";
            // 
            // uYearSemester
            // 
            this.uYearSemester.EditorLeft = 100;
            this.uYearSemester.Location = new System.Drawing.Point(28, 12);
            this.uYearSemester.Name = "uYearSemester";
            this.uYearSemester.ReadOnly = false;
            this.uYearSemester.SemesterEditValue = null;
            this.uYearSemester.Size = new System.Drawing.Size(231, 46);
            this.uYearSemester.TabIndex = 89;
            this.uYearSemester.YearIDEditValue = null;
            // 
            // dtmExamDate
            // 
            this.dtmExamDate.Caption = "Ngày:";
            this.dtmExamDate.EditorLeft = 100;
            this.dtmExamDate.EditValue = null;
            this.dtmExamDate.EditValueDate = null;
            this.dtmExamDate.EditValueDateTime = null;
            this.dtmExamDate.FormatString = "d";
            this.dtmExamDate.Location = new System.Drawing.Point(28, 62);
            this.dtmExamDate.Name = "dtmExamDate";
            this.dtmExamDate.ReadOnly = false;
            this.dtmExamDate.Size = new System.Drawing.Size(231, 21);
            this.dtmExamDate.TabIndex = 88;
            this.dtmExamDate.EditValueChanged += new Control.UDateEdit.EditValueChangedDelegate(this.dtmExamDate_EditValueChanged);
            // 
            // txtOrderIndex
            // 
            this.txtOrderIndex.Caption = "Thứ tự hiển thị:";
            this.txtOrderIndex.DisplayMask = "#,###";
            this.txtOrderIndex.EditMask = "";
            this.txtOrderIndex.EditorLeft = 100;
            this.txtOrderIndex.EditValue = ((long)(0));
            this.txtOrderIndex.EditValueDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtOrderIndex.EditValueDouble = 0D;
            this.txtOrderIndex.EditValueInt32 = 0;
            this.txtOrderIndex.EditValueInt64 = ((long)(0));
            this.txtOrderIndex.Location = new System.Drawing.Point(437, 270);
            this.txtOrderIndex.MaxLength = 0;
            this.txtOrderIndex.Name = "txtOrderIndex";
            this.txtOrderIndex.ReadOnly = false;
            this.txtOrderIndex.Size = new System.Drawing.Size(154, 21);
            this.txtOrderIndex.TabIndex = 87;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.EnterMoveNextControl = true;
            this.chkIsDefault.Location = new System.Drawing.Point(247, 272);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Properties.Caption = "Mặc định";
            this.chkIsDefault.Size = new System.Drawing.Size(75, 19);
            this.chkIsDefault.TabIndex = 86;
            // 
            // chkIsActived
            // 
            this.chkIsActived.EnterMoveNextControl = true;
            this.chkIsActived.Location = new System.Drawing.Point(123, 271);
            this.chkIsActived.Name = "chkIsActived";
            this.chkIsActived.Properties.Caption = "Kích hoạt";
            this.chkIsActived.Size = new System.Drawing.Size(75, 19);
            this.chkIsActived.TabIndex = 85;
            // 
            // txtDescription
            // 
            this.txtDescription.Caption = "Ghi chú:";
            this.txtDescription.EditorLeft = 100;
            this.txtDescription.EditValue = null;
            this.txtDescription.Location = new System.Drawing.Point(28, 116);
            this.txtDescription.MaxLength = 0;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(563, 119);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.TextTrim = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::StudentManager.Properties.Resources.Undo;
            this.btnCancel.Location = new System.Drawing.Point(204, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Trở về";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSaveEdit.Location = new System.Drawing.Point(123, 304);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEdit.TabIndex = 2;
            this.btnSaveEdit.Text = "Cập nhật";
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // txtExamDateName
            // 
            this.txtExamDateName.AllowNull = true;
            this.txtExamDateName.Caption = "Tên kì thi:";
            this.txtExamDateName.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtExamDateName.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtExamDateName.EditorLeft = 100;
            this.txtExamDateName.EditValue = null;
            this.txtExamDateName.EditValueDecimal = null;
            this.txtExamDateName.EditValueDouble = null;
            this.txtExamDateName.EditValueInt32 = null;
            this.txtExamDateName.EnterMoveNext = true;
            this.txtExamDateName.FontSize = 9F;
            this.txtExamDateName.Location = new System.Drawing.Point(28, 89);
            this.txtExamDateName.MaxLength = 0;
            this.txtExamDateName.Name = "txtExamDateName";
            this.txtExamDateName.PasswordChar = '\0';
            this.txtExamDateName.ReadOnly = false;
            this.txtExamDateName.Size = new System.Drawing.Size(563, 21);
            this.txtExamDateName.TabIndex = 1;
            this.txtExamDateName.TextTrim = "";
            // 
            // chkIsGraduation
            // 
            this.chkIsGraduation.EnterMoveNextControl = true;
            this.chkIsGraduation.Location = new System.Drawing.Point(123, 241);
            this.chkIsGraduation.Name = "chkIsGraduation";
            this.chkIsGraduation.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkIsGraduation.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.chkIsGraduation.Properties.Appearance.Options.UseFont = true;
            this.chkIsGraduation.Properties.Appearance.Options.UseForeColor = true;
            this.chkIsGraduation.Properties.Caption = "Kỳ thi tốt nghiệp";
            this.chkIsGraduation.Size = new System.Drawing.Size(127, 19);
            this.chkIsGraduation.TabIndex = 90;
            // 
            // frmExamDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 376);
            this.Controls.Add(this.tcData);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.Name = "frmExamDate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Danh sách kì thi";
            this.Load += new System.EventHandler(this.frmExamDate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmExamDate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcData)).EndInit();
            this.tcData.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDefault.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsActived.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsGraduation.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion        
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private Control.DgTabControl tcData;
        private Control.DgTabPage tpList;
        private Control.DgTabPage tpDetail;
        private Control.DgButton btnAdd;
        private Control.DgButton btnDelete;
        private Control.DgButton btnEdit;
        private Control.DgButton btnClose;
        private Control.DgButton btnCancel;
        private Control.DgButton btnSaveEdit;
        private Control.UTextEdit txtExamDateName;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuItemDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuItemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuItemExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private Control.URichTextEdit txtDescription;
        private Control.UCalcEdit txtOrderIndex;
        private Control.DgCheckEdit chkIsDefault;
        private Control.DgCheckEdit chkIsActived;
        private Control.UDateEdit dtmExamDate;
        private DeclarationManager.Education.UYearSemester uYearSemester;
        private Control.DgCheckEdit chkIsGraduation;          
    }
}