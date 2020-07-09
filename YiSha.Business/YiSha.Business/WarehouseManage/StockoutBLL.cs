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
    /// 日 期：2020-07-09 15:04
    /// 描 述：业务类
    /// </summary>
    public class StockoutBLL
    {
        private StockoutService stockoutService = new StockoutService();

        #region 获取数据
        public async Task<TData<List<StockoutEntity>>> GetList(StockoutListParam param)
        {
            TData<List<StockoutEntity>> obj = new TData<List<StockoutEntity>>();
            obj.Data = await stockoutService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<StockoutEntity>>> GetPageList(StockoutListParam param, Pagination pagination)
        {
            TData<List<StockoutEntity>> obj = new TData<List<StockoutEntity>>();
            obj.Data = await stockoutService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<StockoutEntity>> GetEntity(long id)
        {
            TData<StockoutEntity> obj = new TData<StockoutEntity>();
            obj.Data = await stockoutService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(StockoutEntity entity)
        {
            TData<string> obj = new TData<string>();
            await stockoutService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await stockoutService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
