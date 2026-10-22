using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DCore;

namespace LmsService.Core
{
    /// <summary>
    /// Service để quản lý lookup tables (dropdown data)
    /// Pattern từ source mẫu: Cache lookup tables + lazy loading
    /// </summary>
    public class LookupService
    {
        private readonly string _connectionString;

        public LookupService(string connectionString = null)
        {
            _connectionString = connectionString ?? SystemConfig.ConnectionString;
        }

        /// <summary>
        /// Cache key constants
        /// </summary>
        public static class CacheKeys
        {
            public const string FACULTIES = "FACULTIES";
            public const string DEPARTMENTS = "DEPARTMENTS";
            public const string CLASS_STATUS = "CLASS_STATUS";
            public const string SUBJECTS = "SUBJECTS";
            public const string ETHNICITIES = "ETHNICITIES";
            public const string RELIGIONS = "RELIGIONS";
            public const string PROVINCES = "PROVINCES";
            public const string DISTRICTS = "DISTRICTS";
            public const string CLASS_TYPES = "CLASS_TYPES";
            public const string GRADE_LEVELS = "GRADE_LEVELS";
            public const string USER_ROLES = "USER_ROLES";
            public const string USER_STATUS = "USER_STATUS";
        }

        /// <summary>
        /// Lấy DataTable từ cache hoặc load từ database
        /// </summary>
        public DataTable GetTable(string cacheKey, string storeName, params object[] parameters)
        {
            return TableHelper.GetTable(cacheKey, () => LoadTableFromDatabase(storeName, parameters));
        }

        /// <summary>
        /// Load DataTable từ database
        /// </summary>
        private DataTable LoadTableFromDatabase(string storeName, params object[] parameters)
        {
            IData data = DCore.Data.CreateData();
            try
            {
                data.CreateNewStoredProcedure(storeName);
                data.AddParameter(parameters);
                return data.ExecStoreToDataTable();
            }
            finally
            {
                data.Disconnect();
            }
        }

        /// <summary>
        /// Lấy Faculty list
        /// </summary>
        public DataTable GetFaculties()
        {
            return GetTable(CacheKeys.FACULTIES, "sp_Faculty_GetAll");
        }

        /// <summary>
        /// Lấy Department list
        /// </summary>
        public DataTable GetDepartments()
        {
            return GetTable(CacheKeys.DEPARTMENTS, "sp_Department_GetAll");
        }

        /// <summary>
        /// Lấy Class Status list
        /// </summary>
        public DataTable GetClassStatus()
        {
            return GetTable(CacheKeys.CLASS_STATUS, "sp_ClassStatus_GetAll");
        }

        /// <summary>
        /// Lấy Subject list
        /// </summary>
        public DataTable GetSubjects()
        {
            return GetTable(CacheKeys.SUBJECTS, "sp_Subject_GetAll");
        }

        /// <summary>
        /// Lấy Ethnicity list
        /// </summary>
        public DataTable GetEthnicities()
        {
            return GetTable(CacheKeys.ETHNICITIES, "sp_Ethnicity_GetAll");
        }

        /// <summary>
        /// Lấy Religion list
        /// </summary>
        public DataTable GetReligions()
        {
            return GetTable(CacheKeys.RELIGIONS, "sp_Religion_GetAll");
        }

        /// <summary>
        /// Lấy Province list
        /// </summary>
        public DataTable GetProvinces()
        {
            return GetTable(CacheKeys.PROVINCES, "sp_Province_GetAll");
        }

        /// <summary>
        /// Lấy District list theo Province
        /// </summary>
        public DataTable GetDistricts(string provinceId)
        {
            // District có thể filter theo province, nên cache key có thể dynamic
            string cacheKey = string.IsNullOrEmpty(provinceId)
                ? CacheKeys.DISTRICTS
                : $"{CacheKeys.DISTRICTS}_{provinceId}";

            return TableHelper.GetTable(cacheKey, () =>
            {
                IData data = DCore.Data.CreateData();
                try
                {
                    data.CreateNewStoredProcedure("sp_District_GetByProvince");
                    data.AddParameter(provinceId);
                    return data.ExecStoreToDataTable();
                }
                finally
                {
                    data.Disconnect();
                }
            });
        }

        /// <summary>
        /// Lấy Class Type list
        /// </summary>
        public DataTable GetClassTypes()
        {
            return GetTable(CacheKeys.CLASS_TYPES, "sp_ClassType_GetAll");
        }

        /// <summary>
        /// Lấy Grade Level list
        /// </summary>
        public DataTable GetGradeLevels()
        {
            return GetTable(CacheKeys.GRADE_LEVELS, "sp_GradeLevel_GetAll");
        }

        /// <summary>
        /// Lấy User Role list
        /// </summary>
        public DataTable GetUserRoles()
        {
            return GetTable(CacheKeys.USER_ROLES, "sp_UserRole_GetAll");
        }

        /// <summary>
        /// Lấy User Status list
        /// </summary>
        public DataTable GetUserStatus()
        {
            return GetTable(CacheKeys.USER_STATUS, "sp_UserStatus_GetAll");
        }

        /// <summary>
        /// Convert DataTable sang Dictionary lookup
        /// </summary>
        public Dictionary<string, string> ToLookup(DataTable table, string keyColumn, string valueColumn)
        {
            return TableHelper.ToLookup(table, keyColumn, valueColumn);
        }

        /// <summary>
        /// Filter DataTable theo condition
        /// </summary>
        public DataTable FilterTable(DataTable table, string filterExpression)
        {
            return TableHelper.Filter(table, filterExpression);
        }

        /// <summary>
        /// Clear cache cho một key cụ thể
        /// </summary>
        public void ClearCache(string cacheKey)
        {
            TableHelper.ClearCache(cacheKey);
        }

        /// <summary>
        /// Clear toàn bộ cache
        /// </summary>
        public void ClearAllCache()
        {
            TableHelper.ClearAllCache();
        }

        /// <summary>
        /// Lấy DataTable đã cached hoặc null
        /// </summary>
        public DataTable TryGetTable(string cacheKey)
        {
            return TableHelper.TryGetTable(cacheKey);
        }

        /// <summary>
        /// Kiểm tra table đã được cache chưa
        /// </summary>
        public bool IsCached(string cacheKey)
        {
            return TableHelper.IsCached(cacheKey);
        }

        /// <summary>
        /// Generic method để load custom lookup table
        /// </summary>
        public DataTable GetCustomLookup(string cacheKey, string storeName, params object[] parameters)
        {
            return GetTable(cacheKey, storeName, parameters);
        }
    }
}
