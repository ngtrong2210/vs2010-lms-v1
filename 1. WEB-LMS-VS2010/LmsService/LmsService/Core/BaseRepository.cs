using System;
using System.Collections.Generic;
using System.Data;
using DCore;

namespace LmsService.Core
{
    /// <summary>
    /// Base Repository pattern cho tất cả repositories
    /// Pattern từ source mẫu: Base class với IData, transaction management, error handling
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public abstract class BaseRepository<T> where T : class, new()
    {
        protected IData objIData;
        protected bool bolIsExistIData;
        protected Exception objErrorException;

        /// <summary>
        /// Constructor với IData instance có sẵn
        /// </summary>
        protected BaseRepository(IData data = null)
        {
            bolIsExistIData = (data != null);
            objIData = data ?? DCore.Data.CreateData();
        }

        /// <summary>
        /// Lấy connection string từ SystemConfig
        /// </summary>
        protected string ConnectionString
        {
            get { return SystemConfig.ConnectionString; }
        }

        /// <summary>
        /// Execute stored procedure và trả về DataTable
        /// Pattern từ source mẫu: GetDataTable(storeName, params)
        /// </summary>
        protected DataTable GetDataTable(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();

            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataTable();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(ConnectionString, "Lỗi thực hiện store " + storeName + " trong " + typeof(T).Name, objEx);
                this.objErrorException = objEx;
                return null;
            }
        }

        /// <summary>
        /// Execute stored procedure và trả về DataSet (multiple result sets)
        /// </summary>
        protected DataSet GetDataSet(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();

            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataSet();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(ConnectionString, "Lỗi thực hiện store " + storeName + " trong " + typeof(T).Name, objEx);
                this.objErrorException = objEx;
                return null;
            }
        }

        /// <summary>
        /// Execute stored procedure và trả về IDataReader
        /// </summary>
        protected IDataReader ExecuteReader(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();

            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                return objIData.ExecStoreToDataReader();
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(ConnectionString, "Lỗi thực hiện store " + storeName + " trong " + typeof(T).Name, objEx);
                this.objErrorException = objEx;
                return null;
            }
        }

        /// <summary>
        /// Execute stored procedure không trả về kết quả (INSERT, UPDATE, DELETE)
        /// Pattern từ source mẫu: ExecuteSQL(storeName, pars)
        /// </summary>
        protected bool ExecuteNonQuery(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();

            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                objIData.ExecStoreToDataTable();
                return true;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(ConnectionString, "Lỗi thực hiện store " + storeName + " trong " + typeof(T).Name, objEx);
                this.objErrorException = objEx;
                return false;
            }
        }

        /// <summary>
        /// Execute stored procedure và trả về giá trị đơn (scalar)
        /// </summary>
        protected object ExecuteScalar(string storeName, params object[] pars)
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();

            try
            {
                objIData.CreateNewStoredProcedure(storeName);
                objIData.AddParameter(pars);
                DataTable dt = objIData.ExecStoreToDataTable();
                if (dt != null && dt.Rows.Count > 0)
                    return dt.Rows[0][0];
                return null;
            }
            catch (Exception objEx)
            {
                if (bolIsExistIData)
                    this.RollBackTransaction();
                new SystemError(ConnectionString, "Lỗi thực hiện store " + storeName + " trong " + typeof(T).Name, objEx);
                this.objErrorException = objEx;
                return null;
            }
        }

        /// <summary>
        /// Bắt đầu transaction
        /// Pattern từ source mẫu: BeginTransaction()
        /// </summary>
        protected void BeginTransaction()
        {
            if (!bolIsExistIData)
                objIData = DCore.Data.CreateData();

            objIData.BeginTransaction();
        }

        /// <summary>
        /// Commit transaction
        /// Pattern từ source mẫu: CommitTransaction()
        /// </summary>
        protected void CommitTransaction()
        {
            if (objIData != null)
                objIData.CommitTransaction();
        }

        /// <summary>
        /// Rollback transaction
        /// Pattern từ source mẫu: RollBackTransaction()
        /// </summary>
        protected void RollBackTransaction()
        {
            if (objIData != null)
                objIData.RollBackTransaction();
        }

        /// <summary>
        /// Disconnect data connection
        /// Pattern từ source mẫu: DisposeData()
        /// </summary>
        protected void DisposeData()
        {
            if (!bolIsExistIData && objIData != null)
            {
                objIData.Disconnect();
                objIData = null;
            }
        }

        /// <summary>
        /// Lấy exception nếu có lỗi xảy ra
        /// </summary>
        public Exception GetErrorException()
        {
            return objErrorException;
        }

        /// <summary>
        /// Clear error
        /// </summary>
        protected void ClearError()
        {
            objErrorException = null;
        }

        /// <summary>
        /// Dispose pattern
        /// </summary>
        public void Dispose()
        {
            DisposeData();
        }
    }
}
