using System;
using System.Configuration;

namespace ABM.Common
{   
    public class Constants
    {
        // Common
        public const string SessionIsLock   = "isLock";
        public const string SessionUserId   = "userid";
        public const string SessionSaleId   = "saleid";
        public const string SessionUsername = "username";
        public const string SessionFullname = "fullname";
        
        public const int OtpVerify  = 1;

        public const int Root       = 0;
        public const int NotActive  = 0;
        public const int Active     = 1;

        public const int DefaultPageIndex   = 1;
        public const int DefaultPageSize    = 15;
        public const int DefaultMaxPageSize = 100;
        public const int DefaultPageStep    = 5;      

        public const string AbmConnectionString         = "ABM_CONNECTION_STRING";
        public const string HdcnConnectionString        = "HDCN_CONNECTION_STRING";
        public const string BookingConnectionString     = "BOOKING_CONNECTION_STRING";
        public const string ReportingdbConnectionString = "REPORTINGDB_CONNECTION_STRING";


        public const string ActionInit           = "init";
        public const string ActionSave           = "save";
        public const string ActionGetById        = "getById";
        public const string ActionDelete         = "delete";
        public const string ActionPublished      = "published";
        public const string ActionRemove         = "remove";
        public const string ActionFocus          = "focus";
        public const string ActionTop            = "top";
        public const string ActionAddUserInGroup    = "addUserInGroup";
        public const string ActionRemoveUserInGroup = "removeUserInGroup";
                                                 
        public const string ActionLocked         = "locked";
        public const string ActionUnLocked       = "unlocked";
        public const string ActionChangePassword = "changePassword";

        // System
        public const string Detail          = "chi-tiet";
        public const string Synthesis       = "tong-hop";

        public const string Dashboard       = "bang-dieu-khien";      
        public const string System          = "he-thong";        
        public const string Product         = "san-pham";
        public const string CreateProduct   = "san-pham-moi";
        public const string EditProduct     = "sua-san-pham";
        public const string Website         = "website";
        public const string Contract        = "hop-dong";
        public const string Departments     = "phong-ban";
        public const string Parts           = "bo-phan";
        public const string Group           = "nhom";
        public const string Staff           = "nhan-vien";
        public const string User            = "thanh-vien";
        public const string Menu            = "chuc-nang";
        public const string Category        = "chuyen-muc";        
        public const string Data            = "du-lieu";
        public const string Setting         = "thiet-lap";
        public const string Article         = "bai-viet";
        public const string Adv             = "anh";
        public const string Post            = "bai-viet-moi";
        public const string EditPost        = "sua-bai-viet";        
        public const string Error           = "bao-loi";
        public const string Developers      = "nha-phat-trien";
        public const string Guide           = "huong-dan";
        public const string Tasks           = "ca-nhan/quan-ly-cong-viec";
        public const string Account         = "ca-nhan/thong-tin-tai-khoan";
        public const string ChangePassword  = "ca-nhan/thong-tin-tai-khoan";
        public const string Personalization = "ca-nhan/thiet-lap-chuc-nang";


        // Params
        public const string ParamPageIndex  = "pageIndex";
        public const string ParamPageSize   = "pageSize";
        public const string ParamStartDate  = "startDate";
        public const string ParamEndDate    = "endDate";       
        public const string ParamType       = "type";
        public const string ParamId         = "id";
        public const string ParamLogType    = "logType";

        // Thumbnail 
        public static int ImageSmallSize = Utils.ToInt32(ConfigurationManager.AppSettings["IMAGE_SMALL_SIZE"]);
        public int ImageLargeSize        = Utils.ToInt32(ConfigurationManager.AppSettings["IMAGE_LARGE_SIZE"]);

        public const string ThumbnailTypeImage   = "Image";
        public const string ThumbnailTypePartner = "Partner";
        public const string ThumbnailTypeArticle = "Article";        
    }
}
