using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;

namespace WXPageService.Entity
{
    public class SinglePicPhotoOrAlbum : SingleButton
    {
        public string key { get; set; }
        /// <summary>
        /// 用户点击按钮后，微信客户端将弹出选择器供用户选择“拍照”或者“从手机相册选择”。用户选择后即走其他两种流程。
        /// </summary>
        public SinglePicPhotoOrAlbum() :
            base(PlatformEnums.ButtonType.pic_photo_or_album.ToString())
        { }
    }
}
