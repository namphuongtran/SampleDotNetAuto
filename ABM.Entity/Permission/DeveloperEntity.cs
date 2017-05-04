using System;

namespace ABM.Entity.Permission
{
    public class DeveloperEntity : BaseEntity
    {
        public int DeveloperId { get; set; }
        public int PositionId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageAvatar { get; set; }
        public DateTime Birthday { get; set; }

        public string PositionName {
            get
            {
                switch (PositionId)
                {
                    case 1:
                        return "ASD Division Leader";
                    case 2:
                        return "Team Leader";
                    case 3:
                        return "Senior Developer";
                    case 4:
                        return "Technical Leader";
                    case 5:
                        return "Developer";
                    case 6:
                        return "Tester";
                    case 7:
                        return "Khác";                    
                }
                return string.Empty;
            }
        }
    }
}
