﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WXPageAdmin.Startup))]
namespace WXPageAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
