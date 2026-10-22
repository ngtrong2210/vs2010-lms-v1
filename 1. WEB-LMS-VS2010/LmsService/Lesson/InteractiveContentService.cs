using System;
using System.Data;
using LmsObject;

namespace LmsService.Lesson
{
    /// <summary>
    /// Service quản lý Interactive Content (Nội dung tương tác của bài học)
    /// Pattern theo WEB_ARCHITECTURE_RULES.md
    /// Hỗ trợ cả ModuleService (cho ModuleHandler) và static methods (cho WebForms)
    /// </summary>
    public partial class InteractiveContentService : ModuleService
    {
        public InteractiveContentService()
            : base(BuildOperations())
        {
        }

        private static System.Collections.Generic.IDictionary<string, string> BuildOperations()
        {
            return new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // CRUD operations
                { "get_list", "LMS_InteractiveContents_SEARCHCBX" },
                { "get_by_id", "LMS_InteractiveContents_SEL" },
                { "get_by_lesson", "LMS_InteractiveContents_ByLessonID" },
                { "get_questions", "LMS_InteractiveContentQuestions_SEL" },
                { "create", "LMS_InteractiveContents_INS" },
                { "update", "LMS_InteractiveContents_UPD" },
                { "delete", "LMS_InteractiveContents_DEL" }
            };
        }

        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        /// <summary>
        /// Static Table với caching
        /// </summary>
        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    LMS_InteractiveContents obj = new LMS_InteractiveContents();
                    dtbTable = obj.GetDataTable("LMS_InteractiveContents_SEARCHCBX");
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

        #region UI Helpers

        /// <summary>
        /// Khởi tạo DropDownList cho Interactive Content
        /// </summary>
        public static void InitDropDownList(System.Web.UI.WebControls.DropDownList ddl, string condition = "")
        {
            DataTable dtbCopy = null;
            if (!string.IsNullOrEmpty(condition))
            {
                dtbCopy = Table.Copy();
                dtbCopy.DefaultView.RowFilter = "(" + condition + ") or " + LMS_InteractiveContents.C_InteractiveContentID + " is null";
            }
            else
            {
                dtbCopy = Table;
            }

            // Add a display column combining ID and LessonID for better UX
            if (!dtbCopy.Columns.Contains("DisplayText"))
            {
                dtbCopy.Columns.Add("DisplayText", typeof(string));
                foreach (DataRow row in dtbCopy.Rows)
                {
                    object id = row[LMS_InteractiveContents.C_InteractiveContentID];
                    object lessonId = row[LMS_InteractiveContents.C_LessonID];
                    if (id != DBNull.Value && id != null)
                    {
                        row["DisplayText"] = string.Format("ID={0} - LessonID={1}", id, lessonId != DBNull.Value ? lessonId : "N/A");
                    }
                    else
                    {
                        row["DisplayText"] = "";
                    }
                }
            }

            ddl.DataSource = dtbCopy;
            ddl.DataTextField = "DisplayText";
            ddl.DataValueField = LMS_InteractiveContents.C_InteractiveContentID;
            ddl.DataBind();
            ddl.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Chọn--", ""));
        }

        #endregion

        #region Business Logic

        /// <summary>
        /// Tạo Interactive Content mới
        /// </summary>
        public static bool CreateInteractiveContent(long lessonId, string completionRule,
            bool requireReading, decimal passingScore, bool showResultImmediately,
            bool showScore, long createdByUserId)
        {
            LMS_InteractiveContents obj = new LMS_InteractiveContents();
            obj.LessonID = lessonId;
            obj.CompletionRule = completionRule;
            obj.RequireReading = requireReading;
            obj.PassingScore = passingScore;
            obj.ShowResultImmediately = showResultImmediately;
            obj.ShowScore = showScore;
            obj.CreatedByUserID = createdByUserId;
            obj.CreatedAt = DateTime.UtcNow;

            bool result = obj.Add();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        /// <summary>
        /// Cập nhật Interactive Content
        /// </summary>
        public static bool UpdateInteractiveContent(long interactiveContentId, string completionRule,
            bool requireReading, decimal passingScore, bool showResultImmediately,
            bool showScore, long updatedByUserId)
        {
            LMS_InteractiveContents obj = new LMS_InteractiveContents(interactiveContentId);
            if (obj.InteractiveContentID == 0)
            {
                return false; // Không tìm thấy
            }

            obj.CompletionRule = completionRule;
            obj.RequireReading = requireReading;
            obj.PassingScore = passingScore;
            obj.ShowResultImmediately = showResultImmediately;
            obj.ShowScore = showScore;
            obj.UpdatedByUserID = updatedByUserId;
            obj.UpdatedAt = DateTime.UtcNow;

            bool result = obj.Update();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        /// <summary>
        /// Xóa Interactive Content
        /// </summary>
        public static bool DeleteInteractiveContent(long interactiveContentId)
        {
            LMS_InteractiveContents obj = new LMS_InteractiveContents(interactiveContentId);
            bool result = obj.Delete();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        /// <summary>
        /// Lấy Interactive Content theo ID
        /// </summary>
        public static LMS_InteractiveContents GetById(long interactiveContentId)
        {
            return new LMS_InteractiveContents(interactiveContentId);
        }

        /// <summary>
        /// Lấy Interactive Content theo Lesson ID
        /// </summary>
        public static DataTable GetByLessonId(long lessonId)
        {
            LMS_InteractiveContents obj = new LMS_InteractiveContents();
            return obj.SearchByLessonID(lessonId);
        }

        /// <summary>
        /// Lấy danh sách câu hỏi của Interactive Content
        /// </summary>
        public static DataTable GetQuestions(long interactiveContentId)
        {
            LMS_InteractiveContents obj = new LMS_InteractiveContents();
            return obj.GetQuestions(interactiveContentId);
        }

        /// <summary>
        /// Lấy danh sách Interactive Content theo điều kiện
        /// </summary>
        public static DataTable GetInteractiveContentList(string condition = "")
        {
            LMS_InteractiveContents obj = new LMS_InteractiveContents();
            if (string.IsNullOrEmpty(condition))
                return obj.GetDataTable("LMS_InteractiveContents_SEARCHCBX");
            else
                return obj.Search(condition);
        }

        #endregion
    }
}
