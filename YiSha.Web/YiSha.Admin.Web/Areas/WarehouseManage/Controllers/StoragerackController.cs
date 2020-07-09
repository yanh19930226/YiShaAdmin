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
    /// 日 期：2020-07-09 15:03
    /// 描 述：控制器类
    /// </summary>
    [Area("WarehouseManage")]
    public class StoragerackController :  BaseController
    {
        private StoragerackBLL storagerackBLL = new StoragerackBLL();

        #region 视图功能
        [AuthorizeFilter("warehouse:storagerack:view")]
        public ActionResult StoragerackIndex()
        {
            return View();
        }

        public ActionResult StoragerackForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("warehouse:storagerack:search")]
        public async Task<ActionResult> GetListJson(StoragerackListParam param)
        {
            TData<List<StoragerackEntity>> obj = await storagerackBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("warehouse:storagerack:search")]
        public async Task<ActionResult> GetPageListJson(StoragerackListParam param, Pagination pagination)
        {
            TData<List<StoragerackEntity>> obj = await storagerackBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<StoragerackEntity> obj = await storagerackBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("warehouse:storagerack:add,warehouse:storagerack:edit")]
        public async Task<ActionResult> SaveFormJson(StoragerackEntity entity)
        {
            TData<string> obj = await storagerackBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("warehouse:storagerack:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await storagerackBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
