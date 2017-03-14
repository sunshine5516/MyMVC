using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WXPageBLL.Abatract;
using WXPageBLL.Concrete;
using WXPageAdmin.Models;
using WXPageDomain.Abatract;
using WXPageDomain.Concrete;
using WXPageDomain.Models;

namespace WXPageAdmin.Controllers
{
    public class MessageController : Controller
    {
        //private IWXReplayContentsRepository _repository;
        private IWXReplayContentsBLL _IWXReplayContentsBll;
        //private IWXReplayContentsRepository reposity = new EFWXReplayContentsRepository();
        //string wxAccountId = HttpContext.Items["wxAccount"].ToString();
        public MessageController() : this(new WXReplayContentsBLL()) 
        {
        }
        public MessageController(IWXReplayContentsBLL IWXReplayContentsBll)
        {
            _IWXReplayContentsBll = IWXReplayContentsBll;
        }

        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 关注时候回复
        /// </summary>
        /// <returns></returns>
        public ActionResult FirstResponse(string id)
        {
            //HttpContext context = HttpContext.Current;
            //context.se
            if (!string.IsNullOrEmpty(id))
            {
                HttpContext.Session["wxAccount"] = id;
            }
            //HttpContext.Items.Clear();
            //HttpContext.Items.Add("wxAccount", id);
            ReplayContents content= _IWXReplayContentsBll.GetReplayContent(id);
            return View(content);
        }
        [HttpPost]
        public ActionResult FirstResponse([Bind(Exclude = "InsertTime")]ReplayContents msg, HttpPostedFileBase upImg)
        {
            string wxAccountId = HttpContext.Session["wxAccount"].ToString();
            msg.WXAccountId = wxAccountId;
            if (upImg != null)
            {
                msg.ReplyType = "图片";
                string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetFileName(upImg.FileName);
                string path= Server.MapPath("~/upload/");
                string filePhysicalPath = Server.MapPath("~/upload/" +fileName);
                string pic = "", error = "";
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    upImg.SaveAs(filePhysicalPath);
                    pic = "/upload/" + fileName;
                    msg.ReplyType = "图片";
                    msg.ReplayContent ="url:"+ pic;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
            else
            {
                msg.ReplyType = "文字";
                msg.ReplayContent = "首次关注:" + msg.ReplayContent;
            }
            msg.RequestType = "首次关注";

            _IWXReplayContentsBll.Save(msg);
            return View();
        }

        
        /// <summary>
        /// 默认回复
        /// </summary>
        /// <returns></returns>
        public ActionResult DefaultResponse(string id)
        {
            //HttpContext context = HttpContext.Current;
            //context.se
            if (!string.IsNullOrEmpty(id))
            {
                HttpContext.Session["wxAccount"] = id;
            }
            //HttpContext.Items.Clear();
            //HttpContext.Items.Add("wxAccount", id);
            ReplayContents content = _IWXReplayContentsBll.GetReplayContent(id);
            return View(content);
        }
        [HttpPost]
        public ActionResult DefaultResponse([Bind(Exclude = "InsertTime")]ReplayContents msg, HttpPostedFileBase upImg)
        {
            string wxAccountId = HttpContext.Session["wxAccount"].ToString();
            msg.WXAccountId = wxAccountId;
            if (upImg != null)
            {
                msg.ReplyType = "图片";
                string fileName = Guid.NewGuid().ToString() + System.IO.Path.GetFileName(upImg.FileName);
                string path = Server.MapPath("~/upload/");
                string filePhysicalPath = Server.MapPath("~/upload/" + fileName);
                string pic = "", error = "";
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    upImg.SaveAs(filePhysicalPath);
                    pic = "/upload/" + fileName;
                    msg.ReplyType = "图片";
                    msg.ReplayContent = "url:" + pic;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                }
            }
            else
            {
                msg.ReplyType = "文字";
                msg.ReplayContent = "默认回复:" + msg.ReplayContent;
            }
            msg.RequestType = "默认回复";
            _IWXReplayContentsBll.Save(msg);
           
            return View();
        }


        /// <summary>
        /// 关键字回复
        /// </summary>
        /// <returns></returns>
        public ActionResult KeyWord(string id)
        {
            //HttpContext context = HttpContext.Current;
            //context.se
            if (!string.IsNullOrEmpty(id))
            {
                HttpContext.Session["wxAccount"] = id;
            }
            //HttpContext.Items.Clear();
            //HttpContext.Items.Add("wxAccount", id);
            ReplayContents content = _IWXReplayContentsBll.GetReplayContent(id);
            return View(content);
        }
        [HttpPost]
        public ActionResult KeyWord(ReplayContents msg, HttpPostedFileBase upImg)
        {
            string wxAccountId = HttpContext.Session["wxAccount"].ToString();
            ReplayContents replyContents = new ReplayContents();
            replyContents.WXAccountId = wxAccountId;
            replyContents.ReplyType = "文字";
            replyContents.ReplayContent = msg.ReplayContent;
            replyContents.RequestType = "关键字回复";
            _IWXReplayContentsBll.Save(replyContents);
            return View();
        }


    }
}