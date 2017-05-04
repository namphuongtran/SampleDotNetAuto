using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class MenuDao
    {
        #region Constants

        //=== Store Proc ===//
        private const string SpListAll              = "[dbo].AdminMenu_SelectAll_v2";
        private const string SpListByParentId       = "[dbo].AdminMenu_GetByParentIdAndUserId";
        private const string SpListByUserId         = "[dbo].AdminMenu_Select_By_AdminUserId";
        private const string SpListByTypeAndUserId  = "[dbo].AdminMenu_Select_By_TypeId_And_AdminUserId";
        
        private const string SpGetById              = "[dbo].AdminMenu_GetById";
        private const string SpActionInsert         = "[dbo].AdminMenu_Create_v2";
        private const string SpActionUpdate         = "[dbo].AdminMenu_Update_v2";
        private const string SpActionDelete         = "[dbo].AdminMenu_Delete";

        #endregion

        #region Methods

        /// <summary>
        /// Cây đệ qui chức năng
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListAll(string keyword)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@Keyword", keyword) };
                return DbCommon.ExecuteList<MenuEntity>(DbCommon.ConnectionString, SpListAll, parameters);                                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListAll, ex.Message));
            }
        }

        /// <summary>
        /// Danh sách chức năng gốc (ParentId = 0)
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="adminMenuId"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListByParentIdAndUserId(int parentId, int adminMenuId)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@ParentId", parentId), new SqlParameter("@AdminUserId", adminMenuId) };
                return DbCommon.ExecuteList<MenuEntity>(DbCommon.ConnectionString, SpListByParentId, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListByParentId, ex.Message));
            }
        }

        /// <summary>
        /// Danh sách cây đệ qui chức năng của thành viên được truy cập (Permission)
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListByUserId(int userId)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@AdminUserId", userId) };
                return DbCommon.ExecuteList<MenuEntity>(DbCommon.ConnectionString, SpListByUserId, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListByUserId, ex.Message));
            }
        }

        /// <summary>
        /// Cây đệ qui chức năng theo TypeId & AdminUserId (Personalization)
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListByTypeIdAndUserId(int typeId, int userId)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new[] { new SqlParameter("@TypeId", typeId), new SqlParameter("@AdminUserId", userId) };
                return DbCommon.ExecuteList<MenuEntity>(DbCommon.ConnectionString, SpListByTypeAndUserId, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListByTypeAndUserId, ex.Message));
            }
        }

        /// <summary>
        /// Lấy thông tin chức năng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MenuEntity GetById(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@AdminMenuId", id) };                
                return DbCommon.ExecuteSingle<MenuEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin chức năng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int Save(MenuEntity entity)
        {
            var procedureName = entity.AdminMenuId > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TypeId", entity.TypeId),
                        new SqlParameter("@ParentId", entity.ParentId),
                        new SqlParameter("@Priority", entity.Priority),
                        new SqlParameter("@Status", entity.Status),
                        new SqlParameter("@Name", entity.Name),
                        new SqlParameter("@CtrlKey", entity.CtrlKey),                        
                        new SqlParameter("@CtrlSource", entity.CtrlSource),
                        new SqlParameter("@Description", entity.Description),
                        new SqlParameter("@Params", entity.Params),
                        new SqlParameter("@Url", entity.Url),                        
                        new SqlParameter("@GuideLink", entity.GuideLink),                                                
                        new SqlParameter("@IsDefault", !string.IsNullOrEmpty(entity.FormatIsDefault))
                    };

                if (entity.AdminMenuId > 0)
                    parameters.Add(new SqlParameter("@AdminMenuId", entity.AdminMenuId));

                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var numberRows = SqlHelper.ExecuteScalar(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());
                return entity.AdminMenuId > 0 ? entity.AdminMenuId : (int) numberRows;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", procedureName, ex.Message));
            }
        }

        /// <summary>
        /// Xóa chức năng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@AdminMenuId", id) };
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpActionDelete, parameters);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionDelete, ex.Message));
            }
        }

        /// <summary>
        /// Thiết lập chức năng khi thành viên đăng nhập lần đầu tiên
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="username"></param>
        public static void SetDefaultMenu(int userId, string username)
        {
            
        }

        #endregion
    }
}
