using WXPageService.Enums;
using static WXPageService.Enums.PlatformEnums;
namespace WXPageService.Entity
{
    public class ResponseMessageVideo:ResponseMessageBase
    {
        /// <summary>
        /// 响应视频请求
        /// </summary>
        public override ResponseMsgType MsgType
        {
            get
            {
                return ResponseMsgType.Video;
            }
        }
    }
}
