using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WXPageAdmin.Heplers
{
    public class HttpUtils
    {
        /// <summary>
        /// 发送Get请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string HttpGet(string Url, string paramStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url+(paramStr==""?"":"?")+paramStr);
            request.Method = "Get";
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream,Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return retString;

        }
        /// <summary>
        /// 发送Post请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, string paramStr)
        {
            //if (paramStr != null)
            //{
                byte[] data = Encoding.UTF8.GetBytes(paramStr.ToString());
            //}
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "Post";
            request.ContentLength = data.Length;
            request.ContentType = "text/html;charset=UTF-8";
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(data, 0, data.Length);
            request.Timeout = 90000;
            request.Headers.Set("WXMenu", "no-cache");

            //返回服务器读取信息
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Dispose();
            myResponseStream.Dispose();
            return retString;
        }
    }
}