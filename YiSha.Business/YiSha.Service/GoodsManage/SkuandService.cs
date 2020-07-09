using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.GoodsManage;
using YiSha.Model.Param.GoodsManage;

namespace YiSha.Service.GoodsManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-08 14:07
    /// 描 述：服务类
    /// </summary>
    public class SkuandService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<SkuandEntity>> GetList(SkuandListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<SkuandEntity>> GetPageList(SkuandListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<SkuandEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<SkuandEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(SkuandEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<SkuandEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<SkuandEntity, bool>> ListFilter(SkuandListParam param)
        {
            var expression = LinqExtensions.True<SkuandEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
