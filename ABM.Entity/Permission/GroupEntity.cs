using ABM.Common;

namespace ABM.Entity.Permission
{
    public class GroupEntity : BaseEntity
    {
        public int AdminGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }

        public string ImageStatus {
            get
            {
                return Status.Equals((int) StatusConfig.Active)
                           ? "<button type='button' data-placement='top' title='Kích hoạt' class='btn btn-icon btn-default tip'><i class='icon-checkmark-circle'></i></button>"
                           : "<button type='button' data-placement='top' title='Tạm dừng' class='btn btn-icon btn-default tip'><i class='icon-cancel-circle'></i></button>";
            }
        }
    }
}
