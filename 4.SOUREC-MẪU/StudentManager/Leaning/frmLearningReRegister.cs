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
namespace StudentManager.Learning
{
    public partial class frmLearningReRegister : FormBase, IForm
    {
        #region Consts
        
        public const string PERMISSION_EDIT = "SIM_LearningReRegister_Edit";
        public const string PERMISSION_VIEW = "SIM_LearningReRegister_View";

        #endregion

        #region Variables
        
        DataTable dtbData; // danh sách dữ liệu sinh viên trong lớp
        DataTable dtbLearningReRegister; // danh sách sinh viên đăng ký học lại
        DataTable dtbSubject; // danh sách môn học có trong danh sách sinh viên đăng ký học lại        
        DataTable dtbClassSubject; // Môn học lớp theo môn đăng ký để filter lớp lại theo môn.
        string strClassIDList = ""; // lọc theo danh sách lớp của môn đang chọn        

        private bool bolHavePermissionEdit = false;
       
        #endregion

        #region IForm Members

        private static frmLearningReRegister _instance = null;

        public static frmLearningReRegister Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmLearningReRegister();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmLearningReRegister()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                                    
            bolHavePermissionEdit = UserSession.HasPermission(PERMISSION_EDIT);
        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uSubjectGroup.InitData();
                uYearSemester.InitData();
                
                if (strClassIDList == "")
                    uClass.ClassFilter = "ClassID='-1'";// chỉ lọc ra lớp bình thường
                else
                    uClass.ClassFilter = "ClassType = 0 And ClassID in (" + strClassIDList + ")";

                uClass.InitData();
            }
        }

        private bool IsValidData()
        {
            if (!uClass.IsValidData())
                return false;
            return true;
        }

        public void LoadData()
        {

            SIM_ReRegister obj = new SIM_ReRegister();
            dtbLearningReRegister = obj.SearchLearningReRegister(
                                                "@YearID", uYearSemester.YearIDEditValue,
                                                "@Semester", uYearSemester.SemesterEditValue);
            dtbSubject = obj.SearchSubjectLearningReRegister(
                                                "@YearID", uYearSemester.YearIDEditValue,
                                                "@Semester", uYearSemester.SemesterEditValue);
            dtbClassSubject = obj.SearchClassSubject(
                                                "@YearID", uYearSemester.YearIDEditValue,
                                                "@Semester", uYearSemester.SemesterEditValue);
            dtbData = obj.SearchStudentForReRegister(
                                                "@YearID", uYearSemester.YearIDEditValue,
                                                "@Semester", uYearSemester.SemesterEditValue);

            if (dtbLearningReRegister != null && dtbSubject != null && dtbClassSubject != null && dtbData != null)
            {
                gcData.DataSource = dtbData;
                gcReRegister.DataSource = dtbLearningReRegister;

                lookupSubjectID.InitData(dtbSubject, "--Chọn môn--", "SubjectID", "SubjectName", "SubjectID", "Mã môn", "SubjectName", "Tên môn", "StudentAmount", "Lượng đăng ký");

                FilterReRegisterData();
                FilterStudentData();

              
                Service.SYS_GridColumnService.InitGridColumn(gvReRegister, "SIM_ReRegister_LearningReRegister");
                Service.SYS_GridColumnService.InitGridColumn(gvData, "SIM_ReRegister_StudentList");

                gvReRegister.BestFitColumns();
                gvData.BestFitColumns();
                
                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save 
                btnSave.Enabled = mnuItemSave.Enabled = false;
            }
            else
            {
                //ErrorManager.Error(obj.ErrorException);
                ErrorManager.Error("Việc lấy thông tin sổ điểm bị lỗi!");
            }
        }

        private void FilterStudentData()
        {
            if (dtbData != null)
            {
                string strFilter = "";
                if (cbxStudentTypeView.SelectedIndex == 1)
                    strFilter = " And SubjectID = ''"; // sinh viên của lớp
                else if (cbxStudentTypeView.SelectedIndex == 2)
                    strFilter = " And SubjectID <> ''"; // sinh viên học lại

                if (uClass.ClassIDEditValue != null && lookupSubjectID.EditValueText != null)
                {
                    gvData.RowFilter = "IsDel=0 and ClassID='" + uClass.ClassIDEditValue + "' And (SubjectID='' Or SubjectID='" + lookupSubjectID.EditValueText + "') " + strFilter;
                }
                else
                    gvData.RowFilter = "StudentID='-1'"; // ẩn hết sinh viên

                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
                btnAddAll.Enabled = mnuItemAddAll.Enabled = dtbLearningReRegister.DefaultView.Count > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
                // set order.            
                gvData.SetOrder("Order");
            }
        }

        private void FilterReRegisterData()
        {
            if (dtbLearningReRegister != null)
            {
                if (lookupSubjectID.EditValueText != null)
                {
                    // Chọn lại khoa, bộ môn
                    DataRow[] rows = dtbSubject.Select("SubjectID='" + lookupSubjectID.EditValueText + "'");
                    if (rows.Length > 0)
                    {
                        uSubjectGroup.SubjectGroupEditValue = rows[0]["SubjectGroupID"].ToString();
                    }


                    // lọc lại sinh viên đăng ký
                    gvReRegister.RowFilter = "IsDel = 0 and SubjectID='" + lookupSubjectID.EditValueText + "'";


                    // lọc lại lớp học có học môn này ở niên kì này
                    rows = dtbClassSubject.Select("SubjectID='" + lookupSubjectID.EditValueText + "'");
                    strClassIDList = "";
                    foreach (DataRow drw in rows)
                    {
                        strClassIDList += ",'" + drw["ClassID"].ToString() + "'";
                    }
                    if (strClassIDList != "")
                    {
                        strClassIDList = strClassIDList.Substring(1);
                        uClass.ClassFilter = "ClassType = 0 and ClassID in (" + strClassIDList + ")";
                    }
                    else
                        uClass.ClassFilter = "ClassID='-1'"; // xoá danh sách lớp                    

                }
                else
                    gvReRegister.RowFilter = "IsDel = 0";

                btnAddAll.Enabled = mnuItemAddAll.Enabled = dtbLearningReRegister.DefaultView.Count > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
                gvReRegister.SetOrder("Order");
            }
        }       

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData()
        {
            SIM_SubjectMark item = new SIM_SubjectMark();
            item.BeginTransaction();
          
            foreach(DataRow drw in dtbData.Rows)
            {
                if (drw["SubjectMarkID"].ToString() != "" && drw["IsDel"].ToString() == "1") // dữ liệu cũ, và bị đánh dấu xoá thì xoá
                {
                    SIM_SubjectMark item2 = new SIM_SubjectMark(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;
                    item2.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);                  
                    if (!item2.Delete())
                    {
                        ErrorManager.Error("Việc gỡ bỏ đăng ký học lại bị lỗi!");
                        return false;
                    }
                }
                else if (drw["IsNew"].ToString() == "1" && drw["IsDel"].ToString() == "0")
                {
                    SIM_SubjectMark item2 = new SIM_SubjectMark(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;

                    item2.StudentID = Convert.ToInt64(drw["StudentID"]);
                    item2.SubjectID = drw["SubjectID"].ToString();
                    item2.OrderLearning = Convert.ToInt32(drw["OrderLearning"]); // tăng lần học lên so với lần cuối cùng của sinh viên này (đã cộng trong store)                                       
                    item2.ReRegisterID = Convert.ToInt64(drw["ReRegisterID"]); // mã đăng ký học lại
                    
                    // tìm class subjectID theo từng môn học lớp
                    DataRow[] rows = dtbClassSubject.Select("ClassID='" + drw["ClassID"].ToString() + "' And SubjectID='" + drw["SubjectID"].ToString() + "'");
                    item2.ClassSubjectID = Convert.ToInt32(rows[0]["ClassSubjectID"]);
                    

                    item2.CreatedUser = UserSession.Username;

                    if (!item2.Add())
                    {
                        ErrorManager.Error("Việc đăng ký học lại bị lỗi!");
                        return false;
                    }
                }
            }

            item.CommitTransaction();
            return true;
        }

        private void ModifyGrid()
        {

            #region Commom

            //foreach (DevExpress.XtraGrid.Columns.GridColumn col in gvData.Columns)
            //{
            //    col.OptionsColumn.AllowEdit = true;

            //    switch (col.FieldName)
            //    {
            //        case "Order":
            //            col.Caption = "STT";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //        case "StudentFirstName":
            //            col.Caption = "Họ lót";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //        case "StudentLastName":
            //            col.Caption = "Tên";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;
            //        case "GenderText":
            //            col.Caption = "Giới tính";
            //            col.OptionsColumn.AllowEdit = false;
            //            break;                   
            //        default:
            //            col.Visible = false;
            //            break;
            //    }

            //}

            #endregion

        }

        private void CheckAllReRegisterData(bool bolValue)
        {
            for(int i=0;i<gvReRegister.RowCount; i++)
            {                
                DataRow drw = gvReRegister.GetDataRow(i);                                
                        drw["IsSelected"] = bolValue;
            }
        }

        private void CheckAllStudentData(bool bolValue)
        {
            for(int i=0;i<gvData.RowCount; i++)
            {                
                DataRow drw = gvData.GetDataRow(i);                                
                if(drw["FinalSummary"].ToString()=="" && drw["SubjectID"].ToString()!="") // vầy mới là môn đăng ký học lại và chưa điểm
                        drw["IsSelected"] = bolValue;
            }
        }

        /// <summary>
        /// Add sinh vien vào lớp
        /// </summary>
        /// <param name="isAddAll"></param>
        private void AddStudent(bool isAddAll)
        {
            for (int i = gvReRegister.RowCount - 1; i >= 0; i--)
            {
                DataRow drw = gvReRegister.GetDataRow(i);
                if (isAddAll || Convert.ToBoolean(drw["IsSelected"]) || gvReRegister.IsRowSelected(i))
                {
                    // Đánh dấu xoá ở dữ liệu
                    drw["IsSelected"] = false;
                    drw["IsDel"] = 1; // đã xoá ở lưới dữ liệu


                    // thêm qua dữ liệu sinh viên lớp
                    DataRow[] rows = dtbData.Select("StudentID='" + drw["StudentID"].ToString()
                            + "' And SubjectID='" + drw["SubjectID"].ToString()
                            + "' And ClassID='" + uClass.ClassIDEditValue + "'");

                    // có rồi thì bậc lại ở sinh viên
                    if (rows.Length > 0)
                    {
                        rows[0]["IsDel"] = 0;
                    }
                    else // chưa có thì thêm mới dòng ở sinh viên
                    {
                        DataRow drwNew = dtbData.NewRow();
                        drwNew["IsNew"] = 1; // đánh dấu dòng mới để lát thêm vào
                        drwNew["SubjectMarkID"] = DBNull.Value;
                        drwNew["IsDel"] = 0;
                        drwNew["IsSelected"] = false;
                        drwNew["StudentID"] = drw["StudentID"];
                        drwNew["StudentCode"] = drw["StudentCode"];
                        drwNew["StudentFirstName"] = drw["StudentFirstName"];
                        drwNew["StudentLastName"] = drw["StudentLastName"];
                        drwNew["GenderText"] = drw["GenderText"];
                        drwNew["BirthDateText"] = drw["BirthDateText"];
                        drwNew["ClassOfStudent"] = drw["ClassID"]; // lớp của sinh viên để hiển thị
                        drwNew["ClassID"] = uClass.ClassIDEditValue; // lớp được add vô
                        drwNew["SubjectID"] = drw["SubjectID"];
                        drwNew["OrderLearning"] = drw["OrderLearning"]; // lần học cuối cùng của sinh viên, da +1 khi load len
                        drwNew["ReRegisterID"] = drw["ReRegisterID"]; // mã đăng ký học lại
                        dtbData.Rows.Add(drwNew);
                    }

                }
            }
            if (isAddAll)
            {
                btnAdd.Enabled = mnuItemAdd.Enabled =  btnAddAll.Enabled = mnuItemAddAll.Enabled =  false;                
            }
            else
            {
                btnAdd.Enabled = mnuItemAdd.Enabled =  false;
                btnAddAll.Enabled = mnuItemAddAll.Enabled =  dtbLearningReRegister.DefaultView.Count > 0 && bolHavePermissionEdit;
            }
            btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;
        }

        /// <summary>
        /// Add sinh vien vào lớp
        /// </summary>
        /// <param name="isAddAll"></param>
        private void DelStudent(bool isDelAll)
        {
            for (int i = gvData.RowCount - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (isDelAll || Convert.ToBoolean(drw["IsSelected"]) || gvData.IsRowSelected(i))
                {
                    if (drw["FinalSummary"].ToString() == "" && drw["SubjectID"].ToString() != "")
                    {

                        // Đánh dấu xoá ở sinh viên
                        drw["IsSelected"] = false;
                        drw["IsDel"] = 1; // đã xoá ở lưới dữ liệu


                        // thêm qua dữ liệu
                        DataRow[] rows = dtbLearningReRegister.Select("StudentID='" + drw["StudentID"].ToString()
                                + "' And SubjectID='" + drw["SubjectID"].ToString() + "'");

                        // có rồi thì bậc lại ở dữ liệu
                        if (rows.Length > 0)
                        {
                            rows[0]["IsDel"] = 0;
                        }
                        else // chưa có thì thêm mới dòng ở sinh viên
                        {
                            DataRow drwNew = dtbLearningReRegister.NewRow();
                            drwNew["IsDel"] = 0;
                            drwNew["IsSelected"] = false;
                            drwNew["StudentID"] = drw["StudentID"];
                            drwNew["StudentCode"] = drw["StudentCode"];
                            drwNew["StudentFirstName"] = drw["StudentFirstName"];
                            drwNew["StudentLastName"] = drw["StudentLastName"];
                            drwNew["GenderText"] = drw["GenderText"];
                            drwNew["BirthDateText"] = drw["BirthDateText"];
                            drwNew["ClassID"] = drw["ClassID"]; // lớp của sinh viên để hiển thị                            
                            drwNew["SubjectID"] = drw["SubjectID"];
                            drwNew["OrderLearning"] = drw["OrderLearning"]; // xoa ra, neu xoa trung thang da tung dang ky thi lay orderLearning qua
                            dtbLearningReRegister.Rows.Add(drwNew);
                        }
                    }
                }
            }
            if (isDelAll)
                btnDelete.Enabled = mnuItemDelete.Enabled =  btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  false;
            else
            {
                btnDelete.Enabled = mnuItemDelete.Enabled =  false;
                btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
            }
            btnAddAll.Enabled = mnuItemAddAll.Enabled =  dtbLearningReRegister.DefaultView.Count > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;
        } 

        #endregion

        #region Form Actions

        private void frmLearningReRegister_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (uYearSemester.IsValidData())
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
                LoadData();
                //new Thread(LoadData).Start();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                if (SaveData())
                {
                    //MessageManager.Info("Đã cập nhật dữ liệu thành công!");
                    LoadData();
                    //new Thread(LoadData).Start();
                }
            }
        }

        private void uClass_EditValueChanged(object sender, EventArgs arg)
        {
            FilterStudentData();            
        }

        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnDelete.Enabled = mnuItemDelete.Enabled =  gvData.SelectedRowsCount > 0;
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(e.RowHandle);
            if (drw != null)
            {
                if (drw["FinalSummary"].ToString() != "") // học lại và đã có điểm
                    e.Appearance.BackColor = Color.LightPink;
                else if (drw["SubjectID"].ToString() != "") // là đăng ký học lại
                {
                    if (drw["SubjectMarkID"].ToString() == "") // đăng ký mới
                        e.Appearance.BackColor = Color.LightSkyBlue;
                    else
                        e.Appearance.ForeColor = Color.Blue; // cái đăng ký cũ
                }

            }
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(gvData.FocusedRowHandle);
            if (drw != null)
            {
                if (drw["FinalSummary"].ToString()!="" || drw["SubjectID"].ToString() =="") // nếu hông cho phép edit vì có điểm rồi hoặc hông phải đăng ký mà của chính lớp
                    e.Cancel = true;
            }
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllStudentData(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllStudentData(false);
        }

        /// <summary>
        /// Chọn lại môn thì phải lọc lại sinh viên đang ký, chọn lại khoa bộ môn, lọc lại lớp học có học môn đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void lookupSubjectID_EditValueChanged(object sender, EventArgs arg)
        {
            FilterReRegisterData();
            FilterStudentData();
        }

        private void uYearSemester_EditValueChanged(object sender, EventArgs arg)
        {
            if (uYearSemester.YearIDEditValue != null && uYearSemester.SemesterEditValue != null)
                btnSearch_Click(sender,arg);
        }
               
        private void gvReRegister_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnAdd.Enabled = mnuItemAdd.Enabled = gvReRegister.SelectedRowsCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            AddStudent(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddStudent(false);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DelStudent(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DelStudent(false);
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (uYearSemester.IsValidData())
            {
                if (btnSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi trước khi đóng màn hình?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return;
                    else if (dlrConfirm == DialogResult.Yes)
                        if (!SaveData())
                            return;// lưu không thành công thì return

                    LoadData(); //load leen cho chac, neu khong lat no mo form len nua thi kho
                }
                //new Thread(LoadData).Start();
                this.Close();
            }
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void gvReRegister_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnAdd.Enabled = mnuItemAdd.Enabled = gvReRegister.SelectedRowsCount > 0 && uClass.ClassIDEditValue != null && bolHavePermissionEdit;
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnDelete.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 && bolHavePermissionEdit;
        }

        private void mnuItemCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllReRegisterData(true);
        }

        private void mnuItemUnCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllReRegisterData(false);
        }

        private void gvReRegister_EndSorting(object sender, EventArgs e)
        {
            gvReRegister.SetOrder("Order");
        }

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            gvData.SetOrder("Order");
        }

        private void cbxStudentTypeView_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudentData();
        }

        private void uSubjectGroup_EditValueChanged(object sender, EventArgs arg)
        {
            string strFilter = "";
            if (uSubjectGroup.ScienceEditValue != null)
                strFilter = "ScienceID = '" + uSubjectGroup.ScienceEditValue.ToString() + "'";

            if (uSubjectGroup.SubjectGroupEditValue != null)
            {
                if (strFilter != "")
                    strFilter += " and ";
                strFilter += "SubjectGroupID='" + uSubjectGroup.SubjectGroupEditValue + "'";
            }

            lookupSubjectID.RowFilter = strFilter;
        }
       
    }
}

