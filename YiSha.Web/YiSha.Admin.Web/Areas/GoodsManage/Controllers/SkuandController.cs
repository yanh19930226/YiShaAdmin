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
    /// 日 期：2020-07-08 14:07
    /// 描 述：控制器类
    /// </summary>
    [Area("GoodsManage")]
    public class SkuandController :  BaseController
    {
        private SkuandBLL skuandBLL = new SkuandBLL();

        #region 视图功能
        [AuthorizeFilter("goods:skuand:view")]
        public ActionResult SkuandIndex()
        {
            return View();
        }

        public ActionResult SkuandForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("goods:skuand:search")]
        public async Task<ActionResult> GetListJson(SkuandListParam param)
        {
            TData<List<SkuandEntity>> obj = await skuandBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("goods:skuand:search")]
        public async Task<ActionResult> GetPageListJson(SkuandListParam param, Pagination pagination)
        {
            TData<List<SkuandEntity>> obj = await skuandBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<SkuandEntity> obj = await skuandBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("goods:skuand:add,goods:skuand:edit")]
        public async Task<ActionResult> SaveFormJson(SkuandEntity entity)
        {
            TData<string> obj = await skuandBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("goods:skuand:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await skuandBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
