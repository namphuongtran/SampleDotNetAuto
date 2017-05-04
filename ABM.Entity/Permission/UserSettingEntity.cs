using System;

namespace ABM.Entity.Permission
{
    public class UserSettingEntity : BaseEntity
    {
        public int UserSettingId { get; set; }
        public int UserId { get; set; }
        public int UserDefinitionId { get; set; }
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
