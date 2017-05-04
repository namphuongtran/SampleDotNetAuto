using System;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class GroupController : ApiController
    {        
        [HttpPost]
        public JsonResponse ListGroup([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var totalRecords          = 0;
                jsonResponse.Success      = true;
                jsonResponse.Data         = GroupBiz.ListPagination(model, out totalRecords);
                jsonResponse.TotalRecords = totalRecords;
                jsonResponse.PagerInfo = string.Format(ABM.Resources.vi_VN.Pager_Info_Group, totalRecords);
                jsonResponse.Pager        = PagerHelper.PageLinks(model.PageIndex, model.PageSize, totalRecords, Constants.DefaultPageStep, 
                                                            string.Format(ABM.Resources.vi_VN.Pager_Group, "{0}"));                
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;    
        }

        [HttpPost]
        public JsonResponse Action([FromBody]GroupEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        jsonResponse.Data = GroupBiz.Save(entity);
                        break;
                    case Constants.ActionGetById:
                        jsonResponse.Data = GroupBiz.GetById(entity.AdminGroupId);
                        break;
                    case Constants.ActionDelete:
                        jsonResponse.Data = GroupBiz.Delete(entity.AdminGroupId);
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
