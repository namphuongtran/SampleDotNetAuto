namespace ABM.Entity.Permission
{
    public class GroupUserEntity : BaseEntity
    {
        public int AdminGroupId { get; set; }
        public int AdminUserId { get; set; }
    }
}
