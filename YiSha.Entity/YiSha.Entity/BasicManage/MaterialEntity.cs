using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BasicManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:10
    /// 描 述：实体类
    /// </summary>
    [Table("wms_material")]
    public class MaterialEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MaterialName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MaterialNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MaterialType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? Qty { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? ReservoirAreaId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? StoragerackId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Unit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarehouseId { get; set; }
    }
}
