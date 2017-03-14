﻿using Common;
using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebPage.Controllers;

namespace WebPage.Areas.SysManage.Controllers
{
    public class PermissionController : BaseController
    {
        #region 声明容器
        IRoleManage RoleManage { get; set; }
        /// <summary>
        /// 模块管理
        /// </summary>
        IModuleManage ModuleManage { get; set; }
        /// <summary>
        /// 权限管理
        /// </summary>
        IPermissionManage PermissionManage { get; set; }
        /// <summary>
        /// 系统管理
        /// </summary>
        ISystemManage SystemManage { get; set; }
        /// <summary>
        /// 预置编码管理
        /// </summary>
        ICodeManage CodeManage { get; set; }
        /// <summary>
        /// 角色权限管理
        /// </summary>
        IRolePermissionManage RolePermissionManage { get; set; }
        /// <summary>
        /// 用户权限管理
        /// </summary>
        IUserPermissionManage UserPermissionManage { get; set; }
        //IExtLog log = log4net.Ext.ExtLogManager.GetLogger("dblog");
        bool isEdit = false;

        #endregion
        /// <summary>
        /// 权限管理
        /// </summary>
        /// <returns></returns>
        // GET: SysManage/Permission
        [UserAuthorizeAttribute(ModuleAlias = "Permission", OperaAction = "View")]
        public ActionResult Index()
        {
            try
            {
                var moduleId = Request.QueryString["moduleId"] ?? (Request["moduleId"] ?? "");
                if (!string.IsNullOrEmpty(moduleId))
                {
                    int module_Id = int.Parse(moduleId);
                    var module = this.ModuleManage.Get(p => p.ID == module_Id);
                    var query = this.PermissionManage.LoadAll(p => p.MODULEID == module.ID);
                    //关键字查询
                    if (!string.IsNullOrEmpty(keywords))
                    {
                        query = query.Where(p => p.NAME.Contains(keywords));
                    }
                    //输出结果
                    var result = query.OrderBy(p => p.SHOWORDER).ToList();

                    ViewBag.Search = base.keywords;

                    ViewBag.Module = module;

                    return View(result);
                }
                    return View();
            }
            catch (Exception e)
            {
               // WriteLog(Common.Enums.enumOperator.Select, "对模块权限按钮的管理加载主页：", e);
                throw e.InnerException;
            }
        }
        /// <summary>
        /// 权限管理，默认界面
        /// </summary>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "Permission", OperaAction = "View")]
        public ActionResult Home()
        {
            try
            {
                ViewData["Systemlist"] = this.SystemManage.LoadSystemInfo(CurrentUser.System_Id);
            }
            catch
            {

            }
            return View();
        }
        /// <summary>
        /// 获取树形菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTree()
        {
            var json = new JsonHelper() { Msg = "Success", Status = "y" };
            var sysId = Request.Form["sysId"];
            if (string.IsNullOrEmpty(sysId))
            {
                json.Status = "n";
                json.Msg = "获取模块失败！";
                return Json(json);
            }
            try
            {
                ///获取系统下的模块
                var query = this.ModuleManage.LoadAll(p => p.FK_BELONGSYSTEM == sysId).OrderBy(p => p.SHOWORDER).ToList();
                var result = query.Select(
                    m=>new
                    {
                        id=m.ID,
                        parent = m.PARENTID > 0 ? m.PARENTID.ToString() : "#",
                        text = m.NAME,
                        icon = m.LEVELS == 0 ? "fa fa-circle text-danger" : "fa fa-circle text-navy"
                    }).ToList();
                json.Data = result;
            }
            catch (Exception e)
            {
                json.Status = "n";
                json.Msg = "服务器忙，请稍后再试！";
            }
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 加载权限详情
        /// </summary>
        /// <returns></returns>
        [UserAuthorizeAttribute(ModuleAlias = "Permission", OperaAction = "Detail")]
        public ActionResult Detail(int? id)
        {
            try
            {
                var _entity = this.PermissionManage.Get(p => p.ID == id) ?? new Domain.SYS_PERMISSION();
                var moduleId = Request.QueryString["moduleId"];
                if (!string.IsNullOrEmpty(moduleId))
                {
                    int newmoduleid = int.Parse(moduleId);
                    _entity.MODULEID = newmoduleid;
                }
                ///
                ViewData["PresetValue"] = this.CodeManage.GetCode("ROLEVALUE");
                return View(_entity);
            }
            catch(Exception e)
            {
                throw e.InnerException;
            }

        }
        /// <summary>
        /// 保存权限
        /// </summary>
        [UserAuthorizeAttribute(ModuleAlias = "Permission", OperaAction = "Add,Edit")]
        public ActionResult Save(SYS_PERMISSION entity)
        {
            bool isEdit = false;
            JsonHelper json = new JsonHelper() { Msg = "保存权限成功", Status = "n" };
            try
            {
                if (entity != null)
                {
                    if (System.Text.Encoding.GetEncoding("gb2312").GetBytes(entity.NAME.Trim()).Length > 50)
                    {
                        json.Msg = "权限的名称长度不能超过50个字符";
                        return Json(json);
                    }
                    entity.ICON = Request.Form["ICON"];
                    var nextpervalue = Request.Form["NEXTPERVALUE"];
                    if (!string.IsNullOrEmpty(nextpervalue))
                    {
                        if (!Regex.IsMatch(nextpervalue, @"^[A-Za-z0-9]{1,20}$"))
                        {
                            json.Msg = "权限值只能以英文数字组成，长度不能超过20个字符";
                            return Json(json);
                        }
                        entity.PERVALUE = nextpervalue;
                    }
                    //添加
                    if (entity.ID <= 0)
                    {
                        entity.CREATEDATE = DateTime.Now;
                        entity.UPDATEDATE = DateTime.Now;
                        entity.UPDATEUSER = this.CurrentUser.Name;
                        entity.CREATEUSER = this.CurrentUser.Name;
                    }
                    else //编辑
                    {
                        entity.UPDATEUSER = this.CurrentUser.Name;
                        entity.UPDATEDATE = DateTime.Now;
                        isEdit = true;
                    }
                    //同一模块下权限不能重复
                    if (!this.PermissionManage.IsExist(p => p.NAME.Equals(entity.NAME) && p.ID != entity.ID && p.MODULEID == entity.MODULEID))
                    {
                        if (PermissionManage.SaveOrUpdate(entity, isEdit))
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
                        json.Msg = "权限" + entity.NAME + "同一模块下已存在，不能重复添加";
                    }
                }
                else
                {
                    json.Msg = "未找到要保存的权限记录";
                }
                if (isEdit)
                {
                    //WriteLog(Common.Enums.enumOperator.Edit, "修改权限，结果：" + json.Msg, Common.Enums.enumLog4net.INFO);
                }
                else
                {
                    //WriteLog(Common.Enums.enumOperator.Add, "添加权限，结果：" + json.Msg, Common.Enums.enumLog4net.INFO);
                }
            }
            catch (Exception e)
            {
                json.Msg = "保存权限发生内部错误！";
                //WriteLog(Common.Enums.enumOperator.None, "对模块权限按钮的管理保存权限：", e);
            }
            return Json(json);
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        [UserAuthorizeAttribute(ModuleAlias = "Permission", OperaAction = "Remove")]
        public ActionResult Delete(string idList)
        {
            var json = new JsonHelper() { Msg = "删除权限成功", Status = "n" };
            try
            {
                if (!string.IsNullOrEmpty(idList))
                {
                    var idList1 = idList.Trim(',').Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => int.Parse(p)).ToList();
                    //判断查找角色是否调用
                    if (!this.RolePermissionManage.IsExist(p => idList1.Any(e => e == p.PERMISSIONID)))
                    {
                        //判断查找用户是否调用
                        if (!this.UserPermissionManage.IsExist(p => idList1.Any(e => e == p.FK_PERMISSIONID)))
                        {
                            this.PermissionManage.Delete(p => idList1.Any(e => e == p.ID));
                            json.Status = "y";
                        }
                        else
                        {
                            json.Msg = "有用户正在使用该权限，不能删除!";
                        }
                    }
                    else
                    {
                        json.Msg = "有角色正在使用该权限，不能删除!";
                    }
                }
                else
                {
                    json.Msg = "未找到要删除的权限记录";
                }
                //WriteLog(Common.Enums.enumOperator.Remove, "删除权限，结果：" + json.Msg, Common.Enums.enumLog4net.WARN);
            }
            catch (Exception e)
            {
                json.Msg = e.InnerException.Message;
                //WriteLog(Common.Enums.enumOperator.Remove, "对模块权限按钮的管理删除权限：", e);
            }
            return Json(json);
        }
        /// <summary>
        /// 初始化权限，默认增删改查详情
        /// <param name="id">模块ID</param>
        /// </summary>
        [UserAuthorizeAttribute(ModuleAlias = "Permission", OperaAction = "Reset")]
        public ActionResult Reset(string id)
        {
            var json = new JsonHelper() { Status = "n", Msg = "初始化完毕" };
            try
            {
                //判断模块ID 是否符合规范
                if (string.IsNullOrEmpty(id) || !Regex.IsMatch(id, @"^\d+$"))
                {
                    json.Msg = "模块参数错误";
                    //WriteLog(Common.Enums.enumOperator.Allocation, "初始化权限，结果：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                    return Json(json);
                }
                //将 ID 转为 Int
                int newid = int.Parse(id);

                //判断权限里 模块是否有了权限
                if (this.PermissionManage.IsExist(p => p.MODULEID == newid))
                {
                    json.Msg = "该模块已存在权限，无法初始化";
                    //WriteLog(Common.Enums.enumOperator.Allocation, "初始化权限，结果：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                    return Json(json);
                }
                //添加默认权限 
                var per = new string[] { "查看,View", "列表,List", "详情,Detail", "添加,Add", "修改,Edit", "删除,Remove" };
                var list = new List<Domain.SYS_PERMISSION>();
                foreach (var item in per)
                {
                    list.Add(new Domain.SYS_PERMISSION()
                    {
                        CREATEDATE = DateTime.Now,
                        CREATEUSER = this.CurrentUser.Name,
                        NAME = item.Split(',')[0],
                        PERVALUE = item.Split(',')[1],
                        UPDATEDATE = DateTime.Now,
                        UPDATEUSER = this.CurrentUser.Name,
                        MODULEID = newid,
                        SHOWORDER = 0
                    });
                }
                //批量添加
                if (this.PermissionManage.SaveList(list) > 0)
                {
                    json.Status = "y";
                }
                else
                {
                    json.Msg = "初始化失败";
                }
                //WriteLog(Common.Enums.enumOperator.Allocation, "初始化权限，结果：" + json.Msg, Common.Enums.enumLog4net.INFO);
            }
            catch (Exception e)
            {
                json.Msg = e.InnerException.Message;
                //WriteLog(Common.Enums.enumOperator.Allocation, "对模块权限按钮的管理初始化权限：", e);
            }
            return Json(json);
        }


        /// <summary>
        /// 角色、用户分配权限
        /// </summary>
        [UserAuthorizeAttribute(ModuleAlias = "Role", OperaAction = "Allocation")]
        public ActionResult PerAllocation()
        {
            //系统
            string systemId = "所有可操作系统";
            //用户或角色ID
            string id = Request["id"];

            //权限类型，user/role
            string tp = Request["tp"];

            //搜索关键字
            ViewBag.Search = base.keywords;

            if (string.IsNullOrEmpty(tp))
            {
                return Content("<script>alert('未接收到需要分配权限的类型')</script>");
            }
            if (string.IsNullOrEmpty(id))
            {
                return Content("<script>alert('未接收到需要分配权限的对象')</script>");
            }

            int newid = int.Parse(id);

            //模块
            var moduleList = new List<Domain.SYS_MODULE>();

            if (tp == "role")
            {
                var Role = RoleManage.Get(p => p.ID == newid);

                systemId = SystemManage.Get(p => p.ID == Role.FK_BELONGSYSTEM.ToString()).NAME;

                //获取角色所属系统模块
                moduleList = this.ModuleManage.RecursiveModule(this.ModuleManage.LoadAll(p => p.FK_BELONGSYSTEM == Role.FK_BELONGSYSTEM).ToList());
            }
            else if (tp == "user")
            {
                //获取管理员可操作系统模块
                moduleList = this.ModuleManage.RecursiveModule(this.ModuleManage.LoadAll(p => CurrentUser.System_Id.Any(e => e == p.FK_BELONGSYSTEM)).ToList());
            }

            //搜索关键字
            if (!string.IsNullOrEmpty(keywords))
            {
                moduleList = moduleList.Where(p => p.NAME.Contains(keywords.ToLower())).ToList();
            }

            //ViewData["ModuleList"] = JsonConverter.JsonClass(moduleList.Select(p => new { p.ID, p.ICON, p.PARENTID, p.LEVELS }));
            //ViewData["ModuleList"] = JsonConverter.JsonClass(moduleList.Select(p => new { p.ID, MODULENAME = GetModuleName(p.NAME, p.LEVELS), p.ICON, p.PARENTID, p.LEVELS }));
            ViewData["ModuleList"] = JsonConverter.JsonClass(moduleList.Select(p => new { p.ID, MODULENAME = p.NAME, p.ICON, p.PARENTID, p.LEVELS }));
            //获取权限
            var moduleId = moduleList.Select(p => p.ID).ToList();

            ViewData["PermissionList"] = this.PermissionManage.LoadAll(p => moduleId.Any(e => e == p.MODULEID)).ToList();

            //根据类型获取用户/角色已选中的权限
            var selectper = new List<string>();
            if (tp == "user")
            {
                selectper =
                    this.UserPermissionManage.LoadAll(p => p.FK_USERID == newid)
                        .Select(p => p.FK_PERMISSIONID)
                        .Cast<string>()
                        .ToList();
            }
            else if (tp == "role")
            {
                selectper =
                    this.RolePermissionManage.LoadAll(p => p.ROLEID == newid)
                        .Select(p => p.PERMISSIONID)
                        .Cast<string>()
                        .ToList();
            }

            ViewData["selectper"] = selectper;

            ViewData["PermissionType"] = tp;

            ViewData["objId"] = id;

            ViewData["systemId"] = systemId;

            return View();
        }
        /// <summary>
        /// 设置角色、用户权限
        /// </summary>
        public ActionResult SaveAllocation()
        {
            string temp = "";
            var json = new JsonHelper() { Msg = "分配权限完毕", Status = "n" };
            //类型
            string tp = Request.Form["tp"];
            //用户角色ID
            string id = Request.Form["id"];
            //权限ID集合
            string perid = Request.Form["perid"];

            if (string.IsNullOrEmpty(id))
            {
                json.Msg = "未要分配权限的对象";
                //WriteLog(Common.Enums.enumOperator.Allocation, "设置角色权限，结果：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                return Json(json);
            }

            if (string.IsNullOrEmpty(tp))
            {
                json.Msg = "未要分配权限的类型";
                WriteLog(Common.Enums.enumOperator.Allocation, "设置角色权限，结果：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                return Json(json);
            }

            perid = perid.Trim(',');

            try
            {
                if (tp == "user")
                {
                    if (!this.UserPermissionManage.SetUserPermission(int.Parse(id), perid))
                    {
                        json.Msg = "保存失败";
                        WriteLog(Common.Enums.enumOperator.Allocation, "设置用户权限，结果：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                        return Json(json);
                    }
                }
                else if (tp == "role")
                {
                    if (!this.RolePermissionManage.SetRolePermission(int.Parse(id), perid, "fddeab19-3588-4fe1-83b6-c15d4abb942d"))
                    {
                        json.Msg = "保存失败"; WriteLog(Common.Enums.enumOperator.Allocation, "设置角色权限，结果：" + json.Msg, Common.Enums.enumLog4net.ERROR);
                        return Json(json);
                    }
                }

                json.Status = "y";

                //WriteLog(Common.Enums.enumOperator.Allocation, "设置角色权限，结果：" + json.Msg, Common.Enums.enumLog4net.INFO);
            }
            catch (Exception e)
            {
                json.Msg = "设置角色权限发生内部错误！";
                //WriteLog(Common.Enums.enumOperator.Allocation, "设置角色权限：", e);
            }
            return Json(json);
        }

        private object GetModuleName(string name, int levels)
        {
            throw new NotImplementedException();
        }
    }
}