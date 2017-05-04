using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;
using System;
using System.Web.Http;

namespace ABM_Web.Controllers
{
    public class SKURelatedController : ApiController
    {
        [HttpPost]
        public JsonResponse ListAll([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                jsonResponse.Success = true;
                jsonResponse.Data    = SKURelatedBiz.ListAll(model);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]SKURelatedEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:                        
                        jsonResponse.Success = SKURelatedBiz.Insert(entity);;
                        break;

                    case Constants.ActionDelete:
                        jsonResponse.Success = SKURelatedBiz.Delete(entity);
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
    }
}
