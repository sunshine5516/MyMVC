using Common;
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
    public class RoleController : BaseController
    {
        #region 声明容器
        IRoleManage RoleManage { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        IUserRoleManage UserRoleManage { get; set; }
        /// <summary>
        /// 系统管理
        /// </summary>
        ISystemManage SystemManage { get; set; }
        /// <summary>
        /// 角色权限管理
        /// </summary>
        IRolePermissionManage RolePermissionManage { get; set; }

        //IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        bool isEdit = false;

        #endregion
        /// <summary>
        /// 加载主页
        /// </summary>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "Role", OperaAction = "View")]
        public ActionResult Index()
        {
            try
            {
                #region 处理查询参数
                string System = Request.QueryString["System"];
                ViewData["System"] = System;
                ViewBag.Search = base.keywords;
                #endregion
                ViewData["Systemlist"] = this.SystemManage.LoadSystemInfo(CurrentUser.System_Id);
                //输出分页查询列表
                return View(BindList(System));
            }
            catch (Exception e)
            {
                throw e.InnerException;

            }
            //return View();
        }

        /// <summary>
        /// 加载角色详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "Role", OperaAction = "Detail")]
        public ActionResult Detail(int? id)
        {
            try
            {
                var _entity = new SYS_ROLE() { ISCUSTOM = false };
                //父模块
                string parentId = Request.QueryString["parentId"];
                if (id != null && id > 0)
                {
                    _entity = this.RoleManage.Get(p => p.ID == id);
                }
                else
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["systemId"]))
                    {
                        _entity.FK_BELONGSYSTEM = Request.QueryString["systemId"];
                    }
                }
                ViewData["Systemlist"] = this.SystemManage.LoadSystemInfo(CurrentUser.System_Id);
                return View(_entity);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }

        }
        /// <summary>
        ///保存角色
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "Role", OperaAction = "Add,Edit")]
        public ActionResult Save(SYS_ROLE entity)
        {
            bool isEdit = false;
            var json = new JsonHelper() { Msg = "保存成功", Status = "n" };
            try
            {
                if (entity != null)
                {
                    //判断角色名是否汉字
                    if (System.Text.RegularExpressions.Regex.IsMatch(entity.ROLENAME.Trim(), "^[\u4e00-\u9fa5]+$"))
                    {
                        if (entity.ROLENAME.Length > 36)
                         {
                             json.Msg = "角色名称最多只能能包含36个汉字";
                             return Json(json);
                         }
                        //添加
                        if (entity.ID <= 0)
                        {
                            entity.CREATEDATE = DateTime.Now;
                            entity.CREATEPERID = this.CurrentUser.Name;
                            entity.UPDATEDATE = DateTime.Now;
                            entity.UPDATEUSER = this.CurrentUser.Name;
                        }
                        else //修改
                        {
                            entity.UPDATEDATE = DateTime.Now;
                            entity.UPDATEUSER = this.CurrentUser.Name;
                            isEdit = true;
                        }
                        //判断角色是否重名 
                        if (!this.RoleManage.IsExist(p => p.ROLENAME == entity.ROLENAME && p.ID != entity.ID))
                        {
                            if (isEdit)
                            {
                                //系统更换 删除所有权限
                                var _entity = RoleManage.Get(p => p.ID == entity.ID);
                                if (_entity.FK_BELONGSYSTEM != entity.FK_BELONGSYSTEM)
                                {
                                    RolePermissionManage.Delete(p => p.ROLEID == _entity.ID);
                                }
                            }
                            if (RoleManage.SaveOrUpdate(entity, isEdit))
                            {
                                json.Status = "y";
                            }
                            else
                            {
                                json.Msg = "保存失败";
                            }
                        }
                        else
                        {
                            json.Msg = "角色名" + entity.ROLENAME + "已被使用，请修改角色名称再提交";
                        }
                    }
                    else
                    {
                        json.Msg = "角色名称只能包含汉字";
                    }
                }
                else
                {
                    json.Msg = "未找到需要保存的角色信息";
                }
                    return View();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "Role", OperaAction = "Remove")]
        public ActionResult Delete(string idList)
        {
            var json = new JsonHelper() { Msg = "删除角色完毕", Status = "n" };
            var id = idList.Trim(',').Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToList();
            if (id.Contains(Common.Enums.ClsDic.DicRole["超级管理员"]))
            {
                json.Msg = "删除失败，不能删除系统固有角色!";
                //WriteLog(Common.Enums.enumOperator.Remove, "删除用户角色：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                return Json(json);
            }
            if (this.UserRoleManage.IsExist(p => id.Contains(p.FK_ROLEID)))
            {
                json.Msg = "删除失败，不能删除系统中正在使用的角色!";
                //WriteLog(Common.Enums.enumOperator.Remove, "删除用户角色：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                return Json(json);
            }
            try
            {
                //1、删除角色权限
                RolePermissionManage.Delete(p => id.Contains(p.ROLEID));
                //2、删除角色
                RoleManage.Delete(p => id.Contains(p.ID));
                json.Status = "y";
                //WriteLog(Common.Enums.enumOperator.Remove, "删除用户角色：" + json.Msg, Common.Enums.enumLog4net.WARN);
            }
            catch (Exception e)
            {
                json.Msg = "删除用户角色发生内部错误！";
                //WriteLog(Common.Enums.enumOperator.Remove, "删除用户角色：", e);
            }
            return Json(json);
        }
        private PageInfo BindList(string system)
        {
            var query = this.RoleManage.LoadAll(null);
            //系统
            if (!string.IsNullOrEmpty(system))
            {
                int SuperAdminId = Common.Enums.ClsDic.DicRole["超级管理员"];
                query = query.Where(p => p.FK_BELONGSYSTEM == system || p.ISCUSTOM == true);
            }
            else
            {
                query = query.Where(p => this.CurrentUser.System_Id.Any(e => e == p.FK_BELONGSYSTEM));
            }
            if (!string.IsNullOrEmpty(keywords))
            {
                query = query.Where(p => p.ROLENAME.Contains(keywords));
            }
            query = query.OrderByDescending(p => p.CREATEDATE);
            var result = this.RoleManage.Query(query, page, pagesize);
            var list = result.List.Select(p => new
            {
                //以下是视图需要展示的内容，加动态可循环
                p.CREATEDATE,
                p.ROLENAME,
                p.ROLEDESC,
                USERNAME = p.CREATEPERID,
                p.ID,
                SYSNAME = SystemManage.Get(m => m.ID == p.FK_BELONGSYSTEM).NAME,
                ISCUSTOMSTATUS = p.ISCUSTOM ? "<i class=\"fa fa-circle text-navy\"></i>" : "<i class=\"fa fa-circle text-danger\"></i>"
            }).ToList();
            return new PageInfo(result.Index, result.PageSize, result.Count, Common.JsonConverter.JsonClass(list));
        }
        /// <summary>
        /// 用户角色分配
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "User", OperaAction = "AllocationRole")]
        public ActionResult RoleCall(int? id)
        {
            try
            {
                if (id != null && id > 0)
                {
                    //用户ID
                    ViewData["userId"] = id;
                    //获取用户角色信息
                    var userRoleList = this.UserRoleManage.LoadAll(p => p.FK_USERID == id)
                        .Select(p => p.FK_ROLEID).ToList();
                    return View(Common.JsonConverter.JsonClass
                        (this.RoleManage.LoadAll(p => this.CurrentUser.System_Id.Any
                        (e => e == p.FK_BELONGSYSTEM)).
                        OrderBy(p => p.FK_BELONGSYSTEM).
                        OrderByDescending(p => p.ID).ToList().
                        Select(p => new { p.ID, p.ROLENAME, ISCUSTOMSTATUS = p.ISCUSTOM ? "<i class=\"fa fa-circle text-navy\"></i>" : "<i class=\"fa fa-circle text-danger\"></i>",
                            SYSNAME = SystemManage.Get(m => m.ID == p.FK_BELONGSYSTEM).NAME,
                            IsChoosed = userRoleList.Contains(p.ID) })));
                }
                else
                {
                    return View();
                }

            }
            catch (Exception e)
            {
                WriteLog(Common.Enums.enumOperator.Select, "获取用户分配的角色：", e);
                throw e.InnerException;
            }
        }

        // WebPage.Areas.SysManage.Controllers.RoleController
        [UserAuthorize(ModuleAlias = "Role", OperaAction = "Allocation")]
        public ActionResult UserRole()
        {
            JsonHelper jsonHelper = new JsonHelper
            {
                Msg = "设置用户角色成功",
                Status = "n"
            };
            string text = base.Request.Form["UserId"];
            string text2 = base.Request.Form["checkbox_name"];
            if (string.IsNullOrEmpty(text))
            {
                jsonHelper.Msg = "未找到要分配角色用户";
                return base.Json(jsonHelper);
            }
            text2 = text2.TrimEnd(new char[]
            {
        ','
            });
            try
            {
                this.UserRoleManage.SetUserRole(int.Parse(text), text2);
                jsonHelper.Status = "y";
                //base.WriteLog(enumOperator.Allocation, "设置用户角色：" + jsonHelper.Msg, enumLog4net.INFO);
            }
            catch (Exception ex)
            {
                jsonHelper.Msg = "设置失败，错误：" + ex.Message;
                //base.WriteLog(enumOperator.Allocation, "设置用户角色：", ex);
            }
            return base.Json(jsonHelper);
        }

    }
}