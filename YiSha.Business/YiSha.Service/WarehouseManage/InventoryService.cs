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
    /// 日 期：2020-07-09 15:09
    /// 描 述：服务类
    /// </summary>
    public class InventoryService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<InventoryEntity>> GetList(InventoryListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<InventoryEntity>> GetPageList(InventoryListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<InventoryEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<InventoryEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(InventoryEntity entity)
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
            await this.BaseRepository().Delete<InventoryEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<InventoryEntity, bool>> ListFilter(InventoryListParam param)
        {
            var expression = LinqExtensions.True<InventoryEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
