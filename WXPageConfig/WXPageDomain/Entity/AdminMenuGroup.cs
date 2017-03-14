using System;
using System.Collections.Generic;
using WXPageModel;

namespace WXPageDomain.Models
{
    public class AdminMenuGroup
    {
        public List<AdminMenu> AdminMenuArray { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public string Permission { get; set; }
        public string Info { get; set; }
        //public string ParentId { get; set; }
        //public string Type { get; set; }
        //public DateTime InsertTime { get; set; }
        //public string State { get; set; }
    }
}
