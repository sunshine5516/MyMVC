using Common;
using Common.Enums;
using Domain;
using Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using WebPage.Controllers;

namespace WebPage.Areas.SysManage.Controllers
{
    public class CodeController : BaseController
    {
        #region
        ICodeManage CodeManage { get; set; }
        #endregion
        // GET: SysManage/Code
        public ActionResult Index()
        {
            //try
            //{
            //    string keyWord = base.keywords == null ? "" : base.keywords;
            //    //var query = this.CodeManage.LoadAll(null);


            //    IOrderedQueryable<SYS_CODE> query =
            //    from p in this.CodeManage.LoadAll(null)
            //    orderby p.UPDATEDATE descending
            //    orderby p.SHOWORDER
            //    orderby p.CODETYPE
            //    select p;
            //    var result = query.Where(p => p.NAMETEXT.Contains(keyWord)).ToList();
            //    return View(result);
            //}
            //catch (Exception e)
            //{

            //}
            //return View();
            ActionResult result;
            try
            {
                string text = base.Request.QueryString["codetype"];
                object model = this.BindList(text);
                //if (CodeController.< Index > o__SiteContainer0.<> p__Site1 == null)
                //{
                //    CodeController.< Index > o__SiteContainer0.<> p__Site1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Search", typeof(CodeController), new CSharpArgumentInfo[]
                //    {
                //        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
                //        CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
                //    }));
                //}
                //CodeController.< Index > o__SiteContainer0.<> p__Site1.Target(CodeController.< Index > o__SiteContainer0.<> p__Site1, base.ViewBag, base.keywords);
                base.ViewData["codeType"] = ClsDic.DicCodeType;
                base.ViewData["codet"] = text;
                result = base.View(model);
            }
            catch (Exception ex)
            {
                //base.WriteLog(enumOperator.Select, "数据字典管理加载主页：", ex);
                throw ex.InnerException;
            }
            return result;
        }
        private object BindList(string codetype)
        {
            Expression<Func<SYS_CODE, bool>> expression = PredicateBuilder.True<SYS_CODE>();
            if (!string.IsNullOrEmpty(base.keywords))
            {
                expression = expression.And((SYS_CODE p) => p.NAMETEXT.Contains(this.keywords));
            }
            if (!string.IsNullOrEmpty(codetype))
            {
                expression = expression.And((SYS_CODE p) => p.CODETYPE == codetype);
            }
            IOrderedQueryable<SYS_CODE> query =
                from p in this.CodeManage.LoadAll(expression)
                orderby p.UPDATEDATE descending
                orderby p.SHOWORDER
                orderby p.CODETYPE
                select p;
            return this.CodeManage.Query(query, base.page, base.pagesize);
        }
        /// <summary>
        /// 详情
        /// </summary>
        /// <returns></returns>
        [UserAuthorize(ModuleAlias = "Code", OperaAction = "Detail")]
        public ActionResult Detail(int? id)
        {
            try
            {
                SYS_CODE entity = this.CodeManage.Get((SYS_CODE p) => (int?)p.ID == id) ?? new SYS_CODE();
                //if(id!)
                //var entity = CodeManage.Get(p=>p.ID==id);
                base.ViewData["codeType"] = ClsDic.DicCodeType;
                return View(entity);
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        // WebPage.Areas.SysManage.Controllers.CodeController
        [UserAuthorize(ModuleAlias = "Code", OperaAction = "Remove")]
        public ActionResult Delete(string idList)
        {
            JsonHelper jsonHelper = new JsonHelper
            {
                Msg = "删除编码完毕",
                Status = "n"
            };
            try
            {
                if (!string.IsNullOrEmpty(idList))
                {
                    List<int> idList1 = (
                        from p in idList.Trim(new char[]
                        {
                    ','
                        }).Split(new string[]
                        {
                    ","
                        }, StringSplitOptions.RemoveEmptyEntries)
                        select int.Parse(p)).ToList<int>();
                    //Exception e;
                    this.CodeManage.Delete((SYS_CODE p) => idList1.Any((int e) => e == p.ID));
                    jsonHelper.Status = "y";
                }
                else
                {
                    jsonHelper.Msg = "未找到要删除的记录";
                }
                base.WriteLog(enumOperator.Remove, "删除编码，结果：" + jsonHelper.Msg, enumLog4net.WARN);
            }
            catch (Exception e)
            {
               // Exception e;
                base.WriteLog(enumOperator.Remove, "删除编码出现异常：", e);
            }
            return base.Json(jsonHelper);
        }
        // WebPage.Areas.SysManage.Controllers.CodeController
        public ActionResult GetParentCode()
        {
            JsonHelper jsonHelper = new JsonHelper
            {
                Status = "n",
                Data = ""
            };
            string codetype = base.Request.Form["type"];
            if (!string.IsNullOrEmpty(codetype))
            {
                List<SYS_CODE> list = this.CodeManage.LoadListAll((SYS_CODE p) => p.CODETYPE == codetype);
                if (list != null && list.Count > 0)
                {
                    jsonHelper.Data = list;
                    jsonHelper.Status = "y";
                }
            }
            return base.Json(jsonHelper);
        }
        // WebPage.Areas.SysManage.Controllers.CodeController
        [UserAuthorize(ModuleAlias = "Code", OperaAction = "Add,Edit")]
        public ActionResult Save(SYS_CODE entity)
        {
            bool flag = false;
            JsonHelper jsonHelper = new JsonHelper
            {
                Msg = "保存编码成功",
                Status = "n"
            };
            try
            {
                if (entity != null)
                {
                    if (entity.ID <= 0)
                    {
                        entity.CREATEDATE = new DateTime?(DateTime.Now);
                        entity.CREATEUSER = base.CurrentUser.Name;
                        entity.UPDATEDATE = new DateTime?(DateTime.Now);
                        entity.UPDATEUSER = base.CurrentUser.Name;
                    }
                    else
                    {
                        entity.UPDATEDATE = new DateTime?(DateTime.Now);
                        entity.UPDATEUSER = base.CurrentUser.Name;
                        flag = true;
                    }
                    if (!this.CodeManage.IsExist((SYS_CODE p) => p.NAMETEXT == entity.NAMETEXT && p.CODETYPE == entity.CODETYPE && p.ID != entity.ID))
                    {
                        if (this.CodeManage.SaveOrUpdate(entity, flag))
                        {
                            jsonHelper.Status = "y";
                        }
                        else
                        {
                            jsonHelper.Msg = "保存失败";
                        }
                    }
                    else
                    {
                        jsonHelper.Msg = "编码" + entity.NAMETEXT + "已存在，不能重复添加";
                    }
                }
                else
                {
                    jsonHelper.Msg = "未找到需要保存的编码记录";
                }
                if (flag)
                {
                    base.WriteLog(enumOperator.Edit, "修改编码，结果：" + jsonHelper.Msg, enumLog4net.INFO);
                }
                else
                {
                    base.WriteLog(enumOperator.Add, "添加编码，结果：" + jsonHelper.Msg, enumLog4net.INFO);
                }
            }
            catch (Exception e)
            {
                jsonHelper.Msg = "保存编码发生内部错误！";
                base.WriteLog(enumOperator.None, "保存编码：", e);
            }
            return base.Json(jsonHelper);
        }

    }

}