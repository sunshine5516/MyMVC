using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class RequestMessageText:RequestMessageBase
    {
        /// <summary>
        /// 文本内容
        /// </summary>
        public string Content { get; set; }
        public override PlatformEnums.RequestMsgType MsgType
        {
            get
            {
                return PlatformEnums.RequestMsgType.Text;
            }
        }
        public RequestMessageText()
        {

        }
    }
}
