using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ABM.Entity.Permission;
using ABM.Entity;

namespace ABM.Dao.Permission
{
    public class SKUFileDao
    {
        public SKUFileDao()
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
        }
        
        private const string SpInsert        = "[dbo].SKU_File_Insert";
        private const string SpDeleteBySKUId = "[dbo].SKU_File_DeleteBySKUId";
        private const string SpDelete        = "[dbo].SKU_File_Delete";
        

        #region Insert
        public static bool Insert(SKUFileEntity entity)
        {    
            try
            {
                var paras = new List<SqlParameter>
                {
                    new SqlParameter("@FileName", entity.FileName),
                    new SqlParameter("@FilePath", entity.FilePath),
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
        public static bool DeleteBySKUId(int skuId)
        {
            try
            {
                var paras = new[] { new SqlParameter("@SKUID", skuId) };

                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpDeleteBySKUId, paras);

                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }

        public static bool Delete(int fileId)
        {
            try
            {
                var paras = new[] { new SqlParameter("@FileID", fileId) };

                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpDelete, paras);

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
