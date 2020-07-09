using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.BasicManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-09 15:11
    /// 描 述：实体类
    /// </summary>
    [Table("wms_supplier")]
    public class SupplierEntity : BaseExtensionEntity
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
        public string SupplierLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SupplierName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SupplierNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SupplierPerson { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Tel { get; set; }
    }
}
