using ABM.Common;
using ABM.Dao;
using ABM.Dao.Permission;
using ABM.Entity;
using ABM.Entity.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM.Biz.Permission
{
    public class SKUImageBiz
    {
        #region List All
        
        //=== Table ===//
        private const string Table      = "SKU_Image";
        private const string TableOrder = "Priority ASC";
        private const string FieldList  = "ItemIndex, ImageID, ImagePath, Priority";

        public static List<SKUImageEntity> ListAll(ModelParams model)
        {
            var totalRecords = 0;
            var filter = "1=1";
            if (model.SKUId > 0)
                filter += string.Format(" AND SKUID = {0}", model.SKUId);            

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var lstImage = DbCommon.ExecutePagination<SKUImageEntity>(DbCommon.ConnectionString, Table, filter, FieldList, TableOrder, model.PageIndex, Constants.DefaultMaxPageSize, out totalRecords);
            return lstImage;
        }

        #endregion

        #region Insert
        public static bool Insert(SKUImageEntity entity)
        {
            return SKUImageDao.Insert(entity);
        }
        #endregion

        #region Delete
        public static bool DeleteBySKUId(int skuId)
        {
            return SKUImageDao.DeleteBySKUId(skuId);
        }

        public static bool Delete(int skuId, int imageId)
        {
            return SKUImageDao.Delete(skuId, imageId);
        }

        #endregion
    }
}
