using System;
using System.Linq;
using ABM.Common;

namespace ABM.Entity.Permission
{
    public class MenuEntity : BaseEntity
    {
        public int AdminMenuId { get; set; }
        public int TypeId { get; set; }
        public int ParentId { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string CtrlKey { get; set; }
        public string Description { get; set; }
        public string CtrlSource { get; set; }
        public string Params { get; set; }
        public string Url { get; set; }
        public string GuideLink { get; set; }
        public int IsDefault { get; set; }        
        public DateTime CreatedDate { get; set; }

        public string FormatIsDefault { get; set; }        
        public string ImageStatus
        {
            get
            {
                return Status.Equals((int)StatusConfig.Active)
                    ? "<button type='button' data-placement='top' title='Kích hoạt' class='btn btn-icon btn-default tip'><i class='icon-checkmark-circle'></i></button>"
                    : "<button type='button' data-placement='top' title='Tạm dừng' class='btn btn-icon btn-default tip'><i class='icon-cancel-circle'></i></button>";
            }
        }

        // User Setting
        public int Level { get; set; }
        public int DateCount { get; set; }
        public string Icon { get { return string.Format("<button type='button' class='btn btn-icon btn-default'><i class='{0}'></i></button>", CtrlKey); } }
        public string IconStatus { get { return DateCount > 30 ? Utils.FormatIn_DDMMYYYY(CreatedDate) : string.Format("<span class='label label-danger'>{0} ngày trước</span>", DateCount); } }
        public string SortId { get; set; }
        public string ClassId {
            get {
                var classes = string.Empty;
                if (!string.IsNullOrEmpty(SortId))
                {
                    var lstClass = SortId.Split('/');
                    classes = lstClass.Where(c => !string.IsNullOrEmpty(c)).Aggregate(classes, (current, c) => current + string.Format("m{0} ", c));
                }
                return classes;
            }
        }
        
        public string Tutorial { get; set; }
        public string Developers { get; set; }
    }
}
