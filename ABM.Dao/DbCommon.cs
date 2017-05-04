using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ABM.Common;
using ABM.Entity;

namespace ABM.Dao
{
    public class DbCommon
    {        
        #region Properties

        public static int TotalRecords { get; set; }
        public static string ConnectionString { get; set; }        

        protected static string SpPagination = "[dbo].ABM_Pagination";

        #endregion

        #region Setting Connection, DbSchema

        public enum ConnectionName
        {
            ABM         = 1,
            HDCN        = 2,
            BOOKING     = 3,
            REPORTINGDB = 4
        }

        public static void SetConnection(ConnectionName connectionName)
        {
            switch (connectionName)
            {

                case ConnectionName.ABM:
                    ConnectionString = ConfigurationManager.ConnectionStrings[Constants.AbmConnectionString].ConnectionString;
                    break;
                case ConnectionName.HDCN:
                    ConnectionString = ConfigurationManager.ConnectionStrings[Constants.HdcnConnectionString].ConnectionString; 
                    break;
                case ConnectionName.BOOKING:
                    ConnectionString = ConfigurationManager.ConnectionStrings[Constants.BookingConnectionString].ConnectionString; 
                    break;
                case ConnectionName.REPORTINGDB:
                    ConnectionString = ConfigurationManager.ConnectionStrings[Constants.ReportingdbConnectionString].ConnectionString; 
                    break;
                default:
                    ConnectionString = ConfigurationManager.ConnectionStrings[Constants.AbmConnectionString].ConnectionString; 
                    break;
            }
        }
       
        #endregion

        #region Execute

        public static T ExecuteSingle<T>(string connectionString, string procedureName) where T : new()
        {
            return ExecuteSingle<T>(connectionString, procedureName, null);
        }

        public static T ExecuteSingle<T>(string connectionString, string procedureName, SqlParameter[] parameters) where T : new()
        {
            T tempObject = new T();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, procedureName, parameters);
                if (reader.Read())
                    BaseEntity.SetObjectValue(reader, ref tempObject);
                reader.Close();

                return tempObject;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExecuteSingle :: {0} :: {1}", procedureName, ex.Message));
            }
        }

        public static List<T> ExecuteList<T>(string connectionString, string procedureName) where T : new()
        {
            return ExecuteList<T>(connectionString, procedureName, null);
        }

        public static List<T> ExecuteList<T>(string connectionString, string procedureName, SqlParameter[] parameters) where T : new()
        {
            var list = new List<T>();
            try
            {
                SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, CommandType.StoredProcedure, procedureName, parameters);
                while (reader.Read())
                {
                    T tempObject = new T();

                    BaseEntity.SetObjectValue(reader, ref tempObject);
                    list.Add(tempObject);
                }
                reader.Close();

                if (parameters != null && parameters.Length > 0)
                {
                    foreach (var sqlParameter in parameters)
                    {
                        if (sqlParameter.Direction == ParameterDirection.Output)
                            TotalRecords = int.Parse(parameters[parameters.Length - 1].Value.ToString());
                    }    
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("ExecuteList :: {0} :: {1}", procedureName, ex.Message));
            }
        }

        public static List<T> ExecutePagination<T>(string connectionString, string table, string filter, string fieldList, string orderBy, int pageIndex, int pageSize, out int totalRecords) where T : new() 
        {
            try
            {
                var parameters = new[]
                    {
                        new SqlParameter("@DataSource", table),
                        new SqlParameter("@OrderBy", orderBy),
                        new SqlParameter("@FieldList", fieldList),
                        new SqlParameter("@Filter", filter),                        
                        new SqlParameter("@PageIndex", pageIndex),
                        new SqlParameter("@PageSize", pageSize),
                        new SqlParameter("@MaxRecords", 0) { Direction = ParameterDirection.Output }
                    };

                var list = ExecuteList<T>(connectionString, SpPagination, parameters);
                totalRecords = TotalRecords;
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpPagination, ex.Message));
            }
        }

        #endregion
    }
}
