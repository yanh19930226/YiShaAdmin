using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.GoodsManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-07-08 10:52
    /// 描 述：实体类
    /// </summary>
    [Table("goods_category")]
    public class CategoryEntity : BaseExtensionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Title { get; set; }
    }
}
