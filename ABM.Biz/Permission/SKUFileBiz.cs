using System;
using System.Collections.Generic;
using ABM.Dao.Permission;
using ABM.Entity.Permission;
using ABM.Entity;
using ABM.Dao;
using ABM.Common;

namespace ABM.Biz.Permission
{
    public class SKUFileBiz
    {
        #region List All
        
        //=== Table ===//
        private const string Table      = "SKU_File";
        private const string TableOrder = "FileID DESC";
        private const string FieldList  = "ItemIndex, FileID, FileName, FilePath";

        public static List<SKUFileEntity> ListAll(ModelParams model)
        {
            var totalRecords = 0;
            var filter = "1=1";
            if (model.SKUId > 0)
                filter += string.Format(" AND SKUID = {0}", model.SKUId);            

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var lstFile = DbCommon.ExecutePagination<SKUFileEntity>(DbCommon.ConnectionString, Table, filter, FieldList, TableOrder, model.PageIndex, Constants.DefaultMaxPageSize, out totalRecords);

            return lstFile;
        }

        #endregion

        #region Insert
        public static bool Insert(SKUFileEntity entity)
        {
            return SKUFileDao.Insert(entity);
        }
        #endregion

        #region Delete
        public static bool DeleteBySKUId(int skuId)
        {
            return SKUFileDao.DeleteBySKUId(skuId);
        }

        public static bool Delete(int fileId)
        {
            return SKUFileDao.Delete(fileId);
        }

        #endregion
    }
}
