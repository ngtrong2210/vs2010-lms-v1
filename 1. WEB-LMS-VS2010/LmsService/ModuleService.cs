using System;
using System.Collections.Generic;
using System.Data;
using LmsObject;

namespace LmsService
{
    /// <summary>
    /// Ánh xạ tên thao tác sang store thực tế. Việc kết nối và thực thi vẫn dùng DCore
    /// thông qua GetDataTable/ExecNonQuery có sẵn trên object Base.
    /// </summary>
    public abstract class ModuleService
    {
        private readonly IDictionary<string, string> _operations;

        protected ModuleService(IDictionary<string, string> operations)
        {
            if (operations == null) throw new ArgumentNullException("operations");
            _operations = new Dictionary<string, string>(operations, StringComparer.OrdinalIgnoreCase);
        }

        public IEnumerable<string> Operations { get { return _operations.Keys; } }

        public DataTable GetDataTable(string operation, params object[] pars)
        {
            return new SYS_Users().GetDataTable(Procedure(operation), pars);
        }

        public DataTable GetDataTable(string operation, IDictionary<string, object> values)
        {
            return GetDataTable(operation, Flatten(values));
        }

        public DataSet GetDataSet(string operation, params object[] pars)
        {
            return new SYS_Users().GetDataSet(Procedure(operation), pars);
        }

        public DataSet GetDataSet(string operation, IDictionary<string, object> values)
        {
            return GetDataSet(operation, Flatten(values));
        }

        public bool ExecNonQuery(string operation, params object[] pars)
        {
            return new SYS_Users().ExecNonQuery(Procedure(operation), pars);
        }

        public bool ExecNonQuery(string operation, IDictionary<string, object> values)
        {
            return ExecNonQuery(operation, Flatten(values));
        }

        public string Procedure(string operation)
        {
            string procedure;
            if (string.IsNullOrWhiteSpace(operation) || !_operations.TryGetValue(operation, out procedure))
                throw new InvalidOperationException("Thao tác không được phép trong module: " + operation + ".");
            return procedure;
        }

        protected static IDictionary<string, string> Map(params string[] operationAndProcedure)
        {
            if (operationAndProcedure == null || operationAndProcedure.Length % 2 != 0)
                throw new ArgumentException("Map phải theo cặp operation/procedure.");
            Dictionary<string, string> result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < operationAndProcedure.Length; i += 2)
                result.Add(operationAndProcedure[i], operationAndProcedure[i + 1]);
            return result;
        }

        private static object[] Flatten(IDictionary<string, object> values)
        {
            if (values == null || values.Count == 0) return new object[0];
            object[] pars = new object[values.Count * 2];
            int index = 0;
            foreach (KeyValuePair<string, object> pair in values)
            {
                pars[index++] = pair.Key.StartsWith("@", StringComparison.Ordinal) ? pair.Key : "@" + pair.Key;
                pars[index++] = pair.Value;
            }
            return pars;
        }

        #region Enhanced Load Methods for Generic Use

        /// <summary>
        /// Load một object T từ DataTable đầu tiên trả về bởi operation.
        /// T cần có constructor không tham số và method LoadFromDataRow.
        /// </summary>
        public T LoadSingle<T>(string operation, params object[] pars) where T : new()
        {
            DataTable dt = GetDataTable(operation, pars);
            if (dt != null && dt.Rows.Count > 0)
            {
                T obj = new T();
                var loadMethod = obj.GetType().GetMethod("LoadFromDataRow", new[] { typeof(DataRow) });
                if (loadMethod != null)
                {
                    loadMethod.Invoke(obj, new object[] { dt.Rows[0] });
                    return obj;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Load một object T từ DataTable đầu tiên trả về bởi operation với dictionary values.
        /// </summary>
        public T LoadSingle<T>(string operation, IDictionary<string, object> values) where T : new()
        {
            return LoadSingle<T>(operation, Flatten(values));
        }

        /// <summary>
        /// Load danh sách object T từ DataTable trả về bởi operation.
        /// T cần có constructor không tham số và method LoadFromDataRow.
        /// </summary>
        public List<T> LoadList<T>(string operation, params object[] pars) where T : new()
        {
            List<T> list = new List<T>();
            DataTable dt = GetDataTable(operation, pars);
            if (dt != null)
            {
                var loadMethod = typeof(T).GetMethod("LoadFromDataRow", new[] { typeof(DataRow) });
                foreach (DataRow row in dt.Rows)
                {
                    T obj = new T();
                    if (loadMethod != null)
                    {
                        loadMethod.Invoke(obj, new object[] { row });
                    }
                    list.Add(obj);
                }
            }
            return list;
        }

        /// <summary>
        /// Load danh sách object T từ DataTable trả về bởi operation với dictionary values.
        /// </summary>
        public List<T> LoadList<T>(string operation, IDictionary<string, object> values) where T : new()
        {
            return LoadList<T>(operation, Flatten(values));
        }

        /// <summary>
        /// Load danh sách object T sử dụng static method FromDataTable nếu có.
        /// </summary>
        public List<T> LoadListFromDataTable<T>(string operation, params object[] pars) where T : new()
        {
            DataTable dt = GetDataTable(operation, pars);
            var fromDtMethod = typeof(T).GetMethod("FromDataTable", new[] { typeof(DataTable) });
            if (fromDtMethod != null)
            {
                return (List<T>)fromDtMethod.Invoke(null, new object[] { dt });
            }
            return LoadList<T>(operation, pars);
        }

        #endregion
    }
}
