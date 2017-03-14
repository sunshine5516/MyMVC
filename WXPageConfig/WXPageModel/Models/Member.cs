using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageModel
{
    public class Member
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("会员账号")]
        [Required(ErrorMessage = "请输入Enail地址")]
        [Description("我们直接以Email作为登录账号")]
        [MaxLength(60, ErrorMessage = "最长不能超过60个字符")]
        [DataType(DataType.EmailAddress)]
        public string Account { get; set; }
        [DisplayName("会员密码")]
        [Required(ErrorMessage = "请输入密码")]
        [Description("密码将会加密")]
        [MaxLength(60, ErrorMessage = "最长不能超过60个字符")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("中文名称")]
        [Required(ErrorMessage = "请输入中文")]
        [MaxLength(5, ErrorMessage = "最长不能超过5个字符")]
        public string Name { get; set; }
        [DisplayName("昵称")]
        [Required(ErrorMessage = "请输入中文昵称")]
        [MaxLength(15, ErrorMessage = "最长不能超过15个字符")]
        public string NickName { get; set; }

        [DisplayName("注册时间")]
        public DateTime RegisterOn { get; set; }

        [DisplayName("会员启用认证码")]
        [MaxLength(36)]
        [Description("当AuthCode为NULL代表已经通过认证")]
        public string AuthCode { get; set; }
        [DisplayName("创建时间")]
        public DateTime InsertTime { get; set; }
        [DisplayName("状态")]
        public string State { get; set; }
    }
}
