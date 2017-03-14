using Newtonsoft.Json;
using System;
using System.Data;
//using Senparc.Weixin.MP.Entities.Request;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using WXPageAdmin.Heplers;
using WXPageService.WXHandler;
using WXPageService;
using WXPageService.Entity;
using WXPageService.Enums;
using WXPageService.Heplers;

namespace WXPageAdmin.Controllers
{
    /// <summary>
    /// 测试
    /// </summary>
    public class WeixinController : BaseController
    {
        //与微信公众账号后台的Token设置保持一致，区分大小写。
        //public static readonly string EncodingAESKey = "lXwNXASPmBC7EK8wilkHbwUbDEXjSBqlLdXT2uPas2c";
        //public static readonly string AppId = "wxe948ca27920dacda";
        //public static readonly string Token = "weixinTest";
        public static string token = "";

        public static readonly string EncodingAESKey = "lXwNXASPmBC7EK8wilkHbwUbDEXjSBqlLdXT2uPas2c";
        public static readonly string AppId = "wxfd537a1b809515aa";
        public static readonly string Token = "weixinTest";



        public static string AccessToken()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token";
            string param = "grant_type=client_credential&appid=wxfd537a1b809515aa&secret=2ad4fa081250612384f04bbbd7bb6df0";
            token = HttpUtils.HttpGet(url, param);
            return token;
        }
        /// <summary>
        /// 获取token
        /// </summary>
        /// <returns></returns>
        public string test()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token";
            string param = "grant_type=client_credential&appid=wxfd537a1b809515aa&secret=2ad4fa081250612384f04bbbd7bb6df0";
            string token1 = HttpUtils.HttpGet(url, param);
            if (token1.Contains("errcode"))
            {
                //反序列化字符串
                //ErrcodeEntity errCode = new ErrcodeEntity();
                var errCode = JsonConvert.DeserializeObject<object>(token);
                //errCode = JsonConvert.SerializeObject(errCode)();
                //返回错误编码
                //return "错误编码" + errCode.errCode;
                return "hello";
            }
            else
            {
                AsseccTokenResult tokenResult = JsonConvert.DeserializeObject<AsseccTokenResult>(token);
                return tokenResult.access_token;
            }
            //return token;

            //return View();
        }
        // GET: Weixin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                //返回随机字符串则表示验证通过
                return Content(echostr);
            }
            else
            {
                return Content("failed:" + signature + "," + CheckSignature.Check(timestamp, nonce, Token) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
            }
        }



        //#region 自动回复
        ///// <summary>
        ///// 自动默认回复
        ///// </summary>
        ///// <param name="FromUserName"></param>
        ///// <param name="ToUserName"></param>
        ///// <param name="WeChat_ID"></param>
        ///// <param name="User_ID"></param>
        ///// <returns></returns>
        //public string GetDefault(string FromUserName, string ToUserName, string WeChat_ID, string User_ID)
        //{
        //    string resXml = "";
        //    string sqlWhere = !string.IsNullOrEmpty(WeChat_ID) ? "WeChat_ID=" + WeChat_ID + " and reply_fangshi=1" : "";
        //    //获取保存的默认回复设置信息
        //    //DataTable dtDefault = replydal.GetRandomList(sqlWhere, "1").Tables[0];

        //    //if (dtDefault.Rows.Count > 0)
        //    //{
        //    //    string article_id = dtDefault.Rows[0]["article_id"].ToString();
        //    //    string reply_type = dtDefault.Rows[0]["reply_type"].ToString();
        //    //    string reply_text = dtDefault.Rows[0]["reply_text"].ToString();
        //    resXml = "<xml><ToUserName><![CDATA[" + FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + "hello hope you can save me" + "]]></Content><FuncFlag>0</FuncFlag></xml>";
        //    //}

        //    return resXml;
        //}




        //#endregion 默认回复



        //#region 关键字回复
        ///// <summary>
        ///// 关键字回复
        ///// </summary>
        ///// <param name="FromUserName"></param>
        ///// <param name="ToUserName"></param>
        ///// <param name="Content"></param>
        ///// <returns></returns>
        //public string GetKeyword(string FromUserName, string ToUserName, string Content)
        //{
        //    string resXml = "";

        //    resXml = GetDefault(FromUserName, ToUserName, "oYyiuwcbx3wbybqacNraBZgwR1uY", "oYyiuwXGtF1aKg8CP_e3b44Xy_-o");


        //    return resXml;
        //}
        //#endregion 关键字回复




        private void ResponseMsg(RequestMessageText requestXml)
        {
            string resXml = "";
            string WeChat_Key = Request.QueryString["key"];

            try
            {

                resXml = "<xml><ToUserName><![CDATA[" + requestXml.FromUserName + "]]></ToUserName><FromUserName><![CDATA[" + requestXml.ToUserName + "]]></FromUserName><CreateTime>" + DateTime.Now + "</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[" + "hello hope you can save me" + "]]></Content><FuncFlag>0</FuncFlag></xml>";
            }
            catch (Exception ex)
            {
                //Writebug("异常：" + ex.Message + "Struck:" + ex.StackTrace.ToString());
            }
            //发送xml格式的信息到微信中
            Response.Write(resXml);
            Response.End();
        }
        [HttpPost]
        [ActionName("Index")]
        public void Post(string signature, string timestamp, string nonce, string echostr)
        {
            /*
             
             
             待验证
             */
            //接收信息流
            Stream requestStream = System.Web.HttpContext.Current.Request.InputStream;
            var responseMessage = _WXMessageHandler.RequestMessage(requestStream);
            Response.Write(responseMessage);
            Response.End();
        }
    }
    /// <summary>
    /// 自定义菜单
    /// </summary>
    /// <returns></returns>
    //public ActionResult DefineMenu()
    //{

    //    return View();
    //}
    //var result = CommonApi.CreateMenu("-7_pJ--gMznD_vt8EiSaF9HKWQBMPb1NvFuIRffcsW-egvZqjVPByd-tounDgMecQp-tmMkvFi24lJKUOWOxjPwlN6W1o6fwuWu-TnBWy4EVYIgAGARUE", bg);


}