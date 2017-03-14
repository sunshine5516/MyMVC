using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageAdmin.Heplers;
using WXPageService.Entity;

namespace WXPageService.WXHandler
{
    public class BaseHandler
    {
        /// <summary>
        /// 微信accessToken
        /// </summary>
        public static string token = "";
        public static string code = "";
        /// <summary>
        /// 微信服务器IP地址
        /// </summary>
        public static string IPAddress = "";
        public static readonly string EncodingAESKey = "lXwNXASPmBC7EK8wilkHbwUbDEXjSBqlLdXT2uPas2c";
        public static readonly string AppId = "wxfd537a1b809515aa";
        public static readonly string Token = "weixinTest";
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken(string AppId, string secret)
        {
            try
            {
                string url = "https://api.weixin.qq.com/cgi-bin/token";
                string param = "grant_type=client_credential&appid=" + AppId + "&secret=" + secret + "";
                token = HttpUtils.HttpGet(url, param);
                if (token.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(token);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return "错误编码" + errCode.errCode;
                }
                else
                {
                    AsseccTokenResult tokenResult = JsonConvert.DeserializeObject<AsseccTokenResult>(token);
                    return tokenResult.access_token;
                }
            }
            catch
            {
                return null;
            }
        }
        public static string GetAccessToken()
        {
            try
            {
                string url = "https://api.weixin.qq.com/cgi-bin/token";
                string param = "grant_type=client_credential&appid=wxfd537a1b809515aa&secret=2ad4fa081250612384f04bbbd7bb6df0";
                token = HttpUtils.HttpGet(url, param);
                if (token.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(token);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return "错误编码" + errCode.errCode;
                }
                else
                {
                    AsseccTokenResult tokenResult = JsonConvert.DeserializeObject<AsseccTokenResult>(token);
                    return tokenResult.access_token;
                }

            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static object GetIPAddress()
        {
            try
            {
                string accessToken = GetAccessToken();
                string url = "https://api.weixin.qq.com/cgi-bin/getcallbackip";
                string param = "access_token=" + accessToken + "";
                IPAddress = HttpUtils.HttpGet(url, param);
                if (IPAddress.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(IPAddress);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return "错误编码" + errCode.errCode;
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<object>(IPAddress);
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 用户授权，获取Code
        /// </summary>
        /// <returns></returns>
        public static string GetCode()
        {
            try
            {
                string url = "https://open.weixin.qq.com/connect/oauth2/authorize";
                    
                string param = "appid=wxfd537a1b809515aa" +
                    "&redirect_uri=http://www.wavesun.cn&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect";
                code = HttpUtils.HttpGet(url, param);
                if (code.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(code);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return "错误编码" + errCode.errCode;
                }
                else
                {
                    AsseccTokenResult tokenResult = JsonConvert.DeserializeObject<AsseccTokenResult>(code);
                    return tokenResult.access_token;
                }

            }
            catch
            {
                return "发生未知错误";
            }
        }
    }
}
