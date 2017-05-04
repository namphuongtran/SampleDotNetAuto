using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;
using System;
using System.Web.Http;

namespace ABM_Web.Controllers
{
    public class SKUController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResponse ListSKU([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var totalRecords = 0;
                jsonResponse.Success    = true;
                jsonResponse.Data       = SKUsBiz.ListPagination(model, out totalRecords);
                jsonResponse.PagerInfo  = string.Format(ABM.Resources.vi_VN.Pager_Info_SKU, totalRecords);
                jsonResponse.Pager      = PagerHelper.PageLinks(model.PageIndex, model.PageSize, totalRecords, Constants.DefaultPageStep, string.Format(ABM.Resources.vi_VN.Pager_SKU, "{0}"));
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [System.Web.Mvc.HttpPost]
        public JsonResponse Action([FromBody]SKUsEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var identitySKUId = 0;
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        if (entity.SKUID > 0)
                            identitySKUId = SKUsBiz.Update(entity);
                        else
                            identitySKUId = SKUsBiz.Insert(entity);
                        
                        jsonResponse.Success = true;
                        jsonResponse.Data = identitySKUId;
                        break;

                    case Constants.ActionGetById:
                        var product = SKUsBiz.GetById(entity.SKUID);

                        jsonResponse.Success = true;
                        jsonResponse.Data    = product;
                        break;

                    case Constants.ActionDelete:
                        jsonResponse.Success = SKUsBiz.Delete(entity.SKUID);
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
