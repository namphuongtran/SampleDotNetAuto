using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ABM.Common;

namespace ABM_Web
{
    public class MessageHandler : DelegatingHandler
    {122ffff
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.ToString().ToLower().IndexOf("api/authenticated") == -1)
            {
                //if (HttpContext.Current.Session[Constants.SessionIsLock].ToString().Equals("unlock"))
                {
                    if (HttpContext.Current.Session[Constants.SessionUserId] == null || HttpContext.Current.Session[Constants.SessionUsername] == null)
                    {
                        var tsc      = new TaskCompletionSource<HttpResponseMessage>();
                        var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                        tsc.SetResult(response);
                        return tsc.Task;
                    }
                }
            }

            return base.SendAsync(request, cancellationToken);
        }
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //config.MessageHandlers.Add(new MessageHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultController",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional }
            );

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Remove default XML handler
            var matches = config.Formatters
                                .Where(f => f.SupportedMediaTypes
                                             .Where(m => m.MediaType.ToString() == "application/xml" || m.MediaType.ToString() == "text/xml")
                                             .Count() > 0)
                                .ToList();
            foreach (var match in matches)
                config.Formatters.Remove(match);
        }
    }
}
