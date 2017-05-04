using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ABM.Common;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class DeveloperDao
    {
        #region Constants

        //=== Store Proc ===//
        private const string SpListSearch   = "[dbo].Developer_Search";
        private const string SpGetById      = "[dbo].Developer_GetById";
        private const string SpActionInsert = "[dbo].Developer_Create";
        private const string SpActionUpdate = "[dbo].Developer_Update";
        private const string SpActionDelete = "[dbo].Developer_Delete";

        #endregion

        #region Methods

        public static List<DeveloperEntity> ListAll(string keyword)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@Keyword", keyword) };
                return DbCommon.ExecuteList<DeveloperEntity>(DbCommon.ConnectionString, SpListSearch, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListSearch, ex.Message));
            }
        }

        public static DeveloperEntity GetById(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@DeveloperId", id) };
                return DbCommon.ExecuteSingle<DeveloperEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        public static bool Save(DeveloperEntity entity)
        {
            var procedureName = entity.DeveloperId > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@PositionId", entity.PositionId),
                        new SqlParameter("@Status", entity.Status),
                        new SqlParameter("@Name", entity.Name),
                        new SqlParameter("@Description", entity.Description)
                        //new SqlParameter("@ImageAvatar", entity.ImageAvatar),
                        //new SqlParameter("@Birthday", entity.Birthday)
                    };                

                if (entity.DeveloperId > 0)
                    parameters.Add(new SqlParameter("@DeveloperId", entity.DeveloperId));

                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());
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
                var parameters = new[] { new SqlParameter("@DeveloperId", id) };
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
