using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WXPageDomain.Models
{
    public class WXAccountInfo
    {
       
        [Key]
        public string Id { get; set; }
        /// <summary>
        /// 账号名称
        /// </summary>
        [Required]
        [DisplayName("账号名称")]
        public string AccountName { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [Required]
        [DisplayName("微信号")]
        public string WXAccount { get; set; }
        /// <summary>
        /// 服务器地址
        /// </summary>
        [Required]
        [DisplayName("服务器地址")]
        public string InterfaceURL { get; set; }
        /// <summary>
        /// 微信Token(令牌)
        /// </summary>
        [DisplayName("微信Token(令牌)")]
        public string Token { get; set; }
        /// <summary>
        /// 消息加解密密钥
        /// </summary>
        [Required] 
        [DisplayName("消息加解密密钥")]
        public string EncodingAESKey { get; set; }
        /// <summary>
        /// AppID(应用ID)
        /// </summary>
        [Required]
        [DisplayName("AppID(应用ID)")]
        public string AppID { get; set; }
        /// <summary>
        /// AppSecret(应用密钥)
        /// </summary>
        [Required]
        [DisplayName("应用密钥")]
        public string AppSecret { get; set; }
        /// <summary>
        /// 微信号类型
        /// </summary>
        [DisplayName("微信号类型")]
        public string WXType { get; set; }
        [DisplayName("创建时间")]
        public DateTime InsertTime { get; set; }
        [DisplayName("状态")]
        public string State { get; set; }

    }
}