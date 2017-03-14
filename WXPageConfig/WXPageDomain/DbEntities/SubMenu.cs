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
    public class SubMenu
    {
        [Key]
        [DisplayName("菜单ID")]
        public string ID { get; set; }
        public List<SingleButton> SingleButtons { get; set; }
        [Required]
        [DisplayName("菜单名称")]
        public string Name { get; set; }
        [Required]
        [DisplayName("微信ID")]
        public string WXAccountID { get; set; }
        [Required]
        [DisplayName("插入时间")]
        public DateTime InsertTime { get; set; }
        [Required]
        [DisplayName("菜单状态")]
        public string State { get; set; }
    }
}
