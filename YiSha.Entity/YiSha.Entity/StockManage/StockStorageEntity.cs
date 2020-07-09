using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.StockManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-06 17:30
    /// 描 述：实体类
    /// </summary>
    [Table("StockStorage")]
    public class StockStorageEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarehouseId { get; set; }
        [NotMapped]
        public string WarehouseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
    }
}
