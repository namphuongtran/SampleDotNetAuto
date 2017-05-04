using System.Web.Mvc;
using ABM.Common;

namespace ABM_Web.Controllers
{
    public class SystemController : Controller
    {
        public ActionResult Index()
        {
            string url  = string.Empty;
            string type = string.Empty;
            var id   = Utils.ToInt32(Url.RequestContext.RouteData.Values[Constants.ParamId]);

            try
            {
                type = Url.RequestContext.RouteData.Values[Constants.ParamType].ToString();
            }
            catch { } 
            
            switch (type)
            {
                case Constants.Group:
                     url = "~/Views/Partials/System/Group.cshtml";
                    break;

                case Constants.User:
                    url = "~/Views/Partials/System/User.cshtml";
                    break;

                case Constants.Menu:
                    url = "~/Views/Partials/System/Menu.cshtml";
                    break;

                case Constants.Category:
                    url = "~/Views/Partials/System/Category.cshtml";
                    break;

                case Constants.Adv:
                    url = "~/Views/Partials/System/Adv.cshtml";
                    break;

                case Constants.Article:
                    url = "~/Views/Partials/System/Article.cshtml";
                    break;
                case Constants.Post:
                    url = "~/Views/Partials/System/Post.cshtml";
                    break;
                case Constants.EditPost:
                    url = "~/Views/Partials/System/EditPost.cshtml"; 
                    break;
               
                case Constants.Product:
                    url = "~/Views/Partials/System/SKU.cshtml";
                    break;
                case Constants.CreateProduct:
                    url = "~/Views/Partials/System/CreateSKU.cshtml";
                    break;
                case Constants.EditProduct:
                    url = "~/Views/Partials/System/EditSKU.cshtml";
                    break;                
                default:
                    url = "~/Views/Partials/System/Default.cshtml";
                    break;
            }
           
            if (!string.IsNullOrEmpty(url))
                ViewData["Type"] = url;
            
            return View();
        }

    }
}
