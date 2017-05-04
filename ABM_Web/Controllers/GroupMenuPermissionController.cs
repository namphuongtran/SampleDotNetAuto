using System;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class GroupMenuPermissionController : ApiController
    {
        [HttpPost]
        public JsonResponse GetListByGroupId([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {                
                jsonResponse.Success = true;
                jsonResponse.Data    = GroupMenuPermissionBiz.GetListByGroupId(model.AdminGroupId);                
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse SavePermissionByGroupId([FromBody]GroupMenuPermissionEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {                
                jsonResponse.Success = GroupMenuPermissionBiz.SavePermissionByGroupId(entity);                
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
