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
    /// 日 期：2020-07-09 15:10
    /// 描 述：业务类
    /// </summary>
    public class MaterialBLL
    {
        private MaterialService materialService = new MaterialService();

        #region 获取数据
        public async Task<TData<List<MaterialEntity>>> GetList(MaterialListParam param)
        {
            TData<List<MaterialEntity>> obj = new TData<List<MaterialEntity>>();
            obj.Data = await materialService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<MaterialEntity>>> GetPageList(MaterialListParam param, Pagination pagination)
        {
            TData<List<MaterialEntity>> obj = new TData<List<MaterialEntity>>();
            obj.Data = await materialService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<MaterialEntity>> GetEntity(long id)
        {
            TData<MaterialEntity> obj = new TData<MaterialEntity>();
            obj.Data = await materialService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(MaterialEntity entity)
        {
            TData<string> obj = new TData<string>();
            await materialService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await materialService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
