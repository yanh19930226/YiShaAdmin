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
using YiSha.Entity.GoodsManage;
using YiSha.Business.GoodsManage;
using YiSha.Model.Param.GoodsManage;

namespace YiSha.Admin.Web.Areas.GoodsManage.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-08 14:06
    /// 描 述：控制器类
    /// </summary>
    [Area("GoodsManage")]
    public class SkuController :  BaseController
    {
        private SkuBLL skuBLL = new SkuBLL();

        #region 视图功能
        [AuthorizeFilter("goods:sku:view")]
        public ActionResult SkuIndex()
        {
            return View();
        }

        public ActionResult SkuForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("goods:sku:search")]
        public async Task<ActionResult> GetListJson(SkuListParam param)
        {
            TData<List<SkuEntity>> obj = await skuBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("goods:sku:search")]
        public async Task<ActionResult> GetPageListJson(SkuListParam param, Pagination pagination)
        {
            TData<List<SkuEntity>> obj = await skuBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<SkuEntity> obj = await skuBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("goods:sku:add,goods:sku:edit")]
        public async Task<ActionResult> SaveFormJson(SkuEntity entity)
        {
            TData<string> obj = await skuBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("goods:sku:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await skuBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
