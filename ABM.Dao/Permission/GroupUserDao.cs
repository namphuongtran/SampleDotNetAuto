using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class GroupUserDao
    {
        #region Constants

        //=== Store Proc ===//        

        private const string SpListGroupByUserId = "[dbo].AdminGroupUser_GetGroupsByUserId";
        private const string SpListUserByGroupId = "[dbo].AdminGroupUser_GetUsersByGroupId";

        private const string SpActionInsert      = "[dbo].AdminGroupUser_Create";
        private const string SpActionDelete      = "[dbo].AdminGroupUser_Delete";

        #endregion    

        #region Methods

        /// <summary>
        /// Danh sách Nhóm theo thành viên
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<GroupUserEntity> GetListGroupByUserId(int userId)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@AdminUserId", userId) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteList<GroupUserEntity>(DbCommon.ConnectionString, SpListGroupByUserId, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListGroupByUserId, ex.Message));
            }
        }

        /// <summary>
        /// Danh sách Thành viên theo nhóm
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static List<GroupUserEntity> GetListUserByGroupId(int groupId)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@AdminGroupId", groupId) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteList<GroupUserEntity>(DbCommon.ConnectionString, SpListUserByGroupId, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpListUserByGroupId, ex.Message));
            }
        }

        /// <summary>
        /// Tạo mới Nhóm & Thành viên (Id)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(GroupUserEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionInsert, entity.AdminGroupId, entity.AdminUserId);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionInsert, ex.Message));
            }
        }

        /// <summary>
        /// Xóa Nhóm & Thành viên (Id)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Delete(GroupUserEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionDelete, entity.AdminGroupId, entity.AdminUserId);
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
