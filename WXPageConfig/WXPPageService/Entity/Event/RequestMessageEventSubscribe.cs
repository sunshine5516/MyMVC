using WXPageService.Enums;
namespace WXPageService.Entity
{
    /// <summary>
    /// 订阅事件
    /// </summary>
    public class RequestMessageEventSubscribe:RequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override PlatformEnums.Event Event
        {
            get
            {
                return PlatformEnums.Event.subscribe;
            }
        }
    }
}
