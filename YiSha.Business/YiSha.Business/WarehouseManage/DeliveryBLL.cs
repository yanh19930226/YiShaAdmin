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
    /// 日 期：2020-07-09 15:07
    /// 描 述：业务类
    /// </summary>
    public class DeliveryBLL
    {
        private DeliveryService deliveryService = new DeliveryService();

        #region 获取数据
        public async Task<TData<List<DeliveryEntity>>> GetList(DeliveryListParam param)
        {
            TData<List<DeliveryEntity>> obj = new TData<List<DeliveryEntity>>();
            obj.Data = await deliveryService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<DeliveryEntity>>> GetPageList(DeliveryListParam param, Pagination pagination)
        {
            TData<List<DeliveryEntity>> obj = new TData<List<DeliveryEntity>>();
            obj.Data = await deliveryService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<DeliveryEntity>> GetEntity(long id)
        {
            TData<DeliveryEntity> obj = new TData<DeliveryEntity>();
            obj.Data = await deliveryService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(DeliveryEntity entity)
        {
            TData<string> obj = new TData<string>();
            await deliveryService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await deliveryService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
