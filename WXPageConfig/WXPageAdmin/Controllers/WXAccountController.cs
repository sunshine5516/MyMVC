using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using WXPageBLL.Abatract;
using WXPageBLL.Concrete;
using WXPageModel;

namespace WXPageAdmin.Controllers
{
    /// <summary>
    /// 微信账户信息
    /// </summary>
    [Authorize]
    public class WXAccountController :Controller
    {
        private IWXAccountBLL _IWXAccountBll;
        public WXAccountController() : this(new WXAccountBLL()) 
        {
        }
        public WXAccountController(IWXAccountBLL IWXAccountBll)
        {
            _IWXAccountBll = IWXAccountBll;
        }
        // GET: Account
        //public ActionResult Index(int p = 1, string accountType = "All", string keyWord = "")
        public ActionResult Index(string accountType = "All")
        {
            //var pageData = _IWXAccountBll.FindAllInfo.ToPagedList(pageNumber: p, pageSize: 10); 
            //return View(pageData);
            //if (accountType == "All")
            //{
            //    accountType = "";
            //}
            //var data = _IWXAccountBll.FindAllInfo.Where(t => t.WXType.Contains(accountType)).ToList();
            //var pageData = data.ToPagedList(pageNumber: p, pageSize: 10);
            ////return View(pageData);

            return View((object)accountType);
        }
        /// <summary>
        /// 局部视图
        /// </summary>
        /// <param name="p"></param>
        /// <param name="accountType"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public PartialViewResult GetAccountList(int p = 1, string accountType = "", string keyWord = "")
        {
            if (accountType == "All")
            {
                accountType = "";
            }
            var data = _IWXAccountBll.FindAllInfo.Where(t => t.WXType.Contains(accountType)).ToList();
            var pageData = data.ToPagedList(pageNumber: p, pageSize: 5);
            return PartialView(pageData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ///获取微信类型枚举
            ViewBag.from_enum = Enum.GetValues(typeof(WXEnum.Enums.WXType)).Cast<WXEnum.Enums.WXType>();
            return View();
        }
        /// <summary>
        /// 添加，不验证插入时间
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "InsertTime")]WXAccountInfo info)
        {
            ViewBag.from_enum = Enum.GetValues(typeof(WXEnum.Enums.WXType)).Cast<WXEnum.Enums.WXType>();
            ModelState.Remove("State");
            if (ModelState.IsValid)
            {
                info.Id = Guid.NewGuid().ToString();
                info.State = "Normal";
                info.InsertTime = DateTime.Now;
                _IWXAccountBll.Save(info);
                //WXAccountList.Add(info);
            }
            return RedirectToAction("Index", "WXAccount");
        }
        [HttpGet]
        public ActionResult Edit([Bind(Exclude = "InsertTime")]string id)
        {
            try
            {
                var check = _IWXAccountBll.FindAllInfo.Where(p => p.Id == id).FirstOrDefault();
                if (check == null)
                {
                    ModelState.AddModelError("Edit", "暂无该产品");
                }
                ViewBag.from_enum = Enum.GetValues(typeof(WXEnum.Enums.WXType)).Cast<WXEnum.Enums.WXType>();
                //ViewBag.from_enum = check.WXType;
                return View(check);
            }
            catch
            {
                return HttpNotFound();
            }
        }
        /// <summary>
        /// 修改微信号信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "InsertTime")]WXAccountInfo info)
        {
            try
            {
                var check = _IWXAccountBll.FindAllInfo.Where(p => p.Id == info.Id).FirstOrDefault();
                if (check == null)
                {
                    ModelState.AddModelError("Edit", "暂无该产品");
                }
                if (ModelState.IsValid)
                {
                    _IWXAccountBll.Save(info);
                }
                
                return RedirectToAction("Index", "WXAccount");
            }
            catch
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult GetAuthority(string Id)
        {
            return View();
        }

        public ActionResult Delete(string id)
        {
            WXAccountInfo check = _IWXAccountBll.FindAllInfo.Where(p => p.Id == id).FirstOrDefault();
            _IWXAccountBll.Delete(check);
            return RedirectToAction("Index", "WXAccount");
        }
        //public static string A
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //_IWXAccountBll.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}