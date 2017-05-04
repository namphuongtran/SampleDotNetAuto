using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class GroupMenuPermissionDao
    {
        #region Constants

        //=== Store Proc ===//        

        private const string SpGetByGroupId = "[dbo].AdminGroupMenuPermission_GetByAdminGroupId";  
        private const string SpActionInsert = "[dbo].AdminGroupMenuPermission_Create";
        private const string SpActionDelete = "[dbo].AdminGroupMenuPermission_Delete";

        #endregion      

        #region Methods

        public static List<GroupMenuPermissionEntity> GetListByGroupId(int groupId)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@AdminGroupId", groupId) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteList<GroupMenuPermissionEntity>(DbCommon.ConnectionString, SpGetByGroupId, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetByGroupId, ex.Message));
            }
        }
                
        public static bool Save(GroupMenuPermissionEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionInsert, entity.AdminGroupId, entity.AdminMenuId, entity.Status);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionInsert, ex.Message));
            }
        }

        public static bool Delete(int groupId)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionDelete, groupId);
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
