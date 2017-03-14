using static WXPageService.Enums.PlatformEnums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 返回文字类型的请求
    /// </summary>
    public class ResponseMessageText:ResponseMessageBase
    {
        public override ResponseMsgType MsgType
        {
            get
            {
                return ResponseMsgType.Text;
            }
        }
        public string Content { get; set; }
    }
}
