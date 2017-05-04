using System;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class DeveloperController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResponse ListDeveloperInMenu([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                model.Keyword = string.IsNullOrEmpty(model.Keyword) ? string.Empty : model.Keyword;
                
                jsonResponse.Success = true;
                jsonResponse.Data    = DeveloperBiz.ListAll(model.Keyword);                 
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]DeveloperEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        jsonResponse.Data = DeveloperBiz.Save(entity);
                        break;
                    case Constants.ActionGetById:
                        jsonResponse.Data = DeveloperBiz.GetById(entity.DeveloperId);
                        break;
                    case Constants.ActionDelete:
                        jsonResponse.Data = DeveloperBiz.Delete(entity.DeveloperId);
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
