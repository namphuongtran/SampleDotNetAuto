using System.Collections.Generic;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class MenuDeveloperBiz
    {
        /// <summary>
        /// Lấy danh sách nhà phát triển theo MenuId
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static List<MenuDeveloperEntity> ListByMenuId(int menuId)
        {
            return MenuDeveloperDao.ListByMenuId(menuId);
        }

        /// <summary>
        /// Tạo mới thông tin nhà phát triển
        /// </summary>        
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(MenuDeveloperEntity entity)
        {
            return MenuDeveloperDao.Save(entity);
        }

        /// <summary>
        /// Xóa tất cả nhà phát triển theo MenuId
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public static bool DeleteAllByMenuId(int menuId)
        {
            return MenuDeveloperDao.DeleteAllByMenuId(menuId);
        }
    }
}
