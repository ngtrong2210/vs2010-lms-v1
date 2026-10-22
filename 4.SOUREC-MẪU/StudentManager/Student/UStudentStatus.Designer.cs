namespace StudentManager.Student
{
    partial class UStudentStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uMainSession = new Control.ULookUpEdit();
            this.SuspendLayout();
            // 
            // uMainSession
            // 
            this.uMainSession.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uMainSession.Caption = "Trạng thái:";
            this.uMainSession.DataSource = null;
            this.uMainSession.EditorLeft = 80;
            this.uMainSession.EditValue = null;
            this.uMainSession.Location = new System.Drawing.Point(3, 3);
            this.uMainSession.Margin = new System.Windows.Forms.Padding(0);
            this.uMainSession.Name = "uMainSession";
            this.uMainSession.ReadOnly = false;
            this.uMainSession.Size = new System.Drawing.Size(291, 21);
            this.uMainSession.TabIndex = 0;
            this.uMainSession.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.uMainSession.Load += new System.EventHandler(this.uMainSession_Load);
            // 
            // UStudentStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uMainSession);
            this.Name = "UStudentStatus";
            this.Size = new System.Drawing.Size(294, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.ULookUpEdit uMainSession;
    }
}
