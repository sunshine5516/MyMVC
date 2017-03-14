using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPageDomain.Models
{
    public class LoginViewModel
    {
        [DisplayName("会员账号")]
        [Required(ErrorMessage = "请输入{0}")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "请输入您的账号")]
        public string UserName { get; set; }
        [DisplayName("会员密码")]
        [Required(ErrorMessage = "请输入{0}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "记住密码?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "会员账号")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "会员密码")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认密码")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
