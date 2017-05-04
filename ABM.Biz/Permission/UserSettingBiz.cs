using System.Collections.Generic;
using System.Globalization;
using ABM.Common;
using ABM.Dao.Permission;
using ABM.Entity.Permission;

namespace ABM.Biz.Permission
{
    public class UserSettingBiz
    {
        public static List<UserSettingEntity> ListByUserDefinitionId(UserSettingEntity entity)
        {
            return UserSettingDao.ListByUserDefinitionId(entity);
        }

        /// <summary>
        /// Bước 1: Xóa UserSetting theo UserId & UserDefinitionId
        /// Bước 2: Tạo mới UserSetting theo UserDefinitionId
        /// </summary>
        /// <param name="entity"></param>
        public static void Save(UserSettingEntity entity)
        {
            var userSetting = new UserSettingEntity { UserId = entity.UserId, UserDefinitionId = entity.UserDefinitionId };

            if (entity.LstId != null && entity.LstId.Count > 0)
            {
                UserSettingDao.Delete(userSetting);
                foreach (var menuId in entity.LstId)
                {
                    userSetting.Value = menuId.ToString(CultureInfo.InvariantCulture);
                    UserSettingDao.Save(userSetting);
                }
            }
            else
            {
                UserSettingDao.Delete(userSetting);

                userSetting.Value = entity.Value;
                UserSettingDao.Save(userSetting);  
            }
            
        }
    }
}
