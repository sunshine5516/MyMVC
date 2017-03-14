using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Xml;
using WXPageAdmin.Heplers;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageService.Entity;
using WXPageService.Heplers;
using System.Collections.Generic;
using System.Linq;
using static WXPageService.Enums.PlatformEnums;
namespace WXPageService.WXHandler
{
    public class WXMessageHandler: BaseHandler
    {

        private IWXReplayContentsRepository _repository;
        
        public WXMessageHandler() : this(new EFWXReplayContentsRepository()) 
        {
        }
        public WXMessageHandler(IWXReplayContentsRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public string RequestMessage(Stream requestStream)
        {
            byte[] requestByte = new byte[requestStream.Length];
            requestStream.Read(requestByte, 0, (int)requestStream.Length);
            //转换成字符串
            string requestStr = Encoding.UTF8.GetString(requestByte);
            //if (!string.IsNullOrEmpty(requestStr))
            //{
            //封装请求类到xml文件中
            XmlDocument requestDocXml = new XmlDocument();
            requestDocXml.LoadXml(requestStr);
            XmlElement rootElement = requestDocXml.DocumentElement;
            XmlNode MsgType = rootElement.SelectSingleNode("MsgType");
            string msgType = MsgType.InnerText;
            RequestMsgType requestType = (RequestMsgType)Enum.Parse(typeof(RequestMsgType), msgType, true);
            //ResponseMsgType requestType = (ResponseMsgType)Enum.Parse(typeof(ResponseMsgType), msgType, true);     
            //枚举值转换
            ResponseMessageBase responseMessage = null;
            //RequestMessageBase requestXml = null;

            switch (requestType)
            {
                ///文字请求
                case RequestMsgType.Text:
                    //将XML文件封装到实体类requestXml中
                    RequestMessageText requestXml = new RequestMessageText();
                    requestXml.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    requestXml.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    requestXml.Content = rootElement.SelectSingleNode("Content").InnerText;
                    responseMessage = OnTextRequest((RequestMessageText)requestXml);
                    break;
                ///图片请求
                case RequestMsgType.Image:
                    RequestMessageImage Image = new RequestMessageImage();
                    Image.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    Image.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    responseMessage = OnImageRequest((RequestMessageImage)Image);
                    break;
                ///处理事件
                case RequestMsgType.Event:
                    RequestMessageEventBase eventRequest = new RequestMessageEventBase();
                    eventRequest.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    eventRequest.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    string requestEvent = rootElement.SelectSingleNode("Event").InnerText;
                    Event eventType = (Event)Enum.Parse(typeof(Event), requestEvent, true);
                    switch (eventType)
                    {
                        ///
                        case Event.VIEW:
                            RequestMessageImage defaultView = new RequestMessageImage();
                            defaultView.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                            defaultView.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                            responseMessage = OnImageRequest(defaultView);
                            break;
                        ///关注事件
                        case Event.subscribe:
                            RequestMessageImage subscribeEvent = new RequestMessageImage();
                            subscribeEvent.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                            subscribeEvent.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                            responseMessage = OnImageRequest(subscribeEvent);
                            break;
                        ///取消关注事件
                        case Event.unsubscribe:
                            RequestMessageImage unsubscribeEvent = new RequestMessageImage();
                            unsubscribeEvent.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                            unsubscribeEvent.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                            responseMessage = OnImageRequest(unsubscribeEvent);
                            break;
                            ///位置请求
                        case Event.LOCATION:
                            RequestMessageLocation requestLocation = new RequestMessageLocation();
                            requestLocation.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                            requestLocation.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                            //requestLocation.Location_X = rootElement.SelectSingleNode("ToUserName").InnerText;
                            //requestLocation.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                            //requestLocation.Content = rootElement.SelectSingleNode("Content").InnerText;
                            responseMessage = DefaultRequestMsg(requestLocation);
                            break;
                        default:
                            RequestMessageText defaultEvent = new RequestMessageText();
                            defaultEvent.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                            defaultEvent.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                            responseMessage = OnTextRequest((RequestMessageText)defaultEvent);
                            break;
                    }
                    //responseMessage = OnTextRequest(eventRequest);
                    break;
                ///默认文字请求
                default:
                    RequestMessageText defaultMsg = new RequestMessageText();
                    defaultMsg.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    defaultMsg.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    responseMessage = OnTextRequest((RequestMessageText)defaultMsg);
                    break;

            }

            var xmlInfo = EntityHelper.GetResponseTextXml((ResponseMessageText)responseMessage);


            return xmlInfo;
        }
        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public  ResponseMessageBase OnTextRequest(RequestMessageText requestMessage)
        {
            ResponseMessageText responseText = (ResponseMessageText)ResponseMessageBase.CreateResponseMsg(requestMessage, ResponseMsgType.Text);
            var result = new StringBuilder();
            var replayContent= _repository.FindAllInfo.Where(p => p.KeyName == requestMessage.Content.ToString()&&p.RequestType== "关键字回复").FirstOrDefault();
            ///数据库关键字查询
            if (replayContent==null)
            {
                result.AppendFormat("您刚才发送了文字信息：{0}\r\n\r\n", requestMessage.Content.ToString());
                result.AppendLine("\r\n");
                result.AppendLine(
                    "您还可以发送【位置】【图片】【语音】【视频】等类型的信息（注意是这几种类型，不是这几个文字），查看不同格式的回复.!~~~~~");
                responseText.Content = result.ToString();
                
            }
            else///返回默认值
            {
                responseText.Content = replayContent.ReplayContent.ToString();
            }
            
            return responseText;
        }
        /// <summary>
        /// 图片请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public static ResponseMessageBase OnImageRequest(RequestMessageImage requestMessage)
        {
            //ResponseMessageImage responseImage =(ResponseMessageImage)ResponseMessageBase.CreateResponseMsg(requestMessage, ResponseMsgType.Image);
            //return responseImage;
            ResponseMessageText responseText = (ResponseMessageText)ResponseMessageBase.CreateResponseMsg(requestMessage, ResponseMsgType.Text);
            var result = new StringBuilder();
            result.AppendFormat("我不明白你的意思，傻逼,关注事件");
            responseText.Content = result.ToString();
            return responseText;
        }
        /// <summary>
        /// 默认消息，事件的处理
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public static ResponseMessageBase DefaultRequestMsg(RequestMessageBase requestMessage)
        {
            ResponseMessageText responseText = (ResponseMessageText)ResponseMessageBase.CreateResponseMsg(requestMessage, ResponseMsgType.Text);
            var result = new StringBuilder();
            result.AppendFormat("sorry ,我暂时还不能理解你这个SB发送的消息");
            result.Append(requestMessage.MsgType);
            result.AppendLine(
                "您可以发送【位置】【图片】【语音】【视频】等类型的信息（注意是这几种类型，不是这几个文字），查看不同格式的回复.!~~~~~");
            responseText.Content = result.ToString();
            return responseText;
        }
        //public static ResponseMessageBase OnEventRequest()
        //{

        //}
    }
}