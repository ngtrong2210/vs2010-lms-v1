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

namespace StudentManager.Checking
{
    public partial class frmSubjectCheckingStatistic : FormBase, IForm
    {
        #region Consts

       
        public const string PERMISSION_VIEW = "SIM_YearSubjectCheckingStatistic_View";

        #endregion

        private string strClassID = "";
        private int intYear = 0;
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearSubjectCheckingStatistic itemStudentEditing = new SIM_YearSubjectCheckingStatistic(); // record đang edit

        #endregion

        #region IForm Members

        private static frmSubjectCheckingStatistic _instance = null;

        public static frmSubjectCheckingStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSubjectCheckingStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSubjectCheckingStatistic()
        {
            InitializeComponent();
        }
        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();

            }
        }
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_SubjectChecking obj = new SIM_SubjectChecking();
                DataTable dtbData = obj.SearchSubjectChecking(uClass.ClassSubjectIDEditValue);
                    if (dtbData != null)
                    {
                        gcData.DataSource = dtbData;
                        SYS_GridColumnService.InitGridColumn(gvData, "SIM_SubjectCheckingStatistic");

                        // set order
                        gvData.SetOrder("Order");
                        mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0;
                   
                    }
                    else
                    {
                        //ErrorManager.Error(obj.ErrorException);
                        ErrorManager.Error("Việc lấy thông tin bị lỗi!");
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

        private void frmSubjectCheckingStatistic_Load(object sender, EventArgs e)
        {
       
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();        
        }
     
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                new Thread(LoadData).Start();
            }
        }

        
        private bool IsValidData()
        {
            if (uClass.ClassSubjectIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn môn học!");
                uClass.Focus();
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }
        


    }
}