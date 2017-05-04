using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public JsonResponse ListUser([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                model.Keyword = string.IsNullOrEmpty(model.Keyword) ? string.Empty : model.Keyword;

                var totalRecords = 0;
                var users = UserBiz.ListPagination(model, out totalRecords);                

                jsonResponse.Success   = true;
                jsonResponse.Data      = users;
                jsonResponse.PagerInfo = string.Format(ABM.Resources.vi_VN.Pager_Info_User, totalRecords);
                jsonResponse.Pager     = PagerHelper.PageLinks(model.PageIndex, model.PageSize, totalRecords, Constants.DefaultPageStep,
                                            string.Format(ABM.Resources.vi_VN.Pager_User, "{0}"));
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse ListUserByStatus()
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var users = UserBiz.GetAllByStatus();

                jsonResponse.Success = true;
                jsonResponse.Data    = users;
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        } 


        [HttpPost]
        public JsonResponse ListUserByGroupId([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var users = UserBiz.ListByGroupId(model.AdminGroupId);
                for (var i = 0; i < users.Count; i++)
                    users[i].ItemIndex = Utils.ItemIndex(i, Constants.DefaultPageIndex, Constants.DefaultMaxPageSize);

                jsonResponse.Success = true;
                jsonResponse.Data    = users;                
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        } 

        [HttpPost]
        public JsonResponse Action([FromBody]UserEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)                                
                {
                    case Constants.ActionAddUserInGroup:
                        if (entity.AdminGroupId > 0 && entity.LstId != null && entity.LstId.Count > 0)
                            foreach (var groupUser1 in entity.LstId.Select(userId => new GroupUserEntity { AdminGroupId = entity.AdminGroupId, AdminUserId = userId }))
                                GroupUserBiz.Save(groupUser1);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionRemoveUserInGroup:
                        var groupUser2 = new GroupUserEntity { AdminGroupId = entity.AdminGroupId, AdminUserId = entity.AdminUserId };
                        jsonResponse.Data = GroupUserBiz.Delete(groupUser2);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionSave:
                        jsonResponse.Success = UserBiz.Save(entity);
                        break;

                    case Constants.ActionGetById:
                        jsonResponse.Data = UserBiz.GetById(entity.AdminUserId);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionChangePassword:
                        if (!string.IsNullOrEmpty(entity.Password1) && !string.IsNullOrEmpty(entity.Password2) && entity.Password1 == entity.Password2)
                        {
                            entity.Password = entity.Password1;                            
                            UserBiz.ChangePassword(entity);
                            jsonResponse.Success = true;
                        }
                        else
                            jsonResponse.Success = false;
                        
                        break;

                    case Constants.ActionLocked:
                        ChangeStatus(entity.LstId, (int)StatusConfig.NotActive);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionUnLocked:
                        ChangeStatus(entity.LstId, (int)StatusConfig.Active);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionDelete:
                        UserBiz.Delete(entity.AdminUserId);
                        jsonResponse.Success = true;
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

        private void ChangeStatus(List<int> lstId, int status)
        {
            if (lstId != null && lstId.Count > 0)
            {
                foreach (var userId in lstId)
                {
                    var id = Utils.ToInt32(userId, 0);
                    if (id > 0)
                        UserBiz.ChangeStatus(id, status);
                }
            }
        }
    }
}
