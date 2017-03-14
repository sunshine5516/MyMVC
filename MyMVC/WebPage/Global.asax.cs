using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebPage
{
    public class MvcApplication : Spring.Web.Mvc.SpringMvcApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();
            //启动数据库的数据缓存依赖功能    
            SqlCacheDependencyAdmin.EnableNotifications(connectionString);
            //启用数据表缓存
            SqlCacheDependencyAdmin.EnableTableForNotifications(connectionString, "SYS_CODE_AREA");
        }
    }
}
