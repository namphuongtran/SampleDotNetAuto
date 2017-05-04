using ABM.Entity;
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
    public class SKUImageDao
    {
        public SKUImageDao()
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
        }

        private const string SpInsert        = "[dbo].SKU_Image_Insert";
        private const string SpDeleteBySKUId = "[dbo].SKU_Image_DeleteBySKUId";
        private const string SpDelete        = "[dbo].SKU_Image_Delete";

        #region Insert
        public static bool Insert(SKUImageEntity entity)
        {
            try
            {
                var paras = new List<SqlParameter>
                {
                    new SqlParameter("@SKUID", entity.SKUID),
                    new SqlParameter("@ImagePath", entity.ImagePath),
                    new SqlParameter("@Priority", entity.Priority)
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

        public static bool Delete(int skuId, int imageId)
        {
            try
            {
                var paras = new[] { 
                    new SqlParameter("@SKUID", skuId),
                    new SqlParameter("@ImageID", imageId) 
                };

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
