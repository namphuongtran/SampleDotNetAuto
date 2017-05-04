using ABM.Common;

namespace ABM.Entity.Permission
{
    public class CategoryEntity : BaseEntity
    {        
        public int CategoryID { get; set; }
        public int ReferenceID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public int ParentID { get; set; }
        public int DisplayOrder { get; set; }
        public int Sys_Type_ID { get; set; }
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public bool isDeleted { get; set; }
        public int Level { get; set; }

        public string ImageStatus
        {
            get
            {
                return isDeleted
                    ? "<button type='button' data-placement='top' title='Kích hoạt' class='btn btn-icon btn-default tip'><i class='icon-checkmark-circle'></i></button>"
                    : "<button type='button' data-placement='top' title='Tạm dừng' class='btn btn-icon btn-default tip'><i class='icon-cancel-circle'></i></button>";
            }
        }
    }
}
