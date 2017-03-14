using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WXPageDomain.Models;

namespace WXPageDomain.Config
{
    public class CachedConfigContext
    {
        public static CachedConfigContext Current = new CachedConfigContext();
        public AdminMenuConfig AdminMenuConfig
        {
            get
            {
                return AdminMenuConfig;
            }
        }
    }
}