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
    public partial class frmDateCheckingStatistic : FormBase, IForm
    {
        #region Consts

       
        public const string PERMISSION_VIEW = "SIM_DateCheckingStatistic_View";
        #endregion
        
        #region Variables
         
        bool bolIsEditing = false; // dang edit hay khong
       // SIM_YearDateCheckingStatistic itemStudentEditing = new SIM_YearDateCheckingStatistic(); // record đang edit

        #endregion

        #region IForm Members

        private static frmDateCheckingStatistic _instance = null;

        public static frmDateCheckingStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmDateCheckingStatistic();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmDateCheckingStatistic()
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
        private DataTable dtbData = null;
        private void EditData()
        {
            dtbData.Columns.Add("P0", typeof(int));
            dtbData.Columns.Add("K0", typeof(int));
            dtbData.Columns.Add("P1", typeof(int));
            dtbData.Columns.Add("K1", typeof(int));
            dtbData.Columns.Add("P2", typeof(int));
            dtbData.Columns.Add("K2", typeof(int));
            dtbData.Columns.Add("P3", typeof(int));
            dtbData.Columns.Add("K3", typeof(int));
            dtbData.Columns.Add("P4", typeof(int));
            dtbData.Columns.Add("K4", typeof(int));
            dtbData.Columns.Add("P5", typeof(int));
            dtbData.Columns.Add("K5", typeof(int));
        }
        private bool IsValidData()
        {
            if (dtmFromDate.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn ngày bắt đầu!");
                dtmFromDate.Focus();
                return false;
            }
            if (dtmToDate.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn ngày kết thúc!");
                dtmToDate.Focus();
                return false;
            }

            if (dtmFromDate.EditValueDateTime > dtmToDate.EditValueDateTime)
            {
                MessageManager.Warning("Bạn phải chọn ngày bắt đầu nhỏ hơn!");
                dtmFromDate.Focus();
                return false;
            }
            if (uClass.ClassIDEditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn lớp học!");
                uClass.Focus();
                return false;
            }

            return true;
        }

        public void LoadData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadData));
            else
            {
                SIM_DateChecking obj = new SIM_DateChecking();
                dtbData = obj.DateCheckingStatistic("@ClassID",uClass.ClassIDEditValue.ToString(),
                                                            "@FromDate",dtmFromDate.EditValueDateTime,
                                                            "@ToDate",dtmToDate.EditValueDateTime);
                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    EditData();
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

        private void frmDateCheckingStatistic_Load(object sender, EventArgs e)
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

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void mnuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            int iFrom = 0; int iTo = 0; int iSoThang = 0; int i = 0;
           
            iFrom =  dtmFromDate.EditValueDateTime.Value.Month;
            iTo = dtmToDate.EditValueDateTime.Value.Month;
          
            int iThangBD = 0;
            // truyen tham so theo ý riêng
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData, "Report/StudentManager/Ethic/Student_ThongKe_DiemDanhNgay.repx", false);

            if (iFrom > iTo) // Nếu  tháng bắt đầu lớn hơn
            {
                iSoThang += 13 - iFrom;
                for (i = 0; i < iSoThang; i++) // Cho số tháng đến vị trí 13
                {
                    iThangBD = iFrom + i;
                    for (int j = 0; j < dtbData.Rows.Count; j++)
                    {
                        if (iThangBD < 10)
                            dtbData.Rows[j]["P" + i] = dtbData.Rows[j]["T0" + iThangBD + "P"];
                        else
                            dtbData.Rows[j]["P" + i] = dtbData.Rows[j]["T" + iThangBD + "P"];
                    }
                    frm.SetParameter("pMonth" + i, "THÁNG " + iThangBD);
                }
                // tiếp qua nam mới
                int k =i;
                i = 0;
                iThangBD = 0;
                for (i = 0; i < iTo; i++)
                {
                    iThangBD = i + 1;
                    k += i;
                    for (int j = 0; j < dtbData.Rows.Count; j++)
                    {
                        if (iThangBD < 10)
                            dtbData.Rows[j]["P" + k] = dtbData.Rows[j]["T0" + iThangBD + "P"];
                        else
                            dtbData.Rows[j]["P" + k] = dtbData.Rows[j]["T" + iThangBD + "P"];
                    }
                    frm.SetParameter("pMonth" + k, "THÁNG " + iThangBD);
                }
               
            }
            else
            {
                iSoThang = iTo + 1  - iFrom ;
                for (i = 0; i < iSoThang; i++) // Cho số tháng đến vị trí 13
                {
                    iThangBD = iFrom + i;
                    for (int j = 0; j < dtbData.Rows.Count; j++)
                    {
                        if (iThangBD < 10)
                        {
                            dtbData.Rows[j]["P" + i] = dtbData.Rows[j]["T0" + iThangBD + "P"];
                            dtbData.Rows[j]["K" + i] = dtbData.Rows[j]["T0" + iThangBD + "K"];
                        }
                        else
                        {
                            dtbData.Rows[j]["P" + i] = dtbData.Rows[j]["T" + iThangBD + "P"];
                            dtbData.Rows[j]["K" + i] = dtbData.Rows[j]["T" + iThangBD + "K"];
                        }
                    }
                    frm.SetParameter("pMonth" + i, "THÁNG " + iThangBD);
                }
            }
            
            frm.SetParameter("pCourse", uClass.CourseName);
            frm.SetParameter("pTrainingType", uClass.TrainingTypeName);
            frm.SetParameter("pTrainingLevel", uClass.TrainingLevelName);
            frm.SetParameter("pBranch", uClass.BranchName);
            frm.SetParameter("pSpecialBranch", uClass.SpecialBranchName);
            frm.SetParameter("pScience", uClass.ScienceName);
            frm.SetParameter("pClass", uClass.ClassName);
            frm.SetParameter("pfromdate",Convert.ToDateTime(dtmFromDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.SetParameter("pTodate", Convert.ToDateTime(dtmToDate.EditValueDateTime).ToString("dd/MM/yyyy"));
            frm.Show();
        }

    }
}