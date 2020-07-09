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
    /// 日 期：2020-07-09 15:09
    /// 描 述：业务类
    /// </summary>
    public class InventoryBLL
    {
        private InventoryService inventoryService = new InventoryService();

        #region 获取数据
        public async Task<TData<List<InventoryEntity>>> GetList(InventoryListParam param)
        {
            TData<List<InventoryEntity>> obj = new TData<List<InventoryEntity>>();
            obj.Data = await inventoryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<InventoryEntity>>> GetPageList(InventoryListParam param, Pagination pagination)
        {
            TData<List<InventoryEntity>> obj = new TData<List<InventoryEntity>>();
            obj.Data = await inventoryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<InventoryEntity>> GetEntity(long id)
        {
            TData<InventoryEntity> obj = new TData<InventoryEntity>();
            obj.Data = await inventoryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(InventoryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await inventoryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await inventoryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
