﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WXPageService.Entity;
/*----------------------------------------------------------------

文件名：IMessageHandler.cs
文件功能描述：MessageHandler接口

----------------------------------------------------------------*/
namespace WXPPageService.WXHandler
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMessageHandler<TRequest, TResponse>
        where TRequest : RequestMessageBase
        where TResponse : ResponseMessageBase
    {
        /// <summary>
        /// 发送者用户名（OpenId）
        /// </summary>
        string WeixinOpenId { get; }

        /// <summary>
        /// 取消执行Execute()方法。一般在OnExecuting()中用于临时阻止执行Execute()。
        /// 默认为False。
        /// 如果在执行OnExecuting()执行前设为True，则所有OnExecuting()、Execute()、OnExecuted()代码都不会被执行。
        /// 如果在执行OnExecuting()执行过程中设为True，则后续Execute()及OnExecuted()代码不会被执行。
        /// 建议在设为True的时候，给ResponseMessage赋值，以返回友好信息。
        /// </summary>
        bool CancelExcute { get; set; }

        /// <summary>
        /// 请求实体
        /// </summary>
        TRequest RequestMessage { get; set; }
        /// <summary>
        /// 响应实体
        /// 只有当执行Execute()方法后才可能有值
        /// </summary>
        TResponse ResponseMessage { get; set; }

        /// <summary>
        /// 是否使用了MessageAgent代理
        /// </summary>
        bool UsedMessageAgent { get; set; }

        /// <summary>
        /// 忽略重复发送的同一条消息（通常因为微信服务器没有收到及时的响应）
        /// </summary>
        bool OmitRepeatedMessage { get; set; }


        /// <summary>
        /// 执行微信请求前触发
        /// </summary>
        void OnExecuting();

        /// <summary>
        /// 执行微信请求
        /// </summary>
        void Execute();

        /// <summary>
        /// 执行微信请求后触发
        /// </summary>
        void OnExecuted();
    }
}
