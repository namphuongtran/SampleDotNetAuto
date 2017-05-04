using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;
using System;
using System.Web.Http;

namespace ABM_Web.Controllers
{
    public class SKUImageController : ApiController
    {
        [HttpPost]
        public JsonResponse ListAll([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                jsonResponse.Success = true;
                jsonResponse.Data    = SKUImageBiz.ListAll(model);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]SKUImageEntity entity)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                switch (entity.Action)
                {
                    case Constants.ActionSave:
                        if (!string.IsNullOrEmpty(entity.LstParams) && entity.LstParams.Length > 0)
                        {
                            var countSuccess = 0;
                            var countFalse = 0;

                            var splitSpaceProperty = entity.LstParams.Split('✈');
                            if (splitSpaceProperty != null && splitSpaceProperty.Length > 0)
                            {
                                if (entity.SKUID > 0)
                                    SKUImageBiz.DeleteBySKUId(entity.SKUID);

                                foreach (var strSKUImage in splitSpaceProperty)
                                {
                                    if (!string.IsNullOrEmpty(strSKUImage))
                                    {
                                        var splitProperty = strSKUImage.Split('♥');
                                        try
                                        {
                                            var skuImageEntity = new SKUImageEntity()
                                            {
                                                SKUID     = entity.SKUID,
                                                ImagePath = splitProperty[1],
                                                Priority  = Utils.ToInt32(splitProperty[2])
                                            };
                                            var result = SKUImageBiz.Insert(skuImageEntity);

                                            countSuccess = result.Equals(true) ? countSuccess + 1 : countSuccess;
                                            countFalse   = result.Equals(false) ? countFalse + 1 : countFalse;

                                            // Update Image Path
                                            if (countSuccess.Equals(1))
                                                SKUsBiz.UpdateSmallImage(skuImageEntity.SKUID, skuImageEntity.ImagePath);
                                        }
                                        catch { countFalse++; }
                                    }
                                }
                            }
                            jsonResponse.Success = true;
                            jsonResponse.Message = string.Format("<b>{0}</b> ảnh đẩy lên thành công. <b>{1}</b> ảnh bị lỗi", countSuccess, countFalse);
                        }
                        break;
                  
                    case Constants.ActionDelete:
                        jsonResponse.Success = SKUImageBiz.Delete(entity.SKUID, entity.ImageID);
                        jsonResponse.Message = "Xóa tài liệu thành công.";
                        break;
                }                
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
