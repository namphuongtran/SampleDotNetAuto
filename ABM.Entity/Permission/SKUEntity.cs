using ABM.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM.Entity.Permission
{
    public class SKUEntity : BaseEntity
    {
        public int SKUID { get; set; }
        public int CategoryID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SAP_SKU_DIVISION { get; set; }
        public double NETPrice { get; set; }
        public double VATPrice { get; set; }
        public double NETPriceNPP { get; set; }
        public double VATPriceNPP { get; set; }
        public string CreateDate { get; set; }
        public int CreateBy { get; set; }
        public string LastUpdate { get; set; }
        public int UpdateBy { get; set; }
        public bool isDeleted { get; set; }
        public string FriendlyName { get; set; }
        public string FriendlyDescription { get; set; }
        public string SmallImage { get; set; }
        public string LargeImage { get; set; }
        public bool IsHotProduct { get; set; }
        public int DisplayOrder { get; set; }
        public int DisplayHot { get; set; }
        public string Description { get; set; }

        public string CategoryName { get; set; }
        public string FormatLastUpdate { get { return Utils.FormatIn_HHMM_DDMMYYYY(Convert.ToDateTime(LastUpdate)); } }

        public string FormatSmallImage
        {
            get { return string.Format("{0}/{1}?&Url={2}&Size={3}", ConfigurationManager.AppSettings["DOMAIN"], ConfigurationManager.AppSettings["THUMBNAIL_IMAGE"], SmallImage, Constants.ImageSmallSize); }
        }

        public string ImageStatus
        {
            get { return IsHotProduct ? "<button type='button' data-placement='top' title='Nổi bật' class='btn btn-icon btn-default tip'><i class='icon-star4'></i></button>" : string.Empty; }
        }
    }
}
