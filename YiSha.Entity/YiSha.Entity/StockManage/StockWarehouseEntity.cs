using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.StockManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-06 17:26
    /// 描 述：实体类
    /// </summary>
    [Table("StockWarehouse")]
    public class StockWarehouseEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
    }
}
