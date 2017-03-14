using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageModel
{
    /// <summary>
    /// 关键字回复
    /// </summary>
    public class KeyContents
    {
        /// <summary>
        /// 回复内容ID
        /// </summary>
        [Key]
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [DisplayName("标题")]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        [DisplayName("内容")]
        public string ReplayContent { get; set; }
        /// <summary>
        /// 关键字Id
        /// </summary>
        [Required]
        [DisplayName("关键字Id")]
        public string KeyId { get; set; }
        /// <summary>
        ///回复类型
        /// </summary>
        [Required]
        [DisplayName("回复类型")]
        public string ReplyType { get; set; }
        /// <summary>
        ///图片路径
        /// </summary>
        [DisplayName("图片路径")]
        public string ImageUrl { get; set; }
        //public string IsTop { get; set; }
        /// <summary>
        ///图片路径
        /// </summary>
        //[DisplayName("图片路径")]
        //public string ArticleUrl { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        [DisplayName("创建时间")]
        public DateTime InsertTime { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [DisplayName("状态")]
        public string State { get; set; }
      
    }
}
