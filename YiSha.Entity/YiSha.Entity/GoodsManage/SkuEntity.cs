using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.GoodsManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-08 14:06
    /// 描 述：实体类
    /// </summary>
    [Table("goods_sku")]
    public class SkuEntity : BaseCreateEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? SpuId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StorageName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? StorageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarehouseId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal? Weight { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PropertyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OriginalSku { get; set; }
    }
}
