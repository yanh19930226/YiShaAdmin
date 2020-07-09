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
using YiSha.Entity.WarehouseManage;
using YiSha.Business.WarehouseManage;
using YiSha.Model.Param.WarehouseManage;

namespace YiSha.Admin.Web.Areas.WarehouseManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:04
    /// 描 述：控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class StockoutController :  BaseController
    {
        private StockoutBLL stockoutBLL = new StockoutBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:stockout:view")]
        public ActionResult StockoutIndex()
        {
            return View();
        }

        public ActionResult StockoutForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:stockout:search")]
        public async Task<ActionResult> GetListJson(StockoutListParam param)
        {
            TData<List<StockoutEntity>> obj = await stockoutBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:stockout:search")]
        public async Task<ActionResult> GetPageListJson(StockoutListParam param, Pagination pagination)
        {
            TData<List<StockoutEntity>> obj = await stockoutBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<StockoutEntity> obj = await stockoutBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:stockout:add,warehouse:stockout:edit")]
        public async Task<ActionResult> SaveFormJson(StockoutEntity entity)
        {
            TData<string> obj = await stockoutBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:stockout:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await stockoutBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
