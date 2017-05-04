using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABM.Entity.Permission
{
    public class SKUFileEntity : BaseEntity
    {
        public int FileID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int SKUID { get; set; }
    }
}
