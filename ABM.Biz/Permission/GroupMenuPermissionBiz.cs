using System.Collections.Generic;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class GroupMenuPermissionBiz
    {
        /// <summary>
        /// Danh sách chức năng theo nhóm
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static List<GroupMenuPermissionEntity> GetListByGroupId(int groupId)
        {
            return GroupMenuPermissionDao.GetListByGroupId(groupId);
        }

        /// <summary>
        /// Lưu lại thông tin các chức năng được truy cập theo nhóm        
        ///     Bước 1: Xóa tất cả các quyền thuộc nhóm
        ///     Bước 2: Tạo mới theo nhóm và chức năng tương ứng
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool SavePermissionByGroupId(GroupMenuPermissionEntity entity)
        {
            try
            {
                if (entity.AdminGroupId > 0 && entity.LstId.Count > 0)
                {
                    GroupMenuPermissionDao.Delete(entity.AdminGroupId);

                    foreach (var menuId in entity.LstId)
                    {
                        var groupMenuPermission = new GroupMenuPermissionEntity
                            {
                                AdminGroupId = entity.AdminGroupId,
                                AdminMenuId  = menuId,
                                Status       = 0
                            };

                        GroupMenuPermissionDao.Save(groupMenuPermission);
                    }
                }

                return true;
            }
            catch { return false; }
        }
    }
}
