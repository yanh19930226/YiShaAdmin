using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.BasicManage;
using YiSha.Model.Param.BasicManage;
using YiSha.Service.BasicManage;

namespace YiSha.Business.BasicManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:07
    /// 描 述：业务类
    /// </summary>
    public class CarrierBLL
    {
        private CarrierService carrierService = new CarrierService();

        #region 获取数据
        public async Task<TData<List<CarrierEntity>>> GetList(CarrierListParam param)
        {
            TData<List<CarrierEntity>> obj = new TData<List<CarrierEntity>>();
            obj.Data = await carrierService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<CarrierEntity>>> GetPageList(CarrierListParam param, Pagination pagination)
        {
            TData<List<CarrierEntity>> obj = new TData<List<CarrierEntity>>();
            obj.Data = await carrierService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<CarrierEntity>> GetEntity(long id)
        {
            TData<CarrierEntity> obj = new TData<CarrierEntity>();
            obj.Data = await carrierService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(CarrierEntity entity)
        {
            TData<string> obj = new TData<string>();
            await carrierService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await carrierService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
