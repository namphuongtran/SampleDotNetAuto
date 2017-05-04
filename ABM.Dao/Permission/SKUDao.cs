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
    public class SKUDao
    {
        public SKUDao()
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
        }
        
        private const string SpGetById = "[dbo].THM_D2D_SKUs_GetById";
        private const string SpInsert  = "[dbo].THM_D2D_SKUs_Insert";
        private const string SpUpdate  = "[dbo].THM_D2D_SKUs_Update";
        private const string SpDelete  = "[dbo].THM_D2D_SKUs_Delete";       
        
        #region GetById
        public static SKUsEntity GetById(int sKUID)
        {
            try
            {
                var paras = new[] { new SqlParameter("@SKUID", sKUID)};                

                return DbCommon.ExecuteSingle<SKUsEntity>(DbCommon.ConnectionString, SpGetById, paras);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }            
        }
        #endregion
        
        #region Insert
        public static bool Insert(SKUsEntity entity)
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
                    new SqlParameter("@DisplayHot", entity.DisplayHot),
                    new SqlParameter("@Description", entity.Description)
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
        
        #region Update
        public static bool Update(SKUsEntity entity)
        {    
            try
            {
                var paras = new List<SqlParameter>
                {
                    new SqlParameter("SKUID", entity.SKUID),
                    new SqlParameter("@CategoryID", entity.CategoryID),
                    new SqlParameter("@Code", entity.Code),
                    new SqlParameter("@Name", entity.Name),
                    new SqlParameter("@ShortName", entity.ShortName),
                    new SqlParameter("@NETPrice", entity.NETPrice),
                    new SqlParameter("@VATPrice", entity.VATPrice),
                    new SqlParameter("@NETPriceNPP", entity.NETPriceNPP),
                    new SqlParameter("@VATPriceNPP", entity.VATPriceNPP),
                    new SqlParameter("@LastUpdate", entity.LastUpdate),
                    new SqlParameter("@isDeleted", entity.isDeleted),
                    new SqlParameter("@IsHotProduct", entity.IsHotProduct),
                    new SqlParameter("@DisplayOrder", entity.DisplayOrder),
                    new SqlParameter("@DisplayHot", entity.DisplayHot),
                    new SqlParameter("@Description", entity.Description)
                };
                    
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpUpdate, paras.ToArray());

                return numberRows > 0;
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
