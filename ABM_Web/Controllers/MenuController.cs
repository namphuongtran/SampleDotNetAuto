using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class MenuController : ApiController
    {
        [HttpPost]
        public JsonResponse Dashboard()
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var statistics = GroupBiz.DashboardSystemAll();

                var lstInfoBlocks = new List<InfoBlockEntity>();

                var lstMenu = MenuBiz.ListByParentIdAndUserId(Utils.ToInt32(ConfigurationManager.AppSettings["ROOT_MENU"]), Utils.ToInt32(HttpContext.Current.Session[Constants.SessionUserId]));
                if (lstMenu != null && lstMenu.Count > 0)
                {
                    foreach (var menu in lstMenu)
                    {
                        var ib = new InfoBlockEntity
                            {
                                Name        = menu.Name,
                                Description = menu.Description,
                                Icon        = menu.CtrlKey,
                                Url         = menu.Url,
                                ColorBottom = "bg-primary"
                            };

                        switch (UnicodeHelper.UnsignAndDash(menu.Name))
                        {
                            case "nhom":
                                ib.ColorTop    = "bg-primary";
                                ib.ColorBottom = "bg-danger";
                                ib.Statistics  = string.Format("{0} nhóm", statistics.Rows[0]["Group"]);
                                break;

                            case "thanh-vien":
                                ib.ColorTop   = "bg-success";
                                ib.Statistics = string.Format("{0} thành viên", statistics.Rows[0]["User"]);
                                break;

                            //case "chuc-nang":
                            //    ib.ColorTop = "bg-danger";
                            //    ib.Statistics = string.Format("{0} thành viên", statistics.Rows[0]["Menu"]);
                            //    break;

                            case "chuyen-muc":
                                ib.ColorTop = "bg-danger";
                                ib.Statistics = string.Format("{0} chuyên mục", statistics.Rows[0]["Category"]);
                                break;

                            case "san-pham":
                                ib.ColorTop = "bg-info";
                                ib.Statistics = string.Format("{0} sản phẩm", statistics.Rows[0]["Product"]);
                                break;

                            case "bai-viet":
                                ib.ColorTop = "bg-warning";
                                ib.Statistics = string.Format("{0} bài viết", statistics.Rows[0]["Article"]);
                                break;

                            case "anh":
                                ib.ColorTop = "bg-primary";
                                ib.ColorBottom = "bg-danger";
                                ib.Statistics = "Ảnh & Đối tác";
                                ib.Statistics = string.Format("{0} ảnh", statistics.Rows[0]["Adv"]);
                                break;                                                                                        
                        }     
                       
                        lstInfoBlocks.Add(ib);
                    }
                }

                jsonResponse.Success = true;
                jsonResponse.Data    = lstInfoBlocks;
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Navigator()
        {
            var jsonResponse = new JsonResponse();
            try
            {
                jsonResponse.Success = true;
                jsonResponse.Data    = MenuBiz.BuildNavigator(Utils.ToInt32(HttpContext.Current.Session[Constants.SessionUserId])); 
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse ListAll([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                model.Keyword = string.IsNullOrEmpty(model.Keyword) ? string.Empty : model.Keyword;

                var lstMenu             = MenuBiz.ListAll(model.Keyword);
                jsonResponse.Success    = true;
                jsonResponse.Data       = lstMenu;
                jsonResponse.PagerInfo  = string.Format(@ABM.Resources.vi_VN.Pager_Info_Menu, lstMenu.Count);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;    
        }
        
        [HttpPost]
        public JsonResponse ListByUserId()
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var lstMenu             = MenuBiz.ListByUserId(Utils.ToInt32(HttpContext.Current.Session[Constants.SessionUserId]));
                jsonResponse.Success    = true;
                jsonResponse.Data       = lstMenu;
                jsonResponse.PagerInfo  = string.Format(@ABM.Resources.vi_VN.Pager_Info_Menu, lstMenu.Count);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse ListByTypeIdAndUserId([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var lstMenu             = MenuBiz.ListByTypeIdAndUserId(model.TypeId, Utils.ToInt32(HttpContext.Current.Session[Constants.SessionUserId]));
                jsonResponse.Success    = true;
                jsonResponse.Data       = lstMenu;
                jsonResponse.PagerInfo  = string.Format(@ABM.Resources.vi_VN.Pager_Info_Menu, lstMenu.Count);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]MenuEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {                    
                    case Constants.ActionSave:
                        MenuBiz.Save(entity);
                        jsonResponse.Success = true;
                        break;

                    case Constants.ActionGetById:
                        var menu = MenuBiz.GetById(entity.AdminMenuId);                        

                        jsonResponse.Success = true;
                        jsonResponse.Data    = menu;
                        break;
                    
                    case Constants.ActionDelete:
                        jsonResponse.Success = MenuBiz.Delete(entity.AdminMenuId);
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
