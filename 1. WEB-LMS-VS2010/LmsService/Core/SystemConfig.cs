using System;
using System.Configuration;

namespace LmsService.Core
{
    /// <summary>
    /// Helper class để truy cập configuration từ web.config
    /// </summary>
    public class SystemConfig
    {
        private static string _connectionString;

        /// <summary>
        /// Connection string mặc định cho database
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["LMSConnectionString"]?.ConnectionString
                        ?? ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString
                        ?? throw new InvalidOperationException("Không tìm thấy connection string trong web.config");
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// Lấy connection string theo tên
        /// </summary>
        public static string GetConnectionString(string name)
        {
            string connStr = ConfigurationManager.ConnectionStrings[name]?.ConnectionString
                ?? throw new InvalidOperationException($"Không tìm thấy connection string '{name}' trong web.config");
            return connStr;
        }

        /// <summary>
        /// Lấy app setting theo key
        /// </summary>
        public static string GetAppSetting(string key, string defaultValue = "")
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        /// <summary>
        /// Lấy app setting số nguyên
        /// </summary>
        public static int GetAppSettingInt(string key, int defaultValue = 0)
        {
            string value = GetAppSetting(key);
            if (int.TryParse(value, out int result))
                return result;
            return defaultValue;
        }

        /// <summary>
        /// Lấy app setting boolean
        /// </summary>
        public static bool GetAppSettingBool(string key, bool defaultValue = false)
        {
            string value = GetAppSetting(key);
            if (bool.TryParse(value, out bool result))
                return result;
            return defaultValue;
        }
    }
}
