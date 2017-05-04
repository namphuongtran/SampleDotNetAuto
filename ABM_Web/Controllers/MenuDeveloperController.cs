using System;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class MenuDeveloperController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResponse ListByMenuId([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                jsonResponse.Success = true;
                jsonResponse.Data    = MenuDeveloperBiz.ListByMenuId(model.MenuId);;
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [System.Web.Mvc.HttpPost]
        public JsonResponse Save([FromBody]MenuDeveloperEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                jsonResponse.Success = true;
                MenuDeveloperBiz.DeleteAllByMenuId(entity.AdminMenuId);
                jsonResponse.Data = MenuDeveloperBiz.Save(entity);
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
