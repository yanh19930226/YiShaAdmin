using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.BasicManage;
using YiSha.Model.Param.BasicManage;
using YiSha.Service.BasicManage;

namespace YiSha.Business.BasicManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:11
    /// 描 述：业务类
    /// </summary>
    public class SupplierBLL
    {
        private SupplierService supplierService = new SupplierService();

        #region 获取数据
        public async Task<TData<List<SupplierEntity>>> GetList(SupplierListParam param)
        {
            TData<List<SupplierEntity>> obj = new TData<List<SupplierEntity>>();
            obj.Data = await supplierService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SupplierEntity>>> GetPageList(SupplierListParam param, Pagination pagination)
        {
            TData<List<SupplierEntity>> obj = new TData<List<SupplierEntity>>();
            obj.Data = await supplierService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SupplierEntity>> GetEntity(long id)
        {
            TData<SupplierEntity> obj = new TData<SupplierEntity>();
            obj.Data = await supplierService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SupplierEntity entity)
        {
            TData<string> obj = new TData<string>();
            await supplierService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await supplierService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
