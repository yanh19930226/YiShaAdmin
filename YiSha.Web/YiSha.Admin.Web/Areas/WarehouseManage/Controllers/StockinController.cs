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
    public class StockinController :  BaseController
    {
        private StockinBLL stockinBLL = new StockinBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:stockin:view")]
        public ActionResult StockinIndex()
        {
            return View();
        }

        public ActionResult StockinForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:stockin:search")]
        public async Task<ActionResult> GetListJson(StockinListParam param)
        {
            TData<List<StockinEntity>> obj = await stockinBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:stockin:search")]
        public async Task<ActionResult> GetPageListJson(StockinListParam param, Pagination pagination)
        {
            TData<List<StockinEntity>> obj = await stockinBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<StockinEntity> obj = await stockinBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:stockin:add,warehouse:stockin:edit")]
        public async Task<ActionResult> SaveFormJson(StockinEntity entity)
        {
            TData<string> obj = await stockinBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:stockin:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await stockinBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
