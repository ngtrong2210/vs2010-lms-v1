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
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Collections;


namespace StudentManager.Graduation
{
    public partial class frmSyncGraduationResult : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SYS_GraduationResult_Sync";
        
        #endregion

        #region Variables

        private string strTemplageConnection = "Data Source={0};Initial Catalog={3};Persist Security Info=True;User ID={1};Password={2};";
        private string strFileConfig = "config-old-data.txt";

        DataTable dtbData;
        DataTable dtbClassSubject;
        SIM_Class_Subject objClassSubject = new SIM_Class_Subject();
        bool bolIsGraduationSubject = true;                


        string strOldConn = "";
        DataTable dtbOldData;

        #endregion

        #region IForm Members

        private static frmSyncGraduationResult _instance = null;

        public static frmSyncGraduationResult Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmSyncGraduationResult();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmSyncGraduationResult()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            //gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
            //uClass.ScienceFilter = UserSession.GetScienceFilter(PERMISSION_VIEW); // quyền xem trên khoa nào                                
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

        private bool IsValidData()
        {            
            if (!uClass.IsValidData())
                return false;
            
            return true;
        }

        public void LoadOldData()
        {            
            // lấy classsubject info

            // môn cũ
            try
            {
                DCore.IData objIData = DCore.Data.CreateData(strOldConn);
                objIData.Connect();
                string strSQL = "select 0 as \"Order\", convert(bit,1) IsSelected, DSTotNghiep.SinhVien,SinhVien.Ma as MaSinhVien,SinhVien.Hodem, SinhVien.Ten, " +
                    " DSXetDTTN.TBC as TBTK, DTBTN,TBCXH, XLTN, DSTotNghiep.NamTN, SoQDTN,NgayQDTN  from DSTotNghiep " +
                    " Inner join SinhVien on SinhVien.sinhvien = DSTotNghiep.sinhvien " +
                    " Inner join LopHoc on LopHoc.LopHoc = SinhVien.Lophoc " +
                    " Inner join DSXetDTTN on DSXetDTTN.Sinhvien = DsTotNghiep.Sinhvien " +
                    " Where LopHoc.Ma =N'" + uClass.ClassIDEditValue + "'";
                
                dtbOldData = objIData.ExecQueryToDataTable(strSQL);

                foreach (DataRow drw in dtbOldData.Rows)
                {
                    drw["MaSinhVien"] = MyConvert.ConvertVNIToUnicode(drw["MaSinhVien"]);
                    drw["XLTN"] = Libs.MyConvert.ConvertVNIToUnicode(drw["XLTN"]);
                    drw["Hodem"] = Libs.MyConvert.ConvertVNIToUnicode(drw["Hodem"]);
                    drw["Ten"] = Libs.MyConvert.ConvertVNIToUnicode(drw["Ten"]);
                }
                gcOldData.DataSource = dtbOldData;
                gvOldData.SetOrder("Order");

                objIData.Disconnect();
            }
            catch
            {
                ErrorManager.Error("Không thể tải điểm môn học cũ");
            }
                       
        }

        public void LoadData()
        {
            SIM_GraduationResult obj = new SIM_GraduationResult();
            dtbData = obj.Search_Graduation_Result("@ClassID", uClass.IsRegulation43 ? null : uClass.ClassIDEditValue);                                        
            if (dtbData != null)
            {
                gcData.DataSource = dtbData;
                // set order
                gvData.SetOrder("Order");                
                gvData.BestFitColumns();
                btnSave.Enabled = true; // chưa sửa thì không có save nếu đã từng save                        
            }
            else
            {
                //ErrorManager.Error(obj.ErrorException);
                ErrorManager.Error("Việc lấy thông tin tốt nghiệp bị lỗi!");

            }
        }

        private double? ToDouble(object value)
        {
            if (value == null || value.ToString() == "")
                return null;
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_GraduationResult item = new SIM_GraduationResult();
            SIM_Student objStudent = new SIM_Student();
            item.BeginTransaction();
            objStudent.IDB = item.IDB;
            
            item.ExamDateID = 1;
            item.UpdatedUser = UserSession.Username; // them hay update deu dung truong nay            

            for (int i = 0; i < dtbOldData.Rows.Count; i++)
            {
                DataRow drw = dtbOldData.Rows[i];
                if (Convert.ToBoolean(drw["IsSelected"]))
                {
                    DataRow[] rows = dtbData.Select("StudentCode = '" + drw["MaSinhVien"].ToString() + "'");
                    if (rows.Length > 0)
                    {
                        item.DecisionNo = drw["SoQDTN"].ToString() != "" ? drw["SoQDTN"].ToString() : "...";
                        item.Signingdate = Convert.ToDateTime(drw["NgayQDTN"]);
                        item.YearID = Convert.ToInt32(drw["NamTN"]);

                        if (drw["XLTN"].ToString() != "")
                            item.ResultReview = 1; // đậu                        

                        else

                            item.ResultReview = 0; // rớt
                        
                        item.StudentID = Convert.ToInt32(rows[0]["StudentID"]); // sv du lieu moi    
                        item.SummaryLearningMark =  ToDouble(drw["TBTK"]);
                        //item.SummaryLearningLevel = drw["XLTN"].ToString();
                        item.GraduationExamAverage = ToDouble(drw["DTBTN"]);
                        item.GraduationRankingAverage = ToDouble(drw["TBCXH"]);
                        item.GraduationLevel = drw["XLTN"].ToString();
                        item.OrderExam = 1;
                        item.ExamDateID = 1;
                        item.HaveExamRegister1 = true;
                        item.HaveExamRegister2 = true;
                        item.HaveExamRegister3 = true;

                        if (rows[0]["GraduationResultID"].ToString() == "")
                        {
                            item.CreatedUser = UserSession.Username;
                            if (!item.Add())
                            {
                                ErrorManager.Error("Việc cập nhật thông tin tốt nghiệp bị lỗi!");
                                return false;
                            }
                        }
                        else
                        {
                            item.GraduationResultID = Convert.ToInt64(rows[0]["GraduationResultID"]); // ma du lieu moi
                            item.UpdatedUser = UserSession.Username;
                            if (!item.Update())
                            {
                                ErrorManager.Error("Việc cập nhật thông tin tốt nghiệp bị lỗi!");
                                return false;
                            }
                        }
                    }
                }
            }

            item.CommitTransaction();
            return true;
        }            

        #endregion

        #region Form Actions

        private void frmSyncGraduationResult_Load(object sender, EventArgs e)
        {
            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true; // lệnh này để Thread không bị warning            
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();

            try
            {                
                string str = Libs.Files.ReadFile(strFileConfig);
                string strConn = Core.Security.Secure.DecryptRijndael(str, Core.Security.MachineIdentify.MachineID);
                string[] a = strConn.Split(';');
                if (a.Length == 4)
                {
                    txtServerName.Text = a[0];
                    txtLoginName.Text = a[1];
                    txtPassword.Text = a[2];
                    txtDBName.Text = a[3];
                    strOldConn = string.Format(strTemplageConnection, txtServerName.TextTrim, txtLoginName.TextTrim, txtPassword.Text, txtDBName.TextTrim);
                }                
            }
            catch
            {                
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                btnSave.Enabled = btnSearch.Enabled = false;
                LoadData();
                LoadOldData();
                btnSave.Enabled = dtbOldData.Rows.Count > 0 && dtbData.Rows.Count > 0 && !objClassSubject.IsLocked;
                btnSearch.Enabled = true;
                //new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn chuyển KQTN của những dòng sinh viên đã chọn?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    LoadData();
                    btnSave.Enabled = false;
                    MessageManager.Info("Chuyển điểm thành công!");
                }
            }
        }               

        #endregion       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string strConn = string.Format(strTemplageConnection, txtServerName.TextTrim, txtLoginName.TextTrim, txtPassword.Text, txtDBName.TextTrim);
            DCore.IData objDB = DCore.Data.CreateData(strConn);
            try
            {
                objDB.Connect();
                MessageManager.Info("Kết nối thành công!");
                strOldConn = strConn;
            }
            catch (Exception objExc)
            {
                MessageManager.Error("Kết nối thất bại! " + objExc.Message);
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = txtServerName.Text + ";" + txtLoginName.Text + ";" + txtPassword.Text + ";" + txtDBName.Text;
                string str = Core.Security.Secure.EncryptRijndael(strConn, Core.Security.MachineIdentify.MachineID);

                Libs.Files.WriteFile(strFileConfig, str);
                MessageManager.Info("Đã lưu kết nối thành công!");
                strOldConn = string.Format(strTemplageConnection, txtServerName.TextTrim, txtLoginName.TextTrim, txtPassword.Text, txtDBName.TextTrim);
            }
            catch
            {
                ErrorManager.Error("Việc lưu cấu hình bị lỗi!");
            }
        }

        private void btnSaveGraduationResult_Click(object sender, EventArgs e)
        {

        }
    }
}

