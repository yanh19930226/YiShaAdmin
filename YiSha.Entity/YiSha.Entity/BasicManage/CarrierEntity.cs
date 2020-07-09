using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BasicManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:07
    /// 描 述：实体类
    /// </summary>
    [Table("wms_carrier")]
    public class CarrierEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CarrierLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CarrierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CarrierNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CarrierPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Tel { get; set; }
    }
}
