using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;

namespace ABM_Web.Controllers
{
    public class ErrorController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResponse ListError([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                var totalRecords        = 0;
                jsonResponse.Success    = true;
                jsonResponse.Data       = ErrorBiz.ListPagination(model, out totalRecords);
                jsonResponse.PagerInfo  = string.Format(@ABM.Resources.vi_VN.Pager_Info_Error, totalRecords);
                jsonResponse.Pager      = PagerHelper.PageLinks(model.PageIndex, model.PageSize, totalRecords, Constants.DefaultPageStep, string.Format(ABM.Resources.vi_VN.Pager_Errors, "{0}"));                                                
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public KeyValuePair<bool, string> Send()
        {
            try
            {
                var fileName = string.Empty;
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var postedFile = HttpContext.Current.Request.Files["AttachFile"];
                    
                    if (postedFile != null)
                    {
                        // Validate the uploaded image(optional)
                        
                        // Get the complete file path
                        var rootPath = "~" + ConfigurationManager.AppSettings["FOLDER_IMAGE_ERRORS"];
                        fileName = postedFile.FileName;
                        
                        var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath(rootPath) + "/" + fileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        postedFile.SaveAs(fileSavePath);                        
                    }
                }

                var errorEntity = new ErrorEntity
                {
                    FullName    = HttpContext.Current.Request["FullName"],
                    Email       = HttpContext.Current.Request["Email"],
                    Priority    = Utils.ToInt32(HttpContext.Current.Request["Priority"]),
                    Message     = HttpContext.Current.Request["Message"],
                    Image       = fileName,
                    Status      = Constants.NotActive
                };

                ErrorBiz.Save(errorEntity);

                return new KeyValuePair<bool, string>(true, @ABM.Resources.vi_VN.Send_Message_Complete);
            }
            catch (Exception ex)
            {
                return new KeyValuePair<bool, string>(false, @ABM.Resources.vi_VN.Send_Message_Error + ex.Message);                
            }
        }

        [HttpPost]
        public JsonResponse Action([FromBody]ErrorEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        jsonResponse.Data = ErrorBiz.Save(entity);
                        break;

                    case Constants.ActionGetById:
                        jsonResponse.Data = ErrorBiz.GetById(entity.ErrorId);
                        break;

                    case Constants.ActionPublished:
                        jsonResponse.Success = ChangeStatus(entity.LstId, (int)StatusConfig.Active);
                        break;

                    case Constants.ActionRemove:
                        jsonResponse.Success = ChangeStatus(entity.LstId, (int)StatusConfig.NotActive);
                        break;                 
                }

                jsonResponse.Success = true;
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        private bool ChangeStatus(List<int> lstId, int status)
        {
            if (lstId != null && lstId.Count > 0)
            {
                foreach (var errorId in lstId)
                {
                    var id = Utils.ToInt32(errorId, 0);
                    if (id > 0)
                        ErrorBiz.ChangeStatus(id, status);
                }
                return true;
            }
            return false;
        }
    }
}
