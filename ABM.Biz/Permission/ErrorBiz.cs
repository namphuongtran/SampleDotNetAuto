using ABM.Dao;
using ABM.Dao.Permission;
using ABM.Entity;
using ABM.Entity.Permission;
using System.Collections.Generic;

namespace ABM.Biz.Permission
{
    public class ErrorBiz
    {
        //=== Table ===//
        private const string Table      = "Error";
        private const string TableOrder = "ErrorId DESC";
        private const string FieldList  = "ItemIndex, ErrorId, [Priority], [Status], FullName, Email, Image, Message, Note, ModifiedDate";

        /// <summary>
        /// Danh sách tìm kiếm và phân trang lỗi
        /// </summary>
        /// <param name="model"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static List<ErrorEntity> ListPagination(ModelParams model, out int totalRecords)
        {
            var filter = "1=1";

            if (!string.IsNullOrEmpty(model.Keyword))
                filter += string.Format(" AND ((FullName LIKE N'%{0}%') OR (Email LIKE N'%{0}%') OR (Message LIKE N'%{0}%'))", model.Keyword);

            if (model.Status > 0)
                filter += string.Format(" AND [Status] = {0}", model.Status);

            if (model.Priority > 0)
                filter += string.Format(" AND [Priority] = {0}", model.Priority);

            DbCommon.SetConnection(DbCommon.ConnectionName.ABM);
            return DbCommon.ExecutePagination<ErrorEntity>(DbCommon.ConnectionString, Table, filter,
                                                            FieldList, TableOrder, model.PageIndex, model.PageSize, out totalRecords);
        }

        /// <summary>
        /// Lấy về thông tin lỗi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ErrorEntity GetById(int id)
        {
            return ErrorDao.GetById(id);
        }

        /// <summary>
        /// Tạo mới, Sửa thông tin lỗi
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static bool Save(ErrorEntity entity)
        {
            return ErrorDao.Save(entity);
        }

        /// <summary>
        /// Chuyển trạng thái lỗi (Hoàn thành | Chờ sử lý)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool ChangeStatus(int id, int status)
        {
            return ErrorDao.ChangeStatus(id, status);
        }
    }
}
