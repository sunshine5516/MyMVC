
using WXPageService.Enums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 地理位置消息
    /// </summary>
    public class RequestMessageLocation:RequestMessageBase
    {
        public override PlatformEnums.RequestMsgType MsgType
        {
            get
            {
                return PlatformEnums.RequestMsgType.Location;
            }
        }
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public string Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
    }
}
