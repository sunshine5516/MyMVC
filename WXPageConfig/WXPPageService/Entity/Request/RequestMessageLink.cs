

using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 链接消息
    /// </summary>
    public class RequestMessageLink:RequestMessageBase
    {
        /// <summary>
        /// 
        /// </summary>
        public override PlatformEnums.RequestMsgType MsgType
        {
            get
            {
                return PlatformEnums.RequestMsgType.Link;
            }
        }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }
    }
}
