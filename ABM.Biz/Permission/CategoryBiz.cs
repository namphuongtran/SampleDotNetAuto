using System.Collections.Generic;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class CategoryBiz
    {
        /// <summary>
        /// Cây đệ qui chuyên mục
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<CategoryEntity> ListAll(string keyword)
        {
            return CategoryDao.ListAll(keyword);
        }

        /// <summary>
        /// Lấy thông tin chuyên mục
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static CategoryEntity GetById(int id)
        {
            return CategoryDao.GetById(id);
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin chuyên mục
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(CategoryEntity entity)
        {
            return CategoryDao.Save(entity);
        }

        // Xóa chuyên mục
        public static bool Delete(int id)
        {
            return CategoryDao.Delete(id);
        }
    }
}
