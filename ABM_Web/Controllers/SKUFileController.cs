using ABM.Biz.Permission;
using ABM.Common;
using ABM.Entity;
using ABM.Entity.Permission;
using System;
using System.Web.Http;

namespace ABM_Web.Controllers
{
    public class SKUFileController : ApiController
    {
        [HttpPost]
        public JsonResponse ListAll([FromBody]ModelParams model)
        {
            var jsonResponse = new JsonResponse();
            try
            {
                jsonResponse.Success = true;
                jsonResponse.Data    = SKUFileBiz.ListAll(model);
            }
            catch (Exception ex)
            {
                jsonResponse.Success = false;
                jsonResponse.Message = ex.Message;
            }

            return jsonResponse;
        }

        [HttpPost]
        public JsonResponse Action([FromBody]SKUFileEntity entity)
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
                                    SKUFileBiz.DeleteBySKUId(entity.SKUID);

                                foreach (var strSKUFile in splitSpaceProperty)
                                {
                                    if (!string.IsNullOrEmpty(strSKUFile))
                                    {
                                        var splitProperty = strSKUFile.Split('♥');
                                        try
                                        {
                                            var skuFileEntity = new SKUFileEntity()
                                            {
                                                SKUID = entity.SKUID,
                                                FileName = splitProperty[1],
                                                FilePath = splitProperty[1],
                                            };
                                            var result = SKUFileBiz.Insert(skuFileEntity);

                                            countSuccess = result.Equals(true) ? countSuccess + 1 : countSuccess;
                                            countFalse = result.Equals(false) ? countFalse + 1 : countFalse;
                                        }
                                        catch { countFalse++; }
                                    }
                                }
                            }
                            jsonResponse.Success = true;
                            jsonResponse.Message = string.Format("<b>{0}</b> tài liệu đẩy lên thành công. <b>{1}</b> tài liệu bị lỗi", countSuccess, countFalse);
                        }
                        break;

                    case Constants.ActionDelete:
                        jsonResponse.Success = SKUFileBiz.Delete(entity.FileID);
                        jsonResponse.Message = "Xóa ảnh thành công.";
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
