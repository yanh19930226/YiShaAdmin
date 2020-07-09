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
    /// 日 期：2020-07-09 15:10
    /// 描 述：控制器类
    /// </summary>
    [Area("BasicManage")]
    public class MaterialController :  BaseController
    {
        private MaterialBLL materialBLL = new MaterialBLL();

        #region 视图功能
        [AuthorizeFilter("basic:material:view")]
        public ActionResult MaterialIndex()
        {
            return View();
        }

        public ActionResult MaterialForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("basic:material:search")]
        public async Task<ActionResult> GetListJson(MaterialListParam param)
        {
            TData<List<MaterialEntity>> obj = await materialBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("basic:material:search")]
        public async Task<ActionResult> GetPageListJson(MaterialListParam param, Pagination pagination)
        {
            TData<List<MaterialEntity>> obj = await materialBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<MaterialEntity> obj = await materialBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("basic:material:add,basic:material:edit")]
        public async Task<ActionResult> SaveFormJson(MaterialEntity entity)
        {
            TData<string> obj = await materialBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("basic:material:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await materialBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
