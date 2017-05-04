using System;
using System.Collections.Generic;

namespace ABM.Entity
{
    public class ModelParams
    {
        public string AttachFile { get; set; }
        public int TypeId { get; set; }

        public int UserDefinitionId { get; set; }
        public int AdminGroupId { get; set; }
        public int AdminUserId { get; set; }
        public int CategoryId { get; set; }
        public int MenuId { get; set; }
        public int DeveloperId { get; set; }
        public int ArticleId { get; set; }
        public int SKUId { get; set; }
        public int SKUIdMain { get; set; }        
        public string Mobile { get; set; }

        // Common
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Level { get; set; }

        public string Keyword { get; set; }
        public string OrderBy { get; set; }
        public string Action { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<int> LstId { get; set; }

        // Login
        public string Username { get; set; }
        public string Password { get; set; }
        public string Otp { get; set; }        

        // Report
        public string AdvertisingType { get; set; }
        public string LstProduct { get; set; }
        public string LstBanner { get; set; }
        public string LstContract { get; set; }
        public string LstCustomer { get; set; }
        public string LstUnit { get; set; }

        // Error
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Priority { get; set; }
        public string Message { get; set; }
    }
}


