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
    public class SKUsBiz
    {
        //=== Table ===//
        private const string Table = "THM_D2D_SKUs";
        private const string TableOrder = "SKUID DESC";
        private const string FieldList = "ItemIndex, SKUID, CategoryID, Code, Name, ShortName, NETPrice, VATPrice, NETPriceNPP, VATPriceNPP, isDeleted, SmallImage, IsHotProduct";

        /// <summary>
        /// Tìm kiếm và danh sách sản phẩm được phân trang
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static List<SKUsEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter = "1=1";
            if (!string.IsNullOrEmpty(model.Keyword))
                filter += string.Format(" AND ((Code LIKE N'%{0}%') OR (Name LIKE N'%{0}%') OR (ShortName LIKE N'%{0}%'))", model.Keyword);

            if (model.CategoryId > 0)
                filter += string.Format(" AND (CategoryID = {0})", model.CategoryId);

            if (model.Status > -1)
                filter += string.Format(" AND isDeleted = {0}", model.Status.Equals(1) ? true : false);

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var listSKU = DbCommon.ExecutePagination<SKUsEntity>(DbCommon.ConnectionString, Table, filter,
                                                                        FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);

            foreach (var skuEntity in listSKU)
                skuEntity.CategoryName = CategoryBiz.GetById(skuEntity.CategoryID).CategoryName;

            return listSKU;
        }


        #region GetById
        public static SKUsEntity GetById(int skuId)
        {
            return SKUsDao.GetById(skuId);
        }
        #endregion

        #region Insert
        public static int Insert(SKUsEntity entity)
        {
            return SKUsDao.Insert(entity);
        }
        #endregion

        #region Update
        public static int Update(SKUsEntity entity)
        {
            return SKUsDao.Update(entity);
        }

        public static void UpdateSmallImage(int skuId, string smallImage)
        {
            SKUsDao.UpdateSmallImage(skuId, smallImage);
        }

        #endregion

        #region Delete
        public static bool Delete(int sKUID)
        {
            return SKUsDao.Delete(sKUID);
        }
        #endregion

    }
}
