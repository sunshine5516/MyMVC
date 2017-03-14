using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPage.Controllers;

namespace WebPage.Areas.SysManage.Controllers
{
    public class ChatController : BaseController
    {
        // GET: SysManage/Chat
        public ActionResult Index()
        {
            return View();
        }
    }
}