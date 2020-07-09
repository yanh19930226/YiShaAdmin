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
    /// 日 期：2020-07-09 15:07
    /// 描 述：控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class DeliveryController :  BaseController
    {
        private DeliveryBLL deliveryBLL = new DeliveryBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:delivery:view")]
        public ActionResult DeliveryIndex()
        {
            return View();
        }

        public ActionResult DeliveryForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:delivery:search")]
        public async Task<ActionResult> GetListJson(DeliveryListParam param)
        {
            TData<List<DeliveryEntity>> obj = await deliveryBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:delivery:search")]
        public async Task<ActionResult> GetPageListJson(DeliveryListParam param, Pagination pagination)
        {
            TData<List<DeliveryEntity>> obj = await deliveryBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<DeliveryEntity> obj = await deliveryBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:delivery:add,warehouse:delivery:edit")]
        public async Task<ActionResult> SaveFormJson(DeliveryEntity entity)
        {
            TData<string> obj = await deliveryBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:delivery:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await deliveryBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
