using WXPageService.Enums;
using static WXPageService.Enums.PlatformEnums;
namespace WXPageService.Entity
{
    /// <summary>
    /// 取消订阅事件
    /// </summary>
    public class RequestMessageEventUnsubscribe:RequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override PlatformEnums.Event Event
        {
            get
            {
                return PlatformEnums.Event.unsubscribe;
            }
        }
    }
}
