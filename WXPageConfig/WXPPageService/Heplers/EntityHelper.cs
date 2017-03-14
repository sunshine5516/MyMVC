using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WXPageService.Heplers
{
    /// <summary>
    /// 
    /// </summary>
    public static class EntityHelper
    {
        /// <summary>
        /// 实体转化为Xml
        /// </summary>
        /// <returns></returns>
        public static XDocument ConvertEntityToXml()
        {

            return null;
        }

        /// 实体对象转换成XElement对象
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns>XElement对象</returns>
        public static XElement GetXElement(this object entity)
        {
            try
            {
                XElement element = new XElement("xml");
                Type type = entity.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    object value = propertyInfo.GetValue(entity, null);
                    if (value == null) continue;

                    XElement temp = new XElement(propertyInfo.Name, value);
                    element.Add(temp);
                }
                return element;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 封装返回的文字信息
        /// </summary>
        /// <returns></returns>
        public static string GetResponseTextXml(Entity.ResponseMessageText responseText)
        {
            string resXml = "";
            resXml = "<xml><ToUserName><![CDATA[" + responseText.FromUserName + "]]></ToUserName>"+
                "<FromUserName><![CDATA[" + responseText.ToUserName + "]]></FromUserName>"+
                "<CreateTime>" + DateTime.Now + "</CreateTime>"+
                "<MsgType><![CDATA[text]]></MsgType>"+
                "<Content><![CDATA[" + responseText.Content + "]]></Content>"+
                "<FuncFlag>0</FuncFlag></xml>";
            return resXml;
        }

    }
}
