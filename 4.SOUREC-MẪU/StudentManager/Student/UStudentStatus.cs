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

namespace StudentManager.Student
{
    public partial class UStudentStatus: DevExpress.XtraEditors.XtraUserControl
    {
        public UStudentStatus()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Vị trí left của Text edit value so với control này
        /// </summary>
        public int EditorLeft
        {
            get { return uMainSession.EditorLeft; }
            set
            {
                uMainSession.EditorLeft = value;                
            }
        }

        /// <summary>
        /// Thuộc tính readonlye của lookup value.
        /// Nó tự đổi màu nền theo thuộc tính.
        /// </summary>
        public bool ReadOnly
        {
            get { return uMainSession.ReadOnly; }
            set { uMainSession.ReadOnly = value; }
        }
        

        

        public object EditValue
        {
            get { return uMainSession.EditValue; }
            set
            {
                uMainSession.EditValue = value;
            }
        }

        public int? EditValueInt32
        {
            get { return uMainSession.EditValueInt32; }
           
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Load data, nếu cũ thì khỏi load lại
        /// </summary>
        public void InitData()
        {
            
            DataTable dtb = new DataTable();
            dtb.Columns.Add("StatusID", typeof(int));
            dtb.Columns.Add("Status", typeof(string));

            DataRow drw = dtb.NewRow();            
            dtb.Rows.Add(drw);

            drw = dtb.NewRow();
            drw["StatusID"] = 1;
            drw["Status"] = "Đang học";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"] = 10;
            drw["Status"] = "Đủ điều kiện dự thi TN (chưa TN)";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"]=2;
            drw["Status"] = "Tốt nghiệp";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"]=3;
            drw["Status"] = "Đình chỉ";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"] = 4;
            drw["Status"] = "Buộc thôi học";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"] = 5;
            drw["Status"] = "Bảo lưu";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"] = 6;
            drw["Status"] = "Lưu ban";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();

            drw = dtb.NewRow();
            drw["StatusID"] = 7;
            drw["Status"] = "Tự thôi học";
            dtb.Rows.Add(drw);
            drw = dtb.NewRow();
            

            uMainSession.InitData(dtb, "--Chọn--", "StatusID", "Status", "Status", "Trạng thái");
        }
       

        /// <summary>
        /// reset các chọn lựa, trở về select = null
        /// </summary>
        public void Reset()
        {
            uMainSession.EditValue = null;            
        }
        /// <summary>
        /// Kiểm tra dữ liệu không được null
        /// </summary>
        public bool IsValidData()
        {
            if (uMainSession.EditValue == null || uMainSession.EditValue.ToString() == "")
            {                
                MessageManager.Warning("Bạn phải chọn trạng thái!");
                uMainSession.Focus();
                return false;
            }
          
            return true;
        }

        #endregion
       

        #region Delegate Action Medthods

        public delegate void EditValueChangedDelegate(object sender, EventArgs arg);
        public event EditValueChangedDelegate EditValueChanged = null;

        private void lookup_EditValueChanged(object sender, EventArgs e)
        {
            if (EditValueChanged != null)
                EditValueChanged(sender, e);
        }
        #endregion 

      

        private void uMainSession_Load(object sender, EventArgs e)
        {
            InitData();
        }
    }
}
