using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXPageAdmin.Models
{
    /// <summary>
    /// 关键字回复实体类
    /// </summary>
    public class KeyValueModel
    {
        public string key { get; set; }
        public string value { get; set; }
        public string replayType { get; set; }
        //public string WXAccountId { get; set; }
        //public string ReplayType { get; set; }
        //public string ReplayContent { get; set; }
        //public string RequestType { get; set; }
    }
}