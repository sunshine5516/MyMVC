using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Enums;
using static WXPageService.Enums.PlatformEnums;

namespace WXPageService.Entity
{
    /// <summary>
    /// 基础的请求类
    /// </summary>
    public class RequestMessageBase:MessageBase
    {
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public long MsgId { get; set; }
        public virtual RequestMsgType MsgType { get; }
        public RequestMessageBase()
        {

        }
    }
}
