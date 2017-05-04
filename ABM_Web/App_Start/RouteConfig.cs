using System.Web.Mvc;
using System.Web.Routing;

namespace ABM_Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
          
            routes.MapRoute("Bảng điều khiển", "bang-dieu-khien", new { controller = "Dashboard", action = "Index" });
            routes.MapRoute("Hệ thống", "he-thong/{type}/{id}", new { controller = "System", action = "Index", type = UrlParameter.Optional, id = UrlParameter.Optional });
            routes.MapRoute("Cá nhân", "ca-nhan/{type}", new { controller = "Personalization", action = "Index", type = UrlParameter.Optional });
            routes.MapRoute("Báo lỗi", "bao-loi", new { controller = "Faq", action = "Index" });
            routes.MapRoute("Hướng dẫn", "huong-dan", new { controller = "Faq", action = "Index" });

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Login", action = "Index", id = UrlParameter.Optional });
        }
    }
}