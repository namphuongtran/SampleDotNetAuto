using System;
using System.Data.SqlClient;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class ErrorDao
    {
        #region Constants

        //=== Store Proc ===//        

        private const string SpGetById              = "[dbo].Error_GetById";
        private const string SpActionInsert         = "[dbo].Error_Create";
        private const string SpActionUpdateNote     = "[dbo].Error_Update_Note";
        private const string SpActionUpdateStatus   = "[dbo].Error_Update_Status";

        #endregion      

        #region Methods

        public static ErrorEntity GetById(int id)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@ErrorId", id) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteSingle<ErrorEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        public static bool Save(ErrorEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var procedureName = entity.ErrorId > 0 ? SpActionUpdateNote : SpActionInsert;
            try
            {
                var numberRows = entity.ErrorId > 0
                                 ? SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, procedureName, entity.ErrorId, entity.Note)
                                 : SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, procedureName,
                                                             entity.Priority, entity.Status, entity.FullName,
                                                             entity.Email, !string.IsNullOrEmpty(entity.Image) ? entity.Image : "no-image.jpg", entity.Message);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", procedureName, ex.Message));
            }
        }

        public static bool ChangeStatus(int id, int status)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionUpdateStatus, id, status);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionUpdateStatus, ex.Message));
            }
        }

        #endregion
    }
}
