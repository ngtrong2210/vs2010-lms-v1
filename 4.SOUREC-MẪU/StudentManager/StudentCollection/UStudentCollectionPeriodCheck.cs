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

namespace StudentManager.StudentCollection
{
    public partial class UStudentCollectionPeriodCheck : DevExpress.XtraEditors.XtraUserControl
    {
        public UStudentCollectionPeriodCheck()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Vị trí left của Text edit value so với control này
        /// </summary>
        public int EditorLeft
        {
            get { return lookupStudentCollectionPeriodID.EditorLeft; }
            set
            {
                lookupStudentCollectionPeriodID.EditorLeft = uCourseTypeLevel.EditorLeft = value;                
            }
        }

        /// <summary>
        /// Thuộc tính readonlye của lookup value.
        /// Nó tự đổi màu nền theo thuộc tính.
        /// </summary>
        public bool ReadOnly
        {
            get { return lookupStudentCollectionPeriodID.ReadOnly; }
            set { lookupStudentCollectionPeriodID.ReadOnly = uCourseTypeLevel.ReadOnly = value; }
        }
        

        public string CourseIDEditValue
        {
            get { return uCourseTypeLevel.CourseIDEditValue; }
            set
            {
                uCourseTypeLevel.CourseIDEditValue = value;
            }
        }

        public string TrainingLevelIDEditValue
        {
            get { return uCourseTypeLevel.TrainingLevelIDEditValue; }
            set
            {
                uCourseTypeLevel.TrainingLevelIDEditValue = value;
            }
        }

        public string TrainingTypeEditValue
        {
            get { return uCourseTypeLevel.TrainingTypeEditValue; }
            set
            {
                uCourseTypeLevel.TrainingTypeEditValue = value;
            }
        }

        public string StudentCollectionPeriodIDEditValue
        {
            get { return lookupStudentCollectionPeriodID.ListID_Seleted; }            
        }

        private int intCollectionType = -1;

        public int CollectionType
        {
            get { return intCollectionType; }
            set { intCollectionType = value; }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Load data, nếu cũ thì khỏi load lại
        /// </summary>
        public void InitData()
        {
            uCourseTypeLevel.InitData();
            SimsService.SIM_StudentCollectionPeriodService.InitLookUpEdit(lookupStudentCollectionPeriodID);
        }

        /// <summary>
        /// Load mới data
        /// </summary>
        public void RefrehData()
        {

            uCourseTypeLevel.RefrehData();
            SimsService.SIM_StudentCollectionPeriodService.HaveNewData = true;
            SimsService.SIM_StudentCollectionPeriodService.InitLookUpEdit(lookupStudentCollectionPeriodID);

        }

        /// <summary>
        /// reset các chọn lựa, trở về select = null
        /// </summary>
        public void Reset()
        {
            uCourseTypeLevel.Reset();
            lookupStudentCollectionPeriodID.EditValue = null;
        }
        /// <summary>
        /// Kiểm tra dữ liệu không được null
        /// </summary>
        public bool IsValidData()
        {
            if (!uCourseTypeLevel.IsValidData())
                return false;
            if (lookupStudentCollectionPeriodID.EditValue == null)
            {
                MessageManager.Warning("Bạn phải chọn đợt tuyển sinh!");
                lookupStudentCollectionPeriodID.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Private Methods

        private void uCourseTypeLevel_EditValueChanged(object sender, EventArgs arg)
        {
            string strCondition = "";
            if (uCourseTypeLevel.TrainingLevelIDEditValue != null)
                strCondition = "and TrainingLevelID = '" + uCourseTypeLevel.TrainingLevelIDEditValue.ToString() + "'";

            if (uCourseTypeLevel.TrainingTypeEditValue != null)
                strCondition += "and TrainingType = '" + uCourseTypeLevel.TrainingTypeEditValue.ToString() + "'";

            if (uCourseTypeLevel.CourseIDEditValue != null)
                strCondition += "and CourseID = '" + uCourseTypeLevel.CourseIDEditValue.ToString() + "'";

            if (strCondition != "")
                strCondition = strCondition.Substring(4);

            lookupStudentCollectionPeriodID.RowFilter = strCondition;
            
        }

        private void lookupStudentCollectionPeriodID_EditValueChanged(object sender, EventArgs arg)
        {
           
        }

        #endregion

        #region Delegate Action Medthods

        public delegate void EditValueChangedDelegate(object sender, EventArgs arg);
        public event EditValueChangedDelegate EditValueChanged = null;
        #endregion 
       
    }
}
