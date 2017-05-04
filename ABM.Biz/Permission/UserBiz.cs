using System.Collections.Generic;
using ABM.Dao;
using ABM.Dao.Permission;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class UserBiz
    {
        //=== Table ===//
        private const string Table      = "AdminUser";
        private const string TableOrder = "AdminUserId DESC";
        private const string FieldList  = "ItemIndex, AdminUserId, Username, Password, Fullname, Email, Mobile, [Status], ModifiedOn";

        /// <summary>
        /// Tìm kiếm và phân trang thành viên
        /// </summary>        
        /// <param name="model"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static List<UserEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter = "1=1";
            if (!string.IsNullOrEmpty(model.Keyword))
                filter += string.Format(" AND ((Username LIKE N'%{0}%') OR (Email LIKE N'%{0}%'))", model.Keyword);            

            if (model.Status > -1)
                filter += string.Format(" AND [Status] = {0}", model.Status);

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var users = DbCommon.ExecutePagination<UserEntity>(DbCommon.ConnectionString, Table, filter, FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);
            
            return users;            
        }

        public static bool Validate(ModelParams model)
        {
            return UserDao.Validate(model);
        }

        public static UserEntity GetById(int id)
        {
            return UserDao.GetById(id);
        }

        public static bool Save(UserEntity entity)
        {
            return UserDao.Save(entity);
        }

        public static bool Delete(int id)
        {
            return UserDao.Delete(id);
        }

        public static void ChangePassword(UserEntity entity)
        {
            UserDao.ChangePassword(entity);
        }

        public static void ChangeStatus(int id, int status)
        {
            UserDao.ChangeStatus(id, status);
        }
        
        /// <summary>
        /// Lấy danh sách thành viên thuộc nhóm
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static List<UserEntity> ListByGroupId(int groupId)
        {
            return UserDao.ListByGroupId(groupId);            
        }

        public static List<UserEntity> GetAllByStatus()
        {
            return UserDao.GetAllByStatus();
        }

    }
}
