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
    /// 日 期：2020-07-09 15:09
    /// 描 述：控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class InventoryController :  BaseController
    {
        private InventoryBLL inventoryBLL = new InventoryBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:inventory:view")]
        public ActionResult InventoryIndex()
        {
            return View();
        }

        public ActionResult InventoryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:inventory:search")]
        public async Task<ActionResult> GetListJson(InventoryListParam param)
        {
            TData<List<InventoryEntity>> obj = await inventoryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:inventory:search")]
        public async Task<ActionResult> GetPageListJson(InventoryListParam param, Pagination pagination)
        {
            TData<List<InventoryEntity>> obj = await inventoryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<InventoryEntity> obj = await inventoryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:inventory:add,warehouse:inventory:edit")]
        public async Task<ActionResult> SaveFormJson(InventoryEntity entity)
        {
            TData<string> obj = await inventoryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:inventory:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await inventoryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
