using System;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class CategoryController : ApiController
    {        
        [HttpPost]
        public JsonResponse ListAll([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                model.Keyword = string.IsNullOrEmpty(model.Keyword) ? string.Empty : model.Keyword;

                var lstCategory         = CategoryBiz.ListAll(model.Keyword);
                jsonResponse.Success    = true;
                jsonResponse.Data       = lstCategory;
                jsonResponse.PagerInfo  = string.Format(ABM.Resources.vi_VN.Pager_Info_Category, lstCategory.Count);
            }
            catch (Exception ex)
            {       
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]CategoryEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        jsonResponse.Data = CategoryBiz.Save(entity);
                        break;
                    case Constants.ActionGetById:
                        jsonResponse.Data = CategoryBiz.GetById(entity.CategoryID);
                        break;
                    case Constants.ActionDelete:
                        jsonResponse.Data = CategoryBiz.Delete(entity.CategoryID);
                        break;
                }

                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }
    }
}
