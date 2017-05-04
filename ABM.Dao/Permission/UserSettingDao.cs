using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class UserSettingDao
    {
        #region Constants

        //=== Store Proc ===//
        private const string SpGetUserDefinitionIdAndUserId = "[dbo].UserSetting_Get_By_UserDefinitionId_UserId";
        private const string SpActionInsert                 = "[dbo].UserSetting_Create";
        private const string SpActionDelete                 = "[dbo].UserSetting_Delete";
                    
        #endregion  

        #region Methods

        public static List<UserSettingEntity> ListByUserDefinitionId(UserSettingEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@UserDefinitionId", entity.UserDefinitionId),
                        new SqlParameter("@UserId", entity.UserId)                        
                    };

                return DbCommon.ExecuteList<UserSettingEntity>(DbCommon.ConnectionString, SpGetUserDefinitionIdAndUserId, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetUserDefinitionIdAndUserId, ex.Message));
            }
        }

        public static void Save(UserSettingEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionInsert, entity.UserId, entity.UserDefinitionId, entity.Value);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionInsert, ex.Message));
            }
        }

        public static bool Delete(UserSettingEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionDelete, entity.UserId, entity.UserDefinitionId);
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
