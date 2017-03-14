using static WXPageService.Enums.PlatformEnums;

namespace WXPageService.Entity
{
    public class ResponseMessageVoice:ResponseMessageBase
    {
        /// <summary>
        /// 响应语音消息
        /// </summary>
        public override ResponseMsgType MsgType
        {
            get
            {
                return ResponseMsgType.Voice;
            }
        }
    }
}
