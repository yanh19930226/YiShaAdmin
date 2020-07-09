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
    /// 日 期：2020-07-09 15:05
    /// 描 述：控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class ReservoiareaController :  BaseController
    {
        private ReservoiareaBLL reservoiareaBLL = new ReservoiareaBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:reservoiarea:view")]
        public ActionResult ReservoiareaIndex()
        {
            return View();
        }

        public ActionResult ReservoiareaForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:reservoiarea:search")]
        public async Task<ActionResult> GetListJson(ReservoiareaListParam param)
        {
            TData<List<ReservoiareaEntity>> obj = await reservoiareaBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:reservoiarea:search")]
        public async Task<ActionResult> GetPageListJson(ReservoiareaListParam param, Pagination pagination)
        {
            TData<List<ReservoiareaEntity>> obj = await reservoiareaBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<ReservoiareaEntity> obj = await reservoiareaBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:reservoiarea:add,warehouse:reservoiarea:edit")]
        public async Task<ActionResult> SaveFormJson(ReservoiareaEntity entity)
        {
            TData<string> obj = await reservoiareaBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:reservoiarea:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await reservoiareaBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
