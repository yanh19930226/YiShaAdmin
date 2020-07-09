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
    /// 日 期：2020-07-06 17:30
    /// 描 述：业务类
    /// </summary>
    public class StockStorageBLL
    {
        private StockStorageService stockStorageService = new StockStorageService();
        private StockWarehouseService stockwarehouseService = new StockWarehouseService();

        #region 获取数据
        public async Task<TData<List<StockStorageEntity>>> GetList(StockStorageListParam param)
        {
            TData<List<StockStorageEntity>> obj = new TData<List<StockStorageEntity>>();
            obj.Data = await stockStorageService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<StockStorageEntity>>> GetPageList(StockStorageListParam param, Pagination pagination)
        {
            TData<List<StockStorageEntity>> obj = new TData<List<StockStorageEntity>>();
            obj.Data = await stockStorageService.GetPageList(param, pagination);
            List<StockWarehouseEntity> warehouseList = await stockwarehouseService.GetList(new StockWarehouseListParam { });
            foreach (StockStorageEntity storage in obj.Data)
            {
                storage.WarehouseName = warehouseList.Where(p => p.Id == storage.WarehouseId).Select(p => p.Title).FirstOrDefault();
            }
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<StockStorageEntity>> GetEntity(long id)
        {
            TData<StockStorageEntity> obj = new TData<StockStorageEntity>();
            obj.Data = await stockStorageService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(StockStorageEntity entity)
        {
            TData<string> obj = new TData<string>();
            await stockStorageService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await stockStorageService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
