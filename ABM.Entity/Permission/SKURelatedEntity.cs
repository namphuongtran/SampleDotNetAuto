using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM.Entity.Permission
{
    public class SKURelatedEntity : BaseEntity
    {
        public int SKUIDMain { get; set; }
        public int SKUID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductShortName { get; set; }
        public string NETPrice { get; set; }
        public string NETPriceNPP { get; set; }        
    }
}
