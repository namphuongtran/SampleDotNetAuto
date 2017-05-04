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
    public class SKUBiz
    {
        //=== Table ===//
        private const string Table      = "THM_D2D_SKUs";
        private const string TableOrder = "SKUID DESC";
        private const string FieldList  = "ItemIndex, SKUID, CategoryID, Code, Name, ShortName, NETPrice, VATPrice, NETPriceNPP, VATPriceNPP, isDeleted, SmallImage, IsHotProduct";

        /// <summary>
        /// Tìm kiếm và danh sách sản phẩm được phân trang
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static List<SKUsEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter  = "1=1";
            if (!string.IsNullOrEmpty(model.Keyword))
                filter += string.Format(" AND ((Code LIKE N'%{0}%') OR (Name LIKE N'%{0}%') OR (ShortName LIKE N'%{0}%'))", model.Keyword);

            if (model.CategoryId > 0)
                filter += string.Format(" AND (CategoryID = {0})", model.CategoryId);

            if (model.Status > -1)
                filter += string.Format(" AND isDeleted = {0}", model.Status.Equals(2) ? 0 : 1);  // 2 - Active| 1 - Not Active            

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var listSKU = DbCommon.ExecutePagination<SKUsEntity>(DbCommon.ConnectionString, Table, filter,
                                                                        FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);

            foreach (var skuEntity in listSKU)
                skuEntity.CategoryName = CategoryBiz.GetById(skuEntity.CategoryID).CategoryName;

            return listSKU;            
        }

        #region GetById
        public static SKUsEntity GetById(int sKUID)
        {
            return SKUDao.GetById(sKUID);
        }
        #endregion

        #region Insert
        public static bool Insert(SKUsEntity entity)
        {
            return SKUDao.Insert(entity);
        }
        #endregion

        #region Update
        public static bool Update(SKUsEntity entity)
        {
            return SKUDao.Update(entity);
        }
        #endregion

        #region Delete
        public static bool Delete(int sKUID)
        {
            return SKUDao.Delete(sKUID);
        }
        #endregion
    }
}
