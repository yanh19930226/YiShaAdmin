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
using YiSha.Entity.WarehouseManage;
using YiSha.Model.Param.WarehouseManage;

namespace YiSha.Service.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:04
    /// 描 述：服务类
    /// </summary>
    public class StockoutService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<StockoutEntity>> GetList(StockoutListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<StockoutEntity>> GetPageList(StockoutListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<StockoutEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<StockoutEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(StockoutEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<StockoutEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<StockoutEntity, bool>> ListFilter(StockoutListParam param)
        {
            var expression = LinqExtensions.True<StockoutEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
