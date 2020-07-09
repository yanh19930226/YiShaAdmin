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
    [Table("wms_customer")]
    public class CustomerEntity : BaseExtensionEntity
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
        public string CustomerLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CustomerName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CustomerNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CustomerPerson { get; set; }
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
