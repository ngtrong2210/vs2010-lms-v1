using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using Libs;
using Global;
using DCore;
using SimsObject;
using SimsService;
using Service;
using GeneralObject;
using GeneralService;

namespace StudentManager.Student
{
    public partial class frmMoveStudent : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_MoveStudent_Add";
        public const string PERMISSION_DELETE = "SIM_MoveStudent_Delete";
        public const string PERMISSION_EDIT = "SIM_MoveStudent_Edit";
        public const string PERMISSION_VIEW = "SIM_MoveStudent_View";
        #endregion

        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_MoveStudent itemStudentEditing = new SIM_MoveStudent(); // record đang edit

        #endregion

        #region IForm Members

        private static frmMoveStudent _instance = null;

        public static frmMoveStudent Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmMoveStudent();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmMoveStudent()
        {
            InitializeComponent();
        }

        public void LoadReferenceData()
        {
            
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                try
                {
                    int? intTypeAction = null;
                    if (cbxIsFailed.SelectedIndex > 0)
                        intTypeAction = cbxIsFailed.SelectedIndex;

                    SIM_MoveStudent obj = new SIM_MoveStudent();
                    DataTable dtbData = obj.Search(
                                    "@StudentCode", txtStudentCode_Search.Text,
                                    "@FullName", txtFullName_Search.Text,
                                    "@TypeAction", intTypeAction,
                                    "@FromDate", dtmFromDate.EditValueDateTime,
                                    "@ToDate", dtmToDate.EditValueDateTime);

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_MoveStudent");

                    // set order
                    gvData.SetOrder("Order");

                    //Nhớ lại giá trị khóa để save
                    btnEdit.Enabled = UserSession.HasPermission(PERMISSION_EDIT) && dtbData.Rows.Count > 0;

                }
                catch (Exception objEx)
                {
                   ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmMoveStudent->LoadData", objEx, 0);
                }
            }
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền
           
        }
   

      

        
        #endregion

        #region Form Actions

        private void frmMoveStudent_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }

       

     
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            new Thread(LoadData).Start();
        }
     
        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            //DataRow drw = gvData.GetFocusedDataRow();
            //if (drw != null)
            //{
            //    frmMoveStudentEdit frmEdit = frmMoveStudentEdit.Instance;             
            //    frmEdit.LoadData(Convert.ToInt64( drw[SIM_MoveStudent.C_StudentID]),drw[SIM_MoveStudent.C_DecisionNo].ToString());
            //    frmEdit.ShowDialog();
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMoveStudentEdit frmEdit = frmMoveStudentEdit.Instance;
            frmEdit.ShowDialog();
            if (frmEdit.IsOk)
            {
                LoadData();
                if (frmEdit.MoveStudentID > 0)
                    gvData.SearchAndSelectRow("MoveStudentID", frmEdit.MoveStudentID);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DataRow drw = gvData.GetFocusedDataRow();// Lấy dữ liệu dòng được chọn.
            //if (drw != null)
            //{
            //    if (MessageManager.Confirm("Bạn có chắc muốn xóa dòng dữ liệu này?") == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        SIM_MoveStudent objSaction = new SIM_MoveStudent();

            //        objSaction.BeginTransaction(); // lay mot doi tuong lam chinh de transaction
            //        objSaction.StudentID = Convert.ToInt64(drw[SIM_MoveStudent.C_StudentID]);
            //        objSaction.DecisionNo = drw[SIM_MoveStudent.C_DecisionNo].ToString();
            //        if (!objSaction.Delete())
            //        {
            //            ErrorManager.Error("Xóa thông tin Chuyển lớp sinh viên thất bại");
            //            return;
            //        }

            //        objSaction.CommitTransaction();
            //        gvData.DeleteRow(gvData.FocusedRowHandle);
            //    }
            //}
        }        

    }
}