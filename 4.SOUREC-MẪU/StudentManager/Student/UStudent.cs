using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Service;
using Libs;
using SimsObject;

namespace StudentManager.Student
{
    public partial class UStudent: DevExpress.XtraEditors.XtraUserControl
    {
        public UStudent()
        {
            InitializeComponent();
        }

        #region Properties

        long? lngStudentID = null;
        public long? StudentID
        {
            get { return lngStudentID; }
            set
            {
                lngStudentID = value;
            }
        }

        int intStatus = 0;

        public int Status
        {
            get { return intStatus; }            
        }

        public string ClassID
        {
            get { return txtClassID.Text; }
        }
        public string StudentCode
        {
            get { return txtStudentCode.Text; }
        }

        public string StatusText
        {
            get { return txtStatus.Text; }
        }

        public string StudentName
        {
            get { return txtStudentName.Text; }
        }
        #endregion

        #region Public Methods

        public void LoadStudentInfo()
        {            
            LoadStudentInfo(null, null, null, lngStudentID, false);
        }

        public void LoadStudentInfo(long? studentID)
        {
            LoadStudentInfo(null, null, null, studentID, false);
        }

        public void LoadStudentInfo(SIM_Student obj, string fullName, string studentCode, long? studentID, bool isSearching)
        {
            lngStudentID = null;

            if (obj == null) // không truyền đối tượng sinh viên
            {
                obj = new SIM_Student();
                if (studentID == null) // không truyền chính xác mã sinh viên thì tìm mã sv
                {
                    DataTable dtb = obj.Search("@FullName", fullName, "@StudentCode", studentCode, "@StudentID", studentID);
                    if (dtb == null)
                    {
                        ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                        return;
                    }
                    if (dtb.Rows.Count == 1 && !isSearching) // nếu tìm được 1 thì load luôn sinh viên đó
                    {
                        obj.StudentID = Convert.ToInt64(dtb.Rows[0]["StudentID"]);
                    }
                    else
                    {
                        StudentManager.Student.frmSelectStudent frm = StudentManager.Student.frmSelectStudent.Instance;
                        frm.Data = dtb;
                        frm.ISMultiSelect = false;
                        frm.ShowDialog();
                        if (frm.IsOk)
                        {
                            obj = frm.ItemSelected;
                        }
                        else
                            return;
                    }
                }
                else
                    obj.StudentID = studentID;

                // nếu chưa có load sinh viên thì load
                if (obj.StudentCode == null)
                {
                    if (!obj.Get())
                    {
                        ErrorManager.Error("Việc lấy thông tin sinh viên bị lỗi!");
                        return;
                    }
                }
            }

            if (obj != null)
            {
                lngStudentID = obj.StudentID;
                txtStudentCode.Text = obj.StudentCode;
                txtStudentName.Text = obj.StudentFirstName + " " + obj.StudentLastName;
                txtBirthDateText.Text = obj.BirthDateText;
                txtGenderText.Text = obj.Gender ? "Nam" : "Nữ";
                txtClassID.Text = obj.ClassID;
                intStatus = obj.Status.Value;
                string[] status = { "", "Đang học", "Tốt nghiệp", "Đình chỉ", "Buộc thôi học", "Bảo lưu", "Lưu ban"};
                txtStatus.Text = status[intStatus];
            }

            if (EditValueChanged != null)
                EditValueChanged(null, null);
        }
       
        /// <summary>
        /// reset các chọn lựa, trở về select = null
        /// </summary>
        public void Reset()
        {
            txtStudentCode.Text = txtStudentName.Text = txtBirthDateText.Text = txtGenderText.Text = txtStatus.Text = "";
            txtClassID.Text = "";
            lngStudentID = null;
            intStatus = 0;
        }
        /// <summary>
        /// Kiểm tra dữ liệu không được null
        /// </summary>
        public bool IsValidData()
        {
            if (lngStudentID==null)
            {                
                MessageManager.Warning("Bạn phải chọn sinh viên!");
                txtStudentName.Focus();
                return false;
            }
          
            return true;
        }

        #endregion
       

        #region Delegate Action Medthods

        public delegate void EditValueChangedDelegate(object sender, EventArgs arg);
        public event EditValueChangedDelegate EditValueChanged = null;

        
        #endregion 
      
        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadStudentInfo(null, txtStudentName.Text, txtStudentCode.Text, null, true);
        }

        private void txtStudentName_Leave(object sender, EventArgs e)
        {
            if (txtStudentName.TextTrim != "")
                LoadStudentInfo(null, txtStudentName.Text, null, null, false);
        }

        private void txtStudentCode_Leave(object sender, EventArgs e)
        {
            if (txtStudentCode.TextTrim != "")
                LoadStudentInfo(null, null, txtStudentCode.Text, null, false);
        }
    }
}
