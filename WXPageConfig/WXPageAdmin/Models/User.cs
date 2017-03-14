using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WXPageAdmin.Models
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string WXAccount { get; set; }
        //public string PhoneNum { get; set; }
        public string InsertTime { get; set; }
        public string EndTime { get; set; }
        public string WXType { get; set; }
        public string State { get; set; }
    }
}