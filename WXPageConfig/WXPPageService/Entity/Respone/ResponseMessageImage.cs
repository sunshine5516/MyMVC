using static WXPageService.Enums.PlatformEnums;

namespace WXPageService.Entity
{
    public class ResponseMessageImage: ResponseMessageBase
    {
        /// <summary>
        /// 返回图片类型的请求
        /// </summary>
        public override ResponseMsgType MsgType
        {
            get
            {
                return ResponseMsgType.Image;
            }
        }
    }
}
