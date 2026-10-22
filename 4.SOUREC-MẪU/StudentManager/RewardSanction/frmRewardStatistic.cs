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

namespace StudentManager.RewardSanction
{
    public partial class frmRewardStatistic : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_ADD = "SIM_RewardStatistic_Add";
        public const string PERMISSION_DELETE = "SIM_RewardStatistic_Delete";
        public const string PERMISSION_EDIT = "SIM_RewardStatistic_Edit";
        public const string PERMISSION_VIEW = "SIM_RewardStatistic_View";
        #endregion

        private string strClassID = "";
        private int intYear = 0;
        private int intSemester = 0;
        private string strListIDDeleted = "";

        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_Reward itemStudentEditing = new SIM_Reward(); // record đang edit

        #endregion

        #region IForm Members

        private static frmRewardStatistic _instance = null;

        public static frmRewardStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmRewardStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion


        public frmRewardStatistic()
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
                uYearSemester.InitData();

            }
        }
        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                try
                {
                    SIM_Reward obj = new SIM_Reward();
                    DataTable dtbData = obj.Search(
                                    "@ClassID", uClass.ClassIDEditValue, "@CourseID", uClass.CourseIDEditValue,
                                    "@Year", uYearSemester.YearIDEditValueInt32,
                                    "@Semester", uYearSemester.SemesterEditValueInt32 );

                    gcData.DataSource = dtbData;
                    SYS_GridColumnService.InitGridColumn(gvData, "SIM_Reward");

                    // set order
                    gvData.SetOrder("Order");

                    //Nhớ lại giá trị khóa để save
                    btnEdit.Enabled = UserSession.HasPermission(PERMISSION_EDIT) && dtbData.Rows.Count > 0;
       
                }
                catch (Exception objEx)
                {
                    ErrorManager.Error(objEx);
                    SYS_ErrorLogService.Write(Enums.ActionType.View, "frmSpecialBranch_Subject->LoadData", objEx, 0);
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

        private void frmRewardStatistic_Load(object sender, EventArgs e)
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

       

        
        /// <summary>
        /// Save dữ liệu ở tab editgv
        /// </summary>
      

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnEdit.Enabled = true;
        }

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            // set order
            gvData.SetOrder("Order");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                frmReward frmEdit = frmReward.Instance;             
                frmEdit.LoadData(Convert.ToInt64( drw[SIM_Reward.C_StudentID]),drw[SIM_Reward.C_DecisionNo].ToString());
                frmEdit.ShowDialog();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                frmReward frmEdit = frmReward.Instance;
                frmEdit.ShowDialog();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();// Lấy dữ liệu dòng được chọn.
            if (drw != null)
            {
                if (MessageManager.Confirm("Bạn có chắc muốn xóa dòng dữ liệu này?") == System.Windows.Forms.DialogResult.Yes)
                {
                    SIM_Reward objSaction = new SIM_Reward();

                    objSaction.BeginTransaction(); // lay mot doi tuong lam chinh de transaction
                    objSaction.StudentID = Convert.ToInt64(drw[SIM_Reward.C_StudentID]);
                    objSaction.DecisionNo = drw[SIM_Reward.C_DecisionNo].ToString();
                    if (!objSaction.Delete())
                    {
                        ErrorManager.Error("Xóa thông tin khen thưởng thất bại");
                        return;
                    }

                    objSaction.CommitTransaction();
                    gvData.DeleteRow(gvData.FocusedRowHandle);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        ///  Nếu itemOld = null thì là thêm mới với itemNew


    }
}