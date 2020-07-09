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
    /// 日 期：2020-07-06 17:30
    /// 描 述：控制器类
    /// </summary>
    [Area("StockManage")]
    public class StockStorageController :  BaseController
    {
        private StockStorageBLL stockStorageBLL = new StockStorageBLL();

        #region 视图功能
        [AuthorizeFilter("stock:stockstorage:view")]
        public ActionResult StockStorageIndex()
        {
            return View();
        }

        public ActionResult StockStorageForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("stock:stockstorage:search")]
        public async Task<ActionResult> GetListJson(StockStorageListParam param)
        {
            TData<List<StockStorageEntity>> obj = await stockStorageBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("stock:stockstorage:search")]
        public async Task<ActionResult> GetPageListJson(StockStorageListParam param, Pagination pagination)
        {
            TData<List<StockStorageEntity>> obj = await stockStorageBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<StockStorageEntity> obj = await stockStorageBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("stock:stockstorage:add,stock:stockstorage:edit")]
        public async Task<ActionResult> SaveFormJson(StockStorageEntity entity)
        {
            TData<string> obj = await stockStorageBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("stock:stockstorage:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await stockStorageBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
