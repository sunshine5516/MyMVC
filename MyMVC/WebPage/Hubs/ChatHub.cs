using Common;
using Common.Enums;
using Domain;
using Microsoft.AspNet.SignalR;
using Service.IService;
using Service.ServiceImp;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace WebPage.Hubs
{
    public class ChatHub : Hub
    {
        public IUserManage UserManage = ContextRegistry.GetContext().GetObject("Service.User") as IUserManage;
        public IUserOnlineManage UserOnlineManage = ContextRegistry.GetContext().GetObject("Service.UserOnlineManage") as IUserOnlineManage;
        public ICodeManage CodeManage = ContextRegistry.GetContext().GetObject("Service.CodeManage") as ICodeManage;
        public IDepartmentManage DepartmentManage = ContextRegistry.GetContext().GetObject("Service.Department") as IDepartmentManage;

        public IChatMessageManage ChatMessageManage = ContextRegistry.GetContext().GetObject("Service.ChatMessage") as IChatMessageManage;
        public ChatHub()
        {
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public void Register(string account, string password)
        {
            try
            {
                ///获取用户信息
                var user = UserManage.Get(p => p.ACCOUNT == account);
                if (user != null && user.PASSWORD == password)
                {
                    // IQueryable<SYS_CHATMESSAGE> source = this.ChatMessageManage.LoadAll((SYS_CHATMESSAGE p) => p.MessageDate > dtHistory);
                    //更新在线状态
                    bool isEdit = false;
                    var UserOnline = UserOnlineManage.LoadListAll(p => p.FK_UserId == user.ID).FirstOrDefault();
                    if (UserOnline != null)
                    {
                        UserOnline.ConnectId = Context.ConnectionId;
                        UserOnline.OnlineDate = DateTime.Now;
                        UserOnline.IsOnline = true;
                        UserOnline.UserIP = Utils.GetIP();
                        isEdit = true;
                    }
                    ///第一次登录则注册
                    else
                    {
                        UserOnline = new SYS_USER_ONLINE
                        {
                            ConnectId = Context.ConnectionId,
                            OnlineDate = DateTime.Now,
                            IsOnline = true,
                            UserIP = Utils.GetIP(),
                            FK_UserId = user.ID
                        };

                    }
                    UserOnlineManage.SaveOrUpdate(UserOnline, isEdit);

                    //获取历史消息
                    int days = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["HistoryDays"]);
                    DateTime dtHistory = DateTime.Now.AddDays(-days);
                    var ChatMessageList = ChatMessageManage.LoadAll(p => p.MessageDate > dtHistory);

                    //超级管理员

                    if (user.ID == ClsDic.DicRole["超级管理员"])
                    {
                        //通知用户上线
                        //Clients.All.UserLoginNotice("");
                        Clients.All.UserLoginNotice("超级管理员：" + user.NAME + " 上线了!");
                        var userss = UserManage.Get(m => m.ID == 1);
                        var historyMsg = ChatMessageList.OrderBy(p => p.MessageDate).ToList().Select
                            (
                            p => new
                            {
                                //if()
                                UserName = UserManage.Get(m => m.ID == p.FromUser).NAME,
                                //UserName = UserManage.Get(m => m.ID == (p.FromUser!=null?p.FromUser:1)).NAME,
                                UserFace = string.IsNullOrEmpty(UserManage.Get(m => m.ID == p.FromUser).FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name="
                                + UserManage.Get(m => m.ID == p.FromUser).NAME.Substring(0, 1) 
                                : UserManage.Get(m => m.ID == p.FromUser).FACE_IMG,
                                ////MessageType=GetMessageType(p.MessageType),
                                MessageType = p.MessageType,
                                p.FromUser,
                                p.MessageContent,
                                MessageDate = p.MessageDate.GetDateTimeFormats('D')[1].ToString() + " - " + p.MessageDate.ToString("HH:mm:ss"),
                                ConnectId = UserOnlineManage.LoadListAll(m => m.SYS_USER.ID == p.FromUser).FirstOrDefault().ConnectId
                            }
                            ).ToList();
                        Clients.Client(Context.ConnectionId).addHistoryMessageToPage(JsonConverter.Serialize(historyMsg));
                        //Clients.All.UserLoginNotice(Context.ConnectionId).addHistoryMessageToPage("超级管理员：" + user.NAME + " 上线了!");
                    }
                    else
                    {
                        //获取用户一级部门信息
                        var Depart = GetUserDepart(user.DPTID);
                        if (Depart != null && !string.IsNullOrEmpty(Depart.ID))
                        {
                            //添加用户到部门群组 Groups.Add（用户连接ID，群组）
                            Groups.Add(Context.ConnectionId, Depart.ID);
                            //通知用户上线
                            Clients.All.UserLoginNotice(Depart.NAME + " - " + CodeManage.Get(m => m.CODEVALUE == user.LEVELS && m.CODETYPE == "ZW").NAMETEXT + "：" + user.NAME + " 上线了!");
                            //用户历史消息
                            int typeOfpublic = ClsDic.DicMessageType["广播"];
                            int typeOfgroup = ClsDic.DicMessageType["群组"];
                            int typeOfprivate = ClsDic.DicMessageType["私聊"];
                            var HistoryMessage = ChatMessageList.Where(p => p.MessageType == typeOfpublic ||
                            (p.MessageType == typeOfgroup && p.ToGroup == Depart.ID) || (p.MessageType == typeOfprivate && p.ToGroup == user.ID.ToString())).
                            OrderBy(p => p.MessageDate).ToList().Select(p => new
                            {

                                UserName = UserManage.Get(m => m.ID == p.FromUser).NAME,
                                UserFace = string.IsNullOrEmpty(UserManage.Get(m => m.ID == p.FromUser).FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name=" + UserManage.Get(m => m.ID == p.FromUser).NAME.Substring(0, 1) : UserManage.Get(m => m.ID == p.FromUser).FACE_IMG,
                                MessageType = p.MessageType,
                                p.FromUser,
                                p.MessageContent,
                                MessageDate = p.MessageDate.GetDateTimeFormats('D')[1].ToString() + " - " + p.MessageDate.ToString("HH:mm:ss"),
                                ConnectId = UserOnlineManage.LoadListAll(m => m.SYS_USER.ID == p.FromUser).FirstOrDefault().ConnectId
                            });
                            ///推送历史消息
                            Clients.Client(Context.ConnectionId).addHistoryMessageToPage(JsonConverter.Serialize(HistoryMessage));
                        }
                    }
                    Clients.All.ContactsNotice(JsonConverter.Serialize(UserOnline));
                }

            }
            catch (Exception e)
            {
                Clients.Client(Context.ConnectionId).UserLoginNotice("出错了：" + e.Message);
                throw e.InnerException;
            }
        }
        public override Task OnDisconnected(bool stopCalled)
        {
            var UserOnline = UserOnlineManage.LoadListAll(p => p.ConnectId == Context.ConnectionId).FirstOrDefault();
            UserOnline.ConnectId = Context.ConnectionId;
            UserOnline.OfflineDate = DateTime.Now;
            UserOnline.IsOnline = false;
            UserOnlineManage.Update(UserOnline);
            ///获取用户信息
            var User = UserManage.Get(p => p.ID == UserOnline.FK_UserId);
            Clients.All.UserLogOutNotice(User.NAME + "：离线了!");
            Clients.All.ContactsNotice(JsonConverter.Serialize(UserOnline));
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <param name="departId"></param>
        /// <returns></returns>
        private SYS_DEPARTMENT GetUserDepart(string departId)
        {
            SYS_DEPARTMENT sYS_DEPARTMENT = this.DepartmentManage.Get((SYS_DEPARTMENT p) => p.ID == departId);
            if (sYS_DEPARTMENT != null)
            {
                string ParentId = sYS_DEPARTMENT.PARENTID;
                SYS_DEPARTMENT sYS_DEPARTMENT2 = new SYS_DEPARTMENT();
                for (int? num = sYS_DEPARTMENT.BUSINESSLEVEL; num >= 1; num--)
                {
                    if (!string.IsNullOrEmpty(ParentId))
                    {
                        sYS_DEPARTMENT2 = this.DepartmentManage.Get((SYS_DEPARTMENT p) => p.ID == ParentId);
                        if (string.IsNullOrEmpty(sYS_DEPARTMENT2.PARENTID))
                        {
                            break;
                        }
                        ParentId = sYS_DEPARTMENT2.PARENTID;
                    }
                    
                }
                return sYS_DEPARTMENT2;
            }
            return null;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="groupId"></param>
        public void Send(string message, string groupId)
        {
            try
            {
                var UserOnline = UserOnlineManage.LoadListAll(p => p.ConnectId == Context.ConnectionId).FirstOrDefault();
                if (string.IsNullOrEmpty(groupId))
                {
                    ChatMessageManage.Save(new Domain.SYS_CHATMESSAGE()
                    {
                        FromUser = UserOnline.FK_UserId,
                        MessageType = Common.Enums.ClsDic.DicMessageType["广播"],
                        MessageContent = message,
                        MessageDate = DateTime.Now,
                        MessageIP = Utils.GetIP()
                    });
                    var Message = new Message()
                    {
                        ConnectId = UserOnline.ConnectId,
                        UserName = UserOnline.SYS_USER.NAME,
                        UserFace = string.IsNullOrEmpty(UserOnline.SYS_USER.FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name=" + UserOnline.SYS_USER.NAME.Substring(0, 1) : UserOnline.SYS_USER.FACE_IMG,
                        MessageDate = DateTime.Now.GetDateTimeFormats('D')[1].ToString() + " - " +
                        DateTime.Now.ToString("HH:mm:ss"),
                        MessageContent = message,
                        MessageType = "public",
                        UserId = UserOnline.SYS_USER.ID
                    };
                    //推送消息
                    Clients.All.addNewMessageToPage(JsonConverter.Serialize(Message));
                }
                else
                {
                    ChatMessageManage.Save(new Domain.SYS_CHATMESSAGE()
                    {
                        FromUser = UserOnline.FK_UserId,
                        MessageType = Common.Enums.ClsDic.DicMessageType["群组"],
                        MessageContent = message,
                        MessageDate = DateTime.Now,
                        MessageIP = Utils.GetIP(),
                        ToGroup = groupId
                    });
                    var Message = new Message()
                    {
                        ConnectId = UserOnline.ConnectId,
                        UserName = UserOnline.SYS_USER.NAME,
                        UserFace = string.IsNullOrEmpty(UserOnline.SYS_USER.FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name=" + UserOnline.SYS_USER.NAME.Substring(0, 1) : UserOnline.SYS_USER.FACE_IMG,
                        MessageDate = DateTime.Now.GetDateTimeFormats('D')[1].ToString() + " - " + DateTime.Now.ToString("HH:mm:ss"),
                        MessageContent = message,
                        MessageType = "group",
                        UserId = UserOnline.SYS_USER.ID
                    };
                    ///推送消息
                    Clients.Group(groupId).addNewMessageToPage(JsonConverter.Serialize(Message));
                    var Depart = GetUserDepart(UserOnline.SYS_USER.DPTID);
                    if (Depart == null)
                    {
                        Clients.Client(Context.ConnectionId).addNewMessageToPage(JsonConverter.Serialize(Message));
                    }
                    else if (Depart.ID != groupId)
                    {
                        Clients.Client(Context.ConnectionId).addNewMessageToPage(JsonConverter.Serialize(Message));
                    }
                }
            }
            catch (Exception e)
            {

            }
        }


        /// <summary>
        /// 发送给指定用户（单播）
        /// </summary>
        /// <param name="clientId">接收用户的连接ID</param>
        /// <param name="message">发送的消息</param>
        public void SendSingle(string clientId, string message)
        {
            try
            {
                //接收用户连接为空
                if (string.IsNullOrEmpty(clientId))
                {
                    //推送系统消息
                    Clients.Client(Context.ConnectionId).addSysMessageToPage("系统消息：用户不存在！");
                }
                else
                {
                    //消息用户主体
                    var UserOnline = UserOnlineManage.LoadListAll(p => p.ConnectId == Context.ConnectionId).FirstOrDefault();
                    //接收消息用户主体
                    var ReceiveUser = UserOnlineManage.LoadListAll(p => p.ConnectId == clientId).FirstOrDefault();
                    if (ReceiveUser == null)
                    {
                        //推送系统消息
                        Clients.Client(Context.ConnectionId).addSysMessageToPage("系统消息：用户不存在！");
                    }
                    else
                    {

                        //保存消息
                        ChatMessageManage.Save(new Domain.SYS_CHATMESSAGE()
                        {
                            FromUser = UserOnline.FK_UserId,
                            MessageType = Common.Enums.ClsDic.DicMessageType["私聊"],
                            MessageContent = message,
                            MessageDate = DateTime.Now,
                            MessageIP = Utils.GetIP(),
                            ToGroup = UserOnline.SYS_USER.ID.ToString()
                        });
                        //返回消息实体
                        var Message = new Message()
                        {
                            ConnectId = UserOnline.ConnectId,
                            UserName = UserOnline.SYS_USER.NAME,
                            UserFace = string.IsNullOrEmpty(UserOnline.SYS_USER.FACE_IMG) ? "/Pro/Project/User_Default_Avatat?name=" + UserOnline.SYS_USER.NAME.Substring(0, 1) : UserOnline.SYS_USER.FACE_IMG,
                            MessageDate = DateTime.Now.GetDateTimeFormats('D')[1].ToString() + " - " + DateTime.Now.ToString("HH:mm:ss"),
                            MessageContent = message,
                            MessageType = "private",
                            UserId = UserOnline.SYS_USER.ID
                        };
                        if (ReceiveUser.IsOnline)
                        {
                            //推送给指定用户
                            Clients.Client(clientId).addNewMessageToPage(JsonConverter.Serialize(Message));
                        }
                        //推送给用户
                        Clients.Client(Context.ConnectionId).addNewMessageToPage(JsonConverter.Serialize(Message));

                    }
                }
            }
            catch (Exception ex)
            {
                //推送系统消息
                Clients.Client(Context.ConnectionId).addSysMessageToPage("系统消息：消息发送失败，请稍后再试！");
                throw ex.InnerException;
            }
        }

    }
}