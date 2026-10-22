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
using DeclarationManager.Training;
using DeclarationManager.School;
        
namespace StudentManager.Graduation
{
    public partial class frmMakeGraduationExamSchedule : FormBase, IForm
    {
        #region Consts

        public const string PERMISSION_STUDENT_EDIT = "SIM_MakeGraduationExamSchedule_Student_Edit"; // cập nhật bố trí sinh viên
        public const string PERMISSION_MANAGER = "SIM_MakeGraduationExamSchedule_Manager"; // quản lý lịch thi
        public const string PERMISSION_VIEW = "SIM_MakeGraduationExamSchedule_View"; // xem

        #endregion

        #region Variables

        bool bolIsEditing = false; // dang edit hay khong
        DataTable dtbClass; // danh sách lớp học theo môn
        DataTable dtbStudent; // danh sách sinh viên của lớp                        

        DataTable dtbTestSchedule; // lịch thi
        DataTable dtbData; // danh sách dữ liệu sinh viên theo lịch thi

        string strClassIDList = ""; // lọc theo danh sách lớp của môn đang chọn        
        DateTime dtmFromDateOfYear = DateTime.Now.Date;
        int? intSpecialType = null;

        bool bolHavePermissionEdit = false;
       
        #endregion

        #region IForm Members

        private static frmMakeGraduationExamSchedule _instance = null;

        public static frmMakeGraduationExamSchedule Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmMakeGraduationExamSchedule();
                return _instance;
            }
        }

        public void Run(bool isShowDialog)
        {
            FormManager.Run(Instance, isShowDialog);
        }

        #endregion

        public frmMakeGraduationExamSchedule()
        {
            InitializeComponent();
        }

        #region Support Functions

        private void CheckPermission()
        {
            // Kiểm tra quyền                        
            btnAdd.Enabled = mnuItemAdd.Enabled = UserSession.HasPermission(PERMISSION_MANAGER); // quản lý lịch thi        
            mnuPopupTestSchedule.Enabled = btnAdd.Enabled;

            btnEdit.Text = mnuItemEditList.Text = (UserSession.HasPermission(PERMISSION_MANAGER) || UserSession.HasPermission(PERMISSION_STUDENT_EDIT) ? "Sửa" : "Xem"); // sửa lịch hoặc sửa sinh viên            
            bolHavePermissionEdit = UserSession.HasPermission(PERMISSION_STUDENT_EDIT);
            gvList.RowFilter = UserSession.GetSubjectGroupFilter(PERMISSION_VIEW); // lịch thi theo bộ môn            

             gvClass.RowFilter = UserSession.GetScienceFilter(PERMISSION_STUDENT_EDIT); // thêm sinh viên thì là edit sinh viên vào lịch
            gvData.RowFilter = UserSession.GetScienceFilter(PERMISSION_VIEW); // sinh viên theo khoa. View hết, khi xóa ra thì kiểm tra quyền

        }

        public void LoadReferenceData()
        {
            if (InvokeRequired)
                Invoke(new MethodInvoker(LoadReferenceData));
            else
            {
                uYearSemester.InitData();
                uYearSemesterSearch.InitData();

                SIM_TeacherService.InitRepositoryLookUpEdit(repositoryTeacherID1);
                SIM_TeacherService.InitRepositoryLookUpEdit(repositoryTeacherID2);
                SIM_RoomService.InitRepositoryLookUpEdit(repositoryRoomID);
                SIM_RoomService.InitRepositoryLookUpEdit(repositoryRoomID2);
                SIM_TestSessionService.InitRepositoryLookUpEdit(repositoryTestSessionID);

                SIM_ExamDateService.InitLookUpEdit(lookupExamDate);
                SimsService.SIM_SubjectService.InitLookUpEdit(lookupSubjectID);
                lookupSubjectID.RowFilter = "SpecialType in (2,3,4)";
            }
        }

        private void RefreshReferenceData()
        {
            SIM_ScienceService.HaveNewData = true;
            Service.SIM_SubjectGroupService.HaveNewData = true;
            SIM_YearService.HaveNewData = true;
            SIM_TeacherService.HaveNewData = true;
            SIM_RoomService.HaveNewData = true;
            SIM_TestSessionService.HaveNewData = true;            
            LoadReferenceData();
        }

        private bool IsValidData()
        {            
            return uYearSemesterSearch.IsValidData();
        }

        private void LoadData()
        {
            SIM_TestSchedule obj = new SIM_TestSchedule();
            DataTable dtbList = obj.SearchGraduationExamSchedule("@YearID", uYearSemesterSearch.YearIDEditValue,
                                    "@Semester", uYearSemesterSearch.SemesterEditValue,
                                    "@ExamDateID", lookupExamDate_Search.EditValue);
                                    //"@TestOrder", cbxTestOrderSearch.Text);
            if (dtbList != null)
            {
                gcList.DataSource = dtbList;
                gvList.SetOrder("Order");

                gvList.BestFitColumns();


                gvList.SearchAndSelectRow("ExamDateID", lookupExamDate.EditValueString); // chọn dòng đang edit
                mnuItemEditList.Enabled = btnEdit.Enabled = gvList.GetFocusedDataRow() != null;
                
            }
            else
            {
               ErrorManager.Error("Việc lấy dự liệu lịch thi bị lỗi!");
            }
        }

        public void LoadEditData()
        {
            if (lookupExamDate.EditValue == null || lookupSubjectID.EditValue == null)
            {
                dtbClass = null;
                dtbStudent = null;
                dtbTestSchedule = null;
                dtbData = null;

                gcClass.DataSource = dtbClass;
                gcStudent.DataSource = dtbStudent;
                gcTestSchedule.DataSource = dtbTestSchedule;
                gcData.DataSource = dtbData;                

                return;
            }

            
            // tìm lớp có học môn này ở niên kì này
            SimsObject.SIM_Class objClass = new SIM_Class();
            dtbClass = objClass.SearchForGraduationExamSchedule("@SubjectID", lookupSubjectID.EditValue,
                                    //"@SpecialType",intSpecialType,
                                   "@ExamDateID", lookupExamDate.EditValue);
            
            // tìm sinh viên có học môn ở niên kì này
            // truyền lần thi, để lấy luôn mã lịch thi nếu sv đã được tổ chức thi                       

            SIM_Student objStudent = new SIM_Student();
            dtbStudent = objStudent.SearchForMakeGraduationExamSchedule("@SubjectID", lookupSubjectID.EditValue,
                                    "@ExamDateID", lookupExamDate.EditValue);
                                    //"@SpecialType", intSpecialType,
                                    //"@TestOrder", cbxTestOrder.Text);
            
            // tìm lịch thi
            SIM_TestSchedule objTestSchedule = new SIM_TestSchedule();
            dtbTestSchedule = objTestSchedule.SearchForMakeExamSchedule("@SubjectID", lookupSubjectID.EditValue,
                                    //"@YearID",uYearSemester.YearIDEditValue,
                                    //"@Semester",uYearSemester.SemesterEditValue,
                                    "@ExamDateID",lookupExamDate.EditValue);
                                    //"@TestOrder", cbxTestOrder.Text);

            if (dtbTestSchedule != null && dtbTestSchedule.Rows.Count > 0)
            {
                uYearSemester.YearIDEditValue = dtbTestSchedule.Rows[0]["YearID"];
                uYearSemester.SemesterEditValue = dtbTestSchedule.Rows[0]["Semester"];
            }
            gvTestSchedule.RowFilter = "RoomID is not null"; // khi xoa thi set RoomID null, nen fai view kieu loai tru nay


            // sinh viên của lớp                        

            if (dtbStudent != null && dtbClass != null && dtbTestSchedule != null)
            {
                gcClass.DataSource = dtbClass;
                gcStudent.DataSource = dtbStudent;
                gcTestSchedule.DataSource = dtbTestSchedule;

                // copy qua cho dtbData sinh viên đã đăng ký
                dtbData = dtbStudent.Copy();
                gcData.DataSource = dtbData;
                
                FilterStudent();
                FilterData();

                Service.SYS_GridColumnService.InitGridColumn(gvStudent, "SIM_ReRegister_StudentList");
                Service.SYS_GridColumnService.InitGridColumn(gvData, "SIM_ExamSchedule_StudentList");

                gvStudent.BestFitColumns();
                gvData.BestFitColumns();
                gvTestSchedule.BestFitColumns();

                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save                 
                btnSave.Enabled = mnuItemSave.Enabled = false;

                // tìm l?i ngày b?t ??u c?a niên
                BO.SIM_Year itemYear = new DataAccess.SIM_YearDAO().Get(uYearSemester.YearIDEditValueInt32.Value);
                if (itemYear != null)
                {
                    dtmFromDateOfYear = itemYear.StartAt.Value;
                }
            }
            else
            {
                //ErrorManager.Error(obj.ErrorException);
                ErrorManager.Error("Việc lấy thông tin sổ điểm bị lỗi!");
            }
        }

        /// <summary>
        /// khi save xong thì gọi reload
        /// </summary>
        public void ReLoadEditData()
        {


            // tìm sinh viên có học môn ở niên kì này
            // truyền lần thi, để lấy luôn mã lịch thi nếu sv đã được tổ chức thi            

            SIM_Student objStudent = new SIM_Student();
            dtbStudent = objStudent.SearchForMakeGraduationExamSchedule("@SubjectID", lookupSubjectID.EditValue,
                                    "@ExamDateID", lookupExamDate.EditValue);
                                    //"@SpecialType", intSpecialType,
                                    //"@TestOrder", cbxTestOrder.Text);

            if (dtbStudent != null)
            {
                dtbData = dtbStudent.Copy();
                
                gcStudent.DataSource = dtbStudent;
                gcData.DataSource = dtbData;

                FilterStudent();
                FilterData();

                gvStudent.BestFitColumns();
                gvData.BestFitColumns();

                mnuItemExportToExcel.Enabled = dtbData.Rows.Count > 0; // load lại thì không cần save                 
                btnSave.Enabled = mnuItemSave.Enabled = mnuItemSaveSchedule.Enabled = false;
            }
            else
            {
                //ErrorManager.Error(obj.ErrorException);
                ErrorManager.Error("Việc lấy thông tin sổ điểm bị lỗi!");
            }
        }

        /// <summary>
        /// Active refresh hay reload thì gọi sự kiện này,
        /// Nó kiểm tra nếu có cần lưu thì hỏi có lưu hay không và lưu rồi mới action
        /// </summary>
        public bool ConfirmCommitEdit()
        {
            if (uYearSemester.IsValidData())
            {
                if (btnSave.Enabled || mnuItemSaveSchedule.Enabled || mnuItemSave.Enabled)
                {
                    DialogResult dlrConfirm = MessageManager.Confirm("Bạn có muốn lưu lại thông tin thay đổi?");
                    if (dlrConfirm == DialogResult.Cancel)
                        return false;
                    else if (dlrConfirm == DialogResult.Yes)
                    {
                        DCore.IData objIData = DCore.Data.CreateData();
                        objIData.BeginTransaction();

                        if (mnuItemSaveSchedule.Enabled)
                        {
                            if (!SaveTestSchedule(objIData))
                                return false;
                        }
                        if (!SaveData(objIData))
                            return false;// lưu không thành công thì return

                        objIData.CommitTransaction();
                    }
                }                
            }
            return true;
        }

        private void FilterStudent()
        {
            if (dtbStudent != null)
            {
                strClassIDList = "";
                foreach (DataRow drw in dtbClass.Rows)
                {
                    if (Convert.ToBoolean(drw["IsSelected"]))
                        strClassIDList += ",'" + drw["ClassID"].ToString() + "'";
                }
                if (strClassIDList != "")
                {
                    strClassIDList = strClassIDList.Substring(1);
                    string strRowFilter = "(HaveExamRegister = 1) and (TestScheduleID is null and ClassID in (" + strClassIDList + ") )";
                    string str = UserSession.GetScienceFilter(PERMISSION_STUDENT_EDIT);
                    if (str != "")
                        strRowFilter += " and (" + str + " )"; 
                    gvStudent.RowFilter = strRowFilter;

                }
                else
                    gvStudent.RowFilter = "StudentID='-1'"; // ẩn hết sinh viên

                btnAddAll.Enabled = mnuItemAddAll.Enabled = dtbStudent.DefaultView.Count > 0 && gvTestSchedule.GetFocusedDataRow() != null && bolHavePermissionEdit;
                gvStudent.SetOrder("Order");
            }
        }

        private void FilterData()
        {
            if (dtbData != null)
            {
                DataRow drw = gvTestSchedule.GetFocusedDataRow();
                if(drw!=null)
                {
                    string strRowFilter = "TestScheduleID =" + drw["ScheduleID2"].ToString();
                    string str = UserSession.GetScienceFilter(PERMISSION_VIEW);
                    if (str != "")
                        strRowFilter += " and (" + str + " )"; 
                    gvData.RowFilter = strRowFilter;
                }
                else
                    gvData.RowFilter = "StudentID='-1'"; // ẩn hết sinh viên

                btnCreateExamCode.Enabled = btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled = dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
                btnAddAll.Enabled = mnuItemAddAll.Enabled = dtbStudent.DefaultView.Count > 0 && gvTestSchedule.GetFocusedDataRow() != null && bolHavePermissionEdit;
                // set order.            
                gvData.SetOrder("Order");
                
            }
        }                

        /// <summary>
        /// Save dữ liệu ở tab edit
        /// </summary>
        private bool SaveData(DCore.IData objIData)
        {
            SIM_ExamSchedule item = new SIM_ExamSchedule();
            if (objIData != null)
                item.IDB = objIData;
            else
                item.BeginTransaction();

            foreach (DataRow drw in dtbData.Rows)
            {
                // nếu  đang chọn lịch thi cho sổ điểm thì xem nếu có rồi thì edit
                if (drw["IsEdit"].ToString() == "1") // dòng nào có tác động thì update
                {
                    SIM_ExamSchedule item2 = new SIM_ExamSchedule(); // PHẢI DÙNG CÁI MỚI ĐỂ HÔNG BỊ TRƯỜNG HỢP RÁC TỪ ITEM KHÁC CÒN LẠI khi drw  null thì nó còn data cũ
                    item2.IDB = item.IDB;
                    if (item2.Parse(drw))
                    {
                        if (item2.ExamScheduleID == null && item2.TestScheduleID != null) // thêm mới nếu chưa có mã sổ lịch thi, đồng thời có set mã lịch thi
                        {
                            item2.CreatedUser = UserSession.Username;
                            if (!item2.Add())
                            {
                                ErrorManager.Error("Việc thêm dữ liệu tổ chức thi bị lỗi!: " + ErrorManager.TranslationMessage(item2.ErrorException));
                                
                                return false;
                            }
                        }
                        else if (item2.ExamScheduleID != null)
                        {
                            if (item2.TestScheduleID == null) // xoá vì đã gỡ bỏ hẳn mã lịch thi
                            {
                                if (!item2.Delete())
                                {
                                    ErrorManager.Error("Việc gỡ bỏ tổ chức thi của sinh viên bị lỗi!");
                                    return false;
                                }
                            }
                            else // vẫn còn mã lịch thi thì update
                            {
                                item2.UpdatedUser = UserSession.Username;
                                if (!item2.Update())
                                {
                                    ErrorManager.Error("Việc cập nhật dữ liệu tổ chức thi bị lỗi!: " + ErrorManager.TranslationMessage(item2.ErrorException));
                                    return false;
                                }
                            }
                        }
                    }
                    else
                    {
                        ErrorManager.Error("Việc chuyển dữ liệu từ lưới để lưu bị lỗi!");                        
                        item.RollBackTransaction();// Parse hong co dung tới db nên nó hông có rollback
                        return false;
                    }

                }
            }
            if(objIData==null)
                item.CommitTransaction();

            return true;
        }

        /// <summary>
        /// classSubjectID
        /// </summary>        
        /// <param name="examOrder">lần thi</param>
        /// <returns>Trả về mã tự tăng của file scan vừa tạo để in ra giấy scan</returns>
        private long? SaveForScan()
        {
            SIM_ScanMark objFile = new SIM_ScanMark();
            SIM_ScanMarkDetail objFileDetail = new SIM_ScanMarkDetail();
            objFile.BeginTransaction();
            objFileDetail.IDB = objFile.IDB;

            // tạo file scan            
            objFile.ExamOrder = 1; // thi tốt nghiệp ko có lần thi, vì thi lại vẫn chi chung với thi lần 1
            objFile.CreatedUser = UserSession.Username;
            if (!objFile.Add())
            {
                ErrorManager.Error("Việc tạo file scan bị lỗi!");
                return null;
            }

            // chi tiết file scan 
            objFileDetail.ScanMarkID = objFile.ScanMarkID;
            int intOrderIndex = 0;
            DataTable dtb = dtbData.DefaultView.ToTable(); // theo ds nhìn thấy, vì có thể in luôn ds của sv không đủ đk dự thi
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                DataRow drw = dtb.Rows[i];
                objFileDetail.OrderIndex = intOrderIndex++;
                objFileDetail.SubjectMarkID = Convert.ToInt64(drw["SubjectMarkID"]);
                objFileDetail.ExamOrder = Convert.ToInt32(drw["OrderExam"]); // thi tốt nghiệp có lần thi trong chi tiết
                if (!objFileDetail.Add())
                {
                    ErrorManager.Error("Việc tạo nội dung file scan bị lỗi!");
                    return null;
                }
            }
            objFile.CommitTransaction();
            return objFile.ScanMarkID;
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

        private void CheckAllStudent(bool bolValue)
        {
            for (int i = 0; i < gvStudent.RowCount; i++)
            {
                DataRow drw = gvStudent.GetDataRow(i);
                drw["IsSelected"] = bolValue;
            }
        }

        private void CheckAllData(bool bolValue)
        {
            for (int i = 0; i < gvData.RowCount; i++)
            {
                DataRow drw = gvData.GetDataRow(i);
                drw["IsSelected"] = bolValue;
            }
        }

        /// <summary>
        /// Add sinh vien vào lịch thi
        /// </summary>
        /// <param name="isAddAll"></param>
        private void AddData(bool isAddAll)
        {
            // lấy dòng đang chọn ở lịch thi
            DataRow drwTestSchedule = gvTestSchedule.GetFocusedDataRow();
            if(drwTestSchedule==null)
                return;


            for (int i = gvStudent.RowCount - 1; i >= 0; i--)
            {
                DataRow drw = gvStudent.GetDataRow(i);
                if (isAddAll || Convert.ToBoolean(drw["IsSelected"]) || gvStudent.IsRowSelected(i))
                {
                    
                    // Đánh dấu xoá ở dữ liệu
                    drw["IsSelected"] = false;
                    drw["TestScheduleID"] = "1";// khác null là bị dùng rồi, nó sẽ ẩn đi

                    
                    // Tìm dữ liệu bên sổ lịch thi: Của sinh viên đó.
                    DataRow[] rows = dtbData.Select("StudentID=" + drw["StudentID"].ToString()); // sinh viên theo môn niên kìa là duy nhất
                    //đáy dấu thêm mới ở sổ lịch t hi
                    rows[0]["IsEdit"] = 1; // đánh dấu có thay đổi
                    rows[0]["TestScheduleID"]= drwTestSchedule["ScheduleID2"]; // gán lịch thi vào sổ thi, dùng mã 2, vì là mã thiệt hoặc mã radom khi thêm mới                   
                }
            }

            if (isAddAll)
            {
                btnAddStudent.Enabled = mnuItemAdd.Enabled =  btnAddAll.Enabled = mnuItemAddAll.Enabled =  false;                
            }
            else
            {
                btnAddStudent.Enabled = mnuItemAdd.Enabled =  false;
                btnAddAll.Enabled = mnuItemAddAll.Enabled =  dtbStudent.DefaultView.Count > 0 && bolHavePermissionEdit;
            }
            btnCreateExamCode.Enabled = btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;
            
            gvStudent.SetOrder("Order");
            gvData.SetOrder("Order");
        }

        /// <summary>
        /// Add sinh vien vào lớp
        /// </summary>
        /// <param name="isAddAll"></param>
        private void DelData(bool isDelAll)
        {
            // lấy dòng đang chọn ở lịch thi
            DataRow drwTestSchedule = gvTestSchedule.GetFocusedDataRow();
            if (drwTestSchedule == null)
                return;

            for (int i = gvData.RowCount - 1; i >= 0; i--)
            {
                DataRow drw = gvData.GetDataRow(i);
                if (isDelAll || Convert.ToBoolean(drw["IsSelected"]) || gvData.IsRowSelected(i))
                {
                    if (UserSession.HasPermission(PERMISSION_STUDENT_EDIT, drw["ScienceID"].ToString()))
                    {
                        // Đánh dấu xoá ở sổ lịch thi
                        drw["IsSelected"] = false;
                        drw["TestScheduleID"] = DBNull.Value; // null nghĩa là hông có set nó sẽ ẩn đi
                        drw["IsEdit"] = 1;


                        // Tìm bên sinh viên để xoá
                        DataRow[] rows = dtbStudent.Select("StudentID=" + drw["StudentID"].ToString());
                        rows[0]["TestScheduleID"] = DBNull.Value; // null nghĩa là chưa dùng nó sẽ hiển thị lên  
                    }
                    else
                        MessageManager.Warning("Bạn không có quyền gỡ bỏ sinh viên '" + drw["StudentCode"].ToString() + "' của khoa '" + drw["ScienceID"].ToString() + "'!");
                }
            }

            if (isDelAll)
                btnCreateExamCode.Enabled = btnDeleteStudent.Enabled = mnuItemDelete.Enabled =  btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  false;
            else
            {
                btnDeleteStudent.Enabled = mnuItemDelete.Enabled =  false;
                btnCreateExamCode.Enabled = btnDeleteAll.Enabled = mnuItemDeleteAll.Enabled =  dtbData.DefaultView.Count > 0 && bolHavePermissionEdit;
            }
            btnAddAll.Enabled = mnuItemAddAll.Enabled =  dtbStudent.DefaultView.Count > 0 && bolHavePermissionEdit;
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;

            gvStudent.SetOrder("Order");
            gvData.SetOrder("Order");
        }

        private void CreateExamCode()
        {
            if (chkIsUseStudentCode.Checked)
            {
                for (int i = 0; i < gvData.RowCount; i++)
                {
                    DataRow drw = gvData.GetDataRow(i);
                    drw["ExamCode"] = drw["StudentCode"];
                    drw["OrderIndex"] = drw["Order"];
                    drw["IsEdit"] = 1;
                }
            }
            else
            {
                if(txtStartExamCode.EditValueInt32==null)
                {
                    MessageManager.Warning("Phải nhập số bắt đầu đúng định dạng. Ví dụ 005");
                    txtStartExamCode.Focus();
                    return;
                }

                int intLen = txtStartExamCode.Text.Length;
                int intStartExamCode = txtStartExamCode.EditValueInt32.Value;
                for (int i = 0; i < gvData.RowCount; i++)
                {
                    DataRow drw = gvData.GetDataRow(i);
                    string str="000000000000000"+(intStartExamCode + i).ToString();
                    drw["ExamCode"] = txtPrefixExamCode.TextTrim + str.Substring(str.Length - intLen);                    
                    drw["OrderIndex"] = drw["Order"];
                    drw["IsEdit"] = 1;
                }
            }
            btnSave.Enabled = mnuItemSave.Enabled = bolHavePermissionEdit;
            gvData.BestFitColumns();
        }

        /// <summary>
        /// Xóa từng dòng được chọn, bị lỗi chỗ nào thì ngưng chỗ ấy lại
        /// </summary>
        /// <returns></returns>
        private bool DeleteDataList()
        {
            SIM_TestSchedule obj = new SIM_TestSchedule();
            obj.BeginTransaction();

            int[] arrRowIndex = gvList.GetSelectedRows();
            for (int i = arrRowIndex.Length - 1; i >= 0; i--)
            {
                DataRow drw = gvList.GetDataRow(arrRowIndex[i]);

                if (UserSession.HasPermissionForSubjectGroup(PERMISSION_MANAGER, drw["SubjectGroupID"].ToString()))
                {
                    obj.YearID = Convert.ToInt32(drw["YearID"]);
                    obj.Semester = Convert.ToInt32(drw["Semester"]);
                    obj.TestOrder = Convert.ToInt32(drw["TestOrder"]);
                    obj.SubjectID = drw["SubjectID"].ToString();
                    if (!obj.DeleteForExamSchedule())
                    {
                        ErrorManager.Error("Việc xoá lịch thi bị lỗi!");
                        return false;
                    }
                }
                else
                    MessageManager.Warning("Bạn không có quyền xóa trên bộ môn '" + drw["SubjectGroupName"].ToString() + "'!");
            }

            gvList.DeleteSelectedRows();
            obj.CommitTransaction();
            return true;
        }

        #endregion

        #region Support Functions For TestSchedule

        private void SelectTeacher(DataRow drw, string fieldName)
        {
            
            frmSelectTeacher frmSelect = frmSelectTeacher.Instance;
            frmSelect.ItemSelected = null;
            frmSelect.ISMultiSelect = false; // chọn 1           
            frmSelect.SubjectID = null;

            frmSelect.ShowDialog();
            BO.SIM_Teacher item = frmSelect.ItemSelected;

            if (item != null) // nếu có chọn      
            {
                drw[fieldName] = item.TeacherID;
                drw["IsEdit"] = 1;
                mnuItemSave.Enabled = btnSave.Enabled = true;
            }
        }

        private void SelectRoom(DataRow drw, string fieldName)
        {
            frmSelectRoom frmSelect = frmSelectRoom.Instance;
            frmSelect.ItemSelected = null;
            frmSelect.SubjectID = null;
            frmSelect.IsPractice = null;
            frmSelect.IsPracticeRoom = null;
            frmSelect.SizeForLearning = null;
            frmSelect.SizeForTesting = null;

            #region Hide - khong can xac dinh loai phong, cu hien thi het de tim
            /*
            // xem thử môn này có cần loại phòng gì
            SIM_Subject itemSubject = new SIM_SubjectDAO().Get(drw[SIM_Class_Subject.C_SUBJECTID].ToString());
            int intType = 0;
            if (drw["LessionType"].ToString() != "") // thực hành            
                intType = itemSubject.PracticeRoomType.Value * 10; // để phân biệt với lý thuyết
            else
                intType = itemSubject.TheoryRoomType.Value;

            // Chọn phòng chú ý theo size của lớp
            switch (intType)
            {
                case 0: //khoong can phong
                    MessageManager.Info("Môn học này không dùng phòng!");
                    return;
                case 1: // bất kỳ phòng nào khỏi truyển tham số gì hết
                    break;

                case 10: // bất kỳ phòng nào                                        
                    break;

                case 2: // bất kỳ phòng lý thuyết nào
                    frmSelect.IsPracticeRoom = false; // phải là phòng lý thuyết
                    break;
                case 20:// bất kỳ phòng thực hành  nào
                    frmSelect.IsPracticeRoom = true; // phải là phòng thực hành
                    break;
                case 3: // phải là phòng lý thuyết được chọn
                    frmSelect.SubjectID = itemSubject.SubjectID;
                    frmSelect.IsPractice = false; // phòng cho môn lý thuyết
                    break;
                case 30: // phải là phòng thực hành được chọn
                    frmSelect.SubjectID = itemSubject.SubjectID;
                    frmSelect.IsPractice = true; // phòng cho môn thực hành
                    break;
            }
             
          

            if (fieldName == SIM_Class_Subject.C_TEACHINGATROOM) // chọn phòng học mới phải theo điều kiện            
                frmSelect.SizeForLearning = Convert.ToInt32(drw[SIM_Class.C_CLASSSIZE]); // phải >= kích thước lớp            
            else
                frmSelect.SizeForTesting = Convert.ToInt32(drw[SIM_Class.C_CLASSSIZE]); // phải >= kích thước lớp
            */
            #endregion

            frmSelect.ISMultiSelect = false; // chọn 1                                    
            frmSelect.ShowDialog();
            BO.SIM_Room item = frmSelect.ItemSelected;

            if (item != null) // nếu có chọn      
            {
                drw[fieldName] = item.RoomID;
                drw["IsEdit"] = 1;
                mnuItemSave.Enabled = btnSave.Enabled = true;
            }
        }

        private string CheckValidItem(SIM_TestSchedule item)
        {
            return ""; // tạm thời không cần kiểm tra trùng lịch

            #region Check Free time
            
            SIM_TestSession itemTestSession = new SIM_TestSession();
            
            itemTestSession.TestSessionID = item.TestSessionID;
            if (!itemTestSession.Get())
            {
                return "Việc lấy thông tin ca thi bị lỗi!";
            }
            string strListTestScheduleID = null;
            if (item.ScheduleID != null) // sửa hoặc xoá
                strListTestScheduleID = "," + item.ScheduleID.ToString() + ",";

            string strRs = "";
            // kiểm tra giảng viên
            if (item.TeacherID1 != null && item.TeacherID1 != "")
            {
                strRs = new DataAccess.SIM_TeacherDAO().CheckFreeTime(item.TeacherID1, new DataAccess.SIM_TeacherDAO().Get(item.TeacherID1).TeacherShortName, item.Date.Value,
                       itemTestSession.StartLession.Value, itemTestSession.FinishLession.Value, null, strListTestScheduleID);
                if (strRs != "")
                    return strRs;
            }

            // giảng viên 2
            if (item.TeacherID2 != null && item.TeacherID2 != "")
            {
                strRs = new DataAccess.SIM_TeacherDAO().CheckFreeTime(item.TeacherID2, new DataAccess.SIM_TeacherDAO().Get(item.TeacherID2).TeacherShortName, item.Date.Value,
                       itemTestSession.StartLession.Value, itemTestSession.FinishLession.Value, null, strListTestScheduleID);
                if (strRs != "")
                    return strRs;
            }

            // kiểm tra phòng
            if (item.RoomID != null && item.RoomID != "")
            {
                strRs = new DataAccess.SIM_RoomDAO().CheckFreeTime(item.RoomID, item.RoomID, item.Date.Value,
                                    itemTestSession.StartLession.Value, itemTestSession.FinishLession.Value, null, strListTestScheduleID);
                if (strRs != "")
                    return strRs;
            }

            // kiểm tra phòng 2
            if (item.RoomID2 != null && item.RoomID2 != "")
            {
                strRs = new DataAccess.SIM_RoomDAO().CheckFreeTime(item.RoomID2, item.RoomID2, item.Date.Value,
                                    itemTestSession.StartLession.Value, itemTestSession.FinishLession.Value, null, strListTestScheduleID);
                if (strRs != "")
                    return strRs;
            }

            // các môn của cùng 1 lớp không được thi cùng lúc đâu
            // có gì kiểm tra thêm nha...........................................


            // kiểm tra lịch thi, xem có trùng ngày nghỉ trường
            strRs = new SIM_TestSchedule().CheckFreeTime(item.Date.Value, itemTestSession.StartLession.Value, itemTestSession.FinishLession.Value, strListTestScheduleID);
            if (strRs != "")
                return strRs;

            return "";

            #endregion
        }

        private bool SaveTestSchedule(IData objIData)
        {
            DataRow[] rows = dtbTestSchedule.Select("IsEdit = 1");
            if (rows.Length <= 0)
                return true;

            SIM_TestSchedule item = new SIM_TestSchedule();
            if (objIData != null)
                item.IDB = objIData;
            else
                item.BeginTransaction();


            foreach (DataRow drw in rows)
            {
                SIM_TestSchedule item2 = new SIM_TestSchedule();
                item2.IDB = item.IDB;

                if (item2.Parse(drw))
                {
                    if (item2.RoomID !=null) // cai nay null nghia la xoa, khi nhan nut xoa thi bo cai nay ve null
                    {
                        if (item2.Week != null && item2.Week > 0 && item2.Date != null && item2.RoomID != null) // nếu có lịch thi được set && item2.TeacherID1 != null && item2.TeacherID2 != ""
                        {
                            string strRs = ""; //CheckValidItem(item2);
                            if (strRs != "")
                            {
                                ErrorManager.Error(strRs);
                                return false;
                            }
                            else
                            {
                                item2.Week = item2.Week - 1;
                                if (item2.ScheduleID != null) // update
                                {
                                    if (!item2.Update())
                                    {
                                        ErrorManager.Error("Việc cập nhật lịch thi bị lỗi!");
                                        return false;
                                    }
                                }
                                else // thêm mới
                                {
                                    item2.CreatedUser = UserSession.Username;
                                    if (!item2.Add())
                                    {
                                        ErrorManager.Error("Việc thêm lịch thi bị lỗi!");
                                        return false;
                                    }


                                    // quét sổ điểm thi đã add vào lịch thi tạm (lịch thi new) để update lại 
                                    DataRow[] rows2 = dtbData.Select("TestScheduleID=" + drw["ScheduleID2"].ToString());
                                    foreach (DataRow drw2 in rows2)
                                        drw2["TestScheduleID"] = item2.ScheduleID;

                                    // gán mã nhận, ngày tạo dc lên lưới lại
                                    //drw["ScheduleID"] = item2.ScheduleID;
                                    drw["CreatedDate"] = DateTime.Now;
                                    drw["ScheduleID2"] = item2.ScheduleID;
                                }
                            }
                        }
                        else // lịch hông hợp lệ cũng dừng luôn
                        {
                            ErrorManager.Error("Bạn chưa chọn đầy đủ thông tin cho lịch thi!");
                            return false;
                        }
                    }
                    else // nếu không set lịch thi
                    {
                        if (item2.ScheduleID != null) // mới gỡ bỏ thì là xoá
                        {
                            if (!item2.Delete())
                            {
                                ErrorManager.Error("Việc xoá lịch thi bị lỗi!");
                                return false;
                            }
                            // đánh dấu xoá sổ lịch thi                            
                            DataRow[] rows2 = dtbData.Select("TestScheduleID=" + item2.ScheduleID);
                            foreach (DataRow drw2 in rows2)
                            {
                                drw2["IsEdit"] = 1;
                                drw2["TestScheduleID"] = DBNull.Value;
                            }
                            // đánh dấu lấy lại trong sinh vien
                            rows2 = dtbStudent.Select("TestScheduleID=" + item2.ScheduleID);
                            foreach (DataRow drw2 in rows2)
                                drw2["TestScheduleID"] = DBNull.Value;
                        }
                    }
                                  
                }
                else
                {
                    ErrorManager.Error("Việc lấy thông tin lịch thi để cập nhật bị lỗi!");
                    return false;
                }
            }
            if (objIData == null)
                item.CommitTransaction();
            return true;
        }

        #endregion

        #region Form Actions For Edit TestSchedule

        private void mnuItemSelectTeacher_Click(object sender, EventArgs e)
        {
            DataRow drw = gvTestSchedule.GetFocusedDataRow();
            if (drw != null)
            {
                switch (gvTestSchedule.FocusedColumn.FieldName)
                {
                    case SIM_TestSchedule.C_TeacherID1:
                    case SIM_TestSchedule.C_TeacherID2:
                        SelectTeacher(drw, gvTestSchedule.FocusedColumn.FieldName);
                        break;
                    default:
                        SelectTeacher(drw, SIM_TestSchedule.C_TeacherID1);
                        break;
                }
            }
        }

        private void mnuItemSelectRoom_Click(object sender, EventArgs e)
        {
            DataRow drw = gvTestSchedule.GetFocusedDataRow();
            if (drw != null)
            {
                switch (gvTestSchedule.FocusedColumn.FieldName)
                {
                    case SIM_TestSchedule.C_RoomID:
                    case SIM_TestSchedule.C_RoomID2:
                        SelectRoom(drw, gvTestSchedule.FocusedColumn.FieldName);
                        break;
                    default:
                        SelectRoom(drw, SIM_TestSchedule.C_RoomID);
                        break;
                }
            }
        }

        private void mnuItemDeleteTeacher_Click(object sender, EventArgs e)
        {
            DataRow drw = gvTestSchedule.GetFocusedDataRow();
            if (drw != null)
            {
                switch (gvTestSchedule.FocusedColumn.FieldName)
                {
                    case SIM_TestSchedule.C_TeacherID1:
                    case SIM_TestSchedule.C_TeacherID2:
                        drw[gvTestSchedule.FocusedColumn.FieldName] = "";
                        break;
                    default:
                        drw[SIM_TestSchedule.C_TeacherID1] = "";
                        break;

                }
                drw["IsEdit"] = true;
                mnuItemSave.Enabled = btnSave.Enabled = true;
            }
        }

        private void mnuItemDeleteRoom_Click(object sender, EventArgs e)
        {
            DataRow drw = gvTestSchedule.GetFocusedDataRow();
            if (drw != null)
            {
                switch (gvTestSchedule.FocusedColumn.FieldName)
                {
                    case SIM_TestSchedule.C_RoomID:
                    case SIM_TestSchedule.C_RoomID2:
                        drw[gvTestSchedule.FocusedColumn.FieldName] = "";
                        break;
                    default:
                        drw[SIM_TestSchedule.C_RoomID] = "";
                        break;

                }
                drw["IsEdit"] = true;
                mnuItemSave.Enabled = btnSave.Enabled = true;
            }
        }

        private void mnuItemSaveSchedule_Click(object sender, EventArgs e)
        {
            if (SaveTestSchedule(null))
            {
                mnuItemSaveSchedule.Enabled = false;

                //ok thì mới load lại lịch thi
                foreach (DataRow drw in dtbTestSchedule.Rows)
                {
                    if (drw.RowState != DataRowState.Deleted)
                    {
                        drw["ScheduleID"] = drw["ScheduleID2"];
                        drw["IsEdit"] = 0;
                    }
                }
            }
        }

        private void gvTestSchedule_DoubleClick(object sender, EventArgs e)
        {
            if (UserSession.HasPermission(PERMISSION_MANAGER))
            {
                DataRow drw = gvTestSchedule.GetFocusedDataRow();
                if (drw != null)
                {
                    switch (gvTestSchedule.FocusedColumn.FieldName)
                    {
                        case SIM_TestSchedule.C_TeacherID1:
                        case SIM_TestSchedule.C_TeacherID2:
                            SelectTeacher(drw, gvData.FocusedColumn.FieldName);
                            break;
                        case SIM_TestSchedule.C_RoomID:
                        case SIM_TestSchedule.C_RoomID2:
                            SelectRoom(drw, gvData.FocusedColumn.FieldName);
                            break;
                    }
                }
            }
        }

        private void mnuItemAddRoom_Click(object sender, EventArgs e)
        {
            frmSelectRoom frmSelect = frmSelectRoom.Instance;
            // reset form
            frmSelect.SubjectID = null;
            frmSelect.IsPractice = null;
            frmSelect.IsPracticeRoom = null;
            frmSelect.ISMultiSelect = true; // chọn nhiều
            frmSelect.ShowDialog();
            List<BO.SIM_Room> lstRoom = frmSelect.ListSelected; // nếu chọn 1 thì phải lấy là ItemSelected
            if (lstRoom != null) // nếu có chọn
            {
                foreach (BO.SIM_Room item in lstRoom)
                {
                    if (gvTestSchedule.SearchRow("RoomID", item.RoomID) < 0) // tìm không thấy thì add
                    {
                        DataRow drw = dtbTestSchedule.NewRow();
                        drw["RoomID"] = item.RoomID;
                        drw["ScheduleID2"] = DateTime.Now.ToBinary(); // tạo mã ảo để add
                        drw["YearID"] = uYearSemester.YearIDEditValueInt32;
                        drw["Semester"] = uYearSemester.SemesterEditValueInt32;
                        drw["SubjectID"] = lookupSubjectID.EditValueString;
                        drw["ExamDateID"] = lookupExamDate.EditValueInt32;
                        drw["TestOrder"] = 1;// không cần lần thi cho tốt nghiệp, vì thi lại thi chung với thi lần 1 luôn

                        drw["IsEdit"] = 1;
                        dtbTestSchedule.Rows.Add(drw);
                    }
                }
            }
        }

        private void mnuItemAddTestSchedule_Click(object sender, EventArgs e)
        {
            //ScheduleManager.TestScheduling.frmTestScheduleOfClassEdit frm = ScheduleManager.TestScheduling.frmTestScheduleOfClassEdit.Instance;
            //frm.ShowEditForm();
        }

        private void gvTestSchedule_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DataRow drw = gvTestSchedule.GetFocusedDataRow();

            if (drw != null)
            {
                SIM_TestSchedule item = new SIM_TestSchedule();
                if (item.Parse(drw))
                {
                    if (item.Date == null || item.TestSessionID == null || item.RoomID == null) //|| item.TeacherID1 == null || item.TeacherID2 == null
                    {
                        ErrorManager.Error("Bạn phải chọn đầy đủ dữ liệu!");
                        e.Valid = false;
                    }
                    else
                    {

                        // tính lại tuần và thứ từ date
                        if (drw["Date"].ToString() != "")
                        {
                            DateTime dtmDate = Convert.ToDateTime(drw["Date"]);
                            drw["Day"] = Convert.ToInt64(dtmDate.DayOfWeek).ToString();
                            TimeSpan t = dtmDate - dtmFromDateOfYear;
                            drw["Week"] = t.Days / 7 + 1;
                        }
                        drw["IsEdit"] = true;
                        mnuItemSaveSchedule.Enabled = btnSave.Enabled = mnuItemSave.Enabled = true;
                    }
                }
                else
                {
                    ErrorManager.Error("Dòng dữ liệu bị lỗi!");
                    e.Valid = false;
                }

            }
        }

        private void gvTestSchedule_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvTestSchedule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            FilterData();
        }

        #endregion

        #region Form Actions

        private void frmMakeExamSchedule_Load(object sender, EventArgs e)
        {

            CheckPermission();
            SetToolTip();
            new Thread(LoadReferenceData).Start();
            tcData.SelectedTabPage = tpList;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(IsValidData())
                LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn có thực sự muốn lưu những thay đổi dữ liệu này?") == DialogResult.Yes)
            {
                DCore.IData objIData = DCore.Data.CreateData();
                objIData.BeginTransaction();

                if (SaveTestSchedule(objIData))
                {
                    if (SaveData(objIData))
                    {
                        objIData.CommitTransaction();                        
                        ReLoadEditData();

                        //ok thì mới load lại lịch thi
                        foreach (DataRow drw in dtbTestSchedule.Rows)
                        {
                            if (drw.RowState != DataRowState.Deleted)
                            {
                                drw["ScheduleID"] = drw["ScheduleID2"];
                                drw["IsEdit"] = 0;
                            }
                        }
                        LoadData();
                    }
                }
            }
        }
       
        private void gvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gvClass.FocusedColumn.FieldName != "IsSelected")
            {
                btnSave.Enabled = mnuItemSave.Enabled = true && bolHavePermissionEdit;
            }
            else
            {
                btnDeleteStudent.Enabled = mnuItemDelete.Enabled = gvData.SelectedRowsCount > 0 && bolHavePermissionEdit;
            }
        }

        private void gvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(e.RowHandle);
            if (drw != null)
            {
                if (drw["ExamScheduleID"].ToString() == "") // là edit
                    e.Appearance.BackColor = Color.LightSkyBlue;
            }
        }

        private void gvData_ShowingEditor(object sender, CancelEventArgs e)
        {
            DataRow drw = gvData.GetDataRow(gvData.FocusedRowHandle);
            if (drw != null)
            {
                e.Cancel = !(UserSession.HasPermission(PERMISSION_STUDENT_EDIT, drw["ScienceID"].ToString()) && bolHavePermissionEdit);
            }
            //{
            //    if (drw["FinalSummary"].ToString()!="" || drw["SubjectID"].ToString() =="") // nếu hông cho phép edit vì có điểm rồi hoặc hông phải đăng ký mà của chính lớp
            //        e.Cancel = true;
            //}                                
        }

        private void mnuItemCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllData(true);
        }

        private void mnuItemUnCheckAll_Click(object sender, EventArgs e)
        {
            CheckAllData(false);
        }
        
        /// <summary>
        /// Chọn lại môn thì phải lọc lại sinh viên đang ký, chọn lại khoa bộ môn, lọc lại lớp học có học môn đó
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="arg"></param>
        private void lookupSubjectID_EditValueChanged(object sender, EventArgs arg)
        {
            if (lookupSubjectID.EditValue != null)
            {
                SIM_Subject itemSubject = new SIM_Subject();
                itemSubject.SubjectID = lookupSubjectID.EditValueString;
                if (itemSubject.Get())
                {
                    intSpecialType = itemSubject.SpecialType;
                }
            }
            LoadEditData();
        }
       
        private void gvStudent_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            btnAddStudent.Enabled = mnuItemAdd.Enabled =  gvStudent.SelectedRowsCount > 0 && bolHavePermissionEdit;
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            AddData(true);
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddData(false);
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DelData(true);
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            DelData(false);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(ConfirmCommitEdit())
                this.Close();
        }

        private void mnuItemExportToExcel_Click(object sender, EventArgs e)
        {
            gvData.QuickExportToExcel();
        }

        private void gvStudent_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnAddStudent.Enabled = mnuItemAdd.Enabled = gvStudent.SelectedRowsCount > 0 && gvTestSchedule.GetFocusedDataRow() != null && bolHavePermissionEdit;
        }

        private void gvData_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            btnDeleteStudent.Enabled = mnuItemDelete.Enabled =  gvData.SelectedRowsCount > 0 && bolHavePermissionEdit;
        }

        private void mnuItemCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllStudent(true);
        }

        private void mnuItemUnCheckAll1_Click(object sender, EventArgs e)
        {
            CheckAllStudent(false);
        }

        private void gvStudent_EndSorting(object sender, EventArgs e)
        {
            gvStudent.SetOrder("Order");
        }

        private void gvData_EndSorting(object sender, EventArgs e)
        {
            gvData.SetOrder("Order");
        }      
       
       
        private void gvClass_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            FilterStudent();
        }        
        
        private void chkIsUseStudentCode_CheckedChanged(object sender, EventArgs e)
        {
            txtPrefixExamCode.Enabled = txtStartExamCode.Enabled = !chkIsUseStudentCode.Checked;
        }

        private void btnCreateExamCode_Click(object sender, EventArgs e)
        {
            CreateExamCode();
        }

        private void cbxTestOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEditData();
        }

        #endregion

        #region Form Actions List Data

        private void tcData_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {
            if ((!bolIsEditing && e.Page == tpDetail) || (bolIsEditing && e.Page == tpList))
                e.Cancel = true;
        }

        private void frmMakeExamSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    this.ShowToolTip();
                    break;

                case Keys.F2:
                    if (!bolIsEditing)
                        btnEdit_Click(sender, null);
                    break;
                case Keys.F3:
                    if (!bolIsEditing)
                        btnSearch_Click(sender, null);
                    break;
                case Keys.F4:
                    if (btnDeleteStudent.Enabled && !bolIsEditing)
                        btnDelete_Click(sender, null);
                    break;
                case Keys.F5:
                    if (!bolIsEditing)
                        mnuItemRefreshList_Click(sender, null);
                    else
                    {
                        RefreshReferenceData(); // chi load lai nhung combox nay no de edit
                        ReLoadEditData();
                    }
                    break;
                case Keys.F6:
                    if (btnSave.Enabled && bolIsEditing)
                        btnSave_Click(sender, null);
                    break;
                case Keys.F7:
                    //btnPrint_Click(sender, null);
                    break;
                case Keys.F8:
                    if (btnDelete.Enabled && !bolIsEditing)
                        btnDelete_Click(sender, null);
                    break;
                case Keys.Escape:
                    if (bolIsEditing)
                        btnCancel_Click(sender, null);
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ConfirmCommitEdit())
            {
                bolIsEditing = false;
                tcData.SelectedTabPage = tpList;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            lookupExamDate.EditValue = null;
            LoadEditData();
            bolIsEditing = true;
            tcData.SelectedTabPage = tpDetail;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageManager.Confirm("Bạn thực sự muốn xóa những dữ liệu này?") == DialogResult.Yes)
            {
                DeleteDataList();
                mnuItemEditList.Enabled = btnEdit.Enabled = gvList.GetFocusedDataRow() != null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataRow drw = gvList.GetFocusedDataRow();
            if (drw != null)
            {                                
                uYearSemester.YearIDEditValue = drw["YearID"];
                uYearSemester.SemesterEditValue = drw["Semester"];                
                lookupExamDate.EditValue = drw["ExamDateID"];
                lookupSubjectID.EditValue = drw["SubjectID"];

                bolIsEditing = true;
                tcData.SelectedTabPage = tpDetail;                
            }
        }

        private void mnuItemRefreshList_Click(object sender, EventArgs e)
        {
            RefreshReferenceData();
            btnSearch_Click(sender, e);
        }

        private void mnuItemExportExcelList_Click(object sender, EventArgs e)
        {
            gvList.QuickExportToExcel();
        }

        #endregion

        private void mnuItemRefresh_Click(object sender, EventArgs e)
        {
            if (ConfirmCommitEdit())
                LoadEditData();
        }

        private void mnuItemRefresh1_Click(object sender, EventArgs e)
        {
            if (ConfirmCommitEdit())
                LoadEditData();
        }

        private void mnuItemRefreshTestSchedule_Click(object sender, EventArgs e)
        {
            if (ConfirmCommitEdit())
                LoadEditData();
        }

        private void mnuItemDeleteTestSchedule_Click(object sender, EventArgs e)
        {                        
            int[] arrRowIndex = gvTestSchedule.GetSelectedRows();
            if (arrRowIndex.Length > 0)
            {
                for (int i = arrRowIndex.Length - 1; i >= 0; i--)
                {
                    DataRow drw = gvTestSchedule.GetDataRow(arrRowIndex[i]);
                    drw["RoomID"] = DBNull.Value; // chỉ cần 1 ô null thì nó sẽ xoá đi khi save
                    drw["IsEdit"] = 1;
                }
                
                FilterData();
                btnSave.Enabled = mnuItemSave.Enabled = mnuItemSaveSchedule.Enabled = true;
            }
        }

        private void uSubjectGroupSearch_EditValueChanged(object sender, EventArgs arg)
        {
            if (uYearSemesterSearch.YearIDEditValue != null && uYearSemesterSearch.SemesterEditValue != null)
                LoadData();
        }       

        private void gvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            switch (gvData.FocusedColumn.FieldName)
            {
                case "ExamCode":
                    if (e.Valid == true)
                    {
                        if (gvData.SearchRow("ExamCode", e.Value, gvData.FocusedRowHandle) >= 0)
                        {
                            e.ErrorText = "Đã tồn tại số báo danh này!";
                            e.Valid = false;
                        }
                    }
                    break;
                case "OrderIndex":
                    if (e.Valid == true)
                    {
                        if (gvData.SearchRow("OrderIndex", e.Value, gvData.FocusedRowHandle) >= 0)
                        {
                            e.ErrorText = "Đã tồn tại số thứ tự này!";
                            e.Valid = false;
                        }
                    }
                    break;
            }
        }

        private void mnuItemExportTemplateExcel_Click(object sender, EventArgs e)
        {
            DataRow drw = gvTestSchedule.GetFocusedDataRow();
            if (drw != null)
            {

                Hashtable hstReplaceValues = new Hashtable();                
                hstReplaceValues.Add("{Phòng}", drw["RoomID"].ToString());
                hstReplaceValues.Add("{Môn}", lookupExamDate.Text);
                hstReplaceValues.Add("{Niên}", uYearSemester.YearEditValueText);
                hstReplaceValues.Add("{Kì}", uYearSemester.SemesterEditValue.ToString());                

                if (!gvData.ExportTemplateExcel("Mã SV", hstReplaceValues, Application.StartupPath + "/Report/StudentManager/Learning/DanhSachDuThiTheoPhong.xls"))
                    MessageManager.Warning("File mẫu chưa đúng định dạng hoặc chưa có cột ''Mã SV''!");
            }
            else
                MessageManager.Warning("Không có lịch thi để xuất!");

        }
        
        /// <summary>
        /// Danh sách dự thi tốt nghiệp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuItemPrint3_Click(object sender, EventArgs e)
        {
            string strReport = "Report/StudentManager/Learning/Leaning_DanhSachDuThi_TheoPhong_Mau3.repx";
            DataTable dtb = dtbData.DefaultView.ToTable();
            SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtb, strReport, false);
            frm.Show();
        }

        private void mnuItemPrintForScan_Click(object sender, EventArgs e)
        {
            string strRoomID = "";
            DataRow drw = gvTestSchedule.GetFocusedDataRow();
            if (drw != null)
            {
                strRoomID = drw["RoomID"].ToString();
            }

            // print danh sách sinh viên dự thi có thể bao gồm cả sv không đủ điều kiện
            long? lngScanMarkID = SaveForScan();
            if (lngScanMarkID != null)
            {
                DataTable dtbData2 = dtbData.DefaultView.ToTable();
                if (dtbData2.Rows.Count == 0)
                    return;

                int intRegulationID = 14; // Convert.ToInt32(dtbData2.Rows[0]["RegulationID"]);
                string strreport = "";
                switch (intRegulationID)
                {
                    case 14: // cao đẳng, tc nghề
                        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14_Scan.repx";
                        break;
                    case 46: // trung cấp vừa học vừa làm
                    case 40: // trung cấp chuyên nghiệp
                        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC40_Scan.repx";
                        break;
                    default:
                        strreport = "Report/StudentManager/Learning/Leaning_DSThi_QC14_Scan.repx";
                        break;
                }

                SystemManager.Report.frmReportView frm = new SystemManager.Report.frmReportView(dtbData2, strreport, false);
                frm.SetParameter("par_Recognize", lngScanMarkID); // mã môn học lớp
                //frm.SetParameter("par_OrderTest", Convert.ToInt32(cbxTestOrder.Text)); // lần thi
                //frm.SetParameter("par_Class", dtbData2.Rows[0]["ClassName"].ToString()); // tên lớp  
                frm.SetParameter("par_Room", strRoomID); // tên phòng
                frm.SetParameter("par_Semester", uYearSemester.SemesterEditValue);
                frm.SetParameter("par_Year", uYearSemester.YearEditValueText);
                frm.SetParameter("par_PrintDate", DateTime.Now.ToString("dd / MM / yyyy"));
                frm.Show();
            }
        }            
    }
}

