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
    /// 按钮事件
    /// </summary>
    public class SingleButton
    {
        [Key]
        [DisplayName("按钮ID")]
        public string Id { get; set; }
        [Required]
        [DisplayName("菜单ID")]
        public string SubMenuId { get; set; }
        [Required]
        [DisplayName("序号")]
        public int Index { get; set; }
        [Required]
        [DisplayName("按钮名称")]
        public string Name { get; set; }
        [Required]
        [DisplayName("类型")]
        public string Type { get; set; }
        [DisplayName("处理事件")]
        public string Key { get; set; }
        [DisplayName("链接地址")]
        public string Url { get; set; }

        [DisplayName("状态")]
        public string State { get; set; }
        [Required]
        [DisplayName("插入时间")]
        public DateTime InsertTime { get; set; }
    }
}
