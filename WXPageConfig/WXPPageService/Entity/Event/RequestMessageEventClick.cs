using WXPageService.Enums;
namespace WXPageService.Entity
{
    /// <summary>
    /// 点击菜单拉取消息时的事件推送
    /// </summary>
    public class RequestMessageEventClick : RequestMessageEventBase
    {
        /// <summary>
        /// 点击事件
        /// </summary>
        public override PlatformEnums.Event Event
        {
            get
            {
               return PlatformEnums.Event.CLICK;
            }
        }
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}
