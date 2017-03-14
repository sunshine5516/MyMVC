using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;

namespace WXPageService.Entity
{
    public class SinglePicWeixin : SingleButton
    {
        public string key { get; set; }
        /// <summary>
        /// 用户点击按钮后，微信客户端将调起微信相册，完成选择操作后，将选择的相片发送给开发者的服务器，并推送事件给开发者，同时收起相册，随后可能会收到开发者下发的消息。
        /// </summary>
        public SinglePicWeixin() :
            base(PlatformEnums.ButtonType.pic_photo_or_album.ToString())
        { }
    }
}
