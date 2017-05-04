using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ABM.Common;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class MenuBiz
    {
        #region Methods                

        /// <summary>
        /// Cây đệ qui chức năng
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListAll(string keyword)
        {
            return MenuDao.ListAll(keyword);
        }

        /// <summary>
        /// Chức năng gốc phục vụ cho việc hiển thị Dashboard
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="adminMenuId"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListByParentIdAndUserId(int parentId, int adminMenuId)
        {
            return MenuDao.ListByParentIdAndUserId(parentId, adminMenuId);
        }

        /// <summary>
        /// Danh sách chức năng thành viên được truy cập (Permission)
        ///     Từ AdminUserId => Nhóm của thành viên
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListByUserId(int userId)
        {
            return MenuDao.ListByUserId(userId);
        }

        private static List<MenuEntity> GetChildItems(IEnumerable<MenuEntity> lstMenu, MenuEntity parentItem)
        {
            try { return lstMenu.Where(m => m.ParentId == parentItem.AdminMenuId).ToList(); }
            catch { }
            return null;
        }

        /// <summary>
        /// Hiển thị danh sách chức năng (HTML) 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string BuildNavigator(int userId)
        {
            var sb = new StringBuilder();

            var lstMenu = MenuDao.ListByUserId(userId);
            if (lstMenu != null && lstMenu.Count > 0)
            {
                foreach (var menu in lstMenu)
                {
                    if (menu.ParentId != 0) continue;
                    var childList = GetChildItems(lstMenu, menu);
                    if (childList.Count > 0)
                    {
                        sb.AppendFormat("<li><a href='{0}'><span>{1}</span> <i class='{2}'></i></a><ul>", menu.Url, menu.Name, menu.CtrlKey);
                        sb.Append(Recursion(lstMenu, childList));
                        sb.Append("</ul></li>");
                    }
                    else
                        sb.AppendFormat("<li><a href='{0}'><span>{1}</span> <i class='{2}'></i></a>", menu.Url, menu.Name, menu.CtrlKey);
                }                
            }
            return sb.ToString();
        }
        
        private static string Recursion(IEnumerable<MenuEntity> lst, IEnumerable<MenuEntity> childLst)
        {
            var sb = new StringBuilder();
            foreach (var m in childLst)
            {
                var menuEntities = lst as IList<MenuEntity> ?? lst.ToList();

                var childLst2 = GetChildItems(menuEntities, m);
                if (childLst2.Count > 0)
                {
                    sb.AppendFormat("<li><a href='#'><span>{0}</span></a><ul>", m.Name);
                    sb.Append(Recursion(menuEntities, childLst2));
                    sb.Append("</ul></li>");
                }
                else
                    sb.AppendFormat("<li><a href='{0}'>{1}</a></li>", m.Url, m.Name);
            }
            return sb.ToString();
        } 

        /// <summary>
        /// Danh sách chức năng thành viên được truy cập (Personalization)
        ///     Từ AdminUserId => Nhóm của thành viên
        ///     TypeId => Loại chức năng (ABM, Booking, HĐCN, Thực chạy, Báo cáo Kênh)
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<MenuEntity> ListByTypeIdAndUserId(int typeId, int userId)
        {
            var lstMenu = MenuDao.ListByTypeIdAndUserId(typeId, userId);
            if (lstMenu != null && lstMenu.Count > 0)
            {
                foreach (var menu in lstMenu)
                {
                    // Developer
                    var lstDeveloper = MenuDeveloperBiz.ListByMenuId(menu.AdminMenuId);
                    var developer    = string.Empty;
                    if (lstDeveloper != null && lstDeveloper.Count > 0)
                        developer = lstDeveloper.Aggregate(developer, (current, d) => current + d.DeveloperInfo);

                    if (developer.Length > 0)
                        menu.Developers = string.Format("<ul class='message-list'>{0}</ul>", developer);    

                    // Article                    
                    var tutorial = string.Empty;
                    var articleId = Utils.ToInt32(menu.GuideLink);
                    if (articleId > 0)
                    {
                        var article = ArticleBiz.GetById(articleId);
                        if (article != null && !string.IsNullOrEmpty(article.Title))
                            tutorial = string.Format("<h6>{0} <small class='display-block'>{1}</small></h6><p>{2}</p>", article.Title, article.Sapo, article.Body);
                        menu.Tutorial = tutorial;    
                    }                    
                }                    
            }
            return lstMenu;
        }

        /// <summary>
        /// Lấy thông tin chức năng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MenuEntity GetById(int id)
        {
            return MenuDao.GetById(id);
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin chức năng
        /// 
        /// Bước 1: Lưu thông tin chức năng
        /// Bước 2: Xóa tất cả Nhà phát triển theo MenuId
        /// Bước 3: Thêm nhà phát triển vào theo MenuId tương ứng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static int Save(MenuEntity entity)
        {
            var menuId = MenuDao.Save(entity);
            if (entity.LstId != null && menuId > 0)
            {
                MenuDeveloperBiz.DeleteAllByMenuId(menuId);

                for (var index = 0; index < entity.LstId.Count; index++)
                {
                    var menuDeveloperEntity = new MenuDeveloperEntity
                        {
                            AdminMenuId     = menuId,
                            DeveloperId     = entity.LstId[index],
                            DeveloperInfo   = string.Format("<li>{0}</li>", entity.LstName[index])
                        };
                    MenuDeveloperBiz.Save(menuDeveloperEntity);
                }
            }

            return menuId;
        }        

        /// <summary>
        /// Xóa chức năng (Ẩn)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return MenuDao.Delete(id);
        }

        #endregion
    }
}
