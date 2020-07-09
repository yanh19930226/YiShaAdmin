using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.GoodsManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-08 14:07
    /// 描 述：实体类
    /// </summary>
    [Table("goods_skuand")]
    public class SkuandEntity : BaseCreateEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? SkuId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ShopId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ShopSkuId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ShopSkuTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Num { get; set; }
    }
}
