using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class ArticleController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResponse ListArticle([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var totalRecords = 0;
                jsonResponse.Success    = true;
                jsonResponse.Data       = ArticleBiz.ListPagination(model, out totalRecords);
                jsonResponse.PagerInfo  = string.Format("{0} bài viết", totalRecords);
                jsonResponse.Pager      = PagerHelper.PageLinks(model.PageIndex, model.PageSize, totalRecords, Constants.DefaultPageStep, model.Action != null
                                                ? string.Format(ABM.Resources.vi_VN.Pager_ArticleInMenu, "{0}") 
                                                : string.Format(ABM.Resources.vi_VN.Pager_Article, "{0}"));
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [System.Web.Mvc.HttpPost]
        public JsonResponse ListByCategory([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var articles = ArticleBiz.GetByCategoryStatus(model.CategoryId, Constants.Active);
                if (model.Level >= 1)
                    foreach (var articleEntity in articles)
                        articleEntity.ItemIndex = articleEntity.ItemIndex + 7 * model.Level;

                jsonResponse.Success = true;
                jsonResponse.Data    = articles;
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]ArticleEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        var username = HttpContext.Current.Session[Constants.SessionUsername].ToString();
                        if (entity.Status == (int)StatusConfig.Active)
                            entity.ApprovedBy = username;

                        entity.CreatedBy   = username;
                        entity.ImgAvatar   = entity.ImgAvatar;                        
                        entity.PublishOn   = Utils.ToDateTime(string.Format("{0} {1}", Utils.ValidDateTime(entity.PublishedDate).ToShortDateString(), entity.PublishedTime));

                        jsonResponse.Success = true;
                        jsonResponse.Data    = ArticleBiz.Save(entity);
                        break;

                    case Constants.ActionGetById:
                        var article = ArticleBiz.GetById(entity.ArticleId);
                        article.PublishedDate = Utils.FormatIn_DDMMYYYY(article.PublishOn);
                        article.PublishedTime = Utils.FormatIn_HHMM(article.PublishOn);

                        jsonResponse.Success = true;
                        jsonResponse.Data    = article;                        
                        break;

                    case Constants.ActionPublished:
                        jsonResponse.Success = ChangeStatus(entity.LstId, (int)StatusConfig.Active);
                        break;

                    case Constants.ActionRemove:
                        jsonResponse.Success = ChangeStatus(entity.LstId, (int)StatusConfig.NotActive);
                        break;

                    case Constants.ActionFocus:
                        jsonResponse.Success = ChangeStatus(entity.LstId, (int)StatusConfig.Focus);
                        break;

                    case Constants.ActionTop:
                        jsonResponse.Success = ChangeStatus(entity.LstId, (int)StatusConfig.Top);
                        break;

                    case Constants.ActionDelete:
                        jsonResponse.Success = ArticleBiz.Delete(entity.ArticleId);
                        break;                    
                }                
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        private bool ChangeStatus(List<int> lstId, int status)
        {
            if (lstId != null && lstId.Count > 0)
            {
                foreach (var articleId in lstId)
                {
                    var id = Utils.ToInt32(articleId, 0);
                    if (id > 0)
                        ArticleBiz.ChangeStatus(HttpContext.Current.Session[Constants.SessionUsername].ToString(), id, status);
                }
                return true;    
            }
            return false;
        }
    }
}

