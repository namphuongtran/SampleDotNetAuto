using System.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;
using ABM.Common;

namespace ABM_Web.Controllers
{
    public class ReportController : Controller
    {        
        public ActionResult Index()
        {
            var report       = Url.RequestContext.RouteData.Values[Constants.ParamReport].ToString();
            var typeOfReport = Url.RequestContext.RouteData.Values[Constants.ParamTypeOfReport].ToString();
            
            if (!string.IsNullOrEmpty(report) && !string.IsNullOrEmpty(typeOfReport))
            {
                var filter     = string.Empty;
                var list       = string.Empty;
                var pathConfig = HostingEnvironment.MapPath(ConfigurationManager.AppSettings["PATH_MODULES"]);                

                switch (report)
                {
                    case Constants.Detail:
                        filter = Utils.GetConfigPathXml(pathConfig, (int)ReportConfig.Detail, typeOfReport);
                        list   = Utils.GetConfigPathXml(pathConfig, (int)ReportConfig.Detail, Constants.Detail);                        
                        break;

                    case Constants.Synthesis:                        
                        filter = Utils.GetConfigPathXml(pathConfig, (int)ReportConfig.Synthesis, typeOfReport);
                        list   = Utils.GetConfigPathXml(pathConfig, (int)ReportConfig.Synthesis, Constants.Synthesis);
                        break;
                }
                
                if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(list))
                {
                    ViewData["Filter"] = filter;
                    //ViewData["List"]   = list;
                }                    
            }

            return View();
        }
    }
}
