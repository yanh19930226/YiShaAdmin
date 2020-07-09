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
using YiSha.Entity.BasicManage;
using YiSha.Business.BasicManage;
using YiSha.Model.Param.BasicManage;

namespace YiSha.Admin.Web.Areas.BasicManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:11
    /// 描 述：控制器类
    /// </summary>
    [Area("BasicManage")]
    public class SupplierController :  BaseController
    {
        private SupplierBLL supplierBLL = new SupplierBLL();

        #region 视图功能
        [AuthorizeFilter("basic:supplier:view")]
        public ActionResult SupplierIndex()
        {
            return View();
        }

        public ActionResult SupplierForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("basic:supplier:search")]
        public async Task<ActionResult> GetListJson(SupplierListParam param)
        {
            TData<List<SupplierEntity>> obj = await supplierBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("basic:supplier:search")]
        public async Task<ActionResult> GetPageListJson(SupplierListParam param, Pagination pagination)
        {
            TData<List<SupplierEntity>> obj = await supplierBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<SupplierEntity> obj = await supplierBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("basic:supplier:add,basic:supplier:edit")]
        public async Task<ActionResult> SaveFormJson(SupplierEntity entity)
        {
            TData<string> obj = await supplierBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("basic:supplier:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await supplierBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
