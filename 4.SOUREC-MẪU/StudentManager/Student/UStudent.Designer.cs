namespace StudentManager.Student
{
    partial class UStudent
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
            this.txtStatus = new Control.UTextEdit();
            this.txtStudentCode = new Control.UTextEdit();
            this.btSearch = new Control.DgButton();
            this.txtBirthDateText = new Control.UTextEdit();
            this.txtStudentName = new Control.UTextEdit();
            this.txtClassID = new Control.UTextEdit();
            this.txtGenderText = new Control.UTextEdit();
            this.picStudent = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picStudent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.AllowNull = true;
            this.txtStatus.Caption = "Trạng thái:";
            this.txtStatus.EditorBackColor = System.Drawing.SystemColors.Info;
            this.txtStatus.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStatus.EditorLeft = 70;
            this.txtStatus.EditValue = null;
            this.txtStatus.EditValueDouble = null;
            this.txtStatus.EditValueInt32 = null;
            this.txtStatus.Location = new System.Drawing.Point(432, 66);
            this.txtStatus.MaxLength = 0;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.PasswordChar = '\0';
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(248, 21);
            this.txtStatus.TabIndex = 31;
            this.txtStatus.TextTrim = "";
            // 
            // txtStudentCode
            // 
            this.txtStudentCode.AllowNull = true;
            this.txtStudentCode.Caption = "Mã số:";
            this.txtStudentCode.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentCode.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentCode.EditorLeft = 70;
            this.txtStudentCode.EditValue = null;
            this.txtStudentCode.EditValueDouble = null;
            this.txtStudentCode.EditValueInt32 = null;
            this.txtStudentCode.Location = new System.Drawing.Point(432, 12);
            this.txtStudentCode.MaxLength = 0;
            this.txtStudentCode.Name = "txtStudentCode";
            this.txtStudentCode.PasswordChar = '\0';
            this.txtStudentCode.ReadOnly = false;
            this.txtStudentCode.Size = new System.Drawing.Size(169, 21);
            this.txtStudentCode.TabIndex = 30;
            this.txtStudentCode.TextTrim = "";
            this.txtStudentCode.Leave += new System.EventHandler(this.txtStudentCode_Leave);
            // 
            // btSearch
            // 
            this.btSearch.Image = global::StudentManager.Properties.Resources.Search;
            this.btSearch.Location = new System.Drawing.Point(608, 12);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(72, 23);
            this.btSearch.TabIndex = 26;
            this.btSearch.Text = "Tra cứu";
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // txtBirthDateText
            // 
            this.txtBirthDateText.AllowNull = true;
            this.txtBirthDateText.Caption = "Ngày sinh:";
            this.txtBirthDateText.EditorBackColor = System.Drawing.SystemColors.Info;
            this.txtBirthDateText.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtBirthDateText.EditorLeft = 80;
            this.txtBirthDateText.EditValue = null;
            this.txtBirthDateText.EditValueDouble = null;
            this.txtBirthDateText.EditValueInt32 = null;
            this.txtBirthDateText.Location = new System.Drawing.Point(103, 39);
            this.txtBirthDateText.MaxLength = 0;
            this.txtBirthDateText.Name = "txtBirthDateText";
            this.txtBirthDateText.PasswordChar = '\0';
            this.txtBirthDateText.ReadOnly = true;
            this.txtBirthDateText.Size = new System.Drawing.Size(201, 21);
            this.txtBirthDateText.TabIndex = 27;
            this.txtBirthDateText.TextTrim = "";
            // 
            // txtStudentName
            // 
            this.txtStudentName.AllowNull = true;
            this.txtStudentName.Caption = "Họ và tên:";
            this.txtStudentName.EditorBackColor = System.Drawing.SystemColors.Window;
            this.txtStudentName.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtStudentName.EditorLeft = 80;
            this.txtStudentName.EditValue = null;
            this.txtStudentName.EditValueDouble = null;
            this.txtStudentName.EditValueInt32 = null;
            this.txtStudentName.Location = new System.Drawing.Point(103, 12);
            this.txtStudentName.MaxLength = 0;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.PasswordChar = '\0';
            this.txtStudentName.ReadOnly = false;
            this.txtStudentName.Size = new System.Drawing.Size(313, 21);
            this.txtStudentName.TabIndex = 25;
            this.txtStudentName.TextTrim = "";
            this.txtStudentName.Leave += new System.EventHandler(this.txtStudentName_Leave);
            // 
            // txtClassID
            // 
            this.txtClassID.AllowNull = true;
            this.txtClassID.Caption = "Lớp học:";
            this.txtClassID.EditorBackColor = System.Drawing.SystemColors.Info;
            this.txtClassID.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtClassID.EditorLeft = 80;
            this.txtClassID.EditValue = null;
            this.txtClassID.EditValueDouble = null;
            this.txtClassID.EditValueInt32 = null;
            this.txtClassID.Location = new System.Drawing.Point(103, 66);
            this.txtClassID.MaxLength = 0;
            this.txtClassID.Name = "txtClassID";
            this.txtClassID.PasswordChar = '\0';
            this.txtClassID.ReadOnly = true;
            this.txtClassID.Size = new System.Drawing.Size(313, 21);
            this.txtClassID.TabIndex = 29;
            this.txtClassID.TextTrim = "";
            // 
            // txtGenderText
            // 
            this.txtGenderText.AllowNull = true;
            this.txtGenderText.Caption = "Giới tính:";
            this.txtGenderText.EditorBackColor = System.Drawing.SystemColors.Info;
            this.txtGenderText.EditorForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtGenderText.EditorLeft = 70;
            this.txtGenderText.EditValue = null;
            this.txtGenderText.EditValueDouble = null;
            this.txtGenderText.EditValueInt32 = null;
            this.txtGenderText.Location = new System.Drawing.Point(432, 39);
            this.txtGenderText.MaxLength = 0;
            this.txtGenderText.Name = "txtGenderText";
            this.txtGenderText.PasswordChar = '\0';
            this.txtGenderText.ReadOnly = true;
            this.txtGenderText.Size = new System.Drawing.Size(169, 21);
            this.txtGenderText.TabIndex = 28;
            this.txtGenderText.TextTrim = "";
            // 
            // picStudent
            // 
            this.picStudent.Location = new System.Drawing.Point(0, 0);
            this.picStudent.Name = "picStudent";
            this.picStudent.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picStudent.Size = new System.Drawing.Size(91, 101);
            this.picStudent.TabIndex = 128;
            // 
            // UStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picStudent);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtStudentCode);
            this.Controls.Add(this.btSearch);
            this.Controls.Add(this.txtBirthDateText);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.txtClassID);
            this.Controls.Add(this.txtGenderText);
            this.Name = "UStudent";
            this.Size = new System.Drawing.Size(681, 101);
            ((System.ComponentModel.ISupportInitialize)(this.picStudent.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.UTextEdit txtStudentCode;
        private Control.DgButton btSearch;
        private Control.UTextEdit txtBirthDateText;
        private Control.UTextEdit txtStudentName;
        private Control.UTextEdit txtClassID;
        private Control.UTextEdit txtGenderText;
        private Control.UTextEdit txtStatus;
        private DevExpress.XtraEditors.PictureEdit picStudent;

    }
}
