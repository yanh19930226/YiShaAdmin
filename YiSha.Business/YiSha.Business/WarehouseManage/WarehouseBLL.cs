using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.WarehouseManage;
using YiSha.Model.Param.WarehouseManage;
using YiSha.Service.WarehouseManage;

namespace YiSha.Business.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:02
    /// 描 述：业务类
    /// </summary>
    public class WarehouseBLL
    {
        private WarehouseService warehouseService = new WarehouseService();

        #region 获取数据
        public async Task<TData<List<WarehouseEntity>>> GetList(WarehouseListParam param)
        {
            TData<List<WarehouseEntity>> obj = new TData<List<WarehouseEntity>>();
            obj.Data = await warehouseService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<WarehouseEntity>>> GetPageList(WarehouseListParam param, Pagination pagination)
        {
            TData<List<WarehouseEntity>> obj = new TData<List<WarehouseEntity>>();
            obj.Data = await warehouseService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<WarehouseEntity>> GetEntity(long id)
        {
            TData<WarehouseEntity> obj = new TData<WarehouseEntity>();
            obj.Data = await warehouseService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(WarehouseEntity entity)
        {
            TData<string> obj = new TData<string>();
            await warehouseService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await warehouseService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
