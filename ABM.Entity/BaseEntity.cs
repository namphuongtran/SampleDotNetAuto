using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace ABM.Entity
{
    public class BaseEntity
    {
        public Int64 ItemIndex { get; set; }
        public string Action { get; set; }
        public string LstParams { get; set; }
        public List<int> LstId { get; set; }
        public List<string> LstName { get; set; }

        #region Get & Set Object Value

        private readonly Dictionary<string, object> _extendedProperties = new Dictionary<string, object>();

        public object this[string propertyName]
        {
            get
            {
                return (_extendedProperties.ContainsKey(propertyName) ? _extendedProperties[propertyName] : null);
            }
            set
            {
                if (_extendedProperties.ContainsKey(propertyName))
                {
                    _extendedProperties[propertyName] = value;
                }
                else
                {
                    _extendedProperties.Add(propertyName, value);
                }
            }
        }

        protected static PropertyInfo GetPropertyInfo(object @object, string propertyName)
        {
            foreach (PropertyInfo info in @object.GetType().GetProperties())
            {
                if (info.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return info;
                }
            }
            return null;
        }

        public static bool SetObjectValue<T>(IDataRecord reader, ref T entity)
        {
            Type type = typeof(T);

            for (var i = 0; i < reader.FieldCount; i++)
            {
                var fieldName = reader.GetName(i);
                var propertyInfo = GetPropertyInfo(entity, fieldName);
                if (propertyInfo != null)
                {
                    if ((reader[i] != null) && (reader[i] != DBNull.Value))
                    {
                        propertyInfo.SetValue(entity, reader[i], null);
                    }
                    else
                    {
                        if (propertyInfo.PropertyType == typeof(DateTime))
                        {
                            propertyInfo.SetValue(entity, DateTime.MinValue, null);
                        }
                        else if (propertyInfo.PropertyType == typeof(string))
                        {
                            propertyInfo.SetValue(entity, string.Empty, null);
                        }
                        else if (propertyInfo.PropertyType == typeof(bool))
                        {
                            propertyInfo.SetValue(entity, false, null);
                        }
                        else if (propertyInfo.PropertyType == typeof(decimal))
                        {
                            propertyInfo.SetValue(entity, decimal.Zero, null);
                        }
                        else
                        {
                            propertyInfo.SetValue(entity, 0, null);
                        }
                    }
                }
                else
                    (entity as BaseEntity)[fieldName] = reader[i];
            }

            return true;            
        }

        #endregion
    }
}
