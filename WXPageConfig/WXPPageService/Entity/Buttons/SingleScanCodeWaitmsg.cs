using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;

namespace WXPageService.Entity
{
    public class SingleScanCodeWaitmsg : SingleButton
    {
        /// <summary>
        /// 用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后，将扫码的结果传给开发者，同时收起扫一扫工具，然后弹出“消息接收中”提示框，随后可能会收到开发者下发的消息。
        /// </summary>
        public string key { get; set; }
        public SingleScanCodeWaitmsg() :
            base(PlatformEnums.ButtonType.scancode_waitmsg.ToString())
        { }
    }
}
