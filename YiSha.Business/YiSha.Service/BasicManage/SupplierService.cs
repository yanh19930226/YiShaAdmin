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
using YiSha.Entity.BasicManage;
using YiSha.Model.Param.BasicManage;

namespace YiSha.Service.BasicManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:11
    /// 描 述：服务类
    /// </summary>
    public class SupplierService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<SupplierEntity>> GetList(SupplierListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<SupplierEntity>> GetPageList(SupplierListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<SupplierEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<SupplierEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(SupplierEntity entity)
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
            await this.BaseRepository().Delete<SupplierEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<SupplierEntity, bool>> ListFilter(SupplierListParam param)
        {
            var expression = LinqExtensions.True<SupplierEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
