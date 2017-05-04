using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM.Entity.Permission
{
    public class SKUImageEntity : BaseEntity
    {
        public int ImageID { get; set; }
        public int SKUID { get; set; }
        public string ImagePath { get; set; }
        public int Priority { get; set; }
    }
}
