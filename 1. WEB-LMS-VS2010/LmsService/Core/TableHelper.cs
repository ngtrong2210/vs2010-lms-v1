using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LmsService.Core
{
    /// <summary>
    /// Helper class để cache và quản lý lookup tables (dropdown data)
    /// Pattern từ source mẫu: static cache + lazy loading
    /// </summary>
    public class TableHelper
    {
        /// <summary>
        /// Cache structure cho lookup tables
        /// Key: TableName, Value: DataTable
        /// </summary>
        private static readonly Dictionary<string, DataTable> _tableCache = new Dictionary<string, DataTable>(StringComparer.OrdinalIgnoreCase);
        private static readonly object _lockObj = new object();

        /// <summary>
        /// Lấy DataTable từ cache, nếu chưa có thì load từ database
        /// </summary>
        /// <param name="tableName">Tên bảng hoặc tên cache key</param>
        /// <param name="loadFunc">Function để load data từ database (nếu chưa có trong cache)</param>
        /// <returns>DataTable chứa dữ liệu lookup</returns>
        public static DataTable GetTable(string tableName, Func<DataTable> loadFunc)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                throw new ArgumentException("TableName không được để trống", nameof(tableName));

            // Kiểm tra cache
            if (_tableCache.ContainsKey(tableName))
                return _tableCache[tableName];

            // Lock để tránh race condition
            lock (_lockObj)
            {
                // Double-check sau khi lock
                if (_tableCache.ContainsKey(tableName))
                    return _tableCache[tableName];

                // Load data từ database
                if (loadFunc == null)
                    throw new ArgumentNullException(nameof(loadFunc), "Load function không được null");

                DataTable table = loadFunc();

                // Cache lại
                _tableCache[tableName] = table;
                return table;
            }
        }

        /// <summary>
        /// Clear cache cho một bảng cụ thể
        /// </summary>
        public static void ClearCache(string tableName)
        {
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                lock (_lockObj)
                {
                    if (_tableCache.ContainsKey(tableName))
                        _tableCache.Remove(tableName);
                }
            }
        }

        /// <summary>
        /// Clear toàn bộ cache
        /// </summary>
        public static void ClearAllCache()
        {
            lock (_lockObj)
            {
                _tableCache.Clear();
            }
        }

        /// <summary>
        /// Get cached table hoặc trả về null nếu chưa load
        /// </summary>
        public static DataTable TryGetTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return null;

            lock (_lockObj)
            {
                if (_tableCache.ContainsKey(tableName))
                    return _tableCache[tableName];
            }

            return null;
        }

        /// <summary>
        /// Kiểm tra table đã được cache chưa
        /// </summary>
        public static bool IsCached(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                return false;

            lock (_lockObj)
            {
                return _tableCache.ContainsKey(tableName);
            }
        }

        /// <summary>
        /// Tạo lookup table từ DataTable
        /// Convert DataTable sang Dictionary với key-value pairs
        /// </summary>
        public static Dictionary<string, string> ToLookup(DataTable table, string keyColumn, string valueColumn)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (string.IsNullOrWhiteSpace(keyColumn))
                throw new ArgumentException("KeyColumn không được để trống", nameof(keyColumn));

            if (string.IsNullOrWhiteSpace(valueColumn))
                throw new ArgumentException("ValueColumn không được để trống", nameof(valueColumn));

            return table.AsEnumerable()
                .ToDictionary(
                    row => row[keyColumn].ToString(),
                    row => row[valueColumn].ToString(),
                    StringComparer.OrdinalIgnoreCase
                );
        }

        /// <summary>
        /// Filter DataTable theo condition
        /// </summary>
        public static DataTable Filter(DataTable table, string filterExpression)
        {
            if (table == null)
                throw new ArgumentNullException(nameof(table));

            if (string.IsNullOrWhiteSpace(filterExpression))
                return table.Copy();

            DataRow[] rows = table.Select(filterExpression);
            if (rows.Length == 0)
                return table.Clone();

            DataTable result = table.Clone();
            foreach (DataRow row in rows)
                result.ImportRow(row);

            return result;
        }
    }
}
