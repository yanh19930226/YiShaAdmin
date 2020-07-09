using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.StockManage;
using YiSha.Model.Param.StockManage;
using YiSha.Service.StockManage;

namespace YiSha.Business.StockManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-06 17:26
    /// 描 述：业务类
    /// </summary>
    public class StockWarehouseBLL
    {
        private StockWarehouseService stockWarehouseService = new StockWarehouseService();

        #region 获取数据
        public async Task<TData<List<StockWarehouseEntity>>> GetList(StockWarehouseListParam param)
        {
            TData<List<StockWarehouseEntity>> obj = new TData<List<StockWarehouseEntity>>();
            obj.Data = await stockWarehouseService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<StockWarehouseEntity>>> GetPageList(StockWarehouseListParam param, Pagination pagination)
        {
            TData<List<StockWarehouseEntity>> obj = new TData<List<StockWarehouseEntity>>();
            obj.Data = await stockWarehouseService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<StockWarehouseEntity>> GetEntity(long id)
        {
            TData<StockWarehouseEntity> obj = new TData<StockWarehouseEntity>();
            obj.Data = await stockWarehouseService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(StockWarehouseEntity entity)
        {
            TData<string> obj = new TData<string>();
            await stockWarehouseService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await stockWarehouseService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
