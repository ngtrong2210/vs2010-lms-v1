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
    public partial class frmGraduationExamRegister : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_EDIT = "SIM_GraduationExamRegister_Edit";
        public const string PERMISSION_VIEW = "SIM_GraduationExamRegister_View";

        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        private string strClassID = "";
        private string strListIDDeleted = "";
        DataTable dtbData;
        DataTable dtbClassSubject;
        string[] strSubjectIDs = { "", "", "", "", "", "", "", "" }; // 3 mon thi tot nghiep cua lop nay
        string[] strSubjectNames = { "", "", "", "", "", "", "", "" };
        string strListSpecialType = "";
        bool bolIsRefresh = false;

        #endregion

        #region IForm Members

        private static frmGraduationExamRegister _instance = null;

        public static frmGraduationExamRegister Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmGraduationExamRegister();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmGraduationExamRegister()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            gvData.OptionsBehavior.Editable = UserSession.HasPermission(PERMISSION_EDIT);
            //mnuItemSave.Enabled = btnSave.Enabled = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uClass.ClassFilter = "ClassType = 0";// chỉ lọc ra lớp bình thường
                uClass.InitData();
                SIM_ExamDateService.InitLookUpEdit(lookupExamDate);
                txtMoney.EditValue = new AccountObject.ACC_ReceiptSegment().GetDefaultMoney(AccountObject.ReceiptSegmentGroup.ThiTotNghiep, null, null, null);
            }
        }

        private bool IsValidData()
        {
            if (!uClass.IsValidData())
                return false;

            // lấy ds loại môn được check  
            strListSpecialType = "";
            if (chkTotNghiepVanHoa.Checked)
                strListSpecialType = "," + Global.SubjectSpecialType.TotNghiepVanHoa.ToString();
            if (chkTotNghiepChinhTri.Checked)
                strListSpecialType += "," + Global.SubjectSpecialType.ChinhTriTotNghiep.ToString();
            if (chkTotNghiepNghe.Checked)
                strListSpecialType += "," + Global.SubjectSpecialType.TotNghiepLT.ToString() + "," + Global.SubjectSpecialType.TotNghiepTH.ToString();

            if (strListSpecialType == "")
            {
                MessageManager.Warning("Bạn phải chọn loại môn tốt nghiệp");
                chkTotNghiepVanHoa.Focus();
                return false;
            }
            else
                strListSpecialType += ",";
            if (lookupExamDate.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn kỳ thi tốt nghiệp");
                lookupExamDate.Focus();
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

                // lấy ds dự thi tốt nghiệp đã xét
                SIM_SubjectMark obj = new SIM_SubjectMark();
                dtbData = obj.GetDataTable("SIM_SubjectMark_GraduationExamRegister",
                                                     "@ClassID", uClass.ClassIDEditValue,
                                                     "@ListSpecialType", strListSpecialType,
                                                     "@ExamDateID", lookupExamDate.EditValue);

                if (dtbData != null)
                {
                    gcData.DataSource = dtbData;
                    SystemService.SYS_GridColumnService.InitGridColumn(gvData, "SIM_SubjectMark_GraduationExamRegister", bolIsRefresh);
                    ModifyGrid();
                    ModifyNullValue();
                    gvData.BestFitColumns();
                    mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save 
                    btnSave.Enabled = mnuItemSave.Enabled = false;
                    bolIsRefresh = false;
                }
                else
                {
                    MessageManager.Error("Việc lấy thông tin sổ điểm bị lỗi!");
                }
            }
        }

        private void ModifyGrid()
        {
            SIM_Subject obj = new SIM_Subject();
            dtbClassSubject = obj.GetDataTable("SIM_SubjectMark_GraduationExamRegister_SubjectList",
                                                 "@ClassID", uClass.ClassIDEditValue,
                                                 "@ListSpecialType", strListSpecialType,
                                                 "@ExamDateID", lookupExamDate.EditValue);
            if (dtbClassSubject != null)
            {
                for (int i = 0; i < dtbClassSubject.Rows.Count; i++)
                {
                    string strCol = "Checked_" + (i + 1).ToString();
                    if (gvData.Columns[strCol] != null)
                    {
                        gvData.Columns[strCol].Visible = true;
                        gvData.Columns[strCol].Caption = dtbClassSubject.Rows[i]["SubjectName"].ToString();
                    }
                }

                for (int i = dtbClassSubject.Rows.Count + 1; i <= 10; i++)
                {
                    string strCol = "Checked_" + i.ToString();
                    if (gvData.Columns[strCol] != null)
                        gvData.Columns[strCol].Visible = false;
                }
            }
            else
            {
                ErrorManager.Error("Việc lấy danh sách môn thi bị lỗi!");
            }
        }

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_Subject obj = new SIM_Subject();
            SIM_GraduationResult_Subject itemRegisterSubject = new SIM_GraduationResult_Subject();            
            SIM_GraduationResult itemResult = new SIM_GraduationResult();

            obj.BeginTransaction();
            itemResult.IDB = obj.IDB;
            itemRegisterSubject.IDB = obj.IDB;

            itemRegisterSubject.ExamDateID = itemResult.ExamDateID = lookupExamDate.EditValueInt32;            
            itemResult.CreatedUser = UserSession.Username;

            for (int i = 0; i < dtbData.Rows.Count; i++)
            {
                DataRow drw = dtbData.Rows[i];

                if (drw["Money"].ToString() != "")
                    itemResult.Money = Convert.ToDouble(drw["Money"]);
                else
                    itemResult.Money = null;

                itemRegisterSubject.StudentID = itemResult.StudentID = Convert.ToInt64(drw["StudentID"]);


                if (drw["IsEdit"].ToString() == "1")
                {
                    // quét để cập nhật ds môn đăng ký
                    foreach (DataRow drw2 in dtbClassSubject.Rows)
                    {                        
                        bool bolChecked = false;
                        if (drw["Checked_" + drw2["OrderIndex"]]!= DBNull.Value)
                            bolChecked = Convert.ToBoolean(drw["Checked_" + drw2["OrderIndex"]]);

                        itemRegisterSubject.SubjectID = drw2["SubjectID"].ToString();
                        if (!itemRegisterSubject.AddOrEdit(bolChecked,Convert.ToInt64(drw2["ClassSubjectID"]),UserSession.Username))
                        {
                            ErrorManager.Error("Việc cập nhật đăng ký môn bị lỗi!");
                            return false;
                        }
                    }

                    // xử lý thêm vào sổ điểm và dữ liệu xét tốt nghiệp
                    if (!itemResult.ExamRegister(strClassID,strListSpecialType))
                    {
                        ErrorManager.Error("Việc cập nhật đăng ký kỳ thi bị lỗi!");
                        return false;
                    }
                }
            }

            obj.CommitTransaction();
            return true;
        }


        private void CheckAll(bool bolValue)
        {
            foreach (DataRow drw in dtbData.Rows)
            {
                foreach (DataRow drw2 in dtbClassSubject.Rows)
                {
                    if (Convert.ToBoolean(drw["Allow_" + drw2["OrderIndex"].ToString()]))
                    {
                        drw["Checked_" + drw2["OrderIndex"].ToString()] = bolValue;
                        drw["IsEdit"] = 1;
                        if (bolValue)
                            drw["Money"] = txtMoney.EditValueInt32;
                        else
                            drw["Money"] = DBNull.Value;
                    }
                }
            }
            btnSave.Enabled = mnuItemSave.Enabled = true;
        }

        private void ModifyNullValue()
        {
            foreach (DataRow drw in dtbData.Rows)
            {
                for (int j = 1; j <= 10; j++ )
                {
                    if (drw["Checked_" + j.ToString()] == DBNull.Value)
                    {
                        drw["Checked_" + j.ToString()] = false;
                        drw["Allow_" + j.ToString()] = true;
                    }
                }
            }
        }

        #endregion

        #region Form Actions

        private void frmMakeStudentCode_Load(object sender, EventArgs e)
        {
            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                if (btnSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi trước khi nạp lại dữ liệu?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return;
                    else if (dlrConfirm == DialogResult.Yes)
                        if (!SaveData())
                            return;// lưu không thành công thì return
                }
                new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lookupExamDate.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn kì thi tốt nghiệp!");
                lookupExamDate.Focus();
                return;
            }

            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    new Thread(LoadData).Start();
                }
            }
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
           if (uClass.ClassIDEditValue != null && (chkTotNghiepVanHoa.Checked || chkTotNghiepChinhTri.Checked || chkTotNghiepNghe.Checked))
                btnSearch_Click(sender, arg);
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvData.GetFocusedDataRow();
            if (drw != null)
            {
                btnSave.Enabled = mnuItemSave.Enabled = true;
                drw["IsEdit"] = 1;
            }
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Contains("Checked_"))
            {
                DataRow drw = gvData.GetDataRow(e.RowHandle);
                if (drw != null)
                {
                    int i = Convert.ToInt32(e.Column.FieldName.Replace("Checked_", ""));
                    if (i <= dtbClassSubject.Rows.Count)
                    {
                        if (!Convert.ToBoolean(drw["Allow_"+i.ToString()])) // nếu hông cho phép edit thì đổi màu
                            e.Appearance.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (gvData.FocusedColumn.FieldName.Contains("Checked_"))
            {
                DataRow drw = gvData.GetDataRow(gvData.FocusedRowHandle);
                if (drw != null)
                {
                    if (!Convert.ToBoolean(drw[gvData.FocusedColumn.FieldName.Replace("Checked_", "Allow_")])) // nếu hông cho phép edit thì đổi màu                
                    {
                        MessageManager.Warning("Đã xét tốt nghiệp ở kỳ này, hoặc môn này đã có điểm!");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(false);
        }        

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //if (gvData.FocusedColumn.FieldName.Contains("HaveExamRegister"))
            //{
            //    DataRow drw = gvData.GetFocusedDataRow();
            //    if (drw != null)
            //    {
            //        if (Convert.ToBoolean(e.Value))

            //            drw["Money"] = txtMoney.EditValueInt32;
            //        else
            //            drw["Money"] = DBNull.Value;
            //    }
            //}
        }

        #endregion

        private void txtMoney_Load(object sender, EventArgs e)
        {

        }

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            bolIsRefresh = true;
            btnSearch_Click(null, null);
        }

        private void chkTotNghiepVanHoa_CheckedChanged(object sender, EventArgs e)
        {
            bolIsRefresh = true;
        }
    }
}