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
    /// 子菜单
    /// </summary>
    public class AdminMenu
    {
        /// <summary>
        /// 回复内容ID
        /// </summary>
        [Key]
        [Required]
        public string Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Required]
        [DisplayName("菜单名称")]
        public string Name { get; set; }
        /// <summary>
        /// 对应的界面
        /// </summary>
        [DisplayName("对应界面")]
        public string Url { get; set; }
        /// <summary>
        /// 菜单描述
        /// </summary>
        [Required]
        [DisplayName("菜单描述")]
        public string Info { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Permission { get; set; }
        /// <summary>
        /// 导航图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 父Id
        /// </summary>
        [Required]
        [DisplayName("父Id")]
        public string ParentId { get; set; }
        /// <summary>
        /// 导航类型
        /// </summary>
        [Required]
        [DisplayName("导航类型")]
        public string Type { get; set; }
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
