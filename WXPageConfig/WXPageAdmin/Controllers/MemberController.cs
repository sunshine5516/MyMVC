using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using WCPageBLL.Abatract;
using WCPageBLL.Concrete;
using WXPageDomain.Models;
using System.Web;
using System.Threading.Tasks;
using WXPageModel.Models;

namespace WXPageAdmin.Controllers
{
    [Authorize]
    /// <summary>
    /// 会员功能
    /// </summary>
    public class MemberController : Controller
    {
        private IWXMemberBLL _IWXMemberBLL;
        public MemberController() : this(new WXMemberBLL(), 
            new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()))) 
        {
        }
        public MemberController(IWXMemberBLL IWXAccountBll, UserManager<ApplicationUser> userManager)
        {
            _IWXMemberBLL = IWXAccountBll;
            UserManager = userManager;
        }
        public UserManager<ApplicationUser> UserManager { get; private set; }

        /// <summary>
        /// 密码哈希所需要的Salt随机数
        /// </summary>
        private string pwSalt = "AlrtSqlPe2Mh784QQwG6jRAfkdPpDa90J0i";
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 写入会员信息
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        /// <summary>
        /// 显示会员登录界面
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        /// <summary>
        /// 会员登录
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.UserName, model.Password);
                if (user != null)
                {
                    await SignInAsync(user, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            return View();
        }
        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool ValidateUser(LoginViewModel memberLogin)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + memberLogin.Password, "SHA1");
            var member = _IWXMemberBLL.FindAllInfo.Where(p => p.Account == memberLogin.UserName && p.Password == hash_pw).FirstOrDefault();
            if (member != null)
            {
                if (member.AuthCode == null)
                {
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "您尚未通过会员验证");
                    return false;
                }
            }
            else
            {
                ModelState.AddModelError("", "您输入的账号有误");
                return false;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loginout()
        {

            AuthenticationManager.SignOut();
            return RedirectToAction("Member", "Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && UserManager != null)
            {
                UserManager.Dispose();
                UserManager = null;
            }
            base.Dispose(disposing);
        }

        #region Helpers
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        /// <summary>
        /// 异步登录
        /// </summary>
        /// <param name="user"></param>
        /// <param name="isPersistent"></param>
        /// <returns></returns>
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent=isPersistent},identity);
        }
        /// <summary>
        /// 跳转定位
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "WXAccount");
            }
        }
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}