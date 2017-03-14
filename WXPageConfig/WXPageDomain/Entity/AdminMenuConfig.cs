using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using WXPageDomain.Models;

namespace WXPageDomain.Models
{
    //[Serializable]
    public class AdminMenuConfig
    {
        public AdminMenuConfig()
        {
        }

        //public AdminMenuGroup[] AdminMenuGroups { get; set; }
        public List<AdminMenuGroup>  AdminMenuGroups { get; set; }

    }

    //[Serializable]
   

    //[Serializable]
    //public class AdminMenu
    //{
    //    [XmlAttribute("id")]
    //    public string Id { get; set; }

    //    [XmlAttribute("name")]
    //    public string Name { get; set; }

    //    [XmlAttribute("url")]
    //    public string Url { get; set; }

    //    [XmlAttribute("info")]
    //    public string Info { get; set; }

    //    [XmlAttribute("permission")]
    //    public string Permission { get; set; }
    //}
}
