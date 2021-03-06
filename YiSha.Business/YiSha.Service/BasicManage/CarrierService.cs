﻿using System;
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
    /// 日 期：2020-07-09 15:07
    /// 描 述：服务类
    /// </summary>
    public class CarrierService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<CarrierEntity>> GetList(CarrierListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<CarrierEntity>> GetPageList(CarrierListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<CarrierEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<CarrierEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(CarrierEntity entity)
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
            await this.BaseRepository().Delete<CarrierEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<CarrierEntity, bool>> ListFilter(CarrierListParam param)
        {
            var expression = LinqExtensions.True<CarrierEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
