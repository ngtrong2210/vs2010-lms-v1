using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Global;
using SimsObject;

namespace SimsService
{
    public partial class SIM_Teacher_SubjectService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    // Neu cache thì cache ở đây
                    SIM_Teacher_Subject objTeacher_Subject = new SIM_Teacher_Subject();
                    dtbTable = objTeacher_Subject.Search(); // dùng search để có nhiều trường liên quan hơn
                    DataRow drw = dtbTable.NewRow();

                    dtbTable.Rows.InsertAt(drw, 0); // thêm dòng trống
                    bolHaveNewData = false;
                }
                return dtbTable;
            }
            set { dtbTable = value; }
        }


        public static bool HaveNewData
        {
            get { return bolHaveNewData; }
            set { bolHaveNewData = value; }
        }

        #region Init LookupEdit

        /// <summary>
        /// Chọn giáo viên, chứ không phải chọn môn học giáo viên
        /// Sở dĩ làm vầy để có SubjectID mà lộc thôi
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>
        /// Chọn giáo viên, chứ không phải chọn môn học giáo viên
        /// Sở dĩ làm vầy để có SubjectID mà lộc thôi
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.DgLookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != "" && condition != null)
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Teacher.C_TeacherID , SIM_Teacher.C_TeacherShortName, SIM_Teacher_Subject.C_TeacherID, "Mã giáo viên", SIM_Teacher.C_TeacherShortName, "Tên giáo viên");
        }

        /// <summary>
        /// Chọn giáo viên, chứ không phải chọn môn học giáo viên
        /// Sở dĩ làm vầy để có SubjectID mà lộc thôi
        /// </summary>
        /// <param name="lookupCategory"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup)
        {
            InitLookUpEdit(lookup, "");
        }

        /// <summary>       
        /// Chọn giáo viên, chứ không phải chọn môn học giáo viên
        /// Sở dĩ làm vầy để có SubjectID mà lộc thôi
        /// </summary>
        /// </summary>
        /// <param name="lookupRoom"></param>
        public static void InitLookUpEdit(Control.ULookUpEdit lookup, string condition)
        {
            DataTable dtbCopy = null;
            if (condition != null && condition != "")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            lookup.InitData(dtbCopy, "--Chọn--", SIM_Teacher_Subject.C_TeacherID, SIM_Teacher.C_TeacherShortName, SIM_Teacher.C_TeacherID, "Mã giáo viên", SIM_Teacher.C_TeacherShortName, "Tên giáo viên");
        }

        /// <summary>
        /// Chọn giáo viên, chứ không phải chọn môn học giáo viên
        /// Sở dĩ làm vầy để có SubjectID mà lộc thôi
        /// </summary>
        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository)
        {
            InitRepositoryLookUpEdit(repository, null);
        }

        /// <summary>
        /// Chọn giáo viên, chứ không phải chọn môn học giáo viên
        /// Sở dĩ làm vầy để có SubjectID mà lộc thôi
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="condition"></param>
        public static void InitRepositoryLookUpEdit(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repository, string condition)
        {
            DataTable dtbCopy = null;
            if ( condition != null && condition != "")
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ")" + " or TeacherID is null";
                //Table.DefaultView.RowFilter = condition;
            }
            else
                dtbCopy = Table;
            Control.DgGridView.InitRepositoryLookUpEdit(repository, dtbCopy, "", SIM_Teacher.C_TeacherID , SIM_Teacher.C_TeacherShortName , SIM_Teacher.C_TeacherID, "Mã giáo viên", SIM_Teacher.C_TeacherShortName, "Tên giáo viên");
        }

        #endregion


    }
}
