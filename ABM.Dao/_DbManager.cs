using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using ABM.Entity;

namespace ABM.Dao
{
    public class _DbManager
    {
        private static SqlConnection Connection { get; set; }

        private static SqlCommand Command { get; set; }

        public static List<DbParameter> OutParameters { get; private set; }

        private static void Open(string connectionString)
        {
            try
            {
                Connection = new SqlConnection(connectionString);

                Connection.Open();
            }
            catch (Exception e)
            {
                Close();
                throw new Exception("Database connection Error! Maybe your Database is not runing or database connection string is mistake?", e);                
            }
        }

        private static void Close()
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }
        
        // executes stored procedure with DB parameteres if they are passed
        private static object ExecuteProcedure(string procedureName, ExecuteType executeType, List<DbParameter> parameters)
        {
            object returnObject = null;

            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Command = new SqlCommand(procedureName, Connection) { CommandType = CommandType.StoredProcedure };

                    // pass stored procedure parameters to command
                    if (parameters != null)
                    {
                        Command.Parameters.Clear();

                        foreach (DbParameter dbParameter in parameters)
                        {
                            var parameter = new SqlParameter
                            {
                                ParameterName = "@" + dbParameter.Name,
                                Direction     = dbParameter.Direction,
                                Value         = dbParameter.Value
                            };
                            Command.Parameters.Add(parameter);
                        }
                    }

                    switch (executeType)
                    {
                        case ExecuteType.ExecuteReader:
                            returnObject = Command.ExecuteReader();
                            break;
                        case ExecuteType.ExecuteNonQuery:
                            returnObject = Command.ExecuteNonQuery();
                            break;
                        case ExecuteType.ExecuteScalar:
                            returnObject = Command.ExecuteScalar();
                            break;                        
                    }
                }
            }

            return returnObject;
        }

        // updates output parameters from stored procedure
        private static void UpdateOutParameters()
        {
            if (Command.Parameters.Count > 0)
            {
                OutParameters = new List<DbParameter>();
                OutParameters.Clear();

                for (var i = 0; i < Command.Parameters.Count; i++)
                {
                    if (Command.Parameters[i].Direction == ParameterDirection.Output)
                        OutParameters.Add(new DbParameter(Command.Parameters[i].ParameterName, ParameterDirection.Output, Command.Parameters[i].Value));
                }
            }
        }

        // executes scalar query stored procedure without parameters
        public T ExecuteSingle<T>(string connectionString, string procedureName) where T : new()
        {
            return ExecuteSingle<T>(connectionString, procedureName, null);
        }

        // executes scalar query stored procedure and maps result to single object
        public T ExecuteSingle<T>(string connectionString, string procedureName, List<DbParameter> parameters) where T : new()
        {
            Open(connectionString);
            var reader = (IDataReader)ExecuteProcedure(procedureName, ExecuteType.ExecuteReader, parameters);
            T tempObject = new T();

            if (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                    propertyInfo.SetValue(tempObject, reader.GetValue(i), null);                   
                }
            }

            reader.Close();

            UpdateOutParameters();

            Close();

            return tempObject;
        }

        // executes list query stored procedure without parameters
        public List<T> ExecuteList<T>(string connectionString, string procedureName) where T : new()
        {
            return ExecuteList<T>(connectionString, procedureName, null);
        }

        // executes list query stored procedure and maps result generic list of objects
        public static List<T> ExecuteList<T>(string connectionString, string procedureName, List<DbParameter> parameters) where T : new()
        {
            var objects = new List<T>();

            Open(connectionString);
            var reader = (IDataReader)ExecuteProcedure(procedureName, ExecuteType.ExecuteReader, parameters);

            while (reader.Read())
            {
                T tempObject = new T();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetValue(i) != DBNull.Value)
                    {                        
                        //PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                        //propertyInfo.SetValue(tempObject, reader.GetValue(i), null);

                        var fieldName = reader.GetName(i);
                        PropertyInfo propertyInfo = typeof(T).GetProperty(reader.GetName(i));
                        //var propertyInfo = GetPropertyInfo(entity, fieldName);
                        if (propertyInfo != null)
                        {
                            if ((reader[i] != null) && (reader[i] != DBNull.Value))
                            {
                                propertyInfo.SetValue(tempObject, reader[i], null);
                            }
                            else
                            {
                                if (propertyInfo.PropertyType == typeof(DateTime))
                                {
                                    propertyInfo.SetValue(tempObject, DateTime.MinValue, null);
                                }
                                else if (propertyInfo.PropertyType == typeof(string))
                                {
                                    propertyInfo.SetValue(tempObject, string.Empty, null);
                                }
                                else if (propertyInfo.PropertyType == typeof(bool))
                                {
                                    propertyInfo.SetValue(tempObject, false, null);
                                }
                                else if (propertyInfo.PropertyType == typeof(decimal))
                                {
                                    propertyInfo.SetValue(tempObject, decimal.Zero, null);
                                }
                                else
                                {
                                    propertyInfo.SetValue(tempObject, 0, null);
                                }
                            }
                        }
                        else
                        {
                            (tempObject as BaseEntity)[fieldName] = reader[i];
                        }
                    }
                }

                objects.Add(tempObject);
            }

            reader.Close();

            UpdateOutParameters();

            Close();

            return objects;
        }

        // executes non query stored procedure with parameters
        public int ExecuteNonQuery(string connectionString, string procedureName, List<DbParameter> parameters)
        {
            Open(connectionString);

            var returnValue = (int)ExecuteProcedure(procedureName, ExecuteType.ExecuteNonQuery, parameters);

            UpdateOutParameters();

            Close();

            return returnValue;
        }
    }

    public enum ExecuteType
    {
        ExecuteReader,
        ExecuteNonQuery,
        ExecuteScalar
    };

    public class DbParameter
    {
        public string Name { get; set; }
        public ParameterDirection Direction { get; set; }
        public object Value { get; set; }

        public DbParameter(string paramName, ParameterDirection paramDirection, object paramValue)
        {
            Name      = paramName;
            Direction = paramDirection;
            Value     = paramValue;
        }
    }
}
