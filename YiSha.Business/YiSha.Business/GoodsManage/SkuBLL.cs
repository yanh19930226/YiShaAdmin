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
    /// 日 期：2020-07-08 14:06
    /// 描 述：业务类
    /// </summary>
    public class SkuBLL
    {
        private SkuService skuService = new SkuService();

        #region 获取数据
        public async Task<TData<List<SkuEntity>>> GetList(SkuListParam param)
        {
            TData<List<SkuEntity>> obj = new TData<List<SkuEntity>>();
            obj.Data = await skuService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SkuEntity>>> GetPageList(SkuListParam param, Pagination pagination)
        {
            TData<List<SkuEntity>> obj = new TData<List<SkuEntity>>();
            obj.Data = await skuService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SkuEntity>> GetEntity(long id)
        {
            TData<SkuEntity> obj = new TData<SkuEntity>();
            obj.Data = await skuService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SkuEntity entity)
        {
            TData<string> obj = new TData<string>();
            await skuService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await skuService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
