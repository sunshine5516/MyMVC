using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;

namespace WXPageService.Entity
{
    public class SinglePicSysPhoto : SingleButton
    {
        public string key { get; set; }
        /// <summary>
        /// 用户点击按钮后，微信客户端将调起系统相机，完成拍照操作后，会将拍摄的相片发送给开发者，并推送事件给开发者，同时收起系统相机，随后可能会收到开发者下发的消息。
        /// </summary>
        public SinglePicSysPhoto() :
            base(PlatformEnums.ButtonType.pic_sysphoto.ToString())
        { }
    }
}
