using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class GroupDao
    {
        #region Constants
        
        //=== Store Proc ===//        
        private const string SpDashboardSystemAll   = "[dbo].Dashboard_System_All";
        private const string SpGetById              = "[dbo].AdminGroup_GetById";
        private const string SpActionInsert         = "[dbo].AdminGroup_Create";
        private const string SpActionUpdate         = "[dbo].AdminGroup_Update";
        private const string SpActionDelete         = "[dbo].AdminGroup_Delete_v2";
               
        #endregion

        #region Methods

        public static DataTable DashboardSystemAll()
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return SqlHelper.ExecuteDataset(DbCommon.ConnectionString, SpDashboardSystemAll).Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpDashboardSystemAll, ex.Message));
            }
        }

        public static GroupEntity GetById(int id)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@AdminGroupId", id) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteSingle<GroupEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        public static bool Save(GroupEntity entity)
        {
            var procedureName = entity.AdminGroupId > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@Name", entity.Name),
                        new SqlParameter("@Description", entity.Description),
                        new SqlParameter("@Status", entity.Status),
                        new SqlParameter("@Priority", entity.Priority)
                    };

                if (entity.AdminGroupId > 0)
                    parameters.Add(new SqlParameter("@AdminGroupId", entity.AdminGroupId));

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
                var parameters = new[] { new SqlParameter("@AdminGroupId", id) };
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
