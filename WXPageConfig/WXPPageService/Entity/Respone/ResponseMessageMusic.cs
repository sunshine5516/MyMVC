using WXPageService.Enums;
using static WXPageService.Enums.PlatformEnums;
namespace WXPageService.Entity
{
    public class ResponseMessageMusic:ResponseMessageBase
    {
        public override ResponseMsgType MsgType
        {
            get
            {
                return ResponseMsgType.Music;
            }
        }
    }
}
