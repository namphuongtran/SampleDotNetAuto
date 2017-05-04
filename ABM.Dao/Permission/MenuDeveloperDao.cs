using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class MenuDeveloperDao
    {
        #region Constants

        //=== Store Proc ===//
        private const string SpListByMenuId             = "[dbo].AdminMenu_Developer_Select_By_AdminMenuId";
        private const string SpActionInsert             = "[dbo].AdminMenu_Developer_Create";
        private const string SpActionDeleteAllByMenuId  = "[dbo].AdminMenu_Developer_DeleteAllByMenuId";

        #endregion      

        #region Methods

        public static List<MenuDeveloperEntity> ListByMenuId(int menuId)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@AdminMenuId", menuId) };

                var list = DbCommon.ExecuteList<MenuDeveloperEntity>(DbCommon.ConnectionString, SpListByMenuId, parameters);
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListByMenuId, ex.Message));
            }
        }

        public static bool Save(MenuDeveloperEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionInsert, entity.AdminMenuId, entity.DeveloperId, entity.DeveloperInfo);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionInsert, ex.Message));
            }
        }

        public static bool DeleteAllByMenuId(int menuId)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionDeleteAllByMenuId, menuId);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionDeleteAllByMenuId, ex.Message));
            }
        }       

        #endregion   
    }
}
