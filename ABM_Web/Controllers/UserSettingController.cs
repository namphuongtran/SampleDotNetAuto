using System;
using System.Web;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class UserSettingController : ApiController
    {
        [HttpPost]
        public JsonResponse ListByUserDefinitionId([FromBody]UserSettingEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var userSetting = new UserSettingEntity 
                        { 
                            UserId = entity.UserId > 0 ? entity.UserId : Utils.ToInt32(HttpContext.Current.Session[Constants.SessionUserId]), 
                            UserDefinitionId = entity.UserDefinitionId 
                        };

                jsonResponse.Success = true;
                jsonResponse.Data    = UserSettingBiz.ListByUserDefinitionId(userSetting);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }
        
        [HttpPost]
        public JsonResponse Action([FromBody]UserSettingEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        entity.UserId = Utils.ToInt32(HttpContext.Current.Session[Constants.SessionUserId]);                        
                        UserSettingBiz.Save(entity);
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
