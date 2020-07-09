using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:05
    /// 描 述：实体类
    /// </summary>
    [Table("wms_reservoiarea")]
    public class ReservoiareaEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReservoirAreaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReservoirAreaNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(StringJsonConverter))]
        public long? WarehouseId { get; set; }
    }
}
