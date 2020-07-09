﻿using System;
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
    public class StockinBLL
    {
        private StockinService stockinService = new StockinService();

        #region 获取数据
        public async Task<TData<List<StockinEntity>>> GetList(StockinListParam param)
        {
            TData<List<StockinEntity>> obj = new TData<List<StockinEntity>>();
            obj.Data = await stockinService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<StockinEntity>>> GetPageList(StockinListParam param, Pagination pagination)
        {
            TData<List<StockinEntity>> obj = new TData<List<StockinEntity>>();
            obj.Data = await stockinService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<StockinEntity>> GetEntity(long id)
        {
            TData<StockinEntity> obj = new TData<StockinEntity>();
            obj.Data = await stockinService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(StockinEntity entity)
        {
            TData<string> obj = new TData<string>();
            await stockinService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await stockinService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
