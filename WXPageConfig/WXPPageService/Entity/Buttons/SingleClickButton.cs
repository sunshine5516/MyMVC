using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 单击按钮
    /// </summary>
    public class SingleClickButton : SingleButton
    {
        public string key { get; set; }
        public SingleClickButton() : base(PlatformEnums.ButtonType.click.ToString())
        {

        }

    }
}
