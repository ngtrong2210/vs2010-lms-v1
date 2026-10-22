namespace StudentManager
{
    partial class frmCopyStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCopyStudent));
            this.mnuPopupGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuItemCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemUnCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuItemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new Control.DgButton();
            this.btnSaveEdit = new Control.DgButton();
            this.gcData = new Control.DgGridControl();
            this.gvData = new Control.DgGridView();
            this.uClass21 = new TrainingPlan.FramePlan.UClass2();
            this.mnuPopupGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuPopupGrid
            // 
            this.mnuPopupGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuItemCheck,
            this.mnuItemUnCheck,
            this.mnuItemSave,
            this.toolStripSeparator2,
            this.mnuItemClose});
            this.mnuPopupGrid.Name = "mnuPopupGrid";
            this.mnuPopupGrid.Size = new System.Drawing.Size(145, 98);
            // 
            // mnuItemCheck
            // 
            this.mnuItemCheck.Name = "mnuItemCheck";
            this.mnuItemCheck.Size = new System.Drawing.Size(144, 22);
            this.mnuItemCheck.Text = "Chọn";
            this.mnuItemCheck.Click += new System.EventHandler(this.mnuItemCheck_Click);
            // 
            // mnuItemUnCheck
            // 
            this.mnuItemUnCheck.Name = "mnuItemUnCheck";
            this.mnuItemUnCheck.Size = new System.Drawing.Size(144, 22);
            this.mnuItemUnCheck.Text = "Bỏ chọn";
            this.mnuItemUnCheck.Click += new System.EventHandler(this.mnuItemUnCheck_Click);
            // 
            // mnuItemSave
            // 
            this.mnuItemSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemSave.Image")));
            this.mnuItemSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuItemSave.Name = "mnuItemSave";
            this.mnuItemSave.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuItemSave.Size = new System.Drawing.Size(144, 22);
            this.mnuItemSave.Text = "Lưu";
            this.mnuItemSave.Visible = false;
            this.mnuItemSave.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // mnuItemClose
            // 
            this.mnuItemClose.Image = ((System.Drawing.Image)(resources.GetObject("mnuItemClose.Image")));
            this.mnuItemClose.Name = "mnuItemClose";
            this.mnuItemClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuItemClose.Size = new System.Drawing.Size(144, 22);
            this.mnuItemClose.Text = "Đóng";
            this.mnuItemClose.Click += new System.EventHandler(this.mnuItemClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = global::StudentManager.Properties.Resources.Undo;
            this.btnCancel.Location = new System.Drawing.Point(674, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Trở về";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveEdit.Image = global::StudentManager.Properties.Resources.Save;
            this.btnSaveEdit.Location = new System.Drawing.Point(593, 420);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEdit.TabIndex = 9;
            this.btnSaveEdit.Text = "Cập nhật";
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // gcData
            // 
            this.gcData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gcData.ContextMenuStrip = this.mnuPopupGrid;
            this.gcData.Location = new System.Drawing.Point(-1, -1);
            this.gcData.MainView = this.gvData;
            this.gcData.Name = "gcData";
            this.gcData.Size = new System.Drawing.Size(763, 284);
            this.gcData.TabIndex = 0;
            this.gcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvData});
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
            this.gvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvData_RowCellStyle);
            // 
            // uClass21
            // 
            this.uClass21.BranchEditValue = null;
            this.uClass21.ClassFilter = "";
            this.uClass21.ClassIDEditValue = null;
            this.uClass21.CourseIDEditValue = "0";
            this.uClass21.EditorLeft = 100;
            this.uClass21.EditorLeft2 = 90;
            this.uClass21.EditorWidth = 299;
            this.uClass21.LabelLeft2 = 318;
            this.uClass21.Location = new System.Drawing.Point(12, 304);
            this.uClass21.Name = "uClass21";
            this.uClass21.ReadOnly = false;
            this.uClass21.ScienceFilter = "";
            this.uClass21.ScienceIDEditValue = null;
            this.uClass21.Size = new System.Drawing.Size(737, 99);
            this.uClass21.SpecialBranchIDEditValue = null;
            this.uClass21.TabIndex = 121;
            this.uClass21.TrainingLevelIDEditValue = null;
            this.uClass21.TrainingTypeEditValue = null;
            // 
            // frmCopyStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 448);
            this.Controls.Add(this.uClass21);
            this.Controls.Add(this.gcData);
            this.Controls.Add(this.btnSaveEdit);
            this.Controls.Add(this.btnCancel);
            this.HelpButton = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopyStudent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Sao chép sinh viên";
            this.Load += new System.EventHandler(this.frmCopyStudent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCopyStudent_KeyDown);
            this.mnuPopupGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion        

        private Control.DgButton btnCancel;
        private Control.DgButton btnSaveEdit;
        private System.Windows.Forms.ContextMenuStrip mnuPopupGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuItemClose;
        private Control.DgGridControl gcData;
        private Control.DgGridView gvData;
        private System.Windows.Forms.ToolStripMenuItem mnuItemCheck;
        private System.Windows.Forms.ToolStripMenuItem mnuItemUnCheck;
        private TrainingPlan.FramePlan.UClass2 uClass21;          
    }
}