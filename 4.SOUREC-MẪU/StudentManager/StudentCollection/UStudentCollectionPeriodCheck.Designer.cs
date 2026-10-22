namespace StudentManager.StudentCollection
{
    partial class UStudentCollectionPeriodCheck
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
            this.lookupStudentCollectionPeriodID = new Control.UCheckedComboBoxEdit();
            this.uCourseTypeLevel = new DeclarationManager.Education.UCourseTypeLevel();
            this.SuspendLayout();
            // 
            // lookupStudentCollectionPeriodID
            // 
            this.lookupStudentCollectionPeriodID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lookupStudentCollectionPeriodID.Caption = "Đợt tuyển sinh:";
            this.lookupStudentCollectionPeriodID.DataSource = null;
            this.lookupStudentCollectionPeriodID.EditorLeft = 100;
            this.lookupStudentCollectionPeriodID.EditValue = null;
            this.lookupStudentCollectionPeriodID.Location = new System.Drawing.Point(0, 80);
            this.lookupStudentCollectionPeriodID.Name = "lookupStudentCollectionPeriodID";
            this.lookupStudentCollectionPeriodID.ReadOnly = false;
            this.lookupStudentCollectionPeriodID.Size = new System.Drawing.Size(300, 21);
            this.lookupStudentCollectionPeriodID.TabIndex = 1;
            this.lookupStudentCollectionPeriodID.EditValueChanged += new Control.UCheckedComboBoxEdit.EditValueChangedDelegate(this.lookupStudentCollectionPeriodID_EditValueChanged);
            // 
            // uCourseTypeLevel
            // 
            this.uCourseTypeLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uCourseTypeLevel.CourseIDEditValue = null;
            this.uCourseTypeLevel.EditorLeft = 100;
            this.uCourseTypeLevel.Location = new System.Drawing.Point(0, 0);
            this.uCourseTypeLevel.Name = "uCourseTypeLevel";
            this.uCourseTypeLevel.ReadOnly = false;
            this.uCourseTypeLevel.ScienceFilter = "";
            this.uCourseTypeLevel.Size = new System.Drawing.Size(300, 77);
            this.uCourseTypeLevel.TabIndex = 0;
            this.uCourseTypeLevel.TrainingLevelIDEditValue = null;
            this.uCourseTypeLevel.TrainingTypeEditValue = null;
            this.uCourseTypeLevel.EditValueChanged += new DeclarationManager.Education.UCourseTypeLevel.EditValueChangedDelegate(this.uCourseTypeLevel_EditValueChanged);
            // 
            // UStudentCollectionPeriodCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lookupStudentCollectionPeriodID);
            this.Controls.Add(this.uCourseTypeLevel);
            this.Name = "UStudentCollectionPeriodCheck";
            this.Size = new System.Drawing.Size(300, 101);
            this.ResumeLayout(false);

        }

        #endregion

        private DeclarationManager.Education.UCourseTypeLevel uCourseTypeLevel;
        private Control.UCheckedComboBoxEdit lookupStudentCollectionPeriodID;

    }
}
