using System.Collections.Generic;
using ABM.Dao;
using ABM.Dao.Permission;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class AdvBiz
    {
        #region Constants

        //=== Table ===//
        private const string Table      = "Adv";
        private const string TableOrder = "TypeId, [Priority]";
        private const string FieldList  = "ItemIndex, AdvId, TypeId, [Priority] , ImagePath, Url";
        
        #endregion

        #region Methods

        public static List<AdvEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter = "1=1";

            if (model.TypeId > -1)
                filter += string.Format(" AND TypeId = {0}", model.TypeId);

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            return DbCommon.ExecutePagination<AdvEntity>(DbCommon.ConnectionString, Table, filter,
                                                            FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);
        }


        public static AdvEntity GetById(int id)
        {
            return AdvDao.GetById(id);
        }

        public static bool Save(AdvEntity entity)
        {
            return AdvDao.Save(entity);
        }

        public static bool Delete(int id)
        {
            return AdvDao.Delete(id);
        }

        #endregion
    }
}
