using System.Collections.Generic;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class DeveloperBiz
    {
        /// <summary>
        /// Tìm kiếm và phân trang danh sách nhà phát triển
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<DeveloperEntity> ListAll(string keyword)
        {
            return DeveloperDao.ListAll(keyword);
        }

        /// <summary>
        /// Lấy thông tin nhà phát triển
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DeveloperEntity GetById(int id)
        {
            return DeveloperDao.GetById(id);
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin nhà phát triển
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(DeveloperEntity entity)
        {
            return DeveloperDao.Save(entity);
        }

        /// <summary>
        /// Xóa thông tin nhà phát triển
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete(int id)
        {
            return DeveloperDao.Delete(id);
        }
    }
}
