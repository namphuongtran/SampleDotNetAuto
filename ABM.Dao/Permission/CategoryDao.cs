using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ABM.Common;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class CategoryDao
    {
        #region Constants

        //=== Store Proc ===//
        private const string SpListAll         = "[dbo].Category_SelectAll";
        private const string SpGetById         = "[dbo].Category_GetById";
        private const string SpActionInsert    = "[dbo].Category_Create";
        private const string SpActionUpdate    = "[dbo].Category_Update";
        private const string SpActionDelete    = "[dbo].Category_Delete";        

        #endregion        

        #region Methods

        public static List<CategoryEntity> ListAll(string keyword)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@Keyword", keyword) };
                return DbCommon.ExecuteList<CategoryEntity>(DbCommon.ConnectionString, SpListAll, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListAll, ex.Message));
            }
        }

        public static CategoryEntity GetById(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@CategoryID", id) };                
                return DbCommon.ExecuteSingle<CategoryEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        public static bool Save(CategoryEntity entity)
        {
            var procedureName = entity.CategoryID > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var numberRows = 0;
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@ReferenceID", entity.ReferenceID),
                        new SqlParameter("@CategoryName", entity.CategoryName),                        
                        new SqlParameter("@ParentID", entity.ParentID),                        
                        new SqlParameter("@DisplayOrder", entity.DisplayOrder),
                        new SqlParameter("@ImagePath", entity.ImagePath),
                        new SqlParameter("@Description", entity.Description),
                        new SqlParameter("@isDeleted", entity.isDeleted)
                    };

                if (entity.CategoryID > 0)
                {
                    parameters.Add(new SqlParameter("@CategoryID", entity.CategoryID));
                    SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());
                }
                else
                    numberRows = (int) SqlHelper.ExecuteScalar(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());               

                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", procedureName, ex.Message));
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@CategoryID", id) };
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpActionDelete, parameters);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionDelete, ex.Message));
            }
        }

        #endregion
    }
}
