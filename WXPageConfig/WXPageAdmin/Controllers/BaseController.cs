using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXPageBLL.Abatract;
using WXPageBLL.Concrete;
using WXPageDomain.Models;
using WXPageService.WXHandler;
namespace WXPageAdmin.Controllers
{
    public class BaseController : Controller
    {

        protected WXMessageHandler _WXMessageHandler;
        //private IWXMenuRepository _repository;
        public BaseController() : this(new WXMessageHandler()) 
        {
        }
        public BaseController(WXMessageHandler WXMessageHandler)
        {
            _WXMessageHandler = WXMessageHandler;
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            ////这里判断出没有登录然后进行跳转
            //filterContext.Result = new RedirectResult("/Member/Login");
        }
    }
}