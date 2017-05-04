using ABM.Entity.Permission;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM.Dao.Permission
{
    public class SKURelatedDao
    {
        public SKURelatedDao()
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
        }

        private const string SpInsert = "[dbo].SKU_Related_Insert";
        private const string SpDelete = "[dbo].SKU_Related_Delete";

        #region Insert
        public static bool Insert(SKURelatedEntity entity)
        {    
            try
            {
                var paras = new List<SqlParameter>
                {
                    new SqlParameter("@SKUIDMain", entity.SKUIDMain),
                    new SqlParameter("@SKUID", entity.SKUID)                    
                };
                    
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpInsert, paras.ToArray());

                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            } 
        }
        #endregion
        
        #region Delete
        public static bool Delete(SKURelatedEntity entity)
        {
            try
            {
                var paras = new List<SqlParameter>
                {
                    new SqlParameter("@SKUIDMain", entity.SKUIDMain),
                    new SqlParameter("@SKUID", entity.SKUID)       
                };

                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpDelete, paras.ToArray());

                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }
        #endregion

    }
}
