using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 返回图片消息
    /// </summary>
    public class RequestMessageImage:RequestMessageBase
    {
        /// <summary>
        /// 类型为图片类型
        /// </summary>
        public override PlatformEnums.RequestMsgType MsgType
        {
            get
            {
                return PlatformEnums.RequestMsgType.Image;
            }
        }
        /// <summary>
        /// 图片链接（由系统生成）
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }

    }
}
