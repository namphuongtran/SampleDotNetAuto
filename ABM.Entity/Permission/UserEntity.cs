using System;
using ABM.Common;

namespace ABM.Entity.Permission
{
    public class UserEntity : BaseEntity
    {
        public int AdminGroupId { get; set; }
        public int AdminUserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Mobile { get; set; }
        public int Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime LastLoggedOn { get; set; }
        
        public string ImageStatus
        {
            get
            {
                return Status.Equals((int)StatusConfig.Active)
                    ? "<button type='button' data-placement='top' title='Kích hoạt' class='btn btn-icon btn-default tip'><i class='icon-unlocked'></i></button>"
                    : "<button type='button' data-placement='top' title='Khóa' class='btn btn-icon btn-default tip'><i class='icon-lock'></i></button>";
            }
        }
    }
}
