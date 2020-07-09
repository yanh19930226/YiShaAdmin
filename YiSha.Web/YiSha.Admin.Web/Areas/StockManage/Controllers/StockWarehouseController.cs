using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.StockManage;
using YiSha.Business.StockManage;
using YiSha.Model.Param.StockManage;

namespace YiSha.Admin.Web.Areas.StockManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-06 17:26
    /// 描 述：控制器类
    /// </summary>
    [Area("StockManage")]
    public class StockWarehouseController :  BaseController
    {
        private StockWarehouseBLL stockWarehouseBLL = new StockWarehouseBLL();

        #region 视图功能
        [AuthorizeFilter("stock:stockwarehouse:view")]
        public ActionResult StockWarehouseIndex()
        {
            return View();
        }

        public ActionResult StockWarehouseForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("stock:stockwarehouse:search")]
        public async Task<ActionResult> GetListJson(StockWarehouseListParam param)
        {
            TData<List<StockWarehouseEntity>> obj = await stockWarehouseBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("stock:stockwarehouse:search")]
        public async Task<ActionResult> GetPageListJson(StockWarehouseListParam param, Pagination pagination)
        {
            TData<List<StockWarehouseEntity>> obj = await stockWarehouseBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<StockWarehouseEntity> obj = await stockWarehouseBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("stock:stockwarehouse:add,stock:stockwarehouse:edit")]
        public async Task<ActionResult> SaveFormJson(StockWarehouseEntity entity)
        {
            TData<string> obj = await stockWarehouseBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("stock:stockwarehouse:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await stockWarehouseBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
