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
    public partial class UStudentCollectionPeriod : DevExpress.XtraEditors.XtraUserControl
    {
        public UStudentCollectionPeriod()
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

        public DeclarationManager.Education.UCourseTypeLevel CourseTypeLevelEditor
        {
            get { return uCourseTypeLevel; }
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
            get { return lookupStudentCollectionPeriodID.EditValueString; }
            set { lookupStudentCollectionPeriodID.EditValue = value; }
        }

        public string StudentCollectionPeriodName
        {
            get { return lookupStudentCollectionPeriodID.EditValueString != "" ? lookupStudentCollectionPeriodID.Text : ""; }
        }

        // Loại đợt là thuộc Sơ cấp, Trung Cấp 2 năm, trung cấp 35, Cao đẳng, Liên thông để phân loại mẩu và kiểu xét
        private int intCollectionType = -1;
        /// <summary>
        ///  Loại đợt là thuộc Sơ cấp, Trung Cấp 2 năm, trung cấp 35, Cao đẳng, Liên thông để phân loại mẩu và kiểu xét
        /// </summary>
        public int CollectionType
        {
            get { return intCollectionType; }
            set { intCollectionType = value; }
        }


        private int intLearningLevel = -1;
        /// <summary>
        /// 
        /// </summary>
        public int LearningLevel
        {
            get { return intLearningLevel; }
            set { intLearningLevel = value; }
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
            if (lookupStudentCollectionPeriodID.EditValue != null)
            {
                DataRow[] rows = SimsService.SIM_StudentCollectionPeriodService.Table.Select("StudentCollectionPeriodID = '" + lookupStudentCollectionPeriodID.EditValue.ToString() + "'");
                if (rows != null && rows.Length > 0)
                {
                    uCourseTypeLevel.CourseIDEditValue = rows[0]["CourseID"].ToString();
                    uCourseTypeLevel.TrainingLevelIDEditValue = rows[0]["TrainingLevelID"].ToString();
                    uCourseTypeLevel.TrainingTypeEditValue = rows[0]["TrainingType"].ToString();
                    intCollectionType = Convert.ToInt32(rows[0]["CollectionType"]);
                    intLearningLevel = Convert.ToInt32(rows[0]["LearningLevel"]);
                }
            }
            else
            {
                intCollectionType = -1;
                intLearningLevel = -1;
            }

            // gọi phương thức nếu có định nghĩa lại bên ngoài
            if (EditValueChanged != null)
                EditValueChanged(sender, arg);

            

        }

        #endregion

        #region Delegate Action Medthods

        public delegate void EditValueChangedDelegate(object sender, EventArgs arg);
        public event EditValueChangedDelegate EditValueChanged = null;
        #endregion 

       
    }
}
