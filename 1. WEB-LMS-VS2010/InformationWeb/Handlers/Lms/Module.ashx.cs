using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;
using InformationWeb.LmsInfrastructure;
using LmsObject;

namespace InformationWeb.Handlers.Lms
{
    public sealed class ModuleHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            try
            {
                SYS_Users user = UserSession.Current;
                if (!context.Request.IsAuthenticated || user == null)
                {
                    Write(
                        context,
                        401,
                        new { success = false, message = "Phiên đăng nhập đã hết hạn." }
                    );
                    return;
                }
                string moduleName = (context.Request["module"] ?? string.Empty).Trim();
                string operation = (context.Request["operation"] ?? string.Empty).Trim();
                LmsObject.LmsObjectBase service = Resolve(moduleName, operation, user);
                IDictionary<string, object> values = ReadValues(context);
                ProtectActor(values, user);

                bool isGet = string.Equals(
                    context.Request.HttpMethod,
                    "GET",
                    StringComparison.OrdinalIgnoreCase
                );
                bool returnTable =
                    isGet
                    || string.Equals(
                        context.Request["returnTable"],
                        "true",
                        StringComparison.OrdinalIgnoreCase
                    );
                if (
                    !isGet
                    && !string.Equals(
                        context.Request.Headers["X-LMS-Request"],
                        "1",
                        StringComparison.Ordinal
                    )
                )
                {
                    Write(
                        context,
                        400,
                        new { success = false, message = "Thiếu tiêu đề bảo vệ yêu cầu." }
                    );
                    return;
                }

                if (returnTable)
                {
                    DataTable table = service.GetDataTable(operation, values);
                    Write(
                        context,
                        200,
                        new
                        {
                            success = table != null,
                            data = Rows(table),
                            total = table == null ? 0 : table.Rows.Count,
                        }
                    );
                }
                else
                {
                    bool success = service.ExecNonQuery(operation, values);
                    Write(
                        context,
                        success ? 200 : 400,
                        new
                        {
                            success = success,
                            message = success
                                ? "Thực hiện thành công."
                                : "Stored procedure trả về lỗi.",
                        }
                    );
                }
            }
            catch (Exception ex)
            {
                WebLog.Error("Module handler thất bại.", ex);
                int status =
                    ex is InvalidOperationException ? 403 : (ex is ArgumentException ? 400 : 500);
                Write(
                    context,
                    status,
                    new
                    {
                        success = false,
                        message = status == 500 ? "Không thể thực hiện yêu cầu." : ex.Message,
                    }
                );
            }
        }

        private static LmsObject.LmsObjectBase Resolve(string name, string operation, SYS_Users user)
        {
            switch (name.ToLowerInvariant())
            {
                case "learning":
                    RequireStudent(user);
                    return new LMS_LearningSessions();
                case "comments":
                    return new SYS_Comments();
                case "notifications":
                    return new SYS_Notifications();
                case "quiz":
                    if (
                        operation.Equals("StudentGet", StringComparison.OrdinalIgnoreCase)
                        || operation.Equals("AttemptStart", StringComparison.OrdinalIgnoreCase)
                        || operation.Equals("AttemptSubmit", StringComparison.OrdinalIgnoreCase)
                    )
                        RequireStudent(user);
                    else
                        RequireCms(user);
                    return new LMS_Quiz();
                case "academic":
                    RequireCms(user);
                    return new SIM_Class();
                case "courses":
                    RequireCms(user);
                    return new SIM_Courses();
                case "content":
                    RequireCms(user);
                    return new LMS_Content();
                case "interactivecontent":
                    if (
                        operation.Equals("get_list", StringComparison.OrdinalIgnoreCase)
                        || operation.Equals("get_by_id", StringComparison.OrdinalIgnoreCase)
                        || operation.Equals("get_by_lesson", StringComparison.OrdinalIgnoreCase)
                        || operation.Equals("get_questions", StringComparison.OrdinalIgnoreCase)
                    )
                        RequireStudent(user);
                    else
                        RequireCms(user);
                    return new LMS_InteractiveContents();
                case "questions":
                    RequireCms(user);
                    return new LMS_Questions();
                case "reports":
                    RequireCms(user);
                    return new SIM_Report_Records();
                case "search":
                    RequireCms(user);
                    return new SYS_Search();
                case "students":
                    RequireCms(user);
                    return new SYS_Users();
                case "teacher":
                    RequireCms(user);
                    return new SYS_Teacher();
                case "teaching":
                    RequireCms(user);
                    return new SIM_Teaching();
                case "administration":
                    if (!user.IsAdmin)
                        throw new InvalidOperationException(
                            "Chỉ quản trị viên được dùng chức năng này."
                        );
                    return new SYS_Administration();
                default:
                    throw new InvalidOperationException("Module không hợp lệ.");
            }
        }

        private static IDictionary<string, object> ReadValues(HttpContext context)
        {
            Dictionary<string, object> values = new Dictionary<string, object>(
                StringComparer.OrdinalIgnoreCase
            );
            foreach (string key in context.Request.QueryString.AllKeys)
                if (!Reserved(key))
                    values[key.TrimStart('@')] = EmptyToNull(context.Request.QueryString[key]);
            foreach (string key in context.Request.Form.AllKeys)
                if (!Reserved(key))
                    values[key.TrimStart('@')] = EmptyToNull(context.Request.Form[key]);
            if (
                (context.Request.ContentType ?? string.Empty).StartsWith(
                    "application/json",
                    StringComparison.OrdinalIgnoreCase
                )
            )
            {
                string json;
                using (StreamReader reader = new StreamReader(context.Request.InputStream))
                    json = reader.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(json))
                    foreach (
                        KeyValuePair<string, object> item in new JavaScriptSerializer().Deserialize<
                            Dictionary<string, object>
                        >(json)
                    )
                        if (!Reserved(item.Key))
                            values[item.Key.TrimStart('@')] = item.Value;
            }
            return values;
        }

        private static void ProtectActor(IDictionary<string, object> values, SYS_Users user)
        {
            string[] actorNames = { "ActorId", "ActorID", "ActorUserID" };
            foreach (string name in actorNames)
                if (values.ContainsKey(name))
                    values[name] = user.UserID;
            if (values.ContainsKey("RecipientUserID"))
                values["RecipientUserID"] = user.UserID;
            if (user.IsStudent)
            {
                if (values.ContainsKey("UserId"))
                    values["UserId"] = user.UserID;
                if (values.ContainsKey("StudentId"))
                    values["StudentId"] = user.UserID;
                if (values.ContainsKey("StudentUserID"))
                    values["StudentUserID"] = user.UserID;
            }
            if (values.ContainsKey("IsAdmin"))
                values["IsAdmin"] = user.IsAdmin;
            if (values.ContainsKey("IsTeacher"))
                values["IsTeacher"] = user.IsTeacher;
        }

        private static object Rows(DataTable table)
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
                    item[column.ColumnName] = row[column] == DBNull.Value ? null : row[column];
                rows.Add(item);
            }
            return rows;
        }

        private static bool Reserved(string key)
        {
            return string.IsNullOrWhiteSpace(key)
                || key.Equals("module", StringComparison.OrdinalIgnoreCase)
                || key.Equals("operation", StringComparison.OrdinalIgnoreCase)
                || key.Equals("returnTable", StringComparison.OrdinalIgnoreCase);
        }

        private static object EmptyToNull(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : (object)value;
        }

        private static void RequireCms(SYS_Users user)
        {
            if (!user.IsAdmin && !user.IsTeacher)
                throw new InvalidOperationException("Bạn không có quyền quản trị nội dung.");
        }

        private static void RequireStudent(SYS_Users user)
        {
            if (!user.IsStudent)
                throw new InvalidOperationException("Chức năng chỉ dành cho học viên.");
        }

        private static void Write(HttpContext context, int status, object value)
        {
            context.Response.StatusCode = status;
            context.Response.TrySkipIisCustomErrors = true;
            context.Response.Write(new JavaScriptSerializer().Serialize(value));
        }
    }
}
