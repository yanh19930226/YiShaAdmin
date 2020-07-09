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
    /// 日 期：2020-07-09 15:07
    /// 描 述：控制器类
    /// </summary>
    [Area("BasicManage")]
    public class CarrierController :  BaseController
    {
        private CarrierBLL carrierBLL = new CarrierBLL();

        #region 视图功能
        [AuthorizeFilter("basic:carrier:view")]
        public ActionResult CarrierIndex()
        {
            return View();
        }

        public ActionResult CarrierForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("basic:carrier:search")]
        public async Task<ActionResult> GetListJson(CarrierListParam param)
        {
            TData<List<CarrierEntity>> obj = await carrierBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("basic:carrier:search")]
        public async Task<ActionResult> GetPageListJson(CarrierListParam param, Pagination pagination)
        {
            TData<List<CarrierEntity>> obj = await carrierBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<CarrierEntity> obj = await carrierBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("basic:carrier:add,basic:carrier:edit")]
        public async Task<ActionResult> SaveFormJson(CarrierEntity entity)
        {
            TData<string> obj = await carrierBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("basic:carrier:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await carrierBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
