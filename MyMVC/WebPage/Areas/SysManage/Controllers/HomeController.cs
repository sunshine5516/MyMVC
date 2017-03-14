using Common;
using Common.Enums;
using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPage.Controllers;

namespace WebPage.Areas.SysManage.Controllers
{
    public class HomeController : BaseController
    {

        #region 声明容器
        IDepartmentManage DepartmentManage { get; set; }
        #endregion
        /// <summary>
        /// 模块管理 
        /// </summary>
        IModuleManage ModuleManage { get; set; }
        IUserOnlineManage UserOnlineManage { get; set; }
        // GET: SysManage/Home
        public  ActionResult Index()
        {

            //获取系统模块列表（如果用BUI可以写个方法输出Json给BUI）
            //ViewData["Module"] = ModuleManage.GetModule(this.CurrentUser.Id, this.CurrentUser.Permissions, this.CurrentUser.System_Id);
            //return View(this.CurrentUser);

            base.ViewData["Module"] = this.ModuleManage.GetModule(base.CurrentUser.Id, base.CurrentUser.Permissions, base.CurrentUser.System_Id);
            int CarriedOut = ClsDic.DicProject["进行中"];
            int CarriedOut2 = ClsDic.DicProject["延期"];
            int JoinStatus = ClsDic.DicStatus["通过"];
            //base.ViewData["MissionList"] = (
            //    from p in this.ProjectTeamManage.LoadAll((PRO_PROJECT_TEAMS p) => p.FK_UserId == this.CurrentUser.Id && (p.PRO_PROJECT_STAGES.StageStatus == CarriedOut || p.PRO_PROJECT_STAGES.StageStatus == CarriedOut2) && p.JionStatus == JoinStatus)
            //    orderby p.PRO_PROJECT_STAGES.EndDate
            //    select p).ToList<PRO_PROJECT_TEAMS>();
            int MailInbox = ClsDic.DicMailType["收件箱"];
            int MailUnRead = ClsDic.DicMailReadStatus["未读"];
            //base.ViewData["MailInBox"] = this.MailinManage.LoadListAll((MAIL_INBOX p) => p.Recipient.Contains(this.CurrentUser.LogName + this.EmailDomain) && p.ReadStatus == MailUnRead && p.MailType == MailInbox);
            base.ViewData["Contacts"] = this.Contacts();
            return base.View(base.CurrentUser);
        }
        public ActionResult Default()
        {
            return View();
        }

        // WebPage.Areas.SysManage.Controllers.HomeController
        private object Contacts()
        {
            var obj =
                from m in (
                    from m in this.DepartmentManage.LoadAll((SYS_DEPARTMENT m) => m.BUSINESSLEVEL == (int?)1)
                    orderby m.SHOWORDER
                    select m).ToList<SYS_DEPARTMENT>()
                select new
                {
                    ID = m.ID,
                    DepartName = m.NAME,
                    UserList = this.GetDepartUsers(m.ID)
                };
            return JsonConverter.JsonClass(obj);
        }
        // WebPage.Hubs.ChatHub
        // WebPage.Areas.SysManage.Controllers.HomeController
        private object GetDepartUsers(string departId)
        {
            List<string> departs = (
                from p in this.DepartmentManage.LoadAll((SYS_DEPARTMENT p) => p.PARENTID == departId)
                orderby p.SHOWORDER
                select p.ID).ToList<string>();
            var source = (
                from p in this.UserManage.LoadListAll((SYS_USER p) => p.ID != this.CurrentUser.Id && departs.Any((string e) => e == p.DPTID))
                orderby p.LEVELS
                orderby p.CREATEDATE
                select p).Select(delegate (SYS_USER p)
                {
                    return new
                    {
                        ID = p.ID,
                        FaceImg = string.IsNullOrEmpty(p.FACE_IMG) ? ("/Pro/Project/User_Default_Avatat?name=" + p.NAME.Substring(0, 1)) : p.FACE_IMG,
                        NAME = p.NAME,
                        InsideEmail = p.ACCOUNT,
                        LEVELS = p.LEVELS,
                        //ConnectId="1",
                        //IsOnline=false,
                        ConnectId = (this.UserOnlineManage.LoadAll((SYS_USER_ONLINE m) => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>() == null) ? "" :
                        this.UserOnlineManage.LoadAll((SYS_USER_ONLINE n) => n.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>().ConnectId,
                        IsOnline = this.UserOnlineManage.LoadAll((SYS_USER_ONLINE m) => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>() != null 
                        && this.UserOnlineManage.LoadAll((SYS_USER_ONLINE m) => m.FK_UserId == p.ID).FirstOrDefault<SYS_USER_ONLINE>().IsOnline
                    };
                }).ToList();
            return (
                from p in source
                orderby p.IsOnline
                select p).ToList();
        }


    }
}