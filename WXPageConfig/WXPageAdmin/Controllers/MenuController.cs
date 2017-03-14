using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXPageBLL.Abatract;
using WXPageBLL.Concrete;
using WXPageModel;
using WXPageService.WXHandler;
namespace WXPageAdmin.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenuController : Controller
    {
        private IWXMenuBLL _IWXMenuBll;
        SingleButton t = new SingleButton { Id = "001", SubMenuId = "001", Name = "欢迎关注", Index = 1, InsertTime = DateTime.Now, State = "Normal", Type = "view", Key = "", Url = "" };
        public ActionResult testc()
        {
            ViewBag.from_enum = Enum.GetValues(typeof(WXPageService.Enums.PlatformEnums.ButtonType)).Cast<WXPageService.Enums.PlatformEnums.ButtonType>();
            return View(t);
        }
        //private IWXMenuRepository _repository;
        public MenuController() : this(new WXMenuBLL())
        {
        }
        public MenuController(IWXMenuBLL IWXMenuBll)
        {
            _IWXMenuBll = IWXMenuBll;
        }
        //private IWXReplayContentsRepository rep = new EFWXReplayContentsRepository();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取用户的菜单
        /// </summary>
        [HttpGet]
        public string GetMenu()
        {

            WXPageService.Entity.ResponseMessageText baserespones = new WXPageService.Entity.ResponseMessageText { ToUserName = "001", Content = "hello", CreateTime = DateTime.Now, FromUserName = "002" };
            // var xmlInfo = EntityHelper.GetResponseTextXml(baserespones);
            //return View(WXMessageHandler.GetMenu());
            object result = WXMenuHandler.GetMenu();
            if (result == null)
            {
                return "";
                //return Json(new { error = "菜单不存在或验证失败！" }, JsonRequestBehavior.AllowGet);
            }
            return result.ToString();
            //return Json(result.ToString(), JsonRequestBehavior.AllowGet);
            //return View();
        }
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteMenu()
        {
            try
            {
                //var result = "";
                object result = WXMenuHandler.DeleteMenu();
                var json = new
                {
                    Success = "ok",
                };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var json = new { Success = false, Message = ex.Message };
                return Json(json, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateMenu()
        {
            var data = _IWXMenuBll.WXSubMenu;
            ViewBag.from_enum = Enum.GetValues(typeof(WXPageService.Enums.PlatformEnums.ButtonType)).Cast<WXPageService.Enums.PlatformEnums.ButtonType>();
            return View(data);
        }
        [HttpPost]
        public ActionResult CreateMenu(List<SubMenu> subButtons)
        {
            try
            {

                subButtons = subButtons ?? new List<SubMenu>();
                ViewBag.from_enum = Enum.GetValues(typeof(WXPageService.Enums.PlatformEnums.ButtonType)).Cast<WXPageService.Enums.PlatformEnums.ButtonType>();
                _IWXMenuBll.SaveSubMenu(subButtons);
                return View(subButtons);
            }
            catch (Exception ex)
            {
                return View(subButtons);
            }

        }
        [HttpGet]
        public ActionResult GetList()
        {
            var data = _IWXMenuBll.WXSubMenu;
            ViewBag.from_enum = Enum.GetValues(typeof(WXPageService.Enums.PlatformEnums.ButtonType)).Cast<WXPageService.Enums.PlatformEnums.ButtonType>();
            return View(data);
        }
        [HttpPost]
        public ActionResult GetList(List<SubMenu> subButtons)
        {
            subButtons = subButtons ?? new List<SubMenu>();
            ViewBag.from_enum = Enum.GetValues(typeof(WXPageService.Enums.PlatformEnums.ButtonType)).Cast<WXPageService.Enums.PlatformEnums.ButtonType>();
            return View(subButtons);
        }
        public ActionResult MenuList()
        {
            return View();
        }
        public string GetCode()
        {
            object result = WXMenuHandler.GetCode();
            if (result == null)
            {
                return "";
                //return Json(new { error = "菜单不存在或验证失败！" }, JsonRequestBehavior.AllowGet);
            }
            return result.ToString();
        }
    }
}