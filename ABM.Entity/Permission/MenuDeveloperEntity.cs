namespace ABM.Entity.Permission
{
    public class MenuDeveloperEntity : BaseEntity
    {
        public int AdminMenuId { get; set; }
        public int DeveloperId { get; set; }
        public string DeveloperInfo { get; set; }
    }
}
