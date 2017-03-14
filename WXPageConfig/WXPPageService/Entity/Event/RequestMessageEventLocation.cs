using WXPageService.Enums;
namespace WXPageService.Entity
{
    /// <summary>
    /// 上报地理位置事件
    /// </summary>
    public class RequestMessageEventLocation: RequestMessageEventBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public override PlatformEnums.Event Event
        {
            get
            {
                return PlatformEnums.Event.LOCATION;
            }
        }
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Latitude { get;set;}
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public string Precision { get; set; }
    }
}
