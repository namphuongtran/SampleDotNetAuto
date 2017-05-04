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
    public class SKURelatedBiz
    {
        #region List All By SKUId Main

        //=== Table ===//
        private const string Table      = "SKU_Related";
        private const string TableOrder = "SKUID DESC";
        private const string FieldList  = "ItemIndex, SKUIDMain, SKUID";

        public static List<SKURelatedEntity> ListAll(ModelParams model)
        {
            var totalRecords = 0;
            var filter = "1=1";            
            if (model.SKUId > 0)
                filter += string.Format(" AND SKUIDMain = {0}", model.SKUId);            

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var listSKURelated = DbCommon.ExecutePagination<SKURelatedEntity>(DbCommon.ConnectionString, Table, filter, FieldList, TableOrder, model.PageIndex, Constants.DefaultMaxPageSize, out totalRecords);
            foreach (var skuRelated in listSKURelated)
            {
                var skuEntity = SKUsBiz.GetById(skuRelated.SKUID);
                skuRelated.ProductCode      = skuEntity.Code;
                skuRelated.ProductName      = skuEntity.Name;
                skuRelated.ProductShortName = skuEntity.ShortName;                
                skuRelated.NETPrice         = skuEntity.NETPrice.ToString("N0");
                skuRelated.NETPriceNPP      = skuEntity.NETPriceNPP.ToString("N0");
            }

            return listSKURelated;            
        }        

        #endregion

        #region Insert

        public static bool Insert(SKURelatedEntity entity)
        {
            return SKURelatedDao.Insert(entity);
        }

        #endregion

        #region Delete
        
        public static bool Delete(SKURelatedEntity entity)
        {
            return SKURelatedDao.Delete(entity);
        }

        #endregion
    }
}

