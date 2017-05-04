using System;
using System.Configuration;
using ABM.Common;

namespace ABM.Entity.Permission
{
    public class ErrorEntity : BaseEntity
    {
        public int ErrorId { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Message { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public string FormatCreatedDate
        {
            get { return Utils.FormatIn_HHMM_DDMMYYYY(ModifiedDate); }
        }

        //public string FormatSmallImage {
        //    get
        //    {
        //        return string.Format("{0}{1}?Type={2}&Url={3}&Size={4}",
        //            ConfigurationManager.AppSettings["DOMAIN"], ConfigurationManager.AppSettings["THUMBNAIL_IMAGE"],
        //            Constants.ThumbnailTypeError, Image, Constants.ThumbnailSizeSmallError);
        //    } 
        //}       

        public string FormatPriority { 
            get
            {
                switch (Priority)
                    {
                        case 1:
                            return "<span class='label label-danger'>Cao</span>";
                        case 2:
                            return "<span class='label label-success'>Bình thường</span>";
                        case 3:
                            return "<span class='label label-info'>Thấp</span>";
                    }
                return null;
            }
        }

        public string FormatNote
        {
            get
            {
                return !string.IsNullOrEmpty(Note)
                           ? string.Format("<button onclick='system.error.manipulate(systemConfig.action.getById, {0});' type='button' data-container='body' data-toggle='popover' data-placement='left' data-content='{1}' data-html='true' data-trigger='hover' title='Ghi chú' class='btn btn-default btn-icon'><i class='icon-bubble-dots2'></i></button>", ErrorId, Note)
                           : string.Format("<button onclick='system.error.manipulate(systemConfig.action.getById, {0});' type='button' data-placement='top' title='Ghi chú' class='btn btn-icon btn-default tip'><i class='icon-bubble-dots2'></i></button>", ErrorId);
            }
        }

        public string ImageStatus
        {
            get
            {
                return Status.Equals((int)StatusConfig.Active)
                           ? "<button type='button' data-placement='top' title='Chờ sử lý' class='btn btn-icon btn-default tip'><i class='icon-cancel-circle'></i></button>"
                           : "<button type='button' data-placement='top' title='Hoàn thành' class='btn btn-icon btn-default tip'><i class='icon-checkmark-circle'></i></button>";
            }
        }
    }
}
