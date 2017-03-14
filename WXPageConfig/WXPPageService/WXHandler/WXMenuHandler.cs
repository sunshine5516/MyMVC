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
    public class WXMenuHandler:BaseHandler
    {
        /// <summary>
        /// 获取用户自定义菜单
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static object GetMenu()
        {
            try
            {
                string token = GetAccessToken();
                string url = "https://api.weixin.qq.com/cgi-bin/menu/get";
                string param = "access_token=" + token + "";
                var result = HttpUtils.HttpGet(url, param);
                if (result.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(result);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return errCode.errCode;
                }
                else
                {
                    var jsonResult = JsonConvert.DeserializeObject<object>(result);
                    return jsonResult;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 删除自定义菜单
        /// </summary>
        /// <returns></returns>
        public static object DeleteMenu()
        {
            try
            {
                string token = GetAccessToken();
                string url = "https://api.weixin.qq.com/cgi-bin/menu/delete";
                string param = "access_token=" + token + "";
                var result = HttpUtils.HttpGet(url, param);
                if (result.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(result);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return "错误编码" + errCode.errCode;
                }
                else
                {
                    var jsonResult = JsonConvert.DeserializeObject<object>(result);
                    return jsonResult;
                }
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// 自定义菜单
        /// </summary>
        /// <param name="data">post数据</param>
        /// <returns></returns>
        public static string CreateMenu(string data)
        {
            try
            {
                string token = GetAccessToken();
                string url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=" + token + "";
                //string param = "access_token=" + token + "";
                var result = HttpUtils.HttpPost(url, data);
                if (result.Contains("errcode"))
                {
                    //反序列化字符串
                    ErrcodeEntity errCode = new ErrcodeEntity();
                    errCode = JsonConvert.DeserializeObject<ErrcodeEntity>(result);
                    //errCode = JsonConvert.SerializeObject(errCode)();
                    //返回错误编码
                    return "错误编码" + errCode.errCode;
                }
                else
                {
                    return "cccc";
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
