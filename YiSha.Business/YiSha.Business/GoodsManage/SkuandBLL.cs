using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.GoodsManage;
using YiSha.Model.Param.GoodsManage;
using YiSha.Service.GoodsManage;

namespace YiSha.Business.GoodsManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-08 14:07
    /// 描 述：业务类
    /// </summary>
    public class SkuandBLL
    {
        private SkuandService skuandService = new SkuandService();

        #region 获取数据
        public async Task<TData<List<SkuandEntity>>> GetList(SkuandListParam param)
        {
            TData<List<SkuandEntity>> obj = new TData<List<SkuandEntity>>();
            obj.Data = await skuandService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SkuandEntity>>> GetPageList(SkuandListParam param, Pagination pagination)
        {
            TData<List<SkuandEntity>> obj = new TData<List<SkuandEntity>>();
            obj.Data = await skuandService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SkuandEntity>> GetEntity(long id)
        {
            TData<SkuandEntity> obj = new TData<SkuandEntity>();
            obj.Data = await skuandService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SkuandEntity entity)
        {
            TData<string> obj = new TData<string>();
            await skuandService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await skuandService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
