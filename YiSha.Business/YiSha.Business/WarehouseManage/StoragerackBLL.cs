using System;
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
    /// 日 期：2020-07-09 15:03
    /// 描 述：业务类
    /// </summary>
    public class StoragerackBLL
    {
        private StoragerackService storagerackService = new StoragerackService();

        #region 获取数据
        public async Task<TData<List<StoragerackEntity>>> GetList(StoragerackListParam param)
        {
            TData<List<StoragerackEntity>> obj = new TData<List<StoragerackEntity>>();
            obj.Data = await storagerackService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<StoragerackEntity>>> GetPageList(StoragerackListParam param, Pagination pagination)
        {
            TData<List<StoragerackEntity>> obj = new TData<List<StoragerackEntity>>();
            obj.Data = await storagerackService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<StoragerackEntity>> GetEntity(long id)
        {
            TData<StoragerackEntity> obj = new TData<StoragerackEntity>();
            obj.Data = await storagerackService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(StoragerackEntity entity)
        {
            TData<string> obj = new TData<string>();
            await storagerackService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await storagerackService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
