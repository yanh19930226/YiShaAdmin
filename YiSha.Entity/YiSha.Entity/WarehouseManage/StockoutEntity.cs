using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:04
    /// 描 述：实体类
    /// </summary>
    [Table("wms_stockout")]
    public class StockoutEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? CustomerId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OrderNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string StockOutNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte? StockOutStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? StockOutType { get; set; }
    }
}
