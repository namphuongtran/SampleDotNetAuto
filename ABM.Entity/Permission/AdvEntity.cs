using System.Configuration;
using ABM.Common;

namespace ABM.Entity.Permission
{
    public class AdvEntity : BaseEntity
    {
        public int AdvId { get; set; }
        public int TypeId { get; set; }
        public int Priority { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }

        public string TypeName
        {
            get
            {
                switch (TypeId)
                {
                    case 1:
                        return "Header";
                    case 2:
                        return "Footer";
                    case 3:
                        return "Đối tác";
                    case 4:
                        return "Ảnh";
                }
                return string.Empty;
            }
        }

        public string FormatSmallImage
        {
            get { return string.Format("{0}/{1}?Url={2}&Size={3}", ConfigurationManager.AppSettings["DOMAIN"], ConfigurationManager.AppSettings["THUMBNAIL_IMAGE"], ImagePath, Constants.ImageSmallSize); }
        }       
    }
}
