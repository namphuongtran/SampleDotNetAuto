using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class UserDao
    {
        #region Constants

        //=== Store Proc ===//                

        private const string SpGetByStatus           = "AdminUser_GetAllByStatuses";
        private const string SpGetByGroupIdAndStatus = "AdminUser_GetAllByStatusesByAdminGroupId";
        private const string SpActionGetById         = "AdminUser_GetById";
        private const string SpActionInsert          = "AdminUser_Create";
        private const string SpActionUpdate          = "AdminUser_Update";
        private const string SpActionDelete          = "AdminUser_Delete";        
                                                     
        private const string SpValidateUser          = "AdminUser_ValidateUser";
        private const string SpUpdatePassword        = "AdminUser_Update_Password";
        private const string SpUpdateStatus          = "AdminUser_Update_Status";
                                                     
        private const string SpCreateUserSetting     = "UserSetting_Create";
        private const string SpUpdateUserSetting     = "UserSetting_Update";        
        
        #endregion             

        #region Methods

        public static List<UserEntity> GetAllByStatus()
        {
            try
            {
                var parameters = new[] { new SqlParameter("@Statuses", (int)StatusConfig.Active) };

                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteList<UserEntity>(DbCommon.ConnectionString, SpGetByStatus, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetByStatus, ex.Message));
            }
        }

        public static List<UserEntity> ListByGroupId(int groupId)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@AdminGroupId", groupId), new SqlParameter("@Statuses", (int)StatusConfig.Active) };

                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteList<UserEntity>(DbCommon.ConnectionString, SpGetByGroupIdAndStatus, parameters);                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetByGroupIdAndStatus, ex.Message));
            }
        }
       
        public static bool Validate(ModelParams model)
        {            
            try
            {
                var parameters = new[] {                     
                        new SqlParameter("@Username", model.Username),
                        new SqlParameter("@Password", model.Password),                                                
                        new SqlParameter("@Statuses", (int) StatusConfig.Active), 
                    };

                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var userEntity = DbCommon.ExecuteSingle<UserEntity>(DbCommon.ConnectionString, SpValidateUser, parameters);
                if (userEntity != null && userEntity.AdminUserId > 0)
                {
                    HttpContext.Current.Session[Constants.SessionUserId]   = userEntity.AdminUserId;
                    HttpContext.Current.Session[Constants.SessionUsername] = userEntity.Username;
                    HttpContext.Current.Session[Constants.SessionFullname] = userEntity.Fullname;

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpValidateUser, ex.Message));
            }
        }

        public static UserEntity GetById(int id)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var parameters = new List<SqlParameter> { new SqlParameter("@AdminUserId", id) };
                return DbCommon.ExecuteSingle<UserEntity>(DbCommon.ConnectionString, SpActionGetById, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionGetById, ex.Message));
            }
        }

        public static bool Save(UserEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var procedureName = entity.AdminUserId > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var numberRows = 0;
                if (entity.AdminUserId > 0)
                    numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, procedureName,
                                                entity.AdminUserId, entity.Fullname, entity.Email, entity.Mobile);
                else
                    numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, procedureName,
                                                entity.Username, Utils.EncodePassword(entity.Password), entity.Fullname, entity.Email, entity.Mobile, (int)StatusConfig.Active);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", procedureName, ex.Message));
            }
        }

        public static bool Delete(int id)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);            
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionDelete, id);                
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionDelete, ex.Message));
            }
        }        

        public static void ChangePassword(UserEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);            
            try
            {                
                SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpUpdatePassword, entity.AdminUserId, Utils.EncodePassword(entity.Password));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpUpdatePassword, ex.Message));
            }
        }

        public static void ChangeStatus(int id, int status)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpUpdateStatus, id, status);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpUpdateStatus, ex.Message));
            }
        }        

        #endregion

        #region Cá nhân hóa
       
        public static bool CreateUserSetting(int userId, int userDefinitionId, string value)
        {
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@UserDefinitionId", userDefinitionId),                        
                        new SqlParameter("@Value", value)                        
                    };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpCreateUserSetting, parameters.ToArray());
                return numberRows > 0;                
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpCreateUserSetting, ex.Message));
            }
        }

        public static bool UpdateUserSetting(int userId, int userDefinitionId, string value)
        {
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@UserId", userId),
                        new SqlParameter("@UserDefinitionId", userDefinitionId),                        
                        new SqlParameter("@Value", value)                        
                    };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpUpdateUserSetting, parameters.ToArray());
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpUpdateUserSetting, ex.Message));
            }
        }

        #endregion
    }
}
