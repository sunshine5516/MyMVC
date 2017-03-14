using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageDomain.Models
{
    /// <summary>
    /// 关键字回复
    /// </summary>
    public class KeyWord
    {
        /// <summary>
        /// 回复ID
        /// </summary>
        [Key]
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [Required]
        [DisplayName("微信号")]
        public string WXAccountId { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        [Required]
        [DisplayName("关键字")]
        public string KeyName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Note { get; set; }
        
        /// <summary>
        /// 返回类型
        /// </summary>
        [Required]
        [DisplayName("返回类型")]
        public string ReplyType { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [DisplayName("状态")]
        public string State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DisplayName("创建时间")]
        public DateTime InsertTime { get; set; }
    }
}
