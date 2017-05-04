using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class AdvDao
    {
        #region Constants

        //=== Store Proc ===//        
        private const string SpGetById      = "[dbo].Adv_GetById";
        private const string SpActionInsert = "[dbo].Adv_Create";
        private const string SpActionUpdate = "[dbo].Adv_Update";
        private const string SpActionDelete = "[dbo].Adv_Delete";

        #endregion

        #region Methods

        /// <summary>
        /// Lấy thông tin quảng cáo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AdvEntity GetById(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@AdvId", id) };
                return DbCommon.ExecuteSingle<AdvEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin quảng cáo
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(AdvEntity entity)
        {
            var procedureName = entity.AdvId > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@TypeId", entity.TypeId),
                        new SqlParameter("@Priority", entity.Priority),
                        new SqlParameter("@ImagePath", entity.ImagePath),
                        new SqlParameter("@Url", entity.Url)                        
                    };

                if (entity.AdvId > 0)
                    parameters.Add(new SqlParameter("@AdvId", entity.AdvId));

                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", procedureName, ex.Message));
            }
        }

        /// <summary>
        /// Xóa quảng cáo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@AdvId", id) };
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, SpActionDelete, parameters);
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
