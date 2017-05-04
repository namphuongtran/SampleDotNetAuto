using System.Collections.Generic;
using ABM.Common;
using ABM.Dao;
using ABM.Dao.Permission;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class ArticleBiz
    {
        //=== Table ===//
        private const string Table      = "Article";
        private const string TableOrder = "PublishOn ASC";
        private const string FieldList  = "ItemIndex, ArticleId, CategoryId, Title, Sapo, ImgAvatar, Url, ApprovedOn, PublishOn, ApprovedBy, LockedBy, [Status]";

        /// <summary>
        /// Tìm kiếm và danh sách bài viết được phân trang
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static List<ArticleEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter = "1=1";
            if (!string.IsNullOrEmpty(model.Keyword))
                filter += string.Format(" AND ((Title LIKE N'%{0}%') OR (Sapo LIKE N'%{0}%'))", model.Keyword);

            if (model.CategoryId > 0)
                filter += string.Format(" AND (CategoryId = {0} OR CategoryId IN (SELECT CategoryId FROM Category WHERE ParentId = {0}))", model.CategoryId);

            if (model.Status > -1)
                filter += string.Format(" AND [Status] = {0}", model.Status);

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            var lstArticle = DbCommon.ExecutePagination<ArticleEntity>(DbCommon.ConnectionString, Table, filter,
                                                                        FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);

            foreach (var articleEntity in lstArticle)
                articleEntity.CategoryName = CategoryBiz.GetById(articleEntity.CategoryId).CategoryName;

            return lstArticle;            
        }

        /// <summary>
        /// Danh sách bài viết theo chuyên mục
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static List<ArticleEntity> GetByCategoryStatus(int categoryId, int status)
        {
            return ArticleDao.GetByCategoryStatus(categoryId, status);
        }

        /// <summary>
        /// Thông tin chi tiết của bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ArticleEntity GetById(int id)
        {
            return ArticleDao.GetById(id);
        }

        /// <summary>
        /// Tạo mới hoặc Sửa bài viết
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(ArticleEntity entity)
        {
            return ArticleDao.Save(entity);
        }

        /// <summary>
        /// Chuyển trạng thái bài viết (Xuất bản | Gỡ bài)
        /// </summary>
        /// <param name="approvedBy"></param>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool ChangeStatus(string approvedBy, int id, int status)
        {
            return ArticleDao.ChangeStatus(approvedBy, id, status);
        }

        /// <summary>
        /// Xóa bài viết
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return ArticleDao.Delete(id);
        }
    }
}
