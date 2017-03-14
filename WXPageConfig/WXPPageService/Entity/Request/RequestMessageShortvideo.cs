﻿

using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 小视频消息
    /// </summary>
   public class RequestMessageShortvideo:RequestMessageBase
    {
        /// <summary>
        /// 小视频
        /// </summary>
        public override PlatformEnums.RequestMsgType MsgType
        {
            get
            {
                return PlatformEnums.RequestMsgType.Shortvideo;
            }
        }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
}
