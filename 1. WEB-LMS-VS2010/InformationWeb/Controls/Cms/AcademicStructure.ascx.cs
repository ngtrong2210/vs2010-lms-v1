using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.Controls.Cms
{
    public partial class AcademicStructure : CmsStoreControl
    {
        private SIM_Class _academicService;
        private SIM_Class AcademicService
        {
            get { return _academicService ?? (_academicService = new SIM_Class()); }
        }

        protected override string Operation
        {
            get { return "GetCatalog"; }
        }
        protected override string PageTitle
        {
            get { return "Cơ cấu đào tạo"; }
        }
        protected override string PageDescription
        {
            get
            {
                return "Quản lý môn học lớp theo năm học và liên kết trực tiếp với nội dung LMS.";
            }
        }


        protected override void LoadData()
        {
            try
            {
                DataSet data = AcademicService.GetCatalog(CurrentUser.UserID, CurrentUser.IsAdmin);
                BindTable(DataGrid, data, 0);
                BindTable(YearsGrid, data, 1);
                BindTable(SciencesGrid, data, 2);
                BindTable(CohortsGrid, data, 3);
                BindTable(ClassesGrid, data, 4);
                BindTable(SubjectsGrid, data, 5);
                BindTable(TeachersGrid, data, 6);
                BindTable(StudentsGrid, data, 7);
                BindTable(ClassSubjectsGrid, data, 8);
                BindTable(TimetablesGrid, data, 9);
                AcademicCatalogJsonValue.Value = SerializeCatalog(data);
                AcademicIsAdminValue.Value = CurrentUser.IsAdmin ? "1" : "0";
                EmptyText.Visible = data == null || data.Tables.Count == 0;
                ErrorText.Visible = false;
            }
            catch (System.Exception ex)
            {
                WebLog.Error("Nạp cơ cấu đào tạo thất bại.", ex);
                ErrorText.Text = "Không thể nạp cơ cấu đào tạo.";
                ErrorText.Visible = true;
            }
        }

        protected void AcademicSaveButton_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                ShowActionResult(
                    ActionMessageText,
                    "Bạn không có quyền thay đổi cơ cấu đào tạo.",
                    false
                );
                return;
            }
            try
            {
                Dictionary<string, object> form = DeserializeObject(AcademicFormJsonValue.Value);
                string entityType = TextValue(form, "entityType").ToUpperInvariant();
                if (string.IsNullOrWhiteSpace(entityType))
                    throw new ArgumentException("Loại danh mục đào tạo không hợp lệ.");
                DataTable result = AcademicService.SaveAcademicEntity(
                    entityType,
                    IntValue(form, "dataGroupId", 1),
                    DbText(form, "code"),
                    DbText(form, "name"),
                    DbText(form, "shortName"),
                    DbText(form, "parentCode"),
                    DbInt(form, "startYear"),
                    DbInt(form, "finishYear"),
                    DbDate(form, "startAt"),
                    DbDate(form, "finishAt"),
                    DbInt(form, "yearId"),
                    DbInt(form, "semester"),
                    DbLong(form, "classSubjectId"),
                    DbText(form, "classId"),
                    DbText(form, "subjectId"),
                    DbText(form, "teacherId"),
                    IntValue(form, "classSize", 0),
                    IntValue(form, "creditCount", 0),
                    IntValue(form, "theoryQuantity", 0),
                    IntValue(form, "practiceQuantity", 0),
                    DbLong(form, "timetableId"),
                    DbInt(form, "dayOfWeek"),
                    DbInt(form, "startPeriod"),
                    DbInt(form, "endPeriod"),
                    DbTime(form, "startTime"),
                    DbTime(form, "endTime"),
                    DbText(form, "roomName"),
                    DbDate(form, "effectiveFrom"),
                    DbDate(form, "effectiveTo"),
                    CurrentUser.UserID
                );
                bool ok = result != null && result.Rows.Count > 0;
                ShowActionResult(
                    ActionMessageText,
                    ok ? "Đã lưu cấu trúc đào tạo." : "Không thể lưu cấu trúc đào tạo.",
                    ok
                );
            }
            catch (Exception ex)
            {
                WebLog.Error("Lưu cơ cấu đào tạo thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
            LoadData();
        }

        protected void AcademicAssignButton_Click(object sender, EventArgs e)
        {
            if (!CurrentUser.IsAdmin)
            {
                ShowActionResult(
                    ActionMessageText,
                    "Bạn không có quyền phân học viên vào lớp.",
                    false
                );
                return;
            }
            try
            {
                string classId = (AcademicAssignClassIdValue.Value ?? string.Empty).Trim();
                List<long> submitted = new JavaScriptSerializer().Deserialize<List<long>>(
                    AcademicAssignStudentIdsValue.Value ?? "[]"
                );
                List<long> studentIds = new List<long>();
                HashSet<long> unique = new HashSet<long>();
                if (submitted != null)
                    foreach (long id in submitted)
                        if (id > 0 && unique.Add(id))
                            studentIds.Add(id);
                if (classId.Length == 0 || studentIds.Count == 0)
                    throw new ArgumentException("Vui lòng chọn lớp và ít nhất một học viên.");
                DataTable result = AcademicService.AssignStudentsToClass(
                    1,
                    classId,
                    new JavaScriptSerializer().Serialize(studentIds),
                    CurrentUser.UserID
                );
                bool ok = result != null && result.Rows.Count > 0;
                ShowActionResult(
                    ActionMessageText,
                    ok
                        ? "Đã phân học viên vào lớp và đồng bộ môn LMS."
                        : "Không thể phân học viên vào lớp.",
                    ok
                );
            }
            catch (Exception ex)
            {
                WebLog.Error("Phân học viên vào lớp thất bại.", ex);
                ShowActionResult(ActionMessageText, ex.Message, false);
            }
            LoadData();
        }

        private static void BindTable(GridView grid, DataSet data, int index)
        {
            grid.DataSource = data != null && data.Tables.Count > index ? data.Tables[index] : null;
            grid.DataBind();
        }

        private static string SerializeCatalog(DataSet data)
        {
            Dictionary<string, object> catalog = new Dictionary<string, object>(
                StringComparer.OrdinalIgnoreCase
            );
            string[] names =
            {
                "summary",
                "years",
                "sciences",
                "cohorts",
                "classes",
                "subjects",
                "teachers",
                "students",
                "offerings",
                "timetables",
            };
            for (int index = 0; index < names.Length; index++)
                catalog[names[index]] = TableRows(
                    data != null && data.Tables.Count > index ? data.Tables[index] : null
                );
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = 4 * 1024 * 1024;
            return serializer.Serialize(catalog);
        }

        private static List<Dictionary<string, object>> TableRows(DataTable table)
        {
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            if (table == null)
                return rows;
            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, object> item = new Dictionary<string, object>(
                    StringComparer.OrdinalIgnoreCase
                );
                foreach (DataColumn column in table.Columns)
                {
                    object value = row[column];
                    if (value == DBNull.Value)
                        item[column.ColumnName] = null;
                    else if (value is DateTime)
                        item[column.ColumnName] = ((DateTime)value).ToString(
                            "yyyy-MM-ddTHH:mm:ss",
                            CultureInfo.InvariantCulture
                        );
                    else if (value is TimeSpan)
                        item[column.ColumnName] = ((TimeSpan)value).ToString();
                    else
                        item[column.ColumnName] = value;
                }
                rows.Add(item);
            }
            return rows;
        }

        private static Dictionary<string, object> DeserializeObject(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new ArgumentException("Dữ liệu biểu mẫu không hợp lệ.");
            Dictionary<string, object> value = new JavaScriptSerializer().Deserialize<
                Dictionary<string, object>
            >(json);
            if (value == null)
                throw new ArgumentException("Dữ liệu biểu mẫu không hợp lệ.");
            return value;
        }

        private static string TextValue(IDictionary<string, object> values, string key)
        {
            object value;
            return values != null && values.TryGetValue(key, out value) && value != null
                ? Convert.ToString(value, CultureInfo.InvariantCulture).Trim()
                : string.Empty;
        }

        private static string DbText(IDictionary<string, object> values, string key)
        {
            string value = TextValue(values, key);
            return value.Length == 0 ? null : value;
        }

        private static int IntValue(IDictionary<string, object> values, string key, int fallback)
        {
            int value;
            return int.TryParse(
                TextValue(values, key),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out value
            )
                ? value
                : fallback;
        }

        private static int? DbInt(IDictionary<string, object> values, string key)
        {
            int value;
            return int.TryParse(
                TextValue(values, key),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out value
            )
                ? value
                : (int?)null;
        }

        private static long? DbLong(IDictionary<string, object> values, string key)
        {
            long value;
            return long.TryParse(
                TextValue(values, key),
                NumberStyles.Integer,
                CultureInfo.InvariantCulture,
                out value
            )
                ? value
                : (long?)null;
        }

        private static DateTime? DbDate(IDictionary<string, object> values, string key)
        {
            DateTime value;
            return DateTime.TryParse(
                TextValue(values, key),
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out value
            )
                ? value
                : (DateTime?)null;
        }

        private static TimeSpan? DbTime(IDictionary<string, object> values, string key)
        {
            TimeSpan value;
            return TimeSpan.TryParse(
                TextValue(values, key),
                CultureInfo.InvariantCulture,
                out value
            )
                ? value
                : (TimeSpan?)null;
        }
    }
}
