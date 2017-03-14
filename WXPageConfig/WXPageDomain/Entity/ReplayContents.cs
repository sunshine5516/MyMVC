using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WXPageDomain.Models
{
    [DisplayName("商品类别")]
    public class ReplayContents
    {
        /// <summary>
        /// 关键字ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        public string WXAccountId { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string KeyName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("备注")]
        public string Note { get; set; }

        /// <summary>
        /// 返回类型
        /// </summary>
        public string ReplyType { get; set; }
        /// <summary>
        /// 请求类型
        /// </summary>
        public string RequestType { get; set; }
        /// <summary>
        /// 回复内容
        /// 以文本形式存在数据库中
        /// </summary>
        public string ReplayContent { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime InsertTime { get; set; }






        /// <summary>
        /// 回复内容ID
        /// </summary>
        public string ReplyId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        ///图片路径
        /// </summary>
        public string ImageUrl { get; set; }

        ///// <summary>
        /////回复类型
        ///// </summary>
        //public string Type { get; set; }




    }
}