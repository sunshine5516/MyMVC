using WXPageService.Enums;
using static WXPageService.Enums.PlatformEnums;
namespace WXPageService.Entity
{
    /// <summary>
    /// 事件基类型
    /// </summary>
    public class RequestMessageEventBase:MessageBase
    {
        //public virtual RequestMsgType MsgType { get; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public  RequestMsgType MsgType
        {
            get { return RequestMsgType.Event; }
        }
        public virtual PlatformEnums.Event Event { get; }
    }
}
