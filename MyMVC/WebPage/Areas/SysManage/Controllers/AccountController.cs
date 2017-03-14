using Common;
using Domain;
using log4net.Ext;
using Service.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPage.Areas.SysManage.Controllers
{
    public class AccountController : Controller
    {
        #region 声明容器
        IUserManage UserManage { get; set; }

        IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        #endregion

        #region 基本视图
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public ActionResult Login(SYS_USER item)
        {
            var json = new JsonHelper() { Msg = "登录成功", Status = "n" };
            try
            {
                var code = Request.Form["code"];
                if (Session["gif"] != null)
                {
                    string dd = Session["gif"].ToString().ToLower();
                    ///暂时注销
                    //if (!string.IsNullOrEmpty(code) && code.ToLower() == Session["gif"].ToString().ToLower())
                    //{
                        //调用登录验证接口 返回用户实体类\
                        //var users = UserManage.UserLogin("admin","111111");
                        var users = UserManage.UserLogin(item.ACCOUNT.Trim(), item.PASSWORD.Trim());
                        if (users != null)
                        {
                            //是否锁定
                            if (!users.ISCANLOGIN)
                            {
                                json.Msg = "用户已锁定，禁止登录，请联系管理员进行解锁";
                                log.Warn(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                                return Json(json);
                            }
                            var account = this.UserManage.GetAccountByUser(users);
                            SessionHelper.SetSession("CurrentUser", account);
                            string cookievalue = "{\"id\":\"" + account.Id + "\",\"username\":\"" + account.LogName 
                                +"\",\"password\":\"" + account.PassWord + "\",\"ToKen\":\"" 
                                +Session.SessionID + "\"}";
                            CookieHelper.SetCookie("cookie_rememberme", new Common.CryptHelper.AESCrypt().Encrypt(cookievalue), null);
                            users.LastLoginIP = Utils.GetIP();
                        // UserManage.Update(users);
                        users.SYS_USER_ROLE = null;
                        UserManage.Update(users);
                            json.Status = "y";
                            json.ReUrl = "../Sys/Home/Index";
                            log.Info(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        }
                        else
                        {
                            json.Msg = "用户名或密码不正确";
                            log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                        }
                    //}
                    //else
                    //{
                    //    json.Msg = "验证码不正确";
                    //    log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                    //}
                }
                else
                {
                    json.Msg = "验证码已过期，请刷新验证码";
                    log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
                }
                
            }
            catch (Exception e)
            {
                json.Msg = e.Message;
                log.Error(Utils.GetIP(), item.ACCOUNT, Request.Url.ToString(), "Login", "系统登录，登录结果：" + json.Msg);
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 帮助方法
        public FileContentResult ValidateCode()
        {
            string code = "";
            MemoryStream ms = new Models.verify_code().Create(out code);
            Session["gif"] = code;//验证码存在session中，供验证
            Response.ClearContent();//清空输出流
            return File(ms.ToArray(),@"image/png");
        }
        #endregion
    }
}