using System.Collections.Generic;
using System.Data;
using ABM.Dao;
using ABM.Dao.Permission;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class GroupBiz
    {
        #region Constants

        //=== Table ===//
        private const string Table      = "AdminGroup";
        private const string TableOrder = "[Priority]";
        private const string FieldList  = "ItemIndex, AdminGroupId, Name, Description, [Priority], [Status]";

        #endregion

        #region Methods

        /// <summary>
        /// Thống kê chung của hệ thống
        /// </summary>
        /// <returns></returns>
        public static DataTable DashboardSystemAll()
        {
            return GroupDao.DashboardSystemAll();
        }

        /// <summary>
        /// Danh sách tìm kiếm và phân trang nhóm
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static List<GroupEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter = string.IsNullOrEmpty(model.Keyword) ? "1=1" : string.Format("Name LIKE N'%{0}%'", model.Keyword); 

            if (model.Status > -1)
                filter += string.Format(" AND [Status] = {0}", model.Status);            

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            return DbCommon.ExecutePagination<GroupEntity>(DbCommon.ConnectionString, Table, filter,
                                                            FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);            
        }

        /// <summary>
        /// Lấy thông tin nhóm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GroupEntity GetById(int id)
        {
            return GroupDao.GetById(id);
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin nhóm
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(GroupEntity entity)
        {
            return GroupDao.Save(entity);
        }

        /// <summary>
        /// Xóa nhóm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return GroupDao.Delete(id);
        }

        #endregion
    }
}
