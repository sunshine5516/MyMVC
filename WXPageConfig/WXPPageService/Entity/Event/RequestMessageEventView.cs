using WXPageService.Enums;
namespace WXPageService.Entity
{
    /// <summary>
    /// 点击菜单跳转链接时的事件推送
    /// </summary>
    public class RequestMessageEventView: RequestMessageEventBase
    {
        /// <summary>
        /// 跳转事件
        /// </summary>
        public override PlatformEnums.Event Event
        {
            get
            {
                return PlatformEnums.Event.VIEW;
            }
        }
        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey{get;set;}
    }
}
