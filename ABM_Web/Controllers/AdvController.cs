using System;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class AdvController : ApiController
    {
        [HttpPost]
        public JsonResponse ListAdv([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var totalRecords = 0;
                jsonResponse.Success    = true;
                jsonResponse.Data       = AdvBiz.ListPagination(model, out totalRecords);
                jsonResponse.PagerInfo  = string.Format(ABM.Resources.vi_VN.Pager_Info_Adv, totalRecords);
                jsonResponse.Pager      = PagerHelper.PageLinks(model.PageIndex, model.PageSize, totalRecords, Constants.DefaultPageStep, string.Format(ABM.Resources.vi_VN.Pager_Adv, "{0}"));
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]AdvEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:                        
                        jsonResponse.Data    = AdvBiz.Save(entity);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionGetById:
                        var adv = AdvBiz.GetById(entity.AdvId);
                        jsonResponse.Success = true;
                        jsonResponse.Data    = adv;
                        break;
                    
                    case Constants.ActionDelete:
                        jsonResponse.Success = AdvBiz.Delete(entity.AdvId);
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
