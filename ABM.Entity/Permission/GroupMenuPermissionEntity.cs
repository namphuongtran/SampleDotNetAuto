namespace ABM.Entity.Permission
{
    public class GroupMenuPermissionEntity : BaseEntity
    {
        public int AdminGroupId { get; set; }
        public int AdminMenuId { get; set; }
        public int Status { get; set; }
    }
}
