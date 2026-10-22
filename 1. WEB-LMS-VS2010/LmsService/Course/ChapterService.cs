using System;
using System.Data;
using LmsObject;

namespace LmsService.Course
{
    public partial class ChapterService
    {
        static bool bolHaveNewData = false;
        static DataTable dtbTable = null;

        public static DataTable Table
        {
            get
            {
                if (dtbTable == null || bolHaveNewData)
                {
                    SIM_Chapters obj = new SIM_Chapters();
                    dtbTable = obj.GetDataTable("SIM_Chapters_SEARCHCBX");
                    DataRow drw = dtbTable.NewRow();
                    dtbTable.Rows.InsertAt(drw, 0);
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

        #region Business Logic

        public static bool CreateChapter(long courseId, string title, string description, int sortOrder, string status)
        {
            SIM_Chapters obj = new SIM_Chapters();
            obj.CourseId = courseId;
            obj.Title = title;
            obj.Description = description;
            obj.SortOrder = sortOrder;
            obj.Status = status;
            obj.CreatedAt = DateTime.UtcNow;
            obj.IsDeleted = false;

            bool result = obj.Add();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool UpdateChapter(long chapterId, long courseId, string title, string description, int sortOrder, string status)
        {
            SIM_Chapters obj = new SIM_Chapters();
            obj.ChapterID = chapterId;
            if (!obj.Get())
                return false;

            obj.CourseId = courseId;
            obj.Title = title;
            obj.Description = description;
            obj.SortOrder = sortOrder;
            obj.Status = status;
            obj.UpdatedAt = DateTime.UtcNow;

            bool result = obj.Update();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool DeleteChapter(long chapterId)
        {
            SIM_Chapters obj = new SIM_Chapters();
            obj.ChapterID = chapterId;
            bool result = obj.Delete();
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static bool ReorderChapter(long chapterId, int newSortOrder)
        {
            SIM_Chapters obj = new SIM_Chapters();
            obj.ChapterID = chapterId;
            if (!obj.Get())
                return false;

            bool result = obj.Reorder(newSortOrder);
            if (result)
            {
                HaveNewData = true;
            }
            return result;
        }

        public static DataTable GetChapterList(string condition = "")
        {
            SIM_Chapters obj = new SIM_Chapters();
            if (string.IsNullOrEmpty(condition))
                return obj.GetDataTable("SIM_Chapters_SEARCHCBX");
            else
                return obj.Search(condition);
        }

        public static DataTable GetChaptersByCourse(long courseId)
        {
            SIM_Chapters obj = new SIM_Chapters();
            return obj.GetByCourse(courseId);
        }

        #endregion
    }
}
