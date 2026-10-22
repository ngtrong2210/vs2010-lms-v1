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
    public partial class frmDecision58Statistic : FormBase, IForm
    {
        #region Consts

       
        public const string PERMISSION_VIEW = "SIM_Decision58Statistic_View";
        #endregion

        private string strClassID = "";
        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearDecision58Statistic itemStudentEditing = new SIM_YearDecision58Statistic(); // record đang edit

        #endregion

        #region IForm Members

        private static frmDecision58Statistic _instance = null;

        public static frmDecision58Statistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmDecision58Statistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmDecision58Statistic()
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
        private void  controlchk()
        {
            if (ChkSocialstructure.Checked ==true)
            {
                ChkMovements .Checked =false ;
                ChkPolicy.Checked = false;
            }
            else if (ChkPolicy.Checked == true)
            {
                ChkMovements.Checked = false;
                ChkSocialstructure.Checked = false;

            }
            else if (ChkMovements.Checked == false)
            {
                ChkPolicy.Checked = false;
                ChkSocialstructure.Checked = false;
            }
        }
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_Student obj = new SIM_Student();
                if( ChkSocialstructure.Checked == true )
                {
                    DataTable dtbData = obj.SearchSocialstructure(uClass .CourseIDEditValue.ToString ());
                    if (dtbData != null)
                    {
                        gcData.DataSource = dtbData;
                        SYS_GridColumnService.InitGridColumn(gvData, "SIM_Student_Socialstructure");

                        // set order
                        gvData.SetOrder("Order");
                   
                    }
                    else
                    {
                        //ErrorManager.Error(obj.ErrorException.ToString());
                        ErrorManager.Error("Việc lấy thông tin bị lỗi!");
                    }
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

        private void frmDecision58Statistic_Load(object sender, EventArgs e)
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

            if (uClass.TrainingLevelIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn bậc đào tạo!");
                uClass.Focus();
                return false;
            }
            
            return true;
        }

        private void ChkSocialstructure_CheckedChanged(object sender, EventArgs e)
        {
            controlchk();
        }

        private void ChkMovements_CheckedChanged(object sender, EventArgs e)
        {
            controlchk();
        }

        private void ChkPolicy_CheckedChanged(object sender, EventArgs e)
        {
            controlchk();
        }
        
    }
}