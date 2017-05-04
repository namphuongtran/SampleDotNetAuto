using System;
using System.Configuration;
using ABM.Common;

namespace ABM.Entity.Permission
{
    public class ArticleEntity : BaseEntity
    {
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }        
        public string Title { get; set; }
        public string Sapo { get; set; }
        public string Body { get; set; }
        public string Source { get; set; }
        public string ImgAvatar { get; set; }
        public string Url { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EditedOn { get; set; }
        public DateTime ApprovedOn { get; set; }
        public DateTime PublishOn { get; set; }
        public string CreatedBy { get; set; }
        public string EditedBy { get; set; }
        public string ApprovedBy { get; set; }
        public string LockedBy { get; set; }
        public int Status { get; set; }

        public string CategoryUrl { get; set; }
        public string ArticleUrl { get; set; }
        public string CategoryName { get; set; }
        public string FormatPublishOn { get { return Utils.FormatIn_HHMM_DDMMYYYY(PublishOn); } }

        public string PublishedDate { get; set; }
        public string PublishedTime { get; set; }

        public string FormatSmallImage
        {
            get { return string.Format("{0}/{1}?&Url={2}&Size={3}", ConfigurationManager.AppSettings["DOMAIN"], ConfigurationManager.AppSettings["THUMBNAIL_IMAGE"], ImgAvatar, Constants.ImageSmallSize); }
        }   

        public string ImageStatus
        {
            get
            {
                switch (Status)
                {
                    case (int)StatusConfig.NotActive:
                        return "<button type='button' data-placement='top' title='Chờ duyệt' class='btn btn-icon btn-default tip'><i class='icon-cancel-circle'></i></button>";

                    case (int)StatusConfig.Active:
                        return "<button type='button' data-placement='top' title='Xuất bản' class='btn btn-icon btn-default tip'><i class='icon-checkmark-circle'></i></button>";                    

                    case (int)StatusConfig.Focus:
                        return "<button type='button' data-placement='top' title='Nổi bật' class='btn btn-icon btn-default tip'><i class='icon-star4'></i></button>";

                    case (int)StatusConfig.Top:
                        return "<button type='button' data-placement='top' title='Đầu trang' class='btn btn-icon btn-default tip'><i class='icon-arrow-up3'></i></button>";
                }
                return string.Empty;
            }
        }
    }
}
