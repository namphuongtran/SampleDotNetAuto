using System.Collections.Generic;
using ABM.Common;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class GroupUserBiz
    {
        /// <summary>
        /// Lấy danh sách Nhóm và Thành viên theo loại (Enum GroupUserConfig)
        /// </summary>
        /// <param name="typeId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<GroupUserEntity> GetListGroupOrUserByType(int typeId, int id)
        {
            switch (typeId)
            {
                case (int)GroupUserConfig.Group:
                    return GroupUserDao.GetListGroupByUserId(id);
                        

                case (int)GroupUserConfig.User:
                    return GroupUserDao.GetListUserByGroupId(id);                        
            }
            return null;
        }

        /// <summary>
        /// Tạo mới Nhóm & Thành viên (Id)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(GroupUserEntity entity)
        {
            return GroupUserDao.Save(entity);
        }

        /// <summary>
        /// Xóa Nhóm & Thành viên (Id)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Delete(GroupUserEntity entity)
        {
            return GroupUserDao.Delete(entity);
        }
    }
}
