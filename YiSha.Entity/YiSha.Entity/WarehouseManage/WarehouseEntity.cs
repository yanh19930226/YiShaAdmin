using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.WarehouseManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:02
    /// 描 述：实体类
    /// </summary>
    [Table("wms_warehouse")]
    public class WarehouseEntity : BaseExtensionEntity
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
        public string WarehouseName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string WarehouseNo { get; set; }
    }
}
