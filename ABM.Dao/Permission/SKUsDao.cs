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
    public class SKUsDao
    {
        public SKUsDao()
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
        }

        private const string SpGetById          = "[dbo].SKUs_GetById";
        private const string SpInsert           = "[dbo].SKUs_Insert";
        private const string SpUpdate           = "[dbo].SKUs_Update";
        private const string SpUpdateSmallImage = "[dbo].SKUs_Update_SmallImage";
        private const string SpDelete           = "[dbo].SKUs_Delete";


        #region GetById
        public static SKUsEntity GetById(int skuId)
        {
            try
            {
                var paras = new[] { new SqlParameter("@SKUID", skuId) };                

                return DbCommon.ExecuteSingle<SKUsEntity>(DbCommon.ConnectionString, SpGetById, paras);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }            
        }
        #endregion
        
        #region Insert
        public static int Insert(SKUsEntity entity)
        {    
            try
            {
                var paras = new List<SqlParameter>
                {
                    new SqlParameter("@CategoryID", entity.CategoryID),
                    new SqlParameter("@Code", entity.Code),
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@ShortName", entity.ShortName),
                    new SqlParameter("@NETPrice", entity.NETPrice),
                    new SqlParameter("@VATPrice", entity.VATPrice),
                    new SqlParameter("@NETPriceNPP", entity.NETPriceNPP),
                    new SqlParameter("@VATPriceNPP", entity.VATPriceNPP),
                    new SqlParameter("@CreateBy", entity.CreateBy),
                    new SqlParameter("@isDeleted", entity.isDeleted),
                    new SqlParameter("@IsHotProduct", entity.IsHotProduct),
                    new SqlParameter("@DisplayOrder", entity.DisplayOrder),                    
                    new SqlParameter("@Description", entity.Description)
                };
                    
                var identityId = SqlHelper.ExecuteScalar(DbCommon.ConnectionString, CommandType.StoredProcedure, SpInsert, paras.ToArray());

                return Convert.ToInt32(identityId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            } 
        }
        #endregion
        
        #region Update
        public static int Update(SKUsEntity entity)
        {    
            try
            {
                var paras = new List<SqlParameter>
                {                    
                    new SqlParameter("@SKUID", entity.SKUID),
                    new SqlParameter("@CategoryID", entity.CategoryID),
                    new SqlParameter("@Code", entity.Code),
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@ShortName", entity.ShortName),                    
                    new SqlParameter("@NETPrice", entity.NETPrice),
                    new SqlParameter("@VATPrice", entity.VATPrice),
                    new SqlParameter("@NETPriceNPP", entity.NETPriceNPP),
                    new SqlParameter("@VATPriceNPP", entity.VATPriceNPP),
                    new SqlParameter("@UpdateBy", entity.UpdateBy),
                    new SqlParameter("@isDeleted", entity.isDeleted),
                    new SqlParameter("@IsHotProduct", entity.IsHotProduct),
                    new SqlParameter("@DisplayOrder", entity.DisplayOrder),
                    new SqlParameter("@Description", entity.Description)
                };

                var identityId = SqlHelper.ExecuteScalar(DbCommon.ConnectionString, CommandType.StoredProcedure, SpUpdate, paras.ToArray());

                return Convert.ToInt32(identityId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            } 
        }

        public static void UpdateSmallImage(int skuId, string smallImage)
        {
            try
            {
                var paras = new List<SqlParameter>
                {                    
                    new SqlParameter("@SKUID", skuId),
                    new SqlParameter("@SmallImage", smallImage)
                };

                SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpUpdateSmallImage, paras.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        #endregion
        
        #region Delete
        public static bool Delete(int sKUID)
        {
            try
            {
                var paras = new[] { new SqlParameter("@SKUID", sKUID)};

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
