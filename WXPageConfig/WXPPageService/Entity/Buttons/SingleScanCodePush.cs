using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 扫码推按钮
    /// </summary>
    public class SingleScanCodePush : SingleButton
    {
        /// <summary>
        /// 用户点击按钮后，微信客户端将调起扫一扫工具，完成扫码操作后显示扫描结果（如果是URL，将进入URL），且会将扫码的结果传给开发者，开发者可以下发消息。
        /// 类型为scancode_push时必须。
        /// </summary>
        public string key { get; set; }
        public SingleScanCodePush() :
            base(PlatformEnums.ButtonType.scancode_push.ToString())
        { }
    }
}
