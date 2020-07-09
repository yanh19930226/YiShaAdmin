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
using YiSha.Entity.StockManage;
using YiSha.Model.Param.StockManage;

namespace YiSha.Service.StockManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-06 17:30
    /// 描 述：服务类
    /// </summary>
    public class StockStorageService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<StockStorageEntity>> GetList(StockStorageListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<StockStorageEntity>> GetPageList(StockStorageListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<StockStorageEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<StockStorageEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(StockStorageEntity entity)
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
            await this.BaseRepository().Delete<StockStorageEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<StockStorageEntity, bool>> ListFilter(StockStorageListParam param)
        {
            var expression = LinqExtensions.True<StockStorageEntity>();
            if (!string.IsNullOrEmpty(param.WarehouseId))
            {
                expression = expression.And(t => t.WarehouseId.ToString()==param.WarehouseId);
            }
            return expression;
        }
        #endregion
    }
}
