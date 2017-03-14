
using System;
using WXPageService.Entity;
using static WXPageService.Enums.PlatformEnums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 微信公众号响应回复消息基类
    /// </summary>
    public class ResponseMessageBase:MessageBase
    {
        public virtual ResponseMsgType MsgType { get; }
        /// <summary>
        /// 根据请求的类型返回数据
        /// </summary>
        /// <param name="requestMsg"></param>
        /// <returns></returns>
        public static ResponseMessageBase CreateResponseMsg(RequestMessageBase requestMsg, ResponseMsgType msgType)
        {
            ResponseMessageBase responseMsg = null;
            try
            {
                switch (msgType)
                {
                    //
                    case ResponseMsgType.Text:
                        responseMsg = new ResponseMessageText();
                        
                        break;
                    case ResponseMsgType.Image:
                        responseMsg = new ResponseMessageImage();
                        break;
                    case ResponseMsgType.Video:
                        responseMsg = new ResponseMessageVideo();
                        break;
                    case ResponseMsgType.Voice:
                        responseMsg = new ResponseMessageVoice();
                        break;
                    case ResponseMsgType.News:
                        responseMsg = new ResponseMessageNews();
                        break;
                }
                responseMsg.CreateTime = DateTime.Now;
                responseMsg.FromUserName = requestMsg.FromUserName;
                requestMsg.ToUserName = requestMsg.ToUserName;
            }
            catch (Exception ex)
            {
                //throw new WeixinException("CreateFromRequestMessage过程发生异常", ex);
            }
            return responseMsg;
        }
    }
   
}
