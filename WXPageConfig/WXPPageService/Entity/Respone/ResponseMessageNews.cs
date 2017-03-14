using System.Collections.Generic;
using WXPageService.Enums;
using static WXPageService.Enums.PlatformEnums;
namespace WXPageService.Entity
{
    public class ResponseMessageNews : ResponseMessageBase
    {
        public override ResponseMsgType MsgType
        {
            get
            {
                return ResponseMsgType.News;
            }
        }
        /// <summary>
        /// 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// </summary>
        List<Article> Articles { get; set; }
        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount
        {
            get
            {
                return Articles == null ? 0 : Articles.Count;
            }
            set
            {
                //这里开放set只为了逆向从Response的Xml转成实体的操作一致性，没有实际意义。
            }
        }
        public ResponseMessageNews()
        {
            Articles = new List<Article>();
        }

    }
}
