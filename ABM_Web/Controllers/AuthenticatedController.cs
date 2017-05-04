using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;

namespace ABM_Web.Controllers
{
    public class AuthenticatedController : ApiController
    {
        private readonly string _defaultPage = ConfigurationManager.AppSettings["DEFAULT_PAGE"];

        [HttpPost]
        public JsonResponse Login([FromBody]ModelParams model)
        {
            var isSuccess    = false;
            var message      = "Tên đăng nhập hoặc mật khẩu sai.";
            var jsonResponse = new JsonResponse();            
            try
            {
                var username = model.Username.Trim();
                var password = model.Password.Trim();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {                    
                    if (UserBiz.Validate(model))
                    {
                        isSuccess        = true;
                        message          = "Đăng nhập thành công.";
                        jsonResponse.Url = _defaultPage;
                    }
                }
                
                jsonResponse.Success = isSuccess;
                jsonResponse.Message = message;
            }
            catch
            {
                jsonResponse.Success = false;
                jsonResponse.Message = "Tên đăng nhập hoặc mật khẩu sai."; 
            }
            return jsonResponse;
        }               

        [HttpPost]
        public JsonResponse Logout()
        {
            var jsonResponse = new JsonResponse();
            try
            {
                HttpContext.Current.Session[Constants.SessionUserId]   = null;                
                HttpContext.Current.Session[Constants.SessionUsername] = null;
                HttpContext.Current.Session[Constants.SessionFullname] = null;

                jsonResponse.Success = true;
                jsonResponse.Message = "Clear All Session";
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }
            return jsonResponse;
        }        
    }
}
