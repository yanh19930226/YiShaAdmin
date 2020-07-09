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
    /// 日 期：2020-07-08 14:06
    /// 描 述：服务类
    /// </summary>
    public class SkuService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<SkuEntity>> GetList(SkuListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<SkuEntity>> GetPageList(SkuListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<SkuEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<SkuEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(SkuEntity entity)
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
            await this.BaseRepository().Delete<SkuEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<SkuEntity, bool>> ListFilter(SkuListParam param)
        {
            var expression = LinqExtensions.True<SkuEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
