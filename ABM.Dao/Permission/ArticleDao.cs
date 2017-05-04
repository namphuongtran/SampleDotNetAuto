using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ABM.Common;
using ABM.Entity.Permission;

namespace ABM.Dao.Permission
{
    public class ArticleDao
    {
        #region Constants
        
        //=== Store Proc ===//        
        
        private const string SpGetByCategoryStatus  = "[dbo].Article_GetByCategory_Status";
        private const string SpGetById              = "[dbo].Article_GetById";
        private const string SpActionInsert         = "[dbo].Article_Create";
        private const string SpActionUpdate         = "[dbo].Article_Update";
        private const string SpActionUpdateStatus   = "[dbo].Article_Update_Status";
        private const string SpActionUpdateUrl      = "[dbo].Article_Update_Url";
        private const string SpActionDelete         = "[dbo].Article_Delete";

        #endregion      

        #region Methods

        public static List<ArticleEntity> GetByCategoryStatus(int categoryId, int status)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@CategoryId", categoryId), new SqlParameter("@Status", status) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteList<ArticleEntity>(DbCommon.ConnectionString, SpGetByCategoryStatus, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }

        public static ArticleEntity GetById(int id)
        {
            try
            {
                var parameters = new[] { new SqlParameter("@ArticleId", id) };
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                return DbCommon.ExecuteSingle<ArticleEntity>(DbCommon.ConnectionString, SpGetById, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpGetById, ex.Message));
            }
        }
        
        public static bool Save(ArticleEntity entity)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var procedureName = entity.ArticleId > 0 ? SpActionUpdate : SpActionInsert;
            try
            {
                var numberRows = 0;

                var parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@CategoryId", entity.CategoryId),
                        new SqlParameter("@Title", entity.Title),
                        new SqlParameter("@Url", string.Empty),
                        new SqlParameter("@Sapo", entity.Sapo),
                        new SqlParameter("@Body", entity.Body.Replace("/Data/FileManager/", ConfigurationManager.AppSettings["Domain"] + "/Data/FileManager/")),
                        new SqlParameter("@Source", entity.Source),
                        new SqlParameter("@ImgAvatar", entity.ImgAvatar),
                        new SqlParameter("@PublishOn", entity.PublishOn),
                        new SqlParameter("@Status", entity.Status)
                    };

                if (entity.ArticleId > 0)
                {
                    parameters.Add(new SqlParameter("@ArticleId", entity.ArticleId));
                    parameters.Add(new SqlParameter("@EditedBy", entity.EditedBy));
                    parameters.Add(new SqlParameter("@ApprovedBy", entity.ApprovedBy));
                    SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());                    
                }
                else
                {
                    parameters.Add(new SqlParameter("@CreatedBy", entity.CreatedBy));
                    numberRows = (int)SqlHelper.ExecuteScalar(DbCommon.ConnectionString, CommandType.StoredProcedure, procedureName, parameters.ToArray());                    
                }

                var tempId = entity.ArticleId > 0 ? entity.ArticleId : numberRows;
                if (tempId > 0)
                {
                    var url = string.Format("/a/{0}/{1}.htm", tempId, UnicodeHelper.UnsignAndDash(entity.Title));
                    SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionUpdateUrl, tempId, url);
                }

                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", procedureName, ex.Message));
            }
        }

        public static bool ChangeStatus(string approvedBy, int id, int status)
        {
            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            try
            {
                var numberRows = SqlHelper.ExecuteNonQuery(DbCommon.ConnectionString, SpActionUpdateStatus, approvedBy, id, status);
                return numberRows > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("{0}:: {1}", SpActionUpdateStatus, ex.Message));
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
                var parameters = new[] { new SqlParameter("@ArticleId", id) };
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
